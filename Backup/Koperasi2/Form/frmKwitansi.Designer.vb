<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKwitansi
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmbFisik = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmbStatKwitansi = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.cmbPIC1 = New System.Windows.Forms.ComboBox
        Me.cmbPIC2 = New System.Windows.Forms.ComboBox
        Me.txtNominal = New System.Windows.Forms.TextBox
        Me.txtAlasan = New System.Windows.Forms.TextBox
        Me.dtBayar = New System.Windows.Forms.DateTimePicker
        Me.btnApprove = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.txtKontrak = New System.Windows.Forms.TextBox
        Me.txtNamaKonsumen = New System.Windows.Forms.TextBox
        Me.btnKonsumen = New System.Windows.Forms.Button
        Me.btnKontrak = New System.Windows.Forms.Button
        Me.txtIdKonsumen = New System.Windows.Forms.TextBox
        Me.cmbKwitansi = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "No Kwitansi"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "PIC Pertama"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Status Kwitansi"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(283, 84)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(28, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Fisik"
        '
        'cmbFisik
        '
        Me.cmbFisik.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFisik.FormattingEnabled = True
        Me.cmbFisik.Items.AddRange(New Object() {"Ada", "Tidak ada"})
        Me.cmbFisik.Location = New System.Drawing.Point(399, 81)
        Me.cmbFisik.Name = "cmbFisik"
        Me.cmbFisik.Size = New System.Drawing.Size(134, 21)
        Me.cmbFisik.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 157)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Alasan"
        '
        'cmbStatKwitansi
        '
        Me.cmbStatKwitansi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatKwitansi.FormattingEnabled = True
        Me.cmbStatKwitansi.Items.AddRange(New Object() {"Terpakai", "Belum Terpakai", "Cancel"})
        Me.cmbStatKwitansi.Location = New System.Drawing.Point(121, 76)
        Me.cmbStatKwitansi.Name = "cmbStatKwitansi"
        Me.cmbStatKwitansi.Size = New System.Drawing.Size(134, 21)
        Me.cmbStatKwitansi.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(283, 47)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "PIC Kedua"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 124)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 13)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Nominal"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(283, 244)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 13)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Tanggal Bayar"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(283, 124)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(61, 13)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "No Kontrak"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 246)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 13)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "Nama Konsumen"
        '
        'cmbPIC1
        '
        Me.cmbPIC1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPIC1.FormattingEnabled = True
        Me.cmbPIC1.Location = New System.Drawing.Point(121, 39)
        Me.cmbPIC1.Name = "cmbPIC1"
        Me.cmbPIC1.Size = New System.Drawing.Size(121, 21)
        Me.cmbPIC1.TabIndex = 1
        '
        'cmbPIC2
        '
        Me.cmbPIC2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPIC2.FormattingEnabled = True
        Me.cmbPIC2.Location = New System.Drawing.Point(399, 39)
        Me.cmbPIC2.Name = "cmbPIC2"
        Me.cmbPIC2.Size = New System.Drawing.Size(121, 21)
        Me.cmbPIC2.TabIndex = 2
        '
        'txtNominal
        '
        Me.txtNominal.Location = New System.Drawing.Point(121, 117)
        Me.txtNominal.Name = "txtNominal"
        Me.txtNominal.Size = New System.Drawing.Size(130, 20)
        Me.txtNominal.TabIndex = 5
        '
        'txtAlasan
        '
        Me.txtAlasan.Location = New System.Drawing.Point(121, 154)
        Me.txtAlasan.Multiline = True
        Me.txtAlasan.Name = "txtAlasan"
        Me.txtAlasan.Size = New System.Drawing.Size(272, 67)
        Me.txtAlasan.TabIndex = 8
        '
        'dtBayar
        '
        Me.dtBayar.Location = New System.Drawing.Point(399, 244)
        Me.dtBayar.Name = "dtBayar"
        Me.dtBayar.Size = New System.Drawing.Size(96, 20)
        Me.dtBayar.TabIndex = 11
        '
        'btnApprove
        '
        Me.btnApprove.Location = New System.Drawing.Point(210, 295)
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Size = New System.Drawing.Size(82, 32)
        Me.btnApprove.TabIndex = 12
        Me.btnApprove.Text = "Approve"
        Me.btnApprove.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(332, 295)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(86, 32)
        Me.btnCancel.TabIndex = 13
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'txtKontrak
        '
        Me.txtKontrak.Location = New System.Drawing.Point(399, 117)
        Me.txtKontrak.Name = "txtKontrak"
        Me.txtKontrak.Size = New System.Drawing.Size(130, 20)
        Me.txtKontrak.TabIndex = 6
        '
        'txtNamaKonsumen
        '
        Me.txtNamaKonsumen.Location = New System.Drawing.Point(121, 239)
        Me.txtNamaKonsumen.Name = "txtNamaKonsumen"
        Me.txtNamaKonsumen.Size = New System.Drawing.Size(121, 20)
        Me.txtNamaKonsumen.TabIndex = 9
        '
        'btnKonsumen
        '
        Me.btnKonsumen.Location = New System.Drawing.Point(248, 237)
        Me.btnKonsumen.Name = "btnKonsumen"
        Me.btnKonsumen.Size = New System.Drawing.Size(26, 23)
        Me.btnKonsumen.TabIndex = 10
        Me.btnKonsumen.UseVisualStyleBackColor = True
        '
        'btnKontrak
        '
        Me.btnKontrak.Location = New System.Drawing.Point(535, 115)
        Me.btnKontrak.Name = "btnKontrak"
        Me.btnKontrak.Size = New System.Drawing.Size(26, 23)
        Me.btnKontrak.TabIndex = 7
        Me.btnKontrak.UseVisualStyleBackColor = True
        '
        'txtIdKonsumen
        '
        Me.txtIdKonsumen.Location = New System.Drawing.Point(12, 279)
        Me.txtIdKonsumen.Name = "txtIdKonsumen"
        Me.txtIdKonsumen.Size = New System.Drawing.Size(121, 20)
        Me.txtIdKonsumen.TabIndex = 29
        Me.txtIdKonsumen.Visible = False
        '
        'cmbKwitansi
        '
        Me.cmbKwitansi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbKwitansi.FormattingEnabled = True
        Me.cmbKwitansi.Location = New System.Drawing.Point(118, 7)
        Me.cmbKwitansi.Name = "cmbKwitansi"
        Me.cmbKwitansi.Size = New System.Drawing.Size(124, 21)
        Me.cmbKwitansi.TabIndex = 0
        '
        'frmKwitansi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(641, 366)
        Me.Controls.Add(Me.cmbKwitansi)
        Me.Controls.Add(Me.txtIdKonsumen)
        Me.Controls.Add(Me.btnKontrak)
        Me.Controls.Add(Me.btnKonsumen)
        Me.Controls.Add(Me.txtNamaKonsumen)
        Me.Controls.Add(Me.txtKontrak)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnApprove)
        Me.Controls.Add(Me.dtBayar)
        Me.Controls.Add(Me.txtAlasan)
        Me.Controls.Add(Me.txtNominal)
        Me.Controls.Add(Me.cmbPIC2)
        Me.Controls.Add(Me.cmbPIC1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cmbStatKwitansi)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmbFisik)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmKwitansi"
        Me.Text = "Stok Kwitansi"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbFisik As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbStatKwitansi As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbPIC1 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPIC2 As System.Windows.Forms.ComboBox
    Friend WithEvents txtNominal As System.Windows.Forms.TextBox
    Friend WithEvents txtAlasan As System.Windows.Forms.TextBox
    Friend WithEvents dtBayar As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnApprove As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents txtKontrak As System.Windows.Forms.TextBox
    Friend WithEvents txtNamaKonsumen As System.Windows.Forms.TextBox
    Friend WithEvents btnKonsumen As System.Windows.Forms.Button
    Friend WithEvents btnKontrak As System.Windows.Forms.Button
    Friend WithEvents txtIdKonsumen As System.Windows.Forms.TextBox
    Friend WithEvents cmbKwitansi As System.Windows.Forms.ComboBox
End Class
