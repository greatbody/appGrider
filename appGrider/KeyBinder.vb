Public Class KeyBinder
    Public Sub BindControl(ByRef CControl As TextBox)
        AddHandler CControl.KeyDown, AddressOf TextKeyDown
    End Sub

    Private Sub TextKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        MsgBox(sender)
        Dim txtControl As TextBox = CType(sender, TextBox)
        If e.KeyCode = Keys.A AndAlso (e.KeyData And Keys.Control) Then
            '全选
            txtControl.SelectAll()
        End If
        e.SuppressKeyPress = True
    End Sub
End Class
