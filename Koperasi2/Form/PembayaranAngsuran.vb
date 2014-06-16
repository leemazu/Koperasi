'Option Strict On
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Grid

Public Class PembayaranAngsuran

    Dim contract As String
    Dim ovd As Integer
    Dim totalbayar As Integer
    Dim outstanding As Integer
    Dim kwitansi As String
    Dim denda As Integer
    Dim memberID As String
    Dim ListKwitansi As RepositoryItemComboBox = New RepositoryItemComboBox

    Private Sub PembayaranAngsuran_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillPIC()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        frmTabKontrak.txtFlag.Text = "1"
        frmTabKontrak.Show()
    End Sub

    Private Sub txtKontrak_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKontrak.TextChanged
        If txtKontrak.Text.Length = txtKontrak.MaxLength Then
            FillForm()
            FillGrid()

        Else
            GridControl1.DataSource = Nothing
        End If
    End Sub

    Private Sub FillPIC()
        Dim tablePIC As DataTable = Nothing
        StrSQL = ""
        StrSQL = "SELECT EmployeeID,EmployeeName FROM Employee Where PositionID = 'PC' ORDER BY EmployeeName ASC"
        FillCombobox(StrSQL, cmbPIC, 2, tablePIC)
    End Sub

    Private Sub FillForm()
        StrSQL = ""
        StrSQL = "SELECT m.MemberName,m.Address "
        StrSQL &= ",'Objek'=CASE WHEN a.ApplicationTypeID = 1 THEN 'Motor Baru'"
        StrSQL &= " WHEN a.ApplicationTypeID = 2 THEN 'Dana Tunai'"
        StrSQL &= " WHEN a.ApplicationTypeID=3 THEN 'Elektronik' ELSE 'KTA' END"
        StrSQL &= ",a.EngineCode,a.MotorType,a.Tenor,"
        StrSQL &= "SUBSTRING('JAN FEB MAR APR MEI JUN JUL AGU SEP OKT NOV DES ',"
        StrSQL &= "(convert(int,month(c.BastDate)) * 4) - 3, 3) "
        StrSQL &= "+ '-' + CONVERT(nvarchar,year(c.bastdate)) as [Bulan Booking]"
        StrSQL &= ",m.MemberID as MemberID"
        StrSQL &= " FROM Member m,Application a,contract c where c.ContractID = a.ContractID"
        StrSQL &= " AND a.MemberID=m.MemberID"
        StrSQL &= String.Format(" AND c.ContractID='{0}'", txtKontrak.Text)
        RunSQL(StrSQL, 1)

        txtKonsumen.Text = dt.Rows(0)(1).ToString()
        txtAlamat.Text = dt.Rows(0)(2).ToString()
        txtObjek.Text = dt.Rows(0)(3).ToString()
        txtMesin.Text = dt.Rows(0)(4).ToString()
        txtTipe.Text = dt.Rows(0)(5).ToString()
        txtTenor.Text = dt.Rows(0)(6).ToString()
        txtBulan.Text = dt.Rows(0)(7).ToString()
        memberID = dt.Rows(0)(8).ToString()
    End Sub

    Private Sub FillGrid()

        Dim tanggal As RepositoryItemDateEdit = New RepositoryItemDateEdit() With {.EditMask = "dd/MM/yyyy"}
        tanggal.Mask.UseMaskAsDisplayFormat = True
        Dim uang As RepositoryItemSpinEdit = New RepositoryItemSpinEdit
        Dim uang2 As RepositoryItemSpinEdit = New RepositoryItemSpinEdit

        uang2.MaxLength = 9
        uang2.IsFloatValue = False
        uang2.EditMask = "###,###,##0"
        uang2.Mask.UseMaskAsDisplayFormat = True

        uang.NullText = 0
        uang.MaxLength = 9
        uang.IsFloatValue = False
        uang.EditMask = "###,###,##0"
        uang.Mask.UseMaskAsDisplayFormat = True
        uang.MinValue = 0
        uang.NullText = 0

        Dim tbl_kontrak As New DataTable
        Using ds_kontrak As New DataSet()
            StrSQL = ""
            StrSQL = "SELECT [Index]+1 as [Angs Ke]"
            StrSQL &= ",JatuhTempo as [Due Date]"
            StrSQL &= ",Angsuran"
            StrSQL &= ",Sp as [Amount Principal]"
            StrSQL &= ",Si as [Interest Principal]"
            StrSQL &= ",Op as [Amount Principal (sisa)]"
            StrSQL &= ",Oi as [Interest Principal (sisa)]"
            StrSQL &= ",isnull(CONVERT(nvarchar,tglbayar),'') as [Tanggal Bayar]"
            StrSQL &= ",Angsuran+(CASE WHEN Angsuran*0.005*DATEDIFF(DAY,JatuhTempo,GETDATE()) < 0 then 0 ELSE Angsuran*0.005*DATEDIFF(DAY,JatuhTempo,GETDATE()) end) as [AMBC]"
            StrSQL &= ",ISNULL(OVD,DATEDIFF(DAY,JatuhTempo,GETDATE())) as [OVD]"
            'mark tanggal 11/6/2014 reason ubah tampilan denda berdasar ovd
            'StrSQL &= ",DATEDIFF(DAY,JatuhTempo,GETDATE()) as [OVD]"
            'StrSQL &= ",CASE WHEN Angsuran*0.005*DATEDIFF(DAY,JatuhTempo,GETDATE()) < 0 then 0 ELSE Angsuran*0.005*DATEDIFF(DAY,JatuhTempo,GETDATE()) end as [Denda]"
            'end mark
            StrSQL &= ",CASE WHEN OVD IS NULL THEN CASE WHEN Angsuran*0.005*DATEDIFF(DAY,JatuhTempo,GETDATE()) < 0"
            StrSQL &= " then 0 ELSE Angsuran*0.005*DATEDIFF(DAY,JatuhTempo,GETDATE()) end"
            StrSQL &= " ELSE Angsuran*0.005*DATEDIFF(DAY,JatuhTempo,GETDATE()) END as [Denda]"
            StrSQL &= ",isnull(CONVERT(nvarchar,TotalBayar),'0') as [Total Bayar]"
            StrSQL &= ",isnull(CONVERT(nvarchar,Outstanding),'0') as [Outstanding]"
            StrSQL &= ",isnull(CONVERT(nvarchar,OutstandingReceive),'0') as [Outstanding Receive]"
            StrSQL &= ",isnull(CONVERT(nvarchar,OutstandingTotal),'0') as [Outstanding Total]"
            StrSQL &= ",isnull(CONVERT(nvarchar,NoKwitansi),'unpaid') as [Nomor Kwitansi]"
            StrSQL &= " From ContractDetail "
            StrSQL &= String.Format("WHERE ContractID='{0}' ", txtKontrak.Text)
            da = New SqlDataAdapter(StrSQL, conn)
            da.Fill(tbl_kontrak)
            ds_kontrak.Tables.Add(tbl_kontrak)
        End Using
        GridControl1.DataSource = Nothing
        GridControl1.DataSource = tbl_kontrak

        'set ga bisa diedit
        For i As Integer = 0 To 6
            GridView1.Columns(i).OptionsColumn.AllowEdit = False
        Next

        'set datetime
        GridView1.Columns(1).ColumnEdit = tanggal
        GridView1.Columns(7).ColumnEdit = tanggal
        GridView1.Columns(2).ColumnEdit = uang
        GridView1.Columns(3).ColumnEdit = uang
        GridView1.Columns(4).ColumnEdit = uang
        GridView1.Columns(5).ColumnEdit = uang
        GridView1.Columns(6).ColumnEdit = uang
        GridView1.Columns(8).ColumnEdit = uang
        GridView1.Columns(10).ColumnEdit = uang
        GridView1.Columns(11).ColumnEdit = uang
        GridView1.Columns("Outstanding").ColumnEdit = uang2
        GridView1.Columns("Outstanding Receive").ColumnEdit = uang2
        GridView1.Columns("Outstanding Total").ColumnEdit = uang2
        GridView1.Columns(12).OptionsColumn.AllowEdit = False
        GridView1.Columns("OVD").OptionsColumn.AllowEdit = False
        GridView1.Columns("Denda").OptionsColumn.AllowEdit = False
        GridView1.Columns("Outstanding Receive").OptionsColumn.AllowEdit = False
        GridView1.Columns("Outstanding Total").OptionsColumn.AllowEdit = False
        GridView1.Columns("Nomor Kwitansi").ColumnEdit = ListKwitansi

        'add total
        GridView1.Columns(2).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum

        'set lebar grid
        GridView1.Columns(0).Width = 52
        GridView1.Columns(1).Width = 65
        GridView1.Columns(2).Width = 64
        GridView1.Columns(3).Width = 89
        GridView1.Columns(4).Width = 88
        GridView1.Columns(5).Width = 115
        GridView1.Columns(6).Width = 117
        GridView1.Columns(7).Width = 79
        GridView1.Columns(8).Width = 62
        GridView1.Columns(9).Width = 38
        GridView1.Columns(10).Width = 65
        GridView1.Columns(11).Width = 77
        GridView1.Columns(12).Width = 70
        GridView1.Columns(13).Width = 110
        GridView1.Columns(14).Width = 95
        GridView1.Columns(15).Width = 87


    End Sub

    Private Sub GridView1_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Dim tempTglBayar As Date

        If e.Column.FieldName = "Tanggal Bayar" Then

            contract = txtHidden.Text
            tempTglBayar = e.Value

            StrSQL = ""
            StrSQL = String.Format("Select * From contractDetail where contractID ='{0}' AND TglBayar='{1}'", contract, tempTglBayar)
            RunSQL(StrSQL, 1)

            If dt.Rows.Count > 0 Then
                With ListKwitansi
                    .TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
                    .Items.Clear()
                    StrSQL = ""
                    StrSQL = "SELECT NoKwitansi From Kwitansi Where StatusKwitansi='Belum Terpakai'"
                    StrSQL &= String.Format(" OR (StatusKwitansi='Terpakai' AND TglBayar='{0}') ORDER BY NoKwitansi ASC", tempTglBayar)
                    Call conn_open()
                    cmd = New SqlCommand(StrSQL, conn)
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    While rdr.Read()
                        .Items.Add(rdr("NoKwitansi"))
                    End While
                    conn.Close()
                End With
            Else
                With ListKwitansi
                    .TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
                    .Items.Clear()
                    StrSQL = ""
                    StrSQL = "SELECT NoKwitansi From Kwitansi Where StatusKwitansi='Belum Terpakai' ORDER BY NoKwitansi ASC"
                    Call conn_open()
                    cmd = New SqlCommand(StrSQL, conn)
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    While rdr.Read()
                        .Items.Add(rdr("NoKwitansi"))
                    End While
                    conn.Close()
                End With
            End If


        End If

        If e.Column.FieldName = "Total Bayar" Then

            If IsDBNull(e.Value) Then
                totalbayar = 0
            Else
                totalbayar = e.Value
            End If

            If totalbayar < GridView1.GetFocusedRowCellValue(GridView1.Columns(2)) And totalbayar <> 0 Then
                MessageBox.Show("Total Bayar tidak boleh lebih kecil dari Angsuran")
                GridView1.SetFocusedRowCellValue("Total Bayar", CInt(0))
            Else
                GridView1.SetFocusedRowCellValue(GridView1.Columns(12), CInt(totalbayar - GridView1.GetFocusedRowCellValue(GridView1.Columns("AMBC"))))
            End If

        End If

    End Sub

    Private Sub denda_SAV(ByVal outstanding As Integer, ByVal index As Integer, ByVal kontrak As String)

        StrSQL = ""
        StrSQL = "SELECT * From Denda Where ContractID ='" & kontrak & "'"
        StrSQL &= " AND [index]= " & index & ""
        RunSQL(StrSQL, 1)

        If dt.Rows.Count > 0 Then
            StrSQL = ""
            StrSQL = "UPDATE Denda Set Outstanding = " & outstanding & " "
            StrSQL &= " WHERE ContractId='" & kontrak & "' "
            StrSQL &= " AND [index]= " & index & ""
        Else
            StrSQL = ""
            StrSQL = "INSERT INTO denda (ContractID,Outstanding,[index]) VALUES ("
            StrSQL &= String.Format("'{0}',", kontrak)
            StrSQL &= String.Format("{0},", outstanding)
            StrSQL &= String.Format("{0})", index)
        End If
        RunSQL(StrSQL, 0)
    End Sub

    Private Sub detail_SAV()
        Dim contract As String = txtHidden.Text
        Dim tglBayar As Date = GridView1.GetFocusedRowCellValue(GridView1.Columns("Tanggal Bayar"))
        Dim AMBC As Integer = GridView1.GetFocusedRowCellValue(GridView1.Columns("AMBC"))
        Dim OVD As Integer = GridView1.GetFocusedRowCellValue(GridView1.Columns("OVD"))
        Dim denda As Integer = GridView1.GetFocusedRowCellValue(GridView1.Columns("Denda"))
        Dim totalBayar As Integer = GridView1.GetFocusedRowCellValue(GridView1.Columns("Total Bayar"))
        Dim outstanding As Integer = GridView1.GetFocusedRowCellValue(GridView1.Columns("Outstanding"))
        Dim index As Integer = GridView1.GetFocusedRowCellValue(GridView1.Columns("Angs Ke"))
        Dim Nokwitansi As String = GridView1.GetFocusedRowCellValue(GridView1.Columns("Nomor Kwitansi"))
        Dim alasan As String = "Pembayaran Angsuran Ke " & index & "."

        StrSQL = ""
        StrSQL = "UPDATE ContractDetail SET "
        StrSQL &= String.Format("TglBayar = '{0}',", tglBayar)
        StrSQL &= String.Format("AMBC ={0},", AMBC)
        StrSQL &= "OVD =" & OVD & ","
        StrSQL &= "denda =" & denda & ","
        StrSQL &= "totalBayar = " & totalBayar & ","
        StrSQL &= "outstanding = " & outstanding & ","
        StrSQL &= "NoKwitansi ='" & Nokwitansi & "' "
        StrSQL &= "WHERE ContractID ='" & txtHidden.Text & "' "
        StrSQL &= "AND [index]= " & index - 1 & ""
        RunSQL(StrSQL, 0)

        StrSQL = ""
        StrSQL = "UPDATE Kwitansi SET "
        StrSQL &= "StatusKwitansi ='Terpakai',"
        StrSQL &= "TglBayar ='" & tglBayar & "',"
        StrSQL &= "ContractID ='" & contract & "',"
        StrSQL &= "PIC2='" & cmbPIC.SelectedValue & "',"
        StrSQL &= "Alasan = case when alasan like '%" & alasan & "%'"
        StrSQL &= " THEN Alasan ELSE Alasan+'" & alasan & "' END,"
        'StrSQL &= "Nominal=Nominal+ " & totalBayar & ","
        StrSQL &= "MemberID ='" & memberID & "' "
        StrSQL &= " WHERE NoKwitansi ='" & Nokwitansi & "'"
        RunSQL(StrSQL, 0)

        StrSQL = ""
        StrSQL = ("UPDATE Kwitansi SET ")
        StrSQL &= "Nominal= A.Valsum From Kwitansi INNER JOIN "
        StrSQL &= "(SELECT NoKwitansi,SUM(totalbayar) valsum from ContractDetail "
        StrSQL &= "Where NoKwitansi ='" & Nokwitansi & "' GROUP BY NoKwitansi)  A "
        StrSQL &= " ON Kwitansi.NoKwitansi = A.NoKwitansi "
        StrSQL &= "WHERE Kwitansi.NoKwitansi ='" & Nokwitansi & "'"
        RunSQL(StrSQL, 0)


        If outstanding < 0 Then
            denda_SAV(outstanding, index, contract)
        End If

    End Sub

    Private Sub GridView1_ValidateRow(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles GridView1.ValidateRow
        ovd = GridView1.GetFocusedRowCellValue(GridView1.Columns("OVD"))
        denda = GridView1.GetFocusedRowCellValue(GridView1.Columns("Denda"))
        totalbayar = GridView1.GetFocusedRowCellValue(GridView1.Columns("Total Bayar"))
        outstanding = GridView1.GetFocusedRowCellValue(GridView1.Columns("Outstanding"))
        kwitansi = GridView1.GetFocusedRowCellValue(GridView1.Columns("Nomor Kwitansi"))

        If GridView1.GetFocusedRowCellValue(GridView1.Columns("Tanggal Bayar")).ToString() = "" Or totalbayar = "0" Or kwitansi = "" Then
            FillGrid()
        Else
            detail_SAV()
        End If

    End Sub

    Private Sub GridView1_RowStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GridView1.RowStyle


        Dim View As GridView = CType(sender, GridView)
        If (e.RowHandle >= 0) Then
            Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Angs Ke"))
            Dim tglBayar As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Tanggal Bayar"))
            Dim ambc As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("AMBC"))
            Dim denda As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Denda"))
            Dim totalBayar As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Total Bayar"))
            Dim outstanding As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Outstanding"))
            Dim kwitansi As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Nomor Kwitansi"))

            If tglBayar = "" Or totalBayar = "" Or totalBayar = "0" Or kwitansi = "" Then
                e.Appearance.BackColor = Color.Yellow
            Else

                e.Appearance.BackColor = Color.Red

            End If

        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If SaveFileDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            GridView1.OptionsPrint.AutoWidth = False
            GridView1.BestFitColumns()
            GridControl1.ExportToXls(SaveFileDialog1.FileName)
        End If
    End Sub

    

End Class