Module Module1

    Sub Main()

        Dim grid(5, 5) As Integer

        Init(grid)

        Dim hRow As Integer = 0
        For y = 0 To 4
            If grid(5, y) > grid(5, hRow) Then
                hRow = y
            End If
        Next

        Dim hCol As Integer = 0
        For x = 0 To 4
            If grid(x, 5) > grid(hCol, 5) Then
                hCol = x
            End If
        Next

        Draw(grid, hRow, hCol)

        Console.ReadKey(True)

    End Sub

    Sub Init(ByRef grid(,) As Integer)

        Randomize()
        Dim rand As New Random
        For y = 0 To 4
            For x = 0 To 4
                grid(x, y) = rand.Next(10, 99)
            Next
        Next

        For y = 0 To 4
            Dim sumx As Integer
            For x = 0 To 4
                sumx += grid(x, y)
            Next
            grid(5, y) = sumx
            sumx = 0
        Next

        For x = 0 To 4
            Dim sumy As Integer
            For y = 0 To 4
                sumy += grid(x, y)
            Next
            grid(x, 5) = sumy
            sumy = 0
        Next

    End Sub

    Sub Draw(ByVal grid(,) As Integer, ByVal hRow As Integer, ByVal hCol As Integer)

        Console.ForegroundColor = ConsoleColor.White
        For y = 0 To 5
            For x = 0 To 5
                Console.Write("|")
                If y = hRow Then
                    Console.ForegroundColor = ConsoleColor.Cyan
                End If
                If x = hCol Then
                    Console.ForegroundColor = ConsoleColor.Red
                End If
                If y = hRow And x = hCol Then
                    Console.ForegroundColor = ConsoleColor.Yellow
                End If
                Console.Write(grid(x, y) & " ")
                If grid(x, y) < 100 Then
                    Console.Write(" ")
                    If grid(x, y) < 10 Then
                        Console.Write(" ")
                    End If
                End If
                Console.ForegroundColor = ConsoleColor.White
            Next
            Console.WriteLine("|")
        Next

    End Sub

End Module
