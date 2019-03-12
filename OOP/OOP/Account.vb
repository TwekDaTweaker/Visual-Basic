Public Class Account

    Public Balance As Integer

    Public OverDraftLimit As Integer

    Public Sub MakeDeposit(ByVal Amount As Integer)
        Balance += Amount
    End Sub

    Public Sub MakeWithdrawal(ByVal Amount As Integer)
        Balance -= Amount
    End Sub

End Class
