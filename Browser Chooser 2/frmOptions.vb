Public Class frmOptions
    Private mBrowser As Dictionary(Of Integer, Browser) 'copies
    Private mURLs As SortedDictionary(Of Integer, URL) 'copies
    Private mProtocols As Dictionary(Of Integer, Protocol) 'copies
    Private mProtocolsAreDirty As Boolean = False
    Private mFileTypes As Dictionary(Of Integer, FileType) 'copies
    Private mFileTypesAreDirty As Boolean = False
    Private mLastBrowserID As Integer
    Private mLastURLID As Integer
    Private mLastProtocolID As Integer
    Private mLastFileTypeID As Integer
    Private mA11YSettings As frmAccessibilitySettings.A11YSettings
    Private mbDirty As Boolean = False

#Region "Bottom Control Buttons"
    Private Sub cmdHelp_Click(sender As System.Object, e As System.EventArgs) Handles cmdHelp.Click
        Try
            Process.Start("https://bitbucket.org/gmyx/browserchooser2/wiki/Home")
        Catch ex As Exception
            MsgBox("Help page cannot be reached!" & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub DoSave()
        'update internet classes and then file

        'browsers page
        gSettings.Browsers = New List(Of Browser)
        For Each lBrowser As KeyValuePair(Of Integer, Browser) In mBrowser
            gSettings.Browsers.Add(DirectCast(lBrowser.Value.Clone, Browser))
        Next

        'urls page
        gSettings.URLs = New List(Of URL)
        For Each lURL As KeyValuePair(Of Integer, URL) In mURLs
            gSettings.URLs.Add(DirectCast(lURL.Value.Clone, URL))
        Next

        'protocols page
        gSettings.Protocols = New List(Of Protocol)
        For Each lProtocol As KeyValuePair(Of Integer, Protocol) In mProtocols
            gSettings.Protocols.Add(DirectCast(lProtocol.Value.Clone, Protocol))
        Next

        'filetypes page
        gSettings.FileTypes = New List(Of FileType)
        For Each lFileType As KeyValuePair(Of Integer, FileType) In mFileTypes
            gSettings.FileTypes.Add(DirectCast(lFileType.Value.Clone, FileType))
        Next

        'if file types or protocols have changed, ask to renew defualt settings
        If mFileTypesAreDirty = True Or mProtocolsAreDirty = True Then
            If MessageBox.Show("You have changed the accepted Protocols or Filetypes. Do you want to become default for these as well?", "Become default", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                AddToDefault()
                MakeDefault()
            End If
        End If

        'options page
        'default
        gSettings.ShowURL = chkShowURLs.Checked
        gSettings.RevealShortURL = chkRevealShortURLs.Checked
        gSettings.PortableMode = chkPortableMode.Checked
        gSettings.AutomaticUpdates = chkAutoCheckUpdate.Checked
        gSettings.Height = CInt(nudHeight.Value)
        gSettings.Width = CInt(nudWidth.Value)
        gSettings.CheckDefaultOnLaunch = chkCheckDefaultOnLaunch.Checked
        gSettings.AdvancedScreens = chkAdvanced.Checked
        gSettings.DefaultDelay = CInt(nudDelayBeforeAutoload.Value)
        gSettings.Seperator = txtSeperator.Text

        'a11y settings
        gSettings.AccessibleRendering = mA11YSettings.AccessibleRendering
        gSettings.ShowFocus = mA11YSettings.ShowFocus
        gSettings.UseAreo = mA11YSettings.UseAreo

        If txtOptionsShortcut.Text <> "" Then
            gSettings.OptionsShortcut = txtOptionsShortcut.Text.Chars(0) 'no matter what, i take the first and only char
        Else
            gSettings.OptionsShortcut = Char.MinValue 'null
        End If
        gSettings.DefaultMessage = txtMessage.Text

        'Save
        gSettings.DoSave(True)
        'If gSettings.PortableMode = True Then
        '    gSettings.Save(Application.StartupPath)
        'Else
        '    gSettings.Save(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\BrowserChooser2\")
        'End If

        Application.Restart()
    End Sub

    Private Sub cmdSave_Click(sender As System.Object, e As System.EventArgs) Handles cmdSave.Click
        DoSave()
    End Sub
#End Region

#Region "Browser CRUD"
    Private Sub cmdBrowserAdd_Click(sender As System.Object, e As System.EventArgs) Handles cmdBrowserAdd.Click
        'show up a dialog to set the browser settings
        Dim lfrmAdd As New frmAddEditBrowser

        If lfrmAdd.AddBrowser(mBrowser, mProtocols, mFileTypes, chkAdvanced.Checked, New Point(CInt(nudWidth.Value), CInt(nudHeight.Value))) = True Then
            Dim lNewBrowser As frmAddEditBrowser.BrowserReturnValue = lfrmAdd.GetData
            mBrowser.Add(mLastBrowserID + 1, lNewBrowser.Browser)
            Dim llsiItem As ListViewItem = lstBrowsers.Items.Add(lNewBrowser.Browser.Name)
            llsiItem.Tag = mLastBrowserID + 1
            mLastBrowserID += 1

            'also save updated protocols and filetypes
            mProtocols = lNewBrowser.Protocols
            mFileTypes = lNewBrowser.FileTypes

            'indicate that the screen is dirty and needs to be saved
            mbDirty = True
        End If
    End Sub

    Private Sub cmdBrowserDelete_Click(sender As System.Object, e As System.EventArgs) Handles cmdBrowserDelete.Click
        If lstBrowsers.SelectedItems.Count > 0 Then
            If MessageBox.Show("Are you sure you want delete the " + lstBrowsers.SelectedItems(0).Text + " entry?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                mBrowser.Remove(CInt(lstBrowsers.SelectedItems(0).Tag))
                lstBrowsers.Items.Remove(lstBrowsers.SelectedItems(0))

                'indicate that the screen is dirty and needs to be saved
                mbDirty = True
            End If
        End If
    End Sub

    Private Sub cmdBrowserEdit_Click(sender As System.Object, e As System.EventArgs) Handles cmdBrowserEdit.Click
        If lstBrowsers.SelectedItems.Count > 0 Then
            'show up a dialog to set the browser settings
            Dim lfrmAdd As New frmAddEditBrowser

            If lfrmAdd.EditBrowser(mBrowser(CInt(lstBrowsers.SelectedItems(0).Tag)), mBrowser, mProtocols, mFileTypes, chkAdvanced.Checked) = True Then
                Dim lNewBrowser As frmAddEditBrowser.BrowserReturnValue = lfrmAdd.GetData
                mBrowser(CInt(lstBrowsers.SelectedItems(0).Tag)) = lNewBrowser.Browser

                lstBrowsers.SelectedItems(0).Text = lNewBrowser.Browser.Name

                'also save updated protocols and filetypes
                mProtocols = lNewBrowser.Protocols
                mFileTypes = lNewBrowser.FileTypes

                'indicate that the screen is dirty and needs to be saved
                mbDirty = True
            End If
        End If
    End Sub

    Private Sub cmdBrowserClone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowserClone.Click
        If lstBrowsers.SelectedItems.Count > 0 Then
            'show up a dialog to set the browser settings
            Dim lfrmAdd As New frmAddEditBrowser

            If lfrmAdd.AddBrowser(mBrowser, mProtocols, mFileTypes, chkAdvanced.Checked, New Point(CInt(nudWidth.Value), CInt(nudHeight.Value)), mBrowser(CInt(lstBrowsers.SelectedItems(0).Tag))) = True Then
                Dim lNewBrowser As frmAddEditBrowser.BrowserReturnValue = lfrmAdd.GetData
                mBrowser.Add(mLastBrowserID + 1, lNewBrowser.Browser)
                Dim llsiItem As ListViewItem = lstBrowsers.Items.Add(lNewBrowser.Browser.Name)
                llsiItem.Tag = mLastBrowserID + 1
                mLastBrowserID += 1

                'also save updated protocols and filetypes
                mProtocols = lNewBrowser.Protocols
                mFileTypes = lNewBrowser.FileTypes
            End If
        End If
    End Sub
#End Region

#Region "TabControl Manipulation"
    Private mHiddenTabs As New List(Of TabPage)

    Private Sub HideAdvancedPages()
        mHiddenTabs.Add(tabProtocols)
        mHiddenTabs.Add(tabFileTypes)
        mHiddenTabs.Add(tabCategories)
        tabSettings.TabPages.Remove(tabProtocols)
        tabSettings.TabPages.Remove(tabFileTypes)
        tabSettings.TabPages.Remove(tabCategories)
    End Sub

    Private Sub ShowAdvancedPages()
        If mHiddenTabs.Count > 0 Then
            tabSettings.TabPages.Insert(2, mHiddenTabs(0))
            tabSettings.TabPages.Insert(3, mHiddenTabs(1))
            tabSettings.TabPages.Insert(4, mHiddenTabs(2))
            mHiddenTabs.Clear()
        End If
    End Sub
#End Region

#Region "Form Events"

    Private Sub frmOptions_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            If mbDirty = True Then
                Dim lResult As DialogResult = MessageBox.Show("Do you want to save your settings?", "Save?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

                If lResult = Windows.Forms.DialogResult.Yes Then
                    DoSave()
                ElseIf lResult = Windows.Forms.DialogResult.Cancel Then
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub frmOptions_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If gSettings Is Nothing Then
            modStart.LoadSettings()
        End If

        'determine if Win8+, if yes, must be user
        If Utility.IsRunningPost8 = True Then
            rbScopeUser.Checked = True
            grpScope.Enabled = False

            cmdMakeDefault.Text = "Make Default*"
            lblWarnWin8.Visible = True
            txtWarnWin8.Visible = True
            chkCheckDefaultOnLaunch.Enabled = False
            chkCheckDefaultOnLaunch.Checked = False
        End If

        If Utility.IsRunningPost10 = True Then
            rbScopeUser.Checked = True
            grpScope.Enabled = False

            cmdMakeDefault.Text = "Make Default*"
            lblWarnWin10.Visible = True
            txtWarnWin10.Visible = True
            chkCheckDefaultOnLaunch.Enabled = False
            chkCheckDefaultOnLaunch.Checked = False
            cmdMakeDefault.Enabled = False

            'also remove the single file associations - win10 disabled that too
            cmdOpenDefaultForFile.Visible = False
            cmdOpenDefaultForProtocol.Visible = False
        End If

        'indicate that the screen is NOT dirty and DOES NOT need to be saved
        mbDirty = False
    End Sub

    Private Sub frmOptions_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        'update screen from internet classes 
        Dim llsiItem As ListViewItem

        'browsers
        lstBrowsers.Items.Clear()
        mBrowser = New Dictionary(Of Integer, Browser)
        For Each lBrowser As Browser In gSettings.Browsers
            mBrowser.Add(mBrowser.Count, DirectCast(lBrowser.Clone, Browser))

            llsiItem = lstBrowsers.Items.Add(lBrowser.Name)
            llsiItem.Tag = mBrowser.Count - 1
        Next
        mLastBrowserID = mBrowser.Count - 1

        'urls
        lstURLs.Items.Clear()
        mURLs = New SortedDictionary(Of Integer, URL)
        For Each lURL As URL In gSettings.URLs
            mURLs.Add(mURLs.Count, DirectCast(lURL.Clone, URL))

            llsiItem = lstURLs.Items.Add(lURL.URL)
            llsiItem.SubItems.Add(Utility.GetBrowserByGUID(lURL.Guid).Name)
            llsiItem.Tag = mURLs.Count - 1
        Next
        mLastURLID = mURLs.Count - 1

        'protocols
        lstProtocols.Items.Clear()
        mProtocols = New Dictionary(Of Integer, Protocol)
        For Each lProtocol As Protocol In gSettings.Protocols
            mProtocols.Add(mProtocols.Count, DirectCast(lProtocol.Clone, Protocol))

            llsiItem = lstProtocols.Items.Add(lProtocol.ProtocolName)
            llsiItem.Tag = mProtocols.Count - 1
            llsiItem.SubItems.Add(lProtocol.Header)
        Next
        mLastProtocolID = mProtocols.Count - 1

        'file types / extentions
        lstFiletypes.Items.Clear()
        mFileTypes = New Dictionary(Of Integer, FileType)
        For Each lFileType As FileType In gSettings.FileTypes
            mFileTypes.Add(mFileTypes.Count, DirectCast(lFileType.Clone, FileType))

            llsiItem = lstFiletypes.Items.Add(lFileType.FiletypeName)
            llsiItem.Tag = mFileTypes.Count - 1
            llsiItem.SubItems.Add(lFileType.Extention)
        Next
        mLastFileTypeID = mFileTypes.Count - 1

        'options page
        'default
        chkShowURLs.Checked = gSettings.ShowURL
        chkRevealShortURLs.Checked = gSettings.RevealShortURL
        chkPortableMode.Checked = gSettings.PortableMode
        chkAutoCheckUpdate.Checked = gSettings.AutomaticUpdates
        nudHeight.Value = gSettings.Height
        nudWidth.Value = gSettings.Width
        txtOptionsShortcut.Text = gSettings.OptionsShortcut
        txtMessage.Text = gSettings.DefaultMessage
        chkCheckDefaultOnLaunch.Checked = gSettings.CheckDefaultOnLaunch
        chkAdvanced.Checked = gSettings.AdvancedScreens
        nudDelayBeforeAutoload.Value = gSettings.DefaultDelay
        txtSeperator.Text = gSettings.Seperator

        mA11YSettings = New frmAccessibilitySettings.A11YSettings
        mA11YSettings.AccessibleRendering = gSettings.AccessibleRendering
        mA11YSettings.ShowFocus = gSettings.ShowFocus
        mA11YSettings.UseAreo = gSettings.UseAreo


        'check if advanced settings are on
        If chkAdvanced.Checked = False Then
            HideAdvancedPages()
        End If

        'indicate that the screen is NOT dirty and DOES NOT need to be saved
        mbDirty = False
    End Sub
#End Region

#Region "URL CRUD"
    Private Sub cmdAutoURLAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAutoURLAdd.Click
        'show up a dialog to set the browser settings
        Dim lfrmAdd As New frmAddEditURL

        If lfrmAdd.AddURL(mBrowser) = True Then
            Dim lNewURL As URL = lfrmAdd.GetData
            mURLs.Add(mLastURLID + 1, lNewURL)
            Dim llsiItem As ListViewItem = lstURLs.Items.Add(lNewURL.URL)
            llsiItem.SubItems.Add(Utility.GetBrowserByGUID(lNewURL.Guid).Name)
            llsiItem.Tag = mLastURLID + 1
            mLastURLID += 1

            'indicate that the screen is dirty and needs to be saved
            mbDirty = True
        End If
    End Sub

    Private Sub cmdAutoURLEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAutoURLEdit.Click
        If lstURLs.SelectedItems.Count > 0 Then
            'show up a dialog to set the url settings
            Dim lfrmAdd As New frmAddEditURL

            If lfrmAdd.EditURL(mURLs(CInt(lstURLs.SelectedItems(0).Tag)), mBrowser) = True Then
                Dim lNewURL As URL = lfrmAdd.GetData
                mURLs(CInt(lstURLs.SelectedItems(0).Tag)) = lNewURL
                lstURLs.SelectedItems(0).Text = lNewURL.URL
                lstURLs.SelectedItems(0).SubItems(1).Text = Utility.GetBrowserByGUID(lNewURL.Guid).Name

                'indicate that the screen is dirty and needs to be saved
                mbDirty = True
            End If
        End If
    End Sub

    Private Sub cmdAutoURLDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAutoURLDelete.Click
        If lstURLs.SelectedItems.Count > 0 Then
            If MessageBox.Show("Are you sure you want delete the " + lstURLs.SelectedItems(0).Text + " entry?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                mURLs.Remove(CInt(lstURLs.SelectedItems(0).Tag))
                lstURLs.Items.Remove(lstURLs.SelectedItems(0))

                'indicate that the screen is dirty and needs to be saved
                mbDirty = True
            End If
        End If
    End Sub
#End Region

#Region "Protocol CRUD"
    Private Sub cmdProtocolAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddProtocol.Click
        'show up a dialog to set the browser settings
        Dim lfrmAdd As New frmAddEditProtocols

        If lfrmAdd.AddProtocol(mBrowser) = True Then
            Dim lProtocol As Protocol = lfrmAdd.GetData
            mProtocols.Add(mLastProtocolID + 1, lProtocol)
            Dim llsiItem As ListViewItem = lstProtocols.Items.Add(lProtocol.ProtocolName)
            llsiItem.SubItems.Add(lProtocol.Header)
            llsiItem.Tag = mLastProtocolID + 1
            mLastProtocolID += 1

            mProtocolsAreDirty = True

            'indicate that the screen is dirty and needs to be saved
            mbDirty = True
        End If
    End Sub

    Private Sub cmdProtocolEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEditProtocol.Click
        If lstProtocols.SelectedItems.Count > 0 Then
            'show up a dialog to set the url settings
            Dim lfrmAdd As New frmAddEditProtocols

            If lfrmAdd.EditProtocol(mProtocols(CInt(lstProtocols.SelectedItems(0).Tag)), mBrowser) = True Then
                Dim lProtocol As Protocol = lfrmAdd.GetData
                mProtocols(CInt(lstProtocols.SelectedItems(0).Tag)) = lProtocol
                lstProtocols.SelectedItems(0).Text = lProtocol.ProtocolName
                lstProtocols.SelectedItems(0).SubItems(1).Text = lProtocol.Header

                mProtocolsAreDirty = True

                'indicate that the screen is dirty and needs to be saved
                mbDirty = True
            End If
        End If
    End Sub

    Private Sub cmdProtocolDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteProtocol.Click
        If lstProtocols.SelectedItems.Count > 0 Then
            If MessageBox.Show("Are you sure you want delete the " + lstProtocols.SelectedItems(0).Text + " entry?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                mProtocols.Remove(CInt(lstProtocols.SelectedItems(0).Tag))
                lstProtocols.Items.Remove(lstProtocols.SelectedItems(0))

                mProtocolsAreDirty = True

                'indicate that the screen is dirty and needs to be saved
                mbDirty = True
            End If
        End If
    End Sub
#End Region

#Region "Filetypes CRUD"
    Private Sub cmdFileTypelAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddFileType.Click
        'show up a dialog to set the browser settings
        Dim lfrmAdd As New frmAddEditType

        If lfrmAdd.AddType(mBrowser) = True Then
            Dim lFileType As FileType = lfrmAdd.GetData
            mFileTypes.Add(mLastFileTypeID + 1, lFileType)
            Dim llsiItem As ListViewItem = lstFiletypes.Items.Add(lFileType.FiletypeName)
            llsiItem.SubItems.Add(lFileType.Extention)
            llsiItem.Tag = mLastFileTypeID + 1
            mLastFileTypeID += 1

            mFileTypesAreDirty = True

            'indicate that the screen is dirty and needs to be saved
            mbDirty = True
        End If
    End Sub

    Private Sub cmdFileTypeEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEditFileType.Click
        If lstFiletypes.SelectedItems.Count > 0 Then
            'show up a dialog to set the url settings
            Dim lfrmAdd As New frmAddEditType

            If lfrmAdd.EditType(mFileTypes(CInt(lstFiletypes.SelectedItems(0).Tag)), mBrowser) = True Then
                Dim lFileType As FileType = lfrmAdd.GetData
                mFileTypes(CInt(lstFiletypes.SelectedItems(0).Tag)) = lFileType
                lstFiletypes.SelectedItems(0).Text = lFileType.FiletypeName
                lstFiletypes.SelectedItems(0).SubItems(1).Text = lFileType.Extention

                mFileTypesAreDirty = True

                'indicate that the screen is dirty and needs to be saved
                mbDirty = True
            End If
        End If
    End Sub

    Private Sub cmdFileTypeDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteFileType.Click
        If lstFiletypes.SelectedItems.Count > 0 Then
            If MessageBox.Show("Are you sure you want delete the " + lstFiletypes.SelectedItems(0).Text + " entry?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                mFileTypes.Remove(CInt(lstFiletypes.SelectedItems(0).Tag))
                lstFiletypes.Items.Remove(lstFiletypes.SelectedItems(0))

                mFileTypesAreDirty = True

                'indicate that the screen is dirty and needs to be saved
                mbDirty = True
            End If
        End If
    End Sub
#End Region

    Private Sub cmdImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImport.Click
        If MessageBox.Show("Importing your setting from Browser Chooser 1 will override your settings here. Are you sure you want to import?",
                           "Comfirm Import", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Me.TopMost = False
            Dim lSource As String = frmImportSource.GetSource()

            If lSource <> "" Then
                Dim lImporter As New Importer(lSource)

                MessageBox.Show("Settings imported. Will now restart", "Restarting", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Application.Restart()
            End If
        End If
    End Sub

    Private Sub cmdCheckForUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCheckForUpdate.Click
        Updator.CheckForUpdate(False) ' handles the full process
    End Sub

    Private Sub AddToDefault()
        If rbScopeUser.Checked = True Then
            DefaultBrowser.MakeAvailable(DefaultBrowser.Scope.sUser)
        Else
            Utility.LaunchAdminMode(Utility.ListOfCommands.MakeAvailable)
        End If
    End Sub

    Private Sub MakeDefault()
        If rbScopeUser.Checked = True Then
            DefaultBrowser.MakeDefault(DefaultBrowser.Scope.sUser)
        Else
            Utility.LaunchAdminMode(Utility.ListOfCommands.MakeDefault)
        End If
    End Sub

    Private Sub MakeDefaultSingle(aItem As String, abIsProtocol As Boolean)
        If rbScopeUser.Checked = True Then
            DefaultBrowser.MakeDefault(DefaultBrowser.Scope.sUser, aDoSingle:=aItem, abIsProtocol:=abIsProtocol)
        Else
            Debug.Print("FIXME: Admin does not yet support default single")
            Utility.LaunchAdminMode(Utility.ListOfCommands.MakeDefault) 'admin does not yet support this branch
        End If
    End Sub

    Private Sub cmdAddToDefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddToDefault.Click
        AddToDefault()
    End Sub

    Private Sub cmdMakeDefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMakeDefault.Click
        MakeDefault()
    End Sub

    Private Sub rbScope_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbScopeUser.CheckedChanged, rbScopeSystem.CheckedChanged
        If rbScopeUser.Checked = True Then
            'remove the sheild on the buttons!
            cmdAddToDefault.FlatStyle = FlatStyle.System
            cmdMakeDefault.FlatStyle = FlatStyle.System
            WinAPIs.SendMessage(cmdAddToDefault.Handle, WinAPIs.BCM_SETSHIELD, 0, New IntPtr(0))
            WinAPIs.SendMessage(cmdMakeDefault.Handle, WinAPIs.BCM_SETSHIELD, 0, New IntPtr(0))
        Else
            'put the sheild on the buttons!
            cmdAddToDefault.FlatStyle = FlatStyle.System
            cmdMakeDefault.FlatStyle = FlatStyle.System
            WinAPIs.SendMessage(cmdAddToDefault.Handle, WinAPIs.BCM_SETSHIELD, 0, New IntPtr(1))
            WinAPIs.SendMessage(cmdMakeDefault.Handle, WinAPIs.BCM_SETSHIELD, 0, New IntPtr(1))
        End If
    End Sub

    Private Sub chkAdvanced_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAdvanced.CheckedChanged
        If chkAdvanced.Checked = False Then
            HideAdvancedPages()
        Else
            ShowAdvancedPages()
        End If
    End Sub

    Private Sub tabCategories_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabCategories.Enter
        'update list of categories
        lstCategories.Items.Clear()

        Dim lCategories As New List(Of String)
        For Each lBrowser As KeyValuePair(Of Integer, Browser) In mBrowser
            If lCategories.Contains(lBrowser.Value.Category) = False Then
                lCategories.Add(lBrowser.Value.Category)
                lstCategories.Items.Add(lBrowser.Value.Category)

                'indicate that the screen is dirty and needs to be saved
                mbDirty = True
            End If
        Next
    End Sub

    Private Sub cmdDetectBrowsers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDetectBrowsers.Click
        'retrigger the detection of browsers, while not removing / re-adding existing ones
        Dim lResult As List(Of Browser) = DetectedBrowsers.DoBrowserDetection()
        Dim lMissing As New List(Of Browser)
        Dim lbFound As Boolean

        'check our list to see if any missing
        For Each lDetectedBrowser In lResult

            For Each lBrowser As KeyValuePair(Of Integer, Browser) In mBrowser
                lbFound = False
                If lBrowser.Value.Target = lDetectedBrowser.Target Then
                    lbFound = True

                    Exit For
                End If
            Next

            If lbFound = False Then
                Debug.Print(lDetectedBrowser.Name)
                lMissing.Add(lDetectedBrowser)
            End If
        Next

        'now add missing to the list - this is a lengty (code wise) process
        'first build a list of used spots
        Dim lIndexes As New SortedList 'start with an index of positions used
        For Each lBrowser As KeyValuePair(Of Integer, Browser) In mBrowser
            lIndexes.Add(lBrowser.Value.PosX.ToString & lBrowser.Value.PosY.ToString, Nothing)
        Next

        'go throught each browser and find them a spot and assign default settings
        For Each lBrowser As Browser In lMissing
            'find it a spot
            lbFound = False
            For lY As Integer = 1 To CInt(nudHeight.Value)
                For lX As Integer = 1 To CInt(nudWidth.Value)
                    If lIndexes.ContainsKey(lX.ToString & lY.ToString) = False Then
                        'found it
                        lBrowser.PosX = lX
                        lBrowser.PosY = lY
                        lbFound = True
                        Exit For : Exit For
                    End If
                Next

                If lbFound = True Then Exit For
            Next


            If lbFound = False Then
                'we need to add a row
                nudHeight.Value = nudHeight.Value + 1
                lBrowser.PosX = 1
                lBrowser.PosY = CInt(nudHeight.Value)
            End If

            'add to index
            lIndexes.Add(lBrowser.PosX.ToString & lBrowser.PosY.ToString, Nothing)

            'finish with extra details
            lBrowser.GUID = System.Guid.NewGuid

            'add the new GUID to the list above
            For Each lProtocol As KeyValuePair(Of Integer, Protocol) In mProtocols
                If lProtocol.Value.DefaultCategories.Contains(Utility.DEFAULT_CATEGORY) = True Then
                    lProtocol.Value.SupportingBrowsers.Add(lBrowser.GUID)
                End If
            Next

            For Each lFileTypes As KeyValuePair(Of Integer, FileType) In mFileTypes
                If lFileTypes.Value.DefaultCategories.Contains(Utility.DEFAULT_CATEGORY) = True Then
                    lFileTypes.Value.SupportingBrowsers.Add(lBrowser.GUID)
                End If
            Next

            'finaly, add it to the browser list
            mBrowser.Add(mLastBrowserID + 1, lBrowser)
            mLastBrowserID = mLastBrowserID + 1
            Dim llsiItem As ListViewItem = lstBrowsers.Items.Add(lBrowser.Name)
            llsiItem.Tag = mBrowser.Count - 1
        Next

        'indicate that the screen is dirty and needs to be saved
        mbDirty = True
    End Sub

    Private Sub SwapURLS(ByVal aFirst As Integer, ByVal aSecond As Integer)
        Dim lUrl As URL = mURLs(aFirst)
        Dim lOtherURl As URL = mURLs(aSecond)
        mURLs.Remove(aFirst)
        mURLs.Remove(aSecond)
        mURLs.Add(aSecond, lUrl)
        mURLs.Add(aFirst, lOtherURl)
    End Sub

    Private Sub cmdMoveUpAutoURL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMoveUpAutoURL.Click
        If lstURLs.SelectedItems.Count > 0 Then
            'move the selected item up one 
            If lstURLs.SelectedItems(0).Index > 0 Then
                'can't go any higher
                Dim lItem As ListViewItem = lstURLs.SelectedItems(0)
                Dim lIndex = lItem.Index
                Dim lTag As Integer = CInt(lItem.Tag)
                Dim lOtherTag As Integer = CInt(lstURLs.Items(lIndex - 1).Tag)
                lstURLs.Items(lIndex).Remove()
                lstURLs.Items.Insert(lIndex - 1, lItem)

                'repeat for the internal list of urls
                SwapURLS(lTag, lOtherTag)

                'indicate that the screen is dirty and needs to be saved
                mbDirty = True
            End If
        End If
    End Sub

    Private Sub cmdMoveDownAutoURL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdMoveDownAutoURL.Click
        If lstURLs.SelectedItems.Count > 0 Then
            'move the selected item up one 
            If lstURLs.SelectedItems(0).Index < lstURLs.Items.Count - 1 Then
                'can't go any lower
                Dim lItem As ListViewItem = lstURLs.SelectedItems(0)
                Dim lIndex = lItem.Index
                Dim lTag As Integer = CInt(lItem.Tag)
                Dim lOtherTag As Integer = CInt(lstURLs.Items(lIndex + 1).Tag)
                lstURLs.Items(lIndex).Remove()
                lstURLs.Items.Insert(lIndex + 1, lItem)

                'repeat for the internal list of urls
                SwapURLS(lTag, lOtherTag)

                'indicate that the screen is dirty and needs to be saved
                mbDirty = True
            End If
        End If
    End Sub

    Private Sub cmdAccessiblitySettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAccessiblitySettings.Click
        If frmAccessibilitySettings.ShowSettings(mA11YSettings) = True Then
            mA11YSettings = frmAccessibilitySettings.GetSettings

            'indicate that the screen is dirty and needs to be saved
            mbDirty = True
        End If
    End Sub

    Public Sub DetectDirty(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
        chkShowURLs.CheckedChanged, chkAutoCheckUpdate.CheckedChanged, chkPortableMode.CheckedChanged, chkRevealShortURLs.CheckedChanged, chkAdvanced.CheckedChanged, _
        nudDelayBeforeAutoload.ValueChanged, nudWidth.ValueChanged, nudHeight.ValueChanged, _
        txtOptionsShortcut.TextChanged, txtMessage.TextChanged, txtSeperator.TextChanged

        'indicate that the screen is dirty and needs to be saved
        mbDirty = True
    End Sub

    Private Sub cmdOpenDefaultForFile_Click(sender As System.Object, e As System.EventArgs) Handles cmdOpenDefaultForFile.Click
        If lstFiletypes.SelectedItems.Count > 0 Then
            MakeDefaultSingle(String.Format(".{0}", lstFiletypes.SelectedItems(0).Text), False)
        End If
    End Sub
End Class