Imports System.IO

Module Module1

    Class Student

        Public title As String = ""
        Public firstName As String = ""
        Public lastName As String = ""
        Public age As Integer = 0
        Public favSubject As String = ""

        Sub Init()

            Console.Write("Title: ")
            title = Console.ReadLine()
            Console.Write("First name: ")
            firstName = Console.ReadLine()
            Console.Write("Last name: ")
            lastName = Console.ReadLine()
            Console.Write("Age: ")
            age = Console.ReadLine()
            Console.Write("Favourite subject: ")
            favSubject = Console.ReadLine()

        End Sub

        Sub Show()

            Console.WriteLine()
            Console.WriteLine("Title: " & title)
            Console.WriteLine("First name: " & firstName)
            Console.WriteLine("Last name: " & lastName)
            Console.WriteLine("Age: " & age)
            Console.WriteLine("Favourite subject: " & favSubject)

        End Sub

    End Class

    Sub LoadData(ByRef record As List(Of Student), ByVal filename As String)

        Using Reader As BinaryReader = New BinaryReader(File.OpenRead(filename))
            record.Clear()
            Dim count As Integer = Reader.ReadInt32
            For i = 0 To count - 1

                Dim temp As New Student
                temp.title = Reader.ReadString
                temp.firstName = Reader.ReadString
                temp.lastName = Reader.ReadString
                temp.age = Reader.ReadInt32
                temp.favSubject = Reader.ReadString
                record.Add(temp)

            Next
        End Using

    End Sub

    Sub SaveData(ByVal record As List(Of Student), ByVal filename As String)

        Using Writer As BinaryWriter = New BinaryWriter(File.Open(filename, FileMode.OpenOrCreate))
            Writer.Write(record.Count)
            For Each stu In record

                Writer.Write(stu.title)
                Writer.Write(stu.firstName)
                Writer.Write(stu.lastName)
                Writer.Write(stu.age)
                Writer.Write(stu.favSubject)

            Next
        End Using

    End Sub

    Sub Main()

        Dim record As New List(Of Student)
        Dim filename As String = Directory.GetCurrentDirectory & "..\..\..\database.bin"

        While True

            Console.WriteLine("(1) Add a record")
            Console.WriteLine("(2) View a record")
            Console.WriteLine("(3) View all records")
            Console.WriteLine("(4) Save data to file")
            Console.WriteLine("(5) Load data from file")
            Console.WriteLine("(6) Exit")

            Dim key = Console.ReadKey()

            Select Case key.KeyChar

                Case "1"

                    Console.Clear()
                    Dim temp As New Student
                    temp.Init()
                    record.Add(temp)
                    Console.Clear()

                Case "2"

                    Console.Clear()
                    Dim name As String = ""
                    Console.WriteLine("Press escape to exit.")
                    While True
                        Dim letter = Console.ReadKey()
                        If letter.Key = ConsoleKey.Escape Then
                            Console.Clear()
                            Exit While
                        End If
                        name &= letter.KeyChar
                        Dim found As New List(Of Student)
                        For Each r In record
                            If InStr(LCase(r.firstName), LCase(name)) > 0 Then
                                found.Add(r)
                            ElseIf InStr(LCase(r.lastName), LCase(name)) Then
                                found.Add(r)
                            End If
                        Next
                        Console.SetCursorPosition(0, 1)
                        Console.WriteLine(name)
                        For Each r In found
                            r.Show()
                        Next
                        Console.SetCursorPosition(name.Length, 1)
                    End While

                Case "3"

                    Console.Clear()
                    Console.SetCursorPosition(0, 6)
                    For Each r In record
                        r.Show()
                    Next
                    Console.SetCursorPosition(0, 0)

                Case "4"

                    Console.Clear()
                    SaveData(record, filename)

                Case "5"

                    Console.Clear()
                    LoadData(record, filename)

                Case "6"

                    Console.Clear()
                    Exit While

                Case Else

                    Console.Clear()
                    Console.WriteLine("Please select from 1 to 6.")

            End Select

        End While

    End Sub

End Module
