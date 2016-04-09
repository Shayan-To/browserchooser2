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
            "* TAFactory.IconPack.dll: http://www.codeproject.com/Articles/32617/Extracting-Icons-from-EXE-DLL-and-Icon-Manipulatio and " & vbCrLf & _
            "* OSVersionInfo.dll: http://www.codeproject.com/Articles/73000/Getting-Operating-System-Version-Info-Even-for-Win. " & vbCrLf & _
            "* A Separator Combo/List Box: http://www.codeproject.com/Articles/18971/A-Separator-Combo-List-Box. " & vbCrLf & _
            vbTab & "All licenced under " & vbCrLf & _
            vbTab & "The Code Project Open License (CPOL) 1.02: http://www.codeproject.com/info/cpol10.aspx. " & vbCrLf & _
            vbTab & "The only modifycation done to any of the projects is potentially signing of the code." & vbCrLf & _
            vbTab & vbTab & "- Separator Combo/List Box has also been turned in DLL and had issues fixed as indentifyed in that article's comments."
        'note that signing was an experiment - did not work as expected. Will be revisisted in the future.

        txtAttributions.BringToFront()
        txtAttributions.Enabled = True
        txtContributors.Enabled = False
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

    Private Function AddLine(aInput As String, aAdd As String) As String
        Return String.Format("{0}{1}{2}", aInput, aAdd, vbCrLf)
    End Function

    Private Sub cmdDiagnotics_Click(sender As System.Object, e As System.EventArgs) Handles cmdDiagnotics.Click
        Dim lResult As Boolean = False
        Dim lAPIResult As Boolean = WinAPIs.SystemParametersInfo(WinAPIs.SPI_GETSCREENREADER, 0, lResult, 0)
        Dim lMessage As String = AddLine("", String.Format("Version {0} {1}", My.Application.Info.Version.ToString, CurVersionDisplay))
        Dim lSubMessage As String = ""

        lMessage = AddLine(lMessage, String.Format("WinAPIs.SystemParametersInfo(SPI_GETSCREENREADER): {0}", lAPIResult.ToString))
        lMessage = AddLine(lMessage, String.Format("SPI_GETSCREENREADER: {0}", lResult.ToString))
        lMessage = AddLine(lMessage, String.Format("AERO Status: {0}", Utility.IsAeroEnabled.ToString))
        lMessage = AddLine(lMessage, String.Format("IsAdmin: {0}", Utility.IsAdminMode.ToString))
        lMessage = AddLine(lMessage, StrDup(50, "-"))
        lMessage = AddLine(lMessage, String.Format("Major: {0}, Minor: {1}", JCS.OSVersionInfo.MajorVersion.ToString, JCS.OSVersionInfo.MinorVersion.ToString))
        lMessage = AddLine(lMessage, StrDup(50, "-"))
        lMessage = AddLine(lMessage, String.Format("URL: {0}", StartupLauncher.URL))
        For Each lSup As Guid In StartupLauncher.SupportingBrowsers
            'find this browser in the list
            For Each lBRowser As Browser In gSettings.Browsers
                If lBRowser.GUID = lSup Then
                    If lSubMessage = "" Then
                        lSubMessage = lBRowser.Name
                    Else
                        lSubMessage = String.Format("{0},{1}", lSubMessage, lBRowser.Name)
                    End If
                End If
            Next
        Next

        lMessage = AddLine(lMessage, String.Format("Supporting Browsers: {0}", lSubMessage))


        If MessageBox.Show(String.Format("{0}{1}Do you want to copy this to the clipboard?", lMessage, vbCrLf & vbCrLf), "Diagnotic message", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
            Clipboard.SetText(lMessage)
        End If
    End Sub

    Private Sub cmdContributers_Click(sender As System.Object, e As System.EventArgs) Handles cmdContributers.Click
        txtContributors.Enabled = True
        txtContributors.BringToFront()
        txtAttributions.Enabled = False
    End Sub

    Private Sub cmdAttributions_Click(sender As System.Object, e As System.EventArgs) Handles cmdAttributions.Click
        txtAttributions.Enabled = True
        txtAttributions.BringToFront()
        txtContributors.Enabled = False
    End Sub
End Class
