Module Module1

    Sub Main()

        Randomize()
        Dim width As Integer = 41
        Dim height As Integer = 41
        Console.SetWindowSize(width * 2, height)
        Dim map(height, width) As Boolean
        Dim pos As New Vec2()
        Dim trail As New List(Of Vec2)
        Dim done As Boolean = False
        Dim ft As New FrameTimer
        Dim dt As Decimal = ft.Mark()

        Dim rand As New Random()
        Dim start As New Vec2(1, rand.Next(1, height))
        While start.y Mod 2 = 0
            start.y = rand.Next(0, height)
        End While

        'true means it was explored
        map(start.y, start.x) = True
        map(start.y, start.x - 1) = True
        For j = 0 To height - 1
            For o = 0 To width - 1
                If Not map(j, o) Then
                    Draw(New Vec2(o, j), ConsoleColor.White)
                Else
                    Draw(New Vec2(o, j), ConsoleColor.Black)
                End If
            Next
        Next
        maze(map, start, width, height)

        Dim finish As New Vec2(width - 1, rand.Next(1, height))
        While finish.y Mod 2 = 0 And Not map(finish.y, finish.x - 1)
            finish.y = rand.Next(1, height)
        End While
        map(finish.y, finish.x) = True
        start = New Vec2(start.x - 1, start.y)

        Dim walls As New List(Of Vec2)
        For j = 1 To width - 2
            For i = 1 To height - 2
                If Not map(j, i) And
                    ((map(j + 1, i) Or map(j - 1, i)) And (map(j, i + 1) Or map(j, i - 1))) Then
                    walls.Add(New Vec2(i, j))
                End If
            Next
        Next
        For Each wall In walls
            If rand.Next(0, 101) <= 15 Then
                map(wall.y, wall.x) = True
                Draw(wall, ConsoleColor.Black)
            End If
        Next

        For j = 0 To height - 1
            For o = 0 To width - 1
                If Not map(j, o) Then
                    Draw(New Vec2(o, j), ConsoleColor.White)
                Else
                    Draw(New Vec2(o, j), ConsoleColor.Black)
                End If
            Next
        Next

        Draw(finish, ConsoleColor.Black)

        Dim path As List(Of Vec2) = AStar(map, width, height, start, finish)

        For Each point In path
            Draw(point, ConsoleColor.Green)
        Next

        Console.ReadKey()

    End Sub

    Sub maze(ByRef map(,) As Boolean, ByVal pos As Vec2, ByVal width As Integer, ByVal height As Integer)

        Dim randDirections(3) As Vec2
        randDirections(0) = New Vec2(0, 1)
        randDirections(1) = New Vec2(0, -1)
        randDirections(2) = New Vec2(1, 0)
        randDirections(3) = New Vec2(-1, 0)
        Dim x As Integer
        Dim temp As Vec2
        Dim rand As New Random()
        For i = 0 To 3
            x = rand.Next(0, randDirections.Length)
            temp = New Vec2(randDirections(x))
            randDirections(x) = New Vec2(randDirections(i))
            randDirections(i) = temp
            Threading.Thread.Sleep(5)
        Next

        For i = 0 To randDirections.Length - 1
            Select Case randDirections(i)
                Case New Vec2(0, -1) 'UP
                    If pos.y - 2 <= 0 Then Continue For
                    If Not map(pos.y - 2, pos.x) Then
                        map(pos.y - 2, pos.x) = True
                        map(pos.y - 1, pos.x) = True
                        Draw(New Vec2(pos.x, pos.y - 2), ConsoleColor.Black)
                        Draw(New Vec2(pos.x, pos.y - 1), ConsoleColor.Black)
                        maze(map, New Vec2(pos.x, pos.y - 2), width, height)
                    Else
                        Continue For
                    End If
                Case New Vec2(0, 1) 'DOWN
                    If pos.y + 2 >= width Then Continue For
                    If Not map(pos.y + 2, pos.x) Then
                        map(pos.y + 2, pos.x) = True
                        map(pos.y + 1, pos.x) = True
                        Draw(New Vec2(pos.x, pos.y + 2), ConsoleColor.Black)
                        Draw(New Vec2(pos.x, pos.y + 1), ConsoleColor.Black)
                        maze(map, New Vec2(pos.x, pos.y + 2), width, height)
                    Else
                        Continue For
                    End If
                Case New Vec2(-1, 0) 'LEFT
                    If pos.x - 2 <= 0 Then Continue For
                    If Not map(pos.y, pos.x - 2) Then
                        map(pos.y, pos.x - 2) = True
                        map(pos.y, pos.x - 1) = True
                        Draw(New Vec2(pos.x - 2, pos.y), ConsoleColor.Black)
                        Draw(New Vec2(pos.x - 1, pos.y), ConsoleColor.Black)
                        maze(map, New Vec2(pos.x - 2, pos.y), width, height)
                    Else
                        Continue For
                    End If
                Case New Vec2(1, 0) 'RIGHT
                    If pos.x + 2 >= width Then Continue For
                    If Not map(pos.y, pos.x + 2) Then
                        map(pos.y, pos.x + 2) = True
                        map(pos.y, pos.x + 1) = True
                        Draw(New Vec2(pos.x + 2, pos.y), ConsoleColor.Black)
                        Draw(New Vec2(pos.x + 1, pos.y), ConsoleColor.Black)
                        maze(map, New Vec2(pos.x + 2, pos.y), width, height)
                    Else
                        Continue For
                    End If
            End Select
        Next

    End Sub

    Sub Draw(ByVal pos As Vec2, ByVal color As ConsoleColor)
        Console.SetCursorPosition(pos.x * 2, pos.y)
        Console.CursorVisible = False
        Console.BackgroundColor = color
        Console.Write("  ")
        Console.ResetColor()
    End Sub

    Function heuristic(ByVal pos1 As Vec2, ByVal pos2 As Vec2) As Integer
        Return Math.Abs(pos1.x - pos2.x) + Math.Abs(pos1.y - pos2.y)
    End Function

    Function visualDist(ByVal pos1 As Vec2, ByVal pos2 As Vec2) As Single
        Return Math.Sqrt(Math.Abs(pos1.x - pos2.x) + Math.Abs(pos1.y - pos2.y))
    End Function

    Function AStar(ByVal map(,) As Boolean, ByVal width As Integer, ByVal height As Integer,
                   ByVal start As Vec2, ByVal finish As Vec2) As List(Of Vec2)

        'initializing the grid of nodes
        Dim grid(height, width) As Node
        For j = 0 To height
            For i = 0 To width
                grid(j, i) = New Node(New Vec2(i, j), heuristic(start, finish), visualDist(start, finish))
            Next
        Next
        For i = 0 To height
            For l = 0 To width
                grid(l, i).addNeighbors(grid, map, height, width)
            Next
        Next

        'creating the open and close set
        Dim openSet As New List(Of Node)
        Dim closedSet As New List(Of Node)
        'add first node
        openSet.Add(grid(start.y, start.x))

        'creating themporary variables used for calculations later on
        Dim current As Node
        Dim neighbors As List(Of Node)
        Dim found As Boolean = False
        Dim path As New List(Of Vec2)

        While openSet.Count > 0

            Dim winner As Integer = 0

            'gets the index of the node that is the closest to the finish
            For i = 1 To openSet.Count - 1
                If openSet(i).f < openSet(winner).f Then winner = i
                If openSet(i).f = openSet(winner).f Then
                    If openSet(i).g > openSet(winner).g Then

                        winner = i

                    ElseIf openSet(i).g = openSet(winner).g And
                           openSet(i).vh < openSet(winner).vh Then

                        winner = i

                    End If
                End If
            Next

            current = openSet(winner)

            'end condition, returns path
            If current.pos = finish Then

                Dim temp As Node = current
                path.Add(temp.pos)
                While temp.g > 1
                    path.Add(temp.prev.pos)
                    temp = temp.prev
                End While

                Return path

            End If

            'moves the examined node to the closed set
            openSet.Remove(current)
            closedSet.Add(current)

            neighbors = current.neighbors

            'expands the neighbors of the cell it has calculated
            For i = 0 To neighbors.Count - 1 Step 1

                Dim neighbor As Node = neighbors(i)
                Dim tempG As Integer

                If Not closedSet.Contains(neighbor) Then

                    'calculates the steps required to move to here from the start
                    tempG = current.g + 1

                    If Not openSet.Contains(neighbor) Then

                        openSet.Add(neighbor)

                    ElseIf tempG >= neighbor.g Then

                        Continue For

                    End If

                    'sets new heuristscs
                    neighbor.g = tempG
                    neighbor.h = heuristic(neighbor.pos, finish)
                    neighbor.vh = visualDist(neighbor.pos, finish)
                    neighbor.f = neighbor.h + neighbor.g
                    neighbor.prev = current

                End If
            Next

        End While

        'unable to find a path
        'Throw New Exception

    End Function

End Module
