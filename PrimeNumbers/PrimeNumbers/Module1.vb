Module Module1

    Sub Main()
        Console.CursorVisible = False
        Console.WriteLine("Press space to continue and escape to exit.")
        While True

            Console.Write("Enter an integer: ")
            Dim input As Integer = Console.ReadLine()

            If input = 420 Then
                List()
            End If

            If input <= 1 Then
                Console.WriteLine(input & " is not greater than 1.")
                GoTo prompt
            End If

            For i = 2 To input - 1
                If input Mod i = 0 Then
                    Console.WriteLine(input & " is not a prime.")
                    GoTo prompt
                End If
            Next

            Console.WriteLine(input & " is a prime.")
prompt:
            Console.WriteLine()
            Do
                Dim key = Console.ReadKey(True)
                If key.Key = ConsoleKey.Escape Then
                    Exit While
                ElseIf key.KeyChar = " " Or key.Key = ConsoleKey.Enter Then
                    Continue While
                End If
            Loop

        End While
    End Sub

    Sub List()

        Dim nums As New List(Of Integer)
        Dim i As Integer = 6
        Dim j As Integer = 5
        Dim switch As Boolean = False
        While True
            For Each num In nums
                If j Mod num = 0 Then
                    GoTo noprime
                End If
            Next
            nums.Add(j)
            Console.WriteLine(nums.Count + 2 & " " & j)
noprime:
            If switch Then
                j = i + 1
                i += 6
                switch = False
            Else
                j = i - 1
                switch = True
            End If
        End While

    End Sub

End Module
