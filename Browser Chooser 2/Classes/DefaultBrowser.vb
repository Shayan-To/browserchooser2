Imports Microsoft.Win32
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Security.Permissions
Imports System.Windows.Forms
Imports Browser_Chooser_2.WinAPIs
Imports Browser_Chooser_2.WinAPIExtras
Imports System.Security.AccessControl

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
        'oftware\Microsoft\Windows\CurrentVersion\App Paths
        Dim lKey As RegistryKey = aROOT.CreateSubKey("Software\Microsoft\Windows\CurrentVersion\App Paths", RegistryKeyPermissionCheck.ReadWriteSubTree)
        Dim lSubKey As RegistryKey = lKey.CreateSubKey(mCanonical, RegistryKeyPermissionCheck.ReadWriteSubTree)
        lSubKey.SetValue("", My.Application.Info.DirectoryPath & mCanonical, RegistryValueKind.String)
        lSubKey.SetValue("UseUrl", 1, RegistryValueKind.DWord)
    End Sub

    Private Shared Sub CreateAssociations(ByVal aROOT As RegistryKey)
        'finaly, end with file accociations
        Dim lData As Byte() = New Byte() {2}
        Dim lKey = aROOT.CreateSubKey(mFileAssociations)
        lKey.SetValue("", mCanonical, RegistryValueKind.String)
        lKey.SetValue("FriendlyTypeName", mAppName, RegistryValueKind.String)
        lKey.SetValue("EditFlags", lData, RegistryValueKind.Binary)
        lKey.CreateSubKey("DefaultIcon").SetValue("", _
            """" & Path.Combine(Application.StartupPath, mCanonical) & """,0", RegistryValueKind.String)
        lKey.CreateSubKey("shell\open\command").SetValue("", """" & Application.ExecutablePath & """ ""%1""", RegistryValueKind.String)

        'url accociations
        lKey = aROOT.CreateSubKey(mURLAssociations)
        lKey.SetValue("", mCanonical, RegistryValueKind.String)
        lKey.SetValue("FriendlyTypeName", mAppName, RegistryValueKind.String)
        lKey.SetValue("EditFlags", lData, RegistryValueKind.Binary)
        lKey.SetValue("URL Protocol", mCanonical, RegistryValueKind.String)
        lKey.CreateSubKey("DefaultIcon").SetValue("", _
            """" & Path.Combine(Application.StartupPath, mCanonical) & """,0", RegistryValueKind.String)
        lKey.CreateSubKey("shell\open\command").SetValue("", """" & Application.ExecutablePath & """ ""%1""", RegistryValueKind.String)
    End Sub

    Private Shared Sub CreateCapabilities(ByVal aROOT As RegistryKey)
        Dim lKey = aROOT.CreateSubKey(mBC2KeyName, RegistryKeyPermissionCheck.ReadWriteSubTree)

        If IsNothing(lKey) = False Then
            'write out our values
            lKey.CreateSubKey("Capabilities").SetValue("ApplicationName", mAppName, RegistryValueKind.String)
            lKey.CreateSubKey("Capabilities").SetValue("ApplicationIcon", Application.ExecutablePath & ",0", RegistryValueKind.String)
            lKey.CreateSubKey("Capabilities").SetValue("ApplicationDescription", "Small application that let's you choose what browser to open with a provided url. https://browserchooser2.codeplex.com", RegistryValueKind.String)

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
    End Sub

    Public Shared Sub CreateSPAD(ByVal aROOT As RegistryKey)
        Dim lSubKey As RegistryKey

        'Register the canonical name and Register the Display Name, icon
        Dim lKey As RegistryKey = aROOT.CreateSubKey("SOFTWARE\Clients\StartMenuInternet\" + mCanonical)
        lKey.SetValue("", mAppName, RegistryValueKind.String)
        lKey.SetValue("LocalizedString", mAppName, RegistryValueKind.String)

        lKey.CreateSubKey("DefaultIcon").SetValue("", """" & Path.Combine(Application.StartupPath, mCanonical) & """,0", RegistryValueKind.String)

        'Registering an Open Verb
        lKey.CreateSubKey("shell\open\command").SetValue("", _
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
    End Sub

    Public Shared Sub MakeAvailable(ByVal aScope As DefaultBrowser.Scope) 'needs admin - writes to HKLM
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
            CreateAssociations(Registry.ClassesRoot) 'should work witout admin, need to test
        End If

        CreateCapabilities(Registry.CurrentUser)
        CreateAssociations(Registry.CurrentUser.OpenSubKey("SOFTWARE\Classes", True))

        'broadcast change - this will trigger a notification in Win 8+
        SHChangeNotify(SHChangeNotifyEventID.SHCNE_ASSOCCHANGED, SHChangeNotifyFlags.SHCNF_DWORD Or SHChangeNotifyFlags.SHCNF_FLUSH,
                       IntPtr.Zero, IntPtr.Zero)
    End Sub

    Private Shared Sub DoUserScope(ByVal aMaster As RegistryKey) 'includes windows XP
        'If aScope = Settings.Scope.sGlobal Then
        Registry.CurrentUser.CreateSubKey("SOFTWARE\Clients\StartMenuInternet\").DeleteValue("", False)
        'End If

        'Windows XP section - raw copy, com call above wont work
        For Each lKey As String In aMaster.CreateSubKey(mBC2KeyName, RegistryKeyPermissionCheck.ReadWriteSubTree) _
            .CreateSubKey("Capabilities\FileAssociations").GetValueNames

            'put our canoninical name in the default of those in classes root
            If Utility.IsRunningXP = True Then
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

            If Utility.IsRunningXP = True Then
                'copy our stuff into here - kinds weird XP...
                Registry.CurrentUser.CreateSubKey("SOFTWARE\Classes\" & lKey & "\DefaultIcon", RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("", _
                    """" & Path.Combine(Application.StartupPath, mCanonical) & """,0", RegistryValueKind.String)

                'now copy the open command
                Registry.CurrentUser.CreateSubKey("SOFTWARE\Classes\" & lKey & "\Shell\open\command", RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("", _
                    """" & Path.Combine(Application.StartupPath, mCanonical) & """ ""%1""", RegistryValueKind.String)
            Else
                Registry.CurrentUser.CreateSubKey("SOFTWARE\Microsoft\Windows\Shell\Associations\UrlAssociations\" & lKey & "\UserChoice").SetValue("Progid", mURLAssociations)
            End If
        Next 'and XP ends abrutly like this...

        'one extra for Win Vista and 7 
        If Utility.IsRunningXP = False Then
            '                                                                          intentional front slash ---v do not change
            Registry.CurrentUser.CreateSubKey("SOFTWARE\Microsoft\Windows\Shell\Associations\MIMEAssociations\text/html\UserChoice").SetValue("Progid", mFileAssociations) 'not sure if this will work
        End If

        'create accosiations in user software classes
        CreateAssociations(Registry.CurrentUser.OpenSubKey("SOFTWARE\Classes\", True))
    End Sub

    Public Shared Sub MakeDefault(ByVal aScope As DefaultBrowser.Scope, Optional ByVal aForce8 As Boolean = False, Optional ByVal aShowMessage As Boolean = True)
        If Utility.IsRunningPost8 = False And aForce8 = False Then
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
            If Utility.IsRunningXP = True Or aScope = Scope.sUser Then
                DoUserScope(lMaster)

            Else
                'using a com call here to set the file associations
                Dim aa = New WinAPIExtras.ApplicationAssociationRegistration
                Dim iaa = DirectCast(aa, WinAPIExtras.IApplicationAssociationRegistration)
                'If aScope = Scope.sUser Then
                'Else
                iaa.SetAppAsDefaultAll(mAppName) 'seems to only work  only on hklm
                'End If
            End If

            'as per MS docs, broadcast the change
            Dim lString As IntPtr = Marshal.StringToCoTaskMemAuto("SOFTWARE/Clients/StartMenuInternet")
            SendMessageTimeout(HWND_BROADCAST, WM_SETTINGCHANGE, IntPtr.Zero, lString, SendMessageTimeoutFlags.SMTO_NORMAL, 100, IntPtr.Zero)
            'SHChangeNotify(SHChangeNotifyEventID.SHCNE_ASSOCCHANGED, SHChangeNotifyFlags.SHCNF_DWORD Or SHChangeNotifyFlags.SHCNF_FLUSH, Nothing, Nothing)
        Else
            'cause the open with dialog to open, if canceled go to advanced dialog
            'NOTE THAT THIS SECTION IS NOT WINDOWS XP SAFE, you should never come here on windows XP, but still.
            'NOTE 2: Scope is irrelevent on Windows 8 - it is all user.
            'Dim lOpenAsInfo As New WinAPIs.OPENASINFO
            'lOpenAsInfo.cszFile = "HTTP" 'testing
            'lOpenAsInfo.cszClass = ""
            'lOpenAsInfo.OPEN_AS_INFO_FLAGS = WinAPIs.OPEN_AS_INFO_FLAGS.OAIF_URL_PROTOCOL Or WinAPIs.OPEN_AS_INFO_FLAGS.OAIF_FORCE_REGISTRATION Or WinAPIs.OPEN_AS_INFO_FLAGS.OAIF_REGISTER_EXT
            'Dim lResult As Integer = WinAPIs.SHOpenWithDialog(IntPtr.Zero, lOpenAsInfo)

            'If lResult = WinAPIs.ERROR_CANCELLED Then
            'show the dialog
            If aShowMessage = True Then
                If MessageBox.Show("In order to become the default for any system component, you must use Windows' Set Programs Association screen. In that screen, click on 'Select All' and then Save. Do you want to open this screen?", "Windows 8+ Instructions", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                    Exit Sub
                End If
            End If

            frmOptions.TopMost = False
            Dim aa = New WinAPIExtras.ApplicationAssociationRegistrationUI
            Dim iaa = DirectCast(aa, WinAPIExtras.IApplicationAssociationRegistrationUI)
            iaa.LaunchAdvancedAssociationUI(mAppName)
            'Else
            '    Dim lString As IntPtr = Marshal.StringToCoTaskMemAuto("SOFTWARE/Clients/StartMenuInternet")
            '    SendMessageTimeout(HWND_BROADCAST, WM_SETTINGCHANGE, IntPtr.Zero, lString, SendMessageTimeoutFlags.SMTO_NORMAL, 100, IntPtr.Zero)

            '    'try user scope
            '    'DoUserScope(Registry.CurrentUser)
            'End If
        End If
    End Sub

    Public Shared Sub CheckIfIsDefault()
        'using a com call here to set the file associations
        Dim aa = New WinAPIExtras.ApplicationAssociationRegistration
        Dim iaa = DirectCast(aa, WinAPIExtras.IApplicationAssociationRegistration)
        Dim lbIsDefault As Boolean = False

        Try
            If iaa.QueryAppIsDefaultAll(ASSOCIATIONLEVEL.AL_EFFECTIVE, mAppName, lbIsDefault) = 0 Then
                If lbIsDefault = True Then
                    If MessageBox.Show("Browser Chooser 2 is no longer the default browser. Do you whish to re-enable?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        Utility.LaunchAdminMode(Utility.ListOfCommands.MakeDefault)
                    End If
                End If
            End If
        Catch ex As Exception
            'not machine default - maybe user scope - must use XP fall method
            Dim lbFound As Boolean = True

            'for each protocol and filetype
            For Each lProtocol In gSettings.Protocols
                'copy our stuff into here - kinds weird XP...
                If Utility.IsRunningXP = True Then
                    Dim lKey As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Classes\" & lProtocol.Header, False)

                    If IsNothing(lKey) = True Then
                        lbFound = False
                        Exit For
                    ElseIf IsNothing(lKey.OpenSubKey("DefaultIcon", False)) = False AndAlso lKey.OpenSubKey("DefaultIcon", False).GetValue("").ToString = _
                        """" & Path.Combine(Application.StartupPath, mCanonical) & """,0" Then

                        'first test passed, second test is a negative (we are looking exclusivly for faillures)
                        If lKey.OpenSubKey("Shell\open\command", False).GetValue("").ToString <> _
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
                    If Utility.IsRunningXP = True Then
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
    End Sub
End Class
