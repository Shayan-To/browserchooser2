Public NotInheritable Class frmAbout

    Private Sub About_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set the title of the form.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("About {0}", ApplicationTitle)
        ' Initialize all of the text displayed on the About Box.
        ' TODO: Customize the application's assembly information in the "Application" pane of the project 
        '    properties dialog (under the "Project" menu).
        Me.LabelProductName.Text = My.Application.Info.ProductName
        Me.LabelVersion.Text = String.Format("Version {0} {1}", My.Application.Info.Version.ToString, CurVersionDisplay)
        Me.LabelCopyright.Text = String.Format("{0}, Under Ms-PL", My.Application.Info.Copyright)

        txtContributors.Text = txtContributors.Text & vbCrLf & _
            "Guy Moreau " & vbCrLf & vbCrLf & _
            "--------------------------------" & vbCrLf & _
            "Browser Chooser 1 contributors: " & vbCrLf & _
            "  - Jan Ole Peek - Original BC" & vbCrLf & _
            "  - shahineo - Development" & vbCrLf & _
            "  - bmwzero - Development" & vbCrLf & _
            "  - StormPooper - Development" & vbCrLf & _
            "  - Kukag - Logo & Icon" & vbCrLf & ""

        txtAttributions.Text = txtAttributions.Text & vbCrLf & _
            "TAFactory.IconPack.dll: http://www.codeproject.com/Articles/32617/Extracting-Icons-from-EXE-DLL-and-Icon-Manipulatio licenced under " & _
            vbTab & "The Code Project Open License (CPOL) 1.02: http://www.codeproject.com/info/cpol10.aspx. " & _
            vbTab & "The only modifycation done to the project is signing of the code."
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

    Private Sub PictureBox1_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub PictureBox1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LinkLabel_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llHome.LinkClicked, llLicense.LinkClicked
        Process.Start("http://" & CType(sender, LinkLabel).Text)
    End Sub
End Class
