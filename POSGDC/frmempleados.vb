Imports System.Data.Odbc
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Data
Imports System.Globalization
Imports System.Threading
Imports System.Drawing
Imports System
Imports POSGDC.conexion
Public Class frmempleados
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

    Private Sub frmempleados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conexion = pgconection
        con.openConection(conexion)
        Me.txtbusqeda.Text = ""
        Me.txtbusqeda.Focus()
        Dim cad As String = ""
        cad = "select cast(emp_code as varchar) as Codigo, 
                (p_nombre || ' ' || s_nombre || ' ' || p_apellido || ' ' || s_apellido) 
                as Nombre  
                from  vista_datos_emp"
        Dim adaptador3 As New OdbcDataAdapter(cad, conexion)
        Dim datan As New DataSet
        adaptador3.Fill(datan, "vista_datos_emp")
        Me.DataGridView1.DataSource = datan.Tables("vista_datos_emp")
        Dv.Table = datan.Tables("vista_datos_emp")
        Me.DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    Private Sub txtbusqeda_TextChanged(sender As Object, e As EventArgs) Handles txtbusqeda.TextChanged
        Try
            valcod = "Codigo like '%" + txtbusqeda.Text.Trim + "%' or Nombre like '%" + txtbusqeda.Text.Trim + "%'"
            Dv.RowFilter = valcod
            DataGridView1.DataSource = Dv
            DataGridView1.Update()
        Catch ex As Exception
            MsgBox(ex.Message, 48)
        End Try

    End Sub

    Private Sub txtbusqeda_KeyDown(sender As Object, e As KeyEventArgs) Handles txtbusqeda.KeyDown

        If e.KeyCode = Keys.Enter Then
            If DataGridView1.RowCount > 0 Then
                Dim row As DataGridViewRow = DataGridView1.CurrentRow
                My.Forms.frmVenta.lblnombrecliente.Text = CStr(row.Cells(1).Value)
                My.Forms.frmVenta.txtcod.Text = CStr(row.Cells(0).Value)
                My.Forms.frmVenta.cmbTipo.SelectedValue = 2
                codigoEmpleado = CStr(row.Cells(0).Value)
                empleadoventa = "si"
                Me.Close()
            End If
        End If
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        My.Forms.frmVenta.lblnombrecliente.Text = CStr(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(1).Value)
        My.Forms.frmVenta.txtcod.Text = CStr(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value)
        codigoEmpleado = CStr(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value)
        empleadoventa = "si"
        Me.Close()
    End Sub

    Private Sub frmempleados_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        'If e.KeyCode = Keys.F3 Then
        '    MsgBox("a")
        'End If
    End Sub

    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyDown
        'If e.KeyValue = 13 Then
        '    My.Forms.frmVenta.lblnombrecliente.Text = CStr(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(1).Value)
        '    My.Forms.frmVenta.txtcod.Text = CStr(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value)
        '    codigoEmpleado = CStr(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value)
        '    empleadoventa = "si"
        '    Me.Close()
        'End If
        If e.KeyCode = Keys.Enter Then
            My.Forms.frmVenta.lblnombrecliente.Text = CStr(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(1).Value)
            My.Forms.frmVenta.txtcod.Text = CStr(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value)
            codigoEmpleado = CStr(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value)
            empleadoventa = "si"
            Me.Close()
        End If
    End Sub

End Class