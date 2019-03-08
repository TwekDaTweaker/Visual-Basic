Module Module1

    Dim arr(5, 6) As Integer

    Sub Main()




    End Sub

    Sub token(ByVal col As Integer, ByVal isP1 As Boolean)

        For l = col To 6

            Dim cont As Boolean = False

            For i = 0 To 5

                If arr(i, l) = 0 Then

                    Continue For

                Else

                    If isP1 Then

                        arr(i - 1, l) = 1

                    Else

                        arr(i - 1, l) = 2

                    End If

                End If

            Next

            If Not cont Then

                Exit For

            End If

            If isP1 Then

                arr(5 - 1, l) = 1

            Else

                arr(5 - 1, l) = 2

            End If

        Next

    End Sub

End Module
