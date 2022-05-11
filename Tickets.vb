Imports Cklass.Net
Imports EGlobal.TotalPosSDKNet.Interfaz.Catalog
Imports EGlobal.TotalPosSDKNet.Interfaz.Layout
Imports System.Text

Public Class Tickets
    Public SucNombre As String = ""
    Public SucDomicilio As String = ""
    Public SucColoinia As String = ""
    Public SucCiudad As String = ""
    Public SucCaja As String = ""
    Public MinMonto As Double = 0
    Public MaxMeses As Integer = 0
    Dim cklassSuc As New ckSucursal.CklassSucursal()

    Public Function Pagare(ByVal pOpcion As String, ByVal operation As Operacion, ByVal response As Respuesta, ByVal typeCardSelect As String) As String
        Dim resultado As New StringBuilder("")
        Try
            resultado.AppendLine(ckNet.StrCEN("BBVA Bancomer FECHA " & Format(Now.Date, "dd/MMM/yy").ToUpper & " HORA " & Format(Now, "HH:mm"), 40))
            resultado.AppendLine(ckNet.StrCEN("CKLASS " & cklassSuc.Sucursal, 40))
            resultado.AppendLine(ckNet.StrCEN(cklassSuc.SucursalDomicilioF, 40))
            resultado.AppendLine(ckNet.StrCEN(cklassSuc.SucursalColonia, 40))
            resultado.AppendLine(ckNet.StrCEN(cklassSuc.SucursalCiudad, 40))

            If response.CodigoRespuesta = "00" Then
                If response.Leyenda.Trim <> "" Then resultado.AppendLine(ckNet.StrCEN(response.Leyenda.Trim, 40))
            ElseIf response.CodigoRespuesta = "05" Or response.CodigoRespuesta = "04" Then
                resultado.AppendLine(ckNet.StrCEN(response.CodigoRespuesta & "=" & "DECLINADA", 40))
            Else
                resultado.AppendLine("!" & response.CodigoRespuesta & "=" & response.Leyenda.Trim & "!")
            End If

            If pOpcion = "COPIA" Then
                resultado.AppendLine(ckNet.StrCEN(Format(Val(Mid(response.NumeroTarjeta, 13, 4)), "XXXX XXXX XXXX 0000"), 40))
            Else
                resultado.AppendLine(ckNet.StrCEN(Format(Val(Mid(response.NumeroTarjeta, 1, 8)), "0000 0000") & " " & Format(Val(Mid(response.NumeroTarjeta, 9, 8)), "0000 0000"), 40))
            End If

            If response.NumeroTarjeta.Trim <> "" Or response.EmisorTarjeta.Trim <> "" Then resultado.AppendLine(ckNet.StrCEN(response.NumeroTarjeta & " " & response.EmisorTarjeta, 40))
            resultado.AppendLine(ckNet.StrIZQ("TIPO: " & IIf(response.ProductoTarjeta.Contains("c"), "CREDITO", (IIf(response.ProductoTarjeta.Contains("d"), "DEBITO", IIf(typeCardSelect.Contains("c"), "CREDITO", "DEBITO")))), 20))

            If Val(Operacion.Venta Like operation) Then
                resultado.AppendLine(ckNet.StrIZQ("VENTA " & IIf(response.Parcializacion.ToString() <> "", response.Parcializacion.ToString() & " Meses sin intereses", "NORMAL"), 40))
            ElseIf Val(Operacion.CancelacionVenta) Then
                resultado.AppendLine(ckNet.StrIZQ("CANCELACION " & IIf(response.Parcializacion <> "", response.Parcializacion & " Meses sin intereses", "NORMAL"), 40))
            End If

            resultado.AppendLine(ckNet.StrDER(response.ReferenciaDelComercio & " TOTAL M.N. " & Format(Convert.ToDouble(response.Importe), "Currency"), 40))

            If response.Cash <> "" Then
                Dim finalTotal = Convert.ToDouble(response.Importe) + Convert.ToDouble(response.Cash) '+ Convert.ToDouble(response.CashComision)
                resultado.AppendLine(ckNet.StrDER("DISP. EFECTIVO " & Format(response.Cash, "Currency"), 40))
                'resultado.AppendLine(ckNet.StrDER("COM. DISP. EFECTIVO " & Format(response.CashComision, "Currency"), 40))
                resultado.AppendLine(ckNet.StrDER("Total a pagar " & Format(finalTotal, "Currency"), 40))
            End If


            If response.PesosRedimidos <> "" Then
                resultado.AppendLine(ckNet.StrDER("Pagado con Puntos BBVA: " & Format(response.PesosRedimidos, "Currency"), 40))
                resultado.AppendLine(ckNet.StrDER("Total a pagar " & Format(response.Importe - response.PesosRedimidos, "Currency"), 40))
            End If

            If response.CodigoRespuesta = "00" And response.Autorizacion.Trim <> "" Then
                resultado.AppendLine(ckNet.StrCEN("BC " & IIf(response.ModoLectura.Equals("05"), "|@1", IIf(response.ModoLectura.Equals("01"), "T1", IIf(response.ModoLectura.Equals("80") Or response.ModoLectura.Equals("90"), "D@1", "C@1"))), 40))
                resultado.AppendLine(ckNet.StrCEN("Autorizacion: " & response.Autorizacion, 40))
            Else
                If Val(Operacion.Venta Like operation) Then
                    resultado.AppendLine(ckNet.StrCEN("***" + response.Leyenda + "***", 40))
                Else
                    resultado.AppendLine(ckNet.StrCEN("!!!ERROR!!!", 40))
                End If
            End If

            If response.CriptogramaTarjeta.Trim <> "" Then resultado.AppendLine(ckNet.StrCEN(response.CriptogramaTarjeta.Trim, 40))
            If response.IdAplicacionTarjeta.Trim <> "" Then resultado.AppendLine(ckNet.StrCEN("AID: " + response.IdAplicacionTarjeta.Trim, 40))
            resultado.AppendLine(ckNet.StrIZQ("Referencia: " & Format(Val(response.ReferenciaFinanciera), "00000000"), 40))
            resultado.AppendLine(ckNet.StrIZQ("Afiliacion: " & Format(Val(response.Afiliacion), "00000000"), 20) & ckNet.StrDER("Sucursal: " & Format(Val(cklassSuc.SucursalId), "0000"), 20))
            resultado.AppendLine(ckNet.StrIZQ("Sec. Txn: " & Format(Val(response.SecuenciaTransaccion), "0000"), 20) & ckNet.StrDER("Terminal: " & Format(Val(ckNet.Terminal), "0000"), 20))

            If response.PesosRedimidos <> "" Then
                resultado.AppendLine("")
                resultado.AppendLine(ckNet.StrIZQ("PUNTOS BANCOMER", 40))
                resultado.AppendLine(ckNet.StrIZQ("Saldo anterior ($): " & CInt(response.SaldoAnteriorPesos).ToString, 40))
                resultado.AppendLine(ckNet.StrIZQ("Saldo anterior (PTS): " & CInt(response.SaldoAnteriorPuntos).ToString, 40))
                resultado.AppendLine(ckNet.StrIZQ("Saldo actual pesos ($): " & CDbl(response.SaldoDisponiblePesos).ToString, 40))
                resultado.AppendLine(ckNet.StrIZQ("Saldo actual (PTS):   " & CInt(response.SaldoPuntosDisponibles).ToString, 40))
                resultado.AppendLine(ckNet.StrIZQ("Pesos redimidos ($): " & CDbl(response.PesosRedimidos).ToString, 40))
                resultado.AppendLine(ckNet.StrIZQ("Redimidos (PTS):      " & CInt(response.PuntosRedimidos).ToString, 40))
            End If

            If response.CodigoRespuesta = "00" Then
                If response.Firma.Equals(Firma.Electronica) Then
                    resultado.AppendLine(ckNet.StrCEN("AUTORIZADO MEDIANTE FIRMA ELECTRONICA", 40))
                ElseIf response.Firma.Equals(Firma.Autografa) Then
                    resultado.AppendLine(ckNet.StrCEN("FIRMA __________________________________", 40))
                    If response.Tarjetahabiente.Trim <> "" Then resultado.AppendLine(ckNet.StrCEN(response.Tarjetahabiente.Trim, 40))
                Else
                    resultado.AppendLine(ckNet.StrCEN("AUTORIZADO SIN FIRMA", 40))
                End If

                If pOpcion = "ORIGINAL" Then
                    resultado.AppendLine(ckNet.StrCEN("COPIA COMERCIO", 40))
                Else
                    resultado.AppendLine(ckNet.StrCEN("COPIA CLIENTE", 40))
                End If

                resultado.AppendLine(ckNet.StrIZQ("POR ESTE PAGARE ME OBLIGO INCONDICIONAL", 40))
                resultado.AppendLine(ckNet.StrIZQ("MENTE A PAGAR A LA ORDEN DEL BANCO ACRE", 40))
                resultado.AppendLine(ckNet.StrIZQ("DITANTE EL IMPORTE DE ESTE TITULO. ESTE", 40))
                resultado.AppendLine(ckNet.StrIZQ("PAGARE PROCEDE DEL CONTRATO DE APERTURA", 40))
                resultado.AppendLine(ckNet.StrIZQ("DE CREDITO QUE  EL BANCO ACREDITANTE  Y", 40))
                resultado.AppendLine(ckNet.StrIZQ("EL TARJETAHABIENTE TIENEN CELEBRADO.", 40))
                resultado.AppendLine(ckNet.StrIZQ("PAGARE  NEGOCIABLE  UNICAMENTE", 40))
                resultado.AppendLine(ckNet.StrIZQ("CON  INSTITUCIONES  DE CREDITO.", 40))
            End If

        Catch ex As Exception
            Throw New Exception("Error al generar pagaré...!", ex)
        End Try
        Return resultado.ToString
    End Function


    Public Function ConsultaPuntos(ByVal response As Respuesta) As String
        Dim resultado As New StringBuilder("")
        Try
            resultado.AppendLine(ckNet.StrCEN("BBVA Bancomer FECHA " & Format(Now.Date, "dd/MMM/yy").ToUpper & " HORA " & Format(Now, "HH:mm"), 40))
            resultado.AppendLine(ckNet.StrCEN("CKLASS " & cklassSuc.Sucursal, 40))
            resultado.AppendLine(ckNet.StrCEN(cklassSuc.SucursalDomicilioF, 40))
            resultado.AppendLine(ckNet.StrCEN(cklassSuc.SucursalColonia, 40))
            resultado.AppendLine(ckNet.StrCEN(cklassSuc.SucursalCiudad, 40))

            If response.CodigoRespuesta = "00" Then
                If response.Leyenda.Trim <> "" Then resultado.AppendLine(ckNet.StrCEN(response.Leyenda.Trim, 40))
            ElseIf response.CodigoRespuesta = "05" Or response.CodigoRespuesta = "04" Then
                resultado.AppendLine(ckNet.StrCEN(response.CodigoRespuesta & "=" & "DECLINADA", 40))
            Else
                resultado.AppendLine("!" & response.CodigoRespuesta & "=" & response.Leyenda.Trim & "!")
            End If

            resultado.AppendLine(ckNet.StrCEN(Format(Val(Mid(response.NumeroTarjeta, 1, 8)), "0000 0000") & " " & Format(Val(Mid(response.NumeroTarjeta, 9, 8)), "0000 0000"), 40))
            resultado.AppendLine(ckNet.StrIZQ("TIPO: " & IIf(response.ProductoTarjeta.Contains("c"), "CREDITO", "DEBITO"), 20))
            resultado.AppendLine(ckNet.StrIZQ("CONSULTA DE PUNTOS", 40))

            If response.CodigoRespuesta = "00" And response.Autorizacion.Trim <> "" Then
                resultado.AppendLine(ckNet.StrCEN("BC " & IIf(response.ModoLectura.Equals("05"), "|@1", IIf(response.ModoLectura.Equals("01"), "T1", IIf(response.ModoLectura.Equals("80") Or response.ModoLectura.Equals("90"), "D@1", "C@1"))), 40))
                resultado.AppendLine(ckNet.StrCEN("Autorizacion: " & response.Autorizacion, 40))
            End If

            If response.CriptogramaTarjeta.Trim <> "" Then resultado.AppendLine(ckNet.StrCEN(response.CriptogramaTarjeta.Trim, 40))
            If response.IdAplicacionTarjeta.Trim <> "" Then resultado.AppendLine(ckNet.StrCEN("AID: " + response.IdAplicacionTarjeta.Trim, 40))
            resultado.AppendLine(ckNet.StrIZQ("Referencia: " & Format(Val(response.ReferenciaFinanciera), "00000000"), 40))
            resultado.AppendLine(ckNet.StrIZQ("Afiliacion: " & Format(Val(response.Afiliacion), "00000000"), 20) & ckNet.StrDER("Sucursal: " & Format(Val(cklassSuc.SucursalId), "0000"), 20))
            resultado.AppendLine(ckNet.StrIZQ("Sec. Txn: " & Format(Val(response.SecuenciaTransaccion), "0000"), 20) & ckNet.StrDER("Terminal: " & Format(Val(ckNet.Terminal), "0000"), 20))

            resultado.AppendLine("")
            resultado.AppendLine(ckNet.StrIZQ("PUNTOS BANCOMER", 40))
            resultado.AppendLine(ckNet.StrIZQ("Saldo disponibles pesos ($): " & CDbl(response.SaldoDisponiblePesos).ToString, 40))
            resultado.AppendLine(ckNet.StrIZQ("Saldo disponible puntos (PTS):   " & CInt(response.SaldoPuntosDisponibles).ToString, 40))

            If response.CodigoRespuesta = "00" Then
                resultado.AppendLine(ckNet.StrIZQ("PAGARE NEGOCIABLE UNICAMENTE EN", 40))
                resultado.AppendLine(ckNet.StrIZQ("INSTITUCIONES DE CREDITO.", 40))
                resultado.AppendLine(ckNet.StrIZQ("", 40))
                resultado.AppendLine(ckNet.StrIZQ("", 40))
                resultado.AppendLine(ckNet.StrCEN("CLIENTE", 40))
            End If

        Catch ex As Exception
            Throw New Exception("Error al generar pagaré...!", ex)
        End Try
        Return resultado.ToString
    End Function
End Class
