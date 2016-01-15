Public Class frmAddEditURL
    Private mbOkayed As Boolean = False
    Private miID As Integer 'unique number used as ID

    Private Sub PopulateBrowsers(aBrowsers As Dictionary(Of Integer, Browser))
        For Each lItem As KeyValuePair(Of Integer, Browser) In aBrowsers
            cmbBrowser.Items.Add(lItem.Value)
        Next
    End Sub

    Public Function AddURL(aBrowsers As Dictionary(Of Integer, Browser)) As Boolean
        Dim lbOk As Boolean = False
        Me.Text = "Add URL"
        Me.TopMost = True
        chkAutoLoad.Checked = True
        chkShowURL.CheckState = CheckState.Indeterminate

        PopulateBrowsers(aBrowsers)
        Me.ShowDialog()

        Return mbOkayed
    End Function

    Public Function EditURL(aURL As URL, aBrowsers As Dictionary(Of Integer, Browser)) As Boolean
        Dim lbOk As Boolean = False
        Me.Text = "Edit " + aURL.URL
        Me.TopMost = True

        'populate screen
        PopulateBrowsers(aBrowsers)
        txtURL.Text = aURL.URL
        cmbBrowser.Text = aURL.Browser.Name
        chkAutoLoad.Checked = aURL.AutoLoad
        chkShowURL.CheckState = aURL.ShowURL
        nudDelay.Value = aURL.DelayTime

        Me.ShowDialog()

        Return mbOkayed
    End Function

    Public Function GetData() As URL
        'output the choices
        Dim lOut As New URL

        lOut.URL = txtURL.Text
        lOut.Browser = DirectCast(cmbBrowser.SelectedItem, Browser)
        lOut.AutoLoad = chkAutoLoad.Checked
        lOut.ShowURL = chkShowURL.CheckState
        lOut.DelayTime = CInt(nudDelay.Value)

        Return lOut
    End Function

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        If txtURL.Text = "" Then
            MessageBox.Show("You must enter a URL", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf cmbBrowser.Text = "" Then
            MessageBox.Show("You must choose a Browser", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            mbOkayed = True
            Me.Hide()
        End If
    End Sub
End Class