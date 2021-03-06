Imports System.IO

Public Class ImageUtilities

    Public Shared Function GetImage(ByRef BrowserChoice As Browser, abDoScale As Boolean) As Image
        Logger.AddToLog("ImageUtilities.GetImage", "Start", BrowserChoice.Name, abDoScale)
        Dim lOut As Image

        If (Not String.IsNullOrEmpty(BrowserChoice.CustomImagePath)) Then
            'handles absolute or relative paths, 
            'Path.Combine(path1, path2): If path2 contains an absolute path, this method returns path2
            Dim cImage As FileInfo = New FileInfo(Path.Combine(Application.StartupPath, BrowserChoice.CustomImagePath.Replace("""", "").Trim()))
            If (cImage.Exists) Then
                Try
                    Select Case cImage.Extension.ToUpper
                        Case ".PNG"
                            lOut = Bitmap.FromFile(cImage.FullName)
                        Case ".ICO"
                            lOut = New Icon(cImage.FullName, New Size(75, 80)).ToBitmap()
                        Case ".EXE"
                            lOut = GetICOFromFile(cImage.FullName, 0)
                        Case ".dll"
                            lOut = GetICOFromFile(cImage.FullName, 0)
                        Case Else
                            'unexpected file format - set icon to default
                            lOut = GetICOFromFile(BrowserChoice.Target, BrowserChoice.IconIndex)
                    End Select

                    'now scale that image
                    lOut = ScaleImage(lOut, BrowserChoice.Scale * gSettings.IconScale)

                Catch ex As Exception
                    'file specified not a valid image format - set icon to default
                    lOut = GetICOFromFile(BrowserChoice.Target, BrowserChoice.IconIndex)
                End Try
            Else
                'file doesn't exist - set icon to edefault
                lOut = GetICOFromFile(BrowserChoice.Target, BrowserChoice.IconIndex)
            End If
        Else
            'no file specifyed, extract from file, this is the new default
            lOut = GetICOFromFile(BrowserChoice.Target, BrowserChoice.IconIndex)
            If abDoScale = True Then
                lOut = ScaleImage(lOut, BrowserChoice.Scale * gSettings.IconScale)
            End If
        End If

        Logger.AddToLog("ImageUtilities.GetImage", "End", BrowserChoice.Name, abDoScale)
        Return lOut
    End Function

    Public Shared Function ScaleImageTo(ByVal aImage As Image, ByVal aScale As Size) As Image
        Logger.AddToLog("ImageUtilities.ScaleImageTo", "Start")
        ' Make a bitmap for the result.
        Dim bm_dest As New Bitmap(aImage, aScale)

        '' Display the result.
        Logger.AddToLog("ImageUtilities.ScaleImageTo", "End")
        Return bm_dest
    End Function

    Public Shared Function ScaleImage(ByVal aImage As Image, ByVal aScale As Single) As Image
        Logger.AddToLog("ImageUtilities.ScaleImage", "Start")
        ' Get the source bitmap.
        Dim bm_source As New Bitmap(aImage)

        ' Make a bitmap for the result.
        Dim bm_dest As New Bitmap(
            CInt(bm_source.Width * aScale),
            CInt(bm_source.Height * aScale))

        ' Make a Graphics object for the result Bitmap.
        Dim gr_dest As Graphics = Graphics.FromImage(bm_dest)

        ' Copy the source image into the destination bitmap.
        gr_dest.DrawImage(bm_source, 0, 0,
            bm_dest.Width + 1,
            bm_dest.Height + 1)

        ' Display the result.
        Logger.AddToLog("ImageUtilities.ScaleImage", "End")
        Return bm_dest
    End Function

    Public Shared Function GetAllICOsFromFile(ByVal aFile As String) As Image()
        Logger.AddToLog("ImageUtilities.GetAllICOsFromFile", "Start", aFile)
        Dim lIcons As List(Of Icon) = TAFactory.IconPack.IconHelper.ExtractAllIcons(aFile)
        Dim lOut(lIcons.Count) As Image

        For lCount As Integer = 0 To lIcons.Count - 1
            lOut(lCount) = TAFactory.IconPack.IconHelper.ExtractBestFitIcon(aFile, lCount, New Size(64, 64)).ToBitmap
        Next

        Logger.AddToLog("ImageUtilities.GetAllICOsFromFile", "End", aFile, lOut.Count)
        Return lOut
    End Function

    Public Shared Function GetICOFromFile(ByVal aFile As String, ByVal aIndex As Integer, Optional ByVal ErrorIconOnFail As Boolean = True) As Image
        Logger.AddToLog("ImageUtilities.GetICOFromFile", "Start", aFile, aIndex, ErrorIconOnFail)
        If My.Computer.FileSystem.FileExists(aFile) = True Then
            Dim lIcon As Icon = TAFactory.IconPack.IconHelper.ExtractBestFitIcon(aFile, aIndex, New Size(64, 64))

            'If c.Size.Width = 256 Then 're-add later as an option?
            '    Return Bitmap.FromHicon(c.Handle)
            'Else

            Logger.AddToLog("ImageUtilities.GetICOFromFile", "End", aFile, aIndex, ErrorIconOnFail)
            Return lIcon.ToBitmap
            'End If
        Else
            Logger.AddToLog("ImageUtilities.GetICOFromFile", "End Fail", aFile, aIndex, ErrorIconOnFail)
            Return My.Resources._53
        End If
    End Function

    Public Shared Function MergeImages(aBase As Image, aTop As Image) As Image
        Logger.AddToLog("ImageUtilities.MergeImages", "Start")

        'Dim Result As New Bitmap(aBase)
        Dim g As Graphics = Graphics.FromImage(aBase)
        Dim Layer As New Bitmap(aTop)

        g.DrawImage(Layer, 12, 12, 12, 12)

        Logger.AddToLog("ImageUtilities.MergeImages", "End")

        Return aBase

    End Function
End Class
