Public Class frmCourse
    Dim courseList As New List(Of clsCourse)
    Dim validator As New clsValidator
    Dim aCourseID As String
    Private Sub frmCourse_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'LOAD FROM DB
        CPP_DB.dbOpen()
        courseList = CPP_DB.loadCourse()
        CPP_DB.dbClose()

        'CHECK ERRORS
        If (CPP_DB.dbGetError = "") Then
            refreshDataGrid()
        Else
            MessageBox.Show(CPP_DB.dbGetError)
        End If
    End Sub
    Private Sub refreshDataGrid()
        'CREATE A BINDING SOURCE AND 
        Dim COURSEBindingSource As New BindingSource

        'ASSIGN THE DATAROUCE TO THE COURSE LIST
        COURSEBindingSource.DataSource = courseList

        'SET THE GRID DATASOURCE TO THE BINDING SOURCE
        Me.CPP_COURSESDataGridView.DataSource = COURSEBindingSource
    End Sub
    Public Sub setMode(strMode As String)
        'CONTROL THE DISPLAY OF LIST VS DETAIL OF COURSE
        If strMode = "L" Then
            'MODE IS LIST
            Me.gbCourseDetail.Hide()
            Me.gbCourseList.Left = 0
            Me.gbCourseList.Top = 0
            Me.Width = gbCourseList.Width + 50
            Me.Height = gbCourseList.Height + 50
            Me.gbCourseList.Visible = True
        Else
            'MODE IS DETAIL
            Me.gbCourseList.Hide()
            Me.gbCourseDetail.Left = 0
            Me.gbCourseDetail.Top = 0
            Me.Width = gbCourseDetail.Width + 50
            Me.Height = gbCourseDetail.Height + 50
            Me.gbCourseDetail.Visible = True
        End If
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'SWITCH TO DETAIL DATA ENTRY
        Me.setMode("D")
        Me.COURSE_IDTextBox.Focus()
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'CREATE COURSE OBJECT
        Dim aCourse As New clsCourse

        validator.checkString(Me.COURSE_IDTextBox.Text, "Course ID")
        validator.checkString(Me.DESCRIPTIONTextBox.Text, "Description")
        validator.checkInt(Me.UNITSTextBox.Text, "Units")

        If validator.getError <> "" Then
            MessageBox.Show(validator.getError, "Error saving course", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            validator.clearError()
        Else
            'POPULATE COURSE OBJECT
            aCourse.courseID = Me.COURSE_IDTextBox.Text.ToUpper()
            aCourse.description = Me.DESCRIPTIONTextBox.Text
            aCourse.units = Me.UNITSTextBox.Text

            'CHECK IF WE ARE SAVING OR UPDATING
            If (btnSave.Text = "&Save") Then
                'SAVE COURSE
                CPP_DB.dbOpen()
                CPP_DB.insertCourse(aCourse)
                CPP_DB.dbClose()

                'CHECK FOR ERRORS
                If CPP_DB.dbGetError <> "" Then
                    MessageBox.Show(CPP_DB.dbGetError)
                Else
                    courseList.Add(aCourse)                     'NO ERRORS ADD COURSE TO LIST
                    refreshDataGrid()                           'REFRESH GRID
                    MessageBox.Show("Course Saved!")            'NOTIFY
                    For Each ctrl In gbCourseDetail.Controls    'CLEAR CONTROLS
                        If TypeOf (ctrl) Is TextBox Then
                            TryCast(ctrl, TextBox).Clear()
                        End If
                    Next
                    Me.setMode("L")                             'SWITCH TO LIST MODE
                End If
            Else
                'UPDATE COURSE
                CPP_DB.dbOpen()
                CPP_DB.updateCourse(aCourseID, aCourse)
                CPP_DB.dbClose()

                'CHECK FOR ERRORS
                If CPP_DB.dbGetError <> "" Then
                    MessageBox.Show(CPP_DB.dbGetError)
                Else
                    'REMOVE OLD COURSE FROM LIST
                    For Each course In courseList
                        If course.courseID = aCourseID Then
                            courseList.Remove(course)
                            Exit For
                        End If
                    Next
                    courseList.Add(aCourse)                     'NO ERRORS ADD NEW COURSE TO LIST
                    refreshDataGrid()                           'REFRESH GRID
                    MessageBox.Show("Course Updated!")          'NOTIFY
                    For Each ctrl In gbCourseDetail.Controls    'CLEAR CONTROLS
                        If TypeOf (ctrl) Is TextBox Then
                            TryCast(ctrl, TextBox).Clear()
                        End If
                    Next
                    Me.setMode("L")                             'SWITCH TO LIST MODE
                    Me.btnSave.Text = "&Save"                   'MAKE SURE WE SET THE SAVE BUTTON BACK TO DEFAULT
                End If
            End If
        End If
    End Sub
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'GET CURRENT COURSE ROW FROM THE GRID
        Dim row As DataGridViewRow = Me.CPP_COURSESDataGridView.CurrentRow

        'CHECK IF ROW IS VALIID OTHERWISE STOP
        If IsNothing(row) Then
            MessageBox.Show("Nothing Selected!")
            Exit Sub
        End If

        'CONVERT THE ROW TO A COURSE OBJECT
        Dim aCourse As clsCourse = TryCast(row.DataBoundItem, clsCourse)

        'GET DATA FROM THE ROW TO THE TEXTBOXES
        Me.COURSE_IDTextBox.Text = aCourse.courseID
        Me.DESCRIPTIONTextBox.Text = aCourse.description
        Me.UNITSTextBox.Text = aCourse.units
        aCourseID = aCourse.courseID

        'SET THE FOCUS ON ID
        Me.COURSE_IDTextBox.Focus()

        'SWITCH SAVE TO UPDATE
        Me.btnSave.Text = "&Update"

        'DISPLAY DETAIL MODE
        Me.setMode("D")
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim row As DataGridViewRow = Me.CPP_COURSESDataGridView.CurrentRow

        'CHECK IF ROW IS VALID OTHERWISE STOP
        If IsNothing(row) Then
            MessageBox.Show("Nothing selected!")
            Exit Sub
        End If

        'CONVERT ROW TO COURSE
        Dim aCourse As clsCourse = TryCast(row.DataBoundItem, clsCourse)

        'DELETE COURSE FROM DB
        CPP_DB.dbOpen()
        CPP_DB.deleteCourse(aCourse.courseID)
        CPP_DB.dbClose()

        'CHECK FOR ERRORS
        If CPP_DB.dbGetError = "" Then
            MessageBox.Show("Course Deleted!")
            'REMOVE COURSE FROM LIST
            For Each course In courseList
                If course.courseID = aCourse.courseID Then
                    courseList.Remove(course)
                    Exit For
                End If
            Next
            'UPDATE GRID
            refreshDataGrid()
        Else
            MessageBox.Show(CPP_DB.dbGetError)
        End If
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'CLEAR ALL CONTROLS
        For Each ctrl In gbCourseDetail.Controls
            If TypeOf (ctrl) Is TextBox Then
                TryCast(ctrl, TextBox).Clear()
            End If
        Next

        'SET SAVE BUTTON TO DEFAULT 
        btnSave.Text = "&Save"

        'SWITCH TO LIST MODE
        setMode("L")
    End Sub
    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        Dim strCourseId As String = InputBox("Enter Course ID")

        If Len(strCourseId) > 0 Then
            For Each row As DataGridViewRow In CPP_COURSESDataGridView.Rows
                If row.Cells(0).Value = strCourseId.ToUpper() Then
                    row.Selected = True 'CPP_COURSESDataGridView.CurrentRow.
                    MessageBox.Show("Found!")
                    Exit Sub
                End If
            Next
        Else
            MessageBox.Show("Not found!")
        End If
    End Sub
End Class