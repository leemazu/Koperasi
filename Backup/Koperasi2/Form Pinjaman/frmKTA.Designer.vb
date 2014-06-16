<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKTA
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
        Me.PKTA1 = New Koperasi2.pKTA
        Me.SuspendLayout()
        '
        'PKTA1
        '
        Me.PKTA1.AutoScroll = True
        Me.PKTA1.Location = New System.Drawing.Point(-9, -5)
        Me.PKTA1.Name = "PKTA1"
        Me.PKTA1.Size = New System.Drawing.Size(933, 650)
        Me.PKTA1.TabIndex = 0
        '
        'frmKTA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 750)
        Me.Controls.Add(Me.PKTA1)
        Me.Name = "frmKTA"
        Me.Text = "frmKTA"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PKTA1 As Koperasi2.pKTA
End Class
