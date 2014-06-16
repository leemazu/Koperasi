<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmElektronik
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
        Me.PElektronik1 = New Koperasi2.pElektronik
        Me.SuspendLayout()
        '
        'PElektronik1
        '
        Me.PElektronik1.AutoScroll = True
        Me.PElektronik1.Location = New System.Drawing.Point(0, 1)
        Me.PElektronik1.Name = "PElektronik1"
        Me.PElektronik1.Size = New System.Drawing.Size(924, 1515)
        Me.PElektronik1.TabIndex = 0
        '
        'frmElektronik
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(964, 750)
        Me.Controls.Add(Me.PElektronik1)
        Me.Name = "frmElektronik"
        Me.Text = "frmElektronik"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PElektronik1 As Koperasi2.pElektronik
End Class
