
Public Class Firefox
'' Usage 
Dim pm As New ProcessGuardian()
pm.TerminateFirefoxProcesses("C:\Program Files\Mozilla Firefox\furefox,exe")`
End Class


Public Class ProcessGuardian

    Public Sub TerminateFirefoxProcesses(ByVal targetDirectory As String)
        Dim processes = Process.GetProcessesByName("firefox")

        For Each process In processes
            If process.MainModule.FileName.ToLower().StartsWith(targetDirectory.ToLower()) Then
                Try
                    'Console.WriteLine($"Terminating process {process.Id} from {process.MainModule.FileName}")
                    process.Kill()
                Catch ex As Exception
                    'Console.WriteLine($"Error terminating process: {ex.Message}")
                End Try
            End If
        Next
    End Sub

End Class
