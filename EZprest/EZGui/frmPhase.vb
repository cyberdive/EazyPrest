Public Class frmPhase
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
    Protected WithEvents gpDonnees As System.Windows.Forms.GroupBox
    Friend WithEvents txtLibelle As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.gpDonnees = New System.Windows.Forms.GroupBox
        Me.txtLibelle = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtCode = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.gpDonnees.SuspendLayout()
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
        Me.gpDonnees.TabIndex = 1
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
        'frmPhase
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(336, 266)
        Me.Controls.Add(Me.gpDonnees)
        Me.Name = "frmPhase"
        Me.Text = "Fiche Phase:"
        Me.gpDonnees.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

End Class
