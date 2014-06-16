Imports System.Windows.Forms

Public Class frmMain

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        ' Create a new instance of the child form.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub

   

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticleToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If flag.Text = "MEM" Then
            EditToolStripMenuItem.Visible = False
        Else
            EditToolStripMenuItem.Visible = True
        End If
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Me.Close()
        'frmLogin.Visible = True

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmDana.Show()
        frmDana.MdiParent = Me

    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmElektronik.Show()
        frmElektronik.MdiParent = Me
    End Sub

    Private Sub DanaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DanaToolStripMenuItem.Click
        frmDana.Show()
        frmDana.MdiParent = Me
    End Sub


    
    Private Sub LogouToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogouToolStripMenuItem.Click
        Me.Hide()
        frmLogin.Show()
    End Sub

    Private Sub ElektronikToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ElektronikToolStripMenuItem.Click
        frmElektronik.Show()
        frmElektronik.MdiParent = Me
    End Sub

    Private Sub KTAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KTAToolStripMenuItem.Click
        frmKTA.Show()
        frmKTA.MdiParent = Me
    End Sub

    Private Sub KTAToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KTAToolStripMenuItem1.Click
        BastKTA.Show()
        BastKTA.MdiParent = Me
    End Sub

    Private Sub ElektronikToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ElektronikToolStripMenuItem1.Click
        BastElektronik.Show()
        BastElektronik.MdiParent = Me
    End Sub

    Private Sub DanaTunaiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DanaTunaiToolStripMenuItem.Click
        BastDana.Show()
        BastDana.MdiParent = Me
    End Sub

    Private Sub MotorBaruToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MotorBaruToolStripMenuItem.Click
        'frmMotor1.Show()
    End Sub

    Private Sub PembayaranAngsuranToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PembayaranAngsuranToolStripMenuItem.Click
        PembayaranAngsuran.Show()
        PembayaranAngsuran.MdiParent = Me
    End Sub
End Class
