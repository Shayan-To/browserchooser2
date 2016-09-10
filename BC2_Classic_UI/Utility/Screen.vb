Imports Browser_Chooser_Core.WinAPIs

Namespace Utility
    Public Class Screen
        Public Shared Sub MakeFormGlassy(ByVal aForm As Form)
            Dim margins As MARGINS = New MARGINS
            margins.cxLeftWidth = -1
            margins.cxRightWidth = -1
            margins.cyTopHeight = -1
            margins.cyButtomheight = -1
            'set all the four value -1 to apply glass effect to the whole window
            aForm.BackColor = Color.Black
            Dim hwnd As IntPtr = aForm.Handle
            Dim result As Integer = DwmExtendFrameIntoClientArea(hwnd, margins)

            'attemp to make pretty
            'Try
            '    Dim lPreColor As New WinAPIs.tagCOLORIZATIONPARAMS
            '    WinAPIs.DwmGetColorizationParameters(lPreColor)

            '    Debug.Print(lPreColor.clrColor.R.ToString)

            '    'change RGB to user selected value
            '    Dim lNewColor As WinAPIs.tagCOLORIZATIONPARAMS = lPreColor.Clone
            '    Dim lBackColor As Color = Color.FromArgb(gSettings.BackgroundColor)
            '    lNewColor.clrColor.R = lBackColor.R
            '    lNewColor.clrColor.G = lBackColor.G
            '    lNewColor.clrColor.B = lBackColor.B

            '    WinAPIs.DwmSetColorizationParameters(lNewColor, False)

            '    'show the form
            '    aForm.Show()

            '    'reset to original
            '    WinAPIs.DwmSetColorizationParameters(lPreColor, False)
            'Catch ex As Exception

            'End Try
        End Sub
    End Class
End Namespace
