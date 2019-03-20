Public Class SavingsAcc

    Inherits Account
    Private interest As Decimal

    Public Sub New(ByVal owner As Customer, ByVal interest As Decimal)
        MyBase.New(owner)
        Me.interest = interest
    End Sub

    Public Sub New(ByVal owner As Customer, ByVal startBal As Integer, ByVal interest As Decimal)
        MyBase.New(owner, startBal)
        Me.interest = interest
    End Sub

End Class
