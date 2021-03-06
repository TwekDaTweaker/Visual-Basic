﻿Module Module1

    Sub Main()

        Dim input() As String = {"", "", ""}

        For i = 0 To input.Length - 1

            input(i) = Console.ReadLine()

        Next

        Dim E(1) As Integer
        Dim M(1) As Integer

        For i = 0 To input.Length - 1

            For l = 0 To input(i).Length - 1

                If LCase(input(i)(l)) = "e" Then

                    E(0) = l + 1
                    E(1) = i + 1

                ElseIf LCase(input(i)(l)) = "m" Then

                    M(0) = l + 1
                    M(1) = i + 1

                End If

            Next

        Next

        Console.WriteLine(vbNewLine & "E: x=" & E(0) & ", y=" & E(1) & vbNewLine & "M: x=" & M(0) & ", y=" & M(1))
        Console.WriteLine("M is " & HowFar(E, M) & " moves away from E.")

        Console.ReadKey(True)

    End Sub

    Function HowFar(ByVal E() As Integer, ByVal M() As Integer) As Integer

        Return Math.Abs(E(0) - M(0)) + Math.Abs(E(1) - M(1))

    End Function

End Module
