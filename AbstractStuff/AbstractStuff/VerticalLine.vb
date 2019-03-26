Public Class VerticalLine
    Inherits Drawable

    Protected length As Integer

    Public Sub New(ByVal l As Integer)
        length = l
    End Sub

    Public Overrides Sub Draw()
        For i = 1 To length
            Console.WriteLine("*")
        Next
    End Sub
End Class