Imports System.Text
Imports SunSoft.DAL

Public Class XmlCreator
    Private _XmlCode As New StringBuilder

    Private _DbServer As String, _DbName As String, _DbUser As String, _DbPass As String
    Public Enum AlignType
        Left = 1
        Center = 2
        Right = 4
    End Enum

    Public Enum DateStringType
        DateOnly = 1
        DateTime = 2
        DateHourMinute = 4
    End Enum

    Public Sub SetupDbConn(ByVal DbServer As String, ByVal DbName As String, ByVal DbUser As String, ByVal DbPass As String)
        _DbServer = DbServer
        _DbName = DbName
        _DbUser = DbUser
        _DbPass = DbPass
    End Sub

    Public Function XmlFromSQL(ByVal SqlText As String) As String
        SqlDbHelper.SetUnsafeConnString(String.Format("Server={0};Database={1};uid={2};Pwd={3}", _DbServer, _DbName, _DbUser, _DbPass))
        Dim ExecQuery As SqlDbHelper = SqlDbHelper.Create() + SqlText
        Dim TmpDt As DataTable = ExecQuery.FillDataTable()
        For Each dataColumn As DataColumn In TmpDt.Rows
            Dim i As String = dataColumn.ColumnName
        Next
        Stop
    End Function


    Public Sub NewText(ByVal FieldName As String, ByVal FieldTitle As String, ByVal TextAlign As AlignType)
        Dim newDic As New Dictionary(Of String, String)
        Dim TextCode As New StringBuilder("")
        newDic.Add("field", FieldName)
        newDic.Add("title", FieldTitle)
        newDic.Add("width", GetTitlePixel(FieldTitle).ToString())
        newDic.Add("orderby", FieldName)

        '开始拼接代码
        TextCode.Append("<cell ")
        For Each keyValuePair As KeyValuePair(Of String, String) In newDic
            TextCode.Append(keyValuePair.Key & "=""" & keyValuePair.Value & """ ")
        Next
        TextCode.Append(">" & vbCrLf)
        Select Case TextAlign
            Case AlignType.Left
                TextCode.AppendLine(String.Format("<attribute align=""left"" />"))
            Case AlignType.Center
                TextCode.AppendLine(String.Format("<attribute align=""center"" />"))
            Case AlignType.Right
                TextCode.AppendLine(String.Format("<attribute align=""right"" />"))
        End Select
        TextCode.AppendLine("</cell>")
        _XmlCode.AppendLine(TextCode.ToString())
    End Sub

    Public Sub NewNumber(ByVal FieldName As String, ByVal FieldTitle As String, ByVal IsInteger As Boolean)
        Dim newDic As New Dictionary(Of String, String)
        Dim TextCode As New StringBuilder("")
        newDic.Add("field", FieldName)
        newDic.Add("title", FieldTitle)
        newDic.Add("width", GetTitlePixel(FieldTitle).ToString())
        newDic.Add("orderby", FieldName)
        If IsInteger Then
            newDic.Add("datatype", "int")
            newDic.Add("format", "#,##0")
        Else
            newDic.Add("datatype", "money")
            newDic.Add("format", "#,##0.00")
        End If
        TextCode.Append("<cell ")
        For Each keyValuePair As KeyValuePair(Of String, String) In newDic
            TextCode.Append(keyValuePair.Key & "=""" & keyValuePair.Value & """ ")
        Next
        TextCode.Append(">" & vbCrLf)
        TextCode.AppendLine(String.Format("<attribute align=""right"" />"))
        TextCode.AppendLine("</cell>")
        _XmlCode.AppendLine(TextCode.ToString())
    End Sub

    Public Sub NewDate(ByVal FieldName As String, ByVal FieldTitle As String, ByVal DateType As DateStringType)
        Dim newDic As New Dictionary(Of String, String)
        Dim TextCode As New StringBuilder("")
        newDic.Add("field", FieldName)
        newDic.Add("title", FieldTitle)
        newDic.Add("width", GetTitlePixel(FieldTitle).ToString())
        newDic.Add("orderby", FieldName)
        Select Case DateType
            Case DateStringType.DateOnly
                newDic.Add("format", "yyyy-MM-dd")
            Case DateStringType.DateHourMinute
                newDic.Add("format", "yyyy-MM-dd HH:mm")
            Case DateStringType.DateTime
                newDic.Add("format", "yyyy-MM-dd HH:mm:ss")
        End Select
        newDic.Add("datatype", "datetime")

        TextCode.Append("<cell ")
        For Each keyValuePair As KeyValuePair(Of String, String) In newDic
            TextCode.Append(keyValuePair.Key & "=""" & keyValuePair.Value & """ ")
        Next
        TextCode.Append(">" & vbCrLf)
        TextCode.AppendLine(String.Format("<attribute align=""right"" />"))
        TextCode.AppendLine("</cell>")
        _XmlCode.AppendLine(TextCode.ToString())
    End Sub

    Public Function CreateCode() As String
        Return _XmlCode.ToString()
    End Function
#Region "内部函数"
    Private Function GetTitlePixel(ByVal TextContent As String) As Integer
        Dim e As Integer
        Dim c As Integer
        e = LenB(TextContent) - Len(TextContent)
        c = Len(TextContent) - e
        Return 6 * e + 12 * c - 1
    End Function
    Private Function LenB(ByVal oString As String) As Integer
        Dim strArray() As Byte
        Dim Strlen As Integer
        Dim MyEncoder As System.Text.Encoding = System.Text.Encoding.Default
        strArray = MyEncoder.GetBytes(oString)
        Strlen = strArray.Length
        Return Strlen
    End Function
#End Region

End Class
