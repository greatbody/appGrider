Imports System.Text

Public Class XmlCreator
    Private _XmlCode As StringBuilder
    Public Enum AlignType

    End Enum

    Public Sub NewText(ByVal FieldName As String, ByVal FieldTitle As String, ByVal AlignType As String)
        Dim TextCode As New StringBuilder("")
        TextCode.AppendLine(String.Format("<cell field=""{0}"" title=""{1}"" width=""{2}"" orderby=""{0}"">", FieldName, FieldTitle, GetTitlePixel(FieldTitle)))
        '        <cell field ="字段" title ="[中文字段名]" width ="65" orderby ="DjArea">
        '  <attribute align ="center" />
        '</cell>

    End Sub

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
