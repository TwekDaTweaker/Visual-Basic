Public Class Account

    Private Balance As Integer
    Private OverDraftLimit As Integer
    Private owner As Customer

    Public Sub New(ByVal startBal As Integer, ByVal premium As Boolean)

        Me.New(startBal)
        If premium Then OverDraftLimit = 1500

    End Sub

    Public Sub New()

        Balance = 0
        OverDraftLimit = 0

    End Sub

    Public Sub New(ByVal startBalance As Integer)

        Balance = startBalance
        OverDraftLimit = 0

    End Sub

    Public Sub MakeDeposit(ByVal Amount As Integer)

        Balance += Amount

    End Sub

    Public Function GetBalance() As Integer

        Return Balance

    End Function

    Public Sub MakeWithdrawal(ByVal Amount As Integer)

        If Balance + OverDraftLimit >= Amount Then
            Balance -= Amount
        Else
            Throw New ArgumentException("Insufficient funds.")
        End If

    End Sub

End Class

