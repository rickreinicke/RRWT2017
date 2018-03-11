<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManageParticipantsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuildBracketsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BracketManagementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintBoutSheetsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintBracketSheetsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintParticipantListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdministrationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TournamentSetupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TroubleshootErrorsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UploadResultsToDropboxToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ssStatus = New System.Windows.Forms.StatusStrip()
        Me.USStatusBar1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.USStatusBar2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.USStatusBar3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.USStatusBar4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.USStatusBar5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.USStatusBar6 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblAppPath = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel5 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel6 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel7 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel8 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel9 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel10 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel11 = New System.Windows.Forms.LinkLabel()
        Me.MenuStrip1.SuspendLayout()
        Me.ssStatus.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ToolStripMenuItem3, Me.ToolStripMenuItem1, Me.AdministrationToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(850, 40)
        Me.MenuStrip1.TabIndex = 6
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(66, 36)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(132, 36)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2, Me.ManageParticipantsToolStripMenuItem, Me.BuildBracketsToolStripMenuItem, Me.BracketManagementToolStripMenuItem})
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(119, 36)
        Me.ToolStripMenuItem3.Text = "Manage"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(432, 36)
        Me.ToolStripMenuItem2.Text = "Setup Participant Information"
        '
        'ManageParticipantsToolStripMenuItem
        '
        Me.ManageParticipantsToolStripMenuItem.Name = "ManageParticipantsToolStripMenuItem"
        Me.ManageParticipantsToolStripMenuItem.Size = New System.Drawing.Size(432, 36)
        Me.ManageParticipantsToolStripMenuItem.Text = "Assign Participants To Classes"
        '
        'BuildBracketsToolStripMenuItem
        '
        Me.BuildBracketsToolStripMenuItem.Name = "BuildBracketsToolStripMenuItem"
        Me.BuildBracketsToolStripMenuItem.Size = New System.Drawing.Size(432, 36)
        Me.BuildBracketsToolStripMenuItem.Text = "Populate Brackets"
        '
        'BracketManagementToolStripMenuItem
        '
        Me.BracketManagementToolStripMenuItem.Name = "BracketManagementToolStripMenuItem"
        Me.BracketManagementToolStripMenuItem.Size = New System.Drawing.Size(432, 36)
        Me.BracketManagementToolStripMenuItem.Text = "Enter Results In Brackets"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintBoutSheetsToolStripMenuItem, Me.PrintBracketSheetsToolStripMenuItem, Me.PrintParticipantListToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(116, 36)
        Me.ToolStripMenuItem1.Text = "Reports"
        '
        'PrintBoutSheetsToolStripMenuItem
        '
        Me.PrintBoutSheetsToolStripMenuItem.Name = "PrintBoutSheetsToolStripMenuItem"
        Me.PrintBoutSheetsToolStripMenuItem.Size = New System.Drawing.Size(324, 36)
        Me.PrintBoutSheetsToolStripMenuItem.Text = "Print Bout Sheets"
        '
        'PrintBracketSheetsToolStripMenuItem
        '
        Me.PrintBracketSheetsToolStripMenuItem.Name = "PrintBracketSheetsToolStripMenuItem"
        Me.PrintBracketSheetsToolStripMenuItem.Size = New System.Drawing.Size(324, 36)
        Me.PrintBracketSheetsToolStripMenuItem.Text = "Print Bracket Sheets"
        '
        'PrintParticipantListToolStripMenuItem
        '
        Me.PrintParticipantListToolStripMenuItem.Name = "PrintParticipantListToolStripMenuItem"
        Me.PrintParticipantListToolStripMenuItem.Size = New System.Drawing.Size(324, 36)
        Me.PrintParticipantListToolStripMenuItem.Text = "Print Participant List"
        '
        'AdministrationToolStripMenuItem
        '
        Me.AdministrationToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TournamentSetupToolStripMenuItem, Me.TroubleshootErrorsToolStripMenuItem, Me.UploadResultsToDropboxToolStripMenuItem})
        Me.AdministrationToolStripMenuItem.Name = "AdministrationToolStripMenuItem"
        Me.AdministrationToolStripMenuItem.Size = New System.Drawing.Size(199, 36)
        Me.AdministrationToolStripMenuItem.Text = "Administration"
        '
        'TournamentSetupToolStripMenuItem
        '
        Me.TournamentSetupToolStripMenuItem.Name = "TournamentSetupToolStripMenuItem"
        Me.TournamentSetupToolStripMenuItem.Size = New System.Drawing.Size(406, 36)
        Me.TournamentSetupToolStripMenuItem.Text = "Tournament Setup"
        '
        'TroubleshootErrorsToolStripMenuItem
        '
        Me.TroubleshootErrorsToolStripMenuItem.Name = "TroubleshootErrorsToolStripMenuItem"
        Me.TroubleshootErrorsToolStripMenuItem.Size = New System.Drawing.Size(406, 36)
        Me.TroubleshootErrorsToolStripMenuItem.Text = "Troubleshoot Errors"
        '
        'UploadResultsToDropboxToolStripMenuItem
        '
        Me.UploadResultsToDropboxToolStripMenuItem.Name = "UploadResultsToDropboxToolStripMenuItem"
        Me.UploadResultsToDropboxToolStripMenuItem.Size = New System.Drawing.Size(389, 36)
        Me.UploadResultsToDropboxToolStripMenuItem.Text = "Upload Results to Website"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(80, 36)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'ssStatus
        '
        Me.ssStatus.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.ssStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.USStatusBar1, Me.USStatusBar2, Me.USStatusBar3, Me.USStatusBar4, Me.USStatusBar5, Me.USStatusBar6})
        Me.ssStatus.Location = New System.Drawing.Point(0, 436)
        Me.ssStatus.Name = "ssStatus"
        Me.ssStatus.Size = New System.Drawing.Size(850, 24)
        Me.ssStatus.TabIndex = 121
        Me.ssStatus.Text = "StatusStrip1"
        '
        'USStatusBar1
        '
        Me.USStatusBar1.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.USStatusBar1.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.USStatusBar1.Name = "USStatusBar1"
        Me.USStatusBar1.Size = New System.Drawing.Size(139, 19)
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
        Me.USStatusBar2.Size = New System.Drawing.Size(139, 19)
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
        Me.USStatusBar3.Size = New System.Drawing.Size(139, 19)
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
        Me.USStatusBar4.Size = New System.Drawing.Size(139, 19)
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
        Me.USStatusBar5.Size = New System.Drawing.Size(139, 19)
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
        Me.USStatusBar6.Size = New System.Drawing.Size(139, 19)
        Me.USStatusBar6.Spring = True
        Me.USStatusBar6.Text = "USStatusBar6"
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.Label1.Font = New System.Drawing.Font("Georgia", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(190, 368)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(489, 25)
        Me.Label1.TabIndex = 122
        Me.Label1.Text = "Round Robin Wrestling Tournament Helper"
        '
        'lblAppPath
        '
        Me.lblAppPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAppPath.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.lblAppPath.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblAppPath.Location = New System.Drawing.Point(12, 407)
        Me.lblAppPath.Name = "lblAppPath"
        Me.lblAppPath.Size = New System.Drawing.Size(826, 13)
        Me.lblAppPath.TabIndex = 124
        Me.lblAppPath.Text = "AppPath"
        Me.lblAppPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(41, 83)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(562, 268)
        Me.PictureBox1.TabIndex = 126
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(652, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 13)
        Me.Label2.TabIndex = 127
        Me.Label2.Text = "Basic Work Flow"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(634, 95)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(151, 13)
        Me.LinkLabel1.TabIndex = 128
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Setup Tournament Parameters"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Location = New System.Drawing.Point(634, 119)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(108, 13)
        Me.LinkLabel2.TabIndex = 129
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Weigh-In Participants"
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.Location = New System.Drawing.Point(634, 143)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(190, 13)
        Me.LinkLabel3.TabIndex = 130
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "Create Classes and Assign Participants"
        '
        'LinkLabel4
        '
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.Location = New System.Drawing.Point(634, 167)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(94, 13)
        Me.LinkLabel4.TabIndex = 131
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Text = "Populate Brackets"
        '
        'LinkLabel5
        '
        Me.LinkLabel5.AutoSize = True
        Me.LinkLabel5.Location = New System.Drawing.Point(634, 287)
        Me.LinkLabel5.Name = "LinkLabel5"
        Me.LinkLabel5.Size = New System.Drawing.Size(70, 13)
        Me.LinkLabel5.TabIndex = 132
        Me.LinkLabel5.TabStop = True
        Me.LinkLabel5.Text = "Enter Results"
        '
        'LinkLabel6
        '
        Me.LinkLabel6.AutoSize = True
        Me.LinkLabel6.Location = New System.Drawing.Point(634, 191)
        Me.LinkLabel6.Name = "LinkLabel6"
        Me.LinkLabel6.Size = New System.Drawing.Size(186, 13)
        Me.LinkLabel6.TabIndex = 133
        Me.LinkLabel6.TabStop = True
        Me.LinkLabel6.Text = "Print Bout Sheets and Bracket Sheets"
        '
        'LinkLabel7
        '
        Me.LinkLabel7.AutoSize = True
        Me.LinkLabel7.Location = New System.Drawing.Point(634, 215)
        Me.LinkLabel7.Name = "LinkLabel7"
        Me.LinkLabel7.Size = New System.Drawing.Size(150, 13)
        Me.LinkLabel7.TabIndex = 134
        Me.LinkLabel7.TabStop = True
        Me.LinkLabel7.Text = "Distribute Bout Sheets to Mats"
        '
        'LinkLabel8
        '
        Me.LinkLabel8.AutoSize = True
        Me.LinkLabel8.Location = New System.Drawing.Point(634, 239)
        Me.LinkLabel8.Name = "LinkLabel8"
        Me.LinkLabel8.Size = New System.Drawing.Size(43, 13)
        Me.LinkLabel8.TabIndex = 135
        Me.LinkLabel8.TabStop = True
        Me.LinkLabel8.Text = "Wrestle"
        '
        'LinkLabel9
        '
        Me.LinkLabel9.AutoSize = True
        Me.LinkLabel9.Location = New System.Drawing.Point(634, 263)
        Me.LinkLabel9.Name = "LinkLabel9"
        Me.LinkLabel9.Size = New System.Drawing.Size(100, 13)
        Me.LinkLabel9.TabIndex = 136
        Me.LinkLabel9.TabStop = True
        Me.LinkLabel9.Text = "Collect Bout Sheets"
        '
        'LinkLabel10
        '
        Me.LinkLabel10.AutoSize = True
        Me.LinkLabel10.Location = New System.Drawing.Point(634, 311)
        Me.LinkLabel10.Name = "LinkLabel10"
        Me.LinkLabel10.Size = New System.Drawing.Size(187, 13)
        Me.LinkLabel10.TabIndex = 137
        Me.LinkLabel10.TabStop = True
        Me.LinkLabel10.Text = "Print Updated Bracket Sheets for Wall"
        '
        'LinkLabel11
        '
        Me.LinkLabel11.AutoSize = True
        Me.LinkLabel11.Location = New System.Drawing.Point(634, 335)
        Me.LinkLabel11.Name = "LinkLabel11"
        Me.LinkLabel11.Size = New System.Drawing.Size(133, 13)
        Me.LinkLabel11.TabIndex = 138
        Me.LinkLabel11.TabStop = True
        Me.LinkLabel11.Text = "Upload Results to Website"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(850, 460)
        Me.Controls.Add(Me.LinkLabel11)
        Me.Controls.Add(Me.LinkLabel10)
        Me.Controls.Add(Me.LinkLabel9)
        Me.Controls.Add(Me.LinkLabel8)
        Me.Controls.Add(Me.LinkLabel7)
        Me.Controls.Add(Me.LinkLabel6)
        Me.Controls.Add(Me.LinkLabel5)
        Me.Controls.Add(Me.LinkLabel4)
        Me.Controls.Add(Me.LinkLabel3)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblAppPath)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ssStatus)
        Me.Controls.Add(Me.MenuStrip1)
        Me.DoubleBuffered = True
        Me.ForeColor = System.Drawing.Color.CadetBlue
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MainForm"
        Me.Text = "RRWT Main"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ssStatus.ResumeLayout(False)
        Me.ssStatus.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AdministrationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ssStatus As System.Windows.Forms.StatusStrip
    Friend WithEvents USStatusBar1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents USStatusBar2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents USStatusBar3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents USStatusBar4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents USStatusBar5 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents USStatusBar6 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblAppPath As System.Windows.Forms.Label
    Friend WithEvents PrintBoutSheetsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ManageParticipantsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuildBracketsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BracketManagementToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TournamentSetupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintBracketSheetsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TroubleshootErrorsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UploadResultsToDropboxToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintParticipantListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel3 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel4 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel5 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel6 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel7 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel8 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel9 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel10 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel11 As System.Windows.Forms.LinkLabel

End Class
