
Namespace ErrorFacture

    Public Class InvalidNumero
        Inherits Exception

        Public Sub New()
            MyBase.New("Le numéro de facture doit être supérieur à 1 et inférieur à " & Integer.MaxValue)
        End Sub
    End Class

    Public Class InvalidMontant
        Inherits Exception

        Public Sub New()
            MyBase.New("Le montant de la facture ne peut pas être négatif")
        End Sub
    End Class

End Namespace

Namespace ErrorPersonne

    Public Class InvalidCode
        Inherits Exception

        Public Sub New()
            MyBase.New("Le code doit être constitué de 3 caractères")
        End Sub
    End Class

    Public Class DuplicateCode
        Inherits Exception

        Public Sub New()
            MyBase.New("Code déjà attribué")
        End Sub

    End Class

    Public Class InvalidLibelle
        Inherits Exception

        Public Sub New()
            MyBase.New("La longueur du libelle doit être comprise entre 5 et 50 caractères")
        End Sub
    End Class

    Public Class InvalidNom
        Inherits Exception

        Public Sub New()
            MyBase.New("La longueur du nom doit être comprise entre 3 et 50 caractères")
        End Sub
    End Class

    Public Class InvalidPrenom
        Inherits Exception

        Public Sub New()
            MyBase.New("La longueur du prénom doit être comprise entre 3 et 50 caractères")
        End Sub
    End Class

    Public Class DuplicateAssignation
        Inherits Exception

        Public Sub New()
            MyBase.New("L'assignation est deja liée a cette personne")
        End Sub
    End Class

    Public Class NotAssignation
        Inherits Exception

        Public Sub New()
            MyBase.New("L'assignation n'est pas liée a cette personne")
        End Sub
    End Class

End Namespace

Namespace ErrorRessource

    Public Class InvalidCoutDefaut
        Inherits Exception

        Public Sub New()
            MyBase.New("le cout par défaut d'une resource ne peut être negatif")
        End Sub
    End Class

End Namespace

Namespace ErrorEquipe

    Public Class InvalidLibelle
        Inherits Exception

        Public Sub New()
            MyBase.New("La longueur du libelle doit être comprise entre 5 et 50 caractères")
        End Sub
    End Class

    Public Class DuplicateChef
        Inherits Exception

        Public Sub New()
            MyBase.New("La personne est déjà chef de cette équipe")
        End Sub
    End Class

    Public Class NotChef
        Inherits Exception

        Public Sub New()
            MyBase.New("La personne n'est pas chef de cette équipe")
        End Sub
    End Class

    Public Class DernierChef
        Inherits Exception

        Public Sub New()
            MyBase.New("Une equipe doit contenir au moins un chef")
        End Sub
    End Class

    Public Class DerniereRessource
        Inherits Exception

        Public Sub New()
            MyBase.New("Une equipe doit contenir au moins une ressource")
        End Sub
    End Class

    Public Class NotRessource
        Inherits Exception

        Public Sub New()
            MyBase.New("Cette ressource ne fait pas partie de l'equipe")
        End Sub
    End Class

End Namespace

Namespace ErrorProjet

    Public Class InvalidCode
        Inherits Exception

        Public Sub New()
            MyBase.New("Le code doit être constitué de 3 caractères")
        End Sub
    End Class

    Public Class InvalidLibelle
        Inherits Exception

        Public Sub New()
            MyBase.New("La longueur du libelle doit être comprise entre 5 et 50 caractères")
        End Sub
    End Class

    Public Class DuplicateFacture
        Inherits Exception

        Public Sub New()
            MyBase.New("La facture est deja liée au projet")
        End Sub
    End Class

    Public Class NotFacture
        Inherits Exception

        Public Sub New()
            MyBase.New("La facture ne fait pas partie du projet")
        End Sub
    End Class

    Public Class DuplicateAssignation
        Inherits Exception

        Public Sub New()
            MyBase.New("L'assignation est deja liée au projet")
        End Sub
    End Class

    Public Class NotAssignation
        Inherits Exception

        Public Sub New()
            MyBase.New("L'assignation ne fait pas partie du projet")
        End Sub
    End Class

#Region "Projet Formation "

    Public Class InvalidNbJours
        Inherits Exception

        Public Sub New()
            MyBase.New("Le projet doit compter au moins un jour")
        End Sub
    End Class

    Public Class InvalidPrixUnitaire
        Inherits Exception

        Public Sub New()
            MyBase.New("Le prix unitaire ne peut pas être négatif")
        End Sub
    End Class

    Public Class InvalidNbParticipants
        Inherits Exception

        Public Sub New()
            MyBase.New("Le nombre de participants ne peut pas être négatif")
        End Sub
    End Class

    Public Class InvalidChiffreAffaire
        Inherits Exception

        Public Sub New()
            MyBase.New("Le chiffre d'affaire global du projet ne peut pas être négatif")
        End Sub
    End Class

#End Region

#Region "Projet Forfaitaire "

    Public Class InvalidPrixClient
        Inherits Exception

        Public Sub New()
            MyBase.New("Le prix client ne peut pas être négatif")
        End Sub
    End Class

    Public Class DuplicatePhase
        Inherits Exception

        Public Sub New()
            MyBase.New("La phase fait déjà partie du projet")
        End Sub
    End Class

    Public Class NotPhase
        Inherits Exception

        Public Sub New()
            MyBase.New("La phase ne fait pas partie du projet")
        End Sub
    End Class

#End Region

#Region "Projet Regie "

#End Region

End Namespace

Namespace ErrorPhase

    Public Class InvalidNumOrdre
        Inherits Exception

        Public Sub New()
            MyBase.New("Le numero d'ordre entré est invalide")
        End Sub
    End Class

    Public Class InvalidNbJours
        Inherits Exception

        Public Sub New()
            MyBase.New("Le nombre de jours ne peut pas être négatif")
        End Sub
    End Class

    Public Class InvalidLibelle
        Inherits Exception

        Public Sub New()
            MyBase.New("La longueur du libelle doit être comprise entre 5 et 50 caractères")
        End Sub
    End Class

End Namespace

Namespace ErrorAssignation

    Public Class InvalidLibelleRole
        Inherits Exception

        Public Sub New()
            MyBase.New("La longueur du libelle doit être comprise entre 5 et 50 caractères")
        End Sub
    End Class

    Public Class InvalidCout
        Inherits Exception

        Public Sub New()
            MyBase.New("Le cout ne peut pas être négatif")
        End Sub
    End Class

    Public Class InvalidProjet
        Inherits Exception

        Public Sub New()
            MyBase.New("Une assignation ne peut pas changer de projet")
        End Sub
    End Class

    Public Class InvalidRessource
        Inherits Exception

        Public Sub New()
            MyBase.New("Une assignation ne peut pas changer de ressource")
        End Sub
    End Class

    Public Class DuplicatePrestation
        Inherits Exception

        Public Sub New()
            MyBase.New("la prestation fait deja partie du planning")
        End Sub
    End Class

    Public Class InvalidPrestation
        Inherits Exception

        Public Sub New()
            MyBase.New("la prestation ne fait pas partie du planning")
        End Sub
    End Class


End Namespace

Namespace ErrorPlanning

    Public Class InvalidDureeJournee
        Inherits Exception

        Public Sub New()
            MyBase.New("une journée doit etre comprise entre 0 et 24 h")
        End Sub
    End Class

    Public Class DuplicatePrestation
        Inherits Exception

        Public Sub New()
            MyBase.New("la prestation fait deja partie du planning")
        End Sub
    End Class

    Public Class InvalidPrestation
        Inherits Exception

        Public Sub New()
            MyBase.New("la prestation ne fait pas partie du planning")
        End Sub
    End Class

End Namespace

Namespace ErrorPrestation

    Public Class InvalidAssignation
        Inherits Exception

        Public Sub New()
            MyBase.New("Une prestation ne peut pas changer d'assignation")
        End Sub
    End Class

    Public Class InvalidPlanning
        Inherits Exception

        Public Sub New()
            MyBase.New("Une prestation ne peut pas changer de planning")
        End Sub
    End Class

    Public Class InvalidPhase
        Inherits Exception

        Public Sub New()
            MyBase.New("Une prestation ne peut pas changer de phase")
        End Sub
    End Class

End Namespace