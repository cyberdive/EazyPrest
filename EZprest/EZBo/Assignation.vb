Imports EzErrors

Public Class clsAssignation

    Private dCout As Decimal
    Private eRole As enumRole
    Private bDerniereModification As Byte()
    Private sCodeProjet As String
    Private sCodePersonne As String

    'contient des clsPrestation
    'Private objPrestations As ArrayList

    '
    ' TODO : heu ??? comment je gere les couts du projet regie ???
    '

    Public Sub New(ByVal pProjet As clsProjet, ByVal pRessource As clsRessource, ByVal pCout As Decimal, ByVal pRole As enumRole)

        Projet = pProjet
        Ressource = pRessource
        Cout = pCout
        Role = enumRole.role01
    End Sub
    ' surcharge du constructeur pour le cas du coup par defaut
    Public Sub New(ByVal pProjet As clsProjet, ByVal pRessource As clsRessource, ByVal pRole As enumRole)

        Projet = pProjet
        Ressource = pRessource
        Cout = pRessource.CoutDefaut
        Role = pRole

    End Sub

    Public Property Cout() As Decimal
        Get
            Return dCout
        End Get
        Set(ByVal Value As Decimal)
            If Value < 0 Then
                Throw (New ErrorAssignation.InvalidCout)
            End If
            dCout = Value
        End Set
    End Property

    Public Property Role() As enumRole
        Get
            Return eRole
        End Get
        Set(ByVal Value As enumRole)
            eRole = Value
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

    Public Property Ressource() As clsRessource
        Get
            Return objRessource
        End Get
        Set(ByVal Value As clsRessource)
            If Not objRessource Is Nothing Then
                Throw (New ErrorAssignation.InvalidRessource)
            End If
            'on met la reférence de la personne dans l'assignation
            'ensuite on met la reférence de l'assigantion dans la personne
            objRessource = Value
            objRessource.AddAssignation(Me)
        End Set
    End Property

    Public Property Projet() As clsProjet
        Get
            Return objProjet
        End Get
        Set(ByVal Value As clsProjet)
            If Not objProjet Is Nothing Then
                Throw (New ErrorAssignation.InvalidProjet)
            End If
            'on met la reférence du projet dans l'assignation
            'ensuite on met la reférence de l'assigantion dans le projet
            objProjet = Value
            objProjet.AddAssignation(Me)
        End Set
    End Property

#Region "gestion des prestations"

    'renvoi vrai si la prestation fait partie de l'assignation
    Public Function IsPrestation(ByVal pPrestation As clsPrestation) As Boolean

        If objPrestations.Contains(pPrestation) Then
            Return True
        Else
            Return False
        End If

    End Function
    'renvoi une erreur si la prestation fait deja partie de l'assignation
    Public Sub AddPrestation(ByVal pPrestation As clsPrestation)
        If IsPrestation(pPrestation) Then
            Throw (New ErrorAssignation.DuplicatePrestation)
        End If
        objPrestations.Add(pPrestation)
    End Sub
    'renvoi une erreur si la prestation ne fait pas partie de l'assignation
    Public Sub RemovePrestation(ByVal pPrestation As clsPrestation)
        If Not IsPrestation(pPrestation) Then
            Throw (New ErrorAssignation.InvalidPrestation)
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
