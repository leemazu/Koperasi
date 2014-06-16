Option Strict On
Public Class frmKwitansi
    Dim AlertMsg As String = ""
    Dim flag As Boolean = False


  
    Private Sub frmKwitansi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        flag = False
        FreshForm()
        flag = True
        cmbPIC1_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub FreshForm()
        setTanggal()

        FillCombo()

        cmbStatKwitansi.SelectedIndex = 0
        cmbFisik.SelectedIndex = 0


    End Sub


    Private Sub btnApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprove.Click
        If Validation() Then
            Kwitansi_SAV()
            MessageBox.Show("Data Berhasil Ditambah", "Sukses", MessageBoxButtons.OK)
            FreshForm()
        Else
            MessageBox.Show(AlertMsg, "Error", MessageBoxButtons.OK)
        End If
    End Sub

    Private Function Validation() As Boolean

        
        If txtNominal.Text = "" Or txtNominal.Text = "0" Then

            AlertMsg = "Nominal Tidak Boleh Kosong"
            txtNominal.SelectAll()
            txtNominal.Focus()
            Return False
        Else
            Return True
        End If

    End Function

    Private Sub Kwitansi_SAV()
        StrSQL = ""
        StrSQL = "Sp_Kwitansi_SAV "
        StrSQL &= "'" & CStr(cmbKwitansi.SelectedValue) & "',"
        StrSQL &= "'" & CStr(cmbPIC1.SelectedValue) & "',"
        StrSQL &= "'" & CStr(cmbPIC2.SelectedValue) & "',"
        StrSQL &= "'',"
        StrSQL &= "'" & CStr(cmbStatKwitansi.Text) & "',"
        StrSQL &= "'" & CStr(cmbFisik.Text) & "',"
        StrSQL &= "'" & CStr(txtAlasan.Text) & "',"
        StrSQL &= CDbl(txtNominal.Text) & ","
        StrSQL &= "'" & CStr(dtBayar.Text) & "',"
        StrSQL &= "'" & CStr(txtKontrak.Text) & "',"
        StrSQL &= "'" & CStr(txtIdKonsumen.Text) & "',"
        StrSQL &= "0"
        RunSQL(StrSQL, 0)
    End Sub

    'Private Function GenerateNoKwitansi() As String
    '    GenerateNoKwitansi = ""
    '    Dim Tahun As String
    '    Dim No As String
    '    Dim tempNo As String
    '    Dim tempKode As Integer
    '    Tahun = CStr(Microsoft.VisualBasic.Right(CStr(Year(Now)), 2))

    '    StrSQL = ""
    '    StrSQL = "SELECT TOP 1 NoKwitansi FROM Kwitansi Where NoKwitansi LIKE '%" & Tahun & "' ORDER BY NoKwitansi DESC"
    '    RunSQL(StrSQL, 1)

    '    If dt.Rows.Count > 0 Then
    '        tempNo = CStr(dt.Rows(0)("NoKwitansi"))
    '        tempNo = CStr(Microsoft.VisualBasic.Left(tempNo, 6))
    '        tempKode = CInt(tempNo) + 1
    '        tempNo = CStr(tempKode)
    '        No = CStr(generateCode6Digit(tempNo)) & Tahun

    '    Else
    '        No = "000001" & Tahun
    '    End If

    '    Return No
    'End Function

    Private Sub FillCombo()
        Dim tablePIC1 As DataTable = CType(getTable(), DataTable)
        Dim tablePIC2 As DataTable = CType(getTable(), DataTable)
        StrSQL = ""
        StrSQL = "SpEmployee_CBO 'PC'"

       

        With cmbPIC1
            With tablePIC1
                .Rows.Clear()
                RunSQL(StrSQL, 1)
                For index As Integer = 0 To (dt.Rows.Count - 1)
                    .Rows.Add(dt.Rows(index)(0), dt.Rows(index)(1))
                Next
            End With
            .DataSource = tablePIC1
            .ValueMember = "ID"
            .DisplayMember = "NAMA"
        End With

        StrSQL = ""
        StrSQL = "SpEmployee_CBO 'PC'"
        FillComboWithValue(cmbPIC2, StrSQL, tablePIC2)


    End Sub

 
    Private Sub btnKonsumen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKonsumen.Click
        frmTabMem.Show()
        formFlag = CStr(5)
    End Sub

    Private Sub setTanggal()
       
        dtBayar.Text = CStr(Now)
        dtBayar.Format = DateTimePickerFormat.Custom
        dtBayar.CustomFormat = "dd/MM/yyyy"
    End Sub
       
    Private Sub txtNominal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNominal.KeyPress
        decimalOnly(txtNominal, e, txtNominal.Text)
    End Sub

    Private Sub txtNominal_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNominal.LostFocus
        If txtNominal.Text = "" Then
            txtNominal.Text = CStr(0)
        End If
        txtNominal.Text = CStr(ribuan(txtNominal.Text))
    End Sub
    Private Sub FillKwitansi()
        Dim tableKwitansi As New DataTable


        tableKwitansi.Columns.Add("NoKwitansi", GetType(String))
        StrSQL = ""
        StrSQL = "SELECT TOP 10 * From KwitansiOwner Where EmployeeID='" & CStr(cmbPIC1.SelectedValue) & "'"

        With cmbKwitansi

            With tableKwitansi
                .Rows.Clear()
                RunSQL(StrSQL, 1)

                For index As Integer = 0 To (dt.Rows.Count - 1)
                    .Rows.Add(dt.Rows(index)("NoKwitansi"))
                Next
               
            End With
            If dt.Rows.Count > 0 Then
                .DataSource = tableKwitansi
                .ValueMember = "NoKwitansi"
                .DisplayMember = "NoKwitansi"
            Else
                .DataSource = Nothing
                .ValueMember = Nothing
                .DisplayMember = Nothing
                .Items.Add("Tidak Ada Kwitansi")
                .SelectedIndex = 0
            End If



        End With

       
    End Sub

    Private Sub cmbPIC1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPIC1.SelectedIndexChanged
      

        If flag = True Then

            FillKwitansi()

        End If

      
       

    End Sub

    Private Sub btnKontrak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKontrak.Click
        frmTabKontrak.Show()
    End Sub
End Class