<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
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
        Me.OK = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.lblInvalidLogin = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblLocalIPNumber = New System.Windows.Forms.Label()
        Me.txtDataFolder = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnFindLocation = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbDataFilename = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkRefreshDemoData = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'OK
        '
        Me.OK.Location = New System.Drawing.Point(232, 135)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(75, 23)
        Me.OK.TabIndex = 5
        Me.OK.Text = "OK"
        Me.OK.UseVisualStyleBackColor = True
        '
        'Cancel
        '
        Me.Cancel.Location = New System.Drawing.Point(120, 135)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(75, 23)
        Me.Cancel.TabIndex = 9
        Me.Cancel.Text = "Cancel"
        Me.Cancel.UseVisualStyleBackColor = True
        '
        'lblInvalidLogin
        '
        Me.lblInvalidLogin.AutoSize = True
        Me.lblInvalidLogin.ForeColor = System.Drawing.Color.Red
        Me.lblInvalidLogin.Location = New System.Drawing.Point(54, 161)
        Me.lblInvalidLogin.Name = "lblInvalidLogin"
        Me.lblInvalidLogin.Size = New System.Drawing.Size(70, 13)
        Me.lblInvalidLogin.TabIndex = 10
        Me.lblInvalidLogin.Text = "Invalid Login."
        Me.lblInvalidLogin.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(61, 108)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Local Hostname"
        '
        'lblLocalIPNumber
        '
        Me.lblLocalIPNumber.AutoSize = True
        Me.lblLocalIPNumber.Location = New System.Drawing.Point(155, 108)
        Me.lblLocalIPNumber.Name = "lblLocalIPNumber"
        Me.lblLocalIPNumber.Size = New System.Drawing.Size(19, 13)
        Me.lblLocalIPNumber.TabIndex = 12
        Me.lblLocalIPNumber.Text = "***"
        '
        'txtDataFolder
        '
        Me.txtDataFolder.Location = New System.Drawing.Point(85, 54)
        Me.txtDataFolder.Name = "txtDataFolder"
        Me.txtDataFolder.Size = New System.Drawing.Size(323, 20)
        Me.txtDataFolder.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 57)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Data Folder"
        '
        'btnFindLocation
        '
        Me.btnFindLocation.Location = New System.Drawing.Point(414, 51)
        Me.btnFindLocation.Name = "btnFindLocation"
        Me.btnFindLocation.Size = New System.Drawing.Size(22, 23)
        Me.btnFindLocation.TabIndex = 15
        Me.btnFindLocation.Text = "..."
        Me.btnFindLocation.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 79)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Data Filename"
        '
        'cmbDataFilename
        '
        Me.cmbDataFilename.FormattingEnabled = True
        Me.cmbDataFilename.Items.AddRange(New Object() {"RRWT.db", "RRWTDemo.db"})
        Me.cmbDataFilename.Location = New System.Drawing.Point(85, 76)
        Me.cmbDataFilename.Name = "cmbDataFilename"
        Me.cmbDataFilename.Size = New System.Drawing.Size(187, 21)
        Me.cmbDataFilename.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(53, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(344, 20)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Round Robin Wrestling Tournament Login"
        '
        'chkRefreshDemoData
        '
        Me.chkRefreshDemoData.AutoSize = True
        Me.chkRefreshDemoData.Checked = True
        Me.chkRefreshDemoData.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkRefreshDemoData.Location = New System.Drawing.Point(278, 78)
        Me.chkRefreshDemoData.Name = "chkRefreshDemoData"
        Me.chkRefreshDemoData.Size = New System.Drawing.Size(126, 17)
        Me.chkRefreshDemoData.TabIndex = 19
        Me.chkRefreshDemoData.Text = "Refresh Demo Data?"
        Me.chkRefreshDemoData.UseVisualStyleBackColor = True
        Me.chkRefreshDemoData.Visible = False
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(448, 200)
        Me.Controls.Add(Me.chkRefreshDemoData)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbDataFilename)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnFindLocation)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtDataFolder)
        Me.Controls.Add(Me.lblLocalIPNumber)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblInvalidLogin)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.OK)
        Me.Name = "frmLogin"
        Me.Text = "RRWTApp Login"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OK As System.Windows.Forms.Button
    Friend WithEvents Cancel As System.Windows.Forms.Button
    Friend WithEvents lblInvalidLogin As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblLocalIPNumber As System.Windows.Forms.Label
    Friend WithEvents txtDataFolder As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnFindLocation As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbDataFilename As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkRefreshDemoData As System.Windows.Forms.CheckBox
End Class
