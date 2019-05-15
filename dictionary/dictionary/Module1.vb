Module Module1

    Sub Main()
        Console.Write("Enter string: ")
        Dim input As String = Console.ReadLine()

        Dim words() As String = input.Split(" ")
        Dim dic As New Dictionary(Of String, Integer)

        For Each word In words
            If dic.ContainsKey(word) Then
                dic(word) += 1
            Else
                dic.Add(word, 1)
            End If
        Next

        For Each ent In dic
            Console.WriteLine(ent.Key & " : " & ent.Value)
        Next

        Console.ReadKey()
    End Sub

End Module
