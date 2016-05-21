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
    End Enum

    Public Shared AvailableCommands As New Dictionary(Of ListOfCommands, String) From { _
            {ListOfCommands.MakeAvailable, "--makeavailable"}, _
            {ListOfCommands.MakeDefault, "--makedefault"}, _
            {ListOfCommands.Reinstall, "--reinstall"}, _
            {ListOfCommands.HideIcons, "--hideicons"}, _
            {ListOfCommands.ShowIcons, "--showicons"}, _
            {ListOfCommands.FirstRun, "--firstrun"}, _
            {ListOfCommands.Testadmin, "--testadmin"}, _
            {ListOfCommands.Testadminint, "--testadmin-int"}, _
            {ListOfCommands.ApplyUpdate, "--applyupdate"}, _
            {ListOfCommands.FinishApplyUpdate, "--finishapplyupdate"}, _
            {ListOfCommands.BuildDetectionFile, "--builddetectionfile"}, _
            {ListOfCommands.Settings, "--settings"}, _
            {ListOfCommands.SettingsBrowsers, "--settings:browsers"}, _
            {ListOfCommands.SettingsAutoURLs, "--settings:autourls"}, _
            {ListOfCommands.SettingsProtocols, "--settings:protocols"}, _
            {ListOfCommands.SettingsFileTypes, "--settings:filetypes"}, _
            {ListOfCommands.SettingsCategories, "--settings:categories"}, _
            {ListOfCommands.SettingsSettings, "--settings:settings"}, _
            {ListOfCommands.SettingsMoreSettings, "--settings:moresettings"}, _
            {ListOfCommands.SettingsDefaultBrowser, "--settings:defaultbrowser"}, _
            {ListOfCommands.SSettings, "--s"}, _
            {ListOfCommands.SSettingsBrowsers, "--s:b"}, _
            {ListOfCommands.SSettingsAutoURLs, "--s:a"}, _
            {ListOfCommands.SSettingsProtocols, "--s:p"}, _
            {ListOfCommands.SSettingsFileTypes, "--s:f"}, _
            {ListOfCommands.SSettingsCategories, "--s:c"}, _
            {ListOfCommands.SSettingsSettings, "--s:s"}, _
            {ListOfCommands.SSettingsMoreSettings, "--s:ms"}, _
            {ListOfCommands.SSettingsDefaultBrowser, "--s:db"}, _
            {ListOfCommands.LoggingEnabled, "--log"} _
        }

    'NOTE: TAFactory.IconPack.dll comes from http://www.codeproject.com/Articles/32617/Extracting-Icons-from-EXE-DLL-and-Icon-Manipulatio
    ' it has only been signed.
    ' OSVersionInfo comes from http://www.codeproject.com/Articles/73000/Getting-Operating-System-Version-Info-Even-for-Win. it has not been modifyed

    Public Shared mFileNames As New Dictionary(Of EmbededDLLs, String) From {{EmbededDLLs.SHDocVw, "Interop.SHDocVw.dll"},
                                                                             {EmbededDLLs.TAFactory_IconPack, "TAFactory.IconPack.dll"},
                                                                             {EmbededDLLs.OSVersionInfo, "OSVersionInfo.dll"},
                                                                             {EmbededDLLs.SepCombo, "SepCombo.dll"}}
    Private Shared mbLoadedDLLs As New Dictionary(Of EmbededDLLs, Boolean) From {{EmbededDLLs.SHDocVw, False},
                                                                             {EmbededDLLs.TAFactory_IconPack, False},
                                                                             {EmbededDLLs.OSVersionInfo, False},
                                                                             {EmbededDLLs.SepCombo, False}}

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
    End Enum

    Public Shared Function SafeMessagebox(ByVal text As String, ByVal caption As String,
            ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon) As DialogResult
        If IsAdminMode() = False Then
            Return MessageBox.Show(text, caption, buttons, icon)
        Else
            Return DialogResult.Ignore
        End If
    End Function

    Public Shared Function IsRunningXP() As Boolean
        If Environment.OSVersion.Version.Major <= 5 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Shared Function IsRunningPost8() As Boolean
        If JCS.OSVersionInfo.MajorVersion = 6 And JCS.OSVersionInfo.MinorVersion >= 2 Then
            Return True
        ElseIf JCS.OSVersionInfo.MajorVersion >= 7 Then
            Return True 'does not yet exists, future proffing I guess
        Else
            Return False
        End If
    End Function

    'bloody hell MS - why make this so hard? Yet another API that no longer works.
    Public Shared Function IsRunningPost10() As Boolean
        If JCS.OSVersionInfo.MajorVersion >= 10 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Shared Function IsAdminMode() As Boolean
        Dim identity = WindowsIdentity.GetCurrent()
        Dim principal = New WindowsPrincipal(identity)
        Return principal.IsInRole(WindowsBuiltInRole.Administrator)
    End Function

    Public Shared Function LaunchUserMode(ByVal aCommand As ListOfCommands, ByVal aExtraPart As String, Optional ByVal aAltPath As String = "", Optional ByVal abWait As Boolean = True) As Integer
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
            Return lProc.ExitCode
        Catch ex As Exception
            Return -1
        End Try
    End Function

    Public Shared Function LaunchUserMode(ByVal aCommand As ListOfCommands) As Integer
        Return LaunchUserMode(aCommand, "") 'delegate to super command
    End Function

    Public Shared Function LaunchAdminMode(ByVal aCommand As ListOfCommands) As Integer
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
            Return lProc.ExitCode
        Catch ex As Exception
            Return -1
        End Try
    End Function

#Region "Load Internalized Files"
    Shared Function SHDocVw_ResolveEventHandler(ByVal sender As Object, ByVal args As ResolveEventArgs) As [Assembly]
        Debug.Print(args.Name)

        Dim parentAssembly As Assembly = Assembly.GetExecutingAssembly()

        Dim name As String = args.Name.Substring(0, args.Name.IndexOf(","c)) & ".dll"

        If mFileNames.ContainsValue(name) Then
            'load this assembly
            Dim resourceName = parentAssembly.GetManifestResourceNames().First(Function(s) s.EndsWith(name))

            Using stream As Stream = parentAssembly.GetManifestResourceStream(resourceName)
                Dim block As Byte() = New Byte(CInt(stream.Length - 1)) {}
                stream.Read(block, 0, block.Length)
                Return Assembly.Load(block)
            End Using
        Else
            Return GetType(GeneralUtilities).Assembly
        End If
    End Function

    Public Shared Sub LoadDLLPrep()
        'no need to know which dll, that will be in the args.target parameter above.
        Dim currentDomain As AppDomain = AppDomain.CurrentDomain

        AddHandler currentDomain.AssemblyResolve, AddressOf SHDocVw_ResolveEventHandler
    End Sub
#End Region

    Public Shared Function IsAeroEnabled() As Boolean
        Dim AeroState As Long

        Try
            DwmIsCompositionEnabled(AeroState)
            IsAeroEnabled = CBool(AeroState)
        Catch ex As System.DllNotFoundException
            IsAeroEnabled = False
        End Try

    End Function

    Public Shared Sub MakeFormGlassy(ByVal aForm As Form)
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
    End Sub

    Public Shared Function IsIntranetUrl(ByVal url As String) As Boolean
        Dim targetUri As Uri = New Uri(url)
        Dim domain As String = targetUri.Authority

        If domain.Contains(".") Then
            Return False
        Else
            Return True
        End If
    End Function

    'Public Function UrlsToString() As String
    '    If (Urls Is Nothing OrElse Urls.Count = 0) Then
    '        Return String.Empty
    '    Else
    '        Return String.Join(",", Urls.ToArray())
    '    End If
    'End Function

    'Public Shared Function StringToUrls(ByVal urlList As String) As List(Of String)
    '    If (String.IsNullOrEmpty(urlList)) Then
    '        Return New List(Of String)
    '    Else
    '        Return urlList.Split(",").ToList()
    '    End' If
    'End Function

    Public Shared Sub doCleanExit()
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
    End Sub

    Public Shared Function GetUniquedID() As Guid
        Dim lOut As Guid = System.Guid.NewGuid()

        If lOut <> Guid.Empty Then
            Return lOut
        Else
            Return Nothing 'error occured
        End If

    End Function

    Public Structure URLParts
        Public isProtocol As TriState
        Public Protocol As String
        Public Extention As String
        Public Remainder As String
    End Structure

    Public Shared Function DetermineParts(ByVal aURL As String) As URLParts
        Dim lOut As New URLParts

        If InStr(aURL, "://") > 0 Then 'is a protocol
            lOut.isProtocol = TriState.True
            lOut.Protocol = Left(aURL, InStr(aURL, "://") - 1)

        ElseIf InStr(aURL, ".") > 0 Then
            'file extention
            lOut.isProtocol = TriState.False
            lOut.Extention = Mid(aURL, InStrRev(aURL, ".") + 1) 'to be tested

        ElseIf InStr(aURL, "/") > 0 Then
            'try domain less
            lOut.isProtocol = TriState.True
            lOut.Protocol = "http"
        Else
            lOut.isProtocol = TriState.UseDefault ' for instances where we can't determine easily
        End If

        Return lOut
    End Function
End Class