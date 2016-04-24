Imports System.Runtime.InteropServices
Imports System.Runtime.CompilerServices

Public Class WinAPIs

#Region "Consts"
    Public Const WM_SETTINGCHANGE = &H1A
    Public Shared ReadOnly HWND_BROADCAST As IntPtr = New IntPtr(65535)
    Public Const BCM_SETSHIELD As UInt32 = &H160C
    Public Const ERROR_CANCELLED As Integer = &H800704C7
    Public Const SPI_GETSCREENREADER As Integer = &H46
#End Region

#Region "Flags"
    <Flags()> _
    Public Enum SendMessageTimeoutFlags
        SMTO_NORMAL = 0
        SMTO_BLOCK = 1
        SMTO_ABORTIFHUNG = 2
        SMTO_NOTIMEOUTIFNOTHUNG = 8
    End Enum

    <Flags()> _
    Public Enum BrowserNavConstants
        navOpenInNewWindow = &H1
        navNoHistory = &H2
        navNoReadFromCache = &H4
        navNoWriteToCache = &H8
        navAllowAutosearch = &H10
        navBrowserBar = &H20
        navHyperlink = &H40
        navEnforceRestricted = &H80
        navNewWindowsManaged = &H100
        navUntrustedForDownload = &H200
        navTrustedForActiveX = &H400
        navOpenInNewTab = &H800
        navOpenInBackgroundTab = &H1000
        navKeepWordWheelText = &H2000
        navVirtualTab = &H4000
        navBlockRedirectsXDomain = &H8000
        navOpenNewForegroundTab = &H10000
    End Enum

    <Flags()> _
    Public Enum SHChangeNotifyEventID As UInt32
        SHCNE_ALLEVENTS = &H7FFFFFFFL
        SHCNE_ASSOCCHANGED = &H8000000L
        SHCNE_ATTRIBUTES = &H800L
        SHCNE_CREATE = &H2L
        SHCNE_DELETE = &H4L
        SHCNE_DISKEVENTS = &H2381FL
        SHCNE_DRIVEADD = &H100L
        SHCNE_DRIVEADDGUI = &H10000L
        SHCNE_DRIVEREMOVED = &H80L
        SHCNE_EXTENDED_EVENT = &H4000000L
        SHCNE_FREESPACE = &H40000L
        SHCNE_GLOBALEVENTS = &HC0581E0L
        SHCNE_INTERRUPT = &H80000000L
        SHCNE_MEDIAINSERTED = &H20L
        SHCNE_MEDIAREMOVED = &H40L
        SHCNE_MKDIR = &H8L
        SHCNE_NETSHARE = &H200L
        SHCNE_NETUNSHARE = &H400L
        SHCNE_RENAMEFOLDER = &H20000L
        SHCNE_RENAMEITEM = &H1L
        SHCNE_RMDIR = &H10L
        SHCNE_SERVERDISCONNECT = &H4000L
        SHCNE_UPDATEDIR = &H1000L
        SHCNE_UPDATEIMAGE = &H8000L
        SHCNE_UPDATEITEM = &H2000L
    End Enum

    <Flags()> _
    Public Enum SHChangeNotifyFlags As UInt32
        SHCNF_DWORD = 3
        SHCNF_FLUSH = &H1000
        SHCNF_FLUSHNOWAIT = &H2000
        SHCNF_IDLIST = 0
        SHCNF_PATH = 5
        SHCNF_PATHA = 1
        SHCNF_PATHW = 5
        SHCNF_PRINTER = 6
        SHCNF_PRINTERA = 2
        SHCNF_PRINTERW = 6
        SHCNF_TYPE = &HFF
    End Enum

    <Flags()> _
    Public Enum OPEN_AS_INFO_FLAGS As UInt32
        OAIF_ALLOW_REGISTRATION = &H1 ' Show "Always" checkbox
        OAIF_REGISTER_EXT = &H2 ' Perform registration when user hits OK
        OAIF_EXEC = &H4 '    Exec file after registering
        OAIF_FORCE_REGISTRATION = &H8 ' Force the checkbox to be registration
        OAIF_HIDE_REGISTRATION = &H20 ' Vista+: Hide the "always use this file" checkbox
        OAIF_URL_PROTOCOL = &H40 ' Vista+: cszFile is actually a URI scheme; show handlers for that scheme
        OAIF_FILE_IS_URI = &H80 ' Win8+: The location pointed to by the pcszFile parameter is given as a URI
    End Enum
#End Region

#Region "Structures"
    <StructLayout(LayoutKind.Sequential)> _
    Public Structure MARGINS
        Public cxLeftWidth As Integer
        Public cxRightWidth As Integer
        Public cyTopHeight As Integer
        Public cyButtomheight As Integer
    End Structure

    '<StructLayout(LayoutKind.Sequential)> _
    Public Structure OPENASINFO
        <MarshalAs(UnmanagedType.LPWStr)> Public cszFile As String
        <MarshalAs(UnmanagedType.LPWStr)> Public cszClass As String
        Public OPEN_AS_INFO_FLAGS As OPEN_AS_INFO_FLAGS
    End Structure
#End Region

#Region "DLLImports"
    <DllImport("user32.dll", SetLastError:=True)> _
    Public Shared Sub SendMessageTimeout(ByVal windowHandle As IntPtr, ByVal Msg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr, ByVal flags As SendMessageTimeoutFlags, ByVal timeout As Integer, ByRef result As IntPtr)
    End Sub


    <DllImport("dwmapi.dll")> _
    Public Shared Function DwmExtendFrameIntoClientArea(ByVal hWnd As IntPtr, ByRef pMarinset As MARGINS) As Integer
    End Function

    Public Declare Function DwmIsCompositionEnabled Lib "dwmapi" _
        (ByRef pfEnabled As Long) As Long

    <DllImport("shell32.dll")> _
    Public Shared Sub SHChangeNotify( _
        ByVal wEventID As SHChangeNotifyEventID, _
        ByVal uFlags As SHChangeNotifyFlags, _
        ByVal dwItem1 As IntPtr, _
        ByVal dwItem2 As IntPtr)
    End Sub

    <DllImport("user32", CharSet:=CharSet.Auto, SetLastError:=True)> _
    Public Shared Function SendMessage( _
        ByVal hWnd As IntPtr, _
        ByVal Msg As UInt32, _
        ByVal wParam As Integer, _
        ByVal lParam As IntPtr) _
        As Integer
    End Function

    <DllImport("shell32.dll", EntryPoint:="SHOpenWithDialog", CharSet:=CharSet.Auto)> _
    Public Shared Function SHOpenWithDialog(ByVal hWndParent As IntPtr, ByRef OPENASINFO As OPENASINFO) As Integer
    End Function

    ' SetLastError:=True is required for error checking
    <DllImport("user32", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Public Shared Function SystemParametersInfo( _
            ByVal intAction As Integer, _
            ByVal intParam As Integer, _
            <[In](), Out()> ByRef strParam As Boolean, _
            ByVal intWinIniFlag As Integer) As Boolean
        ' returns non-zero value if function succeeds
    End Function

    <DllImport("user32.dll")> _
    Public Shared Function SetForegroundWindow(ByVal hWnd As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Public Shared Function FindWindow(ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr
    End Function

    <DllImport("user32.dll", EntryPoint:="FindWindow", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Public Shared Function FindWindowByCaption(ByVal zero As IntPtr, ByVal lpWindowName As String) As IntPtr
    End Function
#End Region

#Region "FOLDERID"
    Public Enum SIGDN As UInteger
        NORMALDISPLAY = 0
        PARENTRELATIVEPARSING = &H80018001UI
        PARENTRELATIVEFORADDRESSBAR = &H8001C001UI
        DESKTOPABSOLUTEPARSING = &H80028000UI
        PARENTRELATIVEEDITING = &H80031001UI
        DESKTOPABSOLUTEEDITING = &H8004C000UI
        FILESYSPATH = &H80058000UI
        URL = &H80068000UI

    End Enum

    <Flags()> _
    Public Enum KF_CATEGORY
        KF_CATEGORY_VIRTUAL = &H1
        KF_CATEGORY_FIXED = &H2
        KF_CATEGORY_COMMON = &H3
        KF_CATEGORY_PERUSER = &H4
    End Enum

    <Flags()> _
    Public Enum KF_DEFINITION_FLAGS
        KFDF_PERSONALIZE = &H1
        KFDF_LOCAL_REDIRECT_ONLY = &H2
        KFDF_ROAMABLE = &H4
    End Enum

    <Flags()> _
    Public Enum FFFP_MODE
        FFFP_EXACTMATCH = &H0
        FFFP_NEARESTPARENTMATCH = &H1
    End Enum

    <ComImport()> _
    <InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    <Guid("43826d1e-e718-42ee-bc55-a1e261c37bfe")> _
    Public Interface IShellItem
        Sub BindToHandler(ByVal pbc As IntPtr, <MarshalAs(UnmanagedType.LPStruct)> ByVal bhid As Guid, <MarshalAs(UnmanagedType.LPStruct)> ByVal riid As Guid, ByRef ppv As IntPtr)

        Sub GetParent(ByRef ppsi As IShellItem)

        Sub GetDisplayName(ByVal sigdnName As SIGDN, ByRef ppszName As IntPtr)

        Sub GetAttributes(ByVal sfgaoMask As UInteger, ByRef psfgaoAttribs As UInteger)

        Sub Compare(ByVal psi As IShellItem, ByVal hint As UInteger, ByRef piOrder As Integer)
    End Interface

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto, Pack:=4)> _
    Structure KNOWNFOLDER_DEFINITION
        Public category As KF_CATEGORY

        <MarshalAs(UnmanagedType.LPWStr)> _
        Public pszName As String

        <MarshalAs(UnmanagedType.LPWStr)> _
        Public pszCreator As String

        <MarshalAs(UnmanagedType.LPWStr)> _
        Public pszDescription As String

        Public fidParent As Guid

        <MarshalAs(UnmanagedType.LPWStr)> _
        Public pszRelativePath As String

        <MarshalAs(UnmanagedType.LPWStr)> _
        Public pszParsingName As String

        <MarshalAs(UnmanagedType.LPWStr)> _
        Public pszToolTip As String

        <MarshalAs(UnmanagedType.LPWStr)> _
        Public pszLocalizedName As String

        <MarshalAs(UnmanagedType.LPWStr)> _
        Public pszIcon As String

        <MarshalAs(UnmanagedType.LPWStr)> _
        Public pszSecurity As String

        Public dwAttributes As UInteger
        Public kfdFlags As KF_DEFINITION_FLAGS
        Public ftidType As Guid
    End Structure


    <ComImport(), Guid("3AA7AF7E-9B36-420c-A8E3-F77D4674A488"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Interface IKnownFolder
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Sub GetId(ByRef pkfid As Guid)

        ' Not yet supported - adding to fill slot in vtable
        Sub spacer1()
        '[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        'void GetCategory(out mbtagKF_CATEGORY pCategory);

        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Sub GetShellItem(<[In]()> ByVal dwFlags As UInteger, ByRef riid As Guid, ByRef ppv As IShellItem)

        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Sub GetPath(<[In]()> ByVal dwFlags As UInteger, <MarshalAs(UnmanagedType.LPWStr)> ByRef ppszPath As String)

        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Sub SetPath(<[In]()> ByVal dwFlags As UInteger, <[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal pszPath As String)

        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Sub GetLocation(<[In]()> ByVal dwFlags As UInteger, <Out(), ComAliasName("ShellObjects.wirePIDL")> ByVal ppidl As IntPtr)

        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Sub GetFolderType(ByRef pftid As Guid)

        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Sub GetRedirectionCapabilities(ByRef pCapabilities As UInteger)

        ' Not yet supported - adding to fill slot in vtable
        Sub spacer2()
        '[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        'void GetFolderDefinition(out tagKNOWNFOLDER_DEFINITION pKFD);
    End Interface

    <ComImport(), Guid("8BE2D872-86AA-4d47-B776-32CCA40C7018"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Interface IKnownFolderManager
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Sub FolderIdFromCsidl(<[In]()> ByVal nCsidl As Integer, ByRef pfid As Guid)

        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Sub FolderIdToCsidl(<[In]()> ByRef rfid As Guid, ByRef pnCsidl As Integer)

        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Sub GetFolderIds(<Out()> ByVal ppKFId As IntPtr, <[In](), Out()> ByRef pCount As UInteger)

        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Sub GetFolder(<[In]()> ByRef rfid As Guid, <MarshalAs(UnmanagedType.[Interface])> ByRef ppkf As IKnownFolder)

        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Sub GetFolderByName(<[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal pszCanonicalName As String, <MarshalAs(UnmanagedType.[Interface])> ByRef ppkf As IKnownFolder)

        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Sub RegisterFolder(<[In]()> ByRef rfid As Guid, <[In]()> ByRef pKFD As KNOWNFOLDER_DEFINITION)

        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Sub UnregisterFolder(<[In]()> ByRef rfid As Guid)

        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Sub FindFolderFromPath(<[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal pszPath As String, <[In]()> ByVal mode As FFFP_MODE, <MarshalAs(UnmanagedType.[Interface])> ByRef ppkf As IKnownFolder)

        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Sub FindFolderFromIDList(<[In]()> ByVal pidl As IntPtr, <MarshalAs(UnmanagedType.[Interface])> ByRef ppkf As IKnownFolder)

        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Sub Redirect(<[In]()> ByRef rfid As Guid, <[In]()> ByVal hwnd As IntPtr, <[In]()> ByVal Flags As UInteger, <[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal pszTargetPath As String, <[In]()> ByVal cFolders As UInteger, <[In]()> ByRef pExclusion As Guid, _
  <MarshalAs(UnmanagedType.LPWStr)> ByRef ppszError As String)
    End Interface
#End Region
End Class
