Public Class URLUtilities
    Public Shared Function MatchURLs(ByVal aSource As String, ByVal aTarget As String) As Boolean
        'strip http(s):// from urls and strip www from urls
        Dim lsSource As String = aSource.Replace("http://", "").Replace("https://", "").Replace("www.", "")
        Dim lsTarget As String = aTarget.Replace("http://", "").Replace("https://", "").Replace("www.", "")

        'perform basic wilcard (regex to come later)
        If lsTarget Like lsSource Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
