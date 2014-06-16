Public Class frmTabKontrak

    Dim kontrakFlag As Integer
    Private Sub frmTabKontrak_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillGrid()
    End Sub

    Private Sub FillGrid()

        If txtFlag.Text = "1" Then
            StrSQL = ""
            StrSQL = "SELECT  * FROM Contract ORDER BY ContractID ASC"
            RunSQL(StrSQL, 2, "TabelViewKontrak")
            gv1.DataSource = ds
            gv1.DataMember = "TabelViewKontrak"

        ElseIf txtFlag.Text = "2" Then

            StrSQL = "SELECT Contract.ContractID,Contract.ContractDate,Contract.BpkbNo,contract.BpkbState,contract.EmployeeID,contract.FirstInstallment from Contract left join ContractDetail on contract.ContractID=ContractDetail.ContractID WHERE ContractDetail.Outstanding < 0 GROUP BY contract.ContractID,Contract.ContractDate,Contract.BpkbNo,contract.BpkbState,contract.EmployeeID,contract.FirstInstallment "
            'StrSQL = "SELECT  * FROM Contract LEFT JOIN ContractDetail ON Contract.ContractId=ContractDetail.ContractID"
            'StrSQL &= "WHERE ContractID.Outstanding < 0"
            'StrSQL &= "GROUP BY Conctract.ContractID"
            'StrSQL &= ",Contract.ContractDate"
            'StrSQL &= ",Contract.BastDate"
            'StrSQL &= ",Contract.FirstInstallment"
            'StrSQL &= ",Contract.BpkbNo"
            'StrSQL &= ",Contract.BpkbState"
            'StrSQL &= ",Contract.State"
            'StrSQL &= ",Contract.TransLogID"
            'StrSQL &= "ORDER BY Contract.ContractID ASC"
            RunSQL(StrSQL, 2, "TabelViewDenda")
            gv1.DataSource = ds
            gv1.DataMember = "TabelViewDenda"

        End If


        

    End Sub


    Private Sub gv1_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gv1.CellContentDoubleClick
        If txtFlag.Text = "1" Then
            With PembayaranAngsuran
                .txtKontrak.Text = gv1.CurrentRow.Cells(0).Value
                .txtHidden.Text = gv1.CurrentRow.Cells(0).Value
            End With

        ElseIf txtFlag.Text = "2" Then
            With PembayaranDenda
                .txtKontrak.Text = gv1.CurrentRow.Cells(0).Value
                .txtHidden.Text = gv1.CurrentRow.Cells(0).Value
            End With
        End If
        Me.Close()
    End Sub
End Class