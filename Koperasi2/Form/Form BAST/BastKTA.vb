Public Class BastKTA

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    End Sub

    Private Sub BastKTA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        settanggal()

        FillTable()

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

    Private Sub FillTable()
        da.Dispose()
        ds.Clear()
        StrSQL = "SELECT ApplicationID as [No.Aplikasi],"
        StrSQL &= "MemberName as [Nama Konsumen],"
        StrSQL &= "Convert(varchar(10),convert(date,BirthDate,106),103) as [Tanggal Lahir],"
        StrSQL &= "convert(int,MotorPrice) as [Pinjaman],"
        StrSQL &= "Tenor,convert(int,Installment) as [Angsuran],"
        StrSQL &= "convert(int,(MotorPrice+InsuranceAdmin+LoanAdmin)) as Modal "
        StrSQL &= "from [Application] INNER JOIN Member ON application.MemberID=member.memberid "
        StrSQL &= "AND Application.ApplicationTypeID ='3' ORDER BY ApplicationID ASC"
        RunSQL(StrSQL, 2, "BastKTA")
        gv1.DataSource = ds
        gv1.DataMember = "BastKTA"
    End Sub

    Private Sub txtCari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCari.TextChanged
        da.Dispose()
        ds.Clear()
        StrSQL = "SELECT TOP 100 ApplicationID as [No.Aplikasi],"
        StrSQL &= "MemberName as [Nama Konsumen],"
        StrSQL &= "Convert(varchar(10),convert(date,BirthDate,103),103) as [Tanggal Lahir],"
        StrSQL &= "convert(int,MotorPrice) as [Pinjaman],"
        StrSQL &= "Tenor,convert(int,Installment) as [Angsuran],"
        StrSQL &= "convert(int,(MotorPrice+InsuranceAdmin+LoanAdmin)) as Modal "
        StrSQL &= "from [Application] app,Member mem "
        StrSQL &= "WHERE (ApplicationID LIKE '%" & antisqli(txtCari.Text) & "%' "
        StrSQL &= "OR MemberName LIKE '%" & antisqli(txtCari.Text) & "%') "
        StrSQL &= "AND App.ApplicationTypeID ='3' "
        StrSQL &= "AND App.MemberID = Mem.MemberID"
        RunSQL(StrSQL, 2, "FilterBastKTA")
        gv1.DataSource = ds
        gv1.DataMember = "FilterBastKTA"
    End Sub

    Private Sub gv1_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gv1.CellContentDoubleClick
        txtAplikasi.Text = gv1.CurrentRow.Cells(0).Value
        txtPemNama.Text = gv1.CurrentRow.Cells(1).Value

        RunSQL("SELECT BirthDate from Member inner join Application ON member.MemberID=application.memberid AND applicationid ='" & antisqli(txtAplikasi.Text) & "'", 1)


        dtPem.Text = dt.Rows(0)("BirthDate")


        'dtPem.Text = gv1.CurrentRow.Cells(2).Value
        txtPinjaman.Text = gv1.CurrentRow.Cells(3).Value
        txtTenor.Text = gv1.CurrentRow.Cells(4).Value
        txtAngsuran.Text = gv1.CurrentRow.Cells(5).Value
        txtModal.Text = gv1.CurrentRow.Cells(6).Value
        txtKontrak.Text = AutoNumberContract(txtAplikasi.Text, "03")
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPinjaman.TextChanged

    End Sub
End Class