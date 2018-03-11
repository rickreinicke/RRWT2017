Imports System
Imports System.Data
'Imports System.Data.SqlClient
Imports Microsoft.VisualBasic




Public Class clsLoginManager
    Private msDBServer As String = ""
    Private msDBInstance As String = "" ' LIVE or TEST
    Private msDatabase As String = ""

    Private msDatabaseUser As String = ""
    Private msDatabasePass As String = ""

    Private msGPComputerName As String = ""
    Private msGPServer As String = ""
    Private msGPDatabase As String = ""
    Private msGPDatabaseUser As String = ""
    Private msGPDatabasePass As String = ""

    Private msDataFolder As String = ""
    Private msDataFilename As String = ""
    Private msDataFullPath As String = ""


    Private msUserName As String = ""
    Private msFullName As String = ""

    Private msNetworkLogin As String = ""
    Private msComputerName As String = ""
    Private msExeName As String = ""
    Private msCitrixServer As String = ""
    Private msSessionNumber As String = ""
    Private msAdministrator As String = ""


    Private msSessionType As String = ""
    Private bIsLiveDB As Boolean = False
    Private bIsCitrixServer As Boolean = False
    Private bIsRDPSession As Boolean = False


    Private msErrorTableName As String = ""
    Private msErrorLogPath As String = Application.StartupPath & "\Errors\"
    Private msErrorImagePath As String = Application.StartupPath & "\Errors\"

    Public Property GPServer() As String
        Get
            Return msGPServer
        End Get
        Set(ByVal value As String)
            msGPServer = value
        End Set
    End Property


    Public Property DataFolder() As String
        Get
            Return msDataFolder
        End Get
        Set(ByVal value As String)
            msDataFolder = value
        End Set
    End Property

    Public Property DataFilename() As String
        Get
            Return msDataFilename
        End Get
        Set(ByVal value As String)
            msDataFilename = value
        End Set
    End Property

    Public Property DataFullPath() As String
        Get
            Return msDataFullPath
        End Get
        Set(ByVal value As String)
            msDataFullPath = value
        End Set
    End Property


    Public Property DatabaseUser() As String
        Get
            Return msDatabaseUser
        End Get
        Set(ByVal value As String)
            msDatabaseUser = value
        End Set
    End Property
    Public Property DatabasePass() As String
        Get
            Return msDatabasePass
        End Get
        Set(ByVal value As String)
            msDatabasePass = value
        End Set
    End Property
    Public Property GPComputerName() As String
        Get
            Return msGPComputerName
        End Get
        Set(ByVal value As String)
            msGPComputerName = value
        End Set
    End Property


    Public Property GPDatabase() As String
        Get
            Return msGPDatabase
        End Get
        Set(ByVal value As String)
            msGPDatabase = value
        End Set
    End Property


    Public Property GPDatabaseUser() As String
        Get
            Return msGPDatabaseUser
        End Get
        Set(ByVal value As String)
            msGPDatabaseUser = value
        End Set
    End Property

    Public Property GPDatabasePass() As String
        Get
            Return msGPDatabasePass
        End Get
        Set(ByVal value As String)
            msGPDatabasePass = value
        End Set
    End Property


    Public Property DBServer() As String
        Get
            Return msDBServer
        End Get
        Set(ByVal value As String)
            msDBServer = value
        End Set
    End Property




    Public Property DBInstance() As String
        Get
            Return msDBInstance
        End Get
        Set(ByVal value As String)
            msDBInstance = value
        End Set
    End Property

    'Public Property ConnectionString() As String
    '    Get
    '        Return msConnectionString
    '    End Get
    '    Set(ByVal value As String)
    '        msConnectionString = value
    '    End Set
    'End Property

    Public Property Database() As String
        Get
            Return msDatabase
        End Get
        Set(ByVal value As String)
            msDatabase = value
        End Set
    End Property
    Public Property UserName() As String
        Get
            Return msUserName
        End Get
        Set(ByVal value As String)
            msUserName = value
        End Set
    End Property
    Public Property FullName() As String
        Get
            Return msFullName
        End Get
        Set(ByVal value As String)
            msFullName = value
        End Set
    End Property
    Public Property NetworkLogin() As String
        Get
            Return msNetworkLogin
        End Get
        Set(ByVal value As String)
            msNetworkLogin = value
        End Set
    End Property

    Public Property ComputerName() As String
        Get
            Return msComputerName
        End Get
        Set(ByVal value As String)
            msComputerName = value
        End Set
    End Property
    Public Property ExeName() As String
        Get
            Return msExeName
        End Get
        Set(ByVal value As String)
            msExeName = value
        End Set
    End Property
    Public Property CitrixServer() As String
        Get
            Return msCitrixServer
        End Get
        Set(ByVal value As String)
            msCitrixServer = value
        End Set
    End Property
    Public Property SessionNumber() As String
        Get
            Return msSessionNumber
        End Get
        Set(ByVal value As String)
            msSessionNumber = value
        End Set
    End Property

    Public Property ErrorTableName() As String
        Get
            Return msErrorTableName
        End Get
        Set(ByVal value As String)
            msErrorTableName = value
        End Set
    End Property


    Public Property ErrorLogPath() As String
        Get
            Return msErrorLogPath
        End Get
        Set(ByVal value As String)
            msErrorLogPath = value
        End Set
    End Property
    Public Property ErrorImagePath() As String
        Get
            Return msErrorImagePath
        End Get
        Set(ByVal value As String)
            msErrorImagePath = value
        End Set
    End Property



    Public Sub New()
        Dim sTemp As String = ""

        Try
            ' Get Citrix server name and computer name
            'Login.ComputerName = "" & System.Environment.GetEnvironmentVariable("CLIENTNAME")
            'If Login.ComputerName.Length = 0 Then
            '    ' Not citrix session
            '    Login.CitrixServer = "None"
            '    bIsCitrixServer = False
            '    Login.ComputerName = System.Environment.MachineName
            'Else
            '    ' Citrix session
            '    Login.CitrixServer = System.Environment.MachineName
            'End If

            ' Network Name
            msNetworkLogin = System.Environment.UserName

            ' Session Type
            sTemp = "" & System.Environment.GetEnvironmentVariable("SESSIONNAME") & "   "
            Select Case sTemp.ToUpper.Substring(0, 3)
                Case "ICA"
                    msCitrixServer = System.Environment.MachineName
                    bIsCitrixServer = True
                    msSessionType = "Citrix"
                    bIsRDPSession = False
                Case "RDP"
                    msCitrixServer = "None"
                    bIsCitrixServer = False
                    msComputerName = System.Environment.MachineName
                    msSessionType = "RDP"
                    bIsRDPSession = True
                Case "CON"
                    msCitrixServer = "None"
                    bIsCitrixServer = False
                    msComputerName = System.Environment.MachineName
                    msSessionType = "Console"
                    bIsRDPSession = False
            End Select



        Catch ex As Exception
            Dim s As String = ""

        End Try
    End Sub
End Class


