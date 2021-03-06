Public Class DecimalTextBox
    Inherits System.Windows.Forms.TextBox

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        '
        'NumericTextBox
        '
        Me.Name = "NumericTextBox"

    End Sub

#End Region

    Shared bOneDecimalPoint As Boolean = False

    Private Sub NumericTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If Not IsNumeric(e.KeyChar) Then
            If e.KeyChar = "." Then
                If bOneDecimalPoint = True Then
                    e.Handled = True
                Else
                    bOneDecimalPoint = True
                End If
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            ElseIf Char.IsWhiteSpace(e.KeyChar) Then
                e.Handled = True
            End If
        End If

    End Sub

End Class

