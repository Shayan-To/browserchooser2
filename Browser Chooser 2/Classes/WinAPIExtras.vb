Imports System.Runtime.InteropServices

Public Class WinAPIExtras
    <Flags()> _
    Public Enum ASSOCIATIONLEVEL
        AL_MACHINE
        AL_EFFECTIVE
        AL_USER
    End Enum

    <Flags()> _
    Public Enum ASSOCIATIONTYPE
        AT_FILEEXTENSION
        AT_URLPROTOCOL
        AT_STARTMENUCLIENT
        AT_MIMETYPE
    End Enum

    <ComImport()> _
    <Guid("4e530b0a-e611-4c77-a3ac-9031d022281b")> _
    <InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Interface IApplicationAssociationRegistration
        Function QueryCurrentDefault(<MarshalAs(UnmanagedType.LPWStr)> ByVal query As String,
                                     ByVal queryType As ASSOCIATIONTYPE,
                                     ByVal queryLevel As ASSOCIATIONLEVEL) As <MarshalAs(UnmanagedType.LPWStr)> String

        Function QueryAppIsDefault(<MarshalAs(UnmanagedType.LPWStr)> ByVal query As String,
                                   ByVal queryType As ASSOCIATIONTYPE,
                                   ByVal queryLevel As ASSOCIATIONLEVEL,
                                   <MarshalAs(UnmanagedType.LPWStr)> ByVal appRegistryName As String) As <MarshalAs(UnmanagedType.Bool)> Boolean

        Function QueryAppIsDefaultAll(ByVal queryLevel As ASSOCIATIONLEVEL,
                                      <MarshalAs(UnmanagedType.LPWStr)> ByVal appRegistryName As String,
                                      <Out()> <MarshalAs(UnmanagedType.Bool)> ByRef pfDefault As Boolean) As Integer

        Sub SetAppAsDefault(<MarshalAs(UnmanagedType.LPWStr)> ByVal appRegistryName As String,
                            <MarshalAs(UnmanagedType.LPWStr)> ByVal setx As String,
                            ByVal setType As ASSOCIATIONTYPE)

        Sub SetAppAsDefaultAll(<MarshalAs(UnmanagedType.LPWStr)> ByVal appRegistryName As String)
        Sub ClearUserAssociations()
    End Interface

    <ComImport()> _
    <Guid("591209c7-767b-42b2-9fba-44ee4615f2c7")> _
    Class ApplicationAssociationRegistration
        ' coclass is implemented by the runtime callable wrapper
    End Class

    <ComImport()> _
    <Guid("1f76a169-f994-40ac-8fc8-0959e8874710")> _
    <InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Interface IApplicationAssociationRegistrationUI
        Function LaunchAdvancedAssociationUI(<MarshalAs(UnmanagedType.LPWStr)> ByVal pszAppRegName As String) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Interface

    <ComImport()> _
    <Guid("1968106d-f3b5-44cf-890e-116fcb9ecef1")> _
    Class ApplicationAssociationRegistrationUI
        ' coclass is implemented by the runtime callable wrapper
    End Class
End Class