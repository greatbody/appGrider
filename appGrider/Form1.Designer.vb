<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainWin
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainWin))
        Me.btnOk = New System.Windows.Forms.Button()
        Me.txtSQL = New System.Windows.Forms.TextBox()
        Me.grpConfig = New System.Windows.Forms.GroupBox()
        Me.chkEnConfig = New System.Windows.Forms.CheckBox()
        Me.txtPass = New System.Windows.Forms.TextBox()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.txtDbName = New System.Windows.Forms.TextBox()
        Me.txtServer = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtXml = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.grpField = New System.Windows.Forms.GroupBox()
        Me.lstDest = New System.Windows.Forms.ListBox()
        Me.lstSource = New System.Windows.Forms.ListBox()
        Me.btnGetItems = New System.Windows.Forms.Button()
        Me.btnClearS = New System.Windows.Forms.Button()
        Me.btnClearD = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.chkRepeater = New System.Windows.Forms.CheckBox()
        Me.grpConfig.SuspendLayout()
        Me.grpField.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(721, 452)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(88, 33)
        Me.btnOk.TabIndex = 0
        Me.btnOk.Text = "2)获取XML"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'txtSQL
        '
        Me.txtSQL.Location = New System.Drawing.Point(12, 12)
        Me.txtSQL.Multiline = True
        Me.txtSQL.Name = "txtSQL"
        Me.txtSQL.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSQL.Size = New System.Drawing.Size(500, 209)
        Me.txtSQL.TabIndex = 1
        '
        'grpConfig
        '
        Me.grpConfig.Controls.Add(Me.chkRepeater)
        Me.grpConfig.Controls.Add(Me.chkEnConfig)
        Me.grpConfig.Controls.Add(Me.txtPass)
        Me.grpConfig.Controls.Add(Me.txtUser)
        Me.grpConfig.Controls.Add(Me.txtDbName)
        Me.grpConfig.Controls.Add(Me.txtServer)
        Me.grpConfig.Controls.Add(Me.Label4)
        Me.grpConfig.Controls.Add(Me.Label3)
        Me.grpConfig.Controls.Add(Me.Label2)
        Me.grpConfig.Controls.Add(Me.Label1)
        Me.grpConfig.Location = New System.Drawing.Point(525, 7)
        Me.grpConfig.Name = "grpConfig"
        Me.grpConfig.Size = New System.Drawing.Size(368, 150)
        Me.grpConfig.TabIndex = 2
        Me.grpConfig.TabStop = False
        Me.grpConfig.Text = "配置数据库"
        '
        'chkEnConfig
        '
        Me.chkEnConfig.AutoSize = True
        Me.chkEnConfig.Location = New System.Drawing.Point(78, 0)
        Me.chkEnConfig.Name = "chkEnConfig"
        Me.chkEnConfig.Size = New System.Drawing.Size(72, 16)
        Me.chkEnConfig.TabIndex = 8
        Me.chkEnConfig.Text = "启用编辑"
        Me.chkEnConfig.UseVisualStyleBackColor = True
        '
        'txtPass
        '
        Me.txtPass.Location = New System.Drawing.Point(62, 120)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(45)
        Me.txtPass.Size = New System.Drawing.Size(296, 21)
        Me.txtPass.TabIndex = 7
        '
        'txtUser
        '
        Me.txtUser.Location = New System.Drawing.Point(62, 87)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(296, 21)
        Me.txtUser.TabIndex = 6
        '
        'txtDbName
        '
        Me.txtDbName.Location = New System.Drawing.Point(62, 55)
        Me.txtDbName.Name = "txtDbName"
        Me.txtDbName.Size = New System.Drawing.Size(296, 21)
        Me.txtDbName.TabIndex = 5
        '
        'txtServer
        '
        Me.txtServer.Location = New System.Drawing.Point(62, 22)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(296, 21)
        Me.txtServer.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 123)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 12)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "密  码"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 91)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "账  号"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "数据库"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "服务器"
        '
        'txtXml
        '
        Me.txtXml.Location = New System.Drawing.Point(12, 266)
        Me.txtXml.Multiline = True
        Me.txtXml.Name = "txtXml"
        Me.txtXml.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtXml.Size = New System.Drawing.Size(500, 219)
        Me.txtXml.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Location = New System.Drawing.Point(367, 222)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(144, 44)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "复制到剪贴板(&C)"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'grpField
        '
        Me.grpField.Controls.Add(Me.lstDest)
        Me.grpField.Controls.Add(Me.lstSource)
        Me.grpField.Location = New System.Drawing.Point(525, 165)
        Me.grpField.Name = "grpField"
        Me.grpField.Size = New System.Drawing.Size(368, 281)
        Me.grpField.TabIndex = 5
        Me.grpField.TabStop = False
        Me.grpField.Text = "导出排序"
        '
        'lstDest
        '
        Me.lstDest.FormattingEnabled = True
        Me.lstDest.ItemHeight = 12
        Me.lstDest.Location = New System.Drawing.Point(200, 20)
        Me.lstDest.Name = "lstDest"
        Me.lstDest.Size = New System.Drawing.Size(162, 256)
        Me.lstDest.TabIndex = 1
        '
        'lstSource
        '
        Me.lstSource.FormattingEnabled = True
        Me.lstSource.ItemHeight = 12
        Me.lstSource.Location = New System.Drawing.Point(9, 20)
        Me.lstSource.Name = "lstSource"
        Me.lstSource.Size = New System.Drawing.Size(161, 256)
        Me.lstSource.TabIndex = 0
        '
        'btnGetItems
        '
        Me.btnGetItems.Location = New System.Drawing.Point(534, 452)
        Me.btnGetItems.Name = "btnGetItems"
        Me.btnGetItems.Size = New System.Drawing.Size(95, 33)
        Me.btnGetItems.TabIndex = 6
        Me.btnGetItems.Text = "1)获取列表项"
        Me.btnGetItems.UseVisualStyleBackColor = True
        '
        'btnClearS
        '
        Me.btnClearS.Location = New System.Drawing.Point(643, 452)
        Me.btnClearS.Name = "btnClearS"
        Me.btnClearS.Size = New System.Drawing.Size(52, 33)
        Me.btnClearS.TabIndex = 7
        Me.btnClearS.Text = "清空"
        Me.btnClearS.UseVisualStyleBackColor = True
        '
        'btnClearD
        '
        Me.btnClearD.Location = New System.Drawing.Point(831, 452)
        Me.btnClearD.Name = "btnClearD"
        Me.btnClearD.Size = New System.Drawing.Size(52, 33)
        Me.btnClearD.TabIndex = 8
        Me.btnClearD.Text = "清空"
        Me.btnClearD.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Location = New System.Drawing.Point(12, 222)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(144, 44)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "直接获取XML"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'chkRepeater
        '
        Me.chkRepeater.AutoSize = True
        Me.chkRepeater.Location = New System.Drawing.Point(156, 0)
        Me.chkRepeater.Name = "chkRepeater"
        Me.chkRepeater.Size = New System.Drawing.Size(72, 16)
        Me.chkRepeater.TabIndex = 9
        Me.chkRepeater.Text = "Repeater"
        Me.chkRepeater.UseVisualStyleBackColor = True
        '
        'MainWin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(913, 496)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnClearD)
        Me.Controls.Add(Me.btnClearS)
        Me.Controls.Add(Me.btnGetItems)
        Me.Controls.Add(Me.grpField)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtXml)
        Me.Controls.Add(Me.grpConfig)
        Me.Controls.Add(Me.txtSQL)
        Me.Controls.Add(Me.btnOk)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MainWin"
        Me.Text = "欢迎使用appGrid生成工具"
        Me.grpConfig.ResumeLayout(False)
        Me.grpConfig.PerformLayout()
        Me.grpField.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents txtSQL As System.Windows.Forms.TextBox
    Friend WithEvents grpConfig As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkEnConfig As System.Windows.Forms.CheckBox
    Friend WithEvents txtPass As System.Windows.Forms.TextBox
    Friend WithEvents txtUser As System.Windows.Forms.TextBox
    Friend WithEvents txtDbName As System.Windows.Forms.TextBox
    Friend WithEvents txtServer As System.Windows.Forms.TextBox
    Friend WithEvents txtXml As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents grpField As System.Windows.Forms.GroupBox
    Friend WithEvents lstDest As System.Windows.Forms.ListBox
    Friend WithEvents lstSource As System.Windows.Forms.ListBox
    Friend WithEvents btnGetItems As System.Windows.Forms.Button
    Friend WithEvents btnClearS As System.Windows.Forms.Button
    Friend WithEvents btnClearD As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents chkRepeater As System.Windows.Forms.CheckBox

End Class
