Public Class frmCatalog
    Dim catalogList As New List(Of clsCatalog)
    Dim courseList As New List(Of clsCourse)
    Dim instructorList As New List(Of clsInstructor)
    Dim validator As New clsValidator
    Dim aCatalogID As String
    Private Sub frmCatalog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'LOAD FROM DB
        CPP_DB.dbOpen()
        catalogList = CPP_DB.loadCatalog()
        CPP_DB.dbClose()

        'CHECK ERRORS
        If (CPP_DB.dbGetError = "") Then
            refreshDataGrid()
        Else
            MessageBox.Show(CPP_DB.dbGetError)
        End If

        'LOAD COURSE COMBOBOX
        courseList = CPP_DB.loadCourse()
        For i As Integer = 0 To courseList.Count() - 1
            COURSE_IDComboBox.Items.Add(courseList(i).courseID & " - (" & courseList(i).description & ")")
        Next

        'LOAD INSTRUCTOR COMBOBOX
        instructorList = CPP_DB.loadInstructor()
        For i As Integer = 0 To instructorList.Count() - 1
            PROF_IDComboBox.Items.Add(instructorList(i).profID & " - (" & instructorList(i).firstName & " " & instructorList(i).lastName & ")")
        Next
    End Sub
    Private Sub refreshDataGrid()
        'CREATE A BINDING SOURCE AND 
        Dim CatalogBindingSource As New BindingSource

        'ASSIGN THE DATAROUCE TO THE CATALOG LIST
        CatalogBindingSource.DataSource = catalogList

        'SET THE GRID DATASOURCE TO THE BINDING SOURCE
        Me.CPP_CATALOGDataGridView.DataSource = CatalogBindingSource
    End Sub
    Public Sub setMode(strMode As String)
        'CONTROL THE DISPLAY OF LIST VS DETAIL OF CATALOG
        If strMode = "L" Then
            'MODE IS LIST
            Me.gbCatalogDetail.Hide()
            Me.gbCatalogList.Left = 0
            Me.gbCatalogList.Top = 0
            Me.Width = gbCatalogList.Width + 50
            Me.Height = gbCatalogList.Height + 50
            Me.gbCatalogList.Visible = True
        Else
            'MODE IS DETAIL
            Me.gbCatalogList.Hide()
            Me.gbCatalogDetail.Left = 0
            Me.gbCatalogDetail.Top = 0
            Me.Width = gbCatalogDetail.Width + 50
            Me.Height = gbCatalogDetail.Height + 50
            Me.gbCatalogDetail.Visible = True
        End If
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'SWITCH TO DETAIL DATA ENTRY
        Me.setMode("D")
        Me.CATALOG_IDTextBox.Focus()
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'CREATE CATALOG OBJECT
        Dim aCatalog As New clsCatalog
        Dim aCourseID As String = Me.COURSE_IDComboBox.Text
        Dim aProfID As String = Me.PROF_IDComboBox.Text

        validator.checkString(Me.CATALOG_IDTextBox.Text, "Catalog ID")
        validator.checkInt(Me.YEARTextBox.Text, "Year")
        validator.checkString(Me.QUARTERComboBox.Text, "Quarter")
        validator.checkString(Me.COURSE_IDComboBox.Text, "Course")
        validator.checkString(Me.PROF_IDComboBox.Text, "Prof")

        If validator.getError <> "" Then
            MessageBox.Show(validator.getError, "Error saving course", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            validator.clearError()
        Else
            'POPULATE CATALOG OBJECT
            aCatalog.catalogID = Me.CATALOG_IDTextBox.Text
            aCatalog.year = Me.YEARTextBox.Text
            aCatalog.quarter = Me.QUARTERComboBox.Text
            aCatalog.courseID = aCourseID.Substring(0, aCourseID.IndexOf("-") - 1)
            aCatalog.profID = aProfID.Substring(0, aProfID.IndexOf("-") - 1)

            'CHECK IF WE ARE SAVING OR UPDATING
            If (btnSave.Text = "&Save") Then
                'SAVE CATALOG
                CPP_DB.dbOpen()
                CPP_DB.insertCatalog(aCatalog)
                CPP_DB.dbClose()

                'CHECK FOR ERRORS
                If CPP_DB.dbGetError <> "" Then
                    MessageBox.Show(CPP_DB.dbGetError)
                Else
                    catalogList.Add(aCatalog)                       'NO ERRORS ADD CATALOG TO LIST
                    refreshDataGrid()                               'REFRESH GRID
                    MessageBox.Show("Catalog Saved!")               'NOTIFY
                    For Each ctrl In gbCatalogDetail.Controls       'CLEAR CONTROLS
                        If TypeOf (ctrl) Is TextBox Then
                            TryCast(ctrl, TextBox).Clear()
                        End If
                        If TypeOf (ctrl) Is ComboBox Then
                            ctrl.Text = Nothing
                        End If
                    Next
                    Me.setMode("L")                                 'SWITCH TO LIST MODE
                End If
            Else
                'UPDATE CATALOG
                CPP_DB.dbOpen()
                CPP_DB.updateCatalog(aCatalogID, aCatalog)
                CPP_DB.dbClose()

                'CHECK FOR ERRORS
                If CPP_DB.dbGetError <> "" Then
                    MessageBox.Show(CPP_DB.dbGetError)
                Else
                    'REMOVE OLD CATALOG FROM LIST
                    For Each catalog In catalogList
                        If catalog.catalogID = aCatalogID Then
                            catalogList.Remove(catalog)
                            Exit For
                        End If
                    Next
                    catalogList.Add(aCatalog)                       'NO ERRORS ADD NEW CATALOG TO LIST
                    refreshDataGrid()                               'REFRESH GRID
                    MessageBox.Show("Catalog Updated!")             'NOTIFY
                    For Each ctrl In gbCatalogDetail.Controls       'CLEAR CONTROLS
                        If TypeOf (ctrl) Is TextBox Then
                            TryCast(ctrl, TextBox).Clear()
                        End If
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
        'GET CURRENT CATALOG ROW FROM THE GRID
        Dim row As DataGridViewRow = Me.CPP_CATALOGDataGridView.CurrentRow

        'CHECK IF ROW IS VALIID OTHERWISE STOP
        If IsNothing(row) Then
            MessageBox.Show("Nothing Selected!")
            Exit Sub
        End If

        'CONVERT THE ROW TO A CATALOG OBJECT
        Dim aCatalog As clsCatalog = TryCast(row.DataBoundItem, clsCatalog)

        'GET DATA FROM THE ROW TO THE TEXTBOXES
        Me.CATALOG_IDTextBox.Text = aCatalog.catalogID
        Me.YEARTextBox.Text = aCatalog.year
        Me.QUARTERComboBox.Text = aCatalog.quarter

        For i As Integer = 0 To courseList.Count() - 1
            If courseList(i).courseID = aCatalog.courseID Then
                COURSE_IDComboBox.Text = courseList(i).courseID & " - (" & courseList(i).description & ")"
            End If
        Next

        For i As Integer = 0 To instructorList.Count() - 1
            If instructorList(i).profID = aCatalog.profID Then
                PROF_IDComboBox.Text = instructorList(i).profID & " - (" & instructorList(i).firstName & " " & instructorList(i).lastName & ")"
            End If
        Next

        aCatalogID = aCatalog.catalogID
        'SET THE FOCUS ON ID
        Me.CATALOG_IDTextBox.Focus()

        'SWITCH SAVE TO UPDATE
        Me.btnSave.Text = "&Update"

        'DISPLAY DETAIL MODE
        Me.setMode("D")
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim row As DataGridViewRow = Me.CPP_CATALOGDataGridView.CurrentRow

        'CHECK IF ROW IS VALID OTHERWISE STOP
        If IsNothing(row) Then
            MessageBox.Show("Nothing selected!")
            Exit Sub
        End If

        'CONVERT ROW TO CATALOG
        Dim aCatalog As clsCatalog = TryCast(row.DataBoundItem, clsCatalog)

        'DELETE CATALOG FROM DB
        CPP_DB.dbOpen()
        CPP_DB.deleteCatalog(aCatalog.catalogID)
        CPP_DB.dbClose()

        'CHECK FOR ERRORS
        If CPP_DB.dbGetError = "" Then
            MessageBox.Show("Catalog Deleted!")
            'REMOVE CATALOG FROM LIST
            For Each catalog In catalogList
                If catalog.catalogID = aCatalog.catalogID Then
                    catalogList.Remove(catalog)
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
        For Each ctrl In gbCatalogDetail.Controls
            If TypeOf (ctrl) Is TextBox Then
                TryCast(ctrl, TextBox).Clear()
            End If
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
        Dim strCatalogId As String = InputBox("Enter Catalog ID")

        If Len(strCatalogId) > 0 Then
            For Each row As DataGridViewRow In CPP_CATALOGDataGridView.Rows
                If row.Cells(0).Value = strCatalogId.ToUpper() Then
                    row.Selected = True 'CPP_CATALOGDataGridView.CurrentRow.
                    MessageBox.Show("Found!")
                    Exit Sub
                End If
            Next
        Else
            MessageBox.Show("Not found!")
        End If
    End Sub
End Class