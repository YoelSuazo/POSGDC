Module sessiones

    Friend cadenaConexion As String
    Friend conexion As New Odbc.OdbcConnection("DSN=GRUPOGDCPRIMARIO")
    Friend comando As New Odbc.OdbcCommand
    Friend id_usuario As Integer
    Friend id_almacen As Integer
    Friend id_pos As Integer
    Friend id_loteventa As Integer
    Friend usuario As String
    Friend usuariotemp As String
    Friend almacen As String
    Friend idventa As Integer
    Friend TotalPago As Decimal
    Friend disponible As Decimal
    Friend fila As Integer
    Friend columna As Integer
    Friend tipoventa As Integer
    Friend Activacafe As Integer
    Friend idfactura As Integer
    Friend numeroventa As Integer
    Friend numeroLOTEventa As Integer
    Friend montoinicio As Decimal
    Friend subtotalSesion As Decimal
    Friend impSesion As Decimal
    Friend regresaFactura As Integer
    Friend userlog As String
    Friend infoperfil As String
    Friend empleadoventa As String
    Friend codigoEmpleado As String
    Friend tipo_venta_recibo As Integer = 2




    Function Fg_SoloNumeros(ByVal Digito As String, ByVal Texto As String) As Boolean
        Dim Dt_Entero As Integer = CInt(Asc(Digito))
        If Dt_Entero = 8 Then
            Fg_SoloNumeros = False
        Else
            If InStr("1234567890.", Digito) = 0 Then
                Fg_SoloNumeros = True
            ElseIf IsNumeric(Texto) = True Then
                Fg_SoloNumeros = False
            ElseIf IsNumeric(Texto) = False Then
                Fg_SoloNumeros = True
            End If
        End If
        Return Fg_SoloNumeros
    End Function

End Module
