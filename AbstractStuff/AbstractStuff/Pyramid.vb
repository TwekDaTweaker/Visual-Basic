Public Class Pyramid
    Inherits Drawable

    Private height As Integer

    Public Sub New(ByVal h As Integer)
        height = h
    End Sub

    Public Overrides Sub Draw()
        For i = 1 To height
            For j = 1 To height - i
                Console.Write(" ")
            Next
            For j = 1 To ((i - 1) * 2 + 1)
                Console.Write("*")
            Next
            Console.WriteLine()
        Next
    End Sub
End Class
