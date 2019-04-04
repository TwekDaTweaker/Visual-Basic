Module Module1

    Sub Main()

        Randomize()
        Dim width As Integer = 40
        Dim height As Integer = 40
        Console.SetWindowSize(width * 2, height)
        Dim map(height, width) As Boolean
        Dim pos As New Vec2()
        Dim trail As New List(Of Vec2)
        Dim done As Boolean = False
        Dim ft As New FrameTimer
        Dim dt As Decimal = ft.Mark()
        Dim rand As New Random()
        Dim start As New Vec2(1, rand.Next(1, height))
        Dim finish As New Vec2(width - 2, rand.Next(1, height))

        map(start.y, start.x) = True
        map(start.y, start.x - 1) = True
        map(finish.y, finish.x) = True
        map(finish.y, finish.x + 1) = True

        For j = 0 To height - 1
            For i = 0 To width - 1
                If Not map(j, i) Then Draw(New Vec2(i, j), ConsoleColor.White)
            Next
        Next

        Dim path As List(Of Vec2) = AStar(map, width, height, start, finish)

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
        Throw New Exception

    End Function

End Module
