Module Module1

    Sub Main()

        Dim str As String = Console.ReadLine()

        Console.WriteLine(LetterChange(str))

        Console.ReadKey()

    End Sub

    Function LetterChange(ByVal str As String) As String

        Dim toCap() As Char = {"a", "e", "i", "o", "u"}
        Dim result As String = ""

        For i = 0 To str.Length - 1

            Dim temp = Asc(str(i))

            If temp >= 97 And temp <= 122 Then

                temp += 1

                If temp = 123 Then

                    temp = 97

                End If

                If toCap.Contains(Chr(temp)) Then

                    temp -= 32

                End If

            End If

            result &= Chr(temp)

        Next

        Return result

    End Function

End Module
