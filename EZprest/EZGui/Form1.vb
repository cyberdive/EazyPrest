Imports System.Data.SqlClient


Public Class Form1
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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents SqlConnection1 As System.Data.SqlClient.SqlConnection
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button
        Me.SqlConnection1 = New System.Data.SqlClient.SqlConnection
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(72, 56)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 120)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        '
        'SqlConnection1
        '
        Me.SqlConnection1.ConnectionString = "workstation id=RESERVOIRPROG;packet size=4096;user id=invité;data source=RESERVOI" & _
        "RPROG;persist security info=False;initial catalog=EZPREST;pooling=false"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        'Dim Sqlcommand2 As SqlCommand = New SqlCommand
        'Dim Sqlcommand3 As SqlCommand = New SqlCommand

        'Try

        '    Dim cmdRole As New SqlCommand("sp_setapprole 'EZPREST','test'", SqlConnection1)
        '    SqlConnection1.Open()
        '    cmdRole.ExecuteNonQuery()
        '    'SqlConnection1.Close()
        '    EzDal.clsEzDal.InsertPersonne(SqlConnection1, "ABC", "TRUCEEEEEEEEE", "STEFFEN", "XAVIER")
        '    EzDal.clsEzDal.InsertPersonne(SqlConnection1, "ABD", "TRUCEEEEEEEEE", "STEFFEN", "XAVIER")
        '    'EZPREST','test'"

        '    SqlConnection1.Close()
        'Catch ex As SqlException
        '    MessageBox.Show(ex.Message)
        'End Try

        'EzDal.clsEzDal.CreateDbLogin(New SqlConnection, 3, "thomas", EzDal.clsEzDal.GetCryptedPassword("thomas"), "Sa")
        Try
            'EzDal.clsEzDal.ChangePassword("xavier", , EzDal.clsEzDal.GetCryptedPassword("xavier"))
            'EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER"))
            'EzDal.clsEzDal.InsertHeuresPrestees(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")), 85, 3, New Date(1981, 6, 25), "Matin", 8, 3)
            'EzDal.clsEzDal.InsertChef(), "ESSAI", 3)
            ' EzDal.clsEzDal.GetOnlyPersonne(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")))
            '   EzDal.clsEzDal.GetOnlyRessource(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")))
            '   EzDal.clsEzDal.GetChefsEquipe(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")), "Equipe")
            'EzDal.clsEzDal.GetAllEquipes(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")))
            EzDal.clsEzDal.GetPlanning(EzDal.clsEzDal.GetConnection("xavier", EzDal.clsEzDal.GetCryptedPassword("XAVIER")), New Date(1981, 6, 24))

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        

       
    End Sub
End Class
