Imports System.IO
Public Class frmMain

    'variables for summary
    Dim totalTests As Integer = 0
    Dim totalVehicles As Integer = 0
    Dim totalMiles As Integer = 0
    Dim totalFuelCells As Integer = 0
    Dim totalCost As Integer = 0

    'constant for fuel costs
    Const FUEL_COST As Integer = 22
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load

        'load combo box values for drivers
        cboDriverID.Items.Add("100")
        cboDriverID.Items.Add("200")
        cboDriverID.Items.Add("300")
        cboDriverID.Items.Add("400")

        'load combo box values for vehicles
        cboDataVehicle1.Items.Add("Banshee")
        cboDataVehicle1.Items.Add("Ghost")
        cboDataVehicle1.Items.Add("Chopper")
        cboDataVehicle1.Items.Add("Hornet")
        cboDataVehicle2.Items.Add("Banshee")
        cboDataVehicle2.Items.Add("Ghost")
        cboDataVehicle2.Items.Add("Chopper")
        cboDataVehicle2.Items.Add("Hornet")
        cboDataVehicle3.Items.Add("Banshee")
        cboDataVehicle3.Items.Add("Ghost")
        cboDataVehicle3.Items.Add("Chopper")
        cboDataVehicle3.Items.Add("Hornet")
        cboDataVehicle4.Items.Add("Banshee")
        cboDataVehicle4.Items.Add("Ghost")
        cboDataVehicle4.Items.Add("Chopper")
        cboDataVehicle4.Items.Add("Hornet")
    End Sub
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        'loop through all controls
        'if control is group box, continue,
        'if control is textbox, clear and then continue
        'if control is cbobox, clear and then continue

        For Each grpctrl As Control In Me.Controls
            If TypeOf grpctrl Is GroupBox Then
                For Each txtctrl As Control In grpctrl.Controls
                    If TypeOf txtctrl Is TextBox Then
                        txtctrl.Text = Nothing
                        For Each cboctrl As Control In grpctrl.Controls
                            If TypeOf cboctrl Is ComboBox Then
                                cboctrl.Text = Nothing
                            End If
                        Next
                    End If
                Next
            End If
        Next

        'clear picture box
        picDriver.Image = Nothing

    End Sub
    Private Sub btnProcess_Click(sender As Object, e As EventArgs) Handles btnProcess.Click

        'variables to indicate if form has valid data
        Dim validData As Integer = 0
        Dim validForm As Integer = 0

        'variable for row data
        Dim mile As Integer = 0
        Dim fuel As Integer = 0

        validForm = formValid()

        'if form has valid data, continue. else exit
        If validForm = 0 Then
            Exit Sub
        Else
            validData = ErrorCheck(txtDataStartMileage1.Text, txtDataEndMileage1.Text, txtDataStartFuel1.Text, txtDataEndFuel1.Text, 1)

            'if row has valid data, continue. else exit
            If validData = 0 Then
                Exit Sub
            Else

                'find total miles for row
                mile = mileCal(txtDataEndMileage1.Text, txtDataStartMileage1.Text)

                'find total fuel for row
                fuel = fuelCal(txtDataStartFuel1.Text, txtDataEndFuel1.Text)

                'load formated data into rows
                txtResultsMileage1.Text = Format(mile, "#,###,###,###")
                txtResultsFuelUsed1.Text = Format(fuel, "#,###,###,###")
                txtResultsFuelCost1.Text = Format((FUEL_COST * fuel), "$#,###,###,##0.00")
                txtResultsMPFCRating1.Text = mpfcRating(mile, fuel)
                txtResultsVehicle1.Text = cboDataVehicle1.Text
                txtResultsFamily1.Text = vehicleFamily(cboDataVehicle1.Text)

                'increase total test value
                totalTests = totalTests + 1

                'increase total vechicles tested
                totalVehicles = totalVehicles + 1
            End If

            validData = ErrorCheck(txtDataStartMileage2.Text, txtDataEndMileage2.Text, txtDataStartFuel2.Text, txtDataEndFuel2.Text, 2)

            'if row has valid data, continue. else exit
            If validData = 0 Then
                Exit Sub
            Else

                'find total miles for row
                mile = mileCal(txtDataEndMileage2.Text, txtDataStartMileage2.Text)

                'find total fuel for row
                fuel = fuelCal(txtDataStartFuel2.Text, txtDataEndFuel2.Text)

                'load formated data into rows
                txtResultsMileage2.Text = Format(mile, "#,###,###,###")
                txtResultsFuelUsed2.Text = Format(fuel, "#,###,###,###")
                txtResultsFuelCost2.Text = Format((FUEL_COST * fuel), "$#,###,###,##0.00")
                txtResultsMPFCRating2.Text = mpfcRating(mile, fuel)
                txtResultsVehicle2.Text = cboDataVehicle2.Text
                txtResultsFamily2.Text = vehicleFamily(cboDataVehicle2.Text)

                'increase total vechicles tested
                totalVehicles = totalVehicles + 1
            End If

            validData = ErrorCheck(txtDataStartMileage3.Text, txtDataEndMileage3.Text, txtDataStartFuel3.Text, txtDataEndFuel3.Text, 3)

            'if row has valid data, continue. else exit
            If validData = 0 Then
                Exit Sub
            Else

                'find total miles for row
                mile = mileCal(txtDataEndMileage3.Text, txtDataStartMileage3.Text)

                'find total fuel for row
                fuel = fuelCal(txtDataStartFuel3.Text, txtDataEndFuel3.Text)

                'load formated data into rows
                txtResultsMileage3.Text = Format(mile, "#,###,###,###")
                txtResultsFuelUsed3.Text = Format(fuel, "#,###,###,###")
                txtResultsFuelCost3.Text = Format((FUEL_COST * fuel), "$#,###,###,##0.00")
                txtResultsMPFCRating3.Text = mpfcRating(mile, fuel)
                txtResultsVehicle3.Text = cboDataVehicle3.Text
                txtResultsFamily3.Text = vehicleFamily(cboDataVehicle3.Text)

                'increase total vechicles tested
                totalVehicles = totalVehicles + 1
            End If

            validData = ErrorCheck(txtDataStartMileage4.Text, txtDataEndMileage4.Text, txtDataStartFuel4.Text, txtDataEndFuel4.Text, 4)

            'if row has valid data, continue. else exit
            If validData = 0 Then
                Exit Sub
            Else

                'find total miles for row
                mile = mileCal(txtDataEndMileage4.Text, txtDataStartMileage4.Text)
                'find total fuel for row
                fuel = fuelCal(txtDataStartFuel4.Text, txtDataEndFuel4.Text)

                'load formated data into rows
                txtResultsMileage4.Text = Format(mile, "#,###,###,###")
                txtResultsFuelUsed4.Text = Format(fuel, "#,###,###,###")
                txtResultsFuelCost4.Text = Format((FUEL_COST * fuel), "$#,###,###,##0.00")
                txtResultsMPFCRating4.Text = mpfcRating(mile, fuel)
                txtResultsVehicle4.Text = cboDataVehicle4.Text
                txtResultsFamily4.Text = vehicleFamily(cboDataVehicle4.Text)

                'increase total vechicles tested
                totalVehicles = totalVehicles + 1
            End If
        End If

    End Sub
    Private Function formValid()

        'if form has valid data, return valid as 1
        'if form has invalid data, show messagebox of errors
        Dim valid As Integer = 0
        Dim response As String = ""

        'if textbox does not contain number
        If Not IsNumeric(txtTestNum.Text) Then
            response = response + "Invalid Test Number" & vbCrLf
        End If

        'if textbox does not have a date
        If Not IsDate(txtTestDate.Text) Then
            response = response + "Invalid Test Date" & vbCrLf
        End If

        'if textbox does not data
        If Len(txtInventorFirstName.Text) < 1 Then
            response = response + "Missing Inventory First Name" & vbCrLf
        End If

        'if textbox does not data
        If Len(txtInventorLastName.Text) < 1 Then
            response = response + "Missing Inventory Last Name" & vbCrLf
        End If

        'if combobox does not have a selected value
        If cboDriverID.Text = "" Then
            response = response + "Missing Driver Information" & vbCrLf
        End If

        'if form has valid data, continue processing
        If IsNumeric(txtTestNum.Text) And IsDate(txtTestDate.Text) And Len(txtInventorFirstName.Text) > 0 And Len(txtInventorLastName.Text) > 0 And cboDriverID.Text <> "" Then
            valid = 1
        End If

        'if form has invalid data, show messagebox with errors
        If Len(response) > 0 Then
            MessageBox.Show(response)
        End If

        Return valid

    End Function
    Private Function ErrorCheck(startMileage As String, endMileage As String, startFuel As String, endFuel As String, row As Integer)

        'if row has valid data, return valid as 1
        'if row has invalid data, show messagebox of errors
        Dim valid As Integer = 0
        Dim response As String = ""

        'if row 1 has data, continue
        If row = 1 And (startMileage = "" Or endMileage = "" Or startFuel = "" Or endFuel = "" Or startMileage = "") Then
            response = "Invalid data in row " & row & vbCrLf
        Else
            If startMileage <> "" Or endMileage <> "" Or startFuel <> "" Or endFuel <> "" Or startMileage <> "" Then

                'check if start mileage is a number
                If Not IsNumeric(startMileage) Then
                    response = response + "Invalid Start Mileage " & row & vbCrLf
                End If

                'check if end mileage is a number
                If Not IsNumeric(endMileage) Then
                    response = response + "Invalid End Mileage " & row & vbCrLf
                End If

                'check if start fuel is a number
                If Not IsNumeric(startFuel) Then
                    response = response + "Invalid Start Fuel " & row & vbCrLf
                End If

                'check if end fuel is a number
                If Not IsNumeric(endFuel) Then
                    response = response + "Invalid End Fuel " & row & vbCrLf
                End If

                'if the entire row has valid data, return 1
                If IsNumeric(startMileage) And IsNumeric(endMileage) And IsNumeric(startFuel) And IsNumeric(endFuel) Then
                    valid = 1
                End If
            End If
        End If

        'if form has invalid data, show messagebox with errors
        If Len(response) > 1 Then
            MessageBox.Show(response)
        End If

        Return valid

    End Function
    Private Function mpfcRating(mile As Integer, fuel As Integer)

        'variables for mpfc rating
        Dim mpfc As Integer = mile / fuel
        Dim rating As String

        'if mpfc is greater than 300, Amazing
        'if mpfc is greater than 200, Economical
        'else, guzzler
        If mpfc > 300 Then
            rating = "Amazing!!"
        ElseIf mpfc > 200 Then
            rating = "Economical"
        Else
            rating = "Guzzler"
        End If

        Return rating

    End Function

    Private Function mileCal(endMile As Integer, startMile As Integer)

        'variable for determining mileage
        Dim mileage As Integer

        'mileage math
        mileage = endMile - startMile

        'add mileage to total
        totalMiles = totalMiles + mileage

        Return mileage

    End Function

    Private Function fuelCal(startFuel As Integer, endFuel As Integer)

        'variable for determining fuelage
        Dim fuelage As Integer

        'fuelage math
        fuelage = startFuel - endFuel

        'add fuelage to total
        totalFuelCells = totalFuelCells + fuelage

        Return fuelage

    End Function

    Private Sub btnAllTests_Click(sender As Object, e As EventArgs) Handles btnAllTests.Click

        'variable for total
        Dim sum As String = ""

        'if no test had run, do not display totals
        If totalTests = 0 Then
            MessageBox.Show("No tests have been performed. Can not calculate totals")
        Else

            'total test
            'total vehicles
            'total miles
            'total fuel cells
            'total costs
            sum = sum & "Number of Tests: " & totalTests & vbCrLf
            sum = sum & "Vehicles Tested: " & totalVehicles & vbCrLf
            sum = sum & vbCrLf
            sum = sum & "Total Miles Travelled: " & Format(totalMiles, "#,###,###,###") & vbCrLf
            sum = sum & "Total Fuel Cells Used: " & Format(totalFuelCells, "#,###,###,###") & vbCrLf
            sum = sum & "Total Costs: " & Format((totalFuelCells * FUEL_COST), "$#,###,###,##0.00")

            'create object of summary form
            'assign total variable to the text on summary form
            'show summary form
            Dim sumForm As New SummaryForm
            sumForm.rtbSummary.Text = sum
            sumForm.Show()
        End If

    End Sub
    Private Sub cboDriverID_TextChanged(sender As Object, e As EventArgs) Handles cboDriverID.TextChanged

        'if driver = 100, load information for Bart
        If cboDriverID.Text = "100" Then
            txtDriverFirstName.Text = "Bart"
            txtDriverLastName.Text = "Simpson"
            txtDriverPhone.Text = "909-888-7777"

            'if unable to find image, display error image
            If File.Exists("C:\Projects\Project01\img\" & cboDriverID.Text & ".jpg") Then
                picDriver.Image = System.Drawing.Image.FromFile("C:\Projects\Project01\img\" & cboDriverID.Text & ".jpg")
            Else
                picDriver.Image = picDriver.ErrorImage
                MessageBox.Show("Can not find immage at" & vbCrLf & "C:\Projects\Project01\img\" & cboDriverID.Text & ".jpg" & vbCrLf & "Please move image to this location")
            End If

            'if driver = 200, load information for Homer
        ElseIf cboDriverID.Text = "200" Then
            txtDriverFirstName.Text = "Homer"
            txtDriverLastName.Text = "Simpson"
            txtDriverPhone.Text = "909-666-5555"

            'if unable to find image, display error image
            If File.Exists("C:\Projects\Project01\img\" & cboDriverID.Text & ".jpg") Then
                picDriver.Image = System.Drawing.Image.FromFile("C:\Projects\Project01\img\" & cboDriverID.Text & ".jpg")
            Else
                picDriver.Image = picDriver.ErrorImage
                MessageBox.Show("Can not find immage at" & vbCrLf & "C:\Projects\Project01\img\" & cboDriverID.Text & ".jpg" & vbCrLf & "Please move image to this location")
            End If

            'if driver = 300, load information for Marge
        ElseIf cboDriverID.Text = "300" Then
            txtDriverFirstName.Text = "Marge"
            txtDriverLastName.Text = "Simpson"
            txtDriverPhone.Text = "909-111-3333"

            'if unable to find image, display error image
            If File.Exists("C:\Projects\Project01\img\" & cboDriverID.Text & ".jpg") Then
                picDriver.Image = System.Drawing.Image.FromFile("C:\Projects\Project01\img\" & cboDriverID.Text & ".jpg")
            Else
                picDriver.Image = picDriver.ErrorImage
                MessageBox.Show("Can not find immage at" & vbCrLf & "C:\Projects\Project01\img\" & cboDriverID.Text & ".jpg" & vbCrLf & "Please move image to this location")
            End If

            'if driver = 400, load information for Lisa
        ElseIf cboDriverID.Text = "400" Then
            txtDriverFirstName.Text = "Lisa"
            txtDriverLastName.Text = "Simpson"
            txtDriverPhone.Text = "909-333-6666"

            'if unable to find image, display error image
            If File.Exists("C:\Projects\Project01\img\" & cboDriverID.Text & ".jpg") Then
                picDriver.Image = System.Drawing.Image.FromFile("C:\Projects\Project01\img\" & cboDriverID.Text & ".jpg")
            Else
                picDriver.Image = picDriver.ErrorImage
                MessageBox.Show("Can not find immage at" & vbCrLf & "C:\Projects\Project01\img\" & cboDriverID.Text & ".jpg" & vbCrLf & "Please move image to this location")
            End If
        End If
    End Sub
    Private Function vehicleFamily(vehicle As String)

        'variable to determine family for vehicle
        Dim fam As String = ""

        'if banshee, then covenant
        'if ghost, then covenant
        'if chopper, then covenant
        'if hornet, then unsc
        If vehicle = "Banshee" Then
            fam = "Covenant"
        ElseIf vehicle = "Ghost" Then
            fam = "Covenant"
        ElseIf vehicle = "Chopper" Then
            fam = "Covenant"
        ElseIf vehicle = "Hornet" Then
            fam = "UNSC"
        End If

        Return fam

    End Function
End Class