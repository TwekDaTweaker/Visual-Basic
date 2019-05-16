Module Module1

    Sub Main()
        Console.Write("Test data: ")
        'RecEO(Console.ReadLine())
        'Console.WriteLine(RecRev(Console.ReadLine()))
        Console.WriteLine(RecCap(Console.ReadLine()))
        Console.ReadKey()
    End Sub

    Sub RecEO(ByVal data As Integer)

        If data = 0 Then
            Console.WriteLine()
            Exit Sub
        End If
        If data Mod 2 = 0 Then
            Console.CursorLeft() = Len(CStr(data)) * data - 2
            If Len(CStr(data)) > 1 Then Console.CursorLeft() = Len(CStr(data)) * data - 2 - data / 2 - 5
            Console.Write(data & " ")
            RecEO(data - 1)
        Else
            RecEO(data - 1)
            Console.Write(data & " ")
        End If

    End Sub

    Function RecRev(ByVal data As String)
        If data.Length() <= 1 Then Return data
        Return data(data.Length() - 1) & RecRev(Mid(data, 2, data.Length() - 2)) & data(0)
    End Function

    Function RecCap(ByVal data As String)
        If Char.IsUpper(data, 0) Then Return data(0)
        Return RecCap(Right(data, data.Length() - 1))
    End Function

End Module
