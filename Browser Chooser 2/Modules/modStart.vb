Imports System.IO
Imports System.Reflection
Imports System.Security.Principal

'Imports Microsoft.WindowsAPICodePack.Taskbar

Module modStart
    Public gSettings As Settings
#If Debug = True Then
#If CONFIG = "Debug Update" Or config = "Debug Update and Pause" Then
    Public Const CurVersion As String = "DU"
    Public Const CurVersionDisplay As String = "Debug Update"
#Else
    Public Const CurVersion As String = "B3"
    Public Const CurVersionDisplay As String = "Beta 3"
#End If
#Else
    Public Const CurVersion As String = "B3"
    Public Const CurVersionDisplay As String = "Beta 3"
#End If

    Public Sub CheckForMigrateBeforeOptions(aScreen As frmOptions.SettingsStartPage)
        'if old XML file found and not the new one, ask to migrate - portable mode
        If File.Exists(Path.Combine(Application.StartupPath, LegacyNS.Legacy.Settings.BrowserChooserConfigFileName)) Then
            'see if current doesn't exists
            If Not File.Exists(Path.Combine(Application.StartupPath, Settings.BrowserChooserConfigFileName)) Then
                If GeneralUtilities.SafeMessagebox("Do you want to import the settings from BrowserChooser 1?", "First Run", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Dim lImporter As New Importer(Path.Combine(Application.StartupPath, LegacyNS.Legacy.Settings.BrowserChooserConfigFileName))

                End If
            End If
        ElseIf File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\BrowserChooser\" & LegacyNS.Legacy.Settings.BrowserChooserConfigFileName) Then
            'non portable mode
            If Not File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\BrowserChooser2\" & Settings.BrowserChooserConfigFileName) Then
                If GeneralUtilities.SafeMessagebox("Do you want to import the settings from BrowserChooser 1?", "First Run", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Dim lImporter As New Importer(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\BrowserChooser\" & LegacyNS.Legacy.Settings.BrowserChooserConfigFileName)

                End If
            End If
        End If

        Dim lFormToShow As New frmOptions
        lFormToShow.ShowForm(aScreen, False)
        Application.Run(lFormToShow) 'terrible, but it works
    End Sub

    Public Sub CheckForMigrateBeforeLaunch()
        'if old XML file found and not the new one, ask to migrate - portable mode
        If File.Exists(Path.Combine(Application.StartupPath, LegacyNS.Legacy.Settings.BrowserChooserConfigFileName)) Then
            'see if current doesn't exists
            If Not File.Exists(Path.Combine(Application.StartupPath, Settings.BrowserChooserConfigFileName)) Then
                If GeneralUtilities.SafeMessagebox("Do you want to import the settings from BrowserChooser 1?", "First Run", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Dim lImporter As New Importer(Path.Combine(Application.StartupPath, LegacyNS.Legacy.Settings.BrowserChooserConfigFileName))

                End If
            End If
        ElseIf File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\BrowserChooser\" & LegacyNS.Legacy.Settings.BrowserChooserConfigFileName) Then
            'non portable mode
            If Not File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\BrowserChooser2\" & Settings.BrowserChooserConfigFileName) Then
                If GeneralUtilities.SafeMessagebox("Do you want to import the settings from BrowserChooser 1?", "First Run", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Dim lImporter As New Importer(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\BrowserChooser\" & LegacyNS.Legacy.Settings.BrowserChooserConfigFileName)

                End If
            End If
        End If

        ContinueMain("")
    End Sub

    Public Sub LoadSettings()
        If (File.Exists(Path.Combine(Application.StartupPath, Settings.BrowserChooserConfigFileName))) Then
            gSettings.PortableMode = True
            gSettings = Settings.Load(Application.StartupPath)
        Else
            gSettings.PortableMode = False
            gSettings = Settings.Load(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\BrowserChooser2\")
        End If
    End Sub

    Private Function MatchURLs(ByVal aSource As String, ByVal aTarget As String) As Boolean
        'strip http(s):// from urls and strip www from urls
        Dim lsSource As String = aSource.Replace("http://", "").Replace("https://", "").Replace("www.", "")
        Dim lsTarget As String = aTarget.Replace("http://", "").Replace("https://", "").Replace("www.", "")

        'perform basic wilcard (regex to come later)
        If lsTarget Like lsSource Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub ContinueMain(ByVal aURL As String)
        ' set the portable mode flag if we detect a config file in the same path
        LoadSettings()

        'first things first, check for updates
        If gSettings.AutomaticUpdates = True Then
#If CONFIG = "Debug Update" Or CONFIG = "Debug Update and Pause" Or Not Debug Then
            'update desiabled in debug unless debuggin updates
            Updater.CheckForUpdate(True) ' will not return a value, runs in a thread.
#End If
        End If

        If gSettings.CheckDefaultOnLaunch = True And GeneralUtilities.IsRunningPost8 = False Then
            DefaultBrowser.CheckIfIsDefault()
        End If

        'see if URl is in list of URLs, which browser to use
        Dim lBrowser As Browser = Nothing '= BrowserConfig.GetBrowserByUrl(strUrl)
        Dim lDelay As Integer = 0

        If aURL <> "" Then
            'ignore pattern match if no url provided
            For Each lURL As URL In gSettings.URLs
                If MatchURLs(lURL.URL, aURL) Then
                    'load that browser
                    If lURL.DelayTime = 0 And lURL.AutoLoad = True Then
                        lBrowser = BrowserUtilities.GetBrowserByGUID(lURL.Guid)
                        Exit For

                    ElseIf lURL.DelayTime = -1 Then
                        'look at system setting
                        If gSettings.DefaultDelay <= 0 Then
                            lBrowser = BrowserUtilities.GetBrowserByGUID(lURL.Guid)
                            Exit For
                        Else
                            'launch mainscreen with delay
                            lBrowser = BrowserUtilities.GetBrowserByGUID(lURL.Guid)
                            lDelay = gSettings.DefaultDelay
                        End If
                    Else
                        'launch mainscreen with delay
                        lBrowser = BrowserUtilities.GetBrowserByGUID(lURL.Guid)
                        lDelay = lURL.DelayTime
                    End If

                    Exit For 'first match - look into a stop processing rule (that would be on by default)
                End If
            Next
        End If

        If IsNothing(lBrowser) = False And lDelay = 0 Then
            BrowserUtilities.LaunchBrowser(lBrowser, aURL, True) 'launch and die
        Else
            'skip checkking for migrate at this point - you have already set your settings
            Dim lMain As New frmMain

            Dim lDelegate As New StartupLauncher.UpdateURL(AddressOf lMain.UpdateURL)

            If lDelay <> 0 Then
                StartupLauncher.SetURL(aURL, gSettings.RevealShortURL, lDelay, lBrowser, lDelegate)
            Else
                StartupLauncher.SetURL(aURL, gSettings.RevealShortURL, lDelegate)
            End If

            Application.Run(lMain)
        End If
        'End If
    End Sub

    Public Sub Main()
#If CONFIG = "DebugPauseOnStart" Or CONFIG = "Debug Update and Pause" Then
        MsgBox("Paused to attach")
#End If

        Dim lStartup As New StartupLauncher

        ' load the WindowsAPICodePack DLLs from the embedded resource allowing us to keep one tidy .exe and no dlls.
        'Dim currentDomain As AppDomain = AppDomain.CurrentDomain
        'AddHandler currentDomain.AssemblyResolve, AddressOf MyResolveEventHandler
        Application.EnableVisualStyles()

        If (My.Application.CommandLineArgs.Count > 0) Then
            Dim cmdLineOption As String = My.Application.CommandLineArgs.Item(0)

            If (cmdLineOption = "gooptions") Or gSettings Is Nothing Then
                'note that this part is semi deprecated. gooptions is the BC1 way and may break in the future. use --settings or --s
                LoadSettings()
                CheckForMigrateBeforeOptions(frmOptions.SettingsStartPage.SettingsBrowsers)
            ElseIf cmdLineOption.StartsWith("--") Then
                Dim lbExit As Boolean = True

                'special functions
                Select Case cmdLineOption.ToLower
                    Case GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.Reinstall) '  "--reinstall"
                        'make default
                        DefaultBrowser.MakeDefault(DefaultBrowser.Scope.sUser) 'will do HKCU only
                    Case GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.HideIcons) ' "--hideicons"
                        'undo default, and hide traces
                    Case GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.ShowIcons) '"--showicons"
                        'do default, but show traces
                    Case GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.FirstRun) '"--firstrun"
                        're-run the start-up dialogs
                        'TODO: first run dialog, including addeing IE and co and registering as a browser
                        GeneralUtilities.LaunchAdminMode(GeneralUtilities.ListOfCommands.MakeAvailable)
                    Case GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.Testadmin) ' "--testadmin"
                        'debug purposes only
                        Dim lCode As Integer = GeneralUtilities.LaunchAdminMode(GeneralUtilities.ListOfCommands.Testadminint)
                        MessageBox.Show("ExitCode: " + lCode.ToString)
                    Case GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.Testadminint) '"--testadmin-int"
                        MessageBox.Show("Admin mode launched")
                        Environment.ExitCode = 1 'all good
                    Case GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.MakeAvailable) '"--makeavailable"
#If CONFIG = "Debug Admin" Then
                        MsgBox("Paused to attach")
#End If
                        LoadSettings()
                        DefaultBrowser.MakeAvailable(DefaultBrowser.Scope.sGlobal) ' used by admin mode, so is global

                    Case GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.MakeDefault) ' "--makedefault"
#If CONFIG = "Debug Admin" Then
                        MsgBox("Paused to attach")
#End If
                        LoadSettings()
                        DefaultBrowser.MakeDefault(DefaultBrowser.Scope.sGlobal)
                    Case GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.ApplyUpdate) ' "--applyupdate"
                        If My.Application.CommandLineArgs.Count > 1 Then
                            Updater.ApplyUpdate(My.Application.CommandLineArgs.Item(1))
                        Else
                            Updater.ApplyUpdate("")
                        End If
                    Case GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.FinishApplyUpdate) ' "--finishapplyupdate"
                        Updater.FinishApplyUpdate()
                        lbExit = False
#If CONFIG = "BuildDetectionFile" Then
                    Case Utility.AvailableCommands.Item(Utility.ListOfCommands.BuildDetectionFile)
                        DetectedBrowsers.ExportDetection()
                        MessageBox.Show("Detection file exported to ""C:\temp\DetectedBrowsers.xml""", "Browser Chooser 2 - Detection File Exporter", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End
#End If
                    Case GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.Settings), _
                        GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SSettings), _
                        GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SettingsBrowsers), _
                        GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SettingsBrowsers)

                        LoadSettings()
                        CheckForMigrateBeforeOptions(frmOptions.SettingsStartPage.SettingsBrowsers)
                    Case GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SettingsAutoURLs), _
                        GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SSettingsAutoURLs)

                        LoadSettings()
                        CheckForMigrateBeforeOptions(frmOptions.SettingsStartPage.SettingsAutoURLs)

                    Case GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SettingsProtocols), _
                        GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SSettingsProtocols)

                        LoadSettings()
                        CheckForMigrateBeforeOptions(frmOptions.SettingsStartPage.SettingsProtocols)
                    Case GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SettingsFileTypes), _
                        GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SSettingsFileTypes)

                        LoadSettings()
                        CheckForMigrateBeforeOptions(frmOptions.SettingsStartPage.SettingsFileTypes)
                    Case GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SettingsCategories), _
                        GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SSettingsCategories)

                        LoadSettings()
                        CheckForMigrateBeforeOptions(frmOptions.SettingsStartPage.SettingsCategories)
                    Case GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SettingsSettings), _
                        GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SSettingsSettings)

                        LoadSettings()
                        CheckForMigrateBeforeOptions(frmOptions.SettingsStartPage.SettingsSettings)
                    Case GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SettingsMoreSettings), _
                        GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SSettingsMoreSettings)

                        LoadSettings()
                        CheckForMigrateBeforeOptions(frmOptions.SettingsStartPage.SettingsMoreSettings)
                    Case GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SettingsDefaultBrowser), _
                        GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SSettingsDefaultBrowser)

                        LoadSettings()
                        CheckForMigrateBeforeOptions(frmOptions.SettingsStartPage.SettingsDefaultBrowser)


                    Case GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.LoggingEnabled)
                        'logging
                        Settings.LogDebugs = True
                End Select

                If lbExit = True Then
                    Application.Exit()
                Else
                    'update complete! ready to go!
                    If My.Application.CommandLineArgs.Count > 1 Then
                        ContinueMain(My.Application.CommandLineArgs.Item(1))
                    Else
                        ContinueMain("")
                    End If
                End If
            Else
                    ContinueMain(cmdLineOption)
            End If
        Else
            CheckForMigrateBeforeLaunch()
        End If
    End Sub
End Module