Public Class frmDana

    Private Sub frmDana_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            frmTabApp.Close()
            frmTabMem.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmDana_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMain
    End Sub

   
    Private Sub PDana1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class