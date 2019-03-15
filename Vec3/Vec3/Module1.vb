Module Module1
    Class Vec3

        Public x As Double
        Public y As Double
        Public z As Double

        Public Sub New()

            x = 0
            y = 0
            z = 0

        End Sub

        Public Sub New(ByVal x As Double, ByVal y As Double, ByVal z As Double)

            Me.x = x
            Me.y = y
            Me.z = z

        End Sub

        Public Sub New(ByVal vec As Vec3)

            Me.x = vec.x
            Me.y = vec.y
            Me.z = vec.z

        End Sub

        Public Function GetLenght(ByVal vec As Vec3) As Double

            Return Math.Sqrt(vec.x ^ 2 + vec.y ^ 2 + vec.z ^ 2)

        End Function

        Public Shared Operator =(ByVal vec1 As Vec3, ByVal vec2 As Vec3)

            If vec1.x = vec2.x And vec2.y = vec2.y And vec1.z = vec2.z Then Return True
            Return False

        End Operator

        Public Shared Operator <>(ByVal vec1 As Vec3, ByVal vec2 As Vec3)

            If vec1.x = vec2.x Or vec2.y = vec2.y Or vec1.z = vec2.z Then Return False
            Return True

        End Operator

        Public Shared Operator +(ByVal vec1 As Vec3, ByVal vec2 As Vec3) As Vec3

            Return New Vec3(vec1.x + vec2.x, vec1.y + vec2.y, vec1.z + vec2.z)

        End Operator

        Public Shared Operator -(ByVal vec1 As Vec3, ByVal vec2 As Vec3) As Vec3

            Return New Vec3(vec1.x - vec2.x, vec1.y - vec2.y, vec1.z - vec2.z)

        End Operator

        Public Shared Operator *(ByVal vec As Vec3, ByVal mult As Double) As Vec3

            Return New Vec3(vec.x * mult, vec.y * mult, vec.z * mult)

        End Operator

        Public Shared Operator *(ByVal mult As Double, ByVal vec As Vec3) As Vec3

            Return New Vec3(vec.x * mult, vec.y * mult, vec.z * mult)

        End Operator

        Public Shared Operator *(ByVal vec1 As Vec3, ByVal vec2 As Vec3) As Vec3

            Return New Vec3(vec1.x * vec2.x, vec1.y * vec2.y, vec1.z * vec2.z)

        End Operator

        Public Shared Operator /(ByVal vec As Vec3, ByVal dev As Double)

            Return New Vec3() = vec * (1 / dev)

        End Operator

        Public Shared Operator /(ByVal dev As Double, ByVal vec As Vec3)

            Return New Vec3() = vec * (1 / dev)

        End Operator

    End Class
    Sub Main()

    End Sub

End Module
