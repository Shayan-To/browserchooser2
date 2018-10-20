Imports System.Runtime.InteropServices
Imports Microsoft.Win32
Partial Public Class PolicyMerge
    'this class will merge gSettings and Policy settings to produce a single object
    'to be used intead of gSettings in most cases

#Region "Helper Functions"
    Private Shared Sub LogError(aPart As String, aField As String, aEX As Exception)
        Logger.AddToLog(String.Format("PolicyMerge.URLs.LoadPolicies.{0}", aPart),
                        String.Format("Error: Cannot read field: {0}. Exception: {1}", aField, aEX.Message))
    End Sub

    Protected Shared Function GetSetting(Of T)(aKey As RegistryKey, aPart As String, aName As String, aDefaultValue As T, <Out()> ByRef Errored As Boolean) As T
        Dim lOut As T
        Try
            lOut = DirectCast(aKey.GetValue(aName, aDefaultValue), T)
            Errored = False Or Errored 'using OR to keep error status
        Catch ex As Exception
            LogError(String.Format("Load {0}", aPart), aName, ex)
            Errored = True 'enfore true for error status
        End Try
    End Function

    Protected Shared Function GetPolicyKey(<Out()> ByRef Errored As Boolean) As RegistryKey
        'DefaultDelay
        Logger.AddToLog("PolicyMerge.GetPolicyKey", "Start")

        Dim lbError As Boolean = False
        If Not (Registry.LocalMachine.OpenSubKey(Policy.KeyName) Is Nothing) Then
            'policies exists!
            Logger.AddToLog("PolicyMerge.LoadPolicies", "Policies Key found")

            'determine if URLs subkey Exists
            Logger.AddToLog("PolicyMerge.GetPolicyKey", "End")
            Try
                Errored = False Or Errored 'found policy and move error fowards
                Return Registry.LocalMachine.OpenSubKey(Policy.KeyName)
            Catch ex As Exception
                Logger.AddToLog("PolicyMerge.GetPolicyKey.OpenSubKey", String.Format("Error: {0}", ex.Message))
                Errored = True 'no policy
                Return Nothing
            End Try
        Else
            Errored = True 'no policy
            Return Nothing
        End If
    End Function

    Protected Shared Function GetPolicySubKey(aRoot As RegistryKey, aSubKeyName As String, <Out()> ByRef Errored As Boolean) As RegistryKey
        If aRoot.OpenSubKey(aSubKeyName) Is Nothing Then
            Errored = True
            Return Nothing
        Else
            Errored = False Or Errored 'found policy and move error fowards
            Return aRoot.OpenSubKey(aSubKeyName)
        End If
    End Function
#End Region

    Public Shared ReadOnly Property AutomaticUpdates As Boolean
        Get
            If Policy.DisableAutomaticUpdates = True Then Return False 'no updates allowed - this is a global override

            'AutomaticUpdates
            Logger.AddToLog("PolicyMerge.AutomaticUpdates", "Start")
            Dim lbError As Boolean = False
            Dim lbAutomaticUpdates As Boolean = GetSetting(Of Boolean)(GetPolicyKey(lbError), "AutomaticUpdates", "AutomaticUpdates", False, lbError)

            If lbError = True Then
#Disable Warning
                Return gSettings.AutomaticUpdates
#Enable Warning
            Else
                If Policy.IgnoreSettingsFile = True Then
                    Return lbAutomaticUpdates
                Else
#Disable Warning
                    Return gSettings.AutomaticUpdates Or lbAutomaticUpdates 'if one of them is true, auto updates is on.
#Enable Warning
                End If
            End If
        End Get
    End Property

    Public Shared ReadOnly Property DefaultDelay As Integer
        Get
            'DefaultDelay
            Logger.AddToLog("PolicyMerge.DefaultDelay", "Start")
            Dim lbError As Boolean = False
            Dim lDefaultDelay As Integer = GetSetting(Of Integer)(GetPolicyKey(lbError), "DefaultDelay", "DefaultDelay", 0, lbError)

            If lbError = True Then
#Disable Warning
                Return gSettings.DefaultDelay
#Enable Warning
            Else
                Return lDefaultDelay
            End If
        End Get
    End Property

    'CheckDefaultOnLaunch
    Public Shared ReadOnly Property CheckDefaultOnLaunch As Boolean
        Get
            'DefaultDelay
            Logger.AddToLog("PolicyMerge.DefaultDelay", "Start")
            Dim lbError As Boolean = False
            Dim lbCheckDefaultOnLaunch As Boolean = GetSetting(Of Boolean)(GetPolicyKey(lbError), "CheckDefaultOnLaunch", "CheckDefaultOnLaunch", False, lbError)

            If lbError = True Then
#Disable Warning
                Return gSettings.CheckDefaultOnLaunch
#Enable Warning
            Else
                Return lbCheckDefaultOnLaunch
            End If
        End Get
    End Property
End Class
