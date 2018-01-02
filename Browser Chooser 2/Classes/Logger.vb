Public Class Logger
    Public Shared lPending As New Queue(Of String)(500)
    <DebuggerStepThrough>
    Public Shared Sub AddToLog(aCaller As String, aMessage As String, ParamArray aExtraVars() As Object)
        If Settings.LogDebugs = TriState.False Then Exit Sub

        Dim lOut As String

        If aExtraVars.Length > 0 Then
            lOut = String.Format("""{0}"",""{1}"",""{2}"",""{3}""", Date.Now, aCaller, aMessage, Join(aExtraVars, ","))
        Else
            lOut = String.Format("""{0}"",""{1}"",""{2}""", Date.Now, aCaller, aMessage)
        End If

        lPending.Enqueue(lOut)

        If Settings.LogDebugs = TriState.True Then
            'if in system32, send to logs
            Dim lWritter As System.IO.TextWriter
            If My.Application.Info.DirectoryPath = Environment.SystemDirectory Then
                lWritter = My.Computer.FileSystem.OpenTextFileWriter(Environment.SpecialFolder.Desktop & "\bc2.log", True)
            Else
                lWritter = My.Computer.FileSystem.OpenTextFileWriter(My.Application.Info.DirectoryPath & "\bc2.log", True)
            End If

            'pop everything on the list and write it
            Do While lPending.Count > 0
                Dim lWriteNow As String = lPending.Dequeue
                lWritter.WriteLine(lWriteNow)
            Loop

            'close and exit
            lWritter.Close()
        End If
    End Sub
End Class
