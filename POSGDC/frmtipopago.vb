Imports System.Data.Odbc
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Data
Imports System.Globalization
Imports System.Threading
Imports POSGDC.conexion

Public Class frmtipopago
    Dim con As New conexion
    Dim conexion As New Odbc.OdbcConnection()
    'Dim conexion As New Odbc.OdbcConnection("DSN=ORIECOMP")
    Dim comando As New Odbc.OdbcCommand
    Dim LECTOR As OdbcDataReader

    Public Property pgconection() As OdbcConnection
        Set(value As OdbcConnection)
            conexion = value
        End Set
        Get
            Return Me.conexion
        End Get
    End Property

    Private Sub frmtipopago_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtidcarnet.Text = ""
        txtidcarnet.Focus()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtidcarnet.Text <> "" Then
            Dim sqlcarnet As String = "SELECT id_carnet,saldo_carnet FROM public.tbl_carnet_saldo WHERE id_carnet='" + txtidcarnet.Text + "' Limit 1;"
            comando = New OdbcCommand(sqlcarnet, conexion)
            LECTOR = comando.ExecuteReader()
            If LECTOR.HasRows Then
                My.Forms.frmMetodoPago.codigoCarnet = txtidcarnet.Text.ToString
                My.Forms.frmMetodoPago.saldoCarnet = CDec(LECTOR(1).ToString)
                Me.Close()
            Else
                MessageBox.Show("El codigo de carnet no se encontro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("Debe Ingresar un codigo valido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

    End Sub
End Class