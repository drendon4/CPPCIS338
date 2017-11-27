Public Class clsController
    'Collection to hold our orders
    Private colOrders As New Hashtable
    Private anOrder As clsOrder
    Private lines As AddLines.AddLines
    Private strError As String

    Public Sub Save(ByVal OrderInfoList As ArrayList)
        'Check to see if order is already saved
        Dim dup As Integer

        'If order number is a duplicate, ask to overwrite
        If colOrders.Contains(OrderInfoList(0)) Then
            dup = MessageBox.Show("This is a duplicate Order ID." & vbCrLf & "Would you like to overwrite the order?", "Duplicate Order ID", MessageBoxButtons.YesNo)

            'If no is clicked, indicate duplicate order number. Else delete and save order
            If dup = 7 Then
                addError("ID: Duplicate Order ID (Order exists already!)")
                Exit Sub
            Else
                Delete(OrderInfoList(0))
            End If
        End If

        'Create an order object an Order
        Dim order As New clsOrder

        'Clear the Class error variable
        strError = ""
        Try
            'Store the Order
            order.ID = OrderInfoList(0)                     '0
            order.CustomerName = OrderInfoList(1)           '1
            order.CustomerPhone = OrderInfoList(2)          '2
            order.CustomerOrderDate = OrderInfoList(3)      '3
            order.BillingStreet = OrderInfoList(4)
            order.BillingCity = OrderInfoList(5)
            order.BillingState = OrderInfoList(6)
            order.BillingZip = OrderInfoList(7)
            order.CheckBox = OrderInfoList(8)
            order.ShippingStreet = OrderInfoList(9)
            order.ShippingCity = OrderInfoList(10)
            order.ShippingState = OrderInfoList(11)
            order.ShippingZip = OrderInfoList(12)
            order.RadioButton = OrderInfoList(13)

            'Store the detail
            order.AddDetail(OrderInfoList(14))               '14

            'Check for errors
            If order.getError = "" Then
                colOrders.Add(order.ID, order)
            Else
                addError(order.getError)
            End If

        Catch ex As Exception
            'Add anything we haven't handeled to our
            'Class error message
            addError(ex.Message)
        End Try
    End Sub

    Public Sub Delete(ByVal anID As String)
        'Delete an Order
        If colOrders.Contains(anID) = False Then
            Throw New ApplicationException("Item not found (ID:" & anID & ")")
        Else
            colOrders.Remove(anID)
        End If
    End Sub

    Public Function getLineTotal(ByVal anID As String, ByVal iLine As Integer) As Decimal
        'Check to see if the collection hold the order by using the order id
        If colOrders.Contains(anID) Then
            'Load the order into a myOrder object
            Dim myOrder As clsOrder = CType(colOrders.Item(anID), clsOrder)

            'execute the getLineTotal method of the Order
            Return myOrder.getLineTotal(iLine)
        Else
            addError("ID: Cannot Retrieve Detail for Order")
            Return -1
        End If
    End Function

    Public Function getTotal(ByVal anID As String) As Decimal
        'return the order total
        Dim order As New clsOrder
        order = colOrders.Item(anID)
        Return order.getTotal()
    End Function

    Public Function Retrieve(ByVal anID As String) As ArrayList
        'Retrieve an Order
        Dim order As New clsOrder
        Dim orderInfo As New ArrayList
        Try
            'get the order object
            order = colOrders.Item(anID)

            'retrieve the order header info
            orderInfo.Add(order.ID)
            orderInfo.Add(order.CustomerName)
            orderInfo.Add(order.CustomerPhone)
            orderInfo.Add(order.CustomerOrderDate)
            orderInfo.Add(order.BillingStreet)
            orderInfo.Add(order.BillingCity)
            orderInfo.Add(order.BillingState)
            orderInfo.Add(order.BillingZip)
            orderInfo.Add(order.CheckBox)
            orderInfo.Add(order.ShippingStreet)
            orderInfo.Add(order.ShippingCity)
            orderInfo.Add(order.ShippingState)
            orderInfo.Add(order.ShippingZip)
            orderInfo.Add(order.RadioButton)

            'retrieve the order detail info
            orderInfo.Add(order.GetDetail())

            'retrieves the order total
            orderInfo.Add(order.getTotal())

        Catch ex As Exception
            'If there is not matching order
            'return an error
            If IsNothing(order) Then
                Throw New ApplicationException("Item not found, ID: " & anID)
            Else
                'Any other error push back up the stack
                Throw
            End If
        End Try
        Return orderInfo
    End Function

    Public Sub ClearForm(ByVal f As Control)
        'clear customer, del option, and total information
        For Each grpctrl As Control In f.Controls
            If TypeOf grpctrl Is GroupBox Then
                For Each txtctrl As Control In grpctrl.Controls
                    If TypeOf txtctrl Is TextBox Then
                        txtctrl.Text = Nothing
                    End If
                Next
                For Each rdoctrl As Control In grpctrl.Controls
                    If TypeOf rdoctrl Is RadioButton Then
                        If rdoctrl.Name = "radioDeliveryPickup" Then
                            DirectCast(rdoctrl, RadioButton).Checked = CheckState.Checked
                        Else
                            DirectCast(rdoctrl, RadioButton).Checked = CheckState.Unchecked
                        End If
                    End If
                Next
            End If
        Next

        'clear billing info
        For Each panctrl As Control In f.Controls
            If TypeOf panctrl Is Panel Then
                For Each grpctrl As Control In panctrl.Controls
                    If TypeOf grpctrl Is GroupBox Then
                        For Each txtctrl As Control In grpctrl.Controls
                            If TypeOf txtctrl Is TextBox Then
                                txtctrl.Text = Nothing
                            End If
                        Next
                        For Each chkctrl As Control In grpctrl.Controls
                            If TypeOf chkctrl Is CheckBox Then
                                DirectCast(chkctrl, CheckBox).CheckState = CheckState.Unchecked
                            End If
                        Next
                    End If
                Next
            End If
        Next

        'Clear line items
        Dim c As New Button
        Dim cl As Integer = 0

        For Each grpctrl As Control In f.Controls
            If grpctrl.Name = "grpOrder" Then
                For Each panctrl As Control In grpctrl.Controls
                    If panctrl.Name = "AddLines" Then
                        For Each ctrl As Control In panctrl.Controls
                            If ctrl.Name = "btnRemove" Then
                                c = ctrl
                            End If
                            If ctrl.Name = "pnlDetails" Then
                                For Each cboctrl As Control In ctrl.Controls
                                    If TypeOf cboctrl Is ComboBox Then
                                        cl = cl + 1
                                    End If
                                Next
                                For i As Integer = 0 To cl - 1
                                    ctrl.Controls("lblLine" & (i + 1)).Text = (i + 1)
                                    ctrl.Controls("cboLineItem" & (i + 1)).Text = Nothing
                                    ctrl.Controls("txtLineQty" & (i + 1)).Text = 0
                                    ctrl.Controls("lblLinePrice" & (i + 1)).Text = 0
                                    ctrl.Controls("lblLineTotal" & (i + 1)).Text = 0
                                Next
                            End If
                        Next
                    End If
                Next
            End If
        Next

        For i As Integer = 0 To cl - 2
            c.PerformClick()
        Next

    End Sub

    Public Function getMenu() As String()
        'return the menu
        Dim menu() As String = {"Ghost", "Hornet", "Chopper", "Banshee"}

        Return menu
    End Function

    Public Function getPrices() As String()
        'return the prices
        Dim prices() As String = {"1000", "2000", "3000", "4000"}

        Return prices
    End Function

    Private Sub addError(ByVal s As String)
        'Add an error to the error list
        If strError = "" Then
            strError = s
        Else
            strError += vbCrLf & s
        End If
    End Sub

    Public Function getError() As String
        'return all errors for this object
        Return strError
    End Function
End Class