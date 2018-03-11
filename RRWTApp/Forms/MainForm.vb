Imports System.IO
Imports Dropbox.Api
Imports System.Text

Public Class MainForm




    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs)
        'frmOpen.Show()
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadStatusBar(Me.ssStatus)
        'lblAppPath.Text = Application.StartupPath
        lblAppPath.Text = "Data Location: " & Login.DataFullPath & "  App Start Path: " & Application.StartupPath
        Me.Text = "RRWT Version: " & My.Application.Info.Version.ToString  ' My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build & "." & My.Application.Info.Version.Revision
    End Sub

    'Private Sub LookupUsersToolStripMenuItem_Click(sender As Object, e As EventArgs)
    '    Dim sSql As String = ""
    '    sSql = "select * from rrwt_security order by username "
    '    frmLookup.sSql = sSql
    '    frmLookup.Tag = Me.Name & "-" & System.Reflection.MethodBase.GetCurrentMethod.Name
    '    frmLookup.Load_Grid()
    '    frmLookup.ShowDialog(Me)

    'End Sub


    Private Sub UserListToolStripMenuItem_Click(sender As Object, e As EventArgs)
        'Call RunCRViewer("UserList.rpt", True, False, False, 1, False, 1, 9999)

        'Dim objForm As New frmReportViewer
        'objForm.ViewReport("C:\MyDev\TestApp\testapp\test.rtp", , "@parameter1=test¶mter2=10")
        'frmReportViewer.ViewReport("C:\MyDev\RRWT\RRWTApp\Reports\UserList.rpt", )
        frmReportViewer.ViewReport(Application.StartupPath & "\Reports\UserList.rpt", )
        frmReportViewer.Show()

        'frmReportViewer.ViewReport(Application.StartupPath + "\Reports\UserList.rpt", )
        'frmReportViewer.Show()



        'Dim crReportDocument As New UserList
        'frmReportViewer.CRViewer1.ReportSource = crReportDocument
        'frmReportViewer.Show()
    End Sub

    Private Sub AssignParticipantsToClassesToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ManageParticipantClasses.Show()

    End Sub


    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BuildBracketsFromTheClassesToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PrintBoutSheetsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintBoutSheetsToolStripMenuItem.Click
        '#If DEBUG Then
        frmReportViewer.ViewReport(Application.StartupPath & "\Reports\BoutSheets.rpt", )
        ' {rrwt_brackets_vw.ClassRowId} = 9 and{rrwt_brackets_vw.DivRowId} = 90
        'frmReportViewer.ViewReport("BoutSheets.rpt", )
        '#Else
        '    msgbox (Application.StartupPath & "\Reports\BoutSheets.rpt")
        ' frmReportViewer.ViewReport(Application.StartupPath & "\Reports\BoutSheets.rpt", )
        '     frmReportViewer.ViewReport("BoutSheets.rpt", )
        '#End If


        frmReportViewer.Show()

    End Sub

    Private Sub AdministrationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdministrationToolStripMenuItem.Click

    End Sub

    Private Sub ManageParticipantsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManageParticipantsToolStripMenuItem.Click
        ManageParticipantClasses.Show()
    End Sub

    Private Sub BuildBracketsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuildBracketsToolStripMenuItem.Click
        frmBuildBracketsFromClasses.Show()
    End Sub

    Private Sub BracketManagementToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BracketManagementToolStripMenuItem.Click
        frmBracketMgr.Show()
    End Sub

    Private Sub ToolStripMenuItem2_Click_1(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        frmParticipantMNT.Show()
    End Sub

    Private Sub TournamentSetupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TournamentSetupToolStripMenuItem.Click
        frmTournySetup.ShowDialog()

    End Sub

    Private Sub PrintBracketSheetsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintBracketSheetsToolStripMenuItem.Click
        Dim myRecSel As String = "{rrwt_brackets_vw1.DivisionDesc}={?Divison}"
        frmReportViewer.ViewReport(Application.StartupPath & "\Reports\BracketSheets.rpt", myRecSel)
        frmReportViewer.Show()

    End Sub

    Private Sub TroubleshootErrorsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TroubleshootErrorsToolStripMenuItem.Click
        frmErrors.ShowDialog()



    End Sub

    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click
        System.Diagnostics.Process.Start("https://www.dropbox.com/s/b1pz0fbl172s3wl/RRWTDocumentation.pdf?dl=0")
        'frmHelp.Show()
    End Sub

    Private Sub UploadResultsToDropboxToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UploadResultsToDropboxToolStripMenuItem.Click
        'Dim DropboxClent As DropboxAppClient
        'DropboxClent = New DropboxAppClient("key", "secret")
        'Dim mem As New MemoryStream
        'mem = New MemoryStream(Encoding.UTF8.GetBytes("TESTING"))
        'DropboxClient.
        frmToDropbox.ShowDialog()

    End Sub

    Private Sub PrintParticipantListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintParticipantListToolStripMenuItem.Click
        Dim myRecSel As String = "" '"{rrwt_brackets_vw1.DivisionDesc}={?Divison}"
        frmReportViewer.ViewReport(Application.StartupPath & "\Reports\ParticipantList.rpt", myRecSel)
        frmReportViewer.Show()

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        frmTournySetup.Show()
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        frmParticipantMNT.Show()
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        ManageParticipantClasses.Show()
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        frmBuildBracketsFromClasses.Show()
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        frmBracketMgr.Show()

    End Sub

    Private Sub LinkLabel11_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel11.LinkClicked
        frmToDropbox.Show()
    End Sub
End Class
