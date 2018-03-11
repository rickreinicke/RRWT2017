Imports System.Data
Imports System.Data.SQLite


Public Class clsRegistryManager

    Private msConn As New clsDataManager

    ' US Get Setting
    '===============
    Public Function GetSetting(ByVal Login As clsLoginManager, ByVal AppName As String, ByVal Section As String, ByVal Key As String, Optional ByVal oDefault As Object = "") As String
        Dim sDefault As String
        GetSetting = ""
        Try


            ' Check Default
            If Len(oDefault) = 0 Then
                sDefault = ""
            Else
                sDefault = CStr(oDefault)
            End If

            ' Get Setting from Table
            GetSetting = ReadTableValue(Login, AppName, Section, Key, sDefault)

        Catch ex As Exception
            clsErrorManager.WriteErrorLog("clsRegistryManager", "GetSetting", "", ex, Login)
        Finally

        End Try

    End Function

    Private Function ReadTableValue(ByVal Login As clsLoginManager, ByVal AppName As String, ByVal Section As String, ByVal Key As String, Optional ByVal sDefault As String = "") As String
        Dim sSql As String
        Dim drSetting As SqlITEDataReader = Nothing

        ReadTableValue = ""
        Try

            ReadTableValue = sDefault


            ' Get Connection, if none exists
            Call SetConnection(Login)

            ' Read record
            sSql = "Select "
            sSql = sSql & "Setting "
            sSql = sSql & "from "
            sSql = sSql & "USRegistry  "
            sSql = sSql & "Where "
            sSql = sSql & "UserName = '" & Login.NetworkLogin & "' and "
            sSql = sSql & "AppName = '" & AppName & "' and "
            sSql = sSql & "SettingSection = '" & Section & "' and "
            sSql = sSql & "SettingKey = '" & Key & "'"

            msConn.OpenDB(Login.DBServer, Login.Database, Login.DatabaseUser, Login.DatabasePass)
            drSetting = msConn.QueryDB(sSql)

            ' Get Value
            If drSetting.Read = True Then
                ReadTableValue = drSetting("Setting").ToString & ""

                msConn.CloseReader(drSetting)

                If ReadTableValue = "**In-USRegistryLarge-Table**" Then

                    ' Read Large record
                    sSql = "Select "
                    sSql = sSql & "Setting "
                    sSql = sSql & "from "
                    sSql = sSql & "USRegistryLarge  "
                    sSql = sSql & "Where "
                    sSql = sSql & "UserName = '" & Login.NetworkLogin & "' and "
                    sSql = sSql & "AppName = '" & AppName & "' and "
                    sSql = sSql & "SettingSection = '" & Section & "' and "
                    sSql = sSql & "SettingKey = '" & Key & "'"

                    drSetting = msConn.QueryDB(sSql)

                    If drSetting.Read = True Then
                        ReadTableValue = drSetting("Setting").ToString & ""
                    End If
                End If
            End If


        Catch ex As Exception
            clsErrorManager.WriteErrorLog("clsRegistryManager", "ReadTableValue", "", ex, Login)
        Finally
            msConn.CloseReader(drSetting)
        End Try

    End Function


    ' US Save Setting
    '================
    Public Sub SaveSetting(ByVal Login As clsLoginManager, ByVal AppName As String, ByVal Section As String, ByVal Key As String, ByVal Setting As Object)
        Try
            Dim sSetting As String

            sSetting = CStr(Setting)

            ' Save Setting to Table
            Call SaveTableValue(Login, AppName, Section, Key, sSetting)

        Catch ex As Exception
            clsErrorManager.WriteErrorLog("clsRegistryManager", "SaveSetting", "", ex, Login)
        End Try
    End Sub

    Private Sub SaveTableValue(ByVal Login As clsLoginManager, ByVal AppName As String, ByVal Section As String, ByVal Key As String, ByVal Setting As String)
        Dim drSetting As SQLiteDataReader = Nothing
        Dim sSql As String
        Dim sLargeSetting As String = ""

        Try
            ' Replace single quotes with double quotes for sql
            Setting = Replace(Setting, "'", "''")


            ' Large setting check
            If Len(Setting) > 8000 Then
                sLargeSetting = Setting
                Setting = "**In-USRegistryLarge-Table**"
            End If

            ' Get Connection, if none exists
            Call SetConnection(Login)

            ' Read record
            sSql = "Select "
            sSql = sSql & "Setting "
            sSql = sSql & "from "
            sSql = sSql & "USRegistry  "
            sSql = sSql & "Where "
            sSql = sSql & "UserName = '" & Login.NetworkLogin & "' and "
            sSql = sSql & "AppName = '" & AppName & "' and "
            sSql = sSql & "SettingSection = '" & Section & "' and "
            sSql = sSql & "SettingKey = '" & Key & "'"

            drSetting = msConn.QueryDB(sSql)

            ' Get Value
            If drSetting.Read = True Then

                ' Update to table
                sSql = "Update "
                sSql = sSql & "USRegistry "
                sSql = sSql & "Set "
                sSql = sSql & "Setting = '" & Setting & "', "
                sSql = sSql & "Modified_Date =  date('now') "
                sSql = sSql & "Where "
                sSql = sSql & "UserName = '" & Login.NetworkLogin & "' and "
                sSql = sSql & "AppName = '" & AppName & "' and "
                sSql = sSql & "SettingSection = '" & Section & "' and "
                sSql = sSql & "SettingKey = '" & Key & "'"
            Else

                ' Insert table
                sSql = "Insert into USRegistry "
                sSql = sSql & "(UserName, "
                sSql = sSql & "AppName, "
                sSql = sSql & "SettingSection, "
                sSql = sSql & "SettingKey, "
                sSql = sSql & "Setting, "
                sSql = sSql & "Modified_Date) "
                sSql = sSql & "Values "
                sSql = sSql & "('" & Login.NetworkLogin & "', "
                sSql = sSql & "'" & AppName & "', "
                sSql = sSql & "'" & Section & "', "
                sSql = sSql & "'" & Key & "', "
                sSql = sSql & "'" & Setting & "', "
                sSql = sSql & "date('now'))"

            End If
            ' Close Reader
            msConn.CloseReader(drSetting)

            ' Update or Insert
            msConn.ExecuteDB(sSql)



            ' Large Setting Entries
            If Setting = "**In-USRegistryLarge-Table**" Then

                ' Read record
                sSql = "Select "
                sSql = sSql & "UserName "
                sSql = sSql & "from "
                sSql = sSql & "USRegistryLarge   "
                sSql = sSql & "Where "
                sSql = sSql & "UserName = '" & Login.NetworkLogin & "' and "
                sSql = sSql & "AppName = '" & AppName & "' and "
                sSql = sSql & "SettingSection = '" & Section & "' and "
                sSql = sSql & "SettingKey = '" & Key & "'"

                drSetting = msConn.QueryDB(sSql)
                If drSetting.Read = True Then

                    ' Update to table
                    sSql = "Update "
                    sSql = sSql & "USRegistryLarge "
                    sSql = sSql & "Set "
                    sSql = sSql & "Setting = '" & sLargeSetting & "', "
                    sSql = sSql & "Modified_Date = date('now') "
                    sSql = sSql & "Where "
                    sSql = sSql & "UserName = '" & Login.NetworkLogin & "' and "
                    sSql = sSql & "AppName = '" & AppName & "' and "
                    sSql = sSql & "SettingSection = '" & Section & "' and "
                    sSql = sSql & "SettingKey = '" & Key & "'"
                Else

                    ' Insert table
                    sSql = "Insert into USRegistryLarge "
                    sSql = sSql & "(UserName, "
                    sSql = sSql & "AppName, "
                    sSql = sSql & "SettingSection, "
                    sSql = sSql & "SettingKey, "
                    sSql = sSql & "Setting, "
                    sSql = sSql & "Modified_Date) "
                    sSql = sSql & "Values "
                    sSql = sSql & "('" & Login.NetworkLogin & "', "
                    sSql = sSql & "'" & AppName & "', "
                    sSql = sSql & "'" & Section & "', "
                    sSql = sSql & "'" & Key & "', "
                    sSql = sSql & "'" & sLargeSetting & "', "
                    sSql = sSql & "date('now'))"

                End If

                msConn.CloseReader(drSetting)

                ' Update or Insert
                msConn.ExecuteDB(sSql)

            End If

        Catch ex As Exception
            clsErrorManager.WriteErrorLog("clsRegistryManager", "SaveTableValue", "", ex, Login)
        Finally
            msConn.CloseReader(drSetting)
        End Try
    End Sub

    Public Sub Close()
        msConn.CloseDB()
    End Sub
    Private Sub SetConnection(ByVal Login As clsLoginManager)
        Try
            If msConn.IsOpen = False Then
                msConn.OpenDB(Login.DBServer, Login.Database, Login.DatabaseUser, Login.DatabasePass)
            End If
        Catch ex As Exception
            clsErrorManager.WriteErrorLog("clsRegistryManager", "SetConnection", "", ex, Login)

        End Try
    End Sub


    ' US Get Setting
    '===============
    Public Sub DeleteSetting(ByVal Login As clsLoginManager, ByVal AppName As String, ByVal Section As String, ByVal Key As String)
        Dim sSql As String

        Try
            ' Get Connection, if none exists
            Call SetConnection(Login)


            ' Delete record from USRegistry table
            sSql = "Delete "
            sSql = sSql & "USRegistry "
            sSql = sSql & "Where "
            sSql = sSql & "UserName = '" & Login.NetworkLogin & "' and "
            sSql = sSql & "AppName = '" & AppName & "' and "
            sSql = sSql & "SettingSection = '" & Section & "' and "
            sSql = sSql & "SettingKey = '" & Key & "'"

            ' Delete Record
            msConn.ExecuteDB(sSql)

            ' Delete record from USRegistryLarge table
            sSql = "Delete "
            sSql = sSql & "USRegistryLarge "
            sSql = sSql & "Where "
            sSql = sSql & "UserName = '" & Login.NetworkLogin & "' and "
            sSql = sSql & "AppName = '" & AppName & "' and "
            sSql = sSql & "SettingSection = '" & Section & "' and "
            sSql = sSql & "SettingKey = '" & Key & "'"

            ' Delete Record
            msConn.ExecuteDB(sSql)

        Catch ex As Exception
            clsErrorManager.WriteErrorLog("clsRegistryManager", "Delete Setting", "", ex, Login)

        End Try
    End Sub

End Class



