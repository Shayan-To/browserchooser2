﻿Imports Microsoft.Win32
Imports System.IO
'Imports Microsoft.WindowsAPICodePack

Public Class Options

    Public InstalledBrowsers As List(Of Browser)

    Private Sub LoadBrowsers()

        InstalledBrowsers = New List(Of Browser)

        InstalledBrowsers.Add(New Browser With {.Name = "Custom", .Target = ""})

        Dim programFiles As String = My.Computer.FileSystem.SpecialDirectories.ProgramFiles

        ' If we are running on a 64 bit system, replace the programFiles string with a path to the x86
        If StartupLauncher.Is64Bit Then
            programFiles = Environment.GetEnvironmentVariable("ProgramFiles(x86)")
        End If

        Dim appData As String = Directory.GetParent(My.Computer.FileSystem.SpecialDirectories.Temp).FullName

        ' Add Firefox
        Dim firefox As String = Path.Combine(programFiles, "Mozilla Firefox\firefox.exe")

        If File.Exists(firefox) Then
            InstalledBrowsers.Add(New Browser With {.Name = "Firefox", .Target = firefox})
        End If

        ' Add Flock
        Dim flock As String = Path.Combine(programFiles, "Flock\flock.exe")

        If File.Exists(flock) Then
            InstalledBrowsers.Add(New Browser With {.Name = "Flock", .Target = flock})
        End If

        ' Add Google Chrome
        Dim chrome As String = Path.Combine(appData, "Google\Chrome\Application\chrome.exe")
        If File.Exists(chrome) Then
            InstalledBrowsers.Add(New Browser With {.Name = "Google Chrome", .Target = chrome})
        End If

        ' Add Internet Explorer
        Dim internetExplorer As String = Path.Combine(programFiles, "Internet Explorer\iexplore.exe")
        If File.Exists(internetExplorer) Then
            InstalledBrowsers.Add(New Browser With {.Name = "Internet Explorer", .Target = internetExplorer})
        End If

        ' Add Opera
        Dim opera As String = Path.Combine(programFiles, "Opera\opera.exe")
        If File.Exists(opera) Then
            InstalledBrowsers.Add(New Browser With {.Name = "Opera", .Target = opera})
        End If

        ' Add Safari
        Dim safari As String = Path.Combine(programFiles, "Safari\Safari.exe")
        If File.Exists(safari) Then
            InstalledBrowsers.Add(New Browser With {.Name = "Safari", .Target = safari})
        End If

    End Sub

    Private Sub btnBrowse1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowser1.Click
        Browser1FileDialog.Filter = "Application | *.exe"
        Browser1FileDialog.ShowDialog()
        'if a file is not picked, don't clear the options textbox
        If (Not String.IsNullOrEmpty(Browser1FileDialog.FileName)) Then
            Browser1Target.Text = Browser1FileDialog.FileName.ToString
        End If
        Browser1FileDialog.Reset()
    End Sub

    Private Sub btnBrowse2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowser2.Click
        Browser2FileDialog.Filter = "Application | *.exe"
        Browser2FileDialog.ShowDialog()
        'if a file is not picked, don't clear the options textbox
        If (Not String.IsNullOrEmpty(Browser2FileDialog.FileName)) Then
            Browser2Target.Text = Browser2FileDialog.FileName.ToString
        End If
    End Sub

    Private Sub btnBrowse3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowser3.Click
        Browser3FileDialog.Filter = "Application | *.exe"
        Browser3FileDialog.ShowDialog()
        'if a file is not picked, don't clear the options textbox
        If (Not String.IsNullOrEmpty(Browser3FileDialog.FileName)) Then
            Browser3Target.Text = Browser3FileDialog.FileName.ToString
        End If
    End Sub

    Private Sub btnBrowse4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowser4.Click
        Browser4FileDialog.Filter = "Application | *.exe"
        Browser4FileDialog.ShowDialog()
        'if a file is not picked, don't clear the options textbox
        If (Not String.IsNullOrEmpty(Browser4FileDialog.FileName)) Then
            Browser4Target.Text = Browser4FileDialog.FileName.ToString
        End If
    End Sub

    Private Sub btnBrowse5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowser5.Click
        Browser5FileDialog.Filter = "Application | *.exe"
        Browser5FileDialog.ShowDialog()
        'if a file is not picked, don't clear the options textbox
        If (Not String.IsNullOrEmpty(Browser5FileDialog.FileName)) Then
            Browser5Target.Text = Browser5FileDialog.FileName.ToString
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'Save settings from textboxes
        'Offer to make default browser if not already

        'reset the in memory list of browsers object
        BrowserConfig.Browsers.Clear()

        If Not BrowserConfig.IamDefaultBrowser Then

            Dim Answer As MsgBoxResult = MsgBox("Browser Chooser is not currently set as your default browser. Would you like to make it so now?" & vbCrLf & "(Without being the default browser, Browser Chooser's usefullness rapidly declines...)", MsgBoxStyle.YesNo)

            If Answer = MsgBoxResult.Yes Then
                BrowserConfig.IamDefaultBrowser = True
                SetDefaultBrowserPath()
            Else
                BrowserConfig.IamDefaultBrowser = False
            End If

        End If

        BrowserConfig.ShowUrl = cbURL.Checked
        BrowserConfig.AutoUpdateCheck = cbAutoCheck.Checked
        BrowserConfig.RevealURL = cbRevealURL.Checked

        If cbIntranet.SelectedIndex = 0 Then
            BrowserConfig.IntranetBrowser = Nothing
        ElseIf cbIntranet.SelectedItem IsNot Nothing Then
            BrowserConfig.IntranetBrowser = cbIntranet.SelectedItem
        End If

        If cbDefault.SelectedIndex = 0 Then
            BrowserConfig.DefaultBrowser = Nothing
        ElseIf cbDefault.SelectedItem IsNot Nothing Then
            BrowserConfig.DefaultBrowser = cbDefault.SelectedItem
        End If

        If (Not String.IsNullOrEmpty(Browser1Name.Text)) Then
            BrowserConfig.Browsers.Add(New Browser With {.Name = Browser1Name.Text, .Target = Browser1Target.Text, .Image = Browser1Image.Text, .BrowserNumber = 1, .IsActive = True, .Urls = Browser.StringToUrls(Browser1Urls.Text), .CustomImagePath = Browser1ImagePath.Text})
        End If

        If (Not String.IsNullOrEmpty(Browser2Name.Text)) Then
            BrowserConfig.Browsers.Add(New Browser With {.Name = Browser2Name.Text, .Target = Browser2Target.Text, .Image = Browser2Image.Text, .BrowserNumber = 2, .IsActive = True, .Urls = Browser.StringToUrls(Browser2Urls.Text), .CustomImagePath = Browser2ImagePath.Text})
        End If

        If (Not String.IsNullOrEmpty(Browser3Name.Text)) Then
            BrowserConfig.Browsers.Add(New Browser With {.Name = Browser3Name.Text, .Target = Browser3Target.Text, .Image = Browser3Image.Text, .BrowserNumber = 3, .IsActive = True, .Urls = Browser.StringToUrls(Browser3Urls.Text), .CustomImagePath = Browser3ImagePath.Text})
        End If

        If (Not String.IsNullOrEmpty(Browser4Name.Text)) Then
            BrowserConfig.Browsers.Add(New Browser With {.Name = Browser4Name.Text, .Target = Browser4Target.Text, .Image = Browser4Image.Text, .BrowserNumber = 4, .IsActive = True, .Urls = Browser.StringToUrls(Browser4Urls.Text), .CustomImagePath = Browser4ImagePath.Text})
        End If

        If (Not String.IsNullOrEmpty(Browser5Name.Text)) Then
            BrowserConfig.Browsers.Add(New Browser With {.Name = Browser5Name.Text, .Target = Browser5Target.Text, .Image = Browser5Image.Text, .BrowserNumber = 5, .IsActive = True, .Urls = Browser.StringToUrls(Browser5Urls.Text), .CustomImagePath = Browser5ImagePath.Text})
        End If

        If cbPortable.Checked Then
            PortableMode = True
        End If

        SaveConfig()

        'Me.Close()
        Process.Start(Application.ExecutablePath)
        System.Environment.Exit(-1)
        'frmMain.InitializeMain()

        'MsgBox("Please restart the application for the settings to take effect.")

    End Sub

    Public Sub SaveConfig()
        Try
            'Switch to make portable version
            If (PortableMode) Then
                BrowserConfig.Save(Application.StartupPath)
            Else
                BrowserConfig.Save(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\BrowserChooser")
            End If
        Catch ex As Exception
            MsgBox("There was an error saving to the configuration file." & vbCrLf & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Options_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Autodetect all present browsers
        LoadBrowsers()


        Browser1.DataSource = InstalledBrowsers.ToList()
        Browser1.DisplayMember = "Name"
        Browser1.ValueMember = "Target"
        Browser2.DataSource = InstalledBrowsers.ToList()
        Browser2.DisplayMember = "Name"
        Browser2.ValueMember = "Target"
        Browser3.DataSource = InstalledBrowsers.ToList()
        Browser3.DisplayMember = "Name"
        Browser3.ValueMember = "Target"
        Browser4.DataSource = InstalledBrowsers.ToList()
        Browser4.DisplayMember = "Name"
        Browser4.ValueMember = "Target"
        Browser5.DataSource = InstalledBrowsers.ToList()
        Browser5.DisplayMember = "Name"
        Browser5.ValueMember = "Target"

        'Load settings into textboxes
        Browser1Name.Text = BrowserConfig.GetBrowser(1).Name
        Browser2Name.Text = BrowserConfig.GetBrowser(2).Name
        Browser3Name.Text = BrowserConfig.GetBrowser(3).Name
        Browser4Name.Text = BrowserConfig.GetBrowser(4).Name
        Browser5Name.Text = BrowserConfig.GetBrowser(5).Name

        Browser1Target.Text = BrowserConfig.GetBrowser(1).Target
        Browser2Target.Text = BrowserConfig.GetBrowser(2).Target
        Browser3Target.Text = BrowserConfig.GetBrowser(3).Target
        Browser4Target.Text = BrowserConfig.GetBrowser(4).Target
        Browser5Target.Text = BrowserConfig.GetBrowser(5).Target

        Browser1Image.SelectedItem = BrowserConfig.GetBrowser(1).Image
        Browser2Image.SelectedItem = BrowserConfig.GetBrowser(2).Image
        Browser3Image.SelectedItem = BrowserConfig.GetBrowser(3).Image
        Browser4Image.SelectedItem = BrowserConfig.GetBrowser(4).Image
        Browser5Image.SelectedItem = BrowserConfig.GetBrowser(5).Image

        Browser1Urls.Text = BrowserConfig.GetBrowser(1).UrlsToString
        Browser2Urls.Text = BrowserConfig.GetBrowser(2).UrlsToString
        Browser3Urls.Text = BrowserConfig.GetBrowser(3).UrlsToString
        Browser4Urls.Text = BrowserConfig.GetBrowser(4).UrlsToString
        Browser5Urls.Text = BrowserConfig.GetBrowser(5).UrlsToString

        Browser1ImagePath.Text = BrowserConfig.GetBrowser(1).CustomImagePath
        Browser2ImagePath.Text = BrowserConfig.GetBrowser(2).CustomImagePath
        Browser3ImagePath.Text = BrowserConfig.GetBrowser(3).CustomImagePath
        Browser4ImagePath.Text = BrowserConfig.GetBrowser(4).CustomImagePath
        Browser5ImagePath.Text = BrowserConfig.GetBrowser(5).CustomImagePath

        'Select the correct items in the Browser dropdown
        Try
            SelectBrowser(BrowserConfig.GetBrowser(1).Target, BrowserConfig.GetBrowser(1).Image, Browser1)
            SelectBrowser(BrowserConfig.GetBrowser(2).Target, BrowserConfig.GetBrowser(2).Image, Browser2)
            SelectBrowser(BrowserConfig.GetBrowser(3).Target, BrowserConfig.GetBrowser(3).Image, Browser3)
            SelectBrowser(BrowserConfig.GetBrowser(4).Target, BrowserConfig.GetBrowser(4).Image, Browser4)
            SelectBrowser(BrowserConfig.GetBrowser(5).Target, BrowserConfig.GetBrowser(5).Image, Browser5)
        Catch ex As Exception

        End Try

        cbURL.Checked = BrowserConfig.ShowUrl
        cbAutoCheck.Checked = BrowserConfig.AutoUpdateCheck
        cbRevealURL.Checked = BrowserConfig.RevealUrl

        Dim target As String = ""
        If (BrowserConfig.IntranetBrowser IsNot Nothing) Then
            target = BrowserConfig.IntranetBrowser.Target
        End If

        cbIntranet.Items.Add("None")
        cbIntranet.SelectedIndex = 0
        For Each Browser In BrowserConfig.Browsers
            If (Browser.IsActive) Then
                cbIntranet.Items.Add(Browser)
                If (target = Browser.Target) Then
                    cbIntranet.SelectedItem = Browser
                End If
            End If
        Next

        target = ""
        If (BrowserConfig.DefaultBrowser IsNot Nothing) Then
            target = BrowserConfig.DefaultBrowser.Target
        End If

        cbDefault.Items.Add("None")
        cbDefault.SelectedIndex = 0
        For Each Browser In BrowserConfig.Browsers
            If (Browser.IsActive) Then
                cbDefault.Items.Add(Browser)
                If (target = Browser.Target) Then
                    cbDefault.SelectedItem = Browser
                End If
            End If
        Next

        'Switch for portable version
        Dim ConfigFile As String
        If (PortableMode) Then
            cbPortable.Checked = True
            ConfigFile = Path.Combine(Application.StartupPath, Settings.BrowserChooserConfigFileName)
        Else
            ConfigFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\BrowserChooser", Settings.BrowserChooserConfigFileName)
        End If

        If Not File.Exists(ConfigFile) Then
            If MsgBox("Would you like to automatically check for updates?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                cbAutoCheck.Checked = True
                BrowserConfig.AutoUpdateCheck = True
            End If
        End If
    End Sub

    Private Sub SelectBrowser(ByVal BrowserPath As String, ByVal BrowserName As String, ByVal currentComboBox As ComboBox)
        Dim path As String = BrowserPath
        Dim comparer As New BrowserPredicate(path)
        Dim browser As Browser = InstalledBrowsers.Find(AddressOf comparer.ComparePaths)
        If browser IsNot Nothing Then
            currentComboBox.SelectedIndex = currentComboBox.FindString(BrowserName)
        End If
    End Sub

    Private Class BrowserPredicate
        Private _path As String
        Private _name As String

        Public Sub New(ByVal path As String)
            _path = path
        End Sub

        Public Function ComparePaths(ByVal obj As Browser) As Boolean
            Return (_path = obj.Target)
        End Function

        Public Function CompareNames(ByVal obj As Browser) As Boolean
            Return (_path = obj.Name)
        End Function
    End Class

    Private Sub Browser1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Browser1.SelectedIndexChanged, Browser2.SelectedIndexChanged, Browser3.SelectedIndexChanged, Browser4.SelectedIndexChanged, Browser5.SelectedIndexChanged
        Dim SelectedComboBox As ComboBox = sender

        If SelectedComboBox.SelectedIndex > 0 Then
            Dim SelectedBrowser As Browser
            SelectedBrowser = SelectedComboBox.SelectedItem

            Select Case SelectedComboBox.Name
                Case "Browser1"
                    Browser1Name.Text = SelectedBrowser.Name
                    Browser1Target.Text = SelectedBrowser.Target
                    Browser1Image.SelectedIndex = Browser1Image.FindString(SelectedBrowser.Name)
                Case "Browser2"
                    Browser2Name.Text = SelectedBrowser.Name
                    Browser2Target.Text = SelectedBrowser.Target
                    Browser2Image.SelectedIndex = Browser2Image.FindString(SelectedBrowser.Name)
                Case "Browser3"
                    Browser3Name.Text = SelectedBrowser.Name
                    Browser3Target.Text = SelectedBrowser.Target
                    Browser3Image.SelectedIndex = Browser3Image.FindString(SelectedBrowser.Name)
                Case "Browser4"
                    Browser4Name.Text = SelectedBrowser.Name
                    Browser4Target.Text = SelectedBrowser.Target
                    Browser4Image.SelectedIndex = Browser4Image.FindString(SelectedBrowser.Name)
                Case "Browser5"
                    Browser5Name.Text = SelectedBrowser.Name
                    Browser5Target.Text = SelectedBrowser.Target
                    Browser5Image.SelectedIndex = Browser5Image.FindString(SelectedBrowser.Name)
                Case Else

            End Select
        Else
            Dim SelectedBrowser As Browser
            SelectedBrowser = SelectedComboBox.SelectedItem

            Select Case SelectedComboBox.Name
                Case "Browser1"
                    Browser1Name.Text = ""
                    Browser1Target.Text = ""
                    Browser1Image.SelectedItem = "Custom"
                Case "Browser2"
                    Browser2Name.Text = ""
                    Browser2Target.Text = ""
                    Browser2Image.SelectedItem = "Custom"
                Case "Browser3"
                    Browser3Name.Text = ""
                    Browser3Target.Text = ""
                    Browser3Image.SelectedItem = "Custom"
                Case "Browser4"
                    Browser4Name.Text = ""
                    Browser4Target.Text = ""
                    Browser4Image.SelectedItem = "Custom"
                Case "Browser5"
                    Browser5Name.Text = ""
                    Browser5Target.Text = ""
                    Browser5Image.SelectedItem = "Custom"
                Case Else

            End Select
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If File.Exists(Settings.BrowserChooserConfigFileName) Then 'OrElse Module1.ConfigFile.Exists Then
            Me.Close()
        Else
            Application.Exit()
        End If
    End Sub

    Private Sub btnSetDefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetDefault.Click
        MsgBox(SetDefaultBrowserPath)
    End Sub

    Public Function SetDefaultBrowserPath() As String

        If OS_Version() = "Windows XP" Then

            Try

                Registry.LocalMachine.CreateSubKey("SOFTWARE\Classes").SetValue(".shtml", "BrowserChooserHTML", RegistryValueKind.String)
                Registry.LocalMachine.CreateSubKey("SOFTWARE\Classes").SetValue(".xht", "BrowserChooserHTML", RegistryValueKind.String)
                Registry.LocalMachine.CreateSubKey("SOFTWARE\Classes").SetValue(".xhtm", "BrowserChooserHTML", RegistryValueKind.String)
                Registry.LocalMachine.CreateSubKey("SOFTWARE\Classes").SetValue(".xhtml", "BrowserChooserHTML", RegistryValueKind.String)
                Registry.LocalMachine.CreateSubKey("SOFTWARE\Classes").SetValue(".htm", "BrowserChooserHTML", RegistryValueKind.String)
                Registry.LocalMachine.CreateSubKey("SOFTWARE\Classes").SetValue(".html", "BrowserChooserHTML", RegistryValueKind.String)

                Registry.CurrentUser.CreateSubKey("SOFTWARE\Classes\.shtml").SetValue("", "BrowserChooserHTML", RegistryValueKind.String)
                Registry.CurrentUser.CreateSubKey("SOFTWARE\Classes\.xht").SetValue("", "BrowserChooserHTML", RegistryValueKind.String)
                Registry.CurrentUser.CreateSubKey("SOFTWARE\Classes\.xhtm").SetValue("", "BrowserChooserHTML", RegistryValueKind.String)
                Registry.CurrentUser.CreateSubKey("SOFTWARE\Classes\.xhtml").SetValue("", "BrowserChooserHTML", RegistryValueKind.String)
                Registry.CurrentUser.CreateSubKey("SOFTWARE\Classes\.htm").SetValue("", "BrowserChooserHTML", RegistryValueKind.String)
                Registry.CurrentUser.CreateSubKey("SOFTWARE\Classes\.html").SetValue("", "BrowserChooserHTML", RegistryValueKind.String)
                Registry.CurrentUser.CreateSubKey("SOFTWARE\Classes\.url").SetValue("", "BrowserChooserHTML", RegistryValueKind.String)

                Registry.CurrentUser.CreateSubKey("SOFTWARE\Classes\BrowserChooserHTML\DefaultIcon").SetValue("", Application.ExecutablePath & ",0", RegistryValueKind.String)
                Registry.CurrentUser.CreateSubKey("SOFTWARE\Classes\BrowserChooserHTML\shell\open\command").SetValue("", """" & Application.ExecutablePath & """ ""%1""", RegistryValueKind.String)

                Registry.CurrentUser.CreateSubKey("SOFTWARE\Classes\MyInternetShortcut\DefaultIcon").SetValue("", Application.ExecutablePath & ",0", RegistryValueKind.String)
                Registry.CurrentUser.CreateSubKey("SOFTWARE\Classes\MyInternetShortcut\shell\open\command").SetValue("", """" & Application.ExecutablePath & """ ""%1""", RegistryValueKind.String)

                Registry.CurrentUser.CreateSubKey("SOFTWARE\Classes\http\DefaultIcon").SetValue("", Application.ExecutablePath & ",0", RegistryValueKind.String)
                Registry.CurrentUser.CreateSubKey("SOFTWARE\Classes\http\shell\BrowserChooserHTML\open\command").SetValue("", """" & Application.ExecutablePath & """ ""%1""", RegistryValueKind.String)

                Registry.CurrentUser.CreateSubKey("SOFTWARE\Classes\https\DefaultIcon").SetValue("", Application.ExecutablePath & ",0", RegistryValueKind.String)
                Registry.CurrentUser.CreateSubKey("SOFTWARE\Classes\https\shell\BrowserChooserHTML\open\command").SetValue("", """" & Application.ExecutablePath & """ ""%1""", RegistryValueKind.String)

                Registry.CurrentUser.CreateSubKey("SOFTWARE\Classes\ftp\DefaultIcon").SetValue("", Application.ExecutablePath & ",0", RegistryValueKind.String)
                Registry.CurrentUser.CreateSubKey("SOFTWARE\Classes\ftp\shell\BrowserChooserHTML\open\command").SetValue("", """" & Application.ExecutablePath & """ ""%1""", RegistryValueKind.String)

                Registry.LocalMachine.CreateSubKey("SOFTWARE\Classes\BrowserChooserHTML\DefaultIcon").SetValue("", Application.ExecutablePath & ",0", RegistryValueKind.String)
                Registry.LocalMachine.CreateSubKey("SOFTWARE\Classes\BrowserChooserHTML\shell\open\command").SetValue("", """" & Application.ExecutablePath & """ ""%1""", RegistryValueKind.String)
                Registry.LocalMachine.CreateSubKey("SOFTWARE\Classes\ftp\DefaultIcon").SetValue("", Application.ExecutablePath & ",0", RegistryValueKind.String)
                Registry.LocalMachine.CreateSubKey("SOFTWARE\Classes\ftp\shell\open\command").SetValue("", """" & Application.ExecutablePath & """ ""%1""", RegistryValueKind.String)
                Registry.LocalMachine.CreateSubKey("SOFTWARE\Classes\gopher\DefaultIcon").SetValue("", Application.ExecutablePath & ",0", RegistryValueKind.String)
                Registry.LocalMachine.CreateSubKey("SOFTWARE\Classes\gopher\shell\open\command").SetValue("", """" & Application.ExecutablePath & """ ""%1""", RegistryValueKind.String)
                Registry.LocalMachine.CreateSubKey("SOFTWARE\Classes\http\DefaultIcon").SetValue("", Application.ExecutablePath & ",0", RegistryValueKind.String)
                Registry.LocalMachine.CreateSubKey("SOFTWARE\Classes\http\shell\open\command").SetValue("", """" & Application.ExecutablePath & """ ""%1""", RegistryValueKind.String)
                Registry.LocalMachine.CreateSubKey("SOFTWARE\Classes\https\DefaultIcon").SetValue("", Application.ExecutablePath & ",0", RegistryValueKind.String)
                Registry.LocalMachine.CreateSubKey("SOFTWARE\Classes\https\shell\open\command").SetValue("", """" & Application.ExecutablePath & """ ""%1""", RegistryValueKind.String)
                Registry.LocalMachine.CreateSubKey("SOFTWARE\Classes\CHROME\DefaultIcon").SetValue("", Application.ExecutablePath & ",0", RegistryValueKind.String)
                Registry.LocalMachine.CreateSubKey("SOFTWARE\Classes\CHROME\shell\open\command").SetValue("", """" & Application.ExecutablePath & """ ""%1""", RegistryValueKind.String)


                Registry.CurrentUser.CreateSubKey("SOFTWARE\Classes\BrowserChooserHTML\DefaultIcon").SetValue("", Application.ExecutablePath & ",0", RegistryValueKind.String)
                Registry.CurrentUser.CreateSubKey("SOFTWARE\Classes\BrowserChooserHTML\shell\open\command").SetValue("", """" & Application.ExecutablePath & """ ""%1""", RegistryValueKind.String)
                Registry.CurrentUser.CreateSubKey("SOFTWARE\Classes\ftp\DefaultIcon").SetValue("", Application.ExecutablePath & ",0", RegistryValueKind.String)
                Registry.CurrentUser.CreateSubKey("SOFTWARE\Classes\ftp\shell\open\command").SetValue("", """" & Application.ExecutablePath & """ ""%1""", RegistryValueKind.String)
                Registry.CurrentUser.CreateSubKey("SOFTWARE\Classes\gopher\DefaultIcon").SetValue("", Application.ExecutablePath & ",0", RegistryValueKind.String)
                Registry.CurrentUser.CreateSubKey("SOFTWARE\Classes\gopher\shell\open\command").SetValue("", """" & Application.ExecutablePath & """ ""%1""", RegistryValueKind.String)
                Registry.CurrentUser.CreateSubKey("SOFTWARE\Classes\http\DefaultIcon").SetValue("", Application.ExecutablePath & ",0", RegistryValueKind.String)
                Registry.CurrentUser.CreateSubKey("SOFTWARE\Classes\http\shell\open\command").SetValue("", """" & Application.ExecutablePath & """ ""%1""", RegistryValueKind.String)
                Registry.CurrentUser.CreateSubKey("SOFTWARE\Classes\https\DefaultIcon").SetValue("", Application.ExecutablePath & ",0", RegistryValueKind.String)
                Registry.CurrentUser.CreateSubKey("SOFTWARE\Classes\https\shell\open\command").SetValue("", """" & Application.ExecutablePath & """ ""%1""", RegistryValueKind.String)
                Registry.CurrentUser.CreateSubKey("SOFTWARE\Classes\CHROME\DefaultIcon").SetValue("", Application.ExecutablePath & ",0", RegistryValueKind.String)
                Registry.CurrentUser.CreateSubKey("SOFTWARE\Classes\CHROME\shell\open\command").SetValue("", """" & Application.ExecutablePath & """ ""%1""", RegistryValueKind.String)

                Registry.CurrentUser.CreateSubKey("SOFTWARE\Microsoft\Internet Explorer\Main").SetValue("Check_Associations", "No", RegistryValueKind.String)
                Registry.CurrentUser.CreateSubKey("SOFTWARE\Microsoft\Internet Explorer\Main").SetValue("IgnoreDefCheck", "Yes", RegistryValueKind.String)

            Catch ex As Exception
                BrowserConfig.IamDefaultBrowser = False
                Return "Problem writing or reading Registry: " & vbCrLf & vbCrLf & ex.Message
            End Try

        ElseIf OS_Version() = "Windows 7" Or OS_Version() = "Windows Vista" Or OS_Version() = "Windows 8" Then

            Try
                Registry.LocalMachine.CreateSubKey("SOFTWARE\RegisteredApplications").SetValue("Browser Chooser", "Software\\Browser Chooser\\Capabilities", RegistryValueKind.String)
                Registry.LocalMachine.CreateSubKey("SOFTWARE\Browser Chooser\Capabilities").SetValue("ApplicationName", "Browser Chooser", RegistryValueKind.String)
                Registry.LocalMachine.CreateSubKey("SOFTWARE\Browser Chooser\Capabilities").SetValue("ApplicationIcon", Application.ExecutablePath & ",0", RegistryValueKind.String)
                Registry.LocalMachine.CreateSubKey("SOFTWARE\Browser Chooser\Capabilities").SetValue("ApplicationDescription", "Small app that let's you choose what browser to open a url in. Visit my website for more information. www.janolepeek.com", RegistryValueKind.String)

                Registry.LocalMachine.CreateSubKey("SOFTWARE\Browser Chooser\Capabilities\FileAssociations").SetValue(".xhtml", "BrowserChooserHTML", RegistryValueKind.String)
                Registry.LocalMachine.CreateSubKey("SOFTWARE\Browser Chooser\Capabilities\FileAssociations").SetValue(".xht", "BrowserChooserHTML", RegistryValueKind.String)
                Registry.LocalMachine.CreateSubKey("SOFTWARE\Browser Chooser\Capabilities\FileAssociations").SetValue(".shtml", "BrowserChooserHTML", RegistryValueKind.String)
                Registry.LocalMachine.CreateSubKey("SOFTWARE\Browser Chooser\Capabilities\FileAssociations").SetValue(".html", "BrowserChooserHTML", RegistryValueKind.String)
                Registry.LocalMachine.CreateSubKey("SOFTWARE\Browser Chooser\Capabilities\FileAssociations").SetValue(".htm", "BrowserChooserHTML", RegistryValueKind.String)

                Registry.LocalMachine.CreateSubKey("SOFTWARE\Browser Chooser\Capabilities\StartMenu").SetValue("StartMenuInternet", "Browser Chooser.exe", RegistryValueKind.String)

                Registry.LocalMachine.CreateSubKey("SOFTWARE\Browser Chooser\Capabilities\URLAssociations").SetValue("https", "BrowserChooserHTML", RegistryValueKind.String)
                Registry.LocalMachine.CreateSubKey("SOFTWARE\Browser Chooser\Capabilities\URLAssociations").SetValue("http", "BrowserChooserHTML", RegistryValueKind.String)
                Registry.LocalMachine.CreateSubKey("SOFTWARE\Browser Chooser\Capabilities\URLAssociations").SetValue("ftp", "BrowserChooserHTML", RegistryValueKind.String)

                Registry.ClassesRoot.CreateSubKey("BrowserChooserHTML").SetValue("", "Browser Chooser HTML", RegistryValueKind.String)
                Registry.ClassesRoot.CreateSubKey("BrowserChooserHTML").SetValue("URL Protocol", "", RegistryValueKind.String)

                Registry.ClassesRoot.CreateSubKey("BrowserChooserHTML\DefaultIcon").SetValue("", Application.ExecutablePath & ",0", RegistryValueKind.String)

                Registry.ClassesRoot.CreateSubKey("BrowserChooserHTML\shell\open\command").SetValue("", Application.ExecutablePath & " %1", RegistryValueKind.String)

                Registry.CurrentUser.CreateSubKey("Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http\UserChoice").SetValue("Progid", "BrowserChooserHTML", Microsoft.Win32.RegistryValueKind.String)
                Registry.CurrentUser.CreateSubKey("Software\Microsoft\Windows\Shell\Associations\UrlAssociations\https\UserChoice").SetValue("Progid", "BrowserChooserHTML", Microsoft.Win32.RegistryValueKind.String)
                Registry.CurrentUser.CreateSubKey("Software\Microsoft\Windows\Shell\Associations\UrlAssociations\ftp\UserChoice").SetValue("Progid", "BrowserChooserHTML", Microsoft.Win32.RegistryValueKind.String)

                Try
                    Registry.CurrentUser.DeleteSubKey("Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.htm\UserChoice")
                    Registry.CurrentUser.DeleteSubKey("Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.html\UserChoice")
                    Registry.CurrentUser.DeleteSubKey("Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.shtml\UserChoice")
                    Registry.CurrentUser.DeleteSubKey("Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.xht\UserChoice")
                    Registry.CurrentUser.DeleteSubKey("Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.xhtml\UserChoice")

                    Registry.CurrentUser.CreateSubKey("Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.htm\UserChoice").SetValue("Progid", "BrowserChooserHTML", Microsoft.Win32.RegistryValueKind.String)
                    Registry.CurrentUser.CreateSubKey("Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.html\UserChoice").SetValue("Progid", "BrowserChooserHTML", Microsoft.Win32.RegistryValueKind.String)
                    Registry.CurrentUser.CreateSubKey("Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.shtml\UserChoice").SetValue("Progid", "BrowserChooserHTML", Microsoft.Win32.RegistryValueKind.String)
                    Registry.CurrentUser.CreateSubKey("Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.xht\UserChoice").SetValue("Progid", "BrowserChooserHTML", Microsoft.Win32.RegistryValueKind.String)
                    Registry.CurrentUser.CreateSubKey("Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.xhtml\UserChoice").SetValue("Progid", "BrowserChooserHTML", Microsoft.Win32.RegistryValueKind.String)
                Catch ex As Exception
                    MsgBox("An error may have occured registering the file extensions. You may want to check in the 'Default Programs' option in your start menu to confirm this worked." & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Exclamation)
                End Try

            Catch ex As Exception
                BrowserConfig.IamDefaultBrowser = False
                Return "Problem writing or reading Registry: " & vbCrLf & vbCrLf & ex.Message
            End Try

        Else

            Return "Unable to determine what version of Windows you are running, so we can't set Browser Chooser as the default. Sorry."

        End If



        BrowserConfig.IamDefaultBrowser = True

        Return "Default browser has been set to Browser Chooser."

    End Function


    Private Sub Browser1Target_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Browser1Target.TextChanged
        If Browser1Target.Text <> "" Then Panel2.Enabled = True Else Panel2.Enabled = False
    End Sub

    Private Sub Browser2Target_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Browser2Target.TextChanged
        If Browser2Target.Text <> "" Then Panel3.Enabled = True Else Panel3.Enabled = False
    End Sub

    Private Sub Browser3Target_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Browser3Target.TextChanged
        If Browser3Target.Text <> "" Then Panel4.Enabled = True Else Panel4.Enabled = False
    End Sub

    Private Sub Browser4Target_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Browser4Target.TextChanged
        If Browser4Target.Text <> "" Then Panel5.Enabled = True Else Panel5.Enabled = False
    End Sub


    Private Sub btnUpdateCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateCheck.Click
        frmMain.CheckforUpdate("verbose")
    End Sub

    Private Sub btnHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHelp.Click
        Try
            Process.Start(Application.StartupPath & "\Browser Chooser Help.chm")
        Catch ex As Exception
            MsgBox("Help file not found!" & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub BrowseCustomImageClick(ByRef fileDialog As OpenFileDialog, ByRef filePathTextBox As TextBox, ByRef imageComboBox As ComboBox)
        'try to open the file dialog to the image's path (even if the image doesn't exist)
        'otherwise open to the application startup path
        If (Not String.IsNullOrEmpty(filePathTextBox.Text)) Then
            Dim cImage As FileInfo = New FileInfo(Path.Combine(Application.StartupPath, filePathTextBox.Text))
            If (cImage.Directory.Exists) Then
                fileDialog.InitialDirectory = cImage.DirectoryName
                If (cImage.Exists) Then
                    fileDialog.FileName = cImage.FullName
                End If
            Else
                fileDialog.InitialDirectory = Application.StartupPath
            End If
        Else
            fileDialog.InitialDirectory = Application.StartupPath
        End If

        fileDialog.Filter = "Image (png, ico)|*.png;*.ico"
        fileDialog.ShowDialog()
        'if a file is not picked, don't clear the options textbox
        If (Not String.IsNullOrEmpty(fileDialog.FileName)) Then
            imageComboBox.SelectedItem = "Custom"
            If (fileDialog.FileName.StartsWith(Application.StartupPath)) Then
                'remove application path to support relative paths / particularly for portable mode 
                filePathTextBox.Text = fileDialog.FileName.Substring(Application.StartupPath.Length + 1)
            Else
                filePathTextBox.Text = fileDialog.FileName
            End If
        End If
        fileDialog.Reset()
    End Sub

    Private Sub btnBrowseCustomImage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseCustomImage1.Click
        BrowseCustomImageClick(Browser1FileDialog, Browser1ImagePath, Browser1Image)
    End Sub

    Private Sub btnBrowseCustomImage2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseCustomImage2.Click
        BrowseCustomImageClick(Browser2FileDialog, Browser2ImagePath, Browser2Image)
    End Sub

    Private Sub btnBrowseCustomImage3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseCustomImage3.Click
        BrowseCustomImageClick(Browser3FileDialog, Browser3ImagePath, Browser3Image)
    End Sub

    Private Sub btnBrowseCustomImage4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseCustomImage4.Click
        BrowseCustomImageClick(Browser4FileDialog, Browser4ImagePath, Browser4Image)
    End Sub

    Private Sub btnBrowseCustomImage5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseCustomImage5.Click
        BrowseCustomImageClick(Browser5FileDialog, Browser5ImagePath, Browser5Image)
    End Sub

    Public Function OS_Version() As String

        Dim osInfo As OperatingSystem
        Dim sAns As String = ""

        osInfo = System.Environment.OSVersion

        With osInfo
            Select Case .Platform
                Case .Platform.Win32Windows
                    Select Case (.Version.Minor)
                        Case 0
                            sAns = "Windows 95"
                        Case 10
                            If .Version.Revision.ToString() = "2222A" Then
                                sAns = "Windows 98 Second Edition"
                            Else
                                sAns = "Windows 98"
                            End If
                        Case 90
                            sAns = "Windows Me"
                    End Select
                Case .Platform.Win32NT
                    Select Case (.Version.Major)
                        Case 3
                            sAns = "Windows NT 3.51"
                        Case 4
                            sAns = "Windows NT 4.0"
                        Case 5
                            If .Version.Minor = 0 Then
                                sAns = "Windows 2000"
                            ElseIf .Version.Minor = 1 Then
                                sAns = "Windows XP"
                            ElseIf .Version.Minor = 2 Then
                                sAns = "Windows Server 2003"
                            Else 'Future version maybe update
                                'as needed
                                sAns = "Unknown Windows Version"
                            End If
                        Case 6
                            If .Version.Minor = 0 Then
                                sAns = "Windows Vista"
                            ElseIf .Version.Minor = 1 Then
                                sAns = "Windows 7"
                            ElseIf .Version.Minor = 2 Then
                                sAns = "Windows 8"
                            Else 'Future version maybe update
                                'as needed
                                sAns = "Unknown Windows Version"
                            End If
                    End Select
                Case Else
                    sAns = "Unknown"

            End Select
        End With

        Return sAns
    End Function

    
End Class