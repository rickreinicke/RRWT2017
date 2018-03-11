<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditScore
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cmbWinner = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbWinType = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtScoreOrTime = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbSave = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmbWinner
        '
        Me.cmbWinner.FormattingEnabled = True
        Me.cmbWinner.Location = New System.Drawing.Point(126, 29)
        Me.cmbWinner.Name = "cmbWinner"
        Me.cmbWinner.Size = New System.Drawing.Size(337, 21)
        Me.cmbWinner.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(47, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Winner"
        '
        'cmbWinType
        '
        Me.cmbWinType.FormattingEnabled = True
        Me.cmbWinType.Location = New System.Drawing.Point(126, 56)
        Me.cmbWinType.Name = "cmbWinType"
        Me.cmbWinType.Size = New System.Drawing.Size(121, 21)
        Me.cmbWinType.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(47, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Win Type"
        '
        'txtScoreOrTime
        '
        Me.txtScoreOrTime.Location = New System.Drawing.Point(126, 83)
        Me.txtScoreOrTime.Name = "txtScoreOrTime"
        Me.txtScoreOrTime.Size = New System.Drawing.Size(121, 20)
        Me.txtScoreOrTime.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(47, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Score or Time"
        '
        'cmbSave
        '
        Me.cmbSave.Location = New System.Drawing.Point(217, 123)
        Me.cmbSave.Name = "cmbSave"
        Me.cmbSave.Size = New System.Drawing.Size(75, 23)
        Me.cmbSave.TabIndex = 6
        Me.cmbSave.Text = "Save"
        Me.cmbSave.UseVisualStyleBackColor = True
        '
        'frmEditScore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(495, 169)
        Me.Controls.Add(Me.cmbSave)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtScoreOrTime)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbWinType)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbWinner)
        Me.Name = "frmEditScore"
        Me.Text = "frmEditScore"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbWinner As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbWinType As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtScoreOrTime As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbSave As System.Windows.Forms.Button
End Class
