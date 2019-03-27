Module Module1

    Sub Main()

        Dim pos As New Vec2(3, 4)
        Dim snake As New Head(pos)
        Dim parts As New List(Of Part)
        Dim food As New List(Of Vec2)
        Dim ft As New FrameTimer
        Dim dt As Decimal

        parts.Add(snake)

        While True
            dt = ft.Mark()
            snake.Update(food, parts, dt)
        End While


    End Sub

End Module
