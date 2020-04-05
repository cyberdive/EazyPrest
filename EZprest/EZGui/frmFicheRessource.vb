Public Class frmFicheRessource
    Inherits EZGui.frmFichePersonne

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
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbEquipe As System.Windows.Forms.ComboBox
    Friend WithEvents dtxtCoutDefaut As EZGui.DecimalTextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cbEquipe = New System.Windows.Forms.ComboBox
        Me.dtxtCoutDefaut = New EZGui.DecimalTextBox
        Me.GroupBox1.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(216, 368)
        Me.btnCancel.Name = "btnCancel"
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(136, 368)
        Me.btnOk.Name = "btnOk"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtxtCoutDefaut)
        Me.GroupBox1.Controls.Add(Me.cbEquipe)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(288, 352)
        Me.GroupBox1.Controls.SetChildIndex(Me.Label5, 0)
        Me.GroupBox1.Controls.SetChildIndex(Me.Label6, 0)
        Me.GroupBox1.Controls.SetChildIndex(Me.cbEquipe, 0)
        Me.GroupBox1.Controls.SetChildIndex(Me.dtxtCoutDefaut, 0)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 240)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 16)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Coût par défaut:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 296)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 16)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Equipe:"
        '
        'cbEquipe
        '
        Me.cbEquipe.Location = New System.Drawing.Point(8, 320)
        Me.cbEquipe.Name = "cbEquipe"
        Me.cbEquipe.Size = New System.Drawing.Size(272, 21)
        Me.cbEquipe.TabIndex = 6
        '
        'dtxtCoutDefaut
        '
        Me.dtxtCoutDefaut.Location = New System.Drawing.Point(8, 264)
        Me.dtxtCoutDefaut.MaxLength = 30
        Me.dtxtCoutDefaut.Name = "dtxtCoutDefaut"
        Me.dtxtCoutDefaut.Size = New System.Drawing.Size(272, 20)
        Me.dtxtCoutDefaut.TabIndex = 5
        Me.dtxtCoutDefaut.Text = ""
        '
        'frmFicheRessource
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(306, 400)
        Me.MaximumSize = New System.Drawing.Size(312, 432)
        Me.MinimumSize = New System.Drawing.Size(312, 432)
        Me.Name = "frmFicheRessource"
        Me.Text = "Fiche Ressource"
        Me.GroupBox1.ResumeLayout(False)

    End Sub

#End Region

   
End Class
