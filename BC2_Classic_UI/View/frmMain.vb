Imports System.IO
Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Windows
Imports BC2_Common

Public Class frmMain
    Implements BC2_Common.ILoggingSupported

    ''' <summary>
    ''' All look and feel of the form goes in this class. Connective logic goes in vmMain
    ''' </summary>

    Private mFirstButton As FFButton 'transitory reference
    'Private mHasAero As Boolean
    Private mOldWidth As Integer 'for better looks
    Private mOldHeight As Integer 'for better looks
    Private mCurDelay As Integer
    'Private msCurrentText As String
    Private mSettings As SimplefiedSettings

    Public WriteOnly Property Settings As SimplefiedSettings
        Set(ByVal newSettings As SimplefiedSettings)
            mSettings = newSettings
        End Set
    End Property

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        If mSettings.HasAero = False Then
            'note that the border still looks off but the display is much improved
            Using br As New LinearGradientBrush(Me.DisplayRectangle,
                                                Color.FromArgb(185, 209, 234), Color.FromArgb(132, 151, 173),
                                                LinearGradientMode.Vertical)
                e.Graphics.FillRectangle(br, Me.DisplayRectangle)
            End Using
        ElseIf mSettings.HasAero = True And mSettings.BackgroundColor <> Color.Transparent.ToArgb() Then
            'custom background
            Using br As New LinearGradientBrush(Me.DisplayRectangle,
                                    Color.FromArgb(185, 209, 234), Color.FromArgb(mSettings.BackgroundColor),
                                    LinearGradientMode.Vertical)
                e.Graphics.FillRectangle(br, Me.DisplayRectangle)
            End Using


            ''Composition disabled; fake it like Microsoft does
            'Dim clFakeGlassColor As Integer = &HEAD1B9 ' //(185, 209, 234) This is the fake foreground glass color (for use when composition is disabled)
            'Dim clFakeGlassColorUnfocused As Integer = &HF2E4D7 ' //(215, 228, 242) This is the fake background glass color (for use when composition is disabled)

            ''The color to use depends if the form has focused or not
            'Dim glassColor As SolidBrush
            'If Me.Focused = True Then
            '    glassColor = New SolidBrush(Color.FromArgb(gSettings.BackgroundColor))
            'Else
            '    glassColor = New SolidBrush(Color.FromArgb(gSettings.BackgroundColor))
            '    'glassColor = New SolidBrush(Color.FromArgb(clFakeGlassColorUnfocused))
            'End If

            'e.Graphics.FillRectangle(glassColor, Me.DisplayRectangle) ' //fill rectangle with fake color


            '      'Now we have to draw the two accent lines along the bottom.
            'Dim a As New ColorBlend(2)
            'a.Colors(0) = Color.White
            'a.Colors(1) = glassColor


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
        Me.FormBorderStyle = Forms.FormBorderStyle.FixedDialog
        Me.chkAutoClose.BackColor = Color.Transparent
        Me.chkAutoOpen.BackColor = Color.Transparent
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If mSettings.HasAero = True And mSettings.BackgroundColor = Color.Transparent.ToArgb Then
            Utility.Screen.MakeFormGlassy(Me)
        Else
            'fake it
        End If

        'InitializeMain()

        If Not mSettings.HasAero Then
            styleXP()
        End If
    End Sub

    Private Sub AlignScreenToUserSettings()
        Dim lPosition As BC2_Common.Settings.AvailableStartingPositions = mSettings.StartingPosition
        Select Case lPosition
            Case BC2_Common.Settings.AvailableStartingPositions.CenterScreen
                Dim lCurScreen As Screen = Screen.FromPoint(Me.Location) 'should it pop-up in a seperate screen
                Me.Top = CInt((lCurScreen.WorkingArea.Height - Me.Height) / 2 + lCurScreen.WorkingArea.Location.Y)
                Me.Left = CInt((lCurScreen.WorkingArea.Width - Me.Width) / 2 + lCurScreen.WorkingArea.Location.X)
            Case BC2_Common.Settings.AvailableStartingPositions.XY
                Me.Top = mSettings.OffsetY
                Me.Left = mSettings.OffsetX
            Case BC2_Common.Settings.AvailableStartingPositions.TopLeft
                Me.Top = My.Computer.Screen.Bounds.Top
                Me.Left = My.Computer.Screen.Bounds.Left
            Case BC2_Common.Settings.AvailableStartingPositions.TopRight
                Me.Top = My.Computer.Screen.Bounds.Top
                Me.Left = My.Computer.Screen.Bounds.Right - Me.Width
            Case BC2_Common.Settings.AvailableStartingPositions.BottomLeft
                Me.Top = My.Computer.Screen.Bounds.Bottom - Me.Height
                Me.Left = My.Computer.Screen.Bounds.Left
            Case BC2_Common.Settings.AvailableStartingPositions.BottomRight
                Me.Top = My.Computer.Screen.Bounds.Bottom - Me.Height
                Me.Left = My.Computer.Screen.Bounds.Right - Me.Width
            Case BC2_Common.Settings.AvailableStartingPositions.OffsetTopLeft
                Me.Top = My.Computer.Screen.Bounds.Top + mSettings.OffsetY
                Me.Left = My.Computer.Screen.Bounds.Left + mSettings.OffsetX
            Case BC2_Common.Settings.AvailableStartingPositions.OffsetTopRight
                Me.Top = My.Computer.Screen.Bounds.Top + mSettings.OffsetY
                Me.Left = My.Computer.Screen.Bounds.Right - Me.Width + mSettings.OffsetX
            Case BC2_Common.Settings.AvailableStartingPositions.OffsetBottomLeft
                Me.Top = My.Computer.Screen.Bounds.Bottom - Me.Height + mSettings.OffsetY
                Me.Left = My.Computer.Screen.Bounds.Left + mSettings.OffsetX
            Case BC2_Common.Settings.AvailableStartingPositions.OffsetBottomRight
                Me.Top = My.Computer.Screen.Bounds.Bottom - Me.Height + mSettings.OffsetY
                Me.Left = My.Computer.Screen.Bounds.Right - Me.Width + mSettings.OffsetX
            Case Else 'default to center screen
                Dim lCurScreen As Screen = Screen.FromPoint(Me.Location) 'should it pop-up in a seperate screen
                Me.Top = CInt((lCurScreen.WorkingArea.Height - Me.Height) / 2 + lCurScreen.WorkingArea.Location.Y)
                Me.Left = CInt((lCurScreen.WorkingArea.Width - Me.Width) / 2 + lCurScreen.WorkingArea.Location.X)
        End Select
    End Sub

    Public Sub InitializeMain(aHandleGotFocus As EventHandler, aHandleLostFocus As EventHandler, aHandleKeyUp As KeyEventHandler,
                              aHandleArrowKeyUp As FFButton.ArrowKeyUpEventHandler, aHandleActivated As MouseEventHandler)
        'build array of icons as specifyed

        'calculate the amount of buttons required
        Dim lMax As Integer = mSettings.Width * mSettings.Height
        If mSettings.Browsers.Count > lMax Then
            lMax = mSettings.Browsers.Count
        End If

        'overflow protection provided by enforeced maximums.
        Dim lControls(lMax) As FFButton
        Dim lTooltips(lMax) As ToolTip
        Dim lIndex As Integer = 0
        Dim lBrowser As BC2_Common.Browser
        Dim lToolTipText As String = ""

        'set size of stub to chosen selection
        btnAppStub.Height = mSettings.IconHeight
        btnAppStub.Width = mSettings.IconWidth

        'resize form to fit x and y
        Dim lSpaceX As Integer = (btnAppStub.Width + mSettings.IconGapWidth) * mSettings.Width
        Me.Width = lSpaceX + (btnAppStub.Left * 2)

        Dim lSpaceY As Integer = (btnAppStub.Height + mSettings.IconGapHeight) * mSettings.Height
        Dim lBorderSpace As Integer = Me.Height - chkAutoClose.Height - chkAutoClose.Top
        Me.Height = lSpaceY + chkAutoClose.Height + lBorderSpace + 6 '6 gives just enough space for the custom focus box

        'set on screen colors
        If mSettings.HasAero = False And mSettings.BackgroundColor = Color.Transparent.ToArgb Then
            'Me.BackColor = Color.Transparent
        ElseIf mSettings.BackgroundColor <> Color.Transparent.ToArgb Then
            'Me.BackColor = Color.FromArgb(gSettings.BackgroundColor)
            chkAutoOpen.BackColor = Color.FromArgb(mSettings.BackgroundColor)
            chkAutoClose.BackColor = Color.FromArgb(mSettings.BackgroundColor)
        End If

        'create controls, they are added in order from browser file, with support for x y addressing
        For Each lBrowser In mSettings.Browsers
            'ensure the position is valid and item should be visible
            If Not (lBrowser.PosX < 1 Or lBrowser.PosY < 1 Or lBrowser.PosX > mSettings.Width Or lBrowser.PosY > mSettings.Height) And lBrowser.Shown = True Then
                'copy a stub to it's location
                lControls(lIndex) = New FFButton

                'if first button, save a reference for later
                If mFirstButton Is Nothing Then
                    mFirstButton = lControls(lIndex)
                End If

                With lControls(lIndex)
                    .Top = btnAppStub.Top + ((lBrowser.PosY - 1) * btnAppStub.Height) + CInt(IIf(lBrowser.PosY = 1, 0, mSettings.IconGapHeight)) ' + spacing
                    .Left = btnAppStub.Left + ((lBrowser.PosX - 1) * btnAppStub.Width) + CInt(IIf(lBrowser.PosX = 1, 0, mSettings.IconGapWidth)) ' + spacing
                    .Height = btnAppStub.Height
                    .Width = btnAppStub.Width
                    .Image = BC2_Common.ImageUtilities.GetImage(lBrowser, True)
                    .FlatStyle = FlatStyle.Flat
                    .FlatAppearance.BorderSize = 0
                    .Visible = True
                    .AccessibleName = "Launch " + lBrowser.Name 'to name the applicaiton more accessible
                    .Tag = lIndex
                    .ShowFocusBox = mSettings.ShowFocus
                    .TabIndex = lBrowser.PosY * mSettings.Width + lBrowser.PosX
                    .BringToFront()

                    'disable tabbing withing the buttons (to be handled by arrow keys)
                    If lIndex = 0 Then
                        .TabStop = True
                    Else
                        .TabStop = False
                    End If

                    If mSettings.HasAero = False And mSettings.BackgroundColor = Color.Transparent.ToArgb Then
                        .BackColor = Color.Transparent
                    Else
                        .BackColor = Color.FromArgb(mSettings.BackgroundColor)
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
                    'If Not StartupLauncher.SupportingBrowsers.Contains(lBrowser.GUID) Then
                    '    lControls(lIndex).Enabled = False
                    'End If

                    'add click, mousehover, mouseenter, gotfocus, lostfocus, mouseleave events
                    AddHandler lControls(lIndex).MouseEnter, aHandleGotFocus
                    AddHandler lControls(lIndex).MouseHover, aHandleGotFocus
                    AddHandler lControls(lIndex).GotFocus, aHandleGotFocus

                    AddHandler lControls(lIndex).MouseLeave, aHandleLostFocus
                    AddHandler lControls(lIndex).LostFocus, aHandleLostFocus

                    AddHandler lControls(lIndex).KeyUp, aHandleKeyUp
                    AddHandler lControls(lIndex).ArrowKeyUp, aHandleArrowKeyUp

                    'click and such
                    AddHandler lControls(lIndex).MouseUp, aHandleActivated

                End With
            End If
            lIndex += 1
        Next
        'Next

        'add other event handlers - got focus
        AddHandler btnInfo.MouseEnter, aHandleGotFocus
        AddHandler btnInfo.MouseHover, aHandleGotFocus
        AddHandler btnInfo.GotFocus, aHandleGotFocus
        AddHandler btnOptions.MouseEnter, aHandleGotFocus
        AddHandler btnOptions.MouseHover, aHandleGotFocus
        AddHandler btnOptions.GotFocus, aHandleGotFocus
        AddHandler btnCopyToClipboard.MouseHover, aHandleGotFocus
        AddHandler btnCopyToClipboard.GotFocus, aHandleGotFocus
        AddHandler btnCopyToClipboardAndClose.MouseHover, aHandleGotFocus
        AddHandler btnCopyToClipboardAndClose.GotFocus, aHandleGotFocus

        'lost focus 
        AddHandler btnInfo.MouseLeave, aHandleLostFocus
        AddHandler btnInfo.LostFocus, aHandleLostFocus
        AddHandler btnOptions.MouseLeave, aHandleLostFocus
        AddHandler btnOptions.LostFocus, aHandleLostFocus
        AddHandler btnCopyToClipboard.LostFocus, aHandleLostFocus
        AddHandler btnCopyToClipboard.MouseLeave, aHandleLostFocus
        AddHandler btnCopyToClipboardAndClose.MouseLeave, aHandleLostFocus
        AddHandler btnCopyToClipboardAndClose.LostFocus, aHandleLostFocus

        'add them to the screen
        Me.Controls.AddRange(lControls)

        'TO DO, scan URLs to see if current url has auto close disabled

        'set accesible rendering for the other buttons
        btnCopyToClipboard.ShowFocusBox = mSettings.ShowFocus
        btnCopyToClipboardAndClose.ShowFocusBox = mSettings.ShowFocus
        btnOptions.ShowFocusBox = mSettings.ShowFocus
        btnInfo.ShowFocusBox = mSettings.ShowFocus
        chkAutoClose.ShowFocusBox = mSettings.ShowFocus
        chkAutoOpen.ShowFocusBox = mSettings.ShowFocus

        If mSettings.BackgroundColor = Color.Transparent.ToArgb Then
            chkAutoOpen.UsesAreo = mSettings.UseAreo
            chkAutoClose.UsesAreo = mSettings.UseAreo
        Else
            chkAutoOpen.UsesAreo = False
            chkAutoClose.UsesAreo = False
        End If

        'recenter form
        'Dim lCurScreen As Screen = Screen.FromPoint(Me.Location) 'should it pop-up in a seperate screen
        'Me.Top = CInt((lCurScreen.WorkingArea.Height - Me.Height) / 2 + lCurScreen.WorkingArea.Location.Y)
        'Me.Left = CInt((lCurScreen.WorkingArea.Width - Me.Width) / 2 + lCurScreen.WorkingArea.Location.X)

        'launch delay, if configured
        If mSettings.Delay <> 0 Then
            Me.Height = Me.Height + 1 'for some reason, needs 1 extra pixel to fit the top box.
            tmrDelay.Enabled = True
            'chkAutoOpen.Text = "Automaticly open " & StartupLauncher.Browser.Name & " in " & StartupLauncher.Delay & " seconds."
            chkAutoOpen.Text = String.Format("Automaticly open {0} in {1} seconds.", mSettings.DefaultBrowser.Name, mSettings.Delay)

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





    Private Sub HandleShortcut(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Dim firstChar As String = e.KeyData.ToString.ToLower
        Dim bClose As Boolean = True
        Dim lIndex As Integer = 1

        If firstChar = mSettings.OptionsShortcut.ToString.ToLower Then
            '#If DEBUG Then
            Me.TopMost = False
            'frmOptions.ShowDialog()
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
        For Each lBrowser As Browser In mSettings.Browsers
            If Char.IsDigit(lBrowser.Hotkey) = False Then
                'else ignore
                If lBrowser.Hotkey = firstChar Then
                    'launch this browser
                    'DoLaunch(lBrowser)
                    Exit Sub 'short circuit out of here
                End If
            End If

            'evaluate speparatelty
            If GeneralUtilities.KeyCodeValues.ContainsKey(e.KeyCode) = True Then
                If lIndex <= 10 And lIndex = GeneralUtilities.KeyCodeValues.Item(e.KeyCode) Then
                    'DoLaunch(lBrowser)
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

        If mSettings.URL = "" Then
            btnCopyToClipboard.Enabled = False
            btnCopyToClipboardAndClose.Enabled = False
        End If

        'AddJumpLists()
    End Sub

    Private Sub chkAutoOpen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutoOpen.CheckedChanged
        tmrDelay.Enabled = chkAutoOpen.Checked
    End Sub

    Private Sub OpenOptions()
        Dim lTimerStatus As Boolean = tmrDelay.Enabled
        Me.TopMost = False
        tmrDelay.Enabled = False
        'frmOptions.ShowForm(True)
        tmrDelay.Enabled = lTimerStatus
        Me.TopMost = True
    End Sub

    Public Function FriendlyName() As String Implements ILoggingSupported.FriendlyName
        Return "Classic frmMain"
    End Function
End Class