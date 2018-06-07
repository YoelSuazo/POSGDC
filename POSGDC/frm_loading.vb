Imports System.Data.Odbc
Imports POSGDC.conexion
Public Class frm_loading
    Dim conexion As New Odbc.OdbcConnection
    Public con As conexion

    Public Property pgconection() As OdbcConnection
        Set(value As OdbcConnection)
            conexion = value
        End Set
        Get
            Return Me.conexion
        End Get
    End Property

    Private Sub frm_loading_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conexion = pgconection
        Timer1.Start()

    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        comprobarconexion()
    End Sub

    Public Function comprobarconexion()
        Try
            conexion.Open()
            If (conexion.State = ConnectionState.Open) Then
                Timer1.Stop()
                Me.Close()
            End If
        Catch ex As Exception

        End Try
    End Function

    Private Sub btn_salir_Click(sender As Object, e As EventArgs) Handles btn_salir.Click
        Dim r As DialogResult = MessageBox.Show("Presiones YES para salir y NO para esperar por la conexion.", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (DialogResult.Yes = r) Then
            Application.Exit()
            End
        End If
    End Sub
End Class