

Imports System.Reflection.Assembly
Imports System.Diagnostics.FileVersionInfo
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SQLite
'Imports TenTec.Windows.iGridLib

Module mdlRRWT
    Public Login As New clsLoginManagerRRWT
    Public sAppName As String
    Public gConn As New clsDataManager
    Public gGPConn As New clsDataManager
    Public bSQLTracking As Boolean = False
    Public gReg As New clsRegistryManager
    Public Const vbQuote = """"
    Public bFormLoadedFlag As Boolean = False
    Public sCallingFormName As String = ""
    Public gSecurity As New clsSecurityManager




    ' Lookup Screen Pass values
    'Public sPassString As String
    Public PassRecord_id As Double
    Public PassDate As Date
    Public PassTicketId As String
    Public PassString As String
    Public PassNumber As Double

    Public sRunUnattended As Boolean = False
    Public sRunLive As Boolean = False
    Public GapOrGP As String = "GAP"

    Public sCompany As String = "US"

    Public GPTestOrLive As String = "USI"

    'Public sCompany As String = "US"
    'Public sGPDBServer As String = "uselgp2015\gp"
    'Public sGPComputerName As String = "uselgp2015"
    'Public sGPDatabase As String = "usi"
    'Public sGPDatabaseUsername As String = "sa"
    'Public sGPDatabasePassword As String = "S3cur!ty"

    'Public sUSDBServer As String = "fresh2008"
    'Public sUSComputerName As String = "fresh2008"
    'Public sUSDatabase As String = "tech"
    'Public sUSDatabaseUsername As String = "sa"
    'Public sUSDatabasePassword As String = "admin"



    'Public sSSRSLocation As String = "uselgp2015/ReportServer_GP"
    'Public sAPInvoiceIntegrationLocation = "N:\McGladrey\APInvoiceIntegrationGP2015"
    'Public sARInvoiceIntegrationLocation = "N:\McGladrey\ARInvoiceIntegrationGP2015"
    'Public sTexAPIntegrationLocation = "N:\McGladrey\TexAPIntegrationGP2015"
    'Public sTexARIntegrationLocation = "N:\McGladrey\TexARIntegrationGP2015"
    'Public sTexCustomerIntegrationLocation = "N:\McGladrey\TexCustomerIntegrationGP2015"



    Public Const usRequiredBackColor = &HFFC0C0

    ' Forms Collection
    Public Forms As New clsFormsCollection()



    Public Function PrepareSQL(ByVal msSQL As Object) As String
        Dim sSQL As String = ""

        Try
            'sSQL = CheckDBNull(sSQL, enumObjectType.StrType)
            sSQL = CheckDBNull(msSQL, enumObjectType.StrType) 'fixed this 11/30/09 by rrr.
            If sSQL.Length > 0 Then
                ' Replace Quotes
                sSQL = Replace(sSQL, "'", "''")
                sSQL = Replace(sSQL, Chr(34), "")
                ' Carriage Return & line feeds
                sSQL = Replace(sSQL, Chr(13) & Chr(10), "' + char(13) + char(10) + '")
                If Strings.InStrRev(sSQL, "' + char(13) + char(10) + '", , 1) + 26 = sSQL.Length Then
                    sSQL = sSQL.Substring(0, sSQL.Length - 27)
                End If

            End If
            Return sSQL

        Catch ex As Exception
            Return sSQL

        End Try


    End Function
    Private Function myAppAlreadyRunning() As Boolean
        Dim x As Integer = 0
        Dim myProcesses As Process()
        Dim myProcess As Process
        Try
            myAppAlreadyRunning = False
            myProcesses = Diagnostics.Process.GetProcessesByName(Diagnostics.Process.GetCurrentProcess.ProcessName)
            For Each myProcess In myProcesses
                If myProcess.SessionId = Diagnostics.Process.GetCurrentProcess.SessionId Then
                    x = x + 1
                End If
            Next
            If x > 1 Then
                myAppAlreadyRunning = True
            End If
        Catch ex As Exception
            clsErrorManager.WriteErrorLog("mdlGPDEX", "myAppAlreadyRunning", "", ex, Login)
        End Try
    End Function

    Public Sub Main()
        ' Display the login dialog.
        Try
            ' rrr removed so if it would happen to fail and get stuck open, the next day it could run succeffully. 2-12-13
            'If myAppAlreadyRunning() Then
            'If MsgBox("Warning," & Diagnostics.Process.GetCurrentProcess.ProcessName.ToString & " is already running!" & vbCr & vbLf & "Do you really want to start another copy of this program?", MsgBoxStyle.YesNoCancel, "Duplicate Program Warning!") = MsgBoxResult.No Then
            'Exit Sub
            'End If
            'End If
            sAppName = GetExecutingAssembly.GetName.Name()


            Login.ExeName = "RRWT"
            Login.ErrorTableName = "RRWT_errors"
            Login.ErrorLogPath = Application.StartupPath & "\Errors\"
            Login.ErrorImagePath = Application.StartupPath & "\Errors\"

            ' Get Citrix server name and computer name
            Login.ComputerName = "" & System.Environment.GetEnvironmentVariable("CLIENTNAME")
            If Login.ComputerName.Length = 0 Then
                ' Not citrix session
                Login.CitrixServer = "CitrixNone"
                Login.ComputerName = System.Environment.MachineName
            Else
                ' Citrix session
                Login.CitrixServer = System.Environment.MachineName
            End If

            ' Network Name
            Login.NetworkLogin = System.Environment.UserName





            ' Load Login Screen
            'Dim dlg As New frmLogin
            If frmLogin.ShowDialog() = DialogResult.OK Then
                ' The user correctly logged in.
                ' Display the menu form.
                MainForm.ShowDialog()
            Else
                End
            End If



        Catch ex As Exception
            clsErrorManager.WriteErrorLog("mdlGPDEX", "Main()", "", ex, Login)
        End Try
    End Sub
    Public Sub SaveFormSizeLocation(ByVal tmpForm As Form)
        If tmpForm.WindowState <> FormWindowState.Minimized Then ' RRR to avoid saving location of minimized forms
            ' Save - Left
            gReg.SaveSetting(Login, sAppName, tmpForm.Name, "Form-Left", tmpForm.Left)
            ' Save - Top
            gReg.SaveSetting(Login, sAppName, tmpForm.Name, "Form-Top", tmpForm.Top)
            ' Save - Width
            gReg.SaveSetting(Login, sAppName, tmpForm.Name, "Form-Width", tmpForm.Width)
            ' Save - Height
            gReg.SaveSetting(Login, sAppName, tmpForm.Name, "Form-Height", tmpForm.Height)
        End If
    End Sub
    Public Sub SetMinSize(ByVal tmpForm As Form)
        tmpForm.MinimumSize = New Size(tmpForm.Width, tmpForm.Height)
    End Sub
    Public Sub GetFormSizeLocation(ByVal tmpForm As Form)
        ' Get - Left
        tmpForm.Left = CInt(gReg.GetSetting(Login, sAppName, tmpForm.Name, "Form-Left", tmpForm.Left))
        ' Save - Top
        tmpForm.Top = CInt(gReg.GetSetting(Login, sAppName, tmpForm.Name, "Form-Top", tmpForm.Top))
        ' Save - Width
        tmpForm.Width = CInt(gReg.GetSetting(Login, sAppName, tmpForm.Name, "Form-Width", tmpForm.Width))
        ' Save - Height
        tmpForm.Height = CInt(gReg.GetSetting(Login, sAppName, tmpForm.Name, "Form-Height", tmpForm.Height))
        tmpForm.WindowState = FormWindowState.Normal ' incase form is closed while minimized.
    End Sub



    ' Validate thefield entry
    '    '------------------------
    Public Function isValidEntry(ByVal Value As Object, ByVal sType As String, ByVal sFieldName As String, ByVal sErrorHeader As String, ByVal bReportError As Boolean, Optional ByVal iMinLength As Integer = 0, Optional ByVal iMaxLength As Integer = 0, Optional ByVal sValidListItem As String = "", Optional ByVal bUseMinValue As Boolean = False, Optional ByVal dMinNumericValue As Double = 0) As Boolean
        Try

            Dim sError As String
            Dim iSlashes As Integer
            Dim bValidDate As Boolean

            sError = ""

            isValidEntry = True
            ' Null Value
            If Value Is Nothing Then
                sError = addErrorLine(sError, "You must enter a value in the '" & sFieldName & "' field!")
            Else

                ' Min Length
                If Len(Value) < iMinLength Then
                    If Len(Value) = 0 Then
                        sError = addErrorLine(sError, "You must enter a value in the '" & sFieldName & "' field!")
                    Else
                        sError = addErrorLine(sError, "You have entered a value in the '" & sFieldName & "' field, which is not long enough!")
                    End If
                End If
            End If
            ' Max Length
            If Len(Value) > iMaxLength And iMaxLength <> 0 Then
                sError = addErrorLine(sError, "You have entered a value in the '" & sFieldName & "' field, which is to long!")
            End If

            ' Check List Item
            If Len(sValidListItem) > 0 Then
                If InStr(1, sValidListItem, Value, 1) = 0 Then
                    sError = addErrorLine(sError, "You have entered a value in the '" & sFieldName & "' field, which was not part of the list!")
                End If
            End If


            'Types
            '-----

            ' Numeric value
            If sType = "Numeric" Or sType = "Integer" Then
                If IsNumeric(Value) = False Then
                    sError = addErrorLine(sError, "The value in the '" & sFieldName & "' field, must be a number!")
                Else
                    If bUseMinValue = True And dMinNumericValue > CDbl(Value) Then
                        sError = addErrorLine(sError, "The value in the '" & sFieldName & "' field, must be greater than " & CStr(dMinNumericValue) & " !")
                    End If
                End If
            End If

            If sType = "Integer" Then
                If InStr(1, CStr(Value), ".", 1) > 0 Then
                    sError = addErrorLine(sError, "The value in the '" & sFieldName & "' field, must be an integer!")
                End If
            End If
            ' Date Value
            bValidDate = False
            If sType = "Date" Then
                If IsDate(Value) = False Then
                    iSlashes = InStr(1, Value, "/", 1)
                    If iSlashes = 0 Then
                        ' Format 010105
                        If Len(Value) = 6 Then
                            Value = Left(Value, 2) & "/" & Mid(Value, 3, 2) & "/" & Right(Value, 2)
                        End If
                        ' Format 01012005
                        If Len(Value) = 8 Then
                            Value = Left(Value, 2) & "/" & Mid(Value, 3, 2) & "/" & Right(Value, 4)
                        End If
                        If IsDate(Value) = True Then
                            bValidDate = True
                        End If
                    End If
                Else
                    bValidDate = True
                End If
                ' Invalid date
                If bValidDate = False Then
                    sError = addErrorLine(sError, "The value in the " & sFieldName & " field, must be a Date!")
                End If
            End If



            ' Report Any errors
            If Len(sError) > 0 Then
                If bReportError = True Then
                    Call MsgBox(sError, vbExclamation, sErrorHeader)
                    isValidEntry = False
                End If
            Else
                isValidEntry = True
            End If

        Catch Ex As Exception
            clsErrorManager.WriteErrorLog("mdlGPDEX", "isValidEntry", "", Ex, Login)
        End Try
    End Function



    ' Multiple Error Lines - validate section
    '----------------------------------------
    Private Function addErrorLine(ByVal sErrorLine As String, ByVal sError As String) As String
        Try

            addErrorLine = sErrorLine
            If Len(sErrorLine) > 0 Then
                addErrorLine = addErrorLine & Chr(13) & Chr(10) & sError
            Else
                addErrorLine = sError
            End If
            Return addErrorLine
        Catch ex As Exception
            Return sErrorLine
            clsErrorManager.WriteErrorLog("mdlGPDEX", "addErrorLine", "", ex, Login)
        End Try

    End Function
    Public Function fnd4sql(ByVal myDateString As String, Optional ByVal myFormat As String = "MM/dd/yyyy") As String
        'Examples
        'd Date
        'f Full
        'g General
        'm month/day
        's sortable
        't time
        'u universal
        'y year/month
        ' MM/dd/yyyy hh:mm:ss"
        Dim dt As DateTime
        If Date.TryParse(myDateString, dt) Then
            dt = Date.Parse(myDateString)
            fnd4sql = Chr(39) & dt.ToString(myFormat) & Chr(39)
        Else
            fnd4sql = "Null"
        End If
    End Function
    Public Function HandleNull(ByVal myValue As Object, ByVal sDelimit As String, Optional ByVal bBoolean As Boolean = False) As String
        HandleNull = ""
        Try
            If IsDBNull(myValue) Then
                HandleNull = "Null"
            Else
                If bBoolean = True Then
                    HandleNull = IIf(myValue = True, 1, 0) & sDelimit
                Else
                    HandleNull = sDelimit & Trim(PrepareSQL(Trim(myValue))) & sDelimit
                End If

            End If
        Catch ex As Exception
            clsErrorManager.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login, False, True)
        End Try
    End Function
    Public Function fn(ByVal myNumber As Object) As Decimal
        Try
            If Not IsNumeric(myNumber) Or IsDBNull(myNumber) Then
                fn = 0
            Else
                fn = CDec(myNumber)
            End If
        Catch ex As Exception
            clsErrorManager.WriteErrorLog("mdlGPDEX", "fn", "", ex, Login)
        End Try
    End Function
    Public Function getActiveControl(ByVal oControl As Control) As String
        Dim sName As String = ""

        Try
            sName = oControl.Name

            ' Get Tab Name
            If TypeOf (oControl) Is TabControl Then
                Dim oTab As TabControl
                oTab = oControl
                sName = oTab.SelectedTab.Text.ToUpper() & " tab"
            End If
            ' Get Grid Name
            'If TypeOf (oControl) Is iGrid Then
            '    Dim oGrid As iGrid
            '    oGrid = oControl
            '    If oGrid.Tag Is Nothing Then
            '    Else

            '        sName = oGrid.Tag & " Grid"
            '    End If

            'End If


            Return sName

        Catch ex As Exception

            Return ""
        End Try
    End Function

    Public Sub TextSelected(ByVal oControl As Control)

        Dim i As Integer
        Try


            ' TextBoxes
            If TypeOf (oControl) Is TextBox Then
                Dim oMyTextBox As TextBox
                oMyTextBox = CType(oControl, TextBox)
                i = oMyTextBox.Text.Length
                oMyTextBox.SelectionStart = 0
                oMyTextBox.SelectionLength = i
            End If

            ' MaskedTextBoxes
            If TypeOf (oControl) Is MaskedTextBox Then
                Dim oMyTextBox As MaskedTextBox
                oMyTextBox = CType(oControl, MaskedTextBox)
                i = oMyTextBox.Text.Length
                oMyTextBox.SelectionStart = 0
                oMyTextBox.SelectionLength = i
            End If

        Catch ex As Exception

        End Try
    End Sub
    Public Sub LoadStatusBar(ByVal ssTemp As StatusStrip)
        Try
            ssTemp.Items(0).Text = Login.DataFilename
            If Login.DataFilename.Contains("RRWTDemo") Then
                ssTemp.Items(0).BackColor = Color.Yellow
            Else
                ssTemp.Items(0).BackColor = Color.WhiteSmoke
            End If
            ssTemp.Items(1).BackColor = Color.WhiteSmoke
            ssTemp.Items(2).BackColor = Color.WhiteSmoke
            ssTemp.Items(3).BackColor = Color.WhiteSmoke
            ssTemp.Items(4).BackColor = Color.WhiteSmoke
            ssTemp.Items(5).BackColor = Color.WhiteSmoke

            ssTemp.Items(0).ForeColor = Color.Black
            ssTemp.Items(1).ForeColor = Color.Black
            ssTemp.Items(2).ForeColor = Color.Black
            ssTemp.Items(3).ForeColor = Color.Black
            ssTemp.Items(4).ForeColor = Color.Black
            ssTemp.Items(5).ForeColor = Color.Black

            ssTemp.Items(1).Text = "" ' Login.DataFilename
            ssTemp.Items(2).Text = Login.DataFolder
            ssTemp.Items(3).Text = "" '"F1 = Help"
            ssTemp.Items(4).Text = Format(Now, "MM/dd/yyyy")
            'ssTemp.Items(5).Text = "" 'Login.DataFilename '""
            ssTemp.Items(5).Text = Format(Now, "hh:mm tt")
        Catch ex As Exception
            clsErrorManager.WriteErrorLog("mdlGPDEX", "LoadStatusBar", "", ex, Login)
        End Try
    End Sub

    Public Function isNotValidDate(ByVal myTextbox As TextBox) As Boolean

        Dim WorkDate As String

        isNotValidDate = False
        WorkDate = myTextbox.Text.ToString

        If IsDate(WorkDate) Then
            If CDate(WorkDate) = CDate("12/31/1919") Then
                WorkDate = "12/31/2010"
            End If
        End If


        ' skip if no date entered
        If Len(Trim(WorkDate)) = 0 Then
            Exit Function
        End If

        ' return if valid date entered  with /'s
        If IsDate(WorkDate) Then
            If Year(CDate(WorkDate)) > 1753 And Year(CDate(WorkDate)) <= 9999 Then
                myTextbox.Text = Format(CDate(WorkDate), "MM/dd/yyyy")
                Exit Function
            End If
        End If


        '' return if valid date in format of 1 or 12 indicating only the day, use system month and year.
        If Len(WorkDate) = 1 Or Len(WorkDate) = 2 Then
            WorkDate = Now.Month.ToString.ToString & "/" & WorkDate & "/" & Right(Now.Year.ToString, 2)
            If IsDate(WorkDate) Then
                If Year(CDate(WorkDate)) > 1753 And Year(CDate(WorkDate)) <= 9999 Then
                    myTextbox.Text = Format(CDate(WorkDate), "MM/dd/yyyy")
                    Exit Function
                End If
            End If
        End If



        ' return if valid date in format of 120303
        If Len(WorkDate) = 6 Then
            WorkDate = Left(WorkDate, 2) & "/" & Mid(WorkDate, 3, 2) & "/" & Mid(WorkDate, 5, 2)
            If IsDate(WorkDate) Then
                If Year(CDate(WorkDate)) > 1753 And Year(CDate(WorkDate)) <= 9999 Then
                    myTextbox.Text = Format(CDate(WorkDate), "MM/dd/yyyy")
                    Exit Function
                End If
            End If
        End If


        ' return if valid date in format of 12032003
        If Len(WorkDate) = 8 Then
            WorkDate = Left(WorkDate, 2) & "/" & Mid(WorkDate, 3, 2) & "/" & Mid(WorkDate, 5, 4)
            If IsDate(WorkDate) Then
                If Year(CDate(WorkDate)) > 1753 And Year(CDate(WorkDate)) <= 9999 Then
                    myTextbox.Text = Format(CDate(WorkDate), "MM/dd/yyyy")
                    Exit Function
                End If
            End If
        End If



        MsgBox("This is not a valid date: " & myTextbox.Name, vbCritical, "Invalid Date!")
        isNotValidDate = True


    End Function
    Public Function isNotValidDate(ByVal myTextbox As ComboBox) As Boolean

        Dim WorkDate As String

        isNotValidDate = False
        WorkDate = myTextbox.Text.ToString




        ' skip if no date entered
        If Len(Trim(WorkDate)) = 0 Then
            Exit Function
        End If



        ' return if valid date entered  with /'s
        If IsDate(WorkDate) Then
            If Year(CDate(WorkDate)) > 1753 And Year(CDate(WorkDate)) <= 9999 Then
                myTextbox.Text = Format(CDate(WorkDate), "MM/dd/yyyy")
                Exit Function
            End If
        End If


        '' return if valid date in format of 1 or 12 indicating only the day, use system month and year.
        If Len(WorkDate) = 1 Or Len(WorkDate) = 2 Then
            WorkDate = Now.Month.ToString.ToString & "/" & WorkDate & "/" & Right(Now.Year.ToString, 2)
            If IsDate(WorkDate) Then
                If Year(CDate(WorkDate)) > 1753 And Year(CDate(WorkDate)) <= 9999 Then
                    myTextbox.Text = Format(CDate(WorkDate), "MM/dd/yyyy")
                    Exit Function
                End If
            End If
        End If



        ' return if valid date in format of 120303
        If Len(WorkDate) = 6 Then
            WorkDate = Left(WorkDate, 2) & "/" & Mid(WorkDate, 3, 2) & "/" & Mid(WorkDate, 5, 2)
            If IsDate(WorkDate) Then
                If Year(CDate(WorkDate)) > 1753 And Year(CDate(WorkDate)) <= 9999 Then
                    myTextbox.Text = Format(CDate(WorkDate), "MM/dd/yyyy")
                    Exit Function
                End If
            End If
        End If


        ' return if valid date in format of 12032003
        If Len(WorkDate) = 8 Then
            WorkDate = Left(WorkDate, 2) & "/" & Mid(WorkDate, 3, 2) & "/" & Mid(WorkDate, 5, 4)
            If IsDate(WorkDate) Then
                If Year(CDate(WorkDate)) > 1753 And Year(CDate(WorkDate)) <= 9999 Then
                    myTextbox.Text = Format(CDate(WorkDate), "MM/dd/yyyy")
                    Exit Function
                End If
            End If
        End If



        MsgBox("This is not a valid date: " & myTextbox.Name, vbCritical, "Invalid Date!")
        isNotValidDate = True


    End Function

    Public Function DBdate2TextBox(ByVal myDate As String) As String
        If String.IsNullOrEmpty(myDate) Then
            DBdate2TextBox = ""
        Else
            DBdate2TextBox = "" & Format(CDate(myDate), "MM/dd/yyyy").ToString & ""
        End If

    End Function

    Public Function TextBoxDate2DB(ByVal myDate As Object) As String
        'Try
        ' If String.IsNullOrEmpty(myDate) Then 'Or myDate = Nothing Then
        If IsDBNull(myDate) Then
            TextBoxDate2DB = " null "
        Else
            myDate.ToString.Trim()
            If myDate = "12/31/1919 12:00:00 AM" Then
                TextBoxDate2DB = " null "
            Else
                TextBoxDate2DB = "'" & Format(CDate(myDate), "MM/dd/yyyy") & "'"
            End If
        End If
        'Catch ex As Exception
        '    clsErrorManager.WriteErrorLog("mdlGPDEX", System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login)
        'Finally
        'End Try

    End Function

    Public Function TextBoxDate2UnixDB(ByVal myDate As String) As String
        If String.IsNullOrEmpty(myDate) Then
            TextBoxDate2UnixDB = " null "
        Else
            TextBoxDate2UnixDB = "'" & Format(CDate(myDate), "yyyy-MM-dd") & "'"
        End If
    End Function

    Public Function CreateAppend2FlatFile(ByVal myFileName As String, ByVal myLine As String) As Boolean
        '        Dim sFileName As String = Application.StartupPath & "\USNotes-" & Format(Now, "yyyy-MM-dd") & ".log"
        Dim sw As StreamWriter
        clsErrorManager.addOutputLog("SCreateAppend2FlatFile")

        Try
            CreateAppend2FlatFile = True
            ' This text is added only once to the file.
            If File.Exists(myFileName) = False Then
                ' Create a file to write to.
                sw = File.CreateText(myFileName)
                sw.Flush()
                sw.Close()
            End If

            ' Add Line
            sw = File.AppendText(myFileName)

            sw.WriteLine(myLine)
            sw.Flush()
            sw.Close()
            clsErrorManager.addOutputLog("ECreateAppend2FlatFile")

        Catch ex As Exception
            CreateAppend2FlatFile = False
            clsErrorManager.WriteErrorLog("mdlGPDEX", "CreateAppend2FlatFile", "", ex, Login)
        End Try
    End Function
    Public Function FileDelete(ByVal sFilePathName As String) As String
        Dim sError As String = ""
        Try
            File.Delete(sFilePathName)
            Return sError
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function FileMove(ByVal sFilePathName As String, ByVal sNewFilePathName As String) As String
        Dim sError As String = ""
        Try
            File.Move(sFilePathName, sNewFilePathName)
            Return sError
        Catch ex As Exception
            Return ex.Message

        End Try
    End Function
    Public Sub SetFieldColors(ByRef myForm As Form)

        Dim zIndex As Integer = 0, zControl As Control = Nothing
        Dim zListOfControlsThatNeedTheirChildrenChecked As New ArrayList
        '   Form1 is a control that needs its children checked, so add it to the list:
        zListOfControlsThatNeedTheirChildrenChecked.Add(myForm)


        Do
            zControl = zListOfControlsThatNeedTheirChildrenChecked(zIndex)

            For Each zChildControl As Control In zControl.Controls
                If zChildControl.Controls.Count > 0 Then
                    '   Add the childcontrol to the list of controls to check for children if it has children
                    zListOfControlsThatNeedTheirChildrenChecked.Add(zChildControl)
                End If

                '   Do the check 
                If TypeOf zChildControl Is TextBox Then
                    If zChildControl.GetType.Name = "TextBox" Then
                        If zChildControl.Enabled = True Then
                            If zChildControl.Enabled = True Then
                                zChildControl.BackColor = Color.White
                            Else
                                zChildControl.BackColor = Color.WhiteSmoke
                            End If
                        End If
                    End If
                End If
            Next

            zIndex += 1
        Loop Until zIndex = zListOfControlsThatNeedTheirChildrenChecked.Count

    End Sub


    Private Function CanConnectToSite(ByVal myURL As String) As Boolean

        Dim url As New System.Uri(myURL)
        Dim request As System.Net.WebRequest = System.Net.WebRequest.Create(url)
        Dim response As System.Net.WebResponse = request.GetResponse()

        Try
            response.Close()
            request = Nothing : Return True
        Catch ex As Exception
            request = Nothing : Return False
        End Try
    End Function

    Public Function ShowCreditAlert(ByVal myCustomerNo As Double) As Boolean
        Dim sSql As String = ""
        ShowCreditAlert = False
        Try
            sSql = " select count(operator) from CreditNotes where Customer = " & myCustomerNo & " and ChemWhseAlert = 1 "
            If gConn.getValue(sSql) > 0 Then
                ShowCreditAlert = True
            End If

        Catch ex As Exception
            clsErrorManager.WriteErrorLog("mdlGPDEX", System.Reflection.MethodBase.GetCurrentMethod.Name, sSql, ex, Login)
        Finally
        End Try


    End Function


    '' ********** New
    'Public Sub LoadGridColumns(ByVal dgvGrid As DataGridView, ByVal sGridColumns As String, Optional ByVal bColumnsReadOnly As Boolean = False)
    '    Dim sColumns As String()
    '    Dim i As Integer
    '    Dim j As Integer = 0
    '    Try
    '        dgvGrid.Columns.Clear()
    '        dgvGrid.Rows.Clear()

    '        sColumns = sGridColumns.Split("|")
    '        For i = 0 To sColumns.Length - 1
    '            j = j + 1
    '            Dim sParameters As String()
    '            sParameters = sColumns(i).Split(",")

    '            Select Case sParameters(0)
    '                Case "ComboBox"
    '                    Dim sItems As String()
    '                    sItems = sParameters(2).Split("~")
    '                    If bColumnsReadOnly = True Then
    '                        Call addDGVCombobox(dgvGrid, sParameters(1), sItems, sParameters(3), sParameters(4))
    '                    Else
    '                        Call addDGVCombobox(dgvGrid, sParameters(1), sItems, sParameters(3), sParameters(4))
    '                    End If
    '                Case "CheckBox"
    '                    If bColumnsReadOnly = True Then
    '                        Call addDGVCheckBox(dgvGrid, sParameters(1), True, sParameters(3), sParameters(4))
    '                    Else
    '                        Call addDGVCheckBox(dgvGrid, sParameters(1), sParameters(2), sParameters(3), sParameters(4))
    '                    End If

    '                Case "TextBox"
    '                    If bColumnsReadOnly = True Then
    '                        Call addDGVTextBox(dgvGrid, sParameters(1), True, Convert.ToBoolean(sParameters(3)), sParameters(4), sParameters(5), sParameters(6))
    '                    Else
    '                        Call addDGVTextBox(dgvGrid, sParameters(1), Convert.ToBoolean(sParameters(2)), Convert.ToBoolean(sParameters(3)), sParameters(4), sParameters(5), sParameters(6))
    '                    End If
    '                Case "Image"
    '                    If bColumnsReadOnly = True Then
    '                        Call addDGVImage(dgvGrid, sParameters(1), True, Convert.ToBoolean(sParameters(3)), sParameters(4), sParameters(5))
    '                    Else
    '                        Call addDGVImage(dgvGrid, sParameters(1), Convert.ToBoolean(sParameters(2)), Convert.ToBoolean(sParameters(3)), sParameters(4), sParameters(5))
    '                    End If
    '                Case "ProductCombobox"
    '                    If bColumnsReadOnly = True Then
    '                        Call addDGVProductCombobox(dgvGrid, sParameters(1), sParameters(2), sParameters(3))
    '                    Else
    '                        Call addDGVProductCombobox(dgvGrid, sParameters(1), sParameters(2), sParameters(3))
    '                    End If
    '                Case "DriverCombobox"
    '                    If bColumnsReadOnly = True Then
    '                        Call addDGVDriverCombobox(dgvGrid, sParameters(1), sParameters(2), sParameters(3))
    '                    Else
    '                        Call addDGVDriverCombobox(dgvGrid, sParameters(1), sParameters(2), sParameters(3))
    '                    End If
    '                Case "TractorCombobox"
    '                    If bColumnsReadOnly = True Then
    '                        Call addDGVTractorCombobox(dgvGrid, sParameters(1), sParameters(2), sParameters(3))
    '                    Else
    '                        Call addDGVTractorCombobox(dgvGrid, sParameters(1), sParameters(2), sParameters(3))
    '                    End If
    '                Case "TrailerCombobox"
    '                    If bColumnsReadOnly = True Then
    '                        Call addDGVTrailerCombobox(dgvGrid, sParameters(1), sParameters(2), sParameters(3))
    '                    Else
    '                        Call addDGVTrailerCombobox(dgvGrid, sParameters(1), sParameters(2), sParameters(3))
    '                    End If
    '            End Select

    '        Next i
    '        j = j
    '    Catch ex As Exception
    '        clsErrorManager.WriteErrorLog("frmLoadEntry", "LoadGridColumns", "", ex, Login, False, True)
    '    End Try

    'End Sub
    'Public Sub addDGVCombobox(ByVal dgv As DataGridView, ByVal sName As String, ByVal aItems() As String, ByVal iWidth As Integer, ByVal bFrozen As Boolean)
    '    Dim col As New DataGridViewComboBoxColumn()
    '    Try
    '        col.HeaderText = sName
    '        col.Name = sName
    '        col.ReadOnly = False
    '        col.Visible = True
    '        col.Frozen = bFrozen
    '        col.Width = iWidth
    '        Dim i As Integer
    '        ' Add items
    '        For i = 0 To aItems.Length - 1
    '            col.Items.Add(aItems(i))
    '        Next
    '        col.SortMode = DataGridViewColumnSortMode.NotSortable
    '        dgv.Columns.Add(col)
    '    Catch ex As Exception
    '        clsErrorManager.WriteErrorLog("mdlMaint", "addDGCComboBox", "", ex, Login, False, True)
    '    End Try
    'End Sub
    Public Sub CenterForm(ByVal tmpForm As Form)
        tmpForm.Top = (My.Computer.Screen.WorkingArea.Height \ 2) - (tmpForm.Height \ 2)
        tmpForm.Left = (My.Computer.Screen.WorkingArea.Width \ 2) - (tmpForm.Width \ 2)
    End Sub
    'Public Sub addDGVCheckBox(ByVal dgv As DataGridView, ByVal sName As String, ByVal bReadOnly As Boolean, ByVal iWidth As Integer, ByVal bFrozen As Boolean)
    '    Dim col As New DataGridViewCheckBoxColumn
    '    Try
    '        col.HeaderText = sName
    '        col.Name = sName
    '        col.Frozen = bFrozen
    '        col.ReadOnly = bReadOnly '
    '        col.Width = iWidth

    '        dgv.Columns.Add(col)
    '    Catch ex As Exception
    '        clsErrorManager.WriteErrorLog("mdlMaint", "addDGVCheckox", "", ex, Login, False, True)
    '    End Try
    'End Sub
    'Public Sub addDGVProductCombobox(ByVal dgv As DataGridView, ByVal sName As String, ByVal iWidth As Integer, ByVal bFrozen As Boolean)
    '    Dim col As New DataGridViewComboBoxColumn()
    '    Try
    '        col.HeaderText = sName
    '        col.Name = sName
    '        col.ReadOnly = False
    '        col.Visible = True
    '        col.Width = iWidth
    '        col.Frozen = bFrozen
    '        col.DataSource = gConn.QueryDBTable("Select Product_id,Product from trsys_products where Active=1 order by Product")
    '        col.DisplayMember = "Product"
    '        col.ValueMember = "Product"
    '        col.AutoComplete = True
    '        col.SortMode = DataGridViewColumnSortMode.NotSortable
    '        dgv.Columns.Add(col)
    '    Catch ex As Exception
    '        clsErrorManager.WriteErrorLog("mdlMaint", "addDGVProductCombobox", "", ex, Login, False, True)
    '    End Try
    'End Sub
    'Public Sub addDGVDriverCombobox(ByVal dgv As DataGridView, ByVal sName As String, ByVal iWidth As Integer, ByVal bFrozen As Boolean)
    '    Dim col As New DataGridViewComboBoxColumn()
    '    Try
    '        col.HeaderText = sName
    '        col.Name = sName
    '        col.ReadOnly = False
    '        col.Visible = True
    '        col.Width = iWidth
    '        col.Frozen = bFrozen
    '        col.DataSource = gConn.QueryDBTable("Select Driver_id,Last_name + ', ' + first_name + ' ' +Middle_initial as Driver_name from trsys_drivers where Active=1 order by Last_name,first_name,middle_initial")
    '        col.DisplayMember = "Driver_name"
    '        col.ValueMember = "Driver_id"
    '        col.AutoComplete = True
    '        col.SortMode = DataGridViewColumnSortMode.NotSortable
    '        dgv.Columns.Add(col)
    '    Catch ex As Exception
    '        clsErrorManager.WriteErrorLog("mdlMaint", "addDGVDriverCombobox", "", ex, Login, False, True)
    '    End Try
    'End Sub
    'Public Sub addDGVTractorCombobox(ByVal dgv As DataGridView, ByVal sName As String, ByVal iWidth As Integer, ByVal bFrozen As Boolean)
    '    Dim col As New DataGridViewComboBoxColumn()
    '    Try

    '        col.HeaderText = sName
    '        col.Name = sName
    '        col.ReadOnly = False
    '        col.Visible = True
    '        col.Width = iWidth
    '        col.Frozen = bFrozen
    '        col.DataSource = gConn.QueryDBTable("Select Tractor_id from trsys_Tractors where Active=1 order by Tractor_id")
    '        col.DisplayMember = "Tractor_id"
    '        col.ValueMember = "Tractor_id"
    '        col.AutoComplete = True
    '        col.SortMode = DataGridViewColumnSortMode.NotSortable
    '        dgv.Columns.Add(col)
    '    Catch ex As Exception
    '        clsErrorManager.WriteErrorLog("mdlMaint", "addDGVTractorCombobox", "", ex, Login, False, True)
    '    End Try
    'End Sub
    'Public Sub addDGVTrailerCombobox(ByVal dgv As DataGridView, ByVal sName As String, ByVal iWidth As Integer, ByVal bFrozen As Boolean)
    '    Dim col As New DataGridViewComboBoxColumn()
    '    Try
    '        col.HeaderText = sName
    '        col.Name = sName
    '        col.ReadOnly = False
    '        col.Visible = True
    '        col.Width = iWidth
    '        col.Frozen = bFrozen
    '        col.DataSource = gConn.QueryDBTable("Select Trailer_id from trsys_Trailers where Active=1 order by Trailer_id")
    '        col.DisplayMember = "Trailer_id"
    '        col.ValueMember = "Trailer_id"
    '        col.AutoComplete = True
    '        col.SortMode = DataGridViewColumnSortMode.NotSortable
    '        dgv.Columns.Add(col)
    '    Catch ex As Exception
    '        clsErrorManager.WriteErrorLog("mdlMaint", "addDGVTrailerCombobox", "", ex, Login, False, True)
    '    End Try
    'End Sub
    'Public Sub addDGVTextBox(ByVal dgv As DataGridView, ByVal sName As String, ByVal bReadOnly As Boolean, ByVal bVisible As Boolean, ByVal iWidth As Integer, ByVal iMaxInputLength As Integer, ByVal bFrozen As Boolean)
    '    Dim col As New DataGridViewTextBoxColumn
    '    Try
    '        col.HeaderText = sName
    '        col.Name = sName
    '        col.ReadOnly = bReadOnly
    '        col.Visible = bVisible
    '        col.Frozen = bFrozen
    '        col.Width = iWidth
    '        col.MaxInputLength = iMaxInputLength
    '        If dgv.Name = "dgvStops" Then
    '            col.SortMode = DataGridViewColumnSortMode.NotSortable
    '        Else
    '            col.SortMode = DataGridViewColumnSortMode.Automatic
    '        End If


    '        dgv.Columns.Add(col)
    '    Catch ex As Exception
    '        clsErrorManager.WriteErrorLog("mdlMaint", "addDGVTextBox", "", ex, Login, False, True)
    '    End Try
    'End Sub
    'Public Sub addDGVImage(ByVal dgv As DataGridView, ByVal sName As String, ByVal bReadOnly As Boolean, ByVal bVisible As Boolean, ByVal iWidth As Integer, ByVal bFrozen As Boolean)
    '    Dim col As New DataGridViewImageColumn
    '    Try
    '        col.HeaderText = sName
    '        col.Name = sName
    '        col.ReadOnly = bReadOnly
    '        col.Visible = bVisible
    '        col.Frozen = bFrozen
    '        col.Width = iWidth
    '        col.ValuesAreIcons = True
    '        '' Default to nothing on icons
    '        'Dim mCellStyle As DataGridViewCellStyle = New DataGridViewCellStyle(Nothing)
    '        ''   mCellStyle.NullValue = Nothing
    '        'col.DefaultCellStyle = mCellStyle






    '        dgv.Columns.Add(col)
    '    Catch ex As Exception
    '        clsErrorManager.WriteErrorLog("mdlMaint", "addDGVImage", "", ex, Login, False, True)
    '    End Try
    'End Sub

    Public Function getNextTableID(ByVal sTableName As String, ByVal sID As String, Optional ByVal sWhereClause As String = "") As String
        Dim msConn As New clsDataManager
        Dim Dr As SQLiteDataReader = Nothing
        getNextTableID = "0"
        Dim sSQL As String = ""
        Try

            ' Get Next ID
            msConn.OpenDB(Login.DBServer, Login.Database, Login.DatabaseUser, Login.DatabasePass)
            sSQL = "Select ifnull(max(" & sID & "),0)+1 as maxid from " & sTableName
            sSQL = sSQL & " " & sWhereClause
            Dr = msConn.QueryDB(sSQL)
            If Dr.Read() Then
                getNextTableID = Dr("maxid")
            End If


        Catch ex As Exception
            clsErrorManager.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, sSQL, ex, Login, False, True)
        Finally
            msConn.CloseReader(Dr)
            msConn.CloseDB()
        End Try
    End Function
    Public Function StringCount(ByVal value As String, ByVal mySearch As String) As Integer
        Return System.Text.RegularExpressions.Regex.Matches(value, mySearch).Count()
    End Function

    Enum enumObjectType
        StrType = 0
        IntType = 1
        DblType = 2
    End Enum

    Public Function CheckDBNull(ByVal obj As Object, _
    Optional ByVal ObjectType As enumObjectType = enumObjectType.StrType) As Object
        Dim objReturn As Object
        objReturn = obj
        If ObjectType = enumObjectType.StrType And (IsDBNull(obj) Or obj Is Nothing) Then
            objReturn = ""
        ElseIf ObjectType = enumObjectType.IntType And (IsDBNull(obj) Or obj Is Nothing) Then
            objReturn = 0
        ElseIf ObjectType = enumObjectType.DblType And (IsDBNull(obj) Or IsNothing(obj)) Then
            objReturn = 0.0
        End If
        Return objReturn
    End Function


    Public Function CheckMultiLine(ByVal sOrigData As String, ByVal sNewData As String) As String
        Try
            If sOrigData.Length > 0 Then
                sOrigData = sOrigData & vbCrLf
            End If
            sOrigData = sOrigData & sNewData

            Return sOrigData
        Catch ex As Exception
            Return sOrigData & sNewData
        End Try
    End Function


    Public Function ValidateNumber(ByVal sField As String, ByVal KeyAscii As Integer) As Integer

        Try

            ValidateNumber = KeyAscii
            If KeyAscii = 45 Then
                If Len(sField) > 0 Then
                    KeyAscii = 0
                End If
            Else

                ' Accepts numbers, backspace,Return Key, and decimal point
                If (KeyAscii < 48 Or KeyAscii > 57) And KeyAscii <> 8 And KeyAscii <> 13 And KeyAscii <> 46 Then
                    KeyAscii = 0
                End If
                ' Multiple decimal points not allowed
                If InStr(1, sField, ".", 1) > 0 And KeyAscii = 46 Then
                    KeyAscii = 0
                End If
                If KeyAscii = 13 Then
                    KeyAscii = 0

                    SendKeys.Send("{TAB}")
                End If
            End If
            ValidateNumber = KeyAscii





        Catch ex As Exception
            clsErrorManager.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login, False, True)
        End Try

    End Function


    Public Function hasDateChanged(ByVal sTableName As String, ByVal sWhereClause As String, ByVal sCheckDate As String, Optional ByVal sDateFieldName As String = "") As String

        hasDateChanged = "Error"

        Dim sSQL As String = ""
        Dim msConn As New clsDataManager
        Dim myDR As SQLiteDataReader = Nothing

        Try

            ' Get Date Field
            If Len(Trim(sDateFieldName)) = 0 Then
                sDateFieldName = "Modified_date"
            End If

            ' Setup Query
            sSQL = "Select " & sDateFieldName & " as dteTableDate, Modified_by from " & sTableName & " where " & sWhereClause


            msConn.OpenDB(Login.DBServer, Login.Database, Login.DatabaseUser, Login.DatabasePass)
            myDR = msConn.QueryDB(sSQL)
            ' Check Dates
            If myDR.Read = True Then
                If Format(myDR("dteTableDate"), "MM/dd/yyyy hh:mm tt") = Format(CDate(sCheckDate), "MM/dd/yyyy hh:mm tt") Then
                    ' Dates the same
                    hasDateChanged = ""
                Else
                    hasDateChanged = myDR("Modified_by") & ""
                End If
            End If

        Catch ex As Exception
            clsErrorManager.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, sSQL, ex, Login, False, True)

        Finally
            myDR.Close()
            msConn.CloseDB()
        End Try




    End Function

    Public Function getMaxTableID(ByVal sTableName As String, ByVal sID As String) As String
        Dim msConn As New clsDataManager
        Dim Dr As SQLiteDataReader = Nothing
        getMaxTableID = "0"
        Try

            ' Get Next ID
            msConn.OpenDB(Login.DBServer, Login.Database, Login.DatabaseUser, Login.DatabasePass)
            Dr = msConn.QueryDB("Select ifnull(max(" & sID & "),0)+1 as maxid from " & sTableName)
            If Dr.Read() Then
                getMaxTableID = Dr("maxid")
            End If


        Catch ex As Exception
            clsErrorManager.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login, False, True)
        Finally
            msConn.CloseReader(Dr)
            msConn.CloseDB()
        End Try
    End Function




    Public Function IsFormLoaded(ByVal FormName As String) As Boolean
        'Returns True if form name is found
        Dim f As Form
        For Each f In Forms
            If f.Name = FormName Then
                IsFormLoaded = True
                Exit For
            End If
        Next f
    End Function

    Public Function BolToBit(ByVal obj As Object) As Integer
        BolToBit = 0
        Try
            If obj.GetType.ToString.ToUpper = "SYSTEM.BOOLEAN" Then
                If obj.ToString.ToUpper = "TRUE" Then
                    BolToBit = 1
                Else
                    BolToBit = 0
                End If
            Else
                If IsNumeric(obj) = True Then
                    BolToBit = obj
                End If
            End If


        Catch ex As Exception

        End Try
    End Function



    'Public Function IgridFindRowIndex(ByRef IGrid1 As iGrid, ByVal myColumnName As String, ByVal mySearchText As String) As Integer
    '    Dim myTextFoundInRow As Boolean = False
    '    IgridFindRowIndex = 0
    '    Try
    '        IGrid1.BeginUpdate()
    '        Dim myText As String = UCase(mySearchText)

    '        For r As Integer = IGrid1.Rows.Count - 1 To 0 Step -1 'Step thru each row
    '            If IGrid1.Rows(r).Type = iGRowType.Normal Then  'Only normal rows
    '                myTextFoundInRow = False
    '                IGrid1.Cells(r, myColumnName).BackColor = Color.White
    '                If IGrid1.Cols(myColumnName).Visible = True Then  'Check only visible columns
    '                    If IGrid1.Cells(r, myColumnName).Text.Trim.Length > 0 Then 'Ignore blank cells
    '                        If IGrid1.Cells(r, myColumnName).Type = iGCellType.NotSet Then 'check only text box cells
    '                            If DirectCast(UCase(IGrid1.Cells(r, myColumnName).Value), String).IndexOf(myText) >= 0 Then
    '                                myTextFoundInRow = True
    '                                IgridFindRowIndex = r
    '                                IGrid1.Cells(r, myColumnName).BackColor = Color.LightGreen
    '                            End If
    '                        End If
    '                    End If
    '                End If
    '            End If
    '        Next

    '    Catch ex As Exception
    '        clsErrorManager.WriteErrorLog("mdlGPDEX", System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login)
    '    Finally
    '        IGrid1.EndUpdate()
    '    End Try
    'End Function
    Public Function getUnMappedDriveLetter() As String
        Dim sDriveList As String = "EFGHIJKLMNOPQRSTUVWXYZ"

        Try

            Dim drives As String()
            drives = System.IO.Directory.GetLogicalDrives()

            Dim str As String
            For Each str In drives
                ' ListBox1.Items.Add(str)
                sDriveList = Replace(sDriveList, str.Substring(0, 1).ToUpper, "")
            Next str
            'ListBox1.Items.Add(sDriveList)
            'ListBox1.Items.Add(sDriveList.Substring(0, 1))
            Return sDriveList.Substring(0, 1)


        Catch ex As Exception
            Return ""
        End Try
    End Function


    Private Function IsEmailAddress(ByVal sEmail As String, _
Optional ByRef sReason As String = "") As Boolean

        Dim nCharacter As Integer
        Dim sBuffer As String
        Try
            sEmail = Trim(sEmail)

            If Len(sEmail) < 8 Then
                IsEmailAddress = False
                sReason = "Too short"
                Exit Function
            End If


            If InStr(sEmail, "@") = 0 Then
                IsEmailAddress = False
                sReason = "Missing the @"
                Exit Function
            End If


            If InStr(InStr(sEmail, "@") + 1, sEmail, "@") <> 0 Then
                IsEmailAddress = False
                sReason = "Too many @"
                Exit Function
            End If


            If InStr(sEmail, ".") = 0 Then
                IsEmailAddress = False
                sReason = "Missing the period"
                Exit Function
            End If

            If InStr(sEmail, "@") = 1 Or InStr(sEmail, "@") = Len(sEmail) Or _
                InStr(sEmail, ".") = 1 Or InStr(sEmail, ".") = Len(sEmail) Then
                IsEmailAddress = False
                sReason = "Invalid format"
                Exit Function

            End If


            For nCharacter = 1 To Len(sEmail)
                sBuffer = Mid$(sEmail, nCharacter, 1)
                If Not (LCase(sBuffer) Like "[a-z]" Or sBuffer = "@" Or sBuffer = "." Or sBuffer = "-" Or sBuffer = "_" Or IsNumeric(sBuffer)) Then
                    IsEmailAddress = False
                    sReason = "Invalid character"
                    Exit Function

                End If
            Next nCharacter

            nCharacter = 0



            sBuffer = Right(sEmail, 4)
            If InStr(sBuffer, ".") = 0 Then GoTo TooLong
            If Left(sBuffer, 1) = "." Then sBuffer = Right(sBuffer, 3)
            If Left(Right(sBuffer, 3), 1) = "." Then sBuffer = Right(sBuffer, 2)
            If Left(Right(sBuffer, 2), 1) = "." Then sBuffer = Right(sBuffer, 1)


            If Len(sBuffer) < 2 Then
                IsEmailAddress = False
                sReason = "Suffix too short"
                Exit Function
            End If

TooLong:
            ' New valid emails
            If Right(sEmail, 4).ToUpper = "COOP" Or Right(sEmail, 4).ToUpper = "ARPA" Or Right(sEmail, 4).ToUpper = "AERO" Or Right(sEmail, 4).ToUpper = "NAME" Or Right(sEmail, 4).ToUpper = "INFO" Or Right(sEmail, 4).ToUpper = "MUSEUM" Then

            Else
                If Len(sBuffer) > 3 Then
                    IsEmailAddress = False
                    sReason = "Suffix too long"
                    Exit Function
                End If
            End If




            sReason = ""
            IsEmailAddress = True
        Catch ex As Exception
            clsErrorManager.WriteErrorLog("mdlMaint", "ISEmailAddress", "", ex, Login, False, True)
        End Try
    End Function

    Public Sub SetLoginConnectionInfo()

        Select Case sCompany
            Case "US"
                Select Case sRunLive
                    Case True
                        Login.Database = "Tech"
                        Login.DBServer = "Fresh2008"
                        Login.DatabaseUser = "sa"
                        Login.DatabasePass = "admin"

                        Login.GPComputerName = "USELGP2015"
                        Login.GPServer = "uselgp2015\gp"
                        Login.GPDatabase = "usi"
                        Login.GPDatabaseUser = "sa"
                        Login.GPDatabasePass = "S3cur!ty"
                    Case False
                        Login.Database = "Tech"
                        Login.DBServer = "TestSQL2008"
                        Login.DatabaseUser = "sa"
                        Login.DatabasePass = "admin"

                        Login.GPComputerName = "USELGP2015"
                        Login.GPServer = "uselgp2015\gp"
                        Login.GPDatabase = "zusia"
                        Login.GPDatabaseUser = "sa"
                        Login.GPDatabasePass = "S3cur!ty"
                End Select
            Case "AAD"
                Select Case sRunLive
                    Case True
                        Login.Database = "AAD"
                        Login.DBServer = "Fresh2008"
                        Login.DatabaseUser = "sa"
                        Login.DatabasePass = "admin"

                        Login.GPComputerName = "USELGP2015"
                        Login.GPServer = "uselgp2015\gp"
                        Login.GPDatabase = "aad"
                        Login.GPDatabaseUser = "sa"
                        Login.GPDatabasePass = "S3cur!ty"
                    Case False
                        Login.Database = "AAD"
                        Login.DBServer = "TestSQL2008"
                        Login.DatabaseUser = "sa"
                        Login.DatabasePass = "admin"

                        Login.GPComputerName = "USELGP2015"
                        Login.GPServer = "uselgp2015\gp"
                        Login.GPDatabase = "ZAAD"
                        Login.GPDatabaseUser = "sa"
                        Login.GPDatabasePass = "S3cur!ty"

                End Select
            Case "CANADA"
                Select Case sRunLive
                    Case True
                        Login.Database = "CPCAD"
                        Login.DBServer = "Fresh2008"
                        Login.DatabaseUser = "sa"
                        Login.DatabasePass = "admin"

                        Login.GPComputerName = "USELGP2015"
                        Login.GPServer = "uselgp2015\gp"
                        Login.GPDatabase = "usi"
                        Login.GPDatabaseUser = "sa"
                        Login.GPDatabasePass = "S3cur!ty"
                    Case False
                        Login.Database = "CPCAD"
                        Login.DBServer = "TestSQL2008"
                        Login.DatabaseUser = "sa"
                        Login.DatabasePass = "admin"

                        Login.GPComputerName = "USELGP2015"
                        Login.GPServer = "uselgp2015\gp"
                        Login.GPDatabase = "zusia"
                        Login.GPDatabaseUser = "sa"
                        Login.GPDatabasePass = "S3cur!ty"

                End Select
            Case "WUS"
                Select Case sRunLive
                    Case True
                        Login.Database = "TECH"
                        Login.DBServer = "LIVEDB01"
                        Login.DatabaseUser = "sa"
                        Login.DatabasePass = "admin"

                        Login.GPComputerName = "USELGP2015"
                        Login.GPServer = "uselgp2015\gp"
                        Login.GPDatabase = "WUS"
                        Login.GPDatabaseUser = "sa"
                        Login.GPDatabasePass = "S3cur!ty"
                    Case False
                        Login.Database = "TECH"
                        Login.DBServer = "TESTDB01"
                        Login.DatabaseUser = "sa"
                        Login.DatabasePass = "Admin2015"

                        Login.GPComputerName = "USELGP2015"
                        Login.GPServer = "uselgp2015\gp"
                        Login.GPDatabase = "zUSIB"
                        Login.GPDatabaseUser = "sa"
                        Login.GPDatabasePass = "S3cur!ty"

                End Select

        End Select


    End Sub
    'Public Sub BeginPopulating(myDivisionId As Integer, myClassId As Integer)
    '    'Populate First Round
    '    Dim msConn As New clsDataManager
    '    Dim Dr As SqlDataReader = Nothing
    '    Dim sSQL As String = ""
    '    Dim ht As Hashtable
    '    Dim x As Integer = 0 'sequence counter for participants in class.
    '    Dim y As Integer = 0 'counter for participants in class
    '    Dim myCntInClass As Integer = 0
    '    Dim myCntInBracket As Integer = 0
    '    Dim BracketLetter() As String = {"A", "B", "C", "D", "E", "F"}
    '    Dim myByeRowId As Integer = 0
    '    'Dim msConnB As New clsDataManager
    '    'Dim DrBracket As SqlDataReader = Nothing


    '    Try


    '        'Make sure all participants have been assigned to a Division and Class
    '        'If gConn.getValue("select count(*) from rrwt_participants where divisionId = " & cmbDivisions.SelectedValue & " and classid < 1") > 0 Then
    '        '    MsgBox("Not all Participants have been assigned a Class in Division: " & cmbDivisions.SelectedText)
    '        '    Exit Sub
    '        'End If


    '        ' Get Bye RowId
    '        myByeRowId = gConn.getValue("select top 1 rowid from rrwt_participants where name = 'Bye' order by rowid")

    '        'Clear this bracket
    '        'If chkClearFirst.CheckState = CheckState.Checked Then
    '        gConn.ExecuteDB("delete from rrwt_brackets where divRowid = " & myDivisionId & " and classRowId = " & myClassId)
    '        gConn.ExecuteDB("update rrwt_participants set bracketid = 0 where DivisionId = " & myDivisionId & " and ClassId = " & myClassId)
    '        'End If

    '        'Loop thru participants and assign a position in the brackets
    '        msConn.OpenDB(Login.DBServer, Login.Database, Login.DatabaseUser, Login.DatabasePass)
    '        sSQL = "select * from rrwt_participants where  DivisionId = " & myDivisionId & " and ClassId = " & myClassId & " order by DivisionId,ClassId, Weight"
    '        Dr = msConn.QueryDB(sSQL)
    '        Do While Dr.Read()
    '            'Create Bracket if it doesn't exist
    '            If msConn.getValue("select count(*) from rrwt_brackets where divrowid = " & Dr("DivisionId") & " and classrowid = " & Dr("ClassId")) = 0 Then
    '                sSQL = "insert into rrwt_brackets (DivRowId,ClassRowId) values (" & Dr("DivisionId") & "," & Dr("ClassId") & ")"
    '                gConn.ExecuteDB(sSQL)
    '            End If

    '            'Populate the first round Bracket
    '            myCntInClass = msConn.getValue("select count(*) from rrwt_participants where DivisionId = " & Dr("DivisionId") & " and ClassId = " & Dr("ClassId"))
    '            For y = 1 To myCntInClass
    '                gConn.ExecuteDB("UPDATE rrwt_brackets set R1" & BracketLetter(y - 1) & "PARTROWID = " & Dr("RowId") & " where DivRowId = " & Dr("DivisionId") & " and ClassRowId = " & Dr("ClassId"))

    '                'If 3 or 5 in bracket add a bye in the 4th or 6th spot
    '                If myCntInClass = y And (myCntInClass = 3 Or myCntInClass = 5) Then
    '                    gConn.ExecuteDB("UPDATE rrwt_brackets set R1" & BracketLetter(y) & "PARTROWID = " & myByeRowId & " where DivRowId = " & Dr("DivisionId") & " and ClassRowId = " & Dr("ClassId"))
    '                End If



    '                If y < myCntInClass Then
    '                    Dr.Read()
    '                End If
    '            Next

    '            'Get Bracket Record
    '            ht = gConn.GetHashRecord("Select * from rrwt_brackets where divrowid = " & Dr("DivisionId") & " and classrowid = " & Dr("ClassId"))
    '            'If ht.Count > 0 Then

    '            'Populate Remaining Rounds if 2 Man Bracket
    '            If myCntInClass = 2 Then
    '                sSQL = "update rrwt_brackets set  "
    '                sSQL = sSQL & " R2APARTROWID = R1BPARTROWID,"
    '                sSQL = sSQL & " R2BPARTROWID = R1APARTROWID,"

    '                sSQL = sSQL & " R3APARTROWID = R1APARTROWID,"
    '                sSQL = sSQL & " R3BPARTROWID = R1BPARTROWID"
    '                sSQL = sSQL & " where divrowid = " & Dr("DivisionId") & " and classrowid = " & Dr("ClassId")
    '                gConn.ExecuteDB(sSQL)
    '            End If

    '            If myCntInClass = 3 Then
    '                sSQL = "update rrwt_brackets set  "
    '                sSQL = sSQL & " R2aPARTROWID = R1bPARTROWID,"
    '                sSQL = sSQL & " R2BPARTROWID = R1cPARTROWID,"
    '                sSQL = sSQL & " R2CPARTROWID = R1aPARTROWID,"
    '                sSQL = sSQL & " R2dPARTROWID = " & myByeRowId & ","

    '                sSQL = sSQL & " R3APARTROWID = R1cPARTROWID,"
    '                sSQL = sSQL & " R3BPARTROWID = R1aPARTROWID,"
    '                sSQL = sSQL & " R3CPARTROWID = R1bPARTROWID,"
    '                sSQL = sSQL & " R3dPARTROWID = " & myByeRowId & ""
    '                sSQL = sSQL & " where divrowid = " & Dr("DivisionId") & " and classrowid = " & Dr("ClassId")
    '                gConn.ExecuteDB(sSQL)
    '            End If

    '            If myCntInClass = 4 Then
    '                sSQL = "update rrwt_brackets set  "
    '                sSQL = sSQL & " R2aPARTROWID = R1aPARTROWID,"
    '                sSQL = sSQL & " R2BPARTROWID = R1dPARTROWID,"
    '                sSQL = sSQL & " R2CPARTROWID = R1bPARTROWID,"
    '                sSQL = sSQL & " R2dPARTROWID = R1cPARTROWID,"

    '                sSQL = sSQL & " R3APARTROWID = R1aPARTROWID,"
    '                sSQL = sSQL & " R3BPARTROWID = R1cPARTROWID,"
    '                sSQL = sSQL & " R3CPARTROWID = R1bPARTROWID,"
    '                sSQL = sSQL & " R3dPARTROWID = R1dPARTROWID"
    '                sSQL = sSQL & " where divrowid = " & Dr("DivisionId") & " and classrowid = " & Dr("ClassId")
    '                gConn.ExecuteDB(sSQL)
    '            End If

    '            If myCntInClass = 5 Then
    '                sSQL = "update rrwt_brackets set  "
    '                sSQL = sSQL & " R2aPARTROWID = R1aPARTROWID,"
    '                sSQL = sSQL & " R2BPARTROWID = R1cPARTROWID,"
    '                sSQL = sSQL & " R2CPARTROWID = R1bPARTROWID,"
    '                sSQL = sSQL & " R2dPARTROWID = R1ePARTROWID,"
    '                sSQL = sSQL & " R2ePARTROWID = R1dPARTROWID,"
    '                sSQL = sSQL & " R2fPARTROWID =  " & myByeRowId & ","

    '                sSQL = sSQL & " R3APARTROWID = R1aPARTROWID,"
    '                sSQL = sSQL & " R3BPARTROWID = R1dPARTROWID,"
    '                sSQL = sSQL & " R3CPARTROWID = R1cPARTROWID,"
    '                sSQL = sSQL & " R3dPARTROWID = R1ePARTROWID,"
    '                sSQL = sSQL & " R3ePARTROWID = R1bPARTROWID,"
    '                sSQL = sSQL & " R3fPARTROWID =  " & myByeRowId & ","

    '                sSQL = sSQL & " R4APARTROWID = R1aPARTROWID,"
    '                sSQL = sSQL & " R4BPARTROWID = R1ePARTROWID,"
    '                sSQL = sSQL & " R4CPARTROWID = R1bPARTROWID,"
    '                sSQL = sSQL & " R4dPARTROWID = R1dPARTROWID,"
    '                sSQL = sSQL & " R4ePARTROWID = R1cPARTROWID,"
    '                sSQL = sSQL & " R4fPARTROWID =  " & myByeRowId & ","

    '                sSQL = sSQL & " R5APARTROWID = R1bPARTROWID,"
    '                sSQL = sSQL & " R5BPARTROWID = R1cPARTROWID,"
    '                sSQL = sSQL & " R5CPARTROWID = R1ePARTROWID,"
    '                sSQL = sSQL & " R5dPARTROWID = R1dPARTROWID,"
    '                sSQL = sSQL & " R5ePARTROWID = R1aPARTROWID,"
    '                sSQL = sSQL & " R5fPARTROWID =  " & myByeRowId & ""



    '                sSQL = sSQL & " where divrowid = " & Dr("DivisionId") & " and classrowid = " & Dr("ClassId")
    '                gConn.ExecuteDB(sSQL)
    '            End If


    '            x = x + 1

    '            Application.DoEvents()

    '        Loop


    '        ' Create Bye records in each class if needed.


    '        'lblFeedback.Text = "Finished (" & x.ToString & ")"


    '    Catch ex As Exception
    '        clsErrorManager.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, sSQL, ex, Login, False, True)

    '    Finally
    '        msConn.CloseReader(Dr)
    '        msConn.CloseDB()
    '        ht = Nothing
    '    End Try

    'End Sub

End Module



