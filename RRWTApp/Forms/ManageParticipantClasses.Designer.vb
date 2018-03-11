<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManageParticipantClasses
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ManageParticipantClasses))
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AssignToClassToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnAssignClassFromParticipantToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.PrintBoutSelectedBoutSheetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintSelectedBracketToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmbDivision = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.dgvClasses = New System.Windows.Forms.DataGridView()
        Me.dgvParticipants = New System.Windows.Forms.DataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.btnUnAssign = New System.Windows.Forms.Button()
        Me.btnAssign = New System.Windows.Forms.Button()
        Me.btnDeleteClass = New System.Windows.Forms.Button()
        Me.btnEditClass = New System.Windows.Forms.Button()
        Me.btnCreateClass = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.dgvClasses, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvParticipants, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Enabled = False
        Me.ContextMenuStrip1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AssignToClassToolStripMenuItem, Me.UnAssignClassFromParticipantToolStripMenuItem, Me.ToolStripSeparator1, Me.PrintBoutSelectedBoutSheetToolStripMenuItem, Me.PrintSelectedBracketToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(372, 130)
        '
        'AssignToClassToolStripMenuItem
        '
        Me.AssignToClassToolStripMenuItem.Enabled = False
        Me.AssignToClassToolStripMenuItem.Name = "AssignToClassToolStripMenuItem"
        Me.AssignToClassToolStripMenuItem.Size = New System.Drawing.Size(371, 30)
        Me.AssignToClassToolStripMenuItem.Text = "Assign Participant To Class"
        '
        'UnAssignClassFromParticipantToolStripMenuItem
        '
        Me.UnAssignClassFromParticipantToolStripMenuItem.Enabled = False
        Me.UnAssignClassFromParticipantToolStripMenuItem.Name = "UnAssignClassFromParticipantToolStripMenuItem"
        Me.UnAssignClassFromParticipantToolStripMenuItem.Size = New System.Drawing.Size(371, 30)
        Me.UnAssignClassFromParticipantToolStripMenuItem.Text = "UnAssign Class From Participant"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(368, 6)
        '
        'PrintBoutSelectedBoutSheetToolStripMenuItem
        '
        Me.PrintBoutSelectedBoutSheetToolStripMenuItem.Enabled = False
        Me.PrintBoutSelectedBoutSheetToolStripMenuItem.Name = "PrintBoutSelectedBoutSheetToolStripMenuItem"
        Me.PrintBoutSelectedBoutSheetToolStripMenuItem.Size = New System.Drawing.Size(371, 30)
        Me.PrintBoutSelectedBoutSheetToolStripMenuItem.Text = "Print Selected Bout Sheet"
        '
        'PrintSelectedBracketToolStripMenuItem
        '
        Me.PrintSelectedBracketToolStripMenuItem.Enabled = False
        Me.PrintSelectedBracketToolStripMenuItem.Name = "PrintSelectedBracketToolStripMenuItem"
        Me.PrintSelectedBracketToolStripMenuItem.Size = New System.Drawing.Size(371, 30)
        Me.PrintSelectedBracketToolStripMenuItem.Text = "Print Selected Bracket"
        '
        'cmbDivision
        '
        Me.cmbDivision.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDivision.FormattingEnabled = True
        Me.cmbDivision.Location = New System.Drawing.Point(65, 16)
        Me.cmbDivision.Name = "cmbDivision"
        Me.cmbDivision.Size = New System.Drawing.Size(197, 32)
        Me.cmbDivision.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Division:"
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(268, 14)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(125, 34)
        Me.btnLoad.TabIndex = 4
        Me.btnLoad.Text = "Load Division"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'dgvClasses
        '
        Me.dgvClasses.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvClasses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvClasses.Location = New System.Drawing.Point(3, 47)
        Me.dgvClasses.Name = "dgvClasses"
        Me.dgvClasses.RowTemplate.Height = 44
        Me.dgvClasses.Size = New System.Drawing.Size(569, 367)
        Me.dgvClasses.TabIndex = 12
        '
        'dgvParticipants
        '
        Me.dgvParticipants.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvParticipants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvParticipants.Location = New System.Drawing.Point(3, 3)
        Me.dgvParticipants.Name = "dgvParticipants"
        Me.dgvParticipants.RowTemplate.Height = 44
        Me.dgvParticipants.Size = New System.Drawing.Size(234, 411)
        Me.dgvParticipants.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(399, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(340, 25)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Place Participants into Classes"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(12, 97)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnUnAssign)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnAssign)
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgvParticipants)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnDeleteClass)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnEditClass)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnCreateClass)
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvClasses)
        Me.SplitContainer1.Size = New System.Drawing.Size(868, 417)
        Me.SplitContainer1.SplitterDistance = 289
        Me.SplitContainer1.TabIndex = 15
        '
        'btnUnAssign
        '
        Me.btnUnAssign.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUnAssign.Location = New System.Drawing.Point(244, 172)
        Me.btnUnAssign.Name = "btnUnAssign"
        Me.btnUnAssign.Size = New System.Drawing.Size(35, 74)
        Me.btnUnAssign.TabIndex = 15
        Me.btnUnAssign.Text = "X"
        Me.btnUnAssign.UseVisualStyleBackColor = True
        '
        'btnAssign
        '
        Me.btnAssign.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAssign.Location = New System.Drawing.Point(244, 84)
        Me.btnAssign.Name = "btnAssign"
        Me.btnAssign.Size = New System.Drawing.Size(35, 66)
        Me.btnAssign.TabIndex = 14
        Me.btnAssign.Text = "-->"
        Me.btnAssign.UseVisualStyleBackColor = True
        '
        'btnDeleteClass
        '
        Me.btnDeleteClass.Location = New System.Drawing.Point(180, 16)
        Me.btnDeleteClass.Name = "btnDeleteClass"
        Me.btnDeleteClass.Size = New System.Drawing.Size(99, 23)
        Me.btnDeleteClass.TabIndex = 15
        Me.btnDeleteClass.Text = "Remove a Class"
        Me.btnDeleteClass.UseVisualStyleBackColor = True
        '
        'btnEditClass
        '
        Me.btnEditClass.Location = New System.Drawing.Point(99, 16)
        Me.btnEditClass.Name = "btnEditClass"
        Me.btnEditClass.Size = New System.Drawing.Size(75, 23)
        Me.btnEditClass.TabIndex = 14
        Me.btnEditClass.Text = "Edit Class"
        Me.btnEditClass.UseVisualStyleBackColor = True
        '
        'btnCreateClass
        '
        Me.btnCreateClass.Location = New System.Drawing.Point(14, 16)
        Me.btnCreateClass.Name = "btnCreateClass"
        Me.btnCreateClass.Size = New System.Drawing.Size(79, 23)
        Me.btnCreateClass.TabIndex = 13
        Me.btnCreateClass.Text = "Add a Class"
        Me.btnCreateClass.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.Location = New System.Drawing.Point(16, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(861, 39)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = resources.GetString("Label2.Text")
        '
        'ManageParticipantClasses
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(892, 526)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbDivision)
        Me.Name = "ManageParticipantClasses"
        Me.Text = "ManageParticipantClasses"
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.dgvClasses, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvParticipants, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbDivision As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AssignToClassToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvClasses As System.Windows.Forms.DataGridView
    Friend WithEvents dgvParticipants As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents UnAssignClassFromParticipantToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PrintBoutSelectedBoutSheetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintSelectedBracketToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents btnUnAssign As System.Windows.Forms.Button
    Friend WithEvents btnAssign As System.Windows.Forms.Button
    Friend WithEvents btnDeleteClass As System.Windows.Forms.Button
    Friend WithEvents btnEditClass As System.Windows.Forms.Button
    Friend WithEvents btnCreateClass As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
