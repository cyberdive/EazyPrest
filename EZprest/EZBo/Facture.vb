Imports EzErrors

Public Class clsFacture

    Private iNumero As Integer
    Private dMontant As Decimal
    Private bDerniereModification As Byte()

    Public Sub New(ByVal pNumero As Integer, ByVal pMontant As Decimal)
        Numero = pNumero
        Montant = pMontant
    End Sub

    Public Property Numero() As Integer
        Get
            Return iNumero
        End Get
        Set(ByVal Value As Integer)
            If Value < 1 Then
                Throw (New ErrorFacture.InvalidNumero)
            End If
            iNumero = Value
        End Set
    End Property

    Public Property Montant() As Decimal
        Get
            Return dMontant
        End Get
        Set(ByVal Value As Decimal)
            If Value < 0 Then
                Throw (New ErrorFacture.InvalidMontant)
            End If
            dMontant = Value
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

