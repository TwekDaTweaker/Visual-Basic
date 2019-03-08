Module Module1

    Structure Person

        Dim Name As String
        Dim Age As Integer
        Dim Height As Integer

    End Structure

    Sub DisplayPerson(ByVal Requested As Person)

        Console.WriteLine(Requested.Name)
        Console.WriteLine(Requested.Age)
        Console.WriteLine(Requested.Height)

    End Sub

    Sub InputPerson(ByRef person As Person)

        person.Name = Console.ReadLine()
        person.Age = Console.ReadLine()
        person.Height = Console.ReadLine()

    End Sub

    Function Compare(ByRef person1 As Person, ByRef person2 As Person) As Integer

        If person1.Height > person2.Height Then

            Return -1

        ElseIf person1.Height < person2.Height Then

            Return 1

        ElseIf person1.Height = person2.Height Then

            Return 0

        End If

        Return Math.Sqrt(-1)

    End Function

    Sub Main()

        Dim Myself As Person
        Dim Second As Person

        InputPerson(Myself)
        InputPerson(Second)

        DisplayPerson(Myself)
        DisplayPerson(Second)

        Console.Write(Compare(Myself, Second))
        Console.ReadKey()

    End Sub

End Module