Public Class HorizontalLine
    Inherits VerticalLine

    Public Sub New(ByVal i As Integer)
        MyBase.New(i)
    End Sub

    Public Overrides Sub Draw()
        For i = 1 To length
            Console.Write("*")
        Next
    End Sub

End Class
