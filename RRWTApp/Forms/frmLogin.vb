Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SQLite

Public Class frmLogin
    Public bLoginSuccessfull As Boolean = False


    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles OK.Click
        If Connect_Create_Database() <> True Then
            MsgBox("Exiting Application")
            Stop
        Else
            Me.lblInvalidLogin.Visible = False
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If


        'If PasswordValid(Me.txtUserName.Text, Me.txtPassword.Text) = True Then
        '    Me.lblInvalidLogin.Visible = False
        '    Me.DialogResult = Windows.Forms.DialogResult.OK
        '    Me.Close()
        'Else
        '    Me.lblInvalidLogin.Visible = True
        '    MsgBox("Invalid Login Information.", MsgBoxStyle.OkOnly)
        '    Me.DialogResult = Windows.Forms.DialogResult.Cancel
        '    Me.Close()
        'End If
    End Sub

    Private Sub frmLogin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'MainForm.Close()
        'Me.Dispose()
        'End
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles Me.Load

        InstallSQLiteODBCDriver()

        If My.Computer.Registry.CurrentUser.GetValue("DataFolder") = "" Then
            Me.txtDataFolder.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        Else
            Me.txtDataFolder.Text = My.Computer.Registry.CurrentUser.GetValue("DataFolder")
        End If
        If My.Computer.Registry.CurrentUser.GetValue("DataFilename") = "" Then
            Me.cmbDataFilename.Text = "RRWT.db"
        Else
            Me.cmbDataFilename.Text = My.Computer.Registry.CurrentUser.GetValue("DataFilename")
        End If


        If My.Computer.Registry.CurrentUser.GetValue("RefreshDemoData") > "" Then
            Me.chkRefreshDemoData.Checked = My.Computer.Registry.CurrentUser.GetValue("RefreshDemoData")
        End If

        'Me.txtUserName.Text = My.Computer.Registry.CurrentUser.GetValue("AppUserName")
        ' Me.txtPassword.Text = My.Computer.Registry.CurrentUser.GetValue("AppPassword")
        Me.lblLocalIPNumber.Text = System.Net.Dns.GetHostName.ToUpper


    End Sub
    Private Sub InstallSQLiteODBCDriver()

        Try
            '#If Not Debug Then 
            If System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Sqliteodbc_w64.exe") Then
                If MsgBox("SQLite ODBC Driver needs to be installed, press OK and take the defaults on the next SQLite screens.", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Dim p As Process = Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Sqliteodbc_w64.exe")
                    p.WaitForExit()
                    p.Dispose()
                    System.IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Sqliteodbc_w64.exe")
                End If
            End If
            '#End If
        Catch ex As Exception
            clsErrorManager.WriteErrorLog("frmLogin", "InstallSQLiteODBCDriver", "", ex, Login)

        End Try
    End Sub
    Private Function Connect_Create_Database() As Boolean

        Connect_Create_Database = False

        Try
            ' Setup Login
            ' Login.UserName = Me.txtUserName.Text
            Login.DatabaseUser = "sa" 'Me.txtUserName.Text
            Login.DatabasePass = "admin" 'me.txtPassword.Text
            Login.DataFolder = Me.txtDataFolder.Text
            Login.DataFilename = Me.cmbDataFilename.Text
            Login.DataFullPath = Path.Combine(Login.DataFolder, Login.DataFilename)


            If (Not System.IO.Directory.Exists(Application.StartupPath & "\Errors")) Then
                System.IO.Directory.CreateDirectory(Application.StartupPath & "\Errors")
            End If
            Login.ErrorLogPath = Application.StartupPath & "\Errors\"
            Login.ErrorImagePath = Application.StartupPath & "\Errors\"
            'Login.DBServer = Me.cmbServer.Text
            'Login.Database = Me.cmbDatabase.Text

            'Save Registry Info
            'My.Computer.Registry.CurrentUser.SetValue("Server", Me.cmbServer.Text.ToString)
            'My.Computer.Registry.CurrentUser.SetValue("Database", Me.cmbDatabase.Text.ToString)


            My.Computer.Registry.CurrentUser.SetValue("DataFolder", Me.txtDataFolder.Text.ToString)
            My.Computer.Registry.CurrentUser.SetValue("DataFilename", Me.cmbDataFilename.Text.ToString)
            My.Computer.Registry.CurrentUser.SetValue("RefreshDemoData", Me.chkRefreshDemoData.Checked)
            'My.Computer.Registry.CurrentUser.SetValue("AppUserName", Me.txtUserName.Text.ToString)
            'My.Computer.Registry.CurrentUser.SetValue("AppPassword", Me.txtPassword.Text.ToString)


            'gConn.OpenDB(Login.DBServer, "master", Login.DatabaseUser, Login.DatabasePass)
            'If gConn.ExecuteDB("Select count(*) from sys.databases where name = '" & cmbDatabase.Text.ToString & "'") = 0 Then
            '    gConn.ExecuteDB("Create Database " & Me.cmbDatabase.Text.ToString)
            '    gConn.ExecuteDB("use " & Login.Database & "; create table test(PersonId int);")
            '    gConn.CloseDB()
            '    gConn.OpenDB(Login.DBServer, Login.Database, Login.DatabaseUser, Login.DatabasePass)
            '    'and create tables, views and populate minimum tables.

            'End If


            'If gConn.IsOpen Then
            '    gConn.CloseDB()
            'End If

            ' InstallSQLiteODBCDriver()

            If Me.cmbDataFilename.Text.Contains("RRWTDemo.db") And chkRefreshDemoData.CheckState = CheckState.Checked Then
                System.IO.File.Copy(Application.StartupPath & "\ExtraFiles\RRWTDemo.db", Login.DataFullPath, True)
            End If

            If Not System.IO.File.Exists(Login.DataFullPath) Then
                If MsgBox("Database does not exist, OK to Create?", MsgBoxStyle.OkCancel, "Create:" & Login.DataFullPath) = MsgBoxResult.Ok Then
                    'Create Database
                    gConn.OpenDB(Login.DBServer, Login.Database, Login.DatabaseUser, Login.DatabasePass)
                    CreateTables()
                    gConn.CloseDB()
                End If
            End If


            gConn.OpenDB(Login.DBServer, Login.Database, Login.DatabaseUser, Login.DatabasePass)

            Connect_Create_Database = True
            'Return ValidUser(Login.DatabaseUser, Login.DatabasePass)
            'Return ValidUser(Me.txtUserName.Text, Me.txtPassword.Text)

        Catch ex As Exception
            clsErrorManager.WriteErrorLog("frmLogin", "PasswordValid", "", ex, Login)
            Return False
        End Try

    End Function
  

    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnFindLocation_Click(sender As Object, e As EventArgs) Handles btnFindLocation.Click
        Dim folderDlg As New FolderBrowserDialog
        If folderDlg.ShowDialog() = DialogResult.OK Then
            Me.txtDataFolder.Text = folderDlg.SelectedPath
        End If


    End Sub
    Private Sub CreateTables()

        Try
            'Create Tables
            'DBVersion 100
            gConn.ExecuteDB("CREATE TABLE [RRWT_Participants] ( [RowId] integer NOT NULL PRIMARY KEY AUTOINCREMENT, [Name] varchar(50)  , [Team] varchar(50)  , [Age] integer, [Weight] numeric, [DivisionId] integer, [ClassId] integer, [BracketId] integer DEFAULT 0, [Note] varchar(400)  , [Rating] varchar(50)   DEFAULT '' )")
            gConn.ExecuteDB("CREATE TABLE [RRWT_errors] ( [ServerName] varchar(50)  , [ComputerName] varchar(50)  , [username] varchar(50)  , [date_time] datetime, [app_name] varchar(50)  , [app_rev] varchar(50)  , [form_name] varchar(70)  , [procedure_name] varchar(100)  , [sql_statement] varchar(4000)  , [comment] varchar(4000)  , [ErrNumber] varchar(200)   )")
            gConn.ExecuteDB("CREATE TABLE [RRWT_help] ( [form_name] varchar(50) NOT NULL  , [field_name] varchar(50) NOT NULL  , [Help_text] varchar(8000)  , [Record_id] integer NOT NULL )")
            gConn.ExecuteDB("CREATE TABLE [RRWT_log] ( [date_time] datetime, [table_info] nvarchar(50)  , [record_cnt] nvarchar(30)  , [error_cnt] nvarchar(30)  , [timer_cnt] nvarchar(30)   )")
            'gConn.ExecuteDB("CREATE TABLE [RRWT_security] ( [UserName] varchar(50) NOT NULL, [Password] varchar(50)  , [FullName] varchar(50)  , [Email] varchar(50)  , [Modified_By] varchar(50)  , [Modified_Date] datetime, PRIMARY KEY ([UserName]) )")
            'gConn.ExecuteDB("CREATE TABLE [RRWT_security2] ( [username] char(10) NOT NULL  , [formname] char(150) NOT NULL  , [allowed] bit, [SortOrder] integer, [MenuLevel] integer )")
            gConn.ExecuteDB("CREATE TABLE [USRegistry] ( [UserName] varchar(200) NOT NULL  , [AppName] varchar(200) NOT NULL  , [SettingSection] varchar(200) NOT NULL  , [SettingKey] varchar(200) NOT NULL  , [Setting] varchar(8000)  , [Is_Public] bit DEFAULT 0, [User_Default] bit DEFAULT 0, [Modified_Date] datetime, [Modified_By] varchar(50)  , [Created_By] varchar(50)  , [Created_Date] datetime, PRIMARY KEY ([UserName], [AppName], [SettingSection], [SettingKey]) )")
            gConn.ExecuteDB("CREATE TABLE [USRegistryLarge] ( [UserName] varchar(200) NOT NULL  , [AppName] varchar(200) NOT NULL  , [SettingSection] varchar(200) NOT NULL  , [SettingKey] varchar(200) NOT NULL  , [Setting] text(2147483647)  , [Modified_Date] datetime, [Modified_By] varchar(50)  , [Created_By] varchar(50)  , [Created_Date] datetime, PRIMARY KEY ([UserName], [AppName], [SettingSection], [SettingKey]) )")
            gConn.ExecuteDB("CREATE TABLE [US_security2] ( [appname] varchar(100) NOT NULL  , [username] varchar(50) NOT NULL  , [formname] varchar(100) NOT NULL  , [formtruename] varchar(200)  , [allowed] bit, [SortOrder] integer, [MenuLevel] integer, [MenuSortOrder] varchar(200)  , PRIMARY KEY ([appname], [username], [formname]) )")
            gConn.ExecuteDB("CREATE TABLE [rrwt_brackets] ( `RowId` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, `DivRowId` INTEGER NOT NULL, `ClassRowId` INTEGER NOT NULL, `R1APartRowId` integer DEFAULT 0, `R1BPartRowId` integer DEFAULT 0, `R1ABWinPartRowId` integer DEFAULT 0, `R1ABWinTypeRowId` integer DEFAULT 0, `R1ABScoreOrTime` varchar ( 50 ) DEFAULT '', `R1CPartRowId` integer DEFAULT 0, `R1DPartRowId` integer DEFAULT 0, `R1CDWinPartRowId` integer DEFAULT 0, `R1CDWintypeRowId` integer DEFAULT 0, `R1CDScoreOrTime` varchar ( 50 ) DEFAULT '', `R1EPartRowId` integer DEFAULT 0, `R1FPartRowId` integer DEFAULT 0, `R1EFWinPartRowId` integer DEFAULT 0, `R1EFWintypeRowId` integer DEFAULT 0, `R1EFScoreOrTime` varchar ( 50 ) DEFAULT '', `R2APartRowId` integer DEFAULT 0, `R2BPartRowId` integer DEFAULT 0, `R2ABWinPartRowId` integer DEFAULT 0, `R2ABWintypeRowId` integer DEFAULT 0, `R2ABScoreOrTime` varchar ( 50 ) DEFAULT '', `R2CPartRowId` integer DEFAULT 0, `R2DPartRowId` integer DEFAULT 0, `R2CDWinPartRowId` integer DEFAULT 0, `R2CDWintypeRowId` integer DEFAULT 0, `R2CDScoreOrTime` varchar ( 50 ) DEFAULT '', `R2EPartRowId` integer DEFAULT 0, `R2FPartRowId` integer DEFAULT 0, `R2EFWinPartRowId` integer DEFAULT 0, `R2EFWintypeRowId` integer DEFAULT 0, `R2EFScoreOrTime` varchar ( 50 ) DEFAULT '', `R3APartRowId` integer DEFAULT 0, `R3BPartRowId` integer DEFAULT 0, `R3ABWinPartRowId` integer DEFAULT 0, `R3ABWintypeRowId` integer DEFAULT 0, `R3ABScoreOrTime` varchar ( 50 ) DEFAULT '', `R3CPartRowId` integer DEFAULT 0, `R3DPartRowId` integer DEFAULT 0, `R3CDWinPartRowId` integer DEFAULT 0, `R3CDWintypeRowId` integer DEFAULT 0, `R3CDScoreOrTime` varchar ( 50 ) DEFAULT '', `R3EPartRowId` integer DEFAULT 0, `R3FPartRowId` integer DEFAULT 0, `R3EFWinPartRowId` integer DEFAULT 0, `R3EFWintypeRowId` integer DEFAULT 0, `R3EFScoreOrTime` varchar ( 50 ) DEFAULT '', `R4APartRowId` integer DEFAULT 0, `R4BPartRowId` integer DEFAULT 0, `R4ABWinPartRowId` integer DEFAULT 0, `R4ABWintypeRowId` integer DEFAULT 0, `R4ABScoreOrTime` varchar ( 50 ) DEFAULT '', `R4CPartRowId` integer DEFAULT 0, `R4DPartRowId` integer DEFAULT 0, `R4CDWinPartRowId` integer DEFAULT 0, `R4CDWintypeRowId` integer DEFAULT 0, `R4CDScoreOrTime` varchar ( 50 ) DEFAULT '', `R4EPartRowId` integer DEFAULT 0, `R4FPartRowId` integer DEFAULT 0, `R4EFWinPartRowId` integer DEFAULT 0, `R4EFWintypeRowId` integer DEFAULT 0, `R4EFScoreOrTime` varchar ( 50 ) DEFAULT '', `R5APartRowId` integer DEFAULT 0, `R5BPartRowId` integer DEFAULT 0, `R5ABWinPartRowId` integer DEFAULT 0, `R5ABWintypeRowId` integer DEFAULT 0, `R5ABScoreOrTime` varchar ( 50 ) DEFAULT '', `R5CPartRowId` integer DEFAULT 0, `R5DPartRowId` integer DEFAULT 0, `R5CDWinPartRowId` integer DEFAULT 0, `R5CDWintypeRowId` integer DEFAULT 0, `R5CDScoreOrTime` varchar ( 50 ) DEFAULT '', `R5EPartRowId` integer DEFAULT 0, `R5FPartRowId` integer DEFAULT 0, `R5EFWinPartRowId` integer DEFAULT 0, `R5EFWintypeRowId` integer DEFAULT 0, `R5EFScoreOrTime` varchar ( 50 ) DEFAULT '' )")
            gConn.ExecuteDB("CREATE TABLE [rrwt_classes] ( [RowId] integer NOT NULL PRIMARY KEY AUTOINCREMENT, [DivisionRowId] integer, [ClassDesc] varchar(50)   )")
            gConn.ExecuteDB("CREATE TABLE [rrwt_divisions] ( [RowId] integer NOT NULL PRIMARY KEY AUTOINCREMENT, [DivisionDesc] varchar(50)   )")
            gConn.ExecuteDB("CREATE TABLE [rrwt_system] ( [TournyName] varchar(100) ,[DBVersion] INTEGER  )")
            gConn.ExecuteDB("CREATE TABLE [rrwt_wintypes] ( [RowId] integer NOT NULL PRIMARY KEY AUTOINCREMENT, [WinTypeCode] varchar(50)  , [WinTypeTeamPoints] integer )")

            'Create Views
            gConn.ExecuteDB("CREATE VIEW rrwt_brackets_vw AS SELECT br.RowId, br.DivRowId, dv.DivisionDesc, br.ClassRowId, cl.ClassDesc, br.R1APartRowId, br.R1BPartRowId, br.R1ABWinPartRowId, br.R1ABWinTypeRowId, br.R1ABScoreOrTime, br.R1CPartRowId, br.R1DPartRowId, br.R1CDWinPartRowId, br.R1CDWintypeRowId, br.R1CDScoreOrTime, br.R1EPartRowId, br.R1FPartRowId, br.R1EFWinPartRowId, br.R1EFWintypeRowId, br.R1EFScoreOrTime, br.R2APartRowId, br.R2BPartRowId, br.R2ABWinPartRowId, br.R2ABWintypeRowId, br.R2ABScoreOrTime, br.R2CPartRowId, br.R2DPartRowId, br.R2CDWinPartRowId, br.R2CDWintypeRowId, br.R2CDScoreOrTime, br.R2EPartRowId, br.R2FPartRowId, br.R2EFWinPartRowId, br.R2EFWintypeRowId, br.R2EFScoreOrTime, br.R3APartRowId, br.R3BPartRowId, br.R3ABWinPartRowId, br.R3ABWintypeRowId, br.R3ABScoreOrTime, br.R3CPartRowId, br.R3DPartRowId, br.R3CDWinPartRowId, br.R3CDWintypeRowId, br.R3CDScoreOrTime, br.R3EPartRowId, br.R3FPartRowId, br.R3EFWinPartRowId, br.R3EFWintypeRowId, br.R3EFScoreOrTime, br.R4APartRowId, br.R4BPartRowId, br.R4ABWinPartRowId, br.R4ABWintypeRowId, br.R4ABScoreOrTime, br.R4CPartRowId, br.R4DPartRowId, br.R4CDWinPartRowId, br.R4CDWintypeRowId, br.R4CDScoreOrTime, br.R4EPartRowId, br.R4FPartRowId, br.R4EFWinPartRowId, br.R4EFWintypeRowId, br.R4EFScoreOrTime, br.R5APartRowId, br.R5BPartRowId, br.R5ABWinPartRowId, br.R5ABWintypeRowId, br.R5ABScoreOrTime, br.R5CPartRowId, br.R5DPartRowId, br.R5CDWinPartRowId, br.R5CDWintypeRowId, br.R5CDScoreOrTime, br.R5EPartRowId, br.R5FPartRowId, br.R5EFWinPartRowId, br.R5EFWintypeRowId, br.R5EFScoreOrTime, p1a.RowId AS p1aRowId, p1a.Name AS p1aName, p1a.Team AS p1aTeam, p1a.Age AS p1aAge, p1a.Weight AS p1aWeight, p1a.DivisionId AS p1aDivisionId, p1a.ClassId AS p1aClassId, p1a.BracketId AS p1aBracketId, p1a.Note AS p1aNote, p1b.RowId AS p1bRowId, p1b.Name AS p1bName, p1b.Team AS p1bTeam, p1b.Age AS p1bAge, p1b.Weight AS p1bWeight, p1b.DivisionId AS p1bDivisionId, p1b.ClassId AS p1bClassId, p1b.BracketId AS p1bBracketId, p1b.Note AS p1bNote, p1c.RowId AS p1cRowId, p1c.Name AS p1cName, p1c.Team AS p1cTeam, p1c.Age AS p1cAge, p1c.Weight AS p1cWeight, p1c.DivisionId AS p1cDivisionId, p1c.ClassId AS p1cClassId, p1c.BracketId AS p1cBracketId, p1c.Note AS p1cNote, p1d.RowId AS p1dRowId, p1d.Name AS p1dName, p1d.Team AS p1dTeam, p1d.Age AS p1dAge, p1d.Weight AS p1dWeight, p1d.DivisionId AS p1dDivisionId, p1d.ClassId AS p1dClassId, p1d.BracketId AS P1dBracketId, p1d.Note AS p1dNote, p1e.RowId AS p1eRowId, p1e.Name AS p1eName, p1e.Team AS p1eTeam, p1e.Age AS p1eAge, p1e.Weight AS p1eWeight, p1e.DivisionId AS p1eDivisionId, p1e.ClassId AS p1eClassId, p1e.BracketId AS p1eBracketId, p1e.Note AS p1eNote, p1f.RowId AS p1fRowId, p1f.Name AS p1fName, p1f.Team AS p1fTeam, p1f.Age AS p1fAge, p1f.Weight AS p1fWeight, p1f.DivisionId AS p1fDivisionId, p1f.ClassId AS p1fClassId, p1f.BracketId AS p1fBracketId, p1f.Note AS p1fNote, p2a.RowId AS p2aRowId, p2a.Name AS p2aName, p2a.Team AS p2aTeam, p2a.Age AS p2aAge, p2a.Weight AS p2aWeight, p2a.DivisionId AS p2aDivsionId, p2a.ClassId AS p2aClassId, p2a.BracketId AS p2aBracketId, p2a.Note AS p2aNote, p2b.RowId AS p2bRowId, p2b.Name AS p2bName, p2b.Team AS p2bTeam, p2b.Age AS p2bAge, p2b.Weight AS p2bWeight, p2b.DivisionId AS p2bDivisionId, p2b.ClassId AS p2bClassId, p2b.BracketId AS p2bBracketId, p2b.Note AS p2bNote, p2c.RowId AS p2cRowId, p2c.Name AS p2cName, p2c.Team AS p2cTeam, p2c.Age AS p2cAge, p2c.Weight AS p2cWeight, p2c.DivisionId AS pt2DivsionId, p2c.ClassId AS p2cClassId, p2c.BracketId AS p2cBracketId, p2c.Note AS p2cNote, p2d.RowId AS p2dRowId, p2d.Name AS p2dName, p2d.Team AS p2dTeam, p2d.Age AS p2dAge, p2d.Weight AS p2dWeight, p2d.DivisionId AS p2dDivisionId, p2d.ClassId AS p2dClassId, p2d.BracketId AS p2dBracketId, p2d.Note AS p2dNote, p2e.RowId AS p2eRowId, p2e.Name AS p2eName, p2e.Team AS p2eTeam, p2e.Age AS p2eAge, p2e.Weight AS p2eWeight, p2e.DivisionId AS p2eDivisionId, p2e.ClassId AS p2eClassId, p2e.BracketId AS p2eBracketId, p2e.Note AS p2eNote, p2f.RowId AS p2fRowId, p2f.Name AS p2fName, p2f.Team AS p2fTeam, p2f.Age AS p2fAge, p2f.Weight AS p2fWeight, p2f.DivisionId AS p2fDivisionId, p2f.ClassId AS p2fClassId, p2f.BracketId AS p2fBracketId, p2f.Note AS p2fNote, p3a.RowId AS p3aRowId, p3a.Name AS p3aName, p3a.Team AS p3aTeam, p3a.Age AS p3aAge, p3a.Weight AS p3aWeight, p3a.DivisionId AS p3aDivisionId, p3a.ClassId AS p3aClassId, p3a.BracketId AS p3aBracketId, p3a.Note AS p3aNote, p3b.RowId AS p3bRowId, p3b.Name AS p3bName, p3b.Team AS p3bTeam, p3b.Age AS p3bAge, p3b.Weight AS p3bWeight, p3b.DivisionId AS p3bDivisionId, p3b.ClassId AS p3bClassId, p3b.BracketId AS p3bBracketId, p3b.Note AS p3bNote, p3c.RowId AS p3cRowId, p3c.Name AS p3cName, p3c.Team AS p3cTeam, p3c.Age AS p3cAge, p3c.Weight AS p3cWeight, p3c.DivisionId AS p3cDivisionId, p3c.ClassId AS p3cClassId, p3c.BracketId AS p3cBracketId, p3c.Note AS p3cNote, p3d.RowId AS p3dRowId, p3d.Name AS p3dName, p3d.Team AS p3dTeam, p3d.Age AS p3dAge, p3d.Weight AS p3dWeight, p3d.DivisionId AS p3dDivisionId, p3d.ClassId AS p3dClassId, p3d.BracketId AS p3dBracketId, p3d.Note AS p3dNote, p3e.RowId AS p3eRowId, p3e.Name AS p3eName, p3e.Team AS p3eTeam, p3e.Age AS p3eAge, p3e.Weight AS p3eWeight, p3e.DivisionId AS p3eDivisionId, p3e.ClassId AS p3eClassId, p3e.BracketId AS p3eBracketId, p3e.Note AS p3eNote, p3F.RowId AS p3FRowId, p3F.Name AS p3FName, p3F.Team AS p3FTeam, p3F.Age AS p3FAge, p3F.Weight AS p3FWeight, p3F.DivisionId AS p3FDivisionId, p3F.ClassId AS p3FClassId, p3F.BracketId AS p3FBracketId, p3F.Note AS p3FNote, p4a.RowId AS p4aRowId, p4a.Name AS p4aName, p4a.Team AS p4aTeam, p4a.Age AS p4aAge, p4a.Weight AS p4aWeight, p4a.DivisionId AS p4aDivisionId, p4a.ClassId AS p4aClassId, p4a.BracketId AS p4aBracketId, p4a.Note AS p4aNote, p4b.RowId AS p4bRowId, p4b.Name AS p4bName, p4b.Team AS p4bTeam, p4b.Age AS p4bAge, p4b.Weight AS p4bWeight, p4b.DivisionId AS p4bDivisionId, p4b.ClassId AS p4bClassId, p4b.BracketId AS p4bBracketId, p4b.Note AS p4bNote, p4c.RowId AS p4cRowId, p4c.Name AS p4cName, p4c.Team AS p4cTeam, p4c.Age AS p4cAge, p4c.Weight AS p4cWeight, p4c.DivisionId AS p4cDivisionId, p4c.ClassId AS p4cClassId, p4c.BracketId AS p4cBracketId, p4c.Note AS p4cNote, p4d.RowId AS p4dRowId, p4d.Name AS p4dName, p4d.Team AS p4dTeam, p4d.Age AS p4dAge, p4d.Weight AS p4dWeight, p4d.DivisionId AS p4dDivisionId, p4d.ClassId AS p4dClassId, p4d.BracketId AS p4dBracketId, p4d.Note AS p4dNote, p4e.RowId AS p4eRowId, p4e.Name AS p4eName, p4e.Team AS p4eTeam, p4e.Age AS p4eAge, p4e.Weight AS p4eWeight, p4e.DivisionId AS p4eDivisionId, p4e.ClassId AS p4eClassId, p4e.BracketId AS p4eBracketId, p4e.Note AS p4eNote, p4f.RowId AS p4fRowId, p4f.Name AS p4fName, p4f.Team AS p4fTeam, p4f.Age AS p4fAge, p4f.Weight AS p4fWeight, p4f.DivisionId AS p4fDivisionId, p4f.ClassId AS p4fClassId, p4f.BracketId AS p4fBracketId, p4f.Note AS p4fNote, p5a.RowId AS p5aRowId, p5a.Name AS p5aName, p5a.Team AS p5aTeam, p5a.Age AS p5aAge, p5a.Weight AS p5aWeight, p5a.DivisionId AS pf5aDivisionId, p5a.ClassId AS p5aClassicId, p5a.BracketId AS p5aBracketId, p5a.Note AS p5aNote, p5b.RowId AS p5bRowId, p5b.Name AS p5bName, p5b.Team AS p5bTeam, p5b.Age AS p5bAge, p5b.Weight AS p5bWeight, p5b.DivisionId AS p5bDivisionId, p5b.ClassId AS p5bClassId, p5b.BracketId AS p5bBracketId, p5b.Note AS p5bNote, p5c.RowId AS p5cRowId, p5c.Name AS p5cName, p5c.Team AS p5cTeam, p5c.Age AS p5cAge, p5c.Weight AS p5cWeight, p5c.DivisionId AS p5cDivisionId, p5c.ClassId AS p5cClasic, p5c.BracketId AS p5cBracketId, p5c.Note AS p5cNote, p5d.RowId AS p5dRowId, p5d.Name AS p5dName, p5d.Team AS p5dTeam, p5d.Age AS p5dAge, p5d.Weight AS p5dWeight, p5d.DivisionId AS p5dDivisionId, p5d.ClassId AS p5dClassId, p5d.BracketId AS p5dBracketId, p5d.Note AS p5dNote, p5e.RowId AS p5eRowId, p5e.Name AS p5eName, p5e.Team AS p5eTeam, p5e.Age AS p5eAge, p5e.Weight AS p5eWeight, p5e.DivisionId AS p5eDivisionId, p5e.ClassId AS p5eClassId, p5e.BracketId AS p5eBracketId, p5e.Note AS p5eNote, p5f.RowId AS p5fRowId, p5f.Name AS p5fName, p5f.Team AS p5fTeam, p5f.Age AS p5fAge, p5f.Weight AS p5fWeight, p5f.DivisionId AS p5fDivisionId, p5f.ClassId AS p5fClassId, p5f.BracketId AS p5fBracketId, p5f.Note AS p5fNote, p1ab.RowId AS p1aBRowId, p1ab.Name AS p1aBName, p1ab.Team AS p1aBTeam, p1ab.Age AS p1aBAge, p1ab.Weight AS p1aBWeight, p1ab.DivisionId AS p1aBDivisionId, p1ab.ClassId AS p1aBClassId, p1ab.BracketId AS p1aBBracketId, p1ab.Note AS p1aBNote, p1cd.RowId AS p1cdCDwId, p1cd.Name AS p1CDName, p1cd.Team AS p1CDTeam, p1cd.Age AS p1CDAge, p1cd.Weight AS p1CDWeight, p1cd.DivisionId AS p1CDDivisionId, p1cd.ClassId AS p1CDClassId, p1cd.BracketId AS p1CDBracketId, p1cd.Note AS p1CDNote, p1ef.RowId AS p1EFCDwId, p1ef.Name AS p1EFName, p1ef.Team AS p1EFTeam, p1ef.Age AS p1EFAge, p1ef.Weight AS p1EFWeight, p1ef.DivisionId AS p1EFDivisionId, p1ef.ClassId AS p1EFClassId, p1ef.BracketId AS p1EFBracketId, p1ef.Note AS p1EFNote, p2ab.RowId AS p2aBRowId, p2ab.Name AS p2aBName, p2ab.Team AS p2aBTeam, p2ab.Age AS p2aBAge, p2ab.Weight AS p2aBWeight, p2ab.DivisionId AS p2aBDivisionId, p2ab.ClassId AS p2aBClassId, p2ab.BracketId AS p2aBBracketId, p2ab.Note AS p2aBNote, p2cd.RowId AS p2cdCDwId, p2cd.Name AS p2CDName, p2cd.Team AS p2CDTeam, p2cd.Age AS p2CDAge, p2cd.Weight AS p2CDWeight, p2cd.DivisionId AS p2CDDivisionId, p2cd.ClassId AS p2CDClassId, p2cd.BracketId AS p2CDBracketId, p2cd.Note AS p2CDNote, p2ef.RowId AS p2EFCDwId, p2ef.Name AS p2EFName, p2ef.Team AS p2EFTeam, p2ef.Age AS p2EFAge, p2ef.Weight AS p2EFWeight, p2ef.DivisionId AS p2EFDivisionId, p2ef.ClassId AS p2EFClassId, p2ef.BracketId AS p2EFBracketId, p2ef.Note AS p2EFNote, p3ab.RowId AS p3aBRowId, p3ab.Name AS p3aBName, p3ab.Team AS p3aBTeam, p3ab.Age AS p3aBAge, p3ab.Weight AS p3aBWeight, p3ab.DivisionId AS p3aBDivisionId, p3ab.ClassId AS p3aBClassId, p3ab.BracketId AS p3aBBracketId, p3ab.Note AS p3aBNote, p3cd.RowId AS p3cdCDwId, p3cd.Name AS p3CDName, p3cd.Team AS p3CDTeam, p3cd.Age AS p3CDAge, p3cd.Weight AS p3CDWeight, p3cd.DivisionId AS p3CDDivisionId, p3cd.ClassId AS p3CDClassId, p3cd.BracketId AS p3CDBracketId, p3cd.Note AS p3CDNote, p3ef.RowId AS p3EFCDwId, p3ef.Name AS p3EFName, p3ef.Team AS p3EFTeam, p3ef.Age AS p3EFAge, p3ef.Weight AS p3EFWeight, p3ef.DivisionId AS p3EFDivisionId, p3ef.ClassId AS p3EFClassId, p3ef.BracketId AS p3EFBracketId, p3ef.Note AS p3EFNote, p4ab.RowId AS p4aBRowId, p4ab.Name AS p4aBName, p4ab.Team AS p4aBTeam, p4ab.Age AS p4aBAge, p4ab.Weight AS p4aBWeight, p4ab.DivisionId AS p4aBDivisionId, p4ab.ClassId AS p4aBClassId, p4ab.BracketId AS p4aBBracketId, p4ab.Note AS p4aBNote, p4cd.RowId AS p4cdCDwId, p4cd.Name AS p4CDName, p4cd.Team AS p4CDTeam, p4cd.Age AS p4CDAge, p4cd.Weight AS p4CDWeight, p4cd.DivisionId AS p4CDDivisionId, p4cd.ClassId AS p4CDClassId, p4cd.BracketId AS p4CDBracketId, p4cd.Note AS p4CDNote, p4ef.RowId AS p4EFCDwId, p4ef.Name AS p4EFName, p4ef.Team AS p4EFTeam, p4ef.Age AS p4EFAge, p4ef.Weight AS p4EFWeight, p4ef.DivisionId AS p4EFDivisionId, p4ef.ClassId AS p4EFClassId, p4ef.BracketId AS p4EFBracketId, p4ef.Note AS p4EFNote, p5ab.RowId AS p5aBRowId, p5ab.Name AS p5aBName, p5ab.Team AS p5aBTeam, p5ab.Age AS p5aBAge, p5ab.Weight AS p5aBWeight, p5ab.DivisionId AS p5aBDivisionId, p5ab.ClassId AS p5aBClassId, p5ab.BracketId AS p5aBBracketId, p5ab.Note AS p5aBNote, p5cd.RowId AS p5cdCDwId, p5cd.Name AS p5CDName, p5cd.Team AS p5CDTeam, p5cd.Age AS p5CDAge, p5cd.Weight AS p5CDWeight, p5cd.DivisionId AS p5CDDivisionId, p5cd.ClassId AS p5CDClassId, p5cd.BracketId AS p5CDBracketId, p5cd.Note AS p5CDNote, p5ef.RowId AS p5EFCDwId, p5ef.Name AS p5EFName, p5ef.Team AS p5EFTeam, p5ef.Age AS p5EFAge, p5ef.Weight AS p5EFWeight, p5ef.DivisionId AS p5EFDivisionId, p5ef.ClassId AS p5EFClassId, p5ef.BracketId AS p5EFBracketId, p5ef.Note AS p5EFNote, wt1ab.WinTypeCode as wt1abWinTypeCode, wt1cd.WinTypeCode as wt1cdWinTypeCode, wt1ef.WinTypeCode as wt1efWinTypeCode, wt2ab.WinTypeCode as wt2abWinTypeCode, wt2cd.WinTypeCode as wt2cdWinTypeCode, wt2ef.WinTypeCode as wt2efWinTypeCode, wt3ab.WinTypeCode as wt3abWinTypeCode, wt3cd.WinTypeCode as wt3cdWinTypeCode, wt3ef.WinTypeCode as wt3efWinTypeCode, wt4ab.WinTypeCode as wt4abWinTypeCode, wt4cd.WinTypeCode as wt4cdWinTypeCode, wt4ef.WinTypeCode as wt4efWinTypeCode, wt5ab.WinTypeCode as wt5abWinTypeCode, wt5cd.WinTypeCode as wt5cdWinTypeCode, wt5ef.WinTypeCode as wt5efWinTypeCode, wt1ab.WinTypeTeamPoints as wt1abWinTypeTeamPoints, wt1cd.WinTypeTeamPoints as wt1cdWinTypeTeamPoints, wt1ef.WinTypeTeamPoints as wt1efWinTypeTeamPoints, wt2ab.WinTypeTeamPoints as wt2abWinTypeTeamPoints, wt2cd.WinTypeTeamPoints as wt2cdWinTypeTeamPoints, wt2ef.WinTypeTeamPoints as wt2efWinTypeTeamPoints, wt3ab.WinTypeTeamPoints as wt3abWinTypeTeamPoints, wt3cd.WinTypeTeamPoints as wt3cdWinTypeTeamPoints, wt3ef.WinTypeTeamPoints as wt3efWinTypeTeamPoints, wt4ab.WinTypeTeamPoints as wt4abWinTypeTeamPoints, wt4cd.WinTypeTeamPoints as wt4cdWinTypeTeamPoints, wt4ef.WinTypeTeamPoints as wt4efWinTypeTeamPoints, wt5ab.WinTypeTeamPoints as wt5abWinTypeTeamPoints, wt5cd.WinTypeTeamPoints as wt5cdWinTypeTeamPoints, wt5ef.WinTypeTeamPoints as wt5efWinTypeTeamPoints FROM rrwt_brackets AS br INNER join rrwt_classes AS cl ON br.ClassRowId = cl.RowId INNER join rrwt_divisions AS dv ON br.DivRowId = dv.RowId LEFT OUTER join RRWT_Participants AS p1a ON br.R1APartRowId = p1a.RowId LEFT OUTER join RRWT_Participants AS p1b ON br.R1BPartRowId = p1b.RowId LEFT OUTER join RRWT_Participants AS p1c ON br.R1CPartRowId = p1c.RowId LEFT OUTER join RRWT_Participants AS p1d ON br.R1DPartRowId = p1d.RowId LEFT OUTER join RRWT_Participants AS p1e ON br.R1EPartRowId = p1e.RowId LEFT OUTER join RRWT_Participants AS p1f ON br.R1FPartRowId = p1f.RowId LEFT OUTER join RRWT_Participants AS p2a ON br.R2APartRowId = p2a.RowId LEFT OUTER join RRWT_Participants AS p2b ON br.R2BPartRowId = p2b.RowId LEFT OUTER join RRWT_Participants AS p2c ON br.R2CPartRowId = p2c.RowId LEFT OUTER join RRWT_Participants AS p2d ON br.R2DPartRowId = p2d.RowId LEFT OUTER join RRWT_Participants AS p2e ON br.R2EPartRowId = p2e.RowId LEFT OUTER join RRWT_Participants AS p2f ON br.R2FPartRowId = p2f.RowId LEFT OUTER join RRWT_Participants AS p3a ON br.R3APartRowId = p3a.RowId LEFT OUTER join RRWT_Participants AS p3b ON br.R3BPartRowId = p3b.RowId LEFT OUTER join RRWT_Participants AS p3c ON br.R3CPartRowId = p3c.RowId LEFT OUTER join RRWT_Participants AS p3d ON br.R3DPartRowId = p3d.RowId LEFT OUTER join RRWT_Participants AS p3e ON br.R3EPartRowId = p3e.RowId LEFT OUTER join RRWT_Participants AS p3f ON br.R3FPartRowId = p3f.RowId LEFT OUTER join RRWT_Participants AS p4a ON br.R4APartRowId = p4a.RowId LEFT OUTER join RRWT_Participants AS p4b ON br.R4BPartRowId = p4b.RowId LEFT OUTER join RRWT_Participants AS p4c ON br.R4CPartRowId = p4c.RowId LEFT OUTER join RRWT_Participants AS p4d ON br.R4DPartRowId = p4d.RowId LEFT OUTER join RRWT_Participants AS p4e ON br.R4EPartRowId = p4e.RowId LEFT OUTER join RRWT_Participants AS p4f ON br.R4FPartRowId = p4f.RowId LEFT OUTER join RRWT_Participants AS p5a ON br.R5APartRowId = p5a.RowId LEFT OUTER join RRWT_Participants AS p5b ON br.R5BPartRowId = p5b.RowId LEFT OUTER join RRWT_Participants AS p5c ON br.R5CPartRowId = p5c.RowId LEFT OUTER join RRWT_Participants AS p5d ON br.R5DPartRowId = p5d.RowId LEFT OUTER join RRWT_Participants AS p5e ON br.R5EPartRowId = p5e.RowId LEFT OUTER join RRWT_Participants AS p5f ON br.R5FPartRowId = p5f.RowId LEFT OUTER join RRWT_Participants AS p1ab ON br.R1ABWinPartRowId = p1ab.RowId LEFT OUTER join RRWT_Participants AS p1cd ON br.R1CDWinPartRowId = p1cd.RowId LEFT OUTER join RRWT_Participants AS p1ef ON br.R1EFWinPartRowId = p1ef.RowId LEFT OUTER join RRWT_Participants AS p2ab ON br.R2ABWinPartRowId = p2ab.RowId LEFT OUTER join RRWT_Participants AS p2cd ON br.R2CDWinPartRowId = p2cd.RowId LEFT OUTER join RRWT_Participants AS p2ef ON br.R2EFWinPartRowId = p2ef.RowId LEFT OUTER join RRWT_Participants AS p3ab ON br.R3ABWinPartRowId = p3ab.RowId LEFT OUTER join RRWT_Participants AS p3cd ON br.R3CDWinPartRowId = p3cd.RowId LEFT OUTER join RRWT_Participants AS p3ef ON br.R3EFWinPartRowId = p3ef.RowId LEFT OUTER join RRWT_Participants AS p4ab ON br.R4ABWinPartRowId = p4ab.RowId LEFT OUTER join RRWT_Participants AS p4cd ON br.R4CDWinPartRowId = p4cd.RowId LEFT OUTER join RRWT_Participants AS p4ef ON br.R4EFWinPartRowId = p4ef.RowId LEFT OUTER join RRWT_Participants AS p5ab ON br.R5ABWinPartRowId = p5ab.RowId LEFT OUTER join RRWT_Participants AS p5cd ON br.R5CDWinPartRowId = p5cd.RowId LEFT OUTER join RRWT_Participants AS p5ef ON br.R5EFWinPartRowId = p5ef.RowId left outer join rrwt_wintypes as wt1ab on br.R1ABWinTypeRowId = wt1ab.RowId left outer join rrwt_wintypes as wt1cd on br.R1cdWinTypeRowId = wt1cd.RowId left outer join rrwt_wintypes as wt1ef on br.R1efWinTypeRowId = wt1ef.RowId left outer join rrwt_wintypes as wt2ab on br.R2ABWinTypeRowId = wt2ab.RowId left outer join rrwt_wintypes as wt2cd on br.R2cdWinTypeRowId = wt2cd.RowId left outer join rrwt_wintypes as wt2ef on br.R2efWinTypeRowId = wt2ef.RowId left outer join rrwt_wintypes as wt3ab on br.R3ABWinTypeRowId = wt3ab.RowId left outer join rrwt_wintypes as wt3cd on br.R3cdWinTypeRowId = wt3cd.RowId left outer join rrwt_wintypes as wt3ef on br.R3efWinTypeRowId = wt3ef.RowId left outer join rrwt_wintypes as wt4ab on br.R4ABWinTypeRowId = wt4ab.RowId left outer join rrwt_wintypes as wt4cd on br.R4cdWinTypeRowId = wt4cd.RowId left outer join rrwt_wintypes as wt4ef on br.R4efWinTypeRowId = wt4ef.RowId left outer join rrwt_wintypes as wt5ab on br.R5ABWinTypeRowId = wt5ab.RowId left outer join rrwt_wintypes as wt5cd on br.R5cdWinTypeRowId = wt5cd.RowId left outer join rrwt_wintypes as wt5ef on br.R5efWinTypeRowId = wt5ef.RowId")

            'Create Indexs
            gConn.ExecuteDB("CREATE UNIQUE INDEX `` ON `rrwt_brackets` (`DivRowId`,	`ClassRowId`)")

            'Minimal populate initial records
            gConn.ExecuteDB("insert into rrwt_divisions (DivisionDesc) values ('Division 01')")
            gConn.ExecuteDB("insert into rrwt_wintypes (WinTypeCode,WinTypeTeamPoints) values ('Dec.',3)")
            gConn.ExecuteDB("insert into rrwt_system (TournyName,DBVersion) values ('Enter your tourny name here.'," & My.Application.Info.Version.Revision.ToString & ")")
            ' gConn.ExecuteDB("insert into rrwt_security (UserName,Password,FullName) values ('" & Login.UserName & "','" & txtPassword.Text & "','Demo User')")
            gConn.ExecuteDB("insert into rrwt_participants (Name) values ('Bye')")

        Catch ex As Exception
            clsErrorManager.WriteErrorLog("frmLogin", "CreateTables", "", ex, Login)

        Finally

        End Try
    End Sub

    Private Sub cmbDataFilename_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDataFilename.SelectedIndexChanged
        If cmbDataFilename.Text.Contains("Demo") Then
            Me.chkRefreshDemoData.Visible = True
        Else
            Me.chkRefreshDemoData.Visible = False
        End If
    End Sub

    Private Sub txtDataFolder_TextChanged(sender As Object, e As EventArgs) Handles txtDataFolder.TextChanged
        'Try
        '    cmbDataFilename.Items.Clear()
        '    Me.cmbDataFilename.Items.Add("RRWTDemo.db")
        '    Me.cmbDataFilename.Items.Add("RRWT.db")
        '    For Each foundFile As String In Directory.GetFiles(Me.txtDataFolder.Text, "*.db")
        '        If Path.GetFileName(foundFile) <> "RRWTDemo.db" And Path.GetFileName(foundFile) <> "RRWT.db" Then
        '            Me.cmbDataFilename.Items.Add(Path.GetFileName(foundFile))
        '        End If
        '    Next
        'Catch ex As Exception
        '    clsErrorManager.WriteErrorLog("frmLogin", "PasswordValid", "", ex, Login)

        'End Try

    End Sub
End Class