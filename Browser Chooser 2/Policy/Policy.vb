Imports Microsoft.Win32

Public Class Policy
    Public Const KeyName As String = "SOFTWARE\Policies\BrowserChooser2" 'GPO support

    'applies only to policy, so ne merge
    Private Shared bIgnoreSettingsFile As Boolean = False
    Private Shared bIgnoreCommandLine As Boolean = False
    Private Shared bPoliciesEnabled As Boolean = False

    'settings file overrides
    Private Shared bDisableAutomaticUpdates As Boolean = False

    Public Shared Sub LoadPolicies()
        'check if regkey exists
        Logger.AddToLog("Policy.LoadPolicies", "Start")

        If Not (Registry.LocalMachine.OpenSubKey(KeyName) Is Nothing) Then
            'policies exists!
            bPoliciesEnabled = True
            Logger.AddToLog("Policy.LoadPolicies", "Policies Key found")

            'determine if we read/save the settings file
            Dim lPoliciesKey As RegistryKey = Registry.LocalMachine.OpenSubKey(KeyName)
            If CInt(lPoliciesKey.GetValue("ReadSettingsFile", 1)) = 0 Then
                Logger.AddToLog("Policy.LoadPolicies", "Ignoreing settings file")
                bIgnoreSettingsFile = True
            End If

            'determine if we read the command line
            If CInt(lPoliciesKey.GetValue("ReadCommandLine", 1)) = 0 Then
                Logger.AddToLog("Policy.LoadPolicies", "Ignoreing command line")
                bIgnoreCommandLine = True
            End If

            'determine automatic updates
            If CInt(lPoliciesKey.GetValue("DisableAutomaticUpdates", 1)) = 0 Then
                Logger.AddToLog("Policy.LoadPolicies", "Ignoreing AutomaticUpdates")
                bDisableAutomaticUpdates = True
            End If
        Else
            Logger.AddToLog("Policy.LoadPolicies", "Policies Key not found, policies support disabled.")
        End If

    End Sub

    Public Shared ReadOnly Property PoliciesEnabled As Boolean
        Get
            Return bPoliciesEnabled
        End Get
    End Property

    Public Shared ReadOnly Property IgnoreSettingsFile As Boolean
        Get
            Return bIgnoreSettingsFile
        End Get
    End Property

    Public Shared ReadOnly Property IgnoreCommandLine As Boolean
        Get
            Return bIgnoreCommandLine
        End Get
    End Property

    Public Shared ReadOnly Property DisableAutomaticUpdates As Boolean
        Get
            Return bDisableAutomaticUpdates
        End Get
    End Property
End Class
