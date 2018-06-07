Imports System.Data.Odbc
Public Class POSVENTA
    Public con As New conexion
    Dim conexion As New Odbc.OdbcConnection

    Public Property pgconection() As OdbcConnection
        Set(value As OdbcConnection)
            conexion = value
        End Set
        Get
            Return Me.conexion
        End Get
    End Property


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnLoteventas.Click
        My.Forms.frmlotesventa.pgconection = conexion
        My.Forms.frmlotesventa.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        My.Forms.POSVENTA.pgconection = conexion
        My.Forms.POSVENTA.Show()
        Me.Hide()
    End Sub

    Private Sub POSVENTA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conexion = pgconection
        My.Forms.POSVENTA.lblinfoperfil.Text = sessiones.infoperfil
        My.Forms.POSVENTA.lblNombreusuario.Text = "Bienvenido(a): " + sessiones.userlog
        My.Forms.POSVENTA.lblAlmacen.Text = sessiones.almacen
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles Button1.Click
        id_usuario = 0
        id_almacen = 0
        id_pos = 0
        id_loteventa = 0
        usuario = ""
        almacen = ""
        idventa = 0
        My.Forms.Form1.Show()
        con.openConection(conexion)
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        regresaFactura = 0
        My.Forms.frmFacturasLista.getform = 2
        My.Forms.frmFacturasLista.pgconection = conexion
        My.Forms.frmFacturasLista.Show()
        Me.Close()
    End Sub

    Private Sub lblAlmacen_Click(sender As Object, e As EventArgs) Handles lblAlmacen.Click

    End Sub

    Private Sub lblinfoperfil_Click(sender As Object, e As EventArgs) Handles lblinfoperfil.Click

    End Sub
End Class