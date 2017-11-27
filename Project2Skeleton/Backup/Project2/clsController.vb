Public Class clsController

    'A comment for this class goes here.
    'The comment should describe the purpose of 
    'the class and anthing else that is relevant 
    'for future development.
    'Please comment all your Subs / Functions / Variable Declaration
    'appropriately

    'Collection to hold our orders
    Private colOrders As New Hashtable
    Private anOrder As clsOrder
    Private strError As String

    Public Sub Save(ByVal OrderInfoList As ArrayList)
        'Check to see if order is already saved
        'If that's the case exit
        If colOrders.Contains(OrderInfoList(0)) Then
            addError("ID: Duplicate Order ID (Order exists already!)")
            Exit Sub
        End If

        'Create an order object an Order
        Dim order As New clsOrder

        'Clear the Class error variable
        strError = ""

        Try
            'Store the Order
            order.ID = OrderInfoList(0)                     '0
            order.CustomerName = OrderInfoList(1)           '1


            'Store the detail
            order.AddDetail(OrderInfoList(2))

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

            'retrieve the order detail info
            orderInfo.Add(order.GetDetail())

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
