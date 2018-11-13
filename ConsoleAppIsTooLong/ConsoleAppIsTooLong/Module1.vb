Module Module1

    Sub Main()

        'Console.WindowWidth = 20

        Console.WriteLine(TooLong(Console.ReadLine()))

        Console.ReadKey()

    End Sub

    Function TooLong(ByVal sentence As String) As Boolean

        Return Len(sentence) > Console.WindowWidth

    End Function

End Module
