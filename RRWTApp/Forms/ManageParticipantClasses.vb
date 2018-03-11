'Imports TenTec.Windows.iGridLib
Imports System.Data.SqlClient
Public Class ManageParticipantClasses
    Public sSql As String = ""
    ' sSql Record_id is the field returned to the calling program

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Me.dgvParticipants.Enabled = True
        Me.btnLoad.BackColor = btnAssign.BackColor
        Load_Participants_Grid()
        ApplyBorderToGrid()
        Load_Class_Grid()

    End Sub



    Public Sub Load_Class_Grid()

        Dim msConn As New clsDataManager
        Dim DivisionId As Integer = cmbDivision.SelectedValue
        Try
            sSql = "select c.RowId,c.ClassDesc , "
            sSql = sSql & "(select count(*) from RRWT_Participants p where p.ClassId = c.RowId) CntInClass, "
            sSql = sSql & "(select min(p.weight) from RRWT_Participants p where p.ClassId = c.RowId) MinWt, "
            sSql = sSql & "(select max(p.weight) from RRWT_Participants p where p.ClassId = c.RowId) MaxWt "
            sSql = sSql & " from rrwt_classes c where c.DivisionRowId = " & DivisionId & " order by c.classdesc"
            msConn.OpenDB(Login.DBServer, Login.Database, Login.DatabaseUser, Login.DatabasePass)

            With dgvClasses
                .DataSource = msConn.QueryDBTable(sSql)
                .Columns.Item("RowId").Visible = False
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .MultiSelect = True
                .AllowUserToAddRows = False
                .CurrentCell = Nothing
            End With

            With dgvClasses
                .RowsDefaultCellStyle.BackColor = Color.Beige
                .AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
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

    Public Sub Load_Participants_Grid()

        Dim msConn As New clsDataManager
        Dim DivisionId As Integer = cmbDivision.SelectedValue
        Try


            sSql = "  select  p.DivisionId,p.ClassId,d.DivisionDesc,ifnull(c.ClassDesc,'Unassigned') ClassDesc,p.RowId,P.Name,p.Team,p.Age,p.Weight,p.Rating from rrwt_participants p"
            sSql = sSql & " left join rrwt_divisions d on d.RowId = p.DivisionId "
            sSql = sSql & " left join rrwt_classes c on c.RowId = p.ClassId"
            sSql = sSql & " where p.DivisionId = " & DivisionId
            sSql = sSql & " order by c.ClassDesc, p.weight"
            'sSql = sSql & " order by p.classid, p.weight"

            msConn.OpenDB(Login.DBServer, Login.Database, Login.DatabaseUser, Login.DatabasePass)

            With dgvParticipants

                .Columns.Clear()

                .DataSource = msConn.QueryDBTable(sSql)
                .Columns.Item("RowId").Visible = False
                .Columns.Item("DivisionId").Visible = False
                .Columns.Item("ClassId").Visible = False

                Dim chk As New DataGridViewCheckBoxColumn
                chk.Name = "Selected"
                chk.HeaderText = "Selected"
                .Columns.Insert(4, chk)


                ' .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .SelectionMode = DataGridViewSelectionMode.RowHeaderSelect
                .MultiSelect = True
                .AllowUserToAddRows = False



            End With

            With dgvParticipants
                .RowsDefaultCellStyle.BackColor = Color.LemonChiffon
                .AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
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


    Private Sub ManageParticipantClasses_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.WindowState = FormWindowState.Maximized
        With Me.cmbDivision
            .DataSource = gConn.QueryDBTable("Select RowId,DivisionDesc from rrwt_divisions order by RowId")
            .DisplayMember = "DivisionDesc"
            .ValueMember = "RowId"
            .DropDownStyle = ComboBoxStyle.DropDownList
        End With

        SplitContainer1.SplitterDistance = SplitContainer1.ClientSize.Width * 0.66
        With ToolTip1
            .InitialDelay = 1000
            .ReshowDelay = 500
            .ShowAlways = True
            .SetToolTip(Me.btnAssign, "Assign Selected Participants to Selected Class.")
            .SetToolTip(Me.btnUnAssign, "UnAssign Selected Participant(s) from Thier Current Class")
        End With
    End Sub


    Private Sub AssignToClassToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AssignToClassToolStripMenuItem.Click
        AssignToClass()
 
    End Sub
    Private Sub AssignToClass()
        Dim iSelectedClass As Integer = 0
        Dim cSelectedClass As String = ""
        Dim sSql As String = ""

        Try
            If dgvClasses.SelectedRows.Count <> 1 Then
                MsgBox("No Class is selected.")
                Exit Sub
            End If

            iSelectedClass = dgvClasses.CurrentRow.Cells("RowId").Value
            cSelectedClass = dgvClasses.CurrentRow.Cells("ClassDesc").Value

            For Each row As DataGridViewRow In dgvParticipants.Rows
                Dim isSelected As Boolean = Convert.ToBoolean(row.Cells("Selected").Value)
                If isSelected Then
                    row.Cells("ClassDesc").Value = cSelectedClass
                    'Update Database  
                    sSql = " update rrwt_participants set ClassId = " & iSelectedClass
                    sSql = sSql & " where rowid = " & row.Cells("RowId").Value
                    gConn.ExecuteDB(sSql)
                    row.Cells("Selected").Value = False
                End If
            Next



            'Dim iSelectedClass As Integer = 0
            'Dim cSelectedClass As String = ""
            'Dim sSql As String = ""
            'Try
            '    If dgvClasses.SelectedRows.Count = 0 Then
            '        MsgBox("Nothing selected from the class list.")
            '        Exit Sub
            '    Else
            '        iSelectedClass = dgvClasses.CurrentRow.Cells("RowId").Value
            '        cSelectedClass = dgvClasses.CurrentRow.Cells("ClassDesc").Value
            '    End If

            '    'gConn.BeginTrans()

            '    With dgvParticipants
            '        If .SelectedRows.Count > 0 Then
            '            For Each SelectedRow As DataGridViewRow In .SelectedRows
            '                SelectedRow.Cells("ClassDesc").Value = cSelectedClass
            '                'Update Database  
            '                sSql = " update rrwt_participants set ClassId = " & iSelectedClass
            '                sSql = sSql & " where rowid = " & SelectedRow.Cells("RowId").Value
            '                gConn.ExecuteDB(sSql)

            '            Next
            '        End If

            '    End With
            'gConn.CommitTrans()
            Me.Load_Class_Grid()
            ApplyBorderToGrid()
        Catch ex As Exception
            clsErrorManager.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, sSql, ex, Login, False, True)
        Finally
        End Try
    End Sub
    Private Sub igrid2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub igrid2_SelectionChanged(sender As Object, e As EventArgs)

    End Sub


    Private Sub dgvParticipants_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvParticipants.CellContentClick
        'For Each row As DataGridViewRow In dgvParticipants.Rows
        '    Dim isSelected As Boolean = Convert.ToBoolean(row.Cells("Selected").Value)
        '    If isSelected Then
        '        row.Selected = True
        '    Else
        '        row.Selected = False
        '    End If
        'Next
        ''ApplyBorderToGrid()
    End Sub

    Public Sub ApplyBorderToGrid()
        Dim x As Integer = 0
        Try
            For x = 2 To dgvParticipants.Rows.Count - 1
                With dgvParticipants
                    If dgvParticipants("ClassDesc", x).Value Is Nothing Or dgvParticipants("ClassDesc", x - 1).Value Is Nothing Then
                    Else
                        If dgvParticipants("ClassDesc", x).Value <> dgvParticipants("ClassDesc", x - 1).Value Then
                            dgvParticipants.Rows(x - 1).DividerHeight = 5
                        Else
                            dgvParticipants.Rows(x - 1).DividerHeight = 1


                            'row.DividerHeight = 10;

                            ' MsgBox(x.ToString)
                        End If
                    End If
                End With
            Next x
        Catch ex As Exception
            ' MsgBox(x.ToString)
            clsErrorManager.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login, False, True)

        End Try


    End Sub

    'Public Sub UnApplyClass()
    '    Dim x As Integer = 0
    '    Try
    '        For x = 2 To dgvParticipants.Rows.Count - 1
    '            With dgvParticipants
    '                If dgvParticipants("ClassDesc", x).Value Is Nothing Or dgvParticipants("ClassDesc", x - 1).Value Is Nothing Then
    '                Else
    '                    If dgvParticipants("ClassDesc", x).Value <> dgvParticipants("ClassDesc", x - 1).Value Then
    '                        dgvParticipants.Rows(x - 1).DividerHeight = 5
    '                    Else
    '                        dgvParticipants.Rows(x - 1).DividerHeight = 1

    '                    End If
    '                End If
    '            End With
    '        Next x
    '    Catch ex As Exception
    '        ' MsgBox(x.ToString)
    '        clsErrorManager.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login, False, True)

    '    End Try


    'End Sub


    'Private Sub btnAddAClass_Click(sender As Object, e As EventArgs)
    '    Dim sSql As String = ""
    '    Try
    '        If Me.txtNewClass.Text > "" Then
    '            sSql = " INSERT INTO [rrwt_classes]"
    '            sSql = sSql & " ([DivisionRowId]"
    '            sSql = sSql & " ,[ClassDesc])"
    '            sSql = sSql & " VALUES"
    '            sSql = sSql & " (" & cmbDivision.SelectedValue
    '            sSql = sSql & ", '" & Me.txtNewClass.Text & "'"
    '            sSql = sSql & ")"
    '            gConn.ExecuteDB(sSql)
    '            Me.Load_Class_Grid()
    '            Me.txtNewClass.Text = ""
    '        End If

    '    Catch ex As Exception
    '        ' MsgBox(x.ToString)
    '        clsErrorManager.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login, False, True)

    '    End Try


    'End Sub

    Private Sub txtNewClass_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub

    Private Sub UnAssignClassFromParticipantToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnAssignClassFromParticipantToolStripMenuItem.Click
        UnAssignClass()

    End Sub
    Private Sub UnAssignClass()
        Dim iSelectedClass As Integer = 0
        Dim cSelectedClass As String = ""
        Dim sSql As String = ""
        Try

            'gConn.BeginTrans()


            For Each row As DataGridViewRow In dgvParticipants.Rows
                Dim isSelected As Boolean = Convert.ToBoolean(row.Cells("Selected").Value)
                If isSelected Then
                    row.Cells("ClassDesc").Value = "UnAssigned"
                    'Update Database  
                    sSql = " update rrwt_participants set ClassId = 0"
                    sSql = sSql & " where rowid = " & row.Cells("RowId").Value
                    gConn.ExecuteDB(sSql)
                    row.Cells("Selected").Value = False
                End If
            Next




            'With dgvParticipants
            '    If .SelectedRows.Count > 0 Then
            '        For Each SelectedRow As DataGridViewRow In .SelectedRows
            '            SelectedRow.Cells("ClassDesc").Value = "UnAssigned"
            '            'Update Database  
            '            sSql = " update rrwt_participants set ClassId = 0"
            '            sSql = sSql & " where rowid = " & SelectedRow.Cells("RowId").Value
            '            gConn.ExecuteDB(sSql)

            '        Next
            '    End If
            'End With
            'gConn.CommitTrans()
            Me.Load_Class_Grid()
            ApplyBorderToGrid()
        Catch ex As Exception
            'gConn.RollbackTrans()

            ' this has been changed to log errors only in this sub.   me.tag is used to pass the grid layout key from previous screen
            ' and is not always created yet.  Line 55 (me.tag.tostring)
            ' If ex.GetType.FullName <> "System.NullReferenceException" Then
            clsErrorManager.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login, False, True)
            'End If
        Finally
        End Try
    End Sub
    Private Sub ChangeParticipantInformationToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim SavedRowIndex As Integer = 0
        If dgvParticipants.SelectedRows.Count <> 1 Then
            MsgBox("ONE row must be selected.")
            Exit Sub
        Else
            PassString = ""
            frmParticipantMNT.Hide()
            frmParticipantMNT.Tag = dgvParticipants.CurrentRow.Cells("RowId").Value.ToString
            frmParticipantMNT.ShowDialog()
            'If frmParticipantMNT.btnSave.Tag = "SaveClicked" Then
            If PassString = "SaveClicked" Then
                SavedRowIndex = dgvParticipants.SelectedRows(0).Index
                Load_Participants_Grid()
                dgvParticipants.FirstDisplayedScrollingRowIndex = SavedRowIndex
                dgvParticipants.Rows(SavedRowIndex).Selected = True
            End If
            If PassString = "DeleteClicked" Then
                SavedRowIndex = dgvParticipants.SelectedRows(0).Index
                dgvParticipants.Rows.RemoveAt(SavedRowIndex)
            End If
        End If



    End Sub
    'Private Function EditParticipant()
    '    Dim msConn As New clsDataManager
    '    Dim Dr As SqlDataReader = Nothing
    '    Dim sSql As String = ""
    '    EditParticipant = False
    '    frmParticipantMNT.Hide()
    '    Try

    '        If dgvParticipants.SelectedRows.Count <> 1 Then
    '            MsgBox("ONE row must be selected.")
    '            Exit Function
    '        End If

    '        msConn.OpenDB(Login.DBServer, Login.Database, Login.DatabaseUser, Login.DatabasePass)
    '        sSql = "select * from rrwt_participants where rowid = " & dgvParticipants.CurrentRow.Cells("RowId").Value
    '        Dr = gConn.QueryDB(sSql)
    '        Dr.Read()

    '        With frmParticipantMNT

    '            .txtName.Text = Dr("Name").ToString
    '            .cmbTeam.SelectedValue = Dr("team").ToString
    '            .txtAge.Text = Dr("age").ToString
    '            .txtWeight.Text = Dr("Weight").ToString
    '            .cmbDivision.SelectedValue = Dr("DivisionId").ToString
    '            .cmbClass.SelectedValue = Dr("ClassId").ToString
    '            .cmbRating.Text = Dr("Rating").ToString
    '            .txtNote.Text = Dr("Note").ToString
    '            .ShowDialog()

    '            If .btnSave.Tag = "SaveClicked" Then
    '                sSql = "update rrwt_brackets set "
    '                gConn.ExecuteDB(sSql)
    '                Load_Participants_Grid()
    '                ' MsgBox("Saved")
    '            End If

    '            .Dispose()
    '            .Close()
    '        End With


    '        Return True

    '    Catch ex As Exception
    '        clsErrorManager.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, sSql, ex, Login, False, True)

    '    Finally

    '    End Try

    'End Function

    Private Sub AddParticipantToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim SavedRowIndex As Integer = 0
        PassString = ""
        frmParticipantMNT.Hide()
        frmParticipantMNT.Tag = ""
        frmParticipantMNT.ShowDialog()
        'SavedRowIndex = dgvParticipants.SelectedRows(0).Index
        If PassString > "" Then ' "SaveClicked" Then
            Load_Participants_Grid()
            For Each row As DataGridViewRow In dgvParticipants.Rows
                If row.Cells.Item("Name").Value = PassString Then
                    dgvParticipants.FirstDisplayedScrollingRowIndex = row.Index
                    dgvParticipants.Rows(row.Index).Selected = True
                End If
            Next
        End If
        'dgvParticipants.FirstDisplayedScrollingRowIndex = SavedRowIndex
        'End If



    End Sub


    Private Sub AddAClass()
        Dim myNewClass As String = ""
        myNewClass = InputBox("Enter New Class Name. (Example: Class-03", "Create New Class", "")

        Dim sSql As String = ""
        Try
            If myNewClass > "" Then
                Dim parts As String() = myNewClass.Split(New Char() {","c})
                Dim part As String = ""
                For Each part In parts
                    sSql = " INSERT INTO [rrwt_classes]"
                    sSql = sSql & " ([DivisionRowId]"
                    sSql = sSql & " ,[ClassDesc])"
                    sSql = sSql & " VALUES"
                    sSql = sSql & " (" & cmbDivision.SelectedValue
                    sSql = sSql & ", '" & part.Trim & "'"
                    sSql = sSql & ")"
                    gConn.ExecuteDB(sSql)
                Next
                Me.Load_Class_Grid()

            End If

        Catch ex As Exception
            ' MsgBox(x.ToString)
            clsErrorManager.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login, False, True)

        End Try


    End Sub


    Private Sub DeleteAClass()
        Dim sSql As String = ""
        Dim iClassCount As Integer = 0
        Try
            If dgvClasses.SelectedRows.Count = 1 Then
                With dgvClasses
                    iClassCount = gConn.getValue("select count(*) from rrwt_participants where classid = " & .CurrentRow.Cells("RowId").Value.ToString)
                    If iClassCount = 0 Then
                        sSql = "delete from rrwt_classes where rowid = " & .CurrentRow.Cells("RowId").Value.ToString
                        gConn.ExecuteDB(sSql)
                        Load_Class_Grid()
                    Else
                        MsgBox("Cannot delete this Class because it is assigned to " & iClassCount.ToString & " Participant(s).")
                    End If
                End With
            End If

        Catch ex As Exception

            clsErrorManager.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login, False, True)

        End Try
    End Sub


    Private Sub ChangeAClass()
        Dim myChgClass As String = ""

        If dgvClasses.SelectedRows.Count <> 1 Then
            MsgBox("ONE Class must be selected.")
            Exit Sub
        End If


        myChgClass = InputBox("Change Class Name. (Example: Class-03", "Update Class Description", dgvClasses.CurrentRow.Cells("ClassDesc").Value.ToString)

        Dim sSql As String = ""
        Try
            If myChgClass > "" Then
                sSql = " update [rrwt_classes] set "
                sSql = sSql & " ClassDesc = '" & myChgClass & "'"
                sSql = sSql & "where RowId = " & dgvClasses.CurrentRow.Cells("RowId").Value.ToString

                gConn.ExecuteDB(sSql)
                Me.Load_Class_Grid()
                Me.Load_Participants_Grid()

            End If

        Catch ex As Exception
            ' MsgBox(x.ToString)
            clsErrorManager.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login, False, True)

        End Try

    End Sub

    Private Sub PrintBoutSelectedBoutSheetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintBoutSelectedBoutSheetToolStripMenuItem.Click
        Try
            If dgvParticipants.SelectedRows.Count <> 1 Then
                MsgBox("Only ONE row in this Class must be selected.")
                Exit Sub
            Else
                Dim myRecSel As String = "{rrwt_brackets_vw1.ClassRowId} = " & dgvParticipants.CurrentRow.Cells("ClassId").Value.ToString & " and {rrwt_brackets_vw1.DivRowId} = " & cmbDivision.SelectedValue
                frmReportViewer.ViewReport(Application.StartupPath & "\Reports\BoutSheets.rpt", myRecSel)
                frmReportViewer.Show()
            End If
        Catch ex As Exception
            ' MsgBox(x.ToString)
            clsErrorManager.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login, False, True)

        End Try

    End Sub

    Private Sub PrintSelectedBracketToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintSelectedBracketToolStripMenuItem.Click

        Try
            If dgvParticipants.SelectedRows.Count <> 1 Then
                MsgBox("Only ONE row in this Class must be selected.")
                Exit Sub
            Else
                Dim myRecSel As String = "{rrwt_brackets_vw1.ClassRowId} = " & dgvParticipants.CurrentRow.Cells("ClassId").Value.ToString & " and {rrwt_brackets_vw1.DivRowId} = " & cmbDivision.SelectedValue
                frmReportViewer.ViewReport(Application.StartupPath & "\Reports\BracketSheets.rpt", myRecSel)
                frmReportViewer.Show()
            End If
            Catch ex As Exception
            ' MsgBox(x.ToString)
            clsErrorManager.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login, False, True)

        End Try

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub btnAssign_Click(sender As Object, e As EventArgs) Handles btnAssign.Click
        AssignToClass()
        'MsgBox("Assignment has been done.")
    End Sub

    Private Sub btnUnAssign_Click(sender As Object, e As EventArgs) Handles btnUnAssign.Click
        UnAssignClass()
        'MsgBox("UnAssignment has been done.")
    End Sub

    Private Sub btnCreateClass_Click(sender As Object, e As EventArgs) Handles btnCreateClass.Click
        AddAClass()
    End Sub

    Private Sub btnEditClass_Click(sender As Object, e As EventArgs) Handles btnEditClass.Click
        ChangeAClass()
    End Sub

    Private Sub btnDeleteClass_Click(sender As Object, e As EventArgs) Handles btnDeleteClass.Click
        DeleteAClass()
    End Sub

    Private Sub cmbDivision_LostFocus(sender As Object, e As EventArgs) Handles cmbDivision.LostFocus

    End Sub

    Private Sub cmbDivision_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDivision.SelectedIndexChanged
        Me.dgvParticipants.Enabled = False
        Me.btnLoad.BackColor = Color.Yellow
    End Sub
End Class