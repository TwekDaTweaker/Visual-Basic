Public Class Customer

    Private acc As Account
    Private name As String
    Private premium As Boolean

    Public Sub New(ByVal name As String, ByVal startBal As Integer, ByVal hasPremium As Boolean)

        Me.name = name
        Me.premium = hasPremium
        Me.acc = New Account(startBal, premium, Me)

    End Sub

    Public Sub New()
        Me.name = "Steve"
        Me.premium = False
        Me.acc = New Account(0)
    End Sub

    Public Function IsPremium() As Boolean
        Return premium
    End Function

    Public Function GetName() As String
        Return name
    End Function

End Class
