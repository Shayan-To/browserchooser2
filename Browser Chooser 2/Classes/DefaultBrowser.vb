Imports Microsoft.Win32
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Security.Permissions
Imports System.Windows.Forms
Imports Browser_Chooser_2.WinAPIs
Imports Browser_Chooser_2.WinAPIExtras
Imports System.Security.AccessControl

'windows 10 control panel solution from https://social.msdn.microsoft.com/Forums/windowsdesktop/en-US/7aa1dedd-7016-4093-a5d2-d2e3658f6414/how-to-start-windows-store-control-panel-from-desktop-app?forum=windowsgeneraldevelopmentissues

Public Class DefaultBrowser
    Private Const mBC2KeyName As String = "SOFTWARE\Clients\StartMenuInternet\Browser Chooser 2.exe"
    Private Const mCanonical As String = "Browser Chooser 2.exe"
    Private Const mFileAssociations As String = "BrowserChooser2HTML"
    Private Const mURLAssociations As String = "BrowserChooser2URL"
    Private Const mAppName As String = "Browser Chooser 2"

    Public Enum Scope
        sGlobal
        sUser
    End Enum

    '''
    ''' Notes: As of Alpha 3, the protocols and file types are dynamic and set by the user. this call will happen more often
    '''  Also, Alpha 3 is the first to not fully support windows XP, this class is impcacted by that change. It will be a best effot.
    '''     Windows 7 User scope uses the XP process, so I guess XP will live a little longer.
    '''
    ''' As of Windows 8, we need to deregister and reregister to get the dialog to pop-up. i think.
    ''' Update Nov 2014: It is more simple than that. We can either show the associations dialog in windows or the open with box. 
    '''
    ''' You can try to figure out what i happening for the Windows 8+ hash, but good luck. Here is what I know so far:
    '''     Uses bcrypt and rsa and the machine guid

    Private Shared Sub CreateApplicationRegistration(ByVal aROOT As RegistryKey)
        Logger.AddToLog("DefaultBrowser.CreateApplicationRegistration", "Start", aROOT.Name)
        'oftware\Microsoft\Windows\CurrentVersion\App Paths
        Dim lKey As RegistryKey = aROOT.CreateSubKey("Software\Microsoft\Windows\CurrentVersion\App Paths", RegistryKeyPermissionCheck.ReadWriteSubTree)
        Dim lSubKey As RegistryKey = lKey.CreateSubKey(mCanonical, RegistryKeyPermissionCheck.ReadWriteSubTree)
        lSubKey.SetValue("", String.Format("{0}\{1}", My.Application.Info.DirectoryPath, mCanonical), RegistryValueKind.String)
        lSubKey.SetValue("Path", My.Application.Info.DirectoryPath, RegistryValueKind.String)
        lSubKey.SetValue("UseUrl", 1, RegistryValueKind.DWord)
        Logger.AddToLog("DefaultBrowser.CreateApplicationRegistration", "End", aROOT.Name)
    End Sub

    Private Shared Sub CreateAssociations(ByVal aROOT As RegistryKey)
        Logger.AddToLog("DefaultBrowser.CreateAssociations", "Start", aROOT.Name)
        'finaly, end with file accociations
        Dim lData As Byte() = New Byte() {2}
        Dim lKey = aROOT.CreateSubKey(mFileAssociations)
        lKey.SetValue("", mCanonical, RegistryValueKind.String)
        lKey.SetValue("FriendlyTypeName", mAppName, RegistryValueKind.String)
        lKey.SetValue("EditFlags", lData, RegistryValueKind.Binary)
        lKey.CreateSubKey("DefaultIcon").SetValue("",
            """" & Path.Combine(Application.StartupPath, mCanonical) & """,0", RegistryValueKind.String)
        lKey.CreateSubKey("shell\open\command").SetValue("", """" & Application.ExecutablePath & """ ""%1""", RegistryValueKind.String)

        'file types
        For Each lFileType As FileType In gSettings.FileTypes
            aROOT.CreateSubKey(String.Format(".{0}\OpenWithProgIds", lFileType.Extention)).SetValue(mFileAssociations, RegistryValueKind.String)
        Next

        'url accociations
        lKey = aROOT.CreateSubKey(mURLAssociations)
        lKey.SetValue("", mCanonical, RegistryValueKind.String)
        lKey.SetValue("FriendlyTypeName", mAppName, RegistryValueKind.String)
        lKey.SetValue("EditFlags", lData, RegistryValueKind.Binary)
        lKey.SetValue("URL Protocol", mCanonical, RegistryValueKind.String)
        lKey.CreateSubKey("DefaultIcon").SetValue("",
            """" & Path.Combine(Application.StartupPath, mCanonical) & """,0", RegistryValueKind.String)
        lKey.CreateSubKey("shell\open\command").SetValue("", """" & Application.ExecutablePath & """ ""%1""", RegistryValueKind.String)
        Logger.AddToLog("DefaultBrowser.CreateAssociations", "End", aROOT.Name)
    End Sub

    Private Shared Sub CreateCapabilities(ByVal aROOT As RegistryKey)
        Logger.AddToLog("DefaultBrowser.CreateCapabilities", "Start", aROOT.Name)
        Dim lKey = aROOT.CreateSubKey(mBC2KeyName, RegistryKeyPermissionCheck.ReadWriteSubTree)

        If IsNothing(lKey) = False Then
            'write out our values
            lKey.CreateSubKey("Capabilities").SetValue("ApplicationName", mAppName, RegistryValueKind.String)
            lKey.CreateSubKey("Capabilities").SetValue("ApplicationIcon", Application.ExecutablePath & ",0", RegistryValueKind.String)
            lKey.CreateSubKey("Capabilities").SetValue("ApplicationDescription", "Small application that let's you choose what browser to open with a provided url. https://browserchooser2.com", RegistryValueKind.String)

            'file types
            For Each lFileType As FileType In gSettings.FileTypes
                lKey.CreateSubKey("Capabilities\FileAssociations").SetValue("." & lFileType.Extention, mFileAssociations, RegistryValueKind.String)
            Next

            lKey.CreateSubKey("Capabilities\StartMenu").SetValue("StartMenuInternet", "Browser Chooser 2.exe", RegistryValueKind.String)

            'protocols
            For Each lProtocol As Protocol In gSettings.Protocols
                lKey.CreateSubKey("Capabilities\URLAssociations").SetValue(lProtocol.Header, mURLAssociations, RegistryValueKind.String)
            Next

            'end with registered applications
            aROOT.CreateSubKey("SOFTWARE\RegisteredApplications").SetValue(mAppName, mBC2KeyName & "\Capabilities", RegistryValueKind.String)
        End If
        Logger.AddToLog("DefaultBrowser.CreateCapabilities", "End", aROOT.Name)
    End Sub

    Public Shared Sub CreateSPAD(ByVal aROOT As RegistryKey)
        Logger.AddToLog("DefaultBrowser.CreateSPAD", "Start", aROOT.Name)
        Dim lSubKey As RegistryKey

        'Register the canonical name and Register the Display Name, icon
        Dim lKey As RegistryKey = aROOT.CreateSubKey("SOFTWARE\Clients\StartMenuInternet\" + mCanonical)
        lKey.SetValue("", mAppName, RegistryValueKind.String)
        lKey.SetValue("LocalizedString", mAppName, RegistryValueKind.String)

        lKey.CreateSubKey("DefaultIcon").SetValue("", """" & Path.Combine(Application.StartupPath, mCanonical) & """,0", RegistryValueKind.String)

        'Registering an Open Verb
        lKey.CreateSubKey("shell\open\command").SetValue("",
            """" & Path.Combine(Application.StartupPath, mCanonical) & """", RegistryValueKind.String)

        'Registering Installation Information
        lSubKey = lKey.CreateSubKey("InstallInfo")
        lSubKey.SetValue("ReinstallCommand",
            """" & Path.Combine(Application.StartupPath, mCanonical) & """ --reinstall", RegistryValueKind.String) 'aka set default
        lSubKey.SetValue("HideIconsCommand",
            """" & Path.Combine(Application.StartupPath, "Browser Chooser 2.exe") & """ --hideicons", RegistryValueKind.String) 'aka unset default, hide from system menu
        lSubKey.SetValue("ShowIconsCommand",
            """" & Path.Combine(Application.StartupPath, "Browser Chooser 2.exe") & """ --showicons", RegistryValueKind.String) 'aka not default, show in system menus
        lSubKey.SetValue("IconsVisible", 1, RegistryValueKind.DWord) 'current state - icons shown
        Logger.AddToLog("DefaultBrowser.CreateSPAD", "End", aROOT.Name)
    End Sub

    Public Shared Sub MakeAvailable(ByVal aScope As DefaultBrowser.Scope) 'needs admin - writes to HKLM
        Logger.AddToLog("DefaultBrowser.MakeAvailable", "Start", aScope)
        'note: Part 1: SPAD this is implemented from documentation found at http://msdn.microsoft.com/en-us/library/windows/desktop/cc144109%28v=vs.85%29.aspx
        If aScope = Scope.sGlobal Then
            CreateSPAD(Registry.LocalMachine)
            CreateApplicationRegistration(Registry.LocalMachine)
        End If

        CreateSPAD(Registry.CurrentUser)
        CreateApplicationRegistration(Registry.CurrentUser)

        'PArt 2: now onto default programs. from http://msdn.microsoft.com/en-us/library/windows/desktop/cc144154%28v=vs.85%29.aspx
        If aScope = Scope.sGlobal Then
            CreateCapabilities(Registry.LocalMachine)
            CreateAssociations(Registry.ClassesRoot) 'should work witout admin, need to test - it does
        End If

        CreateCapabilities(Registry.CurrentUser)
        CreateAssociations(Registry.CurrentUser.OpenSubKey("SOFTWARE\Classes", True))

        'broadcast change - this will trigger a notification in Win 8+
        SHChangeNotify(SHChangeNotifyEventID.SHCNE_ASSOCCHANGED, SHChangeNotifyFlags.SHCNF_DWORD Or SHChangeNotifyFlags.SHCNF_FLUSH,
                       IntPtr.Zero, IntPtr.Zero)
        Logger.AddToLog("DefaultBrowser.MakeAvailable", "End", aScope)
    End Sub

    Public Shared Function UpdateUserScope() As DialogResult
        Logger.AddToLog("DefaultBrowser.UpdateUserScope", "Start")
        Dim aROOT As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Classes\", True)

        'no support for XP here. XP code is deprecated and will be removed at some point
        'we need to update our classes root
        Dim lNeedsUpdate As Boolean = False
        Dim lKey = aROOT.OpenSubKey(mFileAssociations, True)
        Dim lKey2 = aROOT.OpenSubKey(mURLAssociations, True)
        Dim lSubKey = lKey.OpenSubKey("shell\open\command", True)
        Dim lSubKey2 = lKey2.OpenSubKey("shell\open\command", True)
        Dim lAnswer As DialogResult = DialogResult.No
        If lSubKey.GetValue("").ToString() <> """" & Application.ExecutablePath & """ ""%1""" Or
            lSubKey2.GetValue("").ToString() <> """" & Application.ExecutablePath & """ ""%1""" Then

            lAnswer = MessageBox.Show("BROSWER CHOOSER 2: The registry settings need updating. Do you want to update registry settings?", "BROSWER CHOOSER 2: Update Registry", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If lAnswer = DialogResult.Yes Then
                lKey.CreateSubKey("shell\open\command").SetValue("", """" & Application.ExecutablePath & """ ""%1""", RegistryValueKind.String)
                lKey2.CreateSubKey("shell\open\command").SetValue("", """" & Application.ExecutablePath & """ ""%1""", RegistryValueKind.String)
            End If
        End If

        Logger.AddToLog("DefaultBrowser.UpdateUserScope", "End")
        Return lAnswer 'default is no, no update required. 
    End Function

    Private Shared Sub DoUserScope(ByVal aMaster As RegistryKey) 'includes windows XP
        Logger.AddToLog("DefaultBrowser.DoUserScope", "Start", aMaster.Name)
        'If aScope = Settings.Scope.sGlobal Then
        Registry.CurrentUser.CreateSubKey("SOFTWARE\Clients\StartMenuInternet\").DeleteValue("", False)
        'End If

        'Windows XP section - raw copy, com call above wont work
        For Each lKey As String In aMaster.CreateSubKey(mBC2KeyName, RegistryKeyPermissionCheck.ReadWriteSubTree) _
            .CreateSubKey("Capabilities\FileAssociations").GetValueNames

            'put our canoninical name in the default of those in classes root
            If GeneralUtilities.IsRunningXP = True Then
                Registry.CurrentUser.CreateSubKey("SOFTWARE\Classes\" & lKey, RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("", mFileAssociations, RegistryValueKind.String)
            Else
                'windows 7. if user has manully set an association there may be a deny mark on the this key, try to override
                Dim lRegSec As New RegistrySecurity
                Dim lRegKey As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\" & lKey & "\\UserChoice", RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.ChangePermissions)
                If IsNothing(lRegKey) = False Then
                    Dim lRegUser As String = Environment.UserDomainName & "\" & Environment.UserName
                    Dim lRule As New RegistryAccessRule(lRegUser, RegistryRights.FullControl, AccessControlType.Allow)

                    'get access control and modify it
                    lRegSec = lRegKey.GetAccessControl()
                    lRegSec.ResetAccessRule(lRule) 'this will leave a duplicate allow rule
                    lRegSec.RemoveAccessRule(lRule) 'this will delete it, BOTH are needed to work
                    lRegKey.SetAccessControl(lRegSec)
                    lRegKey.Close()
                End If

                'reopen it with set value permissions
                lRegKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\" & lKey & "\\UserChoice", RegistryKeyPermissionCheck.ReadWriteSubTree)
                lRegKey.SetValue("Progid", mURLAssociations)
            End If
        Next

        'repeat for URLs
        For Each lKey As String In aMaster.CreateSubKey(mBC2KeyName, RegistryKeyPermissionCheck.ReadWriteSubTree) _
            .CreateSubKey("Capabilities\URLAssociations").GetValueNames

            If GeneralUtilities.IsRunningXP = True Then
                'copy our stuff into here - kinds weird XP...
                Registry.CurrentUser.CreateSubKey("SOFTWARE\Classes\" & lKey & "\DefaultIcon", RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("",
                    """" & Path.Combine(Application.StartupPath, mCanonical) & """,0", RegistryValueKind.String)

                'now copy the open command
                Registry.CurrentUser.CreateSubKey("SOFTWARE\Classes\" & lKey & "\Shell\open\command", RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("",
                    """" & Path.Combine(Application.StartupPath, mCanonical) & """ ""%1""", RegistryValueKind.String)
            Else
                Registry.CurrentUser.CreateSubKey("SOFTWARE\Microsoft\Windows\Shell\Associations\UrlAssociations\" & lKey & "\UserChoice").SetValue("Progid", mURLAssociations)
            End If
        Next 'and XP ends abrutly like this...

        'one extra for Win Vista and 7 
        If GeneralUtilities.IsRunningXP = False Then
            '                                                                          intentional front slash ---v do not change
            Registry.CurrentUser.CreateSubKey("SOFTWARE\Microsoft\Windows\Shell\Associations\MIMEAssociations\text/html\UserChoice").SetValue("Progid", mFileAssociations) 'not sure if this will work
        End If

        'create accosiations in user software classes
        CreateAssociations(Registry.CurrentUser.OpenSubKey("SOFTWARE\Classes\", True))

        Logger.AddToLog("DefaultBrowser.DoUserScope", "End", aMaster.Name)
    End Sub

    Public Shared Sub MakeDefault(ByVal aScope As DefaultBrowser.Scope, Optional ByVal aForce8 As Boolean = False, Optional ByVal aShowMessage As Boolean = True, Optional aDoSingle As String = "", Optional abIsProtocol As Boolean = False)
        Logger.AddToLog("DefaultBrowser.MakeDefault", "Start", aScope, aForce8, aShowMessage, aDoSingle, abIsProtocol)
        If GeneralUtilities.IsRunningPost8 = False And aForce8 = False Then
            'upto windows 7 - default programs / SPAD
            Dim lMaster As RegistryKey

            If aScope = DefaultBrowser.Scope.sGlobal Then
                lMaster = Registry.LocalMachine
            Else
                lMaster = Registry.CurrentUser
            End If

            'apply canonical name to default value - this sets us as default
            lMaster.CreateSubKey("SOFTWARE\Clients\StartMenuInternet").SetValue("", mCanonical, RegistryValueKind.String)

            'windows XP only 
            If GeneralUtilities.IsRunningXP = True Or aScope = Scope.sUser Then
                If aDoSingle <> "" Then
                    Debug.Print("FIXME: Add DoSingle for Windows XP and user mode for Windows 7")
                End If
                DoUserScope(lMaster)

            Else
                If aDoSingle <> "" Then
                    'using a com call here to set the file associations
                    Dim aa = New WinAPIExtras.ApplicationAssociationRegistration
                    Dim iaa = DirectCast(aa, WinAPIExtras.IApplicationAssociationRegistration)

                    If abIsProtocol = True Then
                        iaa.SetAppAsDefault(mAppName, aDoSingle, ASSOCIATIONTYPE.AT_URLPROTOCOL) 'seems to only work  only on hklm
                    Else
                        iaa.SetAppAsDefault(mAppName, aDoSingle, ASSOCIATIONTYPE.AT_FILEEXTENSION) 'seems to only work  only on hklm
                    End If
                Else
                    'using a com call here to set the file associations
                    Dim aa = New WinAPIExtras.ApplicationAssociationRegistration
                    Dim iaa = DirectCast(aa, WinAPIExtras.IApplicationAssociationRegistration)
                    'If aScope = Scope.sUser Then
                    'Else
                    iaa.SetAppAsDefaultAll(mAppName) 'seems to only work  only on hklm
                    'End If
                End If
            End If

            'as per MS docs, broadcast the change
            Dim lString As IntPtr = Marshal.StringToCoTaskMemAuto("SOFTWARE/Clients/StartMenuInternet")
            SendMessageTimeout(HWND_BROADCAST, WM_SETTINGCHANGE, IntPtr.Zero, lString, SendMessageTimeoutFlags.SMTO_NORMAL, 100, IntPtr.Zero)
            'SHChangeNotify(SHChangeNotifyEventID.SHCNE_ASSOCCHANGED, SHChangeNotifyFlags.SHCNF_DWORD Or SHChangeNotifyFlags.SHCNF_FLUSH, Nothing, Nothing)
        ElseIf GeneralUtilities.IsRunningPost10 = True Then
            'scan registry keys for immersivecontrolpanel
            Dim lKey As RegistryKey = Registry.ClassesRoot.OpenSubKey("ActivatableClasses\Package")

            For Each lItem As String In lKey.GetSubKeyNames

                If InStr(lItem, "windows.immersivecontrolpanel") > 0 Then
                    'this is the one we want
                    Debug.Print(lItem)
                    Dim appUserModelId As String = Microsoft.Win32.Registry.GetValue(
                                String.Format("HKEY_CLASSES_ROOT\ActivatableClasses\Package\{0}\Server\microsoft.windows.immersivecontrolpanel",
                                lItem), "AppUserModelId", String.Empty).ToString
                    Debug.Print(appUserModelId)
                    Dim pid As UInteger
                    'Dim result As UInteger = 
                    Dim aa = New ApplicationActivationManager.ApplicationActivationManager
                    Dim iaa = DirectCast(aa, ApplicationActivationManager.IApplicationActivationManager)
                    iaa.ActivateApplication(appUserModelId, "page=SettingsPageAppsDefaults", ApplicationActivationManager.ActivateOptions.None, pid)
                End If
            Next
        Else
            'cause the open with dialog to open, if canceled go to advanced dialog
            If aDoSingle <> "" Then
                'NOTE THAT THIS SECTION IS NOT WINDOWS XP SAFE, you should never come here on windows XP, but still.
                'NOTE 2: Scope is irrelevent on Windows 8 - it is all user.
                Dim lOpenAsInfo As New WinAPIs.OPENASINFO
                lOpenAsInfo.cszFile = aDoSingle.ToUpper() 'testing
                lOpenAsInfo.cszClass = ""
                If abIsProtocol = True Then
                    lOpenAsInfo.OPEN_AS_INFO_FLAGS = WinAPIs.OPEN_AS_INFO_FLAGS.OAIF_URL_PROTOCOL Or WinAPIs.OPEN_AS_INFO_FLAGS.OAIF_FORCE_REGISTRATION Or WinAPIs.OPEN_AS_INFO_FLAGS.OAIF_REGISTER_EXT
                Else
                    lOpenAsInfo.OPEN_AS_INFO_FLAGS = WinAPIs.OPEN_AS_INFO_FLAGS.OAIF_FORCE_REGISTRATION Or WinAPIs.OPEN_AS_INFO_FLAGS.OAIF_REGISTER_EXT
                End If
                Dim lResult As Integer = WinAPIs.SHOpenWithDialog(IntPtr.Zero, lOpenAsInfo)
            Else
                'If lResult = WinAPIs.ERROR_CANCELLED Then
                'show the dialog
                'If aShowMessage = True Then
                '    If MessageBox.Show("In order to become the default for any system component, you must use Windows' Set Programs Association screen. In that screen, click on 'Select All' and then Save. Do you want to open this screen?", "Windows 8+ Instructions", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                '        Exit Sub
                '    End If
                'End If

                frmOptions.TopMost = False
                Dim aa = New WinAPIExtras.ApplicationAssociationRegistrationUI
                Dim iaa = DirectCast(aa, WinAPIExtras.IApplicationAssociationRegistrationUI)
                iaa.LaunchAdvancedAssociationUI(mAppName)
            End If
            'Else
            '    Dim lString As IntPtr = Marshal.StringToCoTaskMemAuto("SOFTWARE/Clients/StartMenuInternet")
            '    SendMessageTimeout(HWND_BROADCAST, WM_SETTINGCHANGE, IntPtr.Zero, lString, SendMessageTimeoutFlags.SMTO_NORMAL, 100, IntPtr.Zero)

            '    'try user scope
            '    'DoUserScope(Registry.CurrentUser)
            'End If
        End If

        Logger.AddToLog("DefaultBrowser.MakeDefault", "End", aScope, aForce8, aShowMessage, aDoSingle, abIsProtocol)
    End Sub

    Public Shared Sub CheckIfIsDefault()
        Logger.AddToLog("DefaultBrowser.CheckIfIsDefault", "Start")
        'using a com call here to set the file associations
        Dim aa = New WinAPIExtras.ApplicationAssociationRegistration
        Dim iaa = DirectCast(aa, WinAPIExtras.IApplicationAssociationRegistration)
        Dim lbIsDefault As Boolean = False

        Try
            If iaa.QueryAppIsDefaultAll(ASSOCIATIONLEVEL.AL_EFFECTIVE, mAppName, lbIsDefault) = 0 Then
                If lbIsDefault = True Then
                    If MessageBox.Show("Browser Chooser 2 is no longer the default browser. Do you whish to re-enable?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        GeneralUtilities.LaunchAdminMode(GeneralUtilities.ListOfCommands.MakeDefault)
                    End If
                End If
            End If
        Catch ex As Exception
            'not machine default - maybe user scope - must use XP fall method
            Dim lbFound As Boolean = True

            'for each protocol and filetype
            For Each lProtocol In gSettings.Protocols
                'copy our stuff into here - kinds weird XP...
                If GeneralUtilities.IsRunningXP = True Then
                    Dim lKey As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Classes\" & lProtocol.Header, False)

                    If IsNothing(lKey) = True Then
                        lbFound = False
                        Exit For
                    ElseIf IsNothing(lKey.OpenSubKey("DefaultIcon", False)) = False AndAlso lKey.OpenSubKey("DefaultIcon", False).GetValue("").ToString =
                        """" & Path.Combine(Application.StartupPath, mCanonical) & """,0" Then

                        'first test passed, second test is a negative (we are looking exclusivly for faillures)
                        If lKey.OpenSubKey("Shell\open\command", False).GetValue("").ToString <>
                            """" & Path.Combine(Application.StartupPath, mCanonical) & """ ""%1""" Then

                            'second test failled
                            lbFound = False
                            Exit For
                        End If
                    Else
                        'first tast failled
                        lbFound = False
                        Exit For
                    End If
                Else
                    'window 7 user mode detenction
                    Dim lKey As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\Shell\Associations\UrlAssociations\" & lProtocol.Header & "\UserChoice", False)

                    If IsNothing(lKey) = True Then
                        lbFound = False
                        Exit For
                    ElseIf IsNothing(lKey.GetValue("Progid")) = False AndAlso lKey.GetValue("Progid").ToString <> mURLAssociations Then
                        lbFound = False
                    End If
                End If
            Next

            'repeat for each filetype
            If lbFound = True Then 'short circuit
                For Each lFileType In gSettings.FileTypes
                    If GeneralUtilities.IsRunningXP = True Then
                        Dim lKey As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Classes\." & lFileType.Extention, False)

                        If IsNothing(lKey) = True Then
                            lbFound = False
                            Exit For

                        ElseIf IsNothing(lKey.GetValue("")) = False AndAlso lKey.GetValue("").ToString <> mFileAssociations Then

                            'test failled
                            lbFound = False
                            Exit For
                        End If
                    Else
                        Dim lKey As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FileExts\." & lFileType.Extention & "\UserChoice", False)

                        If IsNothing(lKey) = True Then
                            lbFound = False
                            Exit For

                        ElseIf IsNothing(lKey.GetValue("Progid")) = False AndAlso lKey.GetValue("Progid").ToString <> mURLAssociations Then

                            'test failled
                            lbFound = False
                            Exit For
                        End If
                    End If
                Next
            End If

            If lbFound = False Then
                'at least one is not default
                If MessageBox.Show("Browser Chooser 2 is no longer the default browser. Do you whish to re-enable?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    MakeAvailable(Scope.sUser)
                    MakeDefault(Scope.sUser, aShowMessage:=False)
                End If
            End If
        End Try

        Logger.AddToLog("DefaultBrowser.CheckIfIsDefault", "End")
    End Sub

    Public Shared Sub RemoveAllKeys(ByVal aScope As DefaultBrowser.Scope)
        Logger.AddToLog("DefaultBrowser.RemoveAllKeys", "Start", aScope)
        'remove all keys we created undre current scope
        Dim lMaster As RegistryKey
        Dim lClassesRoot As RegistryKey

        If aScope = Scope.sGlobal Then
            lMaster = Registry.LocalMachine
            lClassesRoot = Registry.ClassesRoot
        Else
            lMaster = Registry.CurrentUser
            lClassesRoot = Registry.CurrentUser.OpenSubKey("SOFTWARE\Classes", True)
        End If

        'application registration: Software\Microsoft\Windows\CurrentVersion\App Paths
        lMaster.DeleteSubKeyTree(String.Format("Software\Microsoft\Windows\CurrentVersion\App Paths\{0}", mCanonical))

        'associations / capabilities
        lClassesRoot.DeleteSubKeyTree(mFileAssociations)
        lClassesRoot.DeleteSubKeyTree(mURLAssociations)

        'SPAD
        lMaster.DeleteSubKeyTree(String.Format("SOFTWARE\Clients\StartMenuInternet\{0}", mCanonical))

        Logger.AddToLog("DefaultBrowser.RemoveAllKeys", "Start", aScope)
    End Sub
End Class
