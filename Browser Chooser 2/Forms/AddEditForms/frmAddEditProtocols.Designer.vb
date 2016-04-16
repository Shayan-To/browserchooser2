<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddEditProtocols
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
        Me.components = New System.ComponentModel.Container()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ofdBrowse = New System.Windows.Forms.OpenFileDialog()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtHeader = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lstBrowsers = New System.Windows.Forms.ListView()
        Me.chBrowser = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lstCategories = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lblIsDefault = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(75, 9)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(241, 20)
        Me.txtName.TabIndex = 1
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(160, 185)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK.TabIndex = 8
        Me.cmdOK.Text = "&OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(241, 185)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 9
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Name :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Header :" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.ToolTip1.SetToolTip(Me.Label2, "Examples: http; https; ftp; magnet")
        '
        'txtHeader
        '
        Me.txtHeader.Location = New System.Drawing.Point(75, 35)
        Me.txtHeader.Name = "txtHeader"
        Me.txtHeader.Size = New System.Drawing.Size(241, 20)
        Me.txtHeader.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.txtHeader, "Examples: http; https; ftp; magnet")
        '
        'lstBrowsers
        '
        Me.lstBrowsers.CheckBoxes = True
        Me.lstBrowsers.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chBrowser})
        Me.lstBrowsers.Location = New System.Drawing.Point(17, 79)
        Me.lstBrowsers.Name = "lstBrowsers"
        Me.lstBrowsers.Size = New System.Drawing.Size(146, 97)
        Me.lstBrowsers.TabIndex = 5
        Me.lstBrowsers.UseCompatibleStateImageBehavior = False
        Me.lstBrowsers.View = System.Windows.Forms.View.Details
        '
        'chBrowser
        '
        Me.chBrowser.Text = "Browser"
        Me.chBrowser.Width = 142
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Supported Browsers"
        '
        'lstCategories
        '
        Me.lstCategories.CheckBoxes = True
        Me.lstCategories.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.lstCategories.Location = New System.Drawing.Point(169, 79)
        Me.lstCategories.Name = "lstCategories"
        Me.lstCategories.Size = New System.Drawing.Size(147, 97)
        Me.lstCategories.TabIndex = 7
        Me.lstCategories.UseCompatibleStateImageBehavior = False
        Me.lstCategories.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Categories"
        Me.ColumnHeader1.Width = 143
        '
        'lblIsDefault
        '
        Me.lblIsDefault.AutoSize = True
        Me.lblIsDefault.Location = New System.Drawing.Point(166, 61)
        Me.lblIsDefault.Name = "lblIsDefault"
        Me.lblIsDefault.Size = New System.Drawing.Size(108, 13)
        Me.lblIsDefault.TabIndex = 6
        Me.lblIsDefault.Text = "Is Default in Category"
        '
        'frmAddEditProtocols
        '
        Me.AcceptButton = Me.cmdOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(327, 220)
        Me.Controls.Add(Me.lblIsDefault)
        Me.Controls.Add(Me.lstCategories)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lstBrowsers)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtHeader)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.txtName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddEditProtocols"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmAddEditType"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ofdBrowse As System.Windows.Forms.OpenFileDialog
    Protected Friend WithEvents Label2 As System.Windows.Forms.Label
    Protected Friend WithEvents txtHeader As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lstBrowsers As System.Windows.Forms.ListView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chBrowser As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstCategories As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblIsDefault As System.Windows.Forms.Label
End Class
