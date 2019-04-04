Public Class Node

    Public pos As Vec2
    Public f As Single
    Public h As Integer
    Public vh As Single
    Public g As Integer
    Public neighbors As New List(Of Node)
    Public prev As Node

    Public Sub New(ByVal pos As Vec2, ByVal h As Integer, ByVal vh As Single)
        Me.pos = pos
        Me.h = h
        Me.vh = vh
        Me.f = h
    End Sub

    Public Sub New(ByVal pos As Vec2, ByVal h As Integer, ByVal vh As Single,
                   ByVal g As Integer)
        Me.pos = pos
        Me.h = h
        Me.vh = vh
        Me.f = h + g
    End Sub

    Public Sub addNeighbors(ByRef grid(,) As Node, ByRef map(,) As Boolean, ByVal height As Integer, ByVal width As Integer)
        If pos.y > 0 Then
            If map(pos.y - 1, pos.x) Then neighbors.Add(grid(pos.y - 1, pos.x))
        End If
        If pos.y < height Then
            If map(pos.y + 1, pos.x) Then neighbors.Add(grid(pos.y + 1, pos.x))
        End If
        If pos.x > 0 Then
            If map(pos.y, pos.x - 1) Then neighbors.Add(grid(pos.y, pos.x - 1))
        End If
        If pos.x < width Then
            If map(pos.y, pos.x + 1) Then neighbors.Add(grid(pos.y, pos.x + 1))
        End If
    End Sub

    Public Shared Operator =(ByVal N1 As Node, ByVal N2 As Node) As Boolean
        Return N1.pos.x = N2.pos.x And N1.pos.y = N2.pos.y
    End Operator

    Public Shared Operator <>(ByVal N1 As Node, ByVal N2 As Node) As Boolean
        Return N1.pos.x <> N2.pos.x Or N1.pos.y <> N2.pos.y
    End Operator

End Class
