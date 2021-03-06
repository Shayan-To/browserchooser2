Imports SeparatorComboBoxTest

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
        Me.components = New System.ComponentModel.Container()
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Browsers and Applications")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Auto URLs")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Common", New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2})
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Protocols")
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("File Types")
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Associations", New System.Windows.Forms.TreeNode() {TreeNode4, TreeNode5})
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Display")
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Grid")
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Privacy")
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Startup")
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Others")
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Settings", New System.Windows.Forms.TreeNode() {TreeNode7, TreeNode8, TreeNode9, TreeNode10, TreeNode11})
        Dim TreeNode13 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Windows Default")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOptions))
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
        Me.chRow = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chProtocolsAndFileTypes = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.imBrowserIcons = New System.Windows.Forms.ImageList(Me.components)
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
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tabCategories = New System.Windows.Forms.TabPage()
        Me.lstCategories = New System.Windows.Forms.ListView()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tabDisplay = New System.Windows.Forms.TabPage()
        Me.chkAllowStayOpen = New System.Windows.Forms.CheckBox()
        Me.chkRevealShortURLs = New System.Windows.Forms.CheckBox()
        Me.chkUseAreo = New System.Windows.Forms.CheckBox()
        Me.chkUseAccessibleRendering = New System.Windows.Forms.CheckBox()
        Me.cmdAccessiblitySettings = New System.Windows.Forms.Button()
        Me.cmdTransparentBackground = New System.Windows.Forms.Button()
        Me.pbBackgroundColor = New System.Windows.Forms.PictureBox()
        Me.cmdChangeBackgroundColor = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.chkShowURLs = New System.Windows.Forms.CheckBox()
        Me.txtSeperator = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtMessage = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tabGrid = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.nudIconGapHeight = New System.Windows.Forms.NumericUpDown()
        Me.nudIconGapWidth = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.nudIconScale = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.nudIconSizeHeight = New System.Windows.Forms.NumericUpDown()
        Me.nudIconSizeWidth = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.nudHeight = New System.Windows.Forms.NumericUpDown()
        Me.nudWidth = New System.Windows.Forms.NumericUpDown()
        Me.tabOthers = New System.Windows.Forms.TabPage()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtCanonicalizeAppend = New System.Windows.Forms.TextBox()
        Me.chkCanonicalize = New System.Windows.Forms.CheckBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtOptionsShortcut = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tabStartup = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cmbStartingPosition = New SeparatorComboBox.SeparatorComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.nudYOffset = New System.Windows.Forms.NumericUpDown()
        Me.nudXOffset = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.nudDelayBeforeAutoload = New System.Windows.Forms.NumericUpDown()
        Me.chkAdvanced = New System.Windows.Forms.CheckBox()
        Me.cmdCheckForUpdate = New System.Windows.Forms.Button()
        Me.chkAutoCheckUpdate = New System.Windows.Forms.CheckBox()
        Me.chkPortableMode = New System.Windows.Forms.CheckBox()
        Me.tabPrivacy = New System.Windows.Forms.TabPage()
        Me.chkDownloadDetectionfile = New System.Windows.Forms.CheckBox()
        Me.txtUserAgent = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tabDefaultBrowser = New System.Windows.Forms.TabPage()
        Me.cmdRemoveFromDefaultSettings = New System.Windows.Forms.Button()
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
        Me.cdColorDialog = New System.Windows.Forms.ColorDialog()
        Me.treeSettings = New System.Windows.Forms.TreeView()
        Me.chkLog = New System.Windows.Forms.CheckBox()
        Me.chkExtract = New System.Windows.Forms.CheckBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabSettings.SuspendLayout()
        Me.tabBrowsers.SuspendLayout()
        Me.tabAutoURLs.SuspendLayout()
        Me.tabProtocols.SuspendLayout()
        Me.tabFileTypes.SuspendLayout()
        Me.tabCategories.SuspendLayout()
        Me.tabDisplay.SuspendLayout()
        CType(Me.pbBackgroundColor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabGrid.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.nudIconGapHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudIconGapWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.nudIconScale, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudIconSizeHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudIconSizeWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.nudHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabOthers.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.tabStartup.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.nudYOffset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudXOffset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudDelayBeforeAutoload, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPrivacy.SuspendLayout()
        Me.tabDefaultBrowser.SuspendLayout()
        Me.grpScope.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Browser_Chooser_2.My.Resources.Resources.Settings_icon
        Me.PictureBox1.Location = New System.Drawing.Point(12, 79)
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
        Me.tabSettings.Controls.Add(Me.tabDisplay)
        Me.tabSettings.Controls.Add(Me.tabGrid)
        Me.tabSettings.Controls.Add(Me.tabOthers)
        Me.tabSettings.Controls.Add(Me.tabStartup)
        Me.tabSettings.Controls.Add(Me.tabPrivacy)
        Me.tabSettings.Controls.Add(Me.tabDefaultBrowser)
        Me.tabSettings.Location = New System.Drawing.Point(179, 12)
        Me.tabSettings.Name = "tabSettings"
        Me.tabSettings.SelectedIndex = 0
        Me.tabSettings.Size = New System.Drawing.Size(447, 274)
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
        Me.tabBrowsers.Size = New System.Drawing.Size(439, 248)
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
        Me.lstBrowsers.AllowDrop = True
        Me.lstBrowsers.BackColor = System.Drawing.SystemColors.Window
        Me.lstBrowsers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstBrowsers.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chName, Me.chRow, Me.chColumn, Me.chProtocolsAndFileTypes})
        Me.lstBrowsers.FullRowSelect = True
        Me.lstBrowsers.HideSelection = False
        Me.lstBrowsers.Location = New System.Drawing.Point(87, 6)
        Me.lstBrowsers.MultiSelect = False
        Me.lstBrowsers.Name = "lstBrowsers"
        Me.lstBrowsers.Size = New System.Drawing.Size(346, 218)
        Me.lstBrowsers.SmallImageList = Me.imBrowserIcons
        Me.lstBrowsers.TabIndex = 5
        Me.lstBrowsers.UseCompatibleStateImageBehavior = False
        Me.lstBrowsers.View = System.Windows.Forms.View.Details
        '
        'chName
        '
        Me.chName.Text = "Name"
        Me.chName.Width = 109
        '
        'chRow
        '
        Me.chRow.Text = "Row"
        '
        'chColumn
        '
        Me.chColumn.Text = "Column"
        '
        'chProtocolsAndFileTypes
        '
        Me.chProtocolsAndFileTypes.Text = "File Types and Protocols"
        Me.chProtocolsAndFileTypes.Width = 158
        '
        'imBrowserIcons
        '
        Me.imBrowserIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imBrowserIcons.ImageSize = New System.Drawing.Size(16, 16)
        Me.imBrowserIcons.TransparentColor = System.Drawing.Color.Transparent
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
        Me.tabAutoURLs.Size = New System.Drawing.Size(439, 248)
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
        Me.lstURLs.HideSelection = False
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
        Me.tabProtocols.Size = New System.Drawing.Size(439, 248)
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
        Me.tabFileTypes.Size = New System.Drawing.Size(439, 248)
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
        Me.lstFiletypes.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2, Me.ColumnHeader5})
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
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Extention"
        Me.ColumnHeader5.Width = 74
        '
        'tabCategories
        '
        Me.tabCategories.Controls.Add(Me.lstCategories)
        Me.tabCategories.Location = New System.Drawing.Point(4, 22)
        Me.tabCategories.Name = "tabCategories"
        Me.tabCategories.Size = New System.Drawing.Size(439, 248)
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
        'tabDisplay
        '
        Me.tabDisplay.Controls.Add(Me.chkAllowStayOpen)
        Me.tabDisplay.Controls.Add(Me.chkRevealShortURLs)
        Me.tabDisplay.Controls.Add(Me.chkUseAreo)
        Me.tabDisplay.Controls.Add(Me.chkUseAccessibleRendering)
        Me.tabDisplay.Controls.Add(Me.cmdAccessiblitySettings)
        Me.tabDisplay.Controls.Add(Me.cmdTransparentBackground)
        Me.tabDisplay.Controls.Add(Me.pbBackgroundColor)
        Me.tabDisplay.Controls.Add(Me.cmdChangeBackgroundColor)
        Me.tabDisplay.Controls.Add(Me.Label13)
        Me.tabDisplay.Controls.Add(Me.chkShowURLs)
        Me.tabDisplay.Controls.Add(Me.txtSeperator)
        Me.tabDisplay.Controls.Add(Me.Label6)
        Me.tabDisplay.Controls.Add(Me.txtMessage)
        Me.tabDisplay.Controls.Add(Me.Label5)
        Me.tabDisplay.Location = New System.Drawing.Point(4, 22)
        Me.tabDisplay.Name = "tabDisplay"
        Me.tabDisplay.Size = New System.Drawing.Size(439, 248)
        Me.tabDisplay.TabIndex = 9
        Me.tabDisplay.Text = "Display"
        Me.tabDisplay.UseVisualStyleBackColor = True
        '
        'chkAllowStayOpen
        '
        Me.chkAllowStayOpen.AutoSize = True
        Me.chkAllowStayOpen.Location = New System.Drawing.Point(6, 49)
        Me.chkAllowStayOpen.Name = "chkAllowStayOpen"
        Me.chkAllowStayOpen.Size = New System.Drawing.Size(156, 17)
        Me.chkAllowStayOpen.TabIndex = 32
        Me.chkAllowStayOpen.Text = "Allow interface to stay open"
        Me.chkAllowStayOpen.UseVisualStyleBackColor = True
        '
        'chkRevealShortURLs
        '
        Me.chkRevealShortURLs.AutoSize = True
        Me.chkRevealShortURLs.Location = New System.Drawing.Point(6, 26)
        Me.chkRevealShortURLs.Name = "chkRevealShortURLs"
        Me.chkRevealShortURLs.Size = New System.Drawing.Size(142, 17)
        Me.chkRevealShortURLs.TabIndex = 31
        Me.chkRevealShortURLs.Text = "&Reveal Shortened URLs"
        Me.chkRevealShortURLs.UseVisualStyleBackColor = True
        '
        'chkUseAreo
        '
        Me.chkUseAreo.AutoSize = True
        Me.chkUseAreo.Location = New System.Drawing.Point(276, 26)
        Me.chkUseAreo.Name = "chkUseAreo"
        Me.chkUseAreo.Size = New System.Drawing.Size(158, 17)
        Me.chkUseAreo.TabIndex = 30
        Me.chkUseAreo.Text = "Use AERO (when available)"
        Me.chkUseAreo.UseVisualStyleBackColor = True
        '
        'chkUseAccessibleRendering
        '
        Me.chkUseAccessibleRendering.AutoSize = True
        Me.chkUseAccessibleRendering.Location = New System.Drawing.Point(276, 3)
        Me.chkUseAccessibleRendering.Name = "chkUseAccessibleRendering"
        Me.chkUseAccessibleRendering.Size = New System.Drawing.Size(151, 17)
        Me.chkUseAccessibleRendering.TabIndex = 29
        Me.chkUseAccessibleRendering.Text = "Use Accessible Rendering"
        Me.chkUseAccessibleRendering.UseVisualStyleBackColor = True
        '
        'cmdAccessiblitySettings
        '
        Me.cmdAccessiblitySettings.Location = New System.Drawing.Point(286, 45)
        Me.cmdAccessiblitySettings.Name = "cmdAccessiblitySettings"
        Me.cmdAccessiblitySettings.Size = New System.Drawing.Size(134, 23)
        Me.cmdAccessiblitySettings.TabIndex = 28
        Me.cmdAccessiblitySettings.Text = "Focus Settings"
        Me.cmdAccessiblitySettings.UseVisualStyleBackColor = True
        '
        'cmdTransparentBackground
        '
        Me.cmdTransparentBackground.Location = New System.Drawing.Point(286, 222)
        Me.cmdTransparentBackground.Name = "cmdTransparentBackground"
        Me.cmdTransparentBackground.Size = New System.Drawing.Size(149, 23)
        Me.cmdTransparentBackground.TabIndex = 27
        Me.cmdTransparentBackground.Text = "Transparent Background"
        Me.cmdTransparentBackground.UseVisualStyleBackColor = True
        Me.cmdTransparentBackground.Visible = False
        '
        'pbBackgroundColor
        '
        Me.pbBackgroundColor.Location = New System.Drawing.Point(100, 222)
        Me.pbBackgroundColor.Name = "pbBackgroundColor"
        Me.pbBackgroundColor.Size = New System.Drawing.Size(25, 23)
        Me.pbBackgroundColor.TabIndex = 26
        Me.pbBackgroundColor.TabStop = False
        Me.pbBackgroundColor.Visible = False
        '
        'cmdChangeBackgroundColor
        '
        Me.cmdChangeBackgroundColor.Location = New System.Drawing.Point(131, 222)
        Me.cmdChangeBackgroundColor.Name = "cmdChangeBackgroundColor"
        Me.cmdChangeBackgroundColor.Size = New System.Drawing.Size(149, 23)
        Me.cmdChangeBackgroundColor.TabIndex = 25
        Me.cmdChangeBackgroundColor.Text = "Change Background Color"
        Me.cmdChangeBackgroundColor.UseVisualStyleBackColor = True
        Me.cmdChangeBackgroundColor.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(2, 227)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(92, 13)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "Background Color"
        Me.Label13.Visible = False
        '
        'chkShowURLs
        '
        Me.chkShowURLs.AutoSize = True
        Me.chkShowURLs.Location = New System.Drawing.Point(6, 3)
        Me.chkShowURLs.Name = "chkShowURLs"
        Me.chkShowURLs.Size = New System.Drawing.Size(164, 17)
        Me.chkShowURLs.TabIndex = 21
        Me.chkShowURLs.Text = "Show &URLs in User Interface"
        Me.chkShowURLs.UseVisualStyleBackColor = True
        '
        'txtSeperator
        '
        Me.txtSeperator.Location = New System.Drawing.Point(232, 99)
        Me.txtSeperator.Name = "txtSeperator"
        Me.txtSeperator.Size = New System.Drawing.Size(203, 20)
        Me.txtSeperator.TabIndex = 20
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(2, 99)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(224, 13)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Separator (Text between message and URL) :"
        '
        'txtMessage
        '
        Me.txtMessage.Location = New System.Drawing.Point(158, 74)
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.Size = New System.Drawing.Size(277, 20)
        Me.txtMessage.TabIndex = 18
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(2, 74)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(131, 13)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Message on main screen :"
        '
        'tabGrid
        '
        Me.tabGrid.Controls.Add(Me.GroupBox3)
        Me.tabGrid.Controls.Add(Me.GroupBox2)
        Me.tabGrid.Controls.Add(Me.GroupBox1)
        Me.tabGrid.Location = New System.Drawing.Point(4, 22)
        Me.tabGrid.Name = "tabGrid"
        Me.tabGrid.Padding = New System.Windows.Forms.Padding(3)
        Me.tabGrid.Size = New System.Drawing.Size(439, 248)
        Me.tabGrid.TabIndex = 11
        Me.tabGrid.Text = "Grid"
        Me.tabGrid.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.nudIconGapHeight)
        Me.GroupBox3.Controls.Add(Me.nudIconGapWidth)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 110)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(263, 47)
        Me.GroupBox3.TabIndex = 21
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Gap Size between icons in grid (can be negative)"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(150, 20)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(44, 13)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "Height :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 20)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(41, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Width :"
        '
        'nudIconGapHeight
        '
        Me.nudIconGapHeight.Location = New System.Drawing.Point(196, 18)
        Me.nudIconGapHeight.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.nudIconGapHeight.Name = "nudIconGapHeight"
        Me.nudIconGapHeight.Size = New System.Drawing.Size(60, 20)
        Me.nudIconGapHeight.TabIndex = 3
        '
        'nudIconGapWidth
        '
        Me.nudIconGapWidth.Location = New System.Drawing.Point(62, 18)
        Me.nudIconGapWidth.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.nudIconGapWidth.Name = "nudIconGapWidth"
        Me.nudIconGapWidth.Size = New System.Drawing.Size(60, 20)
        Me.nudIconGapWidth.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.nudIconScale)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.nudIconSizeHeight)
        Me.GroupBox2.Controls.Add(Me.nudIconSizeWidth)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 57)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(430, 47)
        Me.GroupBox2.TabIndex = 20
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Size of icons in grid"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(292, 20)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(64, 13)
        Me.Label14.TabIndex = 4
        Me.Label14.Text = "Icon Scale :"
        '
        'nudIconScale
        '
        Me.nudIconScale.DecimalPlaces = 1
        Me.nudIconScale.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.nudIconScale.Location = New System.Drawing.Point(358, 18)
        Me.nudIconScale.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nudIconScale.Minimum = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.nudIconScale.Name = "nudIconScale"
        Me.nudIconScale.Size = New System.Drawing.Size(60, 20)
        Me.nudIconScale.TabIndex = 5
        Me.nudIconScale.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(149, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 13)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Height :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Width :"
        '
        'nudIconSizeHeight
        '
        Me.nudIconSizeHeight.Location = New System.Drawing.Point(196, 18)
        Me.nudIconSizeHeight.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.nudIconSizeHeight.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudIconSizeHeight.Name = "nudIconSizeHeight"
        Me.nudIconSizeHeight.Size = New System.Drawing.Size(60, 20)
        Me.nudIconSizeHeight.TabIndex = 3
        Me.nudIconSizeHeight.Value = New Decimal(New Integer() {80, 0, 0, 0})
        '
        'nudIconSizeWidth
        '
        Me.nudIconSizeWidth.Location = New System.Drawing.Point(62, 18)
        Me.nudIconSizeWidth.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.nudIconSizeWidth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudIconSizeWidth.Name = "nudIconSizeWidth"
        Me.nudIconSizeWidth.Size = New System.Drawing.Size(60, 20)
        Me.nudIconSizeWidth.TabIndex = 1
        Me.nudIconSizeWidth.Value = New Decimal(New Integer() {75, 0, 0, 0})
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.nudHeight)
        Me.GroupBox1.Controls.Add(Me.nudWidth)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(263, 45)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "# of icons in grid"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(149, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Rows:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Columns:"
        '
        'nudHeight
        '
        Me.nudHeight.Location = New System.Drawing.Point(196, 21)
        Me.nudHeight.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudHeight.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudHeight.Name = "nudHeight"
        Me.nudHeight.Size = New System.Drawing.Size(60, 20)
        Me.nudHeight.TabIndex = 3
        Me.nudHeight.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'nudWidth
        '
        Me.nudWidth.Location = New System.Drawing.Point(62, 20)
        Me.nudWidth.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudWidth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudWidth.Name = "nudWidth"
        Me.nudWidth.Size = New System.Drawing.Size(60, 20)
        Me.nudWidth.TabIndex = 1
        Me.nudWidth.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'tabOthers
        '
        Me.tabOthers.Controls.Add(Me.chkExtract)
        Me.tabOthers.Controls.Add(Me.chkLog)
        Me.tabOthers.Controls.Add(Me.GroupBox5)
        Me.tabOthers.Controls.Add(Me.txtOptionsShortcut)
        Me.tabOthers.Controls.Add(Me.Label4)
        Me.tabOthers.Location = New System.Drawing.Point(4, 22)
        Me.tabOthers.Name = "tabOthers"
        Me.tabOthers.Size = New System.Drawing.Size(439, 248)
        Me.tabOthers.TabIndex = 10
        Me.tabOthers.Text = "Others"
        Me.tabOthers.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtCanonicalizeAppend)
        Me.GroupBox5.Controls.Add(Me.chkCanonicalize)
        Me.GroupBox5.Controls.Add(Me.Label19)
        Me.GroupBox5.Location = New System.Drawing.Point(3, 29)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(430, 48)
        Me.GroupBox5.TabIndex = 22
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Append To / Canonicalize Domain"
        '
        'txtCanonicalizeAppend
        '
        Me.txtCanonicalizeAppend.Location = New System.Drawing.Point(159, 19)
        Me.txtCanonicalizeAppend.Name = "txtCanonicalizeAppend"
        Me.txtCanonicalizeAppend.Size = New System.Drawing.Size(100, 20)
        Me.txtCanonicalizeAppend.TabIndex = 23
        '
        'chkCanonicalize
        '
        Me.chkCanonicalize.AutoSize = True
        Me.chkCanonicalize.BackColor = System.Drawing.SystemColors.Control
        Me.chkCanonicalize.Location = New System.Drawing.Point(9, 0)
        Me.chkCanonicalize.Name = "chkCanonicalize"
        Me.chkCanonicalize.Size = New System.Drawing.Size(189, 17)
        Me.chkCanonicalize.TabIndex = 22
        Me.chkCanonicalize.Text = "Append To / Canonicalize Domain"
        Me.chkCanonicalize.UseVisualStyleBackColor = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 22)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(147, 13)
        Me.Label19.TabIndex = 5
        Me.Label19.Text = "URI Part to Add (omit first dot)"
        '
        'txtOptionsShortcut
        '
        Me.txtOptionsShortcut.Location = New System.Drawing.Point(158, 3)
        Me.txtOptionsShortcut.MaxLength = 1
        Me.txtOptionsShortcut.Name = "txtOptionsShortcut"
        Me.txtOptionsShortcut.Size = New System.Drawing.Size(100, 20)
        Me.txtOptionsShortcut.TabIndex = 14
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(2, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(156, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Hotkey to open Options dialog :"
        '
        'tabStartup
        '
        Me.tabStartup.Controls.Add(Me.GroupBox4)
        Me.tabStartup.Controls.Add(Me.Label1)
        Me.tabStartup.Controls.Add(Me.nudDelayBeforeAutoload)
        Me.tabStartup.Controls.Add(Me.chkAdvanced)
        Me.tabStartup.Controls.Add(Me.cmdCheckForUpdate)
        Me.tabStartup.Controls.Add(Me.chkAutoCheckUpdate)
        Me.tabStartup.Controls.Add(Me.chkPortableMode)
        Me.tabStartup.Location = New System.Drawing.Point(4, 22)
        Me.tabStartup.Name = "tabStartup"
        Me.tabStartup.Size = New System.Drawing.Size(439, 248)
        Me.tabStartup.TabIndex = 13
        Me.tabStartup.Text = "Startup"
        Me.tabStartup.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Controls.Add(Me.cmbStartingPosition)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Controls.Add(Me.nudYOffset)
        Me.GroupBox4.Controls.Add(Me.nudXOffset)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 78)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(430, 47)
        Me.GroupBox4.TabIndex = 21
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Main Screen Starting Position"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 20)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(83, 13)
        Me.Label17.TabIndex = 5
        Me.Label17.Text = "Starting Position"
        '
        'cmbStartingPosition
        '
        Me.cmbStartingPosition.AutoAdjustItemHeight = False
        Me.cmbStartingPosition.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbStartingPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStartingPosition.DropDownWidth = 250
        Me.cmbStartingPosition.FormattingEnabled = True
        Me.cmbStartingPosition.Location = New System.Drawing.Point(95, 17)
        Me.cmbStartingPosition.Name = "cmbStartingPosition"
        Me.cmbStartingPosition.SeparatorColor = System.Drawing.Color.Black
        Me.cmbStartingPosition.SeparatorMargin = 1
        Me.cmbStartingPosition.SeparatorStyle = System.Drawing.Drawing2D.DashStyle.Solid
        Me.cmbStartingPosition.SeparatorWidth = 1
        Me.cmbStartingPosition.Size = New System.Drawing.Size(142, 21)
        Me.cmbStartingPosition.TabIndex = 4
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(335, 20)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(17, 13)
        Me.Label15.TabIndex = 2
        Me.Label15.Text = "Y:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(243, 20)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(20, 13)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "X :"
        '
        'nudYOffset
        '
        Me.nudYOffset.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudYOffset.Location = New System.Drawing.Point(358, 18)
        Me.nudYOffset.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nudYOffset.Minimum = New Decimal(New Integer() {10000, 0, 0, -2147483648})
        Me.nudYOffset.Name = "nudYOffset"
        Me.nudYOffset.Size = New System.Drawing.Size(60, 20)
        Me.nudYOffset.TabIndex = 3
        '
        'nudXOffset
        '
        Me.nudXOffset.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudXOffset.Location = New System.Drawing.Point(269, 18)
        Me.nudXOffset.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nudXOffset.Minimum = New Decimal(New Integer() {10000, 0, 0, -2147483648})
        Me.nudXOffset.Name = "nudXOffset"
        Me.nudXOffset.Size = New System.Drawing.Size(60, 20)
        Me.nudXOffset.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(162, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Default Delay before Auto-Load :"
        '
        'nudDelayBeforeAutoload
        '
        Me.nudDelayBeforeAutoload.Location = New System.Drawing.Point(200, 52)
        Me.nudDelayBeforeAutoload.Name = "nudDelayBeforeAutoload"
        Me.nudDelayBeforeAutoload.Size = New System.Drawing.Size(60, 20)
        Me.nudDelayBeforeAutoload.TabIndex = 13
        '
        'chkAdvanced
        '
        Me.chkAdvanced.AutoSize = True
        Me.chkAdvanced.Location = New System.Drawing.Point(3, 228)
        Me.chkAdvanced.Name = "chkAdvanced"
        Me.chkAdvanced.Size = New System.Drawing.Size(139, 17)
        Me.chkAdvanced.TabIndex = 11
        Me.chkAdvanced.Text = "Use Advanced &Screens"
        Me.chkAdvanced.UseVisualStyleBackColor = True
        Me.chkAdvanced.Visible = False
        '
        'cmdCheckForUpdate
        '
        Me.cmdCheckForUpdate.Location = New System.Drawing.Point(185, 24)
        Me.cmdCheckForUpdate.Name = "cmdCheckForUpdate"
        Me.cmdCheckForUpdate.Size = New System.Drawing.Size(75, 23)
        Me.cmdCheckForUpdate.TabIndex = 9
        Me.cmdCheckForUpdate.Text = "&Check Now"
        Me.cmdCheckForUpdate.UseVisualStyleBackColor = True
        '
        'chkAutoCheckUpdate
        '
        Me.chkAutoCheckUpdate.AutoSize = True
        Me.chkAutoCheckUpdate.Location = New System.Drawing.Point(6, 28)
        Me.chkAutoCheckUpdate.Name = "chkAutoCheckUpdate"
        Me.chkAutoCheckUpdate.Size = New System.Drawing.Size(180, 17)
        Me.chkAutoCheckUpdate.TabIndex = 8
        Me.chkAutoCheckUpdate.Text = "&Automatically Check for Updates"
        Me.chkAutoCheckUpdate.UseVisualStyleBackColor = True
        '
        'chkPortableMode
        '
        Me.chkPortableMode.AutoSize = True
        Me.chkPortableMode.Location = New System.Drawing.Point(6, 6)
        Me.chkPortableMode.Name = "chkPortableMode"
        Me.chkPortableMode.Size = New System.Drawing.Size(95, 17)
        Me.chkPortableMode.TabIndex = 10
        Me.chkPortableMode.Text = "&Portable Mode"
        Me.chkPortableMode.UseVisualStyleBackColor = True
        '
        'tabPrivacy
        '
        Me.tabPrivacy.Controls.Add(Me.chkDownloadDetectionfile)
        Me.tabPrivacy.Controls.Add(Me.txtUserAgent)
        Me.tabPrivacy.Controls.Add(Me.Label8)
        Me.tabPrivacy.Location = New System.Drawing.Point(4, 22)
        Me.tabPrivacy.Name = "tabPrivacy"
        Me.tabPrivacy.Size = New System.Drawing.Size(439, 248)
        Me.tabPrivacy.TabIndex = 12
        Me.tabPrivacy.Text = "Privacy"
        Me.tabPrivacy.UseVisualStyleBackColor = True
        '
        'chkDownloadDetectionfile
        '
        Me.chkDownloadDetectionfile.AutoSize = True
        Me.chkDownloadDetectionfile.Location = New System.Drawing.Point(6, 29)
        Me.chkDownloadDetectionfile.Name = "chkDownloadDetectionfile"
        Me.chkDownloadDetectionfile.Size = New System.Drawing.Size(271, 17)
        Me.chkDownloadDetectionfile.TabIndex = 20
        Me.chkDownloadDetectionfile.Text = "&Download Detection file from BrowserChooser2.com"
        Me.chkDownloadDetectionfile.UseVisualStyleBackColor = True
        '
        'txtUserAgent
        '
        Me.txtUserAgent.Location = New System.Drawing.Point(159, 3)
        Me.txtUserAgent.Name = "txtUserAgent"
        Me.txtUserAgent.Size = New System.Drawing.Size(277, 20)
        Me.txtUserAgent.TabIndex = 19
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 6)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(110, 13)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "User Agent To Send :"
        '
        'tabDefaultBrowser
        '
        Me.tabDefaultBrowser.Controls.Add(Me.cmdRemoveFromDefaultSettings)
        Me.tabDefaultBrowser.Controls.Add(Me.lblWarnWin10)
        Me.tabDefaultBrowser.Controls.Add(Me.lblWarnWin8)
        Me.tabDefaultBrowser.Controls.Add(Me.grpScope)
        Me.tabDefaultBrowser.Controls.Add(Me.chkCheckDefaultOnLaunch)
        Me.tabDefaultBrowser.Controls.Add(Me.cmdMakeDefault)
        Me.tabDefaultBrowser.Controls.Add(Me.cmdAddToDefault)
        Me.tabDefaultBrowser.Controls.Add(Me.txtWarnWin10)
        Me.tabDefaultBrowser.Location = New System.Drawing.Point(4, 22)
        Me.tabDefaultBrowser.Name = "tabDefaultBrowser"
        Me.tabDefaultBrowser.Size = New System.Drawing.Size(439, 248)
        Me.tabDefaultBrowser.TabIndex = 4
        Me.tabDefaultBrowser.Text = "Default Browser"
        Me.tabDefaultBrowser.UseVisualStyleBackColor = True
        '
        'cmdRemoveFromDefaultSettings
        '
        Me.cmdRemoveFromDefaultSettings.Location = New System.Drawing.Point(9, 135)
        Me.cmdRemoveFromDefaultSettings.Name = "cmdRemoveFromDefaultSettings"
        Me.cmdRemoveFromDefaultSettings.Size = New System.Drawing.Size(202, 23)
        Me.cmdRemoveFromDefaultSettings.TabIndex = 8
        Me.cmdRemoveFromDefaultSettings.Text = "Remove from Default Programs"
        Me.cmdRemoveFromDefaultSettings.UseVisualStyleBackColor = True
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
        Me.txtWarnWin10.Text = "Microsoft no longer allows a program to automatically gain default status of eith" &
    "er a a protocol (Browser) or Filetypes.  You must manully assign them via the De" &
    "faults App Applet."
        Me.txtWarnWin10.Visible = False
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(385, 292)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(75, 23)
        Me.cmdSave.TabIndex = 1
        Me.cmdSave.Text = "&Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdHelp
        '
        Me.cmdHelp.Location = New System.Drawing.Point(466, 292)
        Me.cmdHelp.Name = "cmdHelp"
        Me.cmdHelp.Size = New System.Drawing.Size(75, 23)
        Me.cmdHelp.TabIndex = 2
        Me.cmdHelp.Text = "&Help"
        Me.cmdHelp.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(547, 292)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 3
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cdColorDialog
        '
        Me.cdColorDialog.AnyColor = True
        Me.cdColorDialog.Color = System.Drawing.Color.Transparent
        '
        'treeSettings
        '
        Me.treeSettings.Location = New System.Drawing.Point(12, 12)
        Me.treeSettings.Name = "treeSettings"
        TreeNode1.Name = "ndBrowsers"
        TreeNode1.Tag = "tabBrowsers"
        TreeNode1.Text = "Browsers and Applications"
        TreeNode2.Name = "ndAutoUrls"
        TreeNode2.Tag = "tabAutoURLs"
        TreeNode2.Text = "Auto URLs"
        TreeNode3.Name = "ndCommon"
        TreeNode3.Text = "Common"
        TreeNode4.Name = "ndProtocols"
        TreeNode4.Tag = "tabProtocols"
        TreeNode4.Text = "Protocols"
        TreeNode5.Name = "ndFileTypes"
        TreeNode5.Tag = "tabFileTypes"
        TreeNode5.Text = "File Types"
        TreeNode6.Name = "ndAssociations"
        TreeNode6.Text = "Associations"
        TreeNode7.Name = "ndDisplay"
        TreeNode7.Tag = "tabDisplay"
        TreeNode7.Text = "Display"
        TreeNode8.Name = "ndGrid"
        TreeNode8.Tag = "tabGrid"
        TreeNode8.Text = "Grid"
        TreeNode9.Name = "ndPrivacy"
        TreeNode9.Tag = "tabPrivacy"
        TreeNode9.Text = "Privacy"
        TreeNode10.Name = "ndStartup"
        TreeNode10.Tag = "tabStartup"
        TreeNode10.Text = "Startup"
        TreeNode11.Name = "ndOthers"
        TreeNode11.Tag = "tabOthers"
        TreeNode11.Text = "Others"
        TreeNode12.Name = "ndSettigns"
        TreeNode12.Text = "Settings"
        TreeNode13.Name = "ndDefauls"
        TreeNode13.Tag = "tabDefaultBrowser"
        TreeNode13.Text = "Windows Default"
        Me.treeSettings.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode3, TreeNode6, TreeNode12, TreeNode13})
        Me.treeSettings.Size = New System.Drawing.Size(165, 270)
        Me.treeSettings.TabIndex = 4
        '
        'chkLog
        '
        Me.chkLog.AutoSize = True
        Me.chkLog.BackColor = System.Drawing.Color.Transparent
        Me.chkLog.Location = New System.Drawing.Point(5, 83)
        Me.chkLog.Name = "chkLog"
        Me.chkLog.Size = New System.Drawing.Size(100, 17)
        Me.chkLog.TabIndex = 24
        Me.chkLog.Text = "Enable Logging"
        Me.chkLog.UseVisualStyleBackColor = False
        '
        'chkExtract
        '
        Me.chkExtract.AutoSize = True
        Me.chkExtract.BackColor = System.Drawing.Color.Transparent
        Me.chkExtract.Location = New System.Drawing.Point(5, 106)
        Me.chkExtract.Name = "chkExtract"
        Me.chkExtract.Size = New System.Drawing.Size(128, 17)
        Me.chkExtract.TabIndex = 25
        Me.chkExtract.Text = "Extract embded DLLs"
        Me.chkExtract.UseVisualStyleBackColor = False
        '
        'frmOptions
        '
        Me.AcceptButton = Me.cmdSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(638, 327)
        Me.Controls.Add(Me.treeSettings)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdHelp)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.tabSettings)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
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
        Me.tabDisplay.ResumeLayout(False)
        Me.tabDisplay.PerformLayout()
        CType(Me.pbBackgroundColor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabGrid.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.nudIconGapHeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudIconGapWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.nudIconScale, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudIconSizeHeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudIconSizeWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.nudHeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabOthers.ResumeLayout(False)
        Me.tabOthers.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.tabStartup.ResumeLayout(False)
        Me.tabStartup.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.nudYOffset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudXOffset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudDelayBeforeAutoload, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPrivacy.ResumeLayout(False)
        Me.tabPrivacy.PerformLayout()
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
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdHelp As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents chName As System.Windows.Forms.ColumnHeader
    Friend WithEvents cmdAutoURLDelete As System.Windows.Forms.Button
    Friend WithEvents cmdAutoURLEdit As System.Windows.Forms.Button
    Friend WithEvents cmdAutoURLAdd As System.Windows.Forms.Button
    Friend WithEvents lstURLs As System.Windows.Forms.ListView
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
    Friend WithEvents grpScope As System.Windows.Forms.GroupBox
    Friend WithEvents rbScopeSystem As System.Windows.Forms.RadioButton
    Friend WithEvents rbScopeUser As System.Windows.Forms.RadioButton
    Friend WithEvents tabCategories As System.Windows.Forms.TabPage
    Friend WithEvents lstCategories As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblWarnWin8 As System.Windows.Forms.Label
    Friend WithEvents cmdBrowserClone As System.Windows.Forms.Button
    Friend WithEvents cmdDetectBrowsers As System.Windows.Forms.Button
    Friend WithEvents cmdMoveDownAutoURL As System.Windows.Forms.Button
    Friend WithEvents cmdMoveUpAutoURL As System.Windows.Forms.Button
    Friend WithEvents txtWarnWin10 As System.Windows.Forms.TextBox
    Friend WithEvents lblWarnWin10 As System.Windows.Forms.Label
    Friend WithEvents cmdOpenDefaultForProtocol As System.Windows.Forms.Button
    Friend WithEvents cmdOpenDefaultForFile As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cdColorDialog As System.Windows.Forms.ColorDialog
    Friend WithEvents imBrowserIcons As System.Windows.Forms.ImageList
    Friend WithEvents chRow As System.Windows.Forms.ColumnHeader
    Friend WithEvents chColumn As System.Windows.Forms.ColumnHeader
    Friend WithEvents chProtocolsAndFileTypes As System.Windows.Forms.ColumnHeader
    Friend WithEvents treeSettings As TreeView
    Friend WithEvents tabDisplay As TabPage
    Friend WithEvents chkRevealShortURLs As CheckBox
    Friend WithEvents chkUseAreo As CheckBox
    Friend WithEvents chkUseAccessibleRendering As CheckBox
    Friend WithEvents cmdAccessiblitySettings As Button
    Friend WithEvents cmdTransparentBackground As Button
    Friend WithEvents pbBackgroundColor As PictureBox
    Friend WithEvents cmdChangeBackgroundColor As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents chkShowURLs As CheckBox
    Friend WithEvents txtSeperator As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtMessage As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents tabGrid As TabPage
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents nudIconGapHeight As NumericUpDown
    Friend WithEvents nudIconGapWidth As NumericUpDown
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label14 As Label
    Friend WithEvents nudIconScale As NumericUpDown
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents nudIconSizeHeight As NumericUpDown
    Friend WithEvents nudIconSizeWidth As NumericUpDown
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents nudHeight As NumericUpDown
    Friend WithEvents nudWidth As NumericUpDown
    Friend WithEvents tabOthers As TabPage
    Friend WithEvents txtOptionsShortcut As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents tabStartup As TabPage
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label17 As Label
    Friend WithEvents cmbStartingPosition As SeparatorComboBox.SeparatorComboBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents nudYOffset As NumericUpDown
    Friend WithEvents nudXOffset As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents nudDelayBeforeAutoload As NumericUpDown
    Friend WithEvents chkAdvanced As CheckBox
    Friend WithEvents cmdCheckForUpdate As Button
    Friend WithEvents chkAutoCheckUpdate As CheckBox
    Friend WithEvents chkPortableMode As CheckBox
    Friend WithEvents tabPrivacy As TabPage
    Friend WithEvents chkDownloadDetectionfile As CheckBox
    Friend WithEvents txtUserAgent As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents cmdRemoveFromDefaultSettings As Button
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents chkAllowStayOpen As CheckBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents chkCanonicalize As CheckBox
    Friend WithEvents Label19 As Label
    Friend WithEvents txtCanonicalizeAppend As TextBox
    Friend WithEvents chkLog As CheckBox
    Friend WithEvents chkExtract As CheckBox
End Class
