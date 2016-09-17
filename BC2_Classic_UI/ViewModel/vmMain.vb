Imports System.IO
Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Windows
Imports BC2ClassicUI.Utility.LoopMath
Imports Browser_Chooser_Core

Public Class vmMain
    Implements Browser_Chooser_Core.ILoggingSupported

    ''' <summary>
    ''' Handles all of the logic and the connection to the settings file. 
    ''' </summary>
    Private WithEvents mfrmMain As frmMain
    Private msCurrentText As String
    Private mSettings As SimplefiedSettings


    Public Sub frmMain(aSettings As Browser_Chooser_Core.Settings, aStartUpDetails As Browser_Chooser_Core.StartupLauncher)
        'Start Log
        Browser_Chooser_Core.Logger.AddToLog(Me, "frmMain", "Enter sub", aSettings, aStartUpDetails)
        'End Log

        Dim lRelevantSettings As SimplefiedSettings = aSettings

        With lRelevantSettings
            .IsAeroEnabled = Browser_Chooser_Core.GeneralUtilities.IsAeroEnabled()
            .URL = aStartUpDetails.URL
            .Delay = aStartUpDetails.Delay
            .DefaultBrowser = aStartUpDetails.Browser
            .HasAero = mSettings.IsAeroEnabled And mSettings.UseAreo
        End With

        mSettings = lRelevantSettings

        'set up the form
        mfrmMain = New frmMain
        mfrmMain.Settings = mSettings
        mfrmMain.InitializeMain(AddressOf HandleGotFocus, AddressOf HandleLostFocus, AddressOf HandleKeyUp, AddressOf HandleArrowKeyUp, AddressOf HandleActivated)

        'non ui related code
        AddHandler mfrmMain.btnCopyToClipboard.Click, AddressOf btnCopyToClipboard_Click
        AddHandler mfrmMain.btnCopyToClipboardAndClose.Click, AddressOf btnCopyToClipboardAndClose_Click
        AddHandler mfrmMain.btnInfo.Click, AddressOf btnInfo_Click
        AddHandler mfrmMain.btnCancel.Click, AddressOf btnCancel_Click
        AddHandler mfrmMain.btnOptions.Click, AddressOf btnOptions_Click
        AddHandler mfrmMain.tmrDelay.Tick, AddressOf tmrDelay_Tick

        'Start Log
        Browser_Chooser_Core.Logger.AddToLog(Me, "frmMain", "Exit sub")
        'End Log
    End Sub

    Private Sub btnCopyToClipboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Start Log
        Browser_Chooser_Core.Logger.AddToLog(Me, "btnCopyToClipboard_Click", "Enter sub", sender, e)
        'End Log

        If mSettings.URL <> "" Then
            Clipboard.SetText(mSettings.URL)
        End If

        'Start Log
        Browser_Chooser_Core.Logger.AddToLog(Me, "btnCopyToClipboard_Click", "Exit sub", sender, e)
        'End Log
    End Sub

    Private Sub btnCopyToClipboardAndClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Start Log
        Browser_Chooser_Core.Logger.AddToLog(Me, "btnCopyToClipboardAndClose_Click", "Enter sub", sender, e)
        'End Log

        If mSettings.URL <> "" Then
            Clipboard.SetText(mSettings.URL)

            End 'need better
        End If

        'Start Log
        Browser_Chooser_Core.Logger.AddToLog(Me, "btnCopyToClipboardAndClose_Click", "Exit sub", sender, e)
        'End Log
    End Sub

    Private Delegate Sub SetTextCallback(ByVal aURL As String)
    Public Sub UpdateURL(ByVal aURL As String)
        'should only have one
        If mSettings.ShowURL = True Then
            Dim lText As String
            If msCurrentText = "" Then
                lText = mSettings.URL
            Else
                lText = msCurrentText & mSettings.Seperator & mSettings.URL
            End If


            'make sure thread safe first
            If mfrmMain.InvokeRequired Then
                Dim d As New SetTextCallback(AddressOf UpdateURL)
                mfrmMain.Invoke(d, New Object() {aURL})
            Else
                mfrmMain.Text = Mid(lText, 1, 256)
            End If
        End If
    End Sub

#Region "Focus Handeling Functions"
    Protected Function frmMain_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) As Boolean Handles mfrmMain.KeyUp
        'Start Log
        Browser_Chooser_Core.Logger.AddToLog(Me, "frmMain_KeyUp", "Enter sub", sender, e)
        'End Log

        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Tab Then
            'move the focus around
            e.SuppressKeyPress = True
            e.Handled = True
            Return True
        Else
            Return False
        End If

        'Start Log
        Browser_Chooser_Core.Logger.AddToLog(Me, "frmMain_KeyUp", "Exit sub", sender, e)
        'End Log
    End Function

    Public Sub HandleGotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Start Log
        Browser_Chooser_Core.Logger.AddToLog(Me, "HandleGotFocus", "Enter sub", sender, e)
        'End Log

        'get the referenced object
        Dim lTitle As String = mSettings.DefaultMessage 'fallback

        If DirectCast(sender, Button).Tag Is Nothing Then
            lTitle = DirectCast(sender, Button).AccessibleName
            msCurrentText = lTitle
        Else
            Dim lBrowser As Browser_Chooser_Core.Browser = mSettings.Browsers(CInt(DirectCast(sender, Button).Tag))
            msCurrentText = "Open " & lBrowser.Name

            If mSettings.ShowURL = True Then
                lTitle = msCurrentText & mSettings.Seperator & mSettings.URL
            Else
                lTitle = msCurrentText
            End If
        End If

        mfrmMain.Text = Mid(lTitle, 1, 256)

        'Start Log
        Browser_Chooser_Core.Logger.AddToLog(Me, "HandleGotFocus", "Exit sub", sender, e)
        'End Log
    End Sub

    Public Sub HandleLostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Start Log
        Browser_Chooser_Core.Logger.AddToLog(Me, "HandleLostFocus", "Enter sub", sender, e)
        'End Log

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

        'Start Log
        Browser_Chooser_Core.Logger.AddToLog(Me, "HandleLostFocus", "Exit sub", sender, e)
        'End Log
    End Sub

    Public Sub HandleActivated(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        'Start Log
        Browser_Chooser_Core.Logger.AddToLog(Me, "HandleActivated", "Enter sub", sender, e)
        'End Log

        Dim lBrowser As Browser_Chooser_Core.Browser = mSettings.Browsers(CInt(DirectCast(sender, Button).Tag))

        If (My.Computer.Keyboard.CtrlKeyDown) And (e.Button = System.Windows.Forms.MouseButtons.Left) Then
            BrowserUtilities.LaunchBrowser(lBrowser, mSettings.URL, True)
        ElseIf (e.Button = System.Windows.Forms.MouseButtons.Left) Then
            If mfrmMain.chkAutoClose.Checked = True Then
                BrowserUtilities.LaunchBrowser(lBrowser, mSettings.URL, True)
            Else
                BrowserUtilities.LaunchBrowser(lBrowser, mSettings.URL, False)
            End If
        End If

        'Start Log
        Browser_Chooser_Core.Logger.AddToLog(Me, "HandleActivated", "Exit sub", sender, e)
        'End Log
    End Sub

    Private Sub HandleKeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        'Start Log
        Browser_Chooser_Core.Logger.AddToLog(Me, "HandleKeyUp", "Enter sub", sender, e)
        'End Log

        Dim lBrowser As Browser_Chooser_Core.Browser = mSettings.Browsers(CInt(DirectCast(sender, Button).Tag))

        If (e.KeyCode = Keys.Enter) Then
            If mfrmMain.chkAutoClose.Checked = True Then
                BrowserUtilities.LaunchBrowser(lBrowser, mSettings.URL, True)
            Else
                BrowserUtilities.LaunchBrowser(lBrowser, mSettings.URL, False)
            End If
        End If

        'Start Log
        Browser_Chooser_Core.Logger.AddToLog(Me, "HandleKeyUp", "Exit sub", sender, e)
        'End Log
    End Sub

    Private Sub HandleArrowKeyUp(ByVal sender As Object, ByVal KeyData As System.Windows.Forms.Keys) 'Handles btnAppStub.ArrowKeyUp
        'Start Log
        Browser_Chooser_Core.Logger.AddToLog(Me, "HandleArrowKeyUp", "Enter sub", sender, KeyData)
        'End Log

        'moves the focus around the buttons - looping around
        Dim lBrowser As Browser_Chooser_Core.Browser = mSettings.Browsers(CInt(DirectCast(sender, FFButton).Tag))
        Debug.Print(lBrowser.PosX & " .. " & lBrowser.PosY)

        Dim lCurPoX As Integer = lBrowser.PosX
        Dim lCurPoY As Integer = lBrowser.PosY
        Dim lData As Integer
        Dim lbFoundBrowser As Browser_Chooser_Core.Browser = Nothing
        Dim lIndex As Integer

        Select Case KeyData
            Case Keys.Up
                'naively look up for the next avilable box, until we hit ourselves
                lData = lCurPoY
                Do
                    lData = MinusLoop(lData, mSettings.Height)

                    'scan for a button at that position
                    lIndex = 0
                    For Each mBrowser As Browser_Chooser_Core.Browser In mSettings.Browsers
                        lIndex += 1
                        If mBrowser.PosY = lData And mBrowser.PosX = lCurPoX Then

                            lbFoundBrowser = mBrowser
                            lCurPoY = lData
                            Exit Do
                        End If
                    Next
                Loop Until lData = lBrowser.PosY
            Case Keys.Down
                'naively look up for the next avilable box, until we hit ourselves
                lData = lCurPoY
                Do
                    lData = AddLoop(lData, mSettings.Height)

                    'scan for a button at that position
                    lIndex = 0
                    For Each mBrowser As Browser_Chooser_Core.Browser In mSettings.Browsers
                        lIndex += 1
                        If mBrowser.PosY = lData And mBrowser.PosX = lCurPoX Then

                            lbFoundBrowser = mBrowser
                            lCurPoY = lData
                            Exit Do
                        End If
                    Next
                Loop Until lData = lBrowser.PosY
            Case Keys.Left
                'naively look up for the next avilable box, until we hit ourselves
                lData = lCurPoX
                Do
                    lData = MinusLoop(lData, mSettings.Width)

                    'scan for a button at that position
                    lIndex = 0
                    For Each mBrowser As Browser_Chooser_Core.Browser In mSettings.Browsers
                        lIndex += 1
                        If mBrowser.PosY = lCurPoY And mBrowser.PosX = lData Then

                            lbFoundBrowser = mBrowser
                            lCurPoX = lData
                            Exit Do
                        End If
                    Next
                Loop Until lData = lBrowser.PosX
            Case Keys.Right
                'naively look up for the next avilable box, until we hit ourselves
                lData = lCurPoX
                Do
                    lData = AddLoop(lData, mSettings.Width)

                    'scan for a button at that position
                    lIndex = 0
                    For Each mBrowser As Browser_Chooser_Core.Browser In mSettings.Browsers
                        lIndex += 1
                        If mBrowser.PosY = lCurPoY And mBrowser.PosX = lData Then

                            lbFoundBrowser = mBrowser
                            lCurPoX = lData
                            Exit Do
                        End If
                    Next
                Loop Until lData = lBrowser.PosX
        End Select

        If IsNothing(lbFoundBrowser) = False Then
            'move focus
            DirectCast(sender, FFButton).TabStop = False

            'find new button

            For Each lButton As Control In mfrmMain.Controls
                If TypeOf (lButton) Is FFButton Then

                    If CInt(lButton.Tag) = lIndex - 1 Then 'i need a better system for this
                        lButton.Focus()
                        lButton.TabStop = True
                    End If


                End If
            Next
        End If

        'Start Log
        Browser_Chooser_Core.Logger.AddToLog(Me, "HandleArrowKeyUp", "Exit sub", sender, KeyData)
        'End Log
    End Sub
#End Region

#Region "Handlers to go to other dialogs"
    Private Sub btnInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Start Log
        Browser_Chooser_Core.Logger.AddToLog(Me, "btnInfo_Click", "Enter sub", sender, e)
        'End Log

        'frmAbout.ShowDialog()

        'Start Log
        Browser_Chooser_Core.Logger.AddToLog(Me, "btnInfo_Click", "Exit sub", sender, e)
        'End Log
    End Sub

    Private Sub btnOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Start Log
        Browser_Chooser_Core.Logger.AddToLog(Me, "btnOptions_Click", "Enter sub", sender, e)
        'End Log

        'OpenOptions()

        'Start Log
        Browser_Chooser_Core.Logger.AddToLog(Me, "btnOptions_Click", "Exit sub", sender, e)
        'End Log
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Start Log
        Browser_Chooser_Core.Logger.AddToLog(Me, "btnCancel_Click", "Enter sub", sender, e)
        'End Log

        ' Me.Close() -- need to go to a proper shutdown function

        'Start Log
        Browser_Chooser_Core.Logger.AddToLog(Me, "btnCancel_Click", "Exit sub", sender, e)
        'End Log
    End Sub
#End Region

#Region "Timer functions"
    Private Sub tmrDelay_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Start Log
        Browser_Chooser_Core.Logger.AddToLog(Me, "tmrDelay_Tick", "Enter sub", sender, e)
        'End Log

        Static lCurTimer As Integer = mSettings.Delay

        'count down
        lCurTimer -= 1

        If lCurTimer > 0 Then
            Dim lText As String = String.Format("Automatically open {0} in {1} seconds.", mSettings.DefaultBrowser.Name, lCurTimer)
            If mSettings.HasAero = True And mSettings.AccessibleRendering = False Then
                mfrmMain.chkAutoOpen.Tag = lText
                mfrmMain.Invalidate()
            Else
                mfrmMain.Text = lText
            End If
        Else
            mfrmMain.tmrDelay.Enabled = False

            Dim lText As String = String.Format("Automatically opening {0}.", mSettings.DefaultBrowser.Name)
            If mSettings.HasAero = True And mSettings.AccessibleRendering = False Then
                mfrmMain.chkAutoOpen.Tag = lText
                mfrmMain.chkAutoOpen.Invalidate()
            Else
                mfrmMain.chkAutoOpen.Text = lText
            End If

            DoLaunch(mSettings.DefaultBrowser)
        End If

        'Start Log
        Browser_Chooser_Core.Logger.AddToLog(Me, "tmrDelay_Tick", "Exit sub", sender, e)
        'End Log
    End Sub
#End Region
    ''' <summary>
    '''  does not belong here - should be in core
    ''' </summary>
    ''' <param name="lBrowser"></param>
    Private Sub DoLaunch(ByVal lBrowser As Browser)
        'Start Log
        Browser_Chooser_Core.Logger.AddToLog(Me, "DoLaunch", "Enter sub", lBrowser)
        'End Log

        BrowserUtilities.LaunchBrowser(lBrowser, mSettings.URL, mfrmMain.chkAutoClose.Checked) 'to do, add if control is pressed, do not close

        'Start Log
        Browser_Chooser_Core.Logger.AddToLog(Me, "DoLaunch", "Exit sub", lBrowser)
        'End Log
    End Sub

    Public Function FriendlyName() As String Implements ILoggingSupported.FriendlyName
        Return "Classic vmMain"
    End Function
End Class
