'Option Strict Off
Imports System.IO
Imports System.Reflection
Imports Browser_Chooser_2.WinAPIs
Imports System.Security.Principal
Imports System
Imports System.Management

Public Class GeneralUtilities
    Public Const DEFAULT_CATEGORY As String = "Browsers"
    Public Enum ListOfCommands
        MakeAvailable
        MakeDefault
        Reinstall
        HideIcons
        ShowIcons
        FirstRun
        Testadmin
        Testadminint
        ApplyUpdate
        FinishApplyUpdate
        BuildDetectionFile
        Uninstall
        ' options screen quick hits
        Settings
        SettingsBrowsers
        SettingsAutoURLs
        SettingsProtocols
        SettingsFileTypes
        SettingsCategories
        SettingsSettings
        SettingsMoreSettings
        SettingsDefaultBrowser
        'options, short hand version
        SSettings
        SSettingsBrowsers
        SSettingsAutoURLs
        SSettingsProtocols
        SSettingsFileTypes
        SSettingsCategories
        SSettingsSettings
        SSettingsMoreSettings
        SSettingsDefaultBrowser
        'log where we are
        LoggingEnabled
        'extract dlls,
        ExtractDLLs
        SExtractDLLs
    End Enum

    Public Shared AvailableCommands As New Dictionary(Of ListOfCommands, String) From {
            {ListOfCommands.MakeAvailable, "--makeavailable"},
            {ListOfCommands.MakeDefault, "--makedefault"},
            {ListOfCommands.Reinstall, "--reinstall"},
            {ListOfCommands.HideIcons, "--hideicons"},
            {ListOfCommands.ShowIcons, "--showicons"},
            {ListOfCommands.FirstRun, "--firstrun"},
            {ListOfCommands.Testadmin, "--testadmin"},
            {ListOfCommands.Testadminint, "--testadmin-int"},
            {ListOfCommands.ApplyUpdate, "--applyupdate"},
            {ListOfCommands.FinishApplyUpdate, "--finishapplyupdate"},
            {ListOfCommands.BuildDetectionFile, "--builddetectionfile"},
            {ListOfCommands.Uninstall, "--uninstall"},
            {ListOfCommands.Settings, "--settings"},
            {ListOfCommands.SettingsBrowsers, "--settings:browsers"},
            {ListOfCommands.SettingsAutoURLs, "--settings:autourls"},
            {ListOfCommands.SettingsProtocols, "--settings:protocols"},
            {ListOfCommands.SettingsFileTypes, "--settings:filetypes"},
            {ListOfCommands.SettingsCategories, "--settings:categories"},
            {ListOfCommands.SettingsSettings, "--settings:settings"},
            {ListOfCommands.SettingsMoreSettings, "--settings:moresettings"},
            {ListOfCommands.SettingsDefaultBrowser, "--settings:defaultbrowser"},
            {ListOfCommands.SSettings, "--s"},
            {ListOfCommands.SSettingsBrowsers, "--s:b"},
            {ListOfCommands.SSettingsAutoURLs, "--s:a"},
            {ListOfCommands.SSettingsProtocols, "--s:p"},
            {ListOfCommands.SSettingsFileTypes, "--s:f"},
            {ListOfCommands.SSettingsCategories, "--s:c"},
            {ListOfCommands.SSettingsSettings, "--s:s"},
            {ListOfCommands.SSettingsMoreSettings, "--s:ms"},
            {ListOfCommands.SSettingsDefaultBrowser, "--s:db"},
            {ListOfCommands.LoggingEnabled, "--log"},
            {ListOfCommands.ExtractDLLs, "--extract"},
            {ListOfCommands.SExtractDLLs, "--e"}
        }

    'NOTE: TAFactory.IconPack.dll comes from http://www.codeproject.com/Articles/32617/Extracting-Icons-from-EXE-DLL-and-Icon-Manipulatio
    ' it has only been signed.
    ' OSVersionInfo comes from http://www.codeproject.com/Articles/73000/Getting-Operating-System-Version-Info-Even-for-Win. it has not been modifyed

    Public Shared mFileNames As New Dictionary(Of EmbededDLLs, String) From {{EmbededDLLs.SHDocVw, "Interop.SHDocVw.dll"},
                                                                             {EmbededDLLs.TAFactory_IconPack, "TAFactory.IconPack.dll"},
                                                                             {EmbededDLLs.OSVersionInfo, "OSVersionInfo.dll"},
                                                                             {EmbededDLLs.SepCombo, "SepCombo.dll"},
                                                                             {EmbededDLLs.XMLSerializer, "Browser Chooser 2.XmlSerializers.dll"}}
    Private Shared mbLoadedDLLs As New Dictionary(Of EmbededDLLs, Boolean) From {{EmbededDLLs.SHDocVw, False},
                                                                             {EmbededDLLs.TAFactory_IconPack, False},
                                                                             {EmbededDLLs.OSVersionInfo, False},
                                                                             {EmbededDLLs.SepCombo, False},
                                                                             {EmbededDLLs.XMLSerializer, False}}

    Public Shared KeyCodeValues As New Dictionary(Of Keys, Integer) From { _
        {Keys.NumPad1, 1}, _
        {Keys.NumPad2, 2}, _
        {Keys.NumPad3, 3}, _
        {Keys.NumPad4, 4}, _
        {Keys.NumPad5, 5}, _
        {Keys.NumPad6, 6}, _
        {Keys.NumPad7, 7}, _
        {Keys.NumPad8, 8}, _
        {Keys.NumPad9, 9}, _
        {Keys.NumPad0, 0}, _
        {Keys.D1, 1}, _
        {Keys.D2, 2}, _
        {Keys.D3, 3}, _
        {Keys.D4, 4}, _
        {Keys.D5, 5}, _
        {Keys.D6, 6}, _
        {Keys.D7, 7}, _
        {Keys.D8, 8}, _
        {Keys.D9, 9}, _
        {Keys.D0, 0}}

    Public Enum EmbededDLLs
        SHDocVw
        TAFactory_IconPack
        OSVersionInfo
        SepCombo
        XMLSerializer
    End Enum

    Public Shared Function SafeMessagebox(ByVal text As String, ByVal caption As String,
            ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon) As DialogResult
        Logger.AddToLog("GeneralUtilities.SafeMessagebox", "Start", text, caption)
        If IsAdminMode() = False Then
            Return MessageBox.Show(text, caption, buttons, icon)
        Else
            Return DialogResult.Ignore
        End If
    End Function

    Public Shared Function IsRunningXP() As Boolean
        Logger.AddToLog("GeneralUtilities.IsRunningXP", "Start")
        If Environment.OSVersion.Version.Major <= 5 Then
            Logger.AddToLog("GeneralUtilities.IsRunningXP", "End", True)
            Return True
        Else
            Logger.AddToLog("GeneralUtilities.IsRunningXP", "End", False)
            Return False
        End If
    End Function

    Public Shared Function IsRunningPost8() As Boolean
        Logger.AddToLog("GeneralUtilities.IsRunningPost8", "Start")
        If JCS.OSVersionInfo.MajorVersion = 6 And JCS.OSVersionInfo.MinorVersion >= 2 Then
            Logger.AddToLog("GeneralUtilities.IsRunningPost8", "End", True, False)
            Return True
        ElseIf JCS.OSVersionInfo.MajorVersion >= 7 Then
            Logger.AddToLog("GeneralUtilities.IsRunningPost8", "End", True, True)
            Return True 'does not yet exists, future proffing I guess
        Else
            Logger.AddToLog("GeneralUtilities.IsRunningPost8", "End", False)
            Return False
        End If
    End Function

    'bloody hell MS - why make this so hard? Yet another API that no longer works.
    Public Shared Function IsRunningPost10() As Boolean
        Logger.AddToLog("GeneralUtilities.IsRunningPost10", "Start")
        If JCS.OSVersionInfo.MajorVersion >= 10 Then
            Logger.AddToLog("GeneralUtilities.IsRunningPost10", "End", True)
            Return True
        Else
            Logger.AddToLog("GeneralUtilities.IsRunningPost10", "End", False)
            Return False
        End If
    End Function

    Public Shared Function IsAdminMode() As Boolean
        Logger.AddToLog("GeneralUtilities.IsAdminMode", "Start")
        Dim identity = WindowsIdentity.GetCurrent()
        Dim principal = New WindowsPrincipal(identity)
        Logger.AddToLog("GeneralUtilities.IsAdminMode", "End", principal.IsInRole(WindowsBuiltInRole.Administrator))
        Return principal.IsInRole(WindowsBuiltInRole.Administrator)
    End Function

    Public Shared Function LaunchUserMode(ByVal aCommand As ListOfCommands, ByVal aExtraPart As String, Optional ByVal aAltPath As String = "", Optional ByVal abWait As Boolean = True) As Integer
        Logger.AddToLog("GeneralUtilities.LaunchUserMode", "Start", aCommand, aExtraPart, aAltPath, abWait)
        Try
            Dim lAdminProc As New ProcessStartInfo
            lAdminProc.WorkingDirectory = Environment.CurrentDirectory
            If aAltPath = "" Then
                lAdminProc.FileName = Application.ExecutablePath
            Else
                lAdminProc.FileName = aAltPath
            End If
            If aExtraPart <> "" Then
                lAdminProc.Arguments = AvailableCommands(aCommand) & " " & aExtraPart
            Else
                lAdminProc.Arguments = AvailableCommands(aCommand)
            End If

            lAdminProc.UseShellExecute = True

            'now run ourselves, command line makes this happen
#If CONFIG = "Debug Update and Pause" Then
            MsgBox("pause")
#End If
            frmOptions.TopMost = False
            Dim lProc As Process = Process.Start(lAdminProc)
            If abWait = True Then
                lProc.WaitForExit() 'this will return a value with success or not
            End If
            frmOptions.TopMost = True

            Logger.AddToLog("GeneralUtilities.LaunchUserMode", "End", lProc.ExitCode)
            Return lProc.ExitCode
        Catch ex As Exception
            Logger.AddToLog("GeneralUtilities.LaunchUserMode", "End", -1)
            Return -1
        End Try
    End Function

    Public Shared Function LaunchUserMode(ByVal aCommand As ListOfCommands) As Integer
        Return LaunchUserMode(aCommand, "") 'delegate to super command
    End Function

    Public Shared Function LaunchAdminMode(ByVal aCommand As ListOfCommands) As Integer
        Logger.AddToLog("GeneralUtilities.LaunchAdminMode", "Start", aCommand)
        Try
            Dim lAdminProc As New ProcessStartInfo
            lAdminProc.WorkingDirectory = Environment.CurrentDirectory
            lAdminProc.FileName = Application.ExecutablePath
            lAdminProc.Arguments = AvailableCommands(aCommand)
            lAdminProc.UseShellExecute = True

            If IsRunningXP() = False Then
                'vista and up need to be admin
                lAdminProc.Verb = "runas"
            End If

            'now run ourselves, command line makes this happen
            frmOptions.TopMost = False
            Dim lProc As Process = Process.Start(lAdminProc)
            lProc.WaitForExit() 'this will return a value with success or not
            frmOptions.TopMost = True

            Logger.AddToLog("GeneralUtilities.LaunchAdminMode", "End", lProc.ExitCode)
            Return lProc.ExitCode
        Catch ex As Exception
            Logger.AddToLog("GeneralUtilities.LaunchAdminMode", "End", -1)
            Return -1
        End Try
    End Function

#Region "Load Internalized Files"
    Shared Function SHDocVw_ResolveEventHandler(ByVal sender As Object, ByVal args As ResolveEventArgs) As [Assembly]
        Logger.AddToLog("GeneralUtilities.SHDocVw_ResolveEventHandler", "Start")
        'Debug.Print(args.Name)

        Dim parentAssembly As Assembly = Assembly.GetExecutingAssembly()

        Dim name As String = args.Name.Substring(0, args.Name.IndexOf(","c)) & ".dll"
        Logger.AddToLog("GeneralUtilities.SHDocVw_ResolveEventHandler", "Name Identifyed", name)

        If mFileNames.ContainsValue(name) Then
            Logger.AddToLog("GeneralUtilities.SHDocVw_ResolveEventHandler", "Assembly Found")
            'load this assembly
            Dim resourceName = parentAssembly.GetManifestResourceNames().First(Function(s) s.EndsWith(name))

            Using stream As Stream = parentAssembly.GetManifestResourceStream(resourceName)
                Logger.AddToLog("GeneralUtilities.SHDocVw_ResolveEventHandler", "Loading assembly")
                Dim block As Byte() = New Byte(CInt(stream.Length - 1)) {}
                stream.Read(block, 0, block.Length)

                'see if this XMlSerializer, extract to disk if yes
                If name = mFileNames.Item(EmbededDLLs.XMLSerializer) Then
                    If Settings.DoExtractDLLs = True Then
                        Logger.AddToLog("GeneralUtilities.SHDocVw_ResolveEventHandler", "Writting assembly to disk")
                        Dim writeStream As New StreamWriter(mFileNames.Item(EmbededDLLs.XMLSerializer), False)
                        writeStream.Write(stream)
                        writeStream.Close()
                    End If
                    Return GetType(GeneralUtilities).Assembly
                Else
                    Return Assembly.Load(block)
                End If
            End Using
        Else
            Logger.AddToLog("GeneralUtilities.SHDocVw_ResolveEventHandler", "Returning Self")
            Return GetType(GeneralUtilities).Assembly
        End If
    End Function

    Public Shared Sub LoadDLLPrep()
        Logger.AddToLog("GeneralUtilities.LoadDLLPrep", "Start")
        'no need to know which dll, that will be in the args.target parameter above.
        Dim currentDomain As AppDomain = AppDomain.CurrentDomain

        AddHandler currentDomain.AssemblyResolve, AddressOf SHDocVw_ResolveEventHandler
        Logger.AddToLog("GeneralUtilities.LoadDLLPrep", "End")
    End Sub
#End Region

    Public Shared Function IsAeroEnabled() As Boolean
        Logger.AddToLog("GeneralUtilities.IsAeroEnabled", "Start")
        Dim AeroState As Long

        Try
            DwmIsCompositionEnabled(AeroState)
            Logger.AddToLog("GeneralUtilities.IsAeroEnabled", "End", CBool(AeroState))
            IsAeroEnabled = CBool(AeroState)
        Catch ex As System.DllNotFoundException
            Logger.AddToLog("GeneralUtilities.IsAeroEnabled", "End EX", False, ex.Message)
            IsAeroEnabled = False
        End Try

    End Function

    Public Shared Sub MakeFormGlassy(ByVal aForm As Form)
        Logger.AddToLog("GeneralUtilities.MakeFormGlassy", "Start", aForm.Text)
        Dim margins As MARGINS = New MARGINS
        margins.cxLeftWidth = -1
        margins.cxRightWidth = -1
        margins.cyTopHeight = -1
        margins.cyButtomheight = -1
        'set all the four value -1 to apply glass effect to the whole window
        aForm.BackColor = Color.Black
        Dim hwnd As IntPtr = aForm.Handle
        Dim result As Integer = DwmExtendFrameIntoClientArea(hwnd, margins)

        'attemp to make pretty
        'Try
        '    Dim lPreColor As New WinAPIs.tagCOLORIZATIONPARAMS
        '    WinAPIs.DwmGetColorizationParameters(lPreColor)

        '    Debug.Print(lPreColor.clrColor.R.ToString)

        '    'change RGB to user selected value
        '    Dim lNewColor As WinAPIs.tagCOLORIZATIONPARAMS = lPreColor.Clone
        '    Dim lBackColor As Color = Color.FromArgb(gSettings.BackgroundColor)
        '    lNewColor.clrColor.R = lBackColor.R
        '    lNewColor.clrColor.G = lBackColor.G
        '    lNewColor.clrColor.B = lBackColor.B

        '    WinAPIs.DwmSetColorizationParameters(lNewColor, False)

        '    'show the form
        '    aForm.Show()

        '    'reset to original
        '    WinAPIs.DwmSetColorizationParameters(lPreColor, False)
        'Catch ex As Exception

        'End Try

        Logger.AddToLog("GeneralUtilities.MakeFormGlassy", "End", aForm.Text)
    End Sub

    Public Shared Sub doCleanExit()
        Logger.AddToLog("GeneralUtilities.doCleanExit", "Start")
        Dim lFormsToClose As New List(Of Form)

        'build list of forms to close
        For Each lForm As Form In Application.OpenForms
            lFormsToClose.Add(lForm) 'cannot close here, causes a colleciton has changed error.
        Next

        'close forms found above
        For Each lForm As Form In lFormsToClose
            lForm.Close()
        Next

        'End 'not clean, will do for now
        'System.Environment.Exit(0) ' this line needs a security permission
        'sercutiry permissions will be done in Beta 3
        Logger.AddToLog("GeneralUtilities.doCleanExit", "End")
        Application.Exit()
    End Sub

    Public Shared Function GetUniquedID() As Guid
        Logger.AddToLog("GeneralUtilities.GetUniquedID", "Start")
        Dim lOut As Guid = System.Guid.NewGuid()

        If lOut <> Guid.Empty Then
            Logger.AddToLog("GeneralUtilities.GetUniquedID", "End", lOut)
            Return lOut
        Else
            Logger.AddToLog("GeneralUtilities.GetUniquedID", "End Error")
            Return Nothing 'error occured
        End If

    End Function
End Class