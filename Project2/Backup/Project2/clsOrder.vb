Public Class clsOrder
    'A comment for this class goes here.
    'The comment should describe the purpose of 
    'the class and anthing else that is relevant 
    'for future development.

    Private sID As String                       'Hold Order ID
    Private sCustomerName As String             'Hold Customer Name
    Private detailsList As ArrayList            'Hold the detail line items as an Arraylist
    Private sError As String

    Public Sub New()
        'Set our initial values
        sID = ""
        sCustomerName = ""
        sError = ""
        detailsList = New ArrayList
    End Sub

    '===================================================
    ' Object properties setters / getters
    '===================================================

    Public Property ID()
        'get and set the order id
        Get
            Return sID
        End Get
        Set(ByVal value)

            'Validation at class level
            If isValidID(value) = True Then
                sID = Convert.ToInt32(value)
            End If
        End Set
    End Property

    Public Property CustomerName()
        'Get and set the customer name
        Get
            Return sCustomerName
        End Get
        Set(ByVal value)
            'Validate, you can also add a try/catch
            If isValidName(value) Then
                sCustomerName = value
            End If
        End Set
    End Property

    '===================================================
    ' Helper routines
    '===================================================

    Public Sub AddDetail(ByVal aDetailsList As ArrayList)

        'Loop through all our arraylist of details
        For i As Integer = 0 To aDetailsList.Count - 1
            'get a single order detail line out of 
            'the ArrayList of orders details
            Dim arrItem As String() = aDetailsList(i)

            'create a new order detail object
            Dim myOrderDetail As New clsOrderDetail

            'Add detail info to our object
            ' 0 - detail line
            ' 1 - Item Description
            ' 2 - Item Quantity
            ' 3 - Item Price

            myOrderDetail.line = arrItem(0)
            myOrderDetail.Item = arrItem(1)
            myOrderDetail.Qty = arrItem(2)
            myOrderDetail.Price = arrItem(3)

            If myOrderDetail.getError = "" Then
                myOrderDetail.total()
            End If

            'Add the order to our collection
            'Check for errors in the detail
            'if no errors then add
            If myOrderDetail.getError = "" Then
                detailsList.Add(myOrderDetail)
            Else
                addError(myOrderDetail.getError)
            End If
        Next

        If detailsList.Count = 0 Then
            addError("Detail:Order must contain at least one valid detail line")
        End If
    End Sub

    Public Function getLineTotal(ByVal iLine As Integer) As Decimal

        'return the line total
        'Loop through all the order lines
        For i As Integer = 0 To detailsList.Count - 1

            Dim myOrderDetail As clsOrderDetail = CType(detailsList(i), clsOrderDetail)
            If myOrderDetail.line = iLine Then
                Return myOrderDetail.total
            End If
        Next
    End Function

    Private Sub addError(ByVal s As String)
        'private function to format our error message by
        'adding line breaks when necessary
        If sError = "" Then
            sError = s
        Else
            sError += vbCrLf & s
        End If
    End Sub

    '===================================================
    ' Public functions to access the detail lines
    ' and the error
    '===================================================

    Public Function GetDetail() As ArrayList
        'Retrieve a detail item from the order
        Dim detailItemsList As New ArrayList
        For i As Integer = 0 To detailsList.Count - 1
            Dim orderDetail As New clsOrderDetail
            orderDetail = detailsList.Item(i)

            Dim arrDetail(4) As String

            arrDetail(0) = orderDetail.line
            arrDetail(1) = orderDetail.Item
            arrDetail(2) = orderDetail.Qty
            arrDetail(3) = orderDetail.Price
            arrDetail(4) = orderDetail.total

            detailItemsList.Add(arrDetail)
        Next
        Return detailItemsList
    End Function

    Public Function getError()
        'public Function to return the error 
        'To other objects
        Return sError
    End Function



    '===================================================
    ' Validation routines
    '===================================================

    Private Function isValidID(ByVal s As String) As Boolean
        Dim bResult As Boolean
        Try
            If s <> "" Then
                bResult = True
            Else
                addError("ID: Cannot be left blank")
                bResult = False
            End If
        Catch ex As Exception
            addError("ID: Invalid ID (" & ex.Message & ")")
            bResult = False
        End Try

        Return bResult
    End Function

    Private Function isValidName(ByVal s As String) As Boolean
        Dim bResult As Boolean
        Try
            If s <> "" Then
                bResult = True
            Else
                addError("Name: Invalid Customer Name")
                bResult = False
            End If
        Catch ex As Exception
            addError("Name: Invalid Customer Name (" & ex.Message & ")")
            bResult = False
        End Try

        Return bResult
    End Function

End Class
