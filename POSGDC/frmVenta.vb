Imports System.Data.Odbc
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Data
Imports System.Globalization
Imports System.Threading
Imports System.Drawing
Imports System
Imports POSGDC.conexion

Public Class frmVenta
    Dim con As New conexion
    Dim conexion As New Odbc.OdbcConnection()
    'Dim conexion As New Odbc.OdbcConnection("DSN=ORIECOMP")
    Dim comando As New Odbc.OdbcCommand
    Dim LECTOR As OdbcDataReader
    Dim datan As New DataSet
    Dim valcod As String
    Dim datan2 As New DataSet
    Dim Dv As New DataView
    Dim totalapagar As Decimal
    Dim CAI As String
    Dim RTN As String
    Dim CORREO As String
    Dim NombreSociedad As String
    Dim rgInicio As String
    Dim rgFinal As String
    Dim fechalimite As String
    Dim nombrelegal As String
    Dim reimprime As String
    Dim numeroventa As Integer
    Dim canti As Decimal = 0
    Dim facanterior As String
    Dim imprimirFact As New imprimir
    Public recargaCarnet As String = ""

    Public vistaItemsPreventa As String = ""
    Dim venta_actual As Integer = 0
    Public id_recibo_preventa As Integer = 0
    Public preventa_a_empleado As String = "no"
    Public nombre_cliente As String = ""
    Public codigo_cliente As String = ""

    Public Property facturaanterior() As String
        Set(fa As String)
            facanterior = fa
        End Set
        Get
            Return facanterior
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

    Private Sub frmVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conexion = pgconection
        codigoEmpleado = ""
        vistaItemsPreventa = "no"
        preventa_a_empleado = "no"
        System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
        con.openConection(conexion)
        Me.Enabled = False
        idventa = 0
        Activacafe = 0
        lblAlmacen.Text = sessiones.almacen
        lblUsuario.Text = sessiones.usuario
        lblnomlo.Text = "Lote de ventas: " + sessiones.id_loteventa.ToString
        txtCodigo.Enabled = False
        txtcod.Text = ""
        lblnombrecliente.Text = ""
        ListView1.Visible = False
        Button4.Enabled = False
        btnar.Enabled = False
        Button1.Enabled = False
        btn_reimprimir.Enabled = False
        btnActualizarInventario.Enabled = False
        btnar.Enabled = False
        btncargalista.Enabled = False
        lstventaespera.Enabled = False
        cmbTipo.Items.Clear()
        Dim adaptador As New OdbcDataAdapter("select * from tiposclientes", conexion)
        Dim data As New DataSet
        adaptador.Fill(data, "tiposclientes")
        'adaptador.FillSchema(data.Tables("tiposclientes"), SchemaType.Source)
        Dim tbd As New DataTable
        tbd.Columns.Add("Text", GetType(String))
        tbd.Columns.Add("Value", GetType(Integer))
        For Each dr As DataRow In data.Tables("tiposclientes").Rows
            If (dr.Item(1).ToString = "Normal") Then
                tbd.Rows.Add("Consumidor Final", dr.Item(0))
            Else
                tbd.Rows.Add(dr.Item(1).ToString, dr.Item(0))
            End If
            'Me.lsPendienteLotes.Items.Add(dr.Item(0).ToString + " " + dr.Item(1).ToString)
        Next
        cmbTipo.DisplayMember = "Text"
        cmbTipo.ValueMember = "Value"
        cmbTipo.DataSource = tbd
        cmbTipo.Text = "Consumidor Final"
        cambiotipoventa(tipoventa)
        Dim th As New Thread(AddressOf CargarProductos)
        th.Start()
    End Sub

    Private Sub frmVenta_Shown(sender As Object, e As EventArgs) Handles Me.Shown

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btncancela.Click
        empleadoventa = "no"
        lblnombrecliente.Text = ""
        txtcod.Text = ""
        ListView1.Enabled = False
        txtbusqeda.Enabled = False
        Me.btncancela.Enabled = False
        Me.btnespera.Enabled = False
        Me.btnpago.Enabled = False
        Me.btn_reimprimir.Enabled = False
        Me.btnbeneficio.Enabled = False
        Me.Button4.Enabled = True
        Me.txtCodigo.Text = ""
        Me.txtCodigo.Enabled = False
        DataGridView1.Rows.Clear()
        'tipoventa = 0
        'cambiotipoventa(tipoventa)
        Me.lblSub.Text = "L. 0.00"
        Me.lbltotal.Text = "L. 0.00"
        Me.lblimp.Text = "L. 0.00"
        Activacafe = 0

        If id_recibo_preventa = 0 Then
            comando = New Odbc.OdbcCommand("DELETE FROM tbl_pos_ventamaterial  WHERE id= '" + idventa.ToString + "'", conexion)
            comando.ExecuteNonQuery()
        End If

        'id_recibo_preventa = 0
        'Dim adaptador3 As New OdbcDataAdapter("SELECT id, to_char(fechahorai, 'DD/MM/YYYY, HH12:MI:SS') as hori, nombre FROM tbl_pos_venta where estado = '1' and idloteventa='" + sessiones.id_loteventa.ToString + "'", conexion)
        'Dim datan As New DataSet
        'adaptador3.Fill(datan, "tbl_pos_venta")
        'adaptador3.FillSchema(datan.Tables("tbl_pos_venta"), SchemaType.Source)
        'Dim tb As New DataTable
        'tb.Columns.Add("Text", GetType(String))
        'tb.Columns.Add("Value", GetType(Integer))
        'For Each dr As DataRow In datan.Tables("tbl_pos_venta").Rows
        '    tb.Rows.Add(dr.Item(0).ToString + " " + dr.Item(2).ToString, dr.Item(0))
        '    'Me.lsPendienteLotes.Items.Add(dr.Item(0).ToString + " " + dr.Item(1).ToString)
        'Next
        ''conexion.Close()
        'lstventaespera.DisplayMember = "Text"
        'lstventaespera.ValueMember = "Value"
        'lstventaespera.DataSource = tb

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        empleadoventa = "no"
        If idventa.ToString <> 0 Then
            facturaanterior = idventa.ToString
        End If
        con.openConection(conexion)
        comando = New OdbcCommand("select fn_vtinsertaventa('" + sessiones.id_loteventa.ToString + "','" + sessiones.id_usuario.ToString + "','" + sessiones.tipoventa.ToString + "')", conexion)
        LECTOR = comando.ExecuteReader
        If LECTOR.Read Then ' lee la consulta
            idventa = LECTOR(0)
            lblnombrefactura.Text = "Numero Factura: " + idventa.ToString
            numeroventa = idventa
            txtCodigo.Enabled = True
            txtCodigo.Focus()
            Me.btncancela.Enabled = True
            Me.btnespera.Enabled = True
            Me.btnpago.Enabled = True
            Me.Button4.Enabled = False
            btnbeneficio.Enabled = True
            Me.Button2.Enabled = True
            ListView1.Enabled = True
            txtbusqeda.Enabled = True
            btnar.Enabled = True
            btncargalista.Enabled = True
            btnConsultasaldo.Enabled = False
            btnActualizarInventario.Enabled = True
            lstventaespera.Enabled = True
        End If

        If tipoventa = 1 Then
            btnReciboPreventa.Enabled = True
            btnbeneficio.Enabled = False
            'btncancela.Enabled = False
            btnespera.Enabled = True
            btnpago.Enabled = False
            lblboletapreventa.Visible = False
        Else
            btnReciboPreventa.Enabled = False
            lblboletapreventa.Visible = True
        End If
    End Sub

    Private Sub txtCodigo_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            InsertaFila(txtCodigo.Text)
            txtCodigo.Focus()
        End If
    End Sub

    Private Sub frmVenta_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        'nueva preventa
        If e.KeyCode = Keys.F3 Then
            If (Button4.Enabled <> False) Then
                Button4.PerformClick()
            End If

            ''tipoventa = 1
            ''cambiotipoventa(tipoventa)
            'con.openConection(conexion)
            'comando = New OdbcCommand("select fn_vtinsertaventa('" + sessiones.id_loteventa.ToString + "','" + sessiones.id_usuario.ToString + "','" + sessiones.tipoventa.ToString + "')", conexion)
            'LECTOR = comando.ExecuteReader
            'If LECTOR.Read Then ' lee la consulta

            '    idventa = LECTOR(0)
            '    'txtCodigo.Enabled = True
            '    'txtCodigo.Focus()
            '    Me.btncancela.Enabled = True
            '    Me.btnespera.Enabled = True
            '    Me.btnpago.Enabled = True
            '    Me.Button4.Enabled = False
            '    DataGridView1.Rows.Clear()

            '    Me.lblSub.Text = "L. 0.00"
            '    Me.lbltotal.Text = "L. 0.00"
            '    Me.lblimp.Text = "L. 0.00"

            'End If

        End If

        If e.KeyCode = Keys.F9 Then
            'valcod = InputBox("Codigo del Material :-> ", "Codigo del material", "")
            If idventa = 0 Then
                MsgBox("Debe crear una nueva venta", MsgBoxStyle.Information)
            Else
                If Activacafe = 1 Then
                    My.Forms.frmBusquedaBeneficios.pgconection = conexion
                    My.Forms.frmBusquedaBeneficios.Show()
                Else
                    Me.txtbusqeda.Focus()
                    'My.Forms.frmbusqueda.pgconection = conexion
                    'My.Forms.frmbusqueda.ShowDialog()
                End If

            End If

        End If
        ' nueva venta
        If e.KeyCode = Keys.F8 Then
            txtCodigo.Focus()
            'If Button4.Enabled <> False Then
            '    Button4.PerformClick()
            'End If
            ''tipoventa = 0
            ''cambiotipoventa(tipoventa)
            'comando = New OdbcCommand("select fn_vtinsertaventa('" + sessiones.id_loteventa.ToString + "','" + sessiones.id_usuario.ToString + "','" + sessiones.tipoventa.ToString + "')", conexion)
            'LECTOR = comando.ExecuteReader
            'If LECTOR.Read Then ' lee la consulta
            '    idventa = LECTOR(0)
            '    txtCodigo.Enabled = True
            '    txtCodigo.Focus()
            '    DataGridView1.Rows.Clear()

            '    Me.lblSub.Text = "L. 0.00"
            '    Me.lbltotal.Text = "L. 0.00"
            '    Me.lblimp.Text = "L. 0.00"
            '    Me.btncancela.Enabled = True
            '    Me.btnespera.Enabled = True
            '    Me.btnpago.Enabled = True
            '    Me.Button4.Enabled = False
            '    Me.btnbeneficio.Enabled = True
            '    Me.txtbusqeda.Enabled = True
            '    Me.ListView1.Enabled = True
            'End If
            'conexion.Close()

        End If
        ' cancelar
        'If e.KeyCode = Keys.F12 Then
        '    Me.btncancela.Enabled = False
        '    Me.btnespera.Enabled = False
        '    Me.btnpago.Enabled = False
        '    Me.Button4.Enabled = True
        '    Me.txtCodigo.Text = ""
        'End If
        If e.KeyCode = Keys.F2 Then
            If tipoventa = 0 Then
                If (btnpago.Enabled <> False) Then
                    btnpago.PerformClick()
                End If
            Else
                If (btnReciboPreventa.Enabled <> False) Then
                    btnReciboPreventa.PerformClick()
                End If
            End If


            'If idventa = 0 Then
            '    MsgBox("Debe crear una nueva venta", MsgBoxStyle.Information)
            'Else
            '    TotalPago = 0

            '    comando = New OdbcCommand("select COALESCE(round(sum(subcan)::numeric,2),0) as subtot,COALESCE(round(sum(impcan)::numeric,2),0) as impuest,COALESCE(round(((round(sum(subcan)::numeric,2))+(round(sum(impcan)::numeric,2)))::numeric,2),0) as tot from detalleTotalmaterial where idventa ='" + idventa.ToString + "'", conexion)
            '    Dim LECTORt As OdbcDataReader
            '    LECTORt = comando.ExecuteReader
            '    Dim toto As Decimal = 0
            '    If LECTORt.Read Then
            '        subtotalSesion = CDbl(LECTORt(0).ToString)
            '        impSesion = CDbl(LECTORt(1).ToString)
            '        If Activacafe = 1 Then
            '            toto = CDbl(LECTORt(2).ToString)
            '        Else
            '            toto = Math.Round((CDbl(LECTORt(2).ToString)), 2, MidpointRounding.ToEven)
            '        End If
            '    End If
            '    TotalPago = toto
            '    disponible = toto

            '    My.Forms.frmMetodoPago.pgconection = conexion
            '    My.Forms.frmMetodoPago.ShowDialog()

            'End If

        End If
        If e.KeyCode = Keys.F1 And Button4.Enabled = False Then
            My.Forms.frmempleados.pgconection = conexion
            My.Forms.frmempleados.ShowDialog()
        End If
        If e.KeyCode = Keys.F12 And Button4.Enabled = False Then
            If (btnbeneficio.Enabled <> False) Then
                btnbeneficio.PerformClick()
            End If
            'Activacafe = 1
            'comando = New OdbcCommand("select fn_vtinsertaventa('" + sessiones.id_loteventa.ToString + "','" + sessiones.id_usuario.ToString + "','" + sessiones.tipoventa.ToString + "')", conexion)
            'LECTOR = comando.ExecuteReader
            'If LECTOR.Read Then ' lee la consulta
            '    idventa = LECTOR(0)
            '    DataGridView1.Rows.Clear()
            '    Me.lblSub.Text = "L. 0.00"
            '    Me.lbltotal.Text = "L. 0.00"
            '    Me.lblimp.Text = "L. 0.00"
            '    Me.btncancela.Enabled = True
            '    Me.btnespera.Enabled = True
            '    Me.btnpago.Enabled = True
            '    Me.Button4.Enabled = False
            '    Me.btnbeneficio.Enabled = True
            'End If

            'My.Forms.frmBusquedaBeneficios.pgconection = conexion
            'My.Forms.frmBusquedaBeneficios.ShowDialog()

        End If
        'If e.KeyCode = Keys.Escape Then
        '    If (Button1.Enabled <> False) Then
        '        My.Forms.frmlotesventa.pgconection = conexion
        '        My.Forms.frmlotesventa.Show()
        '        Me.Close()
        '    End If

        'End If

        If e.KeyCode = Keys.F4 Then
            If (btn_reimprimir.Enabled <> False) Then
                btn_reimprimir.PerformClick()
            End If
        End If

        If e.KeyCode = Keys.F5 Then
            If (btnar.Enabled <> False) Then
                btnar.PerformClick()
            End If
        End If
        If e.KeyCode = Keys.F6 Then
            If tipoventa = 0 And Button4.Enabled = False Then
                My.Forms.frmbusqueda.pgconection = conexion
                Dim f As New frmbusqueda
                f.pgconection = conexion
                f.ShowDialog()
            End If
        End If
    End Sub

    Public Sub InsertaFila(Codbarra As String)
        Dim sqlinsertarfila As String = "select * from vistaMaterialesventa WHERE codigo_barras='" + Codbarra + "' and idcentro='" + id_almacen.ToString + "'"
        comando = New OdbcCommand(sqlinsertarfila, conexion)
        Thread.CurrentThread.CurrentCulture = New CultureInfo("es-HN")
        LECTOR = comando.ExecuteReader
        Dim imp As Integer
        Dim valorimp As Decimal = 0
        Dim valorsub As Decimal = 0
        Dim valortotalproducto As Decimal = 0
        Dim idvt As String = ""
        If LECTOR.Read Then ' lee la consulta
            'inventario negativo=1
            If (LECTOR(10).ToString = "1") Then
                imp = Val(LECTOR(19))
                valorsub = CDec(Val(LECTOR(18)))
                valorimp = CDec(Val(LECTOR(22)))
                valortotalproducto = Math.Round(CDec(Val(LECTOR(23))), 2, MidpointRounding.ToEven)
                'validamos si estaa para venta
                If (LECTOR(8).ToString = "1") Then
                    'Validamos impuestos
                    If (LECTOR(9).ToString = "1") Then
                        comando = New OdbcCommand("select fn_vtinsertaItemsventa('" + idventa.ToString + "', '" + LECTOR(12).ToString + "', '" + valorsub.ToString + "', '" + valortotalproducto.ToString + "', '" + valorimp.ToString + "','1','" + LECTOR(7).ToString + "','" + LECTOR(19).ToString + "','" + LECTOR(18).ToString + "')", conexion)
                        Dim LECTORt As OdbcDataReader
                        LECTORt = comando.ExecuteReader
                        If LECTORt.Read Then
                            idvt = LECTORt(0).ToString
                        End If
                        If Activacafe = 1 Then
                            DataGridView1.Rows.Add("1", LECTOR(7).ToString, valorsub, valorimp, Math.Round(valortotalproducto, 2, MidpointRounding.ToEven), idvt, LECTOR(19).ToString, LECTOR(4).ToString, LECTOR(18).ToString, LECTOR(10).ToString, LECTOR(4).ToString)
                            'DataGridView1.Rows.Add("1", LECTOR(7).ToString, valorsub, valorimp, Math.Round(valortotalproducto, 2, MidpointRounding.ToEven), idvt, LECTOR(19).ToString, LECTOR(18).ToString, LECTOR(10).ToString, LECTOR(4).ToString)
                        Else
                            DataGridView1.Rows.Add("1", LECTOR(7).ToString, valorsub, valorimp, CDec(Math.Round(valortotalproducto, 2, MidpointRounding.ToEven)), idvt, LECTOR(19).ToString, LECTOR(4).ToString, LECTOR(18).ToString, LECTOR(10).ToString, LECTOR(4).ToString)
                            'DataGridView1.Rows.Add("1", LECTOR(7).ToString, valorsub, valorimp, CDec(Math.Round(valortotalproducto, 2, MidpointRounding.ToEven)), idvt, LECTOR(19).ToString, LECTOR(18).ToString, LECTOR(10).ToString, LECTOR(4).ToString)
                        End If

                    Else
                        comando = New OdbcCommand("select fn_vtinsertaItemsventa('" + idventa.ToString + "', '" + LECTOR(12).ToString + "', '" + valorsub.ToString + "', '" + valortotalproducto.ToString + "', '0','1','" + LECTOR(7).ToString + "','0','" + LECTOR(18).ToString + "')", conexion)
                        Dim LECTORt As OdbcDataReader
                        LECTORt = comando.ExecuteReader
                        If LECTORt.Read Then
                            idvt = LECTORt(0).ToString
                        End If
                        DataGridView1.Rows.Add("1", LECTOR(7).ToString, valorsub.ToString("#,##0.00"), "0.00", CDec(valortotalproducto), idvt, LECTOR(19).ToString, LECTOR(4).ToString, LECTOR(18).ToString, LECTOR(10).ToString, LECTOR(4).ToString)
                        'DataGridView1.Rows.Add("1", LECTOR(7).ToString, valorsub.ToString("#,##0.00"), "0.00", CDec(valortotalproducto), idvt, LECTOR(19).ToString, LECTOR(18).ToString, LECTOR(10).ToString, LECTOR(4).ToString)
                    End If
                Else
                    MsgBox("Material no disponible a la venta.", MsgBoxStyle.Critical)
                End If

            Else
                If (Val(LECTOR(4)) > 0) Then
                    imp = Val(LECTOR(19))
                    valorsub = CDec(Val(LECTOR(18)))
                    valorimp = CDec(Val(LECTOR(22)))
                    valortotalproducto = Math.Round(CDec(Val(LECTOR(23))), 2, MidpointRounding.ToEven)
                    'validamos si estaa para venta
                    If (LECTOR(8).ToString = "1") Then
                        'Validamos impuestos
                        If (LECTOR(9).ToString = "1") Then
                            comando = New OdbcCommand("select fn_vtinsertaItemsventa('" + idventa.ToString + "', '" + LECTOR(12).ToString + "', '" + valorsub.ToString + "', '" + valortotalproducto.ToString + "', '" + valorimp.ToString + "','1','" + LECTOR(7).ToString + "','" + LECTOR(19).ToString + "','" + LECTOR(18).ToString + "')", conexion)
                            Dim LECTORt As OdbcDataReader
                            LECTORt = comando.ExecuteReader
                            If LECTORt.Read Then
                                idvt = LECTORt(0).ToString
                            End If
                            'DataGridView1.Rows.Add("1", LECTOR(7).ToString, valorsub, valorimp, CDec(valortotalproducto), idvt, LECTOR(19).ToString, LECTOR(18).ToString, LECTOR(10).ToString, LECTOR(4).ToString)
                            DataGridView1.Rows.Add("1", LECTOR(7).ToString, valorsub, valorimp, CDec(valortotalproducto), idvt, LECTOR(19).ToString, LECTOR(4).ToString, LECTOR(18).ToString, LECTOR(10).ToString, LECTOR(4).ToString)
                            txtCodigo.Focus()
                        Else
                            comando = New OdbcCommand("select fn_vtinsertaItemsventa('" + idventa.ToString + "', '" + LECTOR(12).ToString + "', '" + valorsub.ToString + "', '" + valortotalproducto.ToString + "', '0','1','" + LECTOR(7).ToString + "','0','" + LECTOR(18).ToString + "')", conexion)
                            Dim LECTORt As OdbcDataReader
                            LECTORt = comando.ExecuteReader
                            If LECTORt.Read Then
                                idvt = LECTORt(0).ToString
                            End If
                            'DataGridView1.Rows.Add("1", LECTOR(7).ToString, valorsub.ToString("#,##0.00"), "0.00", CDec(valortotalproducto), idvt, LECTOR(19).ToString, LECTOR(18).ToString, LECTOR(10).ToString, LECTOR(4).ToString)
                            DataGridView1.Rows.Add("1", LECTOR(7).ToString, valorsub.ToString("#,##0.00"), "0.00", CDec(valortotalproducto), idvt, LECTOR(19).ToString, LECTOR(4).ToString, LECTOR(18).ToString, LECTOR(10).ToString, LECTOR(4).ToString)
                            txtCodigo.Focus()
                        End If
                    Else
                        MsgBox("Material no disponible a la venta.", MsgBoxStyle.Critical)
                    End If
                Else
                    MsgBox("Material agotado.", MsgBoxStyle.Critical)
                End If
            End If
        Else
            MsgBox("Material no se encontro en el almacen.", MsgBoxStyle.Critical)
        End If

        recorredata()
        'conexion.Close()
        Me.txtCodigo.Text = ""
        Me.txtCodigo.Focus()


    End Sub

    Public Sub InsertaFilacoodigo(Codbarra As String)
        Dim a As String
        a = ""
        con.openConection(conexion)
        Dim sqlfila As String = "select * from vistaMaterialesventa WHERE idmaterial='" + Codbarra + "' and idcentro='" + id_almacen.ToString + "';"
        comando = New OdbcCommand(sqlfila, conexion)
        Thread.CurrentThread.CurrentCulture = New CultureInfo("es-HN")
        LECTOR = comando.ExecuteReader
        Dim imp As Integer
        Dim valorimp As Double = 0
        Dim valorsub As Double = 0
        Dim valortot As Double = 0
        Dim idvt As String = ""
        If LECTOR.Read Then ' lee la consulta
            'inventario negativo
            If (LECTOR(10).ToString = "1") Then
                imp = Val(LECTOR(19))
                valorsub = Convert.ToDecimal(Val(LECTOR(18)))
                valorimp = Convert.ToDecimal(Val(LECTOR(22)))
                valortot = Convert.ToDecimal(Val(LECTOR(23)))
                'validamos si estaa para venta
                If (LECTOR(8).ToString = "1") Then
                    'Validamos impuestos
                    If (LECTOR(9).ToString = "1") Then
                        comando = New OdbcCommand("select fn_vtinsertaItemsventa('" + idventa.ToString + "', '" + LECTOR(12).ToString + "', '" + valorsub.ToString + "', '" + valortot.ToString + "', '" + valorimp.ToString + "','1','" + LECTOR(7).ToString + "','" + LECTOR(19).ToString + "','" + LECTOR(18).ToString + "')", conexion)
                        Dim LECTORt As OdbcDataReader
                        LECTORt = comando.ExecuteReader
                        If LECTORt.Read Then
                            idvt = LECTORt(0).ToString
                        End If
                        If Activacafe = 1 Then

                            'DataGridView1.Rows.Add("1", LECTOR(7).ToString, valorsub.ToString("#,##0.00"), valorimp.ToString("#,##0.00"), Math.Round(valortot, 2, MidpointRounding.ToEven), idvt, LECTOR(19).ToString, LECTOR(18).ToString, LECTOR(10).ToString, LECTOR(4).ToString)
                            DataGridView1.Rows.Add("1", LECTOR(7).ToString, valorsub.ToString("#,##0.00"), valorimp.ToString("#,##0.00"), Math.Round(valortot, 2, MidpointRounding.ToEven), idvt, LECTOR(19).ToString, LECTOR(4).ToString, LECTOR(18).ToString, LECTOR(10).ToString)
                        Else
                            'DataGridView1.Rows.Add("1", LECTOR(7).ToString, valorsub.ToString("#,##0.00"), valorimp.ToString("#,##0.00"), CDec(valortot).ToString("#,##0.00"), idvt, LECTOR(19).ToString, LECTOR(18).ToString, LECTOR(10).ToString, LECTOR(4).ToString)
                            DataGridView1.Rows.Add("1", LECTOR(7).ToString, valorsub.ToString("#,##0.00"), valorimp.ToString("#,##0.00"), CDec(valortot).ToString("#,##0.00"), idvt, LECTOR(19).ToString, LECTOR(4).ToString, LECTOR(18).ToString, LECTOR(10).ToString)
                        End If

                    Else
                        comando = New OdbcCommand("select fn_vtinsertaItemsventa('" + idventa.ToString + "', '" + LECTOR(12).ToString + "', '" + valorsub.ToString + "', '" + valortot.ToString + "', '0','1','" + LECTOR(7).ToString + "','0','" + LECTOR(18).ToString + "')", conexion)
                        Dim LECTORt As OdbcDataReader
                        LECTORt = comando.ExecuteReader
                        If LECTORt.Read Then
                            idvt = LECTORt(0).ToString
                        End If
                        'DataGridView1.Rows.Add("1", LECTOR(7).ToString, valorsub.ToString("#,##0.00"), "0.00", CDec(valortot).ToString("#,##0.00"), idvt, LECTOR(19).ToString, LECTOR(18).ToString, LECTOR(10).ToString, LECTOR(4).ToString)
                        DataGridView1.Rows.Add("1", LECTOR(7).ToString, valorsub.ToString("#,##0.00"), "0.00", CDec(valortot).ToString("#,##0.00"), idvt, LECTOR(19).ToString, LECTOR(4).ToString, LECTOR(18).ToString, LECTOR(10).ToString)
                    End If
                Else
                    MsgBox("Material no disponible a la venta.", MsgBoxStyle.Critical)
                End If


            Else
                'si hay en disponibilidad
                If (Val(LECTOR(4)) > 0) Then
                    imp = Val(LECTOR(19))
                    valorsub = Convert.ToDecimal(Val(LECTOR(18)))
                    valorimp = Convert.ToDecimal(Val(LECTOR(22)))
                    valortot = Convert.ToDecimal(Val(LECTOR(23)))
                    If valorsub > 0 Then
                        'validamos si estaa para venta
                        If (LECTOR(8).ToString = "1") Then
                            'Validamos impuestos
                            If (LECTOR(9).ToString = "1") Then
                                comando = New OdbcCommand("select fn_vtinsertaItemsventa('" + idventa.ToString + "', '" + LECTOR(12).ToString + "', '" + valorsub.ToString + "', '" + valortot.ToString + "', '" + valorimp.ToString + "','1','" + LECTOR(7).ToString + "','" + LECTOR(19).ToString + "','" + LECTOR(18).ToString + "')", conexion)
                                Dim LECTORt As OdbcDataReader
                                LECTORt = comando.ExecuteReader
                                If LECTORt.Read Then
                                    idvt = LECTORt(0).ToString
                                End If
                                'DataGridView1.Rows.Add("1", LECTOR(7).ToString, valorsub.ToString("#,##0.00"), valorimp.ToString("#,##0.00"), CDec(valortot).ToString("#,##0.00"), idvt, LECTOR(19).ToString, LECTOR(18).ToString, LECTOR(10).ToString, LECTOR(4).ToString)
                                DataGridView1.Rows.Add("1", LECTOR(7).ToString, valorsub.ToString("#,##0.00"), valorimp.ToString("#,##0.00"), CDec(valortot).ToString("#,##0.00"), idvt, LECTOR(19).ToString, LECTOR(4).ToString, LECTOR(18).ToString, LECTOR(10).ToString, LECTOR(4))
                            Else
                                comando = New OdbcCommand("select fn_vtinsertaItemsventa('" + idventa.ToString + "', '" + LECTOR(12).ToString + "', '" + valorsub.ToString + "', '" + valortot.ToString + "', '0','1','" + LECTOR(7).ToString + "','0','" + LECTOR(18).ToString + "')", conexion)
                                Dim LECTORt As OdbcDataReader
                                LECTORt = comando.ExecuteReader
                                If LECTORt.Read Then
                                    idvt = LECTORt(0).ToString
                                End If
                                'DataGridView1.Rows.Add("1", LECTOR(7).ToString, valorsub.ToString("#,##0.00"), "0.00", (CDec(valortot)), idvt, LECTOR(19).ToString, LECTOR(18).ToString, LECTOR(10).ToString, LECTOR(4).ToString)
                                DataGridView1.Rows.Add("1", LECTOR(7).ToString, valorsub.ToString("#,##0.00"), "0.00", (CDec(valortot)), idvt, LECTOR(19).ToString, LECTOR(4).ToString, LECTOR(18).ToString, LECTOR(10).ToString, LECTOR(4))
                            End If
                        Else
                            MsgBox("Material no disponible a la venta.", MsgBoxStyle.Critical)
                        End If
                    Else
                        MsgBox("No se puede agregar producto con costo 0.", MsgBoxStyle.Critical)
                    End If
                Else
                    MsgBox("Material agotado.", MsgBoxStyle.Critical)
                End If

            End If
        Else
            MsgBox("Material no se encontro en el almacen.", MsgBoxStyle.Critical)
        End If

        recorredata()
        'conexion.Close()
        Me.txtCodigo.Text = ""
        Me.txtCodigo.Focus()
    End Sub

    Public Sub recorredata()
        Me.lblSub.Text = "L. 0.00"
        Me.lbltotal.Text = "L. 0.00"
        Me.lblimp.Text = "L. 0.00"
        Dim valorimp As Decimal = 0
        Dim valorsub As Decimal = 0
        Dim valortot As Decimal = 0
        DataGridView1.Refresh()

        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            valorimp = valorimp + Convert.ToDecimal((Val(DataGridView1.Rows(i).Cells(3).Value.ToString)) * (DataGridView1.Rows(i).Cells(0).Value))
            valorsub = valorsub + Convert.ToDecimal((Val(DataGridView1.Rows(i).Cells(2).Value.ToString)) * (DataGridView1.Rows(i).Cells(0).Value))

            If Activacafe = 1 Then
                valortot = valortot + Convert.ToDecimal(DataGridView1.Rows(i).Cells(4).Value.ToString)
            Else
                valortot = (valortot) + (Convert.ToDecimal(Val(DataGridView1.Rows(i).Cells(4).Value.ToString)))
            End If
        Next

        lblSub.Text = "L." + Convert.ToDecimal(valorsub).ToString("#,##0.00")

        If Activacafe = 1 Then
            lbltotal.Text = "L." + valortot.ToString("#,##0.00")
            totalapagar = valortot
        Else
            lbltotal.Text = "L." + (valortot).ToString("#,##0.00")
            totalapagar = (valortot)
        End If

        lblimp.Text = "L." + valorimp.ToString("#,##0.00")

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Forms.frmlotesventa.pgconection = conexion
        My.Forms.frmlotesventa.Show()
        'btncancela.PerformClick()
        Me.Close()
    End Sub

    Private Sub btnespera_Click(sender As Object, e As EventArgs) Handles btnespera.Click
        If DataGridView1.Rows.Count > 0 Then
            Dim prompt As String = String.Empty
            Dim title As String = String.Empty
            Dim defaultResponse As String = String.Empty
            Dim answer As Object
            ' Set prompt.
            prompt = "Nombre:"
            ' Set title.
            title = "Ingrese el nombre del encargado"
            ' Set default value.
            'actualiza venta ;
            answer = InputBox(prompt, title, defaultResponse)
                If answer <> "" Then
                    comando = New Odbc.OdbcCommand("UPDATE public.tbl_pos_venta  SET estado=1,nombre='" + answer + "' WHERE id='" + idventa.ToString + "'", conexion)
                    comando.ExecuteNonQuery()

                    Dim adaptador3 As New OdbcDataAdapter("SELECT id, to_char(fechahorai, 'DD/MM/YYYY, HH12:MI:SS') as hori, nombre FROM tbl_pos_venta where estado = '1' and idloteventa='" + sessiones.id_loteventa.ToString + "'", conexion)
                    Dim datan As New DataSet
                    adaptador3.Fill(datan, "tbl_pos_venta")
                    adaptador3.FillSchema(datan.Tables("tbl_pos_venta"), SchemaType.Source)
                    Dim tb As New DataTable
                    tb.Columns.Add("Text", GetType(String))
                    tb.Columns.Add("Value", GetType(Integer))
                    For Each dr As DataRow In datan.Tables("tbl_pos_venta").Rows
                        tb.Rows.Add(dr.Item(0).ToString + " " + dr.Item(2).ToString, dr.Item(0))
                        'Me.lsPendienteLotes.Items.Add(dr.Item(0).ToString + " " + dr.Item(1).ToString)
                    Next
                    'conexion.Close()
                    lstventaespera.DisplayMember = "Text"
                    lstventaespera.ValueMember = "Value"
                    lstventaespera.DataSource = tb


                    Me.btncancela.Enabled = False
                    Me.btnespera.Enabled = False
                    Me.btnpago.Enabled = False
                    Me.Button4.Enabled = True
                    Me.btnbeneficio.Enabled = False
                    Me.txtCodigo.Text = ""
                    Activacafe = 0
                    'tipoventa = 0
                    cambiotipoventa(tipoventa)
                    Me.txtCodigo.Enabled = False
                    ListView1.Enabled = False
                    txtbusqeda.Enabled = False
                    DataGridView1.Rows.Clear()
                    Me.lblSub.Text = "L. 0.00"
                    Me.lbltotal.Text = "L. 0.00"
                Me.lblimp.Text = "L. 0.00"
                Me.Button4.PerformClick()
            Else
                    MsgBox("Ingrese el nombre por favor")
                End If


            Else
            MessageBox.Show("Debe seleccionar al menos un producto para ponerlo en espera.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If


    End Sub

    Private Sub lstventaespera_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstventaespera.SelectedIndexChanged

    End Sub

    Private Sub btnpago_Click(sender As Object, e As EventArgs) Handles btnpago.Click
        If idventa = 0 Then
            MsgBox("Debe crear una nueva venta", MsgBoxStyle.Information)
        Else
            Dim numeroItem As Integer = DataGridView1.Rows.Count
            If numeroItem > 0 Then
                TotalPago = 0
                'conexion.Open()
                'recorredata()
                Dim sqlpago As String = "select COALESCE(round(sum(subcan)::numeric,2),0) as subtot,COALESCE(round(sum(impcan)::numeric,2),0) as impuest,COALESCE(round(((round(sum(subcan)::numeric,2))+(round(sum(impcan)::numeric,2)))::numeric,2),0) as tot from detalleTotalmaterial where idventa ='" + idventa.ToString + "'"
                comando = New OdbcCommand(sqlpago, conexion)
                Dim LECTORt As OdbcDataReader
                LECTORt = comando.ExecuteReader
                Dim toto As Decimal = 0
                If LECTORt.Read Then
                    subtotalSesion = Convert.ToDecimal(LECTORt(0).ToString)
                    impSesion = Convert.ToDecimal(LECTORt(1).ToString)
                    If Activacafe = 1 Then
                        toto = Convert.ToDecimal(LECTORt(2).ToString)
                    Else
                        toto = (CDec(LECTORt(2).ToString)).ToString("#,##0.00")
                    End If
                End If
                TotalPago = toto
                My.Forms.frmMetodoPago.vtotalapagar = TotalPago
                My.Forms.frmMetodoPago.pgconection = conexion
                My.Forms.frmMetodoPago.ShowDialog()
                Button4.PerformClick()
            Else
                MessageBox.Show("Debe Seleccionar al menos un producto.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If

    End Sub

    'Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs)
    '    Dim FilaSeleccionada As Integer
    '    con.openConection(conexion)

    '    If e.KeyValue = 127 Then

    '        e.Handled = True

    '        comando = New Odbc.OdbcCommand("DELETE FROM public.tbl_pos_ventamaterial
    '                                        WHERE id= '" + DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(5).Value.ToString + "'", conexion)
    '        comando.ExecuteNonQuery()


    '        FilaSeleccionada = CType(sender, DataGridView).CurrentRow.Index
    '        Dim loFila As DataGridViewRow = Me.DataGridView1.CurrentRow()
    '        DataGridView1.Rows.Remove(loFila)
    '        DataGridView1.Refresh()
    '        recorredata()
    '        Me.txtCodigo.Text = ""
    '        Me.txtCodigo.Focus()

    '        If ListView1.Items.Count > 0 Then
    '            Me.ListView1.Items(0).Focused = True
    '            Me.ListView1.Items(0).Selected = True
    '        End If
    '        'MessageBox.Show(FilaSeleccionada)
    '    End If

    '    If e.KeyCode = Keys.Add Then
    '        Dim n As Integer = Convert.ToInt32(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value.ToString)
    '        If n > 0 Then
    '            n = n + 1
    '        Else
    '            n = n - 1
    '        End If
    '        DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value = n
    '        recorredata()
    '        actualizarproductos()
    '        'Dim disponible As Integer = Convert.ToInt32(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(10).Value.ToString)
    '        'If n <=disponible Then
    '        '    DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value = n
    '        '    recorredata()
    '        '    actualizarproductos()
    '        'End If

    '    End If

    '    If e.KeyValue = 187 Then
    '        MessageBox.Show("hola")
    '    End If
    '    'MessageBox.Show(FilaSeleccionada)
    'End Sub

    Public Sub fnnuevaventa()
        Me.btncancela.Enabled = True
        Me.btnespera.Enabled = True
        Me.btnpago.Enabled = True
        Me.Button4.Enabled = False
        Me.txtbusqeda.Enabled = False
        Me.ListView1.Enabled = False
        'conexion.Close()
    End Sub

    Public Sub InsertaFilapreventa(Codbarra As String)
        con.openConection(conexion)
        'If conexion.State = ConnectionState.Open Then
        '    conexion.Close()
        'End If
        'conexion.Open()
        Dim sqlpreventaitem As String = "select * from vistaMaterialesventa WHERE idmaterial='" + Codbarra + "' and idcentro='" + id_almacen.ToString + "';"
        comando = New OdbcCommand(sqlpreventaitem, conexion)
        Thread.CurrentThread.CurrentCulture = New CultureInfo("es-HN")
        LECTOR = comando.ExecuteReader
        Dim imp As Integer
        Dim valorimp As Decimal
        Dim valorsub As Decimal
        Dim valortot As Decimal
        Dim idvt As String = ""
        If LECTOR.Read Then ' lee las 
            imp = Val(LECTOR(19))
            valorsub = CDec(Val(LECTOR(18)))
            valorimp = CDec(Val(LECTOR(22)))
            valortot = CDec(Val(LECTOR(23)))
            comando = New OdbcCommand("select fn_vtinsertaItemsventa('" + idventa.ToString + "', '" + LECTOR(12).ToString + "', '" + valorsub.ToString + "', '" + valortot.ToString + "', '" + valorimp.ToString + "','1','" + LECTOR(7).ToString + "','" + LECTOR(19).ToString + "','" + LECTOR(18).ToString + "')", conexion)
            Dim LECTORt As OdbcDataReader
            LECTORt = comando.ExecuteReader
            If LECTORt.Read Then
                idvt = LECTORt(0).ToString
            End If
            DataGridView1.Rows.Add("1", LECTOR(7).ToString, valorsub.ToString("N2"), valorimp.ToString("N2"), CDec(valortot), idvt, LECTOR(19).ToString, LECTOR(4).ToString, LECTOR(18).ToString, LECTOR(10).ToString, LECTOR(4).ToString)
        Else
            MsgBox("Material no se encontro en el almacen.", MsgBoxStyle.Critical)
        End If

        recorredata()
        'conexion.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        'lstventaespera.Items.Clear()
        'If conexion.State = ConnectionState.Open Then
        '    conexion.Close()
        'End If
        'conexion.Open()
        con.openConection(conexion)
        Dim adaptador3 As New OdbcDataAdapter("SELECT id, to_char(fechahorai, 'DD/MM/YYYY, HH12:MI:SS') as hori, nombre FROM tbl_pos_venta where estado = '1' and idloteventa='" + sessiones.id_loteventa.ToString + "'", conexion)
        Dim datan As New DataSet
        adaptador3.Fill(datan, "tbl_pos_venta")
        adaptador3.FillSchema(datan.Tables("tbl_pos_venta"), SchemaType.Source)
        Dim tb As New DataTable
        tb.Columns.Add("Text", GetType(String))
        tb.Columns.Add("Value", GetType(Integer))
        For Each dr As DataRow In datan.Tables("tbl_pos_venta").Rows
            tb.Rows.Add(dr.Item(0).ToString + " " + dr.Item(2).ToString, dr.Item(0))
            'Me.lsPendienteLotes.Items.Add(dr.Item(0).ToString + " " + dr.Item(1).ToString)
        Next
        lstventaespera.DisplayMember = "Text"
        lstventaespera.ValueMember = "Value"
        lstventaespera.DataSource = tb
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles btnbeneficio.Click
        If txtcod.Text <> "" Then
            Activacafe = 1
            impSesion = 0
            subtotalSesion = 0
            TotalPago = 0
            'DataGridView1.Rows.Clear()
            Me.btnespera.Enabled = False
            My.Forms.frmBusquedaBeneficios.pgconection = conexion
            My.Forms.frmBusquedaBeneficios.ShowDialog()
        Else
            MessageBox.Show("Debe seleccionar un empleado para activar el beneficio de cafe.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub txtCodigo_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        lblnombrecliente.Text = ""
        cmbTipo.SelectedValue = 5
        txtcod.Text = ""
        empleadoventa = "no"
        codigoEmpleado = ""
        Activacafe = 0
        subtotalSesion = 0
        impSesion = 0
        TotalPago = 0
    End Sub

    Private Sub btnar_Click(sender As Object, e As EventArgs) Handles btnar.Click
        regresaFactura = 1
        My.Forms.frmFacturasLista.getform = 1
        My.Forms.frmFacturasLista.pgconection = conexion
        My.Forms.frmFacturasLista.Show()
    End Sub

    Private Function CargarProductos()
        'Dim cad As String = ""
        'If tipoventa = 0 Then
        '    If id_almacen = 1 Then
        '        cad = "select idmaterial, disponible,totalpagoo,descripcion_1,codigo_barras from vistaMaterialesventa where idcentro='" + id_almacen.ToString + "' and codigo_barras not in ('CAFE105','CAFE106','CAFE104','CAFE107') ORDER BY disponible ASC"

        '    Else
        '        cad = "select idmaterial, disponible,totalpagoo,descripcion_1,codigo_barras   from vistaMaterialesventa where idcentro='" + id_almacen.ToString + "' ORDER BY disponible ASC"

        '    End If
        'Else
        '    cad = "select idmaterial, disponible,totalpagoo,descripcion_1,codigo_barras   from vistaMaterialesventa where idcentro='" + id_almacen.ToString + "' and id_categoria in (65,66,67,68,69,70,71,72,73,74,75,76,77) ORDER BY disponible ASC"
        'End If

        'ListView1.View = View.Details
        'ListView1.AllowColumnReorder = True
        'ListView1.FullRowSelect = True
        'ListView1.GridLines = True
        'ListView1.Columns.Clear()
        'ListView1.Columns.Add("ID", 0, HorizontalAlignment.Left)
        'ListView1.Columns.Add("Disponible", 80, HorizontalAlignment.Left)
        'ListView1.Columns.Add("Precio", 50, HorizontalAlignment.Left)
        'ListView1.Columns.Add("Descripción", 250, HorizontalAlignment.Left)
        'ListView1.Columns.Add("Cod. Barra", 0, HorizontalAlignment.Left)

        'Dim cdatos As New OdbcDataAdapter(cad, conexion)
        'Dim datan2 As New DataSet
        'datan2.Clear()
        'cdatos.Fill(datan2, "vistaMaterialesventa")
        'Dv.Table = datan2.Tables("vistaMaterialesventa")
        'cdatos.FillSchema(datan2.Tables("vistaMaterialesventa"), SchemaType.Source)
        'For Each dr As DataRow In datan2.Tables("vistaMaterialesventa").Rows
        '    Dim str(4) As String
        '    Dim itm As ListViewItem
        '    str(0) = dr.Item(0).ToString
        '    str(1) = dr.Item(1).ToString
        '    str(2) = dr.Item(2).ToString
        '    str(3) = dr.Item(3).ToString
        '    str(4) = dr.Item(4).ToString
        '    itm = New ListViewItem(str)
        '    ListView1.Items.Insert(0, itm)
        'Next
        actualizarListaInventario()
        cargarListadoEspera()
        Button4.Enabled = True
        ListView1.Visible = True
        btnar.Enabled = True
        Button1.Enabled = True
        Me.Enabled = True
    End Function

    Private Sub ListView1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListView1.KeyDown
        Dim valor As String = ""

        If ListView1.Items.Count > 0 Then
            valor = ListView1.Items(ListView1.FocusedItem.Index).Text
        End If

        If (e.KeyCode = Keys.Enter) Then
            If tipoventa = 0 Then
                InsertaFilacoodigo(valor)
            Else
                InsertaFilapreventa(valor)
            End If
            txtbusqeda.Text = ""
        End If

        If e.KeyCode = Keys.Left Then
            DataGridView1.Focus()
            If DataGridView1.Rows.Count > 0 Then
                DataGridView1.Rows(0).Selected = True
            End If
        End If
    End Sub

    Private Sub btnDisponible_Click(sender As Object, e As EventArgs) Handles btnDisponible.Click
        'My.Forms.frm_recargaWildcard.pgconection = conexion
        'My.Forms.frm_recargaWildcard.ShowDialog()
        recargaCarnet = "si"
    End Sub

    Private Sub btnConsultasaldo_Click(sender As Object, e As EventArgs) Handles btnConsultasaldo.Click
        Dim fc As New frm_recargaWildcard
        fc.pgconection = conexion
        fc.ShowDialog()
    End Sub

    Private Sub txtCodigo_KeyDown_1(sender As Object, e As KeyEventArgs) Handles txtCodigo.KeyDown

        If e.KeyCode = Keys.Enter Then
            If txtCodigo.Text <> "" Then
                InsertaFila(txtCodigo.Text)
                txtCodigo.Focus()
            End If
        End If
        If e.KeyCode = Keys.Down Then
            DataGridView1.Focus()
            If DataGridView1.Rows.Count > 0 Then
                DataGridView1.Rows(0).Selected = True
            End If
        End If

        If e.KeyCode = Keys.Right Then
            txtbusqeda.Focus()
        End If

    End Sub

    Private Sub DataGridView1_KeyDown_1(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyDown

        Dim FilaSeleccionada As Integer
        If DataGridView1.Rows.Count > 0 Then
            DataGridView1.Rows(DataGridView1.CurrentRow.Index).Selected = True
        End If

        If e.KeyCode = Keys.Add Then
            Dim a As String = CInt(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(9).Value.ToString)
            'inventario negativos=1
            If a = 0 Then
                Dim n As Integer = Convert.ToInt32(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value.ToString)
                Dim mm As Integer = If(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(10).Value.ToString <> "", DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(10).Value.ToString, 0)
                Dim disponible As Integer = Convert.ToInt32(mm)
                If n > 0 Then
                    n = n + 1
                    If n <= disponible Then
                        DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value = n
                        recorredata()
                        actualizarproductos()
                    Else
                        MessageBox.Show("No puede agregar mas que el disponible.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                End If
            Else
                Dim n As Integer = Convert.ToInt32(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value.ToString)
                If n > 0 Then
                    n = n + 1
                    DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value = n
                    recorredata()
                    actualizarproductos()
                End If
            End If
        End If
        If e.KeyCode = Keys.Subtract Then
            Dim n As Integer = Convert.ToInt32(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value.ToString)
            If (n - 1) > 0 Then
                n = n - 1
                DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value = n
                recorredata()
                actualizarproductos()
            End If

        End If
        If e.KeyValue = 46 Then
            e.Handled = True
            Dim sqldeleteitem As String = "DELETE FROM public.tbl_pos_ventamaterial WHERE id= '" + DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(5).Value.ToString + "' AND idventa='" + idventa.ToString + "'"
            comando = New Odbc.OdbcCommand(sqldeleteitem, conexion)
            comando.ExecuteNonQuery()

            If tipoventa = 1 Then
                sqldeleteitem = "DELETE FROM public.tbl_recibo_preventa_detalles WHERE id= '" + DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(5).Value.ToString + "' AND idventa='" + idventa.ToString + "'"
                comando = New Odbc.OdbcCommand(sqldeleteitem, conexion)
                comando.ExecuteNonQuery()
            End If

            FilaSeleccionada = CType(sender, DataGridView).CurrentRow.Index
            Dim loFila As DataGridViewRow = Me.DataGridView1.CurrentRow()
            DataGridView1.Rows.Remove(loFila)
            DataGridView1.Refresh()
            recorredata()
            Me.txtCodigo.Text = ""
            Me.txtCodigo.Focus()
            'If ListView1.Items.Count > 0 Then
            '    Me.ListView1.Items(0).Focused = True
            '    Me.ListView1.Items(0).Selected = True
            'End If
        End If

        'If DataGridView1.Rows.Count > 0 Then
        '    DataGridView1.Rows(0).Selected = True
        'End If
        If e.KeyCode = Keys.Right Then
            ListView1.Focus()
        End If

        'If e.KeyCode = Keys.Enter Then
        '    recorredata()
        '    actualizarproductos()
        'End If

        'If e.KeyCode = Keys.Delete Then

        '    e.Handled = True

        '    comando = New Odbc.OdbcCommand("DELETE FROM public.tbl_pos_ventamaterial
        '                                    WHERE id= '" + DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(5).Value.ToString + "'", conexion)
        '    comando.ExecuteNonQuery()


        '    FilaSeleccionada = CType(sender, DataGridView).CurrentRow.Index
        '    Dim loFila As DataGridViewRow = Me.DataGridView1.CurrentRow()
        '    DataGridView1.Rows.Remove(loFila)
        '    DataGridView1.Refresh()
        '    recorredata()
        '    Me.txtCodigo.Text = ""
        '    Me.txtCodigo.Focus()

        '    If ListView1.Items.Count > 0 Then
        '        Me.ListView1.Items(0).Focused = True
        '        Me.ListView1.Items(0).Selected = True
        '    End If
        '    'MessageBox.Show(FilaSeleccionada)
        'End If

        If e.KeyCode = Keys.Enter Then
            If DataGridView1.Rows.Count > 0 Then
                Dim r As Integer = CInt(DataGridView1.CurrentRow.Index)
                Dim disp As Integer = CInt(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(10).Value)
                Dim cant As String = InputBox("Ingrese una cantida:", "Cantidad", 0)
                Try
                    Dim n As Integer = CInt(cant)
                    Dim a As String = CInt(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(9).Value.ToString)
                    'inventario negativos=1
                    If a = 0 Then
                        Dim mm As Integer = If(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(10).Value.ToString <> "", DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(10).Value.ToString, 0)
                        Dim disponible As Integer = Convert.ToInt32(mm)
                        If n > 0 Then

                            If n <= disponible Then
                                DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value = n
                                recorredata()
                                actualizarproductos()
                            Else
                                MessageBox.Show("No puede agregar mas que el disponible.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            End If
                        End If
                    Else
                        If n > 0 Then

                            DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value = n
                            recorredata()
                            actualizarproductos()
                        End If
                    End If
                    'If n > 0 And n <= disp Then
                    '    DataGridView1.Rows(r).Cells(0).Value = n
                    '    recorredata()
                    '    actualizarproductos()
                    'Else
                    '    MessageBox.Show("No puede ingresar mas que el disponible.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    'End If
                Catch ex As Exception
                    MessageBox.Show("Solo se permiten numeros.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End Try
            End If
        End If

    End Sub

    Private Sub txtbusqeda_TextChanged_1(sender As Object, e As EventArgs) Handles txtbusqeda.TextChanged
        Try
            If tipoventa = 0 Then
                valcod = "descripcion_1 like '%" + txtbusqeda.Text.Trim + "%'"
            Else
                valcod = "codigo_barras like '%" + txtbusqeda.Text.Trim + "%' or descripcion_1 like '%" + txtbusqeda.Text.Trim + "%'"
            End If

            ListView1.Items.Clear()

            Dv.RowFilter = valcod
            For Each row As DataRowView In Dv
                Dim str(4) As String
                Dim itm As ListViewItem
                str(0) = row("idmaterial").ToString()
                str(1) = row("disponible").ToString()
                str(2) = row("totalpagoo").ToString()
                str(3) = row("descripcion_1").ToString()
                str(4) = row("codigo_barras").ToString()
                itm = New ListViewItem(str)
                ListView1.Items.Insert(0, itm)
            Next

            If ListView1.Items.Count > 0 Then
                Me.ListView1.Items(0).Focused = True
                Me.ListView1.Items(0).Selected = True
            End If

            'DataGridView1.DataSource = Dv
            'DataGridView1.Update()
        Catch ex As Exception
            MsgBox(ex.Message, 48)
        End Try
    End Sub

    Private Function cambiotipoventa(tipovent As Integer)
        If (tipovent = 1) Then
            lbltipoventa.Text = "Preventa"
        Else
            lbltipoventa.Text = "Venta normal"
        End If
    End Function

    Private Sub btn_reimprimir_Click(sender As Object, e As EventArgs) Handles btn_reimprimir.Click
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
        'PrintDocument1.Print()
        imprimirFact.ImprimirFactura("s", conexion, facturaanterior(), id_loteventa)
        empleadoventa = "no"
        txtCodigo.Focus()
        btn_reimprimir.Enabled = False
    End Sub

    'Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
    '    Dim lblNumerofactura As String = ""
    '    Dim lblfecha As String = ""
    '    Dim lblestado As String = ""
    '    Dim lblRTN As String = ""
    '    Dim lblnombrecliente2 As String = ""
    '    Dim lblrango As String = ""
    '    Dim lblnumventa As String = ""
    '    Dim lbllote As String = ""
    '    Dim lblinterno As String = ""
    '    Dim lblcajero As String = ""
    '    Dim lblSub As String = ""
    '    Dim lbldesc As String = ""
    '    Dim lblimp As String = ""
    '    Dim horai As String = ""
    '    Dim fechai As String = ""
    '    Dim lbltotal As String = ""
    '    Dim tot As Integer
    '    Dim idfactura As Integer
    '    Dim llevacambio As Integer = -1
    '    Dim nombrecliente As String = ""
    '    Dim sql1 As String = "SELECT cast(id as text),nombrecliente FROM vistafacturasventa WHERE id_venta=" + facturaanterior().ToString + " and idalmacen='" + id_almacen.ToString + "' and id_usuario=" + id_usuario.ToString + ";"
    '    comando = New OdbcCommand(sql1, conexion)
    '    LECTOR = comando.ExecuteReader
    '    If LECTOR.Read Then
    '        idfactura = LECTOR(0).ToString
    '        nombrecliente = LECTOR(1).ToString
    '    End If

    '    comando = New OdbcCommand("SELECT numfactura, COALESCE(descuentototal,0), valortotal, CASE WHEN estado=1 THEN 'Activa' WHEN estado=2 THEN 'Pendiente Anulación' ELSE 'Anulada'  END, COALESCE(to_char(fecha, 'DD/MM/YYYY hh:mm:ss'), '') AS ff, cai, rtn, nombrecliente, rangocorrelativo, cajero, rginicial, rgfinal, COALESCE(subtotal,0) ,COALESCE(total_impuesto,0), COALESCE(to_char(fecha, 'hh:mm:ss'), '') AS hh, COALESCE(to_char(fecha, 'DD/MM/YYYY'), '') AS fechaaa FROM public.tbl_facturaventa where id='" + idfactura.ToString + "'", conexion)
    '    LECTOR = comando.ExecuteReader
    '    If LECTOR.Read Then
    '        lblNumerofactura = LECTOR(0).ToString()
    '        lblfecha = LECTOR(4).ToString()
    '        lblestado = LECTOR(3).ToString()
    '        lblRTN = LECTOR(6).ToString()
    '        lblnombrecliente2 = LECTOR(7).ToString()
    '        lblrango = LECTOR(8).ToString()
    '        lblnumventa = numeroventa.ToString
    '        lbllote = numeroLOTEventa.ToString
    '        lblinterno = idfactura.ToString
    '        lblcajero = LECTOR(9).ToString()
    '        lblSub = "L." + CDbl(LECTOR(12).ToString()).ToString("#,##0.00")
    '        lbldesc = "L." + CDbl(LECTOR(1).ToString()).ToString("#,##0.00")
    '        lblimp = "L." + CDbl(LECTOR(13).ToString()).ToString("#,##0.00")
    '        horai = LECTOR(14).ToString()
    '        fechai = LECTOR(15).ToString()
    '        lbltotal = "L." + CInt(CDbl(LECTOR(2).ToString())).ToString("#,##0.00")
    '        tot = CInt(CDbl(LECTOR(2).ToString()))
    '    End If

    '    Dim topMargin As Double = e.MarginBounds.Top
    '    e.PageSettings.Margins.Left = 1
    '    e.PageSettings.Margins.Right = 1
    '    e.PageSettings.Landscape = False
    '    Dim sf As New StringFormat
    '    sf.Alignment = StringAlignment.Near
    '    Dim yPos As Double = 0
    '    Dim linesPerPage As Double = 0
    '    Dim count As Integer = 0
    '    Dim texto As String = ""
    '    Dim numinterno As Integer = 0
    '    Dim formato As StringFormat = New StringFormat
    '    Dim dispon As Decimal = 0
    '    formato.Alignment = StringAlignment.Center
    '    formato.LineAlignment = StringAlignment.Center
    '    Dim form As StringFormat = New StringFormat
    '    form.Alignment = StringAlignment.Far
    '    form.LineAlignment = StringAlignment.Far
    '    Dim printFont As System.Drawing.Font = New Font("Arial", 10)
    '    Dim printFont2 As System.Drawing.Font = New Font("Arial", 10)
    '    Dim printFont1 As System.Drawing.Font = New Font("Arial", 6)
    '    Dim printFont3 As System.Drawing.Font = New Font("Arial", 8)
    '    Dim printFont4 As System.Drawing.Font = New Font("Arial", 7)
    '    Dim printFont5 As System.Drawing.Font = New Font("Arial", 7)
    '    Dim printFontm As System.Drawing.Font = New Font("Arial", 7)
    '    Dim printFont4n As System.Drawing.Font = New Font("Arial", 7, FontStyle.Bold)
    '    Dim point1 As New Point(5, 137)
    '    Dim point2 As New Point(280, 137)
    '    e.Graphics.DrawLine(Pens.Black, point1, point2)
    '    If reimprime = "s" Then
    '        e.Graphics.DrawString("Reimpresion", printFont, Brushes.Black, New RectangleF(0, 8, 280, printFont.Height), formato)
    '    End If
    '    e.Graphics.DrawString(NombreSociedad, printFont4, Brushes.Black, New RectangleF(0, 24, 280, printFont4.Height), formato)
    '    e.Graphics.DrawString(nombrelegal, printFont4, Brushes.Black, New RectangleF(0, 40, 280, printFont4.Height), formato)
    '    e.Graphics.DrawString("RTN: " + RTN, printFont4, Brushes.Black, New RectangleF(0, 56, 280, printFont4.Height), formato)
    '    e.Graphics.DrawString("Aldea Agua Dulce, Las Hadas", printFont4, Brushes.Black, New RectangleF(0, 72, 280, printFont4.Height), formato)
    '    e.Graphics.DrawString("Tegucigalpa, F.M., PBX", printFont4, Brushes.Black, New RectangleF(0, 88, 280, printFont4.Height), formato)
    '    e.Graphics.DrawString("2234-9595", printFont4, Brushes.Black, New RectangleF(0, 104, 280, printFont4.Height), formato)
    '    e.Graphics.DrawString(CORREO, printFont4, Brushes.Black, New RectangleF(0, 122, 280, printFont4.Height), formato)
    '    Dim point As New Point(5, 155)
    '    Dim point1t As New Point(280, 155)
    '    e.Graphics.DrawLine(Pens.Black, point, point1t)

    '    e.Graphics.DrawString("FACTURA", printFont4n, Brushes.Black, New RectangleF(0, 139, 280, printFont4n.Height), formato)

    '    e.Graphics.DrawString("POS#: " + id_pos.ToString, printFont5, Brushes.Black, 0, 158)
    '    e.Graphics.DrawString("Cajero: " + lblcajero, printFont5, Brushes.Black, 100, 158)
    '    e.Graphics.DrawString("Fecha: " + fechai, printFont5, Brushes.Black, 0, 174)
    '    e.Graphics.DrawString("Hora: " + horai, printFont5, Brushes.Black, 160, 174)
    '    e.Graphics.DrawString("CORRELATIVO: " + lblNumerofactura, printFont5, Brushes.Black, 0, 190)
    '    e.Graphics.DrawString("CAI: " + CAI, printFont1, Brushes.Black, 0, 206)
    '    e.Graphics.DrawString("FECHA LIMITE EMISION: " + fechalimite, printFont5, Brushes.Black, 0, 222)
    '    e.Graphics.DrawString("DESDE: " + rgInicio, printFont5, Brushes.Black, 0, 238)
    '    e.Graphics.DrawString("HASTA: " + rgFinal, printFont5, Brushes.Black, 135, 238)
    '    e.Graphics.DrawString("RTN: " + lblRTN, printFont5, Brushes.Black, 0, 254)
    '    e.Graphics.DrawString("NOMBRE: " + nombrecliente, printFont5, Brushes.Black, 0, 270)
    '    Dim point3 As New Point(5, 286)
    '    Dim point4 As New Point(280, 286)
    '    e.Graphics.DrawLine(Pens.Black, point3, point4)
    '    e.Graphics.DrawString("Cant.", printFont5, Brushes.Black, New RectangleF(0, 288, 30, printFont5.Height), formato)
    '    e.Graphics.DrawString("Descripcion.", printFont5, Brushes.Black, New RectangleF(35, 288, 200, printFont5.Height), formato)
    '    e.Graphics.DrawString("Valor.", printFont5, Brushes.Black, New RectangleF(170, 288, 85, printFont5.Height), formato)
    '    Dim y As Integer = 304
    '    Dim efect As Decimal = 0
    '    Dim camb As Decimal = 0
    '    Dim adaptador As New OdbcDataAdapter("select * from VistaItemsVenta where idventa='" + facturaanterior().ToString + "'", conexion)
    '    Dim data As New DataSet
    '    Dim cont As Integer = 1
    '    adaptador.Fill(data, "VistaItemsVenta")
    '    adaptador.FillSchema(data.Tables("VistaItemsVenta"), SchemaType.Source)
    '    Dim acu15 As Decimal = 0
    '    Dim acu18 As Decimal = 0
    '    Dim acuEx As Decimal = 0
    '    For Each dr As DataRow In data.Tables("VistaItemsVenta").Rows
    '        y = y + 10
    '        numinterno = dr.Item(10).ToString
    '        e.Graphics.DrawString(dr.Item(6).ToString, printFont5, Brushes.Black, New RectangleF(0, y, 30, printFont5.Height), formato)
    '        Dim subcadena As String
    '        Dim s As String = dr.Item(5).ToString
    '        Dim tam As Integer = (dr.Item(5).ToString).Length
    '        If (tam > 30) Then
    '            subcadena = (dr.Item(5).ToString).Substring(0, 24)
    '            e.Graphics.DrawString(subcadena, printFont5, Brushes.Black, New RectangleF(20, y, 180, printFont5.Height))
    '            y = y + 10
    '            Dim sub2 As String = ""
    '            sub2 = s.Substring(30, tam - 30)
    '            e.Graphics.DrawString(sub2, printFont5, Brushes.Black, New RectangleF(20, y, 180, printFont5.Height))
    '        Else
    '            subcadena = (dr.Item(5).ToString)
    '            e.Graphics.DrawString(subcadena, printFont5, Brushes.Black, New RectangleF(20, y, 180, printFont5.Height))
    '        End If
    '        e.Graphics.DrawString("L. " + CInt(CDec(dr.Item(3).ToString) * Val(dr.Item(6).ToString)).ToString("#,##0.00"), printFont5, Brushes.Black, New RectangleF(180, y, 85, printFont5.Height), form)

    '        Dim dispon1 As Decimal = dispon - Val(dr.Item(6).ToString)
    '        If (dr.Item(14).ToString = "15") Then
    '            acu15 = acu15 + (CDbl(Val(dr.Item(4).ToString)) * CDbl(dr.Item(6).ToString))
    '        End If
    '        If (dr.Item(14).ToString = "18") Then
    '            acu18 = acu18 + (CDbl(Val(dr.Item(4).ToString)) * CDbl(dr.Item(6).ToString))
    '        End If
    '        y = y + 10
    '    Next
    '    y = y + 10
    '    Dim point6 As New Point(5, y)
    '    Dim point7 As New Point(280, y)
    '    e.Graphics.DrawLine(Pens.Black, point6, point7)
    '    y = y + 10
    '    e.Graphics.DrawString("Sub total:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
    '    e.Graphics.DrawString(lblSub, printFont4n, Brushes.Black, New RectangleF(140, y, 100, printFont4n.Height), form)
    '    y = y + 10
    '    e.Graphics.DrawString("Imp:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
    '    e.Graphics.DrawString(lblimp, printFont4n, Brushes.Black, New RectangleF(140, y, 100, printFont4n.Height), form)
    '    y = y + 10
    '    e.Graphics.DrawString("Total:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
    '    e.Graphics.DrawString(lbltotal, printFont4n, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)

    '    Dim sql As String = "SELECT idmetodopago,monto,dolares from public.tbl_pos_ventametodospago where idventa=" + facturaanterior().ToString + ";"
    '    Dim adapmetodospago As New OdbcDataAdapter(sql, conexion)
    '    Dim datametodopago As New DataSet
    '    adapmetodospago.Fill(datametodopago, "metodopago")
    '    Dim tmptotal As Integer=0
    '    Dim efectivo As Integer = 0
    '    Dim tarjeta As String = "no"
    '    For Each dr As DataRow In datametodopago.Tables("metodopago").Rows
    '        y = y + 10
    '        If (dr.Item(0) = metodospago.efectivo) Then
    '            e.Graphics.DrawString("Efectivo:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
    '            e.Graphics.DrawString("L. " + dr.Item(1).ToString, printFont5, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)
    '            llevacambio = 1

    '        ElseIf (dr.Item(0) = metodospago.tarjeta) Then
    '            e.Graphics.DrawString("T/C:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
    '            e.Graphics.DrawString("L. " + dr.Item(1).ToString, printFont5, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)
    '            tarjeta = "si"

    '        ElseIf (dr.Item(0) = metodospago.puntos) Then
    '            e.Graphics.DrawString("Puntos:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
    '            e.Graphics.DrawString("L. " + dr.Item(1).ToString, printFont5, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)

    '        ElseIf (dr.Item(0) = metodospago.creditoempleado) Then
    '            e.Graphics.DrawString("Credito Empleado:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
    '            e.Graphics.DrawString("L. " + dr.Item(1).ToString, printFont5, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)

    '        ElseIf (dr.Item(0) = metodospago.descuentoempleado) Then
    '            e.Graphics.DrawString("Descuento Empleado:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
    '            e.Graphics.DrawString("L. " + dr.Item(1).ToString, printFont5, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)

    '        ElseIf (dr.Item(0) = metodospago.wildcard) Then
    '            e.Graphics.DrawString("Wildcard:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
    '            e.Graphics.DrawString("L. " + dr.Item(1).ToString, printFont5, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)

    '        ElseIf (dr.Item(0) = metodospago.carnet)Then
    '            e.Graphics.DrawString("Carnet:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
    '            e.Graphics.DrawString("L. " + dr.Item(1).ToString, printFont5, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)

    '        ElseIf (dr.Item(0) = metodospago.efectivodollar) Then
    '            e.Graphics.DrawString("Dollar:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
    '            e.Graphics.DrawString("$. " + dr.Item(2).ToString, printFont5, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)

    '        ElseIf (dr.Item(0) = metodospago.cafegratis) Then
    '            e.Graphics.DrawString("Cafe Gratis:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
    '        End If
    '        e.Graphics.DrawString(dr.Item(1), printFont4n, Brushes.Black, New RectangleF(140, y, 100, printFont4n.Height), form)
    '        tmptotal += dr.Item(1)
    '    Next
    '    Dim cambiovuelto As Integer

    '    If (llevacambio = 1) Then
    '        cambiovuelto = tmptotal - tot
    '        If (cambiovuelto <= 0) Then
    '            cambiovuelto = 0
    '        End If
    '        y = y + 10
    '        e.Graphics.DrawString("Cambio:", printFont5, Brushes.Black, New RectangleF(46, y, 100, printFont5.Height), form)
    '        e.Graphics.DrawString("L. " + cambiovuelto.ToString, printFont4n, Brushes.Black, New RectangleF(140, y, 100, printFont5.Height), form)
    '    End If

    '    y = y + 10
    '    Dim pointi As New Point(5, y)
    '    Dim pointif As New Point(280, y)
    '    e.Graphics.DrawLine(Pens.Black, pointi, pointif)
    '    y = y + 10
    '    If tarjeta <> "no" Then
    '        Dim sqltc = "SELECT numerotarjteta,numerotransaccion,fechavencimiento FROM public.tbl_pos_ventacreditotarjeta WHERE idventa=" + facturaanterior().ToString + ";"
    '        comando = New OdbcCommand(sqltc, conexion)
    '        LECTOR = comando.ExecuteReader()
    '        If LECTOR.HasRows Then
    '            If LECTOR.Read Then
    '                Dim notarjeta As String = LECTOR(0).ToString
    '                Dim numerot As String = LECTOR(1).ToString
    '                Dim fecha As String = LECTOR(2).ToString
    '                e.Graphics.DrawString("No.Tarjeta:", printFont5, Brushes.Black, New RectangleF(20, y, 100, printFont5.Height), form)
    '                e.Graphics.DrawString(notarjeta, printFont5, Brushes.Black, New RectangleF(60, y, 100, printFont5.Height), form)
    '                y = y + 10
    '                e.Graphics.DrawString("Transaccion:", printFont5, Brushes.Black, New RectangleF(20, y, 100, printFont5.Height), form)
    '                e.Graphics.DrawString(numerot, printFont5, Brushes.Black, New RectangleF(60, y, 100, printFont5.Height), form)
    '                y = y + 10
    '                e.Graphics.DrawString("Fecha vencimiento:", printFont5, Brushes.Black, New RectangleF(20, y, 100, printFont5.Height), form)
    '                e.Graphics.DrawString(fecha, printFont5, Brushes.Black, New RectangleF(60, y, 100, printFont5.Height), form)
    '                y = y + 10
    '                pointi = New Point(5, y)
    '                pointif = New Point(280, y)
    '                e.Graphics.DrawLine(Pens.Black, pointi, pointif)
    '            End If
    '        End If
    '        y = y + 5
    '    End If

    '    e.Graphics.DrawString("Detalle de impuesto", printFontm, Brushes.Black, New RectangleF(5, y, 240, printFont4.Height), formato)
    '    y = y + 10
    '    e.Graphics.DrawString("Imp", printFontm, Brushes.Black, New RectangleF(0, y, 30, printFontm.Height), form)
    '    e.Graphics.DrawString("Base", printFontm, Brushes.Black, New RectangleF(40, y, 50, printFontm.Height), form)
    '    e.Graphics.DrawString("valor", printFontm, Brushes.Black, New RectangleF(90, y, 60, printFontm.Height), form)
    '    e.Graphics.DrawString("Precio Total", printFontm, Brushes.Black, New RectangleF(150, y, 85, printFontm.Height), form)
    '    y = y + 10
    '    Dim poin As New Point(5, y)
    '    Dim poinif As New Point(280, y)
    '    e.Graphics.DrawLine(Pens.Black, poin, poinif)
    '    y = y + 5
    '    e.Graphics.DrawString("Exent", printFontm, Brushes.Black, New RectangleF(0, y, 30, printFontm.Height), form)
    '    e.Graphics.DrawString("0.00", printFontm, Brushes.Black, New RectangleF(40, y, 50, printFontm.Height), form)
    '    e.Graphics.DrawString("0.00", printFontm, Brushes.Black, New RectangleF(90, y, 60, printFontm.Height), form)
    '    e.Graphics.DrawString("0.00", printFontm, Brushes.Black, New RectangleF(150, y, 85, printFontm.Height), form)
    '    y = y + 10
    '    If acu15 > 0 Then
    '        e.Graphics.DrawString("15%", printFontm, Brushes.Black, New RectangleF(0, y, 30, printFontm.Height), form)
    '        e.Graphics.DrawString(lblSub, printFontm, Brushes.Black, New RectangleF(40, y, 50, printFontm.Height), form)
    '        e.Graphics.DrawString(acu15.ToString("#,##0.00"), printFontm, Brushes.Black, New RectangleF(90, y, 60, printFontm.Height), form)
    '        e.Graphics.DrawString(lbltotal, printFontm, Brushes.Black, New RectangleF(150, y, 85, printFontm.Height), form)
    '    Else
    '        e.Graphics.DrawString("15%", printFontm, Brushes.Black, New RectangleF(0, y, 30, printFontm.Height), form)
    '        e.Graphics.DrawString("0.00", printFontm, Brushes.Black, New RectangleF(40, y, 50, printFontm.Height), form)
    '        e.Graphics.DrawString("0.00", printFontm, Brushes.Black, New RectangleF(90, y, 60, printFontm.Height), form)
    '        e.Graphics.DrawString("0.00", printFontm, Brushes.Black, New RectangleF(150, y, 85, printFontm.Height), form)
    '    End If
    '    y = y + 10
    '    If acu18 > 0 Then
    '        e.Graphics.DrawString("18%", printFontm, Brushes.Black, New RectangleF(0, y, 30, printFontm.Height), form)
    '        e.Graphics.DrawString(lblSub, printFontm, Brushes.Black, New RectangleF(40, y, 50, printFontm.Height), form)
    '        e.Graphics.DrawString(acu18.ToString("#,##0.00"), printFontm, Brushes.Black, New RectangleF(90, y, 60, printFontm.Height), form)
    '        e.Graphics.DrawString(lbltotal, printFontm, Brushes.Black, New RectangleF(150, y, 85, printFontm.Height), form)
    '    Else
    '        e.Graphics.DrawString("18%", printFontm, Brushes.Black, New RectangleF(0, y, 30, printFontm.Height), form)
    '        e.Graphics.DrawString("0.00", printFontm, Brushes.Black, New RectangleF(40, y, 50, printFontm.Height), form)
    '        e.Graphics.DrawString("0.00", printFontm, Brushes.Black, New RectangleF(90, y, 60, printFontm.Height), form)
    '        e.Graphics.DrawString("0.00", printFontm, Brushes.Black, New RectangleF(150, y, 85, printFontm.Height), form)
    '    End If
    '    y = y + 10
    '    e.Graphics.DrawString("Total", printFontm, Brushes.Black, New RectangleF(0, y, 30, printFontm.Height), form)
    '    e.Graphics.DrawString(lblSub, printFontm, Brushes.Black, New RectangleF(40, y, 50, printFontm.Height), form)
    '    e.Graphics.DrawString((acu18 + acu15).ToString("#,##0.00"), printFontm, Brushes.Black, New RectangleF(90, y, 60, printFontm.Height), form)
    '    e.Graphics.DrawString(lbltotal, printFontm, Brushes.Black, New RectangleF(150, y, 85, printFontm.Height), form)
    '    y = y + 10
    '    e.Graphics.DrawString("Lotes de venta y #interno: " + id_loteventa.ToString + " #" + numinterno.ToString, printFont4, Brushes.Black, New RectangleF(5, y, 240, printFont4.Height), formato)
    '    y = y + 10
    '    e.Graphics.DrawString("Rango de Correlativo", printFont4, Brushes.Black, New RectangleF(5, y, 240, printFont4.Height), formato)
    '    y = y + 10
    '    e.Graphics.DrawString(rgInicio + "/" + rgFinal, printFont4, Brushes.Black, New RectangleF(5, y, 240, printFont4.Height), formato)
    '    y = y + 10
    '    e.Graphics.DrawString("¡Gracias por su compra!", printFont4, Brushes.Black, New RectangleF(5, y, 240, printFont4.Height), formato)
    '    y = y + 10
    '    e.Graphics.DrawString("Original:Cliente", printFont5, Brushes.Black, 0, y)
    '    y = y + 10
    '    e.Graphics.DrawString("Copia: Obligado tributario emisor", printFont5, Brushes.Black, 0, y)
    '    If (almacen = "Kiosko") Then
    '        y = y + 10
    '        e.Graphics.DrawString("KIOSKO", printFont4n, Brushes.Black, New RectangleF(5, y, 280, printFont4.Height), formato)
    '    End If
    '    If (lblestado <> "Activa") Then
    '        y = y + 10
    '        e.Graphics.DrawString(lblestado, printFont, Brushes.Black, New RectangleF(0, y, 280, printFont.Height), formato)
    '    End If
    'End Sub

    Private Function actualizarproductos()
        con.openConection(conexion)
        Dim rn = DataGridView1.CurrentRow.Index
        Dim cn = DataGridView1.CurrentCell.ColumnIndex
        Dim caracter = DataGridView1.Rows(rn).Cells(0).Value
        Try
            Dim c As Decimal = caracter / 2
            'If DataGridView1.Columns(cn).Name = "Cantidad" Then

            If cn <> -1 Then
                Dim valorimp As Decimal
                Dim valorsub As Decimal
                Dim valortot As Decimal

                canti = CDec(DataGridView1.Rows(rn).Cells(0).Value)
                Dim existencia As Integer = Val(DataGridView1.Rows(rn).Cells(7).Value)
                If DataGridView1.Rows(rn).Cells(9).Value = "1" Then
                    existencia = 10000000
                End If
                If tipoventa = 1 Then
                    'Validar temporalmente el paso de preventa
                    existencia = 10000000
                End If
                If Activacafe = 1 Then
                    'Validar temporalmente el paso de preventa
                    existencia = 10000000
                End If
                If id_almacen = 1 Then
                    'Validar temporalmente el paso de preventa
                    existencia = 10000000
                End If

                If canti <= existencia Then

                    valorsub = CDec(Val(DataGridView1.Rows(rn).Cells(2).Value.ToString))
                    valorimp = CDec(Val(DataGridView1.Rows(rn).Cells(3).Value.ToString))
                    Dim precioInd = Math.Round((valorsub + valorimp), 2, MidpointRounding.ToEven)
                    If Activacafe = 1 Then
                        valortot = Math.Round(precioInd, 2, MidpointRounding.ToEven) * canti
                    Else
                        valortot = (Math.Round(precioInd, 2, MidpointRounding.ToEven)) * canti
                    End If


                    DataGridView1.Rows(rn).Cells(2).Value = valorsub.ToString("N2")
                    DataGridView1.Rows(rn).Cells(3).Value = valorimp.ToString("N2")
                    DataGridView1.Rows(rn).Cells(4).Value = Math.Round(valortot, 2, MidpointRounding.ToEven)
                    Me.lblSub.Text = "L. 0.00"
                    Me.lbltotal.Text = "L. 0.00"
                    Me.lblimp.Text = "L. 0.00"
                    Dim valorimpt As Decimal = 0
                    Dim valorsubt As Decimal = 0
                    Dim valortott As Decimal = 0
                    'DataGridView1.Refresh()


                    For i As Integer = 0 To DataGridView1.Rows.Count - 1
                        valorimpt = valorimpt + (CDec(Val(DataGridView1.Rows(i).Cells(3).Value.ToString)) * CDec(DataGridView1.Rows(i).Cells(0).Value))
                        valorsubt = valorsubt + (CDec(Val(DataGridView1.Rows(i).Cells(2).Value.ToString)) * CDec(DataGridView1.Rows(i).Cells(0).Value))
                        valortott = valortott + CDec(Val(DataGridView1.Rows(i).Cells(4).Value.ToString))
                    Next
                    lblSub.Text = "L." + valorsubt.ToString("#,##0.00")
                    lbltotal.Text = "L." + valortott.ToString("#,##0.00")
                    totalapagar = valortott
                    lblimp.Text = "L." + valorimpt.ToString("#,##0.00")
                    'If conexion.State = ConnectionState.Open Then
                    '    conexion.Close()
                    'End If
                    'conexion.Open()
                    comando = New Odbc.OdbcCommand("UPDATE public.tbl_pos_ventamaterial  SET subtotal='" + valorsub.ToString + "', precio=' " + valortot.ToString + "', impuesto='" + valorimp.ToString + "', cantidad='" + canti.ToString + "' WHERE id='" + DataGridView1.Rows(rn).Cells(5).Value.ToString + "'", conexion)
                    comando.ExecuteNonQuery()
                    'conexion.Close()

                    If tipoventa = 1 Then
                        comando = New Odbc.OdbcCommand("UPDATE public.tbl_recibo_preventa_detalles  SET subtotal='" + valorsub.ToString + "', precio=' " + valortot.ToString + "', impuesto='" + valorimp.ToString + "', cantidad='" + canti.ToString + "' WHERE id='" + (CInt(DataGridView1.Rows(rn).Cells(5).Value.ToString)).ToString + "'", conexion)
                        comando.ExecuteNonQuery()
                    End If
                Else
                    DataGridView1.Rows(rn).Cells(cn).Value = "1"
                    MsgBox("La cantidad ingresada supera la disponible.", MsgBoxStyle.Critical)
                    valorsub = CDec(Val(DataGridView1.Rows(rn).Cells(2).Value.ToString)) * 1
                    valorimp = CDec(Val(DataGridView1.Rows(rn).Cells(3).Value.ToString)) * 1
                    valortot = CDec(valorsub + valorimp) * 1
                    DataGridView1.Rows(rn).Cells(0).Value = 1
                    DataGridView1.Rows(rn).Cells(2).Value = valorsub.ToString("N2")
                    DataGridView1.Rows(rn).Cells(3).Value = valorimp.ToString("N2")
                    DataGridView1.Rows(rn).Cells(4).Value = valortot.ToString("N2")
                    'If conexion.State = ConnectionState.Open Then
                    '    conexion.Close()
                    'End If
                    'conexion.Open()
                    comando = New Odbc.OdbcCommand("UPDATE public.tbl_pos_ventamaterial  SET subtotal='" + valorsub.ToString + "', precio=' " + valortot.ToString + "', impuesto='" + valorimp.ToString + "', cantidad='" + canti.ToString + "' WHERE id='" + DataGridView1.Rows(rn).Cells(5).Value.ToString + "'", conexion)
                    comando.ExecuteNonQuery()
                    'conexion.Close()
                End If
                'recorredata()
                'Me.txtCodigo.Focus()
            End If


        Catch ex As Exception
            ''MessageBox.Show("Caracter incorrecto.")
        End Try
    End Function

    Private Sub txtbusqeda_KeyDown(sender As Object, e As KeyEventArgs) Handles txtbusqeda.KeyDown
        If e.KeyCode = Keys.Down Then
            If ListView1.Items.Count > 0 Then
                ListView1.Focus()
            End If

        End If
        If e.KeyCode = Keys.Left Then
            txtCodigo.Focus()
        End If
    End Sub

    Private Sub btnActualizarInventario_Click(sender As Object, e As EventArgs) Handles btnActualizarInventario.Click
        actualizarListaInventario()
    End Sub

    Private Function actualizarListaInventario()
        Dim cad As String = ""
        If tipoventa = 0 Then
            If id_almacen = 1 Then
                cad = "select idmaterial, disponible,totalpagoo,descripcion_1,codigo_barras from vistaMaterialesventa where idcentro='" + id_almacen.ToString + "' and codigo_barras not in ('CAFE105','CAFE106','CAFE104','CAFE107') ORDER BY disponible ASC"

            Else
                cad = "select idmaterial, disponible,totalpagoo,descripcion_1,codigo_barras from vistaMaterialesventa where idcentro='" + id_almacen.ToString + "' ORDER BY disponible ASC"

            End If
        Else
            cad = "select idmaterial, disponible,totalpagoo,descripcion_1,codigo_barras from vistaMaterialesventa where idcentro='" + id_almacen.ToString + "' and id_categoria in (65,66,67,68,69,70,71,72,73,74,75,76,77) ORDER BY disponible ASC"
        End If

        ListView1.View = View.Details
        ListView1.AllowColumnReorder = True
        ListView1.FullRowSelect = True
        ListView1.GridLines = True
        ListView1.Columns.Clear()
        ListView1.Columns.Add("ID", 0, HorizontalAlignment.Left)
        ListView1.Columns.Add("Disponible", 80, HorizontalAlignment.Left)
        ListView1.Columns.Add("Precio", 50, HorizontalAlignment.Left)
        ListView1.Columns.Add("Descripción", 250, HorizontalAlignment.Left)
        ListView1.Columns.Add("Cod. Barra", 0, HorizontalAlignment.Left)

        Dim cdatos As New OdbcDataAdapter(cad, conexion)
        Dim datan2 As New DataSet
        datan2.Clear()
        cdatos.Fill(datan2, "vistaMaterialesventa")
        Dv.Table = datan2.Tables("vistaMaterialesventa")
        cdatos.FillSchema(datan2.Tables("vistaMaterialesventa"), SchemaType.Source)
        For Each dr As DataRow In datan2.Tables("vistaMaterialesventa").Rows
            Dim str(4) As String
            Dim itm As ListViewItem
            str(0) = dr.Item(0).ToString
            str(1) = dr.Item(1).ToString
            str(2) = dr.Item(2).ToString
            str(3) = dr.Item(3).ToString
            str(4) = dr.Item(4).ToString
            itm = New ListViewItem(str)
            ListView1.Items.Insert(0, itm)
        Next
    End Function

    Private Sub btnReciboPreventa_Click(sender As Object, e As EventArgs) Handles btnReciboPreventa.Click
        If DataGridView1.Rows.Count > 0 Then
            My.Forms.frm_recibo_preventa.pgconection = conexion
            My.Forms.frm_recibo_preventa.numeroventa = CInt(idventa.ToString)
            My.Forms.frm_recibo_preventa.dgvProductos = DataGridView1
            My.Forms.frm_recibo_preventa.ShowDialog()
        Else
            MessageBox.Show("Debe Seleccionar al menos un producto.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If


    End Sub

    Public Function obtenerArticulorPreVenta(id_recibo As Integer)
        Dim sqlitemspreventa As String = "SELECT * FROM public.fn_select_detalle_orden_preventa(" + id_recibo.ToString + ");"
        Dim itempreventa As New OdbcDataAdapter(sqlitemspreventa, conexion)
        Dim dsietmpreventa As New DataSet
        dsietmpreventa.Clear()
        itempreventa.Fill(dsietmpreventa, "listarecibos")
        itempreventa.FillSchema(dsietmpreventa.Tables("listarecibos"), SchemaType.Source)
        DataGridView1.Rows.Clear()
        id_recibo_preventa = id_recibo
        For Each dr As DataRow In dsietmpreventa.Tables("listarecibos").Rows
            DataGridView1.Rows.Add(dr.Item(0).ToString, dr.Item(1).ToString, dr.Item(2).ToString, dr.Item(3).ToString, dr.Item(4).ToString, dr.Item(5).ToString, dr.Item(6).ToString, dr.Item(7).ToString, dr.Item(8).ToString, dr.Item(9).ToString, dr.Item(9).ToString)
        Next
        'If vistaItemsPreventa = "si" Then
        '    DataGridView1.Enabled = False
        'End If


        Dim sqlidfactura As String = "SELECT id_numero_venta,rtn,nombre_cliente,venta_empleado FROM public.tbl_recibo_preventa WHERE id_recibo=" + id_recibo.ToString + ";"
        comando = New OdbcCommand(sqlidfactura, conexion)
        LECTOR = comando.ExecuteReader()
        If LECTOR.HasRows Then
            venta_actual = idventa
            sessiones.idventa = CInt(LECTOR(0).ToString)
            codigo_cliente = LECTOR(1).ToString
            nombre_cliente = LECTOR(2).ToString
            lblnombrefactura.Text = "Numero Recibo: " + idventa.ToString
            'preventa_a_empleado = If(CInt(LECTOR(3).ToString) = 1, "si", "no")
        End If
        recorredata()
    End Function

    Private Sub DataGridView1_RowLeave(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.RowLeave

    End Sub

    Private Sub btncargalista_Click(sender As Object, e As EventArgs) Handles btncargalista.Click
        con.openConection(conexion)
        If lstventaespera.SelectedIndex <> -1 Then
            Dim Valo As Integer = lstventaespera.SelectedValue
            'tipo venta
            comando = New OdbcCommand("SELECT tipo  FROM tbl_POS_Venta where id='" + Valo.ToString + "'", conexion)
            LECTOR = comando.ExecuteReader
            If LECTOR.Read Then ' lee la consulta
                'tipoventa = CDbl(Val(LECTOR(0).ToString))
                'cambiotipoventa(tipoventa)
            End If

            Dim adaptador3 As New OdbcDataAdapter("SELECT id, subtotal, precio, impuesto, descripcion, cantidad,idmaterialcentro,subtotalfinal,factorimpuesto  FROM tbl_pos_ventamaterial where idventa='" + Valo.ToString + "'", conexion)
            Dim datan As New DataSet
            adaptador3.Fill(datan, "tbl_pos_ventamaterial")
            adaptador3.FillSchema(datan.Tables("tbl_pos_ventamaterial"), SchemaType.Source)
            Dim valorimp As Decimal
            Dim valorsub As Decimal
            Dim valortot As Decimal
            If datan.Tables("tbl_pos_ventamaterial").Rows.Count > 0 Then
                Thread.CurrentThread.CurrentCulture = New CultureInfo("es-HN")
                DataGridView1.Rows.Clear()
                For Each dr As DataRow In datan.Tables("tbl_pos_ventamaterial").Rows
                    valorimp = CDec(Val(dr.Item(3).ToString))
                    valorsub = CDec(Val(dr.Item(1).ToString))
                    valortot = CDec(Val(dr.Item(2).ToString))
                    'tb.Rows.Add(dr.Item(0).ToString + " " + dr.Item(1).ToString, dr.Item(0))
                    DataGridView1.Rows.Add(dr.Item(5).ToString, dr.Item(4).ToString, valorsub.ToString("#,##0.00"), valorimp.ToString("#,##0.00"), CDec(valortot), dr.Item(6).ToString, dr.Item(8).ToString, dr.Item(5).ToString, dr.Item(7).ToString)
                    'Me.lsPendienteLotes.Items.Add(dr.Item(0).ToString + " " + dr.Item(1).ToString)
                Next
                'conexion.Close()
                txtCodigo.Enabled = True
                txtCodigo.Focus()
                'recorredata()
                Me.lblSub.Text = "L. 0.00"
                Me.lbltotal.Text = "L. 0.00"
                Me.lblimp.Text = "L. 0.00"
                Dim valorimpt As Decimal = 0
                Dim valorsubt As Decimal = 0
                Dim valortott As Decimal = 0
                DataGridView1.Refresh()


                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    valorimpt = valorimpt + (CDec(Val(DataGridView1.Rows(i).Cells(3).Value.ToString)) * CDec(DataGridView1.Rows(i).Cells(0).Value))
                    valorsubt = valorsubt + (CDec(Val(DataGridView1.Rows(i).Cells(2).Value.ToString)) * CDec(DataGridView1.Rows(i).Cells(0).Value))
                    valortott = CDec(valortott) + (CDec(Val(DataGridView1.Rows(i).Cells(4).Value.ToString)))


                Next
                lblSub.Text = "L." + valorsubt.ToString("#,##0.00")
                lbltotal.Text = "L." + valortott.ToString("#,##0.00")
                totalapagar = valortott
                lblimp.Text = "L." + valorimpt.ToString("#,##0.00")
                Me.btncancela.Enabled = True
                Me.btnespera.Enabled = True
                Me.btnpago.Enabled = True
                Me.Button4.Enabled = False
                idventa = Valo
            Else
                MessageBox.Show("No hay articulos agregados en esta lista de espera", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub


    Public Sub cargarListadoEspera()
        Dim sqlventaespera = "SELECT id, to_char(fechahorai, 'DD/MM/YYYY, HH12:MI:SS') as hori, nombre FROM tbl_pos_venta where estado = '1' and idloteventa=" + sessiones.id_loteventa.ToString + ";"
        Dim adaptador3 As New OdbcDataAdapter(sqlventaespera, conexion)
        Dim datan As New DataSet
        adaptador3.Fill(datan, "tbl_pos_venta")
        adaptador3.FillSchema(datan.Tables("tbl_pos_venta"), SchemaType.Source)
        Dim tb As New DataTable
        tb.Columns.Add("Text", GetType(String))
        tb.Columns.Add("Value", GetType(Integer))
        For Each dr As DataRow In datan.Tables("tbl_pos_venta").Rows
            tb.Rows.Add(dr.Item(0).ToString + " " + dr.Item(2).ToString, dr.Item(0))
            'Me.lsPendienteLotes.Items.Add(dr.Item(0).ToString + " " + dr.Item(1).ToString)
        Next
        lstventaespera.DisplayMember = "Text"
        lstventaespera.ValueMember = "Value"
        lstventaespera.DataSource = tb
    End Sub

End Class