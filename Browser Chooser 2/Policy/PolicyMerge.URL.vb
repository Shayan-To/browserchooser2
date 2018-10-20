Imports Microsoft.Win32

Partial Public Class PolicyMerge
    Public Shared ReadOnly Property URLs As List(Of URL)
        Get
            Dim lOut As New List(Of URL)
            'put policy based URLs on top, then put gSettings URLS
            Logger.AddToLog("PolicyMerge.URLs", "Start")
            If Not (Registry.LocalMachine.OpenSubKey(Policy.KeyName) Is Nothing) Then
                'policies exists!
                Logger.AddToLog("PolicyMerge.LoadPolicies", "Policies Key found")

                'determine if URLs subkey Exists
                Dim lPoliciesKey As RegistryKey = Registry.LocalMachine.OpenSubKey(Policy.KeyName)
                If Not (lPoliciesKey.OpenSubKey("URLs") Is Nothing) Then
                    Logger.AddToLog("PolicyMerge.URLs.LoadPolicies", "URLs Policies Key found")

                    'load each entry and add to urls list
                    For Each lKey As String In lPoliciesKey.OpenSubKey("URLs").GetSubKeyNames
                        Logger.AddToLog("PolicyMerge.URLs.LoadPolicies", String.Format("Attemting to load {0}.", lKey))
                        Dim lItem As RegistryKey = lPoliciesKey.OpenSubKey("URLs").OpenSubKey(lKey)

                        'bulid a URL object from this list
                        Dim lNewUrl As New URL
                        Dim lbError As Boolean = False
                        Try
                            lNewUrl.URL = lItem.GetValue("URL").ToString()
                        Catch ex As Exception
                            LogError("Add URL", "URL", ex)
                            lbError = True
                        End Try

                        'Try
                        '    'more works needs to be done here - need Browsers loaded and GUIDs created
                        '    Dim lGUID As String = lItem.GetValue("GUID").ToString()

                        '    lNewUrl.Guid = New Guid()
                        'Catch ex As Exception
                        '    LogError("Add URL", "GUID", ex)
                        '    lbError = True
                        'End Try

                        Try
                            If CInt(lItem.GetValue("AutoLoad")) = 0 Then
                                lNewUrl.AutoLoad = False
                            Else
                                lNewUrl.AutoLoad = True
                            End If
                        Catch ex As Exception
                            LogError("Add URL", "AutoLoad", ex)
                            lbError = True
                        End Try

                        Try
                            lNewUrl.DelayTime = CInt(lItem.GetValue("DelayTime"))
                        Catch ex As Exception
                            LogError("Add URL", "DelayTime", ex)
                            lbError = True
                        End Try

                        Try
                            lNewUrl.ShowURL = DirectCast(lItem.GetValue("showURL"), CheckState)
                        Catch ex As Exception
                            LogError("Add URL", "ShowURL", ex)
                            lbError = True
                        End Try

                        Try
                            lNewUrl.SearchString = lItem.GetValue("BrowserSearchString", "").ToString()
                        Catch ex As Exception
                            LogError("Add URL", "BrowserSearchString", ex)
                            lbError = True
                        End Try

                        If lbError = False Then
                            'add this one to output
                            lOut.Add(lNewUrl)
                            Logger.AddToLog("PolicyMerge.URLs.LoadPolicies", String.Format("Added URL: {0}.", lKey))
                        Else
                            Logger.AddToLog("PolicyMerge.URLs.LoadPolicies", String.Format("Rejected URL: {0}. See above error message.", lKey))
                        End If

                    Next
                End If
            End If

            'merge gSettings
            For Each lURL In gSettings.URLs
                Logger.AddToLog("PolicyMerge.URLs.gSettings.URLs", String.Format("Adding {0}.", lURL.URL))

                lOut.Add(lURL)
            Next

            'output
            Logger.AddToLog("PolicyMerge.URLs", "End")
            Return lOut
        End Get
    End Property
End Class
