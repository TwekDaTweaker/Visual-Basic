Module Module1

    Sub Main()

        'Add()
        Arr()

        Console.ReadKey(True)

    End Sub

    Sub Add()

        Dim x As Integer
        Dim suc As Boolean = True

        While suc

            Try

                x += 1000000
                Console.WriteLine(x)

            Catch ex As OverflowException

                Console.WriteLine("lol, no")
                suc = False

            End Try

        End While

    End Sub

    Sub Arr()

        Dim arr() As String = {"lolz", "aren't", "good", "enough"}

        While True

            Try

                Dim temp As Integer = Console.ReadLine()
                Console.Clear()
                Console.WriteLine(arr(temp))

            Catch ex As IndexOutOfRangeException

                Console.Clear()
                Console.WriteLine("nope, try again")

            Catch ex As InvalidCastException

                Console.Clear()
                Console.WriteLine("numbers, you fool")

            End Try

        End While

    End Sub

End Module
