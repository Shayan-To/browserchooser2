<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddEditURL
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddEditURL))
		Me.Label1 = New System.Windows.Forms.Label()
		Me.txtURL = New System.Windows.Forms.TextBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.cmbBrowser = New System.Windows.Forms.ComboBox()
		Me.chkShowURL = New System.Windows.Forms.CheckBox()
		Me.nudDelay = New System.Windows.Forms.NumericUpDown()
		Me.chkAutoLoad = New System.Windows.Forms.CheckBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.cmdOK = New System.Windows.Forms.Button()
		Me.cmdCancel = New System.Windows.Forms.Button()
		Me.Label4 = New System.Windows.Forms.Label()
		CType(Me.nudDelay,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'Label1
		'
		Me.Label1.AutoSize = true
		Me.Label1.Location = New System.Drawing.Point(12, 12)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(35, 13)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "URL :"
		'
		'txtURL
		'
		Me.txtURL.Location = New System.Drawing.Point(57, 9)
		Me.txtURL.Name = "txtURL"
		Me.txtURL.Size = New System.Drawing.Size(425, 20)
		Me.txtURL.TabIndex = 1
		'
		'Label2
		'
		Me.Label2.AutoSize = true
		Me.Label2.Location = New System.Drawing.Point(12, 39)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(45, 13)
		Me.Label2.TabIndex = 2
		Me.Label2.Text = "Browser"
		'
		'cmbBrowser
		'
		Me.cmbBrowser.FormattingEnabled = true
		Me.cmbBrowser.Location = New System.Drawing.Point(57, 36)
		Me.cmbBrowser.Name = "cmbBrowser"
		Me.cmbBrowser.Size = New System.Drawing.Size(121, 21)
		Me.cmbBrowser.TabIndex = 3
		'
		'chkShowURL
		'
		Me.chkShowURL.AutoSize = true
		Me.chkShowURL.Location = New System.Drawing.Point(184, 38)
		Me.chkShowURL.Name = "chkShowURL"
		Me.chkShowURL.Size = New System.Drawing.Size(78, 17)
		Me.chkShowURL.TabIndex = 4
		Me.chkShowURL.Text = "Show URL"
		Me.chkShowURL.ThreeState = true
		Me.chkShowURL.UseVisualStyleBackColor = true
		'
		'nudDelay
		'
		Me.nudDelay.Location = New System.Drawing.Point(431, 37)
		Me.nudDelay.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
		Me.nudDelay.Name = "nudDelay"
		Me.nudDelay.Size = New System.Drawing.Size(51, 20)
		Me.nudDelay.TabIndex = 5
		Me.nudDelay.Value = New Decimal(New Integer() {1, 0, 0, -2147483648})
		'
		'chkAutoLoad
		'
		Me.chkAutoLoad.AutoSize = true
		Me.chkAutoLoad.Location = New System.Drawing.Point(271, 38)
		Me.chkAutoLoad.Name = "chkAutoLoad"
		Me.chkAutoLoad.Size = New System.Drawing.Size(75, 17)
		Me.chkAutoLoad.TabIndex = 6
		Me.chkAutoLoad.Text = "Auto Load"
		Me.chkAutoLoad.UseVisualStyleBackColor = true
		'
		'Label3
		'
		Me.Label3.AutoSize = true
		Me.Label3.Location = New System.Drawing.Point(353, 36)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(72, 26)
		Me.Label3.TabIndex = 7
		Me.Label3.Text = "Delay :"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"(-1 for default)"
		'
		'cmdOK
		'
		Me.cmdOK.Location = New System.Drawing.Point(326, 63)
		Me.cmdOK.Name = "cmdOK"
		Me.cmdOK.Size = New System.Drawing.Size(75, 23)
		Me.cmdOK.TabIndex = 8
		Me.cmdOK.Text = "&OK"
		Me.cmdOK.UseVisualStyleBackColor = true
		'
		'cmdCancel
		'
		Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.cmdCancel.Location = New System.Drawing.Point(407, 63)
		Me.cmdCancel.Name = "cmdCancel"
		Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
		Me.cmdCancel.TabIndex = 9
		Me.cmdCancel.Text = "&Cancel"
		Me.cmdCancel.UseVisualStyleBackColor = true
		'
		'Label4
		'
		Me.Label4.AutoSize = true
		Me.Label4.Location = New System.Drawing.Point(15, 72)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(244, 13)
		Me.Label4.TabIndex = 10
		Me.Label4.Text = "Note: Wild cards are supported in the URL above."
		'
		'frmAddEditURL
		'
		Me.AcceptButton = Me.cmdOK
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.cmdCancel
		Me.ClientSize = New System.Drawing.Size(498, 93)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.cmdCancel)
		Me.Controls.Add(Me.cmdOK)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.chkAutoLoad)
		Me.Controls.Add(Me.nudDelay)
		Me.Controls.Add(Me.chkShowURL)
		Me.Controls.Add(Me.cmbBrowser)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.txtURL)
		Me.Controls.Add(Me.Label1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "frmAddEditURL"
		Me.ShowInTaskbar = false
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "frmAddEditURL"
		CType(Me.nudDelay,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)
		Me.PerformLayout

End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtURL As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbBrowser As System.Windows.Forms.ComboBox
    Friend WithEvents chkShowURL As System.Windows.Forms.CheckBox
    Friend WithEvents nudDelay As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkAutoLoad As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
