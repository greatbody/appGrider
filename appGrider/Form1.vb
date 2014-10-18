Imports SunSoft.DAL
Public Class MainWin
    Private _config As New ConfigManager
    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Dim k As New XmlCreator
        k.SetupDbConn(txtServer.Text, txtDbName.Text, txtUser.Text, txtPass.Text)
        Dim xml As String = k.XmlFromSQL(txtSQL.Text)
        txtXml.Clear()
        txtXml.AppendText(xml)
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
            SaveConfigData()
        End If
    End Sub

    Private Sub MainWin_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'baocunshuju
        SaveConfigData()
    End Sub
    '数据保存
    ''' <summary>
    ''' 保存页面上的配置数据
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SaveConfigData()
        With _config
            .SaveConf("server", txtServer.Text)
            .SaveConf("dbname", txtDbName.Text)
            .SaveConf("user", txtUser.Text)
            .SaveConf("pass", txtPass.Text)
            .SaveConf("defSQL", txtSQL.Text)
        End With
        _config.SaveConfigFile()
    End Sub
    '页面控制
    Private Sub MainWin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Show()
        txtServer.Text = _config.GetConf("server")
        txtDbName.Text = _config.GetConf("dbname")
        txtUser.Text = _config.GetConf("user")
        txtPass.Text = _config.GetConf("pass")

        txtSQL.Text = _config.GetConf("defSQL")
        txtSQL.SelectAll()

        AlterSetting(False)
    End Sub
    '
    Private Sub AlterSetting(ByVal AlterValue As Boolean)
        txtServer.Enabled = AlterValue
        txtDbName.Enabled = AlterValue
        txtUser.Enabled = AlterValue
        txtPass.Enabled = AlterValue
    End Sub
End Class
