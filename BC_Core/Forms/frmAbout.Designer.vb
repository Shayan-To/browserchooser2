<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbout
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Friend WithEvents OKButton As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <DebuggerStepThrough()> _
    Private Sub InitializeComponent()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbout))
		Me.OKButton = New System.Windows.Forms.Button()
		Me.PictureBox1 = New System.Windows.Forms.PictureBox()
		Me.llHome = New System.Windows.Forms.LinkLabel()
		Me.PictureBox2 = New System.Windows.Forms.PictureBox()
		Me.LabelProductName = New System.Windows.Forms.Label()
		Me.LabelVersion = New System.Windows.Forms.Label()
		Me.LabelCopyright = New System.Windows.Forms.Label()
		Me.llLicense = New System.Windows.Forms.LinkLabel()
		Me.btnCopy = New System.Windows.Forms.Button()
		Me.TabControl1 = New System.Windows.Forms.TabControl()
		Me.tpInfo = New System.Windows.Forms.TabPage()
		Me.tpContrib = New System.Windows.Forms.TabPage()
		Me.tpAttributions = New System.Windows.Forms.TabPage()
		Me.tpDiagnostics = New System.Windows.Forms.TabPage()
		Me.lblDiagnostics = New System.Windows.Forms.Label()
		Me.lblContributors = New System.Windows.Forms.Label()
		Me.llFactoryPack = New System.Windows.Forms.LinkLabel()
		Me.llOSVersionInfo = New System.Windows.Forms.LinkLabel()
		Me.llSebCboLb = New System.Windows.Forms.LinkLabel()
		Me.llCPOL = New System.Windows.Forms.LinkLabel()
		Me.lblCPOL = New System.Windows.Forms.Label()
		Me.lblAttributions = New System.Windows.Forms.Label()
		CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).BeginInit
		CType(Me.PictureBox2,System.ComponentModel.ISupportInitialize).BeginInit
		Me.TabControl1.SuspendLayout
		Me.tpInfo.SuspendLayout
		Me.tpContrib.SuspendLayout
		Me.tpAttributions.SuspendLayout
		Me.tpDiagnostics.SuspendLayout
		Me.SuspendLayout
		'
		'OKButton
		'
		Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.OKButton.BackColor = System.Drawing.Color.Transparent
		Me.OKButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.OKButton.Location = New System.Drawing.Point(419, 525)
		Me.OKButton.Name = "OKButton"
		Me.OKButton.Size = New System.Drawing.Size(75, 23)
		Me.OKButton.TabIndex = 0
		Me.OKButton.Text = "&OK"
		Me.OKButton.UseVisualStyleBackColor = false
		'
		'PictureBox1
		'
		Me.PictureBox1.Image = Global.Browser_Chooser_2.My.Resources.Resources.browserchooser1
		Me.PictureBox1.Location = New System.Drawing.Point(51, 5)
		Me.PictureBox1.Name = "PictureBox1"
		Me.PictureBox1.Size = New System.Drawing.Size(390, 267)
		Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
		Me.PictureBox1.TabIndex = 1
		Me.PictureBox1.TabStop = false
		'
		'llHome
		'
		Me.llHome.AutoSize = true
		Me.llHome.Location = New System.Drawing.Point(29, 80)
		Me.llHome.Name = "llHome"
		Me.llHome.Size = New System.Drawing.Size(120, 13)
		Me.llHome.TabIndex = 2
		Me.llHome.TabStop = true
		Me.llHome.Text = "browserchooser2.com"
		'
		'PictureBox2
		'
		Me.PictureBox2.Image = Global.Browser_Chooser_2.My.Resources.Resources.world_go
		Me.PictureBox2.Location = New System.Drawing.Point(10, 78)
		Me.PictureBox2.Name = "PictureBox2"
		Me.PictureBox2.Size = New System.Drawing.Size(16, 16)
		Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
		Me.PictureBox2.TabIndex = 4
		Me.PictureBox2.TabStop = false
		'
		'LabelProductName
		'
		Me.LabelProductName.Location = New System.Drawing.Point(9, 16)
		Me.LabelProductName.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
		Me.LabelProductName.Name = "LabelProductName"
		Me.LabelProductName.Size = New System.Drawing.Size(187, 17)
		Me.LabelProductName.TabIndex = 6
		Me.LabelProductName.Text = "Product Name"
		'
		'LabelVersion
		'
		Me.LabelVersion.Location = New System.Drawing.Point(9, 33)
		Me.LabelVersion.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
		Me.LabelVersion.Name = "LabelVersion"
		Me.LabelVersion.Size = New System.Drawing.Size(187, 17)
		Me.LabelVersion.TabIndex = 9
		Me.LabelVersion.Text = "Version"
		'
		'LabelCopyright
		'
		Me.LabelCopyright.Location = New System.Drawing.Point(9, 50)
		Me.LabelCopyright.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
		Me.LabelCopyright.Name = "LabelCopyright"
		Me.LabelCopyright.Size = New System.Drawing.Size(187, 17)
		Me.LabelCopyright.TabIndex = 10
		Me.LabelCopyright.Text = "Copyright"
		'
		'llLicense
		'
		Me.llLicense.AutoSize = true
		Me.llLicense.Location = New System.Drawing.Point(29, 106)
		Me.llLicense.Name = "llLicense"
		Me.llLicense.Size = New System.Drawing.Size(294, 13)
		Me.llLicense.TabIndex = 11
		Me.llLicense.TabStop = true
		Me.llLicense.Text = "https://bitbucket.org/gmyx/browserchooser2/wiki/MSPL"
		'
		'btnCopy
		'
		Me.btnCopy.Location = New System.Drawing.Point(338, 178)
		Me.btnCopy.Name = "btnCopy"
		Me.btnCopy.Size = New System.Drawing.Size(133, 23)
		Me.btnCopy.TabIndex = 12
		Me.btnCopy.Text = "Copy to Clipboard"
		Me.btnCopy.UseVisualStyleBackColor = true
		Me.btnCopy.Visible = false
		'
		'TabControl1
		'
		Me.TabControl1.Controls.Add(Me.tpInfo)
		Me.TabControl1.Controls.Add(Me.tpContrib)
		Me.TabControl1.Controls.Add(Me.tpAttributions)
		Me.TabControl1.Controls.Add(Me.tpDiagnostics)
		Me.TabControl1.Location = New System.Drawing.Point(12, 283)
		Me.TabControl1.Name = "TabControl1"
		Me.TabControl1.SelectedIndex = 0
		Me.TabControl1.Size = New System.Drawing.Size(486, 233)
		Me.TabControl1.TabIndex = 1
		'
		'tpInfo
		'
		Me.tpInfo.Controls.Add(Me.LabelProductName)
		Me.tpInfo.Controls.Add(Me.llHome)
		Me.tpInfo.Controls.Add(Me.PictureBox2)
		Me.tpInfo.Controls.Add(Me.LabelVersion)
		Me.tpInfo.Controls.Add(Me.llLicense)
		Me.tpInfo.Controls.Add(Me.LabelCopyright)
		Me.tpInfo.Location = New System.Drawing.Point(4, 22)
		Me.tpInfo.Name = "tpInfo"
		Me.tpInfo.Padding = New System.Windows.Forms.Padding(3)
		Me.tpInfo.Size = New System.Drawing.Size(478, 207)
		Me.tpInfo.TabIndex = 0
		Me.tpInfo.Text = "Info"
		Me.tpInfo.UseVisualStyleBackColor = true
		'
		'tpContrib
		'
		Me.tpContrib.Controls.Add(Me.lblContributors)
		Me.tpContrib.Location = New System.Drawing.Point(4, 22)
		Me.tpContrib.Name = "tpContrib"
		Me.tpContrib.Padding = New System.Windows.Forms.Padding(3)
		Me.tpContrib.Size = New System.Drawing.Size(478, 207)
		Me.tpContrib.TabIndex = 1
		Me.tpContrib.Text = "Contributors"
		Me.tpContrib.UseVisualStyleBackColor = true
		'
		'tpAttributions
		'
		Me.tpAttributions.Controls.Add(Me.lblAttributions)
		Me.tpAttributions.Controls.Add(Me.lblCPOL)
		Me.tpAttributions.Controls.Add(Me.llCPOL)
		Me.tpAttributions.Controls.Add(Me.llSebCboLb)
		Me.tpAttributions.Controls.Add(Me.llOSVersionInfo)
		Me.tpAttributions.Controls.Add(Me.llFactoryPack)
		Me.tpAttributions.Location = New System.Drawing.Point(4, 22)
		Me.tpAttributions.Name = "tpAttributions"
		Me.tpAttributions.Size = New System.Drawing.Size(478, 207)
		Me.tpAttributions.TabIndex = 2
		Me.tpAttributions.Text = "Attributions"
		Me.tpAttributions.UseVisualStyleBackColor = true
		'
		'tpDiagnostics
		'
		Me.tpDiagnostics.Controls.Add(Me.btnCopy)
		Me.tpDiagnostics.Controls.Add(Me.lblDiagnostics)
		Me.tpDiagnostics.Location = New System.Drawing.Point(4, 22)
		Me.tpDiagnostics.Name = "tpDiagnostics"
		Me.tpDiagnostics.Size = New System.Drawing.Size(478, 207)
		Me.tpDiagnostics.TabIndex = 3
		Me.tpDiagnostics.Text = "Diagnostics"
		Me.tpDiagnostics.UseVisualStyleBackColor = true
		'
		'lblDiagnostics
		'
		Me.lblDiagnostics.BackColor = System.Drawing.Color.White
		Me.lblDiagnostics.ForeColor = System.Drawing.Color.Navy
		Me.lblDiagnostics.Location = New System.Drawing.Point(5, 5)
		Me.lblDiagnostics.Name = "lblDiagnostics"
		Me.lblDiagnostics.Size = New System.Drawing.Size(468, 196)
		Me.lblDiagnostics.TabIndex = 13
		'
		'lblContributors
		'
		Me.lblContributors.BackColor = System.Drawing.Color.White
		Me.lblContributors.ForeColor = System.Drawing.Color.Navy
		Me.lblContributors.Location = New System.Drawing.Point(5, 5)
		Me.lblContributors.Name = "lblContributors"
		Me.lblContributors.Size = New System.Drawing.Size(468, 196)
		Me.lblContributors.TabIndex = 14
		'
		'llFactoryPack
		'
		Me.llFactoryPack.AutoSize = true
		Me.llFactoryPack.Location = New System.Drawing.Point(3, 12)
		Me.llFactoryPack.Name = "llFactoryPack"
		Me.llFactoryPack.Size = New System.Drawing.Size(119, 13)
		Me.llFactoryPack.TabIndex = 1
		Me.llFactoryPack.TabStop = true
		Me.llFactoryPack.Text = "TAFactory.IconPack.dll"
		'
		'llOSVersionInfo
		'
		Me.llOSVersionInfo.AutoSize = true
		Me.llOSVersionInfo.Location = New System.Drawing.Point(170, 12)
		Me.llOSVersionInfo.Name = "llOSVersionInfo"
		Me.llOSVersionInfo.Size = New System.Drawing.Size(97, 13)
		Me.llOSVersionInfo.TabIndex = 2
		Me.llOSVersionInfo.TabStop = true
		Me.llOSVersionInfo.Text = "OSVersionInfo.dll"
		'
		'llSebCboLb
		'
		Me.llSebCboLb.AutoSize = true
		Me.llSebCboLb.Location = New System.Drawing.Point(324, 12)
		Me.llSebCboLb.Name = "llSebCboLb"
		Me.llSebCboLb.Size = New System.Drawing.Size(140, 13)
		Me.llSebCboLb.TabIndex = 3
		Me.llSebCboLb.TabStop = true
		Me.llSebCboLb.Text = "Separator Combo/List Box"
		'
		'llCPOL
		'
		Me.llCPOL.AutoSize = true
		Me.llCPOL.Location = New System.Drawing.Point(3, 57)
		Me.llCPOL.Name = "llCPOL"
		Me.llCPOL.Size = New System.Drawing.Size(225, 13)
		Me.llCPOL.TabIndex = 4
		Me.llCPOL.TabStop = true
		Me.llCPOL.Text = "The Code Project Open License (CPOL) 1.02"
		'
		'lblCPOL
		'
		Me.lblCPOL.AutoSize = true
		Me.lblCPOL.Location = New System.Drawing.Point(3, 40)
		Me.lblCPOL.Name = "lblCPOL"
		Me.lblCPOL.Size = New System.Drawing.Size(102, 13)
		Me.lblCPOL.TabIndex = 5
		Me.lblCPOL.Text = "All licensed under:"
		'
		'lblAttributions
		'
		Me.lblAttributions.BackColor = System.Drawing.Color.White
		Me.lblAttributions.ForeColor = System.Drawing.Color.Navy
		Me.lblAttributions.Location = New System.Drawing.Point(3, 91)
		Me.lblAttributions.Name = "lblAttributions"
		Me.lblAttributions.Size = New System.Drawing.Size(472, 116)
		Me.lblAttributions.TabIndex = 6
		'
		'frmAbout
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.White
		Me.CancelButton = Me.OKButton
		Me.ClientSize = New System.Drawing.Size(510, 560)
		Me.Controls.Add(Me.TabControl1)
		Me.Controls.Add(Me.OKButton)
		Me.Controls.Add(Me.PictureBox1)
		Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "frmAbout"
		Me.Padding = New System.Windows.Forms.Padding(9)
		Me.ShowInTaskbar = false
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "About"
		Me.TopMost = true
		CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).EndInit
		CType(Me.PictureBox2,System.ComponentModel.ISupportInitialize).EndInit
		Me.TabControl1.ResumeLayout(false)
		Me.tpInfo.ResumeLayout(false)
		Me.tpInfo.PerformLayout
		Me.tpContrib.ResumeLayout(false)
		Me.tpAttributions.ResumeLayout(false)
		Me.tpAttributions.PerformLayout
		Me.tpDiagnostics.ResumeLayout(false)
		Me.ResumeLayout(false)

End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents llHome As System.Windows.Forms.LinkLabel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents LabelProductName As System.Windows.Forms.Label
    Friend WithEvents LabelVersion As System.Windows.Forms.Label
    Friend WithEvents LabelCopyright As System.Windows.Forms.Label
    Friend WithEvents llLicense As System.Windows.Forms.LinkLabel
    Friend WithEvents btnCopy As System.Windows.Forms.Button
	Friend WithEvents TabControl1 As TabControl
	Friend WithEvents tpInfo As TabPage
	Friend WithEvents tpContrib As TabPage
	Friend WithEvents tpAttributions As TabPage
	Friend WithEvents tpDiagnostics As TabPage
	Friend WithEvents lblDiagnostics As Label
	Friend WithEvents lblContributors As Label
	Friend WithEvents llSebCboLb As LinkLabel
	Friend WithEvents llOSVersionInfo As LinkLabel
	Friend WithEvents llFactoryPack As LinkLabel
	Friend WithEvents lblCPOL As Label
	Friend WithEvents llCPOL As LinkLabel
	Friend WithEvents lblAttributions As Label
End Class
