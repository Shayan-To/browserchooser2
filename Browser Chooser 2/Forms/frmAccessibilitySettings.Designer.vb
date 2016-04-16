<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAccessibilitySettings
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAccessibilitySettings))
		Me.chkShowVisualFocus = New System.Windows.Forms.CheckBox()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.TextBox1 = New System.Windows.Forms.TextBox()
		Me.Button1 = New System.Windows.Forms.Button()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
		Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
		Me.chkUseAccessibleRendering = New System.Windows.Forms.CheckBox()
		Me.cmdOK = New System.Windows.Forms.Button()
		Me.cmdCancel = New System.Windows.Forms.Button()
		Me.chkUseAreo = New System.Windows.Forms.CheckBox()
		Me.GroupBox1.SuspendLayout
		CType(Me.NumericUpDown1,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'chkShowVisualFocus
		'
		Me.chkShowVisualFocus.AutoSize = true
		Me.chkShowVisualFocus.Location = New System.Drawing.Point(12, 58)
		Me.chkShowVisualFocus.Name = "chkShowVisualFocus"
		Me.chkShowVisualFocus.Size = New System.Drawing.Size(116, 17)
		Me.chkShowVisualFocus.TabIndex = 2
		Me.chkShowVisualFocus.Text = "Show Visual Focus"
		Me.chkShowVisualFocus.UseVisualStyleBackColor = true
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.TextBox1)
		Me.GroupBox1.Controls.Add(Me.Button1)
		Me.GroupBox1.Controls.Add(Me.Label2)
		Me.GroupBox1.Controls.Add(Me.Label1)
		Me.GroupBox1.Controls.Add(Me.NumericUpDown1)
		Me.GroupBox1.Location = New System.Drawing.Point(12, 81)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(190, 71)
		Me.GroupBox1.TabIndex = 3
		Me.GroupBox1.TabStop = false
		Me.GroupBox1.Text = "Customize the Focus"
		'
		'TextBox1
		'
		Me.TextBox1.Enabled = false
		Me.TextBox1.Location = New System.Drawing.Point(76, 43)
		Me.TextBox1.Name = "TextBox1"
		Me.TextBox1.Size = New System.Drawing.Size(25, 20)
		Me.TextBox1.TabIndex = 3
		'
		'Button1
		'
		Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.Button1.Enabled = false
		Me.Button1.Location = New System.Drawing.Point(107, 41)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(75, 23)
		Me.Button1.TabIndex = 4
		Me.Button1.Text = "&Change"
		Me.Button1.UseVisualStyleBackColor = true
		'
		'Label2
		'
		Me.Label2.AutoSize = true
		Me.Label2.Location = New System.Drawing.Point(11, 46)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(58, 13)
		Me.Label2.TabIndex = 2
		Me.Label2.Text = "Box Color :"
		'
		'Label1
		'
		Me.Label1.AutoSize = true
		Me.Label1.Location = New System.Drawing.Point(11, 20)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(59, 13)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "Box width :"
		'
		'NumericUpDown1
		'
		Me.NumericUpDown1.Enabled = false
		Me.NumericUpDown1.Location = New System.Drawing.Point(76, 18)
		Me.NumericUpDown1.Name = "NumericUpDown1"
		Me.NumericUpDown1.Size = New System.Drawing.Size(40, 20)
		Me.NumericUpDown1.TabIndex = 1
		'
		'chkUseAccessibleRendering
		'
		Me.chkUseAccessibleRendering.AutoSize = true
		Me.chkUseAccessibleRendering.Location = New System.Drawing.Point(12, 12)
		Me.chkUseAccessibleRendering.Name = "chkUseAccessibleRendering"
		Me.chkUseAccessibleRendering.Size = New System.Drawing.Size(151, 17)
		Me.chkUseAccessibleRendering.TabIndex = 0
		Me.chkUseAccessibleRendering.Text = "Use Accessible Rendering"
		Me.chkUseAccessibleRendering.UseVisualStyleBackColor = true
		'
		'cmdOK
		'
		Me.cmdOK.Location = New System.Drawing.Point(46, 158)
		Me.cmdOK.Name = "cmdOK"
		Me.cmdOK.Size = New System.Drawing.Size(75, 23)
		Me.cmdOK.TabIndex = 4
		Me.cmdOK.Text = "&OK"
		Me.cmdOK.UseVisualStyleBackColor = true
		'
		'cmdCancel
		'
		Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.cmdCancel.Location = New System.Drawing.Point(127, 158)
		Me.cmdCancel.Name = "cmdCancel"
		Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
		Me.cmdCancel.TabIndex = 5
		Me.cmdCancel.Text = "&Cancel"
		Me.cmdCancel.UseVisualStyleBackColor = true
		'
		'chkUseAreo
		'
		Me.chkUseAreo.AutoSize = true
		Me.chkUseAreo.Location = New System.Drawing.Point(12, 35)
		Me.chkUseAreo.Name = "chkUseAreo"
		Me.chkUseAreo.Size = New System.Drawing.Size(158, 17)
		Me.chkUseAreo.TabIndex = 1
		Me.chkUseAreo.Text = "Use AREO (when available)"
		Me.chkUseAreo.UseVisualStyleBackColor = true
		'
		'frmAccessibilitySettings
		'
		Me.AcceptButton = Me.cmdOK
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.cmdCancel
		Me.ClientSize = New System.Drawing.Size(211, 187)
		Me.Controls.Add(Me.chkUseAreo)
		Me.Controls.Add(Me.cmdCancel)
		Me.Controls.Add(Me.cmdOK)
		Me.Controls.Add(Me.chkUseAccessibleRendering)
		Me.Controls.Add(Me.GroupBox1)
		Me.Controls.Add(Me.chkShowVisualFocus)
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "frmAccessibilitySettings"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Accessibility Settings"
		Me.GroupBox1.ResumeLayout(false)
		Me.GroupBox1.PerformLayout
		CType(Me.NumericUpDown1,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)
		Me.PerformLayout

End Sub
    Friend WithEvents chkShowVisualFocus As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents chkUseAccessibleRendering As System.Windows.Forms.CheckBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents chkUseAreo As System.Windows.Forms.CheckBox
End Class
