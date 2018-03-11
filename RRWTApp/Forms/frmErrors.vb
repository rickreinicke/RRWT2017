Public Class frmErrors

    Private Sub frmErrors_Load(sender As Object, e As EventArgs) Handles Me.Load
        For Each file As String In IO.Directory.GetFiles(Login.ErrorLogPath, "*.*")
            ListBox1.Items.Add(file)
        Next
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If Strings.Right(ListBox1.SelectedItem.ToString(), 4) = ".Jpg" Then
            Dim img As Image = Image.FromFile(ListBox1.SelectedItem.ToString())
            Me.PictureBox1.Image = img
        End If
        If Strings.Right(ListBox1.SelectedItem.ToString(), 4) = ".Log" Then
            TextBox1.Text = System.IO.File.ReadAllText(ListBox1.SelectedItem.ToString())
        End If
    End Sub


End Class