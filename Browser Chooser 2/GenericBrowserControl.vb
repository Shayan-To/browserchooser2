Public Class GenericBrowserControl
    Public Shared Function NormalizeTarget(ByVal target As String) As String
        ' it's possible that in portable mode you have a path to an x86 folder and are running on a 32 bit system
        ' so the strBrowser will point to an invalid browser
        If StartupLauncher.Is64Bit Then
            Dim programFiles As String = My.Computer.FileSystem.SpecialDirectories.ProgramFiles

            If (target.StartsWith(programFiles)) Then
                If (target.StartsWith(Environment.GetEnvironmentVariable("ProgramFiles(x86)")) = False) Then
                    target = target.Replace(programFiles, Environment.GetEnvironmentVariable("ProgramFiles(x86)"))
                End If
            End If
        Else
            If (target.Contains("x86")) Then
                target = target.Replace(" (x86)", "")
            End If
        End If

        Return target
    End Function
End Class
