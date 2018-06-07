Imports System.Data.Odbc
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Data
Imports System.Globalization
Imports System.Threading
Imports System.Drawing
Imports System
Imports POSGDC.conexion
Public Class frmFacturasLista
    Dim con As New conexion
    Dim conexion As New Odbc.OdbcConnection()
    'Dim conexion As New Odbc.OdbcConnection("DSN=ORIECOMP")
    Dim comando As New Odbc.OdbcCommand
    Dim LECTOR As OdbcDataReader
    Dim valcod As String
    Dim Dv As New DataView
    Dim formulario As Integer

    Public Property getform() As Integer
        Set(value As Integer)
            formulario = value
        End Set
        Get
            Return formulario
        End Get
    End Property

    Public Property pgconection() As OdbcConnection
        Set(value As OdbcConnection)
            conexion = value
        End Set
        Get
            Return Me.conexion
        End Get
    End Property

    Private Sub frmFacturasLista_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conexion = pgconection
        System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
        con.openConection(conexion)
        'If regresaFactura = 0 Then
        '    btnregresar.Enabled = True
        '    Button1.Enabled = False
        'Else
        '    btnregresar.Enabled = False
        '    Button1.Enabled = True
        'End If
        txtfiltra.Enabled = False
        Panel2.Enabled = False
        Me.DataGridView1.ScrollBars = ScrollBars.Both
        Me.DataGridView1.EditMode=false
        Dim th As New Thread(AddressOf llenargrid)
        th.Start()
    End Sub

    Private Sub txtfiltra_TextChanged(sender As Object, e As EventArgs) Handles txtfiltra.TextChanged

            Try
                valcod = "Interno like '%" + txtfiltra.Text.Trim + "%' or numfactura like '%" + txtfiltra.Text.Trim + "%'"
                Dv.RowFilter = valcod
                DataGridView1.DataSource = Dv
                DataGridView1.Update()
            Catch ex As Exception
                MsgBox(ex.Message, 48)
            End Try

    End Sub

    Private Sub btnregresar_Click(sender As Object, e As EventArgs) Handles btnregresar.Click
        If formulario = 1 Then
            My.Forms.frmVenta.pgconection = conexion
            My.Forms.frmVenta.Show()
        Else
            My.Forms.POSVENTA.pgconection = conexion
            My.Forms.POSVENTA.Show()
        End If
        Me.Close()
    End Sub



    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        idfactura = Val(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value)
        numeroventa = Val(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(7).Value)
        numeroLOTEventa = Val(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(6).Value)
        My.Forms.frmVistaFactura.pgconection = conexion
        My.Forms.frmVistaFactura.ShowDialog()
        'Me.Dispose()
    End Sub

    Private Sub frmFacturasLista_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'llenargrid()
        dtp_fechafinal.Value = Date.Now()
        dtp_fechainicial.Value = Date.Now()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Forms.POSVENTA.pgconection = conexion
        My.Forms.POSVENTA.Show()
        Me.Close()
    End Sub

    Private Function llenargrid()
        Me.txtfiltra.Text = ""
        Dim hoy As Date = Date.Now()
        Dim hoymenostres As Date = hoy.AddDays(-7)
        Dim sql As String = "select cast(id as text) as Interno,numfactura,ff as Fecha,hora as Hora, CASE WHEN estado=1 THEN 'Activa' WHEN estado=2 THEN 'Pendiente Anulación' ELSE 'Anulada'  END,  valortotal, idloteventa as Numlote, id_venta AS numVenta from vistaFacturasVenta where idalmacen='" + id_almacen.ToString + "' and id_usuario='" + id_usuario.ToString + "' and ff::DATE BETWEEN '" + hoymenostres.ToString("yyyy-MM-dd") + "' and '" + hoy.ToString("yyyy-MM-dd") + "' ORDER BY Interno DESC;"
        Dim adaptador3 As New OdbcDataAdapter(sql, conexion)
        Dim datan As New DataSet
        adaptador3.Fill(datan, "vistaFacturasVenta")
        Me.DataGridView1.DataSource = datan.Tables("vistaFacturasVenta")
        Dv.Table = datan.Tables("vistaFacturasVenta")
        Me.DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        txtfiltra.Enabled = True
        Panel2.Enabled = True
    End Function

    Private Sub btnBuscarFacturas_Click(sender As Object, e As EventArgs) Handles btnBuscarFacturas.Click
        Dim fechafin As String = dtp_fechafinal.Value.ToString("yyyy-MM-dd")
        Dim fechaini As String = dtp_fechainicial.Value.ToString("yyyy-MM-dd")
        Dim hoy As String = Date.Now().ToString("yyyy-MM-dd")
        If (fechaini > fechafin) Then
            MessageBox.Show("Error en el rango de las fechas.", "Fechas incorrectas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            txtfiltra.Enabled = False
            cargarFacturasFechas(fechaini, fechafin)
        End If
    End Sub

    Private Sub cargarFacturasFechas(finicio As String, ffin As String)
        Dim sql As String = "select cast(id as text) as Interno,numfactura,ff as Fecha,hora as Hora, CASE WHEN estado=1 THEN 'Activa' WHEN estado=2 THEN 'Pendiente Anulación' ELSE 'Anulada'  END,  valortotal, idloteventa as Numlote, id_venta AS numVenta from vistaFacturasVenta where idalmacen='" + id_almacen.ToString + "' and id_usuario='" + id_usuario.ToString + "' and ff::DATE BETWEEN '" + finicio + "' and '" + ffin + "' ORDER BY Interno DESC;"
        Dim adaptador3 As New OdbcDataAdapter(sql, conexion)
        Dim datan As New DataSet
        Dv.Table.Clear()
        'Me.DataGridView1.Rows.Clear()
        adaptador3.Fill(datan, "vistaFacturasVenta")
        'Me.DataGridView1.Refresh()
        Dv.Table = datan.Tables("vistaFacturasVenta")
        Me.DataGridView1.DataSource = datan.Tables("vistaFacturasVenta")
        Me.DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        txtfiltra.Enabled = True
    End Sub

End Class