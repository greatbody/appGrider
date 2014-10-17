Imports System.Text

Public Class XmlCreator
    Private _XmlCode As StringBuilder
    Public Enum AlignType
        Left = 1
        Center = 2
        Right = 4
    End Enum

    Public Sub NewText(ByVal FieldName As String, ByVal FieldTitle As String, ByVal TextAlign As AlignType)
        Dim TextCode As New StringBuilder("")
        TextCode.AppendLine(String.Format("<cell field=""{0}"" title=""{1}"" width=""{2}"" orderby=""{0}"">", FieldName, FieldTitle, GetTitlePixel(FieldTitle)))
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
            newDic.Add("format", "#,##0")
        Else
            newDic.Add("format", "#,##0.00")
        End If
        TextCode.Append("<cell ")
        For Each keyValuePair As KeyValuePair(Of String,String) In newDic
            TextCode.Append(keyValuePair.Key & "=""" & keyValuePair.Value & """ ")
        Next
        TextCode.Append(">" & vbCrLf)
        TextCode.AppendLine(String.Format("<attribute align=""right"" />"))
        TextCode.AppendLine("</cell>")
        _XmlCode.AppendLine(TextCode.ToString())
    End Sub

    Public Function CreateCode() As String

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
