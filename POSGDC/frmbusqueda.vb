Imports System.Data.Odbc
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Data
Imports System.Globalization
Imports System.Threading
Imports System.Drawing
Imports System
Imports POSGDC.conexion
Public Class frmbusqueda
    Dim con As New conexion
    Dim conexion As New Odbc.OdbcConnection()
    'Dim conexion As New Odbc.OdbcConnection("DSN=ORIECOMP")
    Dim comando As New Odbc.OdbcCommand
    Dim LECTOR As OdbcDataReader
    Dim datan As New DataSet
    Dim valcod As String
    Dim Dv As New DataView
    Dim adapter_recibos As OdbcDataAdapter
    Dim idrecibo As Integer
    Dim imprimirrecibo As New imprimir


    Public Property pgconection() As OdbcConnection
        Set(value As OdbcConnection)
            conexion = value
        End Set
        Get
            Return Me.conexion
        End Get
    End Property

    'Public Property ds() As DataSet
    '    Set(value As DataSet)
    '        datan = value
    '    End Set
    '    Get
    '        Return Me.datan
    '    End Get
    'End Property

    Private Sub txtbusqeda_TextChanged(sender As Object, e As EventArgs)
        If txtbusqeda.Text = "" Then
            CargarProductos()
        End If

    End Sub

    Private Sub frmbusqueda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conexion = pgconection
        System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
        idrecibo = -1
        ToolTip1.SetToolTip(txtbusqeda, "Busqueda por RTN o Nombre cliente")
        'If dgvRecibosPreventa.Rows.Count > 0 Then
        '    dgvRecibosPreventa.Rows.Clear()
        'End If

        Dim th As New Thread(AddressOf CargarProductos)
        th.Start()
    End Sub

    Private Sub txtbusqeda_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then

        End If

    End Sub


    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs)


    End Sub

    'Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
    '    Dim valor As String = Convert.ToString(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value)
    '    If tipoventa = 0 Then
    '        My.Forms.frmVenta.InsertaFilacoodigo(valor)
    '    Else
    '        My.Forms.frmVenta.InsertaFilapreventa(valor)
    '    End If
    '    Me.txtbusqeda.Text = ""
    '    Me.txtbusqeda.Focus()

    'End Sub

    Private Sub frmbusqueda_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            MsgBox("112")
        End If
    End Sub

    Public Function CargarProductos()
        Dim cad As String = "SELECT id_recibo,rtn,nombre_cliente,fecha,pago_preventa,recibo_activo,venta_empleado FROM public.tbl_recibo_preventa WHERE estado_recibo = 1 ORDER BY id_recibo DESC;"

        adapter_recibos = New OdbcDataAdapter(cad, conexion)
        datan.Clear()
        adapter_recibos.Fill(datan, "listarecibos")
        Dv.Table = datan.Tables("listarecibos")
        adapter_recibos.FillSchema(datan.Tables("listarecibos"), SchemaType.Source)
        dgvRecibosPreventa.Rows.Clear()
        dgvRecibosPreventa.DataSource = Dv
        'For Each dr As DataRow In datan.Tables("listarecibos").Rows
        '    dgvRecibosPreventa.Rows.Add(dr.Item(0).ToString, dr.Item(1), dr.Item(2), dr.Item(3), dr.Item(4), CBool(dr.Item(5).ToString))
        'Next
    End Function

    Private Sub dgvRecibosPreventa_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvRecibosPreventa.KeyDown
        If e.KeyCode = Keys.Enter Then
            enviarDatos()
        End If
    End Sub

    Private Sub dgvRecibosPreventa_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRecibosPreventa.CellContentDoubleClick
        enviarDatos()
    End Sub

    Private Sub txtbusqeda_KeyDown_1(sender As Object, e As KeyEventArgs) Handles txtbusqeda.KeyDown
        If e.KeyCode = Keys.Enter Then
            'Dim n As Integer
            'Dim sqlrecibo As String = ""
            'Try
            '    n = CInt(txtbusqeda.Text) / 1
            '    sqlrecibo = "SELECT DISTINCT (id_recibo),rtn,nombre_cliente,fecha,pago_preventa,recibo_activo,venta_empleado FROM public.tbl_recibo_preventa WHERE id_recibo=" + n + ";"
            'Catch ex As Exception
            '    Dim busqueda As String = txtbusqeda.Text.ToUpper
            '    sqlrecibo = "SELECT DISTINCT (id_recibo),rtn,nombre_cliente,fecha,pago_preventa,recibo_activo,venta_empleado FROM public.tbl_recibo_preventa WHERE  upper(rtn) LIKE '" + busqueda + "%' or upper(nombre_cliente) LIKE '" + busqueda + "%';"
            'End Try
            ''Dim sqlrecibo As String = "SELECT id_recibo,rtn,nombre_cliente,fecha,pago_preventa FROM public.tbl_recibo_preventa WHERE id_recibo=" + busqueda + " or rtn LIKE '" + busqueda + "%' or nombre_cliente LIKE '" + busqueda + "%';"
            'adapter_recibos = New OdbcDataAdapter(sqlrecibo, conexion)
            'datan.Clear()
            'adapter_recibos.Fill(datan, "filtrorecibos")
            'Dv.Table = datan.Tables("filtrorecibos")
            'adapter_recibos.FillSchema(datan.Tables("filtrorecibos"), SchemaType.Source)
            'dgvRecibosPreventa.Rows.Clear()
            'For Each dr As DataRow In datan.Tables("filtrorecibos").Rows
            '    dgvRecibosPreventa.Rows.Add(dr.Item(0), dr.Item(1), dr.Item(2), dr.Item(3), dr.Item(4), CBool(dr.Item(6)))
            'Next

            Dim busq = ""
            If txtbusqeda.Text <> "" Then
                busq = "id_recibo = '" + txtbusqeda.Text + "' or rtn LIKE '%" + txtbusqeda.Text + "%' or nombre_cliente LIKE '%" + txtbusqeda.Text + "%'"
                Dv.RowFilter = busq
                dgvRecibosPreventa.DataSource = Nothing
                dgvRecibosPreventa.Rows.Clear()
                dgvRecibosPreventa.DataSource = Dv
            Else
                Dv.RowFilter = ""
                dgvRecibosPreventa.DataSource = Nothing
                dgvRecibosPreventa.Rows.Clear()
                dgvRecibosPreventa.DataSource = Dv
            End If
        End If
    End Sub

    Private Sub dgvRecibosPreventa_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub btnAnulaRecibo_Click(sender As Object, e As EventArgs) Handles btnAnulaRecibo.Click
        If dgvRecibosPreventa.Rows.Count > 0 Then
            idrecibo = CInt(dgvRecibosPreventa.Rows(dgvRecibosPreventa.CurrentRow.Index).Cells(0).Value)
            If idrecibo >= 0 Then
                Dim r As DialogResult = MessageBox.Show("¿Desea cancelar el recibo No." + idrecibo.ToString + "?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
                If r = DialogResult.Yes Then
                    Dim sqlactualizarecibo As String = "UPDATE public.tbl_recibo_preventa SET estado_recibo = 2 WHERE id_recibo=" + idrecibo.ToString + ";"
                    comando = New OdbcCommand(sqlactualizarecibo, conexion)
                    comando.ExecuteNonQuery()
                End If

            End If
        End If
    End Sub

    Private Sub chkAnulado_CheckedChanged(sender As Object, e As EventArgs) Handles chkAnulado.CheckedChanged
        If chkAnulado.Checked Then
            Dim cad As String = "SELECT id_recibo,rtn,nombre_cliente,fecha,pago_preventa,recibo_activo,venta_empleado FROM public.tbl_recibo_preventa WHERE estado_recibo = 2 ORDER BY id_recibo DESC;"
            adapter_recibos = New OdbcDataAdapter(cad, conexion)
            datan.Clear()
            adapter_recibos.Fill(datan, "listarecibos")
            Dv.Table = datan.Tables("listarecibos")
            adapter_recibos.FillSchema(datan.Tables("listarecibos"), SchemaType.Source)
            dgvRecibosPreventa.Rows.Clear()
            For Each dr As DataRow In datan.Tables("listarecibos").Rows
                dgvRecibosPreventa.Rows.Add(dr.Item(0), dr.Item(1), dr.Item(2), dr.Item(3), dr.Item(4), CBool(dr.Item(5).ToString))
            Next
        Else
            CargarProductos()
        End If
    End Sub

    Private Sub btnReimprime_Click(sender As Object, e As EventArgs) Handles btnReimprime.Click
        If dgvRecibosPreventa.CurrentRow.Index >= 0 Then
            idrecibo = CInt(dgvRecibosPreventa.Rows(dgvRecibosPreventa.CurrentRow.Index).Cells(0).Value)
            If idrecibo <> -1 Then
                Dim venta As String = ""
                Dim sqlventa As String = "SELECT id_numero_venta FROM public.tbl_recibo_preventa WHERE id_recibo=" + idrecibo.ToString + ";"
                comando = New OdbcCommand(sqlventa, conexion)
                LECTOR = comando.ExecuteReader
                If LECTOR.HasRows Then
                    venta = LECTOR(0).ToString
                    imprimirrecibo.ImprimirRecibo(conexion, venta, id_loteventa.ToString, "si", idrecibo.ToString)
                    idrecibo = -1
                Else
                    MessageBox.Show("No se encontro informacion del recibo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If

            Else
                MessageBox.Show("Debe seleccionar un recibo para imprimirlo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

    Private Sub dgvRecibosPreventa_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRecibosPreventa.CellClick
        If dgvRecibosPreventa.Rows.Count > 0 Then
            idrecibo = CInt(dgvRecibosPreventa.Rows(dgvRecibosPreventa.CurrentRow.Index).Cells(0).Value)
            If idrecibo >= 0 Then
                lblidrecibo.Text = "Numero Recibo: " + idrecibo.ToString
            Else
                lblidrecibo.Text = "Numero Recibo: "
            End If
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        enviarDatos()
    End Sub

    Private Sub btnsalir_Click(sender As Object, e As EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub

    Private Function enviarDatos()
        If dgvRecibosPreventa.Rows.Count > 0 Then
            Dim activo As Boolean = CBool(dgvRecibosPreventa.Rows(dgvRecibosPreventa.CurrentRow.Index).Cells(5).Value)
            If activo Then
                Dim id_recibo As Integer = CInt(dgvRecibosPreventa.Rows(dgvRecibosPreventa.CurrentRow.Index).Cells(0).Value)
                My.Forms.frmVenta.vistaItemsPreventa = "si"
                'If dgvRecibosPreventa.Rows(dgvRecibosPreventa.CurrentRow.Index).Cells(6).Value = 1 Then
                '    tipo_venta_recibo = 1
                'End If
                My.Forms.frmVenta.obtenerArticulorPreVenta(id_recibo)
                Me.Close()
            Else
                MessageBox.Show("El recibo ya fue facurado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Function

    Private Sub txtbusqeda_TextChanged_1(sender As Object, e As EventArgs) Handles txtbusqeda.TextChanged
        Dim busq = ""
        If txtbusqeda.Text <> "" Then
            If IsNumeric(txtbusqeda.Text) Then
                busq = "id_recibo = " + txtbusqeda.Text + ""
            Else
                busq = "rtn LIKE '%" + txtbusqeda.Text + "%' or nombre_cliente LIKE '%" + txtbusqeda.Text + "%'"
            End If

            Dv.RowFilter = busq
            dgvRecibosPreventa.DataSource = Nothing
            dgvRecibosPreventa.Rows.Clear()
            dgvRecibosPreventa.DataSource = Dv
        Else
            Dv.RowFilter = ""
            dgvRecibosPreventa.DataSource = Nothing
            dgvRecibosPreventa.Rows.Clear()
            dgvRecibosPreventa.DataSource = Dv
        End If
    End Sub
End Class