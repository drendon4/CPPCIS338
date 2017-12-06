<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SummaryForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.rtbSummary = New System.Windows.Forms.RichTextBox()
        Me.lblSummary = New System.Windows.Forms.Label()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'rtbSummary
        '
        Me.rtbSummary.Enabled = False
        Me.rtbSummary.Location = New System.Drawing.Point(16, 39)
        Me.rtbSummary.Name = "rtbSummary"
        Me.rtbSummary.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.rtbSummary.Size = New System.Drawing.Size(215, 159)
        Me.rtbSummary.TabIndex = 0
        Me.rtbSummary.Text = ""
        '
        'lblSummary
        '
        Me.lblSummary.AutoSize = True
        Me.lblSummary.Location = New System.Drawing.Point(13, 23)
        Me.lblSummary.Name = "lblSummary"
        Me.lblSummary.Size = New System.Drawing.Size(50, 13)
        Me.lblSummary.TabIndex = 1
        Me.lblSummary.Text = "Summary"
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(156, 204)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 2
        Me.btnOk.Text = "&Ok"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'SummaryForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(250, 242)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.lblSummary)
        Me.Controls.Add(Me.rtbSummary)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "SummaryForm"
        Me.Text = "Summary"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents rtbSummary As RichTextBox
    Friend WithEvents lblSummary As Label
    Friend WithEvents btnOk As Button
End Class
