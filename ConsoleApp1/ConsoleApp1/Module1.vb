Module Module1

    Sub Main()

        Dim r, h As Integer
        Dim S, V As Double
        Dim k As String

        Console.WriteLine("Radius: ")
        r = CInt(Console.ReadLine())

        Console.WriteLine("Do you want to calclate example 2? (y/n)")
        k = CStr(Console.ReadLine())

        If k = "y" Then

            Console.WriteLine("Height: ")
            h = CInt(Console.ReadLine())

        End If

        If h = 0 Then

            S = 2 * Math.PI * r * r
            Console.WriteLine("Area: " & S)

        Else

            S = (2 * Math.PI * r * r) + (2 * Math.PI * r * h)
            Console.WriteLine("Area: " & S)

            V = Math.PI * r * r * h
            Console.WriteLine("Volme: " & V)

        End If

        MsgBox("lol?")

    End Sub

End Module
