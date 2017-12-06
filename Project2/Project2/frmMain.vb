Public Class frmMain

    Private x As Integer = 0
    Public controller As New clsController

    Private Sub mnuFile_DropDownOpening(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFile.DropDownOpening
        If Not Me.ActiveMdiChild Is Nothing Then
            mnuFileClose.Enabled = True
            mnuFileSave.Enabled = True
        Else
            mnuFileClose.Enabled = False
            mnuFileSave.Enabled = False
        End If
    End Sub

    Private Sub mnuFileNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNew.Click
        'Open the form
        Dim frm As frmChild
        frm = New frmChild
        x += 1
        frm.Text = "Child " & x
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub mnuFileOpen_Click(sender As Object, e As EventArgs) Handles mnuFileOpen.Click
        Dim orderNumber As String
        Dim frm As frmChild = New frmChild

        orderNumber = InputBox("Please enter an Order number to search", "Order Number Search")
        x += 1
        frm.Text = "Child " & x
        frm.MdiParent = Me
        frm.Show()
        frm.txtCustomerID.Text = orderNumber
        frm.btnOpen.PerformClick()

        If frm.txtCustomerID.Text = "" Then
            Me.mnuFileClose_Click(Me, e)
        End If
    End Sub
    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        'Delete the current order
        If Not Me.ActiveMdiChild Is Nothing Then
            Dim frm As frmChild = Me.ActiveMdiChild
            frm.btnDelete.PerformClick()
        End If
    End Sub

    Private Sub mnuFileSave_Click(sender As Object, e As EventArgs) Handles mnuFileSave.Click
        'Saves the current order
        If Not Me.ActiveMdiChild Is Nothing Then
            Dim frm As frmChild = Me.ActiveMdiChild
            frm.btnSave.PerformClick()
        End If
    End Sub

    Private Sub mnuFileClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileClose.Click
        'Close the current order
        If Not Me.ActiveMdiChild Is Nothing Then
            Me.ActiveMdiChild.Close()
        End If
    End Sub

    Private Sub mnuFileExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileExit.Click
        'Close the parent form
        Me.Close()
    End Sub

    Private Sub mnuEdit_DropDownOpening(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuEdit.DropDownOpening
        'Disable the menus
        mnuEditCut.Enabled = False
        mnuEditCopy.Enabled = False
        mnuEditPaste.Enabled = False

        'Re-enable the menus accordingly
        If Not Me.ActiveMdiChild Is Nothing Then
            If TypeOf Me.ActiveMdiChild.ActiveControl Is TextBox Then
                If CType(Me.ActiveMdiChild.ActiveControl, TextBox).SelectedText <> "" Then
                    mnuEditCut.Enabled = True
                    mnuEditCopy.Enabled = True
                End If
                If Clipboard.GetText <> "" Then
                    mnuEditPaste.Enabled = True
                End If
            End If
        End If
    End Sub

    Private Sub mnuEditCut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEditCut.Click
        Clipboard.SetText(CType(Me.ActiveMdiChild.ActiveControl, TextBox).SelectedText)
        CType(Me.ActiveMdiChild.ActiveControl, TextBox).SelectedText = ""
    End Sub

    Private Sub mnuEditCopy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuEditCopy.Click
        Clipboard.SetText(CType(Me.ActiveMdiChild.ActiveControl, TextBox).SelectedText)
    End Sub

    Private Sub mnuEditPaste_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuEditPaste.Click
        CType(Me.ActiveMdiChild.ActiveControl, TextBox).SelectedText = Clipboard.GetText
    End Sub

    Private Sub mnuWindowCascade_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuWindowCascade.Click
        'Arrange windows cascading
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub mnuWindowHorizontal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuWindowHorizontal.Click
        'Arrange windows tiled horizontally
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub mnuWindowVertical_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuWindowVertical.Click
        'Arrange windows tiled vertically
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("Project Halo" & vbCrLf & "Author: Dennis Rendon" & vbCrLf & "Email: drendon@cpp.edu", vbOKOnly, "Contact Information")
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class