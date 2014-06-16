
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors.Repository

Public Class PembayaranDenda

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        frmTabKontrak.txtFlag.Text = "2"
        frmTabKontrak.Show()
    End Sub

    Private Sub txtKontrak_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKontrak.TextChanged
        If txtKontrak.Text.Length = txtKontrak.MaxLength Then
            FillGrid()

        End If
    End Sub

    Private Sub FillGrid()

        Dim tanggal As RepositoryItemDateEdit = New RepositoryItemDateEdit() With {.EditMask = "dd/MM/yyyy"}
        tanggal.Mask.UseMaskAsDisplayFormat = True
        Dim uang As RepositoryItemSpinEdit = New RepositoryItemSpinEdit

    
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
            StrSQL = "SELECT [Index] as [Angs Ke]"
            StrSQL &= ",isnull(CONVERT(nvarchar,tglbayar),'') as [Tanggal Bayar]"
            StrSQL &= ",Outstanding"
            StrSQL &= ",isnull(CONVERT(nvarchar,outstandingReceive),'') as [Outstanding Receive]"
            StrSQL &= ",isnull(CONVERT(nvarchar,NoKwitansi),'unpaid') as [Nomor Kwitansi]"
            StrSQL &= " From Denda "
            StrSQL &= String.Format("WHERE ContractID='{0}' ", txtKontrak.Text)
            da = New SqlDataAdapter(StrSQL, conn)
            da.Fill(tbl_kontrak)
            ds_kontrak.Tables.Add(tbl_kontrak)
        End Using
        GridControl1.DataSource = Nothing
        GridControl1.DataSource = tbl_kontrak

        GridView1.Columns("Tanggal Bayar").ColumnEdit = tanggal
        GridView1.Columns("Outstanding").ColumnEdit = uang
        GridView1.Columns("Outstanding Receive").ColumnEdit = uang
        GridView1.Columns("Angs Ke").OptionsColumn.AllowEdit = False
        GridView1.Columns("Outstanding").OptionsColumn.AllowEdit = False

    End Sub

    Private Sub GridView1_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged

        Dim tglBayar As Boolean
        Dim tanggal As Date
        Dim outstandingReceive As Integer
        Dim Nokwitansi As String = GridView1.GetFocusedRowCellValue(GridView1.Columns("Nomor Kwitansi"))

        If GridView1.GetFocusedRowCellValue(GridView1.Columns("Outstanding Receive")) = "" Then
            outstandingReceive = 0
        Else
            outstandingReceive = GridView1.GetFocusedRowCellValue(GridView1.Columns("Outstanding Receive"))
        End If

        If GridView1.GetFocusedRowCellValue(GridView1.Columns("Tanggal Bayar")) = "" Then
            tglBayar = False
        Else
            tglBayar = True
            tanggal = GridView1.GetFocusedRowCellValue(GridView1.Columns("Tanggal Bayar"))
        End If


        If e.Column.FieldName = "Outstanding Receive" And tglBayar = True And Nokwitansi <> "unpaid" Then
            denda_SAV(outstandingReceive, tanggal, Nokwitansi)
        End If

        If e.Column.FieldName = "Tanggal Bayar" And outstandingReceive <> 0 And Nokwitansi <> "unpaid" Then
            denda_SAV(outstandingReceive, tanggal, Nokwitansi)
        End If

        If e.Column.FieldName = "Nomor Kwitansi" And tglBayar = True And outstandingReceive <> 0 Then
            denda_SAV(outstandingReceive, tanggal, Nokwitansi)
        End If

    End Sub

    Private Sub denda_SAV(ByVal outstandingreceive As Integer, ByVal TglBayar As Date, ByVal NoKwitansi As String)
        Dim index As Integer = GridView1.GetFocusedRowCellValue(GridView1.Columns("Angs Ke"))
        StrSQL = ""
        StrSQL = "UPDATE Denda SET "
        StrSQL &= "TglBayar='" & TglBayar & "',"
        StrSQL &= "OutstandingReceive=" & outstandingreceive & ","
        StrSQL &= "NoKwitansi='" & NoKwitansi & "' "
        StrSQL &= "WHERE ContractId='" & txtKontrak.Text & "' "
        StrSQL &= "AND [index]=" & index - 1 & ""

        RunSQL(StrSQL, 0)

        'Update ContractDetail

        StrSQL = ""
        StrSQL = "UPDATE ContractDetail SET "
        StrSQL &= "OutstandingReceive=" & outstandingreceive & ""
        StrSQL &= ",OutstandingTotal= Outstanding+" & outstandingreceive & ""
        StrSQL &= " WHERE ContractId='" & txtKontrak.Text & "' "
        StrSQL &= "AND [index]=" & index - 1 & ""

        RunSQL(StrSQL, 0)

    End Sub

   

End Class