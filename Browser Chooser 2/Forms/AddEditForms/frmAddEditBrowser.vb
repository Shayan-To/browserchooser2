Public Class frmAddEditBrowser
    Private mBrowser As Browser
    Private mbOkayed As Boolean = False
    Private miID As Integer 'unique number used as ID
    Private Const COLLAPSED_HEIGHT As Integer = 359
    Private Const EXPANDED_HEIGHT As Integer = 467
    Private mProtocols As Dictionary(Of Integer, Protocol)
    Private mFileTypes As Dictionary(Of Integer, FileType)
    Private mBrowsers As Dictionary(Of Integer, Browser)
    Private mbAddingItems As Boolean = False
    Private mGUID As Guid

    Private Sub PopulateCategories(ByVal aBrowsers As Dictionary(Of Integer, Browser))
        Dim lCategories As New List(Of String)
        For Each lBrowser As KeyValuePair(Of Integer, Browser) In aBrowsers
            If lCategories.Contains(lBrowser.Value.Category) = False Then
                lCategories.Add(lBrowser.Value.Category)
            End If
        Next

        cmbCategory.Items.Clear()
        cmbCategory.Items.AddRange(lCategories.ToArray)
    End Sub

    Private Function doAddBrowser(ByVal aBrowsers As Dictionary(Of Integer, Browser), ByVal aProtocols As Dictionary(Of Integer, Protocol),
                               ByVal aFileTypes As Dictionary(Of Integer, FileType), ByVal abAdvancedScreens As Boolean, ByVal aXY As Point, ByVal aOriginal As Browser) As Boolean
        'get the thread started to fill the combobox
        InitFillPathComboBox()

        'Dim lbOk As Boolean = False
        Me.Text = "Add Browser"
        Me.TopMost = True
        PopulateCategories(aBrowsers)
        Me.Height = COLLAPSED_HEIGHT

        If IsNothing(aOriginal) = False Then
            cmbCategory.Text = aOriginal.Category
            txtName.Text = aOriginal.Name
            chkIsActive.Checked = aOriginal.IsActive
            cmbTarget.Text = aOriginal.Target
            chkIEBehaviour.Checked = aOriginal.IsIE
            chkIsEdge.Checked = aOriginal.IsEdge
            cmbStandard.Text = aOriginal.Image
            txtImagePath.Text = aOriginal.CustomImagePath
            nudIconIndex.Value = aOriginal.IconIndex
            txtArguments.Text = aOriginal.Arguments
            nudScale.Value = CType(aOriginal.Scale, Decimal)
            chkVisible.Checked = aOriginal.Shown
        Else
            chkIsActive.Checked = True
            cmbStandard.Text = "(Extract)"
            cmbCategory.Text = GeneralUtilities.DEFAULT_CATEGORY
            chkVisible.Checked = True
            nudScale.Value = 1
        End If
        UpdateVisible()

        'find the next avilable slot
        Dim lIndexes As New SortedList 'start with an index of positions used
        For Each lBrowser As KeyValuePair(Of Integer, Browser) In aBrowsers
            lIndexes.Add(lBrowser.Value.PosX.ToString & lBrowser.Value.PosY.ToString, Nothing)
        Next

        'go thrught list until a gap is found
        Dim lbFound As Boolean = False
        For lY As Integer = 1 To aXY.Y
            For lX As Integer = 1 To aXY.X
                If lIndexes.ContainsKey(lX.ToString & lY.ToString) = False Then
                    'found it
                    nudX.Value = lX
                    nudY.Value = lY
                    lbFound = True
                    Exit For : Exit For
                End If
            Next

            If lbFound = True Then Exit For
        Next

        mGUID = System.Guid.NewGuid
        mProtocols = aProtocols
        mFileTypes = aFileTypes
        mBrowsers = aBrowsers

        'add the new GUID to the list above
        For Each lProtocol As KeyValuePair(Of Integer, Protocol) In mProtocols
            If lProtocol.Value.DefaultCategories.Contains(GeneralUtilities.DEFAULT_CATEGORY) = True Then
                lProtocol.Value.SupportingBrowsers.Add(mGUID)
            End If
        Next

        For Each lFileTypes As KeyValuePair(Of Integer, FileType) In mFileTypes
            If lFileTypes.Value.DefaultCategories.Contains(GeneralUtilities.DEFAULT_CATEGORY) = True Then
                lFileTypes.Value.SupportingBrowsers.Add(mGUID)
            End If
        Next

        AdjustScreen(abAdvancedScreens)
        Me.ShowDialog()

        Return mbOkayed
    End Function


    Public Function AddBrowser(ByVal aBrowsers As Dictionary(Of Integer, Browser), ByVal aProtocols As Dictionary(Of Integer, Protocol),
                               ByVal aFileTypes As Dictionary(Of Integer, FileType), ByVal abAdvancedScreens As Boolean, ByVal aXY As Point, ByVal aOriginal As Browser) As Boolean

        'shunt over to add function
        Return doAddBrowser(aBrowsers, aProtocols, aFileTypes, abAdvancedScreens, aXY, aOriginal)
    End Function

    Public Function AddBrowser(ByVal aBrowsers As Dictionary(Of Integer, Browser), ByVal aProtocols As Dictionary(Of Integer, Protocol),
                               ByVal aFileTypes As Dictionary(Of Integer, FileType), ByVal abAdvancedScreens As Boolean, ByVal aXY As Point) As Boolean

        'shunt over to add function
        Return doAddBrowser(aBrowsers, aProtocols, aFileTypes, abAdvancedScreens, aXY, Nothing)
    End Function

    Public Function EditBrowser(ByVal aBrowser As Browser, ByVal aBrowsers As Dictionary(Of Integer, Browser), ByVal aProtocols As Dictionary(Of Integer, Protocol),
                               ByVal aFileTypes As Dictionary(Of Integer, FileType), ByVal abAdvancedScreens As Boolean) As Boolean

        'get the thread started to fill the combobox
        InitFillPathComboBox()

        'Dim lbOk As Boolean = False
        Me.Text = "Edit " + aBrowser.Name
        Me.TopMost = True
        PopulateCategories(aBrowsers)
        Me.Height = COLLAPSED_HEIGHT

        'populate screen
        cmbCategory.Text = aBrowser.Category
        txtName.Text = aBrowser.Name
        chkIsActive.Checked = aBrowser.IsActive
        cmbTarget.Text = aBrowser.Target
        chkIEBehaviour.Checked = aBrowser.IsIE
        chkIsEdge.Checked = aBrowser.IsEdge
        cmbStandard.Text = aBrowser.Image
        txtImagePath.Text = aBrowser.CustomImagePath
        nudX.Value = aBrowser.PosX
        nudY.Value = aBrowser.PosY
        txtHotkey.Text = aBrowser.Hotkey
        nudIconIndex.Value = aBrowser.IconIndex
        txtArguments.Text = aBrowser.Arguments
        nudScale.Value = CType(aBrowser.Scale, Decimal)
        chkVisible.Checked = aBrowser.Shown
        UpdateVisible()

        mBrowser = aBrowser

        mGUID = mBrowser.GUID
        mProtocols = aProtocols
        mFileTypes = aFileTypes
        mBrowsers = aBrowsers

        AdjustScreen(abAdvancedScreens)
        Me.ShowDialog()

        Return mbOkayed
    End Function

    Private Sub cmdTargetBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTargetBrowse.Click
        ofdBrowse.Filter = "*.exe|*.exe"
        If ofdBrowse.ShowDialog() = Windows.Forms.DialogResult.OK Then
            cmbTarget.Text = ofdBrowse.FileName

            If InStr(cmbTarget.Text, "iexplore") > 0 Then
                chkIEBehaviour.Checked = True
            Else
                chkIEBehaviour.Checked = False
            End If
        End If
    End Sub

    Private Sub cmbStandard_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStandard.SelectedIndexChanged
        If cmbStandard.Text <> "(Custom)" Then
            txtImagePath.Enabled = False
        Else
            txtImagePath.Enabled = True
        End If
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        'validate screen
        If txtName.Text = "" Then
            MessageBox.Show("Name cannot be empty", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Exit Sub
        ElseIf InStr(cmbTarget.Text, ".exe ") > 0 Then
            MessageBox.Show("Do not put parameter info in target path. Use Arguments field.", "Bad Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Exit Sub
        ElseIf InStr(cmbTarget.Text, """") = 1 Then
            'strip leading and trailling quotes if any
            cmbTarget.Text = Mid(cmbTarget.Text, 2)

            If Microsoft.VisualBasic.Strings.Right(cmbTarget.Text, 1) = """" Then
                cmbTarget.Text = Mid(cmbTarget.Text, 1, cmbTarget.Text.Length - 1)
            End If
        End If

        'check if x and y are already taken
        Dim lIndexes As New SortedList 'start with an index of positions used
        For Each lBrowser As KeyValuePair(Of Integer, Browser) In mBrowsers
            If lBrowser.Value.GUID <> mGUID Then
                lIndexes.Add((lBrowser.Value.PosX).ToString & (lBrowser.Value.PosY).ToString, Nothing)
            End If
        Next

        If lIndexes.ContainsKey(nudX.Value.ToString & nudY.Value.ToString) = True Then
            MessageBox.Show("There is already a browser at position " & nudX.Value.ToString & ", " & nudY.Value.ToString & ". Please use another location.", "Conflicting Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Exit Sub
        End If

        mbOkayed = True

        Me.Hide()
    End Sub
    Public Structure BrowserReturnValue
        Public Browser As Browser
        Public Protocols As Dictionary(Of Integer, Protocol)
        Public FileTypes As Dictionary(Of Integer, FileType)
    End Structure
    Public Function GetData() As BrowserReturnValue
        'output the choices
        Dim lOut As New BrowserReturnValue
        Dim lBOut As New Browser

        lBOut.GUID = mGUID
        lBOut.Name = txtName.Text
        lBOut.Target = cmbTarget.Text
        lBOut.Image = cmbStandard.Text
        lBOut.CustomImagePath = txtImagePath.Text
        lBOut.IsActive = chkIsActive.Checked
        If txtHotkey.Text <> "" Then
            lBOut.Hotkey = txtHotkey.Text.Chars(0)
        Else
            lBOut.Hotkey = Char.MinValue
        End If
        lBOut.IsIE = chkIEBehaviour.Checked
        lBOut.IsEdge = chkIsEdge.Checked
        lBOut.PosX = CInt(nudX.Value)
        lBOut.PosY = CInt(nudY.Value)
        lBOut.IconIndex = CInt(nudIconIndex.Value)
        lBOut.Category = cmbCategory.Text
        lBOut.Arguments = txtArguments.Text
        lBOut.Scale = nudScale.Value
        lBOut.Shown = chkVisible.Checked

        lOut.Browser = lBOut

        'protocols and filetypes
        lOut.Protocols = mProtocols
        lOut.FileTypes = mFileTypes

        Return lOut
    End Function

    Private Sub btnViewAvailable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewAvailable.Click
        Dim lResult As Integer

        If cmbStandard.Text = "(Extract)" Then
            If My.Computer.FileSystem.FileExists(cmbTarget.Text) = True Then
                lResult = frmIcons.ChooseIcon(cmbTarget.Text, CInt(nudIconIndex.Value))
            End If
        Else
            If My.Computer.FileSystem.FileExists(txtImagePath.Text) = True Then
                lResult = frmIcons.ChooseIcon(cmbTarget.Text, CInt(nudIconIndex.Value))
            End If
        End If

        If lResult > -1 Then
            nudIconIndex.Value = lResult
        End If

    End Sub

    Private Sub cmdHelpCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHelpCategory.Click
        'MessageBox.Show("Enter any name here. All Browsers/Applications with the same category will be grouped togher, then have they X & Y coordinates applied.", "Help", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information)
        MessageBox.Show("Enter any name here. Categories are used with protocols and file types to allow quickly adding supported protocols and file types.", "Help", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information)
    End Sub

    Private Sub cmdShowProtocols_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowProtocols.Click
        If Me.Height = COLLAPSED_HEIGHT Or InStr(cmdShowProtocols.Text, "Show") > 0 Then
            Me.Height = EXPANDED_HEIGHT

            cmdShowProtocols.Text = "Hide Protocols"

            lstSupportedProps.Columns.Clear()
            lstSupportedProps.Items.Clear()

            'add the two required columns
            lstSupportedProps.Columns.Add("Header", 200)
            lstSupportedProps.Columns.Add("Protocol Name", 200)

            mbAddingItems = True
            For Each lKVP As KeyValuePair(Of Integer, Protocol) In mProtocols
                Dim llsiItem As ListViewItem = lstSupportedProps.Items.Add(lKVP.Value.Header)
                llsiItem.SubItems.Add(lKVP.Value.ProtocolName)
                llsiItem.Tag = lKVP.Key

                If IsNothing(mBrowser) = False Then
                    If lKVP.Value.SupportingBrowsers.Contains(mGUID) Then
                        llsiItem.Checked = True
                    End If
                ElseIf lKVP.Value.DefaultCategories.Contains(cmbCategory.Text) = True Then
                    llsiItem.Checked = True 'default to on
                End If
            Next
            mbAddingItems = False

            lstSupportedProps.Tag = "Protocols"
            lstSupportedProps.Enabled = True
        Else
            Me.Height = COLLAPSED_HEIGHT
            lstSupportedProps.Enabled = False
            cmdShowProtocols.Text = "Show Protocols"
        End If

        'universal parts
        cmdShowExtentions.Text = "Show Extentions"
    End Sub

    Private Sub cmdShowExtentions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowExtentions.Click
        If Me.Height = COLLAPSED_HEIGHT Or InStr(cmdShowExtentions.Text, "Show") > 0 Then
            Me.Height = EXPANDED_HEIGHT

            cmdShowExtentions.Text = "Hide Extentions"

            lstSupportedProps.Columns.Clear()
            lstSupportedProps.Items.Clear()

            'add the two required columns
            lstSupportedProps.Columns.Add("Extention", 200)
            lstSupportedProps.Columns.Add("Type Name", 200)

            mbAddingItems = True
            For Each lKVP As KeyValuePair(Of Integer, FileType) In mFileTypes
                Dim llsiItem As ListViewItem = lstSupportedProps.Items.Add(lKVP.Value.Extention)
                llsiItem.SubItems.Add(lKVP.Value.FiletypeName)
                llsiItem.Tag = lKVP.Key

                If IsNothing(mBrowser) = False Then
                    If lKVP.Value.SupportingBrowsers.Contains(mGUID) Then
                        llsiItem.Checked = True
                    End If
                ElseIf lKVP.Value.DefaultCategories.Contains(cmbCategory.Text) = True Then
                    llsiItem.Checked = True 'default to on
                End If
            Next
            mbAddingItems = False

            lstSupportedProps.Tag = "Extentions"
            lstSupportedProps.Enabled = True
        Else
            Me.Height = COLLAPSED_HEIGHT
            lstSupportedProps.Enabled = False
            cmdShowExtentions.Text = "Show Extentions"
        End If

        'universal parts
        cmdShowProtocols.Text = "Show Protocols"
    End Sub

    Private Sub AdjustScreen(ByVal abAdvancedScreens As Boolean)
        If abAdvancedScreens = False And (IsNothing(Me.Tag) = True OrElse Me.Tag.ToString <> "Hidden") Then
            cmbCategory.Visible = False
            lblCategory.Visible = False
            cmdHelpCategory.Visible = False
            cmdShowExtentions.Visible = False
            cmdShowProtocols.Visible = False
            grpTarget.Top = grpTarget.Top - 26
            grpImage.Top = grpImage.Top - 26
            grpPosition.Top = grpPosition.Top - 26
            grpHotkey.Top = grpHotkey.Top - 26
            cmdOK.Top = cmdOK.Top - 26
            cmdCancel.Top = cmdCancel.Top - 26
            Me.Height = Me.Height - 26
            Me.Tag = "Hidden"
        ElseIf IsNothing(Me.Tag) = False AndAlso Me.Tag.ToString = "Hidden" Then
            'shoudl no longer be
            cmbCategory.Visible = True
            lblCategory.Visible = True
            cmdHelpCategory.Visible = True
            cmdShowExtentions.Visible = True
            cmdShowProtocols.Visible = True
            grpTarget.Top = grpTarget.Top + 26
            grpImage.Top = grpImage.Top + 26
            grpPosition.Top = grpPosition.Top + 26
            grpHotkey.Top = grpHotkey.Top + 26
            cmdOK.Top = cmdOK.Top + 26
            cmdCancel.Top = cmdCancel.Top + 26
            Me.Height = Me.Height + 26
            Me.Tag = ""
        End If
    End Sub

    Private Sub lstSupportedProps_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles lstSupportedProps.ItemCheck
        'make a copy in memory
        If mbAddingItems = False Then
            Dim llsiItem As ListViewItem = lstSupportedProps.Items(e.Index)
            If lstSupportedProps.Tag.ToString = "Protocols" Then
                Dim lProtocol As Protocol = mProtocols.Item(CInt(llsiItem.Tag))
                If lProtocol.SupportingBrowsers.Contains(mGUID) And llsiItem.Checked = True Then
                    'delete
                    lProtocol.SupportingBrowsers.Remove(mGUID)
                Else
                    'add
                    lProtocol.SupportingBrowsers.Add(mGUID)
                End If
            Else
                Dim lFileType As FileType = mFileTypes.Item(CInt(llsiItem.Tag))
                If lFileType.SupportingBrowsers.Contains(mGUID) And llsiItem.Checked = True Then
                    'delete
                    lFileType.SupportingBrowsers.Remove(mGUID)
                Else
                    'add
                    lFileType.SupportingBrowsers.Add(mGUID)
                End If
            End If
        End If
    End Sub

    Private Sub UpdateVisible()
        If chkVisible.Checked = True Then
            chkVisible.CheckState = CheckState.Checked
            nudX.Enabled = True
            nudY.Enabled = True
        Else
            nudX.Enabled = False
            nudY.Enabled = False
            chkVisible.CheckState = CheckState.Unchecked
        End If
    End Sub

    Private Sub chkVisible_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkVisible.CheckedChanged
        UpdateVisible()
    End Sub

#Region "Detect Browsers to fill Path CMB"
    Private lThread As Threading.Thread
    Private Delegate Sub FinishFillPathComboBoxCallback(aBrowsers As List(Of Browser))

    Private Sub FinishFillPathComboBox(aBrowsers As List(Of Browser))
        For Each lBrowser As Browser In aBrowsers
            cmbTarget.Items.Add(lBrowser.Target)
        Next
    End Sub

    Public Sub DoFillPathComboBox()
        Dim lResult As List(Of Browser) = DetectedBrowsers.DoBrowserDetection()

        'may nto be thread safe
        If Me.InvokeRequired Then
            Dim d As New FinishFillPathComboBoxCallback(AddressOf FinishFillPathComboBox)
            Me.Invoke(d, New Object() {lResult})
        Else
            FinishFillPathComboBox(lResult)
        End If
    End Sub

    Public Sub InitFillPathComboBox()
        lThread = New Threading.Thread(AddressOf DoFillPathComboBox)
        lThread.Start()
    End Sub
#End Region
End Class