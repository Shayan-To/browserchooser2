Imports System.IO

Public Class frmImportSource
    Private mbOkayed As Boolean = False

    Private Sub rbCustom_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbCustom.CheckedChanged
        txtLocation.Enabled = True
        cmdBrowse.Enabled = True
    End Sub

    Private Sub rbOthers_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbCurrentFolder.CheckedChanged, rbUserSettings.CheckedChanged
        txtLocation.Enabled = False
        cmdBrowse.Enabled = False
    End Sub

    Private Sub cmdBrowse_Click(sender As System.Object, e As System.EventArgs) Handles cmdBrowse.Click
        If ofdCustomLocation.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtLocation.Text = ofdCustomLocation.FileName
        End If
    End Sub

    Public Function GetSource() As String 'return "" on cancel
        mbOkayed = False
        Me.TopMost = True
        Me.ShowDialog()

        If mbOkayed = True Then
            Select Case True
                Case rbUserSettings.Checked
                    Return (Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\BrowserChooser\" & LegacyNS.Legacy.Settings.BrowserChooserConfigFileName)
                Case rbCurrentFolder.Checked
                    Return Path.Combine(Application.StartupPath, LegacyNS.Legacy.Settings.BrowserChooserConfigFileName)
                Case rbCustom.Checked
                    Return txtLocation.Text
                Case Else
                    Return ""
            End Select
        Else
            Return ""
        End If
    End Function

    Private Sub cmdOK_Click(sender As System.Object, e As System.EventArgs) Handles cmdOK.Click
        'validate
        If rbCustom.Checked = True Then
            If txtLocation.Text = "" Then
                MessageBox.Show("File location cannot be blank.", "Missing information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                mbOkayed = True
                Me.Close()
            End If
        Else
            mbOkayed = True
            Me.Close()
        End If
    End Sub
End Class