''' <summary>
''' 本类提供对控件快捷键ctrl+a的支持，仅适用于于TextBox等支持文本全选的控件。
''' </summary>
''' <remarks></remarks>
Public Class ControlBinder
    Public Sub BindTextBox(ByRef CControl As TextBox)
        AddHandler CControl.KeyDown, AddressOf TextSelectAll
    End Sub

    Private Sub TextSelectAll(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim txtControl As TextBox = CType(sender, TextBox)
        If e.KeyCode = Keys.A AndAlso (e.KeyData And Keys.Control) Then
            '全选
            txtControl.SelectAll()
        End If
        e.SuppressKeyPress = True
    End Sub
End Class
