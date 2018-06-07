Imports System.Configuration
Imports System.Data.Odbc


Public Class Form1
    Dim conexion As New Odbc.OdbcConnection()
    Dim con As New conexion
    Dim comando As New Odbc.OdbcCommand
    Dim LECTOR As OdbcDataReader

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conexion = con.pg_conecction
        Dim a As String = ConfigurationSettings.AppSettings("database").ToString
        If a <> "Or3@hnd178pk$in" Then
            lblindicador.Visible = True
            lblindicador.Text = "Base: " + a
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        con.openConection(conexion)
        login()
    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        txtpass.Text = "12345"
        txtusuario.Text = ""
        con.openConection(conexion)
    End Sub


    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            login()
        End If
    End Sub

    Private Sub txtpass_TextChanged(sender As Object, e As EventArgs) Handles txtpass.TextChanged

    End Sub

    Private Sub txtpass_KeyDown(sender As Object, e As KeyEventArgs) Handles txtpass.KeyDown
        If e.KeyCode = Keys.Enter Then
            login()
        End If
    End Sub

    Private Function login()
        con.openConection(conexion)
        comando = New OdbcCommand("select fnvalidaUser('" + My.Forms.Form1.txtusuario.Text + "','" + My.Forms.Form1.txtpass.Text + "')", conexion)
        LECTOR = comando.ExecuteReader 'lector va tomar la consulta
        If LECTOR.Read Then ' lee consultala 
            If (LECTOR(0) = "Acceso") Then
                Dim query = "select * from infoposUsuario where us='" + My.Forms.Form1.txtusuario.Text + "' or corr = '" + My.Forms.Form1.txtusuario.Text + "' and id_tipo=1;"
                sessiones.userlog = txtusuario.Text
                'Dim query = "select * from infoposUsuario where us='jsorto' or corr = 'wilcatstore@delcamposchool.org' and id_tipo=1;"
                comando = New OdbcCommand(query, conexion)
                Dim LECTORt As OdbcDataReader
                LECTORt = comando.ExecuteReader
                If LECTORt.Read Then
                    My.Forms.POSVENTA.lblinfoperfil.Text = LECTORt(6)
                    sessiones.infoperfil = LECTORt(6)
                    My.Forms.POSVENTA.lblNombreusuario.Text = "Bienvenido(a): " + LECTORt(1)
                    My.Forms.POSVENTA.lblAlmacen.Text = "Almacen asignado: " + LECTORt(8)
                    sessiones.usuario = "Ventas generadas por: " + LECTORt(1)
                    sessiones.almacen = "Almacen asignado: " + LECTORt(8)
                    sessiones.usuariotemp = LECTORt(1)
                    sessiones.id_almacen = Val(LECTORt(9))
                    sessiones.id_usuario = Val(LECTORt(0))
                    sessiones.id_pos = Val(LECTORt(10))
                End If
                My.Forms.POSVENTA.pgconection = conexion
                My.Forms.POSVENTA.Show()
                Me.Close()
            Else
                MessageBox.Show("Acceso denegado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtpass.Text = ""

            End If
        End If
    End Function

End Class
