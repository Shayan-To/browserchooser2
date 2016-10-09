Imports System.IO
Imports System.Reflection
Imports System.Security.Principal
Imports BC2_Common

'Imports Microsoft.WindowsAPICodePack.Taskbar

Module modStart
    Public Sub LoadSettings()
        If (File.Exists(Path.Combine(Application.StartupPath, Settings.BrowserChooserConfigFileName))) Then
            Globals.gSettings.PortableMode = True
            Globals.gSettings = Settings.Load(Application.StartupPath)
        Else
            Globals.gSettings.PortableMode = False
            Globals.gSettings = Settings.Load(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\BrowserChooser2\")
        End If
    End Sub

    Public Sub ContinueMain(ByVal aURL As String)
        ' set the portable mode flag if we detect a config file in the same path
        LoadSettings()

        'first things first, check for updates
        If Globals.gSettings.AutomaticUpdates = True Then
#If CONFIG = "Debug Update" Or CONFIG = "Debug Update and Pause" Or Not DEBUG Then
            'update desiabled in debug unless debuggin updates
            Updater.CheckForUpdate(True) ' will not return a value, runs in a thread.
#End If
        End If

        If Globals.gSettings.CheckDefaultOnLaunch = True And GeneralUtilities.IsRunningPost8 = False Then
            DefaultBrowser.CheckIfIsDefault()
        End If

        'see if URl is in list of URLs, which browser to use
        Dim lBrowser As Browser = Nothing '= BrowserConfig.GetBrowserByUrl(strUrl)
        Dim lDelay As Integer = 0

        If aURL <> "" Then
            'ignore pattern match if no url provided
            For Each lURL As URL In Globals.gSettings.URLs
                If URLUtilities.MatchURLs(lURL.URL, aURL) Then
                    'load that browser
                    If lURL.DelayTime = 0 And lURL.AutoLoad = True Then
                        lBrowser = BrowserUtilities.GetBrowserByGUID(lURL.Guid)
                        Exit For

                    ElseIf lURL.DelayTime = -1 Then
                        'look at system setting
                        If Globals.gSettings.DefaultDelay <= 0 Then
                            lBrowser = BrowserUtilities.GetBrowserByGUID(lURL.Guid)
                            Exit For
                        Else
                            'launch mainscreen with delay
                            lBrowser = BrowserUtilities.GetBrowserByGUID(lURL.Guid)
                            lDelay = Globals.gSettings.DefaultDelay
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
            'If UI ==== classic
            Dim lMain As New BC2ClassicUI.vmMain

            Dim lDelegate As New StartupLauncher.UpdateURL(AddressOf lMain.UpdateURL)

            If lDelay <> 0 Then
                Globals.gStartupLauncher.SetURL(aURL, Globals.gSettings.RevealShortURL, lDelay, lBrowser, lDelegate)
            Else
                Globals.gStartupLauncher.SetURL(aURL, Globals.gSettings.RevealShortURL, lDelegate)
            End If

            'Application.Run(lMain)
#If UI = "Classic" Then
            'classic launch
            Dim lvmMain As New BC2ClassicUI.vmMain
            lvmMain.frmMain(Globals.gSettings, Globals.gStartupLauncher)
#Else
            'wpf launch
#End If
        End If
        'End If
    End Sub

    Private Sub StartOptions(aScreen As frmOptions.SettingsStartPage)
        'Dim lFormToShow As New frmOptions
        'lFormToShow.ShowForm(aScreen, False)
        'Application.Run(lFormToShow) 'terrible, but it works
    End Sub

    Public Sub Main()
#If CONFIG = "DebugPauseOnStart" Or CONFIG = "Debug Update and Pause" Then
        MsgBox("Paused to attach")
#End If

        Globals.gStartupLauncher = New StartupLauncher
#If DisableV1 = False Then
        Dim lCheck As New BC2_Common.StartChecks
#End If

        ' load the WindowsAPICodePack DLLs from the embedded resource allowing us to keep one tidy .exe and no dlls.
        'Dim currentDomain As AppDomain = AppDomain.CurrentDomain
        'AddHandler currentDomain.AssemblyResolve, AddressOf MyResolveEventHandler
        Application.EnableVisualStyles()

        If (My.Application.CommandLineArgs.Count > 0) Then
            Dim cmdLineOption As String = My.Application.CommandLineArgs.Item(0)

            If (cmdLineOption = "gooptions") Or Globals.gSettings Is Nothing Then
                'note that this part is semi deprecated. gooptions is the BC1 way and may break in the future. use --settings or --s
                LoadSettings()
#If DisableV1 = False Then
                lCheck.CheckForMigrateBeforeOptions()
#End If
                StartOptions(frmOptions.SettingsStartPage.SettingsBrowsers)
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
                    Case GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.Settings),
                        GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SSettings),
                        GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SettingsBrowsers),
                        GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SettingsBrowsers)

                        LoadSettings()
#If DisableV1 = False Then
                        lCheck.CheckForMigrateBeforeOptions()
#End If
                        StartOptions(frmOptions.SettingsStartPage.SettingsBrowsers)
                    Case GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SettingsAutoURLs),
                        GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SSettingsAutoURLs)

                        LoadSettings()
#If DisableV1 = False Then
                        lCheck.CheckForMigrateBeforeOptions()
#End If
                        StartOptions(frmOptions.SettingsStartPage.SettingsAutoURLs)

                    Case GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SettingsProtocols),
                        GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SSettingsProtocols)

                        LoadSettings()
#If DisableV1 = False Then
                        lCheck.CheckForMigrateBeforeOptions()
#End If
                        StartOptions(frmOptions.SettingsStartPage.SettingsProtocols)
                    Case GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SettingsFileTypes),
                        GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SSettingsFileTypes)

                        LoadSettings()
#If DisableV1 = False Then
                        lCheck.CheckForMigrateBeforeOptions()
#End If
                        StartOptions(frmOptions.SettingsStartPage.SettingsFileTypes)
                    Case GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SettingsCategories),
                        GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SSettingsCategories)

                        LoadSettings()
#If DisableV1 = False Then
                        lCheck.CheckForMigrateBeforeOptions()
#End If
                        StartOptions(frmOptions.SettingsStartPage.SettingsCategories)
                    Case GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SettingsSettings),
                        GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SSettingsSettings)

                        LoadSettings()
#If DisableV1 = False Then
                        lCheck.CheckForMigrateBeforeOptions()
#End If
                        StartOptions(frmOptions.SettingsStartPage.SettingsSettings)
                    Case GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SettingsMoreSettings),
                        GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SSettingsMoreSettings)

                        LoadSettings()
#If DisableV1 = False Then
                        lCheck.CheckForMigrateBeforeOptions()
#End If
                        StartOptions(frmOptions.SettingsStartPage.SettingsMoreSettings)
                    Case GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SettingsDefaultBrowser),
                        GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.SSettingsDefaultBrowser)

                        LoadSettings()
#If DisableV1 = False Then
                        lCheck.CheckForMigrateBeforeOptions()
#End If
                        StartOptions(frmOptions.SettingsStartPage.SettingsDefaultBrowser)


                    Case GeneralUtilities.AvailableCommands.Item(GeneralUtilities.ListOfCommands.LoggingEnabled)
                        'logging
                        Settings.LogDebugs = True
                End Select

                If lbExit = True Then
                    CleanUp.DoExit()
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
#If DisableV1 = False Then
            lCheck.CheckForMigrateBeforeLaunch()
#End If
            ContinueMain("")
        End If
    End Sub
End Module