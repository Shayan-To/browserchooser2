Imports System.Xml.Serialization
Imports System.IO

<Serializable()> _
Public Class Settings
    Public Const CURRRENT_FILE_VERSION As Integer = 4 'will be used later for upgrade detection
    '   NOTE: Version 2 adds the protocol and file types - automaticly added
    '   NOTE: Version 3 redoes the protocols and file types, adds accessiblity settings
    '   NOTE: Version 4 redoes the accessiblity settings and mimics v3
    '   NOTE: Several Settings were added in Beta 2 but did not required a version bump.

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

    Public Const BrowserChooserConfigFileName As String = "BrowserChooser2Config.xml"
    Public Browsers As List(Of Browser)
    Public PortableMode As Boolean
    Public ShowURL As Boolean
    Public RevealShortURL As Boolean
    Public FileVersion As Integer = CURRRENT_FILE_VERSION
    Public Protocols As List(Of Protocol)
    Public FileTypes As List(Of FileType)
    Public URLs As List(Of URL)
    Public Width As Integer
    Public Height As Integer
    Public IconWidth As Integer = 75
    Public IconHeight As Integer = 80
    Public IconGapWidth As Integer = 0
    Public IconGapHeight As Integer = 0
    Public IconScale As Decimal = 1D
    Public OptionsShortcut As Char = "O"c
    Public DefaultMessage As String = "Choose a Browser"
    Public DefaultDelay As Integer = 0
    Public AutomaticUpdates As Boolean = True
    Public CheckDefaultOnLaunch As Boolean = False
    Public AdvancedScreens As Boolean = False
    Public Seperator As String = " - "
    Public AccessibleRendering As Boolean 'true only if a screen reader is detected
    Public ShowFocus As Boolean 'determines if we show the black box around the main screen elements
    Public UseAreo As Boolean = True ' incase the user prefers not to have the fancy background
    Public UserAgent As String = "Mozilla/5.0"
    Public DownloadDetectionFile As Boolean = True
    Public BackgroundColor As Integer = Color.Transparent.ToArgb
    Public StartingPosition As Integer = AvailableStartingPositions.CenterScreen
    Public OffsetX As Integer = 0
    Public OffsetY As Integer = 0

    <NonSerialized()> Public SafeMode As Boolean = False 'only true when the file could not be read - prevents saving

    Sub New(ByVal aError As Boolean)
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

        Dim lDefaultCategories As New List(Of String)
        lDefaultCategories.Add(Utility.DEFAULT_CATEGORY)
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
    End Sub

    Private Sub CreateDefaultProtocols(ByVal aBrowsers As List(Of Guid), ByVal aDefaultCategories As List(Of String))
        'xhtml, .xht, .shtml .html, and .htm are defaults
        'ftp and ftps will also be created but not associated with any built-in tool
        FileTypes = New List(Of FileType)
        FileTypes.Add(New FileType("XHTML", "xhtml", aBrowsers, aDefaultCategories))
        FileTypes.Add(New FileType("XHT", "xht", aBrowsers, aDefaultCategories))
        FileTypes.Add(New FileType("SHTML", "shtml", aBrowsers, aDefaultCategories))
        FileTypes.Add(New FileType("HTML", "html", aBrowsers, aDefaultCategories))
        FileTypes.Add(New FileType("HTM", "htm", aBrowsers, aDefaultCategories))
    End Sub

    Private Sub CreateDefaultFileTypes(ByVal aBrowsers As List(Of Guid), ByVal aDefaultCategories As List(Of String))
        'http and https are defaults
        'ftp and ftps will also be created but not associated with any built-in tool
        Protocols = New List(Of Protocol)

        Protocols.Add(New Protocol("HTTP", "http", aBrowsers, aDefaultCategories))
        Protocols.Add(New Protocol("Secure HTTP", "https", aBrowsers, aDefaultCategories))
        Protocols.Add(New Protocol("FTP", "ftp", aBrowsers, aDefaultCategories))
        Protocols.Add(New Protocol("Secure FTP", "ftps", aBrowsers, aDefaultCategories))
        Protocols.Add(New Protocol("URL Shortcut", "url", aBrowsers, aDefaultCategories))
    End Sub

    Private Sub SharedNew()
        Browsers = New List(Of Browser)
        URLs = New List(Of URL)
        PortableMode = False 'default
        RevealShortURL = False 'default
        ShowURL = True 'default
        Width = 5 'default
        Height = 1 'default
    End Sub

    Sub New()
        SharedNew()
    End Sub

    <Obsolete("Should use DoSave instead - it knows about portable mode and such")> _
    Public Sub Save(ByVal aPath As String)
        If Me.SafeMode = True Then Exit Sub 'do not save
        intSave(aPath) 'send to new functions
    End Sub

    Private Sub intSave(ByVal aPath As String)
        If Me.SafeMode = True Then Exit Sub 'do not save
        Dim f As New IO.DirectoryInfo(aPath)
        If Not f.Exists Then
            IO.Directory.CreateDirectory(aPath)
        End If
        Dim xmlSerializer As New XmlSerializer(GetType(Settings)) 'may not work - need to test

        Using writer As Stream = New FileStream(Path.Combine(aPath, Settings.BrowserChooserConfigFileName), FileMode.Create)
            xmlSerializer.Serialize(writer, Me)
            writer.Close()
        End Using
    End Sub

    Public Sub DoSave(ByVal OverrideSafeMode As Boolean)
        If Me.SafeMode = True And OverrideSafeMode = False Then Exit Sub 'do not save
        If Me.PortableMode = True Then
            Me.intSave(Application.StartupPath)
        Else
            Me.intSave(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\BrowserChooser2\")
        End If
    End Sub

    Public Shared Function Load(ByVal aPath As String) As Settings
        Dim serializer As New XmlSerializer(GetType(Settings))
        Dim lOut As Settings

        Dim configPath As String = Path.Combine(aPath, Settings.BrowserChooserConfigFileName)
        If (File.Exists(configPath)) Then
            Try
                Using reader As Stream = New FileStream(configPath, FileMode.Open)
                    lOut = DirectCast(serializer.Deserialize(reader), Settings)
                    reader.Close()
                End Using

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
                    'minor update in v3, the on screen dash is moved into the settings
                    If lOut.Seperator = "" Then
                        lOut.Seperator = " - "
                    End If
                    lOut.FileVersion = CURRRENT_FILE_VERSION

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
                        lBrowsers.Category = Utility.DEFAULT_CATEGORY

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

                    Dim lDefaultCategories As New List(Of String)
                    lDefaultCategories.Add(Utility.DEFAULT_CATEGORY)
                    lOut.CreateDefaultProtocols(lGUIDs, lDefaultCategories) 'moved dow because GUID are created above.
                    lOut.CreateDefaultFileTypes(lGUIDs, lDefaultCategories)

                    'save the changes
                    lOut.DoSave(True)
                End If

                Return lOut
            Catch ex As Exception
                'Utility.SafeMessagebox("Failled to load settings file. Default settings used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return New Settings(True)
            End Try
        Else
            'Utility.SafeMessagebox("Failled to load settings file. Default settings used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return New Settings(False)
        End If
    End Function
End Class
