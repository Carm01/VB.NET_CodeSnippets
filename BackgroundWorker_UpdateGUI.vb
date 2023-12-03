'' Updating the GUI in WinForms inside a background worker without using CheckForIllegalCrossThreadCalls = False in the form load function

 Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

     For i = 0 To 1000
         DisplayOutput(item2:=i)
         Threading.Thread.Sleep(100)
     Next

 End Sub

 Private Sub DisplayOutput(Optional ByVal item1 As String = Nothing, Optional ByVal item2 As Integer = Nothing)
' be aware that using NOthing set the variable type to its default values in this case Integers = 0
     If item2 <> Nothing Then
         Me.Invoke(Sub()
                       'update controls here
                       Label1.Text = CStr(item2)
                   End Sub)
     End If

     If item1 <> Nothing Then

     End If

 End Sub