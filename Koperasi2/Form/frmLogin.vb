Imports System.Data.SqlClient
Public Class frmLogin

    Dim counter As Integer = 0

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call con_getsetting()
        If conn_open() = True Then
            Dim pass As String
            Using cmd As New SqlCommand(String.Format("SELECT UserPass From Account Where UserID='{0}'", Textbox1.Text.Replace("'", "").Replace("--", "")), conn)
                pass = cmd.ExecuteScalar
                If pass <> Nothing Then
                    If pass = Textbox2.Text Then
                        MessageBox.Show("Login Success!!", "Mulya", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        mainFormSetting()
                        frmMain.Show()
                        Me.Hide()
                    Else
                        counter += 1
                        If counter <> 3 Then
                            MessageBox.Show("Password Salah")
                        Else
                            MessageBox.Show(String.Format("Password Salah{0}Anda Sudah 3X Gagal melakukan Login!", vbNewLine))
                            Me.Close()
                        End If
                    End If
                Else
                    counter += 1
                    If counter <> 3 Then
                        MessageBox.Show("Username Salah")
                    Else
                        MessageBox.Show(String.Format("Username Salah{0}Anda Sudah 3X Gagal melakukan Login!", vbNewLine))
                        Me.Close()
                    End If

                End If
            End Using
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim frm As New frmSelectServer
        frm.ShowDialog()
    End Sub

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Textbox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Textbox1.KeyPress
        If e.KeyChar = Chr(13) Then Textbox2.Focus()
    End Sub

    Private Sub Textbox2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Textbox2.KeyPress
        If e.KeyChar = Chr(13) Then Call OK_Click(Button1, New System.EventArgs)
    End Sub

    Private Sub mainFormSetting()
        Dim level As String
        StrSQL = ""
        StrSQL = "SELECT ReferenceID from Account WHERE UserId ='" & Textbox1.Text & "' "
        StrSQL &= "AND UserPass = '" & Textbox2.Text & "'"
        RunSQL(StrSQL, 1)

        level = CStr(dt.Rows(0)("ReferenceID"))
        With frmMain
            If level = "UL01" Then
                .KwitansiToolStripMenuItem.Visible = True
            Else
                .KwitansiToolStripMenuItem.Visible = False
            End If
        End With
    End Sub

End Class
