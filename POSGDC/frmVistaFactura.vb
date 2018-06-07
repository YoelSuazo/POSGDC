Imports System.Data.Odbc
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Data
Imports System.Globalization
Imports System.Threading
Imports System.Drawing
Imports System
Imports System.Drawing.Printing
Imports POSGDC.conexion
Public Class frmVistaFactura
    Dim con As New conexion
    Dim conexion As New Odbc.OdbcConnection()
    'Dim conexion As New Odbc.OdbcConnection("DSN=ORIECOMP")
    Dim comando As New Odbc.OdbcCommand
    Dim LECTOR As OdbcDataReader
    Dim valcod As String
    Dim reimprime As String
    Dim CAI As String
    Dim RTN As String
    Dim CORREO As String
    Dim NombreSociedad As String
    Dim nombrelegal As String
    Dim rgcorrelativo As String
    Dim rgInicio As String
    Dim rgFinal As String
    Dim fechalimite As String
    Dim tasa As Decimal
    Dim dolares As Decimal
    Dim fechai As String
    Dim horai As String
    Dim tot As Integer
    Dim imprimirFact As New imprimir


    Public Property pgconection() As OdbcConnection
        Set(value As OdbcConnection)
            conexion = value
        End Set
        Get
            Return Me.conexion
        End Get
    End Property

    Public Enum metodospago
        efectivo = 1
        tarjeta = 2
        puntos = 3
        creditoempleado = 4
        wildcard = 5
        efectivodollar = 7
        cafegratis = 8
        carnet = 9
        descuentoEmpleado = 10
    End Enum

    Private Sub btnregresar_Click(sender As Object, e As EventArgs) Handles btnregresar.Click
        numeroventa = 0
        numeroLOTEventa = 0
        My.Forms.frmFacturasLista.pgconection = conexion
        My.Forms.frmFacturasLista.Show()
        Me.Close()
    End Sub

    Private Sub frmVistaFactura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conexion = pgconection
        con.openConection(conexion)
        Dim sqlfactura As String = "SELECT numfactura, COALESCE(descuentototal,0), valortotal, CASE WHEN estado=1 THEN 'Activa' WHEN estado=2 THEN 'Pendiente Anulación' ELSE 'Anulada'  END, COALESCE(to_char(fecha, 'DD/MM/YYYY hh:mm:ss'), '') AS ff, cai, rtn, nombrecliente, rangocorrelativo, cajero, rginicial, rgfinal, COALESCE(subtotal,0) ,COALESCE(total_impuesto,0), COALESCE(to_char(fecha, 'hh:mm:ss'), '') AS hh, COALESCE(to_char(fecha, 'DD/MM/YYYY'), '') AS fechaaa FROM public.tbl_facturaventa where id='" + idfactura.ToString + "'"
        comando = New OdbcCommand(sqlfactura, conexion)
        LECTOR = comando.ExecuteReader
        If LECTOR.Read Then
            lblNumerofactura.Text = LECTOR(0).ToString()
            lblfecha.Text = LECTOR(4).ToString()
            lblestado.Text = LECTOR(3).ToString()
            lblRTN.Text = LECTOR(6).ToString()
            lblNombreCliente.Text = LECTOR(7).ToString()
            lblrango.Text = LECTOR(8).ToString()
            lblnumventa.Text = numeroventa.ToString
            lbllote.Text = numeroLOTEventa.ToString
            lblinterno.Text = idfactura.ToString
            lblcajero.Text = LECTOR(9).ToString()
            lblsub.Text = "L." + CDbl(LECTOR(12).ToString()).ToString("#,##0.00")
            lbldesc.Text = "L." + CDbl(LECTOR(1).ToString()).ToString("#,##0.00")
            lblimp.Text = "L." + CDbl(LECTOR(13).ToString()).ToString("#,##0.00")
            horai = LECTOR(14).ToString()
            fechai = LECTOR(15).ToString()
            lbltotal.Text = "L." + (CDbl(LECTOR(2).ToString())).ToString("#,##0.00")
            tot = CInt(CDbl(LECTOR(2).ToString()))
        End If
        Dim np As String = sessiones.numeroventa.ToString
        Dim adaptador As New OdbcDataAdapter("select cantidad,codmate,codigo_barras,descripcion,subtotal,impuesto,precio from VistaItemsVenta WHERE idventa = '" + sessiones.numeroventa.ToString + "'", conexion)
        Dim data As New DataSet
        Dim cont As Integer = 1
        adaptador.Fill(data, "VistaItemsVenta")
        Me.DataGridView1.DataSource = data.Tables("VistaItemsVenta")
        Me.DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        'conexion.Close()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnReimprime.Click
        con.openConection(conexion)
        reimprime = "s"
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
        imprimirFact.ImprimirFactura("s", conexion, numeroventa, numeroLOTEventa)
        'PrintDocument1.Print()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        con.openConection(conexion)
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
            e.Graphics.DrawString("Reimpresion", printFont, Brushes.Black, New RectangleF(0, 8, 280, printFont.Height), formato)
        End If
        e.Graphics.DrawString(NombreSociedad, printFont4, Brushes.Black, New RectangleF(0, 24, 280, printFont4.Height), formato)
        e.Graphics.DrawString(nombrelegal, printFont4, Brushes.Black, New RectangleF(0, 40, 280, printFont4.Height), formato)
        e.Graphics.DrawString("RTN: " + RTN, printFont4, Brushes.Black, New RectangleF(0, 56, 280, printFont4.Height), formato)
        e.Graphics.DrawString("Aldea Agua Dulce, Las Hadas", printFont4, Brushes.Black, New RectangleF(0, 72, 280, printFont4.Height), formato)
        e.Graphics.DrawString("Tegucigalpa, F.M., PBX", printFont4, Brushes.Black, New RectangleF(0, 88, 280, printFont4.Height), formato)
        e.Graphics.DrawString("2234-9595", printFont4, Brushes.Black, New RectangleF(0, 104, 280, printFont4.Height), formato)
        e.Graphics.DrawString(CORREO, printFont4, Brushes.Black, New RectangleF(0, 122, 280, printFont4.Height), formato)
        e.Graphics.DrawString("FACTURA", printFont4n, Brushes.Black, New RectangleF(0, 138, 280, printFont4n.Height), formato)
        Dim point As New Point(5, 155)
        Dim point1t As New Point(280, 155)
        e.Graphics.DrawLine(Pens.Black, point, point1t)
        e.Graphics.DrawString("POS#: " + id_pos.ToString, printFont5, Brushes.Black, 0, 158)
        e.Graphics.DrawString("Cajero: " + lblcajero.Text, printFont5, Brushes.Black, 100, 158)
        e.Graphics.DrawString("Fecha: " + fechai, printFont5, Brushes.Black, 0, 174)
        e.Graphics.DrawString("Hora: " + horai, printFont5, Brushes.Black, 160, 174)
        e.Graphics.DrawString("CORRELATIVO: " + lblNumerofactura.Text, printFont5, Brushes.Black, 0, 190)
        e.Graphics.DrawString("CAI: " + CAI, printFont1, Brushes.Black, 0, 206)
        e.Graphics.DrawString("FECHA LIMITE EMISION: " + fechalimite, printFont5, Brushes.Black, 0, 222)
        e.Graphics.DrawString("DESDE: " + rgInicio, printFont5, Brushes.Black, 0, 238)
        e.Graphics.DrawString("HASTA: " + rgFinal, printFont5, Brushes.Black, 135, 238)
        e.Graphics.DrawString("RTN: " + Me.lblRTN.Text, printFont5, Brushes.Black, 0, 254)
        e.Graphics.DrawString("NOMBRE: " + Me.lblNombreCliente.Text, printFont5, Brushes.Black, 0, 270)
        Dim point3 As New Point(5, 286)
        Dim point4 As New Point(280, 286)
        e.Graphics.DrawLine(Pens.Black, point3, point4)
        e.Graphics.DrawString("Cant.", printFont5, Brushes.Black, New RectangleF(0, 288, 30, printFont5.Height), formato)
        e.Graphics.DrawString("Descripcion.", printFont5, Brushes.Black, New RectangleF(35, 288, 200, printFont5.Height), formato)
        e.Graphics.DrawString("Valor.", printFont5, Brushes.Black, New RectangleF(200, 288, 85, printFont5.Height), formato)
        Dim y As Integer = 304
        Dim efect As Decimal = 0
        Dim camb As Decimal = 0
        Dim adaptador As New OdbcDataAdapter("select * from VistaItemsVenta where idventa='" + numeroventa.ToString + "'", conexion)
        Dim data As New DataSet
        Dim cont As Integer = 1
        adaptador.Fill(data, "VistaItemsVenta")
        adaptador.FillSchema(data.Tables("VistaItemsVenta"), SchemaType.Source)
        Dim acu15 As Decimal = 0
        Dim acu18 As Decimal = 0
        Dim acuEx As Decimal = 0
        For Each dr As DataRow In data.Tables("VistaItemsVenta").Rows
            y = y + 16
            numinterno = dr.Item(10).ToString
            e.Graphics.DrawString(dr.Item(6).ToString, printFont5, Brushes.Black, New RectangleF(0, y, 30, printFont5.Height), formato)
            Dim subcadena As String
            Dim s As String = dr.Item(5).ToString
            Dim tam As Integer = (dr.Item(5).ToString).Length
            If (tam > 30) Then
                subcadena = (dr.Item(5).ToString).Substring(0, 24)
                e.Graphics.DrawString(subcadena, printFont5, Brushes.Black, New RectangleF(20, y, 180, printFont5.Height))
                y = y + 10
                Dim sub2 As String = ""
                sub2 = s.Substring(30, tam - 30)
                e.Graphics.DrawString(sub2, printFont5, Brushes.Black, New RectangleF(20, y, 180, printFont5.Height))
            Else
                subcadena = (dr.Item(5).ToString)
                e.Graphics.DrawString(subcadena, printFont5, Brushes.Black, New RectangleF(20, y, 180, printFont5.Height))
            End If
            e.Graphics.DrawString("L. " + CInt(CDec(dr.Item(3).ToString) * Val(dr.Item(6).ToString)).ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(150, y, 85, printFont5.Height), form)
            Dim dispon1 As Decimal = dispon - Val(dr.Item(6).ToString)
            If (dr.Item(14).ToString = "15") Then
                acu15 = acu15 + (CDbl(Val(dr.Item(4).ToString)) * CDbl(dr.Item(6).ToString))
            End If
            If (dr.Item(14).ToString = "18") Then
                acu18 = acu18 + (CDbl(Val(dr.Item(4).ToString)) * CDbl(dr.Item(6).ToString))
            End If
            y = y + 10
        Next
        y = y + 10
        Dim point6 As New Point(5, y)
        Dim point7 As New Point(280, y)
        e.Graphics.DrawLine(Pens.Black, point6, point7)
        y = y + 10
        e.Graphics.DrawString("Sub total:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
        e.Graphics.DrawString(Me.lblsub.Text, printFont4n, Brushes.Black, New RectangleF(140, y, 100, printFont4n.Height), form)
        y = y + 10
        e.Graphics.DrawString("Imp:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
        e.Graphics.DrawString(Me.lblimp.Text, printFont4n, Brushes.Black, New RectangleF(140, y, 100, printFont4n.Height), form)
        y = y + 10
        e.Graphics.DrawString("Total:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
        e.Graphics.DrawString(Me.lbltotal.Text, printFont4n, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)

        Dim sql As String = "SELECT idmetodopago,monto,dolares from public.tbl_pos_ventametodospago where idventa=" + sessiones.numeroventa.ToString + ";"
        Dim adapmetodospago As New OdbcDataAdapter(sql, conexion)
        Dim datametodopago As New DataSet
        adapmetodospago.Fill(datametodopago, "metodopago")
        'adapmetodospago.FillSchema(datametodopago.Tables("metodopago"), SchemaType.Source)
        Dim tmptotal As Integer = 0
        Dim efectivo As Integer = 0
        Dim llevacambio = -1
        Dim tarjeta As String = "no"
        For Each dr As DataRow In datametodopago.Tables("metodopago").Rows
            y = y + 10
            If (dr.Item(0) = metodospago.efectivo) Then
                e.Graphics.DrawString("Efectivo:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
                e.Graphics.DrawString("L. " + dr.Item(1).ToString, printFont5, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)
                llevacambio = 1
            ElseIf (dr.Item(0) = metodospago.tarjeta) Then
                e.Graphics.DrawString("T/C:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
                e.Graphics.DrawString("L. " + dr.Item(1).ToString, printFont5, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)
                tarjeta = "si"

            ElseIf (dr.Item(0) = metodospago.puntos) Then
                e.Graphics.DrawString("Puntos:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
                e.Graphics.DrawString("L. " + dr.Item(1).ToString, printFont5, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)

            ElseIf (dr.Item(0) = metodospago.creditoempleado) Then
                e.Graphics.DrawString("Credito Empleado:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
                e.Graphics.DrawString("L. " + dr.Item(1).ToString, printFont5, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)

            ElseIf (dr.Item(0) = metodospago.descuentoEmpleado) Then
                e.Graphics.DrawString("Descuento Empleado:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
                e.Graphics.DrawString("L. " + dr.Item(1).ToString, printFont5, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)

            ElseIf (dr.Item(0) = metodospago.wildcard) Then
                e.Graphics.DrawString("Wildcard:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
                e.Graphics.DrawString("L. " + dr.Item(1).ToString, printFont5, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)

            ElseIf (dr.Item(0) = metodospago.efectivodollar) Then
                e.Graphics.DrawString("Dollar:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
                e.Graphics.DrawString("$. " + dr.Item(2).ToString, printFont5, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)
                llevacambio = 1
            ElseIf (dr.Item(0) = metodospago.cafegratis) Then
                e.Graphics.DrawString("Cafe Gratis:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
            End If
            e.Graphics.DrawString(dr.Item(1), printFont4n, Brushes.Black, New RectangleF(140, y, 100, printFont4n.Height), form)
            tmptotal += dr.Item(1)
            y = y + 10
        Next
        Dim cambiovuelto As Integer

        If (llevacambio = 1) Then
            cambiovuelto = tmptotal - tot
            If (cambiovuelto <= 0) Then
                cambiovuelto = 0
            End If
            y = y + 10
            e.Graphics.DrawString("Cambio:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
            e.Graphics.DrawString(cambiovuelto, printFont4n, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)
        End If

        y = y + 10
        Dim pointi As New Point(5, y)
        Dim pointif As New Point(280, y)
        e.Graphics.DrawLine(Pens.Black, pointi, pointif)
        y = y + 10

        If tarjeta <> "no" Then
            Dim sqltc = "SELECT numerotarjteta,numerotransaccion,fechavencimiento FROM public.tbl_pos_ventacreditotarjeta WHERE idventa=" + numeroventa.ToString + ";"
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
        e.Graphics.DrawString("0.00", printFontm, Brushes.Black, New RectangleF(40, y, 50, printFontm.Height), form)
        e.Graphics.DrawString("0.00", printFontm, Brushes.Black, New RectangleF(90, y, 60, printFontm.Height), form)
        e.Graphics.DrawString("0.00", printFontm, Brushes.Black, New RectangleF(150, y, 85, printFontm.Height), form)
        y = y + 10
        If acu15 > 0 Then
            e.Graphics.DrawString("15%", printFontm, Brushes.Black, New RectangleF(0, y, 30, printFontm.Height), form)
            e.Graphics.DrawString(Me.lblsub.Text, printFontm, Brushes.Black, New RectangleF(40, y, 50, printFontm.Height), form)
            e.Graphics.DrawString(acu15.ToString("#,##0.00"), printFontm, Brushes.Black, New RectangleF(90, y, 60, printFontm.Height), form)
            e.Graphics.DrawString(Me.lbltotal.Text, printFontm, Brushes.Black, New RectangleF(150, y, 85, printFontm.Height), form)
        Else
            e.Graphics.DrawString("15%", printFontm, Brushes.Black, New RectangleF(0, y, 30, printFontm.Height), form)
            e.Graphics.DrawString("0.00", printFontm, Brushes.Black, New RectangleF(40, y, 50, printFontm.Height), form)
            e.Graphics.DrawString("0.00", printFontm, Brushes.Black, New RectangleF(90, y, 60, printFontm.Height), form)
            e.Graphics.DrawString("0.00", printFontm, Brushes.Black, New RectangleF(150, y, 85, printFontm.Height), form)
        End If
        y = y + 10
        If acu18 > 0 Then
            e.Graphics.DrawString("18%", printFontm, Brushes.Black, New RectangleF(0, y, 30, printFontm.Height), form)
            e.Graphics.DrawString(Me.lblsub.Text, printFontm, Brushes.Black, New RectangleF(40, y, 50, printFontm.Height), form)
            e.Graphics.DrawString(acu18.ToString("#,##0.00"), printFontm, Brushes.Black, New RectangleF(90, y, 60, printFontm.Height), form)
            e.Graphics.DrawString(Me.lbltotal.Text, printFontm, Brushes.Black, New RectangleF(150, y, 85, printFontm.Height), form)
        Else
            e.Graphics.DrawString("18%", printFontm, Brushes.Black, New RectangleF(0, y, 30, printFontm.Height), form)
            e.Graphics.DrawString("0.00", printFontm, Brushes.Black, New RectangleF(40, y, 50, printFontm.Height), form)
            e.Graphics.DrawString("0.00", printFontm, Brushes.Black, New RectangleF(90, y, 60, printFontm.Height), form)
            e.Graphics.DrawString("0.00", printFontm, Brushes.Black, New RectangleF(150, y, 85, printFontm.Height), form)
        End If
        y = y + 10
        e.Graphics.DrawString("Total", printFontm, Brushes.Black, New RectangleF(0, y, 30, printFontm.Height), form)
        e.Graphics.DrawString(Me.lblsub.Text, printFontm, Brushes.Black, New RectangleF(40, y, 50, printFontm.Height), form)
        e.Graphics.DrawString((acu18 + acu15).ToString("#,##0.00"), printFontm, Brushes.Black, New RectangleF(90, y, 60, printFontm.Height), form)
        e.Graphics.DrawString(Me.lbltotal.Text, printFontm, Brushes.Black, New RectangleF(150, y, 85, printFontm.Height), form)
        y = y + 10
        e.Graphics.DrawString("Lotes de venta y #interno: " + id_loteventa.ToString + " #" + numinterno.ToString, printFont4, Brushes.Black, New RectangleF(5, y, 240, printFont4.Height), formato)
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
        If (lblestado.Text <> "Activa") Then
            y = y + 16
            e.Graphics.DrawString(Me.lblestado.Text, printFont, Brushes.Black, New RectangleF(0, y, 280, printFont.Height), formato)
        End If
    End Sub

    Private Sub btnpago_Click(sender As Object, e As EventArgs) Handles btnpago.Click
        con.openConection(conexion)
        Dim prompt As String = String.Empty
        Dim title As String = String.Empty
        Dim defaultResponse As String = String.Empty
        Dim answer As Object
        ' Set prompt.
        prompt = "Comentario:"
        ' Set title.
        title = "Por favor ingrese un comentario:"
        ' Set default value.
        'actualiza venta ;
        answer = InputBox(prompt, title, defaultResponse)

        If answer <> "" Then
            Dim mensaje As String

            mensaje = MsgBox("DESEA ENVIAR SOLICITUD DE ANULACION?", vbOKCancel, "CONFIRMACION")
            If mensaje = vbOK Then
                comando = New Odbc.OdbcCommand("UPDATE tbl_facturaventa  SET estado='2', observaciones='" + answer + "' WHERE id= '" + idfactura.ToString + "'", conexion)
                comando.ExecuteNonQuery()
                'conexion.Close()
                numeroventa = 0
                numeroLOTEventa = 0
                idfactura = 0
                'My.Forms.frmFacturasLista.pgconection = conexion
                'My.Forms.frmFacturasLista.Show()
                Me.Close()

            Else

            End If
        End If



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        con.openConection(conexion)
        reimprime = "n"
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
        imprimirFact.ImprimirFactura("n", conexion, numeroventa, numeroLOTEventa)
        'PrintDocument1.Print()
    End Sub
End Class