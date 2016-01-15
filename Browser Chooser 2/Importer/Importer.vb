Imports System.IO

Public Class Importer
    Public Sub New(aPath As String)
        Dim lLegacyList As LegacyNS.Legacy.BrowserList = LegacyNS.Legacy.BrowserList.Load(aPath)
        'Dim lXIndex As Integer = 1
        gSettings = New Settings 'will be null

        'convert legacy settings into new format - they are similar but there are changes (e.g. urls list is outside of browsers now)
        For Each lLegacyBrowser As LegacyNS.Legacy.Browser In lLegacyList.Browsers
            Dim lNewBrowser As New Browser(Guid.Empty, lLegacyBrowser.Name, lLegacyBrowser.Target, lLegacyBrowser.Image, lLegacyBrowser.CustomImagePath,
                                           lLegacyBrowser.IsActive, CChar(lLegacyBrowser.BrowserNumber.ToString), False, gSettings.Browsers.Count + 1, 1, 0, "", "", 1)
            If lLegacyBrowser.Target.Contains("iexplore.exe") Then
                lNewBrowser.IsIE = True
            End If

            gSettings.Browsers.Add(lNewBrowser)

            'convert URLs into new format
            For Each lLegacyURL As String In lLegacyBrowser.Urls
                Dim lNewURL As New URL(lLegacyURL, lNewBrowser, False, 0, CheckState.Indeterminate)
                gSettings.URLs.Add(lNewURL)
            Next
        Next

        'now do other settings
        gSettings.ShowURL = lLegacyList.ShowUrl
        gSettings.RevealShortURL = lLegacyList.RevealUrl
        'gSettings.PortableMode = detected TO DO

        'now set defaults on new settings
        gSettings.Width = 5
        gSettings.Height = 1

        'and save
        gSettings.DoSave(True)
        'If gSettings.PortableMode = True Then
        '    gSettings.Save(Application.StartupPath)
        'Else
        '    gSettings.Save(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\BrowserChooser2\")
        'End If
    End Sub
End Class
