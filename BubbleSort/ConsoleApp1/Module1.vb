Module Module1

    Sub Main()

        Dim list As New List(Of Integer)
        Dim len As Integer = Console.ReadLine()
        Randomize()
        Dim rand As New Random
        For i = 1 To len
            list.Add(rand.Next(0, 99))
        Next

        'Bubble(list)
        Quick(list, 0, list.Count - 1)

        Console.WriteLine()
        For Each num In list
            Console.WriteLine(num)
        Next
        Console.ReadKey()


    End Sub

    Sub Quick(ByRef list As List(Of Integer), ByVal low As Integer, ByVal high As Integer)

        Dim pi As Integer
        If (low < high) Then
            pi = partition(list, low, high)
        End If

        Quick(list, low, pi - 1)
        Quick(list, pi + 1, high)

    End Sub

    Function partition(ByRef list As List(Of Integer), ByVal low As Integer, ByVal high As Integer) As Integer

        Dim pivot As Integer = list(high)
        Dim i = low - 1

        For j = low To high - 1
            If list(j) <= pivot Then
                i += 1
                swap(list(i), list(j))
            End If
        Next

        list(i + 1) += list(high)
        swap(list(i + 1), list(high))
        Return i + 1

    End Function

    Sub Bubble(ByRef list As List(Of Integer))

        Dim swaped As Boolean = False
        Do
            swaped = False
            For i = 0 To list.Count - 2
                If list(i) > list(i + 1) Then
                    swap(list(i), list(i + 1))
                    swaped = True
                End If
            Next
        Loop Until Not swaped

    End Sub

    Sub swap(ByRef a As Integer, ByRef b As Integer)

        a += b
        b = a - b
        a -= b

    End Sub

End Module
