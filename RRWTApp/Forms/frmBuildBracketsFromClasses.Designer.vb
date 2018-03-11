<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuildBracketsFromClasses
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBuildBracketsFromClasses))
        Me.btnBegin = New System.Windows.Forms.Button()
        Me.cmbDivisions = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblFeedback = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnBegin
        '
        Me.btnBegin.Location = New System.Drawing.Point(239, 22)
        Me.btnBegin.Name = "btnBegin"
        Me.btnBegin.Size = New System.Drawing.Size(243, 28)
        Me.btnBegin.TabIndex = 0
        Me.btnBegin.Text = "Begin Populating Brackets From Classes"
        Me.btnBegin.UseVisualStyleBackColor = True
        '
        'cmbDivisions
        '
        Me.cmbDivisions.FormattingEnabled = True
        Me.cmbDivisions.Location = New System.Drawing.Point(69, 27)
        Me.cmbDivisions.Name = "cmbDivisions"
        Me.cmbDivisions.Size = New System.Drawing.Size(164, 21)
        Me.cmbDivisions.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Division:"
        '
        'lblFeedback
        '
        Me.lblFeedback.AutoSize = True
        Me.lblFeedback.Location = New System.Drawing.Point(488, 30)
        Me.lblFeedback.Name = "lblFeedback"
        Me.lblFeedback.Size = New System.Drawing.Size(13, 13)
        Me.lblFeedback.TabIndex = 4
        Me.lblFeedback.Text = "_"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(34, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(579, 48)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = resources.GetString("Label2.Text")
        '
        'frmBuildBracketsFromClasses
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(641, 108)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblFeedback)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbDivisions)
        Me.Controls.Add(Me.btnBegin)
        Me.Name = "frmBuildBracketsFromClasses"
        Me.Text = "frmBuildBracketsFromClasses"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnBegin As System.Windows.Forms.Button
    Friend WithEvents cmbDivisions As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblFeedback As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
