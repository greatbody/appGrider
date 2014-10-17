Imports SunSoft.DAL
Public Class Form1
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
        MsgBox(k.GetTitlePixel("中45国King成功"))

        Stop
    End Sub
End Class
