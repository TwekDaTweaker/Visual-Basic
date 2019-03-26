Public Class Part

    Protected pos As Vec2
    Protected father As Part
    Protected child As Part
    Private color As ConsoleColor

    Public Sub New(ByVal pos As Vec2, ByVal father As Part, ByVal color As ConsoleColor)
        Me.pos = pos
        Me.father = father
        Me.color = color
    End Sub

    Protected Sub Draw()
        Draw(pos, color)
    End Sub

    Protected Sub Draw(ByVal pos As Vec2, ByVal color As ConsoleColor)
        Console.SetCursorPosition(pos.y * 2, pos.x * 2)
        Console.BackgroundColor = color
        Console.Write("  ")
        Console.ResetColor()
    End Sub

    Public Function GetPos() As Vec2
        Return pos
    End Function

    Public Overridable Sub Update()
        Draw(pos, ConsoleColor.Black)
        pos = father.GetPos()
        Draw()
    End Sub

    Public Sub MakeChild(ByRef child As Part)
        Dim c As ConsoleColor = ConsoleColor.Green
        If color = ConsoleColor.Green Then c = ConsoleColor.DarkGreen
        child = New Part(Me.GetPos(), Me, c)
    End Sub

End Class
