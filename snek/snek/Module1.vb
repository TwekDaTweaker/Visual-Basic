Module Module1

    Sub Main()

        Dim ft As New FrameTimer
        Dim dt As Decimal = ft.Mark()
        Dim vel As New Vec2(1, 0)
        Dim speed As Decimal
        Dim elapsedTime As Decimal
        Dim snek As New List(Of Vec2)
        snek.Add(New Vec2(4, 4))
        snek.Add(New Vec2(3, 4))
        snek.Add(New Vec2(2, 4))
        snek.Add(New Vec2(1, 4))

        While (True)
            dt = ft.Mark

            Dim update = Sub(ByRef vel As Vec2, ByVal speed As Decimal, ByRef snek As List(Of Vec2))
                             If Console.KeyAvailable = True Then
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
                             End If
                             If elapsedTime > (1 / speed) Then
                                 Draw(snek(0), True)
                                 snek(0) += vel
                                 elapsedTime = 0
                             End If
                             elapsedTime += dt
                         End Sub
            update()

        End While

    End Sub

    Sub Draw(ByVal pos As Vec2, ByVal isWhite As Boolean)
        Console.SetCursorPosition(pos.x * 2, pos.y)
        If Not isWhite Then
            Console.Write("  ")
            Exit Sub
        End If
        Console.Write(Asc(219) & Asc(219))
    End Sub

End Module
