Imports SunSoft.DAL
Public Class DbManager
    Private _connString As String
    Public Property ConnectionString() As String
        Get
            Return _connString
        End Get
        Set(ByVal value As String)
            _connString = value
        End Set
    End Property

    Public Structure DbInfo
        Dim DbName As String
        Dim DbId As Integer
    End Structure

    Public Sub New()
        Init()
    End Sub
    Public Sub New(ByVal ConnStr As String)
        ConnectionString = ConnStr
        Init()
    End Sub

    Private Sub Init()
        If String.IsNullOrEmpty(ConnectionString) Then
            Throw New Exception("未设置连接字符串，或连接字符串错误！")
        End If
        SqlDbHelper.SetUnsafeConnString(ConnectionString)
    End Sub

    Public Function GetDataBase() As DbInfo()
        Dim dt As New SqlDbHelper()
        dt = dt + "select [name] as DbName,[database_id] as DbId from sys.databases"
        Dim t As DataTable = dt.FillDataTable()
        Dim dbs() As DbInfo
        ReDim dbs(0)
        If t.Rows.Count > 0 Then
            ReDim dbs(t.Rows.Count - 1)
            For i As Integer = 0 To t.Rows.Count - 1
                dbs(i).DbName = t.Rows(i).Item("DbName")
                dbs(i).DbId = t.Rows(i).Item("DbId")
            Next
        End If
        Return dbs
    End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
