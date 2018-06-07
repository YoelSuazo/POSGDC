Imports System.Data.Odbc
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Data
Imports System.Globalization
Imports System.Threading
Imports System.Drawing
Imports System
Imports POSGDC.conexion
Public Class frmtarjetacard
    Dim con As New conexion
    Dim conexion As New Odbc.OdbcConnection()
    'Dim conexion As New Odbc.OdbcConnection("DSN=ORIECOMP")
    Dim comando As New Odbc.OdbcCommand
    Dim LECTOR As OdbcDataReader
    Dim tipo_pago As String
    Dim id_recibo As Integer

    Public Property pgconection() As OdbcConnection
        Set(value As OdbcConnection)
            conexion = value
        End Set
        Get
            Return Me.conexion
        End Get
    End Property

    Public Property Tipo_pago_tarjeta() As String
        Set(value As String)
            tipo_pago = value
        End Set
        Get
            Return Me.tipo_pago
        End Get
    End Property

    Public Property Idrecibo() As Integer
        Set(value As Integer)
            id_recibo = value
        End Set
        Get
            Return Me.id_recibo
        End Get
    End Property

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub btnacepta_Click(sender As Object, e As EventArgs) Handles btnacepta.Click
        con.openConection(conexion)
        Dim er As Integer = 0
        If (txtfecha.Text = "") Then
            er = 1
        End If
        If (txtNumero.Text = "") Then
            er = 1
        End If
        If (txtpos.Text = "") Then
            er = 1
        End If

        If Tipo_pago_tarjeta.ToString = "factura" Then
            If (er = 0) Then
                'conexion.Open()
                comando = New Odbc.OdbcCommand("INSERT INTO tbl_pos_ventacreditotarjeta(idventa, numerotarjeta, numerotransaccion, fechavencimiento)  VALUES ('" + idventa.ToString + "','" + txtNumero.Text + "','" + txtpos.Text + "','" + txtfecha.Text + "');", conexion)
                comando.ExecuteNonQuery()
                My.Forms.frmMetodoPago.ingresarTarjeta = False
                'conexion.Close()
                Me.Close()
            Else
                MsgBox("Verifique los datos ingresados.", MsgBoxStyle.Critical)
            End If

        End If

        If Tipo_pago_tarjeta = "recibo" Then
            If (er = 0) Then
                'conexion.Open()
                comando = New Odbc.OdbcCommand("INSERT INTO public.tbl_recibo_ventacreditotarjeta(id_recibo, numero_tarjeta, fecha_vencimiento,numero_transaccion)  VALUES ('" + Idrecibo().ToString + "','" + txtNumero.Text + "','" + txtpos.Text + "','" + txtfecha.Text + "');", conexion)
                comando.ExecuteNonQuery()
                My.Forms.frm_recibo_preventa.ingresar_tarjeta = False
                'conexion.Close()
                Me.Close()
            Else
                MsgBox("Verifique los datos ingresados.", MsgBoxStyle.Critical)
            End If
        End If

    End Sub

    Private Sub frmtarjetacard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conexion = pgconection
        con.openConection(conexion)
        Me.txtfecha.Text = ""
        Me.txtNumero.Text = ""
        Me.txtpos.Text = ""
        Me.txtNumero.Focus()
    End Sub

    Private Sub txtNumero_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumero.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class