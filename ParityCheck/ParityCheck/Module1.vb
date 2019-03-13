Module Module1

    Sub Main()

        Dim data As String = Console.ReadLine()
        If Not GoodParity(data) Then FixParity(data)
        Console.WriteLine(data)
        Console.ReadKey()

    End Sub

    Function GoodParity(ByVal data As String) As Boolean

        Dim one As Integer
        For Each letter In data
            If letter = "1" Then one += 1
        Next
        If one Mod 2 = 0 Then Return False
        Return True

    End Function

    Sub FixParity(ByRef data As String)

        If data(data.Length - 1) = "1" Then
            data = Left(data, data.Length - 1) & "0"
            Exit Sub
        End If
        data = Left(data, data.Length - 1) & "1"

    End Sub

End Module
