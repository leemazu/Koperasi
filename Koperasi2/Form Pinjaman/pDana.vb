Imports System.Data.SqlClient
Imports System.IO
Imports System.Text.RegularExpressions
Imports CrystalDecisions.CrystalReports.engine

Public Class pDana

    Dim tempPokok As Double = 0
    Dim tempPremiAdmin As Double = 0
    Private Sub UserControl1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        setTanggal()
        ClearForm()
        txtAplikasi.Text = autoNumber(cmbPos.Text)
        txtPemNo.Text = autoNumberMember(cmbPos.Text)
        begginingState = "UBAH"


    End Sub

    Private Sub setTanggal()
      
        dtTanggal.Text = Now
        dtTanggal.Format = DateTimePickerFormat.Custom
        dtTanggal.CustomFormat = "dd/MM/yyyy"
        dtPemTl.Text = Now
        dtPemTl.Format = DateTimePickerFormat.Custom
        dtPemTl.CustomFormat = "dd/MM/yyyy"
    End Sub
    Private Sub FreshForm()
        'txtAplikasi.Text = autoNumber()
        ' txtPemNo.Text = autoNumberMember()
        posFlag = False
        txtKendaraan.Clear()
        txtTipe.Clear()
        txtWarna.Clear()
        txtTahun.Clear()
        txtMesin.Clear()
        txtRangka.Clear()
        txtNopol.Clear()
        txtPinjaman.Text = "0"
        txtPremiAsuransi.Text = "0"
        txtAdmin.Text = ribuan("35000")
        txtPremiAdmin.Text = "0"
        txtTenor.Text = "0"
        txtTingkatBunga.Text = "0"
        txtAdminKredit.Text = "0"
        txtBungaFlat.Text = "0"
        txtBungaPengali.Text = "0"
        txtAdminMurni.Text = "0"
        txtPokok.Text = "0"
        txtBunga.Text = "0"
        txtTotalHutang.Text = "0"
        txtAngsuran.Text = "0"
        autoNumberMember(cmbPos.Text)
        txtPemNama.Clear()
        'cmbPemGender.SelectedIndex = 0
        ckBpkb.Checked = False
        txtPemTl.Clear()
        dtPemTl.Text = Now
        txtPemKtp.Clear()
        txtPemAlamat.Clear()
        txtPemHp.Clear()
        txtPemTelp1.Clear()
        txtPemTelp2.Clear()
        txtPemIbu.Clear()
        txtPemRt.Clear()
        txtPemRw.Clear()
        'txtPemKerja.SelectedIndex = 0
        txtPenagihanAlamat.Clear()
        txtPenagihanRt.Clear()
        txtPenagihanRw.Clear()
        txtPerusahaanNama.Clear()
        txtPerusahaanJabatan.Clear()
        txtPerusahaanMasa.Clear()
        txtPerusahaanAlamat.Clear()
        txtPerusahaanRt.Clear()
        txtPerusahaanRw.Clear()
        txtPerusahaanTelp.Clear()
        txtKontakNama.Clear()
        txtKontakAlamat.Clear()
        txtKontakRt.Clear()
        txtKontakRw.Clear()
        txtKontakHubungan.Clear()
        txtKontakTelp.Clear()
        ckBpkb.Checked = False
        txtBpkbNama.Clear()
        txtBpkbAlamat.Clear()
        txtBpkbRt.Clear()
        txtBpkbRw.Clear()
        txtUangPemohon.Text = "0"
        txtUangPasangan.Text = "0"
        txtUangLain.Text = "0"
        txtUangKeluar.Text = "0"
        txtKomentar.Clear()
        txtAplikasi.Focus()

    End Sub

    Private Sub isiComboBox()
        Dim tblSales As DataTable = Nothing
        Dim tblPos As DataTable = Nothing
        Dim tblCA As DataTable = Nothing
        Dim tblSY As DataTable = Nothing
        Dim tblGender As DataTable = Nothing
        Dim tblPemKota As DataTable = Nothing
        Dim tblPemKec As DataTable = Nothing
        Dim tblPemKel As DataTable = Nothing
        Dim tblPemKer As DataTable = Nothing
        Dim tblPenKota As DataTable = Nothing
        Dim tblPenKec As DataTable = Nothing
        Dim tblPenKel As DataTable = Nothing
        Dim tblPerKota As DataTable = Nothing
        Dim tblPerKec As DataTable = Nothing
        Dim tblPerKel As DataTable = Nothing
        Dim tblKonKota As DataTable = Nothing
        Dim tblKonKec As DataTable = Nothing
        Dim tblKonKel As DataTable = Nothing
        Dim tblBpKot As DataTable = Nothing
        Dim tblBpKec As DataTable = Nothing
        Dim tblBpKel As DataTable = Nothing

        FillCombobox("exec SpEmployee_CBO 'SM'", cmbSalesman, 2, tblSales)
        FillCombobox("exec Sp_Reference_CBO 'POS'", cmbPos, 2, tblPos)
        FillCombobox("exec SpEmployee_CBO 'CA'", cmbCreditAnalyst, 2, tblCA)
        FillCombobox("exec SpEmployee_CBO 'SY'", cmbSurveyor, 2, tblSY)
        FillCombobox("exec Sp_Reference_CBO 'GEN'", cmbPemGender, 2, tblGender)
        FillCombobox("select distinct City from [__AddrLocation] where City like 'JAKARTA%' or City like 'Kepulauan Seribu' order by City asc", cmbPemKota, 1, tblPemKota)
        FillCombobox("select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + cmbPemKota.Text + "' ORDER BY [SubDistrict] ASC", cmbPemKec, 1, tblPemKec)
        FillCombobox("select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbPemKec.Text + "' ORDER BY [Village] ASC", cmbPemKel, 2, tblPemKel)
        FillCombobox("exec Sp_Reference_CBO 'TWC'", txtPemKerja, 2, tblPemKer)
        FillCombobox("select distinct City from [__AddrLocation] where City like 'JAKARTA%' or City like 'Kepulauan Seribu' order by City asc", cmbPenagihanKota, 1, tblPenKota)
        FillCombobox("select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + cmbPenagihanKota.Text + "' ORDER BY [SubDistrict] ASC", cmbPenagihanKec, 1, tblPenKec)
        FillCombobox("select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbPenagihanKec.Text + "' ORDER BY [Village] ASC", cmbPenagihanKel, 2, tblPenKel)
        FillCombobox("select distinct City from [__AddrLocation] where City like 'JAKARTA%' or City like 'Kepulauan Seribu' order by City asc", cmbPerusahaanKota, 1, tblPerKota)
        FillCombobox("select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + cmbPerusahaanKota.Text + "' ORDER BY [SubDistrict] ASC", cmbPerusahaanKec, 1, tblPerKota)
        FillCombobox("select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbPerusahaanKec.Text + "' ORDER BY [Village] ASC", cmbPerusahaanKel, 2, tblPerKel)
        FillCombobox("select distinct City from [__AddrLocation] where City like 'JAKARTA%' or City like 'Kepulauan Seribu' order by City asc", cmbKontakKota, 1, tblKonKota)
        FillCombobox("select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + cmbKontakKota.Text + "' ORDER BY [SubDistrict] ASC", cmbKontakKec, 1, tblKonKec)
        FillCombobox("select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbKontakKec.Text + "' ORDER BY [Village] ASC", cmbKontakKel, 2, tblKonKel)
        FillCombobox("select distinct City from [__AddrLocation] where City like 'JAKARTA%' or City like 'Kepulauan Seribu' order by City asc", cmbBpkbKota, 1, tblBpKot)
        FillCombobox("select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + cmbBpkbKota.Text + "' ORDER BY [SubDistrict] ASC", cmbBpkbKec, 1, tblBpKec)
        FillCombobox("select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbBpkbKec.Text + "' ORDER BY [Village] ASC", cmbBpkbKel, 2, tblBpKel)


    End Sub

    Private Sub ClearForm()
        stateApp = "INS"
        stateMember = "INS"
        begginingState = "AWAL"
        _isRollBackMode = False

        FreshForm()
        Try
            isiComboBox()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        cmbPemGender.SelectedIndex = 0

    End Sub

    Private Sub txtPinjaman_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPinjaman.LostFocus
        txtPinjaman.Text = ribuan(txtPinjaman.Text)
        'txtPremiAdmin.Text = ribuan(Format(((CDbl(txtPokok.Text) * CDbl(txtPremiAsuransi.Text)) / 100) + CDbl(txtAdmin.Text), "#,##0"))
    End Sub

    Private Sub txtPinjaman_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPinjaman.TextChanged
        Try
            If txtAdminKredit.Text = "" Then txtAdminKredit.Text = 0
            'If txtPremiAdmin.Text = "" Then txtPremiAdmin.Text = 0

            If txtAdminKredit.Text <> 0 Then
                HitungPremiAdmin()
            End If

        Catch ex As Exception
            Exit Try
        End Try

        txtAdminMurni.Text = 0
        txtBungaPengali.Text = 0
        txtBungaFlat.Text = 0
        'txtPokok.Clear()
        txtBunga.Text = 0
        txtTotalHutang.Text = 0
        txtAngsuran.Text = 0

    End Sub

    Private Sub txtPremiAsuransi_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPremiAsuransi.TextChanged
        Try
            'txtPremiAdmin.Text = Format(((CDbl(txtPokok.Text) * CDbl(txtPremiAsuransi.Text)) / 100) + CDbl(txtAdmin.Text), "#,##0")
        Catch ex As Exception
            Exit Try
        End Try

        txtAdminMurni.Clear()
        txtBungaPengali.Clear()
        txtBungaFlat.Clear()
        txtPokok.Clear()
        txtBunga.Clear()
        txtTotalHutang.Clear()
        txtAngsuran.Clear()
    End Sub

    Private Sub txtAdmin_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAdmin.LostFocus
        txtAdmin.Text = ribuan(txtAdmin.Text)
    End Sub

    Private Sub txtAdmin_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAdmin.TextChanged

        Try
            'txtPokok.Text = Format(CDbl(txtPinjaman.Text) + CDbl(txtAdminKredit.Text) + CDbl(txtPremiAdmin.Text), "#,##0")
            'txtPremiAdmin.Text = Format(((CDbl(txtPokok.Text) * CDbl(txtPremiAsuransi.Text)) / 100) + CDbl(txtAdmin.Text), "#,##0")
        Catch ex As Exception
            Exit Try
        End Try

        txtAdminMurni.Clear()
        txtBungaPengali.Clear()
        txtBungaFlat.Clear()
        txtPokok.Clear()
        txtBunga.Clear()
        txtTotalHutang.Clear()
        txtAngsuran.Clear()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtPinjaman.Text <> "0" Then

            Dim tempBungaFlat As Double = 0
            Dim tempBungaPengali As Double = 0


            txtAdminMurni.Text = Format(CDbl(txtAdminKredit.Text), "#,##0")
            txtPokok.Text = Format(CDbl(txtPinjaman.Text) + CDbl(txtAdminKredit.Text) + CDbl(txtPremiAdmin.Text), "#,##0")
            'txtPremiAdmin.Text = Format(((CDbl(txtPokok.Text) * CDbl(txtPremiAsuransi.Text)) / 100) + CDbl(txtAdmin.Text), "#,##0")
            ' txtPokok.Text = Format(CDbl(txtPinjaman.Text) + CDbl(txtAdminKredit.Text) + CDbl(txtPremiAdmin.Text), "#,##0")
            tempBungaFlat = ((((CDbl(txtTenor.Text) * (CDbl(txtTingkatBunga.Text) / 1200)) / (1 - (1 + (CDbl(txtTingkatBunga.Text) / 1200)) ^ (-1 * CDbl(txtTenor.Text)))) - 1) * (12 / CDbl(txtTenor.Text))) * 100
            txtBungaFlat.Text = Format(tempBungaFlat, "#,##0.00")
            tempBungaPengali = CDbl(tempBungaFlat) * (CDbl(txtTenor.Text) / 12)
            txtBungaPengali.Text = Format(tempBungaPengali, "#,##0.00")
            txtBunga.Text = Format(CDbl(txtPokok.Text) * CDbl(tempBungaPengali) / 100, "#,##0")
            ' txtBunga.Text = Format(30 / 360 * CDbl(txtPokok.Text) * CDbl(tempBungaPengali) / 100, "#,##0")
            txtTotalHutang.Text = Format(CDbl(txtPokok.Text) + CDbl(txtBunga.Text), "#,##0")
            txtAngsuran.Text = Format(Math.Ceiling(CDbl(txtTotalHutang.Text) / (CDbl(txtTenor.Text) * 1000)) * 1000, "#,##0")
        End If
    End Sub

#Region "keypress"
    Private Sub txtPinjaman_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'If Asc(e.KeyChar) <> 8 Then
        '    If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
        '        e.Handled = True
        '    End If
        'End If
        decimalOnly(sender, e, txtPinjaman.Text)
    End Sub

    Private Sub txtPremiAsuransi_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPremiAsuransi.KeyPress
        'If Asc(e.KeyChar) <> 8 And Asc(e.KeyChar) <> 46 Then

        '    If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
        '        e.Handled = True
        '    End If


        'End If

        decimalOnly(sender, e, txtPremiAsuransi.Text)

        'If Char.IsControl(e.KeyChar) = False Then
        '    If Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Then
        '        If txtPremiAsuransi.Text.Contains(".") Then
        '            If txtPremiAsuransi.Text.Split(".")(1).Length < 2 Then
        '                If Char.IsDigit(e.KeyChar) = False Then
        '                    e.Handled = True
        '                End If
        '            Else
        '                e.Handled = True
        '            End If
        '        End If
        '    Else
        '        e.Handled = True
        '    End If
        'End If

    End Sub

    Private Sub txtAdmin_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAdmin.KeyPress
        decimalOnly(sender, e, txtAdmin.Text)
    End Sub

    Private Sub txtPremiAdmin_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPremiAdmin.KeyPress
        decimalOnly(sender, e, txtPremiAdmin.Text)
    End Sub

    Private Sub txtTenor_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTenor.KeyPress
        decimalOnly(sender, e, txtTenor.Text)
    End Sub

    Private Sub txtTingkatBunga_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTingkatBunga.KeyPress
        decimalOnly(sender, e, txtTingkatBunga.Text)

    End Sub

    Private Sub txtAdminKredit_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAdminKredit.KeyPress
        decimalOnly(sender, e, txtAdminKredit.Text)
    End Sub

    Private Sub txtBungaFlat_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBungaFlat.KeyPress
        decimalOnly(sender, e, txtBungaFlat.Text)
    End Sub

    Private Sub txtBungaPengali_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBungaPengali.KeyPress
        decimalOnly(sender, e, txtBungaPengali.Text)
    End Sub

    Private Sub txtAdminMurni_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAdminMurni.KeyPress
        decimalOnly(sender, e, txtBungaPengali.Text)
    End Sub

    Private Sub txtPokok_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPokok.KeyPress
        decimalOnly(sender, e, txtPokok.Text)
    End Sub

    Private Sub txtBunga_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBunga.KeyPress
        decimalOnly(sender, e, txtBunga.Text)
    End Sub

    Private Sub txtTotalHutang_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTotalHutang.KeyPress
        decimalOnly(sender, e, txtTotalHutang.Text)
    End Sub

    Private Sub txtAngsuran_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAngsuran.KeyPress
        decimalOnly(sender, e, txtAngsuran.Text)
    End Sub


    Private Sub txtUangPemohon_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUangPemohon.KeyPress
        decimalOnly(sender, e, txtUangPemohon.Text)
    End Sub

    Private Sub txtUangLain_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUangLain.KeyPress
        decimalOnly(sender, e, txtUangLain.Text)
    End Sub

    Private Sub txtUangPasangan_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUangPasangan.KeyPress
        decimalOnly(sender, e, txtUangPasangan.Text)
    End Sub

    Private Sub txtUangKeluar_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUangKeluar.KeyPress
        decimalOnly(sender, e, txtUangKeluar.Text)
    End Sub

#End Region

   
    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ' frmTabApp.Show()

        With frmTabApp
            formFlag = "1"
            .txtFlag.Text = "1"
            .Show()

        End With
    End Sub
    Private Sub cmbPenagihanKota_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPenagihanKota.SelectedIndexChanged
        Try
            With cmbPenagihanKec
                .Items.Clear()
                Call conn_open()
                str = "select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + cmbPenagihanKota.Text + "' ORDER BY [SubDistrict] ASC"
                cmd = New SqlCommand(str, conn)
                rdr = cmd.ExecuteReader()

                While rdr.Read()
                    .Items.Add(rdr("SubDistrict"))
                    .SelectedIndex = 0
                End While
                conn.Close()
            End With

            With cmbPenagihanKel

                With tableKodeposPenagihan
                    tableKodeposPenagihan.Rows.Clear()
                    Call conn_open()
                    cmd = New SqlCommand("select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbPenagihanKec.Text + "' ORDER BY [Village] ASC", conn)
                    rdr = cmd.ExecuteReader()
                    While rdr.Read()
                        .Rows.Add(rdr("AddrLocationID"), rdr("Village"))
                    End While
                    conn.Close()
                End With

                .DataSource = tableKodeposPenagihan
                .ValueMember = "ID"
                .DisplayMember = "NAMA"

            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbPenagihanKec_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPenagihanKec.SelectedIndexChanged
        Try
            With cmbPenagihanKel

                With tableKodeposPenagihan
                    tableKodeposPenagihan.Rows.Clear()
                    Call conn_open()
                    cmd = New SqlCommand("select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbPenagihanKec.Text + "' ORDER BY [Village] ASC", conn)
                    rdr = cmd.ExecuteReader()
                    While rdr.Read()
                        .Rows.Add(rdr("AddrLocationID"), rdr("Village"))
                    End While
                    conn.Close()
                End With

                .DataSource = tableKodeposPenagihan
                .ValueMember = "ID"
                .DisplayMember = "NAMA"
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbPerusahaanKota_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPerusahaanKota.SelectedIndexChanged
        Try
            With cmbPerusahaanKec
                .Items.Clear()
                Call conn_open()
                str = "select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + cmbPerusahaanKota.Text + "' ORDER BY [SubDistrict] ASC"
                cmd = New SqlCommand(str, conn)
                rdr = cmd.ExecuteReader()

                While rdr.Read()
                    .Items.Add(rdr("SubDistrict"))
                    .SelectedIndex = 0
                End While
                conn.Close()
            End With

            With cmbPerusahaanKel
                With tableKodeposPerusahaan
                    tableKodeposPerusahaan.Rows.Clear()
                    Call conn_open()
                    cmd = New SqlCommand("select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbPerusahaanKec.Text + "' ORDER BY [Village] ASC", conn)
                    rdr = cmd.ExecuteReader()
                    While rdr.Read()
                        .Rows.Add(rdr("AddrLocationID"), rdr("Village"))
                    End While
                    conn.Close()
                End With

                .DataSource = tableKodeposPerusahaan
                .ValueMember = "ID"
                .DisplayMember = "NAMA"
            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbPerusahaanKec_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPerusahaanKec.SelectedIndexChanged
        Try
            With cmbPerusahaanKel
                With tableKodeposPerusahaan
                    tableKodeposPerusahaan.Rows.Clear()
                    Call conn_open()
                    cmd = New SqlCommand("select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbPerusahaanKec.Text + "' ORDER BY [Village] ASC", conn)
                    rdr = cmd.ExecuteReader()
                    While rdr.Read()
                        .Rows.Add(rdr("AddrLocationID"), rdr("Village"))
                    End While
                    conn.Close()
                End With

                .DataSource = tableKodeposPerusahaan
                .ValueMember = "ID"
                .DisplayMember = "NAMA"
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbKontakKota_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbKontakKota.SelectedIndexChanged
        Try
            With cmbKontakKec
                .Items.Clear()
                Call conn_open()
                str = "select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + cmbKontakKota.Text + "' ORDER BY [SubDistrict] ASC"
                cmd = New SqlCommand(str, conn)
                rdr = cmd.ExecuteReader()

                While rdr.Read()
                    .Items.Add(rdr("SubDistrict"))
                    .SelectedIndex = 0
                End While
                conn.Close()
            End With

            With cmbKontakKel
                With tableKodeposKontak
                    tableKodeposKontak.Rows.Clear()
                    Call conn_open()
                    cmd = New SqlCommand("select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbKontakKec.Text + "' ORDER BY [Village] ASC", conn)
                    rdr = cmd.ExecuteReader()
                    While rdr.Read()
                        .Rows.Add(rdr("AddrLocationID"), rdr("Village"))
                    End While
                    conn.Close()
                End With

                .DataSource = tableKodeposKontak
                .ValueMember = "ID"
                .DisplayMember = "NAMA"
            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbKontakKec_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbKontakKec.SelectedIndexChanged
        Try
            With cmbKontakKel
                With tableKodeposKontak
                    tableKodeposKontak.Rows.Clear()
                    Call conn_open()
                    cmd = New SqlCommand("select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbKontakKec.Text + "' ORDER BY [Village] ASC", conn)
                    rdr = cmd.ExecuteReader()
                    While rdr.Read()
                        .Rows.Add(rdr("AddrLocationID"), rdr("Village"))
                    End While
                    conn.Close()
                End With

                .DataSource = tableKodeposKontak
                .ValueMember = "ID"
                .DisplayMember = "NAMA"
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbBpkbKota_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBpkbKota.SelectedIndexChanged
        Try
            With cmbBpkbKec
                .Items.Clear()
                Call conn_open()
                str = "select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + cmbBpkbKota.Text + "' ORDER BY [SubDistrict] ASC"
                cmd = New SqlCommand(str, conn)
                rdr = cmd.ExecuteReader()

                While rdr.Read()
                    .Items.Add(rdr("SubDistrict"))
                    .SelectedIndex = 0
                End While
                conn.Close()
            End With

            With cmbBpkbKel
                With tableKodeposBpkb
                    tableKodeposBpkb.Rows.Clear()
                    Call conn_open()
                    cmd = New SqlCommand("select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbBpkbKec.Text + "' ORDER BY [Village] ASC", conn)
                    rdr = cmd.ExecuteReader()
                    While rdr.Read()
                        .Rows.Add(rdr("AddrLocationID"), rdr("Village"))
                    End While
                    conn.Close()
                End With

                .DataSource = tableKodeposBpkb
                .ValueMember = "ID"
                .DisplayMember = "NAMA"
            End With


        Catch ex As Exception

        End Try
        chkbox()
    End Sub

    Private Sub cmbBpkbKec_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBpkbKec.SelectedIndexChanged
        Try
            With cmbBpkbKel

                With tableKodeposBpkb
                    tableKodeposBpkb.Rows.Clear()
                    Call conn_open()
                    cmd = New SqlCommand("select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbBpkbKec.Text + "' ORDER BY [Village] ASC", conn)
                    rdr = cmd.ExecuteReader()
                    While rdr.Read()
                        .Rows.Add(rdr("AddrLocationID"), rdr("Village"))
                    End While
                    conn.Close()
                End With

                .DataSource = tableKodeposBpkb
                .ValueMember = "ID"
                .DisplayMember = "NAMA"

            End With
        Catch ex As Exception

        End Try
        chkbox()
    End Sub


    Private Sub txtAplikasi_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAplikasi.TextChanged
        'FreshForm()
        'ClearForm()
        If txtAplikasi.Text.Length = txtAplikasi.MaxLength Then

            StrSQL = ""
            StrSQL = "SELECT * FROM APPLICATION WHERE APPLICATIONID ='" + antisqli(txtAplikasi.Text) + "'"
            RunSQL(StrSQL, 1)
            If dt.Rows.Count > 0 Then
                Dim platno As String = dt.Rows(0)("PlatNo")
                Dim motorprice As String = dt.Rows(0)("Motorprice")
                Dim insurancerate As String = dt.Rows(0)("insurancerate")
                Dim insuranceadmin As String = dt.Rows(0)("insuranceadmin")
                Dim tenor As String = dt.Rows(0)("tenor")
                Dim EffectiveInterestP As String = dt.Rows(0)("EffectiveInterestP")
                Dim loanadmin As String = dt.Rows(0)("LoanAdmin")
                Dim memberid As String = dt.Rows(0)("memberid")
                Dim surveycomment As String = dt.Rows(0)("surveycomment")
                Dim adminpremi As String = dt.Rows(0)("adminpremi")



                ' MessageBox.Show(dt.Rows(0)("platno"))
                stateApp = "UPD"
                _isRollBackMode = True
                If stateApp = "UPD" Then
                    dtTanggal.Text = dt.Rows(0)("ApplicationDate")
                    cmbPos.Text = namePOS(dt.Rows(0)("PosID"))
                    posFlag = True
                    cmbCreditAnalyst.Text = nameCA(dt.Rows(0)("CreditAnalystID"))
                    cmbSurveyor.Text = nameSY(dt.Rows(0)("SurveyorID"))
                    cmbSalesman.Text = nameSM(dt.Rows(0)("SalesManID"))
                    txtKendaraan.Text = dt.Rows(0)("MotorBrand")
                    txtTipe.Text = dt.Rows(0)("motortype")
                    txtWarna.Text = dt.Rows(0)("motorcolor")
                    txtTahun.Text = dt.Rows(0)("MotorYear")
                    txtMesin.Text = dt.Rows(0)("EngineCode")
                    txtRangka.Text = dt.Rows(0)("FrameCode")
                    txtNopol.Text = platno
                    txtPinjaman.Text = ribuan(motorprice)
                    txtPremiAsuransi.Text = insurancerate
                    txtAdmin.Text = insuranceadmin
                    txtTenor.Text = tenor
                    txtTingkatBunga.Text = EffectiveInterestP
                    txtAdminKredit.Text = loanadmin
                    txtPemNo.Text = memberid
                    oldMemberID = memberid
                    txtKomentar.Text = surveycomment
                    txtAdmin.Text = ribuan(txtAdmin.Text)
                    txtAdminKredit.Text = ribuan(txtAdminKredit.Text)
                    txtPremiAdmin.Text = ribuan(adminpremi)
                    Button1.PerformClick()
                End If
            Else
                stateApp = "INS"
            End If
            'Try
            '     Call conn_open()
            '    cmd = New SqlCommand("SELECT*FROM APPLICATION WHERE APPLICATIONID ='" + txtAplikasi.Text + "'", conn)
            '    rdr = cmd.ExecuteReader()

            '    If rdr.HasRows Then
            '        stateApp = "UPD"
            '        _isRollBackMode = True
            '        While rdr.Read()
            '            If stateApp = "UPD" Then
            '                dtTanggal.Text = rdr("ApplicationDate")
            '                cmbPos.Text = namePOS(rdr("PosID"))
            '                posFlag = True
            '                cmbCreditAnalyst.Text = nameCA(rdr("CreditAnalystID"))
            '                cmbSurveyor.Text = nameSY(rdr("SurveyorID"))
            '                cmbSalesman.Text = nameSM(rdr("SalesManID"))
            '                txtKendaraan.Text = rdr("MotorBrand")
            '                txtTipe.Text = rdr("motortype")
            '                txtWarna.Text = rdr("motorcolor")
            '                txtTahun.Text = rdr("MotorYear")
            '                txtMesin.Text = rdr("EngineCode")
            '                txtRangka.Text = rdr("FrameCode")
            '                txtNopol.Text = rdr("platno")
            '                txtPinjaman.Text = rdr("Motorprice")
            '                txtPremiAsuransi.Text = rdr("InsuranceRate")
            '                txtAdmin.Text = rdr("InsuranceAdmin")
            '                txtTenor.Text = rdr("tenor")
            '                txtTingkatBunga.Text = rdr("EffectiveInterestP")
            '                txtAdminKredit.Text = rdr("loanAdmin")
            '                txtPemNo.Text = rdr("MEMBERID")
            '                oldMemberID = rdr("MEMBERID")
            '                txtKomentar.Text = rdr("SurveyComment")


            '                txtAdmin.Text = ribuan(txtAdmin.Text)
            '                txtAdminKredit.Text = ribuan(txtAdminKredit.Text)
            '                Button1.PerformClick()
            '            End If


            '            '    .Items.Add(rdr("EmployeeName"))
            '            '    .SelectedIndex = 0
            '        End While
            '    Else
            '        stateApp = "INS"

            '    End If


            'Catch ex As Exception

            'End Try

            'conn.Close()

        Else
            FreshForm()
            txtPemNo.Text = autoNumberMember(cmbPos.Text)
            ' ClearForm()
            'txtPemNo.Text = autoNumberMember(cmbPos.Text)
        End If
    End Sub

    Private Function namePOS(ByVal kode As String)
        Dim namaPOS As String = ""

        Try
            Call conn_open()
            cmd = New SqlCommand("SELECT ReferenceName from [_Reference] where ReferenceID='" + kode + "'", conn)
            rdr = cmd.ExecuteReader()
            While rdr.Read()
                namaPOS = rdr("ReferenceName")
            End While
            conn.Close()
        Catch ex As Exception

        End Try

        namePOS = namaPOS
    End Function

    Private Function nameCA(ByVal kode As String)
        Dim nama As String = ""
      

        Try
            Call conn_open()
            cmd = New SqlCommand("SELECT EmployeeName from Employee where EmployeeID='" + kode + "'", conn)
            rdr = cmd.ExecuteReader()
            While rdr.Read()
                nama = rdr("EmployeeName")
            End While
            conn.Close()
        Catch ex As Exception

        End Try

        nameCA = nama
    End Function

    Private Function nameSY(ByVal kode As String)
        Dim namaSY As String = ""
     
        Try
            Call conn_open()
            cmd = New SqlCommand("SELECT EmployeeName from Employee where EmployeeID='" + kode + "'", conn)
            rdr = cmd.ExecuteReader()
            While rdr.Read()
                namaSY = rdr("EmployeeName")
            End While
            conn.Close()
        Catch ex As Exception

        End Try

        nameSY = namaSY
    End Function

    Private Function nameSM(ByVal kode As String)
        Dim namaSM As String = ""
     

        Try
            Call conn_open()
            cmd = New SqlCommand("SELECT EmployeeName from Employee where EmployeeID='" + kode + "'", conn)
            rdr = cmd.ExecuteReader()
            While rdr.Read()
                namaSM = rdr("EmployeeName")
            End While
            conn.Close()
        Catch ex As Exception

        End Try

        nameSM = namaSM
    End Function


    Private Sub txtPemNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPemNo.TextChanged
       

        Dim kodepos As String

        Try
            Call conn_open()
            cmd = New SqlCommand("SELECT*FROM MEMBER WHERE MEMBERID='" + txtPemNo.Text + "'", conn)
            rdr = cmd.ExecuteReader()

            If rdr.HasRows Then
                stateMember = "UPD"
                While rdr.Read()
                    txtPemNama.Text = rdr("Membername")
                    txtPemTl.Text = rdr("Birthplace")
                    dtPemTl.Text = rdr("BirthDate")
                    dtPemTl.Format = DateTimePickerFormat.Custom
                    dtPemTl.CustomFormat = "dd/MM/yyyy"
                    txtPemKtp.Text = rdr("PersonalIdentity")
                    txtPemAlamat.Text = rdr("Address")
                    If rdr("GenderID").ToString() = "C5AB75CC" Then
                        cmbPemGender.Text = "Pria"
                    Else
                        cmbPemGender.Text = "Wanita"
                    End If
                    txtPemHp.Text = rdr("Phone1")
                    txtPemTelp1.Text = rdr("Phone2")
                    txtPemTelp2.Text = rdr("Phone3")
                    txtPemRt.Text = rdr("MemberRT")
                    txtPemRw.Text = rdr("MemberRW")
                    txtPemIbu.Text = rdr("MomMaidenName")

                    kodepos = Convert.ToString(rdr("PostalID"))
                    cmbPemKota.Text = fillKota(kodepos, 1)
                    cmbPemKec.Text = fillKecamatan(kodepos, cmbPemKota.Text, 1)
                    cmbPemKel.Text = fillKelurahan(kodepos, cmbPemKec.Text, 1, tableKodeposPemohon)

                    txtPenagihanAlamat.Text = rdr("BillingAddress")

                    kodepos = Convert.ToString(rdr("BillingPostalID"))
                    cmbPenagihanKota.Text = fillKota(kodepos, 2)
                    cmbPenagihanKec.Text = fillKecamatan(kodepos, cmbPenagihanKota.Text, 2)
                    cmbPenagihanKel.Text = fillKelurahan(kodepos, cmbPenagihanKec.Text, 2, tableKodeposPenagihan)
                    'ChangedKelurahan(cmbPenagihanKel, cmbPenagihanKec.Text, tableKodeposPenagihan)

                    txtPenagihanRt.Text = rdr("BillingRT")
                    txtPenagihanRw.Text = rdr("BillingRW")
                    txtPerusahaanNama.Text = rdr("CompName")
                    txtPerusahaanJabatan.Text = rdr("CompPosition")
                    txtPerusahaanMasa.Text = rdr("CompWorkTime")
                    txtPerusahaanAlamat.Text = rdr("CompAddress")

                    kodepos = Convert.ToString(rdr("CompPostalID"))
                    cmbPerusahaanKota.Text = fillKota(kodepos, 3)
                    cmbPerusahaanKec.Text = fillKecamatan(kodepos, cmbPerusahaanKota.Text, 3)
                    cmbPerusahaanKel.Text = fillKelurahan(kodepos, cmbPerusahaanKec.Text, 3, tableKodeposPerusahaan)
                    'ChangedKelurahan(cmbPerusahaanKel, cmbPerusahaanKec.Text, tableKodeposPerusahaan)

                    txtPerusahaanRt.Text = rdr("CompRT")
                    txtPerusahaanRw.Text = rdr("CompRW")
                    txtPerusahaanTelp.Text = rdr("CompPhone")
                    txtKontakNama.Text = rdr("EmerName")
                    txtKontakAlamat.Text = rdr("EmerAddress")


                    kodepos = Convert.ToString(rdr("EmerPostalID"))
                    cmbKontakKota.Text = fillKota(kodepos, 4)
                    cmbKontakKec.Text = fillKecamatan(kodepos, cmbKontakKota.Text, 4)
                    cmbKontakKel.Text = fillKelurahan(kodepos, cmbKontakKec.Text, 4, tableKodeposKontak)
                    'ChangedKelurahan(cmbKontakKel, cmbKontakKec.Text, tableKodeposKontak)

                    txtKontakRt.Text = rdr("EmerRT")
                    txtKontakRw.Text = rdr("EmerRW")
                    txtKontakTelp.Text = rdr("EmerPhone")
                    txtBpkbNama.Text = rdr("bpkbName")
                    txtBpkbAlamat.Text = rdr("bpkbAddress")
                    txtKontakHubungan.Text = rdr("EmerRelations")

                    kodepos = Convert.ToString(rdr("BpkbPostalID"))
                    cmbBpkbKota.Text = fillKota(kodepos, 5)
                    cmbBpkbKec.Text = fillKecamatan(kodepos, cmbBpkbKota.Text, 5)
                    cmbBpkbKel.Text = fillKelurahan(kodepos, cmbBpkbKec.Text, 5, tableKodeposBpkb)
                    'ChangedKelurahan(cmbBpkbKel, cmbBpkbKec.Text, tableKodeposBpkb)

                    txtBpkbRt.Text = rdr("bpkbRT")
                    txtBpkbRw.Text = rdr("BpkbRW")
                    txtUangPemohon.Text = rdr("Income")
                    txtUangPasangan.Text = rdr("SpouseIncome")
                    txtUangLain.Text = rdr("OtherIncome")
                    txtUangKeluar.Text = rdr("Expense")

                    txtUangPemohon.Text = ribuan(txtUangPemohon.Text)
                    txtUangPasangan.Text = ribuan(txtUangPasangan.Text)
                    txtUangLain.Text = ribuan(txtUangLain.Text)
                    txtUangKeluar.Text = ribuan(txtUangKeluar.Text)

                    chkbox()



                End While
            End If

           
        Catch ex As Exception

        End Try

    End Sub


    Private Function fillKota(ByVal kodepos As String, ByVal Flag As Integer)
        Dim hasil As String = ""

        Call conn_open()

        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader



        Try

            cmd = New SqlCommand("SELECT [City] FROM __AddrLocation WHERE AddrLocationID='" + kodepos & "'", conn)
            rdr = cmd.ExecuteReader()

            While rdr.Read()

                hasil = Convert.ToString(rdr("City"))
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        conn.Close()
        Return hasil
    End Function

    Private Function fillKecamatan(ByVal kodepos As String, ByVal city As String, ByVal Flag As Integer)
        Dim hasil As String = ""



        Dim objek As ComboBox = New ComboBox

        If Flag = 1 Then
            objek = cmbPemKec
        ElseIf Flag = 2 Then
            objek = cmbPenagihanKec
        ElseIf Flag = 3 Then
            objek = cmbPerusahaanKec
        ElseIf Flag = 4 Then
            objek = cmbKontakKec
        ElseIf Flag = 5 Then
            objek = cmbBpkbKec
        End If

        With objek
            Try
                .Items.Clear()
                Call conn_open()
                cmd = New SqlCommand("SELECT DISTINCT SubDistrict FROM __AddrLocation Where City='" + city + "'", conn)
                rdr = cmd.ExecuteReader()

                While rdr.Read()
                    .Items.Add(rdr("SubDistrict"))
                End While
            Catch ex As Exception
                conn.Close()
            End Try
            conn.Close()
        End With


        Try
            Call conn_open()
            cmd = New SqlCommand("SELECT [SubDistrict] FROM __AddrLocation WHERE AddrLocationID='" + kodepos + "'", conn)
            rdr = cmd.ExecuteReader()



            While rdr.Read()

                hasil = Convert.ToString(rdr("SubDistrict"))
            End While
        Catch ex As Exception
            conn.Close()
        End Try
        conn.Close()
        Return hasil
    End Function
    Private Function fillKelurahan(ByVal kodepos As String, ByVal subdistrict As String, ByVal Flag As Integer, ByVal table As DataTable)
        Dim hasil As String = ""

        Dim objek As ComboBox = New ComboBox

        If Flag = 1 Then
            objek = cmbPemKel
        ElseIf Flag = 2 Then
            objek = cmbPenagihanKel
        ElseIf Flag = 3 Then
            objek = cmbPerusahaanKel
        ElseIf Flag = 4 Then
            objek = cmbKontakKel
        ElseIf Flag = 5 Then
            objek = cmbBpkbKel
        End If

        With objek
            'Try
            '    conn3.Open()
            '    cmd3 = New SqlCommand("SELECT DISTINCT Village FROM __AddrLocation Where Subdistrict='" + subdistrict + "'", conn3)
            '    rdr3 = cmd3.ExecuteReader()

            '    While rdr3.Read()
            '        .Items.Add(rdr3("Village"))

            '    End While
            'Catch ex As Exception
            '    conn3.Close()
            'End Try
            'conn3.Close()
            Try


                With table
                    .Clear()
                    Call conn_open()
                    testString = "select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" & subdistrict & "' ORDER BY [Village] ASC"
                    cmd = New SqlCommand(testString, conn)
                    'txtKomentar.Text = testString
                    rdr = cmd.ExecuteReader()
                    While rdr.Read()
                        .Rows.Add(rdr("AddrLocationID"), rdr("Village"))
                    End While

                End With
                conn.Close()
                .DataSource = table
                .ValueMember = "ID"
                .DisplayMember = "NAMA"
            Catch ex As Exception

            End Try

        End With



        Try
            Call conn_open()
            cmd = New SqlCommand("SELECT [Village] FROM __AddrLocation WHERE AddrLocationID='" + kodepos + "'", conn)
            rdr = cmd.ExecuteReader()

            While rdr.Read()

                hasil = Convert.ToString(rdr("Village"))
            End While
        Catch ex As Exception
            conn.Close()
        End Try
        conn.Close()
        Return hasil
    End Function
    'Private Sub Member_LOA()
    '    Dim _dtLOA As DataTable

    '    Dim conn2 As New SqlConnection(strconn)
    '    Dim cmd2 As SqlCommand
    '    Dim rdr2 As SqlDataReader

    '    Try
    '        conn2.Open()
    '        cmd2 = New SqlCommand("EXEC SpMember_LOA '" + txtPemNo.Text + "'", conn2)
    '        rdr2 = cmd2.ExecuteReader()

    '        while 
    '    Catch ex As Exception

    '    End Try

    'End Sub

    Private Sub isiCombo()


        Dim strCombo As String = ""

        With cmbPemKec
            Call conn_open()
            strCombo = "select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + cmbPemKota.Text + "' ORDER BY [SubDistrict] ASC"
            cmd = New SqlCommand(strCombo, conn)
            rdr = cmd.ExecuteReader()

            While rdr.Read()
                .Items.Add(rdr("SubDistrict"))

            End While
            conn.Close()

        End With

        With cmbPemKel

            With tableKodeposPemohon
                tableKodeposPemohon.Rows.Clear()
                Call conn_open()
                cmd = New SqlCommand("select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbPemKec.Text + "' ORDER BY [Village] ASC", conn)
                rdr = cmd.ExecuteReader()
                While rdr.Read()
                    .Rows.Add(rdr("AddrLocationID"), rdr("Village"))
                End While
                conn.Close()
            End With

            .DataSource = tableKodeposPemohon
            .ValueMember = "ID"
            .DisplayMember = "NAMA"

        End With

    End Sub

    Private Sub cmbPemKota_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPemKota.SelectedIndexChanged
        Try
            With cmbPemKec
                .Items.Clear()
                Call conn_open()
                str = "select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + cmbPemKota.Text + "' ORDER BY [SubDistrict] ASC"
                cmd = New SqlCommand(str, conn)
                rdr = cmd.ExecuteReader()

                While rdr.Read()
                    .Items.Add(rdr("SubDistrict"))
                    .SelectedIndex = 0
                End While
                conn.Close()
            End With

            With cmbPemKel

                With tableKodeposPemohon
                    tableKodeposPemohon.Rows.Clear()
                    Call conn_open()
                    cmd = New SqlCommand("select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbPemKec.Text + "' ORDER BY [Village] ASC", conn)
                    rdr = cmd.ExecuteReader()
                    While rdr.Read()
                        .Rows.Add(rdr("AddrLocationID"), rdr("Village"))
                    End While
                    conn.Close()
                End With

                .DataSource = tableKodeposPemohon
                .ValueMember = "ID"
                .DisplayMember = "NAMA"

            End With


        Catch ex As Exception

        End Try

        chkbox()
    End Sub

    Private Sub cmbPemKec_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPemKec.SelectedIndexChanged
        Try
            With cmbPemKel

                With tableKodeposPemohon
                    tableKodeposPemohon.Rows.Clear()
                    Call conn_open()
                    cmd = New SqlCommand("select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbPemKec.Text + "' ORDER BY [Village] ASC", conn)
                    rdr = cmd.ExecuteReader()
                    While rdr.Read()
                        .Rows.Add(rdr("AddrLocationID"), rdr("Village"))
                    End While
                    conn.Close()
                End With

                .DataSource = tableKodeposPemohon
                .ValueMember = "ID"
                .DisplayMember = "NAMA"

            End With

        Catch ex As Exception

        End Try

        chkbox()
    End Sub

    Private Sub cmbPenagihanKota_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPenagihanKota.TextChanged

    End Sub

    Private Sub cmbPemKota_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPemKota.TextChanged

        Dim str4 As String = ""
        Try
            With cmbPemKec
                .Items.Clear()
                Call conn_open()
                str4 = "select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + cmbPemKota.Text + "' ORDER BY [SubDistrict] ASC"
                cmd = New SqlCommand(str4, conn)
                rdr = cmd.ExecuteReader()

                While rdr.Read()
                    .Items.Add(rdr("SubDistrict"))

                End While
                conn.Close()
            End With

            With cmbPemKel

                With tableKodeposPemohon
                    tableKodeposPemohon.Rows.Clear()
                    Call conn_open()
                    cmd = New SqlCommand("select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbPemKec.Text + "' ORDER BY [Village] ASC", conn)
                    rdr = cmd.ExecuteReader()
                    While rdr.Read()
                        .Rows.Add(rdr("AddrLocationID"), rdr("Village"))
                    End While
                    conn.Close()
                End With

                .DataSource = tableKodeposPemohon
                .ValueMember = "ID"
                .DisplayMember = "NAMA"

            End With


        Catch ex As Exception

        End Try
    End Sub

    Private Function VcAplikasi() As Boolean
        Dim hasil As Boolean = True

        If _isRollBackMode = True Then
            If txtAplikasi.Text <> noAplikasi Then
                alertmsg = "No Aplikasi Tidak Sesuai Ketentuan"
                txtAplikasi.Focus()
                hasil = False
            End If
        End If
        


        If txtKendaraan.Text = "" Then
            alertmsg = "Jenis Kendaraan Tidak Boleh Kosong"
            txtKendaraan.Focus()
            hasil = False
        ElseIf txtTipe.Text = "" Then
            alertmsg = "Tipe Kendaraan Tidak Boleh Kosong"
            txtTipe.Focus()
            hasil = False
        ElseIf txtWarna.Text = "" Then
            alertmsg = "Warna Kendaraan Tidak Boleh Kosong"
            txtWarna.Focus()
            hasil = False
        ElseIf txtTahun.Text = "" Then
            alertmsg = "Tahun Kendaraan Tidak Boleh Kosong "
            txtTahun.Focus()
            hasil = False
        ElseIf txtMesin.Text = "" Then
            alertmsg = "Nomor Mesin Tidak Boleh Kosong"
            txtMesin.Focus()
            hasil = False
        ElseIf txtRangka.Text = "" Then
            alertmsg = "Nomor Rangka Tidak Boleh Kosong"
            txtRangka.Focus()
            hasil = False
        ElseIf txtNopol.Text = "" Then
            alertmsg = "Nomor Plat Tidak Boleh Kosong"
            txtNopol.Focus()
            hasil = False
        ElseIf txtPinjaman.Text < 0 Then
            alertmsg = "Pinjaman Tidak Boleh Minus"
            txtPinjaman.Focus()
            hasil = False
        ElseIf txtPremiAsuransi.Text < 0 Then
            alertmsg = "Premi Asuransi Tidak Boleh Minus"
            txtPremiAsuransi.Focus()
            hasil = False
        ElseIf txtAdmin.Text < 0 Then
            alertmsg = "Admin Tidak Boleh Minus"
            txtAdmin.Focus()
            hasil = False
        ElseIf txtPremiAdmin.Text < 0 Then
            alertmsg = "Premi + Admin Tidak Boleh Minus"
            txtPremiAdmin.Focus()
            hasil = False
        ElseIf txtPemNo.Text = "" Then
            alertmsg = "Nomor Anggota Tidak Boleh Kosong"
            txtPemNo.Focus()
            hasil = False
        ElseIf txtPemNama.Text = "" Then
            alertmsg = "Nama Anggota Tidak Boleh Kosong"
            txtPemNama.Focus()
            hasil = False
        ElseIf txtPemTl.Text = "" Then
            alertmsg = "Tempat Lahir Anggota Tidak Boleh Kosong"
            txtPemTl.Focus()
            hasil = False
        ElseIf dtPemTl.Text = "" Then
            alertmsg = "Tanggal Lahir Anggota Tidak Boleh Kosong"
            dtPemTl.Focus()
            hasil = False
        ElseIf txtPemKtp.Text = "" Then
            alertmsg = "Nomor KTP Anggota Tidak Boleh Kosong"
            txtRangka.Focus()
            hasil = False
        ElseIf txtPemAlamat.Text = "" Then
            alertmsg = "Alamat Anggota Tidak Boleh Kosong"
            txtPemAlamat.Focus()
            hasil = False
        ElseIf txtPemRt.Text = "" Then
            alertmsg = "Nomor RT Anggota Tidak Boleh Kosong"
            txtPemRt.Focus()
            hasil = False
        ElseIf txtPemRw.Text = "" Then
            alertmsg = "Nomor RW Anggota Tidak Boleh Kosong"
            txtPemRw.Focus()
            hasil = False
        ElseIf txtPemHp.Text = "" Then
            alertmsg = "Nomor Handphone Anggota Tidak Boleh Kosong"
            txtPemHp.Focus()
            hasil = False
        ElseIf txtPemIbu.Text = "" Then
            alertmsg = "Nama Ibu Anggota Tidak Boleh Kosong"
            txtPemIbu.Focus()
            hasil = False
        ElseIf txtPenagihanAlamat.Text = "" Then
            alertmsg = "Alamat Penagihan Tidak Boleh Kosong"
            txtPenagihanAlamat.Focus()
            hasil = False
        ElseIf txtPenagihanRt.Text = "" Then
            alertmsg = "Nomor RT Alamat Penagihan Tidak Boleh Kosong"
            txtPenagihanRt.Focus()
            hasil = False
        ElseIf txtPenagihanRw.Text = "" Then
            alertmsg = "Nomor RW Alamat Penagihan Tidak Boleh Kosong"
            txtPenagihanRw.Focus()
            hasil = False
        ElseIf txtPerusahaanNama.Text = "" Then
            alertmsg = "Nama Perusahaan Tidak Boleh Kosong"
            txtPerusahaanNama.Focus()
            hasil = False
        ElseIf txtPerusahaanJabatan.Text = "" Then
            alertmsg = "Jabatan Tidak Boleh Kosong"
            txtPerusahaanJabatan.Focus()
            hasil = False
        ElseIf txtPerusahaanMasa.Text = "" Then
            alertmsg = "Masa Jabatan Tidak Boleh Kosong"
            txtPerusahaanMasa.Focus()
            hasil = False
        ElseIf txtPerusahaanAlamat.Text = "" Then
            alertmsg = "Alamat Perusahaan Tidak Boleh Kosong"
            txtPerusahaanAlamat.Focus()
            hasil = False
        ElseIf txtPerusahaanRt.Text = "" Then
            alertmsg = "Nomor RT Perusahaan Tidak Boleh Kosong"
            txtPerusahaanRt.Focus()
            hasil = False
        ElseIf txtPerusahaanRw.Text = "" Then
            alertmsg = "Nomor RW Perusahaan Tidak Boleh Kosong"
            txtPerusahaanRw.Focus()
            hasil = False
        ElseIf txtBpkbNama.Text = "" Then
            alertmsg = "Nama Pemilik BPKB Tidak Boleh Kosong"
            txtBpkbNama.Focus()
            hasil = False
        ElseIf txtBpkbAlamat.Text = "" Then
            alertmsg = "Alamat Pada BPKB Tidak Boleh Kosong"
            txtBpkbAlamat.Focus()
            hasil = False
        ElseIf txtBpkbRt.Text = "" Then
            alertmsg = "Nomor RT pada BPKB Tidak Boleh Kosong"
            txtBpkbRt.Focus()
            hasil = False
        ElseIf txtBpkbRw.Text = "" Then
            alertmsg = "Nomor RW Pada BPKB Tidak Boleh Kosong"
            txtBpkbRw.Focus()
            hasil = False
        ElseIf txtUangPemohon.Text = "" Then
            alertmsg = "Penghasilan Anggota Tidak Boleh Kosong"
            txtUangPemohon.Focus()
            hasil = False
        ElseIf txtUangPasangan.Text = "" Then
            alertmsg = "Penghasilan Pasangan Anggota Tidak Boleh Kosong"
            txtUangPasangan.Focus()
            hasil = False
        ElseIf txtUangLain.Text = "" Then
            alertmsg = "Penghasilan Lain Anggota Tidak Boleh Kosong"
            txtUangLain.Focus()
            hasil = False
        ElseIf txtUangKeluar.Text = "" Then
            alertmsg = "Pengeluaran Anggota Tidak Boleh Kosong"
            txtUangKeluar.Focus()
            hasil = False
        ElseIf txtKomentar.Text = "" Then
            alertmsg = "Komentar Survey Tidak Boleh Kosong"
            txtKomentar.Focus()
            hasil = False
        Else
            hasil = True
            alertmsg = "Data berhasil ditambahkan"
        End If


        Return hasil
    End Function

    Private Sub btnApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprove.Click, btnReject.Click
        Dim _IsApprv As Boolean = False

        If sender.Name = "btnApprove" Then
            _IsApprv = True
        End If

        If VcAplikasi() = True Then
            '
            If _isRollBackMode Then
                Application_SAV("UPD", txtPemNo.Text, _IsApprv)
                Member_SAV("UPD")
            Else
                Application_SAV("INS", txtPemNo.Text, _IsApprv)
                Member_SAV("INS")
            End If
            MessageBox.Show(alertmsg, "Sukses!", MessageBoxButtons.OK, MessageBoxIcon.Information)

            If sender.Name = "btnApprove" Then
                tempTandaTerimaUang()
                tempTandaTerimaBpkb()
                MultiReportView.Show()

            ElseIf sender.Name = "btnReject" Then

            End If

         
            ClearForm()
            txtAplikasi.Text = autoNumber(cmbPos.Text)
            txtPemNo.Text = autoNumberMember(cmbPos.Text)

        Else
            MessageBox.Show(alertmsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If


       

    End Sub
    Private Sub Application_SAV(ByVal _InsUpd As String, ByVal _MemberID As String, ByVal _IsApprv As Boolean)
        ' If _InsUpd = "INS" Then _ApplicationID = gGUID(11)

        StrSQL = "SpApplication_SAV '" & _InsUpd & "', "
        StrSQL &= "'" & txtAplikasi.Text & "', "
        StrSQL &= "'" & dtTanggal.Value.ToString("yyyyMMdd") & "', "
        StrSQL &= "'" & cmbPos.SelectedValue & "', "
        StrSQL &= "'" & cmbCreditAnalyst.SelectedValue & "', "
        StrSQL &= "'" & cmbSurveyor.SelectedValue & "', "
        StrSQL &= "'" & cmbSalesman.SelectedValue & "', "
        StrSQL &= "'1', "
        StrSQL &= "'" & txtTenor.Text & "', "
        StrSQL &= CInt(txtTingkatBunga.Text) & ", "
        StrSQL &= CDbl(txtPinjaman.Text) & ", "
        StrSQL &= "0, "
        StrSQL &= "0, " 'CDbl(DownPayment.Text) & ", "
        StrSQL &= CDbl(txtPremiAsuransi.Text) & ", "
        StrSQL &= CDbl(txtAdminKredit.Text) & ", "
        StrSQL &= "0, " 'CDbl(DealerSubs.Text) & ", "
        StrSQL &= "0, "
        StrSQL &= CDbl(txtAdmin.Text) & ", "
        StrSQL &= "'" & txtKendaraan.Text & "', "
        StrSQL &= "'" & txtTipe.Text & "', "
        StrSQL &= "'" & txtWarna.Text & "', "
        StrSQL &= "'" & txtTahun.Text & "', "
        StrSQL &= "'" & _MemberID & "', "
        StrSQL &= IIf(_IsApprv, 1, 0) & ", "
        StrSQL &= "'" & txtKomentar.Text & "',"
        StrSQL &= "'',"
        StrSQL &= CDbl(txtPokok.Text) & ", "
        StrSQL &= CDbl(txtAngsuran.Text) & ", "
        StrSQL &= "'', "
        StrSQL &= "'" & txtBpkb.Text & "',"
        StrSQL &= "'" & txtRangka.Text & "',"
        StrSQL &= "'" & txtMesin.Text & "',"
        StrSQL &= "'" & txtNopol.Text & "',"
        StrSQL &= "'" & oldAppID & "',"
        StrSQL &= "" & CStr(Replace(txtPremiAdmin.Text, ",", "")) & ","
        StrSQL &= "" & CStr(Replace(txtBungaPengali.Text, ",", "")) & ","
        StrSQL &= "" & CStr(Replace(txtPokok.Text, ",", "")) & ","
        StrSQL &= "" & CStr(Replace(txtBunga.Text, ",", "")) & ""

        RunSQL(StrSQL, 0)
    End Sub


    Private Sub Member_SAV(ByVal _InsUpd As String)
        'If _InsUpd = "INS" Then _MemberID = gGUID(16)

        StrSQL = "SpMember_SAV '" & _InsUpd & "', "
        StrSQL &= "'" & txtPemNo.Text & "', "
        StrSQL &= "'" & txtPemNama.Text & "', "
        StrSQL &= "'" & cmbSalesman.SelectedValue & "', "
        StrSQL &= "'" & cmbPemGender.SelectedValue & "', "
        StrSQL &= "'" & dtPemTl.Value.ToString("yyyyMMdd") & "', "
        StrSQL &= "'" & txtPemTl.Text & "', "
        StrSQL &= "'" & txtPemKtp.Text & "', "
        StrSQL &= "'" & txtPemAlamat.Text & "', "
        StrSQL &= "'" & txtPemRt.Text & "', "
        StrSQL &= "'" & txtPemRw.Text & "', "
        StrSQL &= "'" & cmbPemKel.SelectedValue & "', "
        StrSQL &= "'" & txtPemHp.Text & "', "
        StrSQL &= "'" & txtPemTelp1.Text & "', "
        StrSQL &= "'" & txtPemTelp2.Text & "', "
        StrSQL &= "'" & txtPemIbu.Text & "', "
        StrSQL &= "'" & txtPemKerja.SelectedValue & "', "
        StrSQL &= "'" & txtPerusahaanNama.Text & "', "
        StrSQL &= "'" & txtPerusahaanJabatan.Text & "', "
        StrSQL &= txtPerusahaanMasa.Text & ", "
        StrSQL &= "'" & txtPerusahaanAlamat.Text & "', "
        StrSQL &= "'" & txtPerusahaanRt.Text & "', "
        StrSQL &= "'" & txtPerusahaanRw.Text & "', "
        StrSQL &= "'" & cmbPerusahaanKel.SelectedValue & "', "
        StrSQL &= "'" & txtPerusahaanTelp.Text & "', "
        StrSQL &= "'" & txtKontakNama.Text & "', "
        StrSQL &= "'" & txtKontakAlamat.Text & "', "
        StrSQL &= "'" & txtKontakRt.Text & "', "
        StrSQL &= "'" & txtKontakRw.Text & "', "
        StrSQL &= "'" & cmbKontakKel.SelectedValue & "', "
        StrSQL &= "'" & txtKontakTelp.Text & "', "
        StrSQL &= "'" & txtKontakHubungan.Text & "', "
        StrSQL &= "'" & txtBpkbNama.Text & "', "
        StrSQL &= "'" & txtBpkbAlamat.Text & "', "
        StrSQL &= "'" & txtBpkbRt.Text & "', "
        StrSQL &= "'" & txtBpkbRw.Text & "', "
        StrSQL &= "'" & cmbBpkbKel.SelectedValue & "', "
        StrSQL &= "'" & txtPenagihanAlamat.Text & "', "
        StrSQL &= "'" & txtPenagihanRt.Text & "', "
        StrSQL &= "'" & txtPenagihanRw.Text & "', "
        StrSQL &= "'" & cmbPenagihanKel.SelectedValue & "', "
        StrSQL &= CDbl(txtUangPemohon.Text) & ", "
        StrSQL &= CDbl(txtUangPasangan.Text) & ", "
        StrSQL &= CDbl(txtUangLain.Text) & ", "
        StrSQL &= CDbl(txtUangKeluar.Text) & ", "
        StrSQL &= "'" & oldMemberID & "' "

        Try
            Call conn_open()
            cmd = New SqlCommand(StrSQL, conn)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            conn.Close()
        End Try
        conn.Close()
        'RunSQL(StrSQL, 0)
        'MessageBox.Show(StrSQL)
        'txtKomentar.Text = StrSQL
    End Sub

  


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        frmTabMem.Show()
        formFlag = 1
    End Sub

    Private Sub PrintTandaTerimaUang()

        Try
            Call connRep_open()
            StrSQL = "SELECT * FROM TTU where ApplicationID='" & txtAplikasi.Text & "'"
            cmd = New SqlCommand(StrSQL, conn)
            da = New SqlDataAdapter(cmd)
            da.Fill(ds, "TandaTerimaUang")

        Catch ex As Exception

        End Try
        conn.Close()
        RepName = "TandaTerimaUang"
        'RepName2 = "../Rpt/rptTandaTerimaUang.rpt"

        strReportPath = Application.StartupPath & "\Report\" & RepName & ".rpt"
        'strReportPath = App_Path & "\rpt\" & RepName & ".rpt"
        If Not IO.File.Exists(strReportPath) Then
            Throw (New Exception("Unable to locate report file:" & vbCrLf & strReportPath))
        End If
        Dim rptDocument As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim paramV As CrystalDecisions.Shared.ParameterValues
        Dim paramDValue As CrystalDecisions.Shared.ParameterDiscreteValue

        'rptDocument.Load(strReportPath)

        rptDocument.Load(strReportPath)

        rptDocument.SetDataSource(dsRep)
        rptDocument.Refresh()
        paramV = New CrystalDecisions.Shared.ParameterValues
        paramDValue = New CrystalDecisions.Shared.ParameterDiscreteValue
        paramDValue.Value = Terbilang(CDbl(txtPinjaman.Text))
        paramV.Add(paramDValue)
        'rptDocument.SetParameterValue("terbilang", Terbilang(CDbl(txtPinjaman.Text)))
        rptDocument.ParameterFields.Item("terbilang").CurrentValues = paramV
        rptDocument.ParameterFields.Item("terbilang").HasCurrentValue = True
        rptDocument.SetDatabaseLogon(repUser, repPwd)
        With MultiReportView
            .CRViewer1.DisplayToolbar = True
            .CRViewer1.ReportSource = rptDocument
        End With


        ''MessageBox.Show(strReportPath)

    End Sub

    Private Sub tempTandaTerimaUang()
        Dim tanggal As String = "1"

        tanggal = Convert.ToString(dtTanggal.Value.Day)
        Try
            StrSQL = "INSERT INTO TTU VALUES (" & CDbl(txtPinjaman.Text) & ",'" & txtAplikasi.Text & "'"
            StrSQL &= ",'" & txtPemNama.Text & "','" & txtPemAlamat.Text & "'"
            StrSQL &= ",'" & txtTenor.Text & "'," & CDbl(txtAngsuran.Text) & ",'" & tanggal & "')"
            Call connRep_open()
            cmd = New SqlCommand(StrSQL, conn)
            cmd.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception

        End Try

        PrintTandaTerimaUang()
    End Sub

    Private Sub tempTandaTerimaBpkb()
        Dim tanggal2 As String = "1"

        tanggal2 = Convert.ToString(dtTanggal.Value.Day)
        Try
            StrSQL = "INSERT INTO TandaTerimaBpkb VALUES ('" & txtPemNama.Text & "','" & txtBpkbNama.Text & "'"
            StrSQL &= ",'" & txtAplikasi.Text & "','" & txtMesin.Text & "'"
            StrSQL &= ",'" & txtRangka.Text & "','" & txtNopol.Text & "')"
            Call connRep_open()
            cmd = New SqlCommand(StrSQL, conn)
            cmd.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception

        End Try

        PrintTandaTerimaBpkb()
    End Sub

    Private Sub PrintTandaTerimaBpkb()

        Try
            StrSQL = "SELECT * FROM TandaTerimaBpkb where ApplicationID='" & txtAplikasi.Text & "'"

            cmd = New SqlCommand(StrSQL, conn)
            da = New SqlDataAdapter(cmd)
            Call connRep_open()
            da.Fill(ds, "TandaTerimaBpkb")

        Catch ex As Exception

        End Try
        conn.Close()
        RepName2 = "TandaTerimaBpkb"
        'RepName2 = "../Rpt/rptTandaTerimaUang.rpt"

        strReportPath2 = Application.StartupPath & "\Report\" & RepName2 & ".rpt"
        'strReportPath = App_Path & "\rpt\" & RepName & ".rpt"
        If Not IO.File.Exists(strReportPath2) Then
            Throw (New Exception("Unable to locate report file:" & vbCrLf & strReportPath2))
        End If
        Dim rptDocument2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument


        'rptDocument.Load(strReportPath)
        rptDocument2.Load(strReportPath2)
        rptDocument2.SetDataSource(dsRep2)
        'rptDocument.SetParameterValue("Terbilang", Terbilang(CDbl(txtPinjaman.Text)))
        rptDocument2.SetDatabaseLogon(repUser2, repPwd2)
        With MultiReportView
            .CRViewer2.ReportSource = rptDocument2
            .CRViewer2.DisplayToolbar = True
        End With


        ''MessageBox.Show(strReportPath)
        ' ReportView.Show()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        frmDana.Close()
    End Sub

    Private Sub ckBpkb_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckBpkb.CheckedChanged
        Dim item As String = ""
        Dim item2 As String = ""
        If ckBpkb.Checked = True Then
            txtBpkbNama.Text = txtPemNama.Text
            txtBpkbAlamat.Text = txtPemAlamat.Text
            txtBpkbRt.Text = txtPemRt.Text
            txtBpkbRw.Text = txtPemRw.Text
            cmbBpkbKel.DataSource = cmbPemKel.DataSource
            cmbBpkbKel.Text = cmbPemKel.Text
            cmbBpkbKota.Text = cmbPemKota.Text
            cmbBpkbKec.Text = cmbPemKec.Text
        End If
    End Sub

    Private Sub chkbox()
        If txtPemNama.Text = txtBpkbNama.Text And txtPemAlamat.Text = txtBpkbAlamat.Text And txtPemRt.Text = txtBpkbRt.Text And txtPemRw.Text = txtBpkbRw.Text Then
            ckBpkb.Checked = True
        Else
            ckBpkb.Checked = False

        End If
    End Sub

    Private Sub txtPemNama_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPemNama.TextChanged
        chkbox()
    End Sub

    Private Sub txtBpkbNama_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBpkbNama.TextChanged
        chkbox()
    End Sub

    Private Sub cmbPos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPos.SelectedIndexChanged
        If stateApp = "INS" And begginingState = "UBAH" Then
            txtAplikasi.Text = autoNumber(cmbPos.Text)
            txtPemNo.Text = autoNumberMember(cmbPos.Text)
        End If

        If stateApp = "UPD" And posFlag = True Then
            txtAplikasi.Text = autoNumber(cmbPos.Text)
            txtPemNo.Text = autoNumberMember(cmbPos.Text)
        End If
    End Sub

   
    Private Sub txtTenor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTenor.LostFocus
        Dim tnr As New Integer
        tnr = Convert.ToInt32(txtTenor.Text)
        If tnr >= 1 And tnr <= 12 Then
            txtPremiAsuransi.Text = "2.5"
        ElseIf tnr >= 13 And tnr <= 18 Then
            txtPremiAsuransi.Text = "3.56"
        ElseIf tnr >= 19 And tnr <= 24 Then
            txtPremiAsuransi.Text = "4.63"
        ElseIf tnr >= 25 And tnr <= 30 Then
            txtPremiAsuransi.Text = "5.56"
        ElseIf tnr >= 31 And tnr <= 36 Then
            txtPremiAsuransi.Text = "6.5"
        Else
            txtPremiAsuransi.Text = "0"
        End If
    End Sub

    Private Sub txtMesin_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMesin.TextChanged
        'Try
        '     Call conn_open()
        '    str = "SELECT FRAMECODE FROM APPLICATION WHERE ENGINECODE='" & antisqli(txtMesin.Text) & "'"
        '    cmd = New SqlCommand(str, conn)
        '    rdr = cmd.ExecuteReader()

        '    While rdr.Read()
        '        txtRangka.Text = rdr("FRAMECODE")
        '    End While
        '    conn.Close()

        'Catch ex As Exception

        'End Try

        StrSQL = ""
        StrSQL = "SELECT FRAMECODE FROM APPLICATION WHERE ENGINECODE='" & antisqli(txtMesin.Text) & "'"
        RunSQL(StrSQL, 1)

        If dt.Rows.Count > 0 Then
            txtRangka.Text = dt.Rows(0)("FrameCode")
        Else
            txtRangka.Clear()
        End If

    End Sub

    
    Private Sub txtTahun_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTahun.KeyPress

        'If Char.IsDigit(e.KeyChar) Then
        '    e.Handled = False
        'Else
        '    e.Handled = True
        'End If
        decimalOnly(sender, e, txtTahun.Text)
    End Sub

    Private Sub txtAdminKredit_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAdminKredit.LostFocus
        txtAdminKredit.Text = ribuan(txtAdminKredit.Text)
    End Sub

   

    Private Sub txtPemAlamat_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPemAlamat.TextChanged
        chkbox()
    End Sub

    Private Sub cmbPemKel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPemKel.SelectedIndexChanged
        chkbox()
    End Sub

    Private Sub txtPemRt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPemRt.TextChanged
        chkbox()
    End Sub

    Private Sub txtPemRw_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPemRw.TextChanged
        chkbox()
    End Sub

    Private Sub txtBpkbAlamat_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBpkbAlamat.TextChanged
        chkbox()
    End Sub

    Private Sub cmbBpkbKel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBpkbKel.SelectedIndexChanged
        chkbox()
    End Sub

    Private Sub txtAdminKredit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAdminKredit.TextChanged
        Try
            If txtPinjaman.Text = "" Then txtAdminKredit.Text = 0
            'If txtPremiAdmin.Text = "" Then txtPremiAdmin.Text = 0

            If txtPinjaman.Text <> 0 Then
                HitungPremiAdmin()
            End If



        Catch ex As Exception
            Exit Try
        End Try

        txtAdminMurni.Text = 0
        txtBungaPengali.Text = 0
        txtBungaFlat.Text = 0
        'txtPokok.Clear()
        txtBunga.Clear()
        txtTotalHutang.Text = 0
        txtAngsuran.Text = 0
    End Sub

    Private Sub txtPremiAdmin_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPremiAdmin.LostFocus
        txtPremiAdmin.Text = ribuan(txtPremiAdmin.Text)
    End Sub

    Private Sub HitungPremiAdmin()
        'Dim pokok As Double = 0
        'Dim PremiAdmin As Double = 0

        'pokok = Format(CDbl(txtPinjaman.Text) + CDbl(txtAdminKredit.Text) + CDbl(txtPremiAdmin.Text), "#,##0")
        'PremiAdmin = Format(((CDbl(pokok) * CDbl(txtPremiAsuransi.Text)) / 100) + CDbl(txtAdmin.Text), "#,##0")

        'txtPremiAdmin.Text = PremiAdmin

        'tempPokok = Format(CDbl(txtPinjaman.Text) + CDbl(txtAdminKredit.Text) + CDbl(txtPremiAdmin.Text), "#,##0")
        tempPokok = Format(CDbl(txtPinjaman.Text) + CDbl(txtAdminKredit.Text), "#,##0")
        tempPremiAdmin = Format(((CDbl(tempPokok) * CDbl(txtPremiAsuransi.Text)) / 100) + CDbl(txtAdmin.Text), "#,##0")
        txtPremiAdmin.Text = ribuan(CStr(tempPremiAdmin))

    End Sub

    Private Sub txtPinjaman_KeyPress_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPinjaman.KeyPress
        decimalOnly(txtPinjaman, e, txtPinjaman.Text)
    End Sub

    Private Sub txtUangPemohon_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUangPemohon.LostFocus
        txtUangPemohon.Text = ribuan(txtUangPemohon.Text)
    End Sub

    Private Sub txtUangPasangan_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUangPasangan.LostFocus
        txtUangPasangan.Text = ribuan(txtUangPasangan.Text)
    End Sub

    Private Sub txtUangLain_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUangLain.LostFocus
        txtUangLain.Text = ribuan(txtUangLain.Text)
    End Sub

    Private Sub txtUangKeluar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUangKeluar.LostFocus
        txtUangKeluar.Text = ribuan(txtUangKeluar.Text)
    End Sub

   

    Private Sub cmbSalesman_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbSalesman.KeyDown
        If e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtKendaraan.Focus()
        End If
    End Sub
End Class
