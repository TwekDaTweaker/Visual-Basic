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

    Public Class Nodes

        Public pos As New Vec2(0, 0)
        Public f As Single
        Public vh As Single
        Public h As Integer
        Public g As Integer = 0
        Public neighbors As New List(Of Nodes)
        Public prev As Nodes

        Public Sub New(ByVal pos_in As Vec2)

            pos = pos_in

        End Sub

        Public Sub addNeighbors(ByRef grid(,) As Nodes, ByRef map(,) As Byte)

            If pos.y > 0 Then

                If map(pos.y - 1, pos.x) = obsticle.null Then

                    neighbors.Add(grid(pos.y - 1, pos.x))

                End If

            End If

            If pos.y < height Then

                If map(pos.y + 1, pos.x) = obsticle.null Then

                    neighbors.Add(grid(pos.y + 1, pos.x))

                End If

            End If

            If pos.x > 0 Then

                If map(pos.y, pos.x - 1) = obsticle.null Then

                    neighbors.Add(grid(pos.y, pos.x - 1))

                End If

            End If

            If pos.x < width Then

                If map(pos.y, pos.x + 1) = obsticle.null Then

                    neighbors.Add(grid(pos.y, pos.x + 1))

                End If

            End If

        End Sub

        Public Shared Operator =(ByVal N1 As Nodes, ByVal N2 As Nodes) As Boolean

            Return N1.pos.x = N2.pos.x And N1.pos.y = N2.pos.y

        End Operator

        Public Shared Operator <>(ByVal N1 As Nodes, ByVal N2 As Nodes) As Boolean

            Return N1.pos.x <> N2.pos.x Or N1.pos.y <> N2.pos.y

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

    Structure Objects

        Dim map(,) As Byte
        Dim house As Vec2
        Dim DogPos As Vec2
        Dim DogPosOld As Vec2
        Dim DogPosVisual As Vec2
        Dim CatchPos As Vec2
        Dim extraTurn As Boolean

    End Structure

    Const height As Byte = 15
    Const width As Byte = 15

    Sub Main()

        Dim obj As Objects

        While True

            Dim gameState As Byte = state.null
            Setup(obj)
            Dim turn As Integer = 0

            While True

                If (turn + 1) Mod 2 = 0 Or (turn + 1) Mod 3 = 0 Then

                    obj.extraTurn = True

                End If

                UpdateDogPos(obj, gameState)
                UpdateCatchPos(obj, obj.DogPosOld, gameState)

                If turn Mod 2 = 0 Or turn Mod 3 = 0 Then

                    UpdateCatchPos(obj, obj.DogPosOld, gameState)

                End If

                obj.extraTurn = False

                If gameState = state.lost Then

                    Threading.Thread.Sleep(700)
                    Console.Clear()
                    Console.SetWindowSize(120, 30)
                    Console.WriteLine("You Lost!")
                    Exit While

                ElseIf gameState = state.won Then

                    Threading.Thread.Sleep(700)
                    Console.Clear()
                    Console.SetWindowSize(120, 30)
                    Console.WriteLine("You Won!")
                    Exit While

                    cc

                    turn += 1

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
            Dim key = Console.ReadKey(True)
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
                obj.DogPosVisual = New Vec2(obj.DogPosOld.x, obj.DogPosOld.y)
                obj.DogPosOld = New Vec2(obj.DogPos.x, obj.DogPos.y)

            ElseIf obj.map(obj.DogPos.y, obj.DogPos.x) = obsticle.bush Then

                Console.ForegroundColor = ConsoleColor.Blue
                Console.SetCursorPosition((obj.DogPos.x * 2) + 1, obj.DogPos.y)
                Console.Write("#")
                Console.ResetColor()

            End If

        Loop Until allowed

        If obj.DogPos = obj.house Then

            gameState = state.won

        End If

    End Sub

    Sub UpdateCatchPos(ByRef obj As Objects, ByVal finish As Vec2, ByRef gameState As Byte)

        If obj.CatchPos = finish And obj.CatchPos <> obj.DogPos Then

            UpdateCatchPos(obj, obj.house, gameState)
            Exit Sub

        End If

        If obj.CatchPos = obj.DogPos And gameState <> state.won Then

            gameState = state.lost
            Exit Sub

        End If

        Dim oldPos As Vec2 = obj.CatchPos

        Dim grid(height, width) As Nodes

        For i = 0 To height

            For l = 0 To width

                grid(i, l) = New Nodes(New Vec2(l, i))

            Next

        Next

        For i = 0 To height

            For l = 0 To width

                grid(l, i).addNeighbors(grid, obj.map)

            Next

        Next

        Dim openSet As New List(Of Nodes)
        Dim closedSet As New List(Of Nodes)

        grid(obj.CatchPos.y, obj.CatchPos.x).h = heuristic(obj.CatchPos, finish)
        grid(obj.CatchPos.y, obj.CatchPos.x).vh = visualDist(obj.CatchPos, finish)
        grid(obj.CatchPos.y, obj.CatchPos.x).f = grid(obj.CatchPos.y, obj.CatchPos.x).h +
                                                 grid(obj.CatchPos.y, obj.CatchPos.x).g
        openSet.Add(grid(obj.CatchPos.y, obj.CatchPos.x))

        Dim current As Nodes
        Dim neighbors As List(Of Nodes)
        Dim path As New List(Of Vec2)
        Dim found As Boolean = False

        While openSet.Count > 0

            Dim winner As Integer = 0

            For i = 1 To openSet.Count - 1

                If openSet(i).f < openSet(winner).f Then

                    winner = i

                End If

                If openSet(i).f = openSet(winner).f Then

                    If openSet(i).g > openSet(winner).g Then

                        winner = i

                    ElseIf finish = obj.DogPos Then

                        If openSet(i).g = openSet(winner).g And
                           openSet(i).vh < visualDist(openSet(winner).pos, obj.DogPosVisual) Then

                            winner = i

                        End If

                    ElseIf openSet(i).g = openSet(winner).g And
                           openSet(i).vh < openSet(winner).vh Then

                        winner = i

                    End If

                End If

            Next

            current = openSet(winner)

            If current.pos = finish Then

                Dim temp As Nodes = current

                path.Add(temp.pos)

                While temp.g > 1

                    path.Add(temp.prev.pos)
                    temp = temp.prev

                End While

                found = True

                Exit While

            End If

            openSet.Remove(current)
            closedSet.Add(current)

            neighbors = current.neighbors

            For i = 0 To neighbors.Count - 1 Step 1

                Dim neighbor As Nodes = neighbors(i)
                Dim tempG As Integer

                If Not closedSet.Contains(neighbor) Then

                    tempG = current.g + 1

                    If Not openSet.Contains(neighbor) Then

                        openSet.Add(neighbor)

                    ElseIf tempG >= neighbor.g Then

                        Continue For

                    End If

                    neighbor.g = tempG
                    neighbor.h = heuristic(neighbor.pos, finish)
                    neighbor.vh = visualDist(neighbor.pos, finish)
                    neighbor.f = neighbor.h + neighbor.g
                    neighbor.prev = current

                End If

            Next

        End While

        If Not found Then

            UpdateCatchPos(obj, obj.house, gameState)
            Exit Sub

        End If

        Console.SetCursorPosition((oldPos.x * 2) + 1, oldPos.y)
        Console.Write(" ")

        Console.ForegroundColor = ConsoleColor.Green
        Console.SetCursorPosition((obj.house.x * 2) + 1, obj.house.y)
        Console.Write("H")

        path.Reverse()
        obj.CatchPos = path(0)

        If obj.CatchPos = obj.house And finish = obj.house Then

            obj.CatchPos = oldPos

        End If

        Console.ForegroundColor = ConsoleColor.Yellow

        If obj.extraTurn Then

            Console.ForegroundColor = ConsoleColor.Red

        End If

        Console.SetCursorPosition((obj.CatchPos.x * 2) + 1, obj.CatchPos.y)
        Console.Write("C")
        Console.ResetColor()

        If obj.CatchPos = obj.DogPos And gameState <> state.won Then

            gameState = state.lost

        End If

    End Sub

    Sub Setup(ByRef obj As Objects)

        Console.Clear()

        Randomize()
        Dim rand As New Random

        Dim temp(height, width) As Byte

        For i As Byte = 0 To height

            For l As Byte = 0 To width

                If Int(rand.Next(0, 1000)) < 100 Then

                    temp(i, l) = obsticle.tree

                End If

                If Int(rand.Next(0, 1000)) < 150 Then

                    temp(i, l) = obsticle.bush

                End If

            Next

        Next

        obj.map = temp

        Do

            obj.house = New Vec2(Int(rand.Next(1, width - 1)), Int(rand.Next(1, height - 1)))

        Loop Until obj.map(obj.house.y, obj.house.x) = obsticle.null

        obj.map(obj.house.y + 1, obj.house.x) = obsticle.null
        obj.map(obj.house.y - 1, obj.house.x) = obsticle.null
        obj.map(obj.house.y, obj.house.x + 1) = obsticle.null
        obj.map(obj.house.y, obj.house.x - 1) = obsticle.null

        Do

            obj.DogPos = New Vec2(Int(rand.Next(0, width)), Int(rand.Next(0, height)))

        Loop Until (Math.Abs(obj.DogPos.x - obj.house.x) > (width / 2) - 1 Or
                    Math.Abs(obj.DogPos.y - obj.house.y) > (height / 2) - 1) And
                    obj.map(obj.DogPos.y, obj.DogPos.x) = obsticle.null

        obj.DogPosOld = New Vec2(obj.DogPos.x, obj.DogPos.y)
        obj.DogPosVisual = New Vec2(obj.DogPos.x, obj.DogPos.y)

        Do

            obj.CatchPos = New Vec2(Int(rand.Next(0, width)), Int(rand.Next(0, height)))

        Loop Until (Math.Abs(obj.CatchPos.x - obj.DogPos.x) > 2 Or
                    Math.Abs(obj.CatchPos.y - obj.DogPos.y) > 2) And
                    (Math.Abs(obj.CatchPos.x - obj.house.x) < 3 Or
                    Math.Abs(obj.CatchPos.y - obj.house.y) < 3) And
                    obj.CatchPos <> obj.house And
                    obj.map(obj.CatchPos.y, obj.CatchPos.x) = obsticle.null

        obj.extraTurn = False

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

        Console.Write("When the catcher turns ")
        Console.ForegroundColor = ConsoleColor.Yellow
        Console.Write("yellow")
        Console.ResetColor()
        Console.WriteLine(" it means it will travel 1 space instead Of 2.")
        Console.WriteLine("At least 85% Of the levels are possible. I may Not have a life, but I'm not crazy." & vbNewLine)

        Console.WriteLine("Use 'w', 'a', 's' and 'd' to move." & vbNewLine)

        Console.Write("Press any key to start. ")
        Console.ReadKey()

        Console.SetWindowSize(width * 2 + 3, height + 2)
        DrawGrid(obj)

    End Sub

    Sub DrawGrid(ByVal obj As Objects)

        Console.Clear()
        Console.CursorVisible = False

        For i As Byte = 0 To height

            For l As Byte = 0 To width

                Console.Write("|")

                Select Case obj.map(i, l)

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

    Function heuristic(ByVal pos1 As Vec2, ByVal pos2 As Vec2) As Integer

        Return Math.Sqrt(Math.Abs(pos1.x - pos2.x) + Math.Abs(pos1.y - pos2.y))

    End Function

    Function visualDist(ByVal pos1 As Vec2, ByVal pos2 As Vec2) As Single

        Return ((pos1.x - pos2.x) ^ 2) + ((pos1.y - pos2.y) ^ 2)

    End Function

End Module
