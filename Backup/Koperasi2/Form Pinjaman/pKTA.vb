Imports System.Data.SqlClient
Imports System.IO
Imports CrystalDecisions.CrystalReports.engine
Public Class pKTA


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtPinjaman.Text <> "0" Then

            Dim tempFlatInterestP As Double = 0
            Dim tempMultiplierInterestP As Double = 0


            txtPokok.Text = Format(CDbl(txtPinjaman.Text), "#,##0")
            tempFlatInterestP = ((((CDbl(txtTenor.Text) * (CDbl(txtTingkatBunga.Text) / 1200)) / (1 - (1 + (CDbl(txtTingkatBunga.Text) / 1200)) ^ (-1 * CDbl(txtTenor.Text)))) - 1) * (12 / CDbl(txtTenor.Text))) * 100
            txtBungaFlat.Text = Format(tempFlatInterestP, "#,##0.00")
            tempMultiplierInterestP = CDbl(tempFlatInterestP) * (CDbl(txtTenor.Text) / 12)
            txtBungaPengali.Text = Format(tempMultiplierInterestP, "#,##0.00")
            txtBunga.Text = Format(CDbl(txtPokok.Text) * CDbl(tempMultiplierInterestP) / 100, "#,##0")
            txtTotalHutang.Text = Format(CDbl(txtPokok.Text) + CDbl(txtBunga.Text), "#,##0")
            txtAngsuran.Text = Format(Math.Ceiling(CDbl(txtTotalHutang.Text) / (CDbl(txtTenor.Text) * 1000)) * 1000, "#,##0")

        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        formFlag = 3
        With frmTabApp
            .txtFlag.Text = "3"
            .Text = "Tabel Aplikasi KTA"
            .Show()
        End With
    End Sub

    Private Sub FreshForm()
       
        txtPinjaman.Text = "0"
        txtTenor.Text = "0"
        txtTingkatBunga.Text = "0"
        txtBungaFlat.Text = "0"
        txtBungaPengali.Text = "0"

        txtPokok.Text = "0"
        txtBunga.Text = "0"
        txtTotalHutang.Text = "0"
        txtAngsuran.Text = "0"
        txtPemNo.Text = autoNumberMember(cmbPos.Text)
        txtPemNama.Clear()
        'cmbPemGender.SelectedIndex = 0
        txtPemTl.Clear()
        dtPemTl.Text = Now
        txtPemKtp.Clear()
        txtPemAlamat.Clear()
        txtPemHp.Clear()
        txtPemTelp1.Clear()
        txtPemTelp2.Clear()
        txtPemIbu.Clear()
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
        txtUangPemohon.Text = "0"
        txtUangPasangan.Text = "0"
        txtUangLain.Text = "0"
        txtUangKeluar.Text = "0"
        txtKomentar.Clear()

        txtPemRt.Clear()
        txtPemRw.Clear()
        txtKontakTelp.Clear()
        setTanggal()
        posFlag = False

    End Sub

    Private Sub pElektronik_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        setTanggal()
        clearForm()
        txtAplikasi.Text = autoNumber(cmbPos.Text)
        txtPemNo.Text = autoNumberMember(cmbPos.Text)
    End Sub

    Private Sub clearForm()
        FillKota(cmbPemKota)
        FillKota(cmbPenagihanKota)
        FillKota(cmbPerusahaanKota)
        FillKota(cmbKontakKota)
        FillKecamatan(cmbPemKec, cmbPemKota.Text)
        FillKecamatan(cmbPenagihanKec, cmbPenagihanKota.Text)
        FillKecamatan(cmbPerusahaanKec, cmbPerusahaanKota.Text)
        FillKecamatan(cmbKontakKec, cmbKontakKota.Text)
        FillKelurahan(cmbPemKel, cmbPemKec.Text, tableKodeposPemohon)
        FillKelurahan(cmbPenagihanKel, cmbPenagihanKec.Text, tableKodeposPenagihan)
        FillKelurahan(cmbPerusahaanKel, cmbPerusahaanKec.Text, tableKodeposPerusahaan)
        FillKelurahan(cmbKontakKel, cmbKontakKec.Text, tableKodeposKontak)
        fillPos(cmbPos)
        FillCA(cmbCreditAnalyst)
        FillSurveyor(cmbSurveyor)
        FillSalesman(cmbSalesman)
        FillGender(cmbPemGender)
        FillJob(txtPemKerja)

    End Sub

    Private Sub kota_changed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPemKota.SelectedIndexChanged, cmbPerusahaanKota.SelectedIndexChanged, cmbPenagihanKota.SelectedIndexChanged, cmbKontakKota.SelectedIndexChanged
        If sender.Name = "cmbPemKota" Then
            ChangedKecamatan(cmbPemKec, cmbPemKota.Text)

        ElseIf sender.name = "cmbPenagihanKota" Then
            ChangedKecamatan(cmbPenagihanKec, cmbPenagihanKota.Text)

        ElseIf sender.name = "cmbPerusahaanKota" Then
            ChangedKecamatan(cmbPerusahaanKec, cmbPerusahaanKota.Text)

        ElseIf sender.name = "cmbKontakKota" Then
            ChangedKecamatan(cmbKontakKec, cmbKontakKota.Text)

        End If
    End Sub

    Private Sub kecamatan_changed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbKontakKec.SelectedIndexChanged, cmbPerusahaanKec.SelectedIndexChanged, cmbPenagihanKec.SelectedIndexChanged, cmbPemKec.SelectedIndexChanged
        If sender.Name = "cmbPemKec" Then
            ChangedKelurahan(cmbPemKel, cmbPemKec.Text, tableKodeposPemohon)

        ElseIf sender.name = "cmbPenagihanKec" Then
            ChangedKelurahan(cmbPenagihanKel, cmbPenagihanKec.Text, tableKodeposPenagihan)

        ElseIf sender.name = "cmbPerusahaanKec" Then
            ChangedKelurahan(cmbPerusahaanKel, cmbPerusahaanKec.Text, tableKodeposPerusahaan)

        ElseIf sender.name = "cmbKontakKec" Then
            ChangedKelurahan(cmbKontakKel, cmbKontakKec.Text, tableKodeposKontak)

        End If
    End Sub
    Private Sub setTanggal()
        dtTanggal.Text = Now
        dtTanggal.Format = DateTimePickerFormat.Custom
        dtTanggal.CustomFormat = "dd/MM/yyyy"
        dtPemTl.Text = Now
        dtPemTl.Format = DateTimePickerFormat.Custom
        dtPemTl.CustomFormat = "dd/MM/yyyy"
    End Sub

    Private Sub btnApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprove.Click, btnRecejt.Click
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
                MultiReportView.Show()

            ElseIf sender.Name = "btnReject" Then

            End If



            FreshForm()
            clearForm()
            txtAplikasi.Text = autoNumber(cmbPos.Text)
            txtPemNo.Text = autoNumberMember(cmbPos.Text)

        Else
            MessageBox.Show(alertmsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If


        'MessageBox.Show(dtTanggal.Value.ToString("yyyyMMdd"))

        'txtKomentar.Text = StrSQL

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
        StrSQL &= "'', "
        StrSQL &= "'', "
        StrSQL &= "'', "
        StrSQL &= "'', "
        StrSQL &= "'', "
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
            conn.Open()
            cmd = New SqlCommand(StrSQL, conn)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            conn.Close()
        End Try
        conn.Close()
        'RunSQL(StrSQL, 0)
        'MessageBox.Show(StrSQL)
        txtKomentar.Text = StrSQL
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
        StrSQL &= "'3', "
        StrSQL &= "'" & txtTenor.Text & "', "
        StrSQL &= CInt(txtTingkatBunga.Text) & ", "
        StrSQL &= CDbl(txtPinjaman.Text) & ", "
        StrSQL &= "0, "
        StrSQL &= "0, " 'CDbl(DownPayment.Text) & ", "
        StrSQL &= "0, "
        StrSQL &= "0, "
        StrSQL &= "0, "
        StrSQL &= "0, "
        StrSQL &= "0, "
        StrSQL &= "'', "
        StrSQL &= "'', "
        StrSQL &= "'', "
        StrSQL &= "'', "
        StrSQL &= "'" & _MemberID & "', "
        StrSQL &= IIf(_IsApprv, 1, 0) & ", "
        StrSQL &= "'" & txtKomentar.Text & "',"
        StrSQL &= "'', "
        StrSQL &= CDbl(txtPokok.Text) & ", "
        StrSQL &= CDbl(txtAngsuran.Text) & ", "
        StrSQL &= "'', "
        StrSQL &= "'', "
        StrSQL &= "'', "
        StrSQL &= "'', "
        StrSQL &= "'', "
        StrSQL &= "'" & oldAppID & "', "
        StrSQL &= "''"
        Try
            conn.Open()
            cmd = New SqlCommand(StrSQL, conn)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            conn.Close()
        End Try
        conn.Close()
        'txtKomentar.Text = StrSQL
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


        If txtPinjaman.Text < 0 Then
            alertmsg = "Pinjaman Tidak Boleh Minus"
            txtPinjaman.Focus()
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
            txtPemKtp.Focus()
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

    Private Sub tempTandaTerimaUang()
        Dim tanggal As String = "1"

        tanggal = Convert.ToString(dtTanggal.Value.Day)
        Try
            RepSQL = "INSERT INTO TTU VALUES (" & CDbl(txtPinjaman.Text) & ",'" & txtAplikasi.Text & "'"
            RepSQL &= ",'" & txtPemNama.Text & "','" & txtPemAlamat.Text & "'"
            RepSQL &= ",'" & txtTenor.Text & "'," & CDbl(txtAngsuran.Text) & ",'" & tanggal & "')"
            connRep.Open()
            cmdRep = New SqlCommand(RepSQL, connRep)
            cmdRep.ExecuteNonQuery()
            connRep.Close()
        Catch ex As Exception

        End Try

        PrintTandaTerimaUang()
    End Sub

    Private Sub PrintTandaTerimaUang()
        dsRep = New DataSet
        Try
            RepSQL = "SELECT * FROM TTU where ApplicationID='" & txtAplikasi.Text & "'"

            cmdRep = New SqlCommand(RepSQL, connRep)
            daRep = New SqlDataAdapter(cmdRep)
            connRep.Open()
            daRep.Fill(dsRep, "TandaTerimaUang")

        Catch ex As Exception

        End Try
        connRep.Close()
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
            .TabControl1.TabPages(1).Text = ""
        End With


        ''MessageBox.Show(strReportPath)

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        frmTabMem.Show()
        formFlag = 3
    End Sub

    Private Sub txtPemNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPemNo.TextChanged
        Dim conn2 As New SqlConnection(strconn)
        Dim cmd2 As SqlCommand
        Dim rdr2 As SqlDataReader
        Dim kodepos As String

        Try
            conn2.Open()
            cmd2 = New SqlCommand("SELECT*FROM MEMBER WHERE MEMBERID='" + txtPemNo.Text + "'", conn2)
            rdr2 = cmd2.ExecuteReader()

            If rdr2.HasRows Then
                stateMember = "UPD"
                While rdr2.Read()
                    txtPemNama.Text = rdr2("Membername")
                    txtPemTl.Text = rdr2("Birthplace")
                    dtPemTl.Text = rdr2("BirthDate")
                    dtPemTl.Format = DateTimePickerFormat.Custom
                    dtPemTl.CustomFormat = "dd/MM/yyyy"
                    txtPemKtp.Text = rdr2("PersonalIdentity")
                    txtPemAlamat.Text = rdr2("Address")
                    If rdr2("GenderID").ToString() = "C5AB75CC" Then
                        cmbPemGender.Text = "Pria"
                    Else
                        cmbPemGender.Text = "Wanita"
                    End If
                    txtPemHp.Text = rdr2("Phone1")
                    txtPemTelp1.Text = rdr2("Phone2")
                    txtPemTelp2.Text = rdr2("Phone3")
                    txtPemRt.Text = rdr2("MemberRT")
                    txtPemRw.Text = rdr2("MemberRW")
                    txtPemIbu.Text = rdr2("MomMaidenName")

                    kodepos = Convert.ToString(rdr2("PostalID"))
                    cmbPemKota.Text = isiKota(kodepos, 1)
                    cmbPemKec.Text = isiKecamatan(kodepos, cmbPemKota.Text, 1)
                    cmbPemKel.Text = isiKelurahan(kodepos, cmbPemKec.Text, 1, tableKodeposPemohon)

                    txtPenagihanAlamat.Text = rdr2("BillingAddress")

                    kodepos = Convert.ToString(rdr2("BillingPostalID"))
                    cmbPenagihanKota.Text = isiKota(kodepos, 2)
                    cmbPenagihanKec.Text = isiKecamatan(kodepos, cmbPenagihanKota.Text, 2)
                    cmbPenagihanKel.Text = isiKelurahan(kodepos, cmbPenagihanKec.Text, 2, tableKodeposPenagihan)
                    'ChangedKelurahan(cmbPenagihanKel, cmbPenagihanKec.Text, tableKodeposPenagihan)

                    txtPenagihanRt.Text = rdr2("BillingRT")
                    txtPenagihanRw.Text = rdr2("BillingRW")
                    txtPerusahaanNama.Text = rdr2("CompName")
                    txtPerusahaanJabatan.Text = rdr2("CompPosition")
                    txtPerusahaanMasa.Text = rdr2("CompWorkTime")
                    txtPerusahaanAlamat.Text = rdr2("CompAddress")

                    kodepos = Convert.ToString(rdr2("CompPostalID"))
                    cmbPerusahaanKota.Text = isiKota(kodepos, 3)
                    cmbPerusahaanKec.Text = isiKecamatan(kodepos, cmbPerusahaanKota.Text, 3)
                    cmbPerusahaanKel.Text = isiKelurahan(kodepos, cmbPerusahaanKec.Text, 3, tableKodeposPerusahaan)
                    'ChangedKelurahan(cmbPerusahaanKel, cmbPerusahaanKec.Text, tableKodeposPerusahaan)

                    txtPerusahaanRt.Text = rdr2("CompRT")
                    txtPerusahaanRw.Text = rdr2("CompRW")
                    txtPerusahaanTelp.Text = rdr2("CompPhone")
                    txtKontakNama.Text = rdr2("EmerName")
                    txtKontakAlamat.Text = rdr2("EmerAddress")


                    kodepos = Convert.ToString(rdr2("EmerPostalID"))
                    cmbKontakKota.Text = isiKota(kodepos, 4)
                    cmbKontakKec.Text = isiKecamatan(kodepos, cmbKontakKota.Text, 4)
                    cmbKontakKel.Text = isiKelurahan(kodepos, cmbKontakKec.Text, 4, tableKodeposKontak)
                    'ChangedKelurahan(cmbKontakKel, cmbKontakKec.Text, tableKodeposKontak)

                    txtKontakRt.Text = rdr2("EmerRT")
                    txtKontakRw.Text = rdr2("EmerRW")
                    txtKontakTelp.Text = rdr2("EmerPhone")
                    txtKontakHubungan.Text = rdr2("EmerRelations")



                    txtUangPemohon.Text = rdr2("Income")
                    txtUangPasangan.Text = rdr2("SpouseIncome")
                    txtUangLain.Text = rdr2("OtherIncome")
                    txtUangKeluar.Text = rdr2("Expense")

                    txtUangPemohon.Text = ribuan(txtUangPemohon.Text)
                    txtUangPasangan.Text = ribuan(txtUangPasangan.Text)
                    txtUangLain.Text = ribuan(txtUangLain.Text)
                    txtUangKeluar.Text = ribuan(txtUangKeluar.Text)





                End While
            End If


        Catch ex As Exception

        End Try

    End Sub

    Private Function isiKota(ByVal kodepos As String, ByVal Flag As Integer)
        Dim hasil As String = ""


        Dim conn3 As New SqlConnection(strconn)
        Dim cmd3 As SqlCommand
        Dim rdr3 As SqlDataReader



        Try
            conn3.Open()
            cmd3 = New SqlCommand("SELECT [City] FROM __AddrLocation WHERE AddrLocationID='" + kodepos + "'", conn3)
            rdr3 = cmd3.ExecuteReader()

            While rdr3.Read()

                hasil = Convert.ToString(rdr3("City"))
            End While
        Catch ex As Exception
            conn3.Close()
        End Try
        conn3.Close()
        Return hasil
    End Function

    Private Function isiKecamatan(ByVal kodepos As String, ByVal city As String, ByVal Flag As Integer)
        Dim hasil As String = ""


        Dim conn3 As New SqlConnection(strconn)
        Dim cmd3 As SqlCommand
        Dim rdr3 As SqlDataReader
        Dim objek As ComboBox = New ComboBox

        If Flag = 1 Then
            objek = cmbPemKec
        ElseIf Flag = 2 Then
            objek = cmbPenagihanKec
        ElseIf Flag = 3 Then
            objek = cmbPerusahaanKec
        ElseIf Flag = 4 Then
            objek = cmbKontakKec

        End If

        With objek
            Try
                .Items.Clear()
                conn3.Open()
                cmd3 = New SqlCommand("SELECT DISTINCT SubDistrict FROM __AddrLocation Where City='" + city + "'", conn3)
                rdr3 = cmd3.ExecuteReader()

                While rdr3.Read()
                    .Items.Add(rdr3("SubDistrict"))
                End While
            Catch ex As Exception
                conn3.Close()
            End Try
            conn3.Close()
        End With


        Try
            conn3.Open()
            cmd3 = New SqlCommand("SELECT [SubDistrict] FROM __AddrLocation WHERE AddrLocationID='" + kodepos + "'", conn3)
            rdr3 = cmd3.ExecuteReader()



            While rdr3.Read()

                hasil = Convert.ToString(rdr3("SubDistrict"))
            End While
        Catch ex As Exception
            conn3.Close()
        End Try
        conn3.Close()
        Return hasil
    End Function
    Private Function isiKelurahan(ByVal kodepos As String, ByVal subdistrict As String, ByVal Flag As Integer, ByVal table As DataTable)
        Dim hasil As String = ""


        Dim conn3 As New SqlConnection(strconn)
        Dim cmd3 As SqlCommand
        Dim rdr3 As SqlDataReader
        Dim objek As ComboBox = New ComboBox

        If Flag = 1 Then
            objek = cmbPemKel
        ElseIf Flag = 2 Then
            objek = cmbPenagihanKel
        ElseIf Flag = 3 Then
            objek = cmbPerusahaanKel
        ElseIf Flag = 4 Then
            objek = cmbKontakKel

        End If

        With objek

            Try


                With table
                    .Clear()
                    conn3.Open()
                    testString = "select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" & subdistrict & "' ORDER BY [Village] ASC"
                    cmd3 = New SqlCommand(testString, conn3)
                    'txtKomentar.Text = testString
                    rdr3 = cmd3.ExecuteReader()
                    While rdr3.Read()
                        .Rows.Add(rdr3("AddrLocationID"), rdr3("Village"))
                    End While

                End With
                conn3.Close()
                .DataSource = table
                .ValueMember = "ID"
                .DisplayMember = "NAMA"
            Catch ex As Exception

            End Try

        End With



        Try
            conn3.Open()
            cmd3 = New SqlCommand("SELECT [Village] FROM __AddrLocation WHERE AddrLocationID='" + kodepos + "'", conn3)
            rdr3 = cmd3.ExecuteReader()

            While rdr3.Read()

                hasil = Convert.ToString(rdr3("Village"))
            End While
        Catch ex As Exception
            conn3.Close()
        End Try
        conn3.Close()
        Return hasil
    End Function

    Private Sub txtAplikasi_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAplikasi.TextChanged
        If txtAplikasi.Text.Length = txtAplikasi.MaxLength Then
            Try
                conn.Open()
                cmd = New SqlCommand("SELECT*FROM APPLICATION WHERE APPLICATIONID ='" + txtAplikasi.Text + "'", conn)
                rdr = cmd.ExecuteReader()

                If rdr.HasRows Then
                    stateApp = "UPD"
                    _isRollBackMode = True
                    While rdr.Read()
                        If stateApp = "UPD" Then
                            dtTanggal.Text = rdr("ApplicationDate")
                            cmbPos.Text = namePOS(rdr("PosID"))
                            posFlag = True
                            cmbCreditAnalyst.Text = nameCA(rdr("CreditAnalystID"))
                            cmbSurveyor.Text = nameSY(rdr("SurveyorID"))
                            cmbSalesman.Text = nameSM(rdr("SalesManID"))
                            txtPinjaman.Text = rdr("Motorprice")
                            txtTenor.Text = rdr("tenor")
                            txtTingkatBunga.Text = rdr("EffectiveInterestP")
                            txtPemNo.Text = rdr("MEMBERID")
                            oldMemberID = rdr("MEMBERID")
                            txtKomentar.Text = rdr("SurveyComment")

                            Button1.PerformClick()
                        End If


                        '    .Items.Add(rdr("EmployeeName"))
                        '    .SelectedIndex = 0
                    End While
                Else
                    stateApp = "INS"

                End If


            Catch ex As Exception

            End Try

            conn.Close()

        Else
            FreshForm()
            txtPemNo.Text = autoNumberMember(cmbPos.Text)
            ' ClearForm()
            'txtPemNo.Text = autoNumberMember(cmbPos.Text)
        End If
    End Sub

    Private Function namePOS(ByVal kode As String)
        Dim namaPOS As String = ""
        Dim connPOS As New SqlConnection(strconn)
        Dim cmdPOS As SqlCommand
        Dim rdrPOS As SqlDataReader

        Try
            connPOS.Open()
            cmdPOS = New SqlCommand("SELECT ReferenceName from [_Reference] where ReferenceID='" + kode + "'", connPOS)
            rdrPOS = cmdPOS.ExecuteReader()
            While rdrPOS.Read()
                namaPOS = rdrPOS("ReferenceName")
            End While
            connPOS.Close()
        Catch ex As Exception

        End Try

        namePOS = namaPOS
    End Function

    Private Function nameCA(ByVal kode As String)
        Dim nama As String = ""
        Dim connCA As New SqlConnection(strconn)
        Dim cmdCA As SqlCommand
        Dim rdrCA As SqlDataReader

        Try
            connCA.Open()
            cmdCA = New SqlCommand("SELECT EmployeeName from Employee where EmployeeID='" + kode + "'", connCA)
            rdrCA = cmdCA.ExecuteReader()
            While rdrCA.Read()
                nama = rdrCA("EmployeeName")
            End While
            connCA.Close()
        Catch ex As Exception

        End Try

        nameCA = nama
    End Function

    Private Function nameSY(ByVal kode As String)
        Dim namaSY As String = ""
        Dim connSY As New SqlConnection(strconn)
        Dim cmdSY As SqlCommand
        Dim rdrSY As SqlDataReader

        Try
            connSY.Open()
            cmdSY = New SqlCommand("SELECT EmployeeName from Employee where EmployeeID='" + kode + "'", connSY)
            rdrSY = cmdSY.ExecuteReader()
            While rdrSY.Read()
                namaSY = rdrSY("EmployeeName")
            End While
            connSY.Close()
        Catch ex As Exception

        End Try

        nameSY = namaSY
    End Function

    Private Function nameSM(ByVal kode As String)
        Dim namaSM As String = ""
        Dim connSM As New SqlConnection(strconn)
        Dim cmdSM As SqlCommand
        Dim rdrSM As SqlDataReader

        Try
            connSM.Open()
            cmdSM = New SqlCommand("SELECT EmployeeName from Employee where EmployeeID='" + kode + "'", connSM)
            rdrSM = cmdSM.ExecuteReader()
            While rdrSM.Read()
                namaSM = rdrSM("EmployeeName")
            End While
            connSM.Close()
        Catch ex As Exception

        End Try

        nameSM = namaSM
    End Function

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        frmElektronik.Close()
    End Sub

    Private Sub cmbPos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPos.SelectedIndexChanged
        If stateApp = "INS" Then
            txtAplikasi.Text = autoNumber(cmbPos.Text)
            txtPemNo.Text = autoNumberMember(cmbPos.Text)
        End If

        If stateApp = "UPD" And posFlag = True Then
            txtAplikasi.Text = autoNumber(cmbPos.Text)
            txtPemNo.Text = autoNumberMember(cmbPos.Text)
        End If
    End Sub

    Private Sub txtTenor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTenor.LostFocus
        'Dim tnr As New Integer
        'tnr = Convert.ToInt32(txtTenor.Text)
        'If tnr >= 1 And tnr <= 12 Then
        '    txtTingkatBunga.Text = "2.5"
        'ElseIf tnr >= 13 And tnr <= 18 Then
        '    txtTingkatBunga.Text = "3.56"
        'ElseIf tnr >= 19 And tnr <= 24 Then
        '    txtTingkatBunga.Text = "4.63"
        'ElseIf tnr >= 25 And tnr <= 30 Then
        '    txtTingkatBunga.Text = "5.56"
        'ElseIf tnr >= 31 And tnr <= 36 Then
        '    txtTingkatBunga.Text = "6.5"
        'Else
        '    txtTingkatBunga.Text = "0"
        'End If
    End Sub
End Class
