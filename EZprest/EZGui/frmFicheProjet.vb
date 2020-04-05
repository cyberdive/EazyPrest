Public Class frmFicheProjet
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents txtLibelle As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Protected WithEvents btnOk As System.Windows.Forms.Button
    Protected WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Protected WithEvents gpDonnees As System.Windows.Forms.GroupBox
    Friend WithEvents gbFactures As System.Windows.Forms.GroupBox
    Protected WithEvents btnModifierFacture As System.Windows.Forms.Button
    Protected WithEvents btnSupprimerFacture As System.Windows.Forms.Button
    Protected WithEvents btnAjouterFacture As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmFicheProjet))
        Me.gpDonnees = New System.Windows.Forms.GroupBox
        Me.txtLibelle = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtCode = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnOk = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.gbFactures = New System.Windows.Forms.GroupBox
        Me.btnModifierFacture = New System.Windows.Forms.Button
        Me.btnSupprimerFacture = New System.Windows.Forms.Button
        Me.btnAjouterFacture = New System.Windows.Forms.Button
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.gpDonnees.SuspendLayout()
        Me.gbFactures.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpDonnees
        '
        Me.gpDonnees.Controls.Add(Me.txtLibelle)
        Me.gpDonnees.Controls.Add(Me.Label2)
        Me.gpDonnees.Controls.Add(Me.txtCode)
        Me.gpDonnees.Controls.Add(Me.Label1)
        Me.gpDonnees.Location = New System.Drawing.Point(8, 8)
        Me.gpDonnees.Name = "gpDonnees"
        Me.gpDonnees.Size = New System.Drawing.Size(320, 136)
        Me.gpDonnees.TabIndex = 0
        Me.gpDonnees.TabStop = False
        Me.gpDonnees.Text = "Données:"
        '
        'txtLibelle
        '
        Me.txtLibelle.Location = New System.Drawing.Point(8, 104)
        Me.txtLibelle.MaxLength = 50
        Me.txtLibelle.Name = "txtLibelle"
        Me.txtLibelle.Size = New System.Drawing.Size(304, 20)
        Me.txtLibelle.TabIndex = 3
        Me.txtLibelle.Text = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Libellé:"
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(8, 48)
        Me.txtCode.MaxLength = 3
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(40, 20)
        Me.txtCode.TabIndex = 1
        Me.txtCode.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Code:"
        '
        'btnOk
        '
        Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOk.Location = New System.Drawing.Point(480, 152)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.TabIndex = 1
        Me.btnOk.Text = "&Ok"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(560, 152)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "&Cancel"
        '
        'gbFactures
        '
        Me.gbFactures.Controls.Add(Me.btnModifierFacture)
        Me.gbFactures.Controls.Add(Me.btnSupprimerFacture)
        Me.gbFactures.Controls.Add(Me.btnAjouterFacture)
        Me.gbFactures.Controls.Add(Me.ListBox1)
        Me.gbFactures.Location = New System.Drawing.Point(336, 8)
        Me.gbFactures.Name = "gbFactures"
        Me.gbFactures.Size = New System.Drawing.Size(296, 136)
        Me.gbFactures.TabIndex = 3
        Me.gbFactures.TabStop = False
        Me.gbFactures.Text = "Factures:"
        '
        'btnModifierFacture
        '
        Me.btnModifierFacture.Location = New System.Drawing.Point(104, 104)
        Me.btnModifierFacture.Name = "btnModifierFacture"
        Me.btnModifierFacture.Size = New System.Drawing.Size(88, 23)
        Me.btnModifierFacture.TabIndex = 5
        Me.btnModifierFacture.Text = "&Modifier "
        '
        'btnSupprimerFacture
        '
        Me.btnSupprimerFacture.Location = New System.Drawing.Point(200, 104)
        Me.btnSupprimerFacture.Name = "btnSupprimerFacture"
        Me.btnSupprimerFacture.Size = New System.Drawing.Size(88, 23)
        Me.btnSupprimerFacture.TabIndex = 6
        Me.btnSupprimerFacture.Text = "&Supprimer "
        '
        'btnAjouterFacture
        '
        Me.btnAjouterFacture.Location = New System.Drawing.Point(8, 104)
        Me.btnAjouterFacture.Name = "btnAjouterFacture"
        Me.btnAjouterFacture.Size = New System.Drawing.Size(88, 23)
        Me.btnAjouterFacture.TabIndex = 4
        Me.btnAjouterFacture.Text = "&Ajouter "
        '
        'ListBox1
        '
        Me.ListBox1.Location = New System.Drawing.Point(8, 16)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(280, 82)
        Me.ListBox1.TabIndex = 0
        '
        'frmFicheProjet
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(642, 184)
        Me.Controls.Add(Me.gbFactures)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.gpDonnees)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmFicheProjet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fiche Projet"
        Me.gpDonnees.ResumeLayout(False)
        Me.gbFactures.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub frmFicheProjet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
