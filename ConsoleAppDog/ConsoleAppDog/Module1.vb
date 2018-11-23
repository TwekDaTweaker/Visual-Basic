Module Module1

    Public Class Vec2

        Public x As Integer = 0
        Public y As Integer = 0

        Public Sub New(ByVal in_x As Integer, ByVal in_y As Integer)

            x = in_x
            y = in_y

        End Sub

        Public Shared Operator =(ByVal V1 As Vec2, ByVal V2 As Vec2) As Boolean

            Return V1.x = V2.x And V1.y = V2.y

        End Operator

        Public Shared Operator <>(ByVal V1 As Vec2, ByVal V2 As Vec2) As Boolean

            Return V1.x <> V2.x Or V1.y <> V2.y

        End Operator

        Public Shared Operator +(ByVal V1 As Vec2, ByVal V2 As Vec2) As Vec2

            Return New Vec2(V1.x + V2.x, V1.y + V2.y)

        End Operator

        Public Shared Operator -(ByVal V1 As Vec2, ByVal V2 As Vec2) As Vec2

            Return New Vec2(V1.x - V2.x, V1.y - V2.y)

        End Operator

    End Class

    Enum state

        null
        won
        lost

    End Enum

    Enum obsticle

        null
        bush
        tree

    End Enum

    Const height As Byte = 16
    Const width As Byte = 16

    Structure Objects

        Dim map(,) As Byte
        Dim house As Vec2
        Dim DogPos As Vec2
        Dim CatchPos As Vec2

    End Structure

    Sub Main()

        Dim obj As Objects

        While True

            Dim gameState As Byte = state.null
            Setup(obj)

            While True

                UpdateDogPos(obj, gameState)
                UpdateCatchPos(obj, gameState)

                If gameState = state.lost Then

                    Console.Clear()
                    Console.SetWindowSize(120, 30)
                    Console.WriteLine("You Lost!")
                    Exit While

                ElseIf gameState = state.won Then

                    Console.Clear()
                    Console.SetWindowSize(120, 30)
                    Console.WriteLine("You Won!")
                    Exit While

                End If

            End While

            Console.Write(vbNewLine & "Would you like to continue playing? (y/n) ")

            Dim key

            Do

                key = Console.ReadKey

                Console.SetCursorPosition(42, 2)
                Console.Write(" ")
                Console.SetCursorPosition(42, 2)

                If LCase(key.Keychar) = "n" Then

                    Exit While

                End If

            Loop Until LCase(key.Keychar) = "y"

        End While

    End Sub

    Sub UpdateDogPos(ByRef obj As Objects, ByRef gameState As Byte)

        Dim allowed As Boolean = False

        Do

            Console.ForegroundColor = ConsoleColor.Green
            Console.SetCursorPosition(obj.house.x * 2 + 1, obj.house.y)
            Dim key = Console.ReadKey()
            Console.SetCursorPosition(obj.house.x * 2 + 1, obj.house.y)
            Console.Write("H")
            Console.ResetColor()

            Console.SetCursorPosition((obj.DogPos.x * 2) + 1, obj.DogPos.y)

            If obj.map(obj.DogPos.y, obj.DogPos.x) = obsticle.bush Then

                Console.Write("#")

            Else

                Console.Write(" ")

            End If

            Select Case LCase(key.KeyChar)

                Case "w"

                    If obj.DogPos.y > 0 Then

                        If obj.map(obj.DogPos.y - 1, obj.DogPos.x) <> obsticle.tree Then

                            obj.DogPos.y += -1
                            allowed = True

                        End If

                    End If

                Case "a"

                    If obj.DogPos.x > 0 Then

                        If obj.map(obj.DogPos.y, obj.DogPos.x - 1) <> obsticle.tree Then

                            obj.DogPos.x += -1
                            allowed = True

                        End If

                    End If

                Case "s"

                    If obj.DogPos.y < height Then

                        If obj.map(obj.DogPos.y + 1, obj.DogPos.x) <> obsticle.tree Then

                            obj.DogPos.y += 1
                            allowed = True

                        End If

                    End If

                Case "d"

                    If obj.DogPos.x < width Then

                        If obj.map(obj.DogPos.y, obj.DogPos.x + 1) <> obsticle.tree Then

                            obj.DogPos.x += 1
                            allowed = True

                        End If

                    End If

            End Select

            If obj.map(obj.DogPos.y, obj.DogPos.x) = obsticle.null Then

                Console.ForegroundColor = ConsoleColor.Blue
                Console.SetCursorPosition((obj.DogPos.x * 2) + 1, obj.DogPos.y)
                Console.Write("D")
                Console.ResetColor()

            End If

        Loop Until allowed

        If obj.DogPos = obj.house Then

            gameState = state.won

        End If

    End Sub

    Sub UpdateCatchPos(ByRef obj As Objects, ByRef gameState As Byte)

        Console.SetCursorPosition((obj.CatchPos.x * 2) + 1, obj.CatchPos.y)
        Console.Write(" ")

        'insert A* algorithum here

        Console.ForegroundColor = ConsoleColor.Red
        Console.SetCursorPosition((obj.CatchPos.x * 2) + 1, obj.CatchPos.y)
        Console.Write("C")
        Console.ResetColor()

        If obj.CatchPos = obj.DogPos And gameState = state.null Then

            gameState = state.lost

        End If

    End Sub

    Sub Setup(ByRef obj As Objects)

        Console.Clear()
        Console.Write("Setting up")

        'setting up obsticles
        Randomize()
        Dim rand As New Random

        Dim temp(height, width) As Byte

        For i As Byte = 0 To height

            For l As Byte = 0 To width

                If Int(rand.Next(0, 1000)) < 50 Then

                    temp(i, l) = obsticle.bush

                ElseIf Int(rand.Next(0, 1000)) < 80 Then

                    temp(i, l) = obsticle.tree

                End If

            Next

        Next

        obj.map = temp

        Console.Write(".")

        'setting up game objects
        Do

            obj.house = New Vec2(Int(rand.Next(0, width)), Int(rand.Next(0, height)))

        Loop Until obj.map(obj.house.y, obj.house.x) = obsticle.null

        Do

            obj.DogPos = New Vec2(Int(rand.Next(0, width)), Int(rand.Next(0, height)))

        Loop Until (Math.Abs(obj.DogPos.x - obj.house.x) > (width / 2) - 1 Or
                    Math.Abs(obj.DogPos.y - obj.house.y) > (height / 2) - 1) And
                    obj.map(obj.DogPos.y, obj.DogPos.x) = obsticle.null

        Do

            obj.CatchPos = New Vec2(Int(rand.Next(0, width)), Int(rand.Next(0, height)))

        Loop Until (Math.Abs(obj.DogPos.x - obj.CatchPos.x) > 2 Or
                    Math.Abs(obj.DogPos.y - obj.CatchPos.y) > 2) And
                    obj.CatchPos <> obj.house And
                    obj.map(obj.CatchPos.y, obj.CatchPos.x) = obsticle.null

        obj.map(obj.house.y, obj.house.x) = obsticle.bush

        Console.Write(".")

        'setting up pathfinding


        Console.Write(".")

        Console.WriteLine(" Done!" & vbNewLine)

        Console.ForegroundColor = ConsoleColor.Green
        Console.Write("H")
        Console.ResetColor()
        Console.WriteLine(" - House")
        Console.ForegroundColor = ConsoleColor.Blue
        Console.Write("D")
        Console.ResetColor()
        Console.WriteLine(" - Dog")
        Console.ForegroundColor = ConsoleColor.Red
        Console.Write("C")
        Console.ResetColor()
        Console.WriteLine(" - Catcher" & vbNewLine)

        Console.WriteLine("# - The dog can pass through bushes, but the catcher can't.")
        Console.WriteLine("T - Neither the dog or the catcher can pass through trees." & vbNewLine)

        Console.WriteLine("Use 'w', 'a', 's' and 'd' to move.")

        Console.Write(vbNewLine & "Press any key to start.")
        Console.ReadKey()

        Console.SetWindowSize(width * 2 + 3, height + 2)
        DrawGrid(obj)

    End Sub

    Sub DrawGrid(ByVal obj As Objects)

        Console.Clear()
        Console.CursorVisible = False

        For j As Byte = 0 To height

            For i As Byte = 0 To width

                Console.Write("|")

                Select Case obj.map(j, i)

                    Case obsticle.bush

                        Console.Write("#")

                    Case obsticle.tree

                        Console.Write("T")

                    Case Else

                        Console.Write(" ")

                End Select

            Next

            Console.Write("|" & vbNewLine)

        Next

        Console.ForegroundColor = ConsoleColor.Green
        Console.SetCursorPosition((obj.house.x * 2) + 1, obj.house.y)
        Console.Write("H")

        Console.ForegroundColor = ConsoleColor.Blue
        Console.SetCursorPosition((obj.DogPos.x * 2) + 1, obj.DogPos.y)
        Console.Write("D")

        Console.ForegroundColor = ConsoleColor.Red
        Console.SetCursorPosition((obj.CatchPos.x * 2) + 1, obj.CatchPos.y)
        Console.Write("C")

        Console.ResetColor()

    End Sub

End Module
