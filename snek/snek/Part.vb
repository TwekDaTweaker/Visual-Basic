Public Class Part

    Private pos As Vec2
    Protected father As Part
    Protected child As Part
    Private color As System.ConsoleColor

    Public Sub Draw()
        Console.SetCursorPosition(pos.y, pos.x)
    End Sub

    Public Sub Update()

    End Sub

End Class
