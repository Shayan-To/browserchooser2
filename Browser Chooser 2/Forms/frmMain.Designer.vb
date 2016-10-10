<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.btnInfo = New Browser_Chooser_2.FFButton()
        Me.btnAppStub = New Browser_Chooser_2.FFButton()
        Me.btnOptions = New Browser_Chooser_2.FFButton()
        Me.btnCancel = New Browser_Chooser_2.FFButton()
        Me.chkAutoClose = New Browser_Chooser_2.FFCheckBox()
        Me.tmrDelay = New System.Windows.Forms.Timer(Me.components)
        Me.chkAutoOpen = New Browser_Chooser_2.FFCheckBox()
        Me.btnCopyToClipboard = New Browser_Chooser_2.FFButton()
        Me.btnCopyToClipboardAndClose = New Browser_Chooser_2.FFButton()
        Me.cmOptions = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miEditMode = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmOptions.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnInfo
        '
        Me.btnInfo.AccessibleName = "About"
        Me.btnInfo.AutoSize = True
        Me.btnInfo.BackColor = System.Drawing.Color.Transparent
        Me.btnInfo.FlatAppearance.BorderSize = 0
        Me.btnInfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnInfo.Image = Global.Browser_Chooser_2.My.Resources.Resources._122
        Me.btnInfo.Location = New System.Drawing.Point(12, 12)
        Me.btnInfo.Margin = New System.Windows.Forms.Padding(0)
        Me.btnInfo.Name = "btnInfo"
        Me.btnInfo.ShowFocusBox = False
        Me.btnInfo.Size = New System.Drawing.Size(24, 24)
        Me.btnInfo.TabIndex = 1
        Me.btnInfo.TrapArrowKeys = False
        Me.btnInfo.UseVisualStyleBackColor = False
        '
        'btnAppStub
        '
        Me.btnAppStub.BackColor = System.Drawing.Color.Transparent
        Me.btnAppStub.FlatAppearance.BorderSize = 0
        Me.btnAppStub.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAppStub.Image = Global.Browser_Chooser_2.My.Resources.Resources.browserchooser1
        Me.btnAppStub.Location = New System.Drawing.Point(56, 1)
        Me.btnAppStub.Name = "btnAppStub"
        Me.btnAppStub.ShowFocusBox = False
        Me.btnAppStub.Size = New System.Drawing.Size(75, 80)
        Me.btnAppStub.TabIndex = 0
        Me.btnAppStub.TabStop = False
        Me.btnAppStub.TrapArrowKeys = False
        Me.btnAppStub.UseVisualStyleBackColor = False
        Me.btnAppStub.Visible = False
        '
        'btnOptions
        '
        Me.btnOptions.AccessibleName = "Options"
        Me.btnOptions.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOptions.AutoSize = True
        Me.btnOptions.BackColor = System.Drawing.Color.Transparent
        Me.btnOptions.FlatAppearance.BorderSize = 0
        Me.btnOptions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOptions.Image = Global.Browser_Chooser_2.My.Resources.Resources._128
        Me.btnOptions.Location = New System.Drawing.Point(470, 12)
        Me.btnOptions.Margin = New System.Windows.Forms.Padding(0)
        Me.btnOptions.Name = "btnOptions"
        Me.btnOptions.ShowFocusBox = False
        Me.btnOptions.Size = New System.Drawing.Size(24, 24)
        Me.btnOptions.TabIndex = 2
        Me.btnOptions.TrapArrowKeys = False
        Me.btnOptions.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Transparent
        Me.btnCancel.BackgroundImage = CType(resources.GetObject("btnCancel.BackgroundImage"), System.Drawing.Image)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Location = New System.Drawing.Point(370, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.ShowFocusBox = False
        Me.btnCancel.Size = New System.Drawing.Size(0, 0)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.TabStop = False
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.TrapArrowKeys = False
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'chkAutoClose
        '
        Me.chkAutoClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkAutoClose.AutoSize = True
        Me.chkAutoClose.BackColor = System.Drawing.Color.Transparent
        Me.chkAutoClose.Checked = True
        Me.chkAutoClose.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAutoClose.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.chkAutoClose.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.chkAutoClose.Location = New System.Drawing.Point(56, 94)
        Me.chkAutoClose.Name = "chkAutoClose"
        Me.chkAutoClose.ShowFocusBox = False
        Me.chkAutoClose.Size = New System.Drawing.Size(350, 24)
        Me.chkAutoClose.TabIndex = 5
        Me.chkAutoClose.Tag = ""
        Me.chkAutoClose.Text = "Automatically close after selecting a browser"
        Me.chkAutoClose.TrapArrowKeys = False
        Me.chkAutoClose.UseCompatibleTextRendering = True
        Me.chkAutoClose.UsesAreo = False
        Me.chkAutoClose.UseVisualStyleBackColor = True
        '
        'tmrDelay
        '
        Me.tmrDelay.Interval = 1000
        '
        'chkAutoOpen
        '
        Me.chkAutoOpen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkAutoOpen.AutoSize = True
        Me.chkAutoOpen.BackColor = System.Drawing.Color.Transparent
        Me.chkAutoOpen.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAutoOpen.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.chkAutoOpen.Location = New System.Drawing.Point(56, 127)
        Me.chkAutoOpen.Name = "chkAutoOpen"
        Me.chkAutoOpen.ShowFocusBox = False
        Me.chkAutoOpen.Size = New System.Drawing.Size(310, 22)
        Me.chkAutoOpen.TabIndex = 6
        Me.chkAutoOpen.Tag = ""
        Me.chkAutoOpen.Text = "Automatically open %1 after %2 seconds"
        Me.chkAutoOpen.TrapArrowKeys = False
        Me.chkAutoOpen.UsesAreo = False
        Me.chkAutoOpen.UseVisualStyleBackColor = False
        '
        'btnCopyToClipboard
        '
        Me.btnCopyToClipboard.AccessibleName = "Copy to clipboard"
        Me.btnCopyToClipboard.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCopyToClipboard.BackColor = System.Drawing.Color.Transparent
        Me.btnCopyToClipboard.FlatAppearance.BorderSize = 0
        Me.btnCopyToClipboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnCopyToClipboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCopyToClipboard.Image = Global.Browser_Chooser_2.My.Resources.Resources.paste_24x24
        Me.btnCopyToClipboard.Location = New System.Drawing.Point(470, 40)
        Me.btnCopyToClipboard.Margin = New System.Windows.Forms.Padding(0)
        Me.btnCopyToClipboard.Name = "btnCopyToClipboard"
        Me.btnCopyToClipboard.ShowFocusBox = False
        Me.btnCopyToClipboard.Size = New System.Drawing.Size(24, 24)
        Me.btnCopyToClipboard.TabIndex = 3
        Me.btnCopyToClipboard.TrapArrowKeys = False
        Me.btnCopyToClipboard.UseVisualStyleBackColor = False
        '
        'btnCopyToClipboardAndClose
        '
        Me.btnCopyToClipboardAndClose.AccessibleName = "Copy to clipboard and Close"
        Me.btnCopyToClipboardAndClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCopyToClipboardAndClose.BackColor = System.Drawing.Color.Transparent
        Me.btnCopyToClipboardAndClose.FlatAppearance.BorderSize = 0
        Me.btnCopyToClipboardAndClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnCopyToClipboardAndClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCopyToClipboardAndClose.Image = Global.Browser_Chooser_2.My.Resources.Resources.paste_and_close_24x24
        Me.btnCopyToClipboardAndClose.Location = New System.Drawing.Point(470, 70)
        Me.btnCopyToClipboardAndClose.Margin = New System.Windows.Forms.Padding(0)
        Me.btnCopyToClipboardAndClose.Name = "btnCopyToClipboardAndClose"
        Me.btnCopyToClipboardAndClose.ShowFocusBox = False
        Me.btnCopyToClipboardAndClose.Size = New System.Drawing.Size(24, 24)
        Me.btnCopyToClipboardAndClose.TabIndex = 4
        Me.btnCopyToClipboardAndClose.TrapArrowKeys = False
        Me.btnCopyToClipboardAndClose.UseVisualStyleBackColor = False
        '
        'cmOptions
        '
        Me.cmOptions.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miEditMode, Me.ToolStripSeparator1, Me.ToolStripMenuItem2, Me.ToolStripMenuItem3})
        Me.cmOptions.Name = "cmOptions"
        Me.cmOptions.Size = New System.Drawing.Size(183, 76)
        '
        'miEditMode
        '
        Me.miEditMode.Name = "miEditMode"
        Me.miEditMode.Size = New System.Drawing.Size(182, 22)
        Me.miEditMode.Text = "&Edit"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(182, 22)
        Me.ToolStripMenuItem2.Text = "ToolStripMenuItem2"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(182, 22)
        Me.ToolStripMenuItem3.Text = "ToolStripMenuItem3"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(179, 6)
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gold
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(501, 157)
        Me.Controls.Add(Me.btnCopyToClipboardAndClose)
        Me.Controls.Add(Me.chkAutoOpen)
        Me.Controls.Add(Me.chkAutoClose)
        Me.Controls.Add(Me.btnCopyToClipboard)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOptions)
        Me.Controls.Add(Me.btnAppStub)
        Me.Controls.Add(Me.btnInfo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain"
        Me.ShowIcon = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Choose a Browser"
        Me.TopMost = True
        Me.cmOptions.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnInfo As FFButton 'System.Windows.Forms.Button
    Friend WithEvents btnAppStub As FFButton ' System.Windows.Forms.Button
    Friend WithEvents btnOptions As FFButton ' System.Windows.Forms.Button
    Friend WithEvents btnCancel As FFButton ' System.Windows.Forms.Button
    Friend WithEvents chkAutoClose As FFCheckBox ' System.Windows.Forms.CheckBox
    Friend WithEvents tmrDelay As System.Windows.Forms.Timer
    Friend WithEvents chkAutoOpen As FFCheckBox
    Friend WithEvents btnCopyToClipboard As Browser_Chooser_2.FFButton
    Friend WithEvents btnCopyToClipboardAndClose As Browser_Chooser_2.FFButton ' System.Windows.Forms.CheckBox
    Friend WithEvents cmOptions As ContextMenuStrip
    Friend WithEvents miEditMode As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
End Class
