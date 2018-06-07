Imports System.Configuration
Imports System.Data.Odbc
Imports System.Threading

Public Class conexion
    Dim host = ConfigurationSettings.AppSettings("host").ToString
    Dim port = ConfigurationSettings.AppSettings("port").ToString
    Dim user = ConfigurationSettings.AppSettings("user").ToString
    Dim pass = ConfigurationSettings.AppSettings("pass").ToString
    Dim db = ConfigurationSettings.AppSettings("database").ToString
    Dim c As OdbcConnection
    Dim strCon = "Driver={PostgreSQL Unicode};database=" + db + ";server=" + host + ";port=" + port + ";uid=postgres;sslmode=disable;readonly=0;protocol=7.4;User ID=" + user + ";password=" + pass + ";"
    Dim conexion As New Odbc.OdbcConnection(strCon)

    Property pg_conecction As OdbcConnection
        Get
            Return conexion

        End Get
        Set(value As OdbcConnection)
        End Set
    End Property

    Public Function openConection(conection As OdbcConnection) As OdbcConnection
        Try
            If (conection.State = ConnectionState.Open) Then
                conection.Close()
            End If
            conection.Open()
        Catch
            My.Forms.frm_loading.pgconection = conection
            If My.Forms.frm_loading.Visible = False Then
                My.Forms.frm_loading.ShowDialog()
            End If
        End Try

    End Function
End Class
