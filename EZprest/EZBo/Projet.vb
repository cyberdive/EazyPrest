Imports EzErrors

Public MustInherit Class clsProjet

    Private iId As Integer
    Private sCode As String
    Private sLibelle As String
    Private bDerniereModification As Byte()
    Private objFactures As New ArrayList
    'Private objAssignations As New ArrayList

    Public Sub New(ByVal pCode As String, ByVal pLibelle As String)
        Code = pCode
        Libelle = pLibelle
    End Sub

    Public Property Id() As Integer
        Get
            Return iId
        End Get
        Set(ByVal Value As Integer)
            iId = Value
        End Set
    End Property

    Public Property Code() As String
        Get
            Return sCode
        End Get
        Set(ByVal Value As String)
            If Not Value.Length = 6 Then
                Throw (New ErrorProjet.InvalidCode)
            End If
            sCode = Value
        End Set
    End Property

    Public Property Libelle() As String
        Get
            Return sLibelle
        End Get
        Set(ByVal Value As String)
            If Value.Length < 3 Or Value.Length > 50 Then
                Throw (New ErrorProjet.InvalidLibelle)
            End If
            sLibelle = Value
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

#Region "gestion des factures"

    'Renvoi true si la facture appartient au projet
    Public Function IsFacture(ByVal pFacture As clsFacture) As Boolean
        If objFactures.Contains(pFacture) Then
            Return True
        Else
            Return False
        End If
    End Function
    'lance une erreur si la facture fait deja partie du projet
    Public Sub AddFacture(ByVal pFacture As clsFacture)
        If IsFacture(pFacture) Then
            Throw (New ErrorProjet.DuplicateFacture)
        End If
        objFactures.Add(pFacture)
    End Sub
    'lance une erreur si on tente de retirer une facture ne faisant pas partie du projet
    Public Sub RemoveFacture(ByVal pFacture As clsFacture)
        If Not IsFacture(pFacture) Then
            Throw (New ErrorProjet.NotFacture)
        End If
        objFactures.Remove(pFacture)
    End Sub
    'Renvoie une interface IEnumerator qui permet le parcours de la collection sans permettre de modification
    Public ReadOnly Property Factures() As IEnumerator
        Get
            Return objFactures.GetEnumerator
        End Get
    End Property

#End Region

    'TODO : plein de soucis !!!
    '#Region "gestion des assignations"

    '    'renvoi vrai si l'assignation fait partie du projet
    '    Public Function IsAssignation(ByVal pAssignation As clsAssignation) As Boolean

    '        If objAssignations.Contains(pAssignation) Then
    '            Return True
    '        Else
    '            Return False
    '        End If

    '    End Function
    '    'renvoi une erreur si l'assignation est fait deja partie du projet
    '    Public Sub AddAssignation(ByVal pAssignation As clsAssignation)
    '        If IsAssignation(pAssignation) Then
    '            Throw (New ErrorProjet.DuplicateAssignation)
    '        End If
    '        'TODO : attention une assignation ne doit pas pouvoir changer de projet
    '        objAssignations.Add(pAssignation)
    '    End Sub
    '    ' TODO : renvoi une erreur si l'assignation ne fait pas partie du projet
    '    ' ce qui peut causer un probleme au niveau de la gestion de la classe assignations
    '    Public Sub RemoveAssignation(ByVal pAssignation As clsAssignation)
    '        If Not IsAssignation(pAssignation) Then
    '            Throw (New ErrorProjet.NotAssignation)
    '        End If
    '        'TODO : a vérifier mais retirer une assignation ne devrait pas detuire l'assignation ?
    '        objAssignations.Remove(pAssignation)
    '    End Sub
    '    'Renvoie une interface IEnumerator qui permet le parcours de la collection sans permettre de modification
    '    Public ReadOnly Property Asignations() As IEnumerator
    '        Get
    '            Return objAssignations.GetEnumerator
    '        End Get
    '    End Property


    '#End Region

End Class

Public Class clsProjetFormation
    Inherits clsProjet

    Private sNbJours As Short
    Private dPrixUnitaire As Decimal
    Private sNbParticipants As Short
    Private dChiffreAffaire As Decimal

    Public Sub New(ByVal pCode As String, ByVal pLibelle As String, ByVal pNbJours As Short, ByVal pPrixUnitaire As Decimal, ByVal pNbParticipants As Short, ByVal pChiffreAffaire As Decimal)

        MyBase.New(pCode, pLibelle)
        NbJours = pNbJours
        PrixUnitaire = pPrixUnitaire
        NbParticipants = pNbParticipants
        ChiffreAffaire = pChiffreAffaire

    End Sub

    Public Property NbJours() As Short
        Get
            Return sNbJours
        End Get
        Set(ByVal Value As Short)
            If Value < 1 Then
                Throw (New ErrorProjet.InvalidNbJours)
            End If
            sNbJours = Value
        End Set
    End Property

    Public Property PrixUnitaire() As Decimal
        Get
            Return dPrixUnitaire
        End Get
        Set(ByVal Value As Decimal)
            If Value < 0 Then
                Throw (New ErrorProjet.InvalidPrixUnitaire)
            End If
            dPrixUnitaire = Value
        End Set
    End Property

    Public Property NbParticipants() As Short
        Get
            Return sNbParticipants
        End Get
        Set(ByVal Value As Short)
            If Value < 0 Then
                Throw (New ErrorProjet.InvalidNbParticipants)
            End If
            sNbParticipants = Value
        End Set
    End Property

    Public Property ChiffreAffaire() As Decimal
        Get
            Return dChiffreAffaire
        End Get
        Set(ByVal Value As Decimal)
            If Value < 0 Then
                Throw (New ErrorProjet.InvalidChiffreAffaire)
            End If
        End Set
    End Property

End Class

Public Class clsProjetForfaitaire
    Inherits clsProjet

    ' le nombre de jours sera recalculé a chaque ajout suppression de phase ^^
    Private sNbJours As Short
    Private dPrixClient As Decimal
    'contient des phases'
    Private objPhases As ArrayList

    Public Sub New(ByVal pCode As String, ByVal pLibelle As String, ByVal pPrixClient As Decimal)

        MyBase.New(pCode, pLibelle)
        PrixClient = pPrixClient
        sNbJours = -1

    End Sub

    Public Property PrixClient() As Decimal
        Get
            Return dPrixClient
        End Get
        Set(ByVal Value As Decimal)
            If Value < 0 Then
                Throw (New ErrorProjet.InvalidPrixClient)
            End If
            dPrixClient = Value
        End Set
    End Property

    Public Function CalculNbJours() As Short

        Dim totalNbJours As Short = 0
        Dim objPhase As clsPhase

        For Each objPhase In objPhases
            totalNbJours += objPhase.NbJours
        Next
        If totalNbJours = 0 Then
            Return -1
        Else
            Return totalNbJours
        End If
    End Function

    Public ReadOnly Property NbJours() As Short
        Get
            If sNbJours = -1 Then
                Return CalculNbJours()
            Else
                Return sNbJours
            End If
        End Get
    End Property

#Region "gestion des phases "

    ' renvoi true si la phase fait partie du projet
    Public Function IsPhase(ByVal pPhase As clsPhase) As Boolean

        If objPhases.Contains(pPhase) Then
            Return True
        Else
            Return False
        End If

    End Function
    'lance une exception si la phase fait deja partie du projet
    Public Sub AddPhase(ByVal pPhase As clsPhase)
        If IsPhase(pPhase) Then
            Throw (New ErrorProjet.DuplicatePhase)
        Else
            'TODO : peut etre remplir ici le numero d'ordre de la phase ?
            objPhases.Add(pPhase)
        End If

    End Sub
    'lance une exception si la phase ne fait pas partie du projet
    Public Sub RemovePhase(ByVal pPhase As clsPhase)
        If Not IsPhase(pPhase) Then
            Throw (New ErrorProjet.NotPhase)
        Else
            'TODO : mettre a jours les phases ou non ?
            objPhases.Remove(pPhase)
        End If
    End Sub
    'Renvoie une interface IEnumerator qui permet le parcours de la collection sans permettre de modification
    Public ReadOnly Property Phases() As IEnumerator
        Get
            Return objPhases.GetEnumerator()
        End Get
    End Property

#End Region

End Class

Public Class clsProjetRegie
    Inherits clsProjet

    Public Sub New(ByVal pCode As String, ByVal pLibelle As String)

        MyBase.New(pCode, pLibelle)

    End Sub

End Class

Public Class clsPhase
    'le num est il calculé par la DB ?? et si oui comment ^^
    Private bNumOrdre As Byte
    Private sNbJours As Short
    Private sLibelle As String
    Private bDerniereModification As Byte()

    Public Sub New(ByVal pNbJours As Short, ByVal pLibelle As String)

        NbJours = pNbJours
        Libelle = pLibelle

    End Sub

    Public Property NumOrdre() As Byte
        Get
            Return bNumOrdre
        End Get
        Set(ByVal Value As Byte)
            If Value < 1 Then
                Throw (New ErrorPhase.InvalidNumOrdre)
            End If
            bNumOrdre = Value
        End Set
    End Property

    Public Property NbJours() As Short
        Get
            Return sNbJours
        End Get
        Set(ByVal Value As Short)
            If Value < 1 Then
                Throw (New ErrorPhase.InvalidNbJours)
            End If
            sNbJours = Value
        End Set
    End Property

    Public Property Libelle() As String
        Get
            Return sLibelle
        End Get
        Set(ByVal Value As String)
            If Value.Length < 5 Or Value.Length > 50 Then
                Throw (New ErrorPhase.InvalidLibelle)
            End If
            sLibelle = Value
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

End Class
