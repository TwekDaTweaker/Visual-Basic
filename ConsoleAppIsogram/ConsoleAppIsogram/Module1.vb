Module Module1

    Sub Main()

        Dim str As String = Console.ReadLine()

        Console.WriteLine(Isogram(str))

        Console.ReadKey(True)

    End Sub

    Function Isogram(ByVal str As String) As Boolean

        str = str.ToLower()
        Dim letters As New List(Of String)

        For i = 0 To str.Length - 1

            If Asc(str(i)) >= 97 And Asc(str(i)) <= 122 Then

                Dim found As Boolean = False

                For j = 0 To letters.Count - 1

                    If str(i) = letters(j)(0) Then

                        letters(j) &= str(i)
                        found = True
                        Exit For

                    End If

                Next

                If Not found Then

                    letters.Add(LCase(str(i)))

                End If

            End If

        Next

        If letters.Count > 0 Then

            Dim def As Integer = letters(0).Length()

            For i = 1 To letters.Count - 1

                If letters(i).Length() <> def Then

                    Return False

                End If

            Next

            Return True

        Else

            Return False

        End If

    End Function

End Module
