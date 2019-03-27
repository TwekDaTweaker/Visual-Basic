Module Module1

    Enum Terrain
        null
        wall
        food
    End Enum

    Sub Main()

        Dim pos As New Vec2(3, 4)
        Dim board(20, 20) As Terrain
        Dim snake As New Head(pos)
        Dim parts As New List(Of Part)

        parts.Add(snake)

        While True
            snake.Update(board, parts)
        End While


    End Sub

End Module
