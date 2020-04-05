Imports EzErrors

Public Class clsEquipe

    Private sLibelle As String
    'Contient des objets clsPersonne
    Private objChefsEquipe As New ArrayList

    'Contient des objets clsRessource
    'Private objEffectifs As New ArrayList

    'Demande au moins un chef!
    Sub New(ByVal pLibelle As String, ByVal ParamArray pChefEquipe() As clsPersonne)
        Dim i As Integer
        Libelle = pLibelle
        For i = 0 To pChefEquipe.Length - 1
            AddChef(pChefEquipe(i))
        Next
    End Sub

    Public Property Libelle() As String
        Get
            Return sLibelle
        End Get
        Set(ByVal Value As String)
            If Value.Length < 3 Or Value.Length > 50 Then
                Throw (New ErrorEquipe.InvalidLibelle)
            End If
            sLibelle = Value
        End Set
    End Property

#Region "gestion des chefs"

    'renvoie true si la personne est chef de cette équipe
    Public Function IsChef(ByVal pPersonne As clsPersonne) As Boolean
        If objChefsEquipe.Contains(pPersonne) Then
            Return True
        Else
            Return False
        End If
    End Function
    'Lance une exception si on essaye d'ajouter deux fois la même personne comme chef
    Public Sub AddChef(ByVal pChef As clsPersonne)
        If IsChef(pChef) Then
            Throw (New ErrorEquipe.DuplicateChef)
        End If
        objChefsEquipe.Add(pChef)
    End Sub
    'Lance une exception si on essaye de retirer le dernier chef ou si la personne n'est pas chef
    Public Sub RemoveChef(ByVal pChef As clsPersonne)
        If Not IsChef(pChef) Then
            Throw (New ErrorEquipe.NotChef)
        End If
        If objChefsEquipe.Count < 1 Then
            Throw (New ErrorEquipe.DernierChef)
        End If
        objChefsEquipe.Remove(pChef)
    End Sub
    'Renvoie une interface IEnumerator qui permet le parcours de la collection sans permettre de modification
    Public ReadOnly Property ChefsEquipe() As IEnumerator
        Get
            Return objChefsEquipe.GetEnumerator()
        End Get
    End Property

#End Region

#Region "gestion des ressources"

    'renvoie true si la personne est une ressource de l'equipe
    Public Function isEffectif(ByVal pRessource As clsRessource) As Boolean
        If objEffectifs.Contains(pRessource) Then
            Return True
        Else
            Return False
        End If
    End Function
    'Ne fait rien si on essaye d'ajouter deux fois la même personne comme ressource
    ' Lancer une exception pourrait empecher le bon fonctionnement du cote personne et inversement !
    Public Sub AddEffectif(ByVal pRessource As clsRessource)
        If Not isEffectif(pRessource) Then
            pRessource.Equipe = Me
            objEffectifs.Add(pRessource)
        End If
    End Sub
    'Lance une exception si on essaye de retirer la derniere ressource ou si la personne n'est pas une ressource
    Public Sub RemoveEffectif(ByVal pRessource As clsRessource)
        If Not isEffectif(pRessource) Then
            Throw (New ErrorEquipe.NotRessource)
        End If
        If objEffectifs.Count < 1 Then
            Throw (New ErrorEquipe.DerniereRessource)
        End If
        objChefsEquipe.Remove(pRessource)
    End Sub
    'Renvoie une interface IEnumerator qui permet le parcours de la collection sans permettre de modification
    Public ReadOnly Property Effectifs() As IEnumerator
        Get
            Return objEffectifs.GetEnumerator()
        End Get
    End Property

#End Region

End Class
