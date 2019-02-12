Imports System.IO

Module Module1

    Sub Main()

        Dim filename As String = Directory.GetCurrentDirectory & "..\..\..\vowels.txt"
        Dim line As String
        Dim a, o, u, e, i As Integer

        Using Reader As StreamReader = New StreamReader(filename)

            line = Reader.ReadLine()

        End Using

        For i = 0 To line.Length() - 1

            Select Case LCase(line(i))

                Case "a"

                    line = Mid(line, 1, i - 1) & Right(line, line.Length() - i - 1)
                    a += 1

                Case "o"

                    o += 1
                    line = Mid(line, 1, i - 1) & Right(line, line.Length() - i - 1)

                Case "u"

                    u += 1
                    line = Mid(line, 1, i - 1) & Right(line, line.Length() - i - 1)

                Case "e"

                    e += 1
                    line = Mid(line, 1, i - 1) & Right(line, line.Length() - i - 1)

                Case "i"

                    i += 1
                    line = Mid(line, 1, i - 1) & Right(line, line.Length() - i - 1)

            End Select

        Next

        Using Writer As StreamWriter = New StreamWriter(filename)

            Writer.WriteLine(line)

        End Using

        Console.ReadKey()

    End Sub

End Module
