Module Module1

    Sub Main()
        Console.WriteLine(fac2(Console.ReadLine()))
        Console.ReadKey()
    End Sub

    Function fac2(ByVal n As Integer)
        If n <= 1 Then Return 1
        Return fac2(n - 2) * n
    End Function

End Module
