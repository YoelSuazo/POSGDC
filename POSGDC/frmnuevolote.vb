Imports System.Data.Odbc
Imports POSGDC.conexion
Public Class frmnuevolote
    Dim con As New conexion
    'Dim conexion As New Odbc.OdbcConnection("DSN=ORIECOMP")
    Dim conexion As New Odbc.OdbcConnection()
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

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        solonumeros(e)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        con.openConection(conexion)
        TextBox1.Focus()
        Dim tp As Integer = -1
        If rdbpreventa.Checked = True Then
            tp = 1
        End If
        If rdbtipo.Checked = True Then
            tp = 0
        End If
        If tp = -1 Then
            MsgBox("Por favor ingrese que tipo de lote de venta", MsgBoxStyle.Critical)
        Else

            Dim valor As String
            valor = If(Me.TextBox1.Text <> "", obtenerValor(TextBox1.Text), 0)
            If valor <> "" And valor > 0 Then
                'conexion.Open()
                comando = New OdbcCommand("select fn_vtinsertaLoteventa('" + valor.ToString + "','" + sessiones.id_pos.ToString + "','" + sessiones.id_usuario.ToString + "','" + tp.ToString + "')", conexion)
                LECTOR = comando.ExecuteReader
                If LECTOR.Read Then ' lee la consulta
                    id_loteventa = LECTOR(0)
                End If
                'conexion.Close()
                My.Forms.frmlotesventa.cargartodoslotes()
                Me.Close()

            Else
                MsgBox("Por favor ingrese un monto valido", MsgBoxStyle.Critical)
            End If

        End If


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

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub frmnuevolote_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conexion = pgconection
        con.openConection(conexion)
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub


    Private Function obtenerValor(valor As String)
        Try
            Convert.ToDouble(valor.ToString)

            Return Convert.ToDouble(valor.ToString)

        Catch ex As Exception
            'MessageBox.Show("Caracter no reconocido, Ingrese solo numeros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0
        End Try
    End Function

End Class