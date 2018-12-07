Imports System.IO

Module Module1

    Sub Main()

        Dim filename As String = Directory.GetCurrentDirectory & "..\..\..\database.txt"
        Dim line As String

        Using Reader As StreamReader = New StreamReader(filename)

            Do Until Reader.EndOfStream

                line = Reader.ReadLine()
                Console.WriteLine(line)

            Loop

        End Using

        Console.ReadKey()

    End Sub

End Module
