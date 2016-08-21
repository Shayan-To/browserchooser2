Namespace LegacyNS
    Partial Public Class Legacy
        Public Class Settings
            Public Shared BrowserConfig As LegacyNS.Legacy.BrowserList
            Public Const BrowserChooserConfigFileName As String = "BrowserChooserConfig.xml"

            Shared Sub New()
                BrowserConfig = New LegacyNS.Legacy.BrowserList
            End Sub
        End Class
    End Class
End Namespace
