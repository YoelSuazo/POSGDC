Imports System.Data.Odbc
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Data
Imports System.Globalization
Imports System.Threading
Imports System.Drawing
Imports System
Imports POSGDC.conexion
Imports System.Drawing.Printing

Public Class imprimir

    Dim con As New conexion
    Dim conexion As New Odbc.OdbcConnection()
    Dim CAI As String = ""
    Dim rgInicio As String = ""
    Dim rgFinal As String = ""
    Dim ids As String = ""
    Dim CORREO As String = ""
    Dim NombreSociedad As String = ""
    Dim nombrelegal As String = ""
    Dim fechalimite As String = ""
    Dim RTN As String = ""
    Dim LECTOR As OdbcDataReader
    Dim reimprime As String = "n"
    Friend WithEvents Pd As New PrintDocument
    Friend WithEvents pd_recibo As PrintDocument
    Dim facturaanterior As String = ""
    Dim facturaOriginal As String = ""
    Dim loteventas As Integer
    Dim tasa As Decimal
    Dim idrecibo As Integer


    'solo cuando la factura es al credito se usan estas variables
    Dim subtotalnuevafactura As Decimal = 0
    Dim totalnuevafactura As Decimal = 0
    Dim descuentonuevafactura As Decimal = 0
    Dim impuestonuevafactura As Decimal = 0
    Dim subtotalnuevafacturasin15 As Decimal = 0
    Dim subtotalnuevafacturasin18 As Decimal = 0
    Dim subtotalnuevafacturasin0 As Decimal = 0
    Dim isv15nuevafactura As Decimal = 0
    Dim isv18nuevafactura As Decimal = 0
    Dim descuento As Decimal = 0
    Dim saldoacumulado As Decimal = 0
    Dim EsCodigo As String = "si"
    Dim es_preventa As String = "no"


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

    Public Function ImprimirFactura(r As String, cone As OdbcConnection, idfactura As String, loteventa As Integer)
        reimprime = r
        pgconection = cone
        facturaanterior = idfactura
        loteventas = loteventa

        Try
            Pd.Print()
        Catch ex As Exception
            Dim re As DialogResult = MessageBox.Show("Ocurrio un error al imprimir, desea probar de nuevo?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)

            If DialogResult.Yes = re Then
                Pd.Print()
            End If

        End Try

    End Function

    Public Function ImprimirRecibo(cone As OdbcConnection, idfactura As String, loteventa As Integer, ventemp As String, id_recibo As Integer)
        pgconection = cone
        reimprime = ventemp
        facturaanterior = idfactura
        loteventas = loteventa
        idrecibo = id_recibo
        pd_recibo = New PrintDocument
        Try
            pd_recibo.Print()
        Catch ex As Exception
            Dim r As DialogResult = MessageBox.Show("Ocurrio un error al imprimir, desea probar de nuevo?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)

            If DialogResult.Yes = r Then
                pd_recibo.Print()
            End If

        End Try

    End Function

    Private Sub Pd_PrintPage(sender As Object, e As PrintPageEventArgs) Handles Pd.PrintPage
        comando = New OdbcCommand("select  * from tbl_cambioactual", conexion)
        LECTOR = comando.ExecuteReader
        If LECTOR.Read Then
            tasa = CDbl(LECTOR(1).ToString)
        End If

        comando = New OdbcCommand("select * from datosfacturaPOS where id='" + sessiones.id_pos.ToString + "'", conexion)
        LECTOR = comando.ExecuteReader
        If LECTOR.Read Then ' lee la consulta
            CAI = LECTOR(3).ToString
            rgInicio = LECTOR(7).ToString
            rgFinal = LECTOR(8).ToString
            Dim ids As String = LECTOR(12).ToString
            CORREO = LECTOR(11).ToString
            NombreSociedad = LECTOR(15).ToString
            nombrelegal = LECTOR(16).ToString
            fechalimite = LECTOR(17).ToString
            RTN = LECTOR(13).ToString
        End If

        Dim lblNumerofactura As String = ""
        Dim lblfecha As String = ""
        Dim lblestado As String = ""
        Dim lblRTN As String = ""
        Dim lblnombrecliente2 As String = ""
        Dim lblrango As String = ""
        Dim lblnumventa As String = ""
        Dim lbllote As String = ""
        Dim lblinterno As String = ""
        Dim lblcajero As String = ""
        Dim lblSub As String = ""
        Dim lbldesc As String = ""
        Dim lblimp As String = ""
        Dim horai As String = ""
        Dim fechai As String = ""
        Dim lbltotal As String = ""
        Dim tot As Decimal
        Dim idfactura As Integer
        Dim llevacambio As Integer = -1
        Dim nombrecliente As String = ""
        subtotalnuevafactura = 0
        isv15nuevafactura = 0
        isv18nuevafactura = 0
        subtotalnuevafacturasin15 = 0
        subtotalnuevafacturasin18 = 0
        subtotalnuevafacturasin0 = 0
        descuentonuevafactura = 0

        Dim sql1 As String = "SELECT cast(id as text),nombrecliente FROM vistafacturasventa WHERE id_venta=" + facturaanterior.ToString + " and idalmacen='" + id_almacen.ToString + "' and id_usuario=" + id_usuario.ToString + ";"
        comando = New OdbcCommand(sql1, conexion)
        LECTOR = comando.ExecuteReader
        If LECTOR.Read Then
            idfactura = LECTOR(0).ToString
            nombrecliente = LECTOR(1).ToString
        End If

        Dim sqldatosfactura As String = "SELECT numfactura, COALESCE(descuentototal,0), valortotal, CASE WHEN estado=1 THEN 'Activa' WHEN estado=2 THEN 'Pendiente Anulación' ELSE 'Anulada'  END, COALESCE(to_char(fecha, 'DD/MM/YYYY hh:mm:ss'), '') AS ff, cai, rtn, nombrecliente, rangocorrelativo, cajero, rginicial, rgfinal, COALESCE(subtotal,0) ,COALESCE(total_impuesto,0), COALESCE(to_char(hora, 'HH:MI'), '') AS hh, COALESCE(to_char(fecha, 'DD/MM/YYYY'), '') AS fechaaa FROM public.tbl_facturaventa where id='" + idfactura.ToString + "';"
        comando = New OdbcCommand(sqldatosfactura, conexion)
        LECTOR = comando.ExecuteReader
        If LECTOR.Read Then
            lblNumerofactura = LECTOR(0).ToString()
            lblfecha = LECTOR(4).ToString()
            lblestado = LECTOR(3).ToString()
            lblRTN = LECTOR(6).ToString()
            lblnombrecliente2 = LECTOR(7).ToString()
            lblrango = LECTOR(8).ToString()
            lblnumventa = numeroventa.ToString
            lbllote = numeroLOTEventa.ToString
            lblinterno = idfactura.ToString
            lblcajero = LECTOR(9).ToString()
            lblSub = CDec(LECTOR(12).ToString()).ToString("#,##0.00")
            lbldesc = CDec(LECTOR(1).ToString()).ToString("#,##0.00")
            lblimp = CDec(LECTOR(13).ToString()).ToString("#,##0.00")
            horai = LECTOR(14).ToString()
            fechai = LECTOR(15).ToString()
            lbltotal = (CDec(LECTOR(2).ToString())).ToString("#,##0.00")
            tot = (CDec(LECTOR(2).ToString()))
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
        Dim point1 As New Point(5, 137)
        Dim point2 As New Point(280, 137)
        e.Graphics.DrawLine(Pens.Black, point1, point2)
        If reimprime = "s" Then
            e.Graphics.DrawString("Reimpresion", printFont, Brushes.Black, New RectangleF(0, 3, 280, printFont.Height), formato)
        End If
        e.Graphics.DrawString(NombreSociedad, printFont4, Brushes.Black, New RectangleF(0, 24, 280, printFont4.Height), formato)
        e.Graphics.DrawString(nombrelegal, printFont4, Brushes.Black, New RectangleF(0, 40, 280, printFont4.Height), formato)
        e.Graphics.DrawString("RTN: " + RTN, printFont4, Brushes.Black, New RectangleF(0, 56, 280, printFont4.Height), formato)
        e.Graphics.DrawString("Aldea Agua Dulce, Las Hadas", printFont4, Brushes.Black, New RectangleF(0, 72, 280, printFont4.Height), formato)
        e.Graphics.DrawString("Tegucigalpa, F.M., PBX", printFont4, Brushes.Black, New RectangleF(0, 88, 280, printFont4.Height), formato)
        e.Graphics.DrawString("2234-9595", printFont4, Brushes.Black, New RectangleF(0, 104, 280, printFont4.Height), formato)
        e.Graphics.DrawString(CORREO, printFont4, Brushes.Black, New RectangleF(0, 122, 280, printFont4.Height), formato)
        Dim point As New Point(5, 155)
        Dim point1t As New Point(280, 155)
        e.Graphics.DrawLine(Pens.Black, point, point1t)

        e.Graphics.DrawString("FACTURA", printFont4n, Brushes.Black, New RectangleF(0, 139, 280, printFont4n.Height), formato)

        e.Graphics.DrawString("POS#: " + id_pos.ToString, printFont3, Brushes.Black, 0, 158)
        e.Graphics.DrawString("Cajero: " + lblcajero, printFont3, Brushes.Black, 100, 158)
        e.Graphics.DrawString("Fecha: " + fechai, printFont3, Brushes.Black, 0, 174)
        e.Graphics.DrawString("Hora: " + horai, printFont3, Brushes.Black, 160, 174)
        e.Graphics.DrawString("CORRELATIVO: " + lblNumerofactura, printFont3, Brushes.Black, 0, 190)
        e.Graphics.DrawString("CAI: " + CAI, printFont4, Brushes.Black, 0, 206)
        e.Graphics.DrawString("FECHA LIMITE EMISION: " + fechalimite, printFont5, Brushes.Black, 0, 222)
        e.Graphics.DrawString("DESDE: " + rgInicio, printFont5, Brushes.Black, 0, 238)
        e.Graphics.DrawString("HASTA: " + rgFinal, printFont5, Brushes.Black, 135, 238)
        e.Graphics.DrawString("RTN: " + lblRTN, printFont5, Brushes.Black, 0, 254)
        e.Graphics.DrawString("NOMBRE: " + nombrecliente, printFont5, Brushes.Black, 0, 264)

        Dim y As Integer = 264
        Dim ventaaempleado As String = "no"
        If (EsCafe(facturaanterior)) Then
            ventaaempleado = "no"
        Else
            If nombrecliente <> "Consumidor Final" And nombrecliente <> "" Then
                ventaaempleado = "si"
                Dim separador As String = "-"
                Dim resultado() As String = nombrecliente.Split(separador)
                Dim codigo_empleado As String = resultado(0).ToString
                DatosdelEmpleado(codigo_empleado)
                If EsCodigo = "si" Then
                    y = y + 10
                    e.Graphics.DrawString("CODIGO EMPLEADO: " + codigo_empleado, printFontm, Brushes.Black, 0, y)
                    y = y + 10
                    e.Graphics.DrawString("Credito Acumulado: L." + saldoacumulado.ToString("#,##0.00"), printFontm, Brushes.Black, 0, y)
                Else
                    ventaaempleado = "no"
                End If

            End If
        End If

        y = y + 15
        Dim point3 As New Point(5, y)
        Dim point4 As New Point(280, y)
        e.Graphics.DrawLine(Pens.Black, point3, point4)
        y = y + 2
        e.Graphics.DrawString("Cant.", printFont5, Brushes.Black, New RectangleF(0, y, 30, printFont5.Height), formato)
        e.Graphics.DrawString("Descripcion.", printFont5, Brushes.Black, New RectangleF(20, y, 200, printFont5.Height), formato)
        e.Graphics.DrawString("Valor.", printFont5, Brushes.Black, New RectangleF(160, y, 85, printFont5.Height), formato)
        y = y + 10
        Dim efect As Decimal = 0
        Dim camb As Decimal = 0
        Dim adaptador As New OdbcDataAdapter("select * from VistaItemsVenta where idventa='" + facturaanterior.ToString + "' order by id", conexion)
        Dim data As New DataSet
        Dim cont As Integer = 1
        adaptador.Fill(data, "VistaItemsVenta")
        adaptador.FillSchema(data.Tables("VistaItemsVenta"), SchemaType.Source)
        Dim acu15 As Decimal = 0
        Dim acu18 As Decimal = 0
        Dim acuEx As Decimal = 0
        Dim sin_isv As Decimal = 0
        Dim isv_15 As Decimal = 0
        Dim isv_18 As Decimal = 0
        Dim isv_si_no As String = ""
        For Each dr As DataRow In data.Tables("VistaItemsVenta").Rows
            y = y + 10
            'NOMBRE PRODUCTO
            numinterno = dr.Item(10).ToString
            e.Graphics.DrawString(dr.Item(6).ToString, printFont5, Brushes.Black, New RectangleF(0, y, 15, printFont5.Height), formato)
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

            'acumula precios netos, agrupados por el tipo de impuesto
            If Convert.ToInt32(dr(14).ToString) = 0 Then
                isv_si_no = "E"
                sin_isv = sin_isv + (CDec(dr.Item(2).ToString) * Val(dr.Item(6).ToString))
            ElseIf Convert.ToInt32(dr(14).ToString) = 15 Then
                isv_si_no = "G"
                isv_15 = isv_15 + (CDec(dr.Item(2).ToString) * Val(dr.Item(6).ToString))
            Else
                isv_si_no = "G"
                isv_18 = isv_18 + (CDec(dr.Item(2).ToString) * Val(dr.Item(6).ToString))
            End If

            Dim precioporproducto As Decimal = CDec((dr.Item(3).ToString))
            'Dim precioporproducto As Decimal = CDec(dr.Item(2).ToString) + CDec(dr.Item(4))
            e.Graphics.DrawString("L. " + CDec(precioporproducto).ToString("#,##0.00") + " ." + isv_si_no.ToString, printFont5, Brushes.Black, New RectangleF(150, y, 85, printFont5.Height), form)

            If ventaaempleado = "si" Then
                y = y + 10
                Dim cant As Integer = Val(dr.Item(6).ToString)
                e.Graphics.DrawString("Descuento:", printFont5, Brushes.Black, New RectangleF(20, y, 180, printFont5.Height))
                e.Graphics.DrawString("L.-" + (((dr.Item(16).ToString) * descuento / 100) * cant).ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(150, y, 85, printFont5.Height), form)
            End If
            'acumula los impuestos de cada producto
            Dim dispon1 As Decimal = dispon - Val(dr.Item(6).ToString)
            If (dr.Item(14).ToString = "15") Then
                acu15 = acu15 + CDec((Val(dr.Item(4))) * Val(dr.Item(6)))
            End If
            If (dr.Item(14).ToString = "18") Then
                acu18 = acu18 + CDec((Val(dr.Item(4))) * Val(dr.Item(6)))
            End If
            y = y + 10
        Next
        y = y + 10
        Dim point6 As New Point(5, y)
        Dim point7 As New Point(280, y)
        e.Graphics.DrawLine(Pens.Black, point6, point7)

        If ventaaempleado = "no" Then
            y = y + 10
            e.Graphics.DrawString("Sub total:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
            e.Graphics.DrawString("L." + lblSub, printFont4n, Brushes.Black, New RectangleF(140, y, 100, printFont4n.Height), form)
            y = y + 10
            e.Graphics.DrawString("Imp:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
            e.Graphics.DrawString("L." + lblimp, printFont4n, Brushes.Black, New RectangleF(140, y, 100, printFont4n.Height), form)
            y = y + 10
            e.Graphics.DrawString("Total:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
            e.Graphics.DrawString("L." + lbltotal, printFont4n, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)
        End If

        If ventaaempleado = "si" Then
            recalcularValores()
            y = y + 10
            e.Graphics.DrawString("Nuevo Balance con Descuento Empleado.", printFont5, Brushes.Black, New RectangleF(20, y, 200, printFont5.Height), form)

            y = y + 10
            e.Graphics.DrawString("Sub total:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
            lblSub = subtotalnuevafactura
            e.Graphics.DrawString("L." + CDec(lblSub).ToString("#,##0.00"), printFont4n, Brushes.Black, New RectangleF(140, y, 100, printFont4n.Height), form)

            y = y + 10
            e.Graphics.DrawString("Descuento:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
            e.Graphics.DrawString("L." + descuentonuevafactura.ToString("#,##0.00"), printFont4n, Brushes.Black, New RectangleF(140, y, 100, printFont4n.Height), form)

            y = y + 10
            e.Graphics.DrawString("ISV:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
            e.Graphics.DrawString("L." + CDec(isv15nuevafactura + isv18nuevafactura).ToString("#,##0.00"), printFont4n, Brushes.Black, New RectangleF(140, y, 100, printFont4n.Height), form)

            y = y + 10
            e.Graphics.DrawString("Total:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
            lbltotal = totalnuevafactura.ToString("#,##0.00")
            e.Graphics.DrawString("L." + CDec(lbltotal).ToString("#,##0.00"), printFont4n, Brushes.Black, New RectangleF(140, y, 100, printFont4n.Height), form)

            acu15 = CDec(isv15nuevafactura)
            acu18 = CDec(isv18nuevafactura)
            sin_isv = subtotalnuevafacturasin0 - (subtotalnuevafacturasin0 * Val(descuento / 100))
            isv_15 = subtotalnuevafacturasin15 - (subtotalnuevafacturasin15 * Val(descuento / 100))
            isv_18 = subtotalnuevafacturasin18 - (subtotalnuevafacturasin18 * Val(descuento / 100))
        End If


        Dim sql As String = "SELECT idmetodopago,monto,dolares from public.tbl_pos_ventametodospago where idventa=" + facturaanterior.ToString + ";"
        Dim adapmetodospago As New OdbcDataAdapter(sql, conexion)
        Dim datametodopago As New DataSet
        adapmetodospago.Fill(datametodopago, "metodopago")
        Dim tmptotal As Decimal = 0
        Dim efectivo As Integer = 0
        Dim tarjeta As String = "no"
        For Each dr As DataRow In datametodopago.Tables("metodopago").Rows
            y = y + 10
            If (dr.Item(0) = metodospago.efectivo) Then
                e.Graphics.DrawString("Efectivo:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
                e.Graphics.DrawString("L. " + CDec(dr.Item(1)).ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)
                llevacambio = 1

            ElseIf (dr.Item(0) = metodospago.tarjeta) Then
                e.Graphics.DrawString("T/C:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
                e.Graphics.DrawString("L. " + CDec(dr.Item(1)).ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)
                tarjeta = "si"

            ElseIf (dr.Item(0) = metodospago.puntos) Then
                e.Graphics.DrawString("Puntos:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
                e.Graphics.DrawString("L. " + CDec(dr.Item(1)).ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)

            ElseIf (dr.Item(0) = metodospago.creditoempleado) Then
                e.Graphics.DrawString("Credito Empleado:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
                e.Graphics.DrawString("L. " + CDec(dr.Item(1)).ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)
            ElseIf (dr.Item(0) = metodospago.wildcard) Then
                e.Graphics.DrawString("Wildcard:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
                e.Graphics.DrawString("L. " + CDec(dr.Item(1)).ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)

            ElseIf (dr.Item(0) = metodospago.carnet) Then
                e.Graphics.DrawString("Carnet:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
                e.Graphics.DrawString("L. " + CDec(dr.Item(1)).ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)

            ElseIf (dr.Item(0) = metodospago.efectivodollar) Then
                e.Graphics.DrawString("Dollar:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
                e.Graphics.DrawString("$. " + CDec(dr.Item(2)).ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)
                y = y + 10
                e.Graphics.DrawString("1$ = L." + tasa.ToString, printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)

            ElseIf (dr.Item(0) = metodospago.cafegratis) Then
                e.Graphics.DrawString("Cafe Gratis:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
                e.Graphics.DrawString("L. " + CDec(dr.Item(1).ToString).ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)

            ElseIf (dr.Item(0) = metodospago.Cambio) Then
                llevacambio = 0
                e.Graphics.DrawString("Cambio:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
                e.Graphics.DrawString("L. " + CDec(dr.Item(1)).ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)
            End If
            'e.Graphics.DrawString(dr.Item(1), printFont4n, Brushes.Black, New RectangleF(140, y, 100, printFont4n.Height), form)
            tmptotal += dr.Item(1)
        Next
        'Dim cambiovuelto As Decimal = 0.00
        y = y + 10
        If (llevacambio = 1) Then
            e.Graphics.DrawString("Cambio:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
            e.Graphics.DrawString("L.0.00 ", printFont4n, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)
        End If

        Dim pp As Decimal = 0
        'Busca si tiene asociado un recibo  y selecciona los metodos de pago para imprimirlos 
        Dim sqlrecibo As String = "SELECT id_recibo,pago_preventa FROM public.tbl_recibo_preventa WHERE id_numero_venta=" + facturaanterior.ToString + ";"
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
        End If

        y = y + 10
        Dim pointi As New Point(5, y)
        Dim pointif As New Point(280, y)
        e.Graphics.DrawLine(Pens.Black, pointi, pointif)

        If tarjeta <> "no" Then
            y = y + 5
            Dim sqltc = "SELECT numerotarjteta,numerotransaccion,fechavencimiento FROM public.tbl_pos_ventacreditotarjeta WHERE idventa=" + facturaanterior.ToString + ";"
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
            y = y + 10
        End If

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
        e.Graphics.DrawString(sin_isv.ToString("#,##0.00"), printFontm, Brushes.Black, New RectangleF(40, y, 50, printFontm.Height), form)
        e.Graphics.DrawString("L.", printFontm, Brushes.Black, New RectangleF(85, y, 30, printFontm.Height), form)
        e.Graphics.DrawString("0.00", printFontm, Brushes.Black, New RectangleF(90, y, 60, printFontm.Height), form)
        e.Graphics.DrawString("L.", printFontm, Brushes.Black, New RectangleF(145, y, 30, printFontm.Height), form)
        e.Graphics.DrawString(sin_isv.ToString("#,##0.00"), printFontm, Brushes.Black, New RectangleF(150, y, 85, printFontm.Height), form)
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
            e.Graphics.DrawString("L.", printFontm, Brushes.Black, New RectangleF(85, y, 30, printFontm.Height), form)
            e.Graphics.DrawString(CDec(acu18).ToString("#,##0.00"), printFontm, Brushes.Black, New RectangleF(90, y, 60, printFontm.Height), form)
            e.Graphics.DrawString("L.", printFontm, Brushes.Black, New RectangleF(145, y, 30, printFontm.Height), form)
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
        e.Graphics.DrawString(CDec(lblSub - descuentonuevafactura).ToString("#,##0.00"), printFontm, Brushes.Black, New RectangleF(40, y, 50, printFontm.Height), form)
        e.Graphics.DrawString("L.", printFontm, Brushes.Black, New RectangleF(85, y, 30, printFontm.Height), form)
        e.Graphics.DrawString(CDec(acu18 + acu15).ToString("#,##0.00"), printFontm, Brushes.Black, New RectangleF(90, y, 60, printFontm.Height), form)
        e.Graphics.DrawString("L.", printFontm, Brushes.Black, New RectangleF(145, y, 30, printFontm.Height), form)
        e.Graphics.DrawString(CDec(lbltotal).ToString("#,##0.00"), printFontm, Brushes.Black, New RectangleF(150, y, 85, printFontm.Height), form)
        y = y + 10
        e.Graphics.DrawString("Lotes de venta y #interno: " + loteventas.ToString + " #" + idfactura.ToString, printFont4, Brushes.Black, New RectangleF(5, y, 240, printFont4.Height), formato)
        y = y + 10
        e.Graphics.DrawString("Rango de Correlativo", printFont4, Brushes.Black, New RectangleF(5, y, 240, printFont4.Height), formato)
        y = y + 10
        e.Graphics.DrawString(rgInicio + "/" + rgFinal, printFont4, Brushes.Black, New RectangleF(5, y, 240, printFont4.Height), formato)
        y = y + 10
        e.Graphics.DrawString("¡Gracias por su compra!", printFont4, Brushes.Black, New RectangleF(5, y, 240, printFont4.Height), formato)
        y = y + 10
        e.Graphics.DrawString("Original:Cliente", printFont5, Brushes.Black, 0, y)
        y = y + 10
        e.Graphics.DrawString("Copia: Obligado tributario emisor", printFont5, Brushes.Black, 0, y)
        If (almacen = "Kiosko") Then
            y = y + 10
            e.Graphics.DrawString("KIOSKO", printFont4n, Brushes.Black, New RectangleF(5, y, 280, printFont4.Height), formato)
        End If
        If (lblestado <> "Activa") Then
            y = y + 10
            e.Graphics.DrawString(lblestado, printFont, Brushes.Black, New RectangleF(0, y, 280, printFont.Height), formato)
        End If
    End Sub

    Private Function recalcularValores()
        Dim adaptador As New OdbcDataAdapter("select * from VistaItemsVenta where idventa='" + facturaanterior.ToString + "' order by id", conexion)
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
                subtotalnuevafacturasin0 = subtotalnuevafacturasin0 + Convert.ToInt32((CInt(dr.Item(16).ToString)) * Val(dr.Item(6).ToString))

            ElseIf valor_isv = 15 Then
                Dim a As Decimal = (Val(dr.Item(16).ToString)) * Val(dr.Item(6).ToString)
                subtotalnuevafacturasin15 = subtotalnuevafacturasin15 + a
                isv15nuevafactura = isv15nuevafactura + CDec((a - Val(a * descuento / 100)) * Val(valor_isv / 100))
            Else
                Dim b As Decimal = (Val(dr.Item(16).ToString)) * Val(dr.Item(6).ToString)
                subtotalnuevafacturasin18 = subtotalnuevafacturasin18 + b
                isv18nuevafactura = isv18nuevafactura + CDec((b - Val(b * descuento / 100)) * Val(valor_isv / 100))
            End If

        Next

        subtotalnuevafactura = CDec(subtotalnuevafacturasin0 + subtotalnuevafacturasin15 + subtotalnuevafacturasin18)

        descuentonuevafactura = CDec(subtotalnuevafactura * descuento / 100)

        impuestonuevafactura = CDec(isv15nuevafactura + isv18nuevafactura).ToString("#,##0.00")

        totalnuevafactura = (CDec(subtotalnuevafactura - descuentonuevafactura) + CDec(impuestonuevafactura))

    End Function

    Function DatosdelEmpleado(codigoEmpleado As String)
        Dim salarioempleado As Decimal = 0
        Dim salariominimo As Decimal = 0
        Dim sqlsalario As String = "SELECT valor FROM public.tbl_parametros WHERE id_parametro=48"
        comando = New OdbcCommand(sqlsalario, conexion)
        LECTOR = comando.ExecuteReader()
        If LECTOR.Read Then
            salariominimo = CDec(LECTOR(0).ToString)
        End If

        Dim sqlsalarioempleado As String = "SELECT salario,descuento_empleado FROM public.tbl_empleado_credito WHERE codigo_empleado='" + codigoEmpleado + "';"
        comando = New OdbcCommand(sqlsalarioempleado, conexion)
        LECTOR = comando.ExecuteReader()
        If LECTOR.Read Then
            Dim sqlc As String = ""
            If es_preventa = "si" Then
                sqlc = "SELECT descuento_empleado,limite_credito,saldo_acumulado FROM public.tbl_empleado_credito WHERE codigo_empleado='" + codigoEmpleado + "' and credito_activo_preventa;"
            Else
                sqlc = "SELECT descuento_empleado,limite_credito,saldo_acumulado FROM public.tbl_empleado_credito WHERE codigo_empleado='" + codigoEmpleado + "' and credito_activo;"
            End If

            comando = New OdbcCommand(sqlc, conexion)
            LECTOR = comando.ExecuteReader()
            If LECTOR.Read Then
                descuento = CDec(LECTOR(0).ToString)
                saldoacumulado = Convert.ToDouble(LECTOR(2).ToString)
            Else
                descuento = 0
                EsCodigo = "no"
            End If

        Else
            EsCodigo = "no"
        End If

        'If (salarioempleado <= salariominimo) Then
        '    descuento = 15
        'ElseIf (salarioempleado > salariominimo And salarioempleado <= 12000) Then
        '    descuento = 10
        'Else
        '    descuento = 0
        'End If


    End Function

    Function EsCafe(idfactura As Integer)
        Dim escred As Boolean = False
        Dim sqlcredito As String = "SELECT idmetodopago,monto,dolares from public.tbl_pos_ventametodospago where idventa=" + facturaanterior.ToString + ";"
        Dim adaptador As New OdbcDataAdapter(sqlcredito, conexion)
        Dim data As New DataSet
        Dim cont As Integer = 1
        adaptador.Fill(data, "Escredito")
        adaptador.FillSchema(data.Tables("Escredito"), SchemaType.Source)
        For Each dr As DataRow In data.Tables("Escredito").Rows
            If dr.Item(0) = metodospago.cafegratis Then
                escred = True
            End If
        Next
        Return escred
    End Function

    Private Sub pd_recibo_PrintPage(sender As Object, e As PrintPageEventArgs) Handles pd_recibo.PrintPage
        comando = New OdbcCommand("select  * from tbl_cambioactual", conexion)
        LECTOR = comando.ExecuteReader
        If LECTOR.Read Then
            tasa = CDbl(LECTOR(1).ToString)
        End If

        comando = New OdbcCommand("select * from datosfacturaPOS where id='" + sessiones.id_pos.ToString + "'", conexion)
        LECTOR = comando.ExecuteReader
        If LECTOR.Read Then ' lee la consulta
            CAI = LECTOR(3).ToString
            rgInicio = LECTOR(7).ToString
            rgFinal = LECTOR(8).ToString
            Dim ids As String = LECTOR(12).ToString
            CORREO = LECTOR(11).ToString
            NombreSociedad = LECTOR(15).ToString
            nombrelegal = LECTOR(16).ToString
            fechalimite = LECTOR(17).ToString
            RTN = LECTOR(13).ToString
        End If

        Dim lblNumerofactura As String = ""
        Dim lblfecha As String = ""
        Dim lblestado As String = ""
        Dim lblRTN As String = ""
        Dim lblnombrecliente2 As String = ""
        Dim lblrango As String = ""
        Dim lblnumventa As String = ""
        Dim lbllote As String = ""
        Dim lblinterno As String = ""
        Dim lblcajero As String = ""
        Dim lblSub As String = ""
        Dim lbldesc As String = ""
        Dim lblimp As String = ""
        Dim horai As String = ""
        Dim fechai As String = ""
        Dim lbltotal As String = ""
        Dim tot As Decimal
        Dim idfactura As Integer
        Dim llevacambio As Integer = -1
        Dim nombrecliente As String = ""
        Dim correo_telefono As String = ""
        Dim pago_preventa As Decimal = 0
        subtotalnuevafactura = 0
        isv15nuevafactura = 0
        isv18nuevafactura = 0
        subtotalnuevafacturasin15 = 0
        subtotalnuevafacturasin18 = 0
        subtotalnuevafacturasin0 = 0
        descuentonuevafactura = 0

        Dim sql1 As String = "SELECT cast(id as text),nombrecliente FROM vistafacturasventa WHERE id_venta=" + facturaanterior.ToString + " and idalmacen='" + id_almacen.ToString + "' and id_usuario=" + id_usuario.ToString + ";"
        comando = New OdbcCommand(sql1, conexion)
        LECTOR = comando.ExecuteReader
        If LECTOR.Read Then
            idfactura = LECTOR(0).ToString
            nombrecliente = LECTOR(1).ToString
        End If
        Dim anulado As Integer = 0
        Dim id_cajero As Integer = 0
        'Dim sqldatosfactura As String = "SELECT numfactura, COALESCE(descuentototal,0), valortotal, CASE WHEN estado=1 THEN 'Activa' WHEN estado=2 THEN 'Pendiente Anulación' ELSE 'Anulada'  END, COALESCE(to_char(fecha, 'DD/MM/YYYY hh:mm:ss'), '') AS ff, cai, rtn, nombrecliente, rangocorrelativo, cajero, rginicial, rgfinal, COALESCE(subtotal,0) ,COALESCE(total_impuesto,0), COALESCE(to_char(hora, 'HH:MI'), '') AS hh, COALESCE(to_char(fecha, 'DD/MM/YYYY'), '') AS fechaaa FROM public.tbl_facturaventa where id='" + idfactura.ToString + "';"
        Dim sqldatosfactura As String = "SELECT * FROM public.tbl_recibo_preventa WHERE id_recibo=" + idrecibo.ToString + ";"
        comando = New OdbcCommand(sqldatosfactura, conexion)
        LECTOR = comando.ExecuteReader
        If LECTOR.Read Then
            lblNumerofactura = LECTOR(0).ToString()
            lblfecha = LECTOR(9).ToString()
            'lblestado = LECTOR(3).ToString()
            lblRTN = LECTOR(2).ToString()
            lblnombrecliente2 = LECTOR(3).ToString()
            'lblrango = LECTOR(8).ToString()
            'lblnumventa = numeroventa.ToString
            'lbllote = numeroLOTEventa.ToString
            'lblinterno = idfactura.ToString
            id_cajero = CInt(LECTOR(8).ToString())
            anulado = CInt(LECTOR(12).ToString)
            'lblSub = CDbl(LECTOR(12).ToString()).ToString("#,##0.00")
            'lbldesc = CDbl(LECTOR(1).ToString()).ToString("#,##0.00")
            'lblimp = CDbl(LECTOR(13).ToString()).ToString("#,##0.00")
            'horai = LECTOR(14).ToString()
            'fechai = LECTOR(15).ToString()
            'lbltotal = CInt(CDbl(LECTOR(2).ToString())).ToString("#,##0.00")
            'tot = CInt(CDbl(LECTOR(2).ToString()))
            correo_telefono = LECTOR(14).ToString

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
        Dim point1 As New Point(5, 137)
        Dim point2 As New Point(280, 137)
        e.Graphics.DrawLine(Pens.Black, point1, point2)
        e.Graphics.DrawString(NombreSociedad, printFont4, Brushes.Black, New RectangleF(0, 24, 280, printFont4.Height), formato)
        e.Graphics.DrawString(nombrelegal, printFont4, Brushes.Black, New RectangleF(0, 40, 280, printFont4.Height), formato)
        e.Graphics.DrawString("RTN: " + RTN, printFont4, Brushes.Black, New RectangleF(0, 56, 280, printFont4.Height), formato)
        e.Graphics.DrawString("Aldea Agua Dulce, Las Hadas", printFont4, Brushes.Black, New RectangleF(0, 72, 280, printFont4.Height), formato)
        e.Graphics.DrawString("Tegucigalpa, F.M., PBX", printFont4, Brushes.Black, New RectangleF(0, 88, 280, printFont4.Height), formato)
        e.Graphics.DrawString("2234-9595", printFont4, Brushes.Black, New RectangleF(0, 104, 280, printFont4.Height), formato)
        e.Graphics.DrawString(CORREO, printFont4, Brushes.Black, New RectangleF(0, 122, 280, printFont4.Height), formato)
        Dim point As New Point(5, 155)
        Dim point1t As New Point(280, 155)
        e.Graphics.DrawLine(Pens.Black, point, point1t)

        Dim a As String = If(reimprime = "si", "REIMPRESION BOLETA PREVENTA", "BOLETA PREVENTA")

        e.Graphics.DrawString(a, printFont4n, Brushes.Black, New RectangleF(0, 139, 280, printFont4n.Height), formato)

        Dim cajero As String = recuperarNombreCajero(id_cajero)
        e.Graphics.DrawString("POS#: " + id_pos.ToString, printFont3, Brushes.Black, 0, 158)
        e.Graphics.DrawString("Cajero: " + cajero.ToString, printFont3, Brushes.Black, 100, 158)
        e.Graphics.DrawString("Fecha: " + CDate(lblfecha).ToString("yyy-MM-dd"), printFont3, Brushes.Black, 0, 174)
        e.Graphics.DrawString("Hora: " + CDate(lblfecha).ToString("HH:MM"), printFont3, Brushes.Black, 160, 174)
        e.Graphics.DrawString("RTN: " + lblRTN, printFont5, Brushes.Black, 0, 184)
        e.Graphics.DrawString("Nombre: " + lblnombrecliente2, printFont5, Brushes.Black, 0, 194)
        e.Graphics.DrawString("Contacto: " + correo_telefono, printFont5, Brushes.Black, 0, 204)

        Dim y As Integer = 216
        Dim p1 As New Point(5, y)
        Dim p2 As New Point(280, y)

        e.Graphics.DrawLine(Pens.Black, p1, p2)
        y = y + 2
        e.Graphics.DrawString("Cant.", printFont5, Brushes.Black, New RectangleF(0, y, 30, printFont5.Height), formato)
        e.Graphics.DrawString("Descripcion.", printFont5, Brushes.Black, New RectangleF(20, y, 200, printFont5.Height), formato)
        e.Graphics.DrawString("Valor.", printFont5, Brushes.Black, New RectangleF(160, y, 85, printFont5.Height), formato)
        y = y + 10
        Dim ventaaempleado As String = ""
        Dim descuentopreventa As Integer = 0
        Dim sqlventaempleado As String = "SELECT descuento_empleado,descuento,pago_preventa FROM public.tbl_recibo_preventa where id_recibo=" + idrecibo.ToString + ";"
        comando = New OdbcCommand(sqlventaempleado, conexion)
        LECTOR = comando.ExecuteReader
        If LECTOR.HasRows Then
            If LECTOR.Read Then
                If LECTOR(0).ToString = "True" Then
                    ventaaempleado = "si"
                    descuentopreventa = CInt(LECTOR(1).ToString)
                    pago_preventa = CDec(LECTOR(2).ToString)
                Else
                    ventaaempleado = "no"
                    descuentopreventa = 0
                    pago_preventa = CDec(LECTOR(2).ToString)
                End If
            End If
        End If

        Dim efect As Decimal = 0
        Dim camb As Decimal = 0
        Dim adaptador As New OdbcDataAdapter("select * from VistaItemsVenta where idventa='" + facturaanterior.ToString + "' order by id", conexion)
        Dim data As New DataSet
        Dim cont As Integer = 1
        adaptador.Fill(data, "VistaItemsVenta")
        adaptador.FillSchema(data.Tables("VistaItemsVenta"), SchemaType.Source)
        Dim acu15 As Decimal = 0
        Dim acu18 As Decimal = 0
        Dim acuEx As Decimal = 0
        Dim sin_isv As Decimal = 0
        Dim isv_15 As Decimal = 0
        Dim isv_18 As Decimal = 0
        Dim isv_si_no As String = ""
        For Each dr As DataRow In data.Tables("VistaItemsVenta").Rows
            y = y + 10
            'NOMBRE PRODUCTO
            numinterno = dr.Item(1).ToString
            e.Graphics.DrawString(dr.Item(6).ToString, printFont5, Brushes.Black, New RectangleF(0, y, 15, printFont5.Height), formato)
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

            'acumula precios netos, agrupados por el tipo de impuesto
            If Convert.ToInt32(dr(14).ToString) = 0 Then
                isv_si_no = "E"
                sin_isv = sin_isv + Convert.ToInt32(CInt(dr.Item(2).ToString) * Val(dr.Item(6).ToString))
            ElseIf Convert.ToInt32(dr(14).ToString) = 15 Then
                isv_si_no = "G"
                isv_15 = isv_15 + CDec(CDec(dr.Item(2).ToString) * Val(dr.Item(6).ToString))
            Else
                isv_si_no = "G"
                isv_18 = isv_18 + CDec(CDec(dr.Item(2).ToString) * Val(dr.Item(6).ToString))
            End If

            Dim precioporproducto As Decimal = (CDec(dr.Item(3).ToString)).ToString("#,##0.00")

            'Dim precioporproducto As Decimal = CDec(dr.Item(2).ToString) + CDec(dr.Item(4))
            e.Graphics.DrawString("L. " + CDec(precioporproducto).ToString("#,##0.00") + " ." + isv_si_no.ToString, printFont5, Brushes.Black, New RectangleF(150, y, 85, printFont5.Height), form)

            If ventaaempleado = "si" Then
                y = y + 10
                Dim cant As Integer = Val(dr.Item(6).ToString)
                e.Graphics.DrawString("Descuento:", printFont5, Brushes.Black, New RectangleF(20, y, 180, printFont5.Height))
                e.Graphics.DrawString("L.-" + (CDec((dr.Item(2).ToString) * descuentopreventa / 100) * cant).ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(150, y, 85, printFont5.Height), form)
            End If

            'acumula los impuestos de cada tipo impuesto producto
            Dim dispon1 As Decimal = dispon - Val(dr.Item(6).ToString)
            If (dr.Item(14).ToString = "15") Then
                acu15 = acu15 + (CDec(Val(dr.Item(4).ToString)) * CDec(dr.Item(6).ToString))
            End If
            If (dr.Item(14).ToString = "18") Then
                acu18 = acu18 + (CDec(Val(dr.Item(4).ToString)) * CDec(dr.Item(6).ToString))
            End If
            If reimprime <> "si" Then
                Dim sqlUpdateMaterial As String = "UPDATE public.tbl_material_centro SET disponible=disponible-" + dr.Item(6).ToString + " WHERE id=" + numinterno.ToString + ";"
                comando = New OdbcCommand(sqlUpdateMaterial, conexion)
                comando.ExecuteNonQuery()
            End If

        Next

        y = y + 15
        Dim point6 As New Point(5, y)
        Dim point7 As New Point(280, y)
        e.Graphics.DrawLine(Pens.Black, point6, point7)

        Dim subtotalrecibo As Decimal = 0
        Dim isvrecibo As Decimal = 0
        Dim descuentorecibo As Decimal = 0
        Dim totalrecibo As Decimal = 0

        If ventaaempleado = "no" Then
            subtotalrecibo = sin_isv + isv_15 + isv_18
            isvrecibo = acu15 + acu18
            totalrecibo = subtotalrecibo + isvrecibo

            y = y + 10
            e.Graphics.DrawString("Sub total:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
            e.Graphics.DrawString("L." + subtotalrecibo.ToString("#,##0.00"), printFont4n, Brushes.Black, New RectangleF(140, y, 100, printFont4n.Height), form)
            y = y + 10
            e.Graphics.DrawString("Imp:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
            e.Graphics.DrawString("L." + isvrecibo.ToString("#,##0.00"), printFont4n, Brushes.Black, New RectangleF(140, y, 100, printFont4n.Height), form)
            y = y + 10
            e.Graphics.DrawString("Total:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
            e.Graphics.DrawString("L." + totalrecibo.ToString("#,##0.00"), printFont4n, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)
        End If

        If ventaaempleado = "si" Then
            sin_isv = sin_isv - (sin_isv * descuentopreventa / 100)
            isv_15 = isv_15 - (isv_15 * descuentopreventa / 100)
            isv_18 = isv_18 - (isv_18 * descuentopreventa / 100)
            acu15 = isv_15 * 0.15
            acu18 = isv_18 * 0.18

            subtotalrecibo = sin_isv + isv_15 + isv_18
            isvrecibo = acu15 + acu18
            descuentorecibo = (sin_isv * descuentopreventa / 100) + (isv_15 * descuentopreventa / 100) + (isv_18 * descuentopreventa / 100)
            totalrecibo = subtotalrecibo + isvrecibo

            y = y + 10
            e.Graphics.DrawString("Nuevo Balance con Descuento Empleado.", printFont5, Brushes.Black, New RectangleF(20, y, 200, printFont5.Height), form)

            y = y + 10
            e.Graphics.DrawString("Sub total:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
            lblSub = subtotalnuevafactura
            e.Graphics.DrawString("L." + CDec(subtotalrecibo).ToString("#,##0.00"), printFont4n, Brushes.Black, New RectangleF(140, y, 100, printFont4n.Height), form)

            y = y + 10
            e.Graphics.DrawString("Descuento:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
            e.Graphics.DrawString("L." + descuentorecibo.ToString("#,##0.00"), printFont4n, Brushes.Black, New RectangleF(140, y, 100, printFont4n.Height), form)

            y = y + 10
            e.Graphics.DrawString("ISV:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
            e.Graphics.DrawString("L." + CDec(acu15 + acu18).ToString("#,##0.00"), printFont4n, Brushes.Black, New RectangleF(140, y, 100, printFont4n.Height), form)

            y = y + 10
            e.Graphics.DrawString("Total:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
            lbltotal = totalnuevafactura.ToString("#,##0.00")
            e.Graphics.DrawString("L." + CDec(totalrecibo).ToString("#,##0.00"), printFont4n, Brushes.Black, New RectangleF(140, y, 100, printFont4n.Height), form)
        End If
        Dim sqlmetodo As String = "SELECT id_metodo_pago,monto FROM public.tbl_recibo_preventa_metodospago WHERE id_recibo=" + idrecibo.ToString + ";"
        Dim adapmetodospago As New OdbcDataAdapter(sqlmetodo, conexion)
        Dim datametodopago As New DataSet
        adapmetodospago.Fill(datametodopago, "metodopago")
        Dim tmptotal As Decimal = 0
        camb = 0
        For Each dr As DataRow In datametodopago.Tables("metodopago").Rows
            y = y + 10
            If (dr.Item(0) = metodospago.efectivo) Then
                e.Graphics.DrawString("Efectivo:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
                e.Graphics.DrawString("L. " + CDec(dr.Item(1)).ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)
                llevacambio = 1

            ElseIf (dr.Item(0) = metodospago.tarjeta) Then
                e.Graphics.DrawString("T/C:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
                e.Graphics.DrawString("L. " + CDec(dr.Item(1)).ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)
                'tarjeta = "si"

            ElseIf (dr.Item(0) = metodospago.puntos) Then
                e.Graphics.DrawString("Puntos:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
                e.Graphics.DrawString("L. " + CDec(dr.Item(1)).ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)

            ElseIf (dr.Item(0) = metodospago.creditoempleado) Then
                e.Graphics.DrawString("Credito Empleado:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
                e.Graphics.DrawString("L. " + CDec(dr.Item(1)).ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)

            ElseIf (dr.Item(0) = metodospago.wildcard) Then
                e.Graphics.DrawString("Wildcard:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
                e.Graphics.DrawString("L. " + CDec(dr.Item(1)).ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)

            ElseIf (dr.Item(0) = metodospago.carnet) Then
                e.Graphics.DrawString("Carnet:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
                e.Graphics.DrawString("L. " + CDec(dr.Item(1)).ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)

            ElseIf (dr.Item(0) = metodospago.efectivodollar) Then
                e.Graphics.DrawString("Dollar:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
                e.Graphics.DrawString("$. " + CDec(dr.Item(2)).ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)
                y = y + 10
                e.Graphics.DrawString("1$ = L." + tasa.ToString, printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)

            ElseIf (dr.Item(0) = metodospago.cafegratis) Then
                e.Graphics.DrawString("Cafe Gratis:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
                e.Graphics.DrawString("L. " + CDec(dr.Item(1).ToString).ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)

            ElseIf (dr.Item(0) = metodospago.Cambio) Then
                e.Graphics.DrawString("Cambio:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
                e.Graphics.DrawString("L. " + CDec(dr.Item(1)).ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)
                camb = CDec(dr.Item(1))
            End If
            'e.Graphics.DrawString(dr.Item(1), printFont4n, Brushes.Black, New RectangleF(140, y, 100, printFont4n.Height), form)
            'tmptotal += dr.Item(1)
        Next
        y = y + 15
        e.Graphics.DrawString("PREVENTA PAGADO: L." + (pago_preventa - camb).ToString("#,##0.00"), printFont4, Brushes.Black, New RectangleF(0, y, 280, printFont4.Height), formato)
        y = y + 12
        Dim saldo_pre As Decimal = If((totalrecibo - pago_preventa + camb) > 0, CDec(totalrecibo - pago_preventa + camb), 0.00)

        e.Graphics.DrawString("SALDO PREVENTA: L." + (saldo_pre).ToString("#,##0.00"), printFont4, Brushes.Black, New RectangleF(0, y, 280, printFont4.Height), formato)

        y = y + 12
        point6 = New Point(5, y)
        point7 = New Point(280, y)
        e.Graphics.DrawLine(Pens.Black, point6, point7)

        y = y + 8
        e.Graphics.DrawString("Lotes de venta y #interno: " + loteventas.ToString + " # " + idrecibo.ToString, printFont4, Brushes.Black, New RectangleF(5, y, 240, printFont4.Height), formato)

        y = y + 10
        e.Graphics.DrawString("¡Gracias por su compra!", printFont4, Brushes.Black, New RectangleF(5, y, 240, printFont4.Height), formato)

        If anulado = 2 Then
            y = y + 10
            e.Graphics.DrawString("BOLETA ANULADA", printFont4, Brushes.Black, New RectangleF(5, y, 240, printFont4.Height), formato)
        End If

        reimprime = "n"
    End Sub

    Private Function recuperarNombreCajero(cajero As Integer)
        Dim sqlusuario As String = "SELECT usuario FROM public.tbl_usuario WHERE id_usuario=" + cajero.ToString + ";"
        comando = New OdbcCommand(sqlusuario, conexion)
        LECTOR = comando.ExecuteReader()
        If LECTOR.HasRows Then
            Return LECTOR(0).ToString
        End If
    End Function

End Class
