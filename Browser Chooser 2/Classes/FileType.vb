<Serializable()> _
Public Class FileType
    Implements ICloneable

    Private msTypeName As String
    Private msExtention As String
    Private mSupportingBrowsers As List(Of Guid)
    Private mDefaultCategories As List(Of String)
    'NOTE the will be extra fields, this can also be made more dynamic by fetching data from registry

    Public Sub New(ByVal aName As String, ByVal aExtention As String, ByVal aBrowsers As List(Of Guid), ByVal aDefaultCategories As List(Of String))
        msTypeName = aName
        msExtention = aExtention
        mSupportingBrowsers = aBrowsers
        mDefaultCategories = aDefaultCategories
    End Sub

    Public Sub New()
        'for use in serialization
    End Sub

    Public Property FiletypeName() As String
        Get
            Return msTypeName
        End Get
        Set(ByVal value As String)
            msTypeName = value
        End Set
    End Property

    Public Property Extention() As String
        Get
            Return msExtention
        End Get
        Set(ByVal value As String)
            msExtention = value
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
        Dim lOut As New FileType

        lOut.FiletypeName = msTypeName
        lOut.Extention = msExtention
        lOut.DefaultCategories = mDefaultCategories

        'required to actually do a clone, also prevents a weird behaviour where removing from one removes from all
        Dim lTemp(mSupportingBrowsers.Count - 1) As System.Guid
        mSupportingBrowsers.CopyTo(lTemp)
        lOut.SupportingBrowsers = New List(Of System.Guid)(lTemp)

        Return lOut

    End Function

End Class
