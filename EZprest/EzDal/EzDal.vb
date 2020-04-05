Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text
Public Class clsEzDal


    'TODO VA falloir que je contr�le la dynamique des statuts dans la DB
    'TODO Va falloir que je contr�le un peu les insertions dans les changements d'�quipes

#Region "Divers (Login, application r�le, connection, erreurs,..."

#Region "Connection, login, password"

    'Renvoie un tableau de byte repr�sentant le password en crypt�
    Public Shared Function GetCryptedPassword(ByVal pPasswordNonCrypte As String) As Byte()

        Dim sha1 As SHA1 = sha1.Create()
        Dim password As Byte()
        password = sha1.ComputeHash(Encoding.Unicode.GetBytes(pPasswordNonCrypte))
        Return password

    End Function

    'Compare deux password 
    Private Shared Function ComparePassword(ByVal pDbPassword As Byte(), ByVal pPassword As Byte()) As Boolean

        ReDim Preserve pPassword(50)

        Dim i As Integer
        For i = 0 To pDbPassword.Length - 1
            If (pDbPassword(i) <> pPassword(i)) Then
                Return False
            End If
        Next

        Return True
    End Function

    'Change un password
    Public Shared Sub ChangePassword(ByVal pUserLogin As String, ByVal pOldUserPassword As Byte(), ByVal pNewUserPassword As Byte())

        Dim objConnection As SqlConnection = GetConnection(pUserLogin, pOldUserPassword)

        Dim objCommand As SqlCommand = New SqlCommand
        'Construction de l'objet SqlCommand
        With objCommand
            .Connection = objConnection
            .CommandType = CommandType.StoredProcedure
            .CommandText = "ChangePassword"
            .Parameters.Add("@pUserLogin", SqlDbType.NVarChar, 50).Value = pUserLogin
            .Parameters.Add("@pOldUserPassword", SqlDbType.Binary, 50).Value = pOldUserPassword
            .Parameters.Add("@pNewUserPassword", SqlDbType.Binary, 50).Value = pNewUserPassword
        End With

        'Excecution de la commande
        Try
            objCommand.ExecuteNonQuery()
        Catch objSqlException As SqlException
            Throw GetExceptionFromSqlException(objSqlException)
        End Try
    End Sub

    'Cr�e un login, accesible uniquement au SA
    Public Shared Sub CreateDbLogin(ByVal pSqlConnection As SqlConnection, ByVal pIdUser As Integer, ByVal pUserLogin As String, ByVal pUserPassword As Byte(), ByVal pUserRole As String)

        Dim objCommand As SqlCommand = New SqlCommand
        'Construction de l'objet SqlCommand
        With objCommand
            .Connection = pSqlConnection
            .CommandType = CommandType.StoredProcedure
            .CommandText = "CreateDbLogin"
            .Parameters.Add("@pIdUser", SqlDbType.Int).Value = pIdUser
            .Parameters.Add("@pUserLogin", SqlDbType.NVarChar, 50).Value = pUserLogin
            .Parameters.Add("@pUserPassword", SqlDbType.Binary, 50).Value = pUserPassword
            .Parameters.Add("@pUserRole", SqlDbType.NVarChar, 50).Value = pUserRole
        End With

        'Excecution de la commande
        Try
            objCommand.ExecuteNonQuery()
        Catch objSqlException As SqlException
            Throw GetExceptionFromSqlException(objSqlException)
        End Try

    End Sub

    'Renvoie une connexion OUVERTE avec l'application r�le correspondant au login.
    Public Shared Function GetConnection(ByVal pUserLogin As String, ByVal pUserPassword As Byte()) As SqlConnection

        'Attention, le pooling de connexion est d�sactiv� pour la gestion des applications r�le
        'Consultez http://support.microsoft.com/default.aspx?scid=http://support.microsoft.com:80/support/kb/articles/Q229/5/64.asp&NoWebContent=1 pour plus de d�tails
        Dim objConnection As New SqlConnection("workstation id=RESERVOIRPROG;packet size=4096;user id=invit�;data source=RESERVOIRPROG;" & _
                                               "persist security info=False;initial catalog=EZPREST;pooling=false")

        Dim objDataSetLogin As DataSet


        'Contr�le du login et du password, chargement de l'application r�le
        Try
            objConnection.Open()
            objDataSetLogin = GetUserByLogin(objConnection, pUserLogin)
            With objDataSetLogin.Tables(0).Rows

                'Contr�le login et password
                If (.Count = 1) Then
                    Dim dbPassword As Byte()
                    dbPassword = CType(.Item(0).Item(2), Byte())
                    If ComparePassword(dbPassword, pUserPassword) = False Then
                        'TODO ajouter cette fonction � la biblioth�que d'erreur
                        Throw New Exception("Password invalide")
                    End If
                Else
                    'TODO ajouter cette fonction � la biblio d'erreur
                    Throw New Exception("Login invalide")
                End If

                'Chargement de l'application r�le
                Dim sApplicationRole As String = CType(.Item(0).Item(3), String)
                Dim objSqlCommand As New SqlCommand("sp_setapprole '" & sApplicationRole & "','steffenmertens'", objConnection)
                objSqlCommand.ExecuteNonQuery()
            End With
        Catch ex As SqlException
            Throw GetExceptionFromSqlException(ex)
            'On ne ferme la connexion que dans le cas d'une erreur sinon on renvoie la connexion ouverte
            objConnection.Close()
        End Try

        'Renvoie d'une connexion ouverte, valide avec l'application r�le charg�
        Return objConnection
    End Function

    'Renvoie la table login avec les donn�es correspondants � pUserLogin: accesible uniquement � "Invit�"
    Private Shared Function GetUserByLogin(ByVal pSqlConnection As SqlConnection, ByVal pUserLogin As String) As DataSet

        Dim objDataSet As New DataSet
        Dim objCommand As New SqlCommand
        Dim objDataAdapter As New SqlDataAdapter
        Try
            With objCommand
                .Connection = pSqlConnection
                .Parameters.Add("@pUserLogin", SqlDbType.NVarChar).Value = pUserLogin
                .CommandText = "GetUserByLogin"
                .CommandType = CommandType.StoredProcedure
            End With

            With objDataAdapter
                .SelectCommand = objCommand
                .Fill(objDataSet)
                .Dispose()
            End With

        Catch ex As SqlException
            GetExceptionFromSqlException(ex)
        End Try

        Return objDataSet

    End Function

#End Region

#Region "Gestion des erreurs"

    'Renvoie une exception construite � partir d'une SqlException. L'exception renvoy�e provient de la Dll EzErrors
    Public Shared Function GetExceptionFromSqlException(ByVal pSqlException As SqlException) As Exception
        Return pSqlException
    End Function

#End Region


#End Region

    'Les gets sont dans la r�gion correspondant � ce qu'elles renvoies

#Region "Projets, Phases"

    'Projet forfaitaire:
    'Pour cr�er un projet forfaitaire, il faut obligatoirement passer le chef de projet et la premi�re phase du projet.
    'La stored procedure est s�curis�e par une transaction.
    Shared Function InsertProjetForfaitaire(ByVal pSqlConnection As SqlConnection, ByVal pCode As String, ByVal pLibelleProjet As String, ByVal pPrixClient As Decimal, ByVal pNumOrdrePhase As Byte, ByVal pNbJoursPhase As Short, ByVal pLibellePhase As String, ByVal pIdChefProjet As Integer, Optional ByVal pCoutAssignationChef As Decimal = -1) As Integer

        Dim objCommand As SqlCommand = New SqlCommand
        Dim iIdProjet As SqlParameter

        With objCommand
            'Construction de l'objet SqlCommand
            .Connection = pSqlConnection
            .CommandType = CommandType.StoredProcedure
            .CommandText = "InsertProjetForfaitaire"

            'Ajout des param�tres
            With .Parameters
                .Add("@pCode", SqlDbType.NVarChar, 6).Value = pCode
                .Add("@pLibelleProjet", SqlDbType.NVarChar, 50).Value = pLibelleProjet
                .Add("@pPrixClient", SqlDbType.Money).Value = pPrixClient
                .Add("@pNumOrdrePhase", SqlDbType.TinyInt).Value = pNumOrdrePhase
                .Add("@pNbJoursPhase", SqlDbType.SmallInt).Value = pNbJoursPhase
                .Add("@pLibellePhase", SqlDbType.NVarChar, 50).Value = pLibellePhase
                .Add("@pIdChefProjet", SqlDbType.Int).Value = pIdChefProjet
                .Add("@pCoutAssignationChef", SqlDbType.Money).Value = pCoutAssignationChef
                'Objet de r�cup�ration de l'id auto increment�.
                iIdProjet = New SqlParameter("@IdProjetForfaitaire", SqlDbType.Int, 0, "Id_Projet")
                iIdProjet.Direction = ParameterDirection.Output
                .Add(iIdProjet)
            End With
        End With

        'Excecution de la commande
        Try
            objCommand.ExecuteNonQuery()
        Catch objSqlException As SqlException
            Throw GetExceptionFromSqlException(objSqlException)
        End Try

        'Renvoie de l'id auto increment�
        InsertProjetForfaitaire = CInt(iIdProjet.Value)

    End Function

    Shared Sub UpdateProjetForfaitaire(ByVal pSqlConnection As SqlConnection, ByVal pIdProjet As Integer, ByVal pCode As String, ByVal pLibelleProjet As String, ByVal pPrixClient As Decimal, ByVal pDerniereModification As Byte())

    End Sub

    'Projet R�gie
    Shared Function InsertProjetRegie(ByVal pSqlConnection As SqlConnection, ByVal pCode As String, ByVal pLibelleProjet As String) As Integer

        Dim objCommand As SqlCommand = New SqlCommand
        Dim iIdProjet As SqlParameter

        With objCommand
            'Construction de l'objet SqlCommand
            .Connection = pSqlConnection
            .CommandType = CommandType.StoredProcedure
            .CommandText = "InsertProjetRegie"

            'Ajout des param�tres
            With .Parameters
                .Add("@pCode", SqlDbType.NVarChar, 6).Value = pCode
                .Add("@pLibelleProjet", SqlDbType.NVarChar, 50).Value = pLibelleProjet

                'Objet de r�cup�ration de l'id auto increment�.
                iIdProjet = New SqlParameter("@IdProjetRegie", SqlDbType.Int, 0, "Id_Projet")
                iIdProjet.Direction = ParameterDirection.Output
                .Add(iIdProjet)
            End With
        End With

        'Excecution de la commande
        Try
            objCommand.ExecuteNonQuery()
        Catch objSqlException As SqlException
            Throw GetExceptionFromSqlException(objSqlException)
        End Try

        'Renvoie de l'id auto increment�
        InsertProjetRegie = CInt(iIdProjet.Value)

    End Function

    Shared Sub UpdateProjetRegie(ByVal pIdProjet As Integer, ByVal pCode As String, ByVal pLibelleProjet As String, ByVal pDerniereModification As Byte())

    End Sub


    'Projet Formation
    Shared Function InsertProjetFormation(ByVal pSqlConnection As SqlConnection, ByVal pCode As String, ByVal pLibelleProjet As String, ByVal pPrixUnitaire As Decimal, ByVal pNbJours As Short, ByVal pNbParticipants As Short) As Integer


        Dim objCommand As SqlCommand = New SqlCommand
        Dim iIdProjet As SqlParameter

        With objCommand
            'Construction de l'objet SqlCommand
            .Connection = pSqlConnection
            .CommandType = CommandType.StoredProcedure
            .CommandText = "InsertProjetFormation"

            'Ajout des param�tres
            With .Parameters
                .Add("@pCode", SqlDbType.NVarChar, 6).Value = pCode
                .Add("@pLibelleProjet", SqlDbType.NVarChar, 50).Value = pLibelleProjet
                .Add("@pPrixUnitaire", SqlDbType.Money).Value = pPrixUnitaire
                .Add("@pNbJours", SqlDbType.SmallInt).Value = pNbJours
                .Add("@pNbParticipants", SqlDbType.SmallInt).Value = pNbParticipants

                'Objet de r�cup�ration de l'id auto increment�.
                iIdProjet = New SqlParameter("@IdProjetFormation", SqlDbType.Int, 0, "Id_Projet")
                iIdProjet.Direction = ParameterDirection.Output
                .Add(iIdProjet)
            End With
        End With

        'Excecution de la commande
        Try
            objCommand.ExecuteNonQuery()
        Catch objSqlException As SqlException
            Throw GetExceptionFromSqlException(objSqlException)
        End Try

        'Renvoie de l'id auto increment�
        InsertProjetFormation = CInt(iIdProjet.Value)

    End Function

    Shared Sub UpdateProjetFormation(ByVal pIdProjet As Integer, ByVal pCode As String, ByVal pLibelleProjet As String, ByVal pPrixUnitaire As Decimal, ByVal pNbParticipants As Short, ByVal pDerniereModification As Byte())

    End Sub

    'Commun
    'Indique le projet comme non actif et met toutes les prestations suivants la date de suppression � 'free'
    Shared Sub DeleteProjet(ByVal pSqlConnection As SqlConnection, ByVal pIdProjet As Integer)

        Dim objCommand As SqlCommand = New SqlCommand

        With objCommand
            'Construction de l'objet SqlCommand
            .Connection = pSqlConnection
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DeleteProjet"

            'Ajout des param�tres
            .Parameters.Add("@pIdProjet", SqlDbType.NVarChar, 6).Value = pIdProjet
        End With


        'Excecution de la commande
        Try
            objCommand.ExecuteNonQuery()
        Catch objSqlException As SqlException
            Throw GetExceptionFromSqlException(objSqlException)
        End Try

    End Sub

    'Phases:
    Shared Sub InsertPhase(ByVal pSqlConnection As SqlConnection, ByVal pIdProjet As Integer, ByVal pNumOrdrePhase As Byte, ByVal pNbJoursPhase As Short, ByVal pLibellePhase As String)

        Dim objCommand As SqlCommand = New SqlCommand

        With objCommand
            'Construction de l'objet SqlCommand
            .Connection = pSqlConnection
            .CommandType = CommandType.StoredProcedure
            .CommandText = "InsertPhase"

            'Ajout des param�tres
            With .Parameters
                .Add("@pIdProjet", SqlDbType.Int).Value = pIdProjet
                .Add("@pNumOrdrePhase", SqlDbType.TinyInt).Value = pNumOrdrePhase
                .Add("@pNbJoursPhase", SqlDbType.SmallInt).Value = pNbJoursPhase
                .Add("@pLibellePhase", SqlDbType.NVarChar, 50).Value = pLibellePhase
            End With
        End With

        'Excecution de la commande
        Try
            objCommand.ExecuteNonQuery()
        Catch objSqlException As SqlException
            Throw GetExceptionFromSqlException(objSqlException)
        End Try

    End Sub

    Shared Sub UpdatePhase(ByVal pIdProjet As Integer, ByVal pNumOrdrePhase As Byte, ByVal pNbJoursPhase As Short, ByVal pLibellePhase As String, ByVal pDerniereModification As Byte())

    End Sub

    Shared Sub DeletePhase(ByVal pIdProjet As Integer, ByVal pNumOrdrePhase As Byte)

    End Sub

    'Reactive un projet supprim�
    Shared Sub ReactiveProjet(ByVal pIdProjet As Integer)

    End Sub

    'Renvoie 3 tables: projets r�gies, projet formation, projet forfaitaire
    Shared Function GetAllProjets(ByVal pSqlConnection As SqlConnection) As DataSet

        Dim objDataSet As New DataSet
        Dim objCommand As New SqlCommand
        Dim objDataAdapter As New SqlDataAdapter

        Try
            'Chargement des projets forfaitaires
            With objCommand
                .Connection = pSqlConnection
                .CommandText = "GetAllProjetForfaitaire"
                .CommandType = CommandType.StoredProcedure
            End With

            With objDataSet.Tables
                .Add(New System.Data.DataTable("Projets Forfaitaire"))
                .Add(New System.Data.DataTable("Projets R�gie"))
                .Add(New System.Data.DataTable("Projets Formation"))
            End With
           

            With objDataAdapter
                .SelectCommand = objCommand
                .Fill(objDataSet.Tables("Projets Forfaitaire"))
            End With

            'Chargement des projets r�gies
            objCommand.CommandText = "GetAllProjetRegie"
            objDataAdapter.Fill(objDataSet.Tables("Projets R�gie"))

            'Chargement des projets de formation
            objCommand.CommandText = "GetAllProjetFormation"
            objDataAdapter.Fill(objDataSet.Tables("Projets Formation"))

            objDataAdapter.Dispose()

        Catch ex As SqlException
            GetExceptionFromSqlException(ex)
        End Try

        Return objDataSet

    End Function

    'Renvoie les phases d'un projet
    Shared Function GetPhasesByProjet(ByVal pSqlConnection As SqlConnection, ByVal pIdProjet As Integer) As DataSet

        Dim objDataSet As New DataSet
        Dim objCommand As New SqlCommand
        Dim objDataAdapter As New SqlDataAdapter

        Try
            With objCommand
                .Connection = pSqlConnection
                .Parameters.Add("@pIdProjet", SqlDbType.Int).Value = pIdProjet
                .CommandText = "GetPhasesByProjet"
                .CommandType = CommandType.StoredProcedure
            End With

            With objDataAdapter
                .SelectCommand = objCommand
                .Fill(objDataSet)
                .Dispose()
            End With

        Catch ex As SqlException
            GetExceptionFromSqlException(ex)
        End Try

        Return objDataSet

    End Function

#End Region

#Region "Personnes"

    'Personne:
    Shared Function InsertPersonne(ByVal pSqlConnection As SqlConnection, ByVal pCodePersonne As String, ByVal pLibellePersonne As String, ByVal pNom As String, ByVal pPrenom As String) As Integer


        Dim objCommand As SqlCommand = New SqlCommand
        Dim iIdPersonne As SqlParameter

        With objCommand
            'Construction de l'objet SqlCommand
            .Connection = pSqlConnection
            .CommandType = CommandType.StoredProcedure
            .CommandText = "InsertPersonne"

            'Ajout des param�tres
            With .Parameters
                .Add("@pCodePersonne", SqlDbType.NVarChar, 3).Value = pCodePersonne
                .Add("@pLibellePersonne", SqlDbType.NVarChar, 50).Value = pLibellePersonne
                .Add("@pNom", SqlDbType.NVarChar, 50).Value = pNom
                .Add("@pPrenom", SqlDbType.NVarChar, 50).Value = pPrenom

                'Objet de r�cup�ration de l'id auto increment�.
                iIdPersonne = New SqlParameter("@IdPersonne", SqlDbType.Int, 0, "Id_Personne")
                iIdPersonne.Direction = ParameterDirection.Output
                .Add(iIdPersonne)

            End With
        End With

        'Excecution de la commande
        Try
            objCommand.ExecuteNonQuery()
        Catch objSqlException As SqlException
            Throw GetExceptionFromSqlException(objSqlException)
        End Try

        'Renvoie de l'id auto increment�
        InsertPersonne = CInt(iIdPersonne.Value)

    End Function
    Shared Sub UpdatePersonne(ByVal pIdPersonne As Integer, ByVal pCodePersonne As String, ByVal pLibellePersonne As String, ByVal pNom As String, ByVal pPrenom As String, ByVal pDerniereModification As Byte())

    End Sub
    Shared Sub DeletePersonne(ByVal pIdPersonne As Integer)

    End Sub

    'Ressource:
    'Pour ins�rer une ressource, on cr�e une personne puis on appelle PersonneToRessource
    Shared Sub UpdateRessource(ByVal pIdRessource As Integer, ByVal pCodePersonne As String, ByVal pLibellePersonne As String, ByVal pNom As String, ByVal pPrenom As String, ByVal pCoutDefautRessource As Decimal, ByVal pLibelleEquipe As String, ByVal pDerniereModification As Byte())

    End Sub
    Shared Sub DeleteRessource(ByVal pIdRessource As Integer)

    End Sub

    'Transforme une ressource en personne (Met la table ressource en 'inactive')
    Shared Sub RessourceToPersonne(ByVal pIdRessource As Integer)

    End Sub

    'Transforme une personne en ressource (ou la retransforme si elle �tait une ressource avant)
    Shared Sub PersonneToRessource(ByVal pSqlConnection As SqlConnection, ByVal pIdPersonne As Integer, ByVal pCoutDefautRessource As Decimal, ByVal pEquipe As String, ByVal pDateDebutAffectationEquipe As Date)

        Dim objCommand As SqlCommand = New SqlCommand

        With objCommand
            'Construction de l'objet SqlCommand
            .Connection = pSqlConnection
            .CommandType = CommandType.StoredProcedure
            .CommandText = "PersonneToRessource"

            'Ajout des param�tres
            With .Parameters
                .Add("@pIdPersonne", SqlDbType.Int).Value = pIdPersonne
                .Add("@pCoutDefautRessource", SqlDbType.Money).Value = pCoutDefautRessource
                .Add("@pDateDebutAffectationEquipe", SqlDbType.DateTime).Value = pDateDebutAffectationEquipe
                .Add("@pEquipe", SqlDbType.NVarChar, 50).Value = pEquipe
            End With
        End With

        'Excecution de la commande
        Try
            objCommand.ExecuteNonQuery()
        Catch objSqlException As SqlException
            Throw GetExceptionFromSqlException(objSqlException)
        End Try

    End Sub

    'Reactive une personne ou une ressource 'supprim�e' 
    Shared Sub ReactivePersonne(ByVal pIdPersonne As Integer)

    End Sub

   
    'Ne renvoie que les personnes qui ne sont pas des ressources
    Shared Function GetOnlyPersonne(ByVal pSqlConnection As SqlConnection) As DataSet

        Dim objDataSet As New DataSet
        Dim objCommand As New SqlCommand
        Dim objDataAdapter As New SqlDataAdapter

        Try
            With objCommand
                .Connection = pSqlConnection
                .CommandText = "GetOnlyPersonne"
                .CommandType = CommandType.StoredProcedure
            End With

            With objDataAdapter
                .SelectCommand = objCommand
                .Fill(objDataSet)
                .Dispose()
            End With

        Catch ex As SqlException
            GetExceptionFromSqlException(ex)
        End Try

        Return objDataSet
    End Function

    'Ne renvoie que des personnes qui sont des ressources
    Shared Function GetOnlyRessource(ByVal pSqlConnection As SqlConnection) As DataSet

        Dim objDataSet As New DataSet
        Dim objCommand As New SqlCommand
        Dim objDataAdapter As New SqlDataAdapter

        Try
            With objCommand
                .Connection = pSqlConnection
                .CommandText = "GetOnlyRessource"
                .CommandType = CommandType.StoredProcedure
            End With

            With objDataAdapter
                .SelectCommand = objCommand
                .Fill(objDataSet)
                .Dispose()
            End With

        Catch ex As SqlException
            GetExceptionFromSqlException(ex)
        End Try

        Return objDataSet

    End Function

    'TODO: EN cours
    'Renvoie tous les chef d'une �quipe
    Shared Function GetChefsEquipe(ByVal pSqlConnection As SqlConnection, ByVal pLibelleEquipe As String) As DataSet

        Dim objDataSet As New DataSet
        Dim objCommand As New SqlCommand
        Dim objDataAdapter As New SqlDataAdapter

        Try
            With objCommand
                .Connection = pSqlConnection
                .CommandText = "GetChefsEquipe"
                .Parameters.Add("@pLibelleEquipe", SqlDbType.NVarChar, 50).Value = pLibelleEquipe
                .CommandType = CommandType.StoredProcedure
            End With

            With objDataAdapter
                .SelectCommand = objCommand
                .Fill(objDataSet)
                .Dispose()
            End With

        Catch ex As SqlException
            GetExceptionFromSqlException(ex)
        End Try

        Return objDataSet

    End Function

#End Region

#Region "Equipe"

    'Equipe:
    Shared Sub InsertEquipe(ByVal pSqlConnection As SqlConnection, ByVal pLibelleEquipe As String, ByVal pIdPersonneChef As Integer)

        Dim objCommand As SqlCommand = New SqlCommand

        With objCommand
            'Construction de l'objet SqlCommand
            .Connection = pSqlConnection
            .CommandType = CommandType.StoredProcedure
            .CommandText = "InsertEquipe"

            'Ajout des param�tres
            With .Parameters
                .Add("@pLibelleEquipe", SqlDbType.NVarChar, 50).Value = pLibelleEquipe
                .Add("@pIdPersonneChef", SqlDbType.Int).Value = pIdPersonneChef
            End With
        End With

        'Excecution de la commande
        Try
            objCommand.ExecuteNonQuery()
        Catch objSqlException As SqlException
            Throw GetExceptionFromSqlException(objSqlException)
        End Try

    End Sub
    Shared Sub UpdateLibelleEquipe(ByVal pAncienLibelleEquipe As String, ByVal pNouveauLibelleEquipe As String, ByVal pDerniereModification As Byte())

    End Sub
    Shared Sub DeleteEquipe(ByVal pLibelleEquipe As String)

    End Sub


    'Chefs:    
    Shared Sub InsertChef(ByVal pSqlConnection As SqlConnection, ByVal pLibelleEquipe As String, ByVal pIdPersonneChef As Integer)

        Dim objCommand As SqlCommand = New SqlCommand

        With objCommand
            'Construction de l'objet SqlCommand
            .Connection = pSqlConnection
            .CommandType = CommandType.StoredProcedure
            .CommandText = "InsertChef"

            'Ajout des param�tres
            With .Parameters
                .Add("@pLibelleEquipe", SqlDbType.NVarChar, 50).Value = pLibelleEquipe
                .Add("@pIdPersonneChef", SqlDbType.Int).Value = pIdPersonneChef
            End With
        End With

        'Excecution de la commande
        Try
            objCommand.ExecuteNonQuery()
        Catch objSqlException As SqlException
            Throw GetExceptionFromSqlException(objSqlException)
        End Try

    End Sub

    Shared Sub DeleteChef(ByVal pLibelleEquipe As String, ByVal pIdPersonneChef As Integer)

    End Sub

    'R�active une �quipe (sans r�activer les anciennes affectations, on ajoute un nouveau chef)
    Shared Sub ReactiveEquipe(ByVal pLibelleEquipe As String, ByVal pIdPersonneChef As Integer)

    End Sub

    'Renvoie toutes les �quipes
    Shared Function GetAllEquipes(ByVal pSqlConnection As SqlConnection) As DataSet

        Dim objDataSet As New DataSet
        Dim objCommand As New SqlCommand
        Dim objDataAdapter As New SqlDataAdapter
        Try
            With objCommand
                .Connection = pSqlConnection
                .CommandText = "GetAllEquipes"
                .CommandType = CommandType.StoredProcedure
            End With

            With objDataAdapter
                .SelectCommand = objCommand
                .Fill(objDataSet)
                .Dispose()
            End With

        Catch ex As SqlException
            GetExceptionFromSqlException(ex)
        End Try

        Return objDataSet

    End Function

#End Region

#Region "Jours non facturables"

    'Jours non facturables
    Shared Sub InsertJoursNonFacturables(ByVal pSqlConnection As SqlConnection, ByVal pJourNonFacturable As Date)

        Dim objCommand As SqlCommand = New SqlCommand

        With objCommand
            'Construction de l'objet SqlCommand
            .Connection = pSqlConnection
            .CommandType = CommandType.StoredProcedure
            .CommandText = "InsertJoursNonFacturables"

            'Ajout des param�tres
            .Parameters.Add("@pJourNonFacturable", SqlDbType.DateTime).Value = pJourNonFacturable
        End With

        'Excecution de la commande
        Try
            objCommand.ExecuteNonQuery()
        Catch objSqlException As SqlException
            Throw GetExceptionFromSqlException(objSqlException)
        End Try

    End Sub
    Shared Sub DeleteJoursNonFacturables(ByVal pJourNonFacturable As Date)

    End Sub

    'Renvoie tous les jours non facturables
    Shared Function GetJoursNonFacturables(ByVal pSqlConnection As SqlConnection) As DataSet

        Dim objDataSet As New DataSet
        Dim objCommand As New SqlCommand
        Dim objDataAdapter As New SqlDataAdapter
        Try
            With objCommand
                .Connection = pSqlConnection
                .CommandText = "GetJoursNonFacturables"
                .CommandType = CommandType.StoredProcedure
            End With

            With objDataAdapter
                .SelectCommand = objCommand
                .Fill(objDataSet)
                .Dispose()
            End With

        Catch ex As SqlException
            GetExceptionFromSqlException(ex)
        End Try

        Return objDataSet

    End Function

    'Renvoie tous les jours non facturables d'un mois et d'une ann�e
    Shared Function GetJoursNonFacturablesParMois(ByVal pSqlConnection As SqlConnection, ByVal pMoisAnnee As Date) As DataSet

        Dim objDataSet As New DataSet
        Dim objCommand As New SqlCommand
        Dim objDataAdapter As New SqlDataAdapter
        Try
            With objCommand
                .Connection = pSqlConnection
                .CommandText = "GetJoursNonFacturablesParMois"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("@pMoisAnnee", SqlDbType.DateTime).Value = pMoisAnnee
            End With

            With objDataAdapter
                .SelectCommand = objCommand
                .Fill(objDataSet)
                .Dispose()
            End With

        Catch ex As SqlException
            GetExceptionFromSqlException(ex)
        End Try

        Return objDataSet
    End Function

#End Region

#Region "Facture"

    'Factures:
    Shared Sub InsertFacture(ByVal pSqlConnection As SqlConnection, ByVal pIdProjet As Integer, ByVal pNumFacture As Integer, ByVal pMontant As Decimal)

        Dim objCommand As SqlCommand = New SqlCommand

        With objCommand
            'Construction de l'objet SqlCommand
            .Connection = pSqlConnection
            .CommandType = CommandType.StoredProcedure
            .CommandText = "InsertFacture"

            'Ajout des param�tres
            With .Parameters
                .Add("@pIdProjet", SqlDbType.Int).Value = pIdProjet
                .Add("@pNumFacture", SqlDbType.Int).Value = pNumFacture
                .Add("@pMontant", SqlDbType.Money).Value = pMontant
            End With
        End With


        'Excecution de la commande
        Try
            objCommand.ExecuteNonQuery()
        Catch objSqlException As SqlException
            Throw GetExceptionFromSqlException(objSqlException)
        End Try

    End Sub
    Shared Sub DeleteFacture(ByVal pNumFacture As Integer)

    End Sub
    Shared Sub UpdateFacture(ByVal pNumFacture As Integer, ByVal pMontant As Decimal, ByVal pDerniereModification As Byte())

    End Sub

    'Renvoie toutes les factures pour un projet
    Shared Function GetFacturesParProjet(ByVal pSqlConnection As SqlConnection, ByVal pIdProjet As Integer) As DataSet

        Dim objDataSet As New DataSet
        Dim objCommand As New SqlCommand
        Dim objDataAdapter As New SqlDataAdapter
        Try
            With objCommand
                .Connection = pSqlConnection
                .CommandText = "GetFacturesParProjet"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("@pIdProjet", SqlDbType.Int).Value = pIdProjet
            End With

            With objDataAdapter
                .SelectCommand = objCommand
                .Fill(objDataSet)
                .Dispose()
            End With

        Catch ex As SqlException
            GetExceptionFromSqlException(ex)
        End Try

        Return objDataSet

    End Function

#End Region

#Region "Assignation"

    'Assignation
    Shared Sub InsertAssignation(ByVal pSqlConnection As SqlConnection, ByVal pIdRessource As Integer, ByVal pLibelleRole As String, ByVal pIdProjet As Integer, Optional ByVal pCoutAssignation As Decimal = -1)

        Dim objCommand As SqlCommand = New SqlCommand

        With objCommand
            'Construction de l'objet SqlCommand
            .Connection = pSqlConnection
            .CommandType = CommandType.StoredProcedure
            .CommandText = "InsertAssignation"

            'Ajout des param�tres
            With .Parameters
                .Add("@pIdRessource", SqlDbType.Int).Value = pIdRessource
                .Add("@pLibelleRole", SqlDbType.NVarChar, 50).Value = pLibelleRole
                .Add("@pIdProjet", SqlDbType.Int).Value = pIdProjet
                .Add("@pCoutAssignation", SqlDbType.Money).Value = pCoutAssignation
            End With
        End With

        'Excecution de la commande
        Try
            objCommand.ExecuteNonQuery()
        Catch objSqlException As SqlException
            Throw GetExceptionFromSqlException(objSqlException)
        End Try

    End Sub

    'Insertion pour le projet en r�gie (enregistrer le cout client par jour):
    Shared Sub InsertAssignationProjetRegie(ByVal pSqlConnection As SqlConnection, ByVal pIdRessource As Integer, ByVal pLibelleRole As String, ByVal pIdProjet As Integer, ByVal pCoutClient As Decimal, Optional ByVal pCoutAssignation As Decimal = -1)


        Dim objCommand As SqlCommand = New SqlCommand

        With objCommand
            'Construction de l'objet SqlCommand
            .Connection = pSqlConnection
            .CommandType = CommandType.StoredProcedure
            .CommandText = "InsertAssignationProjetRegie"

            'Ajout des param�tres
            With .Parameters
                .Add("@pIdRessource", SqlDbType.Int).Value = pIdRessource
                .Add("@pLibelleRole", SqlDbType.NVarChar, 50).Value = pLibelleRole
                .Add("@pIdProjet", SqlDbType.Int).Value = pIdProjet
                .Add("@pCoutAssignation", SqlDbType.Money).Value = pCoutAssignation
                .Add("@pCoutClient", SqlDbType.Money).Value = pCoutClient
            End With
        End With


        'Excecution de la commande
        Try
            objCommand.ExecuteNonQuery()
        Catch objSqlException As SqlException
            Throw GetExceptionFromSqlException(objSqlException)
        End Try

    End Sub
    Shared Sub UpdateCoutAssignation(ByVal pIdRessource As Integer, ByVal pIdProjet As Integer, ByVal pCoutAssignation As Decimal, ByVal pDerniereModification As Byte())

    End Sub

    'Renvoie toutes les assignations
    Shared Function GetAllAssignations(ByVal pSqlConnection As SqlConnection) As DataSet

        Dim objDataSet As New DataSet
        Dim objCommand As New SqlCommand
        Dim objDataAdapter As New SqlDataAdapter
        Try
            With objCommand
                .Connection = pSqlConnection
                .CommandText = "GetAllAssignations"
                .CommandType = CommandType.StoredProcedure
            End With

            With objDataAdapter
                .SelectCommand = objCommand
                .Fill(objDataSet)
                .Dispose()
            End With

        Catch ex As SqlException
            GetExceptionFromSqlException(ex)
        End Try

        Return objDataSet

    End Function
 
    'Renvoie toutes les assignations d'un projet
    Shared Function GetAssignationsParProjet(ByVal pSqlConnection As SqlConnection, ByVal pIdProjet As Integer) As DataSet

        Dim objDataSet As New DataSet
        Dim objCommand As New SqlCommand
        Dim objDataAdapter As New SqlDataAdapter

        Try
            With objCommand
                .Connection = pSqlConnection
                .CommandText = "GetAssignationsParProjet"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("@pIdProjet", SqlDbType.Int).Value = pIdProjet
            End With

            With objDataAdapter
                .SelectCommand = objCommand
                .Fill(objDataSet)
                .Dispose()
            End With

        Catch ex As SqlException
            GetExceptionFromSqlException(ex)
        End Try

        Return objDataSet

    End Function

    'Renvoie toutes les assignations d'une ressource
    Shared Function GetAssignationsParRessource(ByVal pSqlConnection As SqlConnection, ByVal pIdRessource As Integer) As DataSet

        Dim objDataSet As New DataSet
        Dim objCommand As New SqlCommand
        Dim objDataAdapter As New SqlDataAdapter

        Try
            With objCommand
                .Connection = pSqlConnection
                .CommandText = "GetAssignationsParRessource"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("@pIdRessource", SqlDbType.Int).Value = pIdRessource
            End With

            With objDataAdapter
                .SelectCommand = objCommand
                .Fill(objDataSet)
                .Dispose()
            End With

        Catch ex As SqlException
            GetExceptionFromSqlException(ex)
        End Try

        Return objDataSet

    End Function


#End Region

#Region "Planning"

    'Planning:
    'TODO: Faire dans la proc�dure stock�e le test: On ne peut pas g�n�rer un planning pour un mois pass� (Peut-�tre mettre �a dans une contrainte check sur moisannee)
    Shared Function InsertPlanning(ByVal pSqlConnection As SqlConnection, ByVal pMoisAnnee As Date, ByVal pIdPersonneGeneration As Integer, ByVal pDureeJournee As Byte) As Integer


        Dim objCommand As SqlCommand = New SqlCommand
        Dim iIdPlanning As SqlParameter

        With objCommand
            'Construction de l'objet SqlCommand
            .Connection = pSqlConnection
            .CommandType = CommandType.StoredProcedure
            .CommandText = "InsertPlanning"

            'Ajout des param�tres
            With .Parameters
                .Add("@pMoisAnnee", SqlDbType.DateTime).Value = pMoisAnnee
                .Add("@pIdPersonneGeneration", SqlDbType.Int).Value = pIdPersonneGeneration
                .Add("@pDureeJournee", SqlDbType.SmallInt).Value = pDureeJournee

                'Objet de r�cup�ration de l'id auto increment�.
                iIdPlanning = New SqlParameter("@IdPlanning", SqlDbType.Int, 0, "Id_Planning")
                iIdPlanning.Direction = ParameterDirection.Output
                .Add(iIdPlanning)
            End With
        End With


        'Excecution de la commande
        Try
            objCommand.ExecuteNonQuery()
        Catch objSqlException As SqlException
            Throw GetExceptionFromSqlException(objSqlException)
        End Try

        InsertPlanning = CInt(iIdPlanning.Value)

    End Function

    Shared Sub UpdatePlanning(ByVal pIdPlanning As Integer, ByVal pDureeJournee As Byte, ByVal pDerniereModification As Byte())

    End Sub

    Shared Sub DeletePlanning(ByVal pIdPlanning As Integer)

    End Sub

    'Renvoie un planning
    Shared Function GetPlanning(ByVal pSqlConnection As SqlConnection, ByVal pMoisAnnee As DateTime) As DataSet

        Dim objDataSet As New DataSet
        Dim objCommand As New SqlCommand
        Dim objDataAdapter As New SqlDataAdapter

        Try
            With objCommand
                .Connection = pSqlConnection
                .CommandText = "GetPlanning"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("@pMoisAnnee", SqlDbType.DateTime).Value = pMoisAnnee
            End With

            With objDataAdapter
                .SelectCommand = objCommand
                .Fill(objDataSet)
                .Dispose()
            End With

        Catch ex As SqlException
            GetExceptionFromSqlException(ex)
        End Try

        Return objDataSet

    End Function

#End Region

#Region "Prestation"

    'Prestations:
    'TODO: Il va falloir introduire des tests comme le planning doit correspondre au mois de la prestation

    Shared Sub InsertPrestation(ByVal pSqlConnection As SqlConnection, ByVal pIdPlanning As Integer, ByVal pIdProjet As Integer, ByVal pIdRessource As Integer, _
                                ByVal pDatePrestation As Date, ByVal pDureeReservation As String, Optional ByVal pStatut As String = "Free", Optional ByVal pRemarque As String = "", Optional ByVal pNumOrdrePhase As Byte = 0)

        Dim objCommand As SqlCommand = New SqlCommand

        With objCommand
            'Construction de l'objet SqlCommand
            .Connection = pSqlConnection
            .CommandType = CommandType.StoredProcedure
            .CommandText = "InsertPrestation"

            'Ajout des param�tres
            With .Parameters
                .Add("@pIdPlanning", SqlDbType.Int).Value = pIdPlanning
                .Add("@pIdProjet", SqlDbType.Int).Value = pIdProjet
                .Add("@pIdRessource", SqlDbType.Int).Value = pIdRessource
                .Add("@pDatePrestation", SqlDbType.DateTime).Value = pDatePrestation
                .Add("@pDureeReservation", SqlDbType.NVarChar, 50).Value = pDureeReservation
                .Add("@pStatut", SqlDbType.NVarChar, 50).Value = pStatut
                .Add("@pRemarque", SqlDbType.NVarChar, 250).Value = pRemarque
                'On ajoute le num�ro de phase s'il est fourni.
                If Not pNumOrdrePhase = 0 Then
                    .Add("@pNumOrdrePhase", SqlDbType.TinyInt).Value = pNumOrdrePhase
                End If
            End With
        End With

        'Excecution de la commande
        Try
            objCommand.ExecuteNonQuery()
        Catch objSqlException As SqlException
            Throw GetExceptionFromSqlException(objSqlException)
        End Try

    End Sub

    Shared Sub UpdatePrestation(ByVal pIdPlanning As Integer, ByVal pIdProjet As Integer, ByVal pIdPersonne As Integer, ByVal pDureeReservation As String, ByVal pRemarque As String)

    End Sub
    Shared Sub DeletePrestation(ByVal pIdProjet As Integer, ByVal pIdPersonne As Integer, ByVal pDatePrestation As Date, ByVal pDureeReservation As String)

    End Sub

    'Change le statut
    Shared Sub UpdateStatut(ByVal pIdProjet As Integer, ByVal pIdPersonne As Integer, ByVal pDatePrestation As Date, ByVal pDureeReservation As String, ByVal pNouveauStatut As String)

    End Sub
    'Heures prest�es:

    Shared Sub InsertHeuresPrestees(ByVal pSqlConnection As SqlConnection, ByVal pIdProjet As Integer, ByVal pIdRessource As Integer, ByVal pDatePrestation As Date, ByVal pDureeReservation As String, ByVal pHeuresPrestees As Byte, ByVal pIdPersonneEncodage As Integer)

        Dim objCommand As SqlCommand = New SqlCommand

        With objCommand
            'Construction de l'objet SqlCommand
            .Connection = pSqlConnection
            .CommandType = CommandType.StoredProcedure
            .CommandText = "InsertHeuresPrestees"

            'Ajout des param�tres
            With .Parameters
                .Add("@pIdProjet", SqlDbType.Int).Value = pIdProjet
                .Add("@pIdRessource", SqlDbType.Int).Value = pIdRessource
                .Add("@pDatePrestation", SqlDbType.DateTime).Value = pDatePrestation
                .Add("@pDureeReservation", SqlDbType.NVarChar, 50).Value = pDureeReservation
                .Add("@pHeuresPrestees", SqlDbType.SmallInt).Value = pHeuresPrestees
                .Add("@pIdPersonneEncodage", SqlDbType.Int).Value = pIdPersonneEncodage
            End With
        End With
        'Excecution de la commande
        Try
            objCommand.ExecuteNonQuery()
        Catch objSqlException As SqlException
            Throw GetExceptionFromSqlException(objSqlException)
        End Try

    End Sub
    Shared Sub UpdateHeuresPrestees(ByVal pIdProjet As Integer, ByVal pIdPersonne As Integer, ByVal pDatePrestation As Date, ByVal pDureeReservation As String, ByVal pHeuresPrestees As Byte)

    End Sub
    'Pour forfaitaire
    Shared Sub UpdatePhasePrestation(ByVal pIdPlanning As Integer, ByVal pIdProjet As Integer, ByVal pIdPersonne As Integer, ByVal pDatePrestation As Date, ByVal pDureeReservation As String, ByVal pNumOrdrePhase As Byte)

    End Sub

    'Renvoie toutes les prestations d'un projet
    Shared Function GetPrestationsParProjet(ByVal pSqlConnection As SqlConnection, ByVal pIdProjet As Integer) As DataSet

        Dim objDataSet As New DataSet
        Dim objCommand As New SqlCommand
        Dim objDataAdapter As New SqlDataAdapter

        Try
            With objCommand
                .Connection = pSqlConnection
                .CommandText = "GetPrestationsParProjet"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("@pIdProjet", SqlDbType.Int).Value = pIdProjet
            End With

            With objDataAdapter
                .SelectCommand = objCommand
                .Fill(objDataSet)
                .Dispose()
            End With

        Catch ex As SqlException
            GetExceptionFromSqlException(ex)
        End Try

        Return objDataSet

    End Function
    'Renvoie toutes les prestations d'une ressource
    Shared Function GetPrestationsParRessource(ByVal pSqlConnection As SqlConnection, ByVal pIdRessource As Integer) As DataSet

        Dim objDataSet As New DataSet
        Dim objCommand As New SqlCommand
        Dim objDataAdapter As New SqlDataAdapter

        Try
            With objCommand
                .Connection = pSqlConnection
                .CommandText = "GetPrestationsParRessource"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("@pIdRessource", SqlDbType.Int).Value = pIdRessource
            End With

            With objDataAdapter
                .SelectCommand = objCommand
                .Fill(objDataSet)
                .Dispose()
            End With

        Catch ex As SqlException
            GetExceptionFromSqlException(ex)
        End Try

        Return objDataSet

    End Function
    'Renvoie toutes les prestations d'un planning (Donc pour un mois en particulier)
    Shared Function GetPrestationParPlanning(ByVal pSqlConnection As SqlConnection, ByVal pIdPlanning As Integer) As DataSet

        Dim objDataSet As New DataSet
        Dim objCommand As New SqlCommand
        Dim objDataAdapter As New SqlDataAdapter

        Try
            With objCommand
                .Connection = pSqlConnection
                .CommandText = "GetPrestationParPlanning"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("@pIdPlanning", SqlDbType.Int).Value = pIdPlanning
            End With

            With objDataAdapter
                .SelectCommand = objCommand
                .Fill(objDataSet)
                .Dispose()
            End With

        Catch ex As SqlException
            GetExceptionFromSqlException(ex)
        End Try

        Return objDataSet

    End Function

#End Region

#Region "Historique affectation �quipes"

    'Renvoie l'historique complet des affectations
    Shared Function GetHistoriqueEquipe(ByVal pSqlConnection As SqlConnection) As DataSet

        Dim objDataSet As New DataSet
        Dim objCommand As New SqlCommand
        Dim objDataAdapter As New SqlDataAdapter

        Try
            With objCommand
                .Connection = pSqlConnection
                .CommandText = "GetHistoriqueEquipe"
                .CommandType = CommandType.StoredProcedure
            End With

            With objDataAdapter
                .SelectCommand = objCommand
                .Fill(objDataSet)
                .Dispose()
            End With

        Catch ex As SqlException
            GetExceptionFromSqlException(ex)
        End Try

        Return objDataSet

    End Function

   

#End Region

#Region "Historique Changements statuts"

    'Renvoie l'historique complet des changements de statut
    'TODO: Lors de la gestion de l'interface graphique, modifier la requ�te pour que �a soit plus zoli
    Shared Function GetHistoriqueStatut(ByVal pSqlConnection As SqlConnection) As DataSet

        Dim objDataSet As New DataSet
        Dim objCommand As New SqlCommand
        Dim objDataAdapter As New SqlDataAdapter

        Try
            With objCommand
                .Connection = pSqlConnection
                .CommandText = "GetHistoriqueStatut"
                .CommandType = CommandType.StoredProcedure
            End With

            With objDataAdapter
                .SelectCommand = objCommand
                .Fill(objDataSet)
                .Dispose()
            End With

        Catch ex As SqlException
            GetExceptionFromSqlException(ex)
        End Try

        Return objDataSet

    End Function

#End Region


End Class

