Option Explicit On
Public Class frmTabApp
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Try
                dropTable()
                dropTemp()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            StrSQL = String.Format("exec Sp_tempApplication '{0}'", txtFlag.Text)
            RunSQL(StrSQL, 0)
            fillTable()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub gridApplication_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridApplication.CellContentDoubleClick
        oldAppID = gridApplication.CurrentRow.Cells(0).Value
        If formFlag = 1 Then
            With frmDana
                stateApp = "UPD"
                .PDana1.txtAplikasi.Text = gridApplication.CurrentRow.Cells(0).Value
            End With
        ElseIf formFlag = 3 Then
            With frmKTA
                stateApp = "UPD"
                .PKTA1.txtAplikasi.Text = gridApplication.CurrentRow.Cells(0).Value
            End With
        ElseIf formFlag = 4 Then
            With frmElektronik
                stateApp = "UPD"
                .PElektronik1.txtAplikasi.Text = gridApplication.CurrentRow.Cells(0).Value
            End With
        End If
        Me.Close()
    End Sub
    Private Sub fillTable()
        Try
            StrSQL = "SELECT TOP 100 * FROM TEMPAPPLICATION"
            RunSQL(StrSQL, 2, "TempApplication")
            gridApplication.DataSource = ds
            gridApplication.DataMember = "TempApplication"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub dropTable()
        Try
            StrSQL = "DELETE FROM TEMPAPPLICATION"
            RunSQL(StrSQL, 0)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub dropTemp()
        Try
            StrSQL = "exec sp_dropTemp"
            RunSQL(StrSQL, 0)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub txtFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilter.TextChanged
        Dim filter As String = ""
        Try
            filter = String.Format("WHERE [No.Aplikasi] LIKE '%{0}%' ", txtFilter.Text)
            filter &= String.Format("OR [POS] LIKE '%{0}%' ", txtFilter.Text)
            filter &= String.Format("OR [No.Anggota] LIKE '%{0}%' ", txtFilter.Text)
            filter &= String.Format("OR [Nama Anggota] LIKE '%{0}%' ", txtFilter.Text)
            filter &= String.Format("OR [Credit Analyst] LIKE '{0}%' ", txtFilter.Text)
            filter &= String.Format("OR [Surveyor] LIKE '%{0}%' ", txtFilter.Text)
            filter &= String.Format("OR [Salesman] LIKE '%{0}%' ", txtFilter.Text)
            StrSQL = String.Format("SELECT TOP 100 * FROM TEMPAPPLICATION {0} ORDER BY [No.Aplikasi] DESC", filter)
            RunSQL(StrSQL, 2, "TEMPAPPLICATION")
            gridApplication.DataSource = ds
            gridApplication.DataMember = "TEMPAPPLICATION"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class