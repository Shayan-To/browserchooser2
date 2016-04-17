<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddEditBrowser
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddEditBrowser))
		Me.txtName = New System.Windows.Forms.TextBox()
		Me.chkIsActive = New System.Windows.Forms.CheckBox()
		Me.cmdOK = New System.Windows.Forms.Button()
		Me.cmdCancel = New System.Windows.Forms.Button()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.grpTarget = New System.Windows.Forms.GroupBox()
		Me.CheckBox1 = New System.Windows.Forms.CheckBox()
		Me.Label9 = New System.Windows.Forms.Label()
		Me.txtArguments = New System.Windows.Forms.TextBox()
		Me.chkIEBehaviour = New System.Windows.Forms.CheckBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.cmdTargetBrowse = New System.Windows.Forms.Button()
		Me.txtTarget = New System.Windows.Forms.TextBox()
		Me.grpImage = New System.Windows.Forms.GroupBox()
		Me.nudScale = New System.Windows.Forms.NumericUpDown()
		Me.Label8 = New System.Windows.Forms.Label()
		Me.btnViewAvailable = New System.Windows.Forms.Button()
		Me.nudIconIndex = New System.Windows.Forms.NumericUpDown()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.cmdImageBrowse = New System.Windows.Forms.Button()
		Me.txtImagePath = New System.Windows.Forms.TextBox()
		Me.cmbStandard = New System.Windows.Forms.ComboBox()
		Me.ofdBrowse = New System.Windows.Forms.OpenFileDialog()
		Me.grpPosition = New System.Windows.Forms.GroupBox()
		Me.chkVisible = New System.Windows.Forms.CheckBox()
		Me.nudY = New System.Windows.Forms.NumericUpDown()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.nudX = New System.Windows.Forms.NumericUpDown()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.grpHotkey = New System.Windows.Forms.GroupBox()
		Me.txtHotkey = New System.Windows.Forms.TextBox()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.lblCategory = New System.Windows.Forms.Label()
		Me.cmbCategory = New System.Windows.Forms.ComboBox()
		Me.cmdHelpCategory = New System.Windows.Forms.Button()
		Me.cmdShowProtocols = New System.Windows.Forms.Button()
		Me.cmdShowExtentions = New System.Windows.Forms.Button()
		Me.lstSupportedProps = New System.Windows.Forms.ListView()
		Me.grpTarget.SuspendLayout
		Me.grpImage.SuspendLayout
		CType(Me.nudScale,System.ComponentModel.ISupportInitialize).BeginInit
		CType(Me.nudIconIndex,System.ComponentModel.ISupportInitialize).BeginInit
		Me.grpPosition.SuspendLayout
		CType(Me.nudY,System.ComponentModel.ISupportInitialize).BeginInit
		CType(Me.nudX,System.ComponentModel.ISupportInitialize).BeginInit
		Me.grpHotkey.SuspendLayout
		Me.SuspendLayout
		'
		'txtName
		'
		Me.txtName.Location = New System.Drawing.Point(66, 9)
		Me.txtName.Name = "txtName"
		Me.txtName.Size = New System.Drawing.Size(354, 20)
		Me.txtName.TabIndex = 1
		'
		'chkIsActive
		'
		Me.chkIsActive.AutoSize = true
		Me.chkIsActive.Location = New System.Drawing.Point(426, 12)
		Me.chkIsActive.Name = "chkIsActive"
		Me.chkIsActive.Size = New System.Drawing.Size(67, 17)
		Me.chkIsActive.TabIndex = 2
		Me.chkIsActive.Text = "Is Active"
		Me.chkIsActive.UseVisualStyleBackColor = true
		Me.chkIsActive.Visible = false
		'
		'cmdOK
		'
		Me.cmdOK.Location = New System.Drawing.Point(350, 303)
		Me.cmdOK.Name = "cmdOK"
		Me.cmdOK.Size = New System.Drawing.Size(75, 23)
		Me.cmdOK.TabIndex = 12
		Me.cmdOK.Text = "&OK"
		Me.cmdOK.UseVisualStyleBackColor = true
		'
		'cmdCancel
		'
		Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.cmdCancel.Location = New System.Drawing.Point(431, 303)
		Me.cmdCancel.Name = "cmdCancel"
		Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
		Me.cmdCancel.TabIndex = 13
		Me.cmdCancel.Text = "&Cancel"
		Me.cmdCancel.UseVisualStyleBackColor = true
		'
		'Label1
		'
		Me.Label1.AutoSize = true
		Me.Label1.Location = New System.Drawing.Point(12, 9)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(41, 13)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "Name :"
		'
		'grpTarget
		'
		Me.grpTarget.Controls.Add(Me.CheckBox1)
		Me.grpTarget.Controls.Add(Me.Label9)
		Me.grpTarget.Controls.Add(Me.txtArguments)
		Me.grpTarget.Controls.Add(Me.chkIEBehaviour)
		Me.grpTarget.Controls.Add(Me.Label2)
		Me.grpTarget.Controls.Add(Me.cmdTargetBrowse)
		Me.grpTarget.Controls.Add(Me.txtTarget)
		Me.grpTarget.Location = New System.Drawing.Point(12, 61)
		Me.grpTarget.Name = "grpTarget"
		Me.grpTarget.Size = New System.Drawing.Size(500, 104)
		Me.grpTarget.TabIndex = 6
		Me.grpTarget.TabStop = false
		Me.grpTarget.Text = "Target"
		'
		'CheckBox1
		'
		Me.CheckBox1.AutoSize = true
		Me.CheckBox1.Location = New System.Drawing.Point(212, 45)
		Me.CheckBox1.Name = "CheckBox1"
		Me.CheckBox1.Size = New System.Drawing.Size(68, 17)
		Me.CheckBox1.TabIndex = 4
		Me.CheckBox1.Text = "Is Edge?"
		Me.CheckBox1.UseVisualStyleBackColor = true
		'
		'Label9
		'
		Me.Label9.AutoSize = true
		Me.Label9.Location = New System.Drawing.Point(5, 69)
		Me.Label9.Name = "Label9"
		Me.Label9.Size = New System.Drawing.Size(63, 26)
		Me.Label9.TabIndex = 5
		Me.Label9.Text = "Arguments :"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"(Optional)"
		'
		'txtArguments
		'
		Me.txtArguments.Location = New System.Drawing.Point(86, 68)
		Me.txtArguments.Name = "txtArguments"
		Me.txtArguments.Size = New System.Drawing.Size(327, 20)
		Me.txtArguments.TabIndex = 6
		'
		'chkIEBehaviour
		'
		Me.chkIEBehaviour.AutoSize = true
		Me.chkIEBehaviour.Location = New System.Drawing.Point(86, 45)
		Me.chkIEBehaviour.Name = "chkIEBehaviour"
		Me.chkIEBehaviour.Size = New System.Drawing.Size(120, 17)
		Me.chkIEBehaviour.TabIndex = 3
		Me.chkIEBehaviour.Text = "Is Internet Explorer?"
		Me.chkIEBehaviour.UseVisualStyleBackColor = true
		'
		'Label2
		'
		Me.Label2.AutoSize = true
		Me.Label2.Location = New System.Drawing.Point(5, 20)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(35, 13)
		Me.Label2.TabIndex = 0
		Me.Label2.Text = "Path :"
		'
		'cmdTargetBrowse
		'
		Me.cmdTargetBrowse.Location = New System.Drawing.Point(419, 15)
		Me.cmdTargetBrowse.Name = "cmdTargetBrowse"
		Me.cmdTargetBrowse.Size = New System.Drawing.Size(75, 23)
		Me.cmdTargetBrowse.TabIndex = 2
		Me.cmdTargetBrowse.Text = "&Browse"
		Me.cmdTargetBrowse.UseVisualStyleBackColor = true
		'
		'txtTarget
		'
		Me.txtTarget.Location = New System.Drawing.Point(86, 19)
		Me.txtTarget.Name = "txtTarget"
		Me.txtTarget.Size = New System.Drawing.Size(327, 20)
		Me.txtTarget.TabIndex = 1
		'
		'grpImage
		'
		Me.grpImage.Controls.Add(Me.nudScale)
		Me.grpImage.Controls.Add(Me.Label8)
		Me.grpImage.Controls.Add(Me.btnViewAvailable)
		Me.grpImage.Controls.Add(Me.nudIconIndex)
		Me.grpImage.Controls.Add(Me.Label7)
		Me.grpImage.Controls.Add(Me.Label3)
		Me.grpImage.Controls.Add(Me.cmdImageBrowse)
		Me.grpImage.Controls.Add(Me.txtImagePath)
		Me.grpImage.Controls.Add(Me.cmbStandard)
		Me.grpImage.Location = New System.Drawing.Point(12, 171)
		Me.grpImage.Name = "grpImage"
		Me.grpImage.Size = New System.Drawing.Size(500, 77)
		Me.grpImage.TabIndex = 7
		Me.grpImage.TabStop = false
		Me.grpImage.Text = "Image (Optional)"
		'
		'nudScale
		'
		Me.nudScale.DecimalPlaces = 2
		Me.nudScale.Increment = New Decimal(New Integer() {25, 0, 0, 131072})
		Me.nudScale.Location = New System.Drawing.Point(266, 46)
		Me.nudScale.Name = "nudScale"
		Me.nudScale.Size = New System.Drawing.Size(120, 20)
		Me.nudScale.TabIndex = 8
		Me.nudScale.Value = New Decimal(New Integer() {1, 0, 0, 0})
		'
		'Label8
		'
		Me.Label8.AutoSize = true
		Me.Label8.Location = New System.Drawing.Point(220, 48)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(40, 13)
		Me.Label8.TabIndex = 7
		Me.Label8.Text = "Scale :"
		'
		'btnViewAvailable
		'
		Me.btnViewAvailable.Location = New System.Drawing.Point(126, 43)
		Me.btnViewAvailable.Name = "btnViewAvailable"
		Me.btnViewAvailable.Size = New System.Drawing.Size(88, 23)
		Me.btnViewAvailable.TabIndex = 6
		Me.btnViewAvailable.Text = "&View Available"
		Me.btnViewAvailable.UseVisualStyleBackColor = true
		'
		'nudIconIndex
		'
		Me.nudIconIndex.Location = New System.Drawing.Point(54, 46)
		Me.nudIconIndex.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
		Me.nudIconIndex.Name = "nudIconIndex"
		Me.nudIconIndex.Size = New System.Drawing.Size(63, 20)
		Me.nudIconIndex.TabIndex = 5
		'
		'Label7
		'
		Me.Label7.AutoSize = true
		Me.Label7.Location = New System.Drawing.Point(5, 48)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(39, 13)
		Me.Label7.TabIndex = 4
		Me.Label7.Text = "Index :"
		'
		'Label3
		'
		Me.Label3.AutoSize = true
		Me.Label3.Location = New System.Drawing.Point(5, 22)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(35, 13)
		Me.Label3.TabIndex = 0
		Me.Label3.Text = "Path :"
		'
		'cmdImageBrowse
		'
		Me.cmdImageBrowse.Location = New System.Drawing.Point(419, 17)
		Me.cmdImageBrowse.Name = "cmdImageBrowse"
		Me.cmdImageBrowse.Size = New System.Drawing.Size(75, 23)
		Me.cmdImageBrowse.TabIndex = 3
		Me.cmdImageBrowse.Text = "B&rowse"
		Me.cmdImageBrowse.UseVisualStyleBackColor = true
		'
		'txtImagePath
		'
		Me.txtImagePath.Location = New System.Drawing.Point(178, 19)
		Me.txtImagePath.Name = "txtImagePath"
		Me.txtImagePath.Size = New System.Drawing.Size(235, 20)
		Me.txtImagePath.TabIndex = 2
		'
		'cmbStandard
		'
		Me.cmbStandard.FormattingEnabled = true
		Me.cmbStandard.Items.AddRange(New Object() {"(Extract)", "(Custom)"})
		Me.cmbStandard.Location = New System.Drawing.Point(54, 19)
		Me.cmbStandard.Name = "cmbStandard"
		Me.cmbStandard.Size = New System.Drawing.Size(118, 21)
		Me.cmbStandard.TabIndex = 1
		'
		'grpPosition
		'
		Me.grpPosition.Controls.Add(Me.chkVisible)
		Me.grpPosition.Controls.Add(Me.nudY)
		Me.grpPosition.Controls.Add(Me.Label5)
		Me.grpPosition.Controls.Add(Me.nudX)
		Me.grpPosition.Controls.Add(Me.Label4)
		Me.grpPosition.Location = New System.Drawing.Point(12, 254)
		Me.grpPosition.Name = "grpPosition"
		Me.grpPosition.Size = New System.Drawing.Size(272, 43)
		Me.grpPosition.TabIndex = 8
		Me.grpPosition.TabStop = false
		Me.grpPosition.Text = "Position"
		'
		'chkVisible
		'
		Me.chkVisible.AutoSize = true
		Me.chkVisible.Checked = true
		Me.chkVisible.CheckState = System.Windows.Forms.CheckState.Indeterminate
		Me.chkVisible.Location = New System.Drawing.Point(54, 0)
		Me.chkVisible.Name = "chkVisible"
		Me.chkVisible.Size = New System.Drawing.Size(56, 17)
		Me.chkVisible.TabIndex = 0
		Me.chkVisible.Text = "Visible"
		Me.chkVisible.UseVisualStyleBackColor = true
		'
		'nudY
		'
		Me.nudY.Location = New System.Drawing.Point(159, 19)
		Me.nudY.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
		Me.nudY.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
		Me.nudY.Name = "nudY"
		Me.nudY.Size = New System.Drawing.Size(63, 20)
		Me.nudY.TabIndex = 4
		Me.nudY.Value = New Decimal(New Integer() {1, 0, 0, 0})
		'
		'Label5
		'
		Me.Label5.AutoSize = true
		Me.Label5.Location = New System.Drawing.Point(114, 22)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(51, 13)
		Me.Label5.TabIndex = 3
		Me.Label5.Text = "Column : "
		'
		'nudX
		'
		Me.nudX.Location = New System.Drawing.Point(45, 19)
		Me.nudX.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
		Me.nudX.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
		Me.nudX.Name = "nudX"
		Me.nudX.Size = New System.Drawing.Size(63, 20)
		Me.nudX.TabIndex = 2
		Me.nudX.Value = New Decimal(New Integer() {1, 0, 0, 0})
		'
		'Label4
		'
		Me.Label4.AutoSize = true
		Me.Label4.Location = New System.Drawing.Point(5, 21)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(38, 13)
		Me.Label4.TabIndex = 1
		Me.Label4.Text = "Row : "
		'
		'grpHotkey
		'
		Me.grpHotkey.Controls.Add(Me.txtHotkey)
		Me.grpHotkey.Controls.Add(Me.Label6)
		Me.grpHotkey.Location = New System.Drawing.Point(290, 254)
		Me.grpHotkey.Name = "grpHotkey"
		Me.grpHotkey.Size = New System.Drawing.Size(222, 43)
		Me.grpHotkey.TabIndex = 9
		Me.grpHotkey.TabStop = false
		Me.grpHotkey.Text = "Hotkey"
		'
		'txtHotkey
		'
		Me.txtHotkey.Location = New System.Drawing.Point(74, 19)
		Me.txtHotkey.MaxLength = 1
		Me.txtHotkey.Name = "txtHotkey"
		Me.txtHotkey.Size = New System.Drawing.Size(136, 20)
		Me.txtHotkey.TabIndex = 1
		'
		'Label6
		'
		Me.Label6.AutoSize = true
		Me.Label6.Location = New System.Drawing.Point(6, 21)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(59, 13)
		Me.Label6.TabIndex = 0
		Me.Label6.Text = "Character :"
		'
		'lblCategory
		'
		Me.lblCategory.AutoSize = true
		Me.lblCategory.Location = New System.Drawing.Point(12, 35)
		Me.lblCategory.Name = "lblCategory"
		Me.lblCategory.Size = New System.Drawing.Size(55, 13)
		Me.lblCategory.TabIndex = 3
		Me.lblCategory.Text = "Category :"
		'
		'cmbCategory
		'
		Me.cmbCategory.FormattingEnabled = true
		Me.cmbCategory.Location = New System.Drawing.Point(66, 35)
		Me.cmbCategory.Name = "cmbCategory"
		Me.cmbCategory.Size = New System.Drawing.Size(354, 21)
		Me.cmbCategory.TabIndex = 4
		'
		'cmdHelpCategory
		'
		Me.cmdHelpCategory.Location = New System.Drawing.Point(420, 33)
		Me.cmdHelpCategory.Name = "cmdHelpCategory"
		Me.cmdHelpCategory.Size = New System.Drawing.Size(26, 23)
		Me.cmdHelpCategory.TabIndex = 5
		Me.cmdHelpCategory.Text = "?"
		Me.cmdHelpCategory.UseVisualStyleBackColor = true
		'
		'cmdShowProtocols
		'
		Me.cmdShowProtocols.Location = New System.Drawing.Point(12, 303)
		Me.cmdShowProtocols.Name = "cmdShowProtocols"
		Me.cmdShowProtocols.Size = New System.Drawing.Size(108, 23)
		Me.cmdShowProtocols.TabIndex = 10
		Me.cmdShowProtocols.Text = "Show Protocols"
		Me.cmdShowProtocols.UseVisualStyleBackColor = true
		'
		'cmdShowExtentions
		'
		Me.cmdShowExtentions.Location = New System.Drawing.Point(126, 303)
		Me.cmdShowExtentions.Name = "cmdShowExtentions"
		Me.cmdShowExtentions.Size = New System.Drawing.Size(108, 23)
		Me.cmdShowExtentions.TabIndex = 11
		Me.cmdShowExtentions.Text = "Show Extentions"
		Me.cmdShowExtentions.UseVisualStyleBackColor = true
		'
		'lstSupportedProps
		'
		Me.lstSupportedProps.CheckBoxes = true
		Me.lstSupportedProps.Enabled = false
		Me.lstSupportedProps.Location = New System.Drawing.Point(12, 332)
		Me.lstSupportedProps.MultiSelect = false
		Me.lstSupportedProps.Name = "lstSupportedProps"
		Me.lstSupportedProps.Size = New System.Drawing.Size(494, 97)
		Me.lstSupportedProps.TabIndex = 14
		Me.lstSupportedProps.UseCompatibleStateImageBehavior = false
		Me.lstSupportedProps.View = System.Windows.Forms.View.Details
		'
		'frmAddEditBrowser
		'
		Me.AcceptButton = Me.cmdOK
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.cmdCancel
		Me.ClientSize = New System.Drawing.Size(513, 481)
		Me.Controls.Add(Me.lstSupportedProps)
		Me.Controls.Add(Me.cmdShowExtentions)
		Me.Controls.Add(Me.cmdShowProtocols)
		Me.Controls.Add(Me.cmdHelpCategory)
		Me.Controls.Add(Me.cmbCategory)
		Me.Controls.Add(Me.lblCategory)
		Me.Controls.Add(Me.grpHotkey)
		Me.Controls.Add(Me.grpPosition)
		Me.Controls.Add(Me.grpImage)
		Me.Controls.Add(Me.grpTarget)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.cmdCancel)
		Me.Controls.Add(Me.cmdOK)
		Me.Controls.Add(Me.chkIsActive)
		Me.Controls.Add(Me.txtName)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "frmAddEditBrowser"
		Me.ShowInTaskbar = false
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "frmAddEditBrowser"
		Me.grpTarget.ResumeLayout(false)
		Me.grpTarget.PerformLayout
		Me.grpImage.ResumeLayout(false)
		Me.grpImage.PerformLayout
		CType(Me.nudScale,System.ComponentModel.ISupportInitialize).EndInit
		CType(Me.nudIconIndex,System.ComponentModel.ISupportInitialize).EndInit
		Me.grpPosition.ResumeLayout(false)
		Me.grpPosition.PerformLayout
		CType(Me.nudY,System.ComponentModel.ISupportInitialize).EndInit
		CType(Me.nudX,System.ComponentModel.ISupportInitialize).EndInit
		Me.grpHotkey.ResumeLayout(false)
		Me.grpHotkey.PerformLayout
		Me.ResumeLayout(false)
		Me.PerformLayout

End Sub
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents chkIsActive As System.Windows.Forms.CheckBox
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grpTarget As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdTargetBrowse As System.Windows.Forms.Button
    Friend WithEvents txtTarget As System.Windows.Forms.TextBox
    Friend WithEvents grpImage As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdImageBrowse As System.Windows.Forms.Button
    Friend WithEvents txtImagePath As System.Windows.Forms.TextBox
    Friend WithEvents cmbStandard As System.Windows.Forms.ComboBox
    Friend WithEvents ofdBrowse As System.Windows.Forms.OpenFileDialog
    Friend WithEvents chkIEBehaviour As System.Windows.Forms.CheckBox
    Friend WithEvents grpPosition As System.Windows.Forms.GroupBox
    Friend WithEvents nudX As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents nudY As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents grpHotkey As System.Windows.Forms.GroupBox
    Friend WithEvents txtHotkey As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnViewAvailable As System.Windows.Forms.Button
    Friend WithEvents nudIconIndex As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblCategory As System.Windows.Forms.Label
    Friend WithEvents cmbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents cmdHelpCategory As System.Windows.Forms.Button
    Friend WithEvents cmdShowProtocols As System.Windows.Forms.Button
    Friend WithEvents cmdShowExtentions As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtArguments As System.Windows.Forms.TextBox
    Friend WithEvents lstSupportedProps As System.Windows.Forms.ListView
    Friend WithEvents nudScale As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents chkVisible As System.Windows.Forms.CheckBox
End Class
