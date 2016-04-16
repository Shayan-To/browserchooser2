Public Class FFButton
    Inherits System.Windows.Forms.Button

    Public Event ArrowKeyUp(ByVal sender As Object, ByVal KeyData As Keys)

    Private mShowFocusBox As Boolean
    Private mTrapArrowKeys As Boolean

    'protected override bool ShowFocusCues
    Protected Overrides ReadOnly Property ShowFocusCues As Boolean
        Get
            Return False 'not #a11y - will be replaced with a better focus
        End Get
    End Property

    Protected Overrides Function IsInputKey(ByVal keyData As Keys) As Boolean
        If keyData = Keys.Up Or keyData = Keys.Down Or keyData = Keys.Left Or keyData = Keys.Right Then
            'move the focus around
            RaiseEvent ArrowKeyUp(Me, keyData)
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub FFButton_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        If mShowFocusBox = True Then
            Me.FlatAppearance.BorderColor = Color.Black
            Me.FlatAppearance.BorderSize = 1
        End If
    End Sub

    Private Sub FFButton_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
        Me.FlatAppearance.BorderSize = 0
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
End Class
