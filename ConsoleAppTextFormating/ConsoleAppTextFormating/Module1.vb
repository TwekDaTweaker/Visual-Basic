Module Module1

    Sub Main()

        Randomize()

        Dim rand As New Random
        Dim a As Integer
        Dim i As ConsoleKeyInfo = Console.ReadKey()


        While True

            a = rand.Next(65, 122)
            Console.WriteLine(Chr(a))
            i = Console.ReadKey()
            Console.Clear()
            If (i.Key) = 13 Then

                Exit While

            End If

        End While

    End Sub

End Module
