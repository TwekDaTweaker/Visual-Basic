Module Module1
    Sub Main()

        Dim choice As Integer
        Dim BankAccount As New Account()

        Do

            menu()
            choice = Console.ReadLine
            Select Case choice
                Case 1
                    Deposit(BankAccount)
                Case 2
                    Withdrawal(BankAccount)
                Case 3
                    Balance(BankAccount)
            End Select

        Loop Until choice = 9

    End Sub

    Sub menu()

        Console.WriteLine("Welcome to the Gringotts Bank")
        Console.WriteLine()
        Console.WriteLine("1. Deposit")
        Console.WriteLine("2. Withdrawal")
        Console.WriteLine("3. See Balance")
        Console.WriteLine()
        Console.WriteLine("9. Exit")
        Console.WriteLine()

    End Sub

    Sub Deposit(ByRef BankAccount As Account)

        Dim DepositAmount As Integer
        Console.WriteLine("How much would you like to deposit?")
        DepositAmount = Console.ReadLine
        'Line below is the instance of the class - BankAccount - accessing the method MakeDeposit in Account Class 
        BankAccount.MakeDeposit(DepositAmount)
        Console.WriteLine("Deposit of £" & DepositAmount & " has been made")
        Console.WriteLine()

    End Sub

    Sub Withdrawal(ByRef BankAccount As Account)

        Dim WithdrawAmount As Integer
        Console.WriteLine("How much would you like to withdraw?")
        WithdrawAmount = Console.ReadLine
        'Line below is the instance of the class - BankAccount - accessing the method MakeDeposit in Account Class 
        BankAccount.MakeWithdrawal(WithdrawAmount)
        Console.WriteLine("Withdraw of £" & WithdrawAmount & " has been made")
        Console.WriteLine()

    End Sub
    Sub Balance(ByVal BankAccount As Account)

        Console.WriteLine()
        Console.WriteLine("Bal is " & BankAccount.Balance)
        Console.WriteLine()

    End Sub

End Module