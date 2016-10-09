Public Class frmAddEditType
    '    Private mbOkayed As Boolean = False

    '    Private Sub PopulateCategories(ByVal aBrowsers As Dictionary(Of Integer, Browser), ByVal aDefaultCategories As List(Of String))
    '        lstCategories.Items.Clear()
    '        For Each lBrowser As KeyValuePair(Of Integer, Browser) In aBrowsers
    '            If lstCategories.Items.ContainsKey(lBrowser.Value.Category) = False Then
    '                Dim llsiItem As ListViewItem = lstCategories.Items.Add(lBrowser.Value.Category, lBrowser.Value.Category, "")
    '                If aDefaultCategories.Contains(lBrowser.Value.Category) = True Then
    '                    llsiItem.Checked = True
    '                End If
    '            End If
    '        Next
    '    End Sub

    '    Private Sub PopulateBrowsers(ByVal aBrowsers As Dictionary(Of Integer, Browser), ByVal aSupported As List(Of Guid))
    '        lstBrowsers.Items.Clear()

    '        For Each lItem As KeyValuePair(Of Integer, Browser) In aBrowsers
    '            Dim llsiItem As ListViewItem = lstBrowsers.Items.Add(lItem.Value.Name)
    '            llsiItem.Tag = lItem.Value

    '            If IsNothing(aSupported) = False Then
    '                If aSupported.Contains(lItem.Value.GUID) = True Then
    '                    llsiItem.Checked = True
    '                End If
    '            End If
    '        Next
    '    End Sub

    '    Public Function AddType(ByVal aBrowsers As Dictionary(Of Integer, Browser)) As Boolean
    '        Me.Text = "Add FileType"
    '        Me.TopMost = True
    '        PopulateBrowsers(aBrowsers, Nothing)
    '        PopulateCategories(aBrowsers, New List(Of String) From {GeneralUtilities.DEFAULT_CATEGORY})

    '        Me.ShowDialog()

    '        Return mbOkayed
    '    End Function

    '    Public Function EditType(ByVal aFileType As FileType, ByVal aBrowsers As Dictionary(Of Integer, Browser)) As Boolean
    '        Me.Text = "Edit FileType"
    '        Me.TopMost = True
    '        PopulateBrowsers(aBrowsers, aFileType.SupportingBrowsers)
    '        PopulateCategories(aBrowsers, aFileType.DefaultCategories)


    '        txtName.Text = aFileType.FiletypeName
    '        txtHeader.Text = aFileType.Extention

    '        Me.ShowDialog()

    '        Return mbOkayed
    '    End Function

    '    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
    '        'validate screen
    '        If txtName.Text = "" Then
    '            MessageBox.Show("Name cannot be empty", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '            Exit Sub
    '        End If

    '        If txtHeader.Text = "" Then
    '            MessageBox.Show("Header cannot be empty. ", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '            Exit Sub
    '        End If

    '        mbOkayed = True

    '        Me.Hide()
    '    End Sub

    '    Public Function GetData() As FileType
    '        'ensure there is no loading period
    '        If txtName.Text.Chars(0) = "." Then
    '            txtName.Text = Mid(txtName.Text, 2)
    '        End If

    '        'output the choices
    '        Dim lOut As New FileType
    '        lOut.FiletypeName = txtName.Text
    '        lOut.Extention = txtHeader.Text
    '        lOut.SupportingBrowsers = New List(Of Guid)
    '        lOut.DefaultCategories = New List(Of String)

    '        'supported browsers, checked
    '        For Each llsiItem As ListViewItem In lstBrowsers.Items
    '            If llsiItem.Checked = True Then
    '                lOut.SupportingBrowsers.Add(DirectCast(llsiItem.Tag, Browser).GUID)
    '            End If
    '        Next

    '        'default browsers, checked
    '        For Each llsiItem As ListViewItem In lstCategories.Items
    '            If llsiItem.Checked = True Then
    '                lOut.DefaultCategories.Add(llsiItem.Text)
    '            End If
    '        Next

    '        Return lOut
    '    End Function
End Class