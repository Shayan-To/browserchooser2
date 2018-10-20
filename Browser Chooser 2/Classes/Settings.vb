Imports System.Xml.Serialization
Imports System.IO

<Serializable()> _
Public Class Settings
    Public Const CURRRENT_FILE_VERSION As Integer = 5 'will be used later for upgrade detection
    '   NOTE: Version 2 adds the protocol and file types - automaticly added
    '   NOTE: Version 3 redoes the protocols and file types, adds accessiblity settings
    '   NOTE: Version 4 redoes the accessiblity settings and mimics v3
    '   NOTE: Several Settings were added in Beta 2 but did not required a version bump.
    '   NOTE: Version 5 is to check for the registry. If cancel, don't update version

    Public Enum AvailableStartingPositions
        CenterScreen
        OffsetCenter
        XY
        TopLeft
        TopRight
        BottomLeft
        BottomRight
        OffsetTopLeft
        OffsetTopRight
        OffsetBottomLeft
        OffsetBottomRight
        Seperator1 = -1
        Seperator2 = -2
        Seperator3 = -3
    End Enum

    Public Enum DefaultField
        FileVersion
        IconWidth
        IconHeight
        IconGapWidth
        IconGapHeight
        IconScale
        OptionsShortcut
        DefaultMessage
        DefaultDelay
        AutomaticUpdates
        CheckDefaultOnLaunch
        AdvancedScreens
        Seperator
        UseAreo
        FocusBoxLineWidth
        FocusBoxColor
        UserAgent
        DownloadDetectionFile
        BackgroundColor
        StartingPosition
        OffsetX
        OffsetY
        AllowStayOpen
        Canonicalize
        CanonicalizeAppendedText
        EnableLogging
        ExtractDLLs
    End Enum
    'doing the defaults this way allows me refer to them later
    <NonSerialized()>
    Public Defaults As New Dictionary(Of DefaultField, Object) From {
        {DefaultField.FileVersion, CURRRENT_FILE_VERSION},
        {DefaultField.IconWidth, 75},
        {DefaultField.IconHeight, 80},
        {DefaultField.IconGapWidth, 0},
        {DefaultField.IconGapHeight, 0},
        {DefaultField.IconScale, 1D},
        {DefaultField.OptionsShortcut, "O"c},
        {DefaultField.DefaultMessage, "Choose a Browser"},
        {DefaultField.DefaultDelay, 0},
        {DefaultField.AutomaticUpdates, True},
        {DefaultField.CheckDefaultOnLaunch, False},
        {DefaultField.AdvancedScreens, False},
        {DefaultField.Seperator, " - "},
        {DefaultField.UseAreo, True},
        {DefaultField.FocusBoxLineWidth, 1},
        {DefaultField.FocusBoxColor, Color.Transparent.ToArgb},
        {DefaultField.UserAgent, "Mozilla/5.0"},
        {DefaultField.DownloadDetectionFile, True},
        {DefaultField.BackgroundColor, Color.Transparent.ToArgb},
        {DefaultField.StartingPosition, AvailableStartingPositions.CenterScreen},
        {DefaultField.OffsetX, 0},
        {DefaultField.OffsetY, 0},
        {DefaultField.AllowStayOpen, False},
        {DefaultField.Canonicalize, False},
        {DefaultField.CanonicalizeAppendedText, ""},
        {DefaultField.EnableLogging, False},
        {DefaultField.ExtractDLLs, False}
    }

    Public Const BrowserChooserConfigFileName As String = "BrowserChooser2Config.xml"
    Public Browsers As List(Of Browser)
    Public PortableMode As Boolean
    Public ShowURL As Boolean
    Public RevealShortURL As Boolean
    Public FileVersion As Integer = DirectCast(Defaults(DefaultField.FileVersion), Integer) '  CURRRENT_FILE_VERSION
    Public Protocols As List(Of Protocol)
    Public FileTypes As List(Of FileType)
    Public URLs As List(Of URL)
    Public Width As Integer
    Public Height As Integer
    Public IconWidth As Integer = DirectCast(Defaults(DefaultField.IconWidth), Integer)
    Public IconHeight As Integer = DirectCast(Defaults(DefaultField.IconHeight), Integer)
    Public IconGapWidth As Integer = DirectCast(Defaults(DefaultField.IconGapWidth), Integer)
    Public IconGapHeight As Integer = DirectCast(Defaults(DefaultField.IconGapHeight), Integer)
    Public IconScale As Decimal = DirectCast(Defaults(DefaultField.IconScale), Decimal)
    Public OptionsShortcut As Char = DirectCast(Defaults(DefaultField.OptionsShortcut), Char)
    Public DefaultMessage As String = DirectCast(Defaults(DefaultField.DefaultMessage), String)
    Public DefaultDelay As Integer = DirectCast(Defaults(DefaultField.DefaultDelay), Integer)
    Public AutomaticUpdates As Boolean = DirectCast(Defaults(DefaultField.AutomaticUpdates), Boolean)
    Public CheckDefaultOnLaunch As Boolean = DirectCast(Defaults(DefaultField.CheckDefaultOnLaunch), Boolean)
    Public AdvancedScreens As Boolean = DirectCast(Defaults(DefaultField.AdvancedScreens), Boolean)
    Public Seperator As String = DirectCast(Defaults(DefaultField.Seperator), String)
    Public AccessibleRendering As Boolean 'true only if a screen reader is detected
    Public ShowFocus As Boolean 'determines if we show the black box around the main screen elements
    Public UseAreo As Boolean = DirectCast(Defaults(DefaultField.UseAreo), Boolean) ' incase the user prefers not to have the fancy background
    Public FocusBoxLineWidth As Integer = DirectCast(Defaults(DefaultField.FocusBoxLineWidth), Integer)
    Public FocusBoxColor As Integer = DirectCast(Defaults(DefaultField.FocusBoxColor), Integer)
    Public UserAgent As String = DirectCast(Defaults(DefaultField.UserAgent), String)
    Public DownloadDetectionFile As Boolean = DirectCast(Defaults(DefaultField.DownloadDetectionFile), Boolean)
    Public BackgroundColor As Integer = DirectCast(Defaults(DefaultField.BackgroundColor), Integer)
    Public StartingPosition As Integer = DirectCast(Defaults(DefaultField.StartingPosition), Integer)
    Public OffsetX As Integer = DirectCast(Defaults(DefaultField.OffsetX), Integer)
    Public OffsetY As Integer = DirectCast(Defaults(DefaultField.OffsetY), Integer)
    Public AllowStayOpen As Boolean = DirectCast(Defaults(DefaultField.AllowStayOpen), Boolean) 'new behaviour in R1
    Public Canonicalize As Boolean = DirectCast(Defaults(DefaultField.Canonicalize), Boolean) 'new behaviour in R2
    Public CanonicalizeAppendedText As String = DirectCast(Defaults(DefaultField.UserAgent), String) 'new behavoir in R2
    Public EnableLogging As Boolean = DirectCast(Defaults(DefaultField.CanonicalizeAppendedText), Boolean) 'new behavior in R2
    Public ExtractDLLs As Boolean = DirectCast(Defaults(DefaultField.ExtractDLLs), Boolean) 'new behavior in R2

    <NonSerialized()> Public SafeMode As Boolean = False 'only true when the file could not be read - prevents saving
    <NonSerialized()> Public Shared LogDebugs As TriState = TriState.UseDefault 'only true if specified by command line
    <NonSerialized()> Public Shared DoExtractDLLs As Boolean = False 'only true if specified by command line

    Sub New(ByVal aError As Boolean)
        Logger.AddToLog("Settings.New (With Args)", "Start", aError)
        SharedNew()
        If aError = True Then SafeMode = True
        Dim lBrowsers As List(Of Browser) = DetectedBrowsers.DoBrowserDetection()

        Dim lY As Integer = 1

        For Each lSingleBrowser As Browser In lBrowsers
            If lSingleBrowser.PosX > 5 Then
                'recalculate position
                lSingleBrowser.PosY = CInt(Math.Ceiling(lSingleBrowser.PosX / 5))
                lSingleBrowser.PosX = lSingleBrowser.PosX Mod 5

                If lSingleBrowser.PosX = 0 Then
                    lSingleBrowser.PosX = 5
                End If
            End If

            Browsers.Add(lSingleBrowser)
        Next

        'readjust hight
        Height = CInt(Math.Ceiling(lBrowsers.Count / 5))

        Dim lGUIDs As New List(Of Guid)
        For Each lBrowser In Browsers
            lGUIDs.Add(lBrowser.GUID)
        Next

        Dim lDefaultCategories As New List(Of String) From {
            GeneralUtilities.DEFAULT_CATEGORY
        }
        CreateDefaultProtocols(lGUIDs, lDefaultCategories)
        CreateDefaultFileTypes(lGUIDs, lDefaultCategories)

        'determine if a SR is present, if yes, turn on accessible rendering
        Dim lResult As Boolean = False
        Dim lAPIResult As Boolean = WinAPIs.SystemParametersInfo(WinAPIs.SPI_GETSCREENREADER, 0, lResult, 0)
        'MessageBox.Show(lAPIResult.ToString & ":" & lResult.ToString & ":" & CInt(False))
        If lResult = True And lAPIResult = True Then
            'turn on accessible rendering
            AccessibleRendering = True
            ShowFocus = True
        Else
            AccessibleRendering = False
            ShowFocus = False
        End If

        'now save the file
        DoSave(False)
        'Save(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\BrowserChooser2\")
        Logger.AddToLog("Settings.New (With Args)", "End", aError)
    End Sub

    Private Sub CreateDefaultProtocols(ByVal aBrowsers As List(Of Guid), ByVal aDefaultCategories As List(Of String))
        Logger.AddToLog("Settings.CreateDefaultProtocols", "Start")
        'xhtml, .xht, .shtml .html, and .htm are defaults
        'ftp and ftps will also be created but not associated with any built-in tool
        FileTypes = New List(Of FileType) From {
            New FileType("XHTML", "xhtml", aBrowsers, aDefaultCategories),
            New FileType("XHT", "xht", aBrowsers, aDefaultCategories),
            New FileType("SHTML", "shtml", aBrowsers, aDefaultCategories),
            New FileType("HTML", "html", aBrowsers, aDefaultCategories),
            New FileType("HTM", "htm", aBrowsers, aDefaultCategories)
        }
        Logger.AddToLog("Settings.CreateDefaultProtocols", "End")
    End Sub

    Private Sub CreateDefaultFileTypes(ByVal aBrowsers As List(Of Guid), ByVal aDefaultCategories As List(Of String))
        Logger.AddToLog("Settings.CreateDefaultFileTypes", "Start")
        'http and https are defaults
        'ftp and ftps will also be created but not associated with any built-in tool
        Protocols = New List(Of Protocol) From {
            New Protocol("HTTP", "http", aBrowsers, aDefaultCategories),
            New Protocol("Secure HTTP", "https", aBrowsers, aDefaultCategories),
            New Protocol("FTP", "ftp", aBrowsers, aDefaultCategories),
            New Protocol("Secure FTP", "ftps", aBrowsers, aDefaultCategories),
            New Protocol("URL Shortcut", "url", aBrowsers, aDefaultCategories)
        }
        Logger.AddToLog("Settings.CreateDefaultFileTypes", "End")
    End Sub

    Private Sub SharedNew()
        Logger.AddToLog("Settings.SharedNew", "Start")
        Browsers = New List(Of Browser)
        URLs = New List(Of URL)
        PortableMode = False 'default
        RevealShortURL = False 'default
        ShowURL = True 'default
        Width = 5 'default
        Height = 1 'default
        Logger.AddToLog("Settings.SharedNew", "End")
    End Sub

    Sub New()
        Logger.AddToLog("Settings.New (No args)", "Start")
        SharedNew()
        Logger.AddToLog("Settings.New (No args)", "End")
    End Sub

    Private Sub IntSave(ByVal aPath As String)
        Logger.AddToLog("Settings.IntSave", "Start", aPath)
        If Me.SafeMode = True Then
            Logger.AddToLog("Settings.IntSave", "Safe Mode", aPath)
            Exit Sub 'do not save
        End If

        Dim f As New IO.DirectoryInfo(aPath)
        If Not f.Exists Then
            Logger.AddToLog("Settings.IntSave", "Creating Directory", aPath)
            IO.Directory.CreateDirectory(aPath)
        End If
        Dim xmlSerializer As New XmlSerializer(GetType(Settings)) 'may not work - need to test

        Using writer As Stream = New FileStream(Path.Combine(aPath, Settings.BrowserChooserConfigFileName), FileMode.Create)
            Logger.AddToLog("Settings.IntSave", "Writing", aPath)
            xmlSerializer.Serialize(writer, Me)
            writer.Close()
        End Using
        Logger.AddToLog("Settings.IntSave", "End", aPath)
    End Sub

    Public Sub DoSave(ByVal OverrideSafeMode As Boolean)
        Logger.AddToLog("Settings.DoSave", "Start", OverrideSafeMode)
        If Me.SafeMode = True And OverrideSafeMode = False Then Exit Sub 'do not save
        If Policy.IgnoreSettingsFile = True Then Exit Sub 'do not save, file is disabled
        If Me.PortableMode = True Then
            Me.IntSave(Application.StartupPath)
        Else
            Me.IntSave(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\BrowserChooser2\")
        End If
        Logger.AddToLog("Settings.DoSave", "End", OverrideSafeMode)
    End Sub

    Private Shared Sub CheckExtract(aPath As String)
        Dim configPath As String = Path.Combine(aPath, Settings.BrowserChooserConfigFileName)
        If IO.File.Exists(configPath) = False Then Exit Sub

        Dim lConfig() As String = File.ReadAllLines(configPath)

        For Each lSingle As String In lConfig
            If lSingle.ToLower.Contains("<extractdlls>true</extractdlls>") Then
                Settings.DoExtractDLLs = True
                Exit Sub
            End If
        Next
    End Sub

    Public Shared Function Load(ByVal aPath As String) As Settings
        Logger.AddToLog("Settings.Load", "Start", aPath)
        If Policy.IgnoreSettingsFile = True Then
            'basic new - add policy later
            Return New Settings(False)
        End If
        CheckExtract(aPath)
        Dim serializer As New XmlSerializer(GetType(Settings))
        Dim lOut As Settings

        Dim configPath As String = Path.Combine(aPath, Settings.BrowserChooserConfigFileName)
        If (File.Exists(configPath)) Then
            Try
                Logger.AddToLog("Settings.Load", "Reading Settings", aPath)
                Using reader As Stream = New FileStream(configPath, FileMode.Open)
                    lOut = DirectCast(serializer.Deserialize(reader), Settings)
                    reader.Close()
                End Using

                If lOut.EnableLogging = True Then
                    Settings.LogDebugs = TriState.True
                End If

                If lOut.ExtractDLLs = True Then
                    Settings.DoExtractDLLs = True
                End If

                'lock width and height to 10 max, 1 min - acts as overflow protection
                If lOut.Width > 10 Then
                    lOut.Width = 10
                ElseIf lOut.Width < 1 Then
                    lOut.Width = 1
                End If

                If lOut.Height > 10 Then
                    lOut.Height = 10
                ElseIf lOut.Height < 1 Then
                    lOut.Height = 1
                End If

                'yes, the order is wrong, it is a programmers shortcut
                If lOut.FileVersion = 2 Or lOut.FileVersion = 3 Then
                    Logger.AddToLog("Settings.Load", "Old Version", aPath, lOut.FileVersion)
                    'minor update in v3, the on screen dash is moved into the settings
                    If lOut.Seperator = "" Then
                        lOut.Seperator = " - "
                    End If
                    lOut.FileVersion = 4 'force checking of registry below

                    'determine if a SR is present, if yes, turn on accessible rendering
                    Dim lResult As Boolean = False
                    Dim lAPIResult As Boolean = WinAPIs.SystemParametersInfo(WinAPIs.SPI_GETSCREENREADER, 0, lResult, 0)
                    'MessageBox.Show(lAPIResult.ToString & ":" & lResult.ToString & ":" & CInt(False))
                    If lResult = True And lAPIResult = True Then
                        'turn on accessible rendering
                        lOut.AccessibleRendering = True
                        lOut.ShowFocus = True
                    Else
                        lOut.AccessibleRendering = False
                        lOut.ShowFocus = False
                    End If

                    'verify that there are categories and file types
                    If lOut.Protocols.Count = 0 Or lOut.FileTypes.Count = 0 Then
                        lOut.FileVersion = 1 'retrigger the conversion, it didn't work for everyone
                    End If

                    lOut.DoSave(True)
                End If

                'check if version 1, if yes, create default protocols
                If lOut.FileVersion = 1 Then
                    Logger.AddToLog("Settings.Load", "Old Version", aPath, lOut.FileVersion)
                    Dim lGUIDs As New List(Of Guid)
                    lOut.FileVersion = CURRRENT_FILE_VERSION

                    'build an index of browser location. must be located outside of second loop becuase we need complete list
                    Dim lIndexes As New SortedList 'start with an index of positions used
                    For Each lBrowser As Browser In lOut.Browsers
                        lIndexes.Add((lBrowser.PosX).ToString & (lBrowser.PosY).ToString, Nothing)
                    Next

                    ' check each browser for arguments in path and move to arguments
                    For Each lBrowsers As Browser In lOut.Browsers
                        'generate a guid for each first
                        lBrowsers.GUID = System.Guid.NewGuid()
                        lGUIDs.Add(lBrowsers.GUID)

                        'add the Browsers category
                        lBrowsers.Category = GeneralUtilities.DEFAULT_CATEGORY

                        If lBrowsers.Target.Contains(".exe ") Then
                            ' old method
                            Dim lTargetEXE As String = lBrowsers.Target
                            lBrowsers.Target = lTargetEXE.Substring(0, InStr(lTargetEXE, ".exe") + 3)
                            lBrowsers.Arguments = lTargetEXE.Substring(InStr(lTargetEXE, ".exe") + 4, lTargetEXE.Length - (InStr(lTargetEXE, ".exe") + 4))
                        End If

                        'ensure x and y are not 0, if yes, use next availalbe spot algoritim
                        If lBrowsers.PosX = 0 Or lBrowsers.PosY = 0 Then
                            'was in an invalid condition
                            'go thrught list until a gap is found
                            Dim lbFound As Boolean = False
                            For lY As Integer = 0 To 9
                                For lX As Integer = 0 To 9
                                    If lIndexes.ContainsKey(lX.ToString & lY.ToString) = False Then
                                        'found it
                                        lBrowsers.PosX = lX + 1
                                        lBrowsers.PosY = lY + 1
                                        lbFound = True
                                        Exit For : Exit For
                                    End If
                                Next

                                If lbFound = True Then Exit For
                            Next
                        End If
                    Next

                    Dim lDefaultCategories As New List(Of String) From {
                        GeneralUtilities.DEFAULT_CATEGORY
                    }
                    lOut.CreateDefaultProtocols(lGUIDs, lDefaultCategories) 'moved dow because GUID are created above.
                    lOut.CreateDefaultFileTypes(lGUIDs, lDefaultCategories)

                    'save the changes
                    lOut.DoSave(True)
                End If

                'check if version 4, if yes ask to update registry
                If lOut.FileVersion = 4 Then
                    If DefaultBrowser.UpdateUserScope() <> DialogResult.Cancel Then
                        lOut.FileVersion = CURRRENT_FILE_VERSION

                        lOut.DoSave(True)
                    End If
                End If

                Logger.AddToLog("Settings.Load", "End", aPath)
                Return lOut
            Catch ex As Exception
                'Utility.SafeMessagebox("Failled to load settings file. Default settings used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Logger.AddToLog("Settings.Load", "Exception: Failled to load settings file. Default settings used.", aPath)
                Return New Settings(True)
            End Try
        Else
            'Utility.SafeMessagebox("Failled to load settings file. Default settings used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Logger.AddToLog("Settings.Load", "Exception: Failled to load settings file. Default settings used.", aPath)
            Return New Settings(False)
        End If
    End Function
End Class
