Imports System.Reflection.Assembly
Imports System.Diagnostics.FileVersionInfo
Imports System.IO


Public Class clsErrorManager








    Public Shared Sub WriteErrorLog(ByVal CallRoutine As String, ByVal Proc_Name As String, ByVal Sql_Statement As String, ByVal Ex As Exception, ByVal Login As clsLoginManager, Optional ByVal bLogOnly2DB As Boolean = False, Optional ByVal bAlertUser As Boolean = True)

        Dim sMsg As String = ""
        Dim sUserMsg As String = ""
        Dim sSql As String
        Dim dMyDate As Date
        ' Dim dErrorNumber As Double
        Dim Result As Int16

        On Error Resume Next


        dMyDate = Now
        ' Capture Screen
        If bLogOnly2DB = False Then
            Call SaveScreen(dMyDate)
        End If


        sSql = "insert " & Login.ErrorTableName & " ("
        sSql = sSql & "servername,computername,username,date_time,app_name,app_rev,form_name,procedure_name,sql_statement,errnumber,comment"
        sSql = sSql & ") values("
        sSql = sSql & "'" & Login.CitrixServer & "',"
        sSql = sSql & "'" & Login.ComputerName & "',"
        sSql = sSql & "'" & Login.UserName & "',"
        sSql = sSql & "'" & dMyDate & "',"
        sSql = sSql & "'" & GetExecutingAssembly.GetName.Name() & "',"
        sSql = sSql & "'" & GetVersionInfo(GetExecutingAssembly.Location).ProductMajorPart() & "." & GetVersionInfo(GetExecutingAssembly.Location).ProductMinorPart() & "." & GetVersionInfo(GetExecutingAssembly.Location).ProductBuildPart() & "',"
        sSql = sSql & "'" & CallRoutine & "',"
        sSql = sSql & "'" & Proc_Name & "',"
        sSql = sSql & "'" & PrepareSQL(Sql_Statement) & "',"
        sSql = sSql & "'" & Ex.GetType.FullName & "',"
        ' rrr removed and changed to next line 02-09-07        sSql = sSql & "'" & PrepareSQL(Ex.Message) & "')"
        sSql = sSql & "'" & Left(PrepareSQL(Ex.Message) & PrepareSQL(Ex.StackTrace), 4000) & "')"
        'sSql = sSql & "'" & Left(PrepareSQL(Ex.StackTrace), 4000) & "')"

        gConn.ExecuteDB(sSql)

        If gConn.IsOpen = False Then
            Call MsgBox("It appears their is a database connection issue!" & vbCrLf & vbCrLf & "Please try logging out of " & Login.ExeName & " and then try logging in again!.", MsgBoxStyle.Exclamation, "Database connection Issue")
        End If

        If bLogOnly2DB = False Then
            ' Do a NT Message via Net Send - For Developer Warning
            sMsg = "An Error Has Occurred and Logged On:" & Now & vbCr
            sMsg = sMsg & "Error:   " & Replace(Ex.Message, Chr(13) & Chr(10), vbCr) & vbCr
            sMsg = sMsg & "User:    " & Login.UserName & vbCr
            sMsg = sMsg & "Computer:" & Login.ComputerName & vbCr
            sMsg = sMsg & "Citrix:  " & Login.CitrixServer & vbCr
            sMsg = sMsg & "Program: " & GetExecutingAssembly.GetName.Name() & vbCr
            sMsg = sMsg & "Version: " & GetVersionInfo(GetExecutingAssembly.Location).ProductMajorPart() & "." & GetVersionInfo(GetExecutingAssembly.Location).ProductMinorPart() & "." & GetVersionInfo(GetExecutingAssembly.Location).ProductBuildPart() & vbCr
            sMsg = sMsg & "FormName:" & CallRoutine & vbCr
            sMsg = sMsg & "ProcName:" & Proc_Name & vbCr
            sMsg = sMsg & "Error:   " & Ex.GetType.FullName & vbCr
            'sMsg = sMsg & "Error Source:   " & Replace(Ex.Message, Chr(13) & Chr(10), vbCr) & vbCr
            'rrr added 2-9-07
            sMsg = sMsg & "Error Stack Trace:   " & Replace(Ex.StackTrace, Chr(13) & Chr(10), vbCr) & vbCr
            sMsg = sMsg & "Sql Statement:   " & Replace(Sql_Statement, Chr(13) & Chr(10), vbCr) & vbCr

            ' Shell("net send reinicker " & Replace(sMsg, "'", "`"), AppWinStyle.Hide)
        End If
        If bAlertUser = True Then
            sUserMsg = "ERROR MESSAGE:     " & Ex.Message + vbCr + vbCr
            sUserMsg = sUserMsg + "ERROR MESSAGE FROM:" + Ex.Source + vbCr + vbCr
            sUserMsg = sUserMsg + "Click YES to close this popup, or Click NO for error details."
            Result = MsgBox(sUserMsg, MsgBoxStyle.YesNoCancel, "Alert, An Error Has Occurred.")
            If Result = System.Windows.Forms.DialogResult.No Then
                Result = MsgBox(sMsg, MsgBoxStyle.OkOnly, "Error Details.")
            End If
        End If
        Call addOutputLog(sMsg)

    End Sub
    Private Shared Sub SaveScreen(ByVal myDate As Date)
        Dim SC As New clsScreenCapture
        Dim sFileName As String = ""
        Try

            sFileName = Format(myDate, "yyyy-MM-dd-hh-mm-ss-") & Login.UserName.ToLower

            'grabs image of object handle (in this case, the form)
            ' Dim MyWindow As Image = SC.CaptureWindow(Me.Handle)

            'grabs image of entire desktop
            '  Dim MyDesktop As Image = SC.CaptureScreen



            ''captures entire desktop straight to file
            SC.CaptureScreenToFile(Login.ErrorImagePath & sFileName & ".jpg", Imaging.ImageFormat.Jpeg)

            ''captures image of object handle (in this case, the form) straight to file
            'SC.CaptureWindowToFile(Me.Handle, "c:\window2.jpg", Imaging.ImageFormat.Jpeg)

            ''returns bitmap of region of desktop by passing in a rectangle
            'Dim MyNewBitMap2 As Bitmap = SC.CaptureDeskTopRectangle(New Rectangle(Me.Location.X, Me.Location.Y, _
            '                             Me.Width, Me.Height), Me.Width, Me.Height)
            'MyNewBitMap.Save("c:\desktopregion.jpg", Imaging.ImageFormat.Jpeg)
            ''above example gets rectangle of form that it is called in, you can get 
            ''desktop by calling me.hide before the actual function call in order to 
            ''get the desktop that is in the bounds of the form (handy when using a 
            ''transparent Form or control in order to make a "viewfinder" for the capture...)
            ''You can pass in any rectangle you want, this was so you can see how
            ''it works...
        Catch

        End Try

    End Sub


    Public Shared Sub addOutputLog(ByVal sLogItem As String)
        'Commented out by rrr on 7-20-07.  Uncomment for debugging 

        'Dim sFileName As String = Login.ErrorLogPath & Login.ExeName & "-" & Format(Now, "yyyy-MM-dd") & ".log"
        Dim sFileName As String = Login.ErrorLogPath & Format(Now, "yyyy-MM-dd") & ".log"
        Dim sw As StreamWriter
        Try

            ' This text is added only once to the file.
            If File.Exists(sFileName) = False Then
                ' Create a file to write to.
                sw = File.CreateText(sFileName)
                sw.Flush()
                sw.Close()
            End If

            ' Add Line
            sw = File.AppendText(sFileName)

            sw.WriteLine(Format(Now, "MM/dd/yyyy hh:mm:ss") & ": " & sLogItem)
            sw.Flush()
            sw.Close()

        Catch ex As Exception

        End Try
    End Sub

End Class



