Public Class Account

    Private balance As Double
    Private overDraftLimit As Double
    Private owner As Customer

    Public Sub New(ByVal inOwner As Customer)
        balance = 0
        overDraftLimit = 0
        owner = inOwner
    End Sub

    Public Sub New(ByVal inOwner As Customer, ByVal startBalance As Double)
        balance = startBalance
        owner = inOwner

        If owner.IsPremium() Then
            overDraftLimit = 1500
        Else
            overDraftLimit = 0
        End If
    End Sub

    Public Sub MakeDeposit(ByVal Amount As Double)
        balance += Amount
    End Sub

    Public Function GetBalance() As Double
        Return balance
    End Function

    Public Sub MakeWithdrawal(ByVal Amount As Double)
        If balance + overDraftLimit >= Amount Then
            balance -= Amount
        Else
            Throw New ArgumentException("Insufficient funds.")
        End If
    End Sub

End Class
