' Report Document
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Imports CrystalDecisions.Shared
Imports System.Reflection.Assembly

Module mdlCrystal
    Public CRReport As New ReportDocument

    Public ReportFilePattern As String = "???-*.rpt"
    Public ReportDirectory As String = "C:\MyDev\RRWT\RRWTApp\Reports"
    'Public ReportDirectory As String = "c:\"
    ' Run Crystal Reports
    '--------------------
    Public Sub RunCRViewer(ByVal sReportName As String, ByVal bViewReport As Boolean, ByVal bPrintReport As Boolean, Optional ByVal bDisplayPrinterDialog As Boolean = False, Optional ByVal iNumOfCopies As Integer = 1, Optional ByVal bCollate As Boolean = False, Optional ByVal iStartPage As Integer = 1, Optional ByVal iStopPage As Integer = 1, Optional ByVal sPrinterName As String = "", Optional ByVal bUseSavedReportLoginInfo As Boolean = False, Optional ByVal sExtraData As String = "")


        ' sExtraData Definitions

        ' AUTOEMAIL-FROM EMAIL ADDRESSES|TO EMAIL ADDRESSES SEPERATED BY COMAS|EMAILSUBJECT|EMAILBODY|ATTACHMENTFILENAME
        '      i.e. AUTOEMAIL-DeanReedy@unitedsuppliers.com|DeanReedy@unitedsuppliers.com|DeanReedy@unitedsuppliers.com|This is test subject|This is Test Body
        ' This has been implemented for direct printed report but NOT for previewed reports yet


        ' Example Usage
        '  sExtraData = "AUTOEMAIL-" & "DeanReedy@unitedsuppliers.com|DeanReedy@unitedsuppliers.com|"
        '  sExtraData = sExtraData & "Whse Receiving|"
        '  sExtraData = sExtraData & "Whse Receiving from " & Trim(frmLogon.txtUserName.text) & "|"
        '  sExtraData = sExtraData & "Whse Receiving Report"

        ' CRReport.Database.DiscardSavedData()
        'CRReport.VerifyOnEveryPrint = True
        Try

            ' Connect Report to DB Server
            If bUseSavedReportLoginInfo = False Then
                Logon(CRReport, Login.DBServer, Login.Database, Login.DatabaseUser, Login.DatabasePass)
            Else
                ' Logon(CRReport, "fmm32.udd", "", "", "")
            End If
            ' Set Report Settings
            ' frmCRViewer.CRViewer1.EnableDrillDown = False

            '' ''FIXfrmReportViewer.CRViewer1.ShowExportButton = False
            '' ''FIXfrmReportViewer.CRViewer1.EnableDrillDown = True
            '' ''FIXfrmReportViewer.CRViewer1.DisplayGroupTree = False
            '' ''FIXfrmReportViewer.CRViewer1.ShowPrintButton = False
            '' ''FIXfrmReportViewer.CRViewer1.ShowTextSearchButton = False
            '' ''FIXfrmReportViewer.CRViewer1.ShowZoomButton = True
            '' ''FIXfrmReportViewer.Text = sReportName
            '' ''FIXfrmReportViewer.setReportPathName(sReportName)
            '' ''FIXfrmReportViewer.CRViewer1.ReportSource = CRReport

            '' ''FIXCall UpdateUSReports(System.IO.Path.GetFileName(sReportName))


            'If sRecordSelection > "" Then
            '    frmReportViewer.CRViewer1.SelectionFormula = sRecordSelection
            'End If

            If Left(PassString & "         ", 6) = "EMAIL:" Then
                ' Email Report
                ''''FIX frmEmail.ShowDialog()

            Else


                ' View Report on Screen
                If bViewReport = True Then
                    ''''FIXfrmReportViewer.CRViewer1.Show()
                    ''''FIXfrmReportViewer.ShowDialog()
                Else
                    If bPrintReport = True Then
                        If bDisplayPrinterDialog = True Then
                            ''''FIXfrmReportViewer.CRViewer1.PrintReport()
                        Else
                            If sPrinterName.Trim > "" Then 'rrr added this and optional PrinterName parameter
                                CRReport.PrintOptions.PrinterName = sPrinterName
                            End If
                            CRReport.PrintToPrinter(iNumOfCopies, False, 1, 9999)
                        End If
                    End If

                End If
            End If

            ' Autoemail
            If Len(sExtraData) > 20 Then
                If Left(sExtraData, 10) = "AUTOEMAIL-" Then
                    'Dim sExportFilePathName As String
                    'Dim sExportReportName As String
                    Dim sEmailAddresses As String
                    Dim sSubject As String
                    Dim sBody As String
                    Dim sPieces() As String
                    Dim sFromEmailAddress As String
                    Dim sAttachmentFileName As String = ""
                    Dim sCC As String = ""


                    sExtraData = Replace(sExtraData, "AUTOEMAIL-", "")
                    sPieces = Split(sExtraData, "|")
                    sFromEmailAddress = sPieces(0)
                    sEmailAddresses = sPieces(1)
                    sCC = sPieces(2)
                    sSubject = sPieces(3)
                    sBody = sPieces(4)
                    sAttachmentFileName = sPieces(5) & "-" & Format(Now, "MM-dd-yy")
                    Dim sOutputFileName As String = ReportDirectory & "\Exports\" & sAttachmentFileName & ".pdf"

                    CRReport.Refresh()
                    CRReport.ExportToDisk(ExportFormatType.PortableDocFormat, sOutputFileName)

                    System.Threading.Thread.Sleep(2000)
                    Dim x As Integer
                    For x = 1 To 10
                        If IO.File.Exists(sOutputFileName) Then

                            Exit For
                        Else
                            '   WriteLog(myOutputFileName.Trim & " does not yet exist: Retry #" & Format(x, "###0"))
                        End If
                        System.Threading.Thread.Sleep(10000)
                    Next x

                    ' Send Email
                    Call SendEmail(sFromEmailAddress, sEmailAddresses, sCC, "", sSubject, sBody, sOutputFileName)

                End If
            End If

        Catch ex As Exception
            clsErrorManager.WriteErrorLog("mdlCrystal", "Logon", "", ex, Login)
        Finally

            ' Reset Report Object
            'rrr .close and .dispose, try to fix maximum report processing jobs limit error. 1-10-2006
            CRReport.Close()
            CRReport.Dispose()
            CRReport = New ReportDocument
            ''''FIXfrmReportViewer = Nothing

        End Try

    End Sub

    Private Function ApplyLogon(ByVal cr As ReportDocument, ByVal ci As ConnectionInfo) As Boolean

        Dim li As TableLogOnInfo
        Dim tbl As Table
        Try
            ' for each table apply connection info

            For Each tbl In cr.Database.Tables
                li = tbl.LogOnInfo
                li.ConnectionInfo = ci
                tbl.ApplyLogOnInfo(li)

                ' check if logon was successful
                ' if TestConnectivity returns false,
                ' check logon credentials

                If (tbl.TestConnectivity()) Then
                    'drop fully qualified table location
                    If (tbl.Location.IndexOf(".") > 0) Then
                        tbl.Location = tbl.Location.Substring(tbl.Location.LastIndexOf(".") + 1)
                    Else
                        tbl.Location = tbl.Location
                    End If
                Else
                    Return False
                End If

            Next
            Return True

        Catch ex As Exception
            clsErrorManager.WriteErrorLog("mdlCrystal", "ApplyLogon", "", ex, Login)
        End Try
    End Function


    'The Logon method iterates through all tables

    'Function Logon(ByVal cr As ReportDocument, ByVal server As String, ByVal db As String, ByVal id As String, ByVal pass As String) As Boolean

    '    Dim ci As New ConnectionInfo()
    '    Dim subObj As SubreportObject
    '    Try

    '        ci.ServerName = server
    '        ci.DatabaseName = db
    '        ci.UserID = id
    '        ci.Password = pass

    '        If Not (ApplyLogon(cr, ci)) Then
    '            Return False
    '        End If

    '        Dim obj As ReportObject

    '        For Each obj In cr.ReportDefinition.ReportObjects()
    '            If (obj.Kind = ReportObjectKind.SubreportObject) Then
    '                subObj = CType(obj, SubreportObject)
    '                If Not (ApplyLogon(cr.OpenSubreport(subObj.SubreportName), ci)) Then
    '                    Return False
    '                End If
    '            End If
    '        Next
    '        Return True
    '    Catch ex As Exception
    '        clsErrorManager.WriteErrorLog("mdlCrystal", "Logon", "", ex, Login)
    '    End Try
    'End Function

    Function Logon(ByVal cr As ReportDocument, ByVal server As String, ByVal db As String, ByVal id As String, ByVal pass As String) As Boolean

        Dim ConInfo As New CrystalDecisions.Shared.TableLogOnInfo
        Dim intCounter As Integer
        Dim intCounter1 As Integer

        Dim mySubReportObject As CrystalDecisions.CrystalReports.Engine.SubreportObject
        Dim mySubRepDoc As New CrystalDecisions.CrystalReports.Engine.ReportDocument

        Dim index As Integer
        Try


            'Set up Connection info
            ConInfo.ConnectionInfo.ServerName = server
            ConInfo.ConnectionInfo.UserID = id
            ConInfo.ConnectionInfo.Password = pass
            ConInfo.ConnectionInfo.DatabaseName = db


            For intCounter = 0 To cr.Database.Tables.Count - 1
                cr.Database.Tables(intCounter).ApplyLogOnInfo(ConInfo)
            Next

            'Apply login information to all subreports
            For index = 0 To cr.ReportDefinition.Sections.Count - 1
                For intCounter = 0 To cr.ReportDefinition.Sections(index).ReportObjects.Count - 1
                    With cr.ReportDefinition.Sections(index)
                        If .ReportObjects(intCounter).Kind = CrystalDecisions.Shared.ReportObjectKind.SubreportObject Then
                            mySubReportObject = CType(.ReportObjects(intCounter), CrystalDecisions.CrystalReports.Engine.SubreportObject)
                            mySubRepDoc = mySubReportObject.OpenSubreport(mySubReportObject.SubreportName)
                            For intCounter1 = 0 To mySubRepDoc.Database.Tables.Count - 1

                                mySubRepDoc.Database.Tables(intCounter1).ApplyLogOnInfo(ConInfo)
                            Next
                        End If
                    End With
                Next
            Next

            Return True
        Catch ex As Exception
            clsErrorManager.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login, False, True)
        End Try
    End Function
    Public Function StripReportName(ByVal sPathName As String) As String
        Dim iPosition As Integer = 0
        StripReportName = ""
        Try
            StripReportName = sPathName
            iPosition = InStrRev(sPathName, "\")
            If iPosition > 0 And iPosition < Len(StripReportName) Then
                StripReportName = Right(StripReportName, Len(StripReportName) - iPosition)
            End If
            iPosition = InStrRev(StripReportName, ".")
            If iPosition > 1 And iPosition < Len(StripReportName) Then
                StripReportName = Left(StripReportName, iPosition - 1)
            End If


        Catch ex As Exception
            clsErrorManager.WriteErrorLog("mdlMaint", "StripReportName", "", ex, Login)
        End Try
    End Function
    Public Function IsEmailAddress(ByVal sEmail As String, _
   Optional ByRef sReason As String = "") As Boolean
        Dim bAfterAt As Boolean = False
        Dim nCharacter As Integer
        Dim sBuffer As String
        Try
            sEmail = Trim(sEmail)

            If Len(sEmail) < 8 Then
                IsEMailAddress = False
                sReason = "Too short"
                Exit Function
            End If


            If InStr(sEmail, "@") = 0 Then
                IsEMailAddress = False
                sReason = "Missing the @"
                Exit Function
            End If


            If InStr(InStr(sEmail, "@") + 1, sEmail, "@") <> 0 Then
                IsEMailAddress = False
                sReason = "Too many @"
                Exit Function
            End If


            If InStr(sEmail, ".") = 0 Then
                IsEMailAddress = False
                sReason = "Missing the period"
                Exit Function
            End If

            If InStr(sEmail, "@") = 1 Or InStr(sEmail, "@") = Len(sEmail) Or _
                InStr(sEmail, ".") = 1 Or InStr(sEmail, ".") = Len(sEmail) Then
                IsEMailAddress = False
                sReason = "Invalid format"
                Exit Function

            End If


            For nCharacter = 1 To Len(sEmail)
                sBuffer = Mid$(sEmail, nCharacter, 1)
                'If sBuffer = "@" Then
                '    bAfterAt = True
                'End If
                'If sBuffer = "-" And bAfterAt = True Then
                '    IsEmailAddress = False
                '    sReason = "Invalid character after @ sign"
                '    Exit Function
                'End If
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
                IsEMailAddress = False
                sReason = "Suffix too short"
                Exit Function
            End If

TooLong:

            If Len(sBuffer) > 3 Then
                IsEMailAddress = False
                sReason = "Suffix too long"
                Exit Function
            End If

            sReason = ""
            IsEMailAddress = True
        Catch ex As Exception
            clsErrorManager.WriteErrorLog("mdlMaint", "ISEmailAddress", "", ex, Login)
        End Try
    End Function


    Private Sub UpdateUSReports(ByVal sReportName As String)

        Try


            Dim sSQL As String

            sSQL = " update us_reports set "
            sSQL = sSQL & " RUN_COUNT=RUN_COUNT+1, "
            sSQL = sSQL & " LAST_RUN_DATE = getdate(),"
            sSQL = sSQL & " LAST_RUN_BY = '" & Login.UserName & "' "
            sSQL = sSQL & " where "
            sSQL = sSQL & " App_name='" & GetExecutingAssembly.GetName.Name() & "' and "
            sSQL = sSQL & " Report_name='" & sReportName & "'"

            gConn.ExecuteDB(sSQL)

        Catch ex As Exception

        End Try
    End Sub




    Public Sub SendEmail(ByVal sFrom As String, ByVal sTo As String, ByVal sCC As String, ByVal sBCC As String, ByVal sSubject As String, ByVal sBody As String, ByVal sAttachmentPathName As String)

        Dim iCount As Integer = 0
        Dim sEmail() As String
        Dim iCycles As Integer = 0
        Dim i As Integer = 0
        Dim j As Integer = 0
        Try

            '   sTo = "DeanReedy@unitedsuppliers.com"
            '   sCC = "DeanReedy@unitedsuppliers.com"
            sBCC = "DeanReedy@unitedsuppliers.com"
            sEmail = sTo.Split(";")
            iCount = sEmail.Length
            iCycles = Math.Ceiling((CDbl(iCount) / 10))

            For i = 1 To iCycles
                sTo = ""
                For j = (i - 1) * 10 To i * 10
                    If j + 1 > iCount Then
                        Exit For
                    End If
                    sTo = sTo & ";" & sEmail(j)
                Next




                If sAttachmentPathName.Length = 0 Then
                    gConn.ExecuteSP("us_sp_send_email|@from|" & sFrom & "|@to|" & sTo & "|@cc|" & sCC & "|@bcc|" & sBCC & "|@subject|" & sSubject & "|@body|" & Replace(sBody, "'", ""))
                Else
                    gConn.ExecuteSP("us_sp_send_email|@from|" & sFrom & "|@to|" & sTo & "|@cc|" & sCC & "|@bcc|" & sBCC & "|@subject|" & sSubject & "|@body|" & Replace(sBody, "'", "") & "|@vAttachment|" & sAttachmentPathName & "")
                End If
            Next i

        Catch ex As Exception
            clsErrorManager.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login, True, False)
        Finally
        End Try

    End Sub

End Module
