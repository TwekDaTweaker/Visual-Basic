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

    Const height As Integer = 16
    Const width As Integer = 16

    Sub Main()

        Dim house As Vec2
        Dim DogPos As Vec2
        Dim CatchPos As Vec2

        While True

            Setup(house, DogPos, CatchPos)

            While True

                Dim caught As Boolean = False

                UpdateDogPos(DogPos)
                UpdateCatchPos(DogPos, CatchPos, caught)

                If caught Then

                    Console.Clear()
                    Console.SetWindowSize(120, 30)
                    Console.WriteLine("You loose!")
                    Exit While

                End If

            End While

            Console.Write(vbNewLine & "Would you like to continue playing? (y/n)")

            Dim key = Console.ReadKey()

            If key.KeyChar = "n" Then

                Exit While

            End If

        End While


        Console.ReadKey()

    End Sub

    Sub UpdateDogPos(ByRef DogPos As Vec2)

        Dim allowed As Boolean = False

        Do

            Console.SetCursorPosition(0, 0)

            Dim key = Console.ReadKey()

            Console.SetCursorPosition(0, 0)
            Console.Write("|")

            Console.SetCursorPosition((DogPos.x * 2) - 1, DogPos.y)
            Console.Write(" ")

            Select Case key.KeyChar

                Case "w"

                    If DogPos.y > 0 Then

                        DogPos = New Vec2(DogPos.x, DogPos.y - 1)
                        allowed = True

                    End If

                Case "a"

                    If DogPos.x > 1 Then

                        DogPos = New Vec2(DogPos.x - 1, DogPos.y)
                        allowed = True

                    End If

                Case "s"

                    If DogPos.y < height Then

                        DogPos = New Vec2(DogPos.x, DogPos.y + 1)
                        allowed = True

                    End If

                Case "d"

                    If DogPos.x < width + 1 Then

                        DogPos = New Vec2(DogPos.x + 1, DogPos.y)
                        allowed = True

                    End If

            End Select

            Console.SetCursorPosition((DogPos.x * 2) - 1, DogPos.y)
            Console.Write("D")

        Loop Until allowed

    End Sub

    Sub UpdateCatchPos(ByRef DogPos As Vec2, ByRef CatchPos As Vec2, ByRef caught As Boolean)



    End Sub

    Sub Setup(ByRef house As Vec2, ByRef DogPos As Vec2, ByRef CatchPos As Vec2)

        Console.Clear()
        Console.Write("Setting up")

        Randomize()
        Dim rand As New Random

        house = New Vec2(Int(rand.Next(1, width)), Int(rand.Next(0, height)))

        Console.Write(".")

        Do

            DogPos = New Vec2(Int(rand.Next(1, width)), Int(rand.Next(0, height)))

        Loop Until (DogPos.x - house.x) ^ 2 > 4 Or (DogPos.y - house.y) ^ 2 > 4

        Console.Write(".")

        Do

            CatchPos = New Vec2(Int(rand.Next(1, width)), Int(rand.Next(0, height)))

        Loop Until (DogPos.x - CatchPos.x) ^ 2 > 4 Or (DogPos.y - CatchPos.y) ^ 2 > 4

        Console.Write(". Done!" & vbNewLine & vbNewLine & "Press any key to start.")
        Console.ReadKey()

        Console.SetWindowSize(width * 2 + 7, height + 3)
        DrawGrid(house, DogPos, CatchPos)

    End Sub

    Sub DrawGrid(ByVal house As Vec2, ByVal DogPos As Vec2, ByVal CatchPos As Vec2)

        Console.Clear()
        Console.CursorVisible = False

        For j = 0 To height

            For i = 0 To width

                Console.Write("| ")

            Next

            Console.Write("|" & vbNewLine)

        Next

        Console.SetCursorPosition((house.x * 2) - 1, house.y)
        Console.Write("H")

        Console.SetCursorPosition((DogPos.x * 2) - 1, DogPos.y)
        Console.Write("D")

        Console.SetCursorPosition((CatchPos.x * 2) - 1, CatchPos.y)
        Console.Write("C")

    End Sub

End Module
