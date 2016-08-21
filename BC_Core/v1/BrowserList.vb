Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Xml.Serialization

Namespace LegacyNS
    Partial Public Class Legacy
        Public Class BrowserList
            Private _iAmDefaultBrowser As Boolean
            Public Property IamDefaultBrowser() As Boolean
                Get
                    Return _iAmDefaultBrowser
                End Get
                Set(ByVal value As Boolean)
                    _iAmDefaultBrowser = value
                End Set
            End Property

            Private _showUrl As Boolean
            Public Property ShowUrl() As Boolean
                Get
                    Return _showUrl
                End Get
                Set(ByVal value As Boolean)
                    _showUrl = value
                End Set
            End Property

            Private _RevealUrl As Boolean
            Public Property RevealUrl() As Boolean
                Get
                    Return _RevealUrl
                End Get
                Set(ByVal value As Boolean)
                    _RevealUrl = value
                End Set
            End Property

            Private _autoUpdateCheck As Boolean
            Public Property AutoUpdateCheck() As Boolean
                Get
                    Return _autoUpdateCheck
                End Get
                Set(ByVal value As Boolean)
                    _autoUpdateCheck = value
                End Set
            End Property

            Private _lastUpdateCheck As DateTime
            Public Property LastUpdateCheck() As DateTime
                Get
                    Return _lastUpdateCheck
                End Get
                Set(ByVal value As DateTime)
                    _lastUpdateCheck = value
                End Set
            End Property

            Private _intranetBrowser As Legacy.Browser
            Public Property IntranetBrowser() As Legacy.Browser
                Get
                    Return _intranetBrowser
                End Get
                Set(ByVal value As Legacy.Browser)
                    _intranetBrowser = value
                End Set
            End Property

            Private _defaultBrowser As Legacy.Browser
            Public Property DefaultBrowser() As Legacy.Browser
                Get
                    Return _defaultBrowser
                End Get
                Set(ByVal value As Legacy.Browser)
                    _defaultBrowser = value
                End Set
            End Property

            Private _browsers As List(Of Legacy.Browser) = New List(Of Legacy.Browser)
            Public Property Browsers() As List(Of Legacy.Browser)
                Get
                    Return _browsers
                End Get
                Set(ByVal value As List(Of Legacy.Browser))
                    _browsers = value
                End Set
            End Property

            Public Function GetBrowser(ByVal browserNumber As Integer) As Legacy.Browser
                Dim browser As Legacy.Browser = Nothing
                If (Not Me.Browsers Is Nothing) Then
                    browser = Me.Browsers.FirstOrDefault(Function(t) t.BrowserNumber = browserNumber)
                End If
                If (browser Is Nothing) Then
                    browser = New Legacy.Browser
                End If
                Return browser

            End Function

            Public Function GetBrowserByUrl(ByVal url As String) As Integer
                Dim rez = 0

                If Me.IntranetBrowser IsNot Nothing Then
                    If GeneralUtilities.IsIntranetUrl(url) Then
                        rez = Legacy.Settings.BrowserConfig.IntranetBrowser.BrowserNumber
                    End If
                End If

                If Me.DefaultBrowser IsNot Nothing And DefaultBrowser.BrowserNumber <> 0 Then
                    rez = Legacy.Settings.BrowserConfig.DefaultBrowser.BrowserNumber
                End If

                Dim b As Legacy.Browser = Me.Browsers.FirstOrDefault(Function(c) c.Urls.Any(Function(w) url.ToUpper().Contains(w.Trim().ToUpper())))
                If b IsNot Nothing Then
                    rez = b.BrowserNumber
                End If

                Return rez
            End Function

            'Public Sub Save(ByVal browserChooserConfigDirectory As String)
            '    Dim f As New IO.DirectoryInfo(browserChooserConfigDirectory)
            '    If Not f.Exists Then
            '        IO.Directory.CreateDirectory(browserChooserConfigDirectory)
            '    End If
            '    Dim xmlSerializer As New XmlSerializer(GetType(Legacy.BrowserList))

            '    Using writer As Stream = New FileStream(Path.Combine(browserChooserConfigDirectory, Legacy.Settings.BrowserChooserConfigFileName), FileMode.Create)
            '        Me.Browsers.Sort()
            '        xmlSerializer.Serialize(writer, Me)
            '        writer.Close()
            '    End Using
            'End Sub

            Public Shared Function Load(ByVal browserChooserConfigDirectory As String) As Legacy.BrowserList
                Dim serializer As New XmlSerializer(GetType(Legacy.BrowserList))

                Dim blist As Legacy.BrowserList

                'Dim configPath As String = Path.Combine(browserChooserConfigDirectory, Legacy.Settings.BrowserChooserConfigFileName)
                If (File.Exists(browserChooserConfigDirectory)) Then
                    Using writer As Stream = New FileStream(browserChooserConfigDirectory, FileMode.Open)
                        blist = DirectCast(serializer.Deserialize(writer), Legacy.BrowserList)
                        writer.Close()
                    End Using
                Else
                    blist = New Legacy.BrowserList
                End If
                Return blist
            End Function
        End Class
    End Class
End Namespace