Imports System.Text
Imports SunSoft.DAL
Imports SunSoftUtility.TextProcessing
Public Class XmlCreator
    Private _XmlCode As New StringBuilder
    Private Const TAB_SIZE = 4
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
        Dim TmpDt As DataTable
        Try
            TmpDt = ExecQuery.FillDataTable()
        Catch ex As Exception
            Return "SQL错误！请检查！！！"
        End Try

        For Each dataColumn As DataColumn In TmpDt.Columns
            Dim tmpFieldName As String = dataColumn.ColumnName
            Select Case dataColumn.DataType
                Case Type.GetType("System.Decimal")
                    NewNumber(tmpFieldName, tmpFieldName, False)
                Case Type.GetType("System.Integer")
                    NewNumber(tmpFieldName, tmpFieldName, True)
                Case Type.GetType("System.DateTime")
                    NewDate(tmpFieldName, tmpFieldName, DateStringType.DateTime)
                Case Type.GetType("System.Date")
                    NewDate(tmpFieldName, tmpFieldName, DateStringType.DateOnly)
                Case Else
                    NewText(tmpFieldName, tmpFieldName, AlignType.Left)
            End Select
        Next
        Return CreateCode()
    End Function

    Public Sub ClearCache()
        _XmlCode.Clear()
    End Sub

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
                TextCode.AppendLine(String.Format(RepeatString(" ", TAB_SIZE) & "<attribute align=""left"" />"))
            Case AlignType.Center
                TextCode.AppendLine(String.Format(RepeatString(" ", TAB_SIZE) & "<attribute align=""center"" />"))
            Case AlignType.Right
                TextCode.AppendLine(String.Format(RepeatString(" ", TAB_SIZE) & "<attribute align=""right"" />"))
        End Select
        TextCode.AppendLine("</cell>")
        _XmlCode.Append(TextCode.ToString())
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
        TextCode.AppendLine(String.Format(RepeatString(" ", TAB_SIZE) & "<attribute align=""right"" />"))
        TextCode.AppendLine("</cell>")
        _XmlCode.Append(TextCode.ToString())
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
        TextCode.AppendLine(String.Format(RepeatString(" ", TAB_SIZE) & "<attribute align=""right"" />"))
        TextCode.AppendLine("</cell>")
        _XmlCode.Append(TextCode.ToString())
    End Sub

    Public Function CreateCode() As String
        Return _XmlCode.ToString()
    End Function

    Public Sub ExecBind(ByVal SqlQuery As String, ByRef lstBox As ListBox)
        '初始化列表
        lstBox.Items.Clear()
        SqlDbHelper.SetUnsafeConnString(String.Format("Server={0};Database={1};uid={2};Pwd={3}", _DbServer, _DbName, _DbUser, _DbPass))
        Dim ExecQuery As SqlDbHelper = SqlDbHelper.Create() + SqlQuery
        Dim TmpDt As DataTable
        Try
            TmpDt = ExecQuery.FillDataTable()
        Catch ex As Exception
            MsgBox("SQL错误，请检查！")
        End Try

        For Each dataColumn As DataColumn In TmpDt.Columns
            Dim tmpFieldName As String = dataColumn.ColumnName
            Select Case dataColumn.DataType
                Case Type.GetType("System.Decimal")
                    lstBox.Items.Add(tmpFieldName & ",decimal")
                Case Type.GetType("System.Integer")
                    lstBox.Items.Add(tmpFieldName & ",integer")
                Case Type.GetType("System.DateTime")
                    lstBox.Items.Add(tmpFieldName & ",datetime")
                Case Type.GetType("System.Date")
                    lstBox.Items.Add(tmpFieldName & ",date")
                Case Else
                    lstBox.Items.Add(tmpFieldName & ",string")
            End Select
        Next
    End Sub

    Public Function XmlFromListBox(ByRef LstBox As ListBox) As String
        Dim tmpArrStr() As String
        If LstBox.Items.Count = 0 Then
            Return "无选定数据"
        End If
        For i As Integer = 0 To LstBox.Items.Count - 1
            tmpArrStr = Split(LstBox.Items(i), ",")
            If tmpArrStr.Length = 2 Then
                Select Case tmpArrStr(1)
                    Case "decimal"
                        NewNumber(tmpArrStr(0), tmpArrStr(0), False)
                    Case "integer"
                        NewNumber(tmpArrStr(0), tmpArrStr(0), True)
                    Case "datetime"
                        NewDate(tmpArrStr(0), tmpArrStr(0), DateStringType.DateTime)
                    Case "date"
                        NewDate(tmpArrStr(0), tmpArrStr(0), DateStringType.DateOnly)
                    Case Else
                        NewText(tmpArrStr(0), tmpArrStr(0), AlignType.Left)
                End Select
            End If
        Next
        Return CreateCode()
    End Function
#Region "内部函数"
    Private Function GetTitlePixel(ByVal TextContent As String) As Integer
        Dim e As Integer
        Dim c As Integer
        c = LenB(TextContent) - Len(TextContent)
        e = Len(TextContent) - e
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
