''' <summary>
''' 本类提供对于控件拖动的处理。简化拖动操作。
''' </summary>
''' <remarks></remarks>
Public Class ControlMoveBinder
    ''' <summary>
    ''' 定义记录鼠标当前按键状态的变量
    ''' </summary>
    ''' <remarks></remarks>
    Private _mouseState As MouseState = MouseState.MouseUp
    ''' <summary>
    ''' 定义记录鼠标当前坐标的两个变量
    ''' </summary>
    ''' <remarks></remarks>
    Private _locX As Integer, _locY As Integer
    ''' <summary>
    ''' 记录本次是否拖动过。
    ''' </summary>
    ''' <remarks></remarks>
    Private _throughMove As Boolean
    ''' <summary>
    ''' 定义记录鼠标按键状态的枚举类型
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum MouseState
        MouseDown = 1
        MouseUp = 2
    End Enum
    ''' <summary>
    ''' 绑定指定的控件，控件的移动操作将有类在内部进行操作
    ''' </summary>
    ''' <param name="CtlObj"></param>
    ''' <remarks></remarks>
    Public Sub BindControl(ByRef CtlObj As Control)
        ' Dim obj As Control = CType(CtlObj, Control)
        AddHandler CtlObj.MouseDown, AddressOf MouseDown
        AddHandler CtlObj.MouseUp, AddressOf MouseUp
        AddHandler CtlObj.MouseMove, AddressOf MouseMove
    End Sub
    ''' <summary>
    ''' 内部函数，处理鼠标按下
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MouseDown(ByVal sender As Object, ByVal e As Windows.Forms.MouseEventArgs)
        _locX = e.X
        _locY = e.Y
        _mouseState = MouseState.MouseDown
    End Sub
    ''' <summary>
    ''' 处理鼠标弹起的事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MouseUp(ByVal sender As Object, ByVal e As Windows.Forms.MouseEventArgs)
        _mouseState = MouseState.MouseUp
    End Sub
    ''' <summary>
    ''' 处理鼠标移动的事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MouseMove(ByVal sender As Object, ByVal e As Windows.Forms.MouseEventArgs)
        If _mouseState = MouseState.MouseDown Then
            Dim iControl As Control = CType(sender, Control)
            With iControl
                .Left = .Left - _locX + e.X
                .Top = .Top - _locY + e.Y
            End With
        End If
    End Sub

End Class
