Imports System.Runtime.InteropServices
Imports System.Runtime.CompilerServices

Public Class ApplicationActivationManager
    Public Enum ActivateOptions
        None = 0
        DesignMode = 1
        NoErrorUI = 2
        NoSplashScreen = 4
    End Enum
    <ComImport(), _
        Guid("2e941141-7f97-4756-ba1d-9decde894a3d"), _
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Interface IApplicationActivationManager
        ' Activates the specified immersive application for the "Launch" contract, passing the provided arguments
        ' string into the application.  Callers can obtain the process Id of the application instance fulfilling this contract.
        Function ActivateApplication(ByVal appUserModelId As String, ByVal arguments As String, ByVal options As ActivateOptions, ByRef processId As UInt32) As IntPtr
        Function ActivateForFile(ByVal appUserModelId As String, ByVal itemArray As IntPtr, ByVal verb As String, ByRef processId As UInt32) As IntPtr
        Function ActivateForProtocol(ByVal appUserModelId As String, ByVal itemArray As IntPtr, ByRef processId As UInt32) As IntPtr
    End Interface

    <ComImport(), _
        Guid("45BA127D-10A8-46EA-8AB7-56EA9078943C")> _
    Class ApplicationActivationManager
        Implements IApplicationActivationManager

        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Public Function ActivateApplication(ByVal appUserModelId As String, ByVal arguments As String, ByVal options As ActivateOptions, ByRef processId As UInt32) As IntPtr Implements IApplicationActivationManager.ActivateApplication
            ' coclass is implemented by the runtime callable wrapper
        End Function

        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Public Function ActivateForFile(ByVal appUserModelId As String, ByVal itemArray As IntPtr, ByVal verb As String, ByRef processId As UInt32) As IntPtr Implements IApplicationActivationManager.ActivateForFile
            ' coclass is implemented by the runtime callable wrapper
        End Function
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Public Function ActivateForProtocol(ByVal appUserModelId As String, ByVal itemArray As IntPtr, ByRef processId As UInt32) As IntPtr Implements IApplicationActivationManager.ActivateForProtocol
            ' coclass is implemented by the runtime callable wrapper
        End Function

    End Class
End Class
