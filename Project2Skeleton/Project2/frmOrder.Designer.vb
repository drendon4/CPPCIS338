<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmChild
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnOpen = New System.Windows.Forms.Button()
        Me.txtCustomerID = New System.Windows.Forms.TextBox()
        Me.txtCustomerName = New System.Windows.Forms.TextBox()
        Me.lblCustomerID = New System.Windows.Forms.Label()
        Me.lblCustomerName = New System.Windows.Forms.Label()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.grpCustomer = New System.Windows.Forms.GroupBox()
        Me.txtCustomerOrderDate = New System.Windows.Forms.TextBox()
        Me.lblCustomerDate = New System.Windows.Forms.Label()
        Me.txtCustomerPhone = New System.Windows.Forms.TextBox()
        Me.lblCustomerPhone = New System.Windows.Forms.Label()
        Me.grpBillingInfo = New System.Windows.Forms.GroupBox()
        Me.txtBillingZip = New System.Windows.Forms.TextBox()
        Me.txtBillingState = New System.Windows.Forms.TextBox()
        Me.txtBillingCity = New System.Windows.Forms.TextBox()
        Me.txtBillingStreet = New System.Windows.Forms.TextBox()
        Me.lblBillingZip = New System.Windows.Forms.Label()
        Me.lblBillingState = New System.Windows.Forms.Label()
        Me.lblBillingCity = New System.Windows.Forms.Label()
        Me.lblBillingStreet = New System.Windows.Forms.Label()
        Me.panInfo = New System.Windows.Forms.Panel()
        Me.grpShipping = New System.Windows.Forms.GroupBox()
        Me.chkShippingSame = New System.Windows.Forms.CheckBox()
        Me.txtShippingZip = New System.Windows.Forms.TextBox()
        Me.txtShippingState = New System.Windows.Forms.TextBox()
        Me.txtShippingCity = New System.Windows.Forms.TextBox()
        Me.txtShippingStreet = New System.Windows.Forms.TextBox()
        Me.lblShippingZip = New System.Windows.Forms.Label()
        Me.lblShippingState = New System.Windows.Forms.Label()
        Me.lblShippingCity = New System.Windows.Forms.Label()
        Me.lblShippingStreet = New System.Windows.Forms.Label()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.grpDelivery = New System.Windows.Forms.GroupBox()
        Me.radioDeliveryCost = New System.Windows.Forms.RadioButton()
        Me.radioDeliveryPickup = New System.Windows.Forms.RadioButton()
        Me.grpTotal = New System.Windows.Forms.GroupBox()
        Me.txtOrderTotal = New System.Windows.Forms.TextBox()
        Me.lblOrderTotal = New System.Windows.Forms.Label()
        Me.txtOrderDel = New System.Windows.Forms.TextBox()
        Me.lblOrderDelivery = New System.Windows.Forms.Label()
        Me.txtOrderTax = New System.Windows.Forms.TextBox()
        Me.lblOrderTax = New System.Windows.Forms.Label()
        Me.txtOrderSub = New System.Windows.Forms.TextBox()
        Me.lblOrderSub = New System.Windows.Forms.Label()
        Me.grpOrder = New System.Windows.Forms.GroupBox()
        Me.AddLines = New AddLines.AddLines()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCustomer.SuspendLayout()
        Me.grpBillingInfo.SuspendLayout()
        Me.panInfo.SuspendLayout()
        Me.grpShipping.SuspendLayout()
        Me.grpDelivery.SuspendLayout()
        Me.grpTotal.SuspendLayout()
        Me.grpOrder.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(461, 531)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 8
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnOpen
        '
        Me.btnOpen.Location = New System.Drawing.Point(218, 531)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(75, 23)
        Me.btnOpen.TabIndex = 5
        Me.btnOpen.Text = "&Open"
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'txtCustomerID
        '
        Me.txtCustomerID.Location = New System.Drawing.Point(30, 13)
        Me.txtCustomerID.Name = "txtCustomerID"
        Me.txtCustomerID.Size = New System.Drawing.Size(62, 20)
        Me.txtCustomerID.TabIndex = 1
        '
        'txtCustomerName
        '
        Me.txtCustomerName.Location = New System.Drawing.Point(136, 13)
        Me.txtCustomerName.Name = "txtCustomerName"
        Me.txtCustomerName.Size = New System.Drawing.Size(123, 20)
        Me.txtCustomerName.TabIndex = 3
        '
        'lblCustomerID
        '
        Me.lblCustomerID.AutoSize = True
        Me.lblCustomerID.Location = New System.Drawing.Point(6, 16)
        Me.lblCustomerID.Name = "lblCustomerID"
        Me.lblCustomerID.Size = New System.Drawing.Size(18, 13)
        Me.lblCustomerID.TabIndex = 0
        Me.lblCustomerID.Text = "ID"
        '
        'lblCustomerName
        '
        Me.lblCustomerName.AutoSize = True
        Me.lblCustomerName.Location = New System.Drawing.Point(98, 16)
        Me.lblCustomerName.Name = "lblCustomerName"
        Me.lblCustomerName.Size = New System.Drawing.Size(35, 13)
        Me.lblCustomerName.TabIndex = 2
        Me.lblCustomerName.Text = "Name"
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(299, 531)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 6
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'grpCustomer
        '
        Me.grpCustomer.Controls.Add(Me.txtCustomerOrderDate)
        Me.grpCustomer.Controls.Add(Me.lblCustomerDate)
        Me.grpCustomer.Controls.Add(Me.txtCustomerPhone)
        Me.grpCustomer.Controls.Add(Me.lblCustomerPhone)
        Me.grpCustomer.Controls.Add(Me.txtCustomerID)
        Me.grpCustomer.Controls.Add(Me.txtCustomerName)
        Me.grpCustomer.Controls.Add(Me.lblCustomerID)
        Me.grpCustomer.Controls.Add(Me.lblCustomerName)
        Me.grpCustomer.Location = New System.Drawing.Point(12, 12)
        Me.grpCustomer.Name = "grpCustomer"
        Me.grpCustomer.Size = New System.Drawing.Size(523, 44)
        Me.grpCustomer.TabIndex = 0
        Me.grpCustomer.TabStop = False
        '
        'txtCustomerOrderDate
        '
        Me.txtCustomerOrderDate.Location = New System.Drawing.Point(432, 13)
        Me.txtCustomerOrderDate.Name = "txtCustomerOrderDate"
        Me.txtCustomerOrderDate.Size = New System.Drawing.Size(77, 20)
        Me.txtCustomerOrderDate.TabIndex = 7
        '
        'lblCustomerDate
        '
        Me.lblCustomerDate.AutoSize = True
        Me.lblCustomerDate.Location = New System.Drawing.Point(396, 16)
        Me.lblCustomerDate.Name = "lblCustomerDate"
        Me.lblCustomerDate.Size = New System.Drawing.Size(30, 13)
        Me.lblCustomerDate.TabIndex = 6
        Me.lblCustomerDate.Text = "Date"
        '
        'txtCustomerPhone
        '
        Me.txtCustomerPhone.Location = New System.Drawing.Point(306, 13)
        Me.txtCustomerPhone.Name = "txtCustomerPhone"
        Me.txtCustomerPhone.Size = New System.Drawing.Size(84, 20)
        Me.txtCustomerPhone.TabIndex = 5
        '
        'lblCustomerPhone
        '
        Me.lblCustomerPhone.AutoSize = True
        Me.lblCustomerPhone.Location = New System.Drawing.Point(265, 16)
        Me.lblCustomerPhone.Name = "lblCustomerPhone"
        Me.lblCustomerPhone.Size = New System.Drawing.Size(38, 13)
        Me.lblCustomerPhone.TabIndex = 4
        Me.lblCustomerPhone.Text = "Phone"
        '
        'grpBillingInfo
        '
        Me.grpBillingInfo.Controls.Add(Me.txtBillingZip)
        Me.grpBillingInfo.Controls.Add(Me.txtBillingState)
        Me.grpBillingInfo.Controls.Add(Me.txtBillingCity)
        Me.grpBillingInfo.Controls.Add(Me.txtBillingStreet)
        Me.grpBillingInfo.Controls.Add(Me.lblBillingZip)
        Me.grpBillingInfo.Controls.Add(Me.lblBillingState)
        Me.grpBillingInfo.Controls.Add(Me.lblBillingCity)
        Me.grpBillingInfo.Controls.Add(Me.lblBillingStreet)
        Me.grpBillingInfo.Location = New System.Drawing.Point(8, 3)
        Me.grpBillingInfo.Name = "grpBillingInfo"
        Me.grpBillingInfo.Size = New System.Drawing.Size(238, 104)
        Me.grpBillingInfo.TabIndex = 0
        Me.grpBillingInfo.TabStop = False
        Me.grpBillingInfo.Text = "Billing Info"
        '
        'txtBillingZip
        '
        Me.txtBillingZip.Location = New System.Drawing.Point(173, 72)
        Me.txtBillingZip.Name = "txtBillingZip"
        Me.txtBillingZip.Size = New System.Drawing.Size(59, 20)
        Me.txtBillingZip.TabIndex = 7
        '
        'txtBillingState
        '
        Me.txtBillingState.Location = New System.Drawing.Point(104, 72)
        Me.txtBillingState.Name = "txtBillingState"
        Me.txtBillingState.Size = New System.Drawing.Size(63, 20)
        Me.txtBillingState.TabIndex = 6
        '
        'txtBillingCity
        '
        Me.txtBillingCity.Location = New System.Drawing.Point(6, 72)
        Me.txtBillingCity.Name = "txtBillingCity"
        Me.txtBillingCity.Size = New System.Drawing.Size(92, 20)
        Me.txtBillingCity.TabIndex = 5
        '
        'txtBillingStreet
        '
        Me.txtBillingStreet.Location = New System.Drawing.Point(7, 33)
        Me.txtBillingStreet.Name = "txtBillingStreet"
        Me.txtBillingStreet.Size = New System.Drawing.Size(225, 20)
        Me.txtBillingStreet.TabIndex = 1
        '
        'lblBillingZip
        '
        Me.lblBillingZip.AutoSize = True
        Me.lblBillingZip.Location = New System.Drawing.Point(175, 56)
        Me.lblBillingZip.Name = "lblBillingZip"
        Me.lblBillingZip.Size = New System.Drawing.Size(25, 13)
        Me.lblBillingZip.TabIndex = 4
        Me.lblBillingZip.Text = "Zip:"
        '
        'lblBillingState
        '
        Me.lblBillingState.AutoSize = True
        Me.lblBillingState.Location = New System.Drawing.Point(101, 56)
        Me.lblBillingState.Name = "lblBillingState"
        Me.lblBillingState.Size = New System.Drawing.Size(35, 13)
        Me.lblBillingState.TabIndex = 3
        Me.lblBillingState.Text = "State:"
        '
        'lblBillingCity
        '
        Me.lblBillingCity.AutoSize = True
        Me.lblBillingCity.Location = New System.Drawing.Point(6, 56)
        Me.lblBillingCity.Name = "lblBillingCity"
        Me.lblBillingCity.Size = New System.Drawing.Size(27, 13)
        Me.lblBillingCity.TabIndex = 2
        Me.lblBillingCity.Text = "City:"
        '
        'lblBillingStreet
        '
        Me.lblBillingStreet.AutoSize = True
        Me.lblBillingStreet.Location = New System.Drawing.Point(6, 16)
        Me.lblBillingStreet.Name = "lblBillingStreet"
        Me.lblBillingStreet.Size = New System.Drawing.Size(38, 13)
        Me.lblBillingStreet.TabIndex = 0
        Me.lblBillingStreet.Text = "Street:"
        '
        'panInfo
        '
        Me.panInfo.AutoScroll = True
        Me.panInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panInfo.Controls.Add(Me.grpShipping)
        Me.panInfo.Controls.Add(Me.grpBillingInfo)
        Me.panInfo.Location = New System.Drawing.Point(12, 341)
        Me.panInfo.Name = "panInfo"
        Me.panInfo.Size = New System.Drawing.Size(275, 175)
        Me.panInfo.TabIndex = 2
        '
        'grpShipping
        '
        Me.grpShipping.Controls.Add(Me.chkShippingSame)
        Me.grpShipping.Controls.Add(Me.txtShippingZip)
        Me.grpShipping.Controls.Add(Me.txtShippingState)
        Me.grpShipping.Controls.Add(Me.txtShippingCity)
        Me.grpShipping.Controls.Add(Me.txtShippingStreet)
        Me.grpShipping.Controls.Add(Me.lblShippingZip)
        Me.grpShipping.Controls.Add(Me.lblShippingState)
        Me.grpShipping.Controls.Add(Me.lblShippingCity)
        Me.grpShipping.Controls.Add(Me.lblShippingStreet)
        Me.grpShipping.Location = New System.Drawing.Point(8, 113)
        Me.grpShipping.Name = "grpShipping"
        Me.grpShipping.Size = New System.Drawing.Size(238, 125)
        Me.grpShipping.TabIndex = 1
        Me.grpShipping.TabStop = False
        Me.grpShipping.Text = "Shipping Info"
        '
        'chkShippingSame
        '
        Me.chkShippingSame.AutoSize = True
        Me.chkShippingSame.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkShippingSame.Location = New System.Drawing.Point(135, 12)
        Me.chkShippingSame.Name = "chkShippingSame"
        Me.chkShippingSame.Size = New System.Drawing.Size(97, 17)
        Me.chkShippingSame.TabIndex = 0
        Me.chkShippingSame.Text = "Same as Billing"
        Me.chkShippingSame.UseVisualStyleBackColor = True
        '
        'txtShippingZip
        '
        Me.txtShippingZip.Location = New System.Drawing.Point(173, 96)
        Me.txtShippingZip.Name = "txtShippingZip"
        Me.txtShippingZip.Size = New System.Drawing.Size(59, 20)
        Me.txtShippingZip.TabIndex = 8
        '
        'txtShippingState
        '
        Me.txtShippingState.Location = New System.Drawing.Point(104, 96)
        Me.txtShippingState.Name = "txtShippingState"
        Me.txtShippingState.Size = New System.Drawing.Size(63, 20)
        Me.txtShippingState.TabIndex = 7
        '
        'txtShippingCity
        '
        Me.txtShippingCity.Location = New System.Drawing.Point(6, 96)
        Me.txtShippingCity.Name = "txtShippingCity"
        Me.txtShippingCity.Size = New System.Drawing.Size(92, 20)
        Me.txtShippingCity.TabIndex = 6
        '
        'txtShippingStreet
        '
        Me.txtShippingStreet.Location = New System.Drawing.Point(7, 57)
        Me.txtShippingStreet.Name = "txtShippingStreet"
        Me.txtShippingStreet.Size = New System.Drawing.Size(225, 20)
        Me.txtShippingStreet.TabIndex = 2
        '
        'lblShippingZip
        '
        Me.lblShippingZip.AutoSize = True
        Me.lblShippingZip.Location = New System.Drawing.Point(175, 80)
        Me.lblShippingZip.Name = "lblShippingZip"
        Me.lblShippingZip.Size = New System.Drawing.Size(25, 13)
        Me.lblShippingZip.TabIndex = 5
        Me.lblShippingZip.Text = "Zip:"
        '
        'lblShippingState
        '
        Me.lblShippingState.AutoSize = True
        Me.lblShippingState.Location = New System.Drawing.Point(101, 80)
        Me.lblShippingState.Name = "lblShippingState"
        Me.lblShippingState.Size = New System.Drawing.Size(35, 13)
        Me.lblShippingState.TabIndex = 4
        Me.lblShippingState.Text = "State:"
        '
        'lblShippingCity
        '
        Me.lblShippingCity.AutoSize = True
        Me.lblShippingCity.Location = New System.Drawing.Point(6, 80)
        Me.lblShippingCity.Name = "lblShippingCity"
        Me.lblShippingCity.Size = New System.Drawing.Size(27, 13)
        Me.lblShippingCity.TabIndex = 3
        Me.lblShippingCity.Text = "City:"
        '
        'lblShippingStreet
        '
        Me.lblShippingStreet.AutoSize = True
        Me.lblShippingStreet.Location = New System.Drawing.Point(6, 40)
        Me.lblShippingStreet.Name = "lblShippingStreet"
        Me.lblShippingStreet.Size = New System.Drawing.Size(38, 13)
        Me.lblShippingStreet.TabIndex = 1
        Me.lblShippingStreet.Text = "Street:"
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(380, 531)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 7
        Me.btnClear.Text = "&Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'grpDelivery
        '
        Me.grpDelivery.Controls.Add(Me.radioDeliveryCost)
        Me.grpDelivery.Controls.Add(Me.radioDeliveryPickup)
        Me.grpDelivery.Location = New System.Drawing.Point(304, 341)
        Me.grpDelivery.Name = "grpDelivery"
        Me.grpDelivery.Size = New System.Drawing.Size(232, 49)
        Me.grpDelivery.TabIndex = 3
        Me.grpDelivery.TabStop = False
        Me.grpDelivery.Text = "Delivery Option"
        '
        'radioDeliveryCost
        '
        Me.radioDeliveryCost.AutoSize = True
        Me.radioDeliveryCost.Location = New System.Drawing.Point(119, 21)
        Me.radioDeliveryCost.Name = "radioDeliveryCost"
        Me.radioDeliveryCost.Size = New System.Drawing.Size(93, 17)
        Me.radioDeliveryCost.TabIndex = 1
        Me.radioDeliveryCost.Text = "Delivery + $10"
        Me.radioDeliveryCost.UseVisualStyleBackColor = True
        '
        'radioDeliveryPickup
        '
        Me.radioDeliveryPickup.AutoSize = True
        Me.radioDeliveryPickup.Checked = True
        Me.radioDeliveryPickup.Location = New System.Drawing.Point(7, 21)
        Me.radioDeliveryPickup.Name = "radioDeliveryPickup"
        Me.radioDeliveryPickup.Size = New System.Drawing.Size(58, 17)
        Me.radioDeliveryPickup.TabIndex = 0
        Me.radioDeliveryPickup.TabStop = True
        Me.radioDeliveryPickup.Text = "Pickup"
        Me.radioDeliveryPickup.UseVisualStyleBackColor = True
        '
        'grpTotal
        '
        Me.grpTotal.Controls.Add(Me.txtOrderTotal)
        Me.grpTotal.Controls.Add(Me.lblOrderTotal)
        Me.grpTotal.Controls.Add(Me.txtOrderDel)
        Me.grpTotal.Controls.Add(Me.lblOrderDelivery)
        Me.grpTotal.Controls.Add(Me.txtOrderTax)
        Me.grpTotal.Controls.Add(Me.lblOrderTax)
        Me.grpTotal.Controls.Add(Me.txtOrderSub)
        Me.grpTotal.Controls.Add(Me.lblOrderSub)
        Me.grpTotal.Location = New System.Drawing.Point(304, 396)
        Me.grpTotal.Name = "grpTotal"
        Me.grpTotal.Size = New System.Drawing.Size(232, 120)
        Me.grpTotal.TabIndex = 4
        Me.grpTotal.TabStop = False
        Me.grpTotal.Text = "Order Total"
        '
        'txtOrderTotal
        '
        Me.txtOrderTotal.Enabled = False
        Me.txtOrderTotal.Location = New System.Drawing.Point(94, 91)
        Me.txtOrderTotal.Name = "txtOrderTotal"
        Me.txtOrderTotal.Size = New System.Drawing.Size(129, 20)
        Me.txtOrderTotal.TabIndex = 7
        '
        'lblOrderTotal
        '
        Me.lblOrderTotal.AutoSize = True
        Me.lblOrderTotal.Location = New System.Drawing.Point(6, 94)
        Me.lblOrderTotal.Name = "lblOrderTotal"
        Me.lblOrderTotal.Size = New System.Drawing.Size(63, 13)
        Me.lblOrderTotal.TabIndex = 6
        Me.lblOrderTotal.Text = "Order Total:"
        '
        'txtOrderDel
        '
        Me.txtOrderDel.Enabled = False
        Me.txtOrderDel.Location = New System.Drawing.Point(94, 65)
        Me.txtOrderDel.Name = "txtOrderDel"
        Me.txtOrderDel.Size = New System.Drawing.Size(129, 20)
        Me.txtOrderDel.TabIndex = 5
        '
        'lblOrderDelivery
        '
        Me.lblOrderDelivery.AutoSize = True
        Me.lblOrderDelivery.Location = New System.Drawing.Point(6, 68)
        Me.lblOrderDelivery.Name = "lblOrderDelivery"
        Me.lblOrderDelivery.Size = New System.Drawing.Size(85, 13)
        Me.lblOrderDelivery.TabIndex = 4
        Me.lblOrderDelivery.Text = "Delivery Charge:"
        '
        'txtOrderTax
        '
        Me.txtOrderTax.Enabled = False
        Me.txtOrderTax.Location = New System.Drawing.Point(96, 39)
        Me.txtOrderTax.Name = "txtOrderTax"
        Me.txtOrderTax.Size = New System.Drawing.Size(129, 20)
        Me.txtOrderTax.TabIndex = 3
        '
        'lblOrderTax
        '
        Me.lblOrderTax.AutoSize = True
        Me.lblOrderTax.Location = New System.Drawing.Point(6, 42)
        Me.lblOrderTax.Name = "lblOrderTax"
        Me.lblOrderTax.Size = New System.Drawing.Size(80, 13)
        Me.lblOrderTax.TabIndex = 2
        Me.lblOrderTax.Text = "Tax: @ 7.825%"
        '
        'txtOrderSub
        '
        Me.txtOrderSub.Enabled = False
        Me.txtOrderSub.Location = New System.Drawing.Point(96, 13)
        Me.txtOrderSub.Name = "txtOrderSub"
        Me.txtOrderSub.Size = New System.Drawing.Size(129, 20)
        Me.txtOrderSub.TabIndex = 1
        '
        'lblOrderSub
        '
        Me.lblOrderSub.AutoSize = True
        Me.lblOrderSub.Location = New System.Drawing.Point(6, 16)
        Me.lblOrderSub.Name = "lblOrderSub"
        Me.lblOrderSub.Size = New System.Drawing.Size(56, 13)
        Me.lblOrderSub.TabIndex = 0
        Me.lblOrderSub.Text = "Sub Total:"
        '
        'grpOrder
        '
        Me.grpOrder.Controls.Add(Me.AddLines)
        Me.grpOrder.Location = New System.Drawing.Point(12, 62)
        Me.grpOrder.Name = "grpOrder"
        Me.grpOrder.Size = New System.Drawing.Size(523, 264)
        Me.grpOrder.TabIndex = 1
        Me.grpOrder.TabStop = False
        '
        'AddLines
        '
        Me.AddLines.Location = New System.Drawing.Point(6, 19)
        Me.AddLines.Name = "AddLines"
        Me.AddLines.Size = New System.Drawing.Size(509, 239)
        Me.AddLines.TabIndex = 0
        '
        'frmChild
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(556, 564)
        Me.Controls.Add(Me.grpTotal)
        Me.Controls.Add(Me.grpDelivery)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnOpen)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.grpOrder)
        Me.Controls.Add(Me.grpCustomer)
        Me.Controls.Add(Me.panInfo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "frmChild"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpCustomer.ResumeLayout(False)
        Me.grpCustomer.PerformLayout()
        Me.grpBillingInfo.ResumeLayout(False)
        Me.grpBillingInfo.PerformLayout()
        Me.panInfo.ResumeLayout(False)
        Me.grpShipping.ResumeLayout(False)
        Me.grpShipping.PerformLayout()
        Me.grpDelivery.ResumeLayout(False)
        Me.grpDelivery.PerformLayout()
        Me.grpTotal.ResumeLayout(False)
        Me.grpTotal.PerformLayout()
        Me.grpOrder.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnOpen As System.Windows.Forms.Button
    Friend WithEvents txtCustomerID As System.Windows.Forms.TextBox
    Friend WithEvents txtCustomerName As System.Windows.Forms.TextBox
    Friend WithEvents lblCustomerID As System.Windows.Forms.Label
    Friend WithEvents lblCustomerName As System.Windows.Forms.Label
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents grpCustomer As GroupBox
    Friend WithEvents txtCustomerOrderDate As TextBox
    Friend WithEvents lblCustomerDate As Label
    Friend WithEvents txtCustomerPhone As TextBox
    Friend WithEvents lblCustomerPhone As Label
    Friend WithEvents panInfo As Panel
    Friend WithEvents grpBillingInfo As GroupBox
    Friend WithEvents txtBillingZip As TextBox
    Friend WithEvents txtBillingState As TextBox
    Friend WithEvents txtBillingCity As TextBox
    Friend WithEvents txtBillingStreet As TextBox
    Friend WithEvents lblBillingZip As Label
    Friend WithEvents lblBillingState As Label
    Friend WithEvents lblBillingCity As Label
    Friend WithEvents lblBillingStreet As Label
    Friend WithEvents grpShipping As GroupBox
    Friend WithEvents txtShippingZip As TextBox
    Friend WithEvents txtShippingState As TextBox
    Friend WithEvents txtShippingCity As TextBox
    Friend WithEvents txtShippingStreet As TextBox
    Friend WithEvents lblShippingZip As Label
    Friend WithEvents lblShippingState As Label
    Friend WithEvents lblShippingCity As Label
    Friend WithEvents lblShippingStreet As Label
    Friend WithEvents chkShippingSame As CheckBox
    Friend WithEvents btnClear As Button
    Friend WithEvents grpTotal As GroupBox
    Friend WithEvents txtOrderTotal As TextBox
    Friend WithEvents lblOrderTotal As Label
    Friend WithEvents txtOrderDel As TextBox
    Friend WithEvents lblOrderDelivery As Label
    Friend WithEvents txtOrderTax As TextBox
    Friend WithEvents lblOrderTax As Label
    Friend WithEvents txtOrderSub As TextBox
    Friend WithEvents lblOrderSub As Label
    Friend WithEvents grpDelivery As GroupBox
    Friend WithEvents radioDeliveryCost As RadioButton
    Friend WithEvents radioDeliveryPickup As RadioButton
    Friend WithEvents grpOrder As GroupBox
    Public WithEvents AddLines As AddLines.AddLines
End Class
