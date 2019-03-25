Public Class Warrior

    Protected name As String
    Protected currHP As Integer
    Protected maxHP As Integer
    Protected attDMG As Integer

    Public Sub New(ByVal name As String)
        Me.name = name
        maxHP = 100
        currHP = maxHP
        attDMG = 10
    End Sub

    Public Function GetHP() As Integer
        Return currHP
    End Function

    Public Function GetName() As String
        Return name
    End Function

    Public Function IsAlive() As Boolean
        If currHP > 0 Then Return True
        Return False
    End Function

    Public Sub Attack(ByRef enemy As Warrior, ByVal diceroll As Integer)
        enemy.Attacked(diceroll, attDMG)
    End Sub

    Public Sub Attacked(ByVal diceroll As Integer, ByVal attDMG As Integer)
        currHP -= diceroll * attDMG
    End Sub

End Class
