Module Module1

    Const speedMazeSoft As Integer = 0
    Const speedMazeHard As Integer = 0
    Const speedWallDestroy As Integer = 0
    Const speedAStar As Integer = 0
    Const speedBacktrack As Integer = 0
    Const speedFinalParth As Integer = 0

    Sub Main()

        While True

            Randomize()
            Const width As Integer = 51
            Const height As Integer = 51
            Console.SetWindowSize(width * 2, height)
            Dim map(height, width) As Boolean
            Dim pos As New Vec2()
            Dim trail As New List(Of Vec2)
            Dim done As Boolean = False
            Dim ft As New FrameTimer
            Dim dt As Decimal = ft.Mark()
            Dim rand As New Random

            'true means no wall
            'draws the white background
            For j = 0 To height - 1
                For i = 0 To width - 1
                    Draw(New Vec2(i, j), ConsoleColor.White)
                Next
            Next
            Draw(New Vec2(0, 0), ConsoleColor.White)

            'making random position for the maze generator to start
            Dim beginning As New Vec2(rand.Next(1, width - 1), rand.Next(1, height - 1))
            While beginning.x Mod 2 = 0 Or beginning.y Mod 2 = 0
                beginning = New Vec2(rand.Next(1, width - 1), rand.Next(1, height - 1))
            End While

            'calling recursive function to create a maze
            maze(map, beginning, width, height)

            'finding a suitable position for the start and end of the maze
            Dim finish As New Vec2(width - 1, rand.Next(1, height - 1))
            While finish.y Mod 2 = 0 And Not map(finish.y, finish.x - 1)
                finish.y = rand.Next(1, height - 1)
            End While
            map(finish.y, finish.x) = True
            Dim start As New Vec2(0, rand.Next(1, height - 1))
            While start.y Mod 2 = 0 And Not map(start.y, start.x + 1)
                start.y = rand.Next(1, height - 1)
            End While
            map(start.y, start.x) = True
            Draw(start, ConsoleColor.Gray)

            'destroying walls to make the maze more treversable
            Dim walls As New List(Of Vec2)
            For j = 2 To height - 3
                For i = 2 To width - 3
                    'true means wall
                    Dim u = Not map(j - 1, i)
                    Dim uu = Not map(j - 2, i)
                    Dim d = Not map(j + 1, i)
                    Dim dd = Not map(j + 2, i)
                    Dim r = Not map(j, i + 1)
                    Dim rr = Not map(j, i + 2)
                    Dim l = Not map(j, i - 1)
                    Dim ll = Not map(j, i - 2)
                    If Not map(j, i) And ((u And d And uu And dd And Not (l Or r)) Or (Not (u Or d) And l And ll And rr And r)) Then
                        If rand.Next(0, 101) <= 4 Then
                            walls.Add(New Vec2(i, j))
                            map(j, i) = True
                            Draw(walls(walls.Count - 1), ConsoleColor.DarkGray)
                            Threading.Thread.Sleep(speedWallDestroy)
                        End If
                    End If
                Next
            Next

            Draw(finish, ConsoleColor.DarkGray)

            'pathfinding using A* algorithm
            Dim path As List(Of Vec2) = AStar(map, width, height, start, finish)

            'For i = 1 To path.Count - 1
            '    Draw(path(i), ConsoleColor.Green)
            '    Threading.Thread.Sleep(speedBacktrack)
            '    Draw(path(i - 1), ConsoleColor.DarkBlue)
            'Next

            'end animation
            Draw(start, ConsoleColor.Green)
            path.Reverse()
            For Each point In path
                Draw(point, ConsoleColor.Green)
                Threading.Thread.Sleep(speedFinalParth)
            Next

            Threading.Thread.Sleep(1500)

        End While
    End Sub

    Sub maze(ByRef map(,) As Boolean, ByVal pos As Vec2, ByVal width As Integer, ByVal height As Integer)

        Dim randDirections(3) As Vec2
        randDirections(0) = New Vec2(0, 1)
        randDirections(1) = New Vec2(0, -1)
        randDirections(2) = New Vec2(1, 0)
        randDirections(3) = New Vec2(-1, 0)
        Dim x As Integer
        Dim temp As Vec2
        For i = 0 To 3
            x = CInt(Math.Ceiling(Rnd() * (randDirections.Length - 1)))
            temp = New Vec2(randDirections(x))
            randDirections(x) = New Vec2(randDirections(i))
            randDirections(i) = temp
        Next
        Threading.Thread.Sleep(speedMazeSoft)

        For i = 0 To randDirections.Length - 1
            Select Case randDirections(i)
                Case New Vec2(0, -1) 'UP
                    If pos.y - 2 <= 0 Then Continue For
                    If Not map(pos.y - 2, pos.x) Then
                        map(pos.y - 2, pos.x) = True
                        map(pos.y - 1, pos.x) = True
                        Draw(New Vec2(pos.x, pos.y - 2), ConsoleColor.Gray)
                        Draw(New Vec2(pos.x, pos.y - 1), ConsoleColor.Gray)
                        maze(map, New Vec2(pos.x, pos.y - 2), width, height)
                        Draw(New Vec2(pos.x, pos.y - 2), ConsoleColor.DarkGray)
                        Draw(New Vec2(pos.x, pos.y - 1), ConsoleColor.DarkGray)
                    Else
                        Continue For
                    End If
                Case New Vec2(0, 1) 'DOWN
                    If pos.y + 2 >= height Then Continue For
                    If Not map(pos.y + 2, pos.x) Then
                        map(pos.y + 2, pos.x) = True
                        map(pos.y + 1, pos.x) = True
                        Draw(New Vec2(pos.x, pos.y + 2), ConsoleColor.Gray)
                        Draw(New Vec2(pos.x, pos.y + 1), ConsoleColor.Gray)
                        maze(map, New Vec2(pos.x, pos.y + 2), width, height)
                        Draw(New Vec2(pos.x, pos.y + 2), ConsoleColor.DarkGray)
                        Draw(New Vec2(pos.x, pos.y + 1), ConsoleColor.DarkGray)
                    Else
                        Continue For
                    End If
                Case New Vec2(-1, 0) 'LEFT
                    If pos.x - 2 <= 0 Then Continue For
                    If Not map(pos.y, pos.x - 2) Then
                        map(pos.y, pos.x - 2) = True
                        map(pos.y, pos.x - 1) = True
                        Draw(New Vec2(pos.x - 2, pos.y), ConsoleColor.Gray)
                        Draw(New Vec2(pos.x - 1, pos.y), ConsoleColor.Gray)
                        maze(map, New Vec2(pos.x - 2, pos.y), width, height)
                        Draw(New Vec2(pos.x - 2, pos.y), ConsoleColor.DarkGray)
                        Draw(New Vec2(pos.x - 1, pos.y), ConsoleColor.DarkGray)
                    Else
                        Continue For
                    End If
                Case New Vec2(1, 0) 'RIGHT
                    If pos.x + 2 >= width Then Continue For
                    If Not map(pos.y, pos.x + 2) Then
                        map(pos.y, pos.x + 2) = True
                        map(pos.y, pos.x + 1) = True
                        Draw(New Vec2(pos.x + 2, pos.y), ConsoleColor.Gray)
                        Draw(New Vec2(pos.x + 1, pos.y), ConsoleColor.Gray)
                        maze(map, New Vec2(pos.x + 2, pos.y), width, height)
                        Draw(New Vec2(pos.x + 2, pos.y), ConsoleColor.DarkGray)
                        Draw(New Vec2(pos.x + 1, pos.y), ConsoleColor.DarkGray)
                    Else
                        Continue For
                    End If
            End Select
        Next

        Threading.Thread.Sleep(speedMazeHard)

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
        Return Math.Sqrt(Math.Abs(pos1.x - pos2.x) ^ 2 + Math.Abs(pos1.y - pos2.y) ^ 2)
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
                grid(i, l).addNeighbors(grid, map, height, width)
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
            Draw(current.pos, ConsoleColor.DarkBlue)

            neighbors = current.neighbors

            'expands the neighbors of the cell it has calculated
            For i = 0 To neighbors.Count - 1 Step 1

                Dim neighbor As Node = neighbors(i)
                Dim tempG As Integer

                If Not closedSet.Contains(neighbor) Then

                    'calculates the steps required to move to here from the start
                    tempG = current.g + 1

                    If Not openSet.Contains(neighbor) Then

                        'adds suitable neighbor to the open set
                        openSet.Add(neighbor)
                        Draw(neighbor.pos, ConsoleColor.Blue)

                    ElseIf tempG >= neighbor.g Then

                        Continue For

                    End If

                    'sets new heuristscs
                    neighbor.g = tempG
                    neighbor.vh = heuristic(neighbor.pos, finish)
                    neighbor.h = visualDist(neighbor.pos, finish)
                    neighbor.f = neighbor.h + neighbor.g
                    neighbor.prev = current

                End If

            Next

            Threading.Thread.Sleep(speedAStar)

        End While

        'unable to find a path
        Throw New Exception

    End Function

End Module
