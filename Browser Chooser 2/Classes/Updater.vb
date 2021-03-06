Imports System.Threading

Public Class Updater
    Private Shared mThread As Thread

    Private Const UpdateFile As String = "https://browserchooser2.com/app/PublicVersion.xml"
    Private Const DebugUpdateFile As String = "https://browserchooser2.com/app/DebugPublicVersion.xml"

    Private Structure intUpdateFile
        Public id As String
        Public download As String
        Public releaseInfo As String
        Public details As String
    End Structure

    Private Shared Function GetUpdateDetails() As intUpdateFile
        Dim lPublicVersion As New intUpdateFile
        Dim lLocal As String = System.IO.Path.GetTempFileName
#If Debug = True Then
        Dim lUpdateFile As String = DebugUpdateFile
#Else
        Dim lUpdateFile As String = UpdateFile
#End If

        Try
            My.Computer.Network.DownloadFile(lUpdateFile, lLocal, "", "", False, 5000, True)

            'read the file
            Dim lStream As System.IO.StreamReader = My.Computer.FileSystem.OpenTextFileReader(lLocal)
            Dim lContents As String = lStream.ReadToEnd
            lStream.Close()
            My.Computer.FileSystem.DeleteFile(lLocal) ' we don't need it anymore

            'parse the file
            Dim lXML As New Xml.XmlDocument
            lXML.LoadXml(lContents)
            Dim lNode As Xml.XmlNode = lXML.SelectSingleNode("versionInfo")
            For Each lChild As Xml.XmlNode In lNode.ChildNodes
                'parse the children
                Select Case lChild.Name.ToLower
                    Case "id"
                        lPublicVersion.id = lChild.InnerText
                    Case "download"
                        lPublicVersion.download = lChild.InnerText
                    Case "releaseinfo"
                        lPublicVersion.releaseInfo = lChild.InnerText
                    Case "details"
                        lPublicVersion.details = lChild.InnerText
                End Select
            Next
        Catch ex As Exception
            ' auto-update failed
            Return Nothing
        End Try
        Return lPublicVersion
    End Function

    Public Shared Sub WaitForProcessToExit(ByVal aProcName As String)
        For Each lProc As Process In Process.GetProcesses()
            Try
                If lProc.MainModule.ModuleName.ToLower = aProcName.ToLower Then
                    lProc.WaitForExit()
                End If
            Catch
            End Try
        Next
    End Sub

    Public Shared Sub FinishApplyUpdate()
#If CONFIG = "Debug Update" Then
        MessageBox.Show("Debug stop: FinishApplyUpdate")
#End If
        WaitForProcessToExit(My.Application.Info.AssemblyName & ".exe.new.exe")
        My.Computer.FileSystem.DeleteFile(Application.ExecutablePath & ".new.exe")
    End Sub

    Public Shared Sub ApplyUpdate(ByVal aURL As String)
        Dim lFileName As String = Left(Application.ExecutablePath, Application.ExecutablePath.Length - ".new.exe".Length)
#If CONFIG = "Debug Update" Then
        MessageBox.Show("Debug stop: ApplyUpdate")
#End If
        WaitForProcessToExit(My.Application.Info.AssemblyName & ".exe")
        My.Computer.FileSystem.DeleteFile(lFileName, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
        My.Computer.FileSystem.CopyFile(Application.ExecutablePath, lFileName)

        'restart proc again - almost done!
        GeneralUtilities.LaunchUserMode(GeneralUtilities.ListOfCommands.FinishApplyUpdate, aURL, lFileName, False)

        'this process needs to exit
        Application.Exit()
    End Sub

    Public Shared Sub DoUpdate()
        'actually download update and perform it, it's a 2 part process
        Dim lPublicVersion As intUpdateFile = GetUpdateDetails()

        '#If CONFIG = "Debug Update" Then
        '        'special debug mode -> copy this file to .new.exe and restart

        '        My.Computer.FileSystem.CopyFile(Application.ExecutablePath, Application.ExecutablePath & ".new.exe")
        '#Else

        'ideally, we hide the main form. but we are in a threaded enviroment and does not work the same.
        'will need to invoke a method on the main form.
        'Dim lWasEnabled As Boolean
        'Dim lForm As Form = Nothing
        'Dim lTmrControl As System.Windows.Forms.Timer = Nothing
        'For Each lSearchForm As Form In Application.OpenForms
        '    If lSearchForm.Name = "frmMain" Then
        '        lForm = lSearchForm

        '        'now find the timer objecty
        '        For Each lControl As System.Windows.Forms.Control In lForm.Controls
        '            If lControl.Name = "tmrTimer" Then
        '                'seems like timer does not behanve as a normal control
        '                lWasEnabled = lControl.Enabled
        '                lControl.Enabled = False

        '                Exit For
        '            End If
        '        Next

        '        'lWasEnabled = lForm.Controls.Item("tmrDelay").Enabled
        '        'lForm.Controls.Item("tmrDelay").Enabled = False
        '        lForm.Visible = False

        '        Exit For
        '    End If
        'Next
        
        Try
            My.Computer.Network.DownloadFile(lPublicVersion.download, Application.ExecutablePath & ".new.exe", "", "", True, 60000, True, FileIO.UICancelOption.ThrowException)
            '#End If

            GeneralUtilities.LaunchUserMode(GeneralUtilities.ListOfCommands.ApplyUpdate, StartupLauncher.URL, Application.ExecutablePath & ".new.exe", False)

            'this process needs to exit
            Application.Exit()
        Catch ex As System.OperationCanceledException

            'lForm.Controls.Item("tmrDelay").Enabled = lWasEnabled
            'lForm.Visible = True
        End Try

    End Sub

    Private Shared Function askForUpdate() As Boolean
        Dim lPublicVersion As intUpdateFile = GetUpdateDetails()

        If IsNothing(lPublicVersion.id) = False Then
            If lPublicVersion.id <> CurVersion Then
                'build an do you want to update dialog box
                Dim lResult As DialogResult
                Dim lOut As String = "An update to Browser Chooser 2 is available!" & Environment.NewLine & _
                    "Do you want to download and apply this update?" & Environment.NewLine & _
                    "Press Cancel to turn off update notification." & Environment.NewLine & _
                    Environment.NewLine & _
                    "Your version: " & CurVersion + Environment.NewLine & _
                    "Available version: " & lPublicVersion.id & Environment.NewLine & _
                    Environment.NewLine & _
                    "Details: " & lPublicVersion.details

                lResult = MessageBox.Show(lOut, "Download update?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If lResult = DialogResult.Yes Then
                    Return True
                    'ElseIf lResult = DialogResult.Cancel Then
                    'gSettings.AutomaticUpdates = False
                    'gSettings.DoSave(True)

                    'Return False
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Private Shared Sub doCheckForUpdate()
        If askForUpdate() = True Then
            DoUpdate()
        End If
    End Sub

    Public Shared Sub CheckForUpdate(ByVal aThreaded As Boolean)
        If aThreaded = False Then
            doCheckForUpdate() ' self containned
        Else
            'create a thead
            Dim lStart As New ThreadStart(AddressOf doCheckForUpdate)

            mThread = New Thread(lStart)
            mThread.Start()
        End If
    End Sub
End Class
