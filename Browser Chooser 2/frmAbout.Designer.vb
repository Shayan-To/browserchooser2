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
        Me.txtContributors = New System.Windows.Forms.TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.txtAttributions = New System.Windows.Forms.TextBox()
        Me.LabelProductName = New System.Windows.Forms.Label()
        Me.LabelVersion = New System.Windows.Forms.Label()
        Me.LabelCopyright = New System.Windows.Forms.Label()
        Me.llLicense = New System.Windows.Forms.LinkLabel()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OKButton
        '
        Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OKButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.OKButton.Location = New System.Drawing.Point(327, 477)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(75, 23)
        Me.OKButton.TabIndex = 0
        Me.OKButton.Text = "&OK"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Browser_Chooser_2.My.Resources.Resources.browserchooser1
        Me.PictureBox1.Location = New System.Drawing.Point(12, -38)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(390, 267)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'llHome
        '
        Me.llHome.AutoSize = True
        Me.llHome.Location = New System.Drawing.Point(43, 270)
        Me.llHome.Name = "llHome"
        Me.llHome.Size = New System.Drawing.Size(157, 13)
        Me.llHome.TabIndex = 2
        Me.llHome.TabStop = True
        Me.llHome.Text = "browserchooser2.codeplex.com"
        '
        'txtContributors
        '
        Me.txtContributors.Location = New System.Drawing.Point(12, 292)
        Me.txtContributors.Multiline = True
        Me.txtContributors.Name = "txtContributors"
        Me.txtContributors.ReadOnly = True
        Me.txtContributors.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtContributors.Size = New System.Drawing.Size(390, 85)
        Me.txtContributors.TabIndex = 3
        Me.txtContributors.Text = "Contributors:"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Browser_Chooser_2.My.Resources.Resources.world_go
        Me.PictureBox2.Location = New System.Drawing.Point(21, 270)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 4
        Me.PictureBox2.TabStop = False
        '
        'txtAttributions
        '
        Me.txtAttributions.Location = New System.Drawing.Point(12, 380)
        Me.txtAttributions.Multiline = True
        Me.txtAttributions.Name = "txtAttributions"
        Me.txtAttributions.ReadOnly = True
        Me.txtAttributions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAttributions.Size = New System.Drawing.Size(390, 85)
        Me.txtAttributions.TabIndex = 5
        Me.txtAttributions.Text = "Attributions:"
        '
        'LabelProductName
        '
        Me.LabelProductName.Location = New System.Drawing.Point(13, 232)
        Me.LabelProductName.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        Me.LabelProductName.Name = "LabelProductName"
        Me.LabelProductName.Size = New System.Drawing.Size(187, 17)
        Me.LabelProductName.TabIndex = 6
        Me.LabelProductName.Text = "Product Name"
        '
        'LabelVersion
        '
        Me.LabelVersion.Location = New System.Drawing.Point(215, 232)
        Me.LabelVersion.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        Me.LabelVersion.Name = "LabelVersion"
        Me.LabelVersion.Size = New System.Drawing.Size(187, 17)
        Me.LabelVersion.TabIndex = 9
        Me.LabelVersion.Text = "Version"
        '
        'LabelCopyright
        '
        Me.LabelCopyright.Location = New System.Drawing.Point(13, 249)
        Me.LabelCopyright.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        Me.LabelCopyright.Name = "LabelCopyright"
        Me.LabelCopyright.Size = New System.Drawing.Size(187, 17)
        Me.LabelCopyright.TabIndex = 10
        Me.LabelCopyright.Text = "Copyright"
        '
        'llLicense
        '
        Me.llLicense.AutoSize = True
        Me.llLicense.Location = New System.Drawing.Point(215, 270)
        Me.llLicense.Name = "llLicense"
        Me.llLicense.Size = New System.Drawing.Size(195, 13)
        Me.llLicense.TabIndex = 11
        Me.llLicense.TabStop = True
        Me.llLicense.Text = "browserchooser2.codeplex.com/license"
        '
        'frmAbout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.OKButton
        Me.ClientSize = New System.Drawing.Size(414, 512)
        Me.Controls.Add(Me.llLicense)
        Me.Controls.Add(Me.LabelCopyright)
        Me.Controls.Add(Me.LabelVersion)
        Me.Controls.Add(Me.LabelProductName)
        Me.Controls.Add(Me.txtAttributions)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.txtContributors)
        Me.Controls.Add(Me.llHome)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAbout"
        Me.Padding = New System.Windows.Forms.Padding(9)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "About"
        Me.TopMost = True
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents llHome As System.Windows.Forms.LinkLabel
    Friend WithEvents txtContributors As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents txtAttributions As System.Windows.Forms.TextBox
    Friend WithEvents LabelProductName As System.Windows.Forms.Label
    Friend WithEvents LabelVersion As System.Windows.Forms.Label
    Friend WithEvents LabelCopyright As System.Windows.Forms.Label
    Friend WithEvents llLicense As System.Windows.Forms.LinkLabel

End Class
