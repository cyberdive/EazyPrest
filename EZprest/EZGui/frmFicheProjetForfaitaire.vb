Public Class frmFicheProjetForfaitaire
    Inherits frmFicheProjet

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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents itxtNbJours As EZGui.IntegerTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtxtPrixClient As EZGui.DecimalTextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lvPhases As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents clbChefsProjet As System.Windows.Forms.CheckedListBox
    Protected WithEvents btnModifierPhase As System.Windows.Forms.Button
    Protected WithEvents btnSupprimerPhase As System.Windows.Forms.Button
    Protected WithEvents btnAjouterPhase As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("")
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("")
        Dim ListViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("")
        Me.Label3 = New System.Windows.Forms.Label
        Me.itxtNbJours = New EZGui.IntegerTextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtxtPrixClient = New EZGui.DecimalTextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnModifierPhase = New System.Windows.Forms.Button
        Me.btnSupprimerPhase = New System.Windows.Forms.Button
        Me.btnAjouterPhase = New System.Windows.Forms.Button
        Me.lvPhases = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.Label5 = New System.Windows.Forms.Label
        Me.clbChefsProjet = New System.Windows.Forms.CheckedListBox
        Me.gpDonnees.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAjouterFacture
        '
        Me.btnAjouterFacture.Name = "btnAjouterFacture"
        '
        'gpDonnees
        '
        Me.gpDonnees.Controls.Add(Me.clbChefsProjet)
        Me.gpDonnees.Controls.Add(Me.Label5)
        Me.gpDonnees.Controls.Add(Me.dtxtPrixClient)
        Me.gpDonnees.Controls.Add(Me.Label4)
        Me.gpDonnees.Controls.Add(Me.itxtNbJours)
        Me.gpDonnees.Controls.Add(Me.Label3)
        Me.gpDonnees.Name = "gpDonnees"
        Me.gpDonnees.Size = New System.Drawing.Size(320, 336)
        Me.gpDonnees.Controls.SetChildIndex(Me.Label3, 0)
        Me.gpDonnees.Controls.SetChildIndex(Me.itxtNbJours, 0)
        Me.gpDonnees.Controls.SetChildIndex(Me.Label4, 0)
        Me.gpDonnees.Controls.SetChildIndex(Me.dtxtPrixClient, 0)
        Me.gpDonnees.Controls.SetChildIndex(Me.Label5, 0)
        Me.gpDonnees.Controls.SetChildIndex(Me.clbChefsProjet, 0)
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(560, 352)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.TabIndex = 3
        '
        'btnModifierFacture
        '
        Me.btnModifierFacture.Name = "btnModifierFacture"
        '
        'btnSupprimerFacture
        '
        Me.btnSupprimerFacture.Name = "btnSupprimerFacture"
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(480, 352)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 136)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Nombres de jours:"
        '
        'itxtNbJours
        '
        Me.itxtNbJours.Location = New System.Drawing.Point(8, 160)
        Me.itxtNbJours.MaxLength = 5
        Me.itxtNbJours.Name = "itxtNbJours"
        Me.itxtNbJours.ReadOnly = True
        Me.itxtNbJours.Size = New System.Drawing.Size(104, 20)
        Me.itxtNbJours.TabIndex = 5
        Me.itxtNbJours.Text = ""
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(120, 136)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Prix Client:"
        '
        'dtxtPrixClient
        '
        Me.dtxtPrixClient.Location = New System.Drawing.Point(120, 160)
        Me.dtxtPrixClient.MaxLength = 20
        Me.dtxtPrixClient.Name = "dtxtPrixClient"
        Me.dtxtPrixClient.Size = New System.Drawing.Size(192, 20)
        Me.dtxtPrixClient.TabIndex = 4
        Me.dtxtPrixClient.Text = ""
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnModifierPhase)
        Me.GroupBox2.Controls.Add(Me.btnSupprimerPhase)
        Me.GroupBox2.Controls.Add(Me.btnAjouterPhase)
        Me.GroupBox2.Controls.Add(Me.lvPhases)
        Me.GroupBox2.Location = New System.Drawing.Point(336, 152)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(296, 192)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Phases:"
        '
        'btnModifierPhase
        '
        Me.btnModifierPhase.Location = New System.Drawing.Point(104, 160)
        Me.btnModifierPhase.Name = "btnModifierPhase"
        Me.btnModifierPhase.Size = New System.Drawing.Size(88, 23)
        Me.btnModifierPhase.TabIndex = 8
        Me.btnModifierPhase.Text = "&Modifier "
        '
        'btnSupprimerPhase
        '
        Me.btnSupprimerPhase.Location = New System.Drawing.Point(200, 160)
        Me.btnSupprimerPhase.Name = "btnSupprimerPhase"
        Me.btnSupprimerPhase.Size = New System.Drawing.Size(88, 23)
        Me.btnSupprimerPhase.TabIndex = 9
        Me.btnSupprimerPhase.Text = "&Supprimer "
        '
        'btnAjouterPhase
        '
        Me.btnAjouterPhase.Location = New System.Drawing.Point(8, 160)
        Me.btnAjouterPhase.Name = "btnAjouterPhase"
        Me.btnAjouterPhase.Size = New System.Drawing.Size(88, 23)
        Me.btnAjouterPhase.TabIndex = 7
        Me.btnAjouterPhase.Text = "&Ajouter "
        '
        'lvPhases
        '
        Me.lvPhases.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.lvPhases.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2, ListViewItem3})
        Me.lvPhases.Location = New System.Drawing.Point(8, 16)
        Me.lvPhases.MultiSelect = False
        Me.lvPhases.Name = "lvPhases"
        Me.lvPhases.Size = New System.Drawing.Size(280, 136)
        Me.lvPhases.TabIndex = 0
        Me.lvPhases.TabStop = False
        Me.lvPhases.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Ordre:"
        Me.ColumnHeader1.Width = 42
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Jours:"
        Me.ColumnHeader2.Width = 44
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Libellé:"
        Me.ColumnHeader3.Width = 196
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 192)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 16)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Chef(s) de projet:"
        '
        'clbChefsProjet
        '
        Me.clbChefsProjet.Location = New System.Drawing.Point(8, 216)
        Me.clbChefsProjet.Name = "clbChefsProjet"
        Me.clbChefsProjet.Size = New System.Drawing.Size(304, 109)
        Me.clbChefsProjet.TabIndex = 5
        Me.clbChefsProjet.TabStop = False
        '
        'frmFicheProjetForfaitaire
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(642, 384)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "frmFicheProjetForfaitaire"
        Me.Text = "Fiche Projet Forfaitaire"
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.gpDonnees, 0)
        Me.Controls.SetChildIndex(Me.btnOk, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.gpDonnees.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    
End Class
