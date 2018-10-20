Imports Microsoft.Win32
Partial Public Class PolicyMerge
    Public Shared ReadOnly Property Browsers As List(Of Browser)
        Get
            Dim lOut As New List(Of Browser)
            'put policy based URLs on top, then put gSettings URLS
            Logger.AddToLog("PolicyMerge.URLs", "Start")
            If Not (Registry.LocalMachine.OpenSubKey(Policy.KeyName) Is Nothing) Then
                'policies exists!
                Logger.AddToLog("PolicyMerge.LoadPolicies", "Policies Key found")

                'determine if URLs subkey Exists
                Dim lPoliciesKey As RegistryKey = Registry.LocalMachine.OpenSubKey(Policy.KeyName)
                If Not (lPoliciesKey.OpenSubKey("Browsers") Is Nothing) Then
                    Logger.AddToLog("PolicyMerge.Browsers.LoadPolicies", "Browsers Policies Key found")

                    'load each entry and add to urls list
                    For Each lKey As String In lPoliciesKey.OpenSubKey("Browsers").GetSubKeyNames
                        Logger.AddToLog("PolicyMerge.Browsers.LoadPolicies", String.Format("Attemting to load {0}.", lKey))
                        Dim lItem As RegistryKey = lPoliciesKey.OpenSubKey("Browsers").OpenSubKey(lKey)

                        'bulid a URL object from this list
                        Dim lNewBrowser As New Browser
                        Dim lbError As Boolean = False

                        Try
                            lNewBrowser.Name = lItem.GetValue("Name").ToString()
                        Catch ex As Exception
                            LogError("Add Browser", "Name", ex)
                            lbError = True
                        End Try

                        Try
                            lNewBrowser.Target = lItem.GetValue("Target").ToString()
                        Catch ex As Exception
                            LogError("Add Browser", "Target", ex)
                            lbError = True
                        End Try

                        Try
                            lNewBrowser.Image = lItem.GetValue("Image").ToString()
                        Catch ex As Exception
                            LogError("Add Browser", "Image", ex)
                            lbError = True
                        End Try

                        Try
                            lNewBrowser.IconIndex = CInt(lItem.GetValue("IconIndex"))
                        Catch ex As Exception
                            LogError("Add Browser", "IconIndex", ex)
                            lbError = True
                        End Try

                        Try
                            lNewBrowser.CustomImagePath = lItem.GetValue("CustomImagePath").ToString()
                        Catch ex As Exception
                            LogError("Add Browser", "CustomImagePath", ex)
                            lbError = True
                        End Try

                        If lbError = False Then
                            'add this one to output
                            lOut.Add(lNewBrowser)
                            Logger.AddToLog("PolicyMerge.Browsers.LoadPolicies", String.Format("Added Browsers: {0}.", lKey))
                        Else
                            Logger.AddToLog("PolicyMerge.Browsers.LoadPolicies", String.Format("Rejected Browsers: {0}. See above error message.", lKey))
                        End If
                    Next
                End If
            End If

            'tmp
            Return lOut
        End Get
    End Property
End Class
