Public Class Head

    Inherits Part

    Private vel As Vec2

    Public Sub New(ByVal pos As Vec2)
        MyBase.New(pos, Nothing, System.ConsoleColor.DarkRed)
        Randomize()
        Dim rand As New Random()
        Dim temp As Integer = 0
        While temp = 0
            temp = rand.Next(-1, 2)
        End While
        vel.x = temp
        temp = 0
        While temp = 0
            temp = rand.Next(-1, 2)
        End While
        vel.y = temp
    End Sub

    Public Overrides Sub Update()
        Windows.Input.GetKeyState()
        Me.pos += vel
    End Sub

End Class
