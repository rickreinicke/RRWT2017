Public Class frmEditScore

    Private Sub frmEditScore_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(34) Or e.KeyChar = Microsoft.VisualBasic.ChrW(39) Then
            e.Handled = True
        End If

    End Sub


    Private Sub frmEditScore_Load(sender As Object, e As EventArgs) Handles Me.Load
        KeyPreview = True
    End Sub

    Private Sub Load_WinnerCombo()
        cmbSave.Tag = "SaveNotClicked"


    End Sub

    Private Sub cmbSave_Click(sender As Object, e As EventArgs) Handles cmbSave.Click
        'Validate form
        If Me.txtScoreOrTime.Text.Trim.Length = 0 And cmbWinType.Text <> "Bye" Then
            MsgBox("ScoreOrTime must not be blank.")
            Exit Sub
        End If
        If cmbWinner.SelectedValue < 1 Then
            MsgBox("Winner must be selected")
            Exit Sub
        End If
        If cmbWinType.SelectedValue < 1 Then
            MsgBox("Win Type must not be blank")
            Exit Sub
        End If
        cmbSave.Tag = "SaveClicked"
        Me.Hide()
    End Sub
End Class