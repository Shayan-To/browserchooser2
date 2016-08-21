Public Class URL
    Implements ICloneable

    Private msURL As String
    Private mBrowser As Browser 'used only for backwards compatibility
    Private mGUID As Guid
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

    Public ReadOnly Property Browser_Old() As Browser
        Get
            Return mBrowser
        End Get
        'Set(ByVal value As Browser)
        '    mBrowser = value
        'End Set
    End Property

    '<Obsolete("Use GUID instead of direct Browser Access", False)> _
    Public Property Browser() As Browser
        <Obsolete("Use GUID instead of direct Browser Access", False)> _
        Get
            Return Nothing
        End Get
        Set(ByVal value As Browser)
            mGUID = value.GUID
        End Set
    End Property

    Public Property Guid() As Guid
        Get
            Return mGUID
        End Get
        Set(ByVal value As Guid)
            mGUID = value
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

    <Obsolete()> _
    Public Sub New(asName As String, aBrowser As Browser, abAutoLoad As Boolean, aiDelayTime As Integer, abShowURL As CheckState)
        msURL = asName
        mBrowser = aBrowser
        mbAutoLoad = abAutoLoad
        miDelayTime = aiDelayTime
        mbShowURL = abShowURL
        mGUID = aBrowser.GUID
    End Sub

    Public Sub New(asName As String, aBrowser As Browser, abAutoLoad As Boolean, aiDelayTime As Integer, abShowURL As CheckState, aGUID As Guid)
        msURL = asName
        mBrowser = aBrowser
        mbAutoLoad = abAutoLoad
        miDelayTime = aiDelayTime
        mbShowURL = abShowURL
        mGUID = aGUID
    End Sub

    Public Sub New(asName As String, abAutoLoad As Boolean, aiDelayTime As Integer, abShowURL As CheckState, aGUID As Guid)
        msURL = asName
        mbAutoLoad = abAutoLoad
        miDelayTime = aiDelayTime
        mbShowURL = abShowURL
        mGUID = aGUID
    End Sub

    Public Function Clone() As Object Implements System.ICloneable.Clone
        Dim lOut As New URL

        lOut.URL = msURL
        'lOut.Browser = DirectCast(mBrowser.Clone, Browser)
        lOut.AutoLoad = mbAutoLoad
        lOut.DelayTime = miDelayTime
        lOut.ShowURL = mbShowURL
        lOut.Guid = mGUID

        Return lOut

    End Function
End Class
