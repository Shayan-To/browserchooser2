﻿Imports Browser_Chooser_2.WinAPIs

Public Class BrowserUtilities
#Region "IE Open as Tab code"
    Public Shared Sub GetIE(ByVal lBrowser As Browser, ByVal aURL As String, ByVal aTerminate As Boolean)
        'made it an option to allow user to override
        Dim lbFound As Boolean = False

        For Each lIe As SHDocVw.InternetExplorer In New SHDocVw.ShellWindows()
            If lIe.FullName = lBrowser.Target Then
                'good start
                Try
                    lIe.Navigate2(DirectCast(aURL, Object), BrowserNavConstants.navOpenInNewTab)
                Catch ex As Exception
                    lIe.Navigate2(DirectCast(aURL, Object), BrowserNavConstants.navOpenInNewWindow)
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
        Dim strBrowser As String = NormalizeTarget(aTarget.Target)

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
            Dim lID As Integer = lProcess.Id

            lProcess.WaitForInputIdle()
            If lProcess.HasExited = False Then
                'bring this one foward - else we have no way to reliably know when it went
                Try
                    AppActivate(lID)
                Catch ex As Exception
                    'do nothing - this just means that the process is gone.
                End Try
            End If

            'End If

            If aTerminate = True Then
                lProcess = Nothing
                GeneralUtilities.doCleanExit()
            End If

            Return True
        ElseIf aTarget.Target = "" Then
            GeneralUtilities.doCleanExit()
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

    Public Shared Function GetBrowserByGUID(aGUID As Guid) As Browser
        For Each lBrowser As Browser In gSettings.Browsers
            If lBrowser.GUID = aGUID Then
                Return lBrowser
            End If
        Next

        Return Nothing
    End Function

    Public Shared Function GetBrowserByGUID(aGUID As Guid, aSeperateList As List(Of Browser)) As Browser
        For Each lBrowser As Browser In aSeperateList
            If lBrowser.GUID = aGUID Then
                Return lBrowser
            End If
        Next

        Return Nothing
    End Function

    Public Shared Function GetBrowserByGUID(aGUID As Guid, aSeperateDictionary As Dictionary(Of Integer, Browser)) As Browser
        For Each lBrowser As KeyValuePair(Of Integer, Browser) In aSeperateDictionary
            If lBrowser.Value.GUID = aGUID Then
                Return lBrowser.Value
            End If
        Next

        Return Nothing
    End Function

    Public Shared Function NormalizeTarget(ByVal target As String) As String
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

        Return target
    End Function
End Class