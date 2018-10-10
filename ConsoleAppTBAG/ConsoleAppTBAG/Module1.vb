Module Module1

    Dim rand As New Random
    Dim a As Boolean
    Dim gold As Integer = 20
    Dim hp As Integer = 100
    Dim acc As Integer = 0
    Dim dmg As Integer = 0

    Sub Main()

        Randomize()

        print("<< You find yourself in the middle of an old town.")
        print("<< There is an old shop in front of you.")
        print("<< Do you what to go in? (yes/no)")

        a = question()

        If a Then

            shop()

        End If

        print("<< You walk down the street and you see a bar.")
        print("<< There are two men at the entrance talking loudly.")
        print("<< Whould you like to engage in their conversation?")

        a = question()

        If a Then

            print("<< You try to talk to them to see if you can get any information about this town", False)
            print("   that you miraculously appeared in.")

            If success(1) Then

                print("<< They appear to be drunk and let you in on the conversation.")
                print("", False)
                print("Man0: Hello there.")
                print("Man1: Hello fellow human.")
                print("Man0: Nece weather we are having today.")
                print("Man1: Hello there.")
                print("Man0: Hi.")
                print("", False)

            Else

                print("<< They appear to be drunk, but they don't seem very happy about you approaching them.")
                print("<< They start beating you with a wooden stick.")
                print("<< You are dead now.")
                print("<< ...")
                print("<< ...")
                print("<< ...")

                a = question()

                print("<< Incorrect.")

                Exit Sub

            End If

        Else

            print("<< You decide not to get in their way.")

        End If

        print("<< You look inside the bar.")
        print("<< It's a rather empty bar with a shady looking person sitting in one of the corners", False)
        print("   and a few of the drunc locals.")

        print("<< Would you like to speak to the shady looking person?")

        a = question()

        If a Then

            print("<< You go up to the person and he starts talking to you.")
            print("", False)
            print("Shady person: You are not the first one.")
            print("Shady person: There were many more before you", False)

            Console.Clear()

            print("Yes, I did just write that 4 am in whithout any plot or interesting story and yes, I am indeed just puting this here to fill space and because I have no life. But what does it mean for someone to have life and what does it mean to not have one... Obviously I don't have one, but how do you know you have one? Isn't the definision of life bias and filled with the subjectivity of society? Maby life is a refference to the social state of someone or their connection to other people. But what if what's important to you isn't other people but something else entierly... what if you seeked reason instead of acceptance, what if you seeked rasional thinking and efficiency in exchanging information. Then most of what we call communication is irrelevant and if it is then the deffinision of life is irrelevant too. And that's not the end of it, there are so many commonly accepted ideas that rely of a social norm that not everyone agrees with or understands. What the fuck am I doing with my life...........                                 ")

        Else

            print("<< You decide to talk to the local people instead.")
            print("<< They just ignore you.")
            print("<< The shady person is now running towards you.")
            print("<< Would you like to deffend yourself?")
            print("", False)
            print("> no", False)
            print("", False)
            print("<< He grabs you and starts Screaming at you maniacally.")
            print("", False)
            print("Shady person: You must help me escape this place!")
            print("Shady person: I can't live in this hell any longer!")
            print("", False)
            print("<< The shady person is now beeing dragged back towards his seat.")
            print("<< You died.")

        End If

    End Sub

    Sub shop()

        print("Owner: Welcome to our gun shop, would you ike to buy something?")

        a = question()

        If a Then

            print("Owner: We are quite poor and offer only these:" & vbNewLine, False)
            print("1) Shotgun           45% Acc 65 Dmg", False)
            print("2) Revolver          75% Acc 45 Dmg", False)
            print("3) Good ol' Sniper   90% Acc 70 Dmg", False)
            print("4) Bow and arrows    60& Acc 50 Dmg" & vbNewLine, False)

            Console.Write("> ")

            Console.ReadLine()
            print("", False)

            print("Owner: Ah, sorry that's not enough gold.")
            print("Owner: Come again once you have enough.")
            print("", False)
            print("<< You leave confused, the game didn't mention anything about gold.")

            Console.Clear()

        Else

            print("<< You walk out of the gun shop.")

        End If

    End Sub

    Sub print(ByVal str As String, Optional ByVal key As Boolean = True)

        For Each i As String In str

            Console.Write(i)

            Threading.Thread.Sleep(20)

            If i = "?" Then

                key = False

            End If

        Next

        If key Then

            Console.ReadKey()

        End If

        Console.Write(vbNewLine)

    End Sub

    Function success(ByVal percent As Integer) As Boolean

        If rand.Next(0, 100) < percent Then

            Return True

        Else

            Return False

        End If

        Exit Function
    End Function

    Function question() As Boolean

        Dim ans As String = "doesn't matter"

        Console.Write(vbNewLine & "> ")

        Do Until ans.ToLower = "yes" Or ans.ToLower = "no"

            ans = Console.ReadLine()

            If ans = "yes" Then

                Console.Write(vbNewLine)
                Return True

            End If

            Console.Write(vbNewLine)
            Return False

        Loop

    End Function

End Module
