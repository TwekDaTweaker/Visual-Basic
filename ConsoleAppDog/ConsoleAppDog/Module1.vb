Module Module1

    Public Class Vec2

        Dim x, y As Integer

        Public Sub New(ByVal in_x As Integer, ByVal in_y As Integer)

            x = in_x
            y = in_y

        End Sub

        Public Shared Operator +(ByVal V1 As Vec2, ByVal V2 As Vec2) As Vec2

            Return New Vec2(V1.x + V2.x, V1.y + V2.y)

        End Operator

        Public Shared Operator -(ByVal V1 As Vec2, ByVal V2 As Vec2) As Vec2

            Return New Vec2(V1.x - V2.x, V1.y - V2.y)

        End Operator

    End Class


    Dim hight As Integer = 4
    Dim width As Integer = 4

    Dim forest(hight, width) As Integer

    Dim GogPos As Vec2
    Dim CatchPos As Vec2

    Sub Main()

        Setup()

        While True

            For i = 0 To 2

                Dim caught As Boolean = False

                UpdateDogPos()
                UpdateCatchPos(caught)

                If caught Then

                    Console.WriteLine("You loose!")
                    Exit While

                End If


            Next

            DrawGrid()

        End While

        Console.ReadKey()

    End Sub

    Sub Setup()



    End Sub

    Sub UpdateDogPos()



    End Sub


    Sub UpdateCatchPos(ByRef caught As Boolean)



    End Sub

    Sub DrawGrid()



    End Sub

End Module
