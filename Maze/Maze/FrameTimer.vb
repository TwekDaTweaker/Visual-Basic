Public Class FrameTimer

    Private last As Decimal

    Public Sub New()
        last = (DateTime.UtcNow - New DateTime(1970, 1, 1, 0, 0, 0)).TotalMilliseconds
    End Sub

    Public Function Mark()
        Dim old = last
        last = (DateTime.UtcNow - New DateTime(1970, 1, 1, 0, 0, 0)).TotalMilliseconds
        Return (last - old) / 1000
    End Function

End Class
