Imports System.IO
Imports System.Reflection
Imports System.Security.Principal

'Imports Microsoft.WindowsAPICodePack.Taskbar

Module modStart
    Public gSettings As Settings
#If DEBUG = True Then
#If CONFIG = "Debug Update" Or CONFIG = "Debug Update and Pause" Then
    Public Const CurVersion As String = "DU"
    Public Const CurVersionDisplay As String = "Debug Update"
#Else
    Public Const CurVersion As String = "R2"
    Public Const CurVersionDisplay As String = ""
#End If
#Else
    Public Const CurVersion As String = "R1"
    Public Const CurVersionDisplay As String = ""
#End If

    Public Sub CheckForMigrateBeforeOptions(aScreen As frmOptions.SettingsStartPage)
        Logger.AddToLog("modStart.CheckForMigrateBeforeOptions", "Start", aScreen)
#If Importer = True Then
        Logger.AddToLog("modStart.CheckForMigrateBeforeOptions", "Migration Enabled", aScreen.ToString)
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
#Else
        Logger.AddToLog("modStart.CheckForMigrateBeforeOptions", "Migration Disabled", aScreen)
#End If

        Dim lFormToShow As New frmOptions
        lFormToShow.ShowForm(aScreen, False)

        Logger.AddToLog("modStart.CheckForMigrateBeforeOptions", "End", aScreen)
        Application.Run(lFormToShow) 'terrible, but it works
    End Sub

    Public Sub CheckForMigrateBeforeLaunch()
        Logger.AddToLog("modStart.CheckForMigrateBeforeLaunch", "Start")
#If Importer = True Then
        Logger.AddToLog("modStart.CheckForMigrateBeforeLaunch", "Migration Enabled")
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
#Else
        Logger.AddToLog("modStart.CheckForMigrateBeforeLaunch", "Migration Disabled")
#End If

        Logger.AddToLog("modStart.CheckForMigrateBeforeLaunch", "End")
        ContinueMain("")
    End Sub

    Public Sub LoadSettings()
        Logger.AddToLog("modStart.LoadSettings", "Start")
        If (File.Exists(Path.Combine(Application.StartupPath, Settings.BrowserChooserConfigFileName))) Then
            gSettings.PortableMode = True
            Logger.AddToLog("modStart.LoadSettings", "Is portable")
            gSettings = Settings.Load(Application.StartupPath)
        Else
            gSettings.PortableMode = False
            Logger.AddToLog("modStart.LoadSettings", "Is not portable")
            gSettings = Settings.Load(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\BrowserChooser2\")
        End If
        Logger.AddToLog("modStart.LoadSettings", "End")
    End Sub

    Private Function MatchURLs(ByVal aSource As String, ByVal aTarget As String) As Boolean
        Logger.AddToLog("modStart.MatchURLs", "Start", aSource, aTarget)
        'strip http(s):// from urls and strip www from urls
        Dim lsSource As String = aSource.Replace("http://", "").Replace("https://", "").Replace("www.", "")
        Dim lsTarget As String = aTarget.Replace("http://", "").Replace("https://", "").Replace("www.", "")

        'perform basic wilcard (regex to come later)
        If lsTarget Like lsSource Then
            Logger.AddToLog("modStart.MatchURLs", "End", aSource, aTarget, True)
            Return True
        Else
            Logger.AddToLog("modStart.MatchURLs", "End", aSource, aTarget, False)
            Return False
        End If
    End Function

    Public Sub ContinueMain(ByVal aURL As String)
        Logger.AddToLog("modStart.ContinueMain", "Start", aURL)
        'If Settings.LogDebugs = TriState.UseDefault Then
        '--log no specfified, turn off logging
        'Settings.LogDebugs = TriState.False
        'End If

        ' set the portable mode flag if we detect a config file in the same path
        Logger.AddToLog("modStart.ContinueMain", "Loading Settings", aURL)
        LoadSettings()

        'first things first, check for updates
        If gSettings.AutomaticUpdates = True Then
            Logger.AddToLog("modStart.ContinueMain", "Automatic Updates Enabled", aURL)
#If CONFIG = "Debug Update" Or CONFIG = "Debug Update and Pause" Or Not DEBUG Then
            'update desiabled in debug unless debuggin updates
            Updater.CheckForUpdate(True) ' will not return a value, runs in a thread.
#End If
        Else
            Logger.AddToLog("modStart.ContinueMain", "Automatic Updates Disabled", aURL)
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
            Logger.AddToLog("modStart.ContinueMain", "End Auto Launch Browser", aURL, lBrowser.Name)
            BrowserUtilities.LaunchBrowser(lBrowser, aURL, True) 'launch and die
        Else
            'skip checkking for migrate at this point - you have already set your settings
            Logger.AddToLog("modStart.ContinueMain", "Show Main Page", aURL)
            Dim lMain As New frmMain

            Dim lDelegate As New StartupLauncher.UpdateURL(AddressOf lMain.UpdateURL)

            If lDelay <> 0 Then
                StartupLauncher.SetURL(aURL, gSettings.RevealShortURL, lDelay, lBrowser, lDelegate)
            Else
                StartupLauncher.SetURL(aURL, gSettings.RevealShortURL, lDelegate)
            End If

            Logger.AddToLog("modStart.ContinueMain", "End", aURL)
            Application.Run(lMain)
        End If

    End Sub

    Public Sub Main()
        Logger.AddToLog("modStart.Main", "Starting App")
#If CONFIG = "DebugPauseOnStart" Or CONFIG = "Debug Update and Pause" Then
        MsgBox("Paused to attach")
#End If

        Dim lStartup As New StartupLauncher

        ' load the WindowsAPICodePack DLLs from the embedded resource allowing us to keep one tidy .exe and no dlls.
        'Dim currentDomain As AppDomain = AppDomain.CurrentDomain
        'AddHandler currentDomain.AssemblyResolve, AddressOf MyResolveEventHandler
        Application.EnableVisualStyles()

        If (My.Application.CommandLineArgs.Count > 0) Then
            For Each cmdLineOption As String In My.Application.CommandLineArgs
                Logger.AddToLog("modStart.Main", "Start Processing Command Line", cmdLineOption)

                If cmdLineOption.StartsWith("--") Then
                    Dim lbExit As Boolean = True

                    'special functions
                    Select Case cmdLineOption.ToLower
                        Case GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.Uninstall) '  "--Uninstall"
                            Logger.AddToLog("modStart.ContinueMain", "Remove All Keys")
                            DefaultBrowser.RemoveAllKeys(DefaultBrowser.Scope.sUser)
                        Case GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.Reinstall) '  "--reinstall"
                            'make default
                            Logger.AddToLog("modStart.ContinueMain", "Make Default")
                            DefaultBrowser.MakeDefault(DefaultBrowser.Scope.sUser) 'will do HKCU only
                        Case GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.HideIcons) ' "--hideicons"
                        'undo default, and hide traces
                        Case GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.ShowIcons) '"--showicons"
                        'do default, but show traces
                        Case GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.FirstRun) '"--firstrun"
                            're-run the start-up dialogs
                            'TODO: first run dialog, including addeing IE and co and registering as a browser
                            Logger.AddToLog("modStart.ContinueMain", "Launch Admin Mode")
                            GeneralUtilities.LaunchAdminMode(GeneralUtilities.ListOfCommands.MakeAvailable)
                        Case GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.Testadmin) ' "--testadmin"
                            'debug purposes only
                            Logger.AddToLog("modStart.ContinueMain", "Test Admin")
                            Dim lCode As Integer = GeneralUtilities.LaunchAdminMode(GeneralUtilities.ListOfCommands.Testadminint)
                            MessageBox.Show("ExitCode: " + lCode.ToString)
                        Case GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.Testadminint) '"--testadmin-int"
                            MessageBox.Show("Admin mode launched")
                            Environment.ExitCode = 1 'all good
                        Case GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.MakeAvailable) '"--makeavailable"
                            Logger.AddToLog("modStart.ContinueMain", "Make Available")
#If CONFIG = "Debug Admin" Then
                        MsgBox("Paused to attach")
#End If
                            LoadSettings()
                            DefaultBrowser.MakeAvailable(DefaultBrowser.Scope.sGlobal) ' used by admin mode, so is global

                        Case GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.MakeDefault) ' "--makedefault"
                            Logger.AddToLog("modStart.ContinueMain", "MakeDefault")
#If CONFIG = "Debug Admin" Then
                        MsgBox("Paused to attach")
#End If
                            LoadSettings()
                            DefaultBrowser.MakeDefault(DefaultBrowser.Scope.sGlobal)
                        Case GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.ApplyUpdate) ' "--applyupdate"
                            Logger.AddToLog("modStart.ContinueMain", "ApplyUpdate")
                            If My.Application.CommandLineArgs.Count > 1 Then
                                Updater.ApplyUpdate(My.Application.CommandLineArgs.Item(1))
                            Else
                                Updater.ApplyUpdate("")
                            End If
                        Case GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.FinishApplyUpdate) ' "--finishapplyupdate"
                            Logger.AddToLog("modStart.ContinueMain", "Finish Apply Update")
                            Updater.FinishApplyUpdate()
                            lbExit = False
#If CONFIG = "BuildDetectionFile" Then
                    Case Utility.AvailableCommands.Item(Utility.ListOfCommands.BuildDetectionFile)
                        DetectedBrowsers.ExportDetection()
                        MessageBox.Show("Detection file exported to ""C:\temp\DetectedBrowsers.xml""", "Browser Chooser 2 - Detection File Exporter", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End
#End If
                        Case GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.Settings),
                        GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SSettings),
                        GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SettingsBrowsers),
                        GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SettingsBrowsers)
                            Logger.AddToLog("modStart.ContinueMain", "Settings / Settings = Browsers")

                            LoadSettings()
                            CheckForMigrateBeforeOptions(frmOptions.SettingsStartPage.SettingsBrowsers)
                        Case GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SettingsAutoURLs),
                        GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SSettingsAutoURLs)
                            Logger.AddToLog("modStart.ContinueMain", "Settings - Auto URLs")

                            LoadSettings()
                            CheckForMigrateBeforeOptions(frmOptions.SettingsStartPage.SettingsAutoURLs)

                        Case GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SettingsProtocols),
                        GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SSettingsProtocols)
                            Logger.AddToLog("modStart.ContinueMain", "Settings - Protocols")

                            LoadSettings()
                            CheckForMigrateBeforeOptions(frmOptions.SettingsStartPage.SettingsProtocols)
                        Case GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SettingsFileTypes),
                        GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SSettingsFileTypes)
                            Logger.AddToLog("modStart.ContinueMain", "Settings - FileTypes")

                            LoadSettings()
                            CheckForMigrateBeforeOptions(frmOptions.SettingsStartPage.SettingsFileTypes)
                        Case GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SettingsCategories),
                        GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SSettingsCategories)
                            Logger.AddToLog("modStart.ContinueMain", "Settings - Categories")

                            LoadSettings()
                            CheckForMigrateBeforeOptions(frmOptions.SettingsStartPage.SettingsCategories)
                        Case GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SettingsSettings),
                        GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SSettingsSettings)
                            Logger.AddToLog("modStart.ContinueMain", "Settings")

                            LoadSettings()
                            CheckForMigrateBeforeOptions(frmOptions.SettingsStartPage.SettingsSettings)
                        Case GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SettingsMoreSettings),
                        GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SSettingsMoreSettings)
                            Logger.AddToLog("modStart.ContinueMain", "Settings - More Settings")

                            LoadSettings()
                            CheckForMigrateBeforeOptions(frmOptions.SettingsStartPage.SettingsMoreSettings)
                        Case GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SettingsDefaultBrowser),
                        GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SSettingsDefaultBrowser)
                            Logger.AddToLog("modStart.ContinueMain", "Settings - Default")

                            LoadSettings()
                            CheckForMigrateBeforeOptions(frmOptions.SettingsStartPage.SettingsDefaultBrowser)


                        Case GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.LoggingEnabled)
                            Logger.AddToLog("modStart.ContinueMain", "Enable Logging")

                            'logging
                            Settings.LogDebugs = TriState.True
                            lbExit = False
                    End Select

                    If lbExit = True Then
                        Logger.AddToLog("modStart.ContinueMain", "Exiting")
                        Application.Exit()
                    Else
                        Logger.AddToLog("modStart.ContinueMain", "Update complete")
                        'update complete! ready to go!
                        If My.Application.CommandLineArgs.Count > 1 Then
                            Logger.AddToLog("modStart.ContinueMain", "Using Last Args")
                            ContinueMain(My.Application.CommandLineArgs.Last)
                        Else
                            Logger.AddToLog("modStart.ContinueMain", "No Args")
                            ContinueMain("")
                        End If

                        Exit For
                    End If

                Else
                    Logger.AddToLog("modStart.ContinueMain", "Only one Arg")
                    ContinueMain(cmdLineOption)
                End If
            Next
        Else
            Logger.AddToLog("modStart.ContinueMain", "CheckForMigrateBeforeLaunch")
            CheckForMigrateBeforeLaunch()
        End If
    End Sub
End Module