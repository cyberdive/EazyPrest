Public Class clsCoutClient

    Private objAssignation As clsAssignation
    Private objProjetRegie As clsProjetRegie
    Private CoutPrestataire As Decimal

    Public Sub New(ByVal pProjetRegie As clsProjetRegie, ByVal pAssignation As clsAssignation)

        objProjetRegie = pProjetRegie
        objAssignation = pAssignation
        
    End Sub

    Public ReadOnly Property Assignation() As clsAssignation
        Get
            Return objAssignation
        End Get
    End Property

    Public ReadOnly Property ProjetRegie() As clsProjetRegie
        Get
            Return objProjetRegie
        End Get
    End Property

End Class
