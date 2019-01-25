Module Module1

    Dim conn As New System.Data.Odbc.OdbcConnection("DRIVER={MySQL ODBC 5.3 ANSI Driver};SERVER=localhost;PORT=3306;DATABASE=hogwarts;USER=root;PASSWORD=root;OPTION=3;")
    'Structures used to temporaily hold the data taken from the database
    Structure pupil
        Dim id As Integer
        Dim forename As String
        Dim surname As String
        Dim house As String
        Dim age As Integer
    End Structure

    Structure Classes
        Dim name As String
        Dim teacher As String
        Dim id As Integer
    End Structure

    Sub Main()

        conn.Open() 'starts connection with database
        Dim choice As Char
        Do
            Do
                mainmenu()
                choice = Console.ReadLine
            Loop Until choice = "1" Or choice = "2" Or choice = "3" Or choice = "9"
            Select Case choice
                Case "1"
                    pupilsection()
                Case "2"
                    classsection()
                Case "3"
                    enrolsection()
            End Select
        Loop Until choice = "9"
        Console.WriteLine("Goodbye!")
        Console.ReadKey()
    End Sub

    'The findpupil function has been used in viewpupil and deletepupil
    'HINT: It will be useful in enrolpupil and removeenrolment
    Function findpupil(ByRef pupils() As pupil, ByVal surname As String, ByRef count As Integer) As Boolean
        'This function will find all pupils with surname given.  
        'If more then than one pupil with same surname then allows user to choose one and adjusts variable count accordingly
        'Function returns true if pupil found, false if no pupil found with given surname
        'Pupil(s) found will be saved in the pupils structure which has been passed by reference
        Dim choice As String
        Dim rspupils As Odbc.OdbcDataReader
        Dim sql As New Odbc.OdbcCommand("select * from pupils where surname = '" & surname & "' ", conn)
        rspupils = sql.ExecuteReader
        If rspupils.HasRows Then
            If rspupils.RecordsAffected > 1 Then
                Do While rspupils.Read
                    Console.WriteLine("Pupil " & count)
                    pupils(count).id = rspupils("id")
                    pupils(count).forename = rspupils("forename")
                    pupils(count).surname = rspupils("surname")
                    pupils(count).house = rspupils("house")
                    pupils(count).age = rspupils("age")
                    Console.WriteLine("Name: " & pupils(count).forename & " " & pupils(count).surname)
                    Console.WriteLine()
                    count += 1
                Loop
                Console.WriteLine("Select pupil")
                choice = Console.ReadLine
                count = CInt(choice)
            Else
                pupils(count).id = rspupils("id")
                pupils(count).forename = rspupils("forename")
                pupils(count).surname = rspupils("surname")
                pupils(count).house = rspupils("house")
                pupils(count).age = rspupils("age")
            End If
            Return True
        Else
            Console.WriteLine("No pupil with that name found")
            Return False
        End If
    End Function

    'This findclassesForPupil function is used in viewpupil
    Function findclassesForPupil(ByVal pupilId As Integer, ByRef tempclass() As Classes, ByRef count As Integer) As Boolean
        'This function finds all the classes for a particular pupil
        'Returns true if classes found, otherwise returns false
        'If class(es) found they will be put into tempclass struture that is passed by reference
        Dim sql As New Odbc.OdbcCommand("SELECT NAME, teacher FROM classes, enrolment WHERE enrolment.pupilsId = '" & pupilId & "' AND classes.id = enrolment.classesId", conn)
        Dim rsclass As Odbc.OdbcDataReader
        rsclass = sql.ExecuteReader
        If rsclass.HasRows Then
            Do While rsclass.Read
                count += 1
                tempclass(count).name = rsclass("name")
                tempclass(count).teacher = rsclass("teacher")
            Loop
            Return True
        Else
            Return False
        End If
    End Function

    'The following four subs have been coded. Use them to help you with your code
    Sub Viewpupil()
        Dim surname As String
        Dim count As Integer = 0
        Dim pupils(10) As pupil
        Dim tempclass(10) As Classes
        Dim numofclasses As Integer = -1
        Dim found As Boolean = False
        Console.WriteLine("View Pupil Information")
        Console.WriteLine()
        Console.WriteLine("Enter pupil surname:")
        surname = Console.ReadLine
        found = findpupil(pupils, surname, count)
        If found = True Then
            Console.WriteLine()
            Console.WriteLine("Name:  " & pupils(count).forename & " " & pupils(count).surname)
            Console.WriteLine("House: " & pupils(count).house)
            Console.WriteLine("Age:   " & pupils(count).age)
            Console.WriteLine()
            If findclassesForPupil(pupils(count).id, tempclass, numofclasses) Then
                For i = 0 To numofclasses
                    Console.WriteLine("Class name:   " & tempclass(i).name)
                    Console.WriteLine("Teacher name: " & tempclass(i).teacher)
                    Console.WriteLine()
                Next
            Else
                Console.WriteLine("This pupil does not have any classes")
            End If
        End If
        Console.ReadKey()
    End Sub

    Sub addpupil()
        Dim surname, forename, house As String
        Dim age As Integer
        Console.WriteLine("Add New Pupil")
        Console.WriteLine()
        Console.WriteLine("Enter pupil surname:")
        surname = Console.ReadLine
        Console.WriteLine("Enter pupil forename:")
        forename = Console.ReadLine
        Console.WriteLine("Enter pupil age:")
        age = Console.ReadLine
        Console.WriteLine("Enter pupil house:")
        house = Console.ReadLine
        Dim sql As New Odbc.OdbcCommand("INSERT INTO pupils(forename,surname,house,age) VALUES ('" & forename & "', '" & surname & "', '" & house & "', '" & age & "')", conn)
        sql.ExecuteNonQuery()
        Console.WriteLine()
        Console.WriteLine("New pupil " & forename & " " & surname & " added.")
        Console.WriteLine("Press enter to return to menu")
        Console.ReadKey()
    End Sub

    Sub deletepupil()
        Dim surname, choice As String
        Dim pupils(10) As pupil
        Dim found As Boolean
        Dim id, count As Integer
        Dim rsid As Odbc.OdbcDataReader
        count = 0
        Console.WriteLine("Delete Pupil")
        Console.WriteLine()
        Console.WriteLine("The pupil and any enrolments associated with this pupil will be deleted.")
        Console.WriteLine()
        Console.WriteLine("Enter pupil's surname:")
        surname = Console.ReadLine
        Console.WriteLine()
        found = findpupil(pupils, surname, count)
        If found Then
            Console.WriteLine("Are you sure you want to delete " & pupils(count).forename & " " & pupils(count).surname & "? (Y/N)")
            choice = Console.ReadLine.ToUpper
            If choice = "Y" Then
                Dim sqlid As New Odbc.OdbcCommand("SELECT id FROM pupils WHERE surname = '" & surname & "'", conn)
                rsid = sqlid.ExecuteReader
                If rsid.Read Then
                    id = rsid("id")
                End If
                Dim sqldeleteenrolment As New Odbc.OdbcCommand("DELETE FROM enrolment WHERE pupilsId = '" & id & "'", conn)
                sqldeleteenrolment.ExecuteNonQuery()
                Dim sqldeleteclass As New Odbc.OdbcCommand("DELETE FROM pupils WHERE id = '" & id & "'", conn)
                sqldeleteclass.ExecuteNonQuery()
                Console.WriteLine()
                Console.WriteLine("Pupil " & pupils(count).forename & " " & pupils(count).surname & " has been deleted.")
            End If
        End If
        Console.WriteLine("Press enter to return to menu")
        Console.ReadKey()
    End Sub

    Sub pupilsall()
        Dim rspupils As Odbc.OdbcDataReader
        Console.WriteLine("List of all pupils")
        Console.WriteLine()
        Dim sql As New Odbc.OdbcCommand("select * from pupils order by house", conn)
        rspupils = sql.ExecuteReader
        Console.WriteLine()
        Do While rspupils.Read
            Console.WriteLine(rspupils("house") & " " & rspupils("forename") & " " & rspupils("surname") & " " & rspupils("age"))
        Loop
        Console.WriteLine()
        Console.WriteLine("Press enter to return to menu")
        Console.ReadKey()
    End Sub

    Sub viewclass()

        'In this sub the user enters in a class name.  
        'If the class exists then the teacher of the class is displayed  (SQL required for this)
        'also a list of the pupils in the class is displayed (SQL required for this)

        Console.WriteLine("List of all classes:" & vbNewLine)

        Dim rclasses As Odbc.OdbcDataReader
        Dim sql As New Odbc.OdbcCommand("select * from classes order by id", conn)
        rclasses = sql.ExecuteReader

        Do While rclasses.Read

            Console.WriteLine(rclasses("name") & " | " & rclasses("teacher"))

        Loop

        Console.Write(vbNewLine & "Enter the class you want to expand: ")
        Dim name As String = Console.ReadLine()
        Console.WriteLine()

        sql = New Odbc.OdbcCommand("select classes.id from classes where classes.name='" & name & "'", conn)
        Dim classesId = sql.ExecuteReader
        classesId.Read()
        Dim id As Integer = classesId("id")
        sql = New Odbc.OdbcCommand("select enrolment.pupilsId from enrolment where classesId='" & id & "'", conn)
        Dim pupilsId = sql.ExecuteReader
        Dim ids As New List(Of Integer)

        Do While pupilsId.Read()

            ids.Add(pupilsId("pupilsId"))

        Loop

        Dim req As String = "select * from pupils where "

        For Each id In ids

            req &= "id='" & id & "' or"

        Next



        sql = New Odbc.OdbcCommand(req)
        Dim rspupils = sql.ExecuteReader

        While rspupils.Read()

            Console.WriteLine(rspupils("id") & " " & rspupils("house") & " " & rspupils("forename") & " " & rspupils("surname") & " " & rspupils("age"))

        End While

        Console.ReadKey(True)

    End Sub

    Sub addclass()

        'In this sub the user enters in a new class  
        'The user enters a class name and a teacher which is put into the database (SQL required for this)

        Console.Write("Enter class name: ")
        Dim name As String = Console.ReadLine()
        Console.Write("Enter the teacher's name: ")
        Dim teacher As String = Console.ReadLine()

        Dim sql As New Odbc.OdbcCommand("INSERT INTO classes(name, teacher) VALUES ('" & name & "', '" & teacher & "')", conn)
        sql.ExecuteNonQuery()

        Console.ReadKey(True)

    End Sub

    Sub deleteclass()

        'In this sub the user deltes a class  
        'The user enters a class name 
        'Firstly the id of the class will need to be retieved(SQL required for this)
        'Then any enrolments with this class need to be deleted (SQL required for this)
        'Finally the class needs to be deleted from the classes table (SQL required for this)

        Console.WriteLine("List of all classes:" & vbNewLine)

        Dim rclasses As Odbc.OdbcDataReader
        Dim sql As New Odbc.OdbcCommand("select * from classes order by id", conn)
        rclasses = sql.ExecuteReader

        Do While rclasses.Read

            Console.WriteLine(rclasses("name") & " | " & rclasses("teacher"))

        Loop

        Console.Write(vbNewLine & "Enter the class you want to delete: ")
        Dim name As String = Console.ReadLine()
        Console.WriteLine()

        sql = New Odbc.OdbcCommand("select classes.id from classes where classes.name='" & name & "'", conn)
        Dim classesId = sql.ExecuteReader
        classesId.Read()
        Dim id As Integer = classesId("id")

        sql = New Odbc.OdbcCommand("delete * from enrolment where classesId='" & id & "'", conn)
        Dim classDel = sql.ExecuteNonQuery
        sql = New Odbc.OdbcCommand("delete * from classes where id='" & id & "'", conn)
        classDel = sql.ExecuteNonQuery

        Console.ReadKey(True)

    End Sub

    Sub viewallclasses()

        'This sub displays all the classes and the teachers (SQL required for this)

        Console.WriteLine("List of all classes:" & vbNewLine)

        Dim rclasses As Odbc.OdbcDataReader
        Dim sql As New Odbc.OdbcCommand("select * from classes order by id", conn)
        rclasses = sql.ExecuteReader

        Do While rclasses.Read

            Console.WriteLine(rclasses("name") & " | " & rclasses("teacher"))

        Loop

        Console.ReadKey(True)

    End Sub

    Sub enrolpupil()

        'This sub enrols a particular pupil onto a particular class
        'User enters a pupil surname. Use the findpupil function here to help choose the pupil as maybe more than one with same surname
        'Then user enters class name. Need to get class details from database (SQL required for this)
        'Then insert a new enrolment into the enrolment table using the pupil id and class id found before (SQL required for this)



        Console.ReadKey(True)

    End Sub

    Sub removeenrolment()

        'This sub removes a pupil from a class
        'User enters a class. Need to get class details from database (SQL required for this)
        'User enters a pupil surname. Use the findpupil function here to help choose the pupil as maybe more than one with same surname
        'Then delete the enrolment from the enrolment table using the pupil id and class id found before (SQL required for this)



        Console.ReadKey(True)

    End Sub

    'Menus all coded for you
    Sub mainmenu()
        Console.Clear()
        Console.WriteLine("Welcome to HogStudio")
        Console.WriteLine()
        Console.WriteLine("1. Pupil information")
        Console.WriteLine("2. Class information")
        Console.WriteLine("3. Enroling and removing pupils from classes")
        Console.WriteLine()
        Console.WriteLine("9. Exit")
        Console.WriteLine()
    End Sub

    Sub pupilmenu()
        Console.Clear()
        Console.WriteLine("HogStudio - Pupil Section")
        Console.WriteLine()
        Console.WriteLine("1. View a pupil's information")
        Console.WriteLine("2. Add a new pupil")
        Console.WriteLine("3. Delete a pupil")
        Console.WriteLine("4. View all pupils")
        Console.WriteLine()
        Console.WriteLine("9. Return to Main Menu")
        Console.WriteLine()
    End Sub

    Sub classmenu()
        Console.Clear()
        Console.WriteLine("HogStudio - Class Section")
        Console.WriteLine()
        Console.WriteLine("1. View class information")
        Console.WriteLine("2. Add a new class")
        Console.WriteLine("3. Delete a class")
        Console.WriteLine("4. View a list of all classes")
        Console.WriteLine()
        Console.WriteLine("9. Return to Main Menu")
        Console.WriteLine()
    End Sub

    Sub enrolmenu()
        Console.Clear()
        Console.WriteLine("HogStudio - Enrolment Section")
        Console.WriteLine()
        Console.WriteLine("1. Enrol a pupil onto a class")
        Console.WriteLine("2. Remove a pupil from a class")
        Console.WriteLine()
        Console.WriteLine("9. Return to Main Menu")
        Console.WriteLine()
    End Sub

    Sub pupilsection()
        Dim choice As Char
        Do
            Do
                pupilmenu()
                choice = Console.ReadLine
            Loop Until choice = "1" Or choice = "2" Or choice = "3" Or choice = "4" Or choice = "9"
            Select Case choice
                Case "1"
                    Viewpupil()
                Case "2"
                    addpupil()
                Case "3"
                    deletepupil()
                Case "4"
                    pupilsall()
            End Select
        Loop Until choice = "9"
    End Sub

    Sub classsection()
        Dim choice As Char
        Do
            Do
                classmenu()
                choice = Console.ReadLine
            Loop Until choice = "1" Or choice = "2" Or choice = "3" Or choice = "4" Or choice = "9"
            Select Case choice
                Case "1"
                    viewclass()
                Case "2"
                    addclass()
                Case "3"
                    deleteclass()
                Case "4"
                    viewallclasses()
            End Select
        Loop Until choice = "9"
    End Sub

    Sub enrolsection()
        Dim choice As Char
        Do
            Do
                enrolmenu()
                choice = Console.ReadLine
            Loop Until choice = "1" Or choice = "2" Or choice = "9"
            Select Case choice
                Case "1"
                    enrolpupil()
                Case "2"
                    removeenrolment()

            End Select
        Loop Until choice = "9"
    End Sub

End Module