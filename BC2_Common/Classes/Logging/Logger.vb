Public Class Logger
    Public Shared Sub AddToLog(aCaller As ILoggingSupported, aCallingFunction As String, aMessage As String, ParamArray aExtraVars() As Object)
        Dim lWritter As System.IO.TextWriter = My.Computer.FileSystem.OpenTextFileWriter("bc2.log", True)

        If Settings.LogDebugs = True Then
            If aExtraVars.Length > 0 Then
                'convert aExtraCars to text output
                Dim lOut As String = ""
                For Each lExtra As Object In aExtraVars
                    Try
                        lOut &= String.Format("{0}:{1}", TypeName(lExtra), lExtra.ToString)
                    Catch ex As Exception
                        'do nothing
                    End Try

                Next
                lWritter.WriteLine("""{0}"",""{1}"",""{2}"",""{3}""", Date.Now, aCaller.FriendlyName, aMessage, Join(aExtraVars, ","))
            Else
                lWritter.WriteLine("""{0}"",""{1}"",""{2}""", Date.Now, aCaller.FriendlyName, aMessage)
            End If

            'close and exit
            lWritter.Close()
        End If
    End Sub
End Class
