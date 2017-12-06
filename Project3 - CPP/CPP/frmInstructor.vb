Public Class frmInstructor
    Dim instructorList As New List(Of clsInstructor)
    Dim validator As New clsValidator
    Dim aInstructorID As String
    Private Sub frmInstructor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'LOAD FROM DB
        CPP_DB.dbOpen()
        instructorList = CPP_DB.loadInstructor()
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
        Dim InstructorBindingSource As New BindingSource

        'ASSIGN THE DATAROUCE TO THE INSTRUCTOR LIST
        InstructorBindingSource.DataSource = instructorList

        'SET THE GRID DATASOURCE TO THE BINDING SOURCE
        Me.CPP_INSTRUCTORSDataGridView.DataSource = InstructorBindingSource
    End Sub
    Public Sub setMode(strMode As String)
        'CONTROL THE DISPLAY OF LIST VS DETAIL OF INSTRUCTOR
        If strMode = "L" Then
            'MODE IS LIST
            Me.gbInstructorDetail.Hide()
            Me.gbInstructorList.Left = 0
            Me.gbInstructorList.Top = 0
            Me.Width = gbInstructorList.Width + 50
            Me.Height = gbInstructorList.Height + 50
            Me.gbInstructorList.Visible = True
        Else
            'MODE IS DETAIL
            Me.gbInstructorList.Hide()
            Me.gbInstructorDetail.Left = 0
            Me.gbInstructorDetail.Top = 0
            Me.Width = gbInstructorDetail.Width + 50
            Me.Height = gbInstructorDetail.Height + 50
            Me.gbInstructorDetail.Visible = True
        End If
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'SWITCH TO DETAIL DATA ENTRY
        Me.setMode("D")
        Me.PROF_IDTextBox.Focus()
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'CREATE INSTRUCTOR OBJECT
        Dim aInstructor As New clsInstructor

        validator.checkString(Me.PROF_IDTextBox.Text, "Prof ID")
        validator.checkString(Me.FIRST_NAMETextBox.Text, "First Name")
        validator.checkString(Me.LAST_NAMETextBox.Text, "Last Name")
        validator.checkPhone(Me.PHONETextBox.Text, "Phone")
        validator.checkString(Me.DEPARTMENTTextBox.Text, "Department")

        If validator.getError <> "" Then
            MessageBox.Show(validator.getError, "Error saving course", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            validator.clearError()
        Else
            'POPULATE INSTRUCTOR OBJECT
            aInstructor.profID = Me.PROF_IDTextBox.Text.ToUpper()
            aInstructor.firstName = Me.FIRST_NAMETextBox.Text
            aInstructor.lastName = Me.LAST_NAMETextBox.Text
            aInstructor.department = Me.DEPARTMENTTextBox.Text
            aInstructor.phone = Me.PHONETextBox.Text

            'CHECK IF WE ARE SAVING OR UPDATING
            If (btnSave.Text = "&Save") Then
                'SAVE INSTRUCTOR
                CPP_DB.dbOpen()
                CPP_DB.insertInstructor(aInstructor)
                CPP_DB.dbClose()

                'CHECK FOR ERRORS
                If CPP_DB.dbGetError <> "" Then
                    MessageBox.Show(CPP_DB.dbGetError)
                Else
                    instructorList.Add(aInstructor)                 'NO ERRORS ADD INSTRUCTOR TO LIST
                    refreshDataGrid()                               'REFRESH GRID
                    MessageBox.Show("Instructor Saved!")            'NOTIFY
                    For Each ctrl In gbInstructorDetail.Controls    'CLEAR CONTROLS
                        If TypeOf (ctrl) Is TextBox Then
                            TryCast(ctrl, TextBox).Clear()
                        End If
                    Next
                    Me.setMode("L")                                 'SWITCH TO LIST MODE
                End If
            Else
                'UPDATE INSTRUCTOR
                CPP_DB.dbOpen()
                CPP_DB.updateInstructor(aInstructorID, aInstructor)
                CPP_DB.dbClose()

                'CHECK FOR ERRORS
                If CPP_DB.dbGetError <> "" Then
                    MessageBox.Show(CPP_DB.dbGetError)
                Else
                    'REMOVE OLD INSTRUCTOR FROM LIST
                    For Each instructor In instructorList
                        If instructor.profID = aInstructorID Then
                            instructorList.Remove(instructor)
                            Exit For
                        End If
                    Next
                    instructorList.Add(aInstructor)                 'NO ERRORS ADD NEW INSTRUCTOR TO LIST
                    refreshDataGrid()                               'REFRESH GRID
                    MessageBox.Show("Instructor Updated!")          'NOTIFY
                    For Each ctrl In gbInstructorDetail.Controls    'CLEAR CONTROLS
                        If TypeOf (ctrl) Is TextBox Then
                            TryCast(ctrl, TextBox).Clear()
                        End If
                    Next
                    Me.setMode("L")                                 'SWITCH TO LIST MODE
                    Me.btnSave.Text = "&Save"                       'MAKE SURE WE SET THE SAVE BUTTON BACK TO DEFAULT
                End If
            End If
        End If
    End Sub
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'GET CURRENT INSTRUCTOR ROW FROM THE GRID
        Dim row As DataGridViewRow = Me.CPP_INSTRUCTORSDataGridView.CurrentRow

        'CHECK IF ROW IS VALIID OTHERWISE STOP
        If IsNothing(row) Then
            MessageBox.Show("Nothing Selected!")
            Exit Sub
        End If

        'CONVERT THE ROW TO A INSTRUCTOR OBJECT
        Dim aInstructor As clsInstructor = TryCast(row.DataBoundItem, clsInstructor)

        'GET DATA FROM THE ROW TO THE TEXTBOXES
        Me.PROF_IDTextBox.Text = aInstructor.profID
        Me.FIRST_NAMETextBox.Text = aInstructor.firstName
        Me.LAST_NAMETextBox.Text = aInstructor.lastName
        Me.PHONETextBox.Text = aInstructor.phone
        Me.DEPARTMENTTextBox.Text = aInstructor.department
        aInstructorID = aInstructor.profID
        'SET THE FOCUS ON ID
        Me.PROF_IDTextBox.Focus()

        'SWITCH SAVE TO UPDATE
        Me.btnSave.Text = "&Update"

        'DISPLAY DETAIL MODE
        Me.setMode("D")
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim row As DataGridViewRow = Me.CPP_INSTRUCTORSDataGridView.CurrentRow

        'CHECK IF ROW IS VALID OTHERWISE STOP
        If IsNothing(row) Then
            MessageBox.Show("Nothing selected!")
            Exit Sub
        End If

        'CONVERT ROW TO INSTRUCTOR
        Dim aInstructor As clsInstructor = TryCast(row.DataBoundItem, clsInstructor)

        'DELETE INSTRUCTOR FROM DB
        CPP_DB.dbOpen()
        CPP_DB.deleteInstructor(aInstructor.profID)
        CPP_DB.dbClose()

        'CHECK FOR ERRORS
        If CPP_DB.dbGetError = "" Then
            MessageBox.Show("Instructor Deleted!")
            'REMOVE INSTRUCTOR FROM LIST
            For Each instructor In instructorList
                If instructor.profID = aInstructor.profID Then
                    instructorList.Remove(instructor)
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
        For Each ctrl In gbInstructorDetail.Controls
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
        Dim strInstructorId As String = InputBox("Enter Professor ID")

        If Len(strInstructorId) > 0 Then
            For Each row As DataGridViewRow In CPP_INSTRUCTORSDataGridView.Rows
                If row.Cells(0).Value = strInstructorId.ToUpper() Then
                    row.Selected = True 'CPP_INSTRUCTORSDataGridView.CurrentRow.
                    MessageBox.Show("Found!")
                    Exit Sub
                End If
            Next
        Else
            MessageBox.Show("Not found!")
        End If
    End Sub
End Class