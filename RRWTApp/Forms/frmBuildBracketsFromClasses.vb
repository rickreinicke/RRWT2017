Imports System.Data.SQLite
Public Class frmBuildBracketsFromClasses

    Private Sub btnBegin_Click(sender As Object, e As EventArgs) Handles btnBegin.Click
        BeginPopulating()
    End Sub

    Private Sub BeginPopulating()
        'Populate First Round
        ' Dim msConn As New clsDataManager
        Dim Dr As SQLiteDataReader = Nothing
        Dim sSQL As String = ""
        Dim ht As Hashtable
        Dim x As Integer = 0 'sequence counter for participants in class.
        Dim y As Integer = 0 'counter for participants in class
        Dim myCntInClass As Integer = 0
        Dim myCntInBracket As Integer = 0
        Dim BracketLetter() As String = {"A", "B", "C", "D", "E", "F"}
        Dim myByeRowId As Integer = 0
        'Dim msConnB As New clsDataManager
        'Dim DrBracket As SqlDataReader = Nothing


        Try

            'Warn if this has already been done for this Divisibon
            If gConn.getValue("select count(*) from rrwt_brackets where divrowid = " & cmbDivisions.SelectedValue) > 0 Then
                If MsgBox(cmbDivisions.Text & " Participants have already been inserted into brackets for Division: " & vbCrLf & "Click OK to Continue", MsgBoxStyle.OkCancel, "Warning Scores and Pairings will be overwritten for this Division.") <> MsgBoxResult.Ok Then
                    Exit Sub
                End If
            End If

            'Make sure all participants have been assigned to a Division and Class
            If gConn.getValue("select count(*) from rrwt_participants where divisionId = " & cmbDivisions.SelectedValue & " and classid < 1") > 0 Then
                MsgBox("Not all Participants have been assigned a Class in Division: " & cmbDivisions.SelectedText)
                Exit Sub
            End If


            ' Get Bye RowId
            myByeRowId = gConn.getValue("select  rowid from rrwt_participants where name = 'Bye' order by rowid limit 1 ")

            'Clear out all brackets
            'If chkClearFirst.CheckState = CheckState.Checked Then
            gConn.ExecuteDB("delete from rrwt_brackets where divRowid = " & cmbDivisions.SelectedValue)
            gConn.ExecuteDB("update rrwt_participants set bracketid = 0 where DivisionId = " & cmbDivisions.SelectedValue)
            'End If

            'Loop thru participants and assign a position in the brackets
            'msConn.OpenDB(Login.DBServer, Login.Database, Login.DatabaseUser, Login.DatabasePass)
            sSQL = "select * from rrwt_participants where BracketId = 0 and DivisionId = " & cmbDivisions.SelectedValue & " order by DivisionId,ClassId, Weight"
            Dr = gConn.QueryDB(sSQL)
            Do While Dr.Read()
                'Create Bracket if it doesn't exist
                If gConn.getValue("select count(*) from rrwt_brackets where divrowid = " & Dr("DivisionId") & " and classrowid = " & Dr("ClassId")) = 0 Then
                    sSQL = "insert into rrwt_brackets (DivRowId,ClassRowId) values (" & Dr("DivisionId") & "," & Dr("ClassId") & ")"
                    gConn.ExecuteDB(sSQL)
                End If

                'Populate the first round Bracket
                myCntInClass = gConn.getValue("select count(*) from rrwt_participants where DivisionId = " & Dr("DivisionId") & " and ClassId = " & Dr("ClassId"))
                For y = 1 To myCntInClass
                    gConn.ExecuteDB("UPDATE rrwt_brackets set R1" & BracketLetter(y - 1) & "PARTROWID = " & Dr("RowId") & " where DivRowId = " & Dr("DivisionId") & " and ClassRowId = " & Dr("ClassId"))

                    'If 3 or 5 in bracket add a buy in the 4th or 6th spot
                    If myCntInClass = y And (myCntInClass = 3 Or myCntInClass = 5) Then
                        gConn.ExecuteDB("UPDATE rrwt_brackets set R1" & BracketLetter(y) & "PARTROWID = " & myByeRowId & " where DivRowId = " & Dr("DivisionId") & " and ClassRowId = " & Dr("ClassId"))
                    End If



                    If y < myCntInClass Then
                        Dr.Read()
                    End If
                Next

                'Get Bracket Record
                ht = gConn.GetHashRecord("Select * from rrwt_brackets where divrowid = " & Dr("DivisionId") & " and classrowid = " & Dr("ClassId"))
                'If ht.Count > 0 Then

                'Populate Remaining Rounds if 2 Man Bracket
                If myCntInClass = 2 Then
                    sSQL = "update rrwt_brackets set  "
                    sSQL = sSQL & " R2APARTROWID = R1BPARTROWID,"
                    sSQL = sSQL & " R2BPARTROWID = R1APARTROWID,"

                    sSQL = sSQL & " R3APARTROWID = R1APARTROWID,"
                    sSQL = sSQL & " R3BPARTROWID = R1BPARTROWID"
                    sSQL = sSQL & " where divrowid = " & Dr("DivisionId") & " and classrowid = " & Dr("ClassId")
                    gConn.ExecuteDB(sSQL)
                End If

                If myCntInClass = 3 Then
                    sSQL = "update rrwt_brackets set  "
                    sSQL = sSQL & " R2aPARTROWID = R1bPARTROWID,"
                    sSQL = sSQL & " R2BPARTROWID = R1cPARTROWID,"
                    sSQL = sSQL & " R2CPARTROWID = R1aPARTROWID,"
                    sSQL = sSQL & " R2dPARTROWID = " & myByeRowId & ","

                    sSQL = sSQL & " R3APARTROWID = R1cPARTROWID,"
                    sSQL = sSQL & " R3BPARTROWID = R1aPARTROWID,"
                    sSQL = sSQL & " R3CPARTROWID = R1bPARTROWID,"
                    sSQL = sSQL & " R3dPARTROWID = " & myByeRowId & ""
                    sSQL = sSQL & " where divrowid = " & Dr("DivisionId") & " and classrowid = " & Dr("ClassId")
                    gConn.ExecuteDB(sSQL)
                End If

                If myCntInClass = 4 Then
                    sSQL = "update rrwt_brackets set  "
                    sSQL = sSQL & " R2aPARTROWID = R1aPARTROWID,"
                    sSQL = sSQL & " R2BPARTROWID = R1dPARTROWID,"
                    sSQL = sSQL & " R2CPARTROWID = R1bPARTROWID,"
                    sSQL = sSQL & " R2dPARTROWID = R1cPARTROWID,"

                    sSQL = sSQL & " R3APARTROWID = R1aPARTROWID,"
                    sSQL = sSQL & " R3BPARTROWID = R1cPARTROWID,"
                    sSQL = sSQL & " R3CPARTROWID = R1bPARTROWID,"
                    sSQL = sSQL & " R3dPARTROWID = R1dPARTROWID"
                    sSQL = sSQL & " where divrowid = " & Dr("DivisionId") & " and classrowid = " & Dr("ClassId")
                    gConn.ExecuteDB(sSQL)
                End If

                If myCntInClass = 5 Then
                    sSQL = "update rrwt_brackets set  "
                    sSQL = sSQL & " R2aPARTROWID = R1aPARTROWID,"
                    sSQL = sSQL & " R2BPARTROWID = R1cPARTROWID,"
                    sSQL = sSQL & " R2CPARTROWID = R1bPARTROWID,"
                    sSQL = sSQL & " R2dPARTROWID = R1ePARTROWID,"
                    sSQL = sSQL & " R2ePARTROWID = R1dPARTROWID,"
                    sSQL = sSQL & " R2fPARTROWID =  " & myByeRowId & ","

                    sSQL = sSQL & " R3APARTROWID = R1aPARTROWID,"
                    sSQL = sSQL & " R3BPARTROWID = R1dPARTROWID,"
                    sSQL = sSQL & " R3CPARTROWID = R1cPARTROWID,"
                    sSQL = sSQL & " R3dPARTROWID = R1ePARTROWID,"
                    sSQL = sSQL & " R3ePARTROWID = R1bPARTROWID,"
                    sSQL = sSQL & " R3fPARTROWID =  " & myByeRowId & ","

                    sSQL = sSQL & " R4APARTROWID = R1aPARTROWID,"
                    sSQL = sSQL & " R4BPARTROWID = R1ePARTROWID,"
                    sSQL = sSQL & " R4CPARTROWID = R1bPARTROWID,"
                    sSQL = sSQL & " R4dPARTROWID = R1dPARTROWID,"
                    sSQL = sSQL & " R4ePARTROWID = R1cPARTROWID,"
                    sSQL = sSQL & " R4fPARTROWID =  " & myByeRowId & ","

                    sSQL = sSQL & " R5APARTROWID = R1bPARTROWID,"
                    sSQL = sSQL & " R5BPARTROWID = R1cPARTROWID,"
                    sSQL = sSQL & " R5CPARTROWID = R1ePARTROWID,"
                    sSQL = sSQL & " R5dPARTROWID = R1dPARTROWID,"
                    sSQL = sSQL & " R5ePARTROWID = R1aPARTROWID,"
                    sSQL = sSQL & " R5fPARTROWID =  " & myByeRowId & ""



                    sSQL = sSQL & " where divrowid = " & Dr("DivisionId") & " and classrowid = " & Dr("ClassId")
                    gConn.ExecuteDB(sSQL)
                End If

                If myCntInClass = 6 Then
                    sSQL = "update rrwt_brackets set  "
                    sSQL = sSQL & " R2aPARTROWID = R1aPARTROWID,"
                    sSQL = sSQL & " R2BPARTROWID = R1cPARTROWID,"
                    sSQL = sSQL & " R2CPARTROWID = R1bPARTROWID,"
                    sSQL = sSQL & " R2dPARTROWID = R1ePARTROWID,"
                    sSQL = sSQL & " R2ePARTROWID = R1dPARTROWID,"
                    sSQL = sSQL & " R2fPARTROWID = R1fPARTROWID," ' " & myByeRowId & ","

                    sSQL = sSQL & " R3APARTROWID = R1aPARTROWID,"
                    sSQL = sSQL & " R3BPARTROWID = R1dPARTROWID,"
                    sSQL = sSQL & " R3CPARTROWID = R1cPARTROWID,"
                    sSQL = sSQL & " R3dPARTROWID = R1ePARTROWID,"
                    sSQL = sSQL & " R3ePARTROWID = R1bPARTROWID,"
                    sSQL = sSQL & " R3fPARTROWID = R1fPARTROWID, " '& myByeRowId & ","

                    sSQL = sSQL & " R4APARTROWID = R1aPARTROWID,"
                    sSQL = sSQL & " R4BPARTROWID = R1ePARTROWID,"
                    sSQL = sSQL & " R4CPARTROWID = R1bPARTROWID,"
                    sSQL = sSQL & " R4dPARTROWID = R1dPARTROWID,"
                    sSQL = sSQL & " R4ePARTROWID = R1cPARTROWID,"
                    sSQL = sSQL & " R4fPARTROWID = R1fPARTROWID," '& myByeRowId & ","

                    sSQL = sSQL & " R5APARTROWID = R1bPARTROWID,"
                    sSQL = sSQL & " R5BPARTROWID = R1cPARTROWID,"
                    sSQL = sSQL & " R5CPARTROWID = R1ePARTROWID,"
                    sSQL = sSQL & " R5dPARTROWID = R1dPARTROWID,"
                    sSQL = sSQL & " R5ePARTROWID = R1aPARTROWID,"
                    sSQL = sSQL & " R5fPARTROWID = R1fPARTROWID " '& myByeRowId & ""



                    sSQL = sSQL & " where divrowid = " & Dr("DivisionId") & " and classrowid = " & Dr("ClassId")
                    gConn.ExecuteDB(sSQL)
                End If

                x = x + 1

                Application.DoEvents()

            Loop


            ' Create Bye records in each class if needed.


            lblFeedback.Text = "Finished (" & x.ToString & ")"


        Catch ex As Exception
            clsErrorManager.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, sSQL, ex, Login, False, True)

        Finally
            gConn.CloseReader(Dr)
            'gConn.CloseDB()
            ht = Nothing
        End Try

    End Sub

    Private Sub frmBuildBracketsFromClasses_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With Me.cmbDivisions
            .DataSource = gConn.QueryDBTable("Select RowId,DivisionDesc from rrwt_divisions order by RowId")
            .DisplayMember = "DivisionDesc"
            .ValueMember = "RowId"
            .DropDownStyle = ComboBoxStyle.DropDownList
        End With

    End Sub
End Class