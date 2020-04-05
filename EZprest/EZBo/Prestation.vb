Imports EzErrors

Public Class clsPrestation

    Private dDatePrestation As Date
    Private eDureeReservation As enumDureeReservation
    Private eStatutPrestation As enumStatut
    Private bDerniereModification As Byte()
    Private bHeuresPrestees As Byte
    Private dDateHeureEncodage As DateTime
    Private objAssignation As clsAssignation
    Private objPhase As clsPhase
    Private objPlanning As clsPlanning
    Private objPersonneEncode As clsPersonne

    Public Sub New()

    End Sub

    Public Property DatePrestation() As Date
        Get
            Return dDatePrestation
        End Get
        Set(ByVal Value As Date)
            'TODO : un test pour vérifier la date
            dDatePrestation = Value
        End Set
    End Property

    Public Property DureeReservation() As enumDureeReservation
        Get
            Return eDureeReservation
        End Get
        Set(ByVal Value As enumDureeReservation)
            'TODO : test de la durée min et max
            eDureeReservation = Value
        End Set
    End Property

    Public Property StatutPrestation() As enumStatut
        Get
            Return eStatutPrestation
        End Get
        Set(ByVal Value As enumStatut)
            eStatutPrestation = Value
        End Set
    End Property

    Public Property DerniereModification() As Byte()
        Get
            Return bDerniereModification
        End Get
        Set(ByVal Value As Byte())
            bDerniereModification = Value
        End Set
    End Property

    Public Property HeuresPrestees() As Byte
        Get
            Return bHeuresPrestees
        End Get
        Set(ByVal Value As Byte)
            'TODO : un test sur la validité des heures 0-24 et sur la durée max d'une journée défini dans la db
            bHeuresPrestees = Value
        End Set
    End Property
    ' la date de creation est entrée par le constructeur et ne peut pas etre modifiée
    Public ReadOnly Property DateHeureEncodage() As DateTime
        Get
            Return dDateHeureEncodage
        End Get
    End Property

    Public Property Assingnation() As clsAssignation
        Get
            Return objAssignation
        End Get
        Set(ByVal Value As clsAssignation)
            If Not objAssignation Is Nothing Then
                Throw (New ErrorPrestation.InvalidAssignation)
            End If
            'on met la reférence de l'assignation dans la prestation
            'ensuite on met la reférence de la prestation dans l'assignation
            objAssignation = Value
            objAssignation.AddPrestation(Me)
        End Set
    End Property

    Public Property Phase() As clsPhase
        Get
            Return objPhase
        End Get
        Set(ByVal Value As clsPhase)
            If Not objPhase Is Nothing Then
                Throw (New ErrorPrestation.InvalidPhase)
            End If
            objPhase = Value

        End Set
    End Property

    Public Property Planning() As clsPlanning
        Get
            Return objPlanning
        End Get
        Set(ByVal Value As clsPlanning)
            If Not objPlanning Is Nothing Then
                Throw (New ErrorPrestation.InvalidPlanning)
            End If
            'on met la reférence du planning dans la prestation
            'ensuite on met la reférence de la prestation dans le planning
            objPlanning = Value
            objPlanning.AddPrestation(Me)
        End Set
    End Property

    Public Property PersonneEncode() As clsPersonne
        Get
            Return objPersonneEncode
        End Get
        Set(ByVal Value As clsPersonne)
            'TODO un test pas de changement attention
            objPersonneEncode = Value
        End Set
    End Property

End Class