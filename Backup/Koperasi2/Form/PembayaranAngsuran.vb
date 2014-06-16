Option Strict On
Imports System.Data.SqlClient

Public Class PembayaranAngsuran

    'Dim col As New GridDateControl()
    'Dim cell As New CalendarEditingControl
    Dim tglbayar As Date
    Dim ambc As Integer
    Dim ovd As Integer
    Dim totalbayar As Integer
    Dim outstanding As Integer
    Dim kwitansi As String
    Dim index As Integer
    Dim denda As Integer



    Private Sub PembayaranAngsuran_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TestFillGrid()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        frmTabKontrak.txtFlag.Text = "1"
        frmTabKontrak.Show()
    End Sub

    Private Sub txtKontrak_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKontrak.TextChanged
        If txtKontrak.Text.Length = txtKontrak.MaxLength Then
            FillGrid()

        End If
    End Sub

    Private Function tabelgrid() As DataTable
        Dim table As New DataTable
        table.Columns.Add("tglBayar", GetType(Date))
        Return table

    End Function

    Private Sub TestFillGrid()

        Dim tanggal As Date

        StrSQL = ""
        StrSQL = "SELECT TOP 2 TglBayar from ContractDetail"

        Dim contractdetail As DataTable = tabelgrid()




        With contractdetail
            .Rows.Clear()
            conn.Open()
            cmd = New SqlCommand(StrSQL, conn)
            rdr = cmd.ExecuteReader()
            While rdr.Read()
                tanggal = CDate(rdr("TglBayar"))
                .Rows.Add(tanggal)
            End While
            conn.Close()
        End With

        Dim col As New CalendarColumn()
        col.HeaderText = "Tanggal Bayar"
        Me.gv1.Columns.Add(col)

        gv1.Rows("col").Cells(1).Value = tanggal


    End Sub

    Private Sub FillGrid()
        'col.Name = "col"
        'col.HeaderText = "Tgl Bayar"
        'col.DataPropertyName = "TglBayar"
        'col.DisplayIndex = 7

        'With gv1
        '    .Columns.Clear()
        '    .AllowUserToAddRows = False
        '    .AutoGenerateColumns = False
        'End With


        StrSQL = ""
        StrSQL = "SELECT [INDEX]+1 as [Angs Ke],"
        StrSQL &= "CONVERT(nvarchar,jatuhtempo,103) as [Due Date],"
        StrSQL &= "REPLACE(CONVERT(VARCHAR,Angsuran,1), '.00','') as [Angsuran],"
        StrSQL &= "REPLACE(CONVERT(VARCHAR,Sp,1), '.00','') as [Amount Principal],"
        StrSQL &= "REPLACE(CONVERT(VARCHAR,Si,1), '.00','') as [Interest Principal],"
        StrSQL &= "REPLACE(CONVERT(VARCHAR,Op,1), '.00','') as [Amount Principal (sisa)],"
        StrSQL &= "REPLACE(CONVERT(VARCHAR,Oi,1), '.00','') as [Interest Principal (sisa)],"
        StrSQL &= "isnull(CONVERT(nvarchar,tglbayar),'') as [Tanggal Bayar],"
        StrSQL &= "REPLACE(CONVERT(VARCHAR,(ISNULL(AMBC,0)),1),'.00','') as [AMBC],"
        StrSQL &= "DATEDIFF(DAY,JatuhTempo,GETDATE()) as [OVD],"
        StrSQL &= "ISNULL(Denda,0) as [Denda],"
        StrSQL &= "ISNULL(TotalBayar,0) as [Total Bayar],"
        StrSQL &= "ISNULL(Outstanding,0) as [Outstanding],"
        StrSQL &= "ISNULL(NoKwitansi,'') as [Nomor Kwitansi] "
        StrSQL &= "FROM ContractDetail "
        StrSQL &= "WHERE ContractID='" & txtKontrak.Text & "' "

        RunSQL(StrSQL, 2, "TabelDetailKontrak")
        gv1.DataSource = ds
        gv1.DataMember = "TabelDetailKontrak"

        gv1.Columns(0).ReadOnly = True
        gv1.Columns(1).ReadOnly = True
        gv1.Columns(2).ReadOnly = True
        gv1.Columns(3).ReadOnly = True
        gv1.Columns(4).ReadOnly = True
        gv1.Columns(5).ReadOnly = True
        gv1.Columns(6).ReadOnly = True
        gv1.Columns(7).ReadOnly = True
        gv1.Columns(8).ReadOnly = True
        gv1.Columns(9).ReadOnly = True

        'StrSQL = ""
        'StrSQL = "SELECT isnull(CONVERT(nvarchar,tglbayar),'') as [Tanggal Bayar] "
        'StrSQL &= "FROM ContractDetail "
        'StrSQL &= "WHERE ContractID='" & txtKontrak.Text & "' "

        'RunSQL(StrSQL, 2, "TanggalBayar")












    End Sub

    'Private Sub FillGrid()
    '    gv1.AutoGenerateColumns = False
    '    gv1.ColumnCount = 2
    '    gv1.Columns(0).Name = "index"
    '    gv1.Columns(0).HeaderText = "Index"
    '    gv1.Columns(0).DataPropertyName = "Index"

    '    gv1.Columns.Insert(1, col)



    '    StrSQL = ""
    '    StrSQL = "SELECT [INDEX]+1 as [Angs Ke],"
    '    StrSQL &= "isnull(CONVERT(nvarchar,tglbayar),'') as [Tanggal Bayar] "
    '    StrSQL &= "FROM ContractDetail "
    '    StrSQL &= "WHERE ContractID='" & txtKontrak.Text & "' "

    '    RunSQL(StrSQL, 2, "TanggalBayar")
    '    gv1.DataSource = ds
    '    gv1.DataMember = "TanggalBayar"

    'End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        For Each row As DataGridViewRow In gv1.Rows

            If row.Cells("col").Value.ToString() <> "" And row.Cells(7).Value.ToString() <> "" And row.Cells(8).Value.ToString() <> "" And row.Cells(9).Value.ToString() <> "" And row.Cells(10).Value.ToString() <> "" And row.Cells(11).Value.ToString() <> "" And row.Cells(12).Value.ToString() <> "" Then
                tglbayar = CDate(row.Cells("col").Value)
                ambc = CInt(row.Cells(7).Value)
                ovd = CInt(row.Cells(8).Value)
                denda = CInt(row.Cells(9).Value)
                totalbayar = CInt(row.Cells(10).Value)
                outstanding = CInt(row.Cells(11).Value)
                kwitansi = CStr(row.Cells(12).Value)
                index = CInt(row.Cells(0).Value) - 1

                StrSQL = ""
                StrSQL = "UPDATE ContractDetail SET "
                StrSQL &= "TglBayar ='" & CStr(tglbayar) & "',"
                StrSQL &= "AMBC =" & ambc & ","
                StrSQL &= "OVD =" & ovd & ","
                StrSQL &= "Denda =" & denda & ","
                StrSQL &= "TotalBayar =" & totalbayar & ","
                StrSQL &= "Outstanding =" & outstanding & ","
                StrSQL &= "NoKwitansi='" & kwitansi & "' "
                StrSQL &= "WHERE ContractID='" & CStr(txtHidden.Text) & "' "
                StrSQL &= "AND [index]=" & index & ""

                RunSQL(StrSQL, 0)

                gv1.RowsDefaultCellStyle.BackColor = Color.BlueViolet
            Else
                Exit For
            End If

        Next
    End Sub


    Private Sub gv1_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gv1.CellValueChanged

    End Sub
End Class