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



        End Sub

    End Class

    Sub Main()

        Dim record As New List(Of Student)

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

                        For i = 0 To found.Count

                            found(i).Show()

                        Next

                    End While

                Case "3"

                    Console.Clear()


                Case "4"

                    Console.Clear()
                    Exit While

                Case Else

                    Console.Clear()
                    Console.WriteLine("Please select from 1 to 4.")

            End Select

        End While

    End Sub

End Module
