Public Class Customer

    Private name As String
    Private premium As Boolean

    Public Sub New(ByVal inName As String, ByVal inPremium As Boolean)
        name = inName
        premium = inPremium
    End Sub

    Public Function GetName() As String
        Return name
    End Function

    Public Function IsPremium() As Boolean
        Return premium
    End Function

End Class
