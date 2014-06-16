Imports System.Data.SqlClient

Public Class MultiReportView

    Private Sub MultiReportView_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        deltempTTB()
        deltempTTU()
        deltempTTBarang()
    End Sub

    Private Sub MultiReportView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMain
        'Me.ControlBox = True

    End Sub

    Private Sub deltempTTU()
        Try
            RepSQL = "DELETE FROM TTU"
            cmdRep = New SqlCommand(RepSQL, connRep)

            connRep.Open()
            cmdRep.ExecuteNonQuery()


        Catch ex As Exception

        End Try
        connRep.Close()
    End Sub

    Private Sub deltempTTB()
        Try
            RepSQL = "DELETE FROM TANDATERIMABPKB"
            cmdRep = New SqlCommand(RepSQL, connRep)

            connRep.Open()
            cmdRep.ExecuteNonQuery()


        Catch ex As Exception

        End Try
        connRep.Close()
    End Sub

    Private Sub deltempTTBarang()
        Try
            RepSQL = "DELETE FROM TANDATERIMABARANG"
            cmdRep = New SqlCommand(RepSQL, connRep)

            connRep.Open()
            cmdRep.ExecuteNonQuery()


        Catch ex As Exception

        End Try
        connRep.Close()
    End Sub


End Class