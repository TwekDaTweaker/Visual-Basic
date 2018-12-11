Imports System.IO

Module Module1

    Enum tit

        Mr
        Mrs

    End Enum

    Class Student

        Public title As Byte
        Public firstName As String
        Public lastName As String
        Public age As Integer
        Public favSubject As String

        Sub New()

            Dim temp As String = Console.ReadLine()

            Select Case LCase(temp)

                Case "mr"

                    title = tit.Mr

                Case "mrs"

                    title = tit.Mrs

            End Select

            firstName = Console.ReadLine()
            lastName = Console.ReadLine()
            age = Console.ReadLine()
            favSubject = Console.ReadLine()

        End Sub

        Sub Show()

            Console.Write(vbNewLine & vbNewLine & "nope")

        End Sub

    End Class

    Sub Main()

        Dim record As New List(Of Student)
        Dim filename As String = Directory.GetCurrentDirectory & "..\..\..\database.txt"
        Dim line As String

        Using Reader As StreamReader = New StreamReader(filename)

            Dim current As Student

            Do Until Reader.EndOfStream

                line = Reader.ReadLine()

                If line(0) = "#" Then

                    Select Case line(1)

                        Case "1"

                            current.title = CByte(Mid(line, 2, line.Length))

                        Case "2"

                            current.firstName = Mid(line, 2, line.Length - 1)

                        Case "3"

                            current.lastName = Mid(line, 2, line.Length - 1)

                        Case "4"

                            current.age = CInt(Mid(line, 2, line.Length - 1))

                        Case "5"

                            current.favSubject = Mid(line, 2, line.Length - 1)

                        Case Else

                            record.Add(current)

                    End Select

                End If

            Loop

        End Using

        While True

            Console.WriteLine("(1) Add a record")
            Console.WriteLine("(2) View a record")
            Console.WriteLine("(3) View all records")
            Console.WriteLine("(4) Exit")

            Dim key = Console.ReadKey()

            Select Case key.KeyChar

                Case "1"

                    Console.Clear()
                    record.Add(New Student())

                Case "2"

                    Console.Clear()
                    Dim name As String = ""

                    While True

                        Dim letter = Console.ReadKey()
                        name &= letter.KeyChar

                        Dim found As New List(Of Student)

                        For i = 0 To record.Count - 1

                            If InStr(record(i).firstName, name) > 0 Then

                                found.Add(record(i))

                            End If

                        Next

                        For i = 0 To found.Count - 1

                            found(i).Show()

                        Next

                    End While

                Case "3"

                    For i = 0 To record.Count - 1

                        record(i).Show()

                    Next

                    Console.Clear()

                Case "4"

                    Console.Clear()
                    Exit While

                Case Else

                    Console.Clear()
                    Console.WriteLine("Please select from 1 to 4.")

            End Select

        End While

        Using Writer As StreamWriter = New StreamWriter(filename)

            For i = 0 To record.Count - 1

                Writer.WriteLine("#1" & record(i).title)
                Writer.WriteLine("#2" & record(i).firstName)
                Writer.WriteLine("#3" & record(i).lastName)
                Writer.WriteLine("#4" & record(i).age)
                Writer.WriteLine("#5" & record(i).favSubject)
                Writer.WriteLine("#   ")

            Next

        End Using

    End Sub

End Module
