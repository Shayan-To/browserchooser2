Public Class Logger
    Public Shared Sub AddToLog(aCaller As String, aMessage As String, ParamArray aExtraVars() As String)
        Dim lWritter As System.IO.TextWriter = My.Computer.FileSystem.OpenTextFileWriter("bc2.log", True)

        If Settings.LogDebugs = True Then
            If aExtraVars.Length > 0 Then
                lWritter.WriteLine("""{0}"",""{1}"",""{2}"",""{3}""", Date.Now, aCaller, aMessage, Join(aExtraVars, ","))
            Else
                lWritter.WriteLine("""{0}"",""{1}"",""{2}""", Date.Now, aCaller, aMessage)
            End If

            'close and exit
            lWritter.Close()
        End If
    End Sub
End Class
