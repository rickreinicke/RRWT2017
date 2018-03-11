
Option Infer On

Imports System
Imports System.Threading.Tasks
Imports Dropbox.Api
Imports System.IO
Imports System.Text
Imports Dropbox.Api.Files

Friend Class frmToDropbox
    Shared Sub ConnectToDropbox()  '(ByVal args() As String)
        Try
            Dim task = System.Threading.Tasks.Task.Run(CType(AddressOf frmToDropbox.Run, Func(Of Task)))
            task.Wait()

        Catch ex As Exception
            clsErrorManager.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login, False, True)

        Finally

        End Try
    End Sub

    Private Shared Async Function Run() As Task
        'Private Sub run()
        Dim folderstring As String = ""
        Dim filestring As String = ""
        Try
            Using dbx = New DropboxClient("Q46R7wZ-PBsAAAAAAAACdINhyPAY4j5gmFugMTeORluPW1IwR4xbh2fsufe7EFiw")
                Dim full = Await dbx.Users.GetCurrentAccountAsync()
                'MsgBox(full.Name.DisplayName & vbCrLf & full.Email)
                'Dim list = Await dbx.Files.ListFolderAsync(String.Empty)
                'For Each item In list.Entries.Where(Function(i) i.IsFolder)
                '    folderstring = folderstring & item.Name & vbCrLf
                '    'Console.WriteLine("D  {0}/", item.Name)
                'Next item
                'MsgBox(folderstring)

                'For Each item In list.Entries.Where(Function(i) i.IsFile)
                '    filestring = filestring & item.Name & vbCrLf
                'Next item
                'MsgBox(filestring)

                Dim byteArray() As Byte = System.IO.File.ReadAllBytes(Login.DataFolder & "\Exported.pdf")
                Dim stream1 As New System.IO.MemoryStream(byteArray)
                Dim updated = Await dbx.Files.UploadAsync("/" & gConn.getValue("Select TournyName from rrwt_system limit 1").ToString.Trim & "/" & "All Divisions Brackets.pdf", WriteMode.Overwrite.Instance, body:=stream1)

                'Dim updated = Await dbx.Files.UploadAsync(folder & "/" & "Recover.log", WriteMode.Overwrite.Instance, body:=stream1)


            End Using

        Catch ex As Exception
            clsErrorManager.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login, False, True)

        Finally

        End Try
    End Function


    'Async Function Upload(ByVal dbx As DropboxClient, ByVal folder As String, ByVal file As String, ByVal content As String) As Task
    '    Try
    '        Using mem = New MemoryStream(Encoding.UTF8.GetBytes(content))
    '            Dim updated = Await dbx.Files.UploadAsync(folder & "\" & file, WriteMode.Overwrite.Instance, body:=mem)
    '            MsgBox("Version Uploaded: " & updated.Rev.ToString)
    '            Console.WriteLine("Saved {0}/{1} rev {2}", folder, file, updated.Rev)
    '        End Using

    '    Catch ex As Exception
    '        clsErrorManager.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login, False, True)

    '    Finally

    '    End Try
    'End Function


    Private Sub btnBeginUpload_Click(sender As Object, e As EventArgs) Handles btnBeginUpload.Click
        Try
            RunReports()
            ConnectToDropbox()
            Me.btnBeginUpload.Text = "Finished..."

        Catch ex As Exception
            clsErrorManager.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login, False, True)

        Finally

        End Try
    End Sub

    Private Sub RunReports()
        Dim myRecSel As String = "{rrwt_brackets_vw1.DivisionDesc}>''" '& Me.cmbDivision.Text & "'" '={?Divison}"
        frmReportViewer.ViewReport(Application.StartupPath & "\Reports\BracketSheets.rpt", myRecSel, "", True)
        'frmReportViewer.Show()

    End Sub

    Private Sub frmToDropbox_Load(sender As Object, e As EventArgs) Handles Me.Load

        With Me.cmbDivision
            .DataSource = gConn.QueryDBTable("Select RowId,DivisionDesc from rrwt_divisions order by RowId")
            .DisplayMember = "DivisionDesc"
            .ValueMember = "RowId"
            .DropDownStyle = ComboBoxStyle.DropDownList
        End With
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start(LinkLabel1.Text)
    End Sub
End Class