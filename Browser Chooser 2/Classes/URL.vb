Public Class URL
    Implements ICloneable

    Private msURL As String
    Private mGUID As Guid
    Private mbAutoLoad As Boolean
    Private miDelayTime As Integer 'seconds - if definned delays autoload x seconds
    Private mbShowURL As CheckState 'an override to main setting
    Private msSearchString As String

    Public Property URL() As String
        Get
            Return msURL
        End Get
        Set(ByVal value As String)
            msURL = value
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

    Public Property SearchString As String
        Get
            Return msSearchString
        End Get
        Set(value As String)
            msSearchString = value
        End Set
    End Property

    Public Sub New()
        'required for export / import
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
        lOut.AutoLoad = mbAutoLoad
        lOut.DelayTime = miDelayTime
        lOut.ShowURL = mbShowURL
        lOut.Guid = mGUID
        lOut.SearchString = msSearchString

        Return lOut

    End Function
End Class
