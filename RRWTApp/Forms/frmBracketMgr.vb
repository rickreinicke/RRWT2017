
Imports System.Data.SQLite

Public Class frmBracketMgr

    Private bmp As Bitmap
    Private Sub btnPrintBracket_Click(sender As Object, e As EventArgs) Handles btnPrintBracket.Click
        Dim myRecSel As String = "{rrwt_brackets_vw1.ClassRowId} = " & Me.cmbClass.SelectedValue & " and {rrwt_brackets_vw1.DivRowId} = " & cmbDivision.SelectedValue

        frmReportViewer.ViewReport(Application.StartupPath & "\Reports\BracketSheets.rpt", myRecSel)
        frmReportViewer.Show()



        'bmp = New Bitmap(Panel1.Width, Panel1.Height)
        'Dim G As Graphics = Graphics.FromImage(bmp)
        'Panel1.DrawToBitmap(bmp, Panel1.ClientRectangle)
        'G.Dispose()

        'PrintDocument1.DefaultPageSettings.Landscape = True
        'PrintPreviewDialog1.Document = PrintDocument1
        'PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
        'PrintPreviewDialog1.ShowDialog()

    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        e.PageSettings.Landscape = True
        e.Graphics.DrawImage(bmp, 0, 0)

    End Sub

    Private Sub frmBracketMgr_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

    End Sub

    Private Sub frmBracketMgr_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(34) Or e.KeyChar = Microsoft.VisualBasic.ChrW(39) Then
            e.Handled = True
        End If
    End Sub


    Private Sub frmBracketMgr_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.KeyPreview = True
        LoadStatusBar(Me.ssStatus)
        Load_DivCombo()
        Load_ClassCombo()
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
            sSql = sSql & " order by c.ClassDesc"
            .DataSource = gConn.QueryDBTable(sSql)
            .DisplayMember = "ClassDesc"
            .ValueMember = "RowId"
            .DropDownStyle = ComboBoxStyle.DropDownList
        End With
    End Sub


    Private Sub cmbDivision_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDivision.SelectedIndexChanged
        Load_ClassCombo()
    End Sub

    Private Sub btnLoadBracket_Click(sender As Object, e As EventArgs) Handles btnLoadBracket.Click
        Load_Bracket_Data()


    End Sub
    Private Sub Load_Bracket_Data()
        Dim Dr As SQLiteDataReader = Nothing
        Dim sSql As String = ""
        Try

            Me.lblBracketHeader.Text = gConn.getValue("select  tournyname from rrwt_system limit 1") & "        (Division: " & Me.cmbDivision.Text & " Class: " & cmbClass.Text & ")"
            sSql = "select * from rrwt_brackets_vw where classrowId = " & cmbClass.SelectedValue & " and divrowId = " & cmbDivision.SelectedValue & " "
            Dr = gConn.QueryDB(sSql)
            If Dr.Read() Then
                Me.Tag = Dr("RowId") 'Store row id of bracket record in form tag

                txt1A.Tag = Dr("p1aRowId").ToString
                txt1B.Tag = Dr("p1bRowId").ToString
                txt1A.Text = Dr("p1aName").ToString + " " + Dr("p1aTeam").ToString
                txt1B.Text = Dr("p1bName").ToString + " " + Dr("p1bTeam").ToString
                txt1AB.Text = Dr("p1ABName").ToString + vbCrLf + Dr("p1ABTeam").ToString & vbCrLf & gConn.getValue("select WintypeCode from rrwt_wintypes where rowid = " & Dr("R1ABWinTypeRowId").ToString) & " " & Dr("r1abScoreOrTime").ToString

                txt1C.Tag = Dr("p1cRowId").ToString
                txt1D.Tag = Dr("p1dRowId").ToString
                txt1C.Text = Dr("p1cName").ToString + " " + Dr("p1cTeam").ToString
                txt1D.Text = Dr("p1dName").ToString + " " + Dr("p1dTeam").ToString
                txt1CD.Text = Dr("p1cdName").ToString + vbCrLf + Dr("p1CDTeam").ToString & vbCrLf & gConn.getValue("select WintypeCode from rrwt_wintypes where rowid = " & Dr("R1CDWinTypeRowId").ToString) & " " & Dr("r1CDScoreOrTime").ToString

                txt1E.Tag = Dr("p1eRowId").ToString
                txt1F.Tag = Dr("p1fRowId").ToString
                txt1E.Text = Dr("p1eName").ToString + " " + Dr("p1eTeam").ToString
                txt1F.Text = Dr("p1FName").ToString + " " + Dr("p1fTeam").ToString
                txt1EF.Text = Dr("p1efName").ToString + vbCrLf + Dr("p1EFTeam").ToString & vbCrLf & gConn.getValue("select WintypeCode from rrwt_wintypes where rowid = " & Dr("R1EFWinTypeRowId").ToString) & " " & Dr("r1EFScoreOrTime").ToString

                txt2A.Tag = Dr("p2aRowId").ToString
                txt2B.Tag = Dr("p2bRowId").ToString
                txt2A.Text = Dr("p2aName").ToString + " " + Dr("p2aTeam").ToString
                txt2B.Text = Dr("p2bName").ToString + " " + Dr("p2bTeam").ToString
                txt2AB.Text = Dr("p2ABName").ToString + vbCrLf + Dr("p2ABTeam").ToString & vbCrLf & gConn.getValue("select WintypeCode from rrwt_wintypes where rowid = " & Dr("R2ABWinTypeRowId").ToString) & " " & Dr("r2abScoreOrTime").ToString


                txt2C.Tag = Dr("p2cRowId").ToString
                txt2D.Tag = Dr("p2dRowId").ToString
                txt2C.Text = Dr("p2cName").ToString + " " + Dr("p2cTeam").ToString
                txt2D.Text = Dr("p2dName").ToString + " " + Dr("p2dTeam").ToString
                txt2CD.Text = Dr("p2cdName").ToString + vbCrLf + Dr("p2cdTeam").ToString & vbCrLf & gConn.getValue("select WintypeCode from rrwt_wintypes where rowid = " & Dr("R2cdWinTypeRowId").ToString) & " " & Dr("r2cdScoreOrTime").ToString


                txt2E.Tag = Dr("p2eRowId").ToString
                txt2F.Tag = Dr("p2fRowId").ToString
                txt2E.Text = Dr("p2eName").ToString + " " + Dr("p2eTeam").ToString
                txt2F.Text = Dr("p2FName").ToString + " " + Dr("p2fTeam").ToString
                txt2EF.Text = Dr("p2efName").ToString + vbCrLf + Dr("p2efTeam").ToString & vbCrLf & gConn.getValue("select WintypeCode from rrwt_wintypes where rowid = " & Dr("r2efWinTypeRowId").ToString) & " " & Dr("r2efScoreOrTime").ToString



                txt3A.Tag = Dr("p3aRowId").ToString
                txt3B.Tag = Dr("p3bRowId").ToString
                txt3A.Text = Dr("p3aName").ToString + " " + Dr("p3aTeam").ToString
                txt3B.Text = Dr("p3bName").ToString + " " + Dr("p3bTeam").ToString
                txt3AB.Text = Dr("p3ABName").ToString + vbCrLf + Dr("p3ABTeam").ToString & vbCrLf & gConn.getValue("select WintypeCode from rrwt_wintypes where rowid = " & Dr("R3ABWinTypeRowId").ToString) & " " & Dr("r3abScoreOrTime").ToString


                txt3C.Tag = Dr("p3cRowId").ToString
                txt3D.Tag = Dr("p3dRowId").ToString
                txt3C.Text = Dr("p3cName").ToString + " " + Dr("p3cTeam").ToString
                txt3D.Text = Dr("p3dName").ToString + " " + Dr("p3dTeam").ToString
                txt3CD.Text = Dr("p3cdName").ToString + vbCrLf + Dr("p3cdTeam").ToString & vbCrLf & gConn.getValue("select WintypeCode from rrwt_wintypes where rowid = " & Dr("r3cdWinTypeRowId").ToString) & " " & Dr("r3cdScoreOrTime").ToString


                txt3E.Tag = Dr("p3eRowId").ToString
                txt3F.Tag = Dr("p3fRowId").ToString
                txt3E.Text = Dr("p3eName").ToString + " " + Dr("p3eTeam").ToString
                txt3F.Text = Dr("p3FName").ToString + " " + Dr("p3fTeam").ToString
                txt3EF.Text = Dr("p3efName").ToString + vbCrLf + Dr("p3efTeam").ToString & vbCrLf & gConn.getValue("select WintypeCode from rrwt_wintypes where rowid = " & Dr("r3efWinTypeRowId").ToString) & " " & Dr("r3efScoreOrTime").ToString



                txt4A.Tag = Dr("p4aRowId").ToString
                txt4B.Tag = Dr("p4bRowId").ToString
                txt4A.Text = Dr("p4aName").ToString + " " + Dr("p4aTeam").ToString
                txt4B.Text = Dr("p4bName").ToString + " " + Dr("p4bTeam").ToString
                txt4AB.Text = Dr("p4ABName").ToString + vbCrLf + Dr("p4ABTeam").ToString & vbCrLf & gConn.getValue("select WintypeCode from rrwt_wintypes where rowid = " & Dr("r4ABWinTypeRowId").ToString) & " " & Dr("r4ABScoreOrTime").ToString

                txt4C.Tag = Dr("p4cRowId").ToString
                txt4D.Tag = Dr("p4dRowId").ToString
                txt4C.Text = Dr("p4cName").ToString + " " + Dr("p4cTeam").ToString
                txt4D.Text = Dr("p4dName").ToString + " " + Dr("p4dTeam").ToString
                txt4CD.Text = Dr("p4cdName").ToString + vbCrLf + Dr("p4cdTeam").ToString & vbCrLf & gConn.getValue("select WintypeCode from rrwt_wintypes where rowid = " & Dr("r4cdWinTypeRowId").ToString) & " " & Dr("r4cdScoreOrTime").ToString

                txt4E.Tag = Dr("p4eRowId").ToString
                txt4F.Tag = Dr("p4fRowId").ToString
                txt4E.Text = Dr("p4eName").ToString + " " + Dr("p4eTeam").ToString
                txt4F.Text = Dr("p4FName").ToString + " " + Dr("p4fTeam").ToString
                txt4EF.Text = Dr("p4efName").ToString + vbCrLf + Dr("p4efTeam").ToString & vbCrLf & gConn.getValue("select WintypeCode from rrwt_wintypes where rowid = " & Dr("r4efWinTypeRowId").ToString) & " " & Dr("r4efScoreOrTime").ToString


                txt5A.Tag = Dr("p5aRowId").ToString
                txt5B.Tag = Dr("p5bRowId").ToString
                txt5A.Text = Dr("p5aName").ToString + " " + Dr("p5aTeam").ToString
                txt5B.Text = Dr("p5bName").ToString + " " + Dr("p5bTeam").ToString
                txt5AB.Text = Dr("p5ABName").ToString + vbCrLf + Dr("p5ABTeam").ToString & vbCrLf & gConn.getValue("select WintypeCode from rrwt_wintypes where rowid = " & Dr("r5ABWinTypeRowId").ToString) & " " & Dr("r5ABScoreOrTime").ToString

                txt5C.Tag = Dr("p5cRowId").ToString
                txt5D.Tag = Dr("p5dRowId").ToString
                txt5C.Text = Dr("p5cName").ToString + " " + Dr("p5cTeam").ToString
                txt5D.Text = Dr("p5dName").ToString + " " + Dr("p5dTeam").ToString
                txt5CD.Text = Dr("p5cdName").ToString + vbCrLf + Dr("p5cdTeam").ToString & vbCrLf & gConn.getValue("select WintypeCode from rrwt_wintypes where rowid = " & Dr("r5cdWinTypeRowId").ToString) & " " & Dr("r5cdScoreOrTime").ToString

                txt5E.Tag = Dr("p5eRowId").ToString
                txt5F.Tag = Dr("p5fRowId").ToString
                txt5E.Text = Dr("p5eName").ToString + " " + Dr("p5eTeam").ToString
                txt5F.Text = Dr("p5FName").ToString + " " + Dr("p5fTeam").ToString
                txt5EF.Text = Dr("p5efName").ToString + vbCrLf + Dr("p5efTeam").ToString & vbCrLf & gConn.getValue("select WintypeCode from rrwt_wintypes where rowid = " & Dr("r5efWinTypeRowId").ToString) & " " & Dr("r5efScoreOrTime").ToString


            End If

        Catch ex As Exception
            clsErrorManager.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, sSql, ex, Login, False, True)

        Finally

        End Try

    End Sub


    Private Function EditScore(DivisionId As Integer, ClassId As Integer, Bout As String) As Boolean
        Dim sSql As String = ""
        EditScore = False
        frmEditScore.Hide()
        Try
            With frmEditScore
                .cmbWinner.DataSource = gConn.QueryDBTable("select 0  RowId,'' Name union all Select RowId,Name from rrwt_participants where rowid in (" & PassString & ")")
                .cmbWinner.DisplayMember = "Name"
                .cmbWinner.ValueMember = "RowId"
                .cmbWinner.DropDownStyle = ComboBoxStyle.DropDownList
                .cmbWinner.SelectedValue = gConn.getValue("select r" & Bout & "WinPartRowId from rrwt_brackets_vw where DivRowId = " & Me.cmbDivision.SelectedValue & " and classrowid = " & cmbClass.SelectedValue)

                .cmbWinType.DataSource = gConn.QueryDBTable("Select RowId,WinTypeCode,WinTypeTeamPoints from rrwt_WinTypes order by WinTypeCode")
                .cmbWinType.DisplayMember = "WinTypeCode"
                .cmbWinType.ValueMember = "RowId"
                .cmbWinType.DropDownStyle = ComboBoxStyle.DropDownList
                .cmbWinType.SelectedValue = gConn.getValue("select r" & Bout & "WinTypeRowId from rrwt_brackets_vw where DivRowId = " & Me.cmbDivision.SelectedValue & " and classrowid = " & cmbClass.SelectedValue)

                .txtScoreOrTime.Text = gConn.getValue("select r" & Bout & "ScoreOrTime from rrwt_brackets_vw where DivRowId = " & Me.cmbDivision.SelectedValue & " and classrowid = " & cmbClass.SelectedValue)

                .ShowDialog()

                If .cmbSave.Tag = "SaveClicked" Then
                    sSql = "update rrwt_brackets set "
                    sSql = sSql & " r" & Bout & "WinPartRowId = " & .cmbWinner.SelectedValue & ","
                    sSql = sSql & " r" & Bout & "WinTypeRowId = '" & .cmbWinType.SelectedValue & "',"
                    sSql = sSql & " r" & Bout & "ScoreOrTime = '" & .txtScoreOrTime.Text & "'"

                    sSql = sSql & " where DivRowId = " & Me.cmbDivision.SelectedValue & " and classrowid = " & cmbClass.SelectedValue
                    gConn.ExecuteDB(sSql)
                    Load_Bracket_Data()
                    ' MsgBox("Saved")
                End If

                .Dispose()
                .Close()
            End With


            Return True

        Catch ex As Exception
            clsErrorManager.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, sSql, ex, Login, False, True)

        Finally

        End Try

    End Function

    Private Sub txt1AB_DoubleClick(sender As Object, e As EventArgs) Handles txt1AB.DoubleClick
        PassString = txt1A.Tag & "," & txt1B.Tag
        EditScore(Me.cmbDivision.SelectedValue, Me.cmbClass.SelectedValue, "1AB")
    End Sub
    Private Sub txt1cd_DoubleClick(sender As Object, e As EventArgs) Handles txt1CD.DoubleClick
        PassString = txt1C.Tag & "," & txt1D.Tag
        EditScore(Me.cmbDivision.SelectedValue, Me.cmbClass.SelectedValue, "1CD")
    End Sub
    Private Sub txt1ef_DoubleClick(sender As Object, e As EventArgs) Handles txt1EF.DoubleClick
        PassString = txt1E.Tag & "," & txt1F.Tag
        EditScore(Me.cmbDivision.SelectedValue, Me.cmbClass.SelectedValue, "1EF")
    End Sub


    Private Sub txt2AB_DoubleClick(sender As Object, e As EventArgs) Handles txt2AB.DoubleClick
        PassString = txt2A.Tag & "," & txt2B.Tag
        EditScore(Me.cmbDivision.SelectedValue, Me.cmbClass.SelectedValue, "2AB")
    End Sub
    Private Sub txt2cd_DoubleClick(sender As Object, e As EventArgs) Handles txt2CD.DoubleClick
        PassString = txt2C.Tag & "," & txt2D.Tag
        EditScore(Me.cmbDivision.SelectedValue, Me.cmbClass.SelectedValue, "2CD")
    End Sub
    Private Sub txt2EF_DoubleClick(sender As Object, e As EventArgs) Handles txt2EF.DoubleClick
        PassString = txt2E.Tag & "," & txt2F.Tag
        EditScore(Me.cmbDivision.SelectedValue, Me.cmbClass.SelectedValue, "2ef")
    End Sub


    Private Sub txt3AB_DoubleClick(sender As Object, e As EventArgs) Handles txt3AB.DoubleClick
        PassString = txt3A.Tag & "," & txt3B.Tag
        EditScore(Me.cmbDivision.SelectedValue, Me.cmbClass.SelectedValue, "3AB")
    End Sub
    Private Sub txt3cd_DoubleClick(sender As Object, e As EventArgs) Handles txt3CD.DoubleClick
        PassString = txt3C.Tag & "," & txt3D.Tag
        EditScore(Me.cmbDivision.SelectedValue, Me.cmbClass.SelectedValue, "3CD")
    End Sub
    Private Sub txt3EF_DoubleClick(sender As Object, e As EventArgs) Handles txt3EF.DoubleClick
        PassString = txt3E.Tag & "," & txt3F.Tag
        EditScore(Me.cmbDivision.SelectedValue, Me.cmbClass.SelectedValue, "3ef")
    End Sub


    Private Sub txt4AB_DoubleClick(sender As Object, e As EventArgs) Handles txt4AB.DoubleClick
        PassString = txt4A.Tag & "," & txt4B.Tag
        EditScore(Me.cmbDivision.SelectedValue, Me.cmbClass.SelectedValue, "4AB")
    End Sub
    Private Sub txt4cd_DoubleClick(sender As Object, e As EventArgs) Handles txt4CD.DoubleClick
        PassString = txt4C.Tag & "," & txt4D.Tag
        EditScore(Me.cmbDivision.SelectedValue, Me.cmbClass.SelectedValue, "4CD")
    End Sub
    Private Sub txt4EF_DoubleClick(sender As Object, e As EventArgs) Handles txt4EF.DoubleClick
        PassString = txt4E.Tag & "," & txt4F.Tag
        EditScore(Me.cmbDivision.SelectedValue, Me.cmbClass.SelectedValue, "4ef")
    End Sub


    Private Sub txt5AB_DoubleClick(sender As Object, e As EventArgs) Handles txt5AB.DoubleClick
        PassString = txt5A.Tag & "," & txt5B.Tag
        EditScore(Me.cmbDivision.SelectedValue, Me.cmbClass.SelectedValue, "5AB")
    End Sub
    Private Sub txt5cd_DoubleClick(sender As Object, e As EventArgs) Handles txt5CD.DoubleClick
        PassString = txt5C.Tag & "," & txt5D.Tag
        EditScore(Me.cmbDivision.SelectedValue, Me.cmbClass.SelectedValue, "5CD")
    End Sub
    Private Sub txt5EF_DoubleClick(sender As Object, e As EventArgs) Handles txt5EF.DoubleClick
        PassString = txt5E.Tag & "," & txt5F.Tag
        EditScore(Me.cmbDivision.SelectedValue, Me.cmbClass.SelectedValue, "5ef")
    End Sub


    Private Sub btnPrintBoutSheet_Click(sender As Object, e As EventArgs) Handles btnPrintBoutSheet.Click
        Dim myRecSel As String = "{rrwt_brackets_vw1.ClassRowId} = " & Me.cmbClass.SelectedValue & " and {rrwt_brackets_vw1.DivRowId} = " & cmbDivision.SelectedValue
        frmReportViewer.ViewReport(Application.StartupPath & "\Reports\BoutSheets.rpt", myRecSel)
        frmReportViewer.Show()
    End Sub

    Private Sub txt1A_DoubleClick(sender As Object, e As EventArgs) Handles txt1A.DoubleClick
        ProcessParticipantDoubleClick()

    End Sub
    Private Sub ProcessParticipantDoubleClick()
        Dim sSql As String = ""
        frmParticipantPIcker.myDivRowId = cmbDivision.SelectedValue
        frmParticipantPIcker.myClassRowId = cmbClass.SelectedValue
        frmParticipantPIcker.mySelectedParticipantRowId = 0
        frmParticipantPIcker.ShowDialog()
        If frmParticipantPIcker.mySelectedParticipantRowId > 0 Then
            'MsgBox("Save Data " & frmParticipantPIcker.mySelectedParticipantRowId.ToString & " Active Control:" & Me.ActiveControl.Name)
            sSql = "update rrwt_brackets set R" & Strings.Right(Me.ActiveControl.Name, 2) & "PartRowId = " & frmParticipantPIcker.mySelectedParticipantRowId
            sSql = sSql & " where RowId = " & Me.Tag
            If gConn.ExecuteDBRecords(sSql) = 1 Then
                'Save to txtbox tag also.
                Me.ActiveControl.Tag = frmParticipantPIcker.mySelectedParticipantRowId
                Me.ActiveControl.Text = frmParticipantPIcker.mySelectedParticipantName
                Me.ActiveControl.BackColor = Color.Yellow
                frmParticipantPIcker.mySelectedParticipantRowId = 0
            End If
        End If
        frmParticipantPIcker.Close()
        frmParticipantPIcker.Dispose()
    End Sub

    Private Sub txt1B_DoubleClick(sender As Object, e As EventArgs) Handles txt1B.DoubleClick
        ProcessParticipantDoubleClick()
    End Sub


    Private Sub txt1C_DoubleClick(sender As Object, e As EventArgs) Handles txt1C.DoubleClick
        ProcessParticipantDoubleClick()
    End Sub



    Private Sub txt1D_DoubleClick(sender As Object, e As EventArgs) Handles txt1D.DoubleClick
        ProcessParticipantDoubleClick()
    End Sub



    Private Sub txt1E_DoubleClick(sender As Object, e As EventArgs) Handles txt1E.DoubleClick
        ProcessParticipantDoubleClick()
    End Sub



    Private Sub txt1F_DoubleClick(sender As Object, e As EventArgs) Handles txt1F.DoubleClick
        ProcessParticipantDoubleClick()
    End Sub



    Private Sub txt2A_DoubleClick(sender As Object, e As EventArgs) Handles txt2A.DoubleClick
        ProcessParticipantDoubleClick()
    End Sub





    Private Sub txt2C_DoubleClick(sender As Object, e As EventArgs) Handles txt2C.DoubleClick
        ProcessParticipantDoubleClick()
    End Sub



    Private Sub txt2D_DoubleClick(sender As Object, e As EventArgs) Handles txt2D.DoubleClick
        ProcessParticipantDoubleClick()
    End Sub



    Private Sub txt2E_DoubleClick(sender As Object, e As EventArgs) Handles txt2E.DoubleClick
        ProcessParticipantDoubleClick()
    End Sub


    Private Sub txt2F_DoubleClick(sender As Object, e As EventArgs) Handles txt2F.DoubleClick
        ProcessParticipantDoubleClick()
    End Sub



    Private Sub txt3A_DoubleClick(sender As Object, e As EventArgs) Handles txt3A.DoubleClick
        ProcessParticipantDoubleClick()
    End Sub



    Private Sub txt3B_DoubleClick(sender As Object, e As EventArgs) Handles txt3B.DoubleClick
        ProcessParticipantDoubleClick()
    End Sub



    Private Sub txt3C_DoubleClick(sender As Object, e As EventArgs) Handles txt3C.DoubleClick
        ProcessParticipantDoubleClick()
    End Sub



    Private Sub txt3D_DoubleClick(sender As Object, e As EventArgs) Handles txt3D.DoubleClick
        ProcessParticipantDoubleClick()
    End Sub



    Private Sub txt3E_DoubleClick(sender As Object, e As EventArgs) Handles txt3E.DoubleClick
        ProcessParticipantDoubleClick()
    End Sub



    Private Sub txt3F_DoubleClick(sender As Object, e As EventArgs) Handles txt3F.DoubleClick
        ProcessParticipantDoubleClick()
    End Sub



    Private Sub txt4A_DoubleClick(sender As Object, e As EventArgs) Handles txt4A.DoubleClick
        ProcessParticipantDoubleClick()
    End Sub



    Private Sub txt4B_DoubleClick(sender As Object, e As EventArgs) Handles txt4B.DoubleClick
        ProcessParticipantDoubleClick()
    End Sub



    Private Sub txt4C_DoubleClick(sender As Object, e As EventArgs) Handles txt4C.DoubleClick
        ProcessParticipantDoubleClick()
    End Sub



    Private Sub txt4D_DoubleClick(sender As Object, e As EventArgs) Handles txt4D.DoubleClick
        ProcessParticipantDoubleClick()
    End Sub



    Private Sub txt4E_DoubleClick(sender As Object, e As EventArgs) Handles txt4E.DoubleClick
        ProcessParticipantDoubleClick()
    End Sub



    Private Sub txt4F_DoubleClick(sender As Object, e As EventArgs) Handles txt4F.DoubleClick
        ProcessParticipantDoubleClick()
    End Sub



    Private Sub txt5A_DoubleClick(sender As Object, e As EventArgs) Handles txt5A.DoubleClick
        ProcessParticipantDoubleClick()
    End Sub



    Private Sub txt5B_DoubleClick(sender As Object, e As EventArgs) Handles txt5B.DoubleClick
        ProcessParticipantDoubleClick()
    End Sub



    Private Sub txt5C_DoubleClick(sender As Object, e As EventArgs) Handles txt5C.DoubleClick
        ProcessParticipantDoubleClick()
    End Sub



    Private Sub txt5D_DoubleClick(sender As Object, e As EventArgs) Handles txt5D.DoubleClick
        ProcessParticipantDoubleClick()
    End Sub


    Private Sub txt5E_DoubleClick(sender As Object, e As EventArgs) Handles txt5E.DoubleClick
        ProcessParticipantDoubleClick()
    End Sub

    Private Sub txt5F_DoubleClick(sender As Object, e As EventArgs) Handles txt5F.DoubleClick
        ProcessParticipantDoubleClick()
    End Sub

    Private Sub txt1A_TextChanged(sender As Object, e As EventArgs) Handles txt1A.TextChanged

    End Sub

    Private Sub txt2B_DoubleClick(sender As Object, e As EventArgs) Handles txt2B.DoubleClick
        ProcessParticipantDoubleClick()
    End Sub

    Private Sub txt2B_TextChanged(sender As Object, e As EventArgs) Handles txt2B.TextChanged

    End Sub
End Class