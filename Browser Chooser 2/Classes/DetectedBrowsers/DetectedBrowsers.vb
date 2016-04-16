Imports System.Xml.Serialization
Imports System.IO
Imports System.Threading

<Serializable()> _
Public Class DetectedBrowsers
    Private Const UpdateFile As String = "https://browserchooser2.com/app/DetectedBrowsers.xml"
    Public ListOfKnownBrowsers As List(Of BrowserDefinition)

    Private Shared Sub GetLocalfile(ByVal aLocal As String)
        'write the local detection file to the provided file
        'export from self
        Dim writeRes As New FileStream(aLocal, FileMode.Create)
        Dim binWrite As New BinaryWriter(writeRes)
        binWrite.Write(My.Resources.DetectedBrowsers)
        binWrite.Close()
    End Sub

    Public Shared Function DoBrowserDetection() As List(Of Browser) 'ByVal aSettings As Settings)
        'load an xml file form internet, if that fails, use self
        Dim serializer As New XmlSerializer(GetType(DetectedBrowsers))
        Dim DetectedBrowsers As DetectedBrowsers
        Dim lLocal As String = System.IO.Path.GetTempFileName
        Dim lOut As New List(Of Browser)
#If CONFIG <> "Debug Local Detection File" Then
        Try
            If gSettings.DownloadDetectionFile = True Then
                My.Computer.Network.DownloadFile(UpdateFile, lLocal, "", "", False, 5000, True)
            Else
                'export from self
                GetLocalfile(lLocal)
            End If
        Catch ex As Exception
            'export from self
            GetLocalfile(lLocal)
        End Try
#Else
        'export from self
        Dim writeRes As New FileStream(lLocal, FileMode.Create)
        Dim binWrite As New BinaryWriter(writeRes)
        binWrite.Write(My.Resources.DetectedBrowsers)
        binWrite.Close()
#End If

        If (File.Exists(lLocal)) Then
            Try
                'read first char of xml file, if not < then assume bom
                Dim lTemp As String = My.Computer.FileSystem.ReadAllText(lLocal)
                If Mid(lTemp, 1, 1) <> "<" Then
                    'strip chars until
                    lTemp = Mid(lTemp, InStr(lTemp, "<"))
                    My.Computer.FileSystem.WriteAllText(lLocal, lTemp, False)
                End If

                Using reader As Stream = New FileStream(lLocal, FileMode.Open)
                    DetectedBrowsers = DirectCast(serializer.Deserialize(reader), DetectedBrowsers)
                    reader.Close()
                End Using

                Dim lPosX As Integer = 1
                For Each lDefinition As BrowserDefinition In DetectedBrowsers.ListOfKnownBrowsers
                    For Each lPath As String In lDefinition.InstallPath

                        If lDefinition.HasWilcardEndingToPath = True Then
                            Dim lFiles As String() = IO.Directory.GetDirectories(lPath)


                            For Each lItem As String In lFiles
                                If lItem.StartsWith(String.Format("{0}\{1}", lPath, lDefinition.FolderName)) = True Then
                                    'found it - get full path
                                    Dim lNewBrowser As New Browser
                                    lNewBrowser.Name = lDefinition.Name
                                    lNewBrowser.Target = lDefinition.AlternativeExecution.Path
                                    lNewBrowser.Arguments = lDefinition.AlternativeExecution.Arguments
                                    lNewBrowser.IsIE = False 'cannot be true
                                    lNewBrowser.Category = GeneralUtilities.DEFAULT_CATEGORY
                                    lNewBrowser.Image = "(Extract)" ' To be be fixed
                                    lNewBrowser.PosX = lPosX
                                    lNewBrowser.PosY = 1
                                    lNewBrowser.GUID = Guid.NewGuid

                                    If lDefinition.DefaultIconPath <> "" Then
                                        lNewBrowser.Image = "(Custom)"
                                        lNewBrowser.CustomImagePath = String.Format("{0}\{1}", lItem, lDefinition.DefaultIconPath)
                                    Else
                                        lNewBrowser.IconIndex = lDefinition.DefaultIconIndex
                                    End If

                                    lOut.Add(lNewBrowser)

                                    lPosX = lPosX + 1 ' it will be up to the caller to determine final position
                                End If
                            Next

                        Else
                            If My.Computer.FileSystem.FileExists(lPath) = True Then
                                Dim lNewBrowser As New Browser
                                lNewBrowser.Name = lDefinition.Name
                                lNewBrowser.Target = lPath
                                lNewBrowser.IsIE = lDefinition.IsIE
                                lNewBrowser.Category = GeneralUtilities.DEFAULT_CATEGORY
                                lNewBrowser.Image = "(Extract)"
                                lNewBrowser.PosX = lPosX
                                lNewBrowser.PosY = 1
                                lNewBrowser.GUID = Guid.NewGuid

                                If lDefinition.DefaultIconPath <> "" Then
                                    lNewBrowser.Image = "(Custom)"
                                    lNewBrowser.CustomImagePath = lDefinition.DefaultIconPath
                                Else
                                    lNewBrowser.IconIndex = lDefinition.DefaultIconIndex
                                End If


                                lOut.Add(lNewBrowser)

                                lPosX = lPosX + 1 ' it will be up to the caller to determine final position
                            End If
                        End If
                    Next

                    If lDefinition.SupportsNonAdmin = True Then
                        For Each lPath As BrowserDefinition.NonAdminPath In lDefinition.NonAdminInstallPath
                            If My.Computer.FileSystem.FileExists(BrowserDefinition.NonAdminPath.GetSpecialFolder(lPath.SpecialFolder) & "\" & lPath.FinalSection) Then
                                Dim lNewBrowser As New Browser
                                lNewBrowser.Name = lDefinition.Name
                                lNewBrowser.Target = BrowserDefinition.NonAdminPath.GetSpecialFolder(lPath.SpecialFolder) & "\" & lPath.FinalSection
                                lNewBrowser.IsIE = lDefinition.IsIE
                                lNewBrowser.Category = GeneralUtilities.DEFAULT_CATEGORY
                                lNewBrowser.Image = "(Extract)"
                                lNewBrowser.PosX = lPosX
                                lNewBrowser.PosY = 1
                                lNewBrowser.GUID = Guid.NewGuid
                                lNewBrowser.IconIndex = lDefinition.DefaultIconIndex

                                lOut.Add(lNewBrowser)

                                lPosX = lPosX + 1 ' it will be up to the caller to determine final position
                            End If
                        Next
                    End If
                Next
            Catch ex As Exception
                'every resonable attemp has failled, just do IE
                Dim lIE As New Browser
                With lIE
                    .Name = "Internet Explorer"
                    .Target = "C:\Program Files\Internet Explorer\iexplore.exe"
                    .IsIE = True
                    .PosX = 1
                    .PosY = 1
                    .Image = "Internet Explorer"
                End With
                lOut.Add(lIE)
            End Try
        End If

        Return lOut
    End Function

#If CONFIG = "BuildDetectionFile" Then
    Public Shared Sub ExportDetection()
        'hidden function
        Dim lDetectedBrowsers As New DetectedBrowsers
        Dim lListOfKnownBrowsers = New List(Of BrowserDefinition)

        'IE
        Dim lIE As New BrowserDefinition
        lIE.Name = "Internet Explorer"
        lIE.InstallPath = New List(Of String)
        lIE.InstallPath.Add("C:\Program Files\Internet Explorer\iexplore.exe")
        lIE.IsIE = True
        lListOfKnownBrowsers.Add(lIE)

        'EDGE
        Dim lEdge As New BrowserDefinition
        lEdge.Name = "Edge"
        lEdge.InstallPath = New List(Of String)
        lEdge.InstallPath.Add("C:\Windows\SystemApps")
        lEdge.FolderName = "Microsoft.MicrosoftEdge"
        lEdge.AlternativeExecution = New BrowserDefinition.AlternativeExecutionDetails("C:\Windows\explorer.exe", "microsoft-edge:")
        lEdge.DefaultIconPath = "Assets\MicrosoftEdgeSquare44x44.targetsize-64_altform-unplated.png" 'because of wild card above - this is relative
        lEdge.IsUniversalApp = True
        lEdge.HasWilcardEndingToPath = True
        lEdge.IsIE = False ' important - is IE is used for opening tabs in IE since the process is different
        lListOfKnownBrowsers.Add(lEdge)

        'FF
        Dim lFF As New BrowserDefinition
        lFF.Name = "Firefox"
        lFF.InstallPath = New List(Of String)
        lFF.InstallPath.Add("C:\Program Files\Mozilla Firefox\firefox.exe")
        lFF.InstallPath.Add("C:\Program Files (x86)\Mozilla Firefox\firefox.exe")
        'add user mode
        lFF.SupportsNonAdmin = True
        lFF.NonAdminInstallPath = New List(Of BrowserDefinition.NonAdminPath)
        lFF.NonAdminInstallPath.Add(New BrowserDefinition.NonAdminPath With {.SpecialFolder = BrowserDefinition.NonAdminPath.SpecialFolders.LocalApplicationPath, .FinalSection = "Mozilla Firefox\firefox.exe"})
        lListOfKnownBrowsers.Add(lFF)

        'FF Beta - installs to same path as regular FF. Can't add

        'FF Dev Edition
        Dim lFFDev As New BrowserDefinition
        lFFDev.Name = "Firefox Developer Edition"
        lFFDev.InstallPath = New List(Of String)
        lFFDev.InstallPath.Add("C:\Program Files\Firefox Developer Edition\firefox.exe")
        lFFDev.InstallPath.Add("C:\Program Files (x86)\Firefox Developer Edition\firefox.exe")
        'add user mode
        lFFDev.SupportsNonAdmin = True
        lFFDev.NonAdminInstallPath = New List(Of BrowserDefinition.NonAdminPath)
        lFFDev.NonAdminInstallPath.Add(New BrowserDefinition.NonAdminPath With {.SpecialFolder = BrowserDefinition.NonAdminPath.SpecialFolders.LocalApplicationPath, .FinalSection = "Firefox Developer Edition\firefox.exe"})
        lListOfKnownBrowsers.Add(lFFDev)

        'FF Nightly
        Dim lFFNighlty As New BrowserDefinition
        lFFNighlty.Name = "Firefox Nighlty"
        lFFNighlty.InstallPath = New List(Of String)
        lFFNighlty.InstallPath.Add("C:\Program Files\Nightly\firefox.exe")
        lFFNighlty.InstallPath.Add("C:\Program Files (x86)\Nightly\firefox.exe")
        'add user mode
        lFFNighlty.SupportsNonAdmin = True
        lFFNighlty.NonAdminInstallPath = New List(Of BrowserDefinition.NonAdminPath)
        lFFNighlty.NonAdminInstallPath.Add(New BrowserDefinition.NonAdminPath With {.SpecialFolder = BrowserDefinition.NonAdminPath.SpecialFolders.LocalApplicationPath, .FinalSection = "Nightly\firefox.exe"})
        lListOfKnownBrowsers.Add(lFFNighlty)

        'Chrome
        Dim lChrome As New BrowserDefinition
        lChrome.Name = "Chrome"
        lChrome.InstallPath = New List(Of String)
        lChrome.InstallPath.Add("C:\Program Files\Google\Chrome\Application\chrome.exe")
        lChrome.InstallPath.Add("C:\Program Files (x86)\Google\Chrome\Application\chrome.exe")
        'add user mode
        lChrome.SupportsNonAdmin = True
        lChrome.NonAdminInstallPath = New List(Of BrowserDefinition.NonAdminPath)
        lChrome.NonAdminInstallPath.Add(New BrowserDefinition.NonAdminPath With {.SpecialFolder = BrowserDefinition.NonAdminPath.SpecialFolders.LocalApplicationPath, .FinalSection = "Google\Chrome\Application\chrome.exe"})
        lListOfKnownBrowsers.Add(lChrome)

        'Chrome Beta - installs to same path as regular Chrome. Can't add
        'Chrome Dev - installs to same path as regular Chrome. Can't add

        'Chrome Canary
        Dim lChromeCanary As New BrowserDefinition
        lChromeCanary.Name = "Chrome Canary"
        lChromeCanary.InstallPath = New List(Of String)
        lChromeCanary.InstallPath.Add("C:\Program Files\Google\Chrome SxS\Application\chrome.exe")
        lChromeCanary.InstallPath.Add("C:\Program Files (x86)\Google\Chrome SxS\Application\chrome.exe")
        lChromeCanary.DefaultIconIndex = 4 'only Canary seems to need this
        'add user mode
        lChromeCanary.SupportsNonAdmin = True
        lChromeCanary.NonAdminInstallPath = New List(Of BrowserDefinition.NonAdminPath)
        lChromeCanary.NonAdminInstallPath.Add(New BrowserDefinition.NonAdminPath With {.SpecialFolder = BrowserDefinition.NonAdminPath.SpecialFolders.LocalApplicationPath, .FinalSection = "Google\Chrome SxS\Application\chrome.exe"})
        lListOfKnownBrowsers.Add(lChromeCanary)

        'opera
        Dim lOpera As New BrowserDefinition
        lOpera.Name = "Opera"
        lOpera.InstallPath = New List(Of String)
        lOpera.InstallPath.Add("C:\Program Files\Opera\launcher.exe")
        lOpera.InstallPath.Add("C:\Program Files (x86)\Opera\launcher.exe")
        'add user mode
        lOpera.SupportsNonAdmin = True
        lOpera.NonAdminInstallPath = New List(Of BrowserDefinition.NonAdminPath)
        lOpera.NonAdminInstallPath.Add(New BrowserDefinition.NonAdminPath With {.SpecialFolder = BrowserDefinition.NonAdminPath.SpecialFolders.LocalApplicationPath, .FinalSection = "Programs\Opera\launcher.exe"})
        lListOfKnownBrowsers.Add(lOpera)

        'opera beta
        Dim lOperaBeta As New BrowserDefinition
        lOperaBeta.Name = "Opera Beta"
        lOperaBeta.InstallPath = New List(Of String)
        lOperaBeta.InstallPath.Add("C:\Program Files\Opera beta\launcher.exe")
        lOperaBeta.InstallPath.Add("C:\Program Files (x86)\Opera beta\launcher.exe")
        'add user mode
        lOperaBeta.SupportsNonAdmin = True
        lOperaBeta.NonAdminInstallPath = New List(Of BrowserDefinition.NonAdminPath)
        lOperaBeta.NonAdminInstallPath.Add(New BrowserDefinition.NonAdminPath With {.SpecialFolder = BrowserDefinition.NonAdminPath.SpecialFolders.LocalApplicationPath, .FinalSection = "Programs\Opera beta\launcher.exe"})
        lListOfKnownBrowsers.Add(lOperaBeta)

        'opera dev
        Dim lOperaDev As New BrowserDefinition
        lOperaDev.Name = "Opera Developer"
        lOperaDev.InstallPath = New List(Of String)
        lOperaDev.InstallPath.Add("C:\Program Files\Opera developer\launcher.exe")
        lOperaDev.InstallPath.Add("C:\Program Files (x86)\Opera developer\launcher.exe")
        'add user mode
        lOperaDev.SupportsNonAdmin = True
        lOperaDev.NonAdminInstallPath = New List(Of BrowserDefinition.NonAdminPath)
        lOperaDev.NonAdminInstallPath.Add(New BrowserDefinition.NonAdminPath With {.SpecialFolder = BrowserDefinition.NonAdminPath.SpecialFolders.LocalApplicationPath, .FinalSection = "Programs\Opera developer\launcher.exe"})
        lListOfKnownBrowsers.Add(lOperaDev)

        'Vivaldi!
        'C:\Program Files\Vivaldi
        Dim lVivaldi As New BrowserDefinition
        lVivaldi.Name = "Vivaldi"
        lVivaldi.InstallPath = New List(Of String)
        lVivaldi.InstallPath.Add("C:\Program Files\Vivaldi\Application\vivaldi.exe")
        lVivaldi.InstallPath.Add("C:\Program Files (x86)\Vivaldi\Application\vivaldi.exe")
        'add user mode
        lVivaldi.SupportsNonAdmin = True
        lVivaldi.NonAdminInstallPath = New List(Of BrowserDefinition.NonAdminPath)
        lVivaldi.NonAdminInstallPath.Add(New BrowserDefinition.NonAdminPath With {.SpecialFolder = BrowserDefinition.NonAdminPath.SpecialFolders.LocalApplicationPath, .FinalSection = "Vivaldi\Application\vivaldi.exe"})
        lListOfKnownBrowsers.Add(lVivaldi)

        '*** new browsers below 

        'Avant - user mode assumed location
        Dim lAvant As New BrowserDefinition
        lAvant.Name = "Avant"
        lAvant.InstallPath = New List(Of String)
        lAvant.InstallPath.Add("C:\Program Files\Avant Browser\avant.exe")
        lAvant.InstallPath.Add("C:\Program Files (x86)\Avant Browser\avant.exe")
        'add user mode
        lAvant.SupportsNonAdmin = True
        lAvant.NonAdminInstallPath = New List(Of BrowserDefinition.NonAdminPath)
        lAvant.NonAdminInstallPath.Add(New BrowserDefinition.NonAdminPath With {.SpecialFolder = BrowserDefinition.NonAdminPath.SpecialFolders.LocalApplicationPath, .FinalSection = "Avant Browser\avant.exe"})
        lListOfKnownBrowsers.Add(lAvant)

        'Seamonkey - user mode assumed location
        Dim lSeamonkey As New BrowserDefinition
        lSeamonkey.Name = "Seamonkey"
        lSeamonkey.InstallPath = New List(Of String)
        lSeamonkey.InstallPath.Add("C:\Program Files\SeaMonkey\seamonkey.exe")
        lSeamonkey.InstallPath.Add("C:\Program Files (x86)\SeaMonkey\seamonkey.exe")
        'add user mode
        lSeamonkey.SupportsNonAdmin = True
        lSeamonkey.NonAdminInstallPath = New List(Of BrowserDefinition.NonAdminPath)
        lSeamonkey.NonAdminInstallPath.Add(New BrowserDefinition.NonAdminPath With {.SpecialFolder = BrowserDefinition.NonAdminPath.SpecialFolders.LocalApplicationPath, .FinalSection = "SeaMonkey\seamonkey.exe"})
        lListOfKnownBrowsers.Add(lSeamonkey)

        'Waterfox - user mode assumed location
        Dim lWaterfox As New BrowserDefinition
        lWaterfox.Name = "Waterfox"
        lWaterfox.InstallPath = New List(Of String)
        lWaterfox.InstallPath.Add("C:\Program Files\Waterfox\waterfox.exe")
        lWaterfox.InstallPath.Add("C:\Program Files (x86)\Waterfox\waterfox.exe")
        'add user mode
        lWaterfox.SupportsNonAdmin = True
        lWaterfox.NonAdminInstallPath = New List(Of BrowserDefinition.NonAdminPath)
        lWaterfox.NonAdminInstallPath.Add(New BrowserDefinition.NonAdminPath With {.SpecialFolder = BrowserDefinition.NonAdminPath.SpecialFolders.LocalApplicationPath, .FinalSection = "Waterfox\waterfox.exe"})
        lListOfKnownBrowsers.Add(lWaterfox)

        'Maxthon
        '"C:\Program Files (x86)\Maxthon\Bin\Maxthon.exe"
        Dim lMaxthon As New BrowserDefinition
        lMaxthon.Name = "Maxthon"
        lMaxthon.InstallPath = New List(Of String)
        lMaxthon.InstallPath.Add("C:\Program Files\Maxthon\Bin\Maxthon.exe")
        lMaxthon.InstallPath.Add("C:\Program Files (x86)\Maxthon\Bin\Maxthon.exe")
        'add user mode
        lMaxthon.SupportsNonAdmin = True
        lMaxthon.NonAdminInstallPath = New List(Of BrowserDefinition.NonAdminPath)
        lMaxthon.NonAdminInstallPath.Add(New BrowserDefinition.NonAdminPath With {.SpecialFolder = BrowserDefinition.NonAdminPath.SpecialFolders.LocalApplicationPath, .FinalSection = "Maxthon\Bin\Maxthon.exe"})
        lListOfKnownBrowsers.Add(lMaxthon)

        'QupZilla
        Dim lQupZilla As New BrowserDefinition
        lQupZilla.Name = "QupZilla"
        lQupZilla.InstallPath = New List(Of String)
        lQupZilla.InstallPath.Add("C:\Program Files\QupZilla\qupzilla.exee")
        lQupZilla.InstallPath.Add("C:\Program Files (x86)\QupZilla\qupzilla.exe")
        'add user mode
        lQupZilla.SupportsNonAdmin = True
        lQupZilla.NonAdminInstallPath = New List(Of BrowserDefinition.NonAdminPath)
        lQupZilla.NonAdminInstallPath.Add(New BrowserDefinition.NonAdminPath With {.SpecialFolder = BrowserDefinition.NonAdminPath.SpecialFolders.LocalApplicationPath, .FinalSection = "QupZilla\qupzilla.exe"})
        lListOfKnownBrowsers.Add(lQupZilla)

        'Pale Moon (Firefox fork) (maybe have 32 and 64 bit variants)
        Dim lPaleMoon As New BrowserDefinition
        lPaleMoon.Name = "Pale Moon"
        lPaleMoon.InstallPath = New List(Of String)
        lPaleMoon.InstallPath.Add("C:\Program Files\Pale Moon\palemoon.exe")
        lPaleMoon.InstallPath.Add("C:\Program Files (x86)\Pale Moon\palemoon.exe")
        'add user mode
        lPaleMoon.SupportsNonAdmin = True
        lPaleMoon.NonAdminInstallPath = New List(Of BrowserDefinition.NonAdminPath)
        lPaleMoon.NonAdminInstallPath.Add(New BrowserDefinition.NonAdminPath With {.SpecialFolder = BrowserDefinition.NonAdminPath.SpecialFolders.LocalApplicationPath, .FinalSection = "Pale Moon\palemoon.exe"})
        lListOfKnownBrowsers.Add(lPaleMoon)

        'Torch  - by request (codeplex issue #1129) - does not appear to touch program files, but we will still scan it just in case
        Dim lTorch As New BrowserDefinition
        lTorch.Name = "Torch"
        lTorch.InstallPath = New List(Of String)
        lTorch.InstallPath.Add("C:\Program Files\Torch\Application\torch.exe")
        lTorch.InstallPath.Add("C:\Program Files (x86)\Torch\Application\torch.exe")
        'add user mode
        lTorch.SupportsNonAdmin = True
        lTorch.NonAdminInstallPath = New List(Of BrowserDefinition.NonAdminPath)
        lTorch.NonAdminInstallPath.Add(New BrowserDefinition.NonAdminPath With {.SpecialFolder = BrowserDefinition.NonAdminPath.SpecialFolders.LocalApplicationPath, .FinalSection = "Torch\Application\torch.exe"})
        lListOfKnownBrowsers.Add(lTorch)

        lDetectedBrowsers.ListOfKnownBrowsers = lListOfKnownBrowsers

        Dim f As New DirectoryInfo("c:\temp\DetectedBrowsers.xml")

        Dim xmlSerializer As New XmlSerializer(GetType(DetectedBrowsers))

        Using writer As Stream = New FileStream("c:\temp\DetectedBrowsers.xml", FileMode.Create)
            xmlSerializer.Serialize(writer, lDetectedBrowsers)
            writer.Close()
        End Using
    End Sub
#End If

End Class
