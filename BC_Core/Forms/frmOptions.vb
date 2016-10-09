'Imports System.IO

Public Class frmOptions
    '    Private mBrowser As Dictionary(Of Integer, Browser) 'copies
    '    Private mURLs As SortedDictionary(Of Integer, URL) 'copies
    '    Private mProtocols As Dictionary(Of Integer, Protocol) 'copies
    '    Private mProtocolsAreDirty As Boolean = False
    '    Private mFileTypes As Dictionary(Of Integer, FileType) 'copies
    '    Private mFileTypesAreDirty As Boolean = False
    '    Private mLastBrowserID As Integer
    '    Private mLastURLID As Integer
    '    Private mLastProtocolID As Integer
    '    Private mLastFileTypeID As Integer
    '    Private mFocusSettings As frmAccessibilitySettings.FocusSettings
    '    Private mbDirty As Boolean = False

    '#Region "Bottom Control Buttons"
    '    Private Sub cmdHelp_Click(sender As System.Object, e As System.EventArgs) Handles cmdHelp.Click
    '        Try
    '			Launch("https://bitbucket.org/gmyx/browserchooser2/wiki/Home", False)
    '		Catch ex As Exception
    '            MsgBox("Help page cannot be reached!" & Environment.NewLine & Environment.NewLine & ex.Message, MsgBoxStyle.Critical)
    '        End Try
    '    End Sub

    '    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
    '        Me.Close()
    '    End Sub

    '    Private Sub DoSave()
    '        'update internet classes and then file

    '        'browsers page
    '        gSettings.Browsers = New List(Of Browser)
    '        For Each lBrowser As KeyValuePair(Of Integer, Browser) In mBrowser
    '            gSettings.Browsers.Add(DirectCast(lBrowser.Value.Clone, Browser))
    '        Next

    '        'urls page
    '        gSettings.URLs = New List(Of URL)
    '        For Each lURL As KeyValuePair(Of Integer, URL) In mURLs
    '            gSettings.URLs.Add(DirectCast(lURL.Value.Clone, URL))
    '        Next

    '        'protocols page
    '        gSettings.Protocols = New List(Of Protocol)
    '        For Each lProtocol As KeyValuePair(Of Integer, Protocol) In mProtocols
    '            gSettings.Protocols.Add(DirectCast(lProtocol.Value.Clone, Protocol))
    '        Next

    '        'filetypes page
    '        gSettings.FileTypes = New List(Of FileType)
    '        For Each lFileType As KeyValuePair(Of Integer, FileType) In mFileTypes
    '            gSettings.FileTypes.Add(DirectCast(lFileType.Value.Clone, FileType))
    '        Next

    '        'if file types or protocols have changed, ask to renew defualt settings
    '        If mFileTypesAreDirty = True Or mProtocolsAreDirty = True Then
    '            If MessageBox.Show("You have changed the accepted Protocols or Filetypes. Do you want to become default for these as well?", "Become default", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '                AddToDefault()
    '                MakeDefault()
    '            End If
    '        End If

    '        'options page
    '        'default
    '        gSettings.ShowURL = chkShowURLs.Checked
    '        gSettings.RevealShortURL = chkRevealShortURLs.Checked
    '        gSettings.PortableMode = chkPortableMode.Checked
    '        gSettings.AutomaticUpdates = chkAutoCheckUpdate.Checked
    '        gSettings.Height = CInt(nudHeight.Value)
    '        gSettings.Width = CInt(nudWidth.Value)
    '        gSettings.CheckDefaultOnLaunch = chkCheckDefaultOnLaunch.Checked
    '        gSettings.AdvancedScreens = chkAdvanced.Checked
    '        gSettings.DefaultDelay = CInt(nudDelayBeforeAutoload.Value)
    '        gSettings.Seperator = txtSeperator.Text

    '        'more settings
    '        gSettings.UserAgent = txtUserAgent.Text
    '        gSettings.DownloadDetectionFile = chkDownloadDetectionfile.Checked
    '        gSettings.IconWidth = CInt(nudIconSizeWidth.Value)
    '        gSettings.IconHeight = CInt(nudIconSizeHeight.Value)
    '        gSettings.IconGapWidth = CInt(nudIconGapWidth.Value)
    '        gSettings.IconGapHeight = CInt(nudIconGapHeight.Value)
    '        gSettings.BackgroundColor = pbBackgroundColor.BackColor.ToArgb
    '        gSettings.IconScale = nudIconScale.Value

    '        Dim lSelectedStartingPosition As DisplayDictionary = TryCast(cmbStartingPosition.SelectedItem, DisplayDictionary)
    '        If Not lSelectedStartingPosition Is Nothing Then
    '            gSettings.StartingPosition = lSelectedStartingPosition.Index
    '        Else
    '            gSettings.StartingPosition = Settings.AvailableStartingPositions.CenterScreen 'center screen
    '        End If

    '        gSettings.OffsetX = CInt(nudXOffset.Value)
    '        gSettings.OffsetY = CInt(nudYOffset.Value)

    '        'a11y settings
    '        gSettings.AccessibleRendering = chkUseAccessibleRendering.Checked
    '        gSettings.UseAreo = chkUseAreo.Checked

    '        'focus settings
    '        gSettings.ShowFocus = mFocusSettings.ShowFocus
    '        gSettings.FocusBoxColor = mFocusSettings.BoxColor.ToArgb
    '        gSettings.FocusBoxLineWidth = mFocusSettings.BoxWidth

    '        If txtOptionsShortcut.Text <> "" Then
    '            gSettings.OptionsShortcut = txtOptionsShortcut.Text.Chars(0) 'no matter what, i take the first and only char
    '        Else
    '            gSettings.OptionsShortcut = Char.MinValue 'null
    '        End If
    '        gSettings.DefaultMessage = txtMessage.Text

    '        'Save
    '        gSettings.DoSave(True)

    '        Application.Restart()
    '    End Sub

    '    Private Sub cmdSave_Click(sender As System.Object, e As System.EventArgs) Handles cmdSave.Click
    '        DoSave()
    '    End Sub
    '#End Region

    '#Region "Browser CRUD"
    '    Private Sub cmdBrowserAdd_Click(sender As System.Object, e As System.EventArgs) Handles cmdBrowserAdd.Click
    '        'show up a dialog to set the browser settings
    '        Dim lfrmAdd As New frmAddEditBrowser

    '        If lfrmAdd.AddBrowser(mBrowser, mProtocols, mFileTypes, chkAdvanced.Checked, New Point(CInt(nudWidth.Value), CInt(nudHeight.Value))) = True Then
    '            Dim lNewBrowser As frmAddEditBrowser.BrowserReturnValue = lfrmAdd.GetData
    '            mBrowser.Add(mLastBrowserID + 1, lNewBrowser.Browser)
    '            imBrowserIcons.Images.Add(ImageUtilities.GetImage(lNewBrowser.Browser, False))

    '            Dim llsiItem As ListViewItem = lstBrowsers.Items.Add(lNewBrowser.Browser.Name, imBrowserIcons.Images.Count - 1)
    '            llsiItem.Tag = mLastBrowserID + 1
    '            llsiItem.SubItems.Add(lNewBrowser.Browser.PosX.ToString)
    '            llsiItem.SubItems.Add(lNewBrowser.Browser.PosY.ToString)
    '            mLastBrowserID += 1

    '            'also save updated protocols and filetypes
    '            mProtocols = lNewBrowser.Protocols
    '            mFileTypes = lNewBrowser.FileTypes

    '            'now display them
    '            llsiItem.SubItems.Add(GetBrowserProtocolsAndFileTypes(lNewBrowser.Browser))

    '            'indicate that the screen is dirty and needs to be saved
    '            mbDirty = True
    '        End If
    '    End Sub

    '    Private Sub cmdBrowserDelete_Click(sender As System.Object, e As System.EventArgs) Handles cmdBrowserDelete.Click
    '        If lstBrowsers.SelectedItems.Count > 0 Then
    '            If MessageBox.Show("Are you sure you want delete the " + lstBrowsers.SelectedItems(0).Text + " entry?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '                mBrowser.Remove(CInt(lstBrowsers.SelectedItems(0).Tag))
    '                lstBrowsers.Items.Remove(lstBrowsers.SelectedItems(0))

    '                'indicate that the screen is dirty and needs to be saved
    '                mbDirty = True
    '            End If
    '        End If
    '    End Sub

    '    Private Sub cmdBrowserEdit_Click(sender As System.Object, e As System.EventArgs) Handles cmdBrowserEdit.Click, lstBrowsers.DoubleClick
    '        If lstBrowsers.SelectedItems.Count > 0 Then
    '            'show up a dialog to set the browser settings
    '            Dim lfrmAdd As New frmAddEditBrowser

    '            If lfrmAdd.EditBrowser(mBrowser(CInt(lstBrowsers.SelectedItems(0).Tag)), mBrowser, mProtocols, mFileTypes, chkAdvanced.Checked) = True Then
    '                Dim lNewBrowser As frmAddEditBrowser.BrowserReturnValue = lfrmAdd.GetData
    '                mBrowser(CInt(lstBrowsers.SelectedItems(0).Tag)) = lNewBrowser.Browser
    '                imBrowserIcons.Images.Item(CInt(lstBrowsers.SelectedItems(0).Tag)) = ImageUtilities.ScaleImageTo(ImageUtilities.GetImage(lNewBrowser.Browser, False), New Size(16, 16))

    '                lstBrowsers.SelectedItems(0).Text = lNewBrowser.Browser.Name
    '                lstBrowsers.SelectedItems(0).SubItems(1).Text = lNewBrowser.Browser.PosX.ToString
    '                lstBrowsers.SelectedItems(0).SubItems(2).Text = lNewBrowser.Browser.PosY.ToString

    '                'also save updated protocols and filetypes
    '                mProtocols = lNewBrowser.Protocols
    '                mFileTypes = lNewBrowser.FileTypes

    '                ' now display them
    '                lstBrowsers.SelectedItems(0).SubItems(3).Text = GetBrowserProtocolsAndFileTypes(lNewBrowser.Browser)

    '                'indicate that the screen is dirty and needs to be saved
    '                mbDirty = True
    '            End If
    '        End If
    '    End Sub

    '    Private Sub cmdBrowserClone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowserClone.Click
    '        If lstBrowsers.SelectedItems.Count > 0 Then
    '            'show up a dialog to set the browser settings
    '            Dim lfrmAdd As New frmAddEditBrowser

    '            If lfrmAdd.AddBrowser(mBrowser, mProtocols, mFileTypes, chkAdvanced.Checked, New Point(CInt(nudWidth.Value), CInt(nudHeight.Value)), mBrowser(CInt(lstBrowsers.SelectedItems(0).Tag))) = True Then
    '                Dim lNewBrowser As frmAddEditBrowser.BrowserReturnValue = lfrmAdd.GetData
    '                mBrowser.Add(mLastBrowserID + 1, lNewBrowser.Browser)
    '                imBrowserIcons.Images.Add(ImageUtilities.GetImage(lNewBrowser.Browser, False))

    '                Dim llsiItem As ListViewItem = lstBrowsers.Items.Add(lNewBrowser.Browser.Name, imBrowserIcons.Images.Count - 1)
    '                llsiItem.Tag = mLastBrowserID + 1
    '                llsiItem.SubItems.Add(lNewBrowser.Browser.PosX.ToString)
    '                llsiItem.SubItems.Add(lNewBrowser.Browser.PosY.ToString)
    '                mLastBrowserID += 1

    '                'also save updated protocols and filetypes
    '                mProtocols = lNewBrowser.Protocols
    '                mFileTypes = lNewBrowser.FileTypes

    '                'now display them
    '                llsiItem.SubItems.Add(GetBrowserProtocolsAndFileTypes(lNewBrowser.Browser))
    '            End If
    '        End If
    '    End Sub
    '#End Region

    '#Region "TabControl Manipulation"
    '    Private mHiddenTabs As New List(Of TabPage)

    '    Private Sub HideAdvancedPages()
    '        mHiddenTabs.Add(tabProtocols)
    '        mHiddenTabs.Add(tabFileTypes)
    '        mHiddenTabs.Add(tabCategories)
    '        tabSettings.TabPages.Remove(tabProtocols)
    '        tabSettings.TabPages.Remove(tabFileTypes)
    '        tabSettings.TabPages.Remove(tabCategories)
    '    End Sub

    '    Private Sub ShowAdvancedPages()
    '        If mHiddenTabs.Count > 0 Then
    '            tabSettings.TabPages.Insert(2, mHiddenTabs(0))
    '            tabSettings.TabPages.Insert(3, mHiddenTabs(1))
    '            tabSettings.TabPages.Insert(4, mHiddenTabs(2))
    '            mHiddenTabs.Clear()
    '        End If
    '    End Sub
    '#End Region

    '#Region "Form Events"
    Public Enum SettingsStartPage
        SettingsBrowsers
        SettingsAutoURLs
        SettingsProtocols
        SettingsFileTypes
        SettingsCategories
        SettingsSettings
        SettingsMoreSettings
        SettingsDefaultBrowser
    End Enum

    '    Public Sub ShowForm(aModal As Boolean)
    '        If aModal = True Then
    '            Me.ShowDialog()
    '        Else
    '            Me.Show()
    '        End If
    '    End Sub

    '    Public Sub ShowForm(aScreen As SettingsStartPage, aModal As Boolean)
    '        tabSettings.SelectTab(aScreen)

    '        If aModal = True Then
    '            Me.ShowDialog()
    '        Else
    '            Me.Show()
    '        End If
    '    End Sub
    '    Private Sub frmOptions_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    '        If e.CloseReason = CloseReason.UserClosing Then
    '            If mbDirty = True Then
    '                Dim lResult As DialogResult = MessageBox.Show("Do you want to save your settings?", "Save?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

    '                If lResult = Windows.Forms.DialogResult.Yes Then
    '                    DoSave()
    '                ElseIf lResult = Windows.Forms.DialogResult.Cancel Then
    '                    e.Cancel = True
    '                End If
    '            End If
    '        End If
    '    End Sub

    '    Private Sub frmOptions_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '        If gSettings Is Nothing Then
    '            modStart.LoadSettings()
    '        End If

    '        'determine if Win8+, if yes, must be user
    '        If GeneralUtilities.IsRunningPost8 = True Then
    '            rbScopeUser.Checked = True
    '            grpScope.Enabled = False

    '            cmdMakeDefault.Text = "Show Defaults Dialog*"
    '            lblWarnWin8.Visible = True
    '            txtWarnWin10.Visible = True
    '            chkCheckDefaultOnLaunch.Enabled = False
    '            chkCheckDefaultOnLaunch.Checked = False
    '        End If

    '        If GeneralUtilities.IsRunningPost10 = True Then
    '            rbScopeUser.Checked = True
    '            grpScope.Enabled = False

    '            cmdMakeDefault.Text = "Make Default*"
    '            lblWarnWin10.Visible = True
    '            txtWarnWin10.Visible = True
    '            chkCheckDefaultOnLaunch.Enabled = False
    '            chkCheckDefaultOnLaunch.Checked = False
    '            cmdMakeDefault.Text = "Show Defaults Dialog*"

    '            'also remove the single file associations - win10 disabled that too
    '            cmdOpenDefaultForFile.Visible = False
    '            cmdOpenDefaultForProtocol.Visible = False
    '        End If

    '        'prepare the starting position combo box
    '        Dim lbAddSeperator As Boolean
    '        cmbStartingPosition.Items.Clear()
    '        For Each lItem As KeyValuePair(Of Settings.AvailableStartingPositions, String) In DisplayDictionary.AvailableStartingPositionsNames
    '            If lItem.Key < 0 Then
    '                'seperator

    '                lbAddSeperator = True ' happens on the next iteration
    '            Else
    '                If lbAddSeperator = True Then
    '                    cmbStartingPosition.AddStringWithSeparator(DisplayDictionary.Item(lItem.Key))
    '                    lbAddSeperator = False
    '                Else
    '                    cmbStartingPosition.AddString(DisplayDictionary.Item(lItem.Key))
    '                End If

    '            End If
    '        Next

    '        'indicate that the screen is NOT dirty and DOES NOT need to be saved
    '        mbDirty = False
    '    End Sub

    '    Private Sub frmOptions_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
    '        'update screen from internet classes 
    '        Dim llsiItem As ListViewItem

    '        'if advanced settings, show protocols and file types column, else remove
    '        If gSettings.AdvancedScreens = False Then
    '            lstBrowsers.Columns(3).Width = 0
    '        End If

    '        'Note; protocols and filetypes must come first as they are referenced in the browser section
    '        'protocols
    '        lstProtocols.Items.Clear()
    '        mProtocols = New Dictionary(Of Integer, Protocol)
    '        For Each lProtocol As Protocol In gSettings.Protocols
    '            mProtocols.Add(mProtocols.Count, DirectCast(lProtocol.Clone, Protocol))

    '            llsiItem = lstProtocols.Items.Add(lProtocol.ProtocolName)
    '            llsiItem.Tag = mProtocols.Count - 1
    '            llsiItem.SubItems.Add(lProtocol.Header)
    '        Next
    '        mLastProtocolID = mProtocols.Count - 1

    '        'file types / extentions
    '        lstFiletypes.Items.Clear()
    '        mFileTypes = New Dictionary(Of Integer, FileType)
    '        For Each lFileType As FileType In gSettings.FileTypes
    '            mFileTypes.Add(mFileTypes.Count, DirectCast(lFileType.Clone, FileType))

    '            llsiItem = lstFiletypes.Items.Add(lFileType.FiletypeName)
    '            llsiItem.Tag = mFileTypes.Count - 1
    '            llsiItem.SubItems.Add(lFileType.Extention)
    '        Next
    '        mLastFileTypeID = mFileTypes.Count - 1

    '        'browsers
    '        lstBrowsers.Items.Clear()
    '        mBrowser = New Dictionary(Of Integer, Browser)
    '        For Each lBrowser As Browser In gSettings.Browsers
    '            Dim lSingleBrowser As Browser = DirectCast(lBrowser.Clone, Browser)
    '            mBrowser.Add(mBrowser.Count, lSingleBrowser)
    '            imBrowserIcons.Images.Add(ImageUtilities.GetImage(lSingleBrowser, False))

    '            llsiItem = lstBrowsers.Items.Add(lBrowser.Name, imBrowserIcons.Images.Count - 1)
    '            llsiItem.Tag = mBrowser.Count - 1
    '            llsiItem.SubItems.Add(lBrowser.PosX.ToString)
    '            llsiItem.SubItems.Add(lBrowser.PosY.ToString)

    '            llsiItem.SubItems.Add(GetBrowserProtocolsAndFileTypes(lBrowser))
    '        Next
    '        mLastBrowserID = mBrowser.Count - 1

    '        'urls
    '        lstURLs.Items.Clear()
    '        mURLs = New SortedDictionary(Of Integer, URL)
    '        For Each lURL As URL In gSettings.URLs
    '            mURLs.Add(mURLs.Count, DirectCast(lURL.Clone, URL))

    '            llsiItem = lstURLs.Items.Add(lURL.URL)
    '            llsiItem.SubItems.Add(BrowserUtilities.GetBrowserByGUID(lURL.Guid).Name)
    '            llsiItem.Tag = mURLs.Count - 1
    '        Next
    '        mLastURLID = mURLs.Count - 1

    '        'options page
    '        'default
    '        chkShowURLs.Checked = gSettings.ShowURL
    '        chkRevealShortURLs.Checked = gSettings.RevealShortURL
    '        chkPortableMode.Checked = gSettings.PortableMode
    '        chkAutoCheckUpdate.Checked = gSettings.AutomaticUpdates
    '        nudHeight.Value = gSettings.Height
    '        nudWidth.Value = gSettings.Width
    '        txtOptionsShortcut.Text = gSettings.OptionsShortcut
    '        txtMessage.Text = gSettings.DefaultMessage
    '        chkCheckDefaultOnLaunch.Checked = gSettings.CheckDefaultOnLaunch
    '        chkAdvanced.Checked = gSettings.AdvancedScreens
    '        nudDelayBeforeAutoload.Value = gSettings.DefaultDelay
    '        txtSeperator.Text = gSettings.Seperator

    '        'more settings
    '        txtUserAgent.Text = gSettings.UserAgent
    '        chkDownloadDetectionfile.Checked = gSettings.DownloadDetectionFile
    '        nudIconSizeHeight.Value = gSettings.IconHeight
    '        nudIconSizeWidth.Value = gSettings.IconWidth
    '        nudIconGapHeight.Value = gSettings.IconGapHeight
    '        nudIconGapWidth.Value = gSettings.IconGapWidth
    '        pbBackgroundColor.BackColor = Color.FromArgb(gSettings.BackgroundColor)
    '        nudIconScale.Value = gSettings.IconScale
    '        cmbStartingPosition.SelectedItem = cmbStartingPosition.Items(gSettings.StartingPosition)
    '        nudXOffset.Value = gSettings.OffsetX
    '        nudYOffset.Value = gSettings.OffsetY

    '        'FocusSettings
    '        mFocusSettings = New frmAccessibilitySettings.FocusSettings
    '        mFocusSettings.ShowFocus = gSettings.ShowFocus
    '        mFocusSettings.BoxColor = Color.FromArgb(gSettings.FocusBoxColor)
    '        mFocusSettings.BoxWidth = gSettings.FocusBoxLineWidth

    '        chkUseAccessibleRendering.Checked = gSettings.AccessibleRendering
    '        chkUseAreo.Checked = gSettings.UseAreo


    '        'check if advanced settings are on
    '        If chkAdvanced.Checked = False Then
    '            HideAdvancedPages()
    '        End If

    '        'indicate that the screen is NOT dirty and DOES NOT need to be saved
    '        mbDirty = False
    '    End Sub
    '#End Region

    '#Region "URL CRUD"
    '    Private Sub cmdAutoURLAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAutoURLAdd.Click
    '        'show up a dialog to set the browser settings
    '        Dim lfrmAdd As New frmAddEditURL

    '        If lfrmAdd.AddURL(mBrowser) = True Then
    '            Dim lNewURL As URL = lfrmAdd.GetData
    '            mURLs.Add(mLastURLID + 1, lNewURL)
    '            Dim llsiItem As ListViewItem = lstURLs.Items.Add(lNewURL.URL)
    '            llsiItem.SubItems.Add(BrowserUtilities.GetBrowserByGUID(lNewURL.Guid, mBrowser).Name)
    '            llsiItem.Tag = mLastURLID + 1
    '            mLastURLID += 1

    '            'indicate that the screen is dirty and needs to be saved
    '            mbDirty = True
    '        End If
    '    End Sub

    '    Private Sub cmdAutoURLEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAutoURLEdit.Click, lstURLs.DoubleClick
    '        If lstURLs.SelectedItems.Count > 0 Then
    '            'show up a dialog to set the url settings
    '            Dim lfrmAdd As New frmAddEditURL

    '            If lfrmAdd.EditURL(mURLs(CInt(lstURLs.SelectedItems(0).Tag)), mBrowser) = True Then
    '                Dim lNewURL As URL = lfrmAdd.GetData
    '                mURLs(CInt(lstURLs.SelectedItems(0).Tag)) = lNewURL
    '                lstURLs.SelectedItems(0).Text = lNewURL.URL
    '                lstURLs.SelectedItems(0).SubItems(1).Text = BrowserUtilities.GetBrowserByGUID(lNewURL.Guid, mBrowser).Name

    '                'indicate that the screen is dirty and needs to be saved
    '                mbDirty = True
    '            End If
    '        End If
    '    End Sub

    '    Private Sub cmdAutoURLDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAutoURLDelete.Click
    '        If lstURLs.SelectedItems.Count > 0 Then
    '            If MessageBox.Show("Are you sure you want delete the " + lstURLs.SelectedItems(0).Text + " entry?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '                mURLs.Remove(CInt(lstURLs.SelectedItems(0).Tag))
    '                lstURLs.Items.Remove(lstURLs.SelectedItems(0))

    '                'indicate that the screen is dirty and needs to be saved
    '                mbDirty = True
    '            End If
    '        End If
    '    End Sub
    '#End Region

    '#Region "Protocol CRUD"
    '    Private Sub cmdProtocolAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddProtocol.Click
    '        'show up a dialog to set the browser settings
    '        Dim lfrmAdd As New frmAddEditProtocols

    '        If lfrmAdd.AddProtocol(mBrowser) = True Then
    '            Dim lProtocol As Protocol = lfrmAdd.GetData
    '            mProtocols.Add(mLastProtocolID + 1, lProtocol)
    '            Dim llsiItem As ListViewItem = lstProtocols.Items.Add(lProtocol.ProtocolName)
    '            llsiItem.SubItems.Add(lProtocol.Header)
    '            llsiItem.Tag = mLastProtocolID + 1
    '            mLastProtocolID += 1

    '            mProtocolsAreDirty = True

    '            'indicate that the screen is dirty and needs to be saved
    '            mbDirty = True
    '        End If
    '    End Sub

    '    Private Sub cmdProtocolEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEditProtocol.Click, lstProtocols.DoubleClick
    '        If lstProtocols.SelectedItems.Count > 0 Then
    '            'show up a dialog to set the url settings
    '            Dim lfrmAdd As New frmAddEditProtocols

    '            If lfrmAdd.EditProtocol(mProtocols(CInt(lstProtocols.SelectedItems(0).Tag)), mBrowser) = True Then
    '                Dim lProtocol As Protocol = lfrmAdd.GetData
    '                mProtocols(CInt(lstProtocols.SelectedItems(0).Tag)) = lProtocol
    '                lstProtocols.SelectedItems(0).Text = lProtocol.ProtocolName
    '                lstProtocols.SelectedItems(0).SubItems(1).Text = lProtocol.Header

    '                mProtocolsAreDirty = True

    '                'indicate that the screen is dirty and needs to be saved
    '                mbDirty = True
    '            End If
    '        End If
    '    End Sub

    '    Private Sub cmdProtocolDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteProtocol.Click
    '        If lstProtocols.SelectedItems.Count > 0 Then
    '            If MessageBox.Show("Are you sure you want delete the " + lstProtocols.SelectedItems(0).Text + " entry?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '                mProtocols.Remove(CInt(lstProtocols.SelectedItems(0).Tag))
    '                lstProtocols.Items.Remove(lstProtocols.SelectedItems(0))

    '                mProtocolsAreDirty = True

    '                'indicate that the screen is dirty and needs to be saved
    '                mbDirty = True
    '            End If
    '        End If
    '    End Sub
    '#End Region

    '#Region "Filetypes CRUD"
    '    Private Sub cmdFileTypelAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddFileType.Click
    '        'show up a dialog to set the browser settings
    '        Dim lfrmAdd As New frmAddEditType

    '        If lfrmAdd.AddType(mBrowser) = True Then
    '            Dim lFileType As FileType = lfrmAdd.GetData
    '            mFileTypes.Add(mLastFileTypeID + 1, lFileType)
    '            Dim llsiItem As ListViewItem = lstFiletypes.Items.Add(lFileType.FiletypeName)
    '            llsiItem.SubItems.Add(lFileType.Extention)
    '            llsiItem.Tag = mLastFileTypeID + 1
    '            mLastFileTypeID += 1

    '            mFileTypesAreDirty = True

    '            'indicate that the screen is dirty and needs to be saved
    '            mbDirty = True
    '        End If
    '    End Sub

    '    Private Sub cmdFileTypeEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEditFileType.Click, lstFiletypes.DoubleClick
    '        If lstFiletypes.SelectedItems.Count > 0 Then
    '            'show up a dialog to set the url settings
    '            Dim lfrmAdd As New frmAddEditType

    '            If lfrmAdd.EditType(mFileTypes(CInt(lstFiletypes.SelectedItems(0).Tag)), mBrowser) = True Then
    '                Dim lFileType As FileType = lfrmAdd.GetData
    '                mFileTypes(CInt(lstFiletypes.SelectedItems(0).Tag)) = lFileType
    '                lstFiletypes.SelectedItems(0).Text = lFileType.FiletypeName
    '                lstFiletypes.SelectedItems(0).SubItems(1).Text = lFileType.Extention

    '                mFileTypesAreDirty = True

    '                'indicate that the screen is dirty and needs to be saved
    '                mbDirty = True
    '            End If
    '        End If
    '    End Sub

    '    Private Sub cmdFileTypeDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteFileType.Click
    '        If lstFiletypes.SelectedItems.Count > 0 Then
    '            If MessageBox.Show("Are you sure you want delete the " + lstFiletypes.SelectedItems(0).Text + " entry?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '                mFileTypes.Remove(CInt(lstFiletypes.SelectedItems(0).Tag))
    '                lstFiletypes.Items.Remove(lstFiletypes.SelectedItems(0))

    '                mFileTypesAreDirty = True

    '                'indicate that the screen is dirty and needs to be saved
    '                mbDirty = True
    '            End If
    '        End If
    '    End Sub
    '#End Region

    '    Private Sub cmdImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImport.Click
    '        If MessageBox.Show("Importing your setting from Browser Chooser 1 will override your settings here. Are you sure you want to import?",
    '                           "Comfirm Import", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

    '            Me.TopMost = False
    '            Dim lSource As String = frmImportSource.GetSource()

    '            If lSource <> "" Then
    '                Dim lImporter As New Importer(lSource)

    '                MessageBox.Show("Settings imported. Will now restart", "Restarting", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                Application.Restart()
    '            End If
    '        End If
    '    End Sub

    '    Private Sub cmdCheckForUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCheckForUpdate.Click
    '        Updater.CheckForUpdate(False) ' handles the full process
    '    End Sub

    '    Private Sub AddToDefault()
    '        If rbScopeUser.Checked = True Then
    '            DefaultBrowser.MakeAvailable(DefaultBrowser.Scope.sUser)
    '        Else
    '            GeneralUtilities.LaunchAdminMode(GeneralUtilities.ListOfCommands.MakeAvailable)
    '        End If
    '    End Sub

    '    Private Sub MakeDefault()
    '        If rbScopeUser.Checked = True Then
    '            DefaultBrowser.MakeDefault(DefaultBrowser.Scope.sUser)
    '        Else
    '            GeneralUtilities.LaunchAdminMode(GeneralUtilities.ListOfCommands.MakeDefault)
    '        End If
    '    End Sub

    '    Private Sub MakeDefaultSingle(aItem As String, abIsProtocol As Boolean)
    '        If rbScopeUser.Checked = True Then
    '            DefaultBrowser.MakeDefault(DefaultBrowser.Scope.sUser, aDoSingle:=aItem, abIsProtocol:=abIsProtocol)
    '        Else
    '            Debug.Print("FIXME: Admin does not yet support default single")
    '            GeneralUtilities.LaunchAdminMode(GeneralUtilities.ListOfCommands.MakeDefault) 'admin does not yet support this branch
    '        End If
    '    End Sub

    '    Private Sub cmdAddToDefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddToDefault.Click
    '        AddToDefault()
    '    End Sub

    '    Private Sub cmdMakeDefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMakeDefault.Click
    '        MakeDefault()
    '    End Sub

    '    Private Sub rbScope_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbScopeUser.CheckedChanged, rbScopeSystem.CheckedChanged
    '        If rbScopeUser.Checked = True Then
    '            'remove the sheild on the buttons!
    '            cmdAddToDefault.FlatStyle = FlatStyle.System
    '            cmdMakeDefault.FlatStyle = FlatStyle.System
    '            WinAPIs.SendMessage(cmdAddToDefault.Handle, WinAPIs.BCM_SETSHIELD, 0, New IntPtr(0))
    '            WinAPIs.SendMessage(cmdMakeDefault.Handle, WinAPIs.BCM_SETSHIELD, 0, New IntPtr(0))
    '        Else
    '            'put the sheild on the buttons!
    '            cmdAddToDefault.FlatStyle = FlatStyle.System
    '            cmdMakeDefault.FlatStyle = FlatStyle.System
    '            WinAPIs.SendMessage(cmdAddToDefault.Handle, WinAPIs.BCM_SETSHIELD, 0, New IntPtr(1))
    '            WinAPIs.SendMessage(cmdMakeDefault.Handle, WinAPIs.BCM_SETSHIELD, 0, New IntPtr(1))
    '        End If
    '    End Sub

    '    Private Sub chkAdvanced_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAdvanced.CheckedChanged
    '        If chkAdvanced.Checked = False Then
    '            HideAdvancedPages()
    '        Else
    '            ShowAdvancedPages()
    '        End If
    '    End Sub

    '    Private Sub tabCategories_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabCategories.Enter
    '        'update list of categories
    '        lstCategories.Items.Clear()

    '        Dim lCategories As New List(Of String)
    '        For Each lBrowser As KeyValuePair(Of Integer, Browser) In mBrowser
    '            If lCategories.Contains(lBrowser.Value.Category) = False Then
    '                lCategories.Add(lBrowser.Value.Category)
    '                lstCategories.Items.Add(lBrowser.Value.Category)
    '            End If
    '        Next
    '    End Sub

    '    Private Sub cmdDetectBrowsers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDetectBrowsers.Click
    '        'retrigger the detection of browsers, while not removing / re-adding existing ones
    '        Dim lResult As List(Of Browser) = DetectedBrowsers.DoBrowserDetection()
    '        Dim lMissing As New List(Of Browser)
    '        Dim lbFound As Boolean

    '        'check our list to see if any missing
    '        For Each lDetectedBrowser In lResult

    '            For Each lBrowser As KeyValuePair(Of Integer, Browser) In mBrowser
    '                lbFound = False
    '                If lBrowser.Value.Target = lDetectedBrowser.Target Then
    '                    lbFound = True

    '                    Exit For
    '                End If
    '            Next

    '            If lbFound = False Then
    '                Debug.Print(lDetectedBrowser.Name)
    '                lMissing.Add(lDetectedBrowser)
    '            End If
    '        Next

    '        'now add missing to the list - this is a lengty (code wise) process
    '        'first build a list of used spots
    '        Dim lIndexes As New SortedList 'start with an index of positions used
    '        For Each lBrowser As KeyValuePair(Of Integer, Browser) In mBrowser
    '            lIndexes.Add(lBrowser.Value.PosX.ToString & lBrowser.Value.PosY.ToString, Nothing)
    '        Next

    '        'go throught each browser and find them a spot and assign default settings
    '        For Each lBrowser As Browser In lMissing
    '            'find it a spot
    '            lbFound = False
    '            For lY As Integer = 1 To CInt(nudHeight.Value)
    '                For lX As Integer = 1 To CInt(nudWidth.Value)
    '                    If lIndexes.ContainsKey(lX.ToString & lY.ToString) = False Then
    '                        'found it
    '                        lBrowser.PosX = lX
    '                        lBrowser.PosY = lY
    '                        lbFound = True
    '                        Exit For : Exit For
    '                    End If
    '                Next

    '                If lbFound = True Then Exit For
    '            Next


    '            If lbFound = False Then
    '                'we need to add a row
    '                nudHeight.Value = nudHeight.Value + 1
    '                lBrowser.PosX = 1
    '                lBrowser.PosY = CInt(nudHeight.Value)
    '            End If

    '            'add to index
    '            lIndexes.Add(lBrowser.PosX.ToString & lBrowser.PosY.ToString, Nothing)

    '            'finish with extra details
    '            lBrowser.GUID = System.Guid.NewGuid

    '            'add the new GUID to the list above
    '            For Each lProtocol As KeyValuePair(Of Integer, Protocol) In mProtocols
    '                If lProtocol.Value.DefaultCategories.Contains(GeneralUtilities.DEFAULT_CATEGORY) = True Then
    '                    lProtocol.Value.SupportingBrowsers.Add(lBrowser.GUID)
    '                End If
    '            Next

    '            For Each lFileTypes As KeyValuePair(Of Integer, FileType) In mFileTypes
    '                If lFileTypes.Value.DefaultCategories.Contains(GeneralUtilities.DEFAULT_CATEGORY) = True Then
    '                    lFileTypes.Value.SupportingBrowsers.Add(lBrowser.GUID)
    '                End If
    '            Next

    '            'finaly, add it to the browser list
    '            mBrowser.Add(mLastBrowserID + 1, lBrowser)
    '            imBrowserIcons.Images.Add(ImageUtilities.GetImage(lBrowser, False))

    '            Dim llsiItem As ListViewItem = lstBrowsers.Items.Add(lBrowser.Name, imBrowserIcons.Images.Count - 1)
    '            llsiItem.Tag = mLastBrowserID + 1
    '            llsiItem.SubItems.Add(lBrowser.PosX.ToString)
    '            llsiItem.SubItems.Add(lBrowser.PosY.ToString)
    '            mLastBrowserID += 1

    '            'now display them
    '            llsiItem.SubItems.Add(GetBrowserProtocolsAndFileTypes(lBrowser))
    '        Next

    '        'indicate that the screen is dirty and needs to be saved
    '        mbDirty = True
    '    End Sub

    '    Private Sub SwapURLS(ByVal aFirst As Integer, ByVal aSecond As Integer)
    '        Dim lUrl As URL = mURLs(aFirst)
    '        Dim lOtherURl As URL = mURLs(aSecond)
    '        mURLs.Remove(aFirst)
    '        mURLs.Remove(aSecond)
    '        mURLs.Add(aSecond, lUrl)
    '        mURLs.Add(aFirst, lOtherURl)
    '    End Sub

    '    Private Sub cmdMoveUpAutoURL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMoveUpAutoURL.Click
    '        If lstURLs.SelectedItems.Count > 0 Then
    '            'move the selected item up one 
    '            If lstURLs.SelectedItems(0).Index > 0 Then
    '                'can't go any higher
    '                Dim lItem As ListViewItem = lstURLs.SelectedItems(0)
    '                Dim lIndex = lItem.Index
    '                Dim lTag As Integer = CInt(lItem.Tag)
    '                Dim lOtherTag As Integer = CInt(lstURLs.Items(lIndex - 1).Tag)
    '                lstURLs.Items(lIndex).Remove()
    '                lstURLs.Items.Insert(lIndex - 1, lItem)

    '                'repeat for the internal list of urls
    '                SwapURLS(lTag, lOtherTag)

    '                'indicate that the screen is dirty and needs to be saved
    '                mbDirty = True
    '            End If
    '        End If
    '    End Sub

    '    Private Sub cmdMoveDownAutoURL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdMoveDownAutoURL.Click
    '        If lstURLs.SelectedItems.Count > 0 Then
    '            'move the selected item up one 
    '            If lstURLs.SelectedItems(0).Index < lstURLs.Items.Count - 1 Then
    '                'can't go any lower
    '                Dim lItem As ListViewItem = lstURLs.SelectedItems(0)
    '                Dim lIndex = lItem.Index
    '                Dim lTag As Integer = CInt(lItem.Tag)
    '                Dim lOtherTag As Integer = CInt(lstURLs.Items(lIndex + 1).Tag)
    '                lstURLs.Items(lIndex).Remove()
    '                lstURLs.Items.Insert(lIndex + 1, lItem)

    '                'repeat for the internal list of urls
    '                SwapURLS(lTag, lOtherTag)

    '                'indicate that the screen is dirty and needs to be saved
    '                mbDirty = True
    '            End If
    '        End If
    '    End Sub

    '    Private Sub cmdAccessiblitySettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAccessiblitySettings.Click
    '        If frmAccessibilitySettings.ShowSettings(mFocusSettings) = True Then
    '            mFocusSettings = frmAccessibilitySettings.GetSettings

    '            'indicate that the screen is dirty and needs to be saved
    '            mbDirty = True
    '        End If
    '    End Sub

    '    Public Sub DetectDirty(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
    '        chkShowURLs.CheckedChanged, chkAutoCheckUpdate.CheckedChanged, chkPortableMode.CheckedChanged, chkRevealShortURLs.CheckedChanged, chkAdvanced.CheckedChanged, _
    '        nudDelayBeforeAutoload.ValueChanged, nudWidth.ValueChanged, nudHeight.ValueChanged, _
    '        txtOptionsShortcut.TextChanged, txtMessage.TextChanged, txtSeperator.TextChanged, _
    '        txtUserAgent.TextChanged, chkDownloadDetectionfile.CheckedChanged, _
    '        nudIconSizeHeight.ValueChanged, nudIconSizeWidth.ValueChanged, nudIconScale.ValueChanged, _
    '        nudIconGapHeight.ValueChanged, nudIconGapWidth.ValueChanged, _
    '        cmbStartingPosition.SelectedIndexChanged, nudXOffset.ValueChanged, nudYOffset.ValueChanged

    '        'indicate that the screen is dirty and needs to be saved
    '        mbDirty = True
    '    End Sub

    '    Private Sub cmdOpenDefaultForFile_Click(sender As System.Object, e As System.EventArgs) Handles cmdOpenDefaultForFile.Click
    '        If lstFiletypes.SelectedItems.Count > 0 Then
    '            MakeDefaultSingle(String.Format(".{0}", lstFiletypes.SelectedItems(0).Text), False)
    '        End If
    '    End Sub

    '#Region "Auto-URL Drag and Drop"
    '    Private mbURLMouseDown As Boolean = False
    '    Private mDragHighlight As ListViewItem
    '    Private mStartPoint As Point

    '    Private Sub RebuildAutoURLs()
    '        'could be lenghty if long list
    '        Dim lOut As New SortedDictionary(Of Integer, URL)

    '        For Each lItem As ListViewItem In lstURLs.Items
    '            Dim lOldItem As URL = mURLs(DirectCast(lItem.Tag, Integer))
    '            lOut.Add(lItem.Index, lOldItem)
    '        Next

    '        mURLs = lOut
    '        mbDirty = True
    '    End Sub

    '    Private Sub lstURLs_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles lstURLs.DragDrop
    '        Dim myItem As ListViewItem = DirectCast(e.Data.GetData("System.Windows.Forms.ListViewItem"), ListViewItem)
    '        Dim lIndex As Integer = myItem.Index

    '        'get target position - x and y are relative to screen
    '        Dim a As Point = lstURLs.PointToClient(New Point(e.X, e.Y))
    '        Dim lResult As ListViewHitTestInfo = lstURLs.HitTest(a.X, a.Y)

    '        'if lresult is nothing, check if we moved to top or bototm
    '        If IsNothing(lResult.Item) = True Then
    '            If a.X < 0 Then
    '                'remove the item
    '                lstURLs.Items.Remove(myItem)

    '                'move to top
    '                lstURLs.Items.Insert(0, myItem)
    '            Else
    '                'remove the item
    '                lstURLs.Items.Remove(myItem)

    '                'move to bottom
    '                lstURLs.Items.Insert(lstURLs.Items.Count, myItem)
    '            End If
    '        Else

    '            'check to make sure wer not jus tmoving item on itself
    '            If lResult.Item.Text <> myItem.Text Then
    '                Dim lOldIndex As Integer = lResult.Item.Index
    '                'remove the item
    '                lstURLs.Items.Remove(myItem)

    '                'add item at this location
    '                lstURLs.Items.Insert(lResult.Item.Index, myItem)
    '            End If
    '        End If

    '        'rebuild internal list of urls
    '        RebuildAutoURLs()

    '        'remove highlight
    '        If IsNothing(mDragHighlight) = False Then
    '            mDragHighlight.BackColor = System.Drawing.SystemColors.Window
    '        End If

    '        mDragHighlight = lResult.Item
    '    End Sub

    '    Private Sub lstURLs_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles lstURLs.DragEnter
    '        If e.Data.GetDataPresent("System.Windows.Forms.ListViewItem") Then
    '            e.Effect = DragDropEffects.Move
    '        Else
    '            e.Effect = DragDropEffects.None
    '        End If

    '        mDragHighlight = Nothing
    '    End Sub

    '    Private Sub lstURLs_DragOver(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles lstURLs.DragOver
    '        'get target position - x and y are relative to screen
    '        Dim a As Point = lstURLs.PointToClient(New Point(e.X, e.Y))
    '        Dim lResult As ListViewHitTestInfo = lstURLs.HitTest(a.X, a.Y)

    '        'add a border
    '        If IsNothing(lResult.Item) = False Then
    '            If IsNothing(mDragHighlight) = True Then

    '                lResult.Item.BackColor = System.Drawing.SystemColors.Highlight
    '                mDragHighlight = lResult.Item
    '            Else
    '                If mDragHighlight.Text <> lResult.Item.Text Then
    '                    mDragHighlight.BackColor = System.Drawing.SystemColors.Window
    '                End If
    '                lResult.Item.BackColor = System.Drawing.SystemColors.Highlight
    '            End If
    '        Else
    '            If IsNothing(mDragHighlight) = False Then
    '                mDragHighlight.BackColor = System.Drawing.SystemColors.Window
    '            End If
    '        End If
    '        mDragHighlight = lResult.Item
    '    End Sub

    '    'to change in b3 perhaps
    '    'Private Sub lstURLs_DrawItem(sender As Object, e As System.Windows.Forms.DrawListViewItemEventArgs) Handles lstURLs.DrawItem
    '    '    If IsNothing(mDragHighlight) = False Then
    '    '        If e.Item.Text = mDragHighlight.Text Then
    '    '            'add a top border
    '    '            e.DrawBackground()
    '    '        End If
    '    '    End If
    '    'End Sub

    '    Private Sub lstURLs_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lstURLs.MouseDown
    '        If lstURLs.SelectedItems.Count > 0 Then
    '            mbURLMouseDown = True
    '            mStartPoint = e.Location
    '        End If

    '        Dim lResult As ListViewHitTestInfo = lstURLs.HitTest(e.X, e.Y)
    '        Debug.Print(String.Format("lResult success = {0}, x = {1}, y = {2}", Not IsNothing(lResult.Item), e.X, e.Y))
    '    End Sub

    '    Private Sub lstURLs_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lstURLs.MouseMove
    '        If mbURLMouseDown = True Then 'need to add a minimum move, othersize doubleclick doesn't work
    '            Debug.Print(String.Format("start: {0}, current: {1}", mStartPoint.X, e.Location.X))
    '            If mStartPoint.X <> e.Location.X And mStartPoint.Y <> e.Location.Y Then
    '                lstURLs.DoDragDrop(New DataObject("System.Windows.Forms.ListViewItem", lstURLs.SelectedItems(0)), DragDropEffects.Move)
    '            End If
    '        End If
    '    End Sub

    '    Private Sub lstURLs_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lstURLs.MouseUp
    '        mbURLMouseDown = False
    '    End Sub
    '#End Region

    '    Private Sub cmdChangeBackgroundColor_Click(sender As System.Object, e As System.EventArgs) Handles cmdChangeBackgroundColor.Click
    '        cdColorDialog.Color = pbBackgroundColor.BackColor
    '        cdColorDialog.ShowDialog()
    '        pbBackgroundColor.BackColor = cdColorDialog.Color

    '        'indicate that the screen is dirty and needs to be saved
    '        mbDirty = True
    '    End Sub

    '    Private Sub cmdTransparentBackground_Click(sender As System.Object, e As System.EventArgs) Handles cmdTransparentBackground.Click
    '        pbBackgroundColor.BackColor = Color.Transparent

    '        'indicate that the screen is dirty and needs to be saved
    '        mbDirty = True
    '    End Sub

    '    Private Function GetBrowserProtocolsAndFileTypes(aBrowser As Browser) As String
    '        'add the protocols and filetypes
    '        Dim lItems As String = ""
    '        For Each lKVP As KeyValuePair(Of Integer, Protocol) In mProtocols
    '            If lKVP.Value.SupportingBrowsers.Contains(aBrowser.GUID) Then
    '                lItems = String.Format("{0}{1}{2}", IIf(lItems = "", "", lItems), IIf(lItems = "", "", " ,"), lKVP.Value.ProtocolName)

    '            End If
    '        Next

    '        'repeat for file types
    '        For Each lKVP As KeyValuePair(Of Integer, FileType) In mFileTypes
    '            If lKVP.Value.SupportingBrowsers.Contains(aBrowser.GUID) Then
    '                lItems = String.Format("{0}{1}{2}", IIf(lItems = "", "", lItems), IIf(lItems = "", "", " ,"), lKVP.Value.FiletypeName)
    '            End If
    '        Next

    '        Return lItems
    '    End Function

    '	Private Sub lstBrowsers_DragEnter(sender As Object, e As DragEventArgs) Handles lstBrowsers.DragEnter

    '		' See if the data is a File(s).
    '		If e.Data.GetDataPresent(DataFormats.FileDrop) Then
    '			' Yup! Allow copy.
    '			e.Effect = DragDropEffects.Copy
    '			lstBrowsers.BackColor = Color.FromKnownColor(KnownColor.Highlight)
    '		Else
    '			' Nope, Sorry Charlie!
    '			e.Effect = DragDropEffects.None
    '		End If

    '	End Sub

    '	Private Sub lstBrowsers_DragLeave(sender As Object, e As EventArgs) Handles lstBrowsers.DragLeave

    '		' Set back color back to normal
    '		lstBrowsers.BackColor = Color.FromKnownColor(KnownColor.Window)

    '	End Sub

    '	Private Sub lstBrowsers_DragDrop(sender As Object, e As DragEventArgs) Handles lstBrowsers.DragDrop

    '		Dim strFiles() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())

    '		For Each strPath In strFiles

    '			' Confirm it's a .exe
    '			If Path.GetExtension(strPath.ToLower) = ".exe" then

    '				Debug.Print(strPath)

    '			End If

    '		Next

    '		' Set back color back to normal
    '		lstBrowsers.BackColor = Color.FromKnownColor(KnownColor.Window)

    '    End Sub
End Class