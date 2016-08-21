Public Class frmIcons
    Private mbResult As Boolean

    Public Function ChooseIcon(ByVal aFilename As String, ByVal aItem As Integer) As Integer
        Dim lIndex As Integer
        Dim lImageList As New ImageList
        lImageList.ImageSize = New Size(64, 64)
        lImageList.ColorDepth = ColorDepth.Depth32Bit
        lstIcons.Items.Clear()
        lstIcons.LargeImageList = lImageList
        lstIcons.SmallImageList = lImageList

        Dim lIcons() As Image = ImageUtilities.GetAllICOsFromFile(aFilename)

        For lIndex = 0 To lIcons.GetUpperBound(0)
            Try
                If Not lIcons(lIndex) Is Nothing Then
                    lImageList.Images.Add(lIndex.ToString, lIcons(lIndex))

                    Dim llviItem As ListViewItem = lstIcons.Items.Add(lIndex.ToString, lIndex.ToString, lIndex.ToString)
                    'llviItem.ImageKey = lIndex.ToString
                End If
            Catch ex As System.ArgumentException
                Exit For 'no more icons
            End Try
        Next

        If lstIcons.Items.ContainsKey(aItem.ToString) = True Then
            lstIcons.Items(aItem).Selected = True
        End If


        mbResult = False
        btnOK.Enabled = False
        Me.ShowDialog()

        If mbResult = False Then
            Return -1
        Else
            Return CInt(lstIcons.SelectedItems(0).Text)
        End If
    End Function

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If lstIcons.SelectedItems.Count > 0 Then
            mbResult = True
            Me.Hide()
        End If
    End Sub

    Private Sub lstIcons_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstIcons.SelectedIndexChanged
        If lstIcons.SelectedItems.Count > 0 Then
            btnOK.Enabled = True
        Else
            btnOK.Enabled = False
        End If

    End Sub
End Class