Public Class Dice

    Private rand As New Random()
    Private sides As Integer

    Public Sub New()
        sides = 6
        Randomize()
    End Sub

    Public Sub New(ByVal sides As Integer)
        Me.sides = sides
        Randomize()
    End Sub

    Public Function GetSidesCount() As Integer
        Return sides
    End Function

    Public Function Roll() As Integer
        Return rand.Next(1, sides + 1)
    End Function

End Class
