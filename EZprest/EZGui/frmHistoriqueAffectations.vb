Public Class frmHistoriqueAffectation
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnRechercher As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCritere As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbBaseRecherche As System.Windows.Forms.ComboBox
    Friend WithEvents dgResultats As System.Windows.Forms.DataGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmHistoriqueAffectation))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnRechercher = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtCritere = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbBaseRecherche = New System.Windows.Forms.ComboBox
        Me.dgResultats = New System.Windows.Forms.DataGrid
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgResultats, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnRechercher)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtCritere)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cbBaseRecherche)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(560, 88)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Critères de recherche:"
        '
        'btnRechercher
        '
        Me.btnRechercher.Location = New System.Drawing.Point(480, 56)
        Me.btnRechercher.Name = "btnRechercher"
        Me.btnRechercher.TabIndex = 4
        Me.btnRechercher.Text = "&Rechercher"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Critère:"
        '
        'txtCritere
        '
        Me.txtCritere.Location = New System.Drawing.Point(104, 56)
        Me.txtCritere.MaxLength = 50
        Me.txtCritere.Name = "txtCritere"
        Me.txtCritere.Size = New System.Drawing.Size(368, 20)
        Me.txtCritere.TabIndex = 2
        Me.txtCritere.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Recherche sur:"
        '
        'cbBaseRecherche
        '
        Me.cbBaseRecherche.Location = New System.Drawing.Point(104, 24)
        Me.cbBaseRecherche.Name = "cbBaseRecherche"
        Me.cbBaseRecherche.Size = New System.Drawing.Size(368, 21)
        Me.cbBaseRecherche.TabIndex = 0
        '
        'dgResultats
        '
        Me.dgResultats.DataMember = ""
        Me.dgResultats.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgResultats.Location = New System.Drawing.Point(8, 104)
        Me.dgResultats.Name = "dgResultats"
        Me.dgResultats.Size = New System.Drawing.Size(560, 416)
        Me.dgResultats.TabIndex = 4
        Me.dgResultats.TabStop = False
        '
        'frmHistoriqueAffectation
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(576, 526)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgResultats)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmHistoriqueAffectation"
        Me.Text = "Historique des affectations:"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgResultats, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmHistoriqueAffectation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ws As New WSEZPrest.ServiceEZPrest
        Dim objdataset As DataSet = ws.GetHistoriqueAffectation
        objdataset.Tables(0).DefaultView.AllowEdit = False

        dgResultats.DataSource = objdataset.Tables(0)
    End Sub
End Class
