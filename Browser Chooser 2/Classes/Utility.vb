Option Strict Off
Imports System.IO
Imports System.Reflection
Imports Browser_Chooser_2.WinAPIs
Imports System.Security.Principal

Public Class Utility
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
            {ListOfCommands.BuildDetectionFile, "--builddetectionfile"} _
        }

    'NOTE: TAFactory.IconPack.dll comes from http://www.codeproject.com/Articles/32617/Extracting-Icons-from-EXE-DLL-and-Icon-Manipulatio
    ' it has only been signed.
    ' OSVersionInfo comes from http://www.codeproject.com/Articles/73000/Getting-Operating-System-Version-Info-Even-for-Win. it has not been modifyed

    Public Shared mFileNames As New Dictionary(Of EmbededDLLs, String) From {{EmbededDLLs.SHDocVw, "Interop.SHDocVw.dll"},
                                                                             {EmbededDLLs.TAFactory_IconPack, "TAFactory.IconPack.dll"},
                                                                             {EmbededDLLs.OSVersionInfo, "OSVersionInfo.dll"}}
    Private Shared mbLoadedDLLs As New Dictionary(Of EmbededDLLs, Boolean) From {{EmbededDLLs.SHDocVw, False},
                                                                             {EmbededDLLs.TAFactory_IconPack, False},
                                                                             {EmbededDLLs.OSVersionInfo, False}}

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
                Dim block As Byte() = New Byte(stream.Length - 1) {}
                stream.Read(block, 0, block.Length)
                Return Assembly.Load(block)
            End Using
        Else
            Return GetType(Utility).Assembly
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

#Region "IE Open as Tab code"
    Public Shared Sub GetIE(ByVal lBrowser As Browser, ByVal aURL As String, ByVal aTerminate As Boolean)
        'made it an option to allow user to override
        Dim lbFound As Boolean = False

        For Each lIe As SHDocVw.InternetExplorer In New SHDocVw.ShellWindows()
            If lIe.FullName = lBrowser.Target Then
                'good start
                Try
                    lIe.Navigate2(aURL, BrowserNavConstants.navOpenInNewTab)
                Catch ex As Exception
                    lIe.Navigate2(aURL, BrowserNavConstants.navOpenInNewWindow)
                End Try

                lIe.Visible = True

                'AppActivate() ' see if needed

                lbFound = True
                Exit For
            End If
        Next

        If lbFound = False Then
            DoLaunch(lBrowser, aURL, aTerminate)
        ElseIf aTerminate = True Then
            End 'not clean, will do for now
        End If
    End Sub
#End Region


    Private Shared Function DoLaunch(ByVal aTarget As Browser, ByVal aURL As String, ByVal aTerminate As Boolean) As Boolean
        'Dim strParameters As String = ""
        Dim strBrowser As String = GenericBrowserControl.NormalizeTarget(aTarget.Target)

        'If aTarget.Target.Contains(".exe ") Then
        '    ' old method
        '    Dim lTargetEXE As String = GenericBrowserControl.NormalizeTarget(aTarget.Target)
        '    strBrowser = lTargetEXE.Substring(0, InStr(aTarget.Target, ".exe") + 4)
        '    strParameters = lTargetEXE.Substring(InStr(lTargetEXE, ".exe") + 4, lTargetEXE.Length - (InStr(lTargetEXE, ".exe") + 4)) & " " & aTarget.Arguments

        '    If Not String.IsNullOrEmpty(aURL) Then
        '        Process.Start(strBrowser, strParameters & """" & aURL & """")
        '    Else
        '        Process.Start(strBrowser, strParameters)
        '    End If
        'Else
        If My.Computer.FileSystem.FileExists(strBrowser) = True Then
            Dim lProcess As Process
            If Not String.IsNullOrEmpty(aURL) Then
                lProcess = Process.Start(strBrowser, aTarget.Arguments & " """ & aURL & """")
            Else
                lProcess = Process.Start(strBrowser, aTarget.Arguments)
            End If
            'Dim lID As Integer = lProcess.Id

            'lProcess.WaitForInputIdle()
            'AppActivate(lID)
            'End If

            If aTerminate = True Then
                lProcess = Nothing

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
            End If

            Return True
        Else
            MessageBox.Show("Browser " & aTarget.Name & " cannot be found.", "Missing Target", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
    End Function

    Public Shared Sub LaunchBrowser(ByVal lBrowser As Browser, ByVal lURL As String, ByVal aTerminate As Boolean)
        'Dim target As String = GenericBrowserControl.NormalizeTarget(lBrowser.Target)

        'special handleing for IE (surprise, surprise!)
        If lBrowser.IsIE = True Then
            GetIE(lBrowser, lURL, aTerminate) 'now get IE, but the DLL will be loaded before calling

        Else
            'check to see if the file exists
            'If (IO.File.Exists(target)) Or target.Contains(".exe ") Then
            If DoLaunch(lBrowser, lURL, aTerminate) = True Then
                'End If

                If aTerminate = True Then
                    End 'not clean, will do for now
                End If
            End If
        End If
    End Sub

    Public Shared Function GetAllICOsFromFile(ByVal aFile As String) As Image()
        Dim lIcons As List(Of Icon) = TAFactory.IconPack.IconHelper.ExtractAllIcons(aFile)
        Dim lOut(lIcons.Count) As Image

        For lCount As Integer = 0 To lIcons.Count - 1
            lOut(lCount) = TAFactory.IconPack.IconHelper.ExtractBestFitIcon(aFile, lCount, New Size(64, 64)).ToBitmap
        Next

        Return lOut
    End Function

    Public Shared Function GetICOFromFile(ByVal aFile As String, ByVal aIndex As Integer, Optional ByVal ErrorIconOnFail As Boolean = True) As Image
        If My.Computer.FileSystem.FileExists(aFile) = True Then
            Dim lIcon As Icon = TAFactory.IconPack.IconHelper.ExtractBestFitIcon(aFile, aIndex, New Size(64, 64))

            'If c.Size.Width = 256 Then 're-add later as an option?
            '    Return Bitmap.FromHicon(c.Handle)
            'Else
            Return lIcon.ToBitmap
            'End If
        Else
            Return My.Resources._53
        End If
    End Function

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

    Public Shared Function ScaleImage(ByVal aImage As Image, ByVal aScale As Single) As Image
        ' Get the source bitmap.
        Dim bm_source As New Bitmap(aImage)

        ' Make a bitmap for the result.
        Dim bm_dest As New Bitmap( _
            CInt(bm_source.Width * aScale), _
            CInt(bm_source.Height * aScale))

        ' Make a Graphics object for the result Bitmap.
        Dim gr_dest As Graphics = Graphics.FromImage(bm_dest)

        ' Copy the source image into the destination bitmap.
        gr_dest.DrawImage(bm_source, 0, 0, _
            bm_dest.Width + 1, _
            bm_dest.Height + 1)

        ' Display the result.
        Return bm_dest
    End Function

    Public Shared Function GetBrowserByGUID(aGUID As Guid) As Browser
        For Each lBrowser As Browser In gSettings.Browsers
            If lBrowser.GUID = aGUID Then
                Return lBrowser
            End If
        Next

        Return Nothing
    End Function
End Class