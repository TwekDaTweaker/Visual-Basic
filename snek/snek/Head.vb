Public Class Head

    Inherits Part

    Private vel As New Vec2(0, 0)
    Private elapsedTime As Decimal
    Private speed As Decimal

    Public Sub New(ByVal pos As Vec2)
        MyBase.New(pos, Nothing)
        Randomize()
        Dim rand As New Random()
        Dim temp As Integer = 0
        While temp = 0
            temp = rand.Next(-1, 2)
        End While
        vel.x = temp
        vel.y = 0
        speed = 6
        Console.CursorVisible = False
    End Sub

    Public Overloads Sub Update(ByRef food As List(Of Vec2), ByRef parts As List(Of Part), ByVal dt As Decimal)
        If Console.KeyAvailable = True Then
            Dim key = Console.ReadKey(True)
            Select Case LCase(key.KeyChar())
                Case "w"
                    vel.y = -1
                    vel.x = 0
                Case "a"
                    vel.x = -1
                    vel.y = 0
                Case "s"
                    vel.y = +1
                    vel.x = 0
                Case "d"
                    vel.x = +1
                    vel.y = 0
            End Select
        End If
        If elapsedTime > (1 / speed) Then
            Draw(pos, ConsoleColor.Black) 'Potential bugs
            Me.pos += vel
            Draw()
            elapsedTime = 0
        End If
        elapsedTime += dt
    End Sub

End Class
