Imports Cklass.Net
Imports System.Text
Imports EglobalBBVA

Public Class PinPadVX
    Dim SiEnviar As Boolean = True

    'Enumeraciones de tipos y opciones
    Public Enum vxOperacion As Integer
        VentaNormal = 1
        VentaForzada = 901
        VentaPuntos = 18
        DevoluciomNormal = 2
        DevolucionForzada = 902
        CancelarVenta = 201
        CancelarDevolucion = 202
        ConsultaPuntos = 16
        PagosEfectivo = 28
        PagoConTarjeta = 40
        MultipagosEfectivo = 59
        MultipagosTarjeta = 50
        CashBackAdvance = 3
        CargarLlaves = 92
    End Enum

    Public Enum vxEMV As Byte
        PinPadNo = 0
        PinPadSi = 3
    End Enum

    Public Enum vxCVV2 As Byte
        CVV2No = 0
        CVV2Si = 1
    End Enum

    Public Enum vxMoneda As Byte
        Pesos = 0
        Dolares = 1
    End Enum

    Public Enum vxPromocion As Byte
        SinPromocion = 0
        SinIntereses = 3
        ConIntereses = 5
        PagueDespues = 7
    End Enum

    Public Enum vxLector As Byte
        Desconocido = 0
        NoTerminal = 2
        BandaMagnetica = 2
        CodigoBarras = 3
        OCR = 4
        BandaChip = 5
        EntradaManual = 6
        BandaManual = 7
        BandaManualChip = 8
        Chip = 9
    End Enum


    'Variables de opciones y configuracion
    Public EMV As vxEMV = vxEMV.PinPadSi
    Public cCVV2 As vxCVV2 = vxCVV2.CVV2Si
    Public Moneda As vxMoneda = vxMoneda.Pesos
    Public Promocion As vxPromocion = vxPromocion.SinPromocion
    Public Lector As vxLector = vxLector.BandaManualChip

    'Variables de la operacion a procesar
    Public Operacion As String = ""
    Public Afiliacion As Integer = 0
    Public Sucursal As Integer = 0
    Public Terminal As Integer = 0
    Public Sesion As Integer = 0
    Public Autorizacion As String = ""
    Public SecTransaccion As Integer = 0
    Public ReferenciaComercio As String = ""
    Public ReferenciaFinanciera As String = ""
    Public ImporteTransaccion As Double = 0
    Public ImporteOtro As Double = 0
    Public ImporteCashBack As Double = 0
    Public TarjetaEmisor As String = ""
    Public TarjetaNombre As String = ""
    Public TarjetaNumero As String = ""
    Public TarjetaExpira As String = ""
    Public TarjetaBanco As String = ""
    Public TarjetaTipo As String = ""
    Public TarjetaIngreso As String = ""
    Public Criptograma As String = ""
    Public CodigoSeguridad As String = ""
    Public Meses As Integer = 0
    Public Pagos As Integer = 0
    Public CreDebit As String = ""
    Public Operador As String = ""
    Public ClsResponse As String = ""
    Public RespDll As Integer = -1


    Public SucNombre As String = ""
    Public SucDomicilio As String = ""
    Public SucColoinia As String = ""
    Public SucCiudad As String = ""
    Public SucCaja As String = ""
    Public MinMonto As Double = 0
    Public MaxMeses As Integer = 0



    'Variarbles ENVIA (Requerimiento/Request)
    Public e01Tansaccion As String = "" '01 (03) Codigo de transaccion
    Public e02Terminal As String = ""   '02 (08) Numero de terminal
    Public e03Sesion As String = ""     '03 (04) Numero de sesion
    Public e04Secuencia As String = ""  '04 (04) Numero secuencial de transaccion
    Public e05Importe As String = ""    '05 (12) Importe de transaccion
    Public e06Filler As String = ""     '06 (12) Filler
    Public e07Folio As String = ""      '07 (07) Folio
    Public e08EMV As String = ""        '08 (01) Capacidad EMV
    Public e09Tipo As String = ""       '09 (01) Tipo de lector
    Public e10CapCVV2 As String = ""    '10 (01) Capacidad CVV2
    Public e11Pagos As String = ""      '11 (02) Meses financiamiento
    Public e12Parciales As String = ""  '12 (02) Pagos parcializados
    Public e13Promocion As String = ""  '13 (02) Promociones
    Public e14Moneda As String = ""     '14 (01) Tipo de Moneda
    Public e15Autoriza As String = ""   '15 (06) Autorizacion
    Public e16Modo As String = ""       '16 (02) Modo ingreso tarjeta
    Public e17CVV2 As String = ""       '17 (04) CCV2/CVC2
    Public e18TRackII As String = ""    '18 (40) Tranck II
    Public e19Numero As String = ""     '19 (03) Numero secuencial de tarjeta
    Public e20CashBack As String = ""   '20 (12) Importe CashBack
    Public e21FechaHora As String = ""  '21 (12) Fecha-Hora
    Public e22Comercio As String = ""   '22 (45) Referencia comercio 
    Public e23OImporte As String = ""   '23 (12) Otro importe
    Public e24Operador As String = ""   '24 (06) Clave operador
    Public e25Afiliacion As String = "" '25 (08) Afiliacion
    Public e26Filler As String = ""     '26 (04) Filler
    Public e27Referencia As String = "" '27 (08) Referencia financiera
    Public e28Filler As String = ""     '28 (01) Filler
    Public e29Filler As String = ""     '29 (03) Filler
    Public e30Filler As String = ""     '30 (03) Filler
    Public e31MultiPagos As String = "" '31 (04) Pagos y multipagos
    Public e32Id As String = ""         '32 (02) Identificador

    'Variarbles RESULTADO (Respuesta/Response)
    Public r01Transaccion As String = "" '01 (03) Codigo de transaccion
    Public r02Terminal As String = ""  '02 (08) Numero de terminal
    Public r03Sesion As String = ""    '03 (04) Numero de sesion
    Public r04Secuencia As String = "" '04 (04) Numero secuencial de transaccion
    Public r05Respuesta As String = "" '05 (02) Codigo de respuesta
    Public r06Autoriza As String = ""  '06 (06) Numero de autorizacion
    Public r07Afiliacion As String = "" '07 (08) Afiliacion
    Public r08Filler As String = ""    '08 (12) Filler
    Public r09Importe As String = ""   '09 (12) Importe
    Public r10Filler As String = ""    '10 (12) Filler
    Public r11Tarjeta As String = ""   '11 (16) Tarjeta
    Public r12Operador As String = ""  '12 (06) Clave operador
    Public r13Filler As String = ""    '13 (04) Filler
    Public r14Folio As String = ""     '14 (07) Folio
    Public r15LLeyenda As String = ""  '15 (02) Longitud Leyenda
    Public r16Leyenda As String = ""   '16 (LL) Leyenda respuesta
    Public r17RefFin As String = ""    '17 (08) Referencia Financiera
    Public r18Infoint3 As String = ""  '18 (03) Informacion Interna
    Public r19InfoInt255 As String = "" '19 (hb) Informacion Interna
    Public r20LPuntos As String = "" '20 (03) Mensaje para puntos
    Public r21datPuntos As String = "" '21 (vv) Datos de puntos
    Public r22Registro1 As String = "" '22 (36) Datos de registro 1
    Public r23LMACADDR As String = ""  '23 (02) Longitud de MACADDR
    Public r24Registro2 As String = "" '24 (36) Datos de registro 2
    Public r25Registro3 As String = "" '25 (36) Datos de registro 3
    Public r26Registro4 As String = "" '26 (36) Datos de registro 4
    Public r27LMultipagos As String = "" '27 (04) Longitud Pagos y Multipagos
    Public r28DMultipagos As String = "" '28 (vv) Datos de Pagos y Multipagos

    'Variables Puntos BANCOMER
    Public p01Importe As String = ""                '01 (12) Importe en pesos
    Public p02Puntos As String = ""                 '02 (10) Número de puntos
    Public p03FactorExp As String = ""              '03 (02) Factor de exponenciación
    Public p04SaldoDispPesos As String = ""         '04 (12) Saldo disponible en pesos
    Public p05SaldoAntPuntos As String = ""         '05 (10) Saldo anterior en puntos
    Public p06SaldoAntPesos As String = ""          '06 (12) Saldo anterior en pesos
    Public p07VigenciaPromExp As String = ""        '07 (06) Vigencia promoción de puntos exponenciales
    Public p08SaldoRedimExpPesos As String = ""     '08 (12) Saldo redimido exponencial en pesos
    Public p09SaldoRedimExpPuntos As String = ""    '09 (10) Saldo redimido exponencial en puntos
    Public p10SaldoDispExpPesos As String = ""      '10 (12) Saldo disponible exponencial en pesos
    Public p11SaldoDispExpPuntos As String = ""     '11 (10) Saldo disponible exponencial en puntos
    Public p12UsoInterno As String = ""             '12 (02) Uso interno
    Public p13UsoInterno As String = ""             '13 (01) Uso interno
    Public p14UsoInterno As String = ""             '14 (01) Uso interno
    Public p15UsoInterno As String = ""             '15 (01) Uso interno
    Public p16UsoInterno As String = ""             '16 (10) Uso interno
    Public p17UsoInterno As String = ""             '17 (02) Uso interno
    Public p18SaldoPuntosDisp As String = ""         '18 (10) Saldo de puntos disponibles o actualizados
    Public p19UsoInterno As String = ""             '19 (03) Uso interno
    Public p20UsoInterno As String = ""             '20 (01) Uso interno

    Public miRequest As String = ""
    Public miResponse As String = ""
    'Public miPinPad As PinPadSC

    'Public Sub New()
    '    MyBase.New()
    '    'miPinPad = New PinPadSC()
    '    'miPinPad.SincronicacionInicial()
    'End Sub

    'Public Function fxImporte(ByVal pImporte As Double) As String
    '    'Formatear importe 123.45 = 000000012345
    '    Dim resultado As String = ""
    '    resultado = Format(Fix(pImporte), StrDup(10, "0")) & Format((pImporte - Fix(pImporte)) * 100, "00")
    '    Return resultado
    'End Function

    'Private Function fxRequest() As String
    '    Dim req As New StringBuilder("")
    '    req.Append(e01Tansaccion)
    '    req.Append(e02Terminal)
    '    req.Append(e03Sesion)
    '    req.Append(e04Secuencia)
    '    req.Append(e05Importe)
    '    req.Append(e06Filler)
    '    req.Append(e07Folio)
    '    req.Append(e08EMV)
    '    req.Append(e09Tipo)
    '    req.Append(e10CapCVV2)
    '    req.Append(e11Pagos)
    '    req.Append(e12Parciales)
    '    req.Append(e13Promocion)
    '    req.Append(e14Moneda)
    '    req.Append(e15Autoriza)
    '    req.Append(e16Modo)
    '    req.Append(e17CVV2)
    '    req.Append(e18TRackII)
    '    req.Append(e19Numero)
    '    req.Append(e20CashBack)
    '    req.Append(e21FechaHora)
    '    req.Append(e22Comercio)
    '    req.Append(e23OImporte)
    '    req.Append(e24Operador)
    '    req.Append(e25Afiliacion)
    '    req.Append(e26Filler)
    '    req.Append(e27Referencia)
    '    req.Append(e28Filler)
    '    req.Append(e29Filler)
    '    req.Append(e30Filler)
    '    req.Append(e31MultiPagos)
    '    req.Append(e32Id)
    '    Return req.ToString
    'End Function

    'Public Function Enviar() As PinPadSC
    '    e01Tansaccion = Format(Val(Operacion), "000")
    '    e02Terminal = Sucursal.ToString.PadLeft(4, "0"c) + Terminal.ToString.PadLeft(4, "0"c)
    '    e03Sesion = Format(Sesion, "0000")
    '    e04Secuencia = Format(SecTransaccion, "0000")
    '    e05Importe = fxImporte(ImporteTransaccion) 'StrDup(12, "0")
    '    e06Filler = StrDup(12, "0")
    '    e07Folio = StrDup(7, "0")
    '    e08EMV = EMV '"3"
    '    e09Tipo = Lector
    '    e10CapCVV2 = cCVV2
    '    e11Pagos = Format(Meses, "00") '"00"
    '    e12Parciales = Format(Pagos, "00") '"00"
    '    e13Promocion = Format(Val(Promocion), "00") '"00"
    '    e14Moneda = Moneda
    '    e15Autoriza = Autorizacion.PadLeft(6, " "c) 'Format(Autorizacion, f(6, " ")) 'StrDup(6, "0")
    '    e16Modo = StrDup(2, " ")  '"01" 
    '    e17CVV2 = StrDup(4, " ") '= CodigoSeguridad)
    '    e18TRackII = StrDup(40, " ")
    '    e19Numero = StrDup(3, " ")
    '    e20CashBack = fxImporte(ImporteCashBack) 'StrDup(12, "0")
    '    e21FechaHora = Now.ToString("yyMMddhhmmss")
    '    e22Comercio = StrDup(45, " ") 'ReferenciaComercio.PadRight(45) 'StrDup(45, " ")
    '    e23OImporte = fxImporte(ImporteOtro) 'StrDup(12, "0")
    '    e24Operador = Operador 'StrDup(6, "0") '"000000"
    '    e25Afiliacion = Format(Afiliacion, "00000000")
    '    e26Filler = StrDup(4, "0")
    '    e27Referencia = Format(Val(ReferenciaFinanciera), StrDup(8, "0")) 'StrDup(8, "0")
    '    e28Filler = "0"
    '    e29Filler = "000"
    '    e30Filler = "000"
    '    e31MultiPagos = "0000"
    '    e32Id = ""

    '    miRequest = fxRequest()
    '    If SiEnviar Then miPinPad.fncEglobalBBVA(miRequest, 0, "")
    '    'miResponse = miPinPad.Response


    '    Return miPinPad
    'End Function


    'Public Function Llaves() As String
    '    e01Tansaccion = Format(Val(Operacion), "000")
    '    e02Terminal = Sucursal.ToString.PadLeft(4, "0"c) + Terminal.ToString.PadLeft(4, "0"c)
    '    e03Sesion = Format(Sesion, "0000")
    '    e04Secuencia = Format(SecTransaccion, "0000")
    '    e05Importe = fxImporte(ImporteTransaccion) 'StrDup(12, "0")
    '    e06Filler = StrDup(12, "0")
    '    e07Folio = StrDup(7, "0")
    '    e08EMV = 3
    '    e09Tipo = 8
    '    e10CapCVV2 = 0
    '    e11Pagos = Format(Meses, "00") '"00"
    '    e12Parciales = Format(Pagos, "00") '"00"
    '    e13Promocion = Format(Val(Promocion), "00") '"00"
    '    e14Moneda = Moneda
    '    e15Autoriza = Format(Autorizacion, StrDup(6, " ")) 'StrDup(6, "0")
    '    e16Modo = "01"
    '    e17CVV2 = StrDup(4, " ") '= CodigoSeguridad)
    '    e18TRackII = StrDup(40, " ")
    '    e19Numero = StrDup(3, " ")
    '    e20CashBack = fxImporte(ImporteCashBack) 'StrDup(12, "0")
    '    e21FechaHora = Now.ToString("yyMMddhhmmss")
    '    e22Comercio = StrDup(45, " ") 'ReferenciaComercio.PadRight(45) 'StrDup(45, " ")
    '    e23OImporte = fxImporte(ImporteOtro) 'StrDup(12, "0")
    '    e24Operador = Operador 'StrDup(6, "0") '"000000"
    '    e25Afiliacion = Format(Afiliacion, "00000000")
    '    e26Filler = StrDup(4, "0")
    '    e27Referencia = Format(Val(ReferenciaFinanciera), StrDup(8, "0")) 'StrDup(8, "0")
    '    e28Filler = "0"
    '    e29Filler = "000"
    '    e30Filler = "000"
    '    e31MultiPagos = "0000"
    '    e32Id = ""

    '    miRequest = fxRequest()
    '    If SiEnviar Then miPinPad.fncEglobalBBVA(miRequest, 0, "")
    '    miResponse = miPinPad.Response
    '    Return miResponse
    'End Function



    'Public Sub Recibir()
    '    Try
    '        r01Transaccion = Mid(miResponse, 1, 3) '(03) Codigo de transaccion
    '        r02Terminal = Mid(miResponse, 4, 8) '(08) Numero de terminal
    '        r03Sesion = Mid(miResponse, 12, 4) '(04) Numero de sesion 
    '        r04Secuencia = Mid(miResponse, 16, 4) '(04) Numero de secuencia de transaccion
    '        r05Respuesta = Mid(miResponse, 20, 2) '(02) Codigo de respuesta
    '        r06Autoriza = Mid(miResponse, 22, 6) '(06) Numero de autorizacion
    '        r07Afiliacion = Mid(miResponse, 28, 8) '(08) Numero de afiliacion
    '        r08Filler = Mid(miResponse, 36, 12) '(12) Filler
    '        r09Importe = Mid(miResponse, 48, 12) '(12) Importe
    '        r10Filler = Mid(miResponse, 60, 12) '(12) Filler
    '        r11Tarjeta = Mid(miResponse, 72, 16) '(16) Tarjeta
    '        r12Operador = Mid(miResponse, 88, 6) '(06) Clave de operador
    '        r13Filler = Mid(miResponse, 94, 4) '(04) Filler
    '        r14Folio = Mid(miResponse, 98, 7) '(07) Folio
    '        r15LLeyenda = Mid(miResponse, 105, 2) '(02) Longitud Leyenda
    '        r16Leyenda = Mid(miResponse, 107, Val(r15LLeyenda)) '(LL) Leyenda respuesta
    '        Dim refPos1 As Integer = 107 + Val(r15LLeyenda)
    '        r17RefFin = Mid(miResponse, refPos1, 8) '(08) Referencia Financiera
    '        r18Infoint3 = Mid(miResponse, refPos1 + 8, 3) '(03) Informacion DLL
    '        r19InfoInt255 = Mid(miResponse, refPos1 + 8 + 3, Val(r18Infoint3))
    '        Dim refPos2 As Integer = refPos1 + 8 + 3 + Val(r18Infoint3)
    '        r20LPuntos = Mid(miResponse, refPos2, 3)
    '        Dim LenPuntos As Integer = Val(r20LPuntos)
    '        r21datPuntos = Mid(miResponse, refPos2 + 3, LenPuntos)
    '        ''Dim refPos3 As Integer = refPos2 + 3 + LenPuntos
    '        ''r22Registro1 = Mid(miResponse, refPos3, 36)
    '        ''r23LMACADDR = Mid(miResponse, refPos3 + 36, 2)
    '        ''Dim LenMac As Integer = Val(r23LMACADDR)
    '        ''r24Registro2 = Mid(miResponse, refPos3 + 36 + 2, LenMac)
    '        ''Dim refPos4 As Integer = refPos3 + 36 + 2 + LenMac
    '        ''r25Registro3 = Mid(miResponse, refPos4, 36)
    '        ''r26Registro4 = Mid(miResponse, refPos4 + 36, 36)
    '        ''Dim refPos5 As Integer = refPos4 + 36 + 36 + 3
    '        ''r27LMultipagos = Mid(miResponse, refPos4 + 36 + 36, 3)
    '        ''Dim LenMulti As Integer = Val(r27LMultipagos)
    '        ''r28DMultipagos = Mid(miResponse, refPos5, LenMulti)

    '        Autorizacion = r06Autoriza
    '        ReferenciaFinanciera = r17RefFin
    '    Catch ex As Exception
    '        Throw New Exception("Error al procesar respuesta...!", ex)
    '    End Try
    'End Sub

    'Public Sub Puntos()
    '    If r21datPuntos = "" Then Return
    '    Dim cadena As String = r21datPuntos

    '    Try
    '        p01Importe = Mid(cadena, 1, 12) '01 (12) Importe en pesos
    '        p02Puntos = Mid(cadena, 13, 10) '02 (10) Número de puntos
    '        p03FactorExp = Mid(cadena, 23, 2) '03 (02) Factor de exponenciación
    '        p04SaldoDispPesos = Mid(cadena, 25, 12) '04 (12) Saldo disponible en pesos
    '        p05SaldoAntPuntos = Mid(cadena, 37, 10) '05 (10) Saldo anterior en puntos
    '        p06SaldoAntPesos = Mid(cadena, 47, 12) '06 (12) Saldo anterior en pesos
    '        p07VigenciaPromExp = Mid(cadena, 59, 6) '07 (06) Vigencia promoción de puntos exponenciales
    '        p08SaldoRedimExpPesos = Mid(cadena, 65, 12) '08 (12) Saldo redimido exponencial en pesos
    '        p09SaldoRedimExpPuntos = Mid(cadena, 77, 10) '09 (10) Saldo redimido exponencial en puntos
    '        p10SaldoDispExpPesos = Mid(cadena, 87, 12) '10 (12) Saldo disponible exponencial en pesos
    '        p11SaldoDispExpPuntos = Mid(cadena, 99, 10) '11 (10) Saldo disponible exponencial en puntos
    '        p12UsoInterno = Mid(cadena, 109, 2) '12 (02) Uso interno
    '        p13UsoInterno = Mid(cadena, 111, 1) '13 (01) Uso interno
    '        p14UsoInterno = Mid(cadena, 112, 1) '14 (01) Uso interno
    '        p15UsoInterno = Mid(cadena, 113, 1) '15 (01) Uso interno
    '        p16UsoInterno = Mid(cadena, 114, 10) '16 (10) Uso interno
    '        p17UsoInterno = Mid(cadena, 124, 2) '17 (02) Uso interno
    '        p18SaldoPuntosDisp = Mid(cadena, 126, 10) '18 (10) Saldo de puntos disponibles o actualizados

    '    Catch ex As Exception
    '        Throw New Exception("Error al procesar respuesta de puntos...!", ex)
    '    End Try
    'End Sub


    'Public Function Pagare(ByVal pOpcion As String) As String
    '    Dim resultado As New StringBuilder("")
    '    Try
    '        resultado.AppendLine(ckNet.StrCEN("BBVA Bancomer FECHA " & Format(Now.Date, "dd/MMM/yy").ToUpper & " HORA " & Format(Now, "HH:mm"), 40))
    '        resultado.AppendLine(ckNet.StrCEN("CKLASS " & SucNombre, 40))
    '        resultado.AppendLine(ckNet.StrCEN(SucDomicilio, 40))
    '        resultado.AppendLine(ckNet.StrCEN(SucColoinia, 40))
    '        resultado.AppendLine(ckNet.StrCEN(SucCiudad, 40))

    '        If r05Respuesta = "00" Then
    '            If r16Leyenda.Trim <> "" Then resultado.AppendLine(ckNet.StrCEN(r16Leyenda.Trim, 40))
    '        ElseIf (r05Respuesta >= "01" And r05Respuesta <= "99") Then
    '            If r05Respuesta = "04" Then r16Leyenda = "DECLINADA"
    '            resultado.AppendLine(ckNet.StrCEN(r05Respuesta & "=" & r16Leyenda.Trim, 40))
    '        ElseIf r05Respuesta = "R1" Then
    '            resultado.AppendLine(r05Respuesta & "=" & r16Leyenda)
    '            Dim r1 As String = Mid(miResponse, 205, 205).Trim.Replace(" ", "")
    '            resultado.AppendLine(Mid(r1, 1, 19))
    '            resultado.AppendLine(Mid(r1, 20, 28))
    '            resultado.AppendLine(Mid(r1, 48, 27))
    '            resultado.AppendLine(Mid(r1, 75, 20))
    '        Else
    '            resultado.AppendLine("!" & Mid(miResponse, 1, 40).Trim & "!")
    '        End If


    '        If pOpcion = "COPIA" Then
    '            resultado.AppendLine(ckNet.StrCEN(Format(Val(Mid(TarjetaNumero, 13, 4)), "XXXX XXXX XXXX 0000"), 40))
    '        Else
    '            resultado.AppendLine(ckNet.StrCEN(Format(Val(Mid(TarjetaNumero, 1, 8)), "0000 0000") & " " & Format(Val(Mid(TarjetaNumero, 9, 8)), "0000 0000"), 40))
    '        End If

    '        If TarjetaBanco.Trim <> "" Or TarjetaEmisor.Trim <> "" Then resultado.AppendLine(ckNet.StrCEN(TarjetaBanco & " " & TarjetaEmisor, 40))
    '        resultado.AppendLine(ckNet.StrIZQ("TIPO: " & TarjetaTipo, 20)) '& ckNet.StrCEN("VENCE: " & Format(Val(TarjetaExpira), "00/00"), 20))

    '        If Val(Operacion) = Val(vxOperacion.VentaNormal) Then
    '            resultado.AppendLine(ckNet.StrIZQ("VENTA " & IIf(Pagos > 0, Pagos & " Meses sin intereses", "NORMAL"), 40))
    '        End If
    '        If Val(Operacion) = Val(vxOperacion.CancelarVenta) Then
    '            resultado.AppendLine(ckNet.StrIZQ("CANCELACION " & IIf(Pagos > 0, Pagos & " Meses sin intereses", "NORMAL"), 40))
    '        End If

    '        resultado.AppendLine(ckNet.StrDER(ReferenciaComercio & " TOTAL M.N. " & Format(ImporteTransaccion, "Currency"), 40))

    '        If r21datPuntos <> "" Then
    '            resultado.AppendLine(ckNet.StrDER("Pagado con Puntos BBVA: " & Format(Val(p01Importe) / 100, "Currency"), 40))
    '            resultado.AppendLine(ckNet.StrDER("Total a pagar " & Format(ImporteTransaccion - (Val(p01Importe) / 100), "Currency"), 40))
    '        End If


    '        If r05Respuesta = "00" And r06Autoriza.Trim <> "" Then
    '            resultado.AppendLine(ckNet.StrCEN("BC " & TarjetaIngreso & " Autorizacion: " & r06Autoriza, 40))
    '        Else
    '            If Val(Operacion) = Val(vxOperacion.VentaNormal) Then
    '                'resultado.AppendLine(ckNet.StrCEN("***!!!DECLINADA!!!***", 40))
    '                If RespDll = 0 Then
    '                    resultado.AppendLine(ckNet.StrCEN("***" + r16Leyenda + "***", 40))
    '                Else
    '                    resultado.AppendLine(ckNet.StrCEN("***" + ClsResponse + "***", 40))
    '                End If

    '            Else
    '                resultado.AppendLine(ckNet.StrCEN("!!!ERROR!!!", 40))
    '            End If
    '        End If

    '        If miPinPad.Criptograma.Trim <> "" Then resultado.AppendLine(ckNet.StrCEN(miPinPad.Criptograma.Trim, 40))
    '        If miPinPad.AID.Trim <> "" Then resultado.AppendLine(ckNet.StrCEN("AID: " + miPinPad.AID.Trim, 40))

    '        resultado.AppendLine(ckNet.StrIZQ("Referencia: " & Format(Val(r17RefFin), "00000000"), 40))
    '        resultado.AppendLine(ckNet.StrIZQ("Afiliacion: " & Format(Val(Afiliacion), "00000000"), 20) & ckNet.StrDER("Sucursal: " & Format(Val(Sucursal), "0000"), 20))
    '        resultado.AppendLine(ckNet.StrIZQ("Sec. Txn: " & Format(Val(SecTransaccion), "0000"), 20) & ckNet.StrDER("Terminal: " & Format(Val(Terminal), "0000"), 20))

    '        If r21datPuntos <> "" Then
    '            resultado.AppendLine("")
    '            resultado.AppendLine(ckNet.StrIZQ("PUNTOS BANCOMER", 40))
    '            resultado.AppendLine(ckNet.StrIZQ("Saldo anterior (PTS): " & CInt(p05SaldoAntPuntos).ToString, 40))
    '            resultado.AppendLine(ckNet.StrIZQ("Redimidos (PTS):      " & CInt(p02Puntos).ToString, 40))
    '            resultado.AppendLine(ckNet.StrIZQ("Saldo actual (PTS):   " & CInt(p18SaldoPuntosDisp).ToString, 40))
    '        End If

    '        If r05Respuesta = "00" Then

    '            If miPinPad.FirmaElectronica Then
    '                resultado.AppendLine(ckNet.StrCEN("AUTORIZADO MEDIANTE FIRMA ELECTRONICA", 40))
    '            Else
    '                resultado.AppendLine(ckNet.StrCEN("FIRMA __________________________________", 40))
    '                If TarjetaNombre.Trim <> "" Then resultado.AppendLine(ckNet.StrCEN(TarjetaNombre.Trim, 40))
    '            End If

    '            If pOpcion = "ORIGINAL" Then
    '                resultado.AppendLine(ckNet.StrCEN("COPIA COMERCIO", 40))
    '            Else
    '                resultado.AppendLine(ckNet.StrCEN("COPIA CLIENTE", 40))
    '            End If

    '            resultado.AppendLine(ckNet.StrIZQ("POR ESTE PAGARE ME OBLIGO INCONDICIONAL", 40))
    '            resultado.AppendLine(ckNet.StrIZQ("MENTE A PAGAR A LA ORDEN DEL BANCO ACRE", 40))
    '            resultado.AppendLine(ckNet.StrIZQ("DITANTE EL IMPORTE DE ESTE TITULO. ESTE", 40))
    '            resultado.AppendLine(ckNet.StrIZQ("PAGARE PROCEDE DEL CONTRATO DE APERTURA", 40))
    '            resultado.AppendLine(ckNet.StrIZQ("DE CREDITO QUE  EL BANCO ACREDITANTE  Y", 40))
    '            resultado.AppendLine(ckNet.StrIZQ("EL TARJETAHABIENTE TIENEN CELEBRADO.", 40))
    '            resultado.AppendLine(ckNet.StrIZQ("PAGARE  NEGOCIABLE  UNICAMENTE", 40))
    '            resultado.AppendLine(ckNet.StrIZQ("CON  INSTITUCIONES  DE CREDITO.", 40))
    '        End If

    '    Catch ex As Exception
    '        Throw New Exception("Error al generar pagaré...!", ex)
    '    End Try
    '    Return resultado.ToString
    'End Function





End Class
