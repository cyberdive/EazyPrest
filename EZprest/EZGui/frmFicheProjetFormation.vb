Public Class frmFicheProjetFormation
    Inherits EZGui.frmFicheProjet

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents dtxtPrixUnitaire As EZGui.DecimalTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents itxtNbJours As EZGui.IntegerTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents itxtNbParticipants As EZGui.IntegerTextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.dtxtPrixUnitaire = New EZGui.DecimalTextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.itxtNbJours = New EZGui.IntegerTextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.itxtNbParticipants = New EZGui.IntegerTextBox
        Me.gpDonnees.SuspendLayout()
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(176, 256)
        Me.btnOk.Name = "btnOk"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(256, 256)
        Me.btnCancel.Name = "btnCancel"
        '
        'gpDonnees
        '
        Me.gpDonnees.Controls.Add(Me.itxtNbParticipants)
        Me.gpDonnees.Controls.Add(Me.Label5)
        Me.gpDonnees.Controls.Add(Me.dtxtPrixUnitaire)
        Me.gpDonnees.Controls.Add(Me.Label4)
        Me.gpDonnees.Controls.Add(Me.itxtNbJours)
        Me.gpDonnees.Controls.Add(Me.Label3)
        Me.gpDonnees.Name = "gpDonnees"
        Me.gpDonnees.Size = New System.Drawing.Size(320, 240)
        Me.gpDonnees.Controls.SetChildIndex(Me.Label3, 0)
        Me.gpDonnees.Controls.SetChildIndex(Me.itxtNbJours, 0)
        Me.gpDonnees.Controls.SetChildIndex(Me.Label4, 0)
        Me.gpDonnees.Controls.SetChildIndex(Me.dtxtPrixUnitaire, 0)
        Me.gpDonnees.Controls.SetChildIndex(Me.Label5, 0)
        Me.gpDonnees.Controls.SetChildIndex(Me.itxtNbParticipants, 0)
        '
        'dtxtPrixUnitaire
        '
        Me.dtxtPrixUnitaire.Location = New System.Drawing.Point(120, 160)
        Me.dtxtPrixUnitaire.MaxLength = 20
        Me.dtxtPrixUnitaire.Name = "dtxtPrixUnitaire"
        Me.dtxtPrixUnitaire.Size = New System.Drawing.Size(192, 20)
        Me.dtxtPrixUnitaire.TabIndex = 11
        Me.dtxtPrixUnitaire.Text = ""
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(120, 136)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 16)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Prix Unitaire:"
        '
        'itxtNbJours
        '
        Me.itxtNbJours.Location = New System.Drawing.Point(8, 160)
        Me.itxtNbJours.MaxLength = 5
        Me.itxtNbJours.Name = "itxtNbJours"
        Me.itxtNbJours.Size = New System.Drawing.Size(104, 20)
        Me.itxtNbJours.TabIndex = 9
        Me.itxtNbJours.Text = ""
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 136)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 16)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Nombres de jours:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 192)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(124, 16)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Nombre de participants:"
        '
        'itxtNbParticipants
        '
        Me.itxtNbParticipants.Location = New System.Drawing.Point(8, 208)
        Me.itxtNbParticipants.MaxLength = 5
        Me.itxtNbParticipants.Name = "itxtNbParticipants"
        Me.itxtNbParticipants.Size = New System.Drawing.Size(104, 20)
        Me.itxtNbParticipants.TabIndex = 13
        Me.itxtNbParticipants.Text = ""
        '
        'frmFicheProjetFormation
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(338, 288)
        Me.Name = "frmFicheProjetFormation"
        Me.gpDonnees.ResumeLayout(False)

    End Sub

#End Region

End Class
