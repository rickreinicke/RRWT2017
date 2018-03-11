Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmReportViewer
    Private bLoaded As Boolean
    Private sReportPathName As String
    Private sReportName As String

    Private Sub frmReportViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            ' Form Size Location settings
            Call SaveFormSizeLocation(Me)
        Catch ex As Exception
            clsErrorManager.WriteErrorLog("frmReportViewer", "frmReportViewer_FormClosing", "", ex, Login)
        End Try
    End Sub

    Private Sub frmReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ' Form Size Location settings
            Call SetMinSize(Me)
            KeyPreview = True
            Call GetFormSizeLocation(Me)
            ' these next lines are to fix when user goes from dual monitor to single monitor when report is closed while on second screen.
            Me.Top = 0
            Me.Left = 0
            Me.WindowState = FormWindowState.Normal

            ''''fixfix LoadStatusBar(Me.ssStatus)
        Catch ex As Exception
            clsErrorManager.WriteErrorLog("frmReportViewer", "frmReportViewer_Load", "", ex, Login)
        End Try
    End Sub
    Public Sub setReportPathName(ByVal sPathFileName As String)
        sReportPathName = sPathFileName
        sReportName = StripReportName(sReportPathName)
    End Sub


    Public Function ViewReport(ByVal sReportName As String, Optional ByVal sSelectionFormula As String = "", Optional ByVal param As String = "", Optional ByVal ExportIt As Boolean = False) As Boolean

        'Declaring variablesables
        Dim intCounter As Integer
        Dim intCounter1 As Integer
        ViewReport = True
        'Crystal Report's report document object
        Dim objReport As New  _
            CrystalDecisions.CrystalReports.Engine.ReportDocument

        'object of table Log on info of Crystal report
        Dim ConInfo As New CrystalDecisions.Shared.TableLogOnInfo

        'Parameter value object of crystal report 
        ' parameters used for adding the value to parameter.
        Dim paraValue As New CrystalDecisions.Shared.ParameterDiscreteValue

        'Current parameter value object(collection) of crystal report parameters.
        Dim currValue As CrystalDecisions.Shared.ParameterValues

        'Sub report object of crystal report.
        Dim mySubReportObject As  _
            CrystalDecisions.CrystalReports.Engine.SubreportObject

        'Sub report document of crystal report.
        Dim mySubRepDoc As New  _
            CrystalDecisions.CrystalReports.Engine.ReportDocument

        Dim strParValPair() As String
        Dim strVal() As String
        Dim index As Integer

        Try

            'Load the report
            objReport.Load(sReportName)

            'Check if there are parameters or not in report.
            intCounter = objReport.DataDefinition.ParameterFields.Count

            'As parameter fields collection also picks the selection 
            ' formula which is not the parameter
            ' so if total parameter count is 1 then we check whether 
            ' its a parameter or selection formula.

            If intCounter = 1 Then
                If InStr(objReport.DataDefinition.ParameterFields(0).ParameterFieldName, ".", CompareMethod.Text) > 0 Then
                    intCounter = 0
                End If
            End If

            'If there are parameters in report and 
            'user has passed them then split the 
            'parameter string and Apply the values 
            'to their concurrent parameters.

            If intCounter > 0 And Trim(param) <> "" Then
                strParValPair = param.Split("&")

                For index = 0 To UBound(strParValPair)
                    If InStr(strParValPair(index), "=") > 0 Then
                        strVal = strParValPair(index).Split("=")
                        paraValue.Value = strVal(1)
                        currValue = _
                            objReport.DataDefinition.ParameterFields(strVal(0)).CurrentValues
                        currValue.Add(paraValue)
                        objReport.DataDefinition.ParameterFields(strVal(0)).ApplyCurrentValues(currValue)
                    End If
                Next
            End If

            'Set the connection information to ConInfo 
            'object so that we can apply the 
            'connection information on each table in the report
            'ConInfo.ConnectionInfo.UserID = "rrwt" ' Login.DatabaseUser ' "" '<User Name>
            'ConInfo.ConnectionInfo.Password = "rrwt" 'Login.DatabasePass  '<Password>
            'ConInfo.ConnectionInfo.ServerName = Login.DBServer '<Server Name>
            'ConInfo.ConnectionInfo.DatabaseName = Login.Database ' <Database Name>

            'ConInfo.ConnectionInfo.ServerName =
            ConInfo.ConnectionInfo.ServerName = "Driver=SQLite3 ODBC Driver;Database=" & Login.DataFullPath

            For intCounter = 0 To objReport.Database.Tables.Count - 1
                objReport.Database.Tables(intCounter).ApplyLogOnInfo(ConInfo)
            Next

            ' Loop through each section on the report then look 
            ' through each object in the section
            ' if the object is a subreport, then apply logon info 
            ' on each table of that sub report

            For index = 0 To objReport.ReportDefinition.Sections.Count - 1
                For intCounter = 0 To _
                    objReport.ReportDefinition.Sections(index).ReportObjects.Count - 1
                    With objReport.ReportDefinition.Sections(index)
                        If .ReportObjects(intCounter).Kind = _
                        CrystalDecisions.Shared.ReportObjectKind.SubreportObject Then
                            mySubReportObject = CType(.ReportObjects(intCounter),  _
                              CrystalDecisions.CrystalReports.Engine.SubreportObject)
                            mySubRepDoc = _
                     mySubReportObject.OpenSubreport(mySubReportObject.SubreportName)
                            For intCounter1 = 0 To mySubRepDoc.Database.Tables.Count - 1
                                mySubRepDoc.Database.Tables(intCounter1).ApplyLogOnInfo(ConInfo)
                                mySubRepDoc.Database.Tables(intCounter1).ApplyLogOnInfo(ConInfo)
                            Next
                        End If
                    End With
                Next
            Next
            'If there is a selection formula passed to this function then use that
            If sSelectionFormula.Length > 0 Then
                objReport.RecordSelectionFormula = sSelectionFormula
            End If
            'Re setting control 
            CRViewer1.ReportSource = Nothing

            'Set the current report object to report.
            'CRViewer1.ReportSource = New UserList


            CRViewer1.ReportSource = objReport

            'Show the report
            If ExportIt = False Then
                CRViewer1.Show()
            Else
                objReport.ExportToDisk(ExportFormatType.PortableDocFormat, Login.DataFolder & "\Exported.pdf")
            End If

            Return True
        Catch ex As System.Exception
            MsgBox(ex.Message)
        End Try
    End Function
End Class