<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDana
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
        Me.components = New System.ComponentModel.Container
        Me.PDana1 = New Koperasi2.pDana
        Me.SuspendLayout()
        '
        'PDana1
        '
        Me.PDana1.AutoScroll = True
        Me.PDana1.Location = New System.Drawing.Point(0, 0)
        Me.PDana1.Name = "PDana1"
        Me.PDana1.Size = New System.Drawing.Size(850, 1700)
        Me.PDana1.TabIndex = 0
        '
        'frmDana
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(893, 750)
        Me.Controls.Add(Me.PDana1)
        Me.Name = "frmDana"
        Me.Text = "frmDana"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PDana1 As Koperasi2.pDana
End Class
