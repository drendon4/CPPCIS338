Public Class frmEnrollment
    Dim enrollmentList As New List(Of clsEnrollment)
    Dim studentList As New List(Of clsStudent)
    Dim catalogList As New List(Of clsCatalog)
    Dim validator As New clsValidator
    Dim aBroncoID As String
    Dim aCatalogID As String

    Private Sub frmEnrollment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'LOAD FROM DB
        CPP_DB.dbOpen()
        enrollmentList = CPP_DB.loadEnrollment()
        CPP_DB.dbClose()

        'CHECK ERRORS
        If (CPP_DB.dbGetError = "") Then
            refreshDataGrid()
        Else
            MessageBox.Show(CPP_DB.dbGetError)
        End If

        'LOAD BRONCO COMBOBOX
        studentList = CPP_DB.loadStudents()
        For i As Integer = 0 To studentList.Count() - 1
            BRONCO_IDComboBox.Items.Add(studentList(i).broncoID & " - (" & studentList(i).firstName & " " & studentList(i).lastName & ")")
        Next

        'LOAD CATALOG COMBOBOX
        catalogList = CPP_DB.loadCatalog()
        For i As Integer = 0 To catalogList.Count() - 1
            CATALOG_IDComboBox.Items.Add(catalogList(i).catalogID & " - (" & catalogList(i).year & ", " & catalogList(i).quarter & ", " & catalogList(i).courseID & ")")
        Next
    End Sub
    Private Sub refreshDataGrid()
        'CREATE A BINDING SOURCE AND 
        Dim EnrollmentBindingSource As New BindingSource

        'ASSIGN THE DATAROUCE TO THE ENROLLMENT LIST
        EnrollmentBindingSource.DataSource = enrollmentList

        'SET THE GRID DATASOURCE TO THE BINDING SOURCE
        Me.CPP_ENROLLMENTDataGridView.DataSource = EnrollmentBindingSource
    End Sub
    Public Sub setMode(strMode As String)
        'CONTROL THE DISPLAY OF LIST VS DETAIL OF ENROLLMENTS
        If strMode = "L" Then
            'MODE IS LIST
            Me.gbEnrollmentDetail.Hide()
            Me.gbEnrollmentList.Left = 0
            Me.gbEnrollmentList.Top = 0
            Me.Width = gbEnrollmentList.Width + 50
            Me.Height = gbEnrollmentList.Height + 50
            Me.gbEnrollmentList.Visible = True
        Else
            'MODE IS DETAIL
            Me.gbEnrollmentList.Hide()
            Me.gbEnrollmentDetail.Left = 0
            Me.gbEnrollmentDetail.Top = 0
            Me.Width = gbEnrollmentDetail.Width + 50
            Me.Height = gbEnrollmentDetail.Height + 50
            Me.gbEnrollmentDetail.Visible = True
        End If
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'SWITCH TO DETAIL DATA ENTRY
        Me.setMode("D")
        Me.BRONCO_IDComboBox.Focus()
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'CREATE ENROLLMENT OBJECT
        Dim aEnrollment As New clsEnrollment
        Dim aBroID As String = Me.BRONCO_IDComboBox.Text
        Dim aCatID As String = Me.CATALOG_IDComboBox.Text

        validator.checkString(Me.BRONCO_IDComboBox.Text, "Bronco ID")
        validator.checkString(Me.CATALOG_IDComboBox.Text, "Catalog ID")

        If validator.getError <> "" Then
            MessageBox.Show(validator.getError, "Error saving course", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            validator.clearError()
        Else
            'POPULATE ENROLLMENT OBJECT
            aEnrollment.broncoID = aBroID.Substring(0, aBroID.IndexOf("-") - 1)
            aEnrollment.catalogID = aCatID.Substring(0, aCatID.IndexOf("-") - 1)

            'CHECK IF WE ARE SAVING OR UPDATING
            If (btnSave.Text = "&Save") Then
                'SAVE ENROLLMEN
                CPP_DB.dbOpen()
                CPP_DB.insertEnrollment(aEnrollment)
                CPP_DB.dbClose()

                'CHECK FOR ERRORS
                If CPP_DB.dbGetError <> "" Then
                    MessageBox.Show(CPP_DB.dbGetError)
                Else
                    enrollmentList.Add(aEnrollment)                 'NO ERRORS ADD ENROLLMENT TO LIST
                    refreshDataGrid()                               'REFRESH GRID
                    MessageBox.Show("Enrollment Saved!")            'NOTIFY
                    For Each ctrl In gbEnrollmentDetail.Controls    'CLEAR CONTROLS
                        If TypeOf (ctrl) Is ComboBox Then
                            ctrl.Text = Nothing
                        End If
                    Next
                    Me.setMode("L")                                 'SWITCH TO LIST MODE
                End If
            Else
                'UPDATE ENROLLMENT
                CPP_DB.dbOpen()
                CPP_DB.updateEnrollment(aBroncoID, aCatalogID, aEnrollment)
                CPP_DB.dbClose()

                'CHECK FOR ERRORS
                If CPP_DB.dbGetError <> "" Then
                    MessageBox.Show(CPP_DB.dbGetError)
                Else
                    'REMOVE OLD ENROLLMENT FROM LIST
                    For Each enrollment In enrollmentList
                        If enrollment.broncoID = aBroncoID And enrollment.catalogID = aCatalogID Then
                            enrollmentList.Remove(enrollment)
                            Exit For
                        End If
                    Next
                    enrollmentList.Add(aEnrollment)                 'NO ERRORS ADD NEW ENROLLMENT TO LIST
                    refreshDataGrid()                               'REFRESH GRID
                    MessageBox.Show("Enrollment Updated!")          'NOTIFY
                    For Each ctrl In gbEnrollmentDetail.Controls    'CLEAR CONTROLS
                        If TypeOf (ctrl) Is ComboBox Then
                            ctrl.Text = Nothing
                        End If
                    Next
                    Me.setMode("L")                                 'SWITCH TO LIST MODE
                    Me.btnSave.Text = "&Save"                       'MAKE SURE WE SET THE SAVE BUTTON BACK TO DEFAULT
                End If
            End If
        End If
    End Sub
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'GET CURRENT ENROLLMENT ROW FROM THE GRID
        Dim row As DataGridViewRow = Me.CPP_ENROLLMENTDataGridView.CurrentRow

        'CHECK IF ROW IS VALIID OTHERWISE STOP
        If IsNothing(row) Then
            MessageBox.Show("Nothing Selected!")
            Exit Sub
        End If

        'CONVERT THE ROW TO A ENROLLMENT OBJECT
        Dim aEnrollment As clsEnrollment = TryCast(row.DataBoundItem, clsEnrollment)

        'GET DATA FROM THE ROW TO THE TEXTBOXES
        For i As Integer = 0 To studentList.Count() - 1
            If studentList(i).broncoID = aEnrollment.broncoID Then
                BRONCO_IDComboBox.Text = studentList(i).broncoID & " - (" & studentList(i).firstName & " " & studentList(i).lastName & ")"
            End If
        Next

        For i As Integer = 0 To catalogList.Count() - 1
            If catalogList(i).catalogID = aEnrollment.catalogID Then
                CATALOG_IDComboBox.Text = catalogList(i).catalogID & " - (" & catalogList(i).year & ", " & catalogList(i).quarter & ", " & catalogList(i).courseID & ")"
            End If
        Next

        aBroncoID = aEnrollment.broncoID
        aCatalogID = aEnrollment.catalogID

        'SET THE FOCUS ON ID
        Me.BRONCO_IDComboBox.Focus()

        'SWITCH SAVE TO UPDATE
        Me.btnSave.Text = "&Update"

        'DISPLAY DETAIL MODE
        Me.setMode("D")
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim row As DataGridViewRow = Me.CPP_ENROLLMENTDataGridView.CurrentRow

        'CHECK IF ROW IS VALID OTHERWISE STOP
        If IsNothing(row) Then
            MessageBox.Show("Nothing selected!")
            Exit Sub
        End If

        'CONVERT ROW TO ENROLLMENT
        Dim aEnrollment As clsEnrollment = TryCast(row.DataBoundItem, clsEnrollment)

        'DELETE ENROLLMENT FROM DB
        CPP_DB.dbOpen()
        CPP_DB.deleteEnrollment(aEnrollment.broncoID, aEnrollment.catalogID)
        CPP_DB.dbClose()

        'CHECK FOR ERRORS
        If CPP_DB.dbGetError = "" Then
            MessageBox.Show("Enrollment Deleted!")
            'REMOVE ENROLLMENT FROM LIST
            For Each enrollment In enrollmentList
                If enrollment.broncoID = aEnrollment.broncoID And enrollment.catalogID = aEnrollment.catalogID Then
                    enrollmentList.Remove(enrollment)
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
        For Each ctrl In gbEnrollmentDetail.Controls
            If TypeOf (ctrl) Is ComboBox Then
                ctrl.Text = Nothing
            End If
        Next

        'SET SAVE BUTTON TO DEFAULT 
        btnSave.Text = "&Save"

        'SWITCH TO LIST MODE
        setMode("L")
    End Sub
    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        Dim strBroncoID As String = InputBox("Enter Bronco ID")
        Dim strCatalogID As String = InputBox("Enter Catalog ID")

        If Len(strBroncoID) > 0 And Len(strCatalogID) > 0 Then
            For Each row As DataGridViewRow In CPP_ENROLLMENTDataGridView.Rows
                If row.Cells(0).Value = strBroncoID.ToUpper() And row.Cells(1).Value = strCatalogID.ToUpper() Then
                    row.Selected = True 'CPP_ENROLLMENTSDataGridView.CurrentRow.
                    MessageBox.Show("Found!")
                    Exit Sub
                End If
            Next
        Else
            MessageBox.Show("Not found!")
        End If
    End Sub
End Class