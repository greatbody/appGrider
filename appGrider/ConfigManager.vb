Imports SunSoftUtility.TextProcessing
Imports System.Xml

Public Class ConfigManager
    Private _xml As String = ""
    Private _xmlDom As New XmlDocument
    Public Sub New()
        Dim _FilePath As String = Application.StartupPath & "\setting.xml"
        If IO.File.Exists(_FilePath) Then
            _xml = ReadFile(_FilePath)
            If Not String.IsNullOrEmpty(_xml) Then
                _xmlDom.LoadXml(_xml)
            Else
                _xmlDom.LoadXml("<Config><Common></Common></Config>")
            End If
        Else
            _xmlDom.LoadXml("<Config><Common></Common></Config>")
        End If
    End Sub

    Public Function GetConf(ByVal sName As String) As String
        Dim xmlItem As XmlElement = _xmlDom.SelectSingleNode("/Config/Common/Item[@Name='" & sName & "']")
        If Not xmlItem Is Nothing Then
            Return xmlItem.InnerText
        End If
        Return ""
    End Function

    Public Function SaveConf(ByVal ConfName As String, ByVal ConfValue As String) As Boolean
        Try
            Dim _confItem As XmlElement = _xmlDom.SelectSingleNode("/Config/Common/Item[@Name='" & ConfName & "']")
            If Not _confItem Is Nothing Then
                _confItem.InnerText = ConfValue
            Else
                _confItem = _xmlDom.SelectSingleNode("/Config/Common")
                '新增节点元素
                Dim newItem As XmlElement = _xmlDom.CreateElement("Item")
                '新增属性元素
                Dim newAttr As XmlAttribute = _xmlDom.CreateAttribute("Name")
                '节点元素赋值
                newItem.InnerText = ConfValue
                '属性元素赋值
                newAttr.Value = ConfName
                '属性加入到节点中
                newItem.Attributes.Append(newAttr)
                '节点加入到父节点中
                _confItem.AppendChild(newItem)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function SaveConfigFile() As Boolean
        Dim _FilePath As String = Application.StartupPath & "\setting.xml"
        If IO.File.Exists(_FilePath) Then
            Try
                IO.File.Delete(_FilePath)
            Catch ex As Exception
                MsgBox("删除配置文件失败！")
                Return False
            End Try
        End If
        WriteToFile(_FilePath, _xmlDom.OuterXml)
        Return True
    End Function
End Class
