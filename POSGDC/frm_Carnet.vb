Imports System.Data.Odbc

Public Class frm_Carnet
    Dim con As New conexion
    Dim conexion As New Odbc.OdbcConnection()
    Dim comando As New Odbc.OdbcCommand
    Dim LECTOR As OdbcDataReader
    Dim valcod As String
    Dim Dv As New DataView
    Public codigo_carnet As String = ""


    Public Property pgconection() As OdbcConnection
        Set(value As OdbcConnection)
            conexion = value
        End Set
        Get
            Return Me.conexion
        End Get
    End Property

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub frm_Carnet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.openConection(conexion)
        btnacepta.Enabled = False
        lblNombre.Text = "Nombre:"
        codigo_carnet = ""
    End Sub

    Private Sub txtCodigocarnet_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigocarnet.KeyDown
        If e.KeyCode = Keys.Enter And txtCodigocarnet.Text <> "" Then
            'Dim sqlcarnet As String = ""
            'comando = New OdbcCommand(sqlcarnet, conexion)
            'LECTOR = comando.ExecuteReader()
            'If LECTOR.HasRows Then
            '    btnacepta.Enabled = True
            '    lblNombre.Text = "Nombre: " + LECTOR(1).ToString
            '    codigo_carnet = LECTOR(0).ToString
            'Else
            '    btnacepta.Enabled = False
            '    lblNombre.Text = "Nombre:"
            '    MessageBox.Show("Numero de carnet incorrecto o no existe.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'End If
            codigo_carnet = txtCodigocarnet.Text
            btnacepta.Enabled = True
        End If
    End Sub

    Private Sub btnacepta_Click(sender As Object, e As EventArgs) Handles btnacepta.Click
        My.Forms.frmMetodoPago.codigoCarnet = codigo_carnet
        My.Forms.frmVenta.Button2.Enabled -= True
        Me.Close()
    End Sub
End Class