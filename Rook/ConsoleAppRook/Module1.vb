Module Module1

    Structure Pos

        Dim x As Integer
        Dim y As Integer

    End Structure

    Dim R As Pos
    Dim P As New List(Of Pos)

    Sub Main()

        Dim pos As String
        Dim pass As Boolean = True

        Do
            Try
                Do
                    Console.WriteLine("Enter coordinates of rook.")
                    pos = Console.ReadLine()
                    Assign(R, pos)
                    If pos = "b" Then
                        Console.WriteLine("You placed the rook outside the board. Unsurprisingly it landed on the floor.")
                    End If
                Loop Until pos = "c"
                pass = True
            Catch ex As System.InvalidCastException
                Console.WriteLine("Please enter two digits to specify the row and column.")
                pass = False
            Catch ex As System.IndexOutOfRangeException
                Console.WriteLine("Please enter two digits to specify the row and column.")
                pass = False
            End Try
        Loop Until pass

        Do
            Try
                While True
                    Console.WriteLine("Enter the coordinates of a new pawn. (leave blank to proceed)")
                    pos = Console.ReadLine()
                    If pos = "" Then
                        Exit While
                    End If
                    Dim temp As Pos
                    Assign(temp, pos)
                    If pos = "r" Then
                        Console.WriteLine("You placed a pawn on the rook. Sadly the pawn just fell to the floor.")
                        Continue While
                    ElseIf pos = "b" Then
                        Console.WriteLine("You placed a pawnd outside the board. Unsurprisingly it landed on the floor.")
                        Continue While
                    End If
                    If pos <> "m" Then
                        P.Add(temp)
                    End If
                End While
                pass = True
            Catch ex As System.InvalidCastException
                Console.WriteLine("Please enter two digits to specify the row and column.")
                pass = False
            Catch ex As System.IndexOutOfRangeException
                Console.WriteLine("Please enter two digits to specify the row and column.")
                pass = False
            End Try
        Loop Until pass

        For y = 1 To 8
            For x = 1 To 8
                Dim draw As Char = " "
                For Each s In P
                    If s.x = x And s.y = y Then
                        draw = "P"
                    End If
                Next
                If R.x = x And R.y = y Then
                    draw = "R"
                End If
                Console.Write("|" & draw)
            Next
            Console.WriteLine("|")
        Next
        Console.WriteLine()

        Dim canTake As New List(Of Pos)
        Dim found = False

        For x = R.x To 1 Step -1
            For Each s In P
                If x = s.x And R.y = s.y Then
                    canTake.Add(s)
                    found = True
                    Exit For
                End If
            Next
            If found Then
                Exit For
            End If
        Next
        found = False

        For x = R.x To 8
            For Each s In P
                If x = s.x And R.y = s.y Then
                    canTake.Add(s)
                    found = True
                    Exit For
                End If
            Next
            If found Then
                Exit For
            End If
        Next
        found = False

        For y = R.y To 1 Step -1
            For Each s In P
                If y = s.y And R.x = s.x Then
                    canTake.Add(s)
                    found = True
                    Exit For
                End If
            Next
            If found Then
                Exit For
            End If
        Next
        found = False

        For y = R.y To 8
            For Each s In P
                If y = s.y And R.x = s.x Then
                    canTake.Add(s)
                    found = True
                    Exit For
                End If
            Next
            If found Then
                Exit For
            End If
        Next

        For Each s In canTake
            Console.WriteLine("The rook can take a pawn on " & s.x & "," & s.y & ".")
        Next
        If canTake.Count = 0 Then
            Console.WriteLine("No pawns to take. :(")
        End If

        Console.ReadKey(True)

    End Sub

    Sub Assign(ByRef peace As Pos, ByRef pos As String)

        If pos.Length() > 2 Then
            Int("a")
        End If
        Dim x As String = pos(0)
        Dim y As String = pos(1)
        If x < 1 Or x > 8 Or y < 1 Or y > 8 Then
            pos = "b"
        ElseIf x = R.x And y = R.y Then
            pos = "r"
        Else
            peace.x = Int(x)
            peace.y = Int(y)
            pos = "c"
        End If
        For Each s In P
            If s.x = peace.x And s.y = peace.y Then
                pos = "m"
                Console.WriteLine("You placed a pawn on an existing pawn and, strangely enough, they merged.")
            End If
        Next

    End Sub

End Module
