Imports System.Data.SqlClient
Public Class frmTabApp
    Dim flag
    Dim sender As Integer

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'dropTable()
            Try
                dropTable()
                dropTemp()
            Catch ex As Exception

            End Try
            conn.Open()
            cmd = New SqlCommand("exec Sp_tempApplication '" & txtFlag.Text & "'", conn)
            cmd.ExecuteNonQuery()

            fillTable()



        Catch ex As Exception
            conn.Close()
        End Try
        conn.Close()
        'dropTable()

    End Sub

    Private Sub gridApplication_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridApplication.CellContentDoubleClick
        oldAppID = gridApplication.CurrentRow.Cells(0).Value
        'posFlag = True
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
        Dim connFill = New SqlConnection(strconn)
        Dim cmdFill As SqlCommand
        Dim strFill As String
        Dim daFill As SqlDataAdapter
        Dim dsFill As New DataSet

        Try
            'MessageBox.Show(sender)
            strFill = "SELECT TOP 100 * FROM TEMPAPPLICATION"
            cmdFill = New SqlCommand(strFill, connFill)
            daFill = New SqlDataAdapter(cmdFill)
            connFill.Open()
            daFill.Fill(dsFill, "TEMPAPPLICATION")
            connFill.Close()
            gridApplication.DataSource = dsFill
            gridApplication.DataMember = "TEMPAPPLICATION"

        Catch ex As Exception
            connFill.Close()
        End Try
        connFill.Close()

       
    End Sub

    Private Sub dropTable()
        Dim conndrop = New SqlConnection(strconn)
        Dim cmddrop As SqlCommand
        Dim strdrop As String

        Try
            strdrop = "DELETE FROM TEMPAPPLICATION"
            cmddrop = New SqlCommand(strdrop, conndrop)
            conndrop.Open()
            cmddrop.ExecuteNonQuery()

        Catch ex As Exception
            conndrop.Close()

        End Try
        conndrop.Close()
    End Sub

    Private Sub dropTemp()
        Dim connTemp = New SqlConnection(strconn)
        Dim cmdTemp As SqlCommand
        Dim strTemp As String

        Try
            strTemp = "exec sp_dropTemp"
            cmdTemp = New SqlCommand(strTemp, connTemp)
            connTemp.Open()
            cmdTemp.ExecuteNonQuery()

        Catch ex As Exception

        End Try
        connTemp.Close()
    End Sub


    Private Sub txtFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilter.TextChanged
        Dim connFilter = New SqlConnection(strconn)
        Dim cmdFilter As SqlCommand
        Dim strFilter As String
        Dim filter As String = ""
        Dim daFilter As SqlDataAdapter
        Dim dsFilter As New DataSet


        Try
            filter = "WHERE [No.Aplikasi] LIKE '%" + txtFilter.Text + "%' "
            filter &= "OR [POS] LIKE '%" + txtFilter.Text + "%' "
            filter &= "OR [No.Anggota] LIKE '%" + txtFilter.Text + "%' "
            filter &= "OR [Nama Anggota] LIKE '%" + txtFilter.Text + "%' "
            filter &= "OR [Credit Analyst] LIKE '" + txtFilter.Text + "%' "
            filter &= "OR [Surveyor] LIKE '%" + txtFilter.Text + "%' "
            filter &= "OR [Salesman] LIKE '%" + txtFilter.Text + "%' "
            'filter &= "AND [ApplicationTypeID] = '" & txtFlag.Text & "' "
            'filter &= "AND [ApplicationTypeID]='" & formFlag & "' "
            strFilter = "SELECT TOP 100 * FROM TEMPAPPLICATION " + filter + " ORDER BY [No.Aplikasi] DESC"
            cmdFilter = New SqlCommand(strFilter, connFilter)
            daFilter = New SqlDataAdapter(cmdFilter)
            connFilter.Open()
            daFilter.Fill(dsFilter, "TEMPAPPLICATION")
            connFilter.Close()
            gridApplication.DataSource = dsFilter
            gridApplication.DataMember = "TEMPAPPLICATION"

        Catch ex As Exception
            connFilter.Close()
        End Try
        connFilter.Close()
    End Sub


End Class