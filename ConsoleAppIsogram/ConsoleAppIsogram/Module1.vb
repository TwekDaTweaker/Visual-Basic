Module Module1

    Sub Main()

        Dim str As String = Console.ReadLine()

        Console.WriteLine(Isogram(str))

        Console.ReadKey(True)

    End Sub

    Function Isogram(ByVal str As String) As Boolean

        Dim lett As New List(Of String)

        For i = 0 To str.Length - 1

            If Asc(LCase(str(i))) >= 97 And Asc(LCase(str(i))) <= 122 Then

                Dim found As Boolean = False

                For Each item In lett

                    If LCase(str(i)) = item(0) Then

                        item &= LCase(str(i))
                        found = True
                        Exit For

                    End If

                Next

                If Not found Then

                    lett.Add(LCase(str(i)))

                End If

            End If

        Next

        If lett.Count > 0 Then

            Dim def As Integer = lett(0).Length()

            For i = 1 To lett.Count - 1

                If lett(i).Length() <> def Then

                    Return False

                End If

            Next

            Return True

        Else

            Return False

        End If

    End Function

End Module
