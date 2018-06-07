Imports System.Data.Odbc
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Data
Imports System.Globalization
Imports System.Threading
Imports System.Drawing.Printing
Imports POSGDC.conexion

Public Class frmMetodoPago
    Dim con As New conexion
    'Dim conexion As New Odbc.OdbcConnection("DSN=ORIECOMP")
    Dim conexion As New Odbc.OdbcConnection()
    Dim comando As New Odbc.OdbcCommand
    Dim LECTOR As OdbcDataReader
    Dim CAI As String
    Dim RTN As String
    Dim CORREO As String
    Dim NombreSociedad As String
    Dim nombrelegal As String
    Dim valorimp As Decimal = 0
    Dim valorsub As Decimal = 0
    Dim numfact As String
    Dim rgcorrelativo As String
    Dim rgInicio As String
    Dim rgFinal As String
    Dim fechalimite As String
    Dim tasa As Decimal
    Dim dolares As Decimal
    Dim prev As Decimal
    Dim montotem As Decimal
    Dim totalpro As Decimal = 0.00
    Dim cefectivo As String = ""
    Dim ctc As String = ""
    Dim cpnt As String = ""
    Dim ccredito As String = ""
    Dim cwildcart As String = ""
    Dim cefdolar As String = ""
    Dim ccafegr As String = ""
    Dim ccarnet As String = ""
    Dim cdescuento As String = ""
    Dim codcliente As String = ""
    Dim codnombrecliente As String = ""
    Dim imprimirFact As New imprimir
    Dim totalpreventa = 0
    Dim totalapagar As Double
    Dim salariominimo As Decimal = 0
    Dim descuento As Integer = 0
    Dim salarioempleado As Decimal = 0
    Dim descuentoacobrar As Decimal = 0
    Dim creditototal As Decimal = 0
    Dim imprimirDosFacturas As String = ""

    Public codigoCarnet As String = ""
    Public saldoCarnet As Decimal = 0

    Dim efe As Decimal
    Dim tarj As Decimal
    Dim punt As Decimal
    Dim wild As Decimal
    Dim dol As Decimal
    Dim carne As Decimal
    Dim cred As Decimal
    Dim cambiopago As Decimal

    Dim psubtotal As Double
    Dim limitecredito As Double
    Dim saldoacumulado As Double

    Dim acu15 As Decimal = 0
    Dim acu18 As Decimal = 0
    Dim permiteCredito As Boolean = True
    Public ingresarTarjeta As Boolean = False

    'solo cuando la factura es al credito se usan estas variables
    'Dim subtotalnuevafactura As Decimal = 0
    'Dim totalnuevafactura As Decimal = 0
    'Dim descuentonuevafactura As Decimal = 0
    'Dim impuestonuevafactura As Decimal = 0
    'Dim subtotalnuevafacturasin15 As Decimal = 0
    'Dim subtotalnuevafacturasin18 As Decimal = 0
    'Dim subtotalnuevafacturasin0 As Decimal = 0
    'Dim isv15nuevafactura As Decimal = 0
    'Dim isv18nuevafactura As Decimal = 0
    'Dim anticipo_preventa As Decimal = 0

    Dim subtotalnuevafactura As Double = 0
    Dim totalnuevafactura As Double = 0
    Dim descuentonuevafactura As Double = 0
    Dim impuestonuevafactura As Double = 0
    Dim subtotalnuevafacturasin15 As Double = 0
    Dim subtotalnuevafacturasin18 As Double = 0
    Dim subtotalnuevafacturasin0 As Double = 0
    Dim isv15nuevafactura As Double = 0
    Dim isv18nuevafactura As Double = 0
    Dim anticipo_preventa As Double = 0

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
        Cambio = 11
    End Enum

    Public Property pgconection() As OdbcConnection
        Set(value As OdbcConnection)
            conexion = value
        End Set
        Get
            Return Me.conexion
        End Get
    End Property

    Public Property vtotalapagar() As Double
        Set(value As Double)
            totalapagar = value
        End Set
        Get
            Return Me.totalapagar
        End Get
    End Property


    Private Sub frmMetodoPago_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conexion = pgconection
        con.openConection(conexion)
        Me.txtNombref.Text = ""
        Me.txtRTN.Text = ""
        imprimirDosFacturas = "no"
        lblsubtotalcondescuento.Text = "Sub Total:"
        lblDescuento.Text = "Descuento: "
        lblisvcondescuento.Text = "ISV:"
        lbltotalcondescuento.Text = "Total:"
        lblpagocreditototal.Text = "Pago Total al Credito:" 
            codigoCarnet = ""
        'txtefectivo.Text = vtotalapagar()

        If codigoEmpleado <> "" Then
            Dim sqlc As String = "SELECT limite_credito,saldo_acumulado FROM public.tbl_empleado_credito WHERE codigo_empleado='" + codigoEmpleado + "' and credito_activo;"
            comando = New OdbcCommand(sqlc, conexion)
            LECTOR = comando.ExecuteReader()
            If LECTOR.Read Then
                limitecredito = CDec(LECTOR(0).ToString)
                saldoacumulado = CDec(LECTOR(1).ToString)
            Else
                limitecredito = 0
                saldoacumulado = 0
                permiteCredito = False
                MessageBox.Show("El empleado tiene suspendido el credito.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.Close()
            End If
            Dim creddisponible As Decimal = limitecredito - saldoacumulado
            lblCreditoDisponible.Text = "Credito Disponible: L." + creddisponible.ToString("#,##0.00")
        End If

        Button2.Enabled = True
        Me.txtcarnet.Enabled = True
        Me.txttc.Enabled = True
        Me.txtCredito.Enabled = True
        Me.txtdolar.Enabled = True
        Me.txtefectivo.Enabled = True
        Me.txtpuntos.Enabled = True
        Me.txtwildcart.Enabled = True
        Me.txtcarnet.Text = ""
        Me.txttc.Text = ""
        Me.txtCredito.Text = ""
        Me.txtdolar.Text = ""
        Me.txtefectivo.Text = 0
        Me.txtpuntos.Text = ""
        Me.txtwildcart.Text = ""
        Me.txtcafe.Text = ""
        totalpreventa = 0
        salariominimo = 0
        descuento = 0
        cefectivo = ""
        ctc = ""
        cpnt = ""
        ccredito = ""
        cwildcart = ""
        cefdolar = ""
        ccafegr = ""
        ccarnet = ""
        efe = 0
        tarj = 0
        punt = 0
        wild = 0
        dol = 0
        carne = 0
        cred = 0
        codcliente = My.Forms.frmVenta.txtcod.Text
        codnombrecliente = My.Forms.frmVenta.txtcod.Text + "-" + My.Forms.frmVenta.lblnombrecliente.Text
        Me.txtNombref.Text = If(My.Forms.frmVenta.lblnombrecliente.Text <> "", codnombrecliente, "Consumidor Final")
        Me.lblcambiomoney.Text = "L. 0.00"
        Me.lblefectivoregreso.Text = "L. 0.00"
        Me.lblpreventamonto.Text = "L. 0.00"
        Thread.CurrentThread.CurrentCulture = New CultureInfo("es-HN")

        If My.Forms.frmVenta.id_recibo_preventa <> 0 Then
            cargarMetodosPagoRecibo()
        End If

        'VENTA O PREVENTA
        If tipoventa = 1 Then
            'prev = Math.Round((TotalPago * 0.4), 2, MidpointRounding.ToEven)
            Me.lblpreventamonto.Text = "L." + CInt(anticipo_preventa).ToString("#,##0.00")

        Else
            'Me.lblpreventamonto.Visible = False
            If empleadoventa = "si" Then
                lbltotalpagar.Text = "L." + CDec(TotalPago - anticipo_preventa).ToString("#,##0.00")
            Else
                TotalPago = (TotalPago)
                lbltotalpagar.Text = "L." + CInt(TotalPago - anticipo_preventa).ToString("#,##0.00")
            End If

            txtefectivo.Select()
            Me.txtefectivo.Focus()
        End If

        Dim cad As String = ""


        'VENTA AL CREDITO O NO
        If empleadoventa = "si" Then
            Me.txtcarnet.Enabled = False
            Me.txttc.Enabled = False
            Me.txtCredito.Enabled = True
            Me.txtdolar.Enabled = False
            Me.txtefectivo.Enabled = False
            Me.txtpuntos.Enabled = False
            Me.txtwildcart.Enabled = False
            lblpagocreditototal.Text = "Pago sin descuento: L." + (vtotalapagar - anticipo_preventa).ToString("#,##0.00")
            'Dim sqlsalario As String = "SELECT valor FROM public.tbl_parametros WHERE id_parametro=48"
            'comando = New OdbcCommand(sqlsalario, conexion)
            'LECTOR = comando.ExecuteReader()
            'If LECTOR.Read Then
            '    salariominimo = Convert.ToDecimal(LECTOR(0).ToString)
            'End If
            Dim sqlsalarioempleado As String = "SELECT salario,descuento_empleado FROM public.tbl_empleado_credito WHERE codigo_empleado='" + My.Forms.frmVenta.txtcod.Text + "';"
            comando = New OdbcCommand(sqlsalarioempleado, conexion)
            LECTOR = comando.ExecuteReader()
            If LECTOR.Read Then
                salarioempleado = Convert.ToDecimal(LECTOR(0).ToString)
                descuento = Convert.ToDecimal(LECTOR(1).ToString)
            Else
                descuento = 0
            End If

            If My.Forms.frmVenta.id_recibo_preventa <> 0 Then
                descuento = 0
            End If

            If descuento <> 0 Then
                recalcularValores()
            End If

            'If (salarioempleado <= salariominimo) Then
            '    descuento = 15
            'ElseIf (salarioempleado > salariominimo And salarioempleado <= 12000) Then
            '    descuento = 10
            'Else
            '    descuento = 0
            'End If

            'lblDescuento.Text = "Descuento: L." + (CDec(subtotalSesion) * CDec(descuento / 100)).ToString("#,##0.00")
            'Me.txtCredito.Text = CDec(subtotalSesion + impSesion).ToString("#,##0.00")

        ElseIf empleadoventa = "no" Then
            Me.txtCredito.Enabled = False
            If My.Forms.frmVenta.nombre_cliente <> "" And My.Forms.frmVenta.codigo_cliente <> "" Then
                txtRTN.Text = My.Forms.frmVenta.codigo_cliente
                txtNombref.Text = My.Forms.frmVenta.nombre_cliente
            End If
            'If My.Forms.frmVenta.preventa_a_empleado = "si" Then

            '    Dim sqlsalarioempleado As String = "SELECT descuento_empleado FROM public.tbl_empleado_credito WHERE codigo_empleado='" + My.Forms.frmVenta.txtcod.Text + "' and credito_activo_preventa;"
            '    comando = New OdbcCommand(sqlsalarioempleado, conexion)
            '    LECTOR = comando.ExecuteReader()
            '    If LECTOR.Read Then
            '        'salarioempleado = Convert.ToDecimal(LECTOR(0).ToString)
            '        descuento = Convert.ToDecimal(LECTOR(0).ToString)
            '    Else
            '        descuento = 0
            '    End If

            '    If descuento <> 0 Then
            '        recalcularValores()
            '    End If
            'End If
            lbltotalpagar.Text = "L." + CInt(TotalPago - anticipo_preventa).ToString("#,##0.00")
        End If

        If Activacafe = 1 Then
            Me.txtcarnet.Enabled = False
            Me.txttc.Enabled = False
            Me.txtCredito.Enabled = False
            Me.txtdolar.Enabled = False
            Me.txtefectivo.Enabled = False
            Me.txtpuntos.Enabled = False
            Me.txtwildcart.Enabled = False
            txtcafe.Text = vtotalapagar().ToString
            txtcafe.Enabled = True
            Me.lbltotalpagar.Text = "L." + vtotalapagar.ToString
            'cad = "SELECT id, tipo FROM tbl_pos_metodospago where tipo = 'Cafe Gratis'"
            'Else
            '    Me.txtcarnet.Enabled = True
            '    Me.txtCredito.Enabled = True
            '    Me.txttc.Enabled = True
            '    Me.txtdolar.Enabled = True
            '    Me.txtefectivo.Enabled = True
            '    Me.txtpuntos.Enabled = True
            '    Me.txtwildcart.Enabled = True
            '    Me.txtcafe.Enabled = False
            '    txtefectivo.Select()
            '    txtefectivo.Focus()

            'cad = "SELECT id, tipo FROM tbl_pos_metodospago where tipo <> 'Cafe Gratis'"
        End If

        'If My.Forms.frmVenta.recargaCarnet = "si" Then
        '    txtcarnet.Enabled = False
        '    My.Forms.frmtipopago.pgconection = conexion
        '    My.Forms.frmtipopago.ShowDialog()
        'End If

        comando = New OdbcCommand("select  * from tbl_cambioactual", conexion)
        LECTOR = comando.ExecuteReader
        If LECTOR.Read Then
            tasa = CDbl(LECTOR(1).ToString)
        End If
        Me.lblCambio.Text = "$1 = " + "L." + tasa.ToString("#,##0.00")
        'Me.lbltotalpagar.Text = "L." + vtotalapagar.ToString("#,##0.00")
        'conexion.Close()
        'obtenercambiodollar()

    End Sub

    Private Sub chkDivido_CheckedChanged(sender As Object, e As EventArgs) Handles chkDivido.CheckedChanged
        If chkDivido.Checked = True Then
            imprimirDosFacturas = "si"
        Else
            imprimirDosFacturas = "no"
        End If
    End Sub

    Private Sub btnnuevopago_Click(sender As Object, e As EventArgs)
        My.Forms.frmfilatipopago.pgconection = conexion
        My.Forms.frmfilatipopago.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'tipo de venta normal
        If permiteCredito Then
            con.openConection(conexion)
            Dim efectivo As Decimal = 0
            Dim tc As Decimal = 0
            Dim pnt As Decimal = 0
            Dim credito As Decimal = 0
            Dim wildcart As Decimal = 0
            Dim efdolar As Decimal = 0
            Dim cafegr As Decimal = 0
            Dim carnet As Decimal = 0
            Dim cambio As Decimal = 0
            Dim dcto As Decimal = 0
            frmVenta.facturaanterior = idventa.ToString
            efectivo = CDbl(Val(Me.txtefectivo.Text))
            tc = CDbl(Val(Me.txttc.Text))
            credito = CDbl(Val(Me.txtCredito.Text))
            'dcto = ((credito * descuento) / 100)
            'credito = credito - dcto
            totalapagar = totalapagar - dcto
            pnt = CDbl(Val(Me.txtpuntos.Text))
            wildcart = CDbl(Val(Me.txtwildcart.Text))
            efdolar = CDbl(Val(Me.txtdolar.Text))
            cafegr = CDbl(Val(Me.txtcafe.Text))
            carnet = CDbl(Val(Me.txtcarnet.Text))

            Dim creditoactual As Double = If(txtCredito.Text <> "", Convert.ToDouble(txtCredito.Text), 0)
            'Dim descuentoempleado As Decimal = ((creditoactual * descuento) / 100)
            creditototal = saldoacumulado + creditoactual
            Dim tp As Decimal = 0
            If Activacafe = 1 Then
                tp = cafegr
            Else
                tp = efectivo + tc + credito + dcto + pnt + wildcart + (efdolar) + carnet
            End If

            If tp >= Convert.ToDecimal((vtotalapagar()-anticipo_preventa).ToString("#,##0.00")) Then
                    If (creditototal > limitecredito) Then
                        MessageBox.Show("Excedio el limite de credito. Disponible: L." + (limitecredito - saldoacumulado).ToString, "Limite excedido", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else

                        If (txtefectivo.Text <> "") Then
                            If Convert.ToDecimal(txtefectivo.Text) <> 0 Then
                                comando = New Odbc.OdbcCommand("INSERT INTO public.tbl_pos_ventametodospago(idventa, idmetodopago, monto)  VALUES ( '" + idventa.ToString + "', '1', '" + efectivo.ToString + "')", conexion)
                                comando.ExecuteNonQuery()
                                cefectivo = "Efectivo: L." + CDbl(Val(Me.txtefectivo.Text)).ToString("#,##0.00")
                            End If
                        End If

                        If (txttc.Text <> "") Then
                            If Convert.ToDecimal(txttc.Text) <> 0 Then
                                comando = New Odbc.OdbcCommand("INSERT INTO public.tbl_pos_ventametodospago(idventa, idmetodopago, monto)  VALUES ( '" + idventa.ToString + "', '2', '" + tc.ToString + "')", conexion)
                                comando.ExecuteNonQuery()
                                ctc = "T/C: L." + CDbl(Val(Me.txttc.Text)).ToString("#,##0.00")
                            End If
                        End If

                        If (txtpuntos.Text <> "") Then
                            If Convert.ToDecimal(txtpuntos.Text) <> 0 Then
                                comando = New Odbc.OdbcCommand("INSERT INTO public.tbl_pos_ventametodospago(idventa, idmetodopago, monto)  VALUES ( '" + idventa.ToString + "', '3', '" + pnt.ToString + "')", conexion)
                                comando.ExecuteNonQuery()
                                cpnt = "Puntos: L." + CDbl(Val(Me.txtpuntos.Text)).ToString("#,##0.00")
                            End If
                        End If

                        If (txtCredito.Text <> "") Then
                            If Convert.ToDecimal(txtCredito.Text) <> 0 Then
                                comando = New Odbc.OdbcCommand("INSERT INTO public.tbl_pos_ventametodospago(idventa, idmetodopago, monto, codempleado)  VALUES ( '" + idventa.ToString + "', '4', '" + credito.ToString + "', '" + My.Forms.frmVenta.txtcod.Text + "')", conexion)
                                comando.ExecuteNonQuery()
                                ccredito = "C/E: L." + credito.ToString

                                comando = New Odbc.OdbcCommand("INSERT INTO public.tbl_pos_ventametodospago(idventa, idmetodopago, monto, codempleado)  VALUES ( '" + idventa.ToString + "', '10', '" + descuentonuevafactura.ToString + "', '" + My.Forms.frmVenta.txtcod.Text + "')", conexion)
                                comando.ExecuteNonQuery()
                            cdescuento = "Desc/Emp: L." + dcto.ToString

                            comando = New OdbcCommand("INSERT INTO public.tbl_empleado_credito_centro(id_venta,id_metodo_pago,id_centro,monto,codigo_empleado,fecha) VALUES (" + idventa.ToString + ",10," + id_almacen.ToString + "," + (CDec(txtCredito.Text)).ToString + "," + My.Forms.frmVenta.txtcod.Text + ",now());", conexion)
                            comando.ExecuteNonQuery()
                        End If

                        End If

                        If (txtwildcart.Text <> "") Then
                            If Convert.ToDecimal(txtwildcart.Text) <> 0 Then
                                comando = New Odbc.OdbcCommand("INSERT INTO public.tbl_pos_ventametodospago(idventa, idmetodopago, monto)  VALUES ( '" + idventa.ToString + "', '5', '" + wildcart.ToString + "')", conexion)
                                comando.ExecuteNonQuery()
                                cwildcart = "Wildcard: L." + wildcart.ToString("#,##0.00")
                            End If
                        End If

                        If (txtdolar.Text <> "") Then
                            If Convert.ToDouble(txtdolar.Text) <> 0 Then
                                comando = New Odbc.OdbcCommand("INSERT INTO public.tbl_pos_ventametodospago(idventa, idmetodopago, monto, dolares)  VALUES ( '" + idventa.ToString + "', '7', '" + efdolar.ToString + "', '" + (efdolar / tasa).ToString("#,##0.00") + "')", conexion)
                                comando.ExecuteNonQuery()
                                cefdolar = "Dolar $: L." + CDbl(Val(Me.txtdolar.Text)).ToString("#,##0.00")
                            End If
                        End If

                        If (txtcafe.Text <> "") Then
                            If Convert.ToDecimal(txtcafe.Text) Then
                                comando = New Odbc.OdbcCommand("INSERT INTO public.tbl_pos_ventametodospago(idventa, idmetodopago, monto, codempleado)  VALUES ( '" + idventa.ToString + "', '8', '" + cafegr.ToString + "', '" + My.Forms.frmVenta.txtcod.Text + "')", conexion)
                                comando.ExecuteNonQuery()
                                ccafegr = "Cafe Gratis: L." + CDbl(Val(Me.txtcafe.Text)).ToString("#,##0.00")
                            End If
                        End If

                        If (txtcarnet.Text <> "") Then
                            Dim a As String = txtcarnet.Text
                            If Convert.ToDecimal(a) <> 0 Then
                                comando = New Odbc.OdbcCommand("INSERT INTO public.tbl_pos_ventametodospago(idventa, idmetodopago, monto, codempleado)  VALUES ( '" + idventa.ToString + "', '9', '" + a.ToString + "', '" + My.Forms.frmVenta.txtcod.Text + "')", conexion)
                                comando.ExecuteNonQuery()
                                ccarnet = "Carnet: L." + CDbl(Val(Me.txtcarnet.Text)).ToString("#,##0.00")
                            End If
                        End If

                        Dim valorfinal As Decimal = 0

                        If tipoventa = 0 Then
                            valorfinal = efectivo + tc + pnt + credito + wildcart + (efdolar) + cafegr + carnet

                            cambio = valorfinal - (Convert.ToDecimal((vtotalapagar-anticipo_preventa).ToString("#,##0.00")) - dcto)

                        'TotalPago = TotalPago - dcto

                        If cambio < 0 Then
                            MsgBox("Por favor verifique los valores ingresados.", MsgBoxStyle.Critical)
                        Else
                            If cambio > 0 Then
                                comando = New Odbc.OdbcCommand("INSERT INTO public.tbl_pos_ventametodospago(idventa, idmetodopago, monto)  VALUES ( '" + idventa.ToString + "', '11', '" + Convert.ToDecimal(cambio).ToString + "')", conexion)
                                comando.ExecuteNonQuery()
                            End If
                            InsertaFactura()
                            End If
                        Else
                            valorfinal = efectivo + tc + pnt + credito + wildcart + efdolar + cafegr + carnet
                            totalpreventa = valorfinal
                            If valorfinal < CInt(prev) Then
                                MsgBox("El valor a cobrar debe ser mayor a un 40%.", MsgBoxStyle.Critical)
                            Else
                            InsertaFactura()

                        End If
                        End If

                End If
                Else
                    MessageBox.Show("No puede pagar ingresando una cantidad menor al total", "Pago Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If

            Else
            MessageBox.Show("El empleado tiene suspendido el credito.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Public Sub InsertaFactura()
        If tipoventa = 0 Then
            'recorrer valores

            valorimp = impSesion
            valorsub = subtotalSesion

            con.openConection(conexion)
            comando = New OdbcCommand("select * from datosfacturaPOS where id='" + sessiones.id_pos.ToString + "'", conexion)

            LECTOR = comando.ExecuteReader
            If LECTOR.Read Then ' lee la consulta
                CAI = LECTOR(3).ToString
                Dim estado As Integer = 1
                rgcorrelativo = LECTOR(9).ToString + LECTOR(7).ToString + "/" + LECTOR(9).ToString + LECTOR(8).ToString
                Dim cajero As String = usuariotemp
                rgInicio = LECTOR(7).ToString
                rgFinal = LECTOR(8).ToString
                Dim rgcorre As String = LECTOR(9).ToString
                Dim ids As String = LECTOR(12).ToString
                Dim secu As String = LECTOR(14).ToString
                CORREO = LECTOR(11).ToString
                NombreSociedad = LECTOR(15).ToString
                nombrelegal = LECTOR(16).ToString
                fechalimite = LECTOR(17).ToString
                RTN = LECTOR(13).ToString
                Dim nom As String = ""
                If (Me.txtNombref.Text <> "") Then
                    nom = Me.txtNombref.Text
                Else
                    nom = "Consumidor Final"
                End If
                Dim da As String = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")

                Dim valortotalfacturaingresar As Decimal = 0
                Dim sqlinsert As String = ""
                If empleadoventa = "si" Then
                    valortotalfacturaingresar = CDec(impuestonuevafactura + subtotalnuevafactura - descuentonuevafactura).ToString("#,##0.00")
                    sqlinsert = "select fn_insertfacturaVenta('" + valortotalfacturaingresar.ToString("0.00") + "','" + CAI + "','" + estado.ToString + "','" + Me.txtRTN.Text + "','" + nom + "','" + subtotalnuevafactura.ToString("0.00") + "','" + impuestonuevafactura.ToString("0.00") + "','" + rgcorrelativo.ToString + "','" + cajero.ToString + "','" + ids.ToString + "','" + rgInicio.ToString + "','" + rgFinal.ToString + "','" + rgcorre.ToString + "','" + id_usuario.ToString + "','" + secu.ToString + "','" + sessiones.idventa.ToString + "','" + da + "'," + descuentonuevafactura.ToString(".00") + ")"
                Else
                    valortotalfacturaingresar = CDec((impSesion + subtotalSesion).ToString("0.00"))
                    sqlinsert = "select fn_insertfacturaVenta('" + valortotalfacturaingresar.ToString("0.00") + "','" + CAI + "','" + estado.ToString + "','" + Me.txtRTN.Text + "','" + nom + "','" + valorsub.ToString("0.00") + "','" + valorimp.ToString("0.00") + "','" + rgcorrelativo.ToString + "','" + cajero.ToString + "','" + ids.ToString + "','" + rgInicio.ToString + "','" + rgFinal.ToString + "','" + rgcorre.ToString + "','" + id_usuario.ToString + "','" + secu.ToString + "','" + sessiones.idventa.ToString + "','" + da + "',0.00)"
                End If

                comando = New OdbcCommand(sqlinsert, conexion)
                Dim LECTORtt As OdbcDataReader
                LECTORtt = comando.ExecuteReader
                If LECTORtt.Read Then
                    numfact = LECTORtt(0).ToString
                End If

                If codigoEmpleado <> "" And txtCredito.Text <> "" Then
                    Dim sqlupdate As String = "UPDATE public.tbl_empleado_credito SET saldo_acumulado= saldo_acumulado +" + (Convert.ToDouble(txtCredito.Text)).ToString + " WHERE codigo_empleado='" + codigoEmpleado + "';"
                    comando = New OdbcCommand(sqlupdate, conexion)
                    comando.ExecuteNonQuery()
                End If
            End If
            If imprimirDosFacturas = "si" Then
                PrintDocument1.Print()
                PrintDocument1.Print()
            Else
                PrintDocument1.Print()
            End If
            My.Forms.frmVenta.btncancela.Enabled = False
            My.Forms.frmVenta.btnespera.Enabled = False
            My.Forms.frmVenta.btnpago.Enabled = False
            My.Forms.frmVenta.Button4.Enabled = True
            My.Forms.frmVenta.txtCodigo.Text = ""
            My.Forms.frmVenta.txtCodigo.Enabled = False
            My.Forms.frmVenta.btn_reimprimir.Enabled = True
            My.Forms.frmVenta.DataGridView1.Rows.Clear()
            My.Forms.frmVenta.lblSub.Text = "L. 0.00"
            My.Forms.frmVenta.lbltotal.Text = "L. 0.00"
            My.Forms.frmVenta.lblimp.Text = "L. 0.00"
            valorsub = 0
            valorimp = 0
            TotalPago = 0
            Activacafe = 0
            totalpro = 0
            My.Forms.frmVenta.lblnombrecliente.Text = ""
            My.Forms.frmVenta.cmbTipo.SelectedValue = 5
            My.Forms.frmVenta.txtcod.Text = ""
            codigoEmpleado = ""
            'My.Forms.frmVenta.preventa_a_empleado = "no"
        Else

            'recorrer valores
            valorsub = subtotalSesion
            valorimp = impSesion
            comando = New OdbcCommand("select * from datosfacturaPOS where id='" + sessiones.id_pos.ToString + "'", conexion)

            LECTOR = comando.ExecuteReader
            If LECTOR.Read Then ' lee la consulta
                CAI = LECTOR(3).ToString
                Dim estado As Integer = 1
                rgcorrelativo = LECTOR(9).ToString + LECTOR(7).ToString + "-" + LECTOR(9).ToString + LECTOR(8).ToString
                Dim cajero As String = usuariotemp
                rgInicio = LECTOR(7).ToString
                rgFinal = LECTOR(8).ToString
                Dim rgcorre As String = LECTOR(9).ToString
                Dim ids As String = LECTOR(12).ToString
                Dim secu As String = LECTOR(14).ToString
                CORREO = LECTOR(11).ToString
                NombreSociedad = LECTOR(15).ToString
                nombrelegal = LECTOR(16).ToString
                fechalimite = LECTOR(17).ToString
                RTN = LECTOR(13).ToString

            End If
            Dim nom As String = ""
            If (Me.txtNombref.Text <> "") Then
                nom = codnombrecliente
            Else
                nom = "Consumidor Final"
            End If
            comando = New OdbcCommand("select fn_insertfacturaPREventa('" + TotalPago.ToString + "','" + Me.txtRTN.Text + "','" + nom + "','" + valorsub.ToString + "','" + valorimp.ToString + "','" + usuario.ToString + "','" + id_usuario.ToString + "','" + sessiones.idventa.ToString + "')", conexion)
            Dim LECTORtt As OdbcDataReader
            LECTORtt = comando.ExecuteReader
            If LECTORtt.Read Then
                numfact = LECTORtt(0).ToString
            End If
            PrintDocument2.Print()

        End If
        empleadoventa = "no"
        codigoEmpleado = ""
        Me.txtNombref.Text = ""
        Me.txtRTN.Text = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        anticipo_preventa = 0
        Me.Close()

    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim numero_factura As Integer = 0
        Dim sql1 As String = "SELECT cast(id as text),nombrecliente FROM vistafacturasventa WHERE id_venta=" + idventa.ToString + " and idalmacen='" + id_almacen.ToString + "' and id_usuario=" + id_usuario.ToString + ";"
        comando = New OdbcCommand(sql1, conexion)
        LECTOR = comando.ExecuteReader
        If LECTOR.Read Then
            numero_factura = LECTOR(0).ToString
        End If

        Dim topMargin As Double = e.MarginBounds.Top
        e.PageSettings.Margins.Left = 1
        e.PageSettings.Margins.Right = 1
        e.PageSettings.Landscape = False
        Dim sf As New StringFormat
        sf.Alignment = StringAlignment.Near
        Dim yPos As Double = 0
        Dim linesPerPage As Double = 0
        Dim count As Integer = 0
        Dim texto As String = ""
        Dim numinterno As Integer = 0
        Dim formato As StringFormat = New StringFormat
        Dim dispon As Decimal = 0
        acu15 = 0
        acu18 = 0
        formato.Alignment = StringAlignment.Center
        formato.LineAlignment = StringAlignment.Center
        Dim form As StringFormat = New StringFormat
        form.Alignment = StringAlignment.Far
        form.LineAlignment = StringAlignment.Far
        Dim printFont As System.Drawing.Font = New Font("Arial", 10)
        Dim printFont2 As System.Drawing.Font = New Font("Arial", 10)
        Dim printFont1 As System.Drawing.Font = New Font("Arial", 6)
        Dim printFont3 As System.Drawing.Font = New Font("Arial", 8)
        Dim printFont4 As System.Drawing.Font = New Font("Arial", 7)
        Dim printFont5 As System.Drawing.Font = New Font("Arial", 7)
        Dim printFontm As System.Drawing.Font = New Font("Arial", 7)
        Dim printFont4n As System.Drawing.Font = New Font("Arial", 7, FontStyle.Bold)
        Dim point1 As New Point(5, 120)
        Dim point2 As New Point(280, 120)
        e.Graphics.DrawLine(Pens.Black, point1, point2)
        e.Graphics.DrawString(NombreSociedad, printFont4, Brushes.Black, New RectangleF(0, 8, 280, printFont4.Height), formato)
        e.Graphics.DrawString(nombrelegal, printFont4, Brushes.Black, New RectangleF(0, 24, 280, printFont4.Height), formato)
        e.Graphics.DrawString("RTN: " + RTN, printFont4, Brushes.Black, New RectangleF(0, 40, 280, printFont4.Height), formato)
        e.Graphics.DrawString("Aldea Agua Dulce, Las Hadas", printFont4, Brushes.Black, New RectangleF(0, 56, 280, printFont4.Height), formato)
        e.Graphics.DrawString("Tegucigalpa, F.M., PBX", printFont4, Brushes.Black, New RectangleF(0, 72, 280, printFont4.Height), formato)
        e.Graphics.DrawString("2234-9595", printFont4, Brushes.Black, New RectangleF(0, 88, 280, printFont4.Height), formato)
        e.Graphics.DrawString(CORREO, printFont4, Brushes.Black, New RectangleF(0, 104, 280, printFont4.Height), formato)
        e.Graphics.DrawString("FACTURA", printFont4n, Brushes.Black, New RectangleF(0, 122, 280, printFont4n.Height), formato)
        Dim point As New Point(5, 139)
        Dim point1t As New Point(280, 139)
        e.Graphics.DrawLine(Pens.Black, point, point1t)
        e.Graphics.DrawString("POS#: " + id_pos.ToString, printFont3, Brushes.Black, 0, 142)
        e.Graphics.DrawString("Cajero: " + usuariotemp, printFont3, Brushes.Black, 100, 142)
        e.Graphics.DrawString("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy"), printFont3, Brushes.Black, 0, 158)
        e.Graphics.DrawString("Hora: " + DateTime.Now.ToString("hh:mm"), printFont3, Brushes.Black, 160, 158)
        e.Graphics.DrawString("CORRELATIVO: " + numfact, printFont3, Brushes.Black, 0, 174)
        e.Graphics.DrawString("CAI: " + CAI, printFont4, Brushes.Black, 0, 190)
        e.Graphics.DrawString("FECHA LIMITE EMISION: " + fechalimite, printFont5, Brushes.Black, 0, 206)
        e.Graphics.DrawString("DESDE: " + rgInicio, printFont5, Brushes.Black, 0, 222)
        e.Graphics.DrawString("HASTA: " + rgFinal, printFont5, Brushes.Black, 135, 222)
        If (txtRTN.Text <> "") Then
            e.Graphics.DrawString("RTN: " + Me.txtRTN.Text + " " + My.Forms.frmVenta.txtcod.Text, printFontm, Brushes.Black, 0, 238)
        Else
            e.Graphics.DrawString("RTN: ", printFont5, Brushes.Black, 0, 238)
        End If
        Dim y As Integer = 248
        If (Me.txtNombref.Text <> " " And Me.txtNombref.Text <> "") Then
            e.Graphics.DrawString("NOMBRE: " + Me.txtNombref.Text, printFontm, Brushes.Black, 0, y)
            If codcliente.ToString <> "" Then
                y = y + 10
                e.Graphics.DrawString("CODIGO EMPLEADO: " + codcliente, printFontm, Brushes.Black, 0, y)
                y = y + 10
                e.Graphics.DrawString("Credito Acumulado: L." + creditototal.ToString("#,##0.00"), printFontm, Brushes.Black, 0, y)
            End If
        Else
            e.Graphics.DrawString("NOMBRE: Consumidor Final", printFont5, Brushes.Black, 0, y)
        End If

        y = y + 15
        Dim point3 As New Point(5, y)
        Dim point4 As New Point(280, y)
        e.Graphics.DrawLine(Pens.Black, point3, point4)
        Dim sin_isv As Decimal = 0
        Dim isv_15 As Decimal = 0
        Dim isv_18 As Decimal = 0
        Dim isv_si_no As String = ""
        sin_isv = 0
        isv_15 = 0
        isv_18 = 0
        y = y + 2
        e.Graphics.DrawString("Cant.", printFont5, Brushes.Black, New RectangleF(0, y, 30, printFont5.Height), formato)
        e.Graphics.DrawString("Descripcion.", printFont5, Brushes.Black, New RectangleF(20, y, 200, printFont5.Height), formato)
        e.Graphics.DrawString("Valor.", printFont5, Brushes.Black, New RectangleF(160, y, 85, printFont5.Height), formato)
        y = y + 10
        Dim efect As Decimal = 0
        Dim camb As Decimal = 0
        Dim adaptador As New OdbcDataAdapter("select * from VistaItemsVenta where idventa='" + sessiones.idventa.ToString + "' order by id", conexion)
        Dim data As New DataSet
        Dim cont As Integer = 1
        adaptador.Fill(data, "VistaItemsVenta")
        adaptador.FillSchema(data.Tables("VistaItemsVenta"), SchemaType.Source)

        'LEE LOS ITEMS DE LA VENTA Y GENERA LOS TOTALES 
        For Each dr As DataRow In data.Tables("VistaItemsVenta").Rows
            y = y + 10
            numinterno = dr.Item(10).ToString
            comando = New OdbcCommand("select fn_setmovimientoinventarioVentas('" + dr.Item(1).ToString + "','" + numinterno.ToString + "','" + cont.ToString + "','" + dr.Item(12).ToString + "','" + dr.Item(8).ToString + "','" + dr.Item(6).ToString + "','120','" + dr.Item(7).ToString + "','1','" + dr.Item(9).ToString + "','-1')", conexion)
            cont = cont + 1
            LECTOR = comando.ExecuteReader
            If LECTOR.Read Then ' lee la consulta
                dispon = CDbl(Val(LECTOR(0).ToString))
            End If
            e.Graphics.DrawString(dr.Item(6).ToString, printFont5, Brushes.Black, New RectangleF(0, y, 15, printFont5.Height))
            'NOMBRE DEL PRODUCTO
            Dim subcadena As String
            Dim s As String = dr.Item(5).ToString
            Dim tam As Integer = (dr.Item(5).ToString).Length
            If (tam > 30) Then
                subcadena = (dr.Item(5).ToString).Substring(0, 30)
                e.Graphics.DrawString(subcadena, printFont5, Brushes.Black, New RectangleF(20, y, 180, printFont5.Height))
                y = y + 10
                Dim sub2 As String = ""
                sub2 = s.Substring(30, tam - 30)
                e.Graphics.DrawString(sub2, printFont5, Brushes.Black, New RectangleF(20, y, 180, printFont5.Height))
            Else
                subcadena = (dr.Item(5).ToString)
                e.Graphics.DrawString(subcadena, printFont5, Brushes.Black, New RectangleF(20, y, 180, printFont5.Height))
            End If

            Dim valor_isv As Integer = Convert.ToInt32(dr(14).ToString)
            'CALCULA LOS TOTALES REALES SIN DESCUENTO
            If valor_isv = 0 Then
                isv_si_no = "E"
                sin_isv = sin_isv + CDec((CDec(dr.Item(2).ToString)) * Val(dr.Item(6).ToString))

            ElseIf valor_isv = 15 Then
                isv_si_no = "G"
                Dim a As Decimal = CDec(dr.Item(2)).ToString
                isv_15 = isv_15 + CDec(a * Val(dr.Item(6).ToString))
            Else
                isv_si_no = "G"
                Dim b As Decimal = CDec(dr.Item(2).ToString)
                isv_18 = isv_18 + CDec(b * Val(dr.Item(6).ToString))
            End If
            'precio del producto por cantidad
            'Dim preciototalproducto As Double = ((CDec(dr.Item(2).ToString) + CDec(dr.Item(4))) * Val(dr.Item(6).ToString))

            Dim preciototalproducto As Decimal = (CDec(dr.Item(3)))

            'precio unitario
            'Dim preciototalproducto As Double = ((CDec(dr.Item(2).ToString) + CDec(dr.Item(4))))
            e.Graphics.DrawString("L. " + preciototalproducto.ToString("#,##0.00") + " ." + isv_si_no.ToString, printFont5, Brushes.Black, New RectangleF(150, y, 85, printFont5.Height), form)

            'si vewnta empleado
            If empleadoventa = "si" Then
                y = y + 10
                Dim cant As Integer = Val(dr.Item(6).ToString)
                e.Graphics.DrawString("Descuento:", printFont5, Brushes.Black, New RectangleF(20, y, 180, printFont5.Height))
                e.Graphics.DrawString("L.-" + (CDec((dr.Item(2).ToString) * descuento / 100) * cant).ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(150, y, 85, printFont5.Height), form)
            End If

            'actualiza el disponible
            Dim dispon1 As Decimal = dispon - Val(dr.Item(6).ToString)
            comando = New OdbcCommand("UPDATE tbl_material_centro  SET disponible='" + dispon1.ToString + "' WHERE id='" + dr.Item(1).ToString + "'", conexion)
            LECTOR = comando.ExecuteReader
            If LECTOR.Read Then ' lee la consulta
                dispon = CDbl(Val(LECTOR(0).ToString))
            End If
            y = y + 10
        Next
        y = y + 10
        Dim point6 As New Point(5, y)
        Dim point7 As New Point(280, y)
        e.Graphics.DrawLine(Pens.Black, point6, point7)


        If empleadoventa = "no" Then
            y = y + 10
            e.Graphics.DrawString("Sub total:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
            e.Graphics.DrawString("L." + valorsub.ToString("#,##0.00"), printFont4n, Brushes.Black, New RectangleF(140, y, 100, printFont4n.Height), form)


            'If descuentoacobrar > 0 Then
            '    y = y + 10
            '    e.Graphics.DrawString("Descuento: ", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
            '    e.Graphics.DrawString("-" + descuentoacobrar.ToString("#,##0.00"), printFont4n, Brushes.Black, New RectangleF(140, y, 100, printFont4n.Height), form)
            'End If

            y = y + 10
            e.Graphics.DrawString("Imp:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
            e.Graphics.DrawString("L." + CDec(impSesion).ToString("#,##0.00"), printFont4n, Brushes.Black, New RectangleF(140, y, 100, printFont4n.Height), form)
            y = y + 10

            Dim p1 As New Point(5, y)
            Dim p2 As New Point(280, y)
            e.Graphics.DrawLine(Pens.Black, point3, point4)

            'Dim tt As Decimal = (valorsub + valorimp - descuentoacobrar)
            Dim tt As Decimal = (valorsub + valorimp)
            e.Graphics.DrawString("Total:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
            e.Graphics.DrawString("L." + (tt).ToString("#,##0.00"), printFont4n, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)
        End If
        'VENTA AL CREDITO A UN EMPLEADO SE GENERA UN NUEVO BALANCE
        If empleadoventa = "si" Then
            y = y + 10
            e.Graphics.DrawString("Nuevo Balance con Descuento Empleado.", printFont5, Brushes.Black, New RectangleF(20, y, 200, printFont5.Height), form)

            y = y + 10
            e.Graphics.DrawString("Sub total:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
            valorsub = subtotalnuevafactura
            e.Graphics.DrawString("L." + valorsub.ToString("#,##0.00"), printFont4n, Brushes.Black, New RectangleF(140, y, 100, printFont4n.Height), form)

            y = y + 10
            e.Graphics.DrawString("Descuento:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
            e.Graphics.DrawString("L." + descuentonuevafactura.ToString("#,##0.00"), printFont4n, Brushes.Black, New RectangleF(140, y, 100, printFont4n.Height), form)

            y = y + 10
            e.Graphics.DrawString("ISV:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
            e.Graphics.DrawString("L." + CDec(isv15nuevafactura + isv18nuevafactura).ToString("#,##0.00"), printFont4n, Brushes.Black, New RectangleF(140, y, 100, printFont4n.Height), form)

            y = y + 10
            e.Graphics.DrawString("Total:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
            TotalPago = totalnuevafactura
            e.Graphics.DrawString("L." + TotalPago.ToString("#,##0.00"), printFont4n, Brushes.Black, New RectangleF(140, y, 100, printFont4n.Height), form)

            acu15 = CDec(isv15nuevafactura)
            acu18 = CDec(isv18nuevafactura)
            sin_isv = CDec(subtotalnuevafacturasin0 - CDec(subtotalnuevafacturasin0 * descuento / 100))
            isv_15 = CDec(subtotalnuevafacturasin15 - CDec(subtotalnuevafacturasin15 * descuento / 100))
            isv_18 = CDec(subtotalnuevafacturasin18 - CDec(subtotalnuevafacturasin18 * descuento / 100))
            valorsub = CDec((sin_isv + isv_15 + isv_18))
        End If

        Dim tarjeta As String = "no"

        If (cefectivo <> "") Then
            y = y + 10
            e.Graphics.DrawString("Efectivo:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
            e.Graphics.DrawString("L. " + CDec(txtefectivo.Text).ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)
        End If
        If (ctc <> "") Then
            y = y + 10
            e.Graphics.DrawString("T/C:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
            e.Graphics.DrawString("L. " + CDec(txttc.Text).ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)
            tarjeta = "si"
        End If
        If (cpnt <> "") Then
            y = y + 10
            e.Graphics.DrawString("Puntos:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
            e.Graphics.DrawString("L. " + CDec(txtpuntos.Text).ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)
        End If
        If (ccredito <> "") Then
            y = y + 10
            e.Graphics.DrawString("Credito Empleado:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
            e.Graphics.DrawString("L. " + CDec(txtCredito.Text).ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)
            y = y + 10
            'e.Graphics.DrawString("Descuento Empleado:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
            'e.Graphics.DrawString("L. " + descuentoacobrar.ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)
        End If
        If (cwildcart <> "" And cwildcart <> "Wildcard: L.0.00") Then
            y = y + 10
            e.Graphics.DrawString("Wildcard:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
            e.Graphics.DrawString("L. " + CDec(txtwildcart.Text).ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)
        End If
        If (cefdolar <> "") Then
            y = y + 10
            e.Graphics.DrawString("Dollar:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
            e.Graphics.DrawString("$. " + (Convert.ToDecimal(txtdolar.Text) / tasa).ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)
            y = y + 10
            e.Graphics.DrawString("1$ = L." + tasa.ToString, printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
        End If
        If (ccafegr <> "") Then
            y = y + 10
            e.Graphics.DrawString("Cafe Gratis:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
            e.Graphics.DrawString("L. " + CDec(txtcafe.Text).ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)
        End If
        If (ccarnet <> "") Then
            y = y + 10
            e.Graphics.DrawString("Carnet:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
            e.Graphics.DrawString("L. " + CDec(txtcarnet.Text).ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)
        End If

        If cambiopago > 0 Then
            y = y + 10
            e.Graphics.DrawString("Cambio:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
            e.Graphics.DrawString("L. " + cambiopago.ToString("#,##0.00"), printFont4n, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)
        End If
        y = y + 10
        Dim pp As Decimal = 0
        'Busca si tiene asociado un recibo  y selecciona los metodos de pago para imprimirlos 
        Dim sqlrecibo As String = "SELECT id_recibo,pago_preventa FROM public.tbl_recibo_preventa WHERE id_numero_venta=" + idventa.ToString + ";"
        comando = New OdbcCommand(sqlrecibo, conexion)
        Dim cambio_pv As Decimal = 0
        LECTOR = comando.ExecuteReader
        Dim id_recibo As Integer = 0
        If LECTOR.HasRows Then
            id_recibo = CInt(LECTOR(0).ToString)
            pp = CDec(LECTOR(1).ToString)
            Dim sqlmetodopago As String = "SELECT id_metodo_pago,monto FROM public.tbl_recibo_preventa_metodospago WHERE id_recibo=" + id_recibo.ToString + ";"
            comando = New OdbcCommand(sqlmetodopago, conexion)
            LECTOR = comando.ExecuteReader
            If LECTOR.HasRows Then
                y = y + 10
                e.Graphics.DrawString("Pago Preventa", printFont5, Brushes.Black, New RectangleF(20, y, 100, printFont5.Height), form)
                y = y + 10
                While LECTOR.Read
                    If CInt(LECTOR(0)) = metodospago.efectivo Then
                        e.Graphics.DrawString("Efectivo:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
                        e.Graphics.DrawString("L. " + CDec(LECTOR(1)).ToString("#,##0.00"), printFont4n, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)
                        y = y + 10
                    End If

                    If CInt(LECTOR(0)) = metodospago.tarjeta Then
                        e.Graphics.DrawString("T/C:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
                        e.Graphics.DrawString("L. " + CDec(LECTOR(1)).ToString("#,##0.00"), printFont4n, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)
                        y = y + 10
                    End If

                    If CInt(LECTOR(0)) = metodospago.puntos Then
                        e.Graphics.DrawString("Puntos:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
                        e.Graphics.DrawString("L. " + CDec(LECTOR(1)).ToString("#,##0.00"), printFont4n, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)
                        y = y + 10
                    End If

                    If CInt(LECTOR(0)) = metodospago.creditoempleado Then
                        e.Graphics.DrawString("Credito Empleado:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
                        e.Graphics.DrawString("L. " + CDec(LECTOR(1)).ToString("#,##0.00"), printFont4n, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)
                        y = y + 10
                    End If

                    If CInt(LECTOR(0)) = metodospago.Cambio Then
                        e.Graphics.DrawString("Cambio:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
                        e.Graphics.DrawString("L. " + CDec(LECTOR(1)).ToString("#,##0.00"), printFont4n, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)
                        cambio_pv = CDec(LECTOR(1))
                        y = y + 10
                    End If
                End While
                e.Graphics.DrawString("Total: ", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
                e.Graphics.DrawString("L. " + CDec(pp - cambio_pv).ToString("#,##0.00"), printFont4n, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)
            End If

            Dim sqlupdaterecibo As String = "UPDATE public.tbl_recibo_preventa SET recibo_activo=FALSE WHERE id_recibo=" + id_recibo.ToString + ";"
            comando = New OdbcCommand(sqlupdaterecibo, conexion)
            comando.ExecuteNonQuery()

        End If



        comando = New Odbc.OdbcCommand("UPDATE tbl_pos_venta  SET estado=0, cambio='" + totalpro.ToString + "' WHERE id= '" + idventa.ToString + "'", conexion)
        comando.ExecuteNonQuery()
        Dim acuEx As Decimal = 0

        If empleadoventa = "no" Then
            'Dim factorimpuestos As Integer
            'For Each dr As DataRow In data.Tables("VistaItemsVenta").Rows
            '    factorimpuestos = CInt(dr.Item(14))
            '    If factorimpuestos = 15 Then
            '        acu15 = acu15 + (CDec(dr.Item(2).ToString) * factorimpuestos / 100) * Val(dr.Item(6).ToString)
            '    ElseIf factorimpuestos = 18 Then
            '        acu18 = acu18 + (CDec(dr.Item(2).ToString) * factorimpuestos / 100) * Val(dr.Item(6).ToString)
            '    End If
            'Next
            For i As Integer = 0 To My.Forms.frmVenta.DataGridView1.Rows.Count - 1
                If (My.Forms.frmVenta.DataGridView1.Rows(i).Cells(6).Value.ToString = "15") Then
                    acu15 = acu15 + ((Val(My.Forms.frmVenta.DataGridView1.Rows(i).Cells(3).Value.ToString)) * (My.Forms.frmVenta.DataGridView1.Rows(i).Cells(0).Value))
                End If
                If (My.Forms.frmVenta.DataGridView1.Rows(i).Cells(6).Value.ToString = "18") Then
                    acu18 = acu18 + ((Val(My.Forms.frmVenta.DataGridView1.Rows(i).Cells(3).Value.ToString)) * (My.Forms.frmVenta.DataGridView1.Rows(i).Cells(0).Value))
                End If
            Next
        End If
        y = y + 10
        Dim pointi As New Point(5, y)
        Dim pointif As New Point(280, y)
        e.Graphics.DrawLine(Pens.Black, pointi, pointif)

        If tarjeta <> "no" Then
            y = y + 5
            Dim sqltc = "SELECT numerotarjteta,numerotransaccion,fechavencimiento FROM public.tbl_pos_ventacreditotarjeta WHERE idventa=" + idventa.ToString + ";"
            comando = New OdbcCommand(sqltc, conexion)
            LECTOR = comando.ExecuteReader()
            If LECTOR.HasRows Then
                If LECTOR.Read Then
                    Dim notarjeta As String = LECTOR(0).ToString
                    Dim numerot As String = LECTOR(1).ToString
                    Dim fecha As String = LECTOR(2).ToString
                    e.Graphics.DrawString("No.Tarjeta:", printFont5, Brushes.Black, New RectangleF(20, y, 100, printFont5.Height), form)
                    e.Graphics.DrawString(notarjeta, printFont5, Brushes.Black, New RectangleF(60, y, 100, printFont5.Height), form)
                    y = y + 10
                    e.Graphics.DrawString("Transaccion:", printFont5, Brushes.Black, New RectangleF(20, y, 100, printFont5.Height), form)
                    e.Graphics.DrawString(numerot, printFont5, Brushes.Black, New RectangleF(60, y, 100, printFont5.Height), form)
                    y = y + 10
                    e.Graphics.DrawString("Fecha vencimiento:", printFont5, Brushes.Black, New RectangleF(20, y, 100, printFont5.Height), form)
                    e.Graphics.DrawString(fecha, printFont5, Brushes.Black, New RectangleF(60, y, 100, printFont5.Height), form)
                    y = y + 10
                    pointi = New Point(5, y)
                    pointif = New Point(280, y)
                    e.Graphics.DrawLine(Pens.Black, pointi, pointif)
                End If
            End If
            y = y + 5
        End If
        'e.Graphics.DrawString("Detalle de impuesto", printFontm, Brushes.Black, New RectangleF(5, y, 240, printFont4.Height), formato)
        'y = y + 10
        'e.Graphics.DrawString("Imp", printFontm, Brushes.Black, New RectangleF(0, y, 30, printFontm.Height), form)
        'e.Graphics.DrawString("Base", printFontm, Brushes.Black, New RectangleF(40, y, 50, printFontm.Height), form)
        'e.Graphics.DrawString("valor", printFontm, Brushes.Black, New RectangleF(90, y, 60, printFontm.Height), form)
        'e.Graphics.DrawString("Precio Total", printFontm, Brushes.Black, New RectangleF(150, y, 85, printFontm.Height), form)
        'y = y + 10
        'Dim poin As New Point(5, y)
        'Dim poinif As New Point(280, y)
        'e.Graphics.DrawLine(Pens.Black, poin, poinif)
        'y = y + 5
        'e.Graphics.DrawString("Exent", printFontm, Brushes.Black, New RectangleF(0, y, 30, printFontm.Height), form)
        'e.Graphics.DrawString(sin_isv, printFontm, Brushes.Black, New RectangleF(40, y, 50, printFontm.Height), form)
        'e.Graphics.DrawString("0.00", printFontm, Brushes.Black, New RectangleF(90, y, 60, printFontm.Height), form)
        'e.Graphics.DrawString(sin_isv, printFontm, Brushes.Black, New RectangleF(150, y, 85, printFontm.Height), form)
        'y = y + 10
        'If acu15 > 0 Then
        '    e.Graphics.DrawString("15%", printFontm, Brushes.Black, New RectangleF(0, y, 30, printFontm.Height), form)
        '    e.Graphics.DrawString("L." + isv_15.ToString, printFontm, Brushes.Black, New RectangleF(40, y, 50, printFontm.Height), form)
        '    e.Graphics.DrawString("L." + acu15.ToString("#,##0.00"), printFontm, Brushes.Black, New RectangleF(90, y, 60, printFontm.Height), form)
        '    e.Graphics.DrawString("L." + (isv_15 + acu15).ToString("#,##0.00"), printFontm, Brushes.Black, New RectangleF(150, y, 85, printFontm.Height), form)
        'Else
        '    e.Graphics.DrawString("15%", printFontm, Brushes.Black, New RectangleF(0, y, 30, printFontm.Height), form)
        '    e.Graphics.DrawString("0.00", printFontm, Brushes.Black, New RectangleF(40, y, 50, printFontm.Height), form)
        '    e.Graphics.DrawString("0.00", printFontm, Brushes.Black, New RectangleF(90, y, 60, printFontm.Height), form)
        '    e.Graphics.DrawString("0.00", printFontm, Brushes.Black, New RectangleF(150, y, 85, printFontm.Height), form)
        'End If
        'y = y + 10
        'If acu18 > 0 Then
        '    e.Graphics.DrawString("18%", printFontm, Brushes.Black, New RectangleF(0, y, 30, printFontm.Height), form)
        '    e.Graphics.DrawString("L." + isv_18.ToString, printFontm, Brushes.Black, New RectangleF(40, y, 50, printFontm.Height), form)
        '    e.Graphics.DrawString("L." + acu18.ToString("#,##0.00"), printFontm, Brushes.Black, New RectangleF(90, y, 60, printFontm.Height), form)
        '    e.Graphics.DrawString("L." + (isv_18 + acu18).ToString("#,##0.00"), printFontm, Brushes.Black, New RectangleF(150, y, 85, printFontm.Height), form)
        'Else
        '    e.Graphics.DrawString("18%", printFontm, Brushes.Black, New RectangleF(0, y, 30, printFontm.Height), form)
        '    e.Graphics.DrawString("0.00", printFontm, Brushes.Black, New RectangleF(40, y, 50, printFontm.Height), form)
        '    e.Graphics.DrawString("0.00", printFontm, Brushes.Black, New RectangleF(90, y, 60, printFontm.Height), form)
        '    e.Graphics.DrawString("0.00", printFontm, Brushes.Black, New RectangleF(150, y, 85, printFontm.Height), form)
        'End If
        'y = y + 10
        'e.Graphics.DrawString("Total", printFontm, Brushes.Black, New RectangleF(0, y, 30, printFontm.Height), form)
        'e.Graphics.DrawString("L." + (valorsub).ToString("#,##0.00"), printFontm, Brushes.Black, New RectangleF(40, y, 50, printFontm.Height), form)
        'e.Graphics.DrawString("L." + (acu18 + acu15).ToString("#,##0.00"), printFontm, Brushes.Black, New RectangleF(90, y, 60, printFontm.Height), form)
        'e.Graphics.DrawString("L." + (TotalPago).ToString("#,##0.00"), printFontm, Brushes.Black, New RectangleF(150, y, 85, printFontm.Height), form)


        e.Graphics.DrawString("Detalle de impuesto", printFontm, Brushes.Black, New RectangleF(5, y, 240, printFont4.Height), formato)
        y = y + 10
        e.Graphics.DrawString("Imp", printFontm, Brushes.Black, New RectangleF(0, y, 30, printFontm.Height), form)
        e.Graphics.DrawString("Base", printFontm, Brushes.Black, New RectangleF(40, y, 50, printFontm.Height), form)
        e.Graphics.DrawString("valor", printFontm, Brushes.Black, New RectangleF(90, y, 60, printFontm.Height), form)
        e.Graphics.DrawString("Precio Total", printFontm, Brushes.Black, New RectangleF(150, y, 85, printFontm.Height), form)
        y = y + 10
        Dim poin As New Point(5, y)
        Dim poinif As New Point(280, y)
        e.Graphics.DrawLine(Pens.Black, poin, poinif)
        y = y + 5
        e.Graphics.DrawString("Exent", printFontm, Brushes.Black, New RectangleF(0, y, 30, printFontm.Height), form)
        e.Graphics.DrawString("L.", printFontm, Brushes.Black, New RectangleF(20, y, 30, printFontm.Height), form)
        e.Graphics.DrawString(CDec(sin_isv).ToString("#,##0.00"), printFontm, Brushes.Black, New RectangleF(40, y, 50, printFontm.Height), form)
        e.Graphics.DrawString("L.", printFontm, Brushes.Black, New RectangleF(85, y, 30, printFontm.Height), form)
        e.Graphics.DrawString("0.00", printFontm, Brushes.Black, New RectangleF(90, y, 60, printFontm.Height), form)
        e.Graphics.DrawString("L.", printFontm, Brushes.Black, New RectangleF(145, y, 30, printFontm.Height), form)
        e.Graphics.DrawString(CDec(sin_isv).ToString("#,##0.00"), printFontm, Brushes.Black, New RectangleF(150, y, 85, printFontm.Height), form)
        y = y + 10
        If acu15 > 0 Then
            e.Graphics.DrawString("15%", printFontm, Brushes.Black, New RectangleF(0, y, 30, printFontm.Height), form)
            e.Graphics.DrawString("L.", printFontm, Brushes.Black, New RectangleF(20, y, 30, printFontm.Height), form)
            e.Graphics.DrawString(CDec(isv_15).ToString("#,##0.00"), printFontm, Brushes.Black, New RectangleF(40, y, 50, printFontm.Height), form)
            e.Graphics.DrawString("L.", printFontm, Brushes.Black, New RectangleF(85, y, 30, printFontm.Height), form)
            e.Graphics.DrawString(CDec(acu15).ToString("#,##0.00"), printFontm, Brushes.Black, New RectangleF(90, y, 60, printFontm.Height), form)
            e.Graphics.DrawString("L.", printFontm, Brushes.Black, New RectangleF(145, y, 30, printFontm.Height), form)
            e.Graphics.DrawString(CDec(isv_15 + acu15).ToString("#,##0.00"), printFontm, Brushes.Black, New RectangleF(150, y, 85, printFontm.Height), form)
        Else
            e.Graphics.DrawString("15%", printFontm, Brushes.Black, New RectangleF(0, y, 30, printFontm.Height), form)
            e.Graphics.DrawString("L.", printFontm, Brushes.Black, New RectangleF(20, y, 30, printFontm.Height), form)
            e.Graphics.DrawString("0.00", printFontm, Brushes.Black, New RectangleF(40, y, 50, printFontm.Height), form)
            e.Graphics.DrawString("L.", printFontm, Brushes.Black, New RectangleF(85, y, 30, printFontm.Height), form)
            e.Graphics.DrawString("0.00", printFontm, Brushes.Black, New RectangleF(90, y, 60, printFontm.Height), form)
            e.Graphics.DrawString("L.", printFontm, Brushes.Black, New RectangleF(145, y, 30, printFontm.Height), form)
            e.Graphics.DrawString("0.00", printFontm, Brushes.Black, New RectangleF(150, y, 85, printFontm.Height), form)
        End If
        y = y + 10
        If acu18 > 0 Then
            e.Graphics.DrawString("18%", printFontm, Brushes.Black, New RectangleF(0, y, 30, printFontm.Height), form)
            e.Graphics.DrawString("L.", printFontm, Brushes.Black, New RectangleF(20, y, 30, printFontm.Height), form)
            e.Graphics.DrawString(CDec(isv_18).ToString("#,##0.00"), printFontm, Brushes.Black, New RectangleF(40, y, 50, printFontm.Height), form)
            e.Graphics.DrawString("L.", printFontm, Brushes.Black, New RectangleF(83, y, 30, printFontm.Height), form)
            e.Graphics.DrawString(CDec(acu18).ToString("#,##0.00"), printFontm, Brushes.Black, New RectangleF(90, y, 60, printFontm.Height), form)
            e.Graphics.DrawString("L.", printFontm, Brushes.Black, New RectangleF(143, y, 30, printFontm.Height), form)
            e.Graphics.DrawString(CDec(isv_18 + acu18).ToString("#,##0.00"), printFontm, Brushes.Black, New RectangleF(150, y, 85, printFontm.Height), form)
        Else
            e.Graphics.DrawString("18%", printFontm, Brushes.Black, New RectangleF(0, y, 30, printFontm.Height), form)
            e.Graphics.DrawString("L.", printFontm, Brushes.Black, New RectangleF(20, y, 30, printFontm.Height), form)
            e.Graphics.DrawString("0.00", printFontm, Brushes.Black, New RectangleF(40, y, 50, printFontm.Height), form)
            e.Graphics.DrawString("L.", printFontm, Brushes.Black, New RectangleF(85, y, 30, printFontm.Height), form)
            e.Graphics.DrawString("0.00", printFontm, Brushes.Black, New RectangleF(90, y, 60, printFontm.Height), form)
            e.Graphics.DrawString("L.", printFontm, Brushes.Black, New RectangleF(145, y, 30, printFontm.Height), form)
            e.Graphics.DrawString("0.00", printFontm, Brushes.Black, New RectangleF(150, y, 85, printFontm.Height), form)
        End If
        y = y + 10
        e.Graphics.DrawString("Total", printFontm, Brushes.Black, New RectangleF(0, y, 30, printFontm.Height), form)
        e.Graphics.DrawString("L.", printFontm, Brushes.Black, New RectangleF(20, y, 30, printFontm.Height), form)
        e.Graphics.DrawString(CDec(valorsub).ToString("#,##0.00"), printFontm, Brushes.Black, New RectangleF(40, y, 50, printFontm.Height), form)
        e.Graphics.DrawString("L.", printFontm, Brushes.Black, New RectangleF(85, y, 30, printFontm.Height), form)
        e.Graphics.DrawString(CDec(acu18 + acu15).ToString("#,##0.00"), printFontm, Brushes.Black, New RectangleF(90, y, 60, printFontm.Height), form)
        e.Graphics.DrawString("L.", printFontm, Brushes.Black, New RectangleF(145, y, 30, printFontm.Height), form)
        e.Graphics.DrawString(CDec(TotalPago).ToString("#,##0.00"), printFontm, Brushes.Black, New RectangleF(150, y, 85, printFontm.Height), form)


        y = y + 10
        e.Graphics.DrawString("Lotes de venta y #interno: " + id_loteventa.ToString + " #" + numero_factura.ToString, printFont4, Brushes.Black, New RectangleF(5, y, 280, printFont4.Height), formato)
        y = y + 10
        e.Graphics.DrawString("Rango de Correlativo", printFont4, Brushes.Black, New RectangleF(5, y, 280, printFont4.Height), formato)
        y = y + 10
        e.Graphics.DrawString(rgInicio + "/" + rgFinal, printFont4, Brushes.Black, New RectangleF(5, y, 248, printFont4.Height), formato)
        y = y + 10
        e.Graphics.DrawString("¡Gracias por su compra!", printFont4, Brushes.Black, New RectangleF(5, y, 280, printFont4.Height), formato)
        y = y + 10
        e.Graphics.DrawString("Original:Cliente", printFont5, Brushes.Black, 0, y)
        y = y + 10
        e.Graphics.DrawString("Copia: Obligado tributario emisor", printFont5, Brushes.Black, 0, y)
        If (almacen = "Kiosko") Then
            y = y + 10
            e.Graphics.DrawString("KIOSKO", printFont4n, Brushes.Black, New RectangleF(5, y, 280, printFont4.Height), formato)
        End If
        'actualiza los productos con el descuento
        actualizarDescuentoProductos(sessiones.idventa.ToString, descuento)
        My.Forms.frmVenta.cargarListadoEspera()
        Me.Close()
    End Sub

    Private Sub PrintDocument2_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument2.PrintPage
        Dim topMargin As Double = e.MarginBounds.Top
        e.PageSettings.Margins.Left = 1
        e.PageSettings.Margins.Right = 1
        e.PageSettings.Landscape = False
        con.openConection(conexion)
        Dim yPos As Double = 0
        Dim linesPerPage As Double = 0
        Dim count As Integer = 0
        Dim texto As String = ""
        Dim numinterno As Integer = 0
        Dim formato As StringFormat = New StringFormat
        Dim dispon As Decimal = 0
        formato.Alignment = StringAlignment.Center
        formato.LineAlignment = StringAlignment.Center
        Dim form As StringFormat = New StringFormat
        form.Alignment = StringAlignment.Far
        form.LineAlignment = StringAlignment.Far
        Dim printFont As System.Drawing.Font = New Font("Arial", 12)
        Dim printFont2 As System.Drawing.Font = New Font("Arial", 12)
        Dim printFont1 As System.Drawing.Font = New Font("Arial", 8)
        Dim printFont3 As System.Drawing.Font = New Font("Arial", 10)
        Dim printFont4 As System.Drawing.Font = New Font("Arial", 9)
        Dim printFont5 As System.Drawing.Font = New Font("Arial", 9)
        Dim printFont4n As System.Drawing.Font = New Font("Arial", 9, FontStyle.Bold)
        Dim printFontm As System.Drawing.Font = New Font("Arial", 8)
        Dim point1 As New Point(5, 120)
        Dim point2 As New Point(280, 120)
        e.Graphics.DrawLine(Pens.Black, point1, point2)
        e.Graphics.DrawString(NombreSociedad, printFont4, Brushes.Black, New RectangleF(0, 8, 280, printFont4.Height), formato)
        e.Graphics.DrawString(nombrelegal, printFont4, Brushes.Black, New RectangleF(0, 24, 280, printFont4.Height), formato)
        e.Graphics.DrawString("RTN: " + RTN, printFont4, Brushes.Black, New RectangleF(0, 40, 280, printFont4.Height), formato)
        e.Graphics.DrawString("Aldea Agua Dulce, Las Hadas", printFont4, Brushes.Black, New RectangleF(0, 56, 280, printFont4.Height), formato)
        e.Graphics.DrawString("Tegucigalpa, F.M., PBX", printFont4, Brushes.Black, New RectangleF(0, 72, 280, printFont4.Height), formato)
        e.Graphics.DrawString("2234-9595", printFont4, Brushes.Black, New RectangleF(0, 88, 280, printFont4.Height), formato)
        e.Graphics.DrawString(CORREO, printFont4, Brushes.Black, New RectangleF(0, 104, 240, printFont4.Height), formato)
        e.Graphics.DrawString("BOLETA PREVENTA", printFont4n, Brushes.Black, New RectangleF(0, 122, 280, printFont4n.Height), formato)
        Dim point As New Point(5, 139)
        Dim point1t As New Point(280, 139)
        e.Graphics.DrawLine(Pens.Black, point, point1t)
        e.Graphics.DrawString("POS#: " + id_pos.ToString, printFont5, Brushes.Black, 0, 142)
        e.Graphics.DrawString("Cajero: " + usuariotemp, printFont5, Brushes.Black, 100, 142)
        e.Graphics.DrawString("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy"), printFont5, Brushes.Black, 0, 158)
        e.Graphics.DrawString("Hora: " + DateTime.Now.ToString("hh:mm:ss.f"), printFont5, Brushes.Black, 130, 158)
        e.Graphics.DrawString("Número: " + numfact, printFont5, Brushes.Black, 0, 174)
        If (Me.txtNombref.Text <> "" And txtRTN.Text <> "") Then
            e.Graphics.DrawString("RTN: " + Me.txtRTN.Text, printFontm, Brushes.Black, 0, 190)
            e.Graphics.DrawString("NOMBRE: " + Me.txtNombref.Text, printFontm, Brushes.Black, 0, 206)
        Else
            e.Graphics.DrawString("RTN:", printFontm, Brushes.Black, 0, 190)
            e.Graphics.DrawString("NOMBRE: Consumidor final ", printFontm, Brushes.Black, 0, 206)
        End If

        Dim point3 As New Point(5, 223)
        Dim point4 As New Point(280, 223)
        e.Graphics.DrawLine(Pens.Black, point3, point4)
        e.Graphics.DrawString("Cant.", printFont5, Brushes.Black, New RectangleF(5, 226, 30, printFont5.Height), formato)
        e.Graphics.DrawString("Descripcion.", printFont5, Brushes.Black, New RectangleF(40, 226, 120, printFont5.Height), formato)
        e.Graphics.DrawString("Valor.", printFont5, Brushes.Black, New RectangleF(170, 226, 85, printFont5.Height), formato)
        Dim y As Integer = 242
        Dim efect As Decimal = 0
        Dim camb As Decimal = 0
        Dim np As String = sessiones.idventa.ToString
        Dim adaptador As New OdbcDataAdapter("select * from VistaItemsVenta where idventa='" + sessiones.idventa.ToString + "' order by id", conexion)
        Dim data As New DataSet
        Dim cont As Integer = 1
        adaptador.Fill(data, "VistaItemsVenta")
        adaptador.FillSchema(data.Tables("VistaItemsVenta"), SchemaType.Source)
        For Each dr As DataRow In data.Tables("VistaItemsVenta").Rows
            y = y + 16
            numinterno = dr.Item(10).ToString
            e.Graphics.DrawString(dr.Item(6).ToString, printFont5, Brushes.Black, New RectangleF(0, y, 30, printFont5.Height), formato)
            Dim subcadena As String
            If ((dr.Item(5).ToString).Length > 28) Then
                subcadena = (dr.Item(5).ToString).Substring(0, 28)
            Else
                subcadena = (dr.Item(5).ToString)
            End If
            e.Graphics.DrawString(subcadena, printFont1, Brushes.Black, New RectangleF(30, y, 170, printFont5.Height), formato)
            e.Graphics.DrawString("L. " + CDec(dr.Item(2).ToString).ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(190, y, 85, printFont5.Height), form)
        Next
        y = y + 16
        Dim point6 As New Point(5, y)
        Dim point7 As New Point(280, y)
        e.Graphics.DrawLine(Pens.Black, point6, point7)
        y = y + 16
        e.Graphics.DrawString("Sub total:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
        e.Graphics.DrawString(valorsub.ToString("#,##0.00"), printFont4n, Brushes.Black, New RectangleF(140, y, 100, printFont4n.Height), form)
        y = y + 16
        e.Graphics.DrawString("Imp:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
        e.Graphics.DrawString(valorimp.ToString("#,##0.00"), printFont4n, Brushes.Black, New RectangleF(140, y, 100, printFont4n.Height), form)
        y = y + 16
        e.Graphics.DrawString("Total:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
        e.Graphics.DrawString((TotalPago).ToString("#,##0.00"), printFont4n, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)
        'conexion.Close()
        If (cefectivo <> "") Then
            y = y + 16
            e.Graphics.DrawString(cefectivo, printFont5, Brushes.Black, New RectangleF(60, y, 120, printFont5.Height), form)
        End If
        If (ctc <> "") Then
            y = y + 16
            e.Graphics.DrawString(ctc, printFont5, Brushes.Black, New RectangleF(60, y, 120, printFont5.Height), form)
        End If
        If (cpnt <> "") Then
            y = y + 16
            e.Graphics.DrawString(cpnt, printFont5, Brushes.Black, New RectangleF(60, y, 120, printFont5.Height), form)
        End If
        If (ccredito <> "") Then
            y = y + 16
            e.Graphics.DrawString(ccredito, printFont5, Brushes.Black, New RectangleF(60, y, 120, printFont5.Height), form)
        End If
        If (cwildcart <> "") Then
            y = y + 16
            e.Graphics.DrawString(cwildcart, printFont5, Brushes.Black, New RectangleF(60, y, 120, printFont5.Height), form)
        End If
        If (cefdolar <> "") Then
            y = y + 16
            e.Graphics.DrawString(cefdolar, printFont5, Brushes.Black, New RectangleF(60, y, 120, printFont5.Height), form)
        End If
        If (ccafegr <> "") Then
            y = y + 16
            e.Graphics.DrawString(ccafegr, printFont5, Brushes.Black, New RectangleF(60, y, 120, printFont5.Height), form)
        End If
        If (ccarnet <> "") Then
            y = y + 16
            e.Graphics.DrawString(ccarnet, printFont5, Brushes.Black, New RectangleF(60, y, 120, printFont5.Height), form)
        End If
        y = y + 16
        e.Graphics.DrawString("Cambio:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
        e.Graphics.DrawString("L. " + cambiopago.ToString("#,##0.00"), printFont4n, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)
        comando = New Odbc.OdbcCommand("UPDATE public.tbl_pos_venta   SET  estado=0, cambio='" + totalpro.ToString + "' WHERE id= '" + idventa.ToString + "'", conexion)
        comando.ExecuteNonQuery()
        y = y + 16
        e.Graphics.DrawString("Preventa pagado: " + (CInt(totalpreventa)).ToString("#,##0.00"), printFont4n, Brushes.Black, 0, y)
        y = y + 16
        e.Graphics.DrawString("Saldo preventa: " + (CInt(TotalPago) - CInt(totalpreventa)).ToString("#,##0.00"), printFont4n, Brushes.Black, 0, y)
        y = y + 16
        Dim point8 As New Point(5, y)
        Dim point9 As New Point(280, y)
        e.Graphics.DrawLine(Pens.Black, point8, point9)
        y = y + 16
        e.Graphics.DrawString("Lotes de venta y #interno: " + id_loteventa.ToString + " #" + numfact.ToString, printFont4, Brushes.Black, New RectangleF(5, y, 280, printFont4.Height), formato)
        y = y + 16
        e.Graphics.DrawString("¡Gracias por su compra!", printFont4, Brushes.Black, New RectangleF(5, y, 280, printFont4.Height), formato)
        comando = New Odbc.OdbcCommand("UPDATE public.tbl_pos_venta  SET estado=2 WHERE id='" + idventa.ToString + "'", conexion)
        comando.ExecuteNonQuery()
        My.Forms.frmVenta.btncancela.Enabled = False
        My.Forms.frmVenta.btnespera.Enabled = False
        My.Forms.frmVenta.btnpago.Enabled = False
        My.Forms.frmVenta.Button4.Enabled = True
        My.Forms.frmVenta.txtCodigo.Text = ""
        My.Forms.frmVenta.txtCodigo.Enabled = False
        My.Forms.frmVenta.DataGridView1.Rows.Clear()
        My.Forms.frmVenta.lblSub.Text = "L. 0.00"
        My.Forms.frmVenta.lbltotal.Text = "L. 0.00"
        My.Forms.frmVenta.lblimp.Text = "L. 0.00"
        My.Forms.frmVenta.btn_reimprimir.Enabled = True
        valorsub = 0
        valorimp = 0
        TotalPago = 0
        idventa = 0
        tipoventa = 0
        totalpro = 0
        My.Forms.frmVenta.lblnombrecliente.Text = ""
        My.Forms.frmVenta.cmbTipo.SelectedValue = 5
        My.Forms.frmVenta.txtcod.Text = ""
        Me.Close()
    End Sub

    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs)
        Select Case e.KeyData
            Case Keys.Enter
        End Select

    End Sub

    Public Sub solonumeros(ByRef e As System.Windows.Forms.KeyPressEventArgs)

        Select Case e.KeyChar
            Case "."
                e.Handled = False
            Case "0"
                e.Handled = False
            Case "1"
                e.Handled = False

            Case "2"
                e.Handled = False

            Case "3"
                e.Handled = False

            Case "4"
                e.Handled = False

            Case "5"
                e.Handled = False

            Case "6"
                e.Handled = False

            Case "7"
                e.Handled = False

            Case "8"
                e.Handled = False

            Case "9"
                e.Handled = False
            Case Convert.ToChar(Keys.Back)
                e.Handled = False
            Case Else
                e.Handled = True

        End Select

    End Sub

    Private Sub txtefectivo_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtefectivo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtefectivo.KeyDown
        If e.KeyCode = Keys.Space Then
            Me.txtefectivo.Text = CInt(TotalPago).ToString
        End If
    End Sub

    Private Sub frmMetodoPago_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        con.openConection(conexion)
        If e.KeyCode = Keys.F1 Then
            Button2.PerformClick()
        End If
        If e.KeyCode = Keys.F2 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmMetodoPago_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If Activacafe = 1 Then
            Me.txtcafe.Enabled = True
            txtcafe.Select()
            txtcafe.Focus()
            txtcafe.Text = vtotalapagar().ToString
            'cad = "SELECT id, tipo FROM tbl_pos_metodospago where tipo = 'Cafe Gratis'"
        ElseIf empleadoventa = "no" Then
            txtefectivo.Select()
            txtefectivo.Focus()
        Else
            txtCredito.Focus()
            'cad = "SELECT id, tipo FROM tbl_pos_metodospago where tipo <> 'Cafe Gratis'"
        End If
    End Sub

    Private Sub txtefectivo_KeyPress(sender As Object, e As KeyPressEventArgs)
        solonumeros(e)
    End Sub

    Private Sub txttc_KeyPress(sender As Object, e As KeyPressEventArgs)
        solonumeros(e)
    End Sub

    Private Sub txtpuntos_KeyPress(sender As Object, e As KeyPressEventArgs)
        solonumeros(e)
    End Sub

    Private Sub txtCredito_KeyPress(sender As Object, e As KeyPressEventArgs)
        solonumeros(e)
    End Sub

    Private Sub txtwildcart_KeyPress(sender As Object, e As KeyPressEventArgs)
        solonumeros(e)
    End Sub

    Private Sub txtdolar_KeyPress(sender As Object, e As KeyPressEventArgs)
        solonumeros(e)
    End Sub

    Private Sub txtCafe_KeyPress(sender As Object, e As KeyPressEventArgs)
        solonumeros(e)
    End Sub

    Private Sub txtcarnet_KeyPress(sender As Object, e As KeyPressEventArgs)
        solonumeros(e)
    End Sub

    Private Sub txtdolar_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txttc_Focus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttc.Enter
        'My.Forms.frmtarjetacard.pgconection = conexion
        ''txttc.Text = vtotalapagar - Convert.ToInt32(txtefectivo.Text)
        'If (txttc.Text = "") Then
        '    Dim txefectivo As Decimal = If(txtefectivo.Text <> "", Convert.ToDouble(txtefectivo.Text), 0)
        '    Dim txtarj As Decimal = If(txttc.Text <> "", Convert.ToDouble(txttc.Text), 0)
        '    Dim txpunt As Decimal = If(txtpuntos.Text <> "", Convert.ToDouble(txtpuntos.Text), 0)
        '    Dim txwild As Decimal = If(txtwildcart.Text <> "", Convert.ToDouble(txtwildcart.Text), 0)
        '    Dim txdol As Decimal = If(txtdolar.Text <> "", Convert.ToDouble(txtdolar.Text), 0)
        '    Dim txcarne As Decimal = If(txtcarnet.Text <> "", Convert.ToDouble(txtcarnet.Text), 0)

        '    Dim totalingresado = vtotalapagar() - txefectivo - txpunt - txwild - txdol - txcarne
        '    If totalingresado > 0 Then
        '        txttc.Text = totalingresado
        '        My.Forms.frmtarjetacard.ShowDialog()
        '    Else
        '        txttc.Text = 0
        '    End If
        'End If

            suma()
    End Sub

    Private Sub txtdolar_LostFocus(sender As Object, e As EventArgs) Handles txtdolar.LostFocus
        Dim dolar As Double = If(txtdolar.Text <> "", Convert.ToDouble(txtdolar.Text), 0)
        Dim total As Double = Convert.ToDouble(dolar * tasa)
        txtdolar.Text = If(total <> 0, dolar * tasa, "")
        lbldolares.Text = "Dolares: $" + dolar.ToString
        'Dim valoringresado As Decimal = CDbl(Val(Me.txtdolar.Text))
        'If (valoringresado > 0) Then
        '    dolares = valoringresado
        '    lbldolares.Text = "$ Dolares" + valoringresado.ToString("###0.00")
        '    Dim valoringresadot As Decimal = tasa * valoringresado
        '    Me.txtdolar.Text = valoringresadot
        '    disponible = disponible - valoringresadot
        '    totalpro = TotalPago - valoringresadot
        '    Me.lblefectivoregreso.Text = "L." + valoringresadot.ToString("#,##0.00")
        '    If totalpro < 0 Then
        '        totalpro = totalpro * -1
        '        Thread.CurrentThread.CurrentCulture = New CultureInfo("es-HN")
        '        Me.lblcambiomoney.Text = "L." + totalpro.ToString("#,##0.00")
        '    End If
        '    suma()
        'End If
    End Sub

    Private Function guardar(sender As Object, e As KeyPressEventArgs)

        If e.KeyChar = Chr(Keys.Enter) Then
            'Button2.PerformClick()
        End If
    End Function

    Private Sub txtwildcart_KeyPress_1(sender As Object, e As KeyPressEventArgs)
        guardar(sender, e)
    End Sub

    Private Sub txtefectivo_TextChanged_1(sender As Object, e As EventArgs) Handles txtefectivo.TextChanged
        suma()
    End Sub

    Private Sub txttc_TextChanged(sender As Object, e As EventArgs) Handles txttc.TextChanged
        suma()
        If txttc.Text <> "" Then
            ingresarTarjeta = True
        End If
    End Sub

    Private Sub txtpuntos_TextChanged(sender As Object, e As EventArgs) Handles txtpuntos.TextChanged
        suma()
    End Sub

    Private Sub txtCredito_TextChanged(sender As Object, e As EventArgs) Handles txtCredito.TextChanged
        suma()
        'Dim totcredito As Decimal = If(txtCredito.Text <> "", txtCredito.Text, 0)
        'Dim descuentoreal As Decimal = totcredito * (descuento / 100)
        'descuentoacobrar = descuentoreal
        'lblDescuento.Text = "Descuento: " + (descuentoreal).ToString
        'lbltotalpagar.Text = "L." + (vtotalapagar - descuentoreal).ToString
        'Dim a As Decimal = (totcredito - descuentoreal)
        'lblpagocreditototal.Text = "Pago credito total: L." + a.ToString
    End Sub

    Private Sub txtwildcart_TextChanged(sender As Object, e As EventArgs) Handles txtwildcart.TextChanged
        suma()
    End Sub

    Private Sub txtdolar_TextChanged_1(sender As Object, e As EventArgs) Handles txtdolar.TextChanged
        suma()
    End Sub

    Private Sub txtcarnet_TextChanged(sender As Object, e As EventArgs) Handles txtcarnet.TextChanged
        suma()
    End Sub

    Private Function suma()
        efe = If(txtefectivo.Text <> "", obtenerValor(txtefectivo.Text), 0)
        tarj = If(txttc.Text <> "", obtenerValor(txttc.Text), 0)
        punt = If(txtpuntos.Text <> "", obtenerValor(txtpuntos.Text), 0)
        wild = If(txtwildcart.Text <> "", obtenerValor(txtwildcart.Text), 0)
        dol = If(txtdolar.Text <> "", obtenerValor(txtdolar.Text), 0)
        carne = If(txtcarnet.Text <> "", obtenerValor(txtcarnet.Text), 0)
        cred = If(txtCredito.Text <> "", obtenerValor(txtCredito.Text), 0)

        Dim cambio As Decimal=0

        If empleadoventa = "no" Then
            cambio = CInt(efe + tarj + punt + wild + dol + carne) - CInt(vtotalapagar - anticipo_preventa)
            lblefectivoregreso.Text = "L." + (efe + tarj + punt + wild + dol + carne).ToString
            If cambio >= 0 Then
                lblcambiomoney.ForeColor = Color.Green
                lblcambiomoney.Text = "L." + cambio.ToString("#,##0.00")
                cambiopago = cambio
            Else
                lblcambiomoney.ForeColor = Color.Red
                lblcambiomoney.Text = "L." + cambio.ToString("#,##0.00")

            End If

        Else

            cambio = Convert.ToDecimal(Convert.ToDecimal(cred) - Convert.ToDecimal((totalnuevafactura - anticipo_preventa).ToString("#,##0.00")))
            lblefectivoregreso.Text = "L." + (cred).ToString("#,##0.00")
            If cambio >= 0 Then
                lblcambiomoney.ForeColor = Color.Lime
                lblcambiomoney.Text = "L." + cambio.ToString("#,##0.00")
                cambiopago = cambio
            Else
                lblcambiomoney.ForeColor = Color.Red
                lblcambiomoney.Text = "L." + cambio.ToString("#,##0.00")
            End If
        End If
    End Function

    'Private Sub txtefectivo_Enter(sender As Object, e As EventArgs) Handles txtefectivo.Enter
    '    If (txtefectivo.Text = "") Then
    '        Dim txefectivo As Decimal = If(txtefectivo.Text <> "", Convert.ToDouble(txtefectivo.Text), 0)
    '        Dim txtarj As Decimal = If(txttc.Text <> "", Convert.ToDouble(txttc.Text), 0)
    '        Dim txpunt As Decimal = If(txtpuntos.Text <> "", Convert.ToDouble(txtpuntos.Text), 0)
    '        Dim txwild As Decimal = If(txtwildcart.Text <> "", Convert.ToDouble(txtwildcart.Text), 0)
    '        Dim txdol As Decimal = If(txtdolar.Text <> "", Convert.ToDouble(txtdolar.Text), 0)
    '        Dim txcarne As Decimal = If(txtcarnet.Text <> "", Convert.ToDouble(txtcarnet.Text), 0)

    '        Dim totalingresado = vtotalapagar() - txtarj - txpunt - txwild - txdol - txcarne
    '        If totalingresado > 0 Then
    '            txtefectivo.Text = totalingresado
    '        Else
    '            txtefectivo.Text = 0
    '        End If
    '    End If
    'End Sub

    'Private Sub txtpuntos_Enter(sender As Object, e As EventArgs) Handles txtpuntos.Enter
    '    If txtpuntos.Text = "" Then
    '        Dim txefectivo As Decimal = If(txtefectivo.Text <> "", Convert.ToDouble(txtefectivo.Text), 0)
    '        Dim txtarj As Decimal = If(txttc.Text <> "", Convert.ToDouble(txttc.Text), 0)
    '        Dim txpunt As Decimal = If(txtpuntos.Text <> "", Convert.ToDouble(txtpuntos.Text), 0)
    '        Dim txwild As Decimal = If(txtwildcart.Text <> "", Convert.ToDouble(txtwildcart.Text), 0)
    '        Dim txdol As Decimal = If(txtdolar.Text <> "", Convert.ToDouble(txtdolar.Text), 0)
    '        Dim txcarne As Decimal = If(txtcarnet.Text <> "", Convert.ToDouble(txtcarnet.Text), 0)

    '        Dim totalingresado = vtotalapagar() - txefectivo - txtarj - txwild - txdol - txcarne
    '        If totalingresado > 0 Then
    '            txtpuntos.Text = totalingresado
    '        Else
    '            txtpuntos.Text = 0
    '        End If
    '    End If

    'End Sub

    'Private Sub txtCredito_Enter(sender As Object, e As EventArgs) Handles txtCredito.Enter
    '    If txtCredito.Text = "" Then
    '        Dim txefectivo As Decimal = If(txtefectivo.Text <> "", Convert.ToDouble(txtefectivo.Text), 0)
    '        Dim txtarj As Decimal = If(txttc.Text <> "", Convert.ToDouble(txttc.Text), 0)
    '        Dim txpunt As Decimal = If(txtpuntos.Text <> "", Convert.ToDouble(txtpuntos.Text), 0)
    '        Dim txwild As Decimal = If(txtwildcart.Text <> "", Convert.ToDouble(txtwildcart.Text), 0)
    '        Dim txdol As Decimal = If(txtdolar.Text <> "", Convert.ToDouble(txtdolar.Text), 0)
    '        Dim txcarne As Decimal = If(txtcarnet.Text <> "", Convert.ToDouble(txtcarnet.Text), 0)

    '        Dim totalingresado = vtotalapagar() - txefectivo - txpunt - txwild - txdol - txcarne
    '        If totalingresado > 0 Then
    '            txtCredito.Text = totalingresado
    '        Else
    '            txtCredito.Text = 0
    '        End If
    '    End If
    'End Sub

    'Private Sub txtwildcart_Enter(sender As Object, e As EventArgs) Handles txtwildcart.Enter
    '   If txtwildcart.Text = "" Then
    '        Dim txefectivo As Decimal = If(txtefectivo.Text <> "", Convert.ToDouble(txtefectivo.Text), 0)
    '        Dim txtarj As Decimal = If(txttc.Text <> "", Convert.ToDouble(txttc.Text), 0)
    '        Dim txpunt As Decimal = If(txtpuntos.Text <> "", Convert.ToDouble(txtpuntos.Text), 0)
    '        Dim txwild As Decimal = If(txtwildcart.Text <> "", Convert.ToDouble(txtwildcart.Text), 0)
    '        Dim txdol As Decimal = If(txtdolar.Text <> "", Convert.ToDouble(txtdolar.Text), 0)
    '        Dim txcarne As Decimal = If(txtcarnet.Text <> "", Convert.ToDouble(txtcarnet.Text), 0)

    '        Dim totalingresado = vtotalapagar() - txefectivo - txtarj - txpunt - txdol - txcarne
    '        If totalingresado > 0 Then
    '            txtwildcart.Text = totalingresado
    '        Else
    '            txtwildcart.Text = 0
    '        End If
    '    End If

    'End Sub

    'Private Sub txtdolar_Enter(sender As Object, e As EventArgs) Handles txtdolar.Enter
    '    If txtdolar.Text = "" Then
    '        Dim txefectivo As Decimal = If(txtefectivo.Text <> "", Convert.ToDouble(txtefectivo.Text), 0)
    '        Dim txtarj As Decimal = If(txttc.Text <> "", Convert.ToDouble(txttc.Text), 0)
    '        Dim txpunt As Decimal = If(txtpuntos.Text <> "", Convert.ToDouble(txtpuntos.Text), 0)
    '        Dim txwild As Decimal = If(txtwildcart.Text <> "", Convert.ToDouble(txtwildcart.Text), 0)
    '        Dim txdol As Decimal = If(txtdolar.Text <> "", Convert.ToDouble(txtdolar.Text), 0)
    '        Dim txcarne As Decimal = If(txtcarnet.Text <> "", Convert.ToDouble(txtcarnet.Text), 0)

    '        Dim totalingresado = vtotalapagar() - txefectivo - txtarj - txpunt - txwild - txcarne
    '        If totalingresado > 0 Then
    '            txtdolar.Text = totalingresado
    '        Else
    '            txtdolar.Text = 0
    '        End If
    '    End If
    'End Sub

    'Private Sub txtcarnet_Enter(sender As Object, e As EventArgs) Handles txtcarnet.Enter
    '    If txtcarnet.Text = "" Then
    '        Dim txefectivo As Decimal = If(txtefectivo.Text <> "", Convert.ToDouble(txtefectivo.Text), 0)
    '        Dim txtarj As Decimal = If(txttc.Text <> "", Convert.ToDouble(txttc.Text), 0)
    '        Dim txpunt As Decimal = If(txtpuntos.Text <> "", Convert.ToDouble(txtpuntos.Text), 0)
    '        Dim txwild As Decimal = If(txtwildcart.Text <> "", Convert.ToDouble(txtwildcart.Text), 0)
    '        Dim txdol As Decimal = If(txtdolar.Text <> "", Convert.ToDouble(txtdolar.Text), 0)
    '        Dim txcarne As Decimal = If(txtcarnet.Text <> "", Convert.ToDouble(txtcarnet.Text), 0)

    '        Dim totalingresado = vtotalapagar() - txefectivo - txtarj - txpunt - txwild - txdol
    '        If totalingresado > 0 Then
    '            txtcarnet.Text = totalingresado
    '    Else
    '        txtcarnet.Text = 0
    '    End If
    '    End If
    'End Sub

    Private Function obtenerValor(valor As String)
        Try
            Convert.ToDouble(valor.ToString)

            Return Convert.ToDouble(valor.ToString)

        Catch ex As Exception
            MessageBox.Show("Caracter no reconocido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0
        End Try
    End Function

    Private Sub txttc_KeyDown(sender As Object, e As KeyEventArgs) Handles txttc.KeyDown
        If e.KeyCode = Keys.Enter Then
            My.Forms.frmtarjetacard.pgconection = conexion
            My.Forms.frmtarjetacard.Tipo_pago_tarjeta = "factura"
            My.Forms.frmtarjetacard.ShowDialog()
        End If
    End Sub

    Private Function recalcularValores()
        Dim adaptador As New OdbcDataAdapter("select * from VistaItemsVenta where idventa='" + sessiones.idventa.ToString + "' order by id", conexion)
        Dim data As New DataSet
        Dim cont As Integer = 1
        adaptador.Fill(data, "VistaItemsVenta")
        adaptador.FillSchema(data.Tables("VistaItemsVenta"), SchemaType.Source)

        subtotalnuevafactura = 0
        isv15nuevafactura = 0
        isv18nuevafactura = 0
        subtotalnuevafacturasin15 = 0
        subtotalnuevafacturasin18 = 0
        subtotalnuevafacturasin0 = 0
        descuentonuevafactura = 0

        Dim totalfactura As Decimal = 0

        For Each dr As DataRow In data.Tables("VistaItemsVenta").Rows

            Dim valor_isv As Integer = Convert.ToInt32(dr(14).ToString)

            If valor_isv = 0 Then
                subtotalnuevafacturasin0 = subtotalnuevafacturasin0 + ((CDec(dr.Item(2).ToString)) * (dr.Item(6).ToString))

            ElseIf valor_isv = 15 Then
                Dim a As Decimal = ((Val(dr.Item(2).ToString)) * (dr.Item(6).ToString))

                subtotalnuevafacturasin15 = subtotalnuevafacturasin15 + a

                isv15nuevafactura = isv15nuevafactura + CDec((a - Val(a * descuento / 100)) * Val(valor_isv / 100))

            Else
                Dim b As Decimal = ((Val(dr.Item(2).ToString)) * (dr.Item(6).ToString))

                subtotalnuevafacturasin18 = subtotalnuevafacturasin18 + b

                isv18nuevafactura = isv18nuevafactura + CDec((b - Val(b * descuento / 100)) * Val(valor_isv / 100))
            End If

        Next

        subtotalnuevafactura = (subtotalnuevafacturasin0 + subtotalnuevafacturasin15 + subtotalnuevafacturasin18)

        descuentonuevafactura = CDec(subtotalnuevafactura * descuento / 100)

        lblDescuento.Text = "Descuento: L." + descuentonuevafactura.ToString("#,##0.00")

        lblsubtotalcondescuento.Text = "Sub Total: L." + (subtotalnuevafactura).ToString("#,##0.00")

        impuestonuevafactura = (isv15nuevafactura + isv18nuevafactura)

        lblisvcondescuento.Text = "ISV: L." + (impuestonuevafactura).ToString("#,##0.00")

        lbltotalcondescuento.Text = "Total: L." + ((subtotalnuevafactura - descuentonuevafactura) + (impuestonuevafactura)).ToString("#,##0.00")




        totalnuevafactura = ((subtotalnuevafactura - descuentonuevafactura) + (impuestonuevafactura))

        If descuento = 0 Then
            totalnuevafactura = CDec(totalnuevafactura)

            txtCredito.Text =(totalnuevafactura - anticipo_preventa).ToString("#,##0.00")

            vtotalapagar() = (totalnuevafactura).ToString("#,##0.00")
        Else
            txtCredito.Text = (totalnuevafactura - anticipo_preventa).ToString("#,##0.00")

            vtotalapagar() = (totalnuevafactura).ToString("#,##0.00")
        End If

        lbltotalpagar.Text = "L." + (totalnuevafactura).ToString("#,##0.00")

        'txtCredito.Text = CDec(totalnuevafactura - anticipo_preventa).ToString("#,##0.00")

        'vtotalapagar() = CDec(totalnuevafactura).ToString("#,##0.00")

        suma()

    End Function

    Private Sub txtcarnet_KeyDown(sender As Object, e As KeyEventArgs) Handles txtcarnet.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim fcarnet As New frm_Carnet
            fcarnet.pgconection = conexion
            fcarnet.ShowDialog()
        End If
    End Sub

    Private Sub txttc_Leave(sender As Object, e As EventArgs) Handles txttc.Leave
        If ingresarTarjeta And txttc.Text <> "" Then
            MessageBox.Show("Debe ingresar datos de la tarjeta, presione Enter para agregar datos de la tarjeta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txttc.Focus()
        End If
    End Sub

    Function actualizarDescuentoProductos(idventa As String, descuentoN As Integer)
        Dim sqlactualizaproductos As String = "SELECT public.fn_actualiza_precio_producto_descuento('" + idventa + "'," + descuentoN.ToString + ");"
        comando = New OdbcCommand(sqlactualizaproductos, conexion)
        LECTOR = comando.ExecuteReader()
        If LECTOR.HasRows Then
            Dim a As String = LECTOR(0).ToString
        End If
    End Function


    Public Function cargarMetodosPagoRecibo()

        Dim id_recibo = CInt(My.Forms.frmVenta.id_recibo_preventa)
        Dim sqlmetodospago = "SELECT id_metodo_pago,monto,dolares FROM public.tbl_recibo_preventa_metodospago WHERE id_recibo=" + id_recibo.ToString + ";"
        comando = New OdbcCommand(sqlmetodospago, conexion)
        LECTOR = comando.ExecuteReader
        Dim efectivo As Decimal = 0
        Dim puntos As Decimal = 0
        Dim credito_empleado As Decimal = 0
        Dim tarjeta_credito As Decimal = 0
        Dim cambio_prev As Decimal = 0

        While LECTOR.Read
            If CInt(LECTOR(0)) = metodospago.efectivo Then
                efectivo = CDec(LECTOR(1))
            End If

            If CInt(LECTOR(0)) = metodospago.tarjeta Then
                tarjeta_credito = CDec(LECTOR(1))
            End If

            If CInt(LECTOR(0)) = metodospago.puntos Then
                puntos = CDec(LECTOR(1))
            End If

            If CInt(LECTOR(0)) = metodospago.creditoempleado Then
                credito_empleado = CDec(LECTOR(1))
            End If

            If CInt(LECTOR(0) = metodospago.Cambio) Then
                cambio_prev = CDec(LECTOR(1))
            End If
        End While

        Dim monto_preventa As Decimal = efectivo + tarjeta_credito + puntos + credito_empleado - cambio_prev

        lblpreventamonto.Text = "L." + CInt(monto_preventa).ToString("#,##0.00")

        If empleadoventa = "no" Then
            'totalapagar = totalapagar - monto_preventa
            anticipo_preventa = CInt(monto_preventa)
        Else
            anticipo_preventa = CDec(monto_preventa)
            'totalnuevafactura = totalnuevafactura - monto_preventa
        End If
        'TotalPago = TotalPago - monto_preventa
        lbltotalpagar.Text = "L. " + (TotalPago - anticipo_preventa).ToString("#,##0.00")
    End Function

    Private Sub txtcarnet_Leave(sender As Object, e As EventArgs) Handles txtcarnet.Leave
        If txtcarnet.Text <> "" Then
            If codigoCarnet = "" Then
                MessageBox.Show("Debe ingresar un numero de carnet.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Button2.Enabled = False
                txtcarnet.Focus()
            Else
                Button2.Enabled = True
            End If
        Else
            codigoCarnet = ""
            Button2.Enabled = True
        End If
    End Sub
End Class