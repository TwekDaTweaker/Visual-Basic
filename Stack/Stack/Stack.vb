Public Class Stack

    Private top As Integer = -1
    Private arr() As Integer

    Public Sub New(ByVal size As Integer)
        Dim arr(size) As Integer
        Me.arr = arr
    End Sub

    Public Function Peek() As Integer
        Return arr(top)
    End Function

    Public Function Pop() As Integer
        top -= 1
        Return arr(top + 1)
    End Function

    Public Sub Push(ByVal val As Integer)
        top += 1
        arr(top) = val
    End Sub

    Public Function IsEmpty() As Boolean
        If top = -1 Then Return True
        Return False
    End Function

    Public Function IsFull() As Boolean
        If top = arr.Length() Then Return True
        Return False
    End Function

End Class
