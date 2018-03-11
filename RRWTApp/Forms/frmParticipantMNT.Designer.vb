<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmParticipantMNT
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
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.cmbTeam = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtWeight = New System.Windows.Forms.TextBox()
        Me.cmbDivision = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbClass = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.cmbRating = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtAge = New System.Windows.Forms.TextBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.dgvParticipants = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditParticipantToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteParticipantToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmbDivisionTop = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.grpEditBox = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnLoadParticipants = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ssStatus = New System.Windows.Forms.StatusStrip()
        Me.USStatusBar1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.USStatusBar2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.USStatusBar3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.USStatusBar4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.USStatusBar5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.USStatusBar6 = New System.Windows.Forms.ToolStripStatusLabel()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvParticipants, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.grpEditBox.SuspendLayout()
        Me.ssStatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Name"
        '
        'txtName
        '
        Me.txtName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(69, 14)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(259, 26)
        Me.txtName.TabIndex = 1
        '
        'cmbTeam
        '
        Me.cmbTeam.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbTeam.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTeam.FormattingEnabled = True
        Me.cmbTeam.Location = New System.Drawing.Point(69, 53)
        Me.cmbTeam.Name = "cmbTeam"
        Me.cmbTeam.Size = New System.Drawing.Size(147, 28)
        Me.cmbTeam.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Team"
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Age"
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 136)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Weight"
        '
        'txtWeight
        '
        Me.txtWeight.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtWeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWeight.Location = New System.Drawing.Point(69, 133)
        Me.txtWeight.Name = "txtWeight"
        Me.txtWeight.Size = New System.Drawing.Size(126, 26)
        Me.txtWeight.TabIndex = 4
        '
        'cmbDivision
        '
        Me.cmbDivision.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbDivision.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDivision.FormattingEnabled = True
        Me.cmbDivision.Location = New System.Drawing.Point(69, 172)
        Me.cmbDivision.Name = "cmbDivision"
        Me.cmbDivision.Size = New System.Drawing.Size(147, 28)
        Me.cmbDivision.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 175)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Division"
        '
        'cmbClass
        '
        Me.cmbClass.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbClass.Enabled = False
        Me.cmbClass.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbClass.FormattingEnabled = True
        Me.cmbClass.Location = New System.Drawing.Point(69, 212)
        Me.cmbClass.Name = "cmbClass"
        Me.cmbClass.Size = New System.Drawing.Size(147, 28)
        Me.cmbClass.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(11, 215)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Class"
        '
        'txtNote
        '
        Me.txtNote.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNote.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNote.Location = New System.Drawing.Point(69, 292)
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(259, 26)
        Me.txtNote.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 295)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Note"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(598, 19)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 25)
        Me.btnSave.TabIndex = 8
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'cmbRating
        '
        Me.cmbRating.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbRating.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRating.FormattingEnabled = True
        Me.cmbRating.Items.AddRange(New Object() {"", "*", "**", "***"})
        Me.cmbRating.Location = New System.Drawing.Point(69, 252)
        Me.cmbRating.Name = "cmbRating"
        Me.cmbRating.Size = New System.Drawing.Size(98, 28)
        Me.cmbRating.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(11, 255)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Rating"
        '
        'Label9
        '
        Me.Label9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(256, -1)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(231, 16)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Add/Change/Delete Participants"
        '
        'txtAge
        '
        Me.txtAge.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAge.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAge.Location = New System.Drawing.Point(69, 93)
        Me.txtAge.Name = "txtAge"
        Me.txtAge.Size = New System.Drawing.Size(98, 26)
        Me.txtAge.TabIndex = 3
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'dgvParticipants
        '
        Me.dgvParticipants.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvParticipants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvParticipants.Location = New System.Drawing.Point(12, 67)
        Me.dgvParticipants.Name = "dgvParticipants"
        Me.dgvParticipants.RowTemplate.Height = 33
        Me.dgvParticipants.Size = New System.Drawing.Size(326, 343)
        Me.dgvParticipants.TabIndex = 19
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditParticipantToolStripMenuItem, Me.DeleteParticipantToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(167, 48)
        '
        'EditParticipantToolStripMenuItem
        '
        Me.EditParticipantToolStripMenuItem.Name = "EditParticipantToolStripMenuItem"
        Me.EditParticipantToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.EditParticipantToolStripMenuItem.Text = "Display for Edit"
        '
        'DeleteParticipantToolStripMenuItem
        '
        Me.DeleteParticipantToolStripMenuItem.Name = "DeleteParticipantToolStripMenuItem"
        Me.DeleteParticipantToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.DeleteParticipantToolStripMenuItem.Text = "Display for Delete"
        '
        'cmbDivisionTop
        '
        Me.cmbDivisionTop.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDivisionTop.FormattingEnabled = True
        Me.cmbDivisionTop.Location = New System.Drawing.Point(65, 12)
        Me.cmbDivisionTop.Name = "cmbDivisionTop"
        Me.cmbDivisionTop.Size = New System.Drawing.Size(139, 32)
        Me.cmbDivisionTop.TabIndex = 20
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 23)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 13)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Division:"
        '
        'grpEditBox
        '
        Me.grpEditBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpEditBox.Controls.Add(Me.txtAge)
        Me.grpEditBox.Controls.Add(Me.Label8)
        Me.grpEditBox.Controls.Add(Me.cmbRating)
        Me.grpEditBox.Controls.Add(Me.Label7)
        Me.grpEditBox.Controls.Add(Me.txtNote)
        Me.grpEditBox.Controls.Add(Me.Label6)
        Me.grpEditBox.Controls.Add(Me.cmbClass)
        Me.grpEditBox.Controls.Add(Me.Label5)
        Me.grpEditBox.Controls.Add(Me.cmbDivision)
        Me.grpEditBox.Controls.Add(Me.txtWeight)
        Me.grpEditBox.Controls.Add(Me.Label4)
        Me.grpEditBox.Controls.Add(Me.Label3)
        Me.grpEditBox.Controls.Add(Me.Label2)
        Me.grpEditBox.Controls.Add(Me.cmbTeam)
        Me.grpEditBox.Controls.Add(Me.txtName)
        Me.grpEditBox.Controls.Add(Me.Label1)
        Me.grpEditBox.Location = New System.Drawing.Point(346, 50)
        Me.grpEditBox.Name = "grpEditBox"
        Me.grpEditBox.Size = New System.Drawing.Size(345, 332)
        Me.grpEditBox.TabIndex = 22
        Me.grpEditBox.TabStop = False
        Me.grpEditBox.Text = "Edit Box"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(514, 19)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.TabIndex = 23
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Location = New System.Drawing.Point(430, 19)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 25)
        Me.btnDelete.TabIndex = 24
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnLoadParticipants
        '
        Me.btnLoadParticipants.Location = New System.Drawing.Point(210, 18)
        Me.btnLoadParticipants.Name = "btnLoadParticipants"
        Me.btnLoadParticipants.Size = New System.Drawing.Size(112, 23)
        Me.btnLoadParticipants.TabIndex = 25
        Me.btnLoadParticipants.Text = "Load Participants"
        Me.btnLoadParticipants.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNew.Location = New System.Drawing.Point(346, 20)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(75, 23)
        Me.btnNew.TabIndex = 26
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(15, 50)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(285, 13)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = "Right-Click on a line to Display for Edit or Delete Participant"
        '
        'ssStatus
        '
        Me.ssStatus.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.ssStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.USStatusBar1, Me.USStatusBar2, Me.USStatusBar3, Me.USStatusBar4, Me.USStatusBar5, Me.USStatusBar6})
        Me.ssStatus.Location = New System.Drawing.Point(0, 426)
        Me.ssStatus.Name = "ssStatus"
        Me.ssStatus.Size = New System.Drawing.Size(697, 24)
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
        Me.USStatusBar1.Size = New System.Drawing.Size(113, 19)
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
        Me.USStatusBar2.Size = New System.Drawing.Size(113, 19)
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
        Me.USStatusBar3.Size = New System.Drawing.Size(113, 19)
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
        Me.USStatusBar4.Size = New System.Drawing.Size(113, 19)
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
        Me.USStatusBar5.Size = New System.Drawing.Size(113, 19)
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
        Me.USStatusBar6.Size = New System.Drawing.Size(113, 19)
        Me.USStatusBar6.Spring = True
        Me.USStatusBar6.Text = "USStatusBar6"
        '
        'frmParticipantMNT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(697, 450)
        Me.Controls.Add(Me.ssStatus)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnLoadParticipants)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.grpEditBox)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cmbDivisionTop)
        Me.Controls.Add(Me.dgvParticipants)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.btnSave)
        Me.Name = "frmParticipantMNT"
        Me.Text = "frmParticipantMNT"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvParticipants, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.grpEditBox.ResumeLayout(False)
        Me.grpEditBox.PerformLayout()
        Me.ssStatus.ResumeLayout(False)
        Me.ssStatus.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents cmbTeam As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtWeight As System.Windows.Forms.TextBox
    Friend WithEvents cmbDivision As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbClass As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents cmbRating As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtAge As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents dgvParticipants As System.Windows.Forms.DataGridView
    Friend WithEvents cmbDivisionTop As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditParticipantToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteParticipantToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents grpEditBox As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnLoadParticipants As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ssStatus As System.Windows.Forms.StatusStrip
    Friend WithEvents USStatusBar1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents USStatusBar2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents USStatusBar3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents USStatusBar4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents USStatusBar5 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents USStatusBar6 As System.Windows.Forms.ToolStripStatusLabel
End Class
