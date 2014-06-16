Option Strict On
Public Class frmKwitansiOwner

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If validation() Then
            Kwitansi_SAV()
            FreshForm()
        End If




    End Sub

    Private Function validation() As Boolean
        If txtKwitansiDr.Text.Length = txtKwitansiDr.MaxLength And txtKwitansiSm.Text.Length = txtKwitansiSm.MaxLength Then
            If txtKwitansiDr.Text > txtKwitansiSm.Text Then
                MessageBox.Show("Nomor Kwitansi Awal Tidak Boleh Lebih Kecil Dari Nomor Kwitansi Akhir", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                validation = False
            Else
                validation = True
            End If
        Else
            MessageBox.Show("Nomor Kwitansi Salah", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            validation = False
        End If

        
        Return validation
    End Function

    Private Sub frmKwitansiOwner_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillCombo()
        FreshForm()
    End Sub

    Private Sub FillCombo()
        Dim tablePIC As DataTable = CType(getTable(), DataTable)
        StrSQL = ""
        StrSQL = "SpEmployee_CBO 'PC'"
        FillComboWithValue(cmbPIC, StrSQL, tablePIC)
    End Sub

    Private Sub Kwitansi_SAV()
        Dim totalREC As Integer
        Dim tempKwitansi As Integer
        Dim tempTahun As String
        tempKwitansi = CInt(Microsoft.VisualBasic.Left(txtKwitansiDr.Text, 6))
        'tempKwitansi = CInt(txtKwitansiDr.Text)
        Dim tempFormatedKwitansi As String
        tempTahun = Microsoft.VisualBasic.Right(txtKwitansiDr.Text, 2)
        totalREC = 1 + CInt(Microsoft.VisualBasic.Left(txtKwitansiSm.Text, 6)) - CInt(Microsoft.VisualBasic.Left(txtKwitansiDr.Text, 6))
        'totalREC = CInt(txtKwitansiSm.Text) - CInt(txtKwitansiDr.Text) + 1
        StrSQL = ""
        StrSQL = "SELECT*FROM Kwitansi Where NoKwitansi >='" & CStr(antisqli(txtKwitansiDr.Text)) & "' AND NoKwitansi <='" & CStr(antisqli(txtKwitansiSm.Text)) & "'"
        RunSQL(StrSQL, 1)

        If dt.Rows.Count = totalREC Then
            StrSQL = ""
            StrSQL = "UPDATE KwitansiOwner SET EmployeeID='" & CStr(cmbPIC.SelectedValue) & "' "
            StrSQL &= "WHERE NoKwitansi >='" & CStr(antisqli(txtKwitansiDr.Text)) & "' AND NoKwitansi <='" & CStr(antisqli(txtKwitansiSm.Text)) & "'"
            RunSQL(StrSQL, 0)
        Else
            For index As Integer = 0 To (totalREC - 1)
                tempFormatedKwitansi = CStr(tempKwitansi + index)
                tempFormatedKwitansi = CStr(generateCode6Digit(tempFormatedKwitansi)) & tempTahun
                StrSQL = ""
                StrSQL = "SELECT * FROM KWITANSI Where NoKwitansi ='" & tempFormatedKwitansi & "'"
                RunSQL(StrSQL, 1)
                If dt.Rows.Count > 0 Then
                    StrSQL = ""
                    StrSQL = "UPDATE Kwitansi SET PIC1='" & CStr(cmbPIC.SelectedValue) & "', "
                    StrSQL &= "TglAmbil='" & CStr(CDate(dtKwitansi.Value)) & "' "
                    StrSQL &= "WHERE NoKwitansi >='" & CStr(antisqli(txtKwitansiDr.Text)) & "' AND NoKwitansi <='" & CStr(antisqli(txtKwitansiSm.Text)) & "'"
                    RunSQL(StrSQL, 0)
                Else
                    StrSQL = ""
                    'StrSQL = "INSERT INTO KWITANSI VALUES ('" & tempFormatedKwitansi & "','" & CStr(CDate(dtKwitansi.Value)) & "','" & CStr(cmbPIC.SelectedValue) & "')"
                    StrSQL = "INSERT INTO KWITANSI VALUES ("
                    StrSQL &= "'" & tempFormatedKwitansi & "',"
                    StrSQL &= "'EM0043'," 'awal2 bind ke cabang
                    StrSQL &= "'',"
                    StrSQL &= "'" & CStr(CDate(dtKwitansi.Value)) & "',"
                    StrSQL &= "'Belum Terpakai',"
                    StrSQL &= "'Ada',"
                    StrSQL &= "'',"
                    StrSQL &= "0,"
                    StrSQL &= "'',"
                    StrSQL &= "'',"
                    StrSQL &= "'',"
                    StrSQL &= "0,"
                    StrSQL &= "'Pusat')"
                    RunSQL(StrSQL, 0)
                End If
            Next index
        End If
        MessageBox.Show("Proses Selesai")
    End Sub

    Private Sub FreshForm()
        txtKwitansiDr.Clear()
        txtKwitansiSm.Clear()
        setTanggal(dtKwitansi)
        cmbPIC.SelectedIndex = 0


    End Sub

    Private Sub btnApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprove.Click

    End Sub
End Class