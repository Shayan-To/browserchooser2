<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIcons
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIcons))
		Me.lstIcons = New System.Windows.Forms.ListView()
		Me.btnOK = New System.Windows.Forms.Button()
		Me.btnCancel = New System.Windows.Forms.Button()
		Me.SuspendLayout
		'
		'lstIcons
		'
		Me.lstIcons.AccessibleName = "Icons List"
		Me.lstIcons.Dock = System.Windows.Forms.DockStyle.Top
		Me.lstIcons.GridLines = true
		Me.lstIcons.Location = New System.Drawing.Point(0, 0)
		Me.lstIcons.Name = "lstIcons"
		Me.lstIcons.Size = New System.Drawing.Size(581, 276)
		Me.lstIcons.TabIndex = 0
		Me.lstIcons.TileSize = New System.Drawing.Size(96, 96)
		Me.lstIcons.UseCompatibleStateImageBehavior = false
		'
		'btnOK
		'
		Me.btnOK.Location = New System.Drawing.Point(413, 282)
		Me.btnOK.Name = "btnOK"
		Me.btnOK.Size = New System.Drawing.Size(75, 23)
		Me.btnOK.TabIndex = 1
		Me.btnOK.Text = "&OK"
		Me.btnOK.UseVisualStyleBackColor = true
		'
		'btnCancel
		'
		Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCancel.Location = New System.Drawing.Point(494, 282)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(75, 23)
		Me.btnCancel.TabIndex = 2
		Me.btnCancel.Text = "&Cancel"
		Me.btnCancel.UseVisualStyleBackColor = true
		'
		'frmIcons
		'
		Me.AcceptButton = Me.btnOK
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.btnCancel
		Me.ClientSize = New System.Drawing.Size(581, 317)
		Me.Controls.Add(Me.btnCancel)
		Me.Controls.Add(Me.btnOK)
		Me.Controls.Add(Me.lstIcons)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "frmIcons"
		Me.ShowInTaskbar = false
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Choose your icon"
		Me.TopMost = true
		Me.ResumeLayout(false)

End Sub
    Friend WithEvents lstIcons As System.Windows.Forms.ListView
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
