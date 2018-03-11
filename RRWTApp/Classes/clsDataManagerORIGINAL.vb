Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic
Imports System.Reflection.Assembly
Imports System.Reflection
Imports System.IO

Public Class clsDataManagerORIGINAL

    Private Tablecmd As SqlCommand
    Private Tableda As Data.SqlClient.SqlDataAdapter
    Private Tabledt As DataSet
    Private Tablecb As SqlCommandBuilder

    Private mConn As SqlConnection
    Private mCommand As SqlCommand
    Private mTrans As SqlTransaction


    Private msDBServer As String
    Private msDatabase As String

    Private msUsername As String
    Private msPassword As String

    Private msNetworkLogin As String
    Private msComputerName As String
    Private msCitrixServer As String

    Public Sub OpenDB(ByVal sDBServer As String, ByVal sDatabase As String, ByVal sUserName As String, ByVal sPassword As String)
        msDBServer = sDBServer
        msDatabase = sDatabase
        msUsername = sUserName
        msPassword = sPassword

        mConn = New SqlConnection(MakeConnectionString(msDBServer, msDatabase, msUsername, msPassword))
        mConn.Open()

    End Sub

    'Public Sub OpenDB(ByVal tmpLogin As clsLoginManager)
    'test source control

    '    msDBServer = tmpLogin.DBServer
    '    msDatabase = tmpLogin.Database
    '    msNetworkLogin = tmpLogin.NetworkLogin
    '    msComputerName = tmpLogin.ComputerName
    '    msCitrixServer = tmpLogin.CitrixServer


    '    mConn = New SqlConnection(MakeConnectionString(msDBServer, msDatabase))
    '    mConn.Open()


    'End Sub

    'Public Sub OpenDB(ByVal sDBServer As String, ByVal sDatabase As String, Optional ByVal sNetworkLogin As String = "", Optional ByVal sComputerName As String = "", Optional ByVal sCitrixServer As String = "")
    '    msDBServer = sDBServer
    '    msDatabase = sDatabase
    '    msNetworkLogin = sNetworkLogin
    '    msComputerName = sComputerName
    '    msCitrixServer = sCitrixServer

    '    mConn = New SqlConnection(MakeConnectionString(msDBServer, msDatabase))
    '    mConn.Open()


    'End Sub

    'Public Function OpenDB(ByVal tmpLogin As clsLoginManager, ByVal bOpenResults As Boolean) As Boolean

    '    Try
    '        msDBServer = tmpLogin.DBServer
    '        msDatabase = tmpLogin.Database
    '        msNetworkLogin = tmpLogin.NetworkLogin
    '        msComputerName = tmpLogin.ComputerName
    '        msCitrixServer = tmpLogin.CitrixServer


    '        mConn = New SqlConnection(MakeConnectionString(msDBServer, msDatabase))
    '        mConn.Open()
    '        OpenDB = False
    '        If mConn.State = ConnectionState.Open Then
    '            OpenDB = True
    '        End If
    '    Catch ex As Exception
    '        OpenDB = False
    '    End Try

    'End Function

    Public Sub CloseReader(ByRef drReader As SqlDataReader)
        If drReader IsNot Nothing Then
            If drReader.IsClosed = False Then
                drReader.Close()
            End If
        End If

    End Sub
    Public Function IsOpen() As Boolean
        If Not mConn Is Nothing Then
            If mConn.State = ConnectionState.Open Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function
    Public Sub CloseDB()

        If Not mConn Is Nothing Then
            If mConn.State = ConnectionState.Open Then
                mConn.Close()
                mConn.Dispose()
            End If
        End If

    End Sub

    Private Function MakeConnectionString(ByVal sServer As String, ByVal sDatabase As String, ByVal sUsername As String, ByVal sPassword As String) As String
        Dim connString As String = ""


        MakeConnectionString = Nothing


        'MakeConnectionString = "Data Source=tcp:USELGP2015\GP;Initial Catalog=" & sDatabase & ";Persist Security Info=True;User ID=sa;Password=S3cur!ty;MultipleActiveResultSets=True;Workstation ID=" & Login.NetworkLogin & "-" & Login.ComputerName & ";Application Name=" & GetExecutingAssembly.GetName.Name() & "-" & Login.NetworkLogin & "-" & Login.CitrixServer & "-" & Login.ComputerName
        MakeConnectionString = "Data Source=tcp:" & sServer & ";Initial Catalog=" & sDatabase & ";Persist Security Info=True;User ID=rrwt;Password=rrwt;MultipleActiveResultSets=True;Workstation ID=" & Login.NetworkLogin & "-" & Login.ComputerName & ";Application Name=" & GetExecutingAssembly.GetName.Name() & "-" & Login.NetworkLogin & "-" & Login.CitrixServer & "-" & Login.ComputerName
        'Integrated Security = true
        'MakeConnectionString = "Data Source=tcp:" & sServer & ";Integrated Security = true;Initial Catalog=" & sDatabase & ";Persist Security Info=True;MultipleActiveResultSets=True;Workstation ID=" & Login.NetworkLogin & "-" & Login.ComputerName & ";Application Name=" & GetExecutingAssembly.GetName.Name() & "-" & Login.NetworkLogin & "-" & Login.CitrixServer & "-" & Login.ComputerName

        'MakeConnectionString = "Data Source=" & sServer & ";Integrated Security = true;Initial Catalog=" & sDatabase & ";Persist Security Info=True;MultipleActiveResultSets=True;Workstation ID=" & Login.NetworkLogin & "-" & Login.ComputerName & ";Application Name=" & GetExecutingAssembly.GetName.Name() & "-" & Login.NetworkLogin & "-" & Login.CitrixServer & "-" & Login.ComputerName

    End Function

    'Private Function MakeConnectionString(ByVal sServer As String, ByVal sDatabase As String) As String
    '    Dim connString As String = ""


    '    MakeConnectionString = Nothing


    '    If UCase(sServer) = "USELGP2015\GP" Then
    '        MakeConnectionString = "Data Source=tcp:USELGP2015\GP;Initial Catalog=" & sDatabase & ";Persist Security Info=True;User ID=sa;Password=S3cur!ty;MultipleActiveResultSets=True;Workstation ID=" & Login.NetworkLogin & "-" & Login.ComputerName & ";Application Name=" & GetExecutingAssembly.GetName.Name() & "-" & Login.NetworkLogin & "-" & Login.CitrixServer & "-" & Login.ComputerName
    '    End If



    '    If UCase(sServer) = "SCRAPPY" Then
    '        MakeConnectionString = "Data Source=tcp:SCRAPPY;Initial Catalog=" & sDatabase & ";Persist Security Info=True;User ID=sa;Password=admin;MultipleActiveResultSets=True;Workstation ID=" & Login.NetworkLogin & "-" & Login.ComputerName & ";Application Name=" & GetExecutingAssembly.GetName.Name() & "-" & Login.NetworkLogin & "-" & Login.CitrixServer & "-" & Login.ComputerName
    '        ' MakeConnectionString = "Data Source=tcp:SCRAPPY;Initial Catalog=TechA;Persist Security Info=True;User ID=sa;Password=admin;Workstation ID=" & Login.NetworkLogin & "-" & Login.ComputerName & ";Application Name=" & GetExecutingAssembly.GetName.Name() & "-" & Login.NetworkLogin & "-" & Login.CitrixServer & "-" & Login.ComputerName
    '    End If
    '    If UCase(sServer) = "NTSERVER5" Then
    '        '   MakeConnectionString = "Data Source=NTSERVER5;Initial Catalog=" & sDatabase & ";Persist Security Info=True;User ID=sa;Password=admin;Workstation ID=" & msNetworkLogin & "-" & msComputerName & ";Application Name=" & GetExecutingAssembly.GetName.Name() & "-" & msCitrixServer
    '        'MakeConnectionString = "Data Source=NTSERVER5;Initial Catalog=" & sDatabase & ";Persist Security Info=True;User ID=sa;Password=admin;Workstation ID=" & Login.NetworkLogin & "-" & Login.ComputerName & ";Application Name=" & GetExecutingAssembly.GetName.Name() & "-" & Login.NetworkLogin & "-" & Login.CitrixServer & "-" & Login.ComputerName
    '        ' force connection to use tcp,  was getting occational error refering to named pipes which is not even configured. rrr 3-16-2011
    '        'The error was: An error has occurred while establishing a connection to the server.  When connecting to SQL Server 2005, this failure may be caused by the fact that under the default settings SQL Server does not allow remote connections. (provider: Named Pipes Provider, 
    '        MakeConnectionString = "Server=tcp:NTSERVER5;Initial Catalog=" & sDatabase & ";Persist Security Info=True;User ID=sa;Password=admin;MultipleActiveResultSets=True;Workstation ID=" & Login.NetworkLogin & "-" & Login.ComputerName & ";Application Name=" & GetExecutingAssembly.GetName.Name() & "-" & Login.NetworkLogin & "-" & Login.CitrixServer & "-" & Login.ComputerName

    '    End If
    '    If UCase(sServer) = "NETWKS2" Then
    '        MakeConnectionString = "Data Source=NETWKS2;Initial Catalog=" & sDatabase & ";Persist Security Info=True;User ID=sa;Password=admin;MultipleActiveResultSets=True;Workstation ID=" & Login.NetworkLogin & "-" & Login.ComputerName & ";Application Name=" & GetExecutingAssembly.GetName.Name() & "-" & Login.NetworkLogin & "-" & Login.CitrixServer & "-" & Login.ComputerName
    '    End If


    'End Function


    Public Function getValue(ByVal sSQL As String, Optional ByVal iCommandTimeout As Integer = 0) As Object

        Call TrackingSQL(sSQL)

        Dim Dr As SqlDataReader = Nothing
        'Dim ConnEx As New SqlConnection(MakeConnectionString(msDBServer, msDatabase))
        Dim ConnEx As New SqlConnection(MakeConnectionString(msDBServer, msDatabase, msUsername, msPassword))
        getValue = Nothing
        ConnEx.Open()

        Dim cmd As New SqlCommand(sSQL, ConnEx)
        cmd.CommandTimeout = iCommandTimeout

        Dr = cmd.ExecuteReader()
        If Dr.Read() Then
            getValue = CType(Dr(0), Object)
        End If

        Me.CloseReader(Dr)
        If Not ConnEx Is Nothing Then
            If ConnEx.State = ConnectionState.Open Then
                ConnEx.Close()
                ConnEx.Dispose()
            End If
        End If

        Return getValue
    End Function




    'GetRecord Usage:
    '================
    ' GetOne Record of Data
    '    Dim ht As Hashtable = gConn.GetRecord("Select * from ftsys_oemain where Internal_order_number=1111111")
    ' Determine if any results returned
    'if ht.count>0 then
    ' Get Data - Note: Fields names must be uppercased to retrieve data
    '    Dim dSO As Double = ht("INTERNAL_ORDER_NO")
    '    Dim sStage As String = ht("STAGE")
    'end if

    Public Function GetHashRecord(ByVal query As String, Optional ByVal iCommandTimeout As Integer = 0) As Hashtable
        GetHashRecord = New Hashtable
        Dim htResults As New Hashtable(StringComparer.OrdinalIgnoreCase)


        Try
            Call TrackingSQL(query)
            Call CheckDBOpen()

            ' Get Data Set
            Dim cmd As New SqlCommand(query, mConn)
            cmd.CommandTimeout = iCommandTimeout
            Tableda = New Data.SqlClient.SqlDataAdapter()
            Tableda.SelectCommand = cmd
            Tablecb = New SqlCommandBuilder(Tableda)
            Tabledt = New DataSet()
            Tableda.Fill(Tabledt, "TestRecord")

            ' Get Column Names
            Dim drow As DataRow
            Dim dt As DataTable
            Dim iRowCount As Integer = -1
            Dim i As Integer

            dt = Tabledt.Tables("TestRecord")
            Dim dc As DataColumn

            For Each dc In dt.Columns
                iRowCount = iRowCount + 1
                ' Note uppercased Column names
                GetHashRecord.Add("ROW" & CStr(iRowCount), dc.ColumnName.ToUpper)

            Next
            drow = Nothing
            dt = Nothing

            ' Get Data and Combine wiith Columns
            If iRowCount <> -1 Then
                Dim Dr As SqlDataReader = Nothing
                Dim ConnEx As New SqlConnection(MakeConnectionString(msDBServer, msDatabase, msUsername, msPassword))
                ConnEx.Open()
                Dim cmd2 As New SqlCommand(query, ConnEx)


                Dr = cmd2.ExecuteReader()
                If Dr.Read() Then
                    ' getValue
                    For i = 0 To iRowCount
                        ' Add HashTable Record
                        htResults.Add(GetHashRecord.Item("ROW" & CStr(i)), Dr(i))
                    Next

                End If

                Me.CloseReader(Dr)
                ConnEx.Close()
                'If Not ConnEx Is Nothing Then
                '    If ConnEx.State = ConnectionState.Open Then
                '        ConnEx.Close()
                '        ConnEx.Dispose()
                '    End If
                'End If
            End If
            GetHashRecord = Nothing

            Return htResults

        Catch ex As Exception
            Return New Hashtable
        End Try
    End Function


    Public Function GetRecord(ByVal query As String, Optional ByVal iCommandTimeout As Integer = 0) As Hashtable
        GetRecord = New Hashtable
        Dim htResults As New Hashtable

        Try
            Call TrackingSQL(query)
            Call CheckDBOpen()

            ' Get Data Set
            Dim cmd As New SqlCommand(query, mConn)
            cmd.CommandTimeout = iCommandTimeout
            Tableda = New Data.SqlClient.SqlDataAdapter()
            Tableda.SelectCommand = cmd
            Tablecb = New SqlCommandBuilder(Tableda)
            Tabledt = New DataSet()
            Tableda.Fill(Tabledt, "TestRecord")

            ' Get Column Names
            Dim drow As DataRow
            Dim dt As DataTable
            Dim iRowCount As Integer = -1
            Dim i As Integer

            dt = Tabledt.Tables("TestRecord")
            Dim dc As DataColumn

            For Each dc In dt.Columns
                iRowCount = iRowCount + 1
                ' Note uppercased Column names
                GetRecord.Add("ROW" & CStr(iRowCount), dc.ColumnName.ToUpper)

            Next
            drow = Nothing
            dt = Nothing

            ' Get Data and Combine wiith Columns
            If iRowCount <> -1 Then
                Dim Dr As SqlDataReader = Nothing
                Dim ConnEx As New SqlConnection(MakeConnectionString(msDBServer, msDatabase, msUsername, msPassword))
                ConnEx.Open()
                Dim cmd2 As New SqlCommand(query, ConnEx)


                Dr = cmd2.ExecuteReader()
                If Dr.Read() Then
                    ' getValue
                    For i = 0 To iRowCount - 1
                        ' Add HashTable Record
                        htResults.Add(GetRecord.Item("ROW" & CStr(i)), Dr(i))
                    Next

                End If

                Me.CloseReader(Dr)
                ConnEx.Close()
                'If Not ConnEx Is Nothing Then
                '    If ConnEx.State = ConnectionState.Open Then
                '        ConnEx.Close()
                '        ConnEx.Dispose()
                '    End If
                'End If
            End If
            GetRecord = Nothing

            Return htResults

        Catch ex As Exception
            Return New Hashtable
        End Try
    End Function



    'Public Function ExecuteDB(ByVal sServer As String, ByVal sDatabase As String, ByVal query As String) As Boolean

    '    ExecuteDB = False
    '    Dim ConnEx As New SqlConnection(MakeConnectionString(sServer, sDatabase))
    '    Try

    '        ConnEx.Open()

    '        ' Execute Command
    '        Dim Command As New SqlCommand(query, ConnEx)
    '        Command.ExecuteNonQuery()

    '        ExecuteDB = True

    '        If ConnEx.State = ConnectionState.Open Then
    '            ConnEx.Close()
    '        End If
    '    Catch ex As Exception
    '        Throw
    '    Finally
    '        If Not ConnEx Is Nothing Then
    '            If ConnEx.State = ConnectionState.Open Then
    '                ConnEx.Close()
    '                ConnEx.Dispose()
    '            End If
    '        End If
    '    End Try
    'End Function
    Public Function ExecuteDB(ByVal query As String, Optional ByVal iCommandTimeout As Integer = 30) As Boolean
        Call TrackingSQL(query)
        Call CheckDBOpen()

        ExecuteDB = False
        ' Execute Command
        Dim Command As New SqlCommand(query, mConn)
        Command.CommandTimeout = iCommandTimeout
        Command.ExecuteNonQuery()
        ExecuteDB = True

    End Function

    Public Function ExecuteDBRecords(ByVal query As String, Optional ByVal iCommandTimeout As Integer = 30) As Integer
        Call TrackingSQL(query)
        Call CheckDBOpen()
        ExecuteDBRecords = -1
        ' Execute Command
        Dim Command As New SqlCommand(query, mConn)
        Command.CommandTimeout = iCommandTimeout
        ExecuteDBRecords = Command.ExecuteNonQuery()

    End Function

    Public Function ExecuteSP(ByVal sStoredProcedure As String, Optional ByVal iCommandTimeout As Integer = 30) As Integer
        Dim cmd As New SqlCommand
        Dim rowsAffected As Integer = 0
        Dim sColumns As String()
        Dim i As Integer


        Try
            Call TrackingSQL("Stored Procedure: " & sStoredProcedure)
            Call CheckDBOpen()

            sColumns = sStoredProcedure.Split("|")
            cmd.CommandTimeout = iCommandTimeout
            cmd.CommandText = sColumns(0)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = mConn

            For i = 1 To sColumns.Length - 1 Step 2
                cmd.Parameters.AddWithValue(sColumns(i), sColumns(i + 1))
            Next

            rowsAffected = cmd.ExecuteNonQuery()

            Return rowsAffected

        Catch ex As SqlException
            '  Because of Microsoft error
            'http://support.microsoft.com/default.aspx?scid=kb;en-us;896373
            ' http://www.dotnet247.com/247reference/msgs/30/153166.aspx
            '   Dim s As String = ""
        End Try

    End Function


    Public Function QueryDBTable(ByVal query As String, Optional ByVal iCommandTimeout As Integer = 0) As DataTable
        Call TrackingSQL(query)
        Call CheckDBOpen()
        Dim cmd As New SqlCommand(query, mConn)
        cmd.CommandTimeout = iCommandTimeout
        Dim da As New Data.SqlClient.SqlDataAdapter(cmd)
        Dim dt As New DataTable()
        da.Fill(dt)

        Return dt

    End Function
    ' Note this is a connected dataset, thus only one allowed per connection at a time
    ' Good used with a Datagridview
    Public Function GetDataSet(ByVal query As String, ByVal sTableName As String, Optional ByVal iCommandTimeout As Integer = 0) As DataSet
        Try
            Call TrackingSQL(query)
            Call CheckDBOpen()
            Dim cmd As New SqlCommand(query, mConn)
            cmd.CommandTimeout = iCommandTimeout
            Tableda = New Data.SqlClient.SqlDataAdapter()
            Tableda.SelectCommand = cmd
            Tablecb = New SqlCommandBuilder(Tableda)
            Tabledt = New DataSet()
            Tableda.Fill(Tabledt, sTableName)
            Return Tabledt

        Catch ex As Exception
            Return Tabledt
        End Try
    End Function

    Public Function UpdateDataSet(ByVal sTableName As String) As Boolean
        Dim bFlag As Boolean = False

        Try
            Tableda.Update(Tabledt.Tables(sTableName))
            Tabledt.AcceptChanges()
            bFlag = True
            Return bFlag
        Catch ex As Exception
            Return bFlag
        Finally
            Tableda = Nothing
            Tabledt = Nothing
            Tablecb = Nothing
        End Try


    End Function
    Public Function QueryDB(ByVal query As String, Optional ByVal iCommandTimeout As Integer = 0) As SqlDataReader
        Call TrackingSQL(query)
        Call CheckDBOpen()
        Dim cmd As New SqlCommand(query, mConn)
        cmd.CommandTimeout = iCommandTimeout
        Return cmd.ExecuteReader()

    End Function


    ''' <summary>
    ''' Handles Start of Transactions
    ''' </summary>
    ''' <remarks>Handles Start of Transactions2</remarks>
    Public Function BeginTrans() As Boolean
        Call CheckDBOpen()
        mCommand = mConn.CreateCommand

        mTrans = mConn.BeginTransaction()

        mCommand.Connection = mConn
        mCommand.Transaction = mTrans

    End Function
    Public Function ExecuteTrans(ByVal sSQL As String, Optional ByVal iCommandTimeout As Integer = 0) As Boolean
        Call TrackingSQL(sSQL)
        mCommand.CommandTimeout = iCommandTimeout
        mCommand.CommandText = sSQL
        mCommand.ExecuteNonQuery()
        ExecuteTrans = True
        ' If error rollback??
    End Function
    Public Function CommitTrans() As Boolean
        mTrans.Commit()

    End Function
    Public Function RollbackTrans() As Boolean
        mTrans.Rollback()
    End Function

    ' This is a disconnected Dataset
    Public Function QueryDBDataSet(ByVal msTableName As String, ByVal query As String, Optional ByVal iCommandTimeout As Integer = 0) As DataSet
        Dim Conn As New SqlConnection(MakeConnectionString(msDBServer, msDatabase, msUsername, msPassword))
        Call TrackingSQL(query)
        Try
            Conn.Open()

            Dim cmd As New SqlCommand(query, Conn)
            cmd.CommandTimeout = iCommandTimeout
            Dim da As New Data.SqlClient.SqlDataAdapter(cmd)
            Dim dt As New DataSet()
            da.Fill(dt, msTableName)

            Return dt
        Catch ex As Exception
            Throw
        Finally
            If Not Conn Is Nothing Then
                If Conn.State = ConnectionState.Open Then
                    Conn.Close()
                    Conn.Dispose()
                End If
            End If
        End Try

    End Function


    Public Function getConnection() As SqlConnection
        Return mConn
    End Function


    'Public Function GetDataTable(ByVal MyIList As IList) As DataTable
    '    Dim dt As New DataTable
    '    Try


    '        '    Dim entityType as Type= typeof(MyiList)

    '        '    Dim col As New DataColumn("ColumnName", GetType(String))
    '        '    dt.Columns.Add(col)
    '        '    For Each Item As Object In MyIList
    '        '        Dim row As DataRow = dt.NewRow()
    '        '        row("ColumnName") = Item
    '        '        dt.Rows.Add(row)
    '        '    Next
    '        '    Return dt


    '        'Type entityType = typeof(T)
    '        'PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

    '        'foreach (T item in list)
    '        '{
    '        '    DataRow row = table.NewRow();

    '        '    foreach (PropertyDescriptor prop in properties)
    '        '    {
    '        '        row[prop.Name] = prop.GetValue(item);
    '        '    }

    '        '    table.Rows.Add(row);
    '        '}



    '        If MyIList.Count > 0 Then
    '            'Dim grid As DataGrid = New DataGrid

    '            'grid.DataSource = MyIList


    '            Dim columns As List(Of String) = New List(Of String)

    '            For Each Item As Object In MyIList

    '                dt.Columns.Add(Item.ToString)
    '                columns.Add(Item.ToString)
    '            Next


    '            For Each Item As Object In MyIList



    '                Dim cells As Object = getValues(columns, Item)

    '                dt.Rows.Add(cells)

    '            Next



    '        End If
    '        Return dt
    '    Catch ex As Exception
    '        ' Return dt
    '    End Try



    'End Function

    'Private Function getValues(ByVal columns As List(Of String), ByVal instance As Object) As Object


    '    Dim returnVal(columns.Count) As Object

    '    Dim i As Integer = 0
    '    For i = 0 To columns.Count - 1

    '        Dim propertyInfo As PropertyInfo = instance.GetType().GetProperty(columns(0))

    '        Dim value As Object = instance.PropertyInfo.GetValue()

    '        returnVal(i) = value

    '    Next i

    '    Return returnVal

    'End Function

    Private Sub TrackingSQL(ByVal sSQL As String)
        Try
            If bSQLTracking = True Then
                Dim sFileName As String = Login.ErrorLogPath & "SQL-" & sAppName & "-" & Login.NetworkLogin & "-" & Format(Now, "yyyy-MM-dd") & ".log"

                Dim sw As StreamWriter

                ' This text is added only once to the file.
                If File.Exists(sFileName) = False Then
                    ' Create a file to write to.
                    sw = File.CreateText(sFileName)
                    sw.Flush()
                    sw.Close()
                End If

                ' Add Line
                sw = File.AppendText(sFileName)

                sw.WriteLine(Format(Now, "MM/dd/yyyy hh:mm:ss") & ": " & sSQL)
                sw.Flush()
                sw.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Function CheckDBOpen(Optional ByVal iRetryTimes As Integer = 3) As Boolean
        Dim i As Integer = 0
        Try
            Do While mConn.State <> ConnectionState.Open
                i = i + 1
                If i > iRetryTimes Then
                    Exit Do
                End If
                mConn = New SqlConnection(MakeConnectionString(msDBServer, msDatabase, msUsername, msPassword))
                mConn.Open()
            Loop
            Return ConnectionState.Open
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class
