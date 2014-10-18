Imports SunSoft.DAL
Public Class MainWin
    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        'Dim k As New SqlClient.SqlConnection("")
        'k.ConnectionString = String.Format("Server={0};uid=sa;Pwd={1};", "SUNSOFT-PC\SUNSOFTSQL", "windows")
        'Dim com As New SqlClient.SqlCommand
        'com.Connection = k
        'com.CommandText = "select * from sys.databases"
        'com.
        'k.Open()
        'k.Close()
        'SqlDbHelper.SetUnsafeConnString(String.Format("Server={0};uid=sa;Pwd={1};", "SUNSOFT-PC\SUNSOFTSQL", "windows"))
        'Dim dbm As New DbManager(String.Format("Server={0};uid=sa;Pwd={1};", "SUNSOFT-PC\SUNSOFTSQL", "windows"))
        'Dim k() As DbManager.DbInfo = dbm.GetDataBase()
        Dim k As New XmlCreator
        k.SetupDbConn(txtServer.Text, txtDbName.Text, txtUser.Text, txtPass.Text)
        'k.NewNumber("TotalDj", "底价总价", False)
        Dim xml As String = k.XmlFromSQL(txtSQL.Text)
        Stop
    End Sub

    Private Sub txtSQL_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSQL.KeyDown
        If e.KeyCode = Keys.A AndAlso (e.KeyData And Keys.Control) Then
            '全选
            txtSQL.SelectAll()
        End If
    End Sub


    Private Sub chkEnConfig_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEnConfig.CheckedChanged
        If chkEnConfig.CheckState = CheckState.Checked Then
            txtServer.Enabled = True
            txtDbName.Enabled = True
            txtUser.Enabled = True
            txtPass.Enabled = True
        Else
            txtServer.Enabled = False
            txtDbName.Enabled = False
            txtUser.Enabled = False
            txtPass.Enabled = False
        End If
    End Sub
End Class
