Public Class frmAccessibilitySettings
    Private mbOkayed As Boolean = False

    Public Structure A11YSettings
        Public AccessibleRendering As Boolean
        Public ShowFocus As Boolean
        Public UseAreo As Boolean
    End Structure

    Public Function ShowSettings(ByVal aA11YSettings As A11YSettings) As Boolean
        chkUseAccessibleRendering.Checked = aA11YSettings.AccessibleRendering
        chkShowVisualFocus.Checked = aA11YSettings.ShowFocus
        chkUseAreo.Checked = aA11YSettings.UseAreo

        Me.TopMost = True
        Me.ShowDialog()

        Return mbOkayed
    End Function

    Public Function GetSettings() As A11YSettings
        Dim lOut As New A11YSettings
        lOut.AccessibleRendering = chkUseAccessibleRendering.Checked
        lOut.ShowFocus = chkShowVisualFocus.Checked
        lOut.UseAreo = chkUseAreo.Checked

        Return lOut
    End Function

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        mbOkayed = True
        Me.Hide()
    End Sub
End Class