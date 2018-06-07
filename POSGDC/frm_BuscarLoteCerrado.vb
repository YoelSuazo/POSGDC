Imports System.Data.Odbc

Public Class frm_BuscarLoteCerrado


    Dim conexion As New Odbc.OdbcConnection()
    Dim comando As New Odbc.OdbcCommand
    Dim LECTOR As OdbcDataReader
    Dim ventatipo As Integer = 0
    Dim idlotecerrado As Integer = 0
    Dim CAI As String
    Dim RTN As String
    Dim CORREO As String
    Dim NombreSociedad As String
    Dim nombrelegal As String


    Dim efectivo As Decimal = 0
    Dim Tarjetacredito As Decimal = 0
    Dim Puntos As Decimal = 0
    Dim CreditoEmpleados As Decimal = 0
    Dim WildcartDisponible As Decimal = 0
    Dim Efectivodolar As Decimal = 0
    Dim CafeGratis As Decimal = 0
    Dim Carnet As Decimal = 0
    Dim total As Decimal = 0
    Dim montoInicialcerrado As Decimal = 0




    Public Property pgconection() As OdbcConnection
        Set(value As OdbcConnection)
            conexion = value
        End Set
        Get
            Return Me.conexion
        End Get
    End Property


    Private Sub btnbuscar_Click(sender As Object, e As EventArgs) Handles btnbuscar.Click

        Dim fechafin As String = dtpfechafinal.Value.ToString("yyyy/MM/dd")
        Dim fechaini As String = dtpfechainicial.Value.ToString("yyyy/MM/dd")
        If (fechaini > fechafin) Then
            MessageBox.Show("Error en el rango de las fechas.", "Fechas incorrectas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            cargartipoloteFechas(fechaini, fechafin)
        End If
    End Sub


    Private Function cargartipoloteFechas(fechainicial As String, fechafinal As String)
        Me.dgvlotescerrados.Rows.Clear()
        Dim sql = "select id, to_char(fechahorai, 'DD/MM/YYYY, HH12:MI:SS') as hori ,montoinicial  from tbl_pos_loteventa where estado = false and "
        sql += "idposventa='" + sessiones.id_pos.ToString
        sql += "' and tipolote=" + ventatipo.ToString
        sql += " and fecha_creacion between '" + fechainicial + "' and '" + fechafinal
        sql += "' order by id desc;"
        Console.WriteLine(sql)
        Dim adaptador3 As New OdbcDataAdapter(sql, conexion)
        Dim datan As New DataSet
        adaptador3.Fill(datan, "tbl_pos_loteventa")
        adaptador3.FillSchema(datan.Tables("tbl_pos_loteventa"), SchemaType.Source)
        For Each dr As DataRow In datan.Tables("tbl_pos_loteventa").Rows
            dgvlotescerrados.Rows.Add(dr.Item(0).ToString, dr.Item(1).ToString, dr.Item(2).ToString)
        Next
    End Function

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        ventatipo = 0
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        ventatipo = 1
    End Sub

    Private Sub btnaceptar_Click(sender As Object, e As EventArgs) Handles btnaceptar.Click
        If idlotecerrado = 0 Then
            MessageBox.Show("No se ha seleccionado ningun lote.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Dim sql As String = "select efectivo,tarjetacredito,puntos,creditoempleados,wildcartdisponible,efectivodolar,cafegratis,carnet,montoinicial"
            sql += "  from tbl_pos_loteventa "
            sql += " where estado = false "
            sql += "and id='" + idlotecerrado.ToString + "'"
            comando = New OdbcCommand(sql, conexion)
            LECTOR = comando.ExecuteReader()
            If LECTOR.Read Then
                efectivo = Convert.ToDecimal(LECTOR(0).ToString)
                Tarjetacredito = Convert.ToDecimal(LECTOR(1).ToString)
                Puntos = Convert.ToDecimal(LECTOR(2).ToString)
                CreditoEmpleados = Convert.ToDecimal(LECTOR(3).ToString)
                WildcartDisponible = Convert.ToDecimal(LECTOR(4).ToString)
                Efectivodolar = Convert.ToDecimal(LECTOR(5).ToString)
                CafeGratis = Convert.ToDecimal(LECTOR(6).ToString)
                Carnet = Convert.ToDecimal(LECTOR(7).ToString)
                montoInicialcerrado = Convert.ToDecimal(LECTOR(8).ToString)
                total = efectivo + Tarjetacredito + Puntos + CreditoEmpleados + WildcartDisponible + Efectivodolar + CafeGratis + Carnet
            End If
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

    End Sub

    Private Sub dgvlotescerrados_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvlotescerrados.CellClick
        idlotecerrado = Convert.ToInt32(CStr(dgvlotescerrados.Rows(dgvlotescerrados.CurrentRow.Index).Cells(0).Value))
        lblnumeroloteimp.Text = "Numero de Lote: " + idlotecerrado.ToString
    End Sub

    Private Sub btncancelar_Click(sender As Object, e As EventArgs) Handles btncancelar.Click
        Me.Close()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
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
        e.Graphics.DrawString(NombreSociedad, printFont4, Brushes.Black, New RectangleF(0, 8, 240, printFont4.Height), formato)
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
        'Dim efectivo As Decimal = 0
        'Dim Tarjetacredito As Decimal = 0
        'Dim Puntos As Decimal = 0
        'Dim CreditoEmpleados As Decimal = 0
        'Dim WildcartDisponible As Decimal = 0
        'Dim Efectivodolar As Decimal = 0
        'Dim CafeGratis As Decimal = 0
        'Dim Carnet As Decimal = 0
        'Dim total As Decimal = 0

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
        Dim adaptador As New OdbcDataAdapter("select tipo as TipoPago, monto as MontoLempiras, dolar as MontoDolar, id  from vistaCierreinformativo where idloteventa = '" + id_loteventa.ToString + "'", conexion)
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
                e.Graphics.DrawString(dr.Item(0).ToString + ": " + CDbl(dr.Item(1).ToString).ToString("#,##0.00"), printFont4, Brushes.Black, New RectangleF(0, y, 240, printFont4.Height), form)
            End If
        Next
        y = y + 16
        e.Graphics.DrawString("Monto Inicial: " + montoInicialcerrado.ToString, printFont3, Brushes.Black, 0, y)
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
        e.Graphics.DrawString("Efectivo", printFont2, Brushes.Black, 0, y)
        y = y + 16
        e.Graphics.DrawString(efec.ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(0, y, 80, printFont5.Height), formato)
        e.Graphics.DrawString(efectivo.ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(80, y, 80, printFont5.Height), formato)
        Dim sum As Decimal = efec - (efectivo - montoinicio)
        Dim cad As String = ""
        If sum > 0 Then
            cad = "-" + sum.ToString("#,##0.00")
        Else
            cad = "+" + sum.ToString("#,##0.00")
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
            cad = "+" + sum.ToString("#,##0.00")
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
        e.Graphics.DrawString("---------------------------------------", printFont3, Brushes.Black, 0, y)
        'conexion.Close()
        Me.Close()
    End Sub
End Class