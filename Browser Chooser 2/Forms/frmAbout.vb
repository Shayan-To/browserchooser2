Public NotInheritable Class frmAbout

    Private Sub About_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Set the title of the form.
        Dim strApplicationTitle As String = String.Empty

		If String.IsNullOrEmpty(My.Application.Info.Title) = False Then
            strApplicationTitle = My.Application.Info.Title
        Else
            strApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If

        Me.Text = String.Format("About {0}", strApplicationTitle)

        ' Initialize all of the text displayed on the About Box.
        ' TODO: Customize the application's assembly information in the "Application" pane of the project properties dialog (under the "Project" menu).
        LabelProductName.Text = My.Application.Info.ProductName
        LabelVersion.Text = String.Format("Version {0} {1}", My.Application.Info.Version.ToString, CurVersionDisplay)
        LabelCopyright.Text = String.Format("{0}, Under Ms-PL", My.Application.Info.Copyright)

        lblContributors.Text =
            "Guy Moreau" & Environment.NewLine & _
            "J. Scott Elblein" & Environment.NewLine & _
            "--------------------------------" & Environment.NewLine & Environment.NewLine & _
            "Browser Chooser 1: " & Environment.NewLine & Environment.NewLine & _
            "Original BC: Jan Ole Peek" & Environment.NewLine & _
            "Development: shahineo" & Environment.NewLine & _
            "Development: mwzero" & Environment.NewLine & _
            "Development: StormPooper" & Environment.NewLine & _
            "Logo & Icon: Kukag"

		lblAttributions.Text =
            "The only modification done to any of the projects is potentially signing of the code." & Environment.NewLine & _
            "Separator Combo/List Box has also been turned into a DLL and had issues fixed as indentified in that article's comments."
			' NOTE: signing was an experiment - did not work as expected. Will be revisited in the future.

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

    Private Function AddLine(aInput As String, aAdd As String) As String
        Return String.Format("{0}{1}{2}", aInput, aAdd, Environment.NewLine)
	End Function

	Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged

		Select Case TabControl1.SelectedIndex

			Case 0
				' Info Tab

			Case 1
				' Contrib Tab

			Case 2
				' Att Tab

			Case 3
				' Diagnostics Tab

				Dim lResult As Boolean = False
				Dim lAPIResult As Boolean = WinAPIs.SystemParametersInfo(WinAPIs.SPI_GETSCREENREADER, 0, lResult, 0)
				Dim lMessage As String = AddLine("", String.Format("Version {0} {1}", My.Application.Info.Version.ToString, CurVersionDisplay))
				Dim lSubMessage As String = ""

				lMessage = AddLine(lMessage, String.Format("WinAPIs.SystemParametersInfo(SPI_GETSCREENREADER): {0}", lAPIResult.ToString))
				lMessage = AddLine(lMessage, String.Format("SPI_GETSCREENREADER: {0}", lResult.ToString))
				lMessage = AddLine(lMessage, String.Format("AERO Status: {0}", GeneralUtilities.IsAeroEnabled.ToString))
				lMessage = AddLine(lMessage, String.Format("IsAdmin: {0}", GeneralUtilities.IsAdminMode.ToString))
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
								lSubMessage = String.Format("{0}, {1}", lSubMessage, lBRowser.Name)
							End If
						End If
					Next
				Next

				lMessage = AddLine(lMessage, String.Format("Supported Browsers: {0}", lSubMessage))

				' Add results to the Diagnostics tab
				lblDiagnostics.Text = lmessage

				' Since we have something to copy now, make the Copy button visible
				btnCopy.Visible = True

		End Select

	End Sub

	Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click

		' User clicked the Copy to Clipboard button, so let's do so ...
		If String.IsNullOrEmpty(lblDiagnostics.text) = False Then Clipboard.SetText(lblDiagnostics.text)

	End Sub

#Region "Link Labels"

	Private Sub LinkLabel_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llHome.LinkClicked, llLicense.LinkClicked
		Launch("http://" & CType(sender, LinkLabel).Text, False)
	End Sub

	Private Sub llFactoryPack_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llFactoryPack.LinkClicked
		Launch("http://www.codeproject.com/Articles/32617/Extracting-Icons-from-EXE-DLL-and-Icon-Manipulatio", False)
	End Sub

	Private Sub llOSVersionInfo_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llOSVersionInfo.LinkClicked
		Launch("http://www.codeproject.com/Articles/73000/Getting-Operating-System-Version-Info-Even-for-Win", False)
	End Sub

	Private Sub llSebCboLb_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llSebCboLb.LinkClicked
		Launch("http://www.codeproject.com/Articles/18971/A-Separator-Combo-List-Box", False)
	End Sub

	Private Sub llCPOL_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llCPOL.LinkClicked
		Launch("http://www.codeproject.com/info/cpol10.aspx", False)
	End Sub

#End Region

End Class
