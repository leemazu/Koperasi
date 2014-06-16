Imports System.Data.SqlClient
Public Class frmTabMem

    Private Sub frmTabMem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'dropTable()
            'Try
            '    dropTable()
            '    dropTemp()
            'Catch ex As Exception

            'End Try
            'conn.Open()
            'cmd = New SqlCommand("exec Sp_tempApplication", conn)
            'cmd.ExecuteNonQuery()

            fillTable()



        Catch ex As Exception
            'conn.Close()
        End Try
        'conn.Close()
        'dropTable()
    End Sub

    Private Sub fillTable()
        Dim connFill = New SqlConnection(strconn)
        Dim cmdFill As SqlCommand
        Dim strFill As String
        Dim daFill As SqlDataAdapter
        Dim dsFill As New DataSet

        Try
            strFill = "SELECT TOP 100 MemberID as[ID],MemberName as [Nama],PersonalIdentity as [No.KTP],Address as [Alamat] FROM Member ORDER BY MemberID DESC"
            cmdFill = New SqlCommand(strFill, connFill)
            daFill = New SqlDataAdapter(cmdFill)
            connFill.Open()
            daFill.Fill(dsFill, "MEMBER")
            connFill.Close()
            gridMember.DataSource = dsFill
            gridMember.DataMember = "MEMBER"

        Catch ex As Exception
            connFill.Close()
        End Try
        connFill.Close()

        'Try
        '    connFill.Open()
        '    strFill = "SELECT*FROM TEMPAPPLICATION"
        '    cmdFill = New SqlCommand(strFill, connFill)
        '    da = New SqlDataAdapter(cmdFill)
        '    da.Fill(ds, "tempApplication")
        '    gridApplication.DataSource = ds.Tables(0)
        '    gridApplication.DataMember = "tempApplication"
        'Catch ex As Exception

        'End Try
        'connFill.Close()
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

    Private Sub DataGridView1_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridMember.CellContentDoubleClick
        oldMemberID = gridMember.CurrentRow.Cells(0).Value
        If formFlag = 1 Then
            With frmDana
                stateMember = "UPD"
                .PDana1.txtPemNo.Text = gridMember.CurrentRow.Cells(0).Value
            End With
        ElseIf formFlag = 3 Then
            With frmKTA
                stateMember = "UPD"
                .PKTA1.txtPemNo.Text = gridMember.CurrentRow.Cells(0).Value
            End With
        ElseIf formFlag = 4 Then
            With frmElektronik
                stateMember = "UPD"
                .PElektronik1.txtPemNo.Text = gridMember.CurrentRow.Cells(0).Value
            End With
        ElseIf formFlag = 5 Then
            With frmKwitansi
                .txtIdKonsumen.Text = gridMember.CurrentRow.Cells(0).Value
                .txtNamaKonsumen.Text = gridMember.CurrentRow.Cells(1).Value
            End With
        End If
        

        Me.Close()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilter.TextChanged
        Dim connFilter = New SqlConnection(strconn)
        Dim cmdFilter As SqlCommand
        Dim strFilter As String
        Dim filter As String = ""
        Dim daFilter As SqlDataAdapter
        Dim dsFilter As New DataSet


        Try
            filter = "WHERE [MemberID] LIKE '%" + txtFilter.Text + "%' "
            filter &= "OR [MemberName] LIKE '%" + txtFilter.Text + "%' "
            filter &= "OR [PersonalIdentity] LIKE '%" + txtFilter.Text + "%' "
            filter &= "OR [Address] LIKE '%" + txtFilter.Text + "%' "
            strFilter = "SELECT TOP 100 MemberId,MemberName,PersonalIdentity,Address FROM MEMBER " + filter + " ORDER BY [MemberId] DESC"
            cmdFilter = New SqlCommand(strFilter, connFilter)
            daFilter = New SqlDataAdapter(cmdFilter)
            connFilter.Open()
            daFilter.Fill(dsFilter, "MEMBER")
            connFilter.Close()
            gridMember.DataSource = dsFilter
            gridMember.DataMember = "MEMBER"

        Catch ex As Exception
            connFilter.Close()
        End Try
        connFilter.Close()
    End Sub

End Class