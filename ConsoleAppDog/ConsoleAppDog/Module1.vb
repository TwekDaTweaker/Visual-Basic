Module Module1

    Public Class Vec2

        Public x, y As Integer

        Public Sub New(ByVal in_x As Integer, ByVal in_y As Integer)

            x = in_x
            y = in_y

        End Sub

        Public Shared Operator +(ByVal V1 As Vec2, ByVal V2 As Vec2) As Vec2

            Return New Vec2(V1.x + V2.x, V1.y + V2.y)

        End Operator

        Public Shared Operator -(ByVal V1 As Vec2, ByVal V2 As Vec2) As Vec2

            Return New Vec2(V1.x - V2.x, V1.y - V2.y)

        End Operator

    End Class

    Enum State

        null
        won
        lost

    End Enum

    Const height As Integer = 7
    Const width As Integer = 7

    Sub Main()

        Dim map(height, width)

        Dim house As New Vec2(0, 0)
        Dim DogPos As New Vec2(0, 0)
        Dim CatchPos As New Vec2(0, 0)

        While True

            Setup(house, DogPos, CatchPos)

            While True

                Dim gameState As Integer = State.null

                UpdateDogPos(DogPos, house, gameState)
                UpdateCatchPos(CatchPos, DogPos, house, gameState)

                If gameState = State.lost Then

                    Console.Clear()
                    Console.SetWindowSize(120, 30)
                    Console.WriteLine("You loose!")
                    Exit While

                ElseIf gameState = State.won Then

                    Console.Clear()
                    Console.SetWindowSize(120, 30)
                    Console.WriteLine("You win!")
                    Exit While

                End If

            End While

            Console.Write(vbNewLine & "Would you like to continue playing? (y/n)")
            Dim key

            Do

                Console.SetCursorPosition(42, 2)

                key = Console.ReadKey()

                Console.SetCursorPosition(42, 2)
                Console.Write(" ")

                If key.KeyChar = "n" Then

                    Exit While

                End If

            Loop Until LCase(key.keyChar) = "y" Or LCase(key.keyChar) = "n"

        End While

    End Sub

    Sub UpdateDogPos(ByRef DogPos As Vec2, ByVal house As Vec2, ByRef gameState As Integer)

        Dim allowed As Boolean = False

        Do

            Console.SetCursorPosition((DogPos.x * 2) + 1, DogPos.y)

            Dim key = Console.ReadKey()

            Console.SetCursorPosition((DogPos.x * 2) + 1, DogPos.y)
            Console.Write(" ")

            Select Case LCase(key.KeyChar)

                Case "w"

                    If DogPos.y > 0 Then

                        DogPos = New Vec2(DogPos.x, DogPos.y - 1)
                        allowed = True

                    End If

                Case "a"

                    If DogPos.x > 0 Then

                        DogPos = New Vec2(DogPos.x - 1, DogPos.y)
                        allowed = True

                    End If

                Case "s"

                    If DogPos.y < height Then

                        DogPos = New Vec2(DogPos.x, DogPos.y + 1)
                        allowed = True

                    End If

                Case "d"

                    If DogPos.x < width Then

                        DogPos = New Vec2(DogPos.x + 1, DogPos.y)
                        allowed = True

                    End If

            End Select

            If DogPos.x = house.x And DogPos.y = house.y Then

                Console.SetCursorPosition((DogPos.x * 2) + 1, DogPos.y)
                Console.Write("H")

                gameState = State.won
                Exit Sub

            End If

            Console.SetCursorPosition((DogPos.x * 2) + 1, DogPos.y)
            Console.Write("D")

        Loop Until allowed

    End Sub

    Sub UpdateCatchPos(ByRef CatchPos As Vec2, ByVal DogPos As Vec2, ByVal house As Vec2, ByRef gameState As Integer)

        Console.SetCursorPosition((CatchPos.x * 2) + 1, CatchPos.y)
        Console.Write(" ")

        If Math.Abs(CatchPos.x - DogPos.x) > Math.Abs(CatchPos.y - DogPos.y) Then

            If CatchPos.x - DogPos.x < 0 Then

                CatchPos.x += 1

            Else

                CatchPos.x -= 1

            End If

        Else

            If CatchPos.y - DogPos.y < 0 Then

                CatchPos.y += 1

            Else

                CatchPos.y -= 1

            End If

        End If

        Console.SetCursorPosition((CatchPos.x * 2) + 1, CatchPos.y)
        Console.Write("C")

        If CatchPos.x = DogPos.x And CatchPos.y = DogPos.y Then

            gameState = State.lost

        End If

    End Sub

    Sub Setup(ByRef house As Vec2, ByRef DogPos As Vec2, ByRef CatchPos As Vec2)

        Console.Clear()
        Console.Write("Setting up")

        'set random positions
        Randomize()
        Dim rand As New Random

        house = New Vec2(Int(rand.Next(1, width)), Int(rand.Next(0, height)))

        Do

            DogPos = New Vec2(Int(rand.Next(1, width)), Int(rand.Next(0, height)))

        Loop Until (DogPos.x - house.x) ^ 2 > 4 Or (DogPos.y - house.y) ^ 2 > 4

        Do

            CatchPos = New Vec2(Int(rand.Next(1, width)), Int(rand.Next(0, height)))

        Loop Until Math.Abs(DogPos.x - CatchPos.x) > 2 Or Math.Abs(DogPos.y - CatchPos.y) > 2

        Console.Write(".")

        Console.Write(".")

        Console.Write(". Done!" & vbNewLine & vbNewLine & "Press any key to start.")
        Console.ReadKey()

        Console.SetWindowSize(width * 2 + 7, height + 3)
        DrawGrid(house, DogPos, CatchPos)

    End Sub

    Sub DrawGrid(ByVal house As Vec2, ByVal DogPos As Vec2, ByVal CatchPos As Vec2)

        Console.Clear()
        Console.CursorVisible = False

        For j = 0 To height

            Console.Write("|")

            For i = 0 To width

                Console.Write(" |")

            Next

            Console.Write(vbNewLine)

        Next

        Console.SetCursorPosition((house.x * 2) + 1, house.y)
        Console.Write("H")

        Console.SetCursorPosition((DogPos.x * 2) + 1, DogPos.y)
        Console.Write("D")

        Console.SetCursorPosition((CatchPos.x * 2) + 1, CatchPos.y)
        Console.Write("C")

    End Sub

End Module
