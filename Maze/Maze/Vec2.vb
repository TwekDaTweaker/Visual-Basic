Public Class Vec2

    Public x As Integer = 0
    Public y As Integer = 0

    Public Sub New()
        Me.x = 0
        Me.y = 0
    End Sub

    Public Sub New(ByVal x As Integer, ByVal y As Integer)
        Me.x = x
        Me.y = y
    End Sub

    Public Sub New(ByVal vec As Vec2)
        Me.New(vec.x, vec.y)
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

    Public Shared Operator *(ByVal vec As Vec2, ByVal mult As Double) As Vec2
        Return New Vec2(vec.x * mult, vec.y * mult)
    End Operator

End Class
