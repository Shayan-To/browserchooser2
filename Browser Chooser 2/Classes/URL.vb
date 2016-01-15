Public Class URL
    Implements ICloneable

    Private msURL As String
    Private mBrowser As Browser
    Private mbAutoLoad As Boolean
    Private miDelayTime As Integer 'seconds - if definned delays autoload x seconds
    Private mbShowURL As CheckState 'an override to main setting

    Public Property URL() As String
        Get
            Return msURL
        End Get
        Set(ByVal value As String)
            msURL = value
        End Set
    End Property

    Public Property Browser() As Browser
        Get
            Return mBrowser
        End Get
        Set(ByVal value As Browser)
            mBrowser = value
        End Set
    End Property

    Public Property AutoLoad() As Boolean
        Get
            Return mbAutoLoad
        End Get
        Set(ByVal value As Boolean)
            mbAutoLoad = value
        End Set
    End Property

    Public Property DelayTime() As Integer
        Get
            Return miDelayTime
        End Get
        Set(ByVal value As Integer)
            miDelayTime = value
        End Set
    End Property

    Public Property ShowURL() As CheckState
        Get
            Return mbShowURL
        End Get
        Set(ByVal value As CheckState)
            mbShowURL = value
        End Set
    End Property

    Public Sub New()
        'required for export / import
    End Sub

    Public Sub New(asName As String, aBrowser As Browser, abAutoLoad As Boolean, aiDelayTime As Integer, abShowURL As CheckState)
        msURL = asName
        mBrowser = aBrowser
        mbAutoLoad = abAutoLoad
        miDelayTime = aiDelayTime
        mbShowURL = abShowURL
    End Sub

    Public Function Clone() As Object Implements System.ICloneable.Clone
        Dim lOut As New URL

        lOut.URL = msURL
        lOut.Browser = DirectCast(mBrowser.Clone, Browser)
        lOut.AutoLoad = mbAutoLoad
        lOut.DelayTime = miDelayTime
        lOut.ShowURL = mbShowURL

        Return lOut

    End Function
End Class
