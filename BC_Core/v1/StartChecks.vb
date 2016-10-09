Imports System.IO

Public Class StartChecks
    Public Sub CheckForMigrateBeforeOptions()
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

        'Dim lFormToShow As New frmOptions
        'lFormToShow.ShowForm(aScreen, False)
        'Application.Run(lFormToShow) 'terrible, but it works
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

        'ContinueMain("")
    End Sub
End Class
