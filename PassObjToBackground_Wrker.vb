'' Shows how to pass multiple items into a background worker and pass items out of a background worker as an object.
Public Sub PassInto()
    Dim Input As String = "Hello World"
    Dim blnTrueFalse As Boolean = True
    Dim intInteger As Integer = 8

    Dim list As New List(Of Object) From {Input, blnTrueFalse, intInteger}
    BackgroundWorker1.RunWorkerAsync(list)
End Sub

Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
    Dim Input As String = Nothing
    Dim blnTrueFalse As Boolean = Nothing
    Dim intInteger As Integer = Nothing

    Dim sPar As New List(Of Object)()
    sPar = CType(e.Argument, List(Of Object))
    Input = CStr(sPar.Item(0))
    blnTrueFalse = CBool(sPar.Item(1))
    intInteger = CInt(sPar.Item(2))

    Dim sOutput As New List(Of Object) From {"New World", False, 3}
    e.Result = sOutput
End Sub

Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted

    Dim sResult As New List(Of Object)()
    sResult = CType(e.Result, List(Of Object))

    Dim Output As String = sResult.Item(0).ToString
    Dim TrueFalse As Boolean = CBool(sResult.Item(1))
    Dim OutInteger As Integer = CInt(sResult.Item(2))

End Sub