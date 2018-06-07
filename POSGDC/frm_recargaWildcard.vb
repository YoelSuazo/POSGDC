Imports System.Data.Odbc
Public Class frm_recargaWildcard
    Dim con As New conexion
    Dim conexion As New Odbc.OdbcConnection()
    Dim comando As New Odbc.OdbcCommand
    Dim LECTOR As OdbcDataReader
    Dim valcod As String
    Dim Dv As New DataView


    Public Property pgconection() As OdbcConnection
        Set(value As OdbcConnection)
            conexion = value
        End Set
        Get
            Return Me.conexion
        End Get
    End Property



    Private Sub frm_recargaWildcard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conexion = pgconection
        con.openConection(conexion)
    End Sub

    Private Sub txtwildcard_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtCodigoCarnet_TextChanged(sender As Object, e As EventArgs) Handles txtCodigoCarnet.TextChanged
        If txtCodigoCarnet.Text <> "" Then
            BuscarSaldo()
        End If
    End Sub

    Private Sub txtCodigoCarnet_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigoCarnet.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtCodigoCarnet.Text <> "" Then
                BuscarSaldo()
            End If
        End If
    End Sub

    Private Sub BuscarSaldo()
        Dim sqlCarnet As String = "SELECT saldo_disponible FROM public.tbl_carnet WHERE codigo_carnet='" + txtCodigoCarnet.Text + "';"
        comando = New OdbcCommand(sqlCarnet, conexion)
        LECTOR = comando.ExecuteReader()
        If LECTOR.HasRows Then
            lblSaldo.Text = "Saldo Disponible: L." + LECTOR(0).ToString("#,##0.00")
        End If
    End Sub

    Private Sub registroMovimientos(tipo_consulta As Integer)
        Dim sqlCarnet As String = ""
        '1 si es compra, 2 si es venta
        If tipo_consulta = 1 Then
            sqlCarnet = "SELECT monto_transaccion,fecha_transaccion,id_numero_factura FROM public.tbl_carnet_registro_compra WHERE codigo_carnet='" + txtCodigoCarnet.Text + "';"
        Else
            sqlCarnet = "SELECT monto_recarga,fecha_recarga,0 FROM public.tbl_carnet_recargas WHERE codigo_carnet='" + txtCodigoCarnet.Text + "';"
        End If
        comando = New OdbcCommand(sqlCarnet, conexion)
        LECTOR = comando.ExecuteReader()
        dgvHistorial.Rows.Clear()
        While LECTOR.HasRows
            dgvHistorial.Rows.Add(LECTOR(0).ToString, LECTOR(1).ToString, LECTOR(2).ToString)
        End While
    End Sub

    Private Sub rdbCompras_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCompras.CheckedChanged
        registroMovimientos(1)
    End Sub

    Private Sub rdbRecargas_CheckedChanged(sender As Object, e As EventArgs) Handles rdbRecargas.CheckedChanged
        registroMovimientos(2)
    End Sub
End Class