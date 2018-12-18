Imports System.IO

Module Module1

    Sub Main()

        Dim filename As String = Directory.GetCurrentDirectory & "..\..\..\database.txt"
        Dim line As String

        Using Reader As StreamWriter = New StreamWriter(filename)

            For i = 0 To 9

                Reader.WriteLine("This is line: " & i + 1)

            Next

        End Using

        Using Reader As StreamReader = New StreamReader(filename)

            Do Until Reader.EndOfStream

                line = Reader.ReadLine()
                Console.WriteLine(line)

            Loop

        End Using

        filename = "MyFile.bin"

        Using writer As BinaryWriter = New BinaryWriter(File.Open(filename, FileMode.OpenOrCreate))

            writer.Write(5)

            writer.Write("Hello, world")

            writer.Write(True)

        End Using

        Dim myInt As Integer

        Dim myString As String

        Dim myBool As Boolean

        Using reader As BinaryReader = New BinaryReader(File.OpenRead(filename))

            myInt = reader.ReadInt32

            myString = reader.ReadString

            myBool = reader.ReadBoolean

        End Using

        Console.WriteLine(myInt & ", " & myString & ", " & myBool)

        Console.ReadKey()

    End Sub

End Module
