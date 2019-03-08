Module Module1

    Sub Main()

        Dim x As Integer = 5
        Dim y As Integer = 3

        Console.WriteLine(x & " " & y)

        swap(x, y)

        Console.WriteLine(x & " " & y)

        Console.ReadKey()

    End Sub

    Sub swap(ByRef x As Integer, ByRef y As Integer)

        x += y

        y = x - y

        x -= y

    End Sub

End Module
