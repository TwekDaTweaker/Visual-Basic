Module Module1

    Sub Main()

        Console.Write("How many sides should the dice have? ")
        Dim d As New Dice(CInt(Console.ReadLine()))
        Dim warr As New HealingWarrior("Jeff")
        Dim enemy As New Warrior("Mark")

        Console.WriteLine(warr.GetName() & "'s current HP is " & warr.GetHP() & ".")
        Console.WriteLine(enemy.GetName() & "'s current HP is " & enemy.GetHP() & "." & vbNewLine)

        While warr.IsAlive() And enemy.IsAlive()

            warr.Attack(enemy, d.Roll())
            Console.WriteLine(enemy.GetName() & "'s current HP is " & enemy.GetHP() & ".")
            enemy.Attack(warr, d.Roll())
            Console.WriteLine(warr.GetName() & "'s current HP is " & warr.GetHP() & "." & vbNewLine)
            If Not warr.IsHealed() Then
                Console.Write("Do you want to heal " & warr.GetName() & "? (y/n) ")
                Dim key = Console.ReadKey()
                If LCase(key.KeyChar) = "y" Then warr.Heal()
                Console.WriteLine()
            End If

        End While

        If warr.IsAlive Then
            Console.WriteLine(warr.GetName() & " won the match!")
        Else
            Console.WriteLine(enemy.GetName() & " won the match!")
        End If

        Console.ReadKey()

    End Sub

End Module
