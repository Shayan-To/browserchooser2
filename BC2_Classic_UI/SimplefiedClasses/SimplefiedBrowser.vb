Public Class SimplefiedBrowser
    Implements ICloneable
    Implements IEquatable(Of SimplefiedBrowser)

    Public ReadOnly Property PosX As Integer
    Public ReadOnly Property PosY As Integer

    Public ReadOnly Property Name As String

    Public ReadOnly Property Hotkey As Char

    Public Sub New(aPosX As Integer, aPosY As Integer, aName As String, aHotkey As Char)
        PosX = aPosX
        PosY = aPosY
        Name = aName
        Hotkey = aHotkey
    End Sub

    Public Shadows Function Equals(other As SimplefiedBrowser) As Boolean Implements IEquatable(Of SimplefiedBrowser).Equals
        If Me.PosX <> other.PosX Then Return False
        If Me.PosY <> other.PosY Then Return False
        If Me.Name <> other.Name Then Return False
        If Me.Hotkey <> other.Hotkey Then Return False
        Return True ' all checks pass
    End Function

    Public Function Clone() As Object Implements ICloneable.Clone
        Return New SimplefiedBrowser(Me.PosX, Me.PosY, Me.Name, Me.Hotkey)
    End Function
End Class
