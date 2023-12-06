' Properly handles moving borderless forms
Public Sub New()

    ' This call is required by the designer.
    InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
		
End Sub

'Drag Form
<DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
Private Shared Sub ReleaseCapture()
End Sub
<DllImport("user32.DLL", EntryPoint:="SendMessage")>
Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
End Sub

Private Sub panelTitleBar_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseDown, Panel1.MouseDown
    ReleaseCapture()
    SendMessage(Me.Handle, &H112, &HF012, 0)
End Sub

'Minimize border-less form from task-bar
Protected Overrides ReadOnly Property CreateParams As CreateParams
    Get
        Dim cp As CreateParams = MyBase.CreateParams
        cp.Style = cp.Style Or &H20000 '<--- Minimize border-less form from task-bar
        Return cp
    End Get
End Property