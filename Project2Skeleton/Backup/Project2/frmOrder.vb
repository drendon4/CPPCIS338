Public Class frmChild

    'A comment for this class goes here.
    'The comment should describe the purpose of 
    'the class and anthing else that is relevant 
    'for future development.

    Private controller As clsController

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'Save the order
        'We are going to use a combination of ArrayLists and Arrays to pass
        'All the order information to the business logic layer
        'By using this approach we use simple data structure to 
        'communicate between our objects

        'Create an Arraylist to hold all the order Info
        Dim orderList As New ArrayList

        Try
            orderList.Add(txtID.Text)   'Add Order ID
            orderList.Add(txtName.Text) 'Add Customer Name

            'Create an ArrayList to hold all the order detail info
            'for the first 3 lines
            Dim detailList As New ArrayList
            For i As Integer = 0 To 2
                'Create an Array to hold the information for each line item
                'Line Number, Item Description, Qty, Price
                Dim arrDetailItems(3) As String
                arrDetailItems(0) = Me.Panel1.Controls("lblLine" & (i + 1)).Text
                arrDetailItems(1) = Me.Panel1.Controls("txtItem" & (i + 1)).Text
                arrDetailItems(2) = Me.Panel1.Controls("txtQty" & (i + 1)).Text
                arrDetailItems(3) = Me.Panel1.Controls("txtPrice" & (i + 1)).Text

                'Add the array to our Detail arraylist
                detailList.Add(arrDetailItems)
            Next

            'Add the detail arraylist to the order arraylist
            orderList.Add(detailList)

            'Save the order
            controller.Save(orderList)

            'Check for errors
            If controller.getError <> "" Then

                'Display the list of all errors
                MessageBox.Show(controller.getError, "Error saving order", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else

                'Loop through each detail line
                'and retrieve the total for that line
                'use the order ID and the line ID to identify
                'the order and the line item
                For i As Integer = 0 To 2
                    Me.Panel1.Controls("lblTotal" & (i + 1)).Text = FormatCurrency(controller.getLineTotal(txtID.Text, i + 1))
                Next

            End If

            '=== Add code below here to display totals


        Catch ex As Exception
            'Anything else
            MessageBox.Show(ex.Message, "Error Saving Item", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnRetrieve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetrieve.Click
        'Retrieve the order
        Dim orderinfo As ArrayList
        Dim orderDetailList As ArrayList
        Try
            orderinfo = controller.Retrieve(txtID.Text)
            txtID.Text = orderinfo(0)
            txtName.Text = orderinfo(1)

            orderDetailList = orderinfo(2)

            Dim arrDetail As String()
            For i As Integer = 0 To orderDetailList.Count - 1
                arrDetail = orderDetailList.Item(i)
                Me.Panel1.Controls("txtItem" & (i + 1)).Text=arrDetail(1)
                Me.Panel1.Controls("txtQty" & (i + 1)).Text = arrDetail(2)
                Me.Panel1.Controls("txtPrice" & (i + 1)).Text = arrDetail(3)
                Me.Panel1.Controls("lblTotal" & (i + 1)).Text = arrDetail(4)
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub frmChild_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Connect to the parent controller object
        'Child object doesn't create a new controller object
        'but instead uses the instace available in the parent form
        controller = CType(Me.ParentForm, frmMain).controller
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        'Delete order using an ID
        'You can also clear all the data from the form
        'TODO: clear all the controls on the form

        Try
            controller.Delete(txtID.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Deleting Item")
        End Try
    End Sub
End Class
