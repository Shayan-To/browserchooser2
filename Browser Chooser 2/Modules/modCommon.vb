#Region "Description"

' modCommon
'
' A module to contain common functions shared throughout the application

#End Region

Module modCommon

	Public Sub Launch(strPath As String, bLocal As Boolean)
		' Simple call to launch a URL or File, given it's URL/Path as a String
		' bLocal set to True will confirm that the Local File in fact, exists, before attempting to launch it
		'TODO: Move all "Process.Start"'s to this central call.

		If String.IsNullOrEmpty(strPath) = False Then
		' Confirm we HAVE a string first ...

			If bLocal = True Then

				' Local file doesn't actually exist at the passed path, so we just silently exit this Sub without further processing
				If My.Computer.FileSystem.FileExists(strPath) = False Then Exit Sub

			End If

			' Everything is go for Lift Off!
			Process.Start(strPath)

		End If

	End Sub

End Module
