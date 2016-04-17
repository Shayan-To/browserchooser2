Imports System.IO
Imports System.ComponentModel
Imports System.Drawing.Drawing2D

Public Class frmMain
    Private mFirstButton As FFButton 'transitory reference
    Private mHasAero As Boolean
    Private mOldWidth As Integer 'for better looks
    Private mOldHeight As Integer 'for better looks
    Private mCurDelay As Integer
    Private msCurrentText As String
    '    Private mURL As String

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        If mHasAero = False Then
            'note that the border still looks off but the display is much improved
            Using br As New LinearGradientBrush(Me.DisplayRectangle, _
                                                Color.FromArgb(185, 209, 234), Color.FromArgb(132, 151, 173), _
                                                LinearGradientMode.Vertical)
                e.Graphics.FillRectangle(br, Me.DisplayRectangle)
            End Using
        ElseIf mHasAero = True And gSettings.BackgroundColor <> Color.Transparent.ToArgb() Then
            '      'Composition disabled; fake it like Microsoft does
            '      Dim clFakeGlassColor As Integer = &HEAD1B9 ' //(185, 209, 234) This is the fake foreground glass color (for use when composition is disabled)
            '      Dim clFakeGlassColorUnfocused As Integer = &HF2E4D7 ' //(215, 228, 242) This is the fake background glass color (for use when composition is disabled)
            '      'The color to use depends if the form has focused or not
            '      Dim glassColor As SolidBrush
            '      If Me.Focused = True Then
            '          glassColor = New SolidBrush(Color.FromArgb(gSettings.BackgroundColor))
            '      Else
            '          glassColor = New SolidBrush(Color.FromArgb(clFakeGlassColorUnfocused))
            '      End If

            '      e.Graphics.FillRectangle(glassColor, Me.DisplayRectangle) ' //fill rectangle with fake color


            '      'Now we have to draw the two accent lines along the bottom.


            '      Dim edgeHighlight As Color = ColorBlend(Color.White, glassColor, 0.33) '//mix 33% of glass color to white
            '      dim edgeShadow as Color =new ColorBlend(Color.Black, glassColor, 0.33); //mix 33% of glass color to black

            '//Draw highlight as 2nd-last row:
            'g.DrawLine(edgeHighlight, Point(r.Left, r.Bottom-2), Point(r.Right, r.Bottom-2);

            '//Draw shadow on the very last row:
            'g.DrawLine(edgeHighlight, Point(r.Left, r.Bottom-1), Point(r.Right, r.Bottom-1);

            End If

        MyBase.OnPaint(e)

    End Sub

    Private Sub styleXP()
        'TODO: DETERMINE WHAT BACKGROUND OR AERO STYLE TO USE - OR MAKE IT AN OPTION
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
        Me.chkAutoClose.BackColor = Color.Transparent
        Me.chkAutoOpen.BackColor = Color.Transparent
    End Sub

    Protected Function frmMain_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) As Boolean Handles Me.KeyUp
        Debug.Print(e.KeyCode.ToString)
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Tab Then
            'move the focus around
            Debug.Print("hi3")
            e.SuppressKeyPress = True
            e.Handled = True
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mHasAero = GeneralUtilities.IsAeroEnabled() And gSettings.UseAreo
        If mHasAero = True And gSettings.BackgroundColor = Color.Transparent.ToArgb Then
            GeneralUtilities.MakeFormGlassy(Me)
        Else
            'fake it
        End If

        InitializeMain()

        If Not mHasAero Then
            styleXP()
        End If
    End Sub

    Public Sub HandleGotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInfo.MouseEnter, btnInfo.MouseHover, btnInfo.GotFocus, btnOptions.MouseEnter, btnOptions.MouseHover, btnOptions.GotFocus, btnCopyToClipboard.MouseHover, btnCopyToClipboard.GotFocus, btnCopyToClipboardAndClose.MouseHover, btnCopyToClipboardAndClose.GotFocus
        'get the referenced object
        Dim lTitle As String = gSettings.DefaultMessage 'fallback

        If DirectCast(sender, Button).Tag Is Nothing Then
            lTitle = DirectCast(sender, Button).AccessibleName
            msCurrentText = lTitle
        Else
            Dim lBrowser As Browser = gSettings.Browsers(CInt(DirectCast(sender, Button).Tag))
            msCurrentText = "Open " & lBrowser.Name

            If gSettings.ShowURL = True Then
                lTitle = msCurrentText & gSettings.Seperator & StartupLauncher.URL
            Else
                lTitle = msCurrentText
            End If
        End If

        Me.Text = Mid(lTitle, 1, 256)
    End Sub

    Public Sub HandleLostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInfo.MouseLeave, btnInfo.LostFocus, btnOptions.MouseLeave, btnOptions.LostFocus, btnCopyToClipboard.LostFocus, btnCopyToClipboard.MouseLeave, btnCopyToClipboardAndClose.MouseLeave, btnCopyToClipboardAndClose.LostFocus
        msCurrentText = gSettings.DefaultMessage
        If gSettings.ShowURL = True Then
            If msCurrentText = "" Then
                Me.Text = Mid(StartupLauncher.URL, 1, 256)
            Else
                Me.Text = Mid(msCurrentText & gSettings.Seperator & StartupLauncher.URL, 1, 256)
            End If

        Else
            Me.Text = Mid(msCurrentText, 1, 256)
        End If
    End Sub

    Public Sub HandleActivated(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim lBrowser As Browser = gSettings.Browsers(CInt(DirectCast(sender, Button).Tag))

        If (My.Computer.Keyboard.CtrlKeyDown) And (e.Button = Windows.Forms.MouseButtons.Left) Then
            BrowserUtilities.LaunchBrowser(lBrowser, StartupLauncher.URL, True)
        ElseIf (e.Button = Windows.Forms.MouseButtons.Left) Then
            If chkAutoClose.Checked = True Then
                BrowserUtilities.LaunchBrowser(lBrowser, StartupLauncher.URL, True)
            Else
                BrowserUtilities.LaunchBrowser(lBrowser, StartupLauncher.URL, False)
            End If
        End If
    End Sub

    Private Sub AlignScreenToUserSettings()
        Dim lPosition As Settings.AvailableStartingPositions = DirectCast(gSettings.StartingPosition, Settings.AvailableStartingPositions)
        Select Case lPosition
            Case Settings.AvailableStartingPositions.CenterScreen
                Dim lCurScreen As Screen = Screen.FromPoint(Me.Location) 'should it pop-up in a seperate screen
                Me.Top = CInt((lCurScreen.WorkingArea.Height - Me.Height) / 2 + lCurScreen.WorkingArea.Location.Y)
                Me.Left = CInt((lCurScreen.WorkingArea.Width - Me.Width) / 2 + lCurScreen.WorkingArea.Location.X)
            Case Settings.AvailableStartingPositions.XY
                Me.Top = gSettings.OffsetY
                Me.Left = gSettings.OffsetX
            Case Settings.AvailableStartingPositions.TopLeft
                Me.Top = My.Computer.Screen.Bounds.Top
                Me.Left = My.Computer.Screen.Bounds.Left
            Case Settings.AvailableStartingPositions.TopRight
                Me.Top = My.Computer.Screen.Bounds.Top
                Me.Left = My.Computer.Screen.Bounds.Right - Me.Width
            Case Settings.AvailableStartingPositions.BottomLeft
                Me.Top = My.Computer.Screen.Bounds.Bottom - Me.Height
                Me.Left = My.Computer.Screen.Bounds.Left
            Case Settings.AvailableStartingPositions.BottomRight
                Me.Top = My.Computer.Screen.Bounds.Bottom - Me.Height
                Me.Left = My.Computer.Screen.Bounds.Right - Me.Width
            Case Settings.AvailableStartingPositions.OffsetTopLeft
                Me.Top = My.Computer.Screen.Bounds.Top + gSettings.OffsetY
                Me.Left = My.Computer.Screen.Bounds.Left + gSettings.OffsetX
            Case Settings.AvailableStartingPositions.OffsetTopRight
                Me.Top = My.Computer.Screen.Bounds.Top + gSettings.OffsetY
                Me.Left = My.Computer.Screen.Bounds.Right - Me.Width + gSettings.OffsetX
            Case Settings.AvailableStartingPositions.OffsetBottomLeft
                Me.Top = My.Computer.Screen.Bounds.Bottom - Me.Height + gSettings.OffsetY
                Me.Left = My.Computer.Screen.Bounds.Left + gSettings.OffsetX
            Case Settings.AvailableStartingPositions.OffsetBottomRight
                Me.Top = My.Computer.Screen.Bounds.Bottom - Me.Height + gSettings.OffsetY
                Me.Left = My.Computer.Screen.Bounds.Right - Me.Width + gSettings.OffsetX
            Case Else 'default to center screen
                Dim lCurScreen As Screen = Screen.FromPoint(Me.Location) 'should it pop-up in a seperate screen
                Me.Top = CInt((lCurScreen.WorkingArea.Height - Me.Height) / 2 + lCurScreen.WorkingArea.Location.Y)
                Me.Left = CInt((lCurScreen.WorkingArea.Width - Me.Width) / 2 + lCurScreen.WorkingArea.Location.X)
        End Select

    End Sub

    Public Sub InitializeMain()
        'build array of icons as specifyed

        'calculate the amount of buttons required
        Dim lMax As Integer = gSettings.Width * gSettings.Height
        If gSettings.Browsers.Count > lMax Then
            lMax = gSettings.Browsers.Count
        End If

        'overflow protection provided by enforeced maximums.
        Dim lControls(lMax) As FFButton
        Dim lTooltips(lMax) As ToolTip
        Dim lIndex As Integer = 0
        Dim lBrowser As Browser
        Dim lToolTipText As String = ""

        'set size of stub to chosen selection
        btnAppStub.Height = gSettings.IconHeight
        btnAppStub.Width = gSettings.IconWidth

        'resize form to fit x and y
        Dim lSpaceX As Integer = (btnAppStub.Width + gSettings.IconGapWidth) * gSettings.Width
        Me.Width = lSpaceX + (btnAppStub.Left * 2)

        Dim lSpaceY As Integer = (btnAppStub.Height + gSettings.IconGapHeight) * gSettings.Height
        Dim lBorderSpace As Integer = Me.Height - chkAutoClose.Height - chkAutoClose.Top
        Me.Height = lSpaceY + chkAutoClose.Height + lBorderSpace + 6 '6 gives just enough space for the custom focus box

        'set on screen colors
        If mHasAero = False And gSettings.BackgroundColor = Color.Transparent.ToArgb Then
            'Me.BackColor = Color.Transparent
        ElseIf gSettings.BackgroundColor <> Color.Transparent.ToArgb Then
            Me.BackColor = Color.FromArgb(gSettings.BackgroundColor)
            chkAutoOpen.BackColor = Color.FromArgb(gSettings.BackgroundColor)
            chkAutoClose.BackColor = Color.FromArgb(gSettings.BackgroundColor)
        End If

        'create controls, they are added in order from browser file, with support for x y addressing
        For Each lBrowser In gSettings.Browsers
            'ensure the position is valid and item should be visible
            If Not (lBrowser.PosX < 1 Or lBrowser.PosY < 1 Or lBrowser.PosX > gSettings.Width Or lBrowser.PosY > gSettings.Height) And lBrowser.Shown = True Then
                'copy a stub to it's location
                lControls(lIndex) = New FFButton

                'if first button, save a reference for later
                If mFirstButton Is Nothing Then
                    mFirstButton = lControls(lIndex)
                End If

                With lControls(lIndex)
                    .Top = btnAppStub.Top + ((lBrowser.PosY - 1) * btnAppStub.Height) + CInt(IIf(lBrowser.PosY = 1, 0, gSettings.IconGapHeight)) ' + spacing
                    .Left = btnAppStub.Left + ((lBrowser.PosX - 1) * btnAppStub.Width) + CInt(IIf(lBrowser.PosX = 1, 0, gSettings.IconGapWidth)) ' + spacing
                    .Height = btnAppStub.Height
                    .Width = btnAppStub.Width
                    .Image = ImageUtilities.GetImage(lBrowser, True)
                    .FlatStyle = FlatStyle.Flat
                    .FlatAppearance.BorderSize = 0
                    .Visible = True
                    .AccessibleName = "Launch " + lBrowser.Name 'to name the applicaiton more accessible
                    .Tag = lIndex
                    .ShowFocusBox = gSettings.ShowFocus
                    .TabIndex = lBrowser.PosY * gSettings.Width + lBrowser.PosX
                    .BringToFront()

                    'disable tabbing withing the buttons (to be handled by arrow keys)
                    If lIndex = 0 Then
                        .TabStop = True
                    Else
                        .TabStop = False
                    End If

                    If mHasAero = False And gSettings.BackgroundColor = Color.Transparent.ToArgb Then
                        .BackColor = Color.Transparent
                    Else
                        .BackColor = Color.FromArgb(gSettings.BackgroundColor)
                    End If

                    'add tool tip
                    lTooltips(lIndex) = New ToolTip
                    'build tool tip second line
                    If lIndex < 9 Then
                        If lBrowser.Hotkey <> vbNullChar Then
                            If IsNumeric(lBrowser.Hotkey) Then
                                'is numeric - cannot be selected and is ignored if found in config (a.k.a. invalid)
                                lToolTipText = "Hotkey: (" & lIndex + 1 & ")"
                            Else
                                'not numeric
                                lToolTipText = "Hotkeys: (" & lIndex + 1 & ") or (" & lBrowser.Hotkey & ")"
                            End If
                        Else
                            lToolTipText = "Hotkey: (" & lIndex + 1 & ")"
                            lBrowser.Hotkey = CChar(lIndex.ToString)
                        End If
                    ElseIf lIndex = 9 Then
                        'can be 0
                        If lBrowser.Hotkey <> vbNullChar Then
                            If IsNumeric(lBrowser.Hotkey) Then
                                'is numeric - cannot be selected and is ignored if found in config (a.k.a. invalid)
                                lToolTipText = "Hotkey: (0)"
                            Else
                                'not numeric
                                lToolTipText = "Hotkeys: (0) or (" & lBrowser.Hotkey & ")"
                            End If
                        Else
                            lToolTipText = "Hotkey: (0)"
                            lBrowser.Hotkey = "0"c
                        End If
                    Else
                        If lBrowser.Hotkey <> vbNullChar Then
                            lToolTipText = "Hotkey: (" & lBrowser.Hotkey & ")"
                        Else
                            lToolTipText = "Hotkey: None - Use the options dialog to set one."
                        End If
                    End If

                    lTooltips(lIndex).SetToolTip(lControls(lIndex), "Open " & lBrowser.Name & "." & Environment.NewLine & lToolTipText)

                    'see if this item show be grayed out and disabled
                    If Not StartupLauncher.SupportingBrowsers.Contains(lBrowser.GUID) Then
                        lControls(lIndex).Enabled = False
                    End If

                    'add click, mousehover, mouseenter, gotfocus, lostfocus, mouseleave events
                    AddHandler lControls(lIndex).MouseEnter, AddressOf HandleGotFocus
                    AddHandler lControls(lIndex).MouseHover, AddressOf HandleGotFocus
                    AddHandler lControls(lIndex).GotFocus, AddressOf HandleGotFocus

                    AddHandler lControls(lIndex).MouseLeave, AddressOf HandleLostFocus
                    AddHandler lControls(lIndex).LostFocus, AddressOf HandleLostFocus

                    AddHandler lControls(lIndex).KeyUp, AddressOf HandleKeyUp
                    AddHandler lControls(lIndex).ArrowKeyUp, AddressOf HandleArrowKeyUp

                    'click and such
                    AddHandler lControls(lIndex).MouseUp, AddressOf HandleActivated

                End With
            End If
            lIndex += 1
        Next
        'Next

        'add them to the screen
        Me.Controls.AddRange(lControls)

        'TO DO, scan URLs to see if current url has auto close disabled

        'set accesible rendering for the other buttons
        btnCopyToClipboard.ShowFocusBox = gSettings.ShowFocus
        btnCopyToClipboardAndClose.ShowFocusBox = gSettings.ShowFocus
        btnOptions.ShowFocusBox = gSettings.ShowFocus
        btnInfo.ShowFocusBox = gSettings.ShowFocus
        chkAutoClose.ShowFocusBox = gSettings.ShowFocus
        chkAutoOpen.ShowFocusBox = gSettings.ShowFocus

        If gSettings.BackgroundColor = Color.Transparent.ToArgb Then
            chkAutoOpen.UsesAreo = gSettings.UseAreo
            chkAutoClose.UsesAreo = gSettings.UseAreo
        Else
            chkAutoOpen.UsesAreo = False
            chkAutoClose.UsesAreo = False
        End If

        'recenter form
        'Dim lCurScreen As Screen = Screen.FromPoint(Me.Location) 'should it pop-up in a seperate screen
        'Me.Top = CInt((lCurScreen.WorkingArea.Height - Me.Height) / 2 + lCurScreen.WorkingArea.Location.Y)
        'Me.Left = CInt((lCurScreen.WorkingArea.Width - Me.Width) / 2 + lCurScreen.WorkingArea.Location.X)

        'launch delay, if configured
        If StartupLauncher.Delay <> 0 Then
            Me.Height = Me.Height + 1 'for some reason, needs 1 extra pixel to fit the top box.
            tmrDelay.Enabled = True
            'chkAutoOpen.Text = "Automaticly open " & StartupLauncher.Browser.Name & " in " & StartupLauncher.Delay & " seconds."
            chkAutoOpen.Text = String.Format("Automaticly open {0} in {1} seconds.", StartupLauncher.Browser.Name, StartupLauncher.Delay)

            'add auto start
            chkAutoOpen.Checked = True
        Else
            tmrDelay.Enabled = False
            chkAutoOpen.Visible = False

            chkAutoClose.Top = chkAutoOpen.Top
            Me.Height = Me.Height - chkAutoOpen.Height
        End If

        'move form to user requested potions
        AlignScreenToUserSettings()
    End Sub

    Private Sub btnOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptions.Click
        OpenOptions()
    End Sub

    Private Sub btnInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInfo.Click
        frmAbout.ShowDialog()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub DoLaunch(ByVal lBrowser As Browser)
        BrowserUtilities.LaunchBrowser(lBrowser, StartupLauncher.URL, chkAutoClose.Checked) 'to do, add if control is pressed, do not close
    End Sub

    Private Sub HandleShortcut(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Dim firstChar As String = e.KeyData.ToString.ToLower
        Dim bClose As Boolean = True
        Dim lIndex As Integer = 1

        If firstChar = gSettings.OptionsShortcut.ToString.ToLower Then
            '#If DEBUG Then
            Me.TopMost = False
            frmOptions.ShowDialog()
            '#Else
            '            openOptions()
            '#End If
        End If

        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Then
            'move the focus around
            Debug.Print("hi2")
            e.SuppressKeyPress = True
            e.Handled = True
        End If

        'scan browsers to see if their hotkey has been pressed, also look to 1 to 9 + 0 for first 10 browsers
        For Each lBrowser As Browser In gSettings.Browsers
            If Char.IsDigit(lBrowser.Hotkey) = False Then
                'else ignore
                If lBrowser.Hotkey = firstChar Then
                    'launch this browser
                    DoLaunch(lBrowser)
                    Exit Sub 'short circuit out of here
                End If
            End If

            'evaluate speparatelty
            If GeneralUtilities.KeyCodeValues.ContainsKey(e.KeyCode) = True Then
                If lIndex <= 10 And lIndex = GeneralUtilities.KeyCodeValues.Item(e.KeyCode) Then
                    DoLaunch(lBrowser)
                    Exit Sub 'short circuit out of here
                End If
            End If

            lIndex += 1

        Next
    End Sub


    'Private Sub AddJumpLists()
    '    ' create the jump lists
    '    If TaskbarManager.IsPlatformSupported Then

    '        Dim jumpList As JumpList = jumpList.CreateJumpList()

    '        For Each Browser In BrowserConfig.Browsers
    '            If Browser.IsActive Then
    '                Dim target As String = NormalizeTarget(Browser.Target)

    '                Dim strBrowser As String = target
    '                Dim strParameters As String = ""

    '                If target.Contains(".exe ") Then
    '                    strBrowser = target.Substring(0, InStr(target, ".exe") + 4)
    '                    strParameters = target.Substring(InStr(target, ".exe") + 4, target.Length - (InStr(target, ".exe") + 4)) & " "

    '                End If

    '                jumpList.AddUserTasks(New JumpListLink(NormalizeTarget(strBrowser), "Open " + Browser.Name) With {.IconReference = New IconReference(NormalizeTarget(strBrowser), 0), .Arguments = strParameters})
    '            End If
    '        Next

    '        ' Add our user tasks
    '        jumpList.Refresh()
    '    End If
    'End Sub

    Private Sub frmMain_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        'put first button as focus
        btnInfo.Focus()
        If Not (mFirstButton Is Nothing) Then
            mFirstButton.Focus() 'although the focus is not evident
        End If

        If StartupLauncher.URL = "" Then
            btnCopyToClipboard.Enabled = False
            btnCopyToClipboardAndClose.Enabled = False
        End If

        'AddJumpLists()
    End Sub

    Private Sub tmrDelay_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrDelay.Tick
        Static lCurTimer As Integer = StartupLauncher.Delay

        'count down
        lCurTimer -= 1

        If lCurTimer > 0 Then
            Dim lText As String = String.Format("Automatically open {0} in {1} seconds.", StartupLauncher.Browser.Name, lCurTimer)
            If mHasAero = True And gSettings.AccessibleRendering = False Then
                chkAutoOpen.Tag = lText
                chkAutoOpen.Invalidate()
            Else
                chkAutoOpen.Text = lText
            End If
        Else
            tmrDelay.Enabled = False

            Dim lText As String = String.Format("Automatically opening {0}.", StartupLauncher.Browser.Name)
            If mHasAero = True And gSettings.AccessibleRendering = False Then
                chkAutoOpen.Tag = lText
                chkAutoOpen.Invalidate()
            Else
                chkAutoOpen.Text = lText
            End If

            DoLaunch(StartupLauncher.Browser)
        End If

    End Sub

    Private Sub chkAutoOpen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutoOpen.CheckedChanged
        tmrDelay.Enabled = chkAutoOpen.Checked
    End Sub

    Private Delegate Sub SetTextCallback(ByVal aURL As String)
    Public Sub UpdateURL(ByVal aURL As String)
        'should only have one
        If gSettings.ShowURL = True Then
            Dim lText As String
            If msCurrentText = "" Then
                lText = StartupLauncher.URL
            Else
                lText = msCurrentText & gSettings.Seperator & StartupLauncher.URL
            End If


            'make sure thread safe first
            If Me.InvokeRequired Then
                Dim d As New SetTextCallback(AddressOf UpdateURL)
                Me.Invoke(d, New Object() {aURL})
            Else
                Me.Text = Mid(lText, 1, 256)
            End If
        End If
    End Sub

    Private Sub OpenOptions()
        Dim lTimerStatus As Boolean = tmrDelay.Enabled
        Me.TopMost = False
        tmrDelay.Enabled = False
        frmOptions.ShowForm(True)
        tmrDelay.Enabled = lTimerStatus
        Me.TopMost = True
    End Sub

    Private Sub btnCopyToClipboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyToClipboard.Click
        If StartupLauncher.URL <> "" Then
            Clipboard.SetText(StartupLauncher.URL)
        End If
    End Sub

    Private Sub btnCopyToClipboardAndClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyToClipboardAndClose.Click
        If StartupLauncher.URL <> "" Then
            Clipboard.SetText(StartupLauncher.URL)

            End
        End If
    End Sub

    Private Sub HandleKeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim lBrowser As Browser = gSettings.Browsers(CInt(DirectCast(sender, Button).Tag))

        If (e.KeyCode = Keys.Enter) Then
            If chkAutoClose.Checked = True Then
                BrowserUtilities.LaunchBrowser(lBrowser, StartupLauncher.URL, True)
            Else
                BrowserUtilities.LaunchBrowser(lBrowser, StartupLauncher.URL, False)
            End If
        End If
    End Sub

    Private Function MinusLoop(ByVal aStart As Integer, ByVal aMax As Integer) As Integer
        aStart = aStart - 1
        If aStart = 0 Then
            Return aMax
        Else
            Return aStart
        End If
    End Function

    Private Function AddLoop(ByVal aStart As Integer, ByVal aMax As Integer) As Integer
        aStart = aStart + 1
        If aStart > aMax Then
            Return 1
        Else
            Return aStart
        End If
    End Function

    Private Sub HandleArrowKeyUp(ByVal sender As Object, ByVal KeyData As System.Windows.Forms.Keys) Handles btnAppStub.ArrowKeyUp
        'moves the focus around the buttons - looping around
        Dim lBrowser As Browser = gSettings.Browsers(CInt(DirectCast(sender, FFButton).Tag))
        Debug.Print(lBrowser.PosX & " .. " & lBrowser.PosY)

        Dim lCurPoX As Integer = lBrowser.PosX
        Dim lCurPoY As Integer = lBrowser.PosY
        Dim lData As Integer
        Dim lbFoundBrowser As Browser = Nothing
        Dim lIndex As Integer

        Select Case KeyData
            Case Keys.Up
                'naively look up for the next avilable box, until we hit ourselves
                lData = lCurPoY
                Do
                    lData = MinusLoop(lData, gSettings.Height)

                    'scan for a button at that position
                    lIndex = 0
                    For Each mBrowser As Browser In gSettings.Browsers
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
                    lData = AddLoop(lData, gSettings.Height)

                    'scan for a button at that position
                    lIndex = 0
                    For Each mBrowser As Browser In gSettings.Browsers
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
                    lData = MinusLoop(lData, gSettings.Width)

                    'scan for a button at that position
                    lIndex = 0
                    For Each mBrowser As Browser In gSettings.Browsers
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
                    lData = AddLoop(lData, gSettings.Width)

                    'scan for a button at that position
                    lIndex = 0
                    For Each mBrowser As Browser In gSettings.Browsers
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

            For Each lButton As Control In Me.Controls
                If TypeOf (lButton) Is FFButton Then

                    If CInt(lButton.Tag) = lIndex - 1 Then 'i need a better system for this
                        lButton.Focus()
                        lButton.TabStop = True
                    End If


                End If
            Next
        End If
    End Sub
End Class