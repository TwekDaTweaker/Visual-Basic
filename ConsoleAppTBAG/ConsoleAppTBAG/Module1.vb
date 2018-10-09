Module Module1

    Dim rand As New Random
    Dim a As Boolean

    Sub Main()

        print("<< You find yourself in the middle of an old town.")
        print("<< There is an old shop in front of you.")
        print("<< Do you what to go in? (yes/no)")

        a = question()

        If a = True Then

            shop()

        End If

        print("<< This is the end of the demo, damn you GitHub")

        Console.ReadKey()
    End Sub

    Sub shop()

        print("<< The owner of the shop sees you.")
        print("Owner: Hello to our gunshop, would you ike to buy something?")

        a = question()

    End Sub

    Sub print(ByVal str As String)

        For Each i As String In str

            Console.Write(i)

            Threading.Thread.Sleep(25)

        Next

        Console.ReadKey()
        Console.Write(vbNewLine)

    End Sub

    Function success(ByVal percent As Integer) As Boolean

        If rand.Next(0, 100) < percent Then

            Return True

        Else

            Return False

        End If

        Exit Function
    End Function

    Function question() As Boolean

        Dim ans As String = "doesn't matter"


        Console.Write("> ")

        Do Until ans.ToLower = "yes" Or ans.ToLower = "no"

            ans = Console.ReadLine()

            If ans = "yes" Then

                Return True

            End If

            Return False

        Loop

    End Function

End Module
