Imports EzErrors

Public Class clsPlanning

    Private iId As Integer
    Private dMoisAnnee As Date
    Private dDateCreation As Date
    Private bDureeJournee As Byte
    Private bDerniereModification As Byte()
    'contient des clsPrestation
    Private objPrestations As New ArrayList
    Private CodePersonneCree As String

    Public Sub New(ByVal pMoisAnnee As Date, ByVal pDureeJournee As Byte)

        MoisAnnee = pMoisAnnee
        DureeJournee = pDureeJournee
        'TODO : date creation peut etre la solution ???
        dDateCreation = Date.Today

    End Sub

    Public Property Id() As Integer
        Get
            Return iId
        End Get
        Set(ByVal Value As Integer)
            iId = Value
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

    Public Property MoisAnnee() As Date
        Get
            Return dMoisAnnee
        End Get
        Set(ByVal Value As Date)
            'TODO : vérification de la date entrée
            dMoisAnnee = Value
        End Set
    End Property
    'la date sera mise au niveau constructeur et ne pourra pas être modifée par la suite
    Public ReadOnly Property DateCreation() As Date
        Get
            Return dDateCreation
        End Get
    End Property

    Public Property DureeJournee() As Byte
        Get
            Return bDureeJournee
        End Get
        Set(ByVal Value As Byte)
            If Value < 0 Or Value > 24 Then
                Throw (New ErrorPlanning.InvalidDureeJournee)
            End If
            bDureeJournee = Value
        End Set
    End Property

    Public Property PersonneCree() As clsPersonne
        Get
            Return objPersonneCree
        End Get
        Set(ByVal Value As clsPersonne)
            'TODO un test pas de changement attention
            objPersonneCree = Value
        End Set
    End Property

#Region "gestion des prestations"

    'renvoi vrai si la prestation fait partie du planning
    Public Function IsPrestation(ByVal pPrestation As clsPrestation) As Boolean

        If objPrestations.Contains(pPrestation) Then
            Return True
        Else
            Return False
        End If

    End Function
    'renvoi une erreur si la prestation fait deja partie du planning
    Public Sub AddPrestation(ByVal pPrestation As clsPrestation)
        If IsPrestation(pPrestation) Then
            Throw (New ErrorPlanning.DuplicatePrestation)
        End If
        objPrestations.Add(pPrestation)
    End Sub
    'renvoi une erreur si la prestation ne fait pas partie du planning

    Public Sub RemovePrestation(ByVal pPrestation As clsPrestation)
        If Not IsPrestation(pPrestation) Then
            Throw (New ErrorPlanning.InvalidPrestation)
        End If
        objPrestations.Remove(pPrestation)
    End Sub
    'Renvoie une interface IEnumerator qui permet le parcours de la collection sans permettre de modification
    Public ReadOnly Property Asignations() As IEnumerator
        Get
            Return objPrestations.GetEnumerator
        End Get
    End Property

#End Region

End Class
