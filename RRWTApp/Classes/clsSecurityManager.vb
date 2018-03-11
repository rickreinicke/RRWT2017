Imports System.Data.SQLite
Public Class clsSecurityManager
    Private arrEnabled As New ArrayList()
    Private arrDisabled As New ArrayList()
    Private arrReports As New ArrayList()
    Private mcLogin As clsLoginManager

    ' Used in Loading Menu
    Private MenuName As New ArrayList()
    Private MenuTrueName As New ArrayList()
    Private MenuLevel As New ArrayList()
    Private MenuSort As New ArrayList()
    Private iMenuCounter As Integer = 0



    Public Sub LoadUser(ByVal Login As clsLoginManager)
        mcLogin = Login
        Call LoadReportPermissions()
        Call LoadPermissions()
    End Sub
    ' This section is used to set the Menu Security
    ' Note:  This needs to be on the form which it
    '        will control, because otherwise doesn't work

    Public Sub SetPermissions(ByRef tmpMenu As MenuStrip)
        Try

            Call ApplyPermissions(tmpMenu)

        Catch ex As Exception
            clsErrorManager.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login, False, True)
        End Try
    End Sub
    Private Sub ApplyPermissions(ByRef tmpMenu As MenuStrip)
        Dim i As Integer
        Try

            If arrEnabled.Count > 0 Then
                For i = 0 To arrEnabled.Count - 1
                    SetMenuItem(tmpMenu, arrEnabled(i), True)
                Next
            End If
            If arrDisabled.Count > 0 Then
                For i = 0 To arrDisabled.Count - 1
                    SetMenuItem(tmpMenu, arrDisabled(i), False)
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadPermissions()
        Dim sSQL As String = ""
        Dim msConn As New clsDataManager
        Dim Dr As SQLiteDataReader = Nothing

        Try
            arrEnabled.Clear()
            arrDisabled.Clear()
            msConn.OpenDB(Login.DBServer, Login.Database, Login.DatabaseUser, Login.DatabasePass)

            sSQL = "Select * from US_security2 where appname='" & mcLogin.ExeName & "' and upper(username)='" & mcLogin.UserName.ToUpper & "'"

            Dr = msConn.QueryDB(sSQL)
            Do While Dr.Read()
                If Convert.ToBoolean(Dr("Allowed")) = True Then
                    arrEnabled.Add(Dr("formtruename"))
                Else
                    arrDisabled.Add(Dr("formtruename"))
                End If
            Loop

        Catch ex As Exception
            clsErrorManager.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login, False, True)

        Finally
            msConn.CloseReader(Dr)
            msConn.CloseDB()
        End Try
    End Sub

    Public Function SetMenuItem(ByRef tmpMenu As MenuStrip, ByVal name As String, ByVal enabled As Boolean) As Boolean

        Dim m As ToolStripMenuItem
        Try
            m = Me.FindToolStripMenuItem(tmpMenu.Items, name)
            If m IsNot Nothing Then
                m.Enabled = enabled
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            clsErrorManager.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login, False, True)
            Return False
        End Try
    End Function



    Private Function FindToolStripMenuItem(ByRef menus As ToolStripItemCollection, ByVal name As String) As ToolStripMenuItem

        Dim found As Boolean = False
        Dim t, temp As ToolStripMenuItem

        t = menus(name)
        If t Is Nothing Then
            Dim i As Integer = 0
            While Not found And i < menus.Count
                If menus(i).GetType Is GetType(ToolStripMenuItem) Then
                    temp = menus(i)
                    t = Me.FindToolStripMenuItem(temp.DropDownItems, name)
                    found = (t IsNot Nothing)
                End If
                i += 1
            End While
        End If
        Return t

    End Function
    Public Function UserHasReportPermissions(ByVal sReportName) As Boolean
        Dim bFlag As Boolean = False

        Try
            If Me.arrReports.Contains(sReportName) = True Then
                bFlag = True
            End If
            Return bFlag
        Catch ex As Exception
            clsErrorManager.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login, False, True)
            Return False
        End Try
    End Function
    Public Function UserHasPermissions(ByVal sMenuItemName) As Boolean
        Dim bFlag As Boolean = False

        Try
            If Me.arrEnabled.Contains(sMenuItemName & "ToolStripMenuItem") = True Then
                bFlag = True
            End If
            Return bFlag
        Catch ex As Exception
            clsErrorManager.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login, False, True)
            Return False
        End Try
    End Function

    Private Sub LoadReportPermissions()
        Dim sSQL As String = ""
        Dim msConn As New clsDataManager
        Dim Dr As SQLiteDataReader = Nothing

        Try
            arrReports.Clear()

            msConn.OpenDB(Login.DBServer, Login.Database, Login.DatabaseUser, Login.DatabasePass)

            sSQL = "Select * from US_security2 where appname='" & Login.ExeName & "' and upper(username)='" & mcLogin.UserName.ToUpper & "' and MenuSortOrder like 'ACCESS-R-%'"

            Dr = msConn.QueryDB(sSQL)
            Do While Dr.Read()
                If Convert.ToBoolean(Dr("Allowed")) = True Then

                    arrReports.Add(Dr("formtruename").ToString)
                End If
            Loop

        Catch ex As Exception
            clsErrorManager.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login, False, True)

        Finally
            msConn.CloseReader(Dr)
            msConn.CloseDB()
        End Try
    End Sub

    Public Sub LoadMenuItems(ByRef tmpMenu As MenuStrip)
        Dim iHeaderMenuCount As Integer = 0

        Try
            ' Report Pattern
            ReportFilePattern = "???-*.rpt"
            ' Clear Arrays
            MenuName.Clear()
            MenuTrueName.Clear()
            MenuLevel.Clear()
            MenuSort.Clear()
            iMenuCounter = 0

            ' Add Top level Menu Items
            For Each menu As ToolStripMenuItem In tmpMenu.Items
                MenuName.Add(menu.Text)
                MenuTrueName.Add(menu.Name)
                MenuLevel.Add(1)
                iHeaderMenuCount = iHeaderMenuCount + 1
                iMenuCounter = 1
                MenuSort.Add("ACCESS-M-" & Format(iHeaderMenuCount, "000") & "-" & Format(iMenuCounter, "000") & menu.Text)
                ' Add Submenus
                Call AddSubMenus(iHeaderMenuCount, 1, menu)
            Next menu

            ' Read Report file List
            Dim di As New IO.DirectoryInfo(ReportDirectory)
            Dim diar1 As IO.FileInfo() = di.GetFiles(ReportFilePattern)
            Dim dra As IO.FileInfo
            For Each dra In diar1
                ' Add Report
                MenuName.Add(dra.ToString)
                MenuTrueName.Add(dra.ToString)
                MenuLevel.Add(9999)
                iMenuCounter = iMenuCounter + 1
                MenuSort.Add("ACCESS-R-" & Format(1, "000") & "-" & Format(iMenuCounter, "000") & dra.ToString)
            Next
        Catch ex As Exception
            clsErrorManager.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login, False, True)
        End Try
    End Sub
    Private Sub AddSubMenus(ByVal HeaderLevel As Integer, ByVal level As Integer, ByVal subitems As ToolStripMenuItem)
        Try
            For Each child As ToolStripMenuItem In subitems.DropDownItems
                ' If child.Visible = True Then  ' Note always false if submenu, for some reason

                ' Add sub menu item
                MenuName.Add(child.Text)
                MenuTrueName.Add(child.Name)
                MenuLevel.Add(level + 1)
                iMenuCounter = iMenuCounter + 1
                MenuSort.Add("ACCESS-M-" & Format(HeaderLevel, "000") & "-" & Format(iMenuCounter, "000") & child.Text)

                ' Note: Recursive call - to get further submenus
                Call AddSubMenus(HeaderLevel, level + 1, child)
            Next child
        Catch ex As Exception
            clsErrorManager.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, "", ex, Login, False, True)
        End Try
    End Sub
    Public ReadOnly Property GetMenuItemCount()
        Get
            Return MenuName.Count
        End Get
    End Property
    Public ReadOnly Property GetMenuName(ByVal iValue As Integer)
        Get
            Return MenuName(iValue)
        End Get
    End Property
    Public ReadOnly Property GetMenuTrueName(ByVal iValue As Integer)
        Get
            Return MenuTrueName(iValue)
        End Get
    End Property

    Public ReadOnly Property GetMenuLevel(ByVal iValue As Integer)
        Get
            Return MenuLevel(iValue)
        End Get
    End Property

    Public ReadOnly Property GetMenuSort(ByVal iValue As Integer)
        Get
            Return MenuSort(iValue)
        End Get
    End Property

End Class
