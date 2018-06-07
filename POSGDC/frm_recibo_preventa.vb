Imports System.Data.Odbc
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Data
Imports System.Globalization
Imports System.Threading
Imports System.Drawing
Imports System
Imports POSGDC.conexion

Public Class frm_recibo_preventa
    Dim con As New conexion
    Dim conexion As New Odbc.OdbcConnection()
    'Dim conexion As New Odbc.OdbcConnection("DSN=ORIECOMP")
    Dim comando As New Odbc.OdbcCommand
    Dim LECTOR As OdbcDataReader
    Dim imprimirrecibo As New imprimir

    Dim descuento As Integer = 0
    Dim descuento_empleado As Boolean = False
    Public numeroventa As Integer = 0
    Public dgvProductos As DataGridView
    Dim saldo_acumulado As Decimal = 0
    Dim limite_credito As Decimal = 0

    Dim subtotalsinisv As Decimal = 0
    Dim subtotalisv15 As Decimal = 0
    Dim subtotalisv18 As Decimal = 0
    Dim isv15 As Decimal = 0
    Dim isv18 As Decimal = 0
    Dim totaldescuento As Decimal = 0
    Dim id_recibo As Integer = 0


    Dim subtotal As Decimal = 0
    Dim descuentototal As Decimal = 0
    Dim isv As Decimal = 0
    Dim total As Decimal = 0
    Dim cambio As Decimal = 0
    Dim porcentaje_preventa As Decimal = 0
    Dim total_pagar_check As Decimal = 0
    Public ingresar_tarjeta As Boolean = True




    Public Enum metodospago
        efectivo = 1
        tarjeta = 2
        puntos = 3
        creditoempleado = 4
        wildcard = 5
        carnet = 9
        efectivodollar = 7
        cafegratis = 8
        descuentoempleado = 10
        cambio = 11
    End Enum

    Public Property pgconection() As OdbcConnection
        Set(value As OdbcConnection)
            conexion = value
        End Set
        Get
            Return Me.conexion
        End Get
    End Property

    Private Sub frm_recibo_preventa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conexion = pgconection
        chkllevacambio.Checked = False
        rbPagominimo.Checked = False
        rbPagototal.Checked = False
        btnaceptar.Enabled = False
        saldo_acumulado = 0
        porcentaje_preventa = 0
        txtNombreCliente.Text = ""
        txtIdentidad.Text = ""
        txtefectivo.Text = ""
        txttarjetacredito.Text = ""
        txtpuntos.Text = ""
        txtdeduccion.Text = ""
        lblLimiteCredito.Text = ""
        ingresar_tarjeta = True
        If empleadoventa = "si" Then
            txtIdentidad.Text = My.Forms.frmVenta.txtcod.Text
            txtNombreCliente.Text = My.Forms.frmVenta.lblnombrecliente.Text
            buscar_descuento_empleado()
            txtdeduccion.Enabled = True
        Else
            txtIdentidad.Text = ""
            txtNombreCliente.Text = ""
            txtdeduccion.Enabled = False
        End If
        lblNumeroVenta.Text = "Numero Venta: " + numeroventa.ToString


        lblSaldo.Text = "Credito Disponible: L." + (limite_credito - saldo_acumulado).ToString("#,##0.00")

        Dim sqlpreventam As String = "SELECT valor FROM public.tbl_parametros WHERE nombre LIKE 'Pago_preventa%';"
        comando = New OdbcCommand(sqlpreventam, conexion)
        LECTOR = comando.ExecuteReader
        If LECTOR.HasRows Then
            porcentaje_preventa = CDec(CInt(LECTOR(0).ToString) / 100)
        End If

        calcularTotales()
        txtIdentidad.Focus()
    End Sub

    Private Function buscar_descuento_empleado()
        Dim sql As String = "SELECT descuento_empleado,saldo_acumulado,limite_credito FROM public.tbl_empleado_credito WHERE codigo_empleado='" + txtIdentidad.Text + "'"
        comando = New OdbcCommand(sql, conexion)
        LECTOR = comando.ExecuteReader
        If LECTOR.HasRows Then
            'descuento = CInt(LECTOR(0).ToString)
            saldo_acumulado = CDec(LECTOR(1).ToString)
            limite_credito = CDec(LECTOR(2).ToString)
        End If
    End Function

    Private Function calcularTotales()
        subtotalisv15 = 0
        subtotalisv18 = 0
        subtotalsinisv = 0
        isv15 = 0
        isv18 = 0
        totaldescuento = 0
        subtotal = 0
        descuentototal = 0
        isv = 0
        total = 0

        Dim temp As Decimal = 0

        For i As Integer = 0 To dgvProductos.Rows.Count - 1
            If dgvProductos.Rows(i).Cells(6).Value = 18 Then

                Dim st18 As Decimal = (dgvProductos.Rows(i).Cells(0).Value) * (dgvProductos.Rows(i).Cells(2).Value)

                st18 = st18 - (st18 * (descuento / 100))

                subtotalisv18 = subtotalisv18 + (st18)

                isv18 = isv18 + CDec(dgvProductos.Rows(i).Cells(3).Value) * CInt(dgvProductos.Rows(i).Cells(0).Value)
                'isv18 = isv18 + ((st18) * (dgvProductos.Rows(i).Cells(6).Value / 100))

            ElseIf dgvProductos.Rows(i).Cells(6).Value = 15 Then

                Dim st15 As Decimal = (dgvProductos.Rows(i).Cells(0).Value) * (dgvProductos.Rows(i).Cells(2).Value)

                st15 = st15 - (st15 * (descuento / 100))

                subtotalisv15 = subtotalisv15 + (st15)

                isv15 = isv15 + CDec(dgvProductos.Rows(i).Cells(3).Value) * CInt(dgvProductos.Rows(i).Cells(0).Value)
                'isv15 = isv15 + ((st15) * (dgvProductos.Rows(i).Cells(6).Value / 100))
            Else

                Dim st As Decimal = (dgvProductos.Rows(i).Cells(0).Value) * (dgvProductos.Rows(i).Cells(2).Value)

                st = st - (st * (descuento / 100))

                subtotalsinisv = subtotalsinisv + (st)
            End If

            temp += CDec(dgvProductos.Rows(i).Cells(0).Value.ToString) * CDec(dgvProductos.Rows(i).Cells(2).Value.ToString)
        Next

        subtotal = temp
        'descuentototal = subtotal * descuento / 100
        isv = Math.Truncate((isv18 + isv15)*100)/100
        total = (subtotal - descuentototal + isv)

        lbltotalp.Text = "L. " + (total).ToString("#,##0.00")
        lbltotalp.ForeColor = Color.Green

        lblmontominimop.Text = "L. " + (total * porcentaje_preventa).ToString("#,##0.00")
        lblmontominimop.ForeColor = Color.Blue

        lblisvp.Text = "L. " + isv.ToString("#,##0.00")
        lblsubtotalp.Text = "L. " + subtotal.ToString("#,##0.00")
        'lbldescuentop.Text = "L. " + descuentototal.ToString("N2")





        'If descuentototal = 0 Then
        '    lbltotalp.Text = "L. " + CInt(total).ToString("N2")
        '    lblmontominimop.Text = "L. " + (total * 0.4).ToString("N2")
        '    lblisvp.Text = "L. " + isv.ToString("N2")
        '    lblsubtotalp.Text = "L. " + subtotal.ToString("N2")
        '    lbldescuentop.Text = "L. " + descuentototal.ToString("N2")
        'Else
        '    lbltotalp.Text = "L. " + CDec(total).ToString("N2")
        '    lblmontominimop.Text = "L. " + (total * 0.4).ToString("N2")
        '    lblisvp.Text = "L. " + isv.ToString("N2")
        '    lblsubtotalp.Text = "L. " + subtotal.ToString("N2")
        '    lbldescuentop.Text = "L. " + descuentototal.ToString("N2")
        'End If

    End Function

    Private Sub btncancelar_Click(sender As Object, e As EventArgs) Handles btnNuevoCliente.Click
        Me.Close()
    End Sub

    Private Sub btnaceptar_Click(sender As Object, e As EventArgs) Handles btnaceptar.Click

        Dim pago_preventa As Decimal = CDec((valor(txtefectivo.Text)) + (valor(txttarjetacredito.Text)) + (valor(txtpuntos.Text)) + (valor(txtdeduccion.Text)))
        If txtIdentidad.Text <> "" And txtNombreCliente.Text <> "" Then
            If rbPagominimo.Checked Then
                If pago_preventa >= total_pagar_check And pago_preventa < total Then
                    pagoPreventa(pago_preventa)
                Else
                    MessageBox.Show("El valor no puede ser menor al pago minimo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End If

            If rbPagototal.Checked Then
                If pago_preventa > total_pagar_check And chkllevacambio.Checked = True Then
                    pagoPreventa(pago_preventa)
                ElseIf pago_preventa = total_pagar_check Then
                    pagoPreventa(pago_preventa)
                ElseIf pago_preventa < total_pagar_check Then
                    MessageBox.Show("Esta ingresando una cantidad menor que el total.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    MessageBox.Show("Esta ingresando una cantidad mayor, marque 'Lleva Cambio'", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If

                If pago_preventa < total_pagar_check Then
                    MessageBox.Show("El valor no puede ser menor al pago minimo o mayor al pago total", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End If

        Else
            MessageBox.Show("El RTN/Identidad y Nombre cliente, son obligatorios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtdeduccion.TextChanged, txtpuntos.TextChanged, txttarjetacredito.TextChanged, txtefectivo.TextChanged
        If sender.Text <> "" Then
            Try
                Dim a As Integer = CInt(sender.Text) / 1
                suma()
            Catch ex As Exception
                MessageBox.Show("Solo se permiten numeros.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End If
    End Sub

    Private Function guardarMetodosPago()
        Dim efectivo As Decimal = CDec(valor(txtefectivo.Text)).ToString
        Dim tarjetacredito As Decimal = CDec(valor(txttarjetacredito.Text)).ToString
        Dim puntos As Decimal = CDec(valor(txtpuntos.Text)).ToString
        Dim descuentoplanilla As Decimal = CDec(valor(txtdeduccion.Text)).ToString
        Dim sql As String = ""
        Dim metodo As Integer
        If txtefectivo.Text <> "" Then
            metodo = metodospago.efectivo
            sql = "INSERT INTO public.tbl_recibo_preventa_metodospago (id_recibo,id_metodo_pago,monto,dolares) VALUES (" + id_recibo.ToString + ",'" + metodo.ToString + "','" + efectivo.ToString + "','0.0');"
            comando = New OdbcCommand(sql, conexion)
            comando.ExecuteNonQuery()
        End If

        If txttarjetacredito.Text <> "" Then
            metodo = metodospago.tarjeta
            sql = "INSERT INTO public.tbl_recibo_preventa_metodospago (id_recibo,id_metodo_pago,monto,dolares) VALUES (" + id_recibo.ToString + ",'" + metodo.ToString + "','" + tarjetacredito.ToString + "',0.0);"
            comando = New OdbcCommand(sql, conexion)
            comando.ExecuteNonQuery()
        End If

        If txtpuntos.Text <> "" Then
            metodo = metodospago.puntos
            sql = "INSERT INTO public.tbl_recibo_preventa_metodospago (id_recibo,id_metodo_pago,monto,dolares) VALUES (" + id_recibo.ToString + ",'" + metodo.ToString + "','" + puntos.ToString + "',0.0);"
            comando = New OdbcCommand(sql, conexion)
            comando.ExecuteNonQuery()
        End If

        If txtdeduccion.Text <> "" Then
            metodo = metodospago.creditoempleado
            sql = "INSERT INTO public.tbl_recibo_preventa_metodospago (id_recibo,id_metodo_pago,monto,dolares) VALUES (" + id_recibo.ToString + ",'" + metodo.ToString + "','" + descuentoplanilla.ToString + "',0.0);"
            comando = New OdbcCommand(sql, conexion)
            comando.ExecuteNonQuery()

            comando = New OdbcCommand("INSERT INTO public.tbl_empleado_credito_centro(id_venta,id_metodo_pago,id_centro,monto,codigo_empleado,fecha) VALUES (" + idventa.ToString + ",10," + id_almacen.ToString + "," + CDec(txtdeduccion.Text).ToString + "," + My.Forms.frmVenta.txtcod.Text + ",now());", conexion)
            comando.ExecuteNonQuery()
        End If

        If cambio <> 0 Then
            metodo = metodospago.cambio
            sql = "INSERT INTO public.tbl_recibo_preventa_metodospago (id_recibo,id_metodo_pago,monto,dolares) VALUES (" + id_recibo.ToString + ",'" + metodo.ToString + "','" + cambio.ToString + "',0.0);"
            comando = New OdbcCommand(sql, conexion)
            comando.ExecuteNonQuery()
        End If
    End Function

    Private Sub txttarjetacredito_Leave(sender As Object, e As EventArgs) Handles txttarjetacredito.Leave
        If txttarjetacredito.Text <> "" Then
            If ingresar_tarjeta Then
                MessageBox.Show("Debe ingresar los datos de la tarjeta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txttarjetacredito.Focus()
            End If
        End If
    End Sub

    Private Sub txttarjetacredito_KeyDown(sender As Object, e As KeyEventArgs) Handles txttarjetacredito.KeyDown
        If e.KeyCode = Keys.Enter Then
            My.Forms.frmtarjetacard.pgconection = conexion
            My.Forms.frmtarjetacard.Tipo_pago_tarjeta = "recibo"
            My.Forms.frmtarjetacard.Idrecibo = id_recibo
            My.Forms.frmtarjetacard.ShowDialog()
        End If
    End Sub

    Private Function valor(n As String)
        Dim b As Decimal = If(n <> "", CDec(n), 0)
        Return b
    End Function

    Private Sub txtdeduccion_Leave(sender As Object, e As EventArgs) Handles txtdeduccion.Leave
        If txtdeduccion.Text <> "" Then
            Dim totaldecuccion As Decimal = CDec(txtdeduccion.Text)
            If ((saldo_acumulado + totaldecuccion) > limite_credito) Then
                btnaceptar.Enabled = False
                lblLimiteCredito.Visible = True
                lblLimiteCredito.Text = "El usuario excede su limite de credito. Disponible: L." + CDec(limite_credito-saldo_acumulado).ToString("#,##0.00")
            Else
                btnaceptar.Enabled = True
                lblLimiteCredito.Visible = False
                lblLimiteCredito.Text = ""
            End If
        End If
    End Sub

    Private Function actualizarCreditoEmpleado()
        Dim codigoempleado As String = txtIdentidad.Text
        If txtdeduccion.Text <> "" Then
            Dim sqlactualizacredito As String = "UPDATE public.tbl_empleado_credito SET saldo_acumulado=saldo_acumulado+" + CDec(txtdeduccion.Text).ToString + " WHERE codigo_empleado='" + codigoempleado.ToString + "';"
            comando = New OdbcCommand(sqlactualizacredito, conexion)
            Try
                comando.ExecuteNonQuery()
            Catch ex As Exception

            End Try
        End If
    End Function

    Private Function suma()
        Dim efectivo As Decimal = CDec(valor(txtefectivo.Text)).ToString
        Dim tarjetacredito As Decimal = CDec(valor(txttarjetacredito.Text)).ToString
        Dim puntos As Decimal = CDec(valor(txtpuntos.Text)).ToString
        Dim descuentoplanilla As Decimal = CDec(valor(txtdeduccion.Text)).ToString
        cambio = 0

        If rbPagominimo.Checked Then
            cambio = -(total * porcentaje_preventa) + (efectivo + tarjetacredito + puntos + descuentoplanilla)
            total_pagar_check = CDec(total * porcentaje_preventa)
        End If

        If rbPagototal.Checked Then
            cambio = CDec(-total + (efectivo + tarjetacredito + puntos + descuentoplanilla))
            total_pagar_check = CDec(total)
        End If

        If chkllevacambio.Checked Then
            If cambio < 0 Then
                lblcambio.ForeColor = Color.Red
                lblcambio.Text = "Cambio: L." + cambio.ToString("#,##0.00")
            Else
                lblcambio.ForeColor = Color.Black
                lblcambio.Text = "Cambio: L." + cambio.ToString("#,##0.00")
            End If
        Else
            cambio = 0
            lblcambio.ForeColor = Color.Black
            lblcambio.Text = "Cambio: L.0.00"
        End If


    End Function

    Private Sub chkllevacambio_CheckedChanged(sender As Object, e As EventArgs) Handles chkllevacambio.CheckedChanged
        suma()
    End Sub

    Function actualizarDescuentoProductos(idventa As String, descuentoN As Integer)
        Dim sqlactualizaproductos As String = "SELECT public.fn_actualiza_precio_producto_descuento('" + idventa + "'," + descuentoN.ToString + ");"
        comando = New OdbcCommand(sqlactualizaproductos, conexion)
        LECTOR = comando.ExecuteReader()
        If LECTOR.HasRows Then
            Dim a As String = LECTOR(0).ToString
        End If
    End Function

    Private Sub rbPagototal_CheckedChanged(sender As Object, e As EventArgs) Handles rbPagototal.CheckedChanged
        btnaceptar.Enabled = True
        chkllevacambio.Checked = False
        suma()
    End Sub

    Private Sub rbPagominimo_CheckedChanged(sender As Object, e As EventArgs) Handles rbPagominimo.CheckedChanged
        btnaceptar.Enabled = True
        chkllevacambio.Checked = False
        suma()
    End Sub

    Private Sub pagoPreventa(pago_preventa As Decimal)
        Dim fecha As Date = Date.Now()
        Dim tipo_venta_rp As Integer = 2
        If empleadoventa = "si" Then
            tipo_venta_rp = 1
        End If

        Dim sqlguardarrecibo As String = "select fn_insert_recibo_preventa"
        sqlguardarrecibo += "(" + idventa.ToString + ",'" + txtIdentidad.Text + "','" + txtNombreCliente.Text + "'," + pago_preventa.ToString + ",'" + descuento_empleado.ToString + "'," + descuento.ToString + ",'" + id_pos.ToString + "'," + id_usuario.ToString + ",'" + fecha.ToString("dd/MM/yyy hh:MM:ss A") + "','" + fecha.ToString("yyyy/MM/dd") + "'," + tipo_venta_rp.ToString + ",'" + txtTelefonoCliente.Text + "'," + sessiones.id_loteventa.ToString + ");"
        comando = New OdbcCommand(sqlguardarrecibo, conexion)
        id_recibo = comando.ExecuteScalar
        guardarMetodosPago()
        imprimirrecibo.ImprimirRecibo(conexion, idventa.ToString, id_loteventa.ToString, "n", id_recibo.ToString)

        comando = New Odbc.OdbcCommand("UPDATE tbl_pos_venta  SET estado=0, cambio='" + cambio.ToString + "' WHERE id= '" + idventa.ToString + "'", conexion)
        comando.ExecuteNonQuery()

        If empleadoventa = "si" Then
            actualizarCreditoEmpleado()
            'actualizarDescuentoProductos(idventa, descuento)
        End If
        My.Forms.frmVenta.btncancela.Enabled = True
        My.Forms.frmVenta.btnespera.Enabled = False
        My.Forms.frmVenta.btnpago.Enabled = False
        My.Forms.frmVenta.txtCodigo.Text = ""
        My.Forms.frmVenta.txtCodigo.Enabled = False
        My.Forms.frmVenta.btn_reimprimir.Enabled = False
        My.Forms.frmVenta.DataGridView1.Rows.Clear()
        My.Forms.frmVenta.lblSub.Text = "L. 0.00"
        My.Forms.frmVenta.lbltotal.Text = "L. 0.00"
        My.Forms.frmVenta.lblimp.Text = "L. 0.00"
        TotalPago = 0
        Activacafe = 0
        cambio = 0
        empleadoventa = "no"
        codigoEmpleado = ""
        My.Forms.frmVenta.lblnombrecliente.Text = ""
        My.Forms.frmVenta.cmbTipo.SelectedValue = 5
        My.Forms.frmVenta.txtcod.Text = ""
        My.Forms.frmVenta.Button4.Enabled = True
        My.Forms.frmVenta.Button4.PerformClick()
        Me.Close()
    End Sub
End Class