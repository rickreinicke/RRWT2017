Imports System.Data.SQLite
Public Class frmParticipantMNT

    Private Sub frmParticipantMNT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(34) Or e.KeyChar = Microsoft.VisualBasic.ChrW(39) Then
            e.Handled = True
        End If

    End Sub

    Private Sub frmParticipantMNT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        KeyPreview = True

        LoadStatusBar(Me.ssStatus)
        Load_DivCombo()
        Load_ClassCombo()
        Load_TeamCombo()
        SetupButtons("Initial")
        Load_Participants_Grid()
        'If Me.Tag > "" Then
        '    Load4AddEditDelete()
        '    btnDelete.Enabled = True
        'Else
        '    btnDelete.Enabled = False
        'End If
    End Sub


    Private Sub Load_DivCombo()

        With Me.cmbDivision
            .DataSource = gConn.QueryDBTable("Select RowId,DivisionDesc from rrwt_divisions order by RowId")
            .DisplayMember = "DivisionDesc"
            .ValueMember = "RowId"
            .DropDownStyle = ComboBoxStyle.DropDownList
        End With

        With Me.cmbDivisionTop
            .DataSource = gConn.QueryDBTable("Select RowId,DivisionDesc from rrwt_divisions order by RowId")
            .DisplayMember = "DivisionDesc"
            .ValueMember = "RowId"
            .DropDownStyle = ComboBoxStyle.DropDownList
        End With

    End Sub



    Private Sub Load_TeamCombo()

        With Me.cmbTeam
            .DataSource = gConn.QueryDBTable("Select distinct Team from rrwt_participants order by Team")
            .DisplayMember = "Team"
            .ValueMember = "Team"
            .DropDownStyle = ComboBoxStyle.DropDown
        End With

    End Sub


    Private Sub Load_ClassCombo()

        Dim sSql As String = ""



        With Me.cmbClass
            sSql = " Select c.RowId,c.ClassDesc,d.DivisionDesc  from rrwt_classes c"
            sSql = sSql & " left join rrwt_divisions d on d.RowId = c.DivisionRowId"
            sSql = sSql & " where c.DivisionRowId = " & fn(cmbDivisionTop.SelectedValue)
            sSql = sSql & " order by c.ClassDesc"
            .DataSource = gConn.QueryDBTable(sSql)
            .DisplayMember = "ClassDesc"
            .ValueMember = "RowId"
            .DropDownStyle = ComboBoxStyle.DropDownList
        End With
    End Sub

    Private Function Load4AddEditDelete(myRowId As Integer) As Boolean

        Dim msConn As New clsDataManager
        Dim Dr As SQLiteDataReader = Nothing
        Dim sSql As String = ""
        Load4AddEditDelete = False

        Try

            If myRowId > 0 Then
                msConn.OpenDB(Login.DBServer, Login.Database, Login.DatabaseUser, Login.DatabasePass)
                sSql = "select * from rrwt_participants where rowid = " & myRowId
                Dr = gConn.QueryDB(sSql)
                Dr.Read()



                txtName.Text = Dr("Name").ToString
                cmbTeam.SelectedValue = Dr("team").ToString
                txtAge.Text = Dr("age").ToString
                txtWeight.Text = Dr("Weight").ToString
                cmbDivision.SelectedValue = Dr("DivisionId").ToString
                cmbClass.SelectedValue = Dr("ClassId").ToString
                cmbRating.Text = Dr("Rating").ToString
                txtNote.Text = Dr("Note").ToString

            Else

                txtName.Text = ""
                cmbTeam.SelectedValue = ""
                txtAge.Text = ""
                txtWeight.Text = ""
                cmbDivision.SelectedValue = cmbDivisionTop.SelectedValue
                cmbClass.SelectedValue = 0
                cmbRating.Text = ""
                txtNote.Text = ""


            End If




            Return True

        Catch ex As Exception
            clsErrorManager.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, sSql, ex, Login, False, True)

        Finally
            msConn.CloseReader(Dr)
            msConn.CloseDB()
        End Try

    End Function


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim sSql As String = ""
        Dim SavedRowIndex As Integer = 0
        Try


            If Me.Tag > 0 Then 'Edit'
                sSql = "  Update [RRWT_Participants]"
                sSql = sSql & " SET [Name] = '" & txtName.Text & "'"
                sSql = sSql & ",[Team] = '" & cmbTeam.Text & "'"
                sSql = sSql & ",[Age] = '" & txtAge.Text & "'"
                sSql = sSql & ",[Weight] = '" & txtWeight.Text & "'"
                sSql = sSql & ",[DivisionId] = '" & cmbDivision.SelectedValue & "'"
                sSql = sSql & ",[Note] = '" & txtNote.Text & "'"
                sSql = sSql & ",[Rating] = '" & cmbRating.Text & "'"
                sSql = sSql & "WHERE rowid = " & Me.Tag.ToString
            Else '"Add"
                sSql = " INSERT INTO [RRWT_Participants]"
                sSql = sSql & "  ([Name]"
                sSql = sSql & " ,[Team]"
                sSql = sSql & " ,[Age]"
                sSql = sSql & " ,[Weight]"
                sSql = sSql & " ,[DivisionId]"
                sSql = sSql & " ,[ClassId]"
                sSql = sSql & " ,[BracketId]"
                sSql = sSql & " ,[Note]"
                sSql = sSql & " ,[Rating])"
                sSql = sSql & " VALUES"
                sSql = sSql & " ("
                sSql = sSql & "'" & txtName.Text & "'"
                sSql = sSql & ",'" & cmbTeam.Text & "'"
                sSql = sSql & ",'" & txtAge.Text & "'"
                sSql = sSql & ",'" & txtWeight.Text & "'"
                sSql = sSql & ",'" & cmbDivision.SelectedValue & "'"
                sSql = sSql & ",0"
                sSql = sSql & ",0"
                sSql = sSql & ",'" & txtNote.Text & "'"
                sSql = sSql & ",'" & txtNote.Text & "'"
                sSql = sSql & ")"
            End If


            If ValidEntries() Then
                gConn.ExecuteDB(sSql)
                If Me.Tag > 0 Then
                    SavedRowIndex = dgvParticipants.SelectedRows(0).Index
                End If

                Load_Participants_Grid()
                Load_TeamCombo()
                If Me.Tag > 0 Then
                    dgvParticipants.FirstDisplayedScrollingRowIndex = SavedRowIndex
                    dgvParticipants.Rows(SavedRowIndex).Selected = True
                End If
                ClearAll()
                SetupButtons("Initial")
            Else
                Exit Sub
            End If


            'Me.Close()
            ' Me.Dispose()
            ' MsgBox("Saved")
        Catch ex As Exception
            clsErrorManager.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, sSql, ex, Login, False, True)

        Finally

        End Try

    End Sub


    Private Sub MarkError(ByRef myControl As MaskedTextBox, Optional ByVal myMessage As String = "Invalid Entry.")
        Try
            ErrorProvider1.SetIconAlignment(myControl, ErrorIconAlignment.MiddleLeft)
            ErrorProvider1.SetError(myControl, myMessage)
        Catch ex As NullReferenceException
            Exit Sub
        Catch ex As Exception
            clsErrorManager.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login)
        End Try


    End Sub
    Private Sub MarkError(ByRef myControl As ComboBox, Optional ByVal myMessage As String = "Invalid Entry.")
        Try
            ErrorProvider1.SetIconAlignment(myControl, ErrorIconAlignment.MiddleLeft)
            ErrorProvider1.SetError(myControl, myMessage)
        Catch ex As NullReferenceException
            Exit Sub
        Catch ex As Exception
            clsErrorManager.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login)
        End Try


    End Sub
    Private Sub MarkError(ByRef myControl As TextBox, Optional ByVal myMessage As String = "Invalid Entry.")
        Try
            ErrorProvider1.SetIconAlignment(myControl, ErrorIconAlignment.MiddleLeft)
            ErrorProvider1.SetError(myControl, myMessage)
        Catch ex As NullReferenceException
            Exit Sub
        Catch ex As Exception
            clsErrorManager.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login)
        End Try


    End Sub
    Private Sub MarkError(ByRef myControl As CheckedListBox, Optional ByVal myMessage As String = "Invalid Entry.")
        Try
            ErrorProvider1.SetIconAlignment(myControl, ErrorIconAlignment.MiddleLeft)
            ErrorProvider1.SetError(myControl, myMessage)
        Catch ex As NullReferenceException
            Exit Sub
        Catch ex As Exception
            clsErrorManager.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login)
        End Try


    End Sub
    Private Sub MarkError(ByRef myControl As CheckBox, Optional ByVal myMessage As String = "Invalid Entry.")
        Try
            ErrorProvider1.SetIconAlignment(myControl, ErrorIconAlignment.MiddleLeft)
            ErrorProvider1.SetError(myControl, myMessage)
        Catch ex As NullReferenceException
            Exit Sub
        Catch ex As Exception
            clsErrorManager.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login)
        End Try


    End Sub
    Private Function ValidEntries() As Boolean

        'sSql = sSql & "  ([Name]"
        'sSql = sSql & " ,[Team]"
        'sSql = sSql & " ,[Age]"
        'sSql = sSql & " ,[Weight]"
        'sSql = sSql & " ,[DivisionId]"
        'sSql = sSql & " ,[ClassId]"
        'sSql = sSql & " ,[BracketId]"
        'sSql = sSql & " ,[Note]"
        'sSql = sSql & " ,[Rating])"



        ValidEntries = True
        ErrorProvider1.Clear()
        If txtName.Text.Trim.Length = 0 Then
            MarkError(txtName, "Name must not be blank.")
            ValidEntries = False
        End If

        If Not IsNumeric(txtAge.Text) Then
            MarkError(txtAge, "Age must be numeric.")
            ValidEntries = False
        End If

        If Not IsNumeric(txtWeight.Text) Then
            MarkError(txtWeight, "Weight must be numeric.")
            ValidEntries = False
        End If

        If cmbDivision.SelectedValue = 0 Then
            MarkError(cmbDivision, "Division is required")
            ValidEntries = False
        End If



    End Function



    Public Sub Load_Participants_Grid()
        Dim sSql As String = ""
        Dim msConn As New clsDataManager
        Dim DivisionId As Integer = cmbDivisionTop.SelectedValue
        Try


            sSql = "  select d.DivisionDesc, ifnull(c.ClassDesc,'Unassigned') ClassDesc,p.RowId,P.Name,p.Team,p.Age,p.Weight,p.Rating from rrwt_participants p"
            sSql = sSql & " left join rrwt_divisions d on d.RowId = p.DivisionId "
            sSql = sSql & " left join rrwt_classes c on c.RowId = p.ClassId"
            sSql = sSql & " where p.DivisionId = " & DivisionId
            sSql = sSql & " order by c.ClassDesc, p.weight"
            'sSql = sSql & " order by p.classid, p.weight"

            msConn.OpenDB(Login.DBServer, Login.Database, Login.DatabaseUser, Login.DatabasePass)

            With dgvParticipants
                .DataSource = msConn.QueryDBTable(sSql)
                .Columns.Item("RowId").Visible = False
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .MultiSelect = True
                .AllowUserToAddRows = False


            End With

            With dgvParticipants
                .RowsDefaultCellStyle.BackColor = Color.LemonChiffon
                .AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

                If .Columns.Contains("btnEdit") = False Then
                    Dim btn As New DataGridViewButtonColumn()
                    .Columns.Add(btn)
                    btn.HeaderText = "Delete"
                    btn.Text = "Delete"
                    btn.Name = "btnDelete"
                    btn.UseColumnTextForButtonValue = True

                    Dim btnEdit As New DataGridViewButtonColumn()
                    .Columns.Insert(0, btnEdit)
                    btnEdit.HeaderText = "Edit"
                    btnEdit.Text = "Edit"
                    btnEdit.Name = "btnEdit"
                    btnEdit.UseColumnTextForButtonValue = True


                End If


                '.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Empty
                '.RowsDefaultCellStyle.BackColor = Color.LightGray
                '.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray
                '.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                '.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            End With
        Catch ex As Exception
            ' this has been changed to log errors only in this sub.   me.tag is used to pass the grid layout key from previous screen
            ' and is not always created yet.  Line 55 (me.tag.tostring)
            ' If ex.GetType.FullName <> "System.NullReferenceException" Then
            clsErrorManager.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login, False, True)
            'End If
        Finally
        End Try

    End Sub


    'Private Sub dgvParticipants_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvParticipants.CellContentClick
    '    Dim SavedRowIndex As Integer = 0
    '    If dgvParticipants.SelectedRows.Count <> 1 Then
    '        MsgBox("ONE row must be selected.")
    '        Exit Sub
    '    Else

    '        Load4AddEditDelete(dgvParticipants.CurrentRow.Cells("RowId").Value)
    '        SavedRowIndex = dgvParticipants.SelectedRows(0).Index
    '        Load_Participants_Grid()
    '        dgvParticipants.FirstDisplayedScrollingRowIndex = SavedRowIndex
    '        dgvParticipants.Rows(SavedRowIndex).Selected = True

    '        If PassString = "DeleteClicked" Then
    '            SavedRowIndex = dgvParticipants.SelectedRows(0).Index
    '            dgvParticipants.Rows.RemoveAt(SavedRowIndex)
    '        End If
    '    End If

    'End Sub

    Private Sub EditParticipantToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditParticipantToolStripMenuItem.Click
        Dim SavedRowIndex As Integer = 0
        If dgvParticipants.SelectedRows.Count <> 1 Then
            MsgBox("ONE row must be selected.")
            Exit Sub
        Else
            Me.Tag = dgvParticipants.CurrentRow.Cells("RowId").Value
            Load4AddEditDelete(Me.Tag)
            SetupButtons("Edit")

            'SavedRowIndex = dgvParticipants.SelectedRows(0).Index



            'Load_Participants_Grid()
            'dgvParticipants.FirstDisplayedScrollingRowIndex = SavedRowIndex
            'dgvParticipants.Rows(SavedRowIndex).Selected = True

            'If PassString = "DeleteClicked" Then
            '    SavedRowIndex = dgvParticipants.SelectedRows(0).Index
            '    dgvParticipants.Rows.RemoveAt(SavedRowIndex)
            'End If
        End If

    End Sub


    Private Sub ClearAll()

        txtName.Text = ""
        cmbTeam.SelectedValue = ""
        txtAge.Text = ""
        txtWeight.Text = ""
        cmbDivision.SelectedValue = cmbDivisionTop.SelectedValue
        cmbClass.SelectedValue = 0
        cmbRating.Text = ""
        txtNote.Text = ""

    End Sub

    Private Sub AddParticipantToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ClearAll()
        Me.Tag = 0
        SetupButtons("Add")
    End Sub

    Private Sub SetupButtons(myAddEditDeleteMode As String)
        If myAddEditDeleteMode = "Edit" Or myAddEditDeleteMode = "Add" Then
            btnNew.Enabled = False
            btnSave.Enabled = True
            btnCancel.Enabled = True
            btnDelete.Enabled = False
            Me.dgvParticipants.Enabled = False
            grpEditBox.Enabled = True
        End If
        If myAddEditDeleteMode = "Initial" Then
            btnNew.Enabled = True
            btnSave.Enabled = False
            btnCancel.Enabled = False
            btnDelete.Enabled = False
            Me.dgvParticipants.Enabled = True
            grpEditBox.Enabled = False
        End If
        If myAddEditDeleteMode = "Delete" Then
            btnNew.Enabled = False
            btnSave.Enabled = False
            btnCancel.Enabled = True
            btnDelete.Enabled = True
            Me.dgvParticipants.Enabled = False
            grpEditBox.Enabled = False

        End If
        If btnCancel.Enabled Then
            btnCancel.BackColor = Color.Yellow
        Else
            btnCancel.BackColor = btnLoadParticipants.BackColor
        End If
        If btnDelete.Enabled Then
            btnDelete.BackColor = Color.Yellow
        Else
            btnDelete.BackColor = btnLoadParticipants.BackColor
        End If
        If btnSave.Enabled Then
            btnSave.BackColor = Color.Yellow
        Else
            btnSave.BackColor = btnLoadParticipants.BackColor
        End If
        If btnNew.Enabled Then
            btnNew.BackColor = Color.Yellow
        Else
            btnNew.BackColor = btnLoadParticipants.BackColor
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ClearAll()
        SetupButtons("Initial")
    End Sub

    Private Sub DeleteParticipantToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteParticipantToolStripMenuItem.Click
        Dim SavedRowIndex As Integer = 0
        If dgvParticipants.SelectedRows.Count <> 1 Then
            MsgBox("ONE row must be selected.")
            Exit Sub
        Else
            Me.Tag = dgvParticipants.CurrentRow.Cells("RowId").Value
            Load4AddEditDelete(Me.Tag)
            SetupButtons("Delete")
            Me.btnDelete.Focus()


        End If

    End Sub

    Private Sub btnDelete_Click_1(sender As Object, e As EventArgs) Handles btnDelete.Click

        Dim sSql As String = ""
        Try
            sSql = "delete from rrwt_participants where rowId = " & Me.Tag
            If gConn.ExecuteDB(sSql) Then
                dgvParticipants.Rows.RemoveAt(dgvParticipants.CurrentRow.Index)
                SetupButtons("Initial")
                ClearAll()
            Else
                MsgBox("Error Deleting Record.")
            End If
        Catch ex As Exception
            ' this has been changed to log errors only in this sub.   me.tag is used to pass the grid layout key from previous screen
            ' and is not always created yet.  Line 55 (me.tag.tostring)
            ' If ex.GetType.FullName <> "System.NullReferenceException" Then
            clsErrorManager.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, sSql, ex, Login, False, True)
            'End If
        Finally
        End Try

    End Sub

    Private Sub cmbDivisionTop_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDivisionTop.SelectedIndexChanged


    End Sub

    Private Sub btnLoadParticipants_Click(sender As Object, e As EventArgs) Handles btnLoadParticipants.Click

        Load_Participants_Grid()

    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        ClearAll()
        Me.Tag = 0
        SetupButtons("Add")
        Me.txtName.Focus()
    End Sub

    Private Sub dgvParticipants_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvParticipants.CellContentClick
        If e.ColumnIndex = dgvParticipants.Columns("btnEdit").Index AndAlso e.RowIndex >= 0 Then
            Dim SavedRowIndex As Integer = 0
            If dgvParticipants.SelectedRows.Count <> 1 Then
                MsgBox("ONE row must be selected.")
                Exit Sub
            Else
                Me.Tag = dgvParticipants.CurrentRow.Cells("RowId").Value
                Load4AddEditDelete(Me.Tag)
                SetupButtons("Edit")

            End If

        End If
        If e.ColumnIndex = dgvParticipants.Columns("btnDelete").Index AndAlso e.RowIndex >= 0 Then
            Dim SavedRowIndex As Integer = 0
            If dgvParticipants.SelectedRows.Count <> 1 Then
                MsgBox("ONE row must be selected.")
                Exit Sub
            Else
                Me.Tag = dgvParticipants.CurrentRow.Cells("RowId").Value
                Load4AddEditDelete(Me.Tag)
                SetupButtons("Delete")
                Me.btnDelete.Focus()


            End If
        End If


    End Sub
End Class