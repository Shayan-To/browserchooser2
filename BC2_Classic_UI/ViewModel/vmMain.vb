Imports System.IO
Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Windows

Public Class vmMain
    ''' <summary>
    ''' Handles all of the logic and the connection to the settings file. 
    ''' </summary>
    Private WithEvents mfrmMain As frmMain
    Private msCurrentText As String
    Private mSettings As RelevantSettings

    Public Structure RelevantSettings
        Public BackgroundColor As Integer
        Public UseAreo As Boolean 'classic only
        Public IsAeroEnabled As Boolean 'classic only
        Public DefaultMessage As String
        Public ShowURL As String
        Public Seperator As String
        Public Browsers As List(Of SimplefiedBrowser)
        Public Width As Integer
        Public Height As Integer
        Public URL As String 'wrong type?
        Public IconHeight As Integer
        Public IconWidth As Integer
        Public IconGapWidth As Integer
        Public IconGapHeight As Integer
        Public ShowFocus As Boolean
    End Structure

    Public Sub frmMain(aSettings As Browser_Chooser_Core.Settings, aURL As String)
        Dim lRelevantSettings As New RelevantSettings

        With lRelevantSettings
            .BackgroundColor = aSettings.BackgroundColor
            .UseAreo = aSettings.UseAreo
            .IsAeroEnabled = Browser_Chooser_Core.GeneralUtilities.IsAeroEnabled()
            .DefaultMessage = aSettings.DefaultMessage
            .ShowURL = aSettings.ShowURL
            .Seperator = aSettings.Seperator

            For Each lBrowser As Browser_Chooser_Core.Browser In aSettings.Browsers
                .Browsers.Add(New SimplefiedBrowser(lBrowser.PosX, lBrowser.PosY, lBrowser.Name, lBrowser.Hotkey))

            Next

            .Width = aSettings.Width
            .Height = aSettings.Height
            .URL = aURL
            .IconHeight = aSettings.IconHeight
            .IconWidth = aSettings.IconWidth
            .IconGapHeight = aSettings.IconGapHeight
            .IconGapWidth = aSettings.IconGapWidth
            .ShowFocus = aSettings.ShowFocus
        End With

        mSettings = lRelevantSettings

        'set up the form
        mfrmMain = New frmMain
        mfrmMain.Settings = mSettings
        mfrmMain.InitializeMain()

        'non ui related code
        AddHandler mfrmMain.btnCopyToClipboard.Click, AddressOf btnCopyToClipboard_Click
        AddHandler mfrmMain.btnCopyToClipboardAndClose.Click, AddressOf btnCopyToClipboardAndClose_Click

    End Sub

    Private Sub btnCopyToClipboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If mSettings.URL <> "" Then
            Clipboard.SetText(mSettings.URL)
        End If
    End Sub

    Private Sub btnCopyToClipboardAndClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If mSettings.URL <> "" Then
            Clipboard.SetText(mSettings.URL)

            End 'need better
        End If
    End Sub

#Region "Focus Handeling Functions"
    Protected Function frmMain_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) As Boolean Handles mfrmMain.KeyUp
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Tab Then
            'move the focus around
            e.SuppressKeyPress = True
            e.Handled = True
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub HandleGotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'get the referenced object
        Dim lTitle As String = mSettings.DefaultMessage 'fallback

        If DirectCast(sender, Button).Tag Is Nothing Then
            lTitle = DirectCast(sender, Button).AccessibleName
            msCurrentText = lTitle
        Else
            Dim lBrowser As SimplefiedBrowser = mSettings.Browsers(CInt(DirectCast(sender, Button).Tag))
            msCurrentText = "Open " & lBrowser.Name

            If mSettings.ShowURL = True Then
                lTitle = msCurrentText & mSettings.Seperator & mSettings.URL
            Else
                lTitle = msCurrentText
            End If
        End If

        mfrmMain.Text = Mid(lTitle, 1, 256)
    End Sub

    Public Sub HandleLostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        msCurrentText = mSettings.DefaultMessage
        If mSettings.ShowURL = True Then
            If msCurrentText = "" Then
                mfrmMain.Text = Mid(mSettings.URL, 1, 256)
            Else
                mfrmMain.Text = Mid(msCurrentText & mSettings.Seperator & mSettings.URL, 1, 256)
            End If

        Else
            mfrmMain.Text = Mid(msCurrentText, 1, 256)
        End If
    End Sub

    Public Sub HandleActivated(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim lBrowser As SimplefiedBrowser = mSettings.Browsers(CInt(DirectCast(sender, Button).Tag))

        If (My.Computer.Keyboard.CtrlKeyDown) And (e.Button = System.Windows.Forms.MouseButtons.Left) Then
            BrowserUtilities.LaunchBrowser(lBrowser, mSettings.URL, True)
        ElseIf (e.Button = System.Windows.Forms.MouseButtons.Left) Then
            If chkAutoClose.Checked = True Then
                BrowserUtilities.LaunchBrowser(lBrowser, mSettings.URL, True)
            Else
                BrowserUtilities.LaunchBrowser(lBrowser, mSettings.URL, False)
            End If
        End If
    End Sub

    Private Sub HandleKeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim lBrowser As SimplefiedBrowser = mSettings.Browsers(CInt(DirectCast(sender, Button).Tag))

        If (e.KeyCode = Keys.Enter) Then
            If mfrmMain.chkAutoClose.Checked = True Then
                BrowserUtilities.LaunchBrowser(lBrowser, mSettings.URL, True)
            Else
                BrowserUtilities.LaunchBrowser(lBrowser, mSettings.URL, False)
            End If
        End If
    End Sub
#End Region
End Class
