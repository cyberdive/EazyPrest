Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports EZBo
Imports EzDal

<System.Web.Services.WebService(Namespace:="http://tempuri.org/EZwebservice/EZService")> _
Public Class ServiceEZPrest
    Inherits System.Web.Services.WebService

#Region " Web Services Designer Generated Code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Web Services Designer.
        InitializeComponent()

        'Add your own initialization code after the InitializeComponent() call

    End Sub

    'Required by the Web Services Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Web Services Designer
    'It can be modified using the Web Services Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        'CODEGEN: This procedure is required by the Web Services Designer
        'Do not modify it using the code editor.
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

#End Region

#Region "Historique Affectations"

    <WebMethod()> _
    Public Function GetHistoriqueAffectation() As DataSet
        Try
            Return EzDal.clsEzDal.GetHistoriqueAffectation(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")))
        Catch ex As Exception
            Throw New SoapException(ex.Message, SoapException.ClientFaultCode, ex.Message)
        End Try
    End Function

    <WebMethod()> _
    Public Function GetHistoriqueAffectationParEquipe(ByVal pLibelleEquipe As String) As DataSet
        Try
            Return EzDal.clsEzDal.GetHistoriqueAffectationParEquipe(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")), pLibelleEquipe)
        Catch ex As Exception
            Throw New SoapException(ex.Message, SoapException.ClientFaultCode, ex.Message)
        End Try
    End Function

    <WebMethod()> _
    Public Function GetHistoriqueAffectationParEmploye(ByVal pCodePersonne As String) As DataSet
        Return EzDal.clsEzDal.GetHistoriqueAffectationParRessource(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")), pCodePersonne)
    End Function

#End Region

#Region "Historique des changements de statut"

    <WebMethod()> _
    Public Function GetHistoriqueChangementStatut() As DataSet
        Try
            Return EzDal.clsEzDal.GetHistoriqueStatut(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")))
        Catch ex As Exception
            Throw New SoapException(ex.Message, SoapException.ClientFaultCode, ex.Message)
        End Try
    End Function

    <WebMethod()> _
    Public Function GetHistoriqueChangementStatutParCriteres(ByVal pDatePrestation As Date, ByVal pCodeProjet As String, ByVal pCodeRessource As String) As DataSet
        Try
            Return EzDal.clsEzDal.GetHistoriqueStatutParCritere(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")), pDatePrestation, pCodeProjet, pCodeRessource)
        Catch ex As Exception
            Throw New SoapException(ex.Message, SoapException.ClientFaultCode, ex.Message)
        End Try
    End Function

#End Region

#Region "Personnes Ressources"

#Region "Get"

    <WebMethod()> _
    Public Function GetAllEmployes() As DataSet
        Try
            Return clsEzDal.GetAllEmployes(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")))
        Catch ex As Exception
            Throw New SoapException(ex.Message, SoapException.ClientFaultCode, ex.Message)
        End Try
    End Function

    <WebMethod()> _
    Public Function GetOnlyEmployes() As DataSet
        Try
            Return clsEzDal.GetOnlyPersonne(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")))
        Catch ex As Exception
            Throw New SoapException(ex.Message, SoapException.ClientFaultCode, ex.Message)
        End Try
    End Function

    <WebMethod()> _
    Public Function GetOnlyRessources() As DataSet
        Try
            Return clsEzDal.GetOnlyRessource(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")))
        Catch ex As Exception
            Throw New SoapException(ex.Message, SoapException.ClientFaultCode, ex.Message)
        End Try
    End Function

    <WebMethod()> _
    Public Function GetEmployesParCode(ByVal pCodeEmploye As String) As DataSet
        Try
            Return clsEzDal.GetEmployesParCode(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")), pCodeEmploye)
        Catch ex As Exception
            Throw New SoapException(ex.Message, SoapException.ClientFaultCode, ex.Message)
        End Try
    End Function

    <WebMethod()> _
    Public Function GetEmployesParNom(ByVal pNomEmploye As String) As DataSet
        Try
            Return clsEzDal.GetEmployesParNom(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")), pNomEmploye)
        Catch ex As Exception
            Throw New SoapException(ex.Message, SoapException.ClientFaultCode, ex.Message)
        End Try
    End Function

    <WebMethod()> _
    Public Function GetEmployesParEquipe(ByVal pNomEquipe As String) As DataSet
        Try
            Return clsEzDal.GetEmployesParEquipe(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")), pNomEquipe)
        Catch ex As Exception
            Throw New SoapException(ex.Message, SoapException.ClientFaultCode, ex.Message)
        End Try
    End Function

    'Récupère la FICHE COMPLETE ! destinée aux modifications
    <WebMethod()> _
    Public Function GetFicheEmploye(ByVal pCode As String) As clsPersonne
        Try
            Return Factory.GetEmploye(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")), pCode)
        Catch ex As Exception
            Throw New SoapException(ex.Message, SoapException.ClientFaultCode, ex.Message)
        End Try
    End Function

    'Récupère la fiche complète d'une ressource
    <WebMethod()> _
    Public Function GetFicheRessource(ByVal pCode As String) As clsRessource
        Try
            Return Factory.GetRessource(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")), pCode)
        Catch ex As Exception
            Throw New SoapException(ex.Message, SoapException.ClientFaultCode, ex.Message)
        End Try
    End Function

#End Region

#Region "Insert, Update, Delete"

    <WebMethod()> _
    Public Sub InsertNewEmploye(ByVal pCode As String, ByVal pNom As String, ByVal pPrenom As String, ByVal pLibelle As String)
        Try
            'Contrôle des contraintes d'intégrité
            Dim objPersonne As New clsPersonne
            objPersonne.Code = pCode
            objPersonne.Nom = pNom
            objPersonne.Prenom = pPrenom
            objPersonne.Libelle = pLibelle

            clsEzDal.InsertPersonne(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")), objPersonne.Code, objPersonne.Libelle, objPersonne.Nom, objPersonne.Prenom)
        Catch ex As Exception
            Throw New SoapException(ex.Message, SoapException.ClientFaultCode, ex.Message)
        End Try
    End Sub

    <WebMethod()> _
    Public Sub UpdateEmploye(ByVal pIdEmploye As Integer, ByVal pCode As String, ByVal pNom As String, ByVal pPrenom As String, _
                             ByVal pLibelle As String, ByVal pDerniereModification As Byte())
        Try
            'Contrôle des contraintes d'intégrité
            Dim objPersonne As New clsPersonne
            objPersonne.Id = pIdEmploye
            objPersonne.Code = pCode
            objPersonne.Nom = pNom
            objPersonne.Prenom = pPrenom
            objPersonne.Libelle = pLibelle
            objPersonne.DerniereModification = pDerniereModification

            clsEzDal.UpdatePersonne(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")), objPersonne.Id, objPersonne.Code, objPersonne.Libelle, objPersonne.Nom, objPersonne.Prenom, objPersonne.DerniereModification)
        Catch ex As Exception
            Throw New SoapException(ex.Message, SoapException.ClientFaultCode, ex.Message)
        End Try
    End Sub

    <WebMethod()> _
   Public Sub InsertNewRessource(ByVal pCode As String, ByVal pNom As String, ByVal pPrenom As String, ByVal pLibelleRessource As String, _
                                 ByVal pCoutDefaut As Decimal, ByVal pLibelleEquipe As String, ByVal pDateDebutAffectation As Date)
        Try
            'Contrôle des contraintes d'intégrité
            Dim objRessource As New clsRessource
            objRessource.Code = pCode
            objRessource.Nom = pNom
            objRessource.Prenom = pPrenom
            objRessource.Libelle = pLibelleRessource
            objRessource.CoutDefaut = pCoutDefaut
            objRessource.Equipe = pLibelleEquipe
            objRessource.DateDebutAffectation = pDateDebutAffectation

            clsEzDal.InsertRessource(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")), objRessource.Code, objRessource.Libelle, _
                                     objRessource.Nom, objRessource.Prenom, objRessource.CoutDefaut, objRessource.Equipe, objRessource.DateDebutAffectation)
        Catch ex As Exception
            Throw New SoapException(ex.Message, SoapException.ClientFaultCode, ex.Message)
        End Try
    End Sub

    <WebMethod()> _
    Public Sub UpdateRessource(ByVal pIdRessource As Integer, ByVal pCode As String, ByVal pNom As String, ByVal pPrenom As String, ByVal pLibelleRessource As String, ByVal pCoutDefaut As Decimal, _
                               ByVal pLibelleEquipe As String, ByVal pDerniereModification As Byte())
        Try
            'Contrôle des contraintes d'intégrité
            Dim objRessource As New clsRessource
            objRessource.Id = pIdRessource
            objRessource.Code = pCode
            objRessource.Nom = pNom
            objRessource.Prenom = pPrenom
            objRessource.Libelle = pLibelleRessource
            objRessource.CoutDefaut = pCoutDefaut
            objRessource.Equipe = pLibelleEquipe
            objRessource.DerniereModification = pDerniereModification

            clsEzDal.UpdateRessource(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")), objRessource.Id, objRessource.Code, objRessource.Libelle, _
                                     objRessource.Nom, objRessource.Prenom, objRessource.CoutDefaut, objRessource.Equipe, objRessource.DerniereModification)
        Catch ex As Exception
            Throw New SoapException(ex.Message, SoapException.ClientFaultCode, ex.Message)
        End Try
    End Sub

    <WebMethod()> _
    Public Sub RessourceToPersonne(ByVal pCodeRessource As String)
        Try
            clsEzDal.RessourceToPersonne(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")), pCodeRessource)
        Catch ex As Exception
            Throw New SoapException(ex.Message, SoapException.ClientFaultCode, ex.Message)
        End Try
    End Sub

    <WebMethod()> _
    Public Sub PersonneToRessource(ByVal pCodePersonne As String, ByVal pCoutDefautRessource As Decimal, ByVal pEquipe As String, ByVal pDateDebutAffectationEquipe As Date)
        Try
            'contrôle des contraintes d'intégrité
            Dim objRessource As New clsRessource
            objRessource.CoutDefaut = pCoutDefautRessource
            objRessource.Equipe = pEquipe
            objRessource.DateDebutAffectation = pDateDebutAffectationEquipe

            clsEzDal.PersonneToRessource(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")), pCodePersonne, pCoutDefautRessource, pEquipe, pDateDebutAffectationEquipe)
        Catch ex As Exception
            Throw New SoapException(ex.Message, SoapException.ClientFaultCode, ex.Message)
        End Try
    End Sub

#End Region

#End Region

#Region "Equipe"

    <WebMethod()> _
    Public Function GetAllLibellesEquipes() As String()
        Try
            Return Factory.GetAllLibelleEquipe(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")))
        Catch ex As Exception
            Throw New SoapException(ex.Message, SoapException.ClientFaultCode, ex.Message)
        End Try
    End Function

    <WebMethod()> _
    Public Function GetAllEquipes() As DataSet
        Try
            Return EzDal.clsEzDal.GetAllEquipes(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")))
        Catch ex As Exception
            Throw New SoapException(ex.Message, SoapException.ClientFaultCode, ex.Message)
        End Try
    End Function

    <WebMethod()> _
    Public Function GetFicheEquipe(ByVal pLibelleEquipe As String) As clsEquipe
        Try
            Return Factory.GetFicheEquipe(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")), pLibelleEquipe)
        Catch ex As Exception
            Throw New SoapException(ex.Message, SoapException.ClientFaultCode, ex.Message)
        End Try
    End Function

    <WebMethod()> _
    Public Sub InsertNewEquipe(ByVal pLibelleEquipe As String, ByVal pCodeChef As String)
        Try
            Dim objEquipe As clsEquipe = Factory.GetNewEquipe(pLibelleEquipe, pCodeChef)
            EzDal.clsEzDal.InsertEquipe(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")), objEquipe.Libelle, objEquipe.ChefsEquipe(0))
        Catch ex As Exception
            Throw New SoapException(ex.Message, SoapException.ClientFaultCode, ex.Message)
        End Try
    End Sub

    <WebMethod()> _
    Public Sub AddChef(ByVal pLibelleEquipe As String, ByVal pCodeChef As String)
        Try
            EzDal.clsEzDal.InsertChef(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")), pLibelleEquipe, pCodeChef)
        Catch ex As Exception
            Throw New SoapException(ex.Message, SoapException.ClientFaultCode, ex.Message)
        End Try
    End Sub

    <WebMethod()> _
    Public Sub RemoveChef(ByVal pLibelleEquipe As String, ByVal pCodeChef As String)
        Try
            EzDal.clsEzDal.DeleteChef(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")), pLibelleEquipe, pCodeChef)
        Catch ex As Exception
            Throw New SoapException(ex.Message, SoapException.ClientFaultCode, ex.Message)
        End Try
    End Sub

    <WebMethod()> _
    Public Sub UpdateEquipe(ByVal pOldLibelleEquipe As String, ByVal pNewLibelleEquipe As String, ByVal pDerniereModification As Byte())
        Try
            EzDal.clsEzDal.UpdateEquipe(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")), pOldLibelleEquipe, pNewLibelleEquipe, pDerniereModification)
        Catch ex As Exception
            Throw New SoapException(ex.Message, SoapException.ClientFaultCode, ex.Message)
        End Try
    End Sub

    <WebMethod()> _
    Public Function GetCodeChefsEquipe() As String()
        Try
            Return Factory.GetCodeChefsEquipe(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")))
        Catch ex As Exception
            Throw New SoapException(ex.Message, SoapException.ClientFaultCode, ex.Message)
        End Try
    End Function

#End Region

#Region "Assignation"

    <WebMethod()> _
    Public Function GetAllAssignations() As DataSet
        Try
            Return EzDal.clsEzDal.GetAllAssignations(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")))
        Catch ex As Exception
            Throw New SoapException(ex.Message, SoapException.ClientFaultCode, ex.Message)
        End Try
    End Function

    <WebMethod()> _
    Public Function GetAllAssignationsParCodeRessource(ByVal pCode As String) As DataSet
        Try
            Return EzDal.clsEzDal.GetAllAssignationsParCodeRessource(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")), pCode)
        Catch ex As Exception
            Throw New SoapException(ex.Message, SoapException.ClientFaultCode, ex.Message)
        End Try
    End Function

    <WebMethod()> _
    Public Function GetAllAssignationsParCodeProjet(ByVal pCode As String) As DataSet
        Try
            Return EzDal.clsEzDal.GetAllAssignationsParCodeProjet(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")), pCode)
        Catch ex As Exception
            Throw New SoapException(ex.Message, SoapException.ClientFaultCode, ex.Message)
        End Try
    End Function

    <WebMethod()> _
    Public Function GetAllAssignationsForfaitaire() As DataSet
        Try
            Return EzDal.clsEzDal.GetAllAssignationsForfaitaire(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")))
        Catch ex As Exception
            Throw New SoapException(ex.Message, SoapException.ClientFaultCode, ex.Message)
        End Try
    End Function

    <WebMethod()> _
    Public Function GetAllAssignationsRegie() As DataSet
        Try
            Return EzDal.clsEzDal.GetAllAssignationsRegie(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")))
        Catch ex As Exception
            Throw New SoapException(ex.Message, SoapException.ClientFaultCode, ex.Message)
        End Try
    End Function

    <WebMethod()> _
    Public Function GetAllAssignationsFormation() As DataSet
        Try
            Return EzDal.clsEzDal.GetAllAssignationsFormation(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")))
        Catch ex As Exception
            Throw New SoapException(ex.Message, SoapException.ClientFaultCode, ex.Message)
        End Try
    End Function

#End Region

#Region "Projet"

    <WebMethod()> _
    Public Function GetAllProjets() As DataSet
        Try
            Return EzDal.clsEzDal.GetAllProjets(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")))
        Catch ex As Exception
            Throw New SoapException(ex.Message, SoapException.ClientFaultCode, ex.Message)
        End Try
    End Function

    <WebMethod()> _
        Public Function GetAllProjetsFormation() As DataSet
        Try
            Return EzDal.clsEzDal.GetAllProjetsFormation(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")))
        Catch ex As Exception
            Throw New SoapException(ex.Message, SoapException.ClientFaultCode, ex.Message)
        End Try
    End Function

    <WebMethod()> _
        Public Function GetAllProjetsForfaitaire() As DataSet
        Try
            Return EzDal.clsEzDal.GetAllProjetsForfaitaire(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")))
        Catch ex As Exception
            Throw New SoapException(ex.Message, SoapException.ClientFaultCode, ex.Message)
        End Try
    End Function

    <WebMethod()> _
        Public Function GetAllProjetsRegie() As DataSet
        Try
            Return EzDal.clsEzDal.GetAllProjetsRegie(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")))
        Catch ex As Exception
            Throw New SoapException(ex.Message, SoapException.ClientFaultCode, ex.Message)
        End Try
    End Function

    <WebMethod()> _
    Public Function GetAllProjetsParCode(ByVal pCode As String) As DataSet
        Try
            Return EzDal.clsEzDal.GetAllProjetsParCode(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")), pCode)
        Catch ex As Exception
            Throw New SoapException(ex.Message, SoapException.ClientFaultCode, ex.Message)
        End Try
    End Function


    <WebMethod()> _
    Public Function GetAllProjetParLibelle(ByVal pLibelle As String) As DataSet
        Try
            Return EzDal.clsEzDal.GetAllProjetParLibelle(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")), pLibelle)
        Catch ex As Exception
            Throw New SoapException(ex.Message, SoapException.ClientFaultCode, ex.Message)
        End Try
    End Function

    <WebMethod()> _
    Public Function GetFicheProjetForfaitaire(ByVal pCode As String) As clsProjetForfaitaire
        Try
            Return Factory.GetFicheProjetForfaitaire(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")), pCode)
        Catch ex As Exception
            Throw New SoapException(ex.Message, SoapException.ClientFaultCode, ex.Message)
        End Try
    End Function

    <WebMethod()> _
    Public Function GetFicheProjetRegie(ByVal pCode As String) As clsProjetRegie
        Try
            Return Factory.GetFicheProjetRegie(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")), pCode)
        Catch ex As Exception
            Throw New SoapException(ex.Message, SoapException.ClientFaultCode, ex.Message)
        End Try
    End Function

    <WebMethod()> _
    Public Function GetFicheProjetFormation(ByVal pCode As String) As clsProjetFormation
        Try
            Return Factory.GetFicheProjetFormation(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")), pCode)
        Catch ex As Exception
            Throw New SoapException(ex.Message, SoapException.ClientFaultCode, ex.Message)
        End Try
    End Function

    <WebMethod()> _
    Public Function GetFactureParProjet(ByVal pCode As String) As DataSet
        Try
            Return EzDal.clsEzDal.GetFacturesParProjet(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")), pCode)
        Catch ex As Exception
            Throw New SoapException(ex.Message, SoapException.ClientFaultCode, ex.Message)
        End Try
    End Function

    <WebMethod()> _
    Public Function GetPhasesParProjet(ByVal pCode As String) As DataSet
        Try
            Return EzDal.clsEzDal.GetPhasesParProjet(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")), pCode)
        Catch ex As Exception
            Throw New SoapException(ex.Message, SoapException.ClientFaultCode, ex.Message)
        End Try
    End Function

    <WebMethod()> _
    Public Function GetChefsParProjet(ByVal pCode As String) As DataSet
        Try
            Return EzDal.clsEzDal.GetChefsParProjet(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")), pCode)
        Catch ex As Exception
            Throw New SoapException(ex.Message, SoapException.ClientFaultCode, ex.Message)
        End Try
    End Function

#End Region

#Region "Planning"

    <WebMethod()> _
    Public Sub GenererPlanning(ByVal pMoisAnnee As Date, ByVal pDureeJournee As Short)
        'TODO, avec la sécurité indiquer qui a généré le planning
        Try
            EzDal.clsEzDal.InsertPlanning(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")), pMoisAnnee, 2, pDureeJournee)
        Catch ex As Exception
            Throw New SoapException(ex.Message, SoapException.ClientFaultCode, ex.Message)
        End Try
    End Sub

    <WebMethod()> _
    Public Function GetPlanning(ByVal pMoisAnnee As Date) As DataSet
        Try
            'Return EzDal.clsEzDal.GetPlanning(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")), pMoisAnnee)
            Return EzDal.clsEzDal.Essai()
        Catch ex As Exception
            Throw New SoapException(ex.Message, SoapException.ClientFaultCode, ex.Message)
        End Try
    End Function

#End Region


End Class
