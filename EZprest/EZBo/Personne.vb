Imports EzErrors

Public Class clsPersonne

    Private iId As Integer
    Private sCode As String
    Private sLibelle As String
    Private sNom As String
    Private sPrenom As String
    Private bDerniereModification As Byte()

    Public Sub New(ByVal pCode As String, ByVal pLibelle As String, ByVal pNom As String, ByVal pPrenom As String)

        Code = pCode
        Libelle = pLibelle
        Nom = pNom
        Prenom = pPrenom

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
            If Not Value.Length = 3 Then
                Throw (New ErrorPersonne.InvalidCode)
            End If
            sCode = Value
        End Set
    End Property

    Public Property Libelle() As String
        Get
            Return sLibelle
        End Get
        Set(ByVal Value As String)
            If Value.Length > 5 Or Value.Length < 50 Then
                Throw (New ErrorPersonne.InvalidLibelle)
            End If
            sLibelle = Value
        End Set
    End Property

    Public Property Nom() As String
        Get
            Return sNom
        End Get
        Set(ByVal Value As String)
            If Value.Length < 3 Or Value.Length > 50 Then
                Throw (New ErrorPersonne.InvalidNom)
            End If
        End Set
    End Property

    Public Property Prenom() As String
        Get
            Return sPrenom
        End Get
        Set(ByVal Value As String)
            If Value.Length < 3 Or Value.Length > 50 Then
                Throw (New ErrorPersonne.InvalidPrenom)
            End If
            sPrenom = Value
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

Public Class clsRessource
    Inherits clsPersonne

    Private dCoutDefaut As Decimal
    Private sEquipe As String
    'contient des clsAssignations
    Private objAssignations As New ArrayList

    Public Sub New(ByVal pCode As String, ByVal pLibelle As String, ByVal pNom As String, ByVal pPrenom As String, ByVal pCoutDefaut As Decimal, ByVal pEquipe As clsEquipe)

        MyBase.New(pCode, pLibelle, pNom, pPrenom)
        CoutDefaut = pCoutDefaut
        Equipe = pEquipe

    End Sub

    Public Property CoutDefaut() As Decimal
        Get
            Return dCoutDefaut
        End Get
        Set(ByVal Value As Decimal)
            If Value < 0 Then
                Throw (New ErrorRessource.InvalidCoutDefaut)
            End If
            dCoutDefaut = Value
        End Set
    End Property

    Public Property Equipe() As clsEquipe
        Get
            Return objEquipe
        End Get
        Set(ByVal Value As clsEquipe)
            ' TODO : vérifier coté equipe si tout se passe bien
            ' si la nouvelle equipe n'est pas deja l'equipe de la ressource
            ' alors on change l'equipe
            ' Sinon on ne fait rien le changement a du etre effectué du coté equipe
            '
            If Not objEquipe Is Value Then
                objEquipe.RemoveEffectif(Me)
                objEquipe = Value
                objEquipe.AddEffectif(Me)
            End If
        End Set
    End Property

#Region "gestion des assignations"

    'renvoi vrai si l'assignation fait partie du projet
    Public Function IsAssignation(ByVal pAssignation As clsAssignation) As Boolean

        If objAssignations.Contains(pAssignation) Then
            Return True
        Else
            Return False
        End If

    End Function
    'renvoi une erreur si l'assignation est fait deja partie du projet
    Public Sub AddAssignation(ByVal pAssignation As clsAssignation)
        If IsAssignation(pAssignation) Then
            Throw (New ErrorPersonne.DuplicateAssignation)
        End If
        'TODO : attention une assignation ne doit pas pouvoir changer de ressource
        objAssignations.Add(pAssignation)
    End Sub
    ' TODO : renvoi une erreur si l'assignation ne fait pas partie de la ressource
    Public Sub RemoveAssignation(ByVal pAssignation As clsAssignation)
        If Not IsAssignation(pAssignation) Then
            Throw (New ErrorPersonne.NotAssignation)
        End If
        objAssignations.Remove(pAssignation)
    End Sub
    'Renvoie une interface IEnumerator qui permet le parcours de la collection sans permettre de modification
    Public ReadOnly Property Asignations() As IEnumerator
        Get
            Return objAssignations.GetEnumerator
        End Get
    End Property


#End Region

End Class
