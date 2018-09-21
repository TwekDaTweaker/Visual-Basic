Module Module1

    Sub Main()

        Dim h, black, white As Integer

        h = Console.ReadLine()
        white = 1
        black = h - 1

        For i = 1 To h

            For l = 1 To black

                WL(" ")

            Next

            For l = 1 To white

                WL("#")

            Next

            white += 2
            black -= 1

            Console.WriteLine()

        Next

        MsgBox("k?")

    End Sub

    Function WL(ByVal succ As String)

        Console.Write(succ)

    End Function

End Module
