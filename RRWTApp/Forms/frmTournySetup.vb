Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Drawing
Imports System
Imports System.Data.OleDb

Public Class frmTournySetup

    Private Sub frmTournySetup_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            If gConn.getValue("select count(*) from rrwt_system") = 1 Then
                gConn.ExecuteDB(" update rrwt_system set tournyname = '" & Me.txtTournamentName.Text & "'")
            Else
                gConn.ExecuteDB(" insert into rrwt_system (tournyName) values ('" & Me.txtTournamentName.Text & "')")
            End If

        Catch ex As Exception
            clsErrorManager.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login, False, True)

        Finally

        End Try
    End Sub

    Private Sub frmTournySetup_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(34) Or e.KeyChar = Microsoft.VisualBasic.ChrW(39) Then
            e.Handled = True
        End If

    End Sub

    Private Sub TournySetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        KeyPreview = True
        LoadStatusBar(Me.ssStatus)
        'Dim str As String = gConn.getConnection.ConnectionString '"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Database\InsertDate.accdb;Persist Security Info=False;"
        'Dim dt As New DataTable()
        'Dim bs As New BindingSource()
        'Dim conn As New SqlClient.SqlConnection(str)
        'Dim sql As String = "select * from rrwt_divisions"
        'Using cmd As New SqlDataAdapter(sql, conn)
        '    Dim adapter As New SqlDataAdapter
        '    ' adapter.UpdateCommand = "update rrwt_divisions"
        '    adapter.Fill(dt)
        '    bs.DataSource = dt
        '    dgvDivisions.DataSource = bs
        'End Using


        'Dim cmd As New SqlCommand("select * from rrwt_divisions", gConn.getConnection)
        'cmd.CommandTimeout = 0
        'Dim da As New Data.SqlClient.SqlDataAdapter(cmd)
        'Dim dt As New DataTable()
        'da.Fill(dt)

        'Validate()
        'BindingSource1.EndEdit()
        'da.Update(Me.NorthwindDataSet.Customers)




        'With dgvDivisions
        '    '.Dock = DockStyle.Fill
        '    .ReadOnly = False
        '    .AutoGenerateColumns = True
        '    BindingSource1.DataSource = gConn.QueryDBTable("select * from rrwt_divisions")
        '    .DataSource = BindingSource1
        '    .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        '    .BorderStyle = BorderStyle.Fixed3D
        '    .EditMode = DataGridViewEditMode.EditOnEnter
        '    .Columns("DivisionDesc").ReadOnly = False
        '    .Columns("RowId").ReadOnly = True

        'End With
        'With dgvWinTypes
        '    '.Dock = DockStyle.Fill
        '    .ReadOnly = False
        '    .AutoGenerateColumns = True
        '    BindingSource2.DataSource = gConn.QueryDBTable("select * from rrwt_WinTypes")
        '    .DataSource = BindingSource2
        '    .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        '    .BorderStyle = BorderStyle.Fixed3D
        '    .EditMode = DataGridViewEditMode.EditOnEnter
        'End With

        Me.txtTournamentName.Text = gConn.getValue(" select  TournyName from rrwt_system limit 1")
        Load_Combos()


    End Sub

    Private Sub Load_Combos()

        With dgvDivisions
            '.Dock = DockStyle.Fill
            .ReadOnly = False
            .AutoGenerateColumns = True
            .DataSource = gConn.QueryDBTable("select * from rrwt_divisions")
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
            .BorderStyle = BorderStyle.Fixed3D
            '.EditMode = DataGridViewEditMode.EditOnEnter
            .Columns("DivisionDesc").ReadOnly = False
            .Columns("RowId").ReadOnly = True
            .Columns("RowId").Visible = False
        End With
        With dgvWinTypes
            '.Dock = DockStyle.Fill
            .ReadOnly = False
            .AutoGenerateColumns = True
            .DataSource = gConn.QueryDBTable("select * from rrwt_WinTypes")
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
            .BorderStyle = BorderStyle.Fixed3D
            '.EditMode = DataGridViewEditMode.EditOnEnter
            .Columns("RowId").ReadOnly = True
            .Columns("RowId").Visible = False
        End With
    End Sub


    Private Sub dgvDivisions_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDivisions.CellContentClick

    End Sub

    Private Sub dgvDivisions_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDivisions.CellValidated

    End Sub

    Private Sub dgvDivisions_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDivisions.CellValueChanged
        'MsgBox("CellValueChanged")
        Dim sSql As String = ""
        Try
            With dgvDivisions
                If .Rows(e.RowIndex).Cells("DivisionDesc").Value.ToString > "" Then
                    If .Rows(e.RowIndex).Cells("RowId").Value.ToString > "" Then
                        sSql = "update rrwt_Divisions set "
                        sSql = sSql & " DivisionDesc = '" & .Rows(e.RowIndex).Cells("DivisionDesc").Value.ToString & "'"
                        sSql = sSql & " where RowId = " & .Rows(e.RowIndex).Cells("RowId").Value.ToString
                        gConn.ExecuteDB(sSql)
                        Load_Combos()
                    Else
                        sSql = " insert into rrwt_divisions (DivisionDesc) values ("
                        sSql = sSql & "'" & .Rows(e.RowIndex).Cells("DivisionDesc").Value.ToString & "'"
                        sSql = sSql & ")"
                        gConn.ExecuteDB(sSql)
                        Load_Combos()
                    End If
                End If
            End With

        Catch ex As Exception
            clsErrorManager.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, sSql, ex, Login, False, True)

        Finally

        End Try
    End Sub


    Private Sub dgvDivisions_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles dgvDivisions.UserDeletingRow
        Dim sSql As String = ""
        Try
            With dgvDivisions
                If gConn.getValue("select count(*) from rrwt_participants where divisionid = " & .Rows(e.Row.Index).Cells("RowId").Value) = 0 Then
                    sSql = "delete from rrwt_Divisions where RowId =  " & .Rows(e.Row.Index).Cells("RowId").Value.ToString
                    gConn.ExecuteDB(sSql)
                Else
                    MsgBox("You Cannot delete this Division because there are participants assigned to it.")
                    e.Cancel = True

                End If
                ' Load_Combos()
            End With

        Catch ex As Exception
            clsErrorManager.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, sSql, ex, Login, False, True)

        Finally

        End Try

    End Sub

    Private Sub dgvWinTypes_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvWinTypes.CellValueChanged
        'MsgBox("CellValueChanged")
        Dim sSql As String = ""
        Try
            With dgvWinTypes
                'If .Rows(e.RowIndex).Cells("DivisionDesc").Value.ToString > "" Then
                If .Rows(e.RowIndex).Cells("RowId").Value.ToString > "" Then
                    sSql = "update rrwt_WinTypes set "
                    sSql = sSql & " WinTypeCode = '" & .Rows(e.RowIndex).Cells("WinTypeCode").Value.ToString & "',"
                    sSql = sSql & " WinTypeTeamPoints = " & fn(.Rows(e.RowIndex).Cells("WinTypeTeamPoints").Value.ToString) & ""
                    sSql = sSql & " where RowId = " & .Rows(e.RowIndex).Cells("RowId").Value.ToString
                    gConn.ExecuteDB(sSql)
                    'Load_Combos()
                Else
                    sSql = " insert into rrwt_WinTypes (WinTypeCode,WinTypeTeamPoints) values ("
                    sSql = sSql & "'" & .Rows(e.RowIndex).Cells("WinTypeCode").Value.ToString & "',"
                    sSql = sSql & "" & fn(.Rows(e.RowIndex).Cells("WinTypeTeamPoints").Value.ToString) & ""
                    sSql = sSql & ")"
                    gConn.ExecuteDB(sSql)
                    Load_Combos()
                End If
                'End If
            End With

        Catch ex As Exception
            clsErrorManager.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, sSql, ex, Login, False, True)

        Finally

        End Try

    End Sub

    Private Sub dgvWinTypes_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles dgvWinTypes.UserDeletingRow
        Dim sSql As String = ""
        Try
            With dgvWinTypes
                sSql = "delete from rrwt_WinTypes where RowId =  " & .Rows(e.Row.Index).Cells("RowId").Value.ToString
                gConn.ExecuteDB(sSql)
                ' Load_Combos()
            End With

        Catch ex As Exception
            clsErrorManager.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, sSql, ex, Login, False, True)

        Finally

        End Try

    End Sub


End Class