Imports System.Reflection
Imports System.IO
Imports System.Threading
Imports System.ComponentModel
Imports System.Net
Imports Browser_Chooser_2.GeneralUtilities


Public Class StartupLauncher
    Public Delegate Sub UpdateURL(ByVal mURL As String)
    Private Shared mURL As String
    Private Shared mbIs64Bit As Boolean
    Private Shared mDelay As Integer 'if > 0 count down and launch browser
    Private Shared mBrowser As Browser
    Private Shared mDeletegate As UpdateURL
    Private Shared mSupportingBrowsers As List(Of Guid)

    Sub New()
        Logger.AddToLog("StartupLancher.New", "Start")
        gSettings = New Settings

        'init some basic properties - run once only
        If IntPtr.Size = 8 Or Not String.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432")) Then
            Logger.AddToLog("StartupLancher.New", "Is 64 Bit")
            mbIs64Bit = True
        End If

        GeneralUtilities.LoadDLLPrep()
        Logger.AddToLog("StartupLancher.New", "End")
    End Sub

#Region "Read-only Properties"
    Public Shared ReadOnly Property Is64Bit As Boolean
        Get
            Return mbIs64Bit
        End Get
    End Property

    Public Shared ReadOnly Property URL As String
        Get
            Return mURL
        End Get
    End Property

    Public Shared ReadOnly Property Browser As Browser
        Get
            Return mBrowser
        End Get
    End Property

    Public Shared ReadOnly Property Delay As Integer
        Get
            Return mDelay
        End Get
    End Property

    Public Shared ReadOnly Property SupportingBrowsers As List(Of Guid)
        Get
            Return mSupportingBrowsers
        End Get
    End Property

    Private Shared Sub ProcessParts(ByVal aParts As GeneralUtilities.URLParts)
        mSupportingBrowsers = New List(Of Guid)

        If aParts.isProtocol = TriState.True Then
            For Each lProtocol In gSettings.Protocols
                If lProtocol.Header = aParts.Protocol Then
                    For Each lBrowser As Browser In gSettings.Browsers
                        If lProtocol.SupportingBrowsers.Contains(lBrowser.GUID) Then
                            mSupportingBrowsers.Add(lBrowser.GUID)
                        End If
                    Next

                    Exit For 'short circuit
                End If
            Next
        ElseIf aParts.isProtocol = TriState.False Then 'is extention            
            For Each lFileType In gSettings.FileTypes
                If lFileType.Extention.ToLower() = aParts.Extention.ToLower() Then
                    For Each lBrowser As Browser In gSettings.Browsers
                        If lFileType.SupportingBrowsers.Contains(lBrowser.GUID) Then
                            mSupportingBrowsers.Add(lBrowser.GUID)
                        End If
                    Next

                    Exit For 'short circuit
                End If
            Next
        Else 'use default
            'just show all?
            For Each lProtocol In gSettings.Protocols
                'If lProtocol.Header = "http" Then
                For Each lBrowser As Browser In gSettings.Browsers
                    If lProtocol.SupportingBrowsers.Contains(lBrowser.GUID) Then
                        mSupportingBrowsers.Add(lBrowser.GUID)
                    End If
                Next

                'Exit For 'short circuit
                'End If
            Next
        End If
    End Sub

    Public Shared Sub SetURL(ByVal aURL As String, ByVal abUnShorten As Boolean, ByVal aDeletegate As UpdateURL)
        mURL = aURL
        mDeletegate = aDeletegate
        Dim lParts As GeneralUtilities.URLParts = DetermineParts(aURL)
        ProcessParts(lParts)

        If abUnShorten = True And mURL <> "" And lParts.isProtocol = TriState.True Then
            'to do
            If lParts.Protocol = "http" Or lParts.Protocol = "https" Then
                mWorker = New System.Threading.Thread(AddressOf mWorker_DoWork_HTTP)
                mWorker.IsBackground = True
                mWorker.Start()
            End If
        End If
    End Sub

    Public Shared Sub SetURL(ByVal aURL As String, ByVal abUnShorten As Boolean, ByVal aDelay As Integer, ByVal aBrowser As Browser, ByVal aDeletegate As UpdateURL)
        mURL = aURL
        mDelay = aDelay
        mBrowser = aBrowser
        mDeletegate = aDeletegate
        Dim lParts As GeneralUtilities.URLParts = DetermineParts(aURL)
        ProcessParts(lParts)

        If abUnShorten = True And mURL <> "" And lParts.isProtocol = TriState.True Then
            'to do
            If lParts.Protocol = "http" Or lParts.Protocol = "https" Then
                mWorker = New System.Threading.Thread(AddressOf mWorker_DoWork_HTTP)
                mWorker.IsBackground = True
                mWorker.Start()
            End If
        End If
    End Sub
#End Region

#Region "ShortURL deshortening"
    'only applies to http(s) 
    Private Shared mWorker As System.Threading.Thread
    Private Shared Sub mWorker_DoWork_HTTP()

        Dim lRequest As HttpWebRequest
        Dim lResponse As WebResponse = Nothing

        Try
            lRequest = DirectCast(WebRequest.Create(mURL), HttpWebRequest)
            lRequest.UserAgent = gSettings.UserAgent
            lRequest.Method = WebRequestMethods.Http.Head
            lResponse = lRequest.GetResponse

            mURL = lResponse.ResponseUri.ToString
        Catch ex As WebException

            Try
                lRequest = DirectCast(WebRequest.Create(mURL), HttpWebRequest)
                lRequest.UserAgent = gSettings.UserAgent
                lRequest.Method = WebRequestMethods.Http.Get
                lResponse = lRequest.GetResponse
            Catch
                'cannot be converted
            End Try

            If IsNothing(lResponse) = False AndAlso IsNothing(lResponse.ResponseUri) = False Then
                mURL = lResponse.ResponseUri.ToString
            End If

        End Try

        'clean up and destroy self
        If IsNothing(mDeletegate) = False Then
            mDeletegate.Invoke(mURL) 'send the new URL message
        End If

        mWorker = Nothing

    End Sub
#End Region

    Private Shared Sub mWorker_DoWork()
        Throw New NotImplementedException
    End Sub

End Class
