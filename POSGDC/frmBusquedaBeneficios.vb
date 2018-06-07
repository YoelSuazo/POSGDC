Imports System.Data.Odbc
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Data
Imports System.Globalization
Imports System.Threading
Imports System.Drawing
Imports System
Imports POSGDC.conexion
Public Class frmBusquedaBeneficios
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


    Private Sub txtbusqeda_TextChanged(sender As Object, e As EventArgs) Handles txtbusqeda.TextChanged
        Try
            valcod = "descripcion_1 like '%" + txtbusqeda.Text.Trim + "%' or codigo_barras like '%" + txtbusqeda.Text.Trim + "%'"
            Dv.RowFilter = valcod
            DataGridView1.DataSource = Dv
            DataGridView1.Update()
        Catch ex As Exception
            MsgBox(ex.Message, 48)
        End Try

    End Sub

    Private Sub frmBusquedaBeneficios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conexion = pgconection
        con.openConection(conexion)
        Me.txtbusqeda.Text = ""
        Dim cad As String = ""
        cad = "select idmaterial, descripcion_1,codigo_barras, disponible  from vistaMaterialesventa where idcentro='" + id_almacen.ToString + "' and id_categoria in (14) and idmaterial not in(515,508,510,514)"
        Dim adaptador3 As New OdbcDataAdapter(cad, conexion)
        Dim datan As New DataSet
        adaptador3.Fill(datan, "vistaMaterialesventa")
        Me.DataGridView1.DataSource = datan.Tables("vistaMaterialesventa")
        Dv.Table = datan.Tables("vistaMaterialesventa")
        Me.DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.Focus()
        If DataGridView1.RowCount > 0 Then
            DataGridView1.Rows(0).Cells(0).Selected = True
        End If
        'conexion.Close()
    End Sub


    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyDown
        Dim valor As String = Convert.ToString(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value)
        'Dim codmaterial As String = Convert.ToString(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value)

        If (e.KeyCode = Keys.Enter) Then

            My.Forms.frmVenta.InsertaFilacoodigo(valor)
            Me.txtbusqeda.Text = ""
            empleadoventa = "no"
            Me.txtbusqeda.Focus()
            Me.Close()
        End If

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim valor As String = Convert.ToString(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value)
        My.Forms.frmVenta.InsertaFilacoodigo(valor)
        Activacafe = 1
        empleadoventa = "no"
        Me.txtbusqeda.Text = ""
        Me.txtbusqeda.Focus()
        Me.Close()
    End Sub

    Private Sub frmBusquedaBeneficios_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub txtbusqeda_KeyDown(sender As Object, e As KeyEventArgs) Handles txtbusqeda.KeyDown
        If e.KeyCode = Keys.Enter Then
            If DataGridView1.RowCount > 0 Then
                Dim row As DataGridViewRow = DataGridView1.CurrentRow
                My.Forms.frmVenta.InsertaFilacoodigo(CStr(row.Cells(0).Value))
                empleadoventa = "no"
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class