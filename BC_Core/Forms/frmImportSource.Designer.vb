<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportSource
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImportSource))
		Me.cmdOK = New System.Windows.Forms.Button()
		Me.cmdCancel = New System.Windows.Forms.Button()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.cmdBrowse = New System.Windows.Forms.Button()
		Me.txtLocation = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.rbCustom = New System.Windows.Forms.RadioButton()
		Me.rbCurrentFolder = New System.Windows.Forms.RadioButton()
		Me.rbUserSettings = New System.Windows.Forms.RadioButton()
		Me.ofdCustomLocation = New System.Windows.Forms.OpenFileDialog()
		Me.GroupBox1.SuspendLayout
		Me.SuspendLayout
		'
		'cmdOK
		'
		Me.cmdOK.Location = New System.Drawing.Point(429, 139)
		Me.cmdOK.Name = "cmdOK"
		Me.cmdOK.Size = New System.Drawing.Size(75, 23)
		Me.cmdOK.TabIndex = 1
		Me.cmdOK.Text = "&OK"
		Me.cmdOK.UseVisualStyleBackColor = true
		'
		'cmdCancel
		'
		Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.cmdCancel.Location = New System.Drawing.Point(510, 139)
		Me.cmdCancel.Name = "cmdCancel"
		Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
		Me.cmdCancel.TabIndex = 2
		Me.cmdCancel.Text = "&Cancel"
		Me.cmdCancel.UseVisualStyleBackColor = true
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.cmdBrowse)
		Me.GroupBox1.Controls.Add(Me.txtLocation)
		Me.GroupBox1.Controls.Add(Me.Label1)
		Me.GroupBox1.Controls.Add(Me.rbCustom)
		Me.GroupBox1.Controls.Add(Me.rbCurrentFolder)
		Me.GroupBox1.Controls.Add(Me.rbUserSettings)
		Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(585, 133)
		Me.GroupBox1.TabIndex = 0
		Me.GroupBox1.TabStop = false
		Me.GroupBox1.Text = "Choose Import Source"
		'
		'cmdBrowse
		'
		Me.cmdBrowse.Enabled = false
		Me.cmdBrowse.Location = New System.Drawing.Point(504, 88)
		Me.cmdBrowse.Name = "cmdBrowse"
		Me.cmdBrowse.Size = New System.Drawing.Size(75, 23)
		Me.cmdBrowse.TabIndex = 5
		Me.cmdBrowse.Text = "&Browse"
		Me.cmdBrowse.UseVisualStyleBackColor = true
		'
		'txtLocation
		'
		Me.txtLocation.Enabled = false
		Me.txtLocation.Location = New System.Drawing.Point(91, 92)
		Me.txtLocation.Name = "txtLocation"
		Me.txtLocation.Size = New System.Drawing.Size(402, 20)
		Me.txtLocation.TabIndex = 4
		'
		'Label1
		'
		Me.Label1.AutoSize = true
		Me.Label1.Location = New System.Drawing.Point(31, 93)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(54, 13)
		Me.Label1.TabIndex = 3
		Me.Label1.Text = "Location :"
		'
		'rbCustom
		'
		Me.rbCustom.AutoSize = true
		Me.rbCustom.Location = New System.Drawing.Point(13, 68)
		Me.rbCustom.Name = "rbCustom"
		Me.rbCustom.Size = New System.Drawing.Size(60, 17)
		Me.rbCustom.TabIndex = 2
		Me.rbCustom.TabStop = true
		Me.rbCustom.Text = "Custom"
		Me.rbCustom.UseVisualStyleBackColor = true
		'
		'rbCurrentFolder
		'
		Me.rbCurrentFolder.AutoSize = true
		Me.rbCurrentFolder.Location = New System.Drawing.Point(13, 44)
		Me.rbCurrentFolder.Name = "rbCurrentFolder"
		Me.rbCurrentFolder.Size = New System.Drawing.Size(283, 17)
		Me.rbCurrentFolder.TabIndex = 1
		Me.rbCurrentFolder.TabStop = true
		Me.rbCurrentFolder.Text = "Same folder as current Executable (i.e. portable mode)."
		Me.rbCurrentFolder.UseVisualStyleBackColor = true
		'
		'rbUserSettings
		'
		Me.rbUserSettings.AutoSize = true
		Me.rbUserSettings.Location = New System.Drawing.Point(13, 20)
		Me.rbUserSettings.Name = "rbUserSettings"
		Me.rbUserSettings.Size = New System.Drawing.Size(88, 17)
		Me.rbUserSettings.TabIndex = 0
		Me.rbUserSettings.TabStop = true
		Me.rbUserSettings.Text = "User Settings"
		Me.rbUserSettings.UseVisualStyleBackColor = true
		'
		'ofdCustomLocation
		'
		Me.ofdCustomLocation.DefaultExt = "*.xml"
		Me.ofdCustomLocation.FileName = "BrowserChooserConfig.xml"
		Me.ofdCustomLocation.Filter = "BrowserChooserConfig.xml|BrowserChooserConfig.xml|All files|*.*"
		'
		'frmImportSource
		'
		Me.AcceptButton = Me.cmdOK
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.cmdCancel
		Me.ClientSize = New System.Drawing.Size(597, 174)
		Me.Controls.Add(Me.GroupBox1)
		Me.Controls.Add(Me.cmdCancel)
		Me.Controls.Add(Me.cmdOK)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "frmImportSource"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Choose import source"
		Me.GroupBox1.ResumeLayout(false)
		Me.GroupBox1.PerformLayout
		Me.ResumeLayout(false)

End Sub
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdBrowse As System.Windows.Forms.Button
    Friend WithEvents txtLocation As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rbCustom As System.Windows.Forms.RadioButton
    Friend WithEvents rbCurrentFolder As System.Windows.Forms.RadioButton
    Friend WithEvents rbUserSettings As System.Windows.Forms.RadioButton
    Friend WithEvents ofdCustomLocation As System.Windows.Forms.OpenFileDialog
End Class
