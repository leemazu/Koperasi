Public Class BastElektronik


    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    End Sub

    Private Sub BastKTA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


    
        settanggal()
        FillTable()

    End Sub

    Private Sub FillTable()
        da.Dispose()
        ds.Clear()
        StrSQL = "SELECT ApplicationID as [No.Aplikasi],"
        StrSQL &= "MemberName as [Nama Konsumen],"
        StrSQL &= "Convert(varchar,BirthDate,103) as [Tanggal Lahir],"
        StrSQL &= "MotorBrand as [Nama Barang],"
        StrSQL &= "MotorColor as [Nomor Seri],"
        StrSQL &= "MotorType as [Keterangan],"
        StrSQL &= "convert(int,MotorPrice) as [Harga Barang],"
        StrSQL &= "Tenor,convert(int,Installment) as [Angsuran],"
        StrSQL &= "convert(int,(MotorPrice+InsuranceAdmin+LoanAdmin)) as Modal "
        StrSQL &= "from [Application] INNER JOIN Member ON application.MemberID=member.memberid "
        StrSQL &= "AND Application.ApplicationTypeID ='4' ORDER BY ApplicationID ASC"
        RunSQL(StrSQL, 2, "BastElektronik")
        gv1.DataSource = ds
        gv1.DataMember = "BastElektronik"
    End Sub

    Private Sub txtCari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCari.TextChanged
        da.Dispose()
        ds.Clear()
        StrSQL = ""
        StrSQL = "SELECT ApplicationID as [No.Aplikasi],"
        StrSQL &= "MemberName as [Nama Konsumen],"
        StrSQL &= "Convert(varchar,BirthDate,103) as [Tanggal Lahir],"
        StrSQL &= "MotorBrand as [Nama Barang],"
        StrSQL &= "MotorColor as [Nomor Seri],"
        StrSQL &= "MotorType as [Keterangan],"
        StrSQL &= "convert(int,MotorPrice) as [Harga Barang],"
        StrSQL &= "Tenor,convert(int,Installment) as [Angsuran],"
        StrSQL &= "convert(int,(MotorPrice+InsuranceAdmin+LoanAdmin)) as Modal "
        StrSQL &= "from [Application] INNER JOIN Member ON application.MemberID=member.memberid "
        StrSQL &= "AND (ApplicationID LIKE '%" & antisqli(txtCari.Text) & "%' "
        StrSQL &= "OR MemberName LIKE '%" & antisqli(txtCari.Text) & "%') "
        StrSQL &= "AND Application.ApplicationTypeID ='4' ORDER BY ApplicationID ASC"
        RunSQL(StrSQL, 2, "FilterBastElektronik")
        gv1.DataSource = ds
        gv1.DataMember = "FilterBastElektronik"
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReject.Click

    End Sub

    Private Sub gv1_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gv1.CellContentDoubleClick

        txtAplikasi.Text = gv1.CurrentRow.Cells(0).Value

        RunSQL("SELECT BirthDate from Member inner join Application ON member.MemberID=application.memberid AND applicationid ='" & antisqli(txtAplikasi.Text) & "'", 1)
        dtPem.Text = dt.Rows(0)("BirthDate")
        txtPemNama.Text = gv1.CurrentRow.Cells(1).Value
        'dtPem.Text = tampung
        txtBarang.Text = gv1.CurrentRow.Cells(3).Value
        txtNoSeri.Text = gv1.CurrentRow.Cells(4).Value
        txtKeterangan.Text = gv1.CurrentRow.Cells(5).Value
        txtHarga.Text = gv1.CurrentRow.Cells(6).Value
        txtTenor.Text = gv1.CurrentRow.Cells(7).Value
        txtAngsuran.Text = gv1.CurrentRow.Cells(8).Value
        txtModal.Text = gv1.CurrentRow.Cells(9).Value
        txtKontrak.Text = AutoNumberContract(txtAplikasi.Text, "04")

    End Sub

    Private Sub settanggal()
        dtPem.Text = Now
        dtAngsuran.Text = Now
        dtBast.Text = Now
        dtKontrak.Text = Now

        dtPem.Format = DateTimePickerFormat.Custom
        dtPem.CustomFormat = "dd/MM/yyyy"

        dtAngsuran.Format = DateTimePickerFormat.Custom
        dtAngsuran.CustomFormat = "dd/MM/yyyy"

        dtBast.Format = DateTimePickerFormat.Custom
        dtBast.CustomFormat = "dd/MM/yyyy"

        dtKontrak.Format = DateTimePickerFormat.Custom
        dtKontrak.CustomFormat = "dd/MM/yyyy"

    End Sub
End Class