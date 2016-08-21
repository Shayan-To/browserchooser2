Namespace WpfApplication1.View.ViewStyles.ExtraCodeBehind
    Public Class animationsAP
        Inherits DependencyObject

        Public Shared ReadOnly APMinWidthProperty As DependencyProperty = DependencyProperty.RegisterAttached("APMinWidth", GetType(System.Double), GetType(animationsAP), New FrameworkPropertyMetadata(CDbl(0), AddressOf APMinWidthPropertyChanged))

        Public Shared Sub SetAPMinWidthProperty(ByVal element As UIElement, ByVal value As System.Double)
            element.SetValue(APMinWidthProperty, value)
        End Sub
        Public Shared Function GetAPMinWidthProperty(ByVal element As UIElement) As System.Double
            Return CType(element.GetValue(APMinWidthProperty), Boolean)
        End Function

        Private Shared Sub APMinWidthPropertyChanged(ByVal d As System.Windows.DependencyObject, ByVal e As System.Windows.DependencyPropertyChangedEventArgs)
        End Sub
    End Class
End Namespace
