Imports System.Data.Odbc
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Data
Imports System.Globalization
Imports System.Threading
Imports POSGDC.conexion


Public Class frmlotesventa
    Dim con As New conexion
    Dim conexion As New Odbc.OdbcConnection()
    Dim comando As New Odbc.OdbcCommand
    Dim LECTOR As OdbcDataReader
    Dim tipodelote As Integer

    Public Property pgconection() As OdbcConnection
        Set(value As OdbcConnection)
            conexion = value
        End Set
        Get
            Return Me.conexion
        End Get
    End Property

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        My.Forms.POSVENTA.pgconection = conexion
        My.Forms.POSVENTA.Show()
        Me.Hide()
        My.Forms.frmnuevolote.Hide()
    End Sub

    Private Sub frmLotesventa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.lblusuario.Text = sessiones.usuario
        Me.lblalma.Text = sessiones.almacen
        conexion = pgconection
        con.openConection(conexion)

        dtp_fechafinal.Enabled = False
        dtp_fechainicial.Enabled = False
        btn_buscarlotes.Enabled = False
        chk_filtrofecha.Enabled = False
        'dtp_fechafinal.CustomFormat = "yyyy/MM/dd"
        'dtp_fechainicial.CustomFormat = "yyyy/MM/dd"

        'Me.DataGridView1.Rows.Clear()
        'Dim adaptador3 As New OdbcDataAdapter("select id, to_char(fechahorai, 'DD/MM/YYYY, HH12:MI:SS') as hori ,montoinicial  from tbl_pos_loteventa where estado = true and id_usuario_creo='" + id_usuario.ToString + "' and idposventa='" + sessiones.id_pos.ToString + "' order by id desc", pgconection)
        'Dim datan As New DataSet
        'adaptador3.Fill(datan, "tbl_pos_loteventa")
        'adaptador3.FillSchema(datan.Tables("tbl_pos_loteventa"), SchemaType.Source)
        'For Each dr As DataRow In datan.Tables("tbl_pos_loteventa").Rows
        '    DataGridView1.Rows.Add(dr.Item(0).ToString, dr.Item(1).ToString, dr.Item(2).ToString)
        'Next
    End Sub

    Private Sub btncarga_Click(sender As Object, e As EventArgs) Handles btncarga.Click
        My.Forms.frmVenta.pgconection = conexion
        My.Forms.frmVenta.Show()
        Me.Hide()
    End Sub

    Public Function cargartodoslotes()
        Me.lblusuario.Text = sessiones.usuario
        Me.lblalma.Text = sessiones.almacen
        Me.DataGridView1.Rows.Clear()
        Dim adaptador3 As New OdbcDataAdapter("select id, to_char(fechahorai, 'DD/MM/YYYY, HH12:MI:SS') as hori ,montoinicial  from tbl_pos_loteventa where estado = true and id_usuario_creo='" + id_usuario.ToString + "' and idposventa='" + sessiones.id_pos.ToString + "' order by id desc", conexion)
        Dim datan As New DataSet
        adaptador3.Fill(datan, "tbl_pos_loteventa")
        adaptador3.FillSchema(datan.Tables("tbl_pos_loteventa"), SchemaType.Source)
        For Each dr As DataRow In datan.Tables("tbl_pos_loteventa").Rows
            DataGridView1.Rows.Add(dr.Item(0).ToString, dr.Item(1).ToString, dr.Item(2).ToString)
        Next
    End Function



    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        My.Forms.frmCierre.pgconection = conexion
        My.Forms.frmCierre.Show()
        Me.Close()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.RowIndex < 0 Then
            Exit Sub
        End If

        Dim grid = DirectCast(sender, DataGridView)

        If TypeOf grid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn Then
            If grid.Columns(e.ColumnIndex).Name = "btn_edit" Then
                Dim Valo As Integer = DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString

                comando = New OdbcCommand("select id, to_char(fechahorai, 'DD/MM/YYYY, HH12:MI:SS'),montoinicial,tipolote from tbl_pos_loteventa where id='" + Valo.ToString + "'", conexion)
                LECTOR = comando.ExecuteReader 'lector va tomar la consulta
                Thread.CurrentThread.CurrentCulture = New CultureInfo("es-HN")
                Dim digitoTotal As Decimal
                If LECTOR.Read Then ' lee la consulta
                    Me.lblNUMLOTE.Text = "Num. de lote de venta: " + LECTOR(0).ToString
                    id_loteventa = LECTOR(0)
                    digitoTotal = CDbl(Val(LECTOR(2)))
                    montoinicio = CDbl(Val(LECTOR(2)))
                    tipoventa = LECTOR(3)
                    Console.WriteLine(tipoventa)
                    Dim a As String
                    a = If((tipoventa = 1), "Lote: Preventa", "Lote: Venta Normal")
                    lbltipoventa.Text = a
                End If
                Me.lblMonto.Text = "Monto: L. " + digitoTotal.ToString("#,##0.00")

                Me.Button3.Enabled = True
                'conexion.Close()
                btncarga.Enabled = True
            End If
        End If
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        My.Forms.POSVENTA.pgconection = conexion
        My.Forms.POSVENTA.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        My.Forms.frmnuevolote.pgconection = conexion
        My.Forms.frmnuevolote.ShowDialog()
    End Sub

    Private Sub chk_filtrofecha_CheckedChanged(sender As Object, e As EventArgs) Handles chk_filtrofecha.CheckedChanged
        If (chk_filtrofecha.Checked) Then
            dtp_fechafinal.Enabled = True
            dtp_fechainicial.Enabled = True
            btn_buscarlotes.Enabled = True
        Else
            dtp_fechafinal.Enabled = False
            dtp_fechainicial.Enabled = False
            btn_buscarlotes.Enabled = False
        End If
    End Sub

    Private Sub rdb_preventa_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_preventa.CheckedChanged
        tipodelote = 1
        cargartodoFiltrado(tipodelote)
        chk_filtrofecha.Enabled = True
    End Sub

    Private Sub rdb_ventanormal_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_ventanormal.CheckedChanged
        tipodelote = 0
        cargartodoFiltrado(tipodelote)
        chk_filtrofecha.Enabled = True
    End Sub

    Private Sub rdb_todos_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_todos.CheckedChanged
        chk_filtrofecha.Enabled = False
        dtp_fechafinal.Enabled = False
        dtp_fechainicial.Enabled = False
        btn_buscarlotes.Enabled = False
        cargartodoslotes()
    End Sub

    Private Function cargartodoFiltrado(ventatipo As Integer)
        Me.DataGridView1.Rows.Clear()
        Dim sql = "select id, to_char(fechahorai, 'DD/MM/YYYY, HH12:MI:SS') as hori ,montoinicial  from tbl_pos_loteventa where estado = true and id_usuario_creo='" + id_usuario.ToString + "' and idposventa='" + sessiones.id_pos.ToString + "' and tipolote=" + ventatipo.ToString + " order by id desc"
        Dim adaptador3 As New OdbcDataAdapter(sql, conexion)
        Dim datan As New DataSet
        adaptador3.Fill(datan, "tbl_pos_loteventa")
        adaptador3.FillSchema(datan.Tables("tbl_pos_loteventa"), SchemaType.Source)
        For Each dr As DataRow In datan.Tables("tbl_pos_loteventa").Rows
            DataGridView1.Rows.Add(dr.Item(0).ToString, dr.Item(1).ToString, dr.Item(2).ToString)
        Next
    End Function

    Private Function cargartipoloteFechas(ventatipo As Integer, fechainicial As String, fechafinal As String)
        Me.DataGridView1.Rows.Clear()
        Dim sql = "select id, to_char(fechahorai, 'DD/MM/YYYY, HH12:MI:SS') as hori ,montoinicial  from tbl_pos_loteventa where estado = true and id_usuario_creo='"
        sql += id_usuario.ToString + "' and idposventa='" + sessiones.id_pos.ToString
        sql += "' and tipolote=" + ventatipo.ToString
        sql += " and fecha_creacion between '" + fechainicial + "' and '" + fechafinal
        sql += "' order by id desc;"
        Console.WriteLine(sql)
        Dim adaptador3 As New OdbcDataAdapter(sql, conexion)
        Dim datan As New DataSet
        adaptador3.Fill(datan, "tbl_pos_loteventa")
        adaptador3.FillSchema(datan.Tables("tbl_pos_loteventa"), SchemaType.Source)
        For Each dr As DataRow In datan.Tables("tbl_pos_loteventa").Rows
            DataGridView1.Rows.Add(dr.Item(0).ToString, dr.Item(1).ToString, dr.Item(2).ToString)
        Next
    End Function

    Private Sub btn_buscarlotes_Click(sender As Object, e As EventArgs) Handles btn_buscarlotes.Click
        Dim fechafin As String = dtp_fechafinal.Value.ToString("yyyy/MM/dd")
        Dim fechaini As String = dtp_fechainicial.Value.ToString("yyyy/MM/dd")

        If (fechaini > fechafin) Then
            MessageBox.Show("Error en el rango de las fechas.", "Fechas incorrectas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            cargartipoloteFechas(tipodelote, fechaini, fechafin)
        End If


    End Sub

    Private Sub btn_lotescerrados_Click(sender As Object, e As EventArgs) Handles btn_lotescerrados.Click
        My.Forms.frm_BuscarLoteCerrado.pgconection = conexion
        My.Forms.frm_BuscarLoteCerrado.ShowDialog()
    End Sub
End Class