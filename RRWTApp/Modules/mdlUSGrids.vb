Imports System.Reflection.Assembly
Imports System.Diagnostics.FileVersionInfo
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports TenTec.Windows.iGridLib

Module mdlUSGrids

    ' Lookup Screen Pass values
    Public sPassString As String



    'Public Sub GridSortable(ByVal tmpGrid As iGrid, ByVal bSortable As Boolean)
    '    Dim i As Integer = 0
    '    Try
    '        For i = 0 To tmpGrid.Rows.Count - 1
    '            tmpGrid.Rows.Item(i).Sortable = bSortable
    '        Next
    '    Catch ex As Exception
    '        clsErrorManager.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login, False, True)
    '    End Try
    'End Sub




    'Public Sub LoadGridSavedLayout(ByRef myForm As Form, ByRef myIgrid As iGrid)
    '    Try
    '        If gReg.GetSetting(Login, Login.ExeName, myForm.Name, myIgrid.Name, "") > "" Then
    '            SetLayoutFlagsToGrid(myIgrid)
    '            myIgrid.LayoutObject.Text = gReg.GetSetting(Login, Login.ExeName, myForm.Name, myIgrid.Name, "")
    '        End If
    '    Catch ex As Exception
    '        clsErrorManager.WriteErrorLog(myForm.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login)
    '    Finally

    '    End Try

    'End Sub
    'Public Sub SetLayoutFlagsToGridWidthOnly(ByRef myiGrid As iGrid)

    '    Dim myFlags As iGLayoutFlags = 0
    '    Try
    '        '            myFlags = myFlags Or iGLayoutFlags.ColVisibility
    '        '           myFlags = myFlags Or iGLayoutFlags.ColOrder
    '        myFlags = myFlags Or iGLayoutFlags.ColWidth
    '        '          myFlags = myFlags Or iGLayoutFlags.Grouping
    '        '         myFlags = myFlags Or iGLayoutFlags.Sorting
    '        myiGrid.LayoutObject.Flags = myFlags
    '    Catch ex As Exception
    '        clsErrorManager.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login, False, True)
    '    End Try

    ''End Sub
    'Public Sub ExportIGrid(ByVal igrid As iGrid, ByVal bIncludeHiddenColumns As Boolean)

    '    Try
    '        Dim sExcelFileName As String = ExportiGridtoExcel(igrid, bIncludeHiddenColumns)
    '        If sExcelFileName.Length > 0 Then
    '            ' Email
    '            ''''FIX Call frmEmail.LoadReportInfo(sExcelFileName, ReportDirectory & "\Exports\" & sExcelFileName, True)
    '            ''''FIXfrmEmail.ShowDialog()
    '        Else
    '            Call MsgBox("Error exporting to excel!", MsgBoxStyle.Critical, "Export Grid")
    '        End If
    '    Catch ex As Exception
    '        clsErrorManager.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login, False, True)
    '    End Try

    'End Sub
    'Public Function ExportiGridtoExcel(ByVal igGrid As iGrid, ByVal bIncludeHiddenColumns As Boolean, Optional ByVal myTitle As String = "") As String
    '    Dim i As Integer = 0
    '    Dim j As Integer = 0

    '    Try
    '        Dim iFileNumber As Integer = FreeFile()
    '        Dim sFileName = Login.UserName & "-GridExport.csv"
    '        File.Delete(ReportDirectory & "\Exports\" & sFileName)
    '        FileOpen(iFileNumber, ReportDirectory & "\Exports\" & sFileName, OpenMode.Output)

    '        ' Get Header
    '        Dim sHeader As String = ""
    '        For i = 0 To igGrid.Cols.Count - 1
    '            If bIncludeHiddenColumns = True Or (bIncludeHiddenColumns = False And igGrid.Cols.Item(i).Visible = True) Then
    '                If sHeader.Length > 0 Then
    '                    sHeader = sHeader & ","
    '                End If
    '                sHeader = sHeader & vbQuote & igGrid.Header.Cells(0, i).Value & vbQuote
    '            End If

    '        Next
    '        Print(iFileNumber, sHeader & vbCrLf)

    '        Dim sColumn As String = ""

    '        If igGrid.Rows.Count > 0 Then
    '            ' Loop Results
    '            For i = 0 To igGrid.Rows.Count - 1
    '                If igGrid.Rows(i).Visible = True Then
    '                    If igGrid.Rows(i).Type = iGRowType.Normal Then
    '                        Dim sRow As String = ""
    '                        ' Loop Fields
    '                        For j = 0 To igGrid.Cols.Count - 1
    '                            If bIncludeHiddenColumns = True Or (bIncludeHiddenColumns = False And igGrid.Cols.Item(j).Visible = True) Then
    '                                If sRow.Length > 0 Then
    '                                    sRow = sRow & ","
    '                                End If
    '                                Try
    '                                    sRow = sRow & vbQuote & igGrid.Cells(i, j).Value.ToString() & "" & vbQuote
    '                                Catch
    '                                    sRow = sRow & vbQuote & "" & "" & vbQuote
    '                                Finally
    '                                End Try
    '                            End If
    '                        Next
    '                        Print(iFileNumber, sRow & vbCrLf)
    '                    End If
    '                End If
    '            Next
    '        End If


    '        FileClose(iFileNumber)

    '        Return sFileName

    '    Catch ex As Exception
    '        clsErrorManager.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login, False, True)
    '        Return ""
    '    End Try
    'End Function

    'Public Function CopyIGrid2Clipboard(ByVal igGrid As iGrid, ByVal bIncludeHiddenColumns As Boolean) As Boolean
    '    Dim i As Integer = 0
    '    Dim j As Integer = 0
    '    Dim myString As String = ""
    '    CopyIGrid2Clipboard = True
    '    Try
    '        Cursor.Current = Cursors.WaitCursor
    '        ' Get Header
    '        Dim sHeader As String = ""
    '        For i = 0 To igGrid.Cols.Count - 1
    '            If bIncludeHiddenColumns = True Or (bIncludeHiddenColumns = False And igGrid.Cols.Item(i).Visible = True) Then
    '                If sHeader.Length > 0 Then
    '                    sHeader = sHeader & vbTab
    '                End If
    '                sHeader = sHeader & vbQuote & igGrid.Header.Cells(0, i).Value & vbQuote
    '            End If

    '        Next
    '        myString = sHeader & vbCrLf
    '        '            Print(iFileNumber, sHeader & vbCrLf)

    '        Dim sColumn As String = ""

    '        If igGrid.Rows.Count > 0 Then
    '            ' Loop Results
    '            For i = 0 To igGrid.Rows.Count - 1
    '                If igGrid.Rows(i).Visible = True Then
    '                    If igGrid.Rows(i).Type = iGRowType.Normal Then
    '                        Dim sRow As String = ""
    '                        ' Loop Fields
    '                        For j = 0 To igGrid.Cols.Count - 1
    '                            If bIncludeHiddenColumns = True Or (bIncludeHiddenColumns = False And igGrid.Cols.Item(j).Visible = True) Then
    '                                If sRow.Length > 0 Then
    '                                    sRow = sRow & vbTab
    '                                End If
    '                                Try
    '                                    sRow = sRow & vbQuote & igGrid.Cells(i, j).Value.ToString() & "" & vbQuote
    '                                Catch
    '                                    sRow = sRow & vbQuote & "" & "" & vbQuote
    '                                Finally
    '                                End Try
    '                            End If
    '                        Next
    '                        myString = myString & sRow & vbCrLf
    '                        'Print(iFileNumber, sRow & vbCrLf)
    '                    End If
    '                End If
    '            Next
    '        End If
    '        Clipboard.SetDataObject(myString.ToString, True)
    '        MsgBox("Grid has been copied to your clipboard")
    '    Catch ex As Exception


    '        clsErrorManager.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login, False, True)
    '        CopyIGrid2Clipboard = False
    '    Finally
    '        Cursor.Current = Cursors.Default

    '    End Try

    'End Function



    Public Function USButton(ByVal myName As String, ByVal myVisible As Boolean, ByVal myFrozen As Boolean) As String
        USButton = ""
        Try
            USButton = "Button," & myName & "," & myVisible & "," & myFrozen & "|"
        Catch ex As Exception
            clsErrorManager.WriteErrorLog("mdlUSGrids", "USButton", "", ex, Login)
        End Try

    End Function

    Public Function USTextBox(ByVal myName As String, ByVal myReadOnly As Boolean, ByVal myVisible As Boolean, ByVal myWidth As Int16, ByVal myMaxInputLength As Int16, ByVal myFrozen As Boolean, Optional ByVal myFormat As String = "", Optional ByVal myAlignment As DataGridViewContentAlignment = DataGridViewContentAlignment.BottomLeft) As String
        USTextBox = ""
        Try
            USTextBox = "TextBox," & myName & "," & myReadOnly & "," & myVisible & "," & myWidth & "," & myMaxInputLength & "," & myFrozen & "," & myFormat & "," & myAlignment & "|"
        Catch ex As Exception
            clsErrorManager.WriteErrorLog("mdlUSGrids", "USTextBox", "", ex, Login)
        End Try

    End Function
    Public Function USCheckBox(ByVal myName As String, ByVal myReadOnly As Boolean, ByVal myWidth As Int16, ByVal myFrozen As Boolean) As String
        USCheckBox = ""
        Try
            USCheckBox = "CheckBox," & myName & "," & myReadOnly & "," & myWidth & "," & myFrozen & "|"
        Catch ex As Exception
            clsErrorManager.WriteErrorLog("mdlUSGrids", "USCheckbox", "", ex, Login)
        End Try

    End Function


    Public Sub USaddDGVCombobox(ByVal dgv As DataGridView, ByVal sName As String, ByVal aItems() As String, ByVal iWidth As Integer, ByVal bFrozen As Boolean)
        Dim col As New DataGridViewComboBoxColumn()
        Try
            col.HeaderText = sName
            col.Name = sName
            col.ReadOnly = False
            col.Visible = True
            col.Frozen = bFrozen
            col.Width = iWidth
            Dim i As Integer
            ' Add items
            For i = 0 To aItems.Length - 1
                col.Items.Add(aItems(i))
            Next
            col.SortMode = DataGridViewColumnSortMode.NotSortable
            dgv.Columns.Add(col)
        Catch ex As Exception
            clsErrorManager.WriteErrorLog("mdlUSGrids", "USaddDGCComboBox", "", ex, Login)
        End Try
    End Sub
    Public Sub USaddDGVCheckBox(ByVal dgv As DataGridView, ByVal sName As String, ByVal bReadOnly As Boolean, ByVal iWidth As Integer, ByVal bFrozen As Boolean)
        Dim col As New DataGridViewCheckBoxColumn
        Try
            col.HeaderText = sName
            col.Name = sName
            col.Frozen = bFrozen
            col.ReadOnly = bReadOnly '
            col.Width = iWidth

            dgv.Columns.Add(col)
        Catch ex As Exception
            clsErrorManager.WriteErrorLog("mdlUSGrids", "USaddDGVCheckox", "", ex, Login)
        End Try
    End Sub
    Public Sub USaddDGVButton(ByVal dgv As DataGridView, ByVal sName As String, ByVal bVisible As Boolean, ByVal bFrozen As Boolean)
        Dim col As New DataGridViewButtonColumn
        Try
            col.HeaderText = sName
            col.Name = sName
            col.Text = sName
            col.Frozen = bFrozen
            col.Visible = bVisible
            col.UseColumnTextForButtonValue = True
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            col.FlatStyle = FlatStyle.Standard
            col.CellTemplate.Style.BackColor = Color.Honeydew
            col.CellTemplate.Style.SelectionBackColor = Color.Honeydew
            col.CellTemplate.Style.SelectionForeColor = Color.Black


            dgv.Columns.Add(col)
        Catch ex As Exception
            clsErrorManager.WriteErrorLog("mdlUSGrids", "USaddDGVbutton", "", ex, Login)
        End Try
    End Sub

    Public Sub USaddDGVTextBox(ByVal dgv As DataGridView, ByVal sName As String, ByVal bReadOnly As Boolean, ByVal bVisible As Boolean, ByVal iWidth As Integer, ByVal iMaxInputLength As Integer, ByVal bFrozen As Boolean, Optional ByVal sFormat As String = "", Optional ByVal iAlignment As DataGridViewContentAlignment = DataGridViewContentAlignment.BottomLeft)

        Dim col As New DataGridViewTextBoxColumn
        Try
            col.HeaderText = sName
            col.Name = sName
            col.ReadOnly = bReadOnly
            col.Visible = bVisible
            col.Frozen = bFrozen
            col.Width = iWidth
            col.MaxInputLength = iMaxInputLength
            col.DefaultCellStyle.Alignment = iAlignment
            If sFormat > "" Then
                col.DefaultCellStyle.Format = sFormat
            End If
            col.SortMode = DataGridViewColumnSortMode.Automatic

            dgv.Columns.Add(col)
        Catch ex As Exception
            clsErrorManager.WriteErrorLog("mdlUSGrids", "USaddDGVTextBox", "", ex, Login)
        End Try
    End Sub
    'Public Sub USLoadGridColumns(ByVal dgvGrid As DataGridView, ByVal sGridColumns As String, Optional ByVal bColumnsReadOnly As Boolean = False)
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
    '                    Call addDGVCheckBox(dgvGrid, sParameters(1), sParameters(2), sParameters(3), sParameters(4))
    '                Case "TextBox"
    '                    Call USaddDGVTextBox(dgvGrid, sParameters(1), sParameters(2), Convert.ToBoolean(sParameters(3)), sParameters(4), sParameters(5), sParameters(6), sParameters(7), sParameters(8))
    '                Case "Button"
    '                    Call USaddDGVButton(dgvGrid, sParameters(1), sParameters(2), sParameters(3))
    '            End Select

    '        Next i
    '        j = j
    '    Catch ex As Exception
    '        clsErrorManager.WriteErrorLog("mdlUSGrids", System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login)
    '    End Try

    'End Sub
    Public Sub USSaveGridColumnsOrder(ByVal dgvGrid As DataGridView, ByVal sRegForm As String, ByVal sRegKey As String)
        Dim sCustomGridLayout As String = ""
        Dim i As Integer
        Dim k As Integer
        Dim l As Integer
        Try
            With dgvGrid

                For k = 0 To .ColumnCount - 1

                    ' Get Index of Column - Note DisplayIndex is the Order displayed on the screen
                    i = k
                    If k <> dgvGrid.Columns(k).DisplayIndex Then
                        ' Search or new order
                        For l = 0 To .ColumnCount - 1
                            If k = dgvGrid.Columns(l).DisplayIndex Then
                                i = l
                                Exit For
                            End If
                        Next
                    End If


                    'Combobox
                    If InStr(1, dgvGrid.Columns(i).ToString, "DataGridViewComboBoxColumn", 1) > 0 Then
                        sCustomGridLayout = sCustomGridLayout & "ComboBox,"
                        sCustomGridLayout = sCustomGridLayout & dgvGrid.Columns(i).Name & ","
                        '  Get Items
                        Dim cItems As DataGridViewComboBoxColumn
                        cItems = dgvGrid.Columns(i).Clone
                        Dim j As Integer
                        For j = 0 To cItems.Items.Count - 1
                            sCustomGridLayout = sCustomGridLayout & cItems.Items(j).ToString() & "~"
                        Next
                        sCustomGridLayout = sCustomGridLayout & ","
                        sCustomGridLayout = sCustomGridLayout & CStr(dgvGrid.Columns(i).Width) & ","
                        sCustomGridLayout = sCustomGridLayout & CStr(dgvGrid.Columns(i).Frozen) & "|"
                    End If


                    If InStr(1, dgvGrid.Columns(i).ToString, "DataGridViewTextBoxColumn", 1) > 0 Then
                        sCustomGridLayout = sCustomGridLayout & "TextBox,"
                        sCustomGridLayout = sCustomGridLayout & dgvGrid.Columns(i).Name & ","
                        sCustomGridLayout = sCustomGridLayout & CStr(dgvGrid.Columns(i).ReadOnly) & ","
                        sCustomGridLayout = sCustomGridLayout & CStr(dgvGrid.Columns(i).Visible) & ","
                        sCustomGridLayout = sCustomGridLayout & CStr(dgvGrid.Columns(i).Width) & ","
                        Dim cText As DataGridViewTextBoxColumn
                        cText = dgvGrid.Columns(i).Clone
                        sCustomGridLayout = sCustomGridLayout & CStr(cText.MaxInputLength) & ","
                        sCustomGridLayout = sCustomGridLayout & CStr(dgvGrid.Columns(i).Frozen) & ","
                        sCustomGridLayout = sCustomGridLayout & CStr(cText.DefaultCellStyle.Format) & ","
                        sCustomGridLayout = sCustomGridLayout & CStr(cText.DefaultCellStyle.Alignment) & "|"



                        '"#######0", DataGridViewContentAlignment.BottomRight

                    End If


                    If InStr(1, dgvGrid.Columns(i).ToString, "DataGridViewbuttonColumn", 1) > 0 Then
                        sCustomGridLayout = sCustomGridLayout & "Button,"
                        sCustomGridLayout = sCustomGridLayout & dgvGrid.Columns(i).Name & ","
                        sCustomGridLayout = sCustomGridLayout & CStr(dgvGrid.Columns(i).Visible) & ","
                        sCustomGridLayout = sCustomGridLayout & CStr(dgvGrid.Columns(i).Frozen) & "|"


                        '.HeaderText = "Sales"
                        '.Text = "Sales"
                        '.UseColumnTextForButtonValue = True
                        '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        '.FlatStyle = FlatStyle.Standard
                        '.CellTemplate.Style.BackColor = Color.Honeydew
                        '.DisplayIndex = 0


                    End If



                    If InStr(1, dgvGrid.Columns(i).ToString, "DataGridViewCheckBoxColumn", 1) > 0 Then
                        sCustomGridLayout = sCustomGridLayout & "CheckBox,"
                        sCustomGridLayout = sCustomGridLayout & dgvGrid.Columns(i).Name & ","
                        sCustomGridLayout = sCustomGridLayout & CStr(dgvGrid.Columns(i).ReadOnly) & ","
                        sCustomGridLayout = sCustomGridLayout & CStr(dgvGrid.Columns(i).Width) & ","
                        sCustomGridLayout = sCustomGridLayout & CStr(dgvGrid.Columns(i).Frozen) & "|"

                    End If
                    '        tempfield = .Rows(.CurrentRow.Index).Cells(i).Value
                Next
            End With

            gReg.SaveSetting(Login, sAppName, sRegForm, sRegKey, sCustomGridLayout)
        Catch ex As Exception
            clsErrorManager.WriteErrorLog("mdlUSGrids", "USSaveGridColumnsOrder", "", ex, Login)
        End Try
    End Sub
    Public Function GetGridLayout(ByVal RetrievedRegistryLayout As String) As String
        GetGridLayout = RetrievedRegistryLayout
        Try
            If System.Windows.Forms.Control.ModifierKeys = Keys.Shift Then
                GetGridLayout = ""
            Else
                GetGridLayout = RetrievedRegistryLayout
            End If
        Catch ex As Exception
            clsErrorManager.WriteErrorLog("mdlUSGrids", "GetGridLayout", "", ex, Login, False, False)
        End Try
    End Function
    'Public Sub SetGridColors(ByRef myIGrid As iGrid)
    '    With myIGrid
    '        .Header.ForeColor = Color.Black
    '        .Header.BackColor = Color.LightGray
    '        .GroupBox.BackColor = Color.LightGray
    '        .GroupBox.HintBackColor = Color.LightGray
    '        .GroupBox.HintForeColor = Color.DarkGray
    '        .GroupRowLevelStyles(0).ForeColor = Color.Black
    '        .GroupRowLevelStyles(0).BackColor = Color.Yellow

    '        iGSubtotalManager.ForeColor = Color.Black
    '        iGSubtotalManager.BackColor = Color.LightGreen

    '        .BackColor = Color.White
    '        .ForeColor = Color.Black


    '        HideGridCost(myIGrid)
    '    End With

    'End Sub
    'Public Sub SetLayoutFlagsToGrid(ByRef myiGrid As iGrid)

    '    Dim myFlags As iGLayoutFlags = 0
    '    Try
    '        myFlags = myFlags Or iGLayoutFlags.ColVisibility
    '        myFlags = myFlags Or iGLayoutFlags.ColOrder
    '        myFlags = myFlags Or iGLayoutFlags.ColWidth
    '        myFlags = myFlags Or iGLayoutFlags.Grouping
    '        myFlags = myFlags Or iGLayoutFlags.Sorting
    '        myiGrid.LayoutObject.Flags = myFlags
    '    Catch ex As Exception
    '        clsErrorManager.WriteErrorLog("mdlUSGrids", " SetLayoutFlagsToGrid", "", ex, Login, False, False)
    '    End Try

    'End Sub
    'Public Sub PrintIGrid(ByRef myIGPrintManager As TenTec.Windows.iGridLib.Printing.iGPrintManager, ByVal myCurrentForm As Form, ByVal myIgridToPrint As iGrid)
    '    Try
    '        With myIGPrintManager
    '            .Grid = myIgridToPrint

    '            .PageHeader.MiddleSection.Text = myCurrentForm.Text
    '            .PageHeader.MiddleSection.Font = New Font("Times", 18.0F)

    '            .PageFooter.MiddleSection.Text = "- Page %[PageNumber] of %[PageCount] -"
    '            .PageFooter.MiddleSection.Font = New Font("Times", 10.0F)

    '            .PageFooter.LeftSection.Text = DateTime.Now.ToString
    '            .PageFooter.LeftSection.Font = New Font("Times", 10.0F)

    '            .Document.DefaultPageSettings.Landscape = True
    '            .PrintGroupBox = Printing.iGPrintGroupBox.OnFirstPage

    '            .ForceExpandGroups = False
    '            'rrr added this line 1-17-07
    '            .PrintOrder = Printing.iGPrintOrder.DownRight


    '            .PrintPreview()
    '        End With
    '    Catch ex As Exception
    '        clsErrorManager.WriteErrorLog("mdlUSGrids", System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login)
    '    End Try

    'End Sub
    'Public Sub SaveOrClearGridLayout(ByVal myForm As Form, ByVal myGrid As iGrid, ByVal myClearIt As Boolean)
    '    Try
    '        SetLayoutFlagsToGrid(myGrid)
    '        ' Save layout if f9 or remove saved layout if shift-f9
    '        If myClearIt = True Then
    '            gReg.SaveSetting(Login, Login.ExeName, myForm.Name, myGrid.Name, "")
    '        Else
    '            gReg.SaveSetting(Login, Login.ExeName, myForm.Name, myGrid.Name, myGrid.LayoutObject.Text)
    '        End If
    '        myGrid.Enabled = True
    '    Catch ex As Exception
    '        clsErrorManager.WriteErrorLog("mdlUSGrids", System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login)
    '    End Try

    'End Sub
    'Public Sub ShowGridToolTipEnter(ByRef iGrid1 As iGrid, ByVal e As TenTec.Windows.iGridLib.iGCellMouseEnterLeaveEventArgs, ByVal fToolTip As ToolTip)
    '    'rrr Added 1-17-07

    '    Dim myText As String = iGrid1.Cells(e.RowIndex, e.ColIndex).Text
    '    Dim myGraphics As Graphics = iGrid1.CreateGraphics()
    '    Dim mySize As SizeF = myGraphics.MeasureString(myText, iGrid1.Font)
    '    Try
    '        If mySize.Width > iGrid1.Cells(e.RowIndex, e.ColIndex).TextBounds.Width Then
    '            fToolTip.SetToolTip(iGrid1, myText)
    '        Else
    '            fToolTip.SetToolTip(iGrid1, Nothing)
    '        End If
    '        myGraphics.Dispose()
    '    Catch ex As Exception
    '        clsErrorManager.WriteErrorLog("mdlUSGrids", System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login)
    '    End Try

    'End Sub
    'Public Sub ShowGridToolTipLeave(ByRef iGrid1 As iGrid, ByVal e As TenTec.Windows.iGridLib.iGCellMouseEnterLeaveEventArgs, ByVal fToolTip As ToolTip)
    '    'rrr Added 1-17-07
    '    Try
    '        fToolTip.SetToolTip(iGrid1, Nothing)
    '    Catch ex As Exception
    '        clsErrorManager.WriteErrorLog("mdlUSGrids", System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login)
    '    End Try
    'End Sub





    'Public Sub FilterTextChanged(ByRef IGrid1 As iGrid, ByVal mySearchText As String, Optional ByVal myMaxColumns As Integer = 0)
    '    ', Optional ByVal myCols2Search() As String = Nothing
    '    ' Rick Added this subroutine to FeedSys on 3-28-07, Used to filter grids searching for text in all columns unless maxColumns is set.
    '    ' If MaxColumns is set, it searches that # of rows from the left of the grid only
    '    Dim myTextFoundInRow As Boolean = False
    '    Try
    '        IGrid1.BeginUpdate()
    '        Dim myText As String = UCase(mySearchText)

    '        For r As Integer = IGrid1.Rows.Count - 1 To 0 Step -1 'Step thru each row
    '            If IGrid1.Rows(r).Type = iGRowType.Normal Then  'Only normal rows
    '                myTextFoundInRow = False
    '                For c As Integer = 0 To IIf(myMaxColumns = 0, IGrid1.Cols.Count - 1, myMaxColumns - 1) Step 1  'Step thru each column
    '                    IGrid1.Cells(r, c).BackColor = Color.White
    '                    If IGrid1.Cols(c).Visible = True Then  'Check only visible columns
    '                        If IGrid1.Cells(r, c).Text.Trim.Length > 0 Then 'Ignore blank cells
    '                            If IGrid1.Cells(r, c).Type = iGCellType.NotSet Then 'check only text box cells
    '                                If DirectCast(UCase(IGrid1.Cells(r, c).Value), String).IndexOf(myText) >= 0 Then
    '                                    myTextFoundInRow = True
    '                                    IGrid1.Cells(r, c).BackColor = Color.WhiteSmoke
    '                                End If
    '                            End If
    '                        End If
    '                    End If
    '                Next
    '                If myTextFoundInRow Or Strings.Len(myText.Trim) = 0 Then
    '                    IGrid1.Rows(r).Visible = True
    '                Else
    '                    IGrid1.Rows(r).Visible = False
    '                End If
    '            End If
    '        Next

    '    Catch ex As Exception
    '        clsErrorManager.WriteErrorLog("mdlUSGrids", System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login)
    '    Finally
    '        IGrid1.EndUpdate()
    '    End Try
    'End Sub

    Public Sub ExportDataGridView(ByVal tmpGrid As DataGridView)
        Try
            Dim sExcelFileName As String = ExportDataGridViewtoExcel(tmpGrid)
            If sExcelFileName.Length > 0 Then
                ' Email
                ''''FIXCall frmEmail.LoadReportInfo(sExcelFileName, ReportDirectory & "\Exports\" & sExcelFileName, True)
                ''''FIXfrmEmail.ShowDialog()
            Else
                Call MsgBox("Error exporting to excel!", MsgBoxStyle.Critical, "Export Grid")
            End If
        Catch ex As Exception
            clsErrorManager.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login, False, True)
        End Try
    End Sub
    Public Function ExportDataGridViewtoExcel(ByVal tmpGrid As DataGridView) As String
        Dim i As Integer = 0
        Dim j As Integer = 0
        Try
            Dim iFileNumber As Integer = FreeFile()
            Dim sFileName = Login.UserName & "-GridExport.csv"

            File.Delete(ReportDirectory & "\Exports\" & sFileName)
            FileOpen(iFileNumber, ReportDirectory & "\Exports\" & sFileName, OpenMode.Output)

            Dim sHeader As String = ""
            For i = 0 To tmpGrid.Columns.Count - 1
                If sHeader.Length > 0 Then
                    sHeader = sHeader & ","
                End If
                sHeader = sHeader & vbQuote & tmpGrid.Columns(i).HeaderText() & vbQuote
            Next
            Print(iFileNumber, sHeader & vbCrLf)

            Dim sColumn As String = ""
            For i = 0 To tmpGrid.Rows.Count - 1
                sColumn = ""
                For j = 0 To tmpGrid.Columns.Count - 1
                    If sColumn.Length > 0 Then
                        sColumn = sColumn & ","
                    End If
                    sColumn = sColumn & vbQuote & tmpGrid(j, i).Value.ToString & vbQuote
                Next
                Print(iFileNumber, sColumn & vbCrLf)
            Next
            FileClose(iFileNumber)

            Return sFileName

        Catch ex As Exception
            clsErrorManager.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login, False, True)
            Return ""
        End Try
    End Function

    'Sub HideGridCost(ByRef myIgrid As iGrid)
    '    Dim myCol As iGCol
    '    'On Error Resume Next
    '    If gSecurity.UserHasPermissions("AllowedToSeeCost") <> True Then
    '        'myIgrid.Cols("CostLastPurchase").Visible = False
    '        'myIgrid.Cols("ReplacementQuote").Visible = False
    '        'myIgrid.Cols("AvgCost").Visible = False
    '        'myIgrid.Cols("UnitCost").Visible = False
    '        'myIgrid.Cols("AvgCostAfter").Visible = False
    '        'myIgrid.Cols("Cost").Visible = False

    '        On Error Resume Next
    '        'background color
    '        For Each myCol In myIgrid.Cols
    '            If InStr(myCol.Key.ToLower, "cost", CompareMethod.Text) > 0 _
    '              Or Strings.Left(myCol.Key.ToLower, 3) = "ap_" _
    '              Or InStr(myCol.Key.ToLower, "replacementquote", CompareMethod.Text) > 0 Then
    '                myCol.Visible = False
    '                '                    myCol.CellStyle.BackColor = Color.Black
    '                '                    myCol.CellStyle.ForeColor = Color.Black

    '            End If
    '        Next
    '        'myIgrid.Cols("CostLastPurchase").CellStyle.BackColor = Color.AntiqueWhite
    '        'myIgrid.Cols("ReplacementQuote").CellStyle.BackColor = Color.AntiqueWhite
    '        'myIgrid.Cols("AvgCost").CellStyle.BackColor = Color.AntiqueWhite
    '        'myIgrid.Cols("UnitCost").CellStyle.BackColor = Color.AntiqueWhite
    '        'myIgrid.Cols("AvgCostAfter").CellStyle.BackColor = Color.AntiqueWhite
    '        'myIgrid.Cols("Cost").CellStyle.BackColor = Color.AntiqueWhite
    '        'myIgrid.Cols("CostExtension").CellStyle.BackColor = Color.AntiqueWhite
    '        'myIgrid.Cols("replacementquote").CellStyle.BackColor = Color.AntiqueWhite
    '        ''foreground color
    '        'myIgrid.Cols("CostLastPurchase").CellStyle.ForeColor = Color.AntiqueWhite
    '        'myIgrid.Cols("ReplacementQuote").CellStyle.ForeColor = Color.AntiqueWhite
    '        'myIgrid.Cols("AvgCost").CellStyle.ForeColor = Color.AntiqueWhite
    '        'myIgrid.Cols("UnitCost").CellStyle.ForeColor = Color.AntiqueWhite
    '        'myIgrid.Cols("AvgCostAfter").CellStyle.ForeColor = Color.AntiqueWhite
    '        'myIgrid.Cols("Cost").CellStyle.ForeColor = Color.AntiqueWhite
    '        'myIgrid.Cols("CostExtension").CellStyle.ForeColor = Color.AntiqueWhite
    '        'myIgrid.Cols("replacementquote").CellStyle.ForeColor = Color.AntiqueWhite




    '    End If
    'End Sub
    'Public Sub SetIGridLayoutFull(ByRef tmpGrid As iGrid)
    '    Dim myFlags As iGLayoutFlags = 0
    '    myFlags = myFlags Or iGLayoutFlags.ColVisibility
    '    myFlags = myFlags Or iGLayoutFlags.ColOrder
    '    myFlags = myFlags Or iGLayoutFlags.ColWidth
    '    myFlags = myFlags Or iGLayoutFlags.Grouping
    '    myFlags = myFlags Or iGLayoutFlags.Sorting
    '    tmpGrid.LayoutObject.Flags = myFlags
    'End Sub

    'Public Sub ReadOnlyIGridColumns(ByRef tmpGrid As iGrid, Optional ByVal sNotLockedList As String = "")
    '    Dim i As Integer = 0
    '    Try
    '        For i = 0 To tmpGrid.Cols.Count - 1
    '            ' Dim s As String = tmpGrid.Cols.Item(i).Text
    '            If InStr(1, sNotLockedList, tmpGrid.Cols.Item(i).Text, 1) = 0 Then
    '                tmpGrid.Cols.Item(i).CellStyle.ReadOnly = iGBool.True
    '            Else

    '                tmpGrid.Cols.Item(i).CellStyle.ReadOnly = iGBool.False
    '            End If
    '        Next
    '    Catch ex As Exception
    '        clsErrorManager.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login, False, True)

    '    End Try
    'End Sub
    ' Make a ListView row.
    Public Sub ListViewMakeRow(ByVal lvw As ListView, ByVal _
        item_title As String, ByVal ParamArray subitem_titles() _
        As String)


        Try
            ' Make the item.
            Dim new_item As ListViewItem = lvw.Items.Add(item_title)

            ' Make the sub-items.
            For i As Integer = subitem_titles.GetLowerBound(0) To _
                subitem_titles.GetUpperBound(0)
                new_item.SubItems.Add(subitem_titles(i))
            Next i

        Catch ex As Exception
            clsErrorManager.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login, False, True)
        End Try
    End Sub
    ' Used in USReports Form for Customer Tooltips
    'Public Sub ShowGridToolTipEnter(ByRef iGrid1 As iGrid, ByVal e As TenTec.Windows.iGridLib.iGCellMouseEnterLeaveEventArgs, ByVal fToolTip As ToolTip, ByVal myToolTipText As String, ByVal sToolTipTitle As String)
    '    'rrr Added 1-17-07

    '    '  Dim myText As String = iGrid1.Cells(e.RowIndex, e.ColIndex).Text
    '    Dim myGraphics As Graphics = iGrid1.CreateGraphics()
    '    Dim mySize As SizeF = myGraphics.MeasureString(myToolTipText, iGrid1.Font)
    '    Try
    '        '  If mySize.Width > iGrid1.Cells(e.RowIndex, e.ColIndex).TextBounds.Width Then
    '        fToolTip.ToolTipTitle = sToolTipTitle
    '        fToolTip.SetToolTip(iGrid1, myToolTipText)
    '        '   Else
    '        '       fToolTip.SetToolTip(iGrid1, Nothing)
    '        '  End If
    '        myGraphics.Dispose()
    '    Catch ex As Exception
    '        clsErrorManager.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login, False, True)
    '    End Try

    'End Sub

End Module

