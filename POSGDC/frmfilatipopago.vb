Imports System.Data.Odbc
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Data
Imports System.Globalization
Imports System.Threading
Imports POSGDC.conexion
Public Class frmfilatipopago
    Dim con As New conexion
    Dim conexion As New Odbc.OdbcConnection()
    'Dim conexion As New Odbc.OdbcConnection("DSN=ORIECOMP")
    Dim comando As New Odbc.OdbcCommand
    Dim LECTOR As OdbcDataReader

    Public Property pgconection() As OdbcConnection
        Set(value As OdbcConnection)
            conexion = value
        End Set
        Get
            Return Me.conexion
        End Get
    End Property

    Private Sub frmfilatipopago_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conexion = pgconection
        con.openConection(conexion)
        'conexion.Open()
        Thread.CurrentThread.CurrentCulture = New CultureInfo("es-HN")
        Dim adaptador3 As New OdbcDataAdapter("SELECT id, tipo FROM tbl_pos_metodospago", conexion)
        Dim datan As New DataSet
        adaptador3.Fill(datan, "tbl_pos_metodospago")
        adaptador3.FillSchema(datan.Tables("tbl_pos_metodospago"), SchemaType.Source)
        Dim tb As New DataTable
        tb.Columns.Add("Text", GetType(String))
        tb.Columns.Add("Value", GetType(Integer))
        For Each dr As DataRow In datan.Tables("tbl_pos_metodospago").Rows
            tb.Rows.Add(dr.Item(1).ToString, dr.Item(0))
            'Me.lsPendienteLotes.Items.Add(dr.Item(0).ToString + " " + dr.Item(1).ToString)
        Next
        cmblista.DisplayMember = "Text"
        cmblista.ValueMember = "Value"
        cmblista.DataSource = tb
        Me.TextBox1.Text = disponible.ToString("N2")
        Me.lblPropuesto.Text = "L." + disponible.ToString("#,##0.00")
        'conexion.Close()
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



    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        solonumeros(e)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If Me.TextBox1.Text <> "" Then
            If CDbl(Me.TextBox1.Text) > disponible Then
                MsgBox("Por favor ingrese un monto no mayor al propuesto")
            Else
                disponible = disponible - CDbl(Me.TextBox1.Text)
                'My.Forms.frmMetodoPago.DataGridView1.Rows.Add(CDbl(Me.TextBox1.Text), Me.cmblista.Text)
                Me.Close()
            End If
        Else
            MsgBox("Por favor ingrese el monto")
        End If

    End Sub
End Class