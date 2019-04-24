Module Module1

    Dim max As Integer = 0

    Sub Main()

        fib(Console.ReadLine())
        Console.ReadKey(True)

    End Sub

    Sub fib(ByVal x As Integer)
        If x > 0 Then
            x -= 1
            fib(x)
            If x > max Then
                Console.WriteLine(x)
                max = x
            End If
            x -= 1
            fib(x)
        End If
    End Sub

End Module
