Imports System.Data.Odbc

Public Class frm_credito
    Dim con As New conexion
    Dim conexion As New Odbc.OdbcConnection()
    Dim comando As New Odbc.OdbcCommand
    Dim LECTOR As OdbcDataReader
    Dim valcod As String
    Dim Dv As New DataView

    Public Property pgconection() As OdbcConnection
        Set(value As OdbcConnection)
            conexion = value
        End Set
        Get
            Return Me.conexion
        End Get
    End Property

    Private Sub frm_credito_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conexion = pgconection
        con.openConection(conexion)
    End Sub
End Class