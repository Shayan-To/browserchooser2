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
        Me.btnInfo = New BC2ClassicUI.FFButton()
        Me.btnAppStub = New BC2ClassicUI.FFButton()
        Me.btnOptions = New BC2ClassicUI.FFButton()
        Me.btnCancel = New BC2ClassicUI.FFButton()
        Me.chkAutoClose = New BC2ClassicUI.FFCheckBox()
        Me.tmrDelay = New System.Windows.Forms.Timer(Me.components)
        Me.chkAutoOpen = New BC2ClassicUI.FFCheckBox()
        Me.btnCopyToClipboard = New BC2ClassicUI.FFButton()
        Me.btnCopyToClipboardAndClose = New BC2ClassicUI.FFButton()
        Me.SuspendLayout
		'
		'btnInfo
		'
		Me.btnInfo.AccessibleName = "About"
		Me.btnInfo.AutoSize = true
		Me.btnInfo.BackColor = System.Drawing.Color.Transparent
		Me.btnInfo.FlatAppearance.BorderSize = 0
		Me.btnInfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
		Me.btnInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnInfo.Image = BC2_Common.My.Resources._122
        Me.btnInfo.Location = New System.Drawing.Point(12, 12)
		Me.btnInfo.Margin = New System.Windows.Forms.Padding(0)
		Me.btnInfo.Name = "btnInfo"
		Me.btnInfo.ShowFocusBox = false
		Me.btnInfo.Size = New System.Drawing.Size(24, 24)
		Me.btnInfo.TabIndex = 1
		Me.btnInfo.TrapArrowKeys = false
		Me.btnInfo.UseVisualStyleBackColor = false
		'
		'btnAppStub
		'
		Me.btnAppStub.BackColor = System.Drawing.Color.Transparent
		Me.btnAppStub.FlatAppearance.BorderSize = 0
		Me.btnAppStub.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAppStub.Image = Nothing
        Me.btnAppStub.Location = New System.Drawing.Point(56, 1)
		Me.btnAppStub.Name = "btnAppStub"
		Me.btnAppStub.ShowFocusBox = false
		Me.btnAppStub.Size = New System.Drawing.Size(75, 80)
		Me.btnAppStub.TabIndex = 0
		Me.btnAppStub.TabStop = false
		Me.btnAppStub.TrapArrowKeys = false
		Me.btnAppStub.UseVisualStyleBackColor = false
		Me.btnAppStub.Visible = false
		'
		'btnOptions
		'
		Me.btnOptions.AccessibleName = "Options"
		Me.btnOptions.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.btnOptions.AutoSize = true
		Me.btnOptions.BackColor = System.Drawing.Color.Transparent
		Me.btnOptions.FlatAppearance.BorderSize = 0
		Me.btnOptions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
		Me.btnOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOptions.Image = BC2_Common.My.Resources._128
        Me.btnOptions.Location = New System.Drawing.Point(470, 12)
		Me.btnOptions.Margin = New System.Windows.Forms.Padding(0)
		Me.btnOptions.Name = "btnOptions"
		Me.btnOptions.ShowFocusBox = false
		Me.btnOptions.Size = New System.Drawing.Size(24, 24)
		Me.btnOptions.TabIndex = 2
		Me.btnOptions.TrapArrowKeys = false
		Me.btnOptions.UseVisualStyleBackColor = false
		'
		'btnCancel
		'
		Me.btnCancel.BackColor = System.Drawing.Color.Transparent
		Me.btnCancel.BackgroundImage = CType(resources.GetObject("btnCancel.BackgroundImage"),System.Drawing.Image)
		Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCancel.FlatAppearance.BorderSize = 0
		Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnCancel.Location = New System.Drawing.Point(370, 12)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.ShowFocusBox = false
		Me.btnCancel.Size = New System.Drawing.Size(0, 0)
		Me.btnCancel.TabIndex = 6
		Me.btnCancel.TabStop = false
		Me.btnCancel.Text = "Cancel"
		Me.btnCancel.TrapArrowKeys = false
		Me.btnCancel.UseVisualStyleBackColor = false
		'
		'chkAutoClose
		'
		Me.chkAutoClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
		Me.chkAutoClose.AutoSize = true
		Me.chkAutoClose.BackColor = System.Drawing.Color.Transparent
		Me.chkAutoClose.Checked = true
		Me.chkAutoClose.CheckState = System.Windows.Forms.CheckState.Checked
		Me.chkAutoClose.Font = New System.Drawing.Font("Arial", 12!)
		Me.chkAutoClose.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
		Me.chkAutoClose.Location = New System.Drawing.Point(56, 94)
		Me.chkAutoClose.Name = "chkAutoClose"
		Me.chkAutoClose.ShowFocusBox = false
		Me.chkAutoClose.Size = New System.Drawing.Size(350, 24)
		Me.chkAutoClose.TabIndex = 5
		Me.chkAutoClose.Tag = ""
		Me.chkAutoClose.Text = "Automatically close after selecting a browser"
		Me.chkAutoClose.TrapArrowKeys = false
		Me.chkAutoClose.UseCompatibleTextRendering = true
		Me.chkAutoClose.UsesAreo = false
		Me.chkAutoClose.UseVisualStyleBackColor = true
		'
		'tmrDelay
		'
		Me.tmrDelay.Interval = 1000
		'
		'chkAutoOpen
		'
		Me.chkAutoOpen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
		Me.chkAutoOpen.AutoSize = true
		Me.chkAutoOpen.BackColor = System.Drawing.Color.Transparent
		Me.chkAutoOpen.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.chkAutoOpen.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
		Me.chkAutoOpen.Location = New System.Drawing.Point(56, 127)
		Me.chkAutoOpen.Name = "chkAutoOpen"
		Me.chkAutoOpen.ShowFocusBox = false
		Me.chkAutoOpen.Size = New System.Drawing.Size(310, 22)
		Me.chkAutoOpen.TabIndex = 6
		Me.chkAutoOpen.Tag = ""
		Me.chkAutoOpen.Text = "Automatically open %1 after %2 seconds"
		Me.chkAutoOpen.TrapArrowKeys = false
		Me.chkAutoOpen.UsesAreo = false
		Me.chkAutoOpen.UseVisualStyleBackColor = false
		'
		'btnCopyToClipboard
		'
		Me.btnCopyToClipboard.AccessibleName = "Copy to clipboard"
		Me.btnCopyToClipboard.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.btnCopyToClipboard.BackColor = System.Drawing.Color.Transparent
		Me.btnCopyToClipboard.FlatAppearance.BorderSize = 0
		Me.btnCopyToClipboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
		Me.btnCopyToClipboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCopyToClipboard.Image = BC2_Common.My.Resources.paste_24x24
        Me.btnCopyToClipboard.Location = New System.Drawing.Point(470, 40)
		Me.btnCopyToClipboard.Margin = New System.Windows.Forms.Padding(0)
		Me.btnCopyToClipboard.Name = "btnCopyToClipboard"
		Me.btnCopyToClipboard.ShowFocusBox = false
		Me.btnCopyToClipboard.Size = New System.Drawing.Size(24, 24)
		Me.btnCopyToClipboard.TabIndex = 3
		Me.btnCopyToClipboard.TrapArrowKeys = false
		Me.btnCopyToClipboard.UseVisualStyleBackColor = false
		'
		'btnCopyToClipboardAndClose
		'
		Me.btnCopyToClipboardAndClose.AccessibleName = "Copy to clipboard and Close"
		Me.btnCopyToClipboardAndClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.btnCopyToClipboardAndClose.BackColor = System.Drawing.Color.Transparent
		Me.btnCopyToClipboardAndClose.FlatAppearance.BorderSize = 0
		Me.btnCopyToClipboardAndClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
		Me.btnCopyToClipboardAndClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCopyToClipboardAndClose.Image = BC2_Common.My.Resources.paste_and_close_24x24
        Me.btnCopyToClipboardAndClose.Location = New System.Drawing.Point(470, 70)
		Me.btnCopyToClipboardAndClose.Margin = New System.Windows.Forms.Padding(0)
		Me.btnCopyToClipboardAndClose.Name = "btnCopyToClipboardAndClose"
		Me.btnCopyToClipboardAndClose.ShowFocusBox = false
		Me.btnCopyToClipboardAndClose.Size = New System.Drawing.Size(24, 24)
		Me.btnCopyToClipboardAndClose.TabIndex = 4
		Me.btnCopyToClipboardAndClose.TrapArrowKeys = false
		Me.btnCopyToClipboardAndClose.UseVisualStyleBackColor = false
		'
		'frmMain
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
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
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.KeyPreview = true
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "frmMain"
		Me.ShowIcon = false
		Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Choose a Browser"
		Me.TopMost = true
		Me.ResumeLayout(false)
		Me.PerformLayout

End Sub
    Friend WithEvents btnInfo As FFButton 'System.Windows.Forms.Button
    Friend WithEvents btnAppStub As FFButton ' System.Windows.Forms.Button
    Friend WithEvents btnOptions As FFButton ' System.Windows.Forms.Button
    Friend WithEvents btnCancel As FFButton ' System.Windows.Forms.Button
    Friend WithEvents chkAutoClose As FFCheckBox ' System.Windows.Forms.CheckBox
    Friend WithEvents tmrDelay As System.Windows.Forms.Timer
    Friend WithEvents chkAutoOpen As FFCheckBox
    Friend WithEvents btnCopyToClipboard As BC2ClassicUI.FFButton
    Friend WithEvents btnCopyToClipboardAndClose As BC2ClassicUI.FFButton ' System.Windows.Forms.CheckBox

End Class
