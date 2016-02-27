<Serializable()> _
Public Class BrowserDefinition
    <Serializable()> _
    Public Class NonAdminPath
        Public Enum SpecialFolders
            LocalApplicationPath
            SystemApps
        End Enum
        Public SpecialFolder As SpecialFolders
        Public FinalSection As String

        Public Shared Function GetSpecialFolder(ByVal aSpecialFolder As SpecialFolders) As String
            Select Case aSpecialFolder
                Case SpecialFolders.LocalApplicationPath
                    Return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
                Case SpecialFolders.SystemApps
                    Return Environment.GetFolderPath(Environment.SpecialFolder.System)
                Case Else
                    Return Nothing
            End Select
        End Function
    End Class



    Public Name As String
    Public InstallPath As List(Of String)
    Public ExecutePath As List(Of String)
    Public IsIE As Boolean = False
    Public IsEdge As Boolean = False 'must launch differently
    Public SupportsNonAdmin As Boolean = False
    Public NonAdminInstallPath As List(Of NonAdminPath)
    Public DefaultIconIndex As Integer = 0
    Public HasWilcardEndingToPath As Boolean = False ' for use with MS edge and other Metro based broswers
End Class
