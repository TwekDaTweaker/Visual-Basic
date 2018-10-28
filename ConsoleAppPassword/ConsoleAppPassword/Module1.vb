Module Module1

    Sub Main()

        Dim info(4) As String
        Dim text() As String = {"Surname:", "Year of birth:", "Colour:", "Street:", "Shoe size:"}

        For i = 0 To info.Length - 1

            Console.WriteLine(text(i))
            info(i) = Console.ReadLine
            Console.WriteLine(vbNewLine)

        Next

        Console.WriteLine(vbNewLine &
                    "Password: " &
                    CStr(info(0)(1)) &
                    Right(info(1), 2) &
                    Mid(info(2), 2, 2) &
                    Left(info(3), 3) &
                    info(4)(0))

        Console.ReadKey()
    End Sub

End Module
