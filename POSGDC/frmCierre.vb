Imports System.Data.Odbc
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Data
Imports System.Globalization
Imports System.Threading
Imports System.Drawing.Printing
Imports POSGDC.conexion
Public Class frmCierre
    Dim con As New conexion
    Dim conexion As New Odbc.OdbcConnection()
    Dim comando As New Odbc.OdbcCommand
    Dim LECTOR As OdbcDataReader
    Dim CAI As String
    Dim RTN As String
    Dim CORREO As String
    Dim NombreSociedad As String
    Dim nombrelegal As String
    Dim tasa As Decimal = 0

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
    End Enum

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs)

    End Sub


    Public Sub solonumeros(ByRef e As System.Windows.Forms.KeyPressEventArgs)

        Select Case e.KeyChar
            Case "."
                e.Handled = False
            Case "-"
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


    Private Sub txtefectivo_KeyPress(sender As Object, e As KeyPressEventArgs)
        solonumeros(e)
    End Sub

    Private Sub txttarjeta_KeyPress(sender As Object, e As KeyPressEventArgs)
        solonumeros(e)
    End Sub
    Private Sub txtpuntos_KeyPress(sender As Object, e As KeyPressEventArgs)
        solonumeros(e)
    End Sub
    Private Sub txtempleados_KeyPress(sender As Object, e As KeyPressEventArgs)
        solonumeros(e)
    End Sub

    Private Sub txtwildacart_KeyPress(sender As Object, e As KeyPressEventArgs)
        solonumeros(e)
    End Sub
    Private Sub txtcafe_KeyPress(sender As Object, e As KeyPressEventArgs)
        solonumeros(e)
    End Sub

    Private Sub txtcarnet_KeyPress(sender As Object, e As KeyPressEventArgs)
        solonumeros(e)
    End Sub

    Private Sub btnReimprime_Click(sender As Object, e As EventArgs) Handles btnReimprime.Click
        Dim prompt As String = String.Empty
        Dim title As String = String.Empty
        Dim defaultResponse As String = String.Empty
        Dim answer As Object

        If (txtefectivo.Text <> "" And txttarjeta.Text <> "" And txtdolares.Text <> "" And txtpuntos.Text <> "" And txtempleados.Text <> "" And txtwildacart.Text <> "" And txtcafe.Text <> "" And txtcarnet.Text <> "") Then

            ' Set prompt.
            prompt = "Comentario:"
            ' Set title.
            title = "Desea agregar un comentario:"
            ' Set default value.
            'actualiza venta ;
            answer = InputBox(prompt, title, defaultResponse)
            If answer <> "" Then
                Dim mensaje As String

                mensaje = MsgBox("DESEA REALIZAR EL CIERRE DEL LOTE " + lbllote.Text + "?", vbOKCancel, "CONFIRMACION")
                If mensaje = vbOK Then
                    con.openConection(conexion)
                    Dim efectivo As Decimal = 0
                    Dim Tarjetacredito As Decimal = 0
                    Dim Puntos As Decimal = 0
                    Dim CreditoEmpleados As Decimal = 0
                    Dim WildcartDisponible As Decimal = 0
                    Dim Efectivodolar As Decimal = 0
                    Dim CafeGratis As Decimal = 0
                    Dim Carnet As Decimal = 0
                    Dim total As Decimal = 0
                    If (Me.txtefectivo.Text <> "") Then
                        efectivo = CDbl(Me.txtefectivo.Text)
                    End If
                    If (Me.txttarjeta.Text <> "") Then
                        Tarjetacredito = CDbl(Me.txttarjeta.Text)
                    End If
                    If (Me.txtpuntos.Text <> "") Then
                        Puntos = CDbl(Me.txtpuntos.Text)
                    End If
                    If (Me.txtempleados.Text <> "") Then
                        CreditoEmpleados = CDbl(Me.txtempleados.Text)
                    End If
                    If (Me.txtwildacart.Text <> "") Then
                        WildcartDisponible = CDbl(Me.txtwildacart.Text)
                    End If
                    If (Me.txtdolares.Text <> "") Then
                        Efectivodolar = CDbl(Me.txtdolares.Text)
                    End If
                    If (Me.txtcafe.Text <> "") Then
                        CafeGratis = CDbl(Me.txtcafe.Text)
                    End If
                    If (Me.txtcarnet.Text <> "") Then
                        Carnet = CDbl(Me.txtcarnet.Text)
                    End If
                    'conexion.Open()
                    comando = New Odbc.OdbcCommand("UPDATE public.tbl_pos_loteventa
                               SET fechahoraf=now(), estado=false, efectivo='" + efectivo.ToString + "', tarjetacredito='" + Tarjetacredito.ToString + "', 
                                   puntos='" + Puntos.ToString + "', creditoempleados='" + CreditoEmpleados.ToString + "', wildcartdisponible='" + WildcartDisponible.ToString + "', efectivodolar='" + Efectivodolar.ToString + "', 
                                   cafegratis='" + CafeGratis.ToString + "', carnet='" + Carnet.ToString + "', comentario='" + answer + "'
                             WHERE id='" + id_loteventa.ToString + "';", conexion)
                    comando.ExecuteNonQuery()
                    comando = New OdbcCommand("select * from datosfacturaPOS where id='" + sessiones.id_pos.ToString + "'", conexion)
                    LECTOR = comando.ExecuteReader
                    If LECTOR.Read Then ' lee la consulta
                        CAI = LECTOR(3).ToString
                        CORREO = LECTOR(11).ToString
                        NombreSociedad = LECTOR(15).ToString
                        nombrelegal = LECTOR(16).ToString
                        RTN = LECTOR(13).ToString
                    End If
                    PrintDocument1.Print()
                End If
            End If
        Else
            MessageBox.Show("Debe llenar todos los campos para generar cierre", "Error al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim topMargin As Double = e.MarginBounds.Top
        e.PageSettings.Margins.Left = 1
        e.PageSettings.Margins.Right = 1
        e.PageSettings.Landscape = False
        Dim sf As New StringFormat
        sf.Alignment = StringAlignment.Near
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
        Dim printFont As System.Drawing.Font = New Font("Arial", 12, FontStyle.Bold)
        Dim printFont2 As System.Drawing.Font = New Font("Arial", 9, FontStyle.Bold)
        Dim printFont1 As System.Drawing.Font = New Font("Arial", 8)
        Dim printFont3 As System.Drawing.Font = New Font("Arial", 10)
        Dim printFont4 As System.Drawing.Font = New Font("Arial", 9)
        Dim printFont5 As System.Drawing.Font = New Font("Arial", 9)
        Dim printFontm As System.Drawing.Font = New Font("Arial", 8)
        Dim printFont4n As System.Drawing.Font = New Font("Arial", 9, FontStyle.Bold)
        Dim point1 As New Point(5, 120)
        Dim point2 As New Point(240, 120)
        e.Graphics.DrawLine(Pens.Black, point1, point2)
        e.Graphics.DrawString(NombreSociedad, printFont5, Brushes.Black, New RectangleF(0, 8, 240, printFont4.Height), formato)
        e.Graphics.DrawString(nombrelegal, printFont4, Brushes.Black, New RectangleF(0, 24, 240, printFont4.Height), formato)
        e.Graphics.DrawString("RTN: " + RTN, printFont4, Brushes.Black, New RectangleF(0, 40, 240, printFont4.Height), formato)
        e.Graphics.DrawString("Aldea Agua Dulce, Las Hadas", printFont4, Brushes.Black, New RectangleF(0, 56, 240, printFont4.Height), formato)
        e.Graphics.DrawString("Tegucigalpa, F.M., PBX", printFont4, Brushes.Black, New RectangleF(0, 72, 240, printFont4.Height), formato)
        e.Graphics.DrawString("2234-9595", printFont4, Brushes.Black, New RectangleF(0, 88, 240, printFont4.Height), formato)
        e.Graphics.DrawString(CORREO, printFont4, Brushes.Black, New RectangleF(0, 104, 240, printFont4.Height), formato)
        e.Graphics.DrawString("CIERRE DE CAJA LOTE " + id_loteventa.ToString, printFont4n, Brushes.Black, New RectangleF(0, 122, 240, printFont4n.Height), formato)
        Dim point As New Point(5, 139)
        Dim point1t As New Point(240, 139)
        e.Graphics.DrawLine(Pens.Black, point, point1t)
        e.Graphics.DrawString("POS#: " + id_pos.ToString, printFont5, Brushes.Black, 0, 142)
        e.Graphics.DrawString("Cajero: " + usuariotemp, printFont5, Brushes.Black, 70, 142)
        e.Graphics.DrawString("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy"), printFont5, Brushes.Black, 0, 158)
        e.Graphics.DrawString("Hora: " + DateTime.Now.ToString("hh:mm:ss.f"), printFont5, Brushes.Black, 130, 158)
        Dim point3 As New Point(5, 174)
        Dim point4 As New Point(240, 174)
        Dim efectivo As Decimal = 0
        Dim Tarjetacredito As Decimal = 0
        Dim Puntos As Decimal = 0
        Dim CreditoEmpleados As Decimal = 0
        Dim WildcartDisponible As Decimal = 0
        Dim Efectivodolar As Decimal = 0
        Dim CafeGratis As Decimal = 0
        Dim Carnet As Decimal = 0
        Dim total As Decimal = 0
        'CDbl(Me.txtefectivo.Text)
        If (Me.txtefectivo.Text <> "") Then
            efectivo = CDbl(Me.txtefectivo.Text)
        End If
        If (Me.txttarjeta.Text <> "") Then
            Tarjetacredito = CDbl(Me.txttarjeta.Text)
        End If
        If (Me.txtpuntos.Text <> "") Then
            Puntos = CDbl(Me.txtpuntos.Text)
        End If
        If (Me.txtempleados.Text <> "") Then
            CreditoEmpleados = CDbl(Me.txtempleados.Text)
        End If
        If (Me.txtwildacart.Text <> "") Then
            WildcartDisponible = CDbl(Me.txtwildacart.Text)
        End If
        If (Me.txtdolares.Text <> "") Then
            Efectivodolar = CDbl(Me.txtdolares.Text)
        End If
        If (Me.txtcafe.Text <> "") Then
            CafeGratis = CDbl(Me.txtcafe.Text)
        End If
        If (Me.txtcarnet.Text <> "") Then
            Carnet = CDbl(Me.txtcarnet.Text)
        End If
        e.Graphics.DrawString("Datos Cajero", printFont, Brushes.Black, New RectangleF(0, 176, 240, printFont4n.Height), formato)
        e.Graphics.DrawString("Efectivo: " + efectivo.ToString("#,##0.00"), printFont5, Brushes.Black, 0, 192)
        e.Graphics.DrawString("Tarjeta de credito: " + Tarjetacredito.ToString("#,##0.00"), printFont5, Brushes.Black, 0, 208)
        e.Graphics.DrawString("Puntos: " + Puntos.ToString("#,##0.00"), printFont5, Brushes.Black, 0, 224)
        e.Graphics.DrawString("Credito Empleados: " + CreditoEmpleados.ToString("#,##0.00"), printFont5, Brushes.Black, 0, 240)
        e.Graphics.DrawString("Wildcart Disponible: " + WildcartDisponible.ToString("#,##0.00"), printFont5, Brushes.Black, 0, 256)
        e.Graphics.DrawString("Efectivo $: " + Efectivodolar.ToString("#,##0.00"), printFont5, Brushes.Black, 0, 272)
        e.Graphics.DrawString("Cafe Gratis: " + CafeGratis.ToString("#,##0.00"), printFont5, Brushes.Black, 0, 288)
        e.Graphics.DrawString("Carnet: " + Carnet.ToString("#,##0.00"), printFont5, Brushes.Black, 0, 304)
        Dim y As Integer = 320
        Dim y2 As New Point(5, y)
        Dim y1 As New Point(240, y)
        e.Graphics.DrawLine(Pens.Black, y2, y1)
        y = y + 5
        Dim efect As Decimal = 0
        Dim camb As Decimal = 0
        Dim sqlcierre As String = "select tipo as TipoPago, monto as MontoLempiras, dolar as MontoDolar, id  from vistaCierreinformativo where idloteventa = '" + id_loteventa.ToString + "'"
        Dim adaptador As New OdbcDataAdapter(sqlcierre, conexion)
        Dim data As New DataSet
        Dim cont As Integer = 1
        adaptador.Fill(data, "vistaCierreinformativo")
        adaptador.FillSchema(data.Tables("vistaCierreinformativo"), SchemaType.Source)
        e.Graphics.DrawString("Datos Connect", printFont, Brushes.Black, New RectangleF(0, y, 240, printFont4n.Height), formato)
        Dim efec As Decimal = 0
        Dim Tarj As Decimal = 0
        Dim Pun As Decimal = 0
        Dim Credi As Decimal = 0
        Dim Wild As Decimal = 0
        Dim Efedolar As Decimal = 0
        Dim Cafe As Decimal = 0
        Dim Carn As Decimal = 0
        Dim DescuentoEmpleados As Decimal = 0
        Dim cambio As Decimal = 0
        For Each dr As DataRow In data.Tables("vistaCierreinformativo").Rows
            y = y + 16
            If dr.Item(0).ToString = "Efectivo $" Then
                Efedolar = CDbl(dr.Item(2).ToString)
                e.Graphics.DrawString(dr.Item(0).ToString + ": " + CDbl(dr.Item(2).ToString).ToString("#,##0.00"), printFont4, Brushes.Black, New RectangleF(0, y, 240, printFont4.Height), form)
            Else
                If dr.Item(0).ToString = "Efectivo" Then
                    efec = CDbl(dr.Item(1).ToString)
                End If
                If dr.Item(0).ToString = "Tarjeta de credito" Then
                    Tarj = CDbl(dr.Item(1).ToString)
                End If
                If dr.Item(0).ToString = "Puntos" Then
                    Pun = CDbl(dr.Item(1).ToString)
                End If
                If dr.Item(0).ToString = "Credito Empleados" Then
                    Credi = CDbl(dr.Item(1).ToString)
                End If
                If dr.Item(0).ToString = "Wildcart Disponible" Then
                    Wild = CDbl(dr.Item(1).ToString)
                End If
                If dr.Item(0).ToString = "Cafe Gratis" Then
                    Cafe = CDbl(dr.Item(1).ToString)
                End If
                If dr.Item(0).ToString = "Carnet" Then
                    Carn = CDbl(dr.Item(1).ToString)
                End If
                If dr.Item(0).ToString = "Descuento Empleados" Then
                    DescuentoEmpleados = CDbl(dr.Item(1).ToString)
                End If
                If dr.Item(0).ToString = "Cambio" Then
                    cambio = CDbl(dr.Item(1).ToString)
                End If
                e.Graphics.DrawString(dr.Item(0).ToString + ": " + CDbl(dr.Item(1).ToString).ToString("#,##0.00"), printFont4, Brushes.Black, New RectangleF(0, y, 240, printFont4.Height), form)
            End If

        Next
        y = y + 16
        e.Graphics.DrawString("Monto Inicial: " + lblMontoInicial.Text, printFont3, Brushes.Black, 0, y)
        y = y + 16
        Dim yt As New Point(5, y)
        Dim yt1 As New Point(240, y)
        e.Graphics.DrawLine(Pens.Black, yt, yt1)
        e.Graphics.DrawString("Verificación", printFont4, Brushes.Black, New RectangleF(0, 8, 240, printFont4.Height), formato)
        y = y + 16
        e.Graphics.DrawString("Connect", printFont5, Brushes.Black, New RectangleF(0, y, 80, printFont5.Height), formato)
        e.Graphics.DrawString("Usuario", printFont5, Brushes.Black, New RectangleF(80, y, 80, printFont5.Height), formato)
        e.Graphics.DrawString("Dif.", printFont5, Brushes.Black, New RectangleF(160, y, 80, printFont5.Height), formato)
        y = y + 16
        '------------------------------------------
        e.Graphics.DrawString("Efectivo", printFont2, Brushes.Black, 0, y)
        y = y + 16
        'efectivo = CDec(1293.32)
        e.Graphics.DrawString(efec.ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(0, y, 80, printFont5.Height), formato)
        e.Graphics.DrawString(efectivo.ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(80, y, 80, printFont5.Height), formato)
        Dim sum As Decimal = (efec) - (efectivo - montoinicio + cambio)
        Dim cad As String = ""
        If sum > 0 Then
            cad = "-" + sum.ToString("#,##0.00")
        Else
            cad = "+" + (-1 * sum).ToString("#,##0.00")
        End If
        e.Graphics.DrawString(cad, printFont5, Brushes.Black, New RectangleF(160, y, 80, printFont5.Height), formato)
        '------------------------------------------
        y = y + 16
        e.Graphics.DrawString("Tarjeta de credito", printFont2, Brushes.Black, 0, y)
        y = y + 16
        e.Graphics.DrawString(Tarj.ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(0, y, 80, printFont5.Height), formato)
        e.Graphics.DrawString(Tarjetacredito.ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(80, y, 80, printFont5.Height), formato)
        sum = Tarj - Tarjetacredito
        cad = ""
        If sum > 0 Then
            cad = "-" + sum.ToString("#,##0.00")
        Else
            cad = "+" + (-1 * sum).ToString("#,##0.00")
        End If
        e.Graphics.DrawString(cad, printFont5, Brushes.Black, New RectangleF(160, y, 80, printFont5.Height), formato)
        '------------------------------------------
        y = y + 16
        e.Graphics.DrawString("Puntos", printFont2, Brushes.Black, 0, y)
        y = y + 16
        e.Graphics.DrawString(Pun.ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(0, y, 80, printFont5.Height), formato)
        e.Graphics.DrawString(Puntos.ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(80, y, 80, printFont5.Height), formato)
        sum = Pun - Puntos
        cad = ""
        If sum > 0 Then
            cad = "-" + sum.ToString("#,##0.00")
        Else
            cad = "+" + sum.ToString("#,##0.00")
        End If
        e.Graphics.DrawString(cad, printFont5, Brushes.Black, New RectangleF(160, y, 80, printFont5.Height), formato)
        '------------------------------------------
        y = y + 16
        e.Graphics.DrawString("Credito Empleados", printFont2, Brushes.Black, 0, y)
        y = y + 16
        e.Graphics.DrawString(Credi.ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(0, y, 80, printFont5.Height), formato)
        e.Graphics.DrawString(CreditoEmpleados.ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(80, y, 80, printFont5.Height), formato)
        sum = Credi - CreditoEmpleados
        cad = ""
        If sum > 0 Then
            cad = "-" + sum.ToString("#,##0.00")
        Else
            cad = "+" + sum.ToString("#,##0.00")
        End If
        e.Graphics.DrawString(cad, printFont5, Brushes.Black, New RectangleF(160, y, 80, printFont5.Height), formato)
        '------------------------------------------
        y = y + 16
        e.Graphics.DrawString("Descuento Empleados", printFont2, Brushes.Black, 0, y)
        y = y + 16
        e.Graphics.DrawString(DescuentoEmpleados.ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(0, y, 80, printFont5.Height), formato)
        e.Graphics.DrawString("0.00", printFont5, Brushes.Black, New RectangleF(80, y, 80, printFont5.Height), formato)
        sum = DescuentoEmpleados
        cad = ""
        If sum > 0 Then
            cad = "-" + sum.ToString("#,##0.00")
        Else
            cad = "+" + sum.ToString("#,##0.00")
        End If
        e.Graphics.DrawString(cad, printFont5, Brushes.Black, New RectangleF(160, y, 80, printFont5.Height), formato)
        '------------------------------------------
        y = y + 16
        e.Graphics.DrawString("Wildcart Disponible", printFont2, Brushes.Black, 0, y)
        y = y + 16
        e.Graphics.DrawString(Wild.ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(0, y, 80, printFont5.Height), formato)
        e.Graphics.DrawString(WildcartDisponible.ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(80, y, 80, printFont5.Height), formato)
        sum = Wild - WildcartDisponible
        cad = ""
        If sum > 0 Then
            cad = "-" + sum.ToString("#,##0.00")
        Else
            cad = "+" + sum.ToString("#,##0.00")
        End If
        e.Graphics.DrawString(cad, printFont5, Brushes.Black, New RectangleF(160, y, 80, printFont5.Height), formato)
        '------------------------------------------
        y = y + 16
        e.Graphics.DrawString("Efectivo $", printFont2, Brushes.Black, 0, y)
        y = y + 16
        e.Graphics.DrawString(CDec(Efedolar * tasa).ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(0, y, 80, printFont5.Height), formato)
        e.Graphics.DrawString((Efectivodolar).ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(80, y, 80, printFont5.Height), formato)
        sum = (Efedolar * tasa) - Efectivodolar
        cad = ""
        If sum > 0 Then
            cad = "-" + sum.ToString("#,##0.00")
        Else
            cad = "+" + sum.ToString("#,##0.00")
        End If
        e.Graphics.DrawString(cad, printFont5, Brushes.Black, New RectangleF(160, y, 80, printFont5.Height), formato)
        '------------------------------------------
        y = y + 16
        e.Graphics.DrawString("Cafe Gratis", printFont2, Brushes.Black, 0, y)
        y = y + 16
        e.Graphics.DrawString(Cafe.ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(0, y, 80, printFont5.Height), formato)
        e.Graphics.DrawString(CafeGratis.ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(80, y, 80, printFont5.Height), formato)
        sum = Cafe - CafeGratis
        cad = ""
        If sum > 0 Then
            cad = "-" + sum.ToString("#,##0.00")
        Else
            cad = "+" + sum.ToString("#,##0.00")
        End If
        e.Graphics.DrawString(cad, printFont5, Brushes.Black, New RectangleF(160, y, 80, printFont5.Height), formato)
        '------------------------------------------
        y = y + 16
        e.Graphics.DrawString("Carnet", printFont2, Brushes.Black, 0, y)
        y = y + 16
        e.Graphics.DrawString(Carnet.ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(0, y, 80, printFont5.Height), formato)
        e.Graphics.DrawString(Carn.ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(80, y, 80, printFont5.Height), formato)
        sum = Carn - Carnet
        cad = ""
        If sum > 0 Then
            cad = "-" + sum.ToString("#,##0.00")
        Else
            cad = "+" + sum.ToString("#,##0.00")
        End If
        e.Graphics.DrawString(cad, printFont5, Brushes.Black, New RectangleF(160, y, 80, printFont5.Height), formato)
        '------------------------------------------
        y = y + 16
        e.Graphics.DrawString("---------------------------------------", printFont3, Brushes.Black, 0, y)
        'conexion.Close()
        Me.Close()
        My.Forms.frmlotesventa.pgconection = conexion
        My.Forms.frmlotesventa.Show()
    End Sub


    Public Sub tempo()
        Dim efectivo As Decimal = 0
        Dim Tarjetacredito As Decimal = 0
        Dim Puntos As Decimal = 0
        Dim CreditoEmpleados As Decimal = 0
        Dim WildcartDisponible As Decimal = 0
        Dim Efectivodolar As Decimal = 0
        Dim CafeGratis As Decimal = 0
        Dim Carnet As Decimal = 0
        Dim total As Decimal = 0
        'CDbl(Me.txtefectivo.Text)

        If (Me.txtefectivo.Text <> "") Then
            efectivo = CDbl(Me.txtefectivo.Text)
        End If
        If (Me.txttarjeta.Text <> "") Then
            Tarjetacredito = CDbl(Me.txttarjeta.Text)
        End If
        If (Me.txtpuntos.Text <> "") Then
            Puntos = CDbl(Me.txtpuntos.Text)
        End If
        If (Me.txtempleados.Text <> "") Then
            CreditoEmpleados = CDbl(Me.txtempleados.Text)
        End If
        If (Me.txtwildacart.Text <> "") Then
            WildcartDisponible = CDbl(Me.txtwildacart.Text)
        End If
        If (Me.txtdolares.Text <> "") Then
            Efectivodolar = CDbl(Me.txtdolares.Text)
        End If
        If (Me.txtcafe.Text <> "") Then
            CafeGratis = CDbl(Me.txtcafe.Text)
        End If
        If (Me.txtcarnet.Text <> "") Then
            Carnet = CDbl(Me.txtcarnet.Text)
        End If
        total = efectivo + Tarjetacredito + Puntos + CreditoEmpleados + WildcartDisponible + Efectivodolar + CafeGratis + Carnet
        Me.lblTotal.Text = CInt(total).ToString("#,##0.00")
    End Sub



    Private Sub btnregresar_Click(sender As Object, e As EventArgs) Handles btnregresar.Click
        My.Forms.POSVENTA.pgconection = conexion
        My.Forms.POSVENTA.Show()
        Me.Close()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub frmCierre_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conexion = pgconection
        con.openConection(conexion)
        comando = New OdbcCommand("select * from detalleLoteventa where idloteventa ='" + id_loteventa.ToString + "' limit 1", conexion)
        LECTOR = comando.ExecuteReader
        If LECTOR.Read Then
            lblMontoInicial.Text = "L." + CDbl(LECTOR(0).ToString()).ToString("#,##0.00")
            lblcajero.Text = usuariotemp
            lblfecha.Text = LECTOR(12).ToString()
            lbllote.Text = id_loteventa.ToString
        End If
        'Dim sql As String = "select idmetodopago,SUM(monto) from detalleLoteventa WHERE idloteventa = " + id_loteventa.ToString + " GROUP BY idmetodopago;"
        'comando = New OdbcCommand(sql, conexion)
        'LECTOR = comando.ExecuteReader
        'If LECTOR.HasRows Then
        '    While LECTOR.Read
        '        If (LECTOR(0) = metodospago.efectivo) Then
        '            txtefectivo.Text = LECTOR(1).ToString
        '        ElseIf (LECTOR(0) = metodospago.tarjeta) Then
        '            txttarjeta.Text = LECTOR(1).ToString
        '        ElseIf (LECTOR(0) = metodospago.puntos) Then
        '            txtpuntos.Text = LECTOR(1).ToString
        '        ElseIf (LECTOR(0) = metodospago.creditoempleado) Then
        '            txtempleados.Text = LECTOR(1).ToString
        '        ElseIf (LECTOR(0) = metodospago.wildcard) Then
        '            txtwildacart.Text = LECTOR(1).ToString
        '        ElseIf (LECTOR(0) = metodospago.efectivodollar) Then
        '            txtdolares.Text = LECTOR(1).ToString
        '        ElseIf (LECTOR(0) = metodospago.cafegratis) Then
        '            txtcafe.Text = LECTOR(1).ToString
        '        End If
        '    End While
        'End If
        Dim adaptador As New OdbcDataAdapter("select tipo as TipoPago, monto as Lempiras, dolar as Dolares  from vistaCierreinformativo where idloteventa = '" + id_loteventa.ToString + "' and tipo in ('Cafe Gratis','Credito Empleados')", conexion)
        Dim data As New DataSet
        Dim cont As Integer = 1
        adaptador.Fill(data, "vistaCierreinformativo")
        Me.DataGridView1.DataSource = data.Tables("vistaCierreinformativo")
        Me.DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill


        comando = New OdbcCommand("select  * from tbl_cambioactual", conexion)
        LECTOR = comando.ExecuteReader
        If LECTOR.Read Then
            tasa = CDbl(LECTOR(1).ToString)
        End If

    End Sub

    Private Sub txtdolares_Leave(sender As Object, e As EventArgs) Handles txtdolares.Leave
        Try
            Dim d As Decimal = Convert.ToDecimal(txtdolares.Text)
            Dim a = d * tasa
            txtdolares.Text = a.ToString
        Catch ex As Exception
            txtdolares.Text = ""
        End Try
    End Sub

    Private Sub txtefectivo_TextChanged(sender As Object, e As EventArgs) Handles txtwildacart.TextChanged, txttarjeta.TextChanged, txtpuntos.TextChanged, txtempleados.TextChanged, txtefectivo.TextChanged, txtdolares.TextChanged, txtcarnet.TextChanged, txtcafe.TextChanged
        If sender.Text <> "" Then
            Try
                Dim n As Decimal = (Convert.ToDecimal(sender.Text) / 2)

            Catch ex As Exception
                MessageBox.Show("Solo se permiten numeros en los campos.")
            End Try
        End If
    End Sub
End Class