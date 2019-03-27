Public Class Head

    Inherits Part

    Enum Terrain
        null
        wall
        food
    End Enum

    Private vel As New Vec2(0, 0)

    Public Sub New(ByVal pos As Vec2)
        MyBase.New(pos, Nothing)
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
        Console.CursorVisible = False
    End Sub

    Public Sub Update(ByVal board(,) As Terrain, ByRef parts As List(Of Part))
        Dim key = Console.ReadKey(True)
        Select Case LCase(key.KeyChar())
            Case "w"
                vel.y = -1
                vel.x = 0
            Case "a"
                vel.x = -1
                vel.y = 0
            Case "s"
                vel.y = +1
                vel.x = 0
            Case "d"
                vel.x = +1
                vel.y = 0
        End Select
        Draw(pos, ConsoleColor.Black) 'Potential bugs
        Me.pos += vel
        Draw()
        If board(pos.y, pos.x) = Terrain.food Then
            Dim temp As New Part(parts(parts.Count - 1).GetPos(), parts(parts.Count - 1))
            Me.MakeChild(temp)
            parts.Add(temp)
        End If
    End Sub

End Class
