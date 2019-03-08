Module Module1

    Enum type

        circle
        triangle
        rectangle

    End Enum

    Structure Shape

        Dim type As Byte
        Dim radius As Integer
        Dim width As Integer
        Dim height As Integer

    End Structure

    Sub Main()

        Dim shape(2) As Shape

        For i = 0 To shape.Length - 1

            Init(shape(i))

        Next

        For i = 0 To shape.Length - 1

            Console.WriteLine("Shape: " & i + 1)
            Show(shape(i))

        Next

        Console.ReadKey()

    End Sub

    Sub Init(ByRef shape As Shape)

        Console.WriteLine("Enter 'c' for circle, 't' for triangle, 'r' for rectangle and the following dimensions." & vbNewLine)

        Dim sh = Console.ReadLine()

        Select Case LCase(sh)

            Case "c"

                shape.type = type.circle
                shape.radius = Console.ReadLine()

            Case "t"

                shape.type = type.triangle
                shape.width = Console.ReadLine()
                shape.height = Console.ReadLine()

            Case "r"

                shape.type = type.rectangle
                shape.width = Console.ReadLine()
                shape.height = Console.ReadLine()

        End Select

        Console.WriteLine()

    End Sub

    Sub Show(ByVal shape As Shape)

        Select Case shape.type

            Case type.circle

                Console.WriteLine("Radius: " & shape.radius)
                Console.WriteLine("Area: " & 2 * Math.PI * shape.radius)

            Case type.triangle

                Console.WriteLine("Width: " & shape.width)
                Console.WriteLine("height: " & shape.height)
                Console.WriteLine("Area: " & CSng(shape.width * shape.height) / 2)

            Case type.rectangle

                Console.WriteLine("Width: " & shape.width)
                Console.WriteLine("height: " & shape.height)
                Console.WriteLine("Area: " & shape.width * shape.height)

        End Select

        Console.WriteLine()

    End Sub

End Module
