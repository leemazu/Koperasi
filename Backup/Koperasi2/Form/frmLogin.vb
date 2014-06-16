Imports System.Data.SqlClient
Public Class frmLogin

  

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If txtUser.Text = "" Or txtPass.Text = "" Then
            MessageBox.Show("Input Username dan Password !", "error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Else
            connLogin.Open()
            cmdLogin = New SqlCommand("SELECT*FROM UM where UName='" & antisqli(txtUser.Text) & "' AND UPass='" & antisqli(txtPass.Text) & "'", connLogin)
            rdrLogin = cmdLogin.ExecuteReader()

            If rdrLogin.HasRows = False Then
                MessageBox.Show("Username atau Password Salah", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                While rdrLogin.Read()
                    If txtUser.Text <> rdrLogin("UName").ToString() Or txtPass.Text <> rdrLogin("UPass").ToString() Then
                        MessageBox.Show("Username atau Password Salah", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        With frmMain
                            'While rdrLogin.Read()
                            .flag.Text = rdrLogin("RefID")
                            .flag.Visible = False
                            'End While
                        End With
                        txtUser.Clear()
                        txtPass.Clear()
                        frmMain.Show()
                        Me.Hide()
                    End If
                End While
            End If
            connLogin.Close()


        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
        Application.Exit()
    End Sub

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
