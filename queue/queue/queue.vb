Public Class queue

    Dim arr() As Integer
    Dim start As Integer = 0
    Dim finish As Integer = 0
    Dim size As Integer

    Public Sub New(ByVal size As Integer)
        Dim arr(size - 1) As Integer
        Me.arr = arr
        Me.size = size
    End Sub

    Public Sub enqueue(ByVal input As Integer)
        arr(start) = input
        finish += 1
    End Sub

    Public Function isFull() As Boolean
        If finish - start + 1 = 0 Then Return True
        Return False
    End Function

    Public Function isEmpty() As Boolean
        If start = finish Then Return True
        Return False
    End Function

End Class
