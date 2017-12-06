Imports System.Data.SqlClient
Public Class CPP_DB
    Private Shared cn As SqlConnection
    Private Shared strError As String
    Public Shared Function loadStudents() As List(Of clsStudent)
        'List of students that will be returned
        Dim studentList As New List(Of clsStudent)

        'DB variables
        Dim strSQL As String
        Dim cmd As New SqlCommand
        Dim rdr As SqlDataReader

        'clear the errors
        strError = ""
        Try
            dbConnect()
            strSQL = "SELECT * FROM CPP_STUDENTS"
            cmd.Connection = cn
            cmd.CommandText = strSQL
            rdr = cmd.ExecuteReader()
            Do While rdr.Read()
                'Add basic student information
                Dim aStudent As New clsStudent
                aStudent.broncoID = rdr("BRONCO_ID")
                aStudent.firstName = rdr("FIRST_NAME")
                aStudent.lastName = rdr("LAST_NAME")
                aStudent.email = rdr("EMAIL")
                aStudent.phone = rdr("PHONE")
                studentList.Add(aStudent)
            Loop
            dbClose()
        Catch ex As SqlException
            dbAddError(ex.Message)
        Catch ex As Exception
            dbAddError(ex.Message)
        End Try
        Return studentList
    End Function
    Public Shared Function deleteStudent(strStudentID As String) As Integer
        'Result that will be returned
        Dim intResult As Integer = 0

        'DB variables
        Dim cmd As New SqlCommand
        Dim strSQL As String

        'Clear errors
        strError = ""

        'Delete from database
        Try
            dbConnect()
            strSQL = "DELETE FROM CPP_STUDENTS WHERE BRONCO_ID = '" & strStudentID & "'"
            cmd.Connection = cn
            cmd.CommandText = strSQL
            intResult = cmd.ExecuteNonQuery()
            If (intResult < 1) Then
                dbAddError("DELETE Failed, Student id " & strStudentID & " was not found!")
            End If
            dbClose()
        Catch ex As Exception
            dbAddError("DELETE Failed " & vbCrLf & ex.Message)
        Finally
            cmd.Dispose()
        End Try
        Return intResult
    End Function
    Public Shared Sub updateStudent(aBroncoID As String, aStudent As clsStudent)
        strError = ""
        'To update we remove old student and add new student
        'there are other ways to do this as well using the update statement
        deleteStudent(aBroncoID)
        insertStudent(aStudent)
        If strError <> "" Then
            strError = "Could not Update student " & aStudent.broncoID & vbCrLf & vbCrLf & strError
        End If
    End Sub
    Public Shared Function insertStudent(aStudent As clsStudent) As Integer
        'Result that will be returned
        Dim intResult As Integer = 0

        'DB variables
        Dim cmd As New SqlCommand
        Dim strSQL As String

        'clear the errors
        strError = ""

        'insert into database
        Try
            dbConnect()
            strSQL = "INSERT INTO CPP_STUDENTS (BRONCO_ID, FIRST_NAME, LAST_NAME, PHONE, EMAIL) " &
                        "VALUES ('" & aStudent.broncoID & "', '" & aStudent.firstName & "', '" & aStudent.lastName & "', '" & aStudent.phone & "', '" & aStudent.email & "')"
            cmd.Connection = cn
            cmd.CommandText = strSQL
            cmd.ExecuteNonQuery()
            dbClose()
        Catch ex As Exception
            dbAddError("Insert Failed " & vbCrLf & ex.Message)
        Finally
            cmd.Dispose()
        End Try
        Return intResult
    End Function
    'Public Shared Function findStudent(strStudentID As String) As clsStudent
    '    'student that will be returned
    '    Dim aStudent As clsStudent = New clsStudent

    '    'db variables
    '    Dim cmd As New SqlCommand
    '    Dim strSQL As String
    '    Dim rdr As SqlDataReader

    '    'clear error
    '    strError = ""
    '    Try
    '        'strSQL = "SELECT * FROM CPP_STUDENTS WHERE BRONCO_ID = '@StudentID'"
    '        'cmd.Parameters.AddWithValue("@StudentID", strStudentID)
    '        strSQL = "SELECT * FROM CPP_STUDENTS WHERE BRONCO_ID = '" & strStudentID & "'"
    '        cmd.Connection = cn
    '        cmd.CommandText = strSQL
    '        rdr = cmd.ExecuteReader()
    '        If rdr.Read() Then
    '            aStudent.broncoID = rdr("BRONCO_ID")
    '            aStudent.firstName = rdr("FIRST_NAME")
    '            aStudent.lastName = rdr("LAST_NAME")
    '            aStudent.email = rdr("EMAIL")
    '            aStudent.phone = rdr("PHONE")
    '        Else
    '            dbAddError("Student not found")
    '        End If
    '        dbClose()
    '    Catch ex As SqlException
    '        dbAddError(ex.Message)
    '    Catch ex As Exception
    '        dbAddError(ex.Message)
    '    End Try
    '    Return aStudent
    'End Function
    Public Shared Function loadInstructor() As List(Of clsInstructor)
        'List of students that will be returned
        Dim instructorList As New List(Of clsInstructor)

        'DB variables
        Dim cmd As New SqlCommand
        Dim strSQL As String
        Dim rdr As SqlDataReader

        'clear the errors
        strError = ""
        Try
            dbConnect()
            strSQL = "SELECT * FROM CPP_INSTRUCTORS"
            cmd.Connection = cn
            cmd.CommandText = strSQL
            rdr = cmd.ExecuteReader()
            Do While rdr.Read()
                'Add basic instructor information
                Dim aInstructor As New clsInstructor
                aInstructor.profID = rdr("PROF_ID")
                aInstructor.firstName = rdr("FIRST_NAME")
                aInstructor.lastName = rdr("LAST_NAME")
                aInstructor.phone = rdr("PHONE")
                aInstructor.department = rdr("DEPARTMENT")
                instructorList.Add(aInstructor)
            Loop
            dbClose()
        Catch ex As SqlException
            dbAddError(ex.Message)
        Catch ex As Exception
            dbAddError(ex.Message)
        End Try
        Return instructorList
    End Function
    Public Shared Function deleteInstructor(strProfID As String) As Integer
        'Result that will be returned
        Dim intResult As Integer = 0

        'DB variables
        Dim cmd As New SqlCommand
        Dim strSQL As String

        'Clear errors
        strError = ""

        'Delete from database
        Try
            dbConnect()
            strSQL = "DELETE FROM CPP_INSTRUCTORS WHERE PROF_ID = '" & strProfID & "'"
            cmd.Connection = cn
            cmd.CommandText = strSQL
            intResult = cmd.ExecuteNonQuery()
            If (intResult < 1) Then
                dbAddError("DELETE Failed, Instructor id " & strProfID & " was not found!")
            End If
            dbClose()
        Catch ex As Exception
            dbAddError("DELETE Failed " & vbCrLf & ex.Message)
        Finally
            cmd.Dispose()
        End Try
        Return intResult
    End Function
    Public Shared Sub updateInstructor(aInstructorID As String, aInstructor As clsInstructor)
        strError = ""
        'To update we remove old instructor and add new instructor there are other ways to do this as well using the update statement
        deleteInstructor(aInstructorID)
        insertInstructor(aInstructor)
        If strError <> "" Then
            strError = "Could not Update instructor " & aInstructor.profID & vbCrLf & vbCrLf & strError
        End If
    End Sub
    Public Shared Function insertInstructor(aInstructor As clsInstructor) As Integer
        'Result that will be returned
        Dim intResult As Integer = 0

        'DB variables
        Dim cmd As New SqlCommand
        Dim strSQL As String

        'clear the errors
        strError = ""

        'insert into database
        Try
            dbConnect()
            strSQL = "INSERT INTO CPP_INSTRUCTORS (PROF_ID, FIRST_NAME, LAST_NAME, PHONE, DEPARTMENT) " &
                            "VALUES('" & aInstructor.profID & "','" & aInstructor.firstName & "','" & aInstructor.lastName & "','" & aInstructor.phone & "', '" & aInstructor.department & "')"
            cmd.Connection = cn
            cmd.CommandText = strSQL
            cmd.ExecuteNonQuery()
            dbClose()
        Catch ex As Exception
            dbAddError("Insert Failed " & vbCrLf & ex.Message)
        Finally
            cmd.Dispose()
        End Try
        Return intResult
    End Function
    'Public Shared Function findInstructor(strProfID As String) As clsInstructor
    '    'instructor that will be returned
    '    Dim aInstructor As clsInstructor = New clsInstructor

    '    'db variables
    '    Dim cmd As New SqlCommand
    '    Dim rdr As SqlDataReader
    '    Dim strSQL As String

    '    'clear error
    '    strError = ""
    '    Try
    '        strSQL = "SELECT * FROM CPP_INSTRUCTORS WHERE PROF_ID = '" & strProfID & "'"
    '        cmd.Connection = cn
    '        cmd.CommandText = strSQL
    '        rdr = cmd.ExecuteReader()
    '        If rdr.Read() Then
    '            aInstructor.profID = rdr("PROF_ID")
    '            aInstructor.firstName = rdr("FIRST_NAME")
    '            aInstructor.lastName = rdr("LAST_NAME")
    '            aInstructor.department = rdr("DEPARTMENT")
    '            aInstructor.phone = rdr("PHONE")
    '        Else
    '            dbAddError("Instructor not found")
    '        End If
    '        dbClose()
    '    Catch ex As SqlException
    '        dbAddError(ex.Message)
    '    Catch ex As Exception
    '        dbAddError(ex.Message)
    '    End Try
    '    Return aInstructor
    'End Function
    Public Shared Function loadCourse() As List(Of clsCourse)
        'List of students that will be returned
        Dim courseList As New List(Of clsCourse)

        'DB variables
        Dim cmd As New SqlCommand
        Dim strSQL As String
        Dim rdr As SqlDataReader

        'clear the errors
        strError = ""
        Try
            dbConnect()
            strSQL = "SELECT * FROM CPP_COURSES"
            cmd.Connection = cn
            cmd.CommandText = strSQL
            rdr = cmd.ExecuteReader()
            Do While rdr.Read()
                'Add basic course information
                Dim aCourse As New clsCourse
                aCourse.courseID = rdr("COURSE_ID")
                aCourse.description = rdr("DESCRIPTION")
                aCourse.units = rdr("UNITS")
                courseList.Add(aCourse)
            Loop
            dbClose()
        Catch ex As SqlException
            dbAddError(ex.Message)
        Catch ex As Exception
            dbAddError(ex.Message)
        End Try
        Return courseList
    End Function
    Public Shared Function deleteCourse(strCourseID As String) As Integer
        'Result that will be returned
        Dim intResult As Integer = 0

        'DB variables
        Dim cmd As New SqlCommand
        Dim strSQL As String

        'Clear errors
        strError = ""

        'Delete from database
        Try
            dbConnect()
            strSQL = "DELETE FROM CPP_COURSES WHERE COURSE_ID = '" & strCourseID & "'"
            cmd.Connection = cn
            cmd.CommandText = strSQL
            intResult = cmd.ExecuteNonQuery()
            If (intResult < 1) Then
                dbAddError("DELETE Failed, Course id " & strCourseID & " was not found!")
            End If
            dbClose()
        Catch ex As Exception
            dbAddError("DELETE Failed " & vbCrLf & ex.Message)
        Finally
            cmd.Dispose()
        End Try
        Return intResult
    End Function

    Public Shared Sub updateCourse(aCourseID As String, aCourse As clsCourse)
        strError = ""
        'To update we remove old course and add new course there are other ways to do this as well using the update statement
        deleteCourse(aCourseID)
        insertCourse(aCourse)
        If strError <> "" Then
            strError = "Could not Update course " & aCourse.courseID & vbCrLf & vbCrLf & strError
        End If
    End Sub
    Public Shared Function insertCourse(aCourse As clsCourse) As Integer
        'Result that will be returned
        Dim intResult As Integer = 0

        'DB variables
        Dim cmd As New SqlCommand
        Dim strSQL As String

        'clear the errors
        strError = ""

        'insert into database
        Try
            dbConnect()
            strSQL = "INSERT INTO CPP_COURSES (COURSE_ID, DESCRIPTION, UNITS) " &
                            "VALUES('" & aCourse.courseID & "','" & aCourse.description & "'," & aCourse.units & ")"
            cmd.Connection = cn
            cmd.CommandText = strSQL
            cmd.ExecuteNonQuery()
            dbClose()
        Catch ex As Exception
            dbAddError("Insert Failed " & vbCrLf & ex.Message)
        Finally
            cmd.Dispose()
        End Try
        Return intResult
    End Function
    'Public Shared Function findCourse(strCourseID As String) As clsCourse
    '    'course that will be returned
    '    Dim aCourse As clsCourse = New clsCourse

    '    'db variables
    '    Dim cmd As New SqlCommand
    '    Dim strSQL As String
    '    Dim rdr As SqlDataReader

    '    'clear error
    '    strError = ""
    '    Try
    '        strSQL = "SELECT * FROM CPP_COURSES WHERE COURSE_ID = '" & strCourseID & "'"
    '        cmd.Connection = cn
    '        cmd.CommandText = strSQL
    '        rdr = cmd.ExecuteReader()
    '        If rdr.Read() Then
    '            aCourse.courseID = rdr("COURSE_ID")
    '            aCourse.description = rdr("DESCRIPTION")
    '            aCourse.units = rdr("UNITS")
    '        Else
    '            dbAddError("Course not found")
    '        End If
    '        dbClose()
    '    Catch ex As SqlException
    '        dbAddError(ex.Message)
    '    Catch ex As Exception
    '        dbAddError(ex.Message)
    '    End Try
    '    Return aCourse
    'End Function
    Public Shared Function loadCatalog() As List(Of clsCatalog)
        'List of catalog that will be returned
        Dim catalogList As New List(Of clsCatalog)

        'DB variables
        Dim cmd As New SqlCommand
        Dim strSQL As String
        Dim rdr As SqlDataReader

        'clear the errors
        strError = ""
        Try
            dbConnect()
            strSQL = "SELECT * FROM CPP_CATALOG"
            cmd.Connection = cn
            cmd.CommandText = strSQL
            rdr = cmd.ExecuteReader()
            Do While rdr.Read()
                'Add basic catalog information
                Dim aCatalog As New clsCatalog
                aCatalog.catalogID = rdr("CATALOG_ID")
                aCatalog.year = rdr("YEAR")
                aCatalog.quarter = rdr("QUARTER")
                aCatalog.courseID = rdr("COURSE_ID")
                aCatalog.profID = rdr("PROF_ID")
                catalogList.Add(aCatalog)
            Loop
            dbClose()
        Catch ex As SqlException
            dbAddError(ex.Message)
        Catch ex As Exception
            dbAddError(ex.Message)
        End Try
        Return catalogList
    End Function
    Public Shared Function deleteCatalog(strCatalogID As String) As Integer
        'Result that will be returned
        Dim intResult As Integer = 0

        'DB variables
        Dim cmd As New SqlCommand
        Dim strSQL As String

        'Clear errors
        strError = ""

        'Delete from database
        Try
            dbConnect()
            strSQL = "DELETE FROM CPP_CATALOG WHERE CATALOG_ID = '" & strCatalogID & "'"
            cmd.Connection = cn
            cmd.CommandText = strSQL
            intResult = cmd.ExecuteNonQuery()
            If (intResult < 1) Then
                dbAddError("DELETE Failed, Catalog id " & strCatalogID & " was not found!")
            End If
            dbClose()
        Catch ex As Exception
            dbAddError("DELETE Failed " & vbCrLf & ex.Message)
        Finally
            cmd.Dispose()
        End Try
        Return intResult
    End Function
    Public Shared Sub updateCatalog(aCatalogID As String, aCatalog As clsCatalog)
        strError = ""
        'To update we remove old catalog and add new catalog there are other ways to do this as well using the update statement
        deleteCatalog(aCatalogID)
        insertCatalog(aCatalog)
        If strError <> "" Then
            strError = "Could not Update catalog " & aCatalog.catalogID & vbCrLf & vbCrLf & strError
        End If
    End Sub
    Public Shared Function insertCatalog(aCatalog As clsCatalog) As Integer
        'Result that will be returned
        Dim intResult As Integer = 0

        'DB variables
        Dim cmd As New SqlCommand
        Dim strSQL As String

        'clear the errors
        strError = ""

        'insert into database
        Try
            dbConnect()
            strSQL = "INSERT INTO CPP_CATALOG (CATALOG_ID, YEAR, QUARTER, COURSE_ID, PROF_ID) " &
                            "VALUES('" & aCatalog.catalogID & "'," & aCatalog.year & ",'" & aCatalog.quarter & "','" & aCatalog.courseID & "', '" & aCatalog.profID & "')"
            cmd.Connection = cn
            cmd.CommandText = strSQL
            cmd.ExecuteNonQuery()
            dbClose()
        Catch ex As Exception
            dbAddError("Insert Failed " & vbCrLf & ex.Message)
        Finally
            cmd.Dispose()
        End Try
        Return intResult
    End Function
    'Public Shared Function findCatalog(strCatalogID As String) As clsCatalog
    '    'catalog that will be returned
    '    Dim aCatalog As clsCatalog = New clsCatalog

    '    'db variables
    '    Dim cmd As New SqlCommand
    '    Dim rdr As SqlDataReader
    '    Dim strSQL As String

    '    'clear error
    '    strError = ""
    '    Try
    '        dbConnect()
    '        strSQL = "SELECT * FROM CPP_CATALOG WHERE BRONCO_ID = '" & strCatalogID & "'"
    '        cmd.Connection = cn
    '        cmd.CommandText = strSQL
    '        rdr = cmd.ExecuteReader()
    '        If rdr.Read() Then
    '            aCatalog.courseID = rdr("CATALOG_ID")
    '            aCatalog.year = rdr("YEAR")
    '            aCatalog.quarter = rdr("QUARTER")
    '            aCatalog.courseID = rdr("COURSE_ID")
    '            aCatalog.profID = rdr("PROF_ID")
    '        Else
    '            dbAddError("Catalog not found")
    '        End If
    '        dbClose()
    '    Catch ex As SqlException
    '        dbAddError(ex.Message)
    '    Catch ex As Exception
    '        dbAddError(ex.Message)
    '    End Try
    '    Return aCatalog
    'End Function
    Public Shared Function loadEnrollment() As List(Of clsEnrollment)
        'List of enrollments that will be returned
        Dim enrollmentList As New List(Of clsEnrollment)

        'DB variables
        Dim cmd As New SqlCommand
        Dim strSQL As String
        Dim rdr As SqlDataReader

        'clear the errors
        strError = ""
        Try
            dbConnect()
            strSQL = "SELECT * FROM CPP_ENROLLMENT"
            cmd.Connection = cn
            cmd.CommandText = strSQL
            rdr = cmd.ExecuteReader()
            Do While rdr.Read()
                'Add basic enrollment information
                Dim aEnrollment As New clsEnrollment
                aEnrollment.broncoID = rdr("BRONCO_ID")
                aEnrollment.catalogID = rdr("CATALOG_ID")
                enrollmentList.Add(aEnrollment)
            Loop
            dbClose()
        Catch ex As SqlException
            dbAddError(ex.Message)
        Catch ex As Exception
            dbAddError(ex.Message)
        End Try
        Return enrollmentList
    End Function
    Public Shared Function deleteEnrollment(strBroncoID As String, strCatalogID As String) As Integer
        'Result that will be returned
        Dim intResult As Integer = 0

        'DB variables
        Dim cmd As New SqlCommand
        Dim strSQL As String

        'Clear errors
        strError = ""

        'Delete from database
        Try
            dbConnect()
            strSQL = "DELETE FROM CPP_ENROLLMENT WHERE BRONCO_ID = '" & strBroncoID & "' AND CATALOG_ID = '" & strCatalogID & "'"
            cmd.Connection = cn
            cmd.CommandText = strSQL
            intResult = cmd.ExecuteNonQuery()
            If (intResult < 1) Then
                dbAddError("DELETE Failed, Bronco id " & strBroncoID & " and Catalog ID " & strCatalogID & " was not found!")
            End If
            dbClose()
        Catch ex As Exception
            dbAddError("DELETE Failed " & vbCrLf & ex.Message)
        Finally
            cmd.Dispose()
        End Try
        Return intResult
    End Function
    Public Shared Sub updateEnrollment(aBroncoID As String, aCatalogID As String, aEnrollment As clsEnrollment)
        strError = ""
        'To update we remove old enrollment and add new enrollment there are other ways to do this as well using the update statement
        deleteEnrollment(aBroncoID, aCatalogID)
        insertEnrollment(aEnrollment)
        If strError <> "" Then
            strError = "Could not Update enrollment " & aEnrollment.broncoID & " and " & aEnrollment.catalogID & vbCrLf & vbCrLf & strError
        End If
    End Sub
    Public Shared Function insertEnrollment(aEnrollment As clsEnrollment) As Integer
        'Result that will be returned
        Dim intResult As Integer = 0

        'DB variables
        Dim cmd As New SqlCommand
        Dim strSQL As String

        'clear the errors
        strError = ""

        'insert into database
        Try
            dbConnect()
            strSQL = "INSERT INTO CPP_ENROLLMENT (BRONCO_ID, CATALOG_ID) " &
                            "VALUES('" & aEnrollment.broncoID & "', '" & aEnrollment.catalogID & "')"
            cmd.Connection = cn
            cmd.CommandText = strSQL
            cmd.ExecuteNonQuery()
            dbClose()
        Catch ex As Exception
            dbAddError("Insert Failed " & vbCrLf & ex.Message)
        Finally
            cmd.Dispose()
        End Try
        Return intResult
    End Function
    'Public Shared Function findEnrollment(strBroncoID As String, strCatalogID As String) As clsEnrollment
    '    'enrollment that will be returned
    '    Dim aEnrollment As clsEnrollment = New clsEnrollment

    '    'db variables
    '    Dim cmd As New SqlCommand
    '    Dim rdr As SqlDataReader
    '    Dim strSQL As String

    '    'clear error
    '    strError = ""
    '    Try
    '        strSQL = "SELECT * FROM CPP_ENROLLMENT WHERE BRONCO_ID = '" & strBroncoID & "' AND CATALOG_ID = '" & strCatalogID & "'"
    '        cmd.Connection = cn
    '        cmd.CommandText = strSQL
    '        rdr = cmd.ExecuteReader()
    '        If rdr.Read() Then
    '            aEnrollment.broncoID = rdr("BRONCO_ID")
    '            aEnrollment.catalogID = rdr("CATALOG_ID")
    '        Else
    '            dbAddError("Enrollment not found")
    '        End If
    '        dbClose()
    '    Catch ex As SqlException
    '        dbAddError(ex.Message)
    '    Catch ex As Exception
    '        dbAddError(ex.Message)
    '    End Try
    '    Return aEnrollment
    'End Function
    Public Shared Sub dbOpen()
        'Only assign one reference to the connection
        If IsNothing(cn) Then
            cn = New SqlConnection
            cn.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CPP.mdf;Integrated Security=True"
        End If
    End Sub
    Public Shared Sub dbConnect()
        'Only open if connection is closed
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
    End Sub
    Public Shared Sub dbClose()
        'Only close if open
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
    End Sub
    Private Shared Sub dbAddError(ByVal s As String)
        'build error
        If strError = "" Then
            strError = s
        Else
            strError += vbCrLf & s
        End If
    End Sub
    Public Shared Function dbGetError() As String
        'return error
        Return strError
    End Function
End Class