Imports Browser_Chooser_2.WinAPIs
Imports System.Net

Public Class BrowserUtilities
#Region "IE Open as Tab code"
    Public Shared Sub GetIE(ByVal lBrowser As Browser, ByVal aURL As String, ByVal aTerminate As Boolean)
        Logger.AddToLog("BrowserUtilities.getIE", "Starting", lBrowser.Name, aURL, aTerminate)
        'made it an option to allow user to override
        Dim lbFound As Boolean = False

        For Each lIe As SHDocVw.InternetExplorer In New SHDocVw.ShellWindows()
            'on 64bit systems, first half will NOT match
            If lIe.FullName.ToLower = lBrowser.Target.ToLower OrElse lIe.FullName.ToLower = Replace(lBrowser.Target, "\Program Files\", "\Program Files (x86)\").ToLower Then
                'good start
                Try
                    lIe.Navigate2(DirectCast(aURL, Object), BrowserNavConstants.navOpenInNewTab)
                Catch ex As Exception
                    lIe.Navigate2(DirectCast(aURL, Object), BrowserNavConstants.navOpenInNewWindow)
                End Try

                lIe.Visible = True

                SetForegroundWindow(New IntPtr(lIe.HWND))

                lbFound = True
                Exit For
            End If
        Next

        If lbFound = False Then
            Logger.AddToLog("BrowserUtilities.getIE", "IE not starting, using alternative", lBrowser.Name, aURL, aTerminate)
            DoLaunch(lBrowser, aURL, aTerminate)
        ElseIf aTerminate = True Then
            Logger.AddToLog("BrowserUtilities.getIE", "End", lBrowser.Name, aURL, aTerminate)
            GeneralUtilities.doCleanExit()
        End If
    End Sub
#End Region

    Private Shared Sub TryToBringToFront(strBrowser As String)
        Logger.AddToLog("BrowserUtilities.getIE", "TryToBringToFront", strBrowser)
        'see if we only have once process of target browser
        Try
            Dim lTarget As String = Mid(strBrowser, InStrRev(strBrowser, "\") + 1)
            'now trim out .exe
            lTarget = Left(lTarget, InStrRev(lTarget, ".") - 1)
            Dim lAllProcesses() As Process = Process.GetProcessesByName(lTarget)

            If lAllProcesses.Count = 1 Then
                'bring that one up
                'AppActivate(lAllProcesses(0).Id)
                SetForegroundWindow(lAllProcesses(0).Handle) 'will not work with chrome, but then abgain chrome has many processes

            Else
                'seach for the right window
                Dim lCandidates As New List(Of Process)
                For Each lProc As Process In lAllProcesses
                    'if it has a title, probably the process we want
                    If lProc.MainWindowTitle <> "" Then
                        lCandidates.Add(lProc)
                    End If
                Next

                If lCandidates.Count = 1 Then
                    SetForegroundWindow(lCandidates.Item(0).Handle) 'chome has only one window with a title
                Else
                    'need a better way to find the correct process, for now bail out.
                End If
            End If
        Catch ex As Exception
            Logger.AddToLog("BrowserUtilities.TryTryToBringToFront", "Failled", ex.Message)
        End Try

        Logger.AddToLog("BrowserUtilities.TryTryToBringToFront", "End", strBrowser)
    End Sub

    Private Shared Function DoLaunch(ByVal aTarget As Browser, ByVal aURL As String, ByVal aTerminate As Boolean) As Boolean
        Logger.AddToLog("BrowserUtilities.DoLaunch", "Start", aTarget.Name, aURL, aTerminate)
        'Dim strParameters As String = ""
        Dim strBrowser As String

        'hide the main form
        frmMain.Visible = False

        'find the exe, start with supplied path, if not found, try to normalize
        If My.Computer.FileSystem.FileExists(aTarget.Target) = True Then
            strBrowser = aTarget.Target
        Else
            strBrowser = NormalizeTarget(aTarget.Target)
        End If

        'use windows api to bypass permissions, may be an issue with non-admin accounts
        Dim lInfo As WinAPIs.WIN32_FILE_ATTRIBUTE_DATA
        If WinAPIs.GetFileAttributesEx(strBrowser, GET_FILEEX_INFO_LEVELS.GetFileExInfoStandard, lInfo) = True Then
            'If My.Computer.FileSystem.FileExists(strBrowser) = True Then
            Dim lProcess As Process
            If Not String.IsNullOrEmpty(aURL) Then
                If InStr(aTarget.Arguments, "{0}") > 0 Or InStr(aTarget.Arguments, "{1}") > 0 Then
                    'using replacement, new start
                    Dim lParts As URLUtilities.URLParts = URLUtilities.DetermineParts(aURL)
                    lProcess = Process.Start(strBrowser, String.Format(aTarget.Arguments, lParts.Protocol, lParts.Remainder))
                Else
                    'no replacement, old start
                    lProcess = Process.Start(strBrowser, aTarget.Arguments & " """ & aURL & """")
                End If
            Else
                lProcess = Process.Start(strBrowser, aTarget.Arguments)
            End If
            Dim lID As Integer = lProcess.Id

            Try
                lProcess.WaitForInputIdle(1000)
            Catch ex As Exception
                'do nothing
            End Try

            If lProcess.HasExited = False Then
                'bring this one foward - else we have no way to reliably know when it went
                Try
                    AppActivate(lID)
                Catch ex As Exception
                    'do nothing - this just means that the process is gone.

                    'see if we only have once process of target browser
                    TryToBringToFront(strBrowser)
                End Try
            Else
                TryToBringToFront(strBrowser)
            End If

            'End If

            If aTerminate = True Then
                lProcess = Nothing
                Logger.AddToLog("BrowserUtilities.DoLaunch", "Terminate 1", aTarget.Name, aURL, aTerminate)
                GeneralUtilities.doCleanExit()
            End If

            Return True
        ElseIf aTarget.Target = "" Then
            Logger.AddToLog("BrowserUtilities.DoLaunch", "Terminate 2", aTarget.Name, aURL, aTerminate)
            GeneralUtilities.doCleanExit()
        Else
            MessageBox.Show("Browser " & aTarget.Name & " cannot be found.", "Missing Target", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Logger.AddToLog("BrowserUtilities.DoLaunch", "Not found", aTarget.Name, aURL, aTerminate)
            Return False
        End If

        'should not get here
        MessageBox.Show("Failled to launch Browser. Please submit a bug request.", "Missing Target", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Logger.AddToLog("BrowserUtilities.DoLaunch", "Major Fail", aTarget.Name, aURL, aTerminate)
        Return False
    End Function

    Private Shared Sub StartEdge(ByVal aTarget As Browser, ByVal aURL As String, ByVal aTerminate As Boolean)
        Logger.AddToLog("BrowserUtilities.StartEdge", "Start", aTarget.Name, aURL, aTerminate)
        Dim lProcess As Process

        If Not String.IsNullOrEmpty(aURL) Then
            'no replacement, old start
            lProcess = Process.Start("microsoft-edge:" & aURL)
        Else
            lProcess = Process.Start("microsoft-edge:")
        End If
        If aTerminate = True Then
            lProcess = Nothing
            Logger.AddToLog("BrowserUtilities.StartEdge", "Terminate", aTarget.Name, aURL, aTerminate)
            GeneralUtilities.doCleanExit()
        End If

        Logger.AddToLog("BrowserUtilities.StartEdge", "End", aTarget.Name, aURL, aTerminate)
    End Sub

    Public Shared Sub LaunchBrowser(ByVal lBrowser As Browser, ByVal lURL As String, ByVal aTerminate As Boolean)
        Logger.AddToLog("BrowserUtilities.LaunchBrowser", "Start", lBrowser.Name, lURL, aTerminate)

        'special handleing for IE (surprise, surprise!)
        If lBrowser.IsIE = True Then
            GetIE(lBrowser, lURL, aTerminate) 'now get IE, but the DLL will be loaded before calling
        ElseIf lBrowser.IsEdge = True Then
            StartEdge(lBrowser, lURL, aTerminate)
        Else
            'check to see if the file exists
            'If (IO.File.Exists(target)) Or target.Contains(".exe ") Then
            If DoLaunch(lBrowser, lURL, aTerminate) = True Then
                'End If

                If aTerminate = True Then
                    Logger.AddToLog("BrowserUtilities.LaunchBrowser", "Terminate", lBrowser.Name, lURL, aTerminate)
                    GeneralUtilities.doCleanExit() 'not clean, will do for now
                End If
            End If
        End If

        Logger.AddToLog("BrowserUtilities.LaunchBrowser", "End", lBrowser.Name, lURL, aTerminate)
    End Sub

    Public Shared Function GetBrowserByGUID(aGUID As Guid) As Browser
        Logger.AddToLog("BrowserUtilities.GetBrowserByGUID", "Start", aGUID.ToString())
        For Each lBrowser As Browser In gSettings.Browsers
            If lBrowser.GUID = aGUID Then
                Logger.AddToLog("BrowserUtilities.GetBrowserByGUID", "GUID found", aGUID.ToString())
                Return lBrowser
            End If
        Next

        Logger.AddToLog("BrowserUtilities.GetBrowserByGUID", "GUID not found", aGUID.ToString())
        Return Nothing
    End Function

    Public Shared Function GetBrowserByGUID(aGUID As Guid, aSeperateList As List(Of Browser)) As Browser
        Logger.AddToLog("BrowserUtilities.GetBrowserByGUID list", "Start", aGUID.ToString())
        For Each lBrowser As Browser In aSeperateList
            If lBrowser.GUID = aGUID Then
                Logger.AddToLog("BrowserUtilities.GetBrowserByGUID list", "GUID found", aGUID.ToString())
                Return lBrowser
            End If
        Next

        Logger.AddToLog("BrowserUtilities.GetBrowserByGUID list", "GUID not found", aGUID)
        Return Nothing
    End Function

    Public Shared Function GetBrowserByGUID(aGUID As Guid, aSeperateDictionary As Dictionary(Of Integer, Browser)) As Browser
        Logger.AddToLog("BrowserUtilities.GetBrowserByGUID Dictionary", "Start", aGUID.ToString())
        For Each lBrowser As KeyValuePair(Of Integer, Browser) In aSeperateDictionary
            If lBrowser.Value.GUID = aGUID Then

                Logger.AddToLog("BrowserUtilities.GetBrowserByGUID Dictionary", "GUID found", aGUID.ToString())
                Return lBrowser.Value
            End If
        Next

        Logger.AddToLog("BrowserUtilities.GetBrowserByGUID Dictionary", "GUID Not found", aGUID.ToString())
        Return Nothing
    End Function

    Public Shared Function NormalizeTarget(ByVal target As String) As String
        Logger.AddToLog("BrowserUtilities.NormalizeTarget", "Start", target)
        ' it's possible that in portable mode you have a path to an x86 folder and are running on a 32 bit system
        ' so the strBrowser will point to an invalid browser
        If StartupLauncher.Is64Bit Then
            Dim programFiles As String = My.Computer.FileSystem.SpecialDirectories.ProgramFiles

            If (target.StartsWith(programFiles)) Then
                If (target.StartsWith(Environment.GetEnvironmentVariable("ProgramFiles(x86)")) = False) Then
                    target = target.Replace(programFiles, Environment.GetEnvironmentVariable("ProgramFiles(x86)"))
                End If
            End If
        Else
            If (target.Contains("x86")) Then
                target = target.Replace(" (x86)", "")
            End If
        End If

        Logger.AddToLog("BrowserUtilities.NormalizeTarget", "End", target)
        Return target
    End Function
End Class
