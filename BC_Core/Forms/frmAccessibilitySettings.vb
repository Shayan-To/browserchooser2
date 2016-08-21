Public Class frmAccessibilitySettings
    Private mbOkayed As Boolean = False

    Public Structure FocusSettings
        Public ShowFocus As Boolean
        Public BoxWidth As Integer
        Public BoxColor As Color
    End Structure

    Public Function ShowSettings(ByVal aA11YSettings As FocusSettings) As Boolean
        chkShowVisualFocus.Checked = aA11YSettings.ShowFocus
        nudWidth.Value = aA11YSettings.BoxWidth
        txtColor.BackColor = aA11YSettings.BoxColor

        Me.TopMost = True
        Me.ShowDialog()

        Return mbOkayed
    End Function

    Public Function GetSettings() As FocusSettings
        Dim lOut As New FocusSettings
        lOut.ShowFocus = chkShowVisualFocus.Checked
        lOut.BoxColor = txtColor.BackColor
        lOut.BoxWidth = CInt(nudWidth.Value)

        Return lOut
    End Function

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        mbOkayed = True
        Me.Hide()
    End Sub
End Class