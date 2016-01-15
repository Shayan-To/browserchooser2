Imports System.Drawing.Drawing2D

Public Class FFCheckBox
    Inherits System.Windows.Forms.CheckBox

    Private Declare Function GetDesktopWindow Lib "user32" () As IntPtr
    Public Declare Function GetWindowDC Lib "user32" Alias "GetWindowDC" (ByVal hWnd As IntPtr) As IntPtr
    Public Declare Function ReleaseDC Lib "user32" Alias "ReleaseDC" (ByVal hWnd As IntPtr, ByVal hDc As IntPtr) As Integer

    Private mShowFocusBox As Boolean
    Private mUsesAreo As Boolean
    Private mTrapArrowKeys As Boolean
    Private mOldwidth As Integer
    Private mOldHeight As Integer
    Private mbHasFocus As Boolean = False

    'protected override bool ShowFocusCues
    Protected Overrides ReadOnly Property ShowFocusCues As Boolean
        Get
            If Me.DesignMode = False Then
                If gSettings.ShowFocus = True Then
                    Return False 'not #a11y - will be replaced with a better focus
                Else
                    Return True
                End If
            Else
                Return True
            End If
        End Get
    End Property

    Private Sub FFCheckBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        mbHasFocus = True
    End Sub

    Private Sub FFCheckBox_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.HandleCreated
        Debug.Print("On load Me.Parent = " & Me.Parent.Name)
        AddHandler Me.Parent.MouseUp, AddressOf frmMain_MouseUp
    End Sub

    Private Sub FFCheckBox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
        mbHasFocus = False
        Me.Parent.Refresh()
    End Sub

    Private Sub FFCheckBox_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim lCheckBox As CheckBox = CType(sender, CheckBox)

        If Me.DesignMode = True Then Exit Sub 'do nothing
        If Utility.IsAeroEnabled() = True And mUsesAreo = True And gSettings.AccessibleRendering = False Then
            'draw using buffered graphics - prevents fliker
            Dim g As Graphics = Me.Parent.CreateGraphics
            Dim lRect As New Rectangle(lCheckBox.Location.X + 15, lCheckBox.Location.Y - 4, mOldwidth, mOldHeight)

            Dim myContext As BufferedGraphicsContext
            myContext = BufferedGraphicsManager.Current
            Dim lBuffered As BufferedGraphics = myContext.Allocate(g, lRect)

            Dim tx As New GraphicsPath

            If IsNothing(lCheckBox.Tag) OrElse lCheckBox.Tag.ToString = "" Then
                lCheckBox.Tag = lCheckBox.Text
                mOldwidth = lCheckBox.Width
                mOldHeight = lCheckBox.Height
                lCheckBox.Text = ""
            End If

            'begin draw text
            tx.AddString(lCheckBox.Tag.ToString, lCheckBox.Font.FontFamily, FontStyle.Regular, 16,
                         New Point(lCheckBox.Location.X + 15, lCheckBox.Location.Y - 4), StringFormat.GenericDefault)
            ' Set Smoothing Mode to get smooth text
            lBuffered.Graphics.SmoothingMode = SmoothingMode.AntiAlias
            'Fill form with text and color (brush)
            lBuffered.Graphics.FillPath(New SolidBrush(Color.Black), tx)
            lBuffered.Render()
        End If

        If ShowFocusBox = True And mbHasFocus = True Then
            Dim g As Graphics = Me.Parent.CreateGraphics

            Dim lPen As New Pen(Brushes.Black, 2)
            If Utility.IsAeroEnabled() = True And gSettings.AccessibleRendering = False Then
                g.DrawRectangle(lPen, Me.Location.X - 5, Me.Location.Y - 5, mOldwidth + 10, mOldHeight)
            Else
                g.DrawRectangle(lPen, Me.Location.X - 5, Me.Location.Y - 5, Me.Width + 10, Me.Height + 10)
            End If

            Me.BringToFront()

        End If
    End Sub

    Private Sub frmMain_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If mUsesAreo = True And gSettings.AccessibleRendering = False Then
            Debug.Print(e.Location.ToString)
            'the plus width excludes the checkbox from the hit test
            If e.Location.X > Me.Location.X + Me.Width And e.Location.X < Me.Location.X + mOldwidth Then
                If e.Location.Y > Me.Location.Y And e.Location.Y < Me.Location.Y + mOldHeight Then
                    Me.Focus()
                    Me.Checked = Not Me.Checked
                End If
            End If
        End If
    End Sub

    Public Property TrapArrowKeys As Boolean
        Get
            Return mTrapArrowKeys
        End Get
        Set(ByVal value As Boolean)
            mTrapArrowKeys = value
        End Set
    End Property

    Public Property ShowFocusBox As Boolean
        Get
            Return mShowFocusBox
        End Get
        Set(ByVal value As Boolean)
            mShowFocusBox = value
        End Set
    End Property

    Public Property UsesAreo As Boolean
        Get
            Return mUsesAreo
        End Get
        Set(ByVal value As Boolean)
            mUsesAreo = value
        End Set
    End Property
End Class
