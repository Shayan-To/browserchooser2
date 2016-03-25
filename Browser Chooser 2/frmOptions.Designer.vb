<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOptions
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.tabSettings = New System.Windows.Forms.TabControl()
        Me.tabBrowsers = New System.Windows.Forms.TabPage()
        Me.cmdDetectBrowsers = New System.Windows.Forms.Button()
        Me.cmdBrowserClone = New System.Windows.Forms.Button()
        Me.cmdBrowserDelete = New System.Windows.Forms.Button()
        Me.cmdBrowserEdit = New System.Windows.Forms.Button()
        Me.cmdBrowserAdd = New System.Windows.Forms.Button()
        Me.lstBrowsers = New System.Windows.Forms.ListView()
        Me.chName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chAssociatedProtocols = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tabAutoURLs = New System.Windows.Forms.TabPage()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmdMoveDownAutoURL = New System.Windows.Forms.Button()
        Me.cmdMoveUpAutoURL = New System.Windows.Forms.Button()
        Me.cmdAutoURLDelete = New System.Windows.Forms.Button()
        Me.cmdAutoURLEdit = New System.Windows.Forms.Button()
        Me.cmdAutoURLAdd = New System.Windows.Forms.Button()
        Me.lstURLs = New System.Windows.Forms.ListView()
        Me.chURL = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chBrowser = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tabProtocols = New System.Windows.Forms.TabPage()
        Me.cmdOpenDefaultForProtocol = New System.Windows.Forms.Button()
        Me.cmdDeleteProtocol = New System.Windows.Forms.Button()
        Me.cmdEditProtocol = New System.Windows.Forms.Button()
        Me.cmdAddProtocol = New System.Windows.Forms.Button()
        Me.lstProtocols = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tabFileTypes = New System.Windows.Forms.TabPage()
        Me.cmdOpenDefaultForFile = New System.Windows.Forms.Button()
        Me.cmdDeleteFileType = New System.Windows.Forms.Button()
        Me.cmdEditFileType = New System.Windows.Forms.Button()
        Me.cmdAddFileType = New System.Windows.Forms.Button()
        Me.lstFiletypes = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tabCategories = New System.Windows.Forms.TabPage()
        Me.lstCategories = New System.Windows.Forms.ListView()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tabOtherSettings = New System.Windows.Forms.TabPage()
        Me.cmdAccessiblitySettings = New System.Windows.Forms.Button()
        Me.txtSeperator = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chkAdvanced = New System.Windows.Forms.CheckBox()
        Me.txtMessage = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtOptionsShortcut = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.nudHeight = New System.Windows.Forms.NumericUpDown()
        Me.nudWidth = New System.Windows.Forms.NumericUpDown()
        Me.cmdImport = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.nudDelayBeforeAutoload = New System.Windows.Forms.NumericUpDown()
        Me.cmdCheckForUpdate = New System.Windows.Forms.Button()
        Me.chkAutoCheckUpdate = New System.Windows.Forms.CheckBox()
        Me.chkPortableMode = New System.Windows.Forms.CheckBox()
        Me.chkRevealShortURLs = New System.Windows.Forms.CheckBox()
        Me.chkShowURLs = New System.Windows.Forms.CheckBox()
        Me.tabMoreSettings = New System.Windows.Forms.TabPage()
        Me.txtUserAgent = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tabDefaultBrowser = New System.Windows.Forms.TabPage()
        Me.lblWarnWin10 = New System.Windows.Forms.Label()
        Me.lblWarnWin8 = New System.Windows.Forms.Label()
        Me.grpScope = New System.Windows.Forms.GroupBox()
        Me.rbScopeSystem = New System.Windows.Forms.RadioButton()
        Me.rbScopeUser = New System.Windows.Forms.RadioButton()
        Me.chkCheckDefaultOnLaunch = New System.Windows.Forms.CheckBox()
        Me.cmdMakeDefault = New System.Windows.Forms.Button()
        Me.cmdAddToDefault = New System.Windows.Forms.Button()
        Me.txtWarnWin10 = New System.Windows.Forms.TextBox()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cmdHelp = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.chkDownloadDetectionfile = New System.Windows.Forms.CheckBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabSettings.SuspendLayout()
        Me.tabBrowsers.SuspendLayout()
        Me.tabAutoURLs.SuspendLayout()
        Me.tabProtocols.SuspendLayout()
        Me.tabFileTypes.SuspendLayout()
        Me.tabCategories.SuspendLayout()
        Me.tabOtherSettings.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.nudHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudDelayBeforeAutoload, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabMoreSettings.SuspendLayout()
        Me.tabDefaultBrowser.SuspendLayout()
        Me.grpScope.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Browser_Chooser_2.My.Resources.Resources.Settings_icon
        Me.PictureBox1.Location = New System.Drawing.Point(12, 74)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(161, 161)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'tabSettings
        '
        Me.tabSettings.Controls.Add(Me.tabBrowsers)
        Me.tabSettings.Controls.Add(Me.tabAutoURLs)
        Me.tabSettings.Controls.Add(Me.tabProtocols)
        Me.tabSettings.Controls.Add(Me.tabFileTypes)
        Me.tabSettings.Controls.Add(Me.tabCategories)
        Me.tabSettings.Controls.Add(Me.tabOtherSettings)
        Me.tabSettings.Controls.Add(Me.tabMoreSettings)
        Me.tabSettings.Controls.Add(Me.tabDefaultBrowser)
        Me.tabSettings.Location = New System.Drawing.Point(179, 12)
        Me.tabSettings.Name = "tabSettings"
        Me.tabSettings.SelectedIndex = 0
        Me.tabSettings.Size = New System.Drawing.Size(447, 256)
        Me.tabSettings.TabIndex = 0
        '
        'tabBrowsers
        '
        Me.tabBrowsers.Controls.Add(Me.cmdDetectBrowsers)
        Me.tabBrowsers.Controls.Add(Me.cmdBrowserClone)
        Me.tabBrowsers.Controls.Add(Me.cmdBrowserDelete)
        Me.tabBrowsers.Controls.Add(Me.cmdBrowserEdit)
        Me.tabBrowsers.Controls.Add(Me.cmdBrowserAdd)
        Me.tabBrowsers.Controls.Add(Me.lstBrowsers)
        Me.tabBrowsers.Location = New System.Drawing.Point(4, 22)
        Me.tabBrowsers.Name = "tabBrowsers"
        Me.tabBrowsers.Padding = New System.Windows.Forms.Padding(3)
        Me.tabBrowsers.Size = New System.Drawing.Size(439, 230)
        Me.tabBrowsers.TabIndex = 0
        Me.tabBrowsers.Text = "Browsers / Applications"
        Me.tabBrowsers.UseVisualStyleBackColor = True
        '
        'cmdDetectBrowsers
        '
        Me.cmdDetectBrowsers.Location = New System.Drawing.Point(6, 93)
        Me.cmdDetectBrowsers.Name = "cmdDetectBrowsers"
        Me.cmdDetectBrowsers.Size = New System.Drawing.Size(75, 38)
        Me.cmdDetectBrowsers.TabIndex = 3
        Me.cmdDetectBrowsers.Text = "Detect &Browsers"
        Me.cmdDetectBrowsers.UseVisualStyleBackColor = True
        '
        'cmdBrowserClone
        '
        Me.cmdBrowserClone.Location = New System.Drawing.Point(6, 64)
        Me.cmdBrowserClone.Name = "cmdBrowserClone"
        Me.cmdBrowserClone.Size = New System.Drawing.Size(75, 23)
        Me.cmdBrowserClone.TabIndex = 2
        Me.cmdBrowserClone.Text = "C&lone"
        Me.cmdBrowserClone.UseVisualStyleBackColor = True
        '
        'cmdBrowserDelete
        '
        Me.cmdBrowserDelete.Location = New System.Drawing.Point(6, 201)
        Me.cmdBrowserDelete.Name = "cmdBrowserDelete"
        Me.cmdBrowserDelete.Size = New System.Drawing.Size(75, 23)
        Me.cmdBrowserDelete.TabIndex = 4
        Me.cmdBrowserDelete.Text = "&Delete"
        Me.cmdBrowserDelete.UseVisualStyleBackColor = True
        '
        'cmdBrowserEdit
        '
        Me.cmdBrowserEdit.Location = New System.Drawing.Point(6, 35)
        Me.cmdBrowserEdit.Name = "cmdBrowserEdit"
        Me.cmdBrowserEdit.Size = New System.Drawing.Size(75, 23)
        Me.cmdBrowserEdit.TabIndex = 1
        Me.cmdBrowserEdit.Text = "&Edit"
        Me.cmdBrowserEdit.UseVisualStyleBackColor = True
        '
        'cmdBrowserAdd
        '
        Me.cmdBrowserAdd.Location = New System.Drawing.Point(6, 6)
        Me.cmdBrowserAdd.Name = "cmdBrowserAdd"
        Me.cmdBrowserAdd.Size = New System.Drawing.Size(75, 23)
        Me.cmdBrowserAdd.TabIndex = 0
        Me.cmdBrowserAdd.Text = "&Add"
        Me.cmdBrowserAdd.UseVisualStyleBackColor = True
        '
        'lstBrowsers
        '
        Me.lstBrowsers.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chName, Me.chAssociatedProtocols})
        Me.lstBrowsers.FullRowSelect = True
        Me.lstBrowsers.HideSelection = False
        Me.lstBrowsers.Location = New System.Drawing.Point(87, 6)
        Me.lstBrowsers.MultiSelect = False
        Me.lstBrowsers.Name = "lstBrowsers"
        Me.lstBrowsers.Size = New System.Drawing.Size(346, 218)
        Me.lstBrowsers.TabIndex = 5
        Me.lstBrowsers.UseCompatibleStateImageBehavior = False
        Me.lstBrowsers.View = System.Windows.Forms.View.Details
        '
        'chName
        '
        Me.chName.Text = "Name"
        Me.chName.Width = 109
        '
        'chAssociatedProtocols
        '
        Me.chAssociatedProtocols.Text = "Associated Protocols"
        Me.chAssociatedProtocols.Width = 215
        '
        'tabAutoURLs
        '
        Me.tabAutoURLs.Controls.Add(Me.Label7)
        Me.tabAutoURLs.Controls.Add(Me.cmdMoveDownAutoURL)
        Me.tabAutoURLs.Controls.Add(Me.cmdMoveUpAutoURL)
        Me.tabAutoURLs.Controls.Add(Me.cmdAutoURLDelete)
        Me.tabAutoURLs.Controls.Add(Me.cmdAutoURLEdit)
        Me.tabAutoURLs.Controls.Add(Me.cmdAutoURLAdd)
        Me.tabAutoURLs.Controls.Add(Me.lstURLs)
        Me.tabAutoURLs.Location = New System.Drawing.Point(4, 22)
        Me.tabAutoURLs.Name = "tabAutoURLs"
        Me.tabAutoURLs.Size = New System.Drawing.Size(439, 230)
        Me.tabAutoURLs.TabIndex = 3
        Me.tabAutoURLs.Text = "Auto-URLs"
        Me.tabAutoURLs.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(87, 206)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(279, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Auto-URLs are processed in order that they are displayed."
        '
        'cmdMoveDownAutoURL
        '
        Me.cmdMoveDownAutoURL.Location = New System.Drawing.Point(6, 120)
        Me.cmdMoveDownAutoURL.Name = "cmdMoveDownAutoURL"
        Me.cmdMoveDownAutoURL.Size = New System.Drawing.Size(75, 23)
        Me.cmdMoveDownAutoURL.TabIndex = 3
        Me.cmdMoveDownAutoURL.Text = "Move &Down"
        Me.cmdMoveDownAutoURL.UseVisualStyleBackColor = True
        '
        'cmdMoveUpAutoURL
        '
        Me.cmdMoveUpAutoURL.Location = New System.Drawing.Point(6, 91)
        Me.cmdMoveUpAutoURL.Name = "cmdMoveUpAutoURL"
        Me.cmdMoveUpAutoURL.Size = New System.Drawing.Size(75, 23)
        Me.cmdMoveUpAutoURL.TabIndex = 2
        Me.cmdMoveUpAutoURL.Text = "Move &Up"
        Me.cmdMoveUpAutoURL.UseVisualStyleBackColor = True
        '
        'cmdAutoURLDelete
        '
        Me.cmdAutoURLDelete.Location = New System.Drawing.Point(6, 201)
        Me.cmdAutoURLDelete.Name = "cmdAutoURLDelete"
        Me.cmdAutoURLDelete.Size = New System.Drawing.Size(75, 23)
        Me.cmdAutoURLDelete.TabIndex = 4
        Me.cmdAutoURLDelete.Text = "&Delete"
        Me.cmdAutoURLDelete.UseVisualStyleBackColor = True
        '
        'cmdAutoURLEdit
        '
        Me.cmdAutoURLEdit.Location = New System.Drawing.Point(6, 35)
        Me.cmdAutoURLEdit.Name = "cmdAutoURLEdit"
        Me.cmdAutoURLEdit.Size = New System.Drawing.Size(75, 23)
        Me.cmdAutoURLEdit.TabIndex = 1
        Me.cmdAutoURLEdit.Text = "&Edit"
        Me.cmdAutoURLEdit.UseVisualStyleBackColor = True
        '
        'cmdAutoURLAdd
        '
        Me.cmdAutoURLAdd.Location = New System.Drawing.Point(6, 6)
        Me.cmdAutoURLAdd.Name = "cmdAutoURLAdd"
        Me.cmdAutoURLAdd.Size = New System.Drawing.Size(75, 23)
        Me.cmdAutoURLAdd.TabIndex = 0
        Me.cmdAutoURLAdd.Text = "&Add"
        Me.cmdAutoURLAdd.UseVisualStyleBackColor = True
        '
        'lstURLs
        '
        Me.lstURLs.AllowDrop = True
        Me.lstURLs.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chURL, Me.chBrowser})
        Me.lstURLs.FullRowSelect = True
        Me.lstURLs.Location = New System.Drawing.Point(87, 6)
        Me.lstURLs.Name = "lstURLs"
        Me.lstURLs.Size = New System.Drawing.Size(346, 195)
        Me.lstURLs.TabIndex = 5
        Me.lstURLs.UseCompatibleStateImageBehavior = False
        Me.lstURLs.View = System.Windows.Forms.View.Details
        '
        'chURL
        '
        Me.chURL.Text = "URL"
        Me.chURL.Width = 226
        '
        'chBrowser
        '
        Me.chBrowser.Text = "Browser"
        Me.chBrowser.Width = 105
        '
        'tabProtocols
        '
        Me.tabProtocols.Controls.Add(Me.cmdOpenDefaultForProtocol)
        Me.tabProtocols.Controls.Add(Me.cmdDeleteProtocol)
        Me.tabProtocols.Controls.Add(Me.cmdEditProtocol)
        Me.tabProtocols.Controls.Add(Me.cmdAddProtocol)
        Me.tabProtocols.Controls.Add(Me.lstProtocols)
        Me.tabProtocols.Location = New System.Drawing.Point(4, 22)
        Me.tabProtocols.Name = "tabProtocols"
        Me.tabProtocols.Size = New System.Drawing.Size(439, 230)
        Me.tabProtocols.TabIndex = 5
        Me.tabProtocols.Text = "Protocols"
        Me.tabProtocols.UseVisualStyleBackColor = True
        '
        'cmdOpenDefaultForProtocol
        '
        Me.cmdOpenDefaultForProtocol.Location = New System.Drawing.Point(6, 93)
        Me.cmdOpenDefaultForProtocol.Name = "cmdOpenDefaultForProtocol"
        Me.cmdOpenDefaultForProtocol.Size = New System.Drawing.Size(75, 36)
        Me.cmdOpenDefaultForProtocol.TabIndex = 5
        Me.cmdOpenDefaultForProtocol.Text = "Select Default App"
        Me.cmdOpenDefaultForProtocol.UseVisualStyleBackColor = True
        '
        'cmdDeleteProtocol
        '
        Me.cmdDeleteProtocol.Location = New System.Drawing.Point(6, 201)
        Me.cmdDeleteProtocol.Name = "cmdDeleteProtocol"
        Me.cmdDeleteProtocol.Size = New System.Drawing.Size(75, 23)
        Me.cmdDeleteProtocol.TabIndex = 2
        Me.cmdDeleteProtocol.Text = "&Delete"
        Me.cmdDeleteProtocol.UseVisualStyleBackColor = True
        '
        'cmdEditProtocol
        '
        Me.cmdEditProtocol.Location = New System.Drawing.Point(6, 35)
        Me.cmdEditProtocol.Name = "cmdEditProtocol"
        Me.cmdEditProtocol.Size = New System.Drawing.Size(75, 23)
        Me.cmdEditProtocol.TabIndex = 1
        Me.cmdEditProtocol.Text = "&Edit"
        Me.cmdEditProtocol.UseVisualStyleBackColor = True
        '
        'cmdAddProtocol
        '
        Me.cmdAddProtocol.Location = New System.Drawing.Point(6, 6)
        Me.cmdAddProtocol.Name = "cmdAddProtocol"
        Me.cmdAddProtocol.Size = New System.Drawing.Size(75, 23)
        Me.cmdAddProtocol.TabIndex = 0
        Me.cmdAddProtocol.Text = "&Add"
        Me.cmdAddProtocol.UseVisualStyleBackColor = True
        '
        'lstProtocols
        '
        Me.lstProtocols.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader3})
        Me.lstProtocols.FullRowSelect = True
        Me.lstProtocols.HideSelection = False
        Me.lstProtocols.Location = New System.Drawing.Point(87, 6)
        Me.lstProtocols.MultiSelect = False
        Me.lstProtocols.Name = "lstProtocols"
        Me.lstProtocols.Size = New System.Drawing.Size(346, 218)
        Me.lstProtocols.TabIndex = 3
        Me.lstProtocols.UseCompatibleStateImageBehavior = False
        Me.lstProtocols.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Name"
        Me.ColumnHeader1.Width = 109
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Header"
        Me.ColumnHeader3.Width = 124
        '
        'tabFileTypes
        '
        Me.tabFileTypes.Controls.Add(Me.cmdOpenDefaultForFile)
        Me.tabFileTypes.Controls.Add(Me.cmdDeleteFileType)
        Me.tabFileTypes.Controls.Add(Me.cmdEditFileType)
        Me.tabFileTypes.Controls.Add(Me.cmdAddFileType)
        Me.tabFileTypes.Controls.Add(Me.lstFiletypes)
        Me.tabFileTypes.Location = New System.Drawing.Point(4, 22)
        Me.tabFileTypes.Name = "tabFileTypes"
        Me.tabFileTypes.Size = New System.Drawing.Size(439, 230)
        Me.tabFileTypes.TabIndex = 6
        Me.tabFileTypes.Text = "File Types"
        Me.tabFileTypes.UseVisualStyleBackColor = True
        '
        'cmdOpenDefaultForFile
        '
        Me.cmdOpenDefaultForFile.Location = New System.Drawing.Point(6, 93)
        Me.cmdOpenDefaultForFile.Name = "cmdOpenDefaultForFile"
        Me.cmdOpenDefaultForFile.Size = New System.Drawing.Size(75, 36)
        Me.cmdOpenDefaultForFile.TabIndex = 4
        Me.cmdOpenDefaultForFile.Text = "Select Default App"
        Me.cmdOpenDefaultForFile.UseVisualStyleBackColor = True
        '
        'cmdDeleteFileType
        '
        Me.cmdDeleteFileType.Location = New System.Drawing.Point(6, 201)
        Me.cmdDeleteFileType.Name = "cmdDeleteFileType"
        Me.cmdDeleteFileType.Size = New System.Drawing.Size(75, 23)
        Me.cmdDeleteFileType.TabIndex = 2
        Me.cmdDeleteFileType.Text = "&Delete"
        Me.cmdDeleteFileType.UseVisualStyleBackColor = True
        '
        'cmdEditFileType
        '
        Me.cmdEditFileType.Location = New System.Drawing.Point(6, 35)
        Me.cmdEditFileType.Name = "cmdEditFileType"
        Me.cmdEditFileType.Size = New System.Drawing.Size(75, 23)
        Me.cmdEditFileType.TabIndex = 1
        Me.cmdEditFileType.Text = "&Edit"
        Me.cmdEditFileType.UseVisualStyleBackColor = True
        '
        'cmdAddFileType
        '
        Me.cmdAddFileType.Location = New System.Drawing.Point(6, 6)
        Me.cmdAddFileType.Name = "cmdAddFileType"
        Me.cmdAddFileType.Size = New System.Drawing.Size(75, 23)
        Me.cmdAddFileType.TabIndex = 0
        Me.cmdAddFileType.Text = "&Add"
        Me.cmdAddFileType.UseVisualStyleBackColor = True
        '
        'lstFiletypes
        '
        Me.lstFiletypes.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2})
        Me.lstFiletypes.FullRowSelect = True
        Me.lstFiletypes.HideSelection = False
        Me.lstFiletypes.Location = New System.Drawing.Point(87, 6)
        Me.lstFiletypes.MultiSelect = False
        Me.lstFiletypes.Name = "lstFiletypes"
        Me.lstFiletypes.Size = New System.Drawing.Size(346, 218)
        Me.lstFiletypes.TabIndex = 3
        Me.lstFiletypes.UseCompatibleStateImageBehavior = False
        Me.lstFiletypes.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Name"
        Me.ColumnHeader2.Width = 109
        '
        'tabCategories
        '
        Me.tabCategories.Controls.Add(Me.lstCategories)
        Me.tabCategories.Location = New System.Drawing.Point(4, 22)
        Me.tabCategories.Name = "tabCategories"
        Me.tabCategories.Size = New System.Drawing.Size(439, 230)
        Me.tabCategories.TabIndex = 7
        Me.tabCategories.Text = "Categories"
        Me.tabCategories.UseVisualStyleBackColor = True
        '
        'lstCategories
        '
        Me.lstCategories.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4})
        Me.lstCategories.FullRowSelect = True
        Me.lstCategories.HideSelection = False
        Me.lstCategories.Location = New System.Drawing.Point(3, 6)
        Me.lstCategories.MultiSelect = False
        Me.lstCategories.Name = "lstCategories"
        Me.lstCategories.Size = New System.Drawing.Size(430, 218)
        Me.lstCategories.TabIndex = 0
        Me.lstCategories.UseCompatibleStateImageBehavior = False
        Me.lstCategories.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Name"
        Me.ColumnHeader4.Width = 425
        '
        'tabOtherSettings
        '
        Me.tabOtherSettings.Controls.Add(Me.cmdAccessiblitySettings)
        Me.tabOtherSettings.Controls.Add(Me.txtSeperator)
        Me.tabOtherSettings.Controls.Add(Me.Label6)
        Me.tabOtherSettings.Controls.Add(Me.chkAdvanced)
        Me.tabOtherSettings.Controls.Add(Me.txtMessage)
        Me.tabOtherSettings.Controls.Add(Me.Label5)
        Me.tabOtherSettings.Controls.Add(Me.txtOptionsShortcut)
        Me.tabOtherSettings.Controls.Add(Me.Label4)
        Me.tabOtherSettings.Controls.Add(Me.GroupBox1)
        Me.tabOtherSettings.Controls.Add(Me.cmdImport)
        Me.tabOtherSettings.Controls.Add(Me.Label1)
        Me.tabOtherSettings.Controls.Add(Me.nudDelayBeforeAutoload)
        Me.tabOtherSettings.Controls.Add(Me.cmdCheckForUpdate)
        Me.tabOtherSettings.Controls.Add(Me.chkAutoCheckUpdate)
        Me.tabOtherSettings.Controls.Add(Me.chkPortableMode)
        Me.tabOtherSettings.Controls.Add(Me.chkRevealShortURLs)
        Me.tabOtherSettings.Controls.Add(Me.chkShowURLs)
        Me.tabOtherSettings.Location = New System.Drawing.Point(4, 22)
        Me.tabOtherSettings.Name = "tabOtherSettings"
        Me.tabOtherSettings.Size = New System.Drawing.Size(439, 230)
        Me.tabOtherSettings.TabIndex = 2
        Me.tabOtherSettings.Text = "Settings"
        Me.tabOtherSettings.UseVisualStyleBackColor = True
        '
        'cmdAccessiblitySettings
        '
        Me.cmdAccessiblitySettings.Location = New System.Drawing.Point(283, 77)
        Me.cmdAccessiblitySettings.Name = "cmdAccessiblitySettings"
        Me.cmdAccessiblitySettings.Size = New System.Drawing.Size(134, 23)
        Me.cmdAccessiblitySettings.TabIndex = 9
        Me.cmdAccessiblitySettings.Text = "Accessibility Settings"
        Me.cmdAccessiblitySettings.UseVisualStyleBackColor = True
        '
        'txtSeperator
        '
        Me.txtSeperator.Location = New System.Drawing.Point(233, 178)
        Me.txtSeperator.Name = "txtSeperator"
        Me.txtSeperator.Size = New System.Drawing.Size(203, 20)
        Me.txtSeperator.TabIndex = 16
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 178)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(224, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Separator (Text between message and URL) :"
        '
        'chkAdvanced
        '
        Me.chkAdvanced.AutoSize = True
        Me.chkAdvanced.Location = New System.Drawing.Point(275, 49)
        Me.chkAdvanced.Name = "chkAdvanced"
        Me.chkAdvanced.Size = New System.Drawing.Size(139, 17)
        Me.chkAdvanced.TabIndex = 7
        Me.chkAdvanced.Text = "Use Advanced &Screens"
        Me.chkAdvanced.UseVisualStyleBackColor = True
        '
        'txtMessage
        '
        Me.txtMessage.Location = New System.Drawing.Point(159, 153)
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.Size = New System.Drawing.Size(277, 20)
        Me.txtMessage.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 153)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(131, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Message on main screen :"
        '
        'txtOptionsShortcut
        '
        Me.txtOptionsShortcut.Location = New System.Drawing.Point(159, 128)
        Me.txtOptionsShortcut.MaxLength = 1
        Me.txtOptionsShortcut.Name = "txtOptionsShortcut"
        Me.txtOptionsShortcut.Size = New System.Drawing.Size(100, 20)
        Me.txtOptionsShortcut.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 131)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(156, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Hotkey to open Options dialog :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.nudHeight)
        Me.GroupBox1.Controls.Add(Me.nudWidth)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 77)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(263, 45)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "# of icons in grid"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(149, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Height :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Width :"
        '
        'nudHeight
        '
        Me.nudHeight.Location = New System.Drawing.Point(193, 16)
        Me.nudHeight.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudHeight.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudHeight.Name = "nudHeight"
        Me.nudHeight.Size = New System.Drawing.Size(60, 20)
        Me.nudHeight.TabIndex = 3
        Me.nudHeight.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'nudWidth
        '
        Me.nudWidth.Location = New System.Drawing.Point(47, 18)
        Me.nudWidth.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudWidth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudWidth.Name = "nudWidth"
        Me.nudWidth.Size = New System.Drawing.Size(60, 20)
        Me.nudWidth.TabIndex = 1
        Me.nudWidth.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'cmdImport
        '
        Me.cmdImport.Location = New System.Drawing.Point(6, 204)
        Me.cmdImport.Name = "cmdImport"
        Me.cmdImport.Size = New System.Drawing.Size(430, 23)
        Me.cmdImport.TabIndex = 17
        Me.cmdImport.Text = "Import Settings from Browser Chooser 1"
        Me.cmdImport.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(0, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(162, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Default Delay before Auto-Load :"
        '
        'nudDelayBeforeAutoload
        '
        Me.nudDelayBeforeAutoload.Location = New System.Drawing.Point(196, 51)
        Me.nudDelayBeforeAutoload.Name = "nudDelayBeforeAutoload"
        Me.nudDelayBeforeAutoload.Size = New System.Drawing.Size(60, 20)
        Me.nudDelayBeforeAutoload.TabIndex = 4
        '
        'cmdCheckForUpdate
        '
        Me.cmdCheckForUpdate.Location = New System.Drawing.Point(184, 22)
        Me.cmdCheckForUpdate.Name = "cmdCheckForUpdate"
        Me.cmdCheckForUpdate.Size = New System.Drawing.Size(75, 23)
        Me.cmdCheckForUpdate.TabIndex = 2
        Me.cmdCheckForUpdate.Text = "&Check Now"
        Me.cmdCheckForUpdate.UseVisualStyleBackColor = True
        '
        'chkAutoCheckUpdate
        '
        Me.chkAutoCheckUpdate.AutoSize = True
        Me.chkAutoCheckUpdate.Location = New System.Drawing.Point(3, 26)
        Me.chkAutoCheckUpdate.Name = "chkAutoCheckUpdate"
        Me.chkAutoCheckUpdate.Size = New System.Drawing.Size(180, 17)
        Me.chkAutoCheckUpdate.TabIndex = 1
        Me.chkAutoCheckUpdate.Text = "&Automatically Check for Updates"
        Me.chkAutoCheckUpdate.UseVisualStyleBackColor = True
        '
        'chkPortableMode
        '
        Me.chkPortableMode.AutoSize = True
        Me.chkPortableMode.Location = New System.Drawing.Point(275, 3)
        Me.chkPortableMode.Name = "chkPortableMode"
        Me.chkPortableMode.Size = New System.Drawing.Size(95, 17)
        Me.chkPortableMode.TabIndex = 5
        Me.chkPortableMode.Text = "&Portable Mode"
        Me.chkPortableMode.UseVisualStyleBackColor = True
        '
        'chkRevealShortURLs
        '
        Me.chkRevealShortURLs.AutoSize = True
        Me.chkRevealShortURLs.Location = New System.Drawing.Point(275, 26)
        Me.chkRevealShortURLs.Name = "chkRevealShortURLs"
        Me.chkRevealShortURLs.Size = New System.Drawing.Size(142, 17)
        Me.chkRevealShortURLs.TabIndex = 6
        Me.chkRevealShortURLs.Text = "&Reveal Shortened URLs"
        Me.chkRevealShortURLs.UseVisualStyleBackColor = True
        '
        'chkShowURLs
        '
        Me.chkShowURLs.AutoSize = True
        Me.chkShowURLs.Location = New System.Drawing.Point(3, 3)
        Me.chkShowURLs.Name = "chkShowURLs"
        Me.chkShowURLs.Size = New System.Drawing.Size(164, 17)
        Me.chkShowURLs.TabIndex = 0
        Me.chkShowURLs.Text = "Show &URLs in User Interface"
        Me.chkShowURLs.UseVisualStyleBackColor = True
        '
        'tabMoreSettings
        '
        Me.tabMoreSettings.Controls.Add(Me.chkDownloadDetectionfile)
        Me.tabMoreSettings.Controls.Add(Me.txtUserAgent)
        Me.tabMoreSettings.Controls.Add(Me.Label8)
        Me.tabMoreSettings.Location = New System.Drawing.Point(4, 22)
        Me.tabMoreSettings.Name = "tabMoreSettings"
        Me.tabMoreSettings.Size = New System.Drawing.Size(439, 230)
        Me.tabMoreSettings.TabIndex = 8
        Me.tabMoreSettings.Text = "More Settings"
        Me.tabMoreSettings.UseVisualStyleBackColor = True
        '
        'txtUserAgent
        '
        Me.txtUserAgent.Location = New System.Drawing.Point(159, 3)
        Me.txtUserAgent.Name = "txtUserAgent"
        Me.txtUserAgent.Size = New System.Drawing.Size(277, 20)
        Me.txtUserAgent.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 3)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(110, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "User Agent To Send :"
        '
        'tabDefaultBrowser
        '
        Me.tabDefaultBrowser.Controls.Add(Me.lblWarnWin10)
        Me.tabDefaultBrowser.Controls.Add(Me.lblWarnWin8)
        Me.tabDefaultBrowser.Controls.Add(Me.grpScope)
        Me.tabDefaultBrowser.Controls.Add(Me.chkCheckDefaultOnLaunch)
        Me.tabDefaultBrowser.Controls.Add(Me.cmdMakeDefault)
        Me.tabDefaultBrowser.Controls.Add(Me.cmdAddToDefault)
        Me.tabDefaultBrowser.Controls.Add(Me.txtWarnWin10)
        Me.tabDefaultBrowser.Location = New System.Drawing.Point(4, 22)
        Me.tabDefaultBrowser.Name = "tabDefaultBrowser"
        Me.tabDefaultBrowser.Size = New System.Drawing.Size(439, 230)
        Me.tabDefaultBrowser.TabIndex = 4
        Me.tabDefaultBrowser.Text = "Default Browser"
        Me.tabDefaultBrowser.UseVisualStyleBackColor = True
        '
        'lblWarnWin10
        '
        Me.lblWarnWin10.AutoSize = True
        Me.lblWarnWin10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWarnWin10.Location = New System.Drawing.Point(217, 55)
        Me.lblWarnWin10.Name = "lblWarnWin10"
        Me.lblWarnWin10.Size = New System.Drawing.Size(195, 13)
        Me.lblWarnWin10.TabIndex = 6
        Me.lblWarnWin10.Text = "* Note for users of Windows 10+:"
        Me.lblWarnWin10.Visible = False
        '
        'lblWarnWin8
        '
        Me.lblWarnWin8.AutoSize = True
        Me.lblWarnWin8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWarnWin8.Location = New System.Drawing.Point(217, 55)
        Me.lblWarnWin8.Name = "lblWarnWin8"
        Me.lblWarnWin8.Size = New System.Drawing.Size(188, 13)
        Me.lblWarnWin8.TabIndex = 4
        Me.lblWarnWin8.Text = "* Note for users of Windows 8+:"
        Me.lblWarnWin8.Visible = False
        '
        'grpScope
        '
        Me.grpScope.Controls.Add(Me.rbScopeSystem)
        Me.grpScope.Controls.Add(Me.rbScopeUser)
        Me.grpScope.Location = New System.Drawing.Point(3, 3)
        Me.grpScope.Name = "grpScope"
        Me.grpScope.Size = New System.Drawing.Size(274, 45)
        Me.grpScope.TabIndex = 0
        Me.grpScope.TabStop = False
        Me.grpScope.Text = "Scope"
        '
        'rbScopeSystem
        '
        Me.rbScopeSystem.AutoSize = True
        Me.rbScopeSystem.Location = New System.Drawing.Point(59, 19)
        Me.rbScopeSystem.Name = "rbScopeSystem"
        Me.rbScopeSystem.Size = New System.Drawing.Size(206, 17)
        Me.rbScopeSystem.TabIndex = 1
        Me.rbScopeSystem.Text = "System (Administrator access required)"
        Me.rbScopeSystem.UseVisualStyleBackColor = True
        '
        'rbScopeUser
        '
        Me.rbScopeUser.AutoSize = True
        Me.rbScopeUser.Checked = True
        Me.rbScopeUser.Location = New System.Drawing.Point(6, 19)
        Me.rbScopeUser.Name = "rbScopeUser"
        Me.rbScopeUser.Size = New System.Drawing.Size(47, 17)
        Me.rbScopeUser.TabIndex = 0
        Me.rbScopeUser.TabStop = True
        Me.rbScopeUser.Text = "&User"
        Me.rbScopeUser.UseVisualStyleBackColor = True
        '
        'chkCheckDefaultOnLaunch
        '
        Me.chkCheckDefaultOnLaunch.AutoSize = True
        Me.chkCheckDefaultOnLaunch.Location = New System.Drawing.Point(9, 112)
        Me.chkCheckDefaultOnLaunch.Name = "chkCheckDefaultOnLaunch"
        Me.chkCheckDefaultOnLaunch.Size = New System.Drawing.Size(174, 17)
        Me.chkCheckDefaultOnLaunch.TabIndex = 3
        Me.chkCheckDefaultOnLaunch.Text = "Check on launch (Vista/7 Only)"
        Me.chkCheckDefaultOnLaunch.UseVisualStyleBackColor = True
        '
        'cmdMakeDefault
        '
        Me.cmdMakeDefault.Location = New System.Drawing.Point(9, 83)
        Me.cmdMakeDefault.Name = "cmdMakeDefault"
        Me.cmdMakeDefault.Size = New System.Drawing.Size(202, 23)
        Me.cmdMakeDefault.TabIndex = 2
        Me.cmdMakeDefault.Text = "Make Default"
        Me.cmdMakeDefault.UseVisualStyleBackColor = True
        '
        'cmdAddToDefault
        '
        Me.cmdAddToDefault.Location = New System.Drawing.Point(9, 54)
        Me.cmdAddToDefault.Name = "cmdAddToDefault"
        Me.cmdAddToDefault.Size = New System.Drawing.Size(202, 23)
        Me.cmdAddToDefault.TabIndex = 1
        Me.cmdAddToDefault.Text = "Add to Default Programs"
        Me.cmdAddToDefault.UseVisualStyleBackColor = True
        '
        'txtWarnWin10
        '
        Me.txtWarnWin10.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtWarnWin10.Location = New System.Drawing.Point(220, 70)
        Me.txtWarnWin10.Multiline = True
        Me.txtWarnWin10.Name = "txtWarnWin10"
        Me.txtWarnWin10.Size = New System.Drawing.Size(178, 88)
        Me.txtWarnWin10.TabIndex = 7
        Me.txtWarnWin10.Text = "Microsoft no longer allows a program to automatically gain default status of eith" & _
    "er a a protocol (Browser) or Filetypes.  You must manully assign them via the De" & _
    "faults App Applet."
        Me.txtWarnWin10.Visible = False
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(385, 274)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(75, 23)
        Me.cmdSave.TabIndex = 1
        Me.cmdSave.Text = "&Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdHelp
        '
        Me.cmdHelp.Location = New System.Drawing.Point(466, 274)
        Me.cmdHelp.Name = "cmdHelp"
        Me.cmdHelp.Size = New System.Drawing.Size(75, 23)
        Me.cmdHelp.TabIndex = 2
        Me.cmdHelp.Text = "&Help"
        Me.cmdHelp.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(547, 274)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 3
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'chkDownloadDetectionfile
        '
        Me.chkDownloadDetectionfile.AutoSize = True
        Me.chkDownloadDetectionfile.Location = New System.Drawing.Point(6, 29)
        Me.chkDownloadDetectionfile.Name = "chkDownloadDetectionfile"
        Me.chkDownloadDetectionfile.Size = New System.Drawing.Size(271, 17)
        Me.chkDownloadDetectionfile.TabIndex = 17
        Me.chkDownloadDetectionfile.Text = "&Download Detection file from BrowserChooser2.com"
        Me.chkDownloadDetectionfile.UseVisualStyleBackColor = True
        '
        'frmOptions
        '
        Me.AcceptButton = Me.cmdSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(638, 308)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdHelp)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.tabSettings)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmOptions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Options"
        Me.TopMost = True
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabSettings.ResumeLayout(False)
        Me.tabBrowsers.ResumeLayout(False)
        Me.tabAutoURLs.ResumeLayout(False)
        Me.tabAutoURLs.PerformLayout()
        Me.tabProtocols.ResumeLayout(False)
        Me.tabFileTypes.ResumeLayout(False)
        Me.tabCategories.ResumeLayout(False)
        Me.tabOtherSettings.ResumeLayout(False)
        Me.tabOtherSettings.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.nudHeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudDelayBeforeAutoload, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabMoreSettings.ResumeLayout(False)
        Me.tabMoreSettings.PerformLayout()
        Me.tabDefaultBrowser.ResumeLayout(False)
        Me.tabDefaultBrowser.PerformLayout()
        Me.grpScope.ResumeLayout(False)
        Me.grpScope.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents tabSettings As System.Windows.Forms.TabControl
    Friend WithEvents tabBrowsers As System.Windows.Forms.TabPage
    Friend WithEvents cmdBrowserDelete As System.Windows.Forms.Button
    Friend WithEvents cmdBrowserEdit As System.Windows.Forms.Button
    Friend WithEvents cmdBrowserAdd As System.Windows.Forms.Button
    Friend WithEvents lstBrowsers As System.Windows.Forms.ListView
    Friend WithEvents tabAutoURLs As System.Windows.Forms.TabPage
    Friend WithEvents tabOtherSettings As System.Windows.Forms.TabPage
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdHelp As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents chName As System.Windows.Forms.ColumnHeader
    Friend WithEvents cmdAutoURLDelete As System.Windows.Forms.Button
    Friend WithEvents cmdAutoURLEdit As System.Windows.Forms.Button
    Friend WithEvents cmdAutoURLAdd As System.Windows.Forms.Button
    Friend WithEvents lstURLs As System.Windows.Forms.ListView
    Friend WithEvents cmdImport As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nudDelayBeforeAutoload As System.Windows.Forms.NumericUpDown
    Friend WithEvents cmdCheckForUpdate As System.Windows.Forms.Button
    Friend WithEvents chkAutoCheckUpdate As System.Windows.Forms.CheckBox
    Friend WithEvents chkPortableMode As System.Windows.Forms.CheckBox
    Friend WithEvents chkRevealShortURLs As System.Windows.Forms.CheckBox
    Friend WithEvents chkShowURLs As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents nudHeight As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudWidth As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtOptionsShortcut As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtMessage As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chURL As System.Windows.Forms.ColumnHeader
    Friend WithEvents chBrowser As System.Windows.Forms.ColumnHeader
    Friend WithEvents tabDefaultBrowser As System.Windows.Forms.TabPage
    Friend WithEvents chkCheckDefaultOnLaunch As System.Windows.Forms.CheckBox
    Friend WithEvents cmdMakeDefault As System.Windows.Forms.Button
    Friend WithEvents cmdAddToDefault As System.Windows.Forms.Button
    Friend WithEvents tabProtocols As System.Windows.Forms.TabPage
    Friend WithEvents cmdDeleteProtocol As System.Windows.Forms.Button
    Friend WithEvents cmdEditProtocol As System.Windows.Forms.Button
    Friend WithEvents cmdAddProtocol As System.Windows.Forms.Button
    Friend WithEvents lstProtocols As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents tabFileTypes As System.Windows.Forms.TabPage
    Friend WithEvents cmdDeleteFileType As System.Windows.Forms.Button
    Friend WithEvents cmdEditFileType As System.Windows.Forms.Button
    Friend WithEvents cmdAddFileType As System.Windows.Forms.Button
    Friend WithEvents lstFiletypes As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents chAssociatedProtocols As System.Windows.Forms.ColumnHeader
    Friend WithEvents grpScope As System.Windows.Forms.GroupBox
    Friend WithEvents rbScopeSystem As System.Windows.Forms.RadioButton
    Friend WithEvents rbScopeUser As System.Windows.Forms.RadioButton
    Friend WithEvents chkAdvanced As System.Windows.Forms.CheckBox
    Friend WithEvents tabCategories As System.Windows.Forms.TabPage
    Friend WithEvents lstCategories As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblWarnWin8 As System.Windows.Forms.Label
    Friend WithEvents cmdBrowserClone As System.Windows.Forms.Button
    Friend WithEvents cmdDetectBrowsers As System.Windows.Forms.Button
    Friend WithEvents txtSeperator As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmdMoveDownAutoURL As System.Windows.Forms.Button
    Friend WithEvents cmdMoveUpAutoURL As System.Windows.Forms.Button
    Friend WithEvents cmdAccessiblitySettings As System.Windows.Forms.Button
    Friend WithEvents txtWarnWin10 As System.Windows.Forms.TextBox
    Friend WithEvents lblWarnWin10 As System.Windows.Forms.Label
    Friend WithEvents cmdOpenDefaultForProtocol As System.Windows.Forms.Button
    Friend WithEvents cmdOpenDefaultForFile As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tabMoreSettings As System.Windows.Forms.TabPage
    Friend WithEvents txtUserAgent As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents chkDownloadDetectionfile As System.Windows.Forms.CheckBox
End Class
