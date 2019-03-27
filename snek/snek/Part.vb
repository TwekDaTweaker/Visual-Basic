Public Class Part

    Protected pos As Vec2
    Protected father As Part
    Protected child As Part
    Private color As ConsoleColor

    Public Sub New(ByVal pos As Vec2, ByVal father As Part)
        Me.pos = pos
        Me.father = father
        Me.color = ConsoleColor.White
        Me.child = Nothing
        Console.CursorVisible = False
    End Sub

    Protected Sub Draw()
        Draw(pos, color)
    End Sub

    Protected Sub Draw(ByVal pos As Vec2, ByVal color As ConsoleColor)
        Console.SetCursorPosition(pos.x * 2, pos.y)
        Console.BackgroundColor = color
        Console.Write("  ")
        Console.ResetColor()
    End Sub

    Public Function GetPos() As Vec2
        Return pos
    End Function

    Public Sub Update()
        If Me.child.color = Nothing Then Draw(pos, ConsoleColor.Black) 'Potential bugs
        pos = father.GetPos()
        Draw()
    End Sub

    Public Sub MakeChild(ByRef child As Part)
        child = New Part(Me.GetPos(), Me)
    End Sub

End Class
