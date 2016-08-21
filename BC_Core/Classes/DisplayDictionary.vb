Public Class DisplayDictionary
    'used to build the list box, will also allow future translations
    Public Shared ReadOnly AvailableStartingPositionsNames As New Dictionary(Of Settings.AvailableStartingPositions, String) From {
        {Settings.AvailableStartingPositions.CenterScreen, "Center Screen"},
        {Settings.AvailableStartingPositions.OffsetCenter, "Offset Center (Use X, Y for Offset)"},
        {Settings.AvailableStartingPositions.XY, "X, Y"},
        {Settings.AvailableStartingPositions.Seperator1, "--"},
        {Settings.AvailableStartingPositions.TopLeft, "Top Left"},
        {Settings.AvailableStartingPositions.TopRight, "Top Right"},
        {Settings.AvailableStartingPositions.BottomLeft, "Bottom Left"},
        {Settings.AvailableStartingPositions.BottomRight, "Bottom Right"},
        {Settings.AvailableStartingPositions.Seperator2, "--"},
        {Settings.AvailableStartingPositions.OffsetTopLeft, "Offset Top Left (Use X, Y for Offset)"},
        {Settings.AvailableStartingPositions.OffsetTopRight, "Offset Top Right (Use X, Y for Offset)"},
        {Settings.AvailableStartingPositions.OffsetBottomLeft, "Offset Bottom Left (Use X, Y for Offset)"},
        {Settings.AvailableStartingPositions.OffsetBottomRight, "Offset Bottom Right (Use X, Y for Offset)"}
    }

    Dim mIndex As Integer

    Public Function Index() As Integer
        Return mIndex
    End Function

    Private Sub New(Index As Settings.AvailableStartingPositions)
        mIndex = Index
    End Sub

    Public Shared Function Item(Index As Integer) As DisplayDictionary
        Return New DisplayDictionary(DirectCast(Index, Settings.AvailableStartingPositions))
    End Function

    Public Overrides Function ToString() As String
        Return AvailableStartingPositionsNames(DirectCast(mIndex, Settings.AvailableStartingPositions))
    End Function
End Class
