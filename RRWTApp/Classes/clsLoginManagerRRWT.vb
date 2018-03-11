Public Class clsLoginManagerRRWT


    Inherits clsLoginManager
    Private msWhse_Id As Integer
    Private msWhse_List As String
    Private msSalesman_List As String
    Private msShippingTicketPrefix As String
    Private msReceivingTicketPrefix As String

    Public Property Whse_Id() As String
        Get
            Return msWhse_Id
        End Get
        Set(ByVal value As String)
            msWhse_Id = value
        End Set
    End Property

    Public Property Whse_List() As String
        Get
            Return msWhse_List
        End Get
        Set(ByVal value As String)
            msWhse_List = value
        End Set
    End Property
    Public Property Salesman_List() As String
        Get
            Return msSalesman_List
        End Get
        Set(ByVal value As String)
            msSalesman_List = value
        End Set
    End Property

    Public Property ShippingTicketPrefix() As String
        Get
            Return msShippingTicketPrefix
        End Get
        Set(ByVal value As String)
            msShippingTicketPrefix = value
        End Set
    End Property

    Public Property ReceivingTicketPrefix() As String
        Get
            Return msReceivingTicketPrefix
        End Get
        Set(ByVal value As String)
            msReceivingTicketPrefix = value
        End Set
    End Property

End Class



