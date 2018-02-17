Imports System.Text.RegularExpressions

Public Class URLUtilities
    Public Structure URLParts
        Public isProtocol As TriState
        Public Protocol As String
        Public Extention As String
        Public Remainder As String

        Public Overrides Function ToString() As String
            If Protocol = "" Then
                Return String.Format("{0}.{1}", Extention, Remainder)
            Else
                Return String.Format("{0}://{1}", Protocol, Remainder)
            End If
        End Function
    End Structure

    Public Shared Function DetermineParts(ByVal aURL As String) As URLParts
        Logger.AddToLog("URLUtilities.DetermineParts", "Start", aURL)
        Dim lOut As New URLParts

        If InStr(aURL, "://") > 0 Then 'is a protocol
            lOut.isProtocol = TriState.True
            lOut.Protocol = Left(aURL, InStr(aURL, "://") - 1)
            lOut.Remainder = Mid(aURL, InStr(aURL, "://") + 3)
        ElseIf InStr(aURL, ".") > 0 Then
            'file extention
            lOut.isProtocol = TriState.False
            lOut.Extention = Mid(aURL, InStrRev(aURL, ".") + 1) 'to be tested
            lOut.Remainder = Left(aURL, InStrRev(aURL, ".") - 1)

        ElseIf InStr(aURL, "/") > 0 Then
            'try domain less
            lOut.isProtocol = TriState.True
            lOut.Protocol = "https"
            lOut.Remainder = aURL
        Else
            lOut.isProtocol = TriState.UseDefault ' for instances where we can't determine easily
        End If

        Logger.AddToLog("URLUtilities.DetermineParts", "End", lOut.isProtocol, lOut.Protocol, lOut.Extention, lOut.Remainder)
        Return Canonicalize(lOut)
    End Function

    Public Shared Function MatchURLs(ByVal aSource As String, ByVal aTarget As String) As Boolean
        Logger.AddToLog("URLUtilities.MatchURLs", "Start", aSource, aTarget)
        'strip http(s):// from urls and strip www from urls
        Dim lsSource As String = aSource.Replace("http://", "").Replace("https://", "").Replace("www.", "")
        Dim lsTarget As String = aTarget.Replace("http://", "").Replace("https://", "").Replace("www.", "")

        'perform basic wilcard (regex to come later)
        If lsTarget Like lsSource Then
            Logger.AddToLog("URLUtilities.MatchURLs", "End", aSource, aTarget, True)
            Return True
        Else
            Logger.AddToLog("URLUtilities.MatchURLs", "End", aSource, aTarget, False)
            Return False
        End If
    End Function

    Public Shared Function Canonicalize(ByVal url As URLUtilities.URLParts) As URLUtilities.URLParts
        'determine if remainder does not contain a TLD/ending
        If url.isProtocol = TriState.True And gSettings.Canonicalize = True Then
            Dim lFirstSlash As Integer = InStr(url.Remainder, "/")
            Dim lFirstQuestion As Integer = InStr(url.Remainder, "?")
            Dim lFirstDot As Integer = InStr(url.Remainder, ".")

            'if there is a slash before a dot, add extra there
            Dim lSubIn As String
            Select Case True
                Case lFirstDot = 0 And lFirstSlash > 0 And (lFirstQuestion = 0 Or lFirstQuestion > lFirstSlash)
                    'no dot, has a slash before any question
                    Logger.AddToLog("URLUtilities.DetermineParts", "Select 1", lFirstSlash, lFirstQuestion, lFirstDot)
                    lSubIn = String.Format("{0}.{1}{2}", Left(url.Remainder, lFirstSlash - 1), gSettings.CanonicalizeAppendedText, Mid(url.Remainder, lFirstSlash))
                Case lFirstDot = 0 And lFirstQuestion > 0 And (lFirstSlash = 0 Or lFirstSlash > lFirstQuestion)
                    'not dot, has a question before first slash
                    Logger.AddToLog("URLUtilities.DetermineParts", "Select 2", lFirstSlash, lFirstQuestion, lFirstDot)
                    lSubIn = String.Format("{0}.{1}{2}", Left(url.Remainder, lFirstQuestion - 1), gSettings.CanonicalizeAppendedText, Mid(url.Remainder, lFirstQuestion))
                Case lFirstDot = 0 And lFirstSlash = 0 And lFirstQuestion = 0
                    'no dot, slash or question make - append to tend
                    Logger.AddToLog("URLUtilities.DetermineParts", "Select 3", lFirstSlash, lFirstQuestion, lFirstDot)
                    lSubIn = String.Format("{0}.{1}", url.Remainder, gSettings.CanonicalizeAppendedText)
                Case (lFirstSlash > 0 And lFirstSlash < lFirstDot) And (lFirstQuestion = 0 Or lFirstQuestion > lFirstSlash)
                    'has a dot but slash is before dot and any question
                    Logger.AddToLog("URLUtilities.DetermineParts", "Select 4", lFirstSlash, lFirstQuestion, lFirstDot)
                    lSubIn = String.Format("{0}.{1}{2}", Left(url.Remainder, lFirstSlash - 1), gSettings.CanonicalizeAppendedText, Mid(url.Remainder, lFirstSlash))
                Case (lFirstQuestion > 0 And lFirstQuestion < lFirstDot) And (lFirstSlash = 0 Or lFirstSlash > lFirstQuestion)
                    'question mark is before a dot and slash
                    Logger.AddToLog("URLUtilities.DetermineParts", "Select 5", lFirstSlash, lFirstQuestion, lFirstDot)
                    lSubIn = String.Format("{0}.{1}{2}", Left(url.Remainder, lFirstQuestion - 1), gSettings.CanonicalizeAppendedText, Mid(url.Remainder, lFirstQuestion))
                Case Else
                    Logger.AddToLog("URLUtilities.DetermineParts", "Select 6", lFirstSlash, lFirstQuestion, lFirstDot)
                    lSubIn = url.Remainder 'dot comes before any slash or question
            End Select

            url.Remainder = lSubIn
        End If

        Return url
    End Function
End Class
