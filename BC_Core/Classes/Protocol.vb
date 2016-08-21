<Serializable()> _
Public Class Protocol
    Implements ICloneable

    Private msProtocolName As String
    Private msHeader As String
    Private mSupportingBrowsers As List(Of Guid)
    Private mDefaultCategories As List(Of String)

    Public Sub New(ByVal aName As String, ByVal aHeader As String, ByVal aBrowsers As List(Of Guid), ByVal aDefaultCategories As List(Of String))
        msProtocolName = aName
        msHeader = aHeader
        mSupportingBrowsers = aBrowsers
        mDefaultCategories = aDefaultCategories
    End Sub

    Public Sub New()
        'for use in serialization
    End Sub

    Public Property ProtocolName() As String
        Get
            Return msProtocolName
        End Get
        Set(ByVal value As String)
            msProtocolName = value
        End Set
    End Property

    Public Property Header() As String
        Get
            Return msHeader
        End Get
        Set(ByVal value As String)
            msHeader = value
        End Set
    End Property

    Public Property SupportingBrowsers() As List(Of Guid)
        Get
            Return mSupportingBrowsers
        End Get
        Set(ByVal value As List(Of Guid))
            mSupportingBrowsers = value
        End Set
    End Property

    Public Property DefaultCategories() As List(Of String)
        Get
            Return mDefaultCategories
        End Get
        Set(ByVal value As List(Of String))
            mDefaultCategories = value
        End Set
    End Property

    Public Function Clone() As Object Implements System.ICloneable.Clone
        Dim lOut As New Protocol

        lOut.ProtocolName = msProtocolName
        lOut.Header = msHeader
        lOut.DefaultCategories = mDefaultCategories

        'required to actually do a clone, also prevents a weird behaviour where removing from one removes from all
        Dim lTemp(mSupportingBrowsers.Count - 1) As System.Guid
        mSupportingBrowsers.CopyTo(lTemp)
        lOut.SupportingBrowsers = New List(Of System.Guid)(lTemp)

        Return lOut

    End Function
End Class
