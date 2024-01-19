Structure personInfo
    Public Name As String
    Public Age As Integer
End Structure

Public Function GetPersonInfo() As personInfo
    Dim person As New personInfo
    person.Name = "John Doe"
    person.Age = 30
    Return person
End Function

Sub Main()
    Dim info As personInfo = GetPersonInfo()
    Console.WriteLine("Name: {0}, Age: {1}", info.Name, info.Age)
End Sub
