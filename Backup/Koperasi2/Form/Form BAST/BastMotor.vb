Public Class BastMotor

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    End Sub

    Private Sub BastKTA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            RunSQL("SP_dropTemp", 0)
        Catch ex As Exception

        End Try


        FillTable()

    End Sub

    Private Sub FillTable()
        RunSQL("SP_tempApplication '" & "3" & "' ", 0)
        RunSQL("SELECT TOP 10 * FROM TempApplication", 2, "TempApplication")
        gv1.DataSource = ds
        gv1.DataMember = "TempApplication"
    End Sub

    Private Sub txtCari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCari.TextChanged
        StrSQL = "SELECT TOP 100 * From TempApplication "
    End Sub
End Class