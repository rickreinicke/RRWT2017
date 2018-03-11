Public Class frmParticipantPIcker
    Public myDivRowId As Integer = 0
    Public myClassRowId As Integer = 0
    Public mySelectedParticipantRowId = 0
    Public mySelectedParticipantName = ""
    Private Sub frmParticipantPIcker_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_DivCombo()
        Load_ClassCombo()
        If myDivRowId <> 0 Then
            cmbDivision.SelectedValue = myDivRowId
        End If
        If myClassRowId <> 0 Then
            cmbClass.SelectedValue = myClassRowId
        End If
        Load_Participants_Grid()
    End Sub

    Private Sub Load_DivCombo()

        With Me.cmbDivision
            .DataSource = gConn.QueryDBTable("Select RowId,DivisionDesc from rrwt_divisions order by RowId")
            .DisplayMember = "DivisionDesc"
            .ValueMember = "RowId"
            .DropDownStyle = ComboBoxStyle.DropDownList
        End With

    End Sub
    Private Sub Load_ClassCombo()

        Dim sSql As String = ""



        With Me.cmbClass
            sSql = " Select c.RowId,c.ClassDesc,d.DivisionDesc  from rrwt_classes c"
            sSql = sSql & " left join rrwt_divisions d on d.RowId = c.DivisionRowId"
            sSql = sSql & " where c.DivisionRowId = " & fn(cmbDivision.SelectedValue)
            sSql = sSql & " order by c.RowId"
            .DataSource = gConn.QueryDBTable(sSql)
            .DisplayMember = "ClassDesc"
            .ValueMember = "RowId"
            .DropDownStyle = ComboBoxStyle.DropDownList
        End With
    End Sub

    Public Sub Load_Participants_Grid()
        Dim sSql As String = ""
        Dim msConn As New clsDataManager
        Dim DivisionId As Integer = cmbDivision.SelectedValue
        Dim ClassId As Integer = cmbClass.SelectedValue
        Try


            sSql = "  select p.DivisionId,p.ClassId,d.DivisionDesc,ifnull(c.ClassDesc,'Unassigned') ClassDesc,p.RowId,P.Name,p.Team,p.Age,p.Weight,p.Rating from rrwt_participants p"
            sSql = sSql & " left join rrwt_divisions d on d.RowId = p.DivisionId "
            sSql = sSql & " left join rrwt_classes c on c.RowId = p.ClassId"
            sSql = sSql & " where (p.DivisionId = " & DivisionId & " and p.classid = " & ClassId & ") or p.name = 'Bye' "
            sSql = sSql & " order by c.ClassDesc, p.weight"
            'sSql = sSql & " order by p.classid, p.weight"

            msConn.OpenDB(Login.DBServer, Login.Database, Login.DatabaseUser, Login.DatabasePass)

            With dgvParticipants
                .DataSource = msConn.QueryDBTable(sSql)
                .Columns.Item("RowId").Visible = False
                .Columns.Item("DivisionId").Visible = False
                .Columns.Item("ClassId").Visible = False
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .MultiSelect = True
                .AllowUserToAddRows = False



            End With

            With dgvParticipants
                .RowsDefaultCellStyle.BackColor = Color.LemonChiffon
                .AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow

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

    Private Sub dgvParticipants_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvParticipants.CellContentClick

    End Sub

    Private Sub dgvParticipants_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvParticipants.CellMouseDoubleClick

        mySelectedParticipantRowId = dgvParticipants.CurrentRow.Cells("RowId").Value
        mySelectedParticipantName = dgvParticipants.CurrentRow.Cells("Name").Value
        Me.Close()
    End Sub
End Class