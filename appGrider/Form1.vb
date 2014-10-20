Imports SunSoft.DAL
Public Class MainWin
    Private _config As New ConfigManager
    Private _TextBinder As New ControlBinder
    'Private _LocX As Integer
    'Private _LocY As Integer
    'Private _KeyDown As Boolean = False
    Private _moveBinder As New ControlMoveBinder
    Private k As New XmlCreator
    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        k.ClearCache()
        txtXml.Text = k.XmlFromListBox(lstDest)
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

        _TextBinder.BindTextBox(txtSQL)
        _TextBinder.BindTextBox(txtXml)

    End Sub
    '
    Private Sub AlterSetting(ByVal AlterValue As Boolean)
        txtServer.Enabled = AlterValue
        txtDbName.Enabled = AlterValue
        txtUser.Enabled = AlterValue
        txtPass.Enabled = AlterValue
    End Sub


    Private Sub btnGetItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetItems.Click

        k.SetupDbConn(txtServer.Text, txtDbName.Text, txtUser.Text, txtPass.Text)
        k.ExecBind(txtSQL.Text, lstSource)
    End Sub

    Private Sub lstSource_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstSource.MouseClick
        If lstSource.Items.Count > 0 AndAlso lstSource.SelectedIndex >= 0 Then
            lstDest.Items.Add(lstSource.Items(lstSource.SelectedIndex).ToString())
            lstSource.Items.RemoveAt(lstSource.SelectedIndex)
        End If
    End Sub

    Private Sub lstDest_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstDest.MouseClick
        If lstDest.Items.Count > 0 AndAlso lstDest.SelectedIndex >= 0 Then
            lstSource.Items.Add(lstDest.Items(lstDest.SelectedIndex).ToString())
            lstDest.Items.RemoveAt(lstDest.SelectedIndex)
        End If
    End Sub

    Private Sub btnClearS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearS.Click
        lstSource.Items.Clear()
    End Sub

    Private Sub btnClearD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearD.Click
        lstDest.Items.Clear()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Clipboard.Clear()
        Clipboard.SetText(txtXml.Text)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        k.SetupDbConn(txtServer.Text, txtDbName.Text, txtUser.Text, txtPass.Text)
        txtXml.Text = k.XmlFromSQL(txtSQL.Text)
    End Sub
End Class
