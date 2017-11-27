Public Class frmChild
    'This class contains the controls
    'They interact with the UI and the business logic
    Private controller As clsController
    Private itemsMenu() As String
    Private itemsPrices() As String
    Private Const TAX_RATE As Decimal = 1.7825

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'Save the order
        'We are going to use a combination of ArrayLists and Arrays to pass
        'All the order information to the business logic layer
        'By using this approach we use simple data structure to communicate between our objects

        'Create an Arraylist to hold all the order Info
        Dim orderList As New ArrayList

        Try
            orderList.Add(txtCustomerID.Text)           'Add Order ID
            orderList.Add(txtCustomerName.Text)         'Add Customer Name
            orderList.Add(txtCustomerPhone.Text)        'Add Customer Name
            orderList.Add(txtCustomerOrderDate.Text)    'Add Customer Name
            orderList.Add(txtBillingStreet.Text)        'Add Billing Street
            orderList.Add(txtBillingCity.Text)          'Add Billing City
            orderList.Add(txtBillingState.Text)         'Add Billing State
            orderList.Add(txtBillingZip.Text)           'Add Billing Zip
            orderList.Add(chkShippingSame.Checked)      'Add Check Box
            orderList.Add(txtShippingStreet.Text)       'Add Shipping Street
            orderList.Add(txtShippingCity.Text)         'Add Shipping City
            orderList.Add(txtShippingState.Text)        'Add Shipping State
            orderList.Add(txtShippingZip.Text)          'Add Shipping Zip
            orderList.Add(radioDeliveryCost.Checked)    'Add Radio Button

            'Find number of lines in panel
            Dim cl As Integer = 0
            For Each ctrl As Control In Me.AddLines.pnlDetails.Controls
                If TypeOf ctrl Is ComboBox Then
                    cl = cl + 1
                End If
            Next

            'Create an ArrayList to hold all the order detail info
            Dim detailList As New ArrayList
            For i As Integer = 0 To cl - 1
                'Create an Array to hold the information for each line item
                'Line Number, Item Description, Qty, Price
                Dim arrDetailItems(4) As String
                arrDetailItems(0) = Me.AddLines.pnlDetails.Controls("lblLine" & (i + 1)).Text
                arrDetailItems(1) = Me.AddLines.pnlDetails.Controls("cboLineItem" & (i + 1)).Text
                arrDetailItems(2) = Me.AddLines.pnlDetails.Controls("txtLineQty" & (i + 1)).Text
                arrDetailItems(3) = Me.AddLines.pnlDetails.Controls("lblLinePrice" & (i + 1)).Text
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
                'Loop through each detail line and retrieve the total for that line
                'use the order ID and the line ID to identify the order and the line item
                For i As Integer = 0 To cl - 1
                    Me.AddLines.pnlDetails.Controls("lblLineTotal" & (i + 1)).Text = FormatCurrency(controller.getLineTotal(txtCustomerID.Text, i + 1))
                Next

                txtOrderSub.Text = controller.getTotal(txtCustomerID.Text)
                txtOrderTax.Text = txtOrderSub.Text * TAX_RATE
                If radioDeliveryCost.Checked = True Then
                    txtOrderDel.Text = 10
                Else
                    txtOrderDel.Text = 0
                End If
                txtOrderTotal.Text = Convert.ToDecimal(txtOrderSub.Text) + Convert.ToDecimal(txtOrderTax.Text) + Convert.ToDecimal(txtOrderDel.Text)
                txtOrderSub.Text = FormatCurrency(txtOrderSub.Text)
                txtOrderTax.Text = FormatCurrency(txtOrderTax.Text)
                txtOrderDel.Text = FormatCurrency(txtOrderDel.Text)
                txtOrderTotal.Text = FormatCurrency(txtOrderTotal.Text)
            End If

        Catch ex As Exception
            'Anything else
            MessageBox.Show(ex.Message, "Error Saving Item", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRetrieve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        'Retrieve the order
        Dim orderinfo As ArrayList
        Dim orderDetailList As ArrayList

        Try
            orderinfo = controller.Retrieve(txtCustomerID.Text)

            txtCustomerID.Text = orderinfo(0)
            txtCustomerName.Text = orderinfo(1)
            txtCustomerPhone.Text = orderinfo(2)
            txtCustomerOrderDate.Text = orderinfo(3)
            txtBillingStreet.Text = orderinfo(4)
            txtBillingCity.Text = orderinfo(5)
            txtBillingState.Text = orderinfo(6)
            txtBillingZip.Text = orderinfo(7)
            chkShippingSame.Checked = orderinfo(8)
            txtShippingStreet.Text = orderinfo(9)
            txtShippingCity.Text = orderinfo(10)
            txtShippingState.Text = orderinfo(11)
            txtShippingZip.Text = orderinfo(12)
            radioDeliveryCost.Checked = orderinfo(13)
            orderDetailList = orderinfo(14)

            Dim c As New Button
            For Each ctrl As Control In Me.AddLines.Controls
                If ctrl.Name = "btnAdd" Then
                    c = ctrl
                End If
            Next

            For i As Integer = 0 To orderDetailList.Count - 2
                c.PerformClick()
            Next

            Dim arrDetail As String()
            For i As Integer = 0 To orderDetailList.Count - 1
                arrDetail = orderDetailList.Item(i)
                Me.AddLines.pnlDetails.Controls("lblLine" & (i + 1)).Text = (i + 1)
                Me.AddLines.pnlDetails.Controls("cboLineItem" & (i + 1)).Text = arrDetail(1)
                Me.AddLines.pnlDetails.Controls("txtLineQty" & (i + 1)).Text = arrDetail(2)
                Me.AddLines.pnlDetails.Controls("lblLinePrice" & (i + 1)).Text = arrDetail(3)
            Next

            For i As Integer = 0 To orderDetailList.Count - 1
                Me.AddLines.pnlDetails.Controls("lblLineTotal" & (i + 1)).Text = FormatCurrency(controller.getLineTotal(orderinfo(0), i + 1))
            Next

            txtOrderSub.Text = controller.getTotal(orderinfo(0))
            txtOrderTax.Text = txtOrderSub.Text * TAX_RATE
            If radioDeliveryCost.Checked = True Then
                txtOrderDel.Text = 10
            Else
                txtOrderDel.Text = 0
            End If
            txtOrderTotal.Text = Convert.ToDecimal(txtOrderSub.Text) + Convert.ToDecimal(txtOrderTax.Text) + Convert.ToDecimal(txtOrderDel.Text)
            txtOrderSub.Text = FormatCurrency(txtOrderSub.Text)
            txtOrderTax.Text = FormatCurrency(txtOrderTax.Text)
            txtOrderDel.Text = FormatCurrency(txtOrderDel.Text)
            txtOrderTotal.Text = FormatCurrency(txtOrderTotal.Text)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            txtCustomerID.Text = Nothing
        End Try
    End Sub

    Private Sub frmChild_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Connect to the parent controller object
        'Child object doesn't create a new controller object
        'but instead uses the instace available in the parent form
        controller = CType(Me.ParentForm, frmMain).controller

        'Load menu into comboboxes
        itemsMenu = controller.getMenu()
        itemsPrices = controller.getPrices()

        Dim ctrl As New ComboBox

        For Each c As Control In Me.AddLines.pnlDetails.Controls
            If TypeOf c Is ComboBox Then
                ctrl.Items.AddRange(itemsMenu)
            End If
        Next
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        'Delete order using an ID
        Try
            controller.Delete(txtCustomerID.Text)
            controller.ClearForm(Me)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Deleting Item")
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Try
            controller.ClearForm(Me)
            MessageBox.Show("Order form cleared!")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Clearing Form")
        End Try
    End Sub

    Private Sub chkShippingSame_CheckedChanged(sender As Object, e As EventArgs) Handles chkShippingSame.CheckedChanged
        If chkShippingSame.Checked = True Then
            txtShippingStreet.Text = txtBillingStreet.Text
            txtShippingCity.Text = txtBillingCity.Text
            txtShippingState.Text = txtBillingState.Text
            txtShippingZip.Text = txtBillingZip.Text
            txtShippingStreet.Enabled = False
            txtShippingCity.Enabled = False
            txtShippingState.Enabled = False
            txtShippingZip.Enabled = False
        Else
            txtShippingStreet.Text = ""
            txtShippingCity.Text = ""
            txtShippingState.Text = ""
            txtShippingZip.Text = ""
            txtShippingStreet.Enabled = True
            txtShippingCity.Enabled = True
            txtShippingState.Enabled = True
            txtShippingZip.Enabled = True
        End If
    End Sub
End Class