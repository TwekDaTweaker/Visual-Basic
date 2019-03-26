Public Class Vec2

    Public x As Integer = 0
    Public y As Integer = 0

    Public Sub New(ByVal x As Integer, ByVal y As Integer)

        Me.x = x
        Me.y = y

    End Sub

    Public Shared Operator =(ByVal V1 As Vec2, ByVal V2 As Vec2) As Boolean

        Return V1.x = V2.x And V1.y = V2.y

    End Operator

    Public Shared Operator <>(ByVal V1 As Vec2, ByVal V2 As Vec2) As Boolean

        Return V1.x <> V2.x Or V1.y <> V2.y

    End Operator

    Public Shared Operator +(ByVal V1 As Vec2, ByVal V2 As Vec2) As Vec2

        Return New Vec2(V1.x + V2.x, V1.y + V2.y)

    End Operator

    Public Shared Operator -(ByVal V1 As Vec2, ByVal V2 As Vec2) As Vec2

        Return New Vec2(V1.x - V2.x, V1.y - V2.y)

    End Operator

End Class