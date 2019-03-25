Public Class HealingWarrior

    Inherits Warrior

    Private healed As Boolean

    Public Sub New(ByVal name As String)
        MyBase.New(name)
        healed = False
    End Sub

    Public Function IsHealed() As Boolean
        Return healed
    End Function

    Public Sub SetHealed(ByVal healed As Boolean)
        Me.healed = healed
    End Sub

    Public Sub Heal()
        currHP = maxHP
        healed = True
    End Sub

End Class
