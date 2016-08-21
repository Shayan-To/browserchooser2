
Imports System.Globalization

Namespace WpfApplication1.View.ViewStyles.ExtraCodeBehind
    Public Class CalculateWidth
        Implements IMultiValueConverter

        Private Const ActualWidthIndex As Integer = 0
        Private Const TagIndex As Integer = 1
        Private Const MinWidthIndex As Integer = 2

        Public Function Convert(values() As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IMultiValueConverter.Convert


            Try
                ' must have 4 inputs
                If values.Length <> 3 Then
                    Throw New MissingFieldException("Need to specify exactly 3 items, ActualWidth, Tag, MinWidth")
                End If

                Dim result As Double = 1.0 * DirectCast(values(TagIndex), Double) 'initialise the result to 1 * current size (tag)

                'now convert to actual width
                result *= DirectCast(values(ActualWidthIndex), Double)

                'now ensure we are bigger or euqal to min width
                If result < values(MinWidthIndex) Then
                    result = values(MinWidthIndex)
                End If

                Return result
            Catch ex As Exception
                Debug.Print("CalculateWidth.Convert Exception: " & values.Length)
                'MsgBox(values.Length)
            End Try
        End Function

        Public Function ConvertBack(value As Object, targetTypes() As Type, parameter As Object, culture As CultureInfo) As Object() Implements IMultiValueConverter.ConvertBack
            Throw New NotImplementedException()
        End Function
    End Class
End Namespace