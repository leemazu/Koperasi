Public Class frmTabKontrak

    Dim kontrakFlag As Integer
    Private Sub frmTabKontrak_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillGrid()
    End Sub

    Private Sub FillGrid()
        StrSQL = ""
        StrSQL = "SELECT TOP 50 * FROM Contract ORDER BY ContractID ASC"
        RunSQL(StrSQL, 2, "TabelViewKontrak")
        gv1.DataSource = ds
        gv1.DataMember = "TabelViewKontrak"

    End Sub


    Private Sub gv1_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gv1.CellContentDoubleClick
        If txtFlag.Text = "1" Then
            With PembayaranAngsuran
                .txtKontrak.Text = gv1.CurrentRow.Cells(0).Value
                .txtHidden.Text = gv1.CurrentRow.Cells(0).Value
            End With
        End If
        Me.Close()
    End Sub
End Class