<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTournySetup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTournySetup))
        Me.dgvDivisions = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvWinTypes = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTournamentName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ssStatus = New System.Windows.Forms.StatusStrip()
        Me.USStatusBar1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.USStatusBar2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.USStatusBar3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.USStatusBar4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.USStatusBar5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.USStatusBar6 = New System.Windows.Forms.ToolStripStatusLabel()
        CType(Me.dgvDivisions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvWinTypes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ssStatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvDivisions
        '
        Me.dgvDivisions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDivisions.Location = New System.Drawing.Point(41, 101)
        Me.dgvDivisions.Name = "dgvDivisions"
        Me.dgvDivisions.Size = New System.Drawing.Size(276, 304)
        Me.dgvDivisions.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Divisions"
        '
        'dgvWinTypes
        '
        Me.dgvWinTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvWinTypes.Location = New System.Drawing.Point(335, 101)
        Me.dgvWinTypes.Name = "dgvWinTypes"
        Me.dgvWinTypes.Size = New System.Drawing.Size(356, 304)
        Me.dgvWinTypes.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(332, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Win Types"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(41, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(276, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Do Not Change After Any Participants Have Been Added"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(332, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(260, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Do Not Change After Any Scores Have Been Entered"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(41, 30)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Tournament Name"
        '
        'txtTournamentName
        '
        Me.txtTournamentName.Location = New System.Drawing.Point(153, 27)
        Me.txtTournamentName.MaxLength = 98
        Me.txtTournamentName.Name = "txtTournamentName"
        Me.txtTournamentName.Size = New System.Drawing.Size(538, 20)
        Me.txtTournamentName.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(12, 408)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(710, 42)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = resources.GetString("Label6.Text")
        '
        'ssStatus
        '
        Me.ssStatus.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.ssStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.USStatusBar1, Me.USStatusBar2, Me.USStatusBar3, Me.USStatusBar4, Me.USStatusBar5, Me.USStatusBar6})
        Me.ssStatus.Location = New System.Drawing.Point(0, 454)
        Me.ssStatus.Name = "ssStatus"
        Me.ssStatus.Size = New System.Drawing.Size(734, 24)
        Me.ssStatus.TabIndex = 122
        Me.ssStatus.Text = "StatusStrip1"
        '
        'USStatusBar1
        '
        Me.USStatusBar1.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.USStatusBar1.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.USStatusBar1.Name = "USStatusBar1"
        Me.USStatusBar1.Size = New System.Drawing.Size(119, 19)
        Me.USStatusBar1.Spring = True
        Me.USStatusBar1.Text = "USStatusBar1"
        '
        'USStatusBar2
        '
        Me.USStatusBar2.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.USStatusBar2.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.USStatusBar2.Name = "USStatusBar2"
        Me.USStatusBar2.Size = New System.Drawing.Size(119, 19)
        Me.USStatusBar2.Spring = True
        Me.USStatusBar2.Text = "USStatusBar2"
        '
        'USStatusBar3
        '
        Me.USStatusBar3.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.USStatusBar3.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.USStatusBar3.Name = "USStatusBar3"
        Me.USStatusBar3.Size = New System.Drawing.Size(119, 19)
        Me.USStatusBar3.Spring = True
        Me.USStatusBar3.Text = "USStatusBar3"
        '
        'USStatusBar4
        '
        Me.USStatusBar4.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.USStatusBar4.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.USStatusBar4.Name = "USStatusBar4"
        Me.USStatusBar4.Size = New System.Drawing.Size(119, 19)
        Me.USStatusBar4.Spring = True
        Me.USStatusBar4.Text = "USStatusBar4"
        '
        'USStatusBar5
        '
        Me.USStatusBar5.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.USStatusBar5.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.USStatusBar5.Name = "USStatusBar5"
        Me.USStatusBar5.Size = New System.Drawing.Size(119, 19)
        Me.USStatusBar5.Spring = True
        Me.USStatusBar5.Text = "USStatusBar5"
        '
        'USStatusBar6
        '
        Me.USStatusBar6.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.USStatusBar6.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.USStatusBar6.Name = "USStatusBar6"
        Me.USStatusBar6.Size = New System.Drawing.Size(119, 19)
        Me.USStatusBar6.Spring = True
        Me.USStatusBar6.Text = "USStatusBar6"
        '
        'frmTournySetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 478)
        Me.Controls.Add(Me.ssStatus)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtTournamentName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dgvWinTypes)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvDivisions)
        Me.Name = "frmTournySetup"
        Me.Text = "TournySetup"
        CType(Me.dgvDivisions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvWinTypes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ssStatus.ResumeLayout(False)
        Me.ssStatus.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvDivisions As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvWinTypes As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTournamentName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ssStatus As System.Windows.Forms.StatusStrip
    Friend WithEvents USStatusBar1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents USStatusBar2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents USStatusBar3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents USStatusBar4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents USStatusBar5 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents USStatusBar6 As System.Windows.Forms.ToolStripStatusLabel
End Class
