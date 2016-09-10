Namespace Utility
    Public Class LoopMath
        Public Shared Function MinusLoop(ByVal aStart As Integer, ByVal aMax As Integer) As Integer
            aStart = aStart - 1
            If aStart = 0 Then
                Return aMax
            Else
                Return aStart
            End If
        End Function

        Public Shared Function AddLoop(ByVal aStart As Integer, ByVal aMax As Integer) As Integer
            aStart = aStart + 1
            If aStart > aMax Then
                Return 1
            Else
                Return aStart
            End If
        End Function
    End Class
End Namespace