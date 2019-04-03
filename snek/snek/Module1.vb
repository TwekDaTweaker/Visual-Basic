Module Module1

    Sub Main()

        Console.WindowHeight = 30
        Console.WindowWidth = 30 * 2

        Dim isAlive As Boolean = True
        Dim ft As New FrameTimer
        Dim dt As Decimal = ft.Mark()
        Dim vel As New Vec2(1, 0)
        Dim oldvel As New Vec2()
        Dim speed As Decimal = 10
        Dim elapsedTime As Decimal
        Dim snek As New List(Of Vec2)
        Dim super As Boolean = False

        Randomize()
        Dim rand As New Random
        Dim food As New Vec2(rand.Next(0, Console.WindowWidth / 2 - 1), rand.Next(0, Console.WindowHeight))

        snek.Add(New Vec2(6, 4))
        snek.Add(New Vec2(5, 4))
        snek.Add(New Vec2(4, 4))

        While True
            While (isAlive)
            dt = ft.Mark

            'Gets velocity
            If Console.KeyAvailable = True Then
                Dim key = Console.ReadKey(True)
                    If key.Key = ConsoleKey.Escape Then
                        Console.SetCursorPosition(Console.WindowWidth / 2 - 2, Console.WindowHeight / 2 - 1)
                        Console.Write("Pause")
                        key = Console.ReadKey(True)
                        Console.SetCursorPosition(Console.WindowWidth / 2 - 2, Console.WindowHeight / 2 - 1)
                        Console.Write("     ")
                    End If
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
            If oldvel + vel = New Vec2(0, 0) Then vel = oldvel

                If elapsedTime > (1 / (speed + (snek.Count / 10))) Then
                    'Updates the snake's position
                    Draw(snek(snek.Count - 1), ConsoleColor.Black)
                    For i = snek.Count - 1 To 1 Step -1
                        snek(i) = snek(i - 1)
                    Next
                    snek(0) += vel
                    oldvel = New Vec2(vel)

                    'Cheks if the food is eaten
                    If snek(0) = food Then
                        If super Then
                            snek.Add(snek(snek.Count - 1))
                            snek.Add(snek(snek.Count - 1))
                            snek.Add(snek(snek.Count - 1))
                            snek.Add(snek(snek.Count - 1))
                        End If
                        snek.Add(snek(snek.Count - 1))
                        super = False
                        food.x = rand.Next(0, Console.WindowWidth / 2 - 1)
                        food.y = rand.Next(0, Console.WindowHeight)
                        If rand.Next(1, 8) = 1 Then super = True
                    End If

                    'Check if the snake died
                    For i = 1 To snek.Count - 1
                        If snek(0) = snek(i) Then
                            isAlive = False
                            Exit While
                        End If
                    Next
                    If snek(0).x < 0 Or snek(0).y < 0 Or snek(0).x * 2 + 2 > Console.WindowWidth Or snek(0).y > Console.WindowHeight - 1 Then
                        isAlive = False
                        Exit While
                    End If

                    'Draws snake and food
                    For Each part In snek
                        Draw(part, ConsoleColor.White)
                    Next
                    If super Then
                        Draw(food, ConsoleColor.Yellow)
                    Else
                        Draw(food, ConsoleColor.Green)
                    End If
                    elapsedTime = 0
                End If

                elapsedTime += dt
            End While

            Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2 - 1)
            Console.Write("You Died!")
            Console.ReadKey(True)
            Console.Clear()
            snek.Clear()
            snek.Add(New Vec2(6, 4))
            snek.Add(New Vec2(5, 4))
            snek.Add(New Vec2(4, 4))
            food.x = rand.Next(0, Console.WindowWidth / 2 - 1)
            food.y = rand.Next(0, Console.WindowHeight)
            vel = New Vec2(1, 0)
            oldvel = New Vec2(vel)
            isAlive = True

        End While

    End Sub

    Sub Draw(ByVal pos As Vec2, ByVal color As ConsoleColor)
        Console.SetCursorPosition(pos.x * 2, pos.y)
        Console.CursorVisible = False
        Console.BackgroundColor = color
        Console.Write("  ")
        Console.ResetColor()
    End Sub

End Module
