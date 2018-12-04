Module Module1

    Enum title

        Mr
        Mrs

    End Enum

    Class Student

        Public title As Byte
        Public firstName As String
        Public lastName As String
        Public age As Integer
        Public favSubject As String

        Sub New(ByVal su As Student)

            title = su.title
            firstName = su.firstName
            lastName = su.lastName
            age = su.age
            favSubject = su.favSubject

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

            Select Case key.Key

                Case 1

                    Dim temp As Student
                    Dim tit As String = Console.ReadLine

                    Select Case LCase(tit)

                        Case "mr"

                            temp.title = title.Mr

                        Case "mrs"

                            temp.title = title.Mrs

                    End Select

                    temp.firstName = Console.ReadLine()
                    temp.lastName = Console.ReadLine()
                    temp.age = Console.ReadLine()
                    temp.favSubject = Console.ReadLine()

                    record.Add(temp)

                Case 2

                    Dim name As String = ""

                    While True

                        Dim letter = Console.ReadKey()
                        name &= letter.KeyChar

                        For i = 0 To record.Count - 1

                            If InStr(record(i).firstName, name) Then



                            End If

                        Next

                    End While

                Case 3



                Case 4



                Case Else

                    Console.WriteLine("Please select from 1 to 4.")

            End Select

        End While

    End Sub

End Module





















