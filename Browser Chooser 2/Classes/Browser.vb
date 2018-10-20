Public Class Browser
    Implements ICloneable
    'Implements IComparable(Of Browser)
    Implements IEquatable(Of Browser)

    Private mGUID As Guid
    'Private mType As String 'eg. browser, editor, BT, office editor
    Private msName As String
    Private msTarget As String
    Private msImage As String
    Private miIconIndex As Integer
    Private msCustomImagePath As String
    Private mbIsActive As Boolean
    Private mcHotkey As Char

    '<Obsolete("X is ambigous. Use Row instead")>
    Private mPosX As Integer
    Private mPosRow As Integer

    '<Obsolete("Y is ambigous. Use Col instead")>
    Private mPosY As Integer
    Private mPosCol As Integer

    Private msCategory As String = ""
    Private mbIsIE As Boolean 'triggers special handling
    Private mbIsIdge As Boolean 'triggers special handling
    Private msArguments As String
    Private msScale As Single = 1 'standard default
    'Private msGroupName As String 'ver 2 feature
    Private mbShown As Boolean = True 'allows to hide an option

    Public Property GUID As Guid
        Get
            Return mGUID
        End Get
        Set(ByVal value As Guid)
            mGUID = value
        End Set
    End Property

    Public Property Name() As String
        Get
            Return msName
        End Get
        Set(ByVal value As String)
            msName = value
        End Set
    End Property

    Public Property Category() As String
        Get
            Return msCategory
        End Get
        Set(ByVal value As String)
            msCategory = value
        End Set
    End Property

    Public Property Target() As String
        Get
            Return msTarget
        End Get
        Set(ByVal value As String)
            msTarget = value
        End Set
    End Property

    Public Property IconIndex() As Integer
        Get
            Return miIconIndex
        End Get
        Set(ByVal value As Integer)
            miIconIndex = value
        End Set
    End Property

    Public Property Image() As String
        Get
            Return msImage
        End Get
        Set(ByVal value As String)
            msImage = value
        End Set
    End Property

    Public Property CustomImagePath() As String
        Get
            Return msCustomImagePath
        End Get
        Set(ByVal value As String)
            msCustomImagePath = value
        End Set
    End Property

    Public Property IsActive() As Boolean
        Get
            Return mbIsActive
        End Get
        Set(ByVal value As Boolean)
            mbIsActive = value
        End Set
    End Property

    Public Property Hotkey() As Char
        Get
            Return mcHotkey
        End Get
        Set(ByVal value As Char)
            mcHotkey = value
        End Set
    End Property

    <Obsolete("X is ambigous. Use Row instead")>
    Public Property PosX() As Integer
        Get
            Return mPosX
        End Get
        Set(ByVal value As Integer)
            mPosX = value
        End Set
    End Property

    <Obsolete("Y is ambigous. Use Col instead")>
    Public Property PosY() As Integer
        Get
            Return mPosY
        End Get
        Set(ByVal value As Integer)
            mPosY = value
        End Set
    End Property

    Public Property IsIE() As Boolean
        Get
            Return mbIsIE
        End Get
        Set(ByVal value As Boolean)
            mbIsIE = value
        End Set
    End Property

    Public Property IsEdge() As Boolean
        Get
            Return mbIsIdge
        End Get
        Set(ByVal value As Boolean)
            mbIsIdge = value
        End Set
    End Property

    Public Property Arguments As String
        Get
            Return msArguments
        End Get
        Set(ByVal value As String)
            msArguments = value
        End Set
    End Property

    Public Property Scale As Single
        Get
            Return msScale
        End Get
        Set(ByVal value As Single)
            msScale = value
        End Set
    End Property

    Public Property Shown As Boolean
        Get
            Return mbShown
        End Get
        Set(ByVal value As Boolean)
            mbShown = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return msName
    End Function

    'Function CompareTo(ByVal other As Browser) As Integer Implements IComparable(Of Browser).CompareTo
    '    Return (Me.GetHashCode() = other.GetHashCode())
    'End Function

    Public Sub New()
        'required for export / import
    End Sub

    Public Sub New(ByVal aGUID As Guid, ByVal asName As String, ByVal asTarget As String, ByVal asImage As String, ByVal asCustomImagePath As String, ByVal abIsActive As Boolean, ByVal acHotkey As Char, ByVal abIsIE As Boolean, abIsEdge As Boolean, ByVal aPosX As Integer, ByVal aPosY As Integer, ByVal aIconIndex As Integer, ByVal aCategory As String, ByVal asArguemnts As String, ByVal asScale As Single, abShown As Boolean)
        If aGUID <> Guid.Empty Then
            mGUID = aGUID
        Else
            mGUID = GeneralUtilities.GetUniquedID
        End If
        msName = asName
        msTarget = asTarget
        msImage = asImage
        msCustomImagePath = asCustomImagePath
        mbIsActive = abIsActive
        mcHotkey = acHotkey
        mbIsIE = abIsIE
        mbIsIdge = abIsEdge
        mPosX = aPosX
        mPosY = aPosY
        msCategory = aCategory
        miIconIndex = aIconIndex
        msArguments = asArguemnts
        msScale = asScale
        mbShown = abShown
    End Sub

    Public Function Clone() As Object Implements System.ICloneable.Clone
        Dim lOut As New Browser

        lOut.GUID = mGUID
        lOut.Name = msName
        lOut.Target = msTarget
        lOut.Image = msImage
        lOut.CustomImagePath = msCustomImagePath
        lOut.IsActive = mbIsActive
        lOut.Hotkey = mcHotkey
        lOut.IsIE = mbIsIE
        lOut.IsEdge = mbIsIdge
        lOut.PosX = mPosX
        lOut.PosY = mPosY
        lOut.IconIndex = miIconIndex
        lOut.Category = msCategory
        lOut.Arguments = msArguments
        lOut.Scale = msScale
        lOut.Shown = mbShown

        Return lOut
    End Function

    Public Function IEquatable_Equals(ByVal other As Browser) As Boolean Implements System.IEquatable(Of Browser).Equals
        If Me.mGUID <> other.GUID Then Return False
        If Me.msName <> other.Name Then Return False
        If Me.msTarget <> other.Target Then Return False
        If Me.msImage <> other.Image Then Return False
        If Me.CustomImagePath <> other.CustomImagePath Then Return False
        If Me.IsActive <> other.IsActive Then Return False
        If Me.mcHotkey <> other.Hotkey Then Return False
        If Me.mbIsIE <> other.IsIE Then Return False
        If Me.mbIsIdge <> other.IsEdge Then Return False
        If Me.mPosX <> other.PosX Then Return False
        If Me.mPosY <> other.PosY Then Return False
        If Me.miIconIndex <> other.IconIndex Then Return False
        If Me.msCategory <> other.Category Then Return False
        If Me.msArguments <> other.Arguments Then Return False
        If Me.msScale <> other.Scale Then Return False
        If Me.mbShown <> other.Shown Then Return False
        Return True ' all checks pass
    End Function
End Class