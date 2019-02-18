Imports System.IO

Module Module1

    Sub Main()

        Dim filename As String = Directory.GetCurrentDirectory & "..\..\..\vowels.txt"
        Dim lineS As String
        Dim a, o, u, e, i As Integer

        Using Reader As StreamReader = New StreamReader(filename)

            lineS = Reader.ReadLine()

        End Using

        Dim oldline As String = lineS
        Dim line As New List(Of String)

        For i = 0 To lineS.Length - 1
            Dim temp As String = lineS(i)
            line.Add(temp)
        Next

        For i = 0 To line.Count - 1

            Select Case LCase(line(i))
                Case "a"
                    a += 1
                Case "o"
                    o += 1
                Case "u"
                    u += 1
                Case "e"
                    e += 1
                Case "i"
                    i += 1
                Case Else
                    Continue For
            End Select
            line.Remove(line(i))

        Next

        lineS = ""
        For Each e In line
            lineS &= e
        Next

        Using Writer As StreamWriter = New StreamWriter(filename)

            Writer.WriteLine(oldline)
            Writer.WriteLine(lineS)

        End Using

        Console.ReadKey()

    End Sub

End Module
