Imports System.IO
Imports Cklass.Net
Imports Cklass.Net.ckPrinter
Imports System.Data.SqlClient
Imports System.Text
Imports EGlobal.TotalPosSDKNet.Interfaz.Authorizer
Imports EGlobal.TotalPosSDKNet.Interfaz.Catalog
Imports EGlobal.TotalPosSDKNet.Interfaz.Exceptions
Imports EGlobal.TotalPosSDKNet.Interfaz.Layout

Public Class frmPinPad


    Public ckVX As PinPadVX

    Dim ToDoAprobado As Boolean = False     'Bandera para transacciones siempre sean aprobadas 
    Dim Probando As Boolean = True          'Bandera para habilitar ambiente de pruebas
    Dim ValidarTipoCard As Boolean = True      'Bandera para validación del Tipo de Tarjeta Credito/Debito
    Dim Bandera1 As Boolean = True           'Bandera para carga de llaves
    Dim Registrar As Boolean = False        'Bandera para registro en pinlog /LOG PARA INGRESAR HISTORIAL DE REQUEST/RESPONSE DEL BANCO guardar en BD
    Dim bMSI As Boolean = False
    Dim ModoAutomatico As Boolean = False
    Dim ckSuc As New ckSucursal.CklassSucursal()
    Dim ckDatos As New ckData(ckSuc.SucCnnStr)
    Dim settings = New Settings()
    Dim ticket = New Tickets()
    Dim CajaId As String = ""
    Dim PedidoId As String = ""
    Dim Operacion As String = ""
    Dim Importe As Double = 0
    Dim LineaRef As Integer = 0
    Dim ImporteRetiro As Double = 0         'Importe a disponer en Efectivo Cash Advance
    Dim ClienteId As String = ""            'Variable cliente para registro en disposicion de efectivo
    Dim SuperUsuario As String = ""         'Contiene el Usuario Supervisor ingresado
    Dim miPedido As New ckSucursal.ckPedido("")

    Private Sub frmBancomer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.impresora = cmbImpresora.Text
        My.Settings.Save()
    End Sub

    Private Sub frmBancomer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F10
                If ckToolBar.Enabled Then Accion()
                e.Handled = True
            Case Keys.F8
                CargarLlaves()
            Case Keys.F6
                Nuevo()
        End Select
    End Sub

    Private Sub frmBancomer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Visible = True
            Me.txtResponse.Text = " "
            lblSUC.Text = ckSuc.SucursalId & " " & ckSuc.Sucursal
            ckVX = New PinPadVX()
            Bandera1 = CBool(fxBandera1())
            If ckSuc.ValidarCaja("V", CajaId) Then
                If ToDoAprobado Then
                    Me.Text = " MODO DE PRUEBAS TODO SERÁ APROBADO...!"
                    ckNet.MsgInf(Me.Text)
                End If
                If Command.Trim <> "" Then
                    PedidoId = Command.Split()(0)
                    Operacion = Command.Split()(1)
                    Importe = Val(Command.Split()(2))
                    LineaRef = Val(Command.Split()(3))
                    ImporteRetiro = Val(Command.Split()(4))


                    Me.optCredito.Enabled = False
                    Me.optDebito.Enabled = False

                End If
                ModoAutomatico = PedidoId.Trim <> ""
                With Me.txtPedidoId
                    If PedidoId <> "" And Importe > 0 Then .Text = PedidoId
                    If ModoAutomatico Then
                        Me.Text = Me.Text & " [Modo Integrado]"
                    Else
                        .SqlCnn = ckDatos.CnnStr
                        .SqlStr = "sp2UltimosPedidos"
                        Me.Text = Me.Text & " [Modo Express]"
                    End If
                End With
                txtImporte.Text = Importe
                txtDispEfe.Text = ImporteRetiro
                ConfigurarModoAutomatico(ModoAutomatico)
                ckVX = New PinPadVX
                If fxRetirosEfectivo() Then
                    lblDisponer.Visible = True
                    txtDispEfe.Visible = True
                End If
                If ImporteRetiro > 0 And Importe <= 0 And ModoAutomatico Then
                    lblCliente.Text = PedidoId
                End If
                CargarPedido()
            Else
                ckToolBar.Enabled = Probando
                ckPanel.Enabled = Probando
            End If
            If ModoAutomatico Then
                Me.ActiveControl = Me.txtCVV2
                If Operacion = "V" Then
                    Me.chkVentaNormal.Text = "Venta Normal"
                    Me.chkVentaNormal.Checked = True
                    Me.chkVentaNormal.ForeColor = Color.Black
                Else
                    Me.chkVentaNormal.Text = "CANCELACION"
                    Me.chkVentaNormal.Checked = False
                    Me.chkVentaNormal.ForeColor = Color.Red
                End If
            Else
                Me.ActiveControl = Me.txtPedidoId
            End If
            cmbImpresora.Items.Clear()
            For Each printer As String In ckPrinter.InstalledPrinters
                cmbImpresora.Items.Add(printer)
            Next
            Me.cmbImpresora.Text = ckPrinter.DefaultPrinter
            'If My.Settings.impresora.Trim <> "" Then Me.cmbImpresora.Text = My.Settings.impresora.Trim
            If Probando Then
                ModoSupervisor(True)
                ModoAvanzado(True)
            End If
            settings.LoadSettingsWithConfig()
            Me.txtAfiliacion.Text = settings.ComercioAfiliacion
            Me.txtTerminal.Text = settings.ComercioTerminal
            Me.lblMAC.Text = settings.ComercioMac
            If Bandera1 Then CargarLlaves()
        Catch ex As Exception
            ckNet.MsgErr(ex.ToString)
        End Try
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub ConfigurarModoAutomatico(ByVal pValor As Boolean)
        Me.txtPedidoId.ReadOnly = pValor
        Me.btnNuevo.Visible = Not pValor
    End Sub

    Private Sub ModoSupervisor(ByVal pValue As Boolean)

        Me.btnReimprimir.Visible = pValue
        Me.btnReimprimir.Enabled = pValue
        Me.chkVentaNormal.Enabled = pValue

        If fxRetirosEfectivo() And Not ModoAutomatico Then
            btnRetiro.Visible = pValue
            lblDisponer.Visible = pValue
            txtDispEfe.Visible = pValue
        End If

    End Sub

    Private Sub ModoAvanzado(ByVal pValue As Boolean)
        Me.txtSucursal.ReadOnly = Not pValue
        Me.txtTerminal.ReadOnly = Not pValue
        Me.txtSesion.ReadOnly = Not pValue
        Me.txtSecTxn.ReadOnly = Not pValue
        Me.txtReferenciaComercial.ReadOnly = Not pValue
        Me.txtImporte.ReadOnly = Not pValue
        Me.txtDispEfe.Hide()
        Me.txtAutorizacion.ReadOnly = Not pValue
        Me.txtReferenciaFinanciera.ReadOnly = Not pValue
        Me.txtMeses.ReadOnly = Not pValue
        If Not Probando Then
            Me.chkMeses.Enabled = pValue
            Me.txtMeses.Enabled = pValue
        End If
        Me.txtAfiliacion.ReadOnly = Not pValue
        Me.txtMinMonto.ReadOnly = Not pValue
        Me.txtMaxMeses.ReadOnly = Not pValue
        Me.txtTipoTarjeta.ReadOnly = Not pValue

        Me.btnRequest.Visible = pValue
        Me.btnRequest.Enabled = pValue

        Me.btnResponse.Visible = pValue
        Me.btnResponse.Enabled = pValue

        Me.btnRetiro.Visible = pValue


    End Sub

    Private Sub btnSupervisor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSupervisor.Click
        If Not chkVentaNormal.Enabled Then
            Dim frmSuper As New ckSucursal.ckForms.frmSupervisor
            frmSuper.ShowDialog()
            SuperUsuario = frmSuper.SuperUsuario
            If frmSuper.SuperNivel = 3 Then
                ModoSupervisor(True)
            End If
        Else
            ModoSupervisor(False)
            ModoAvanzado(False)
        End If
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Me.btnImprimir.Enabled = False
        Imprimir()
        Me.btnImprimir.Enabled = True
    End Sub

    Private Sub Imprimir()
        If Me.txtResponse.Text.Trim = "" Then Return
        ckPrinter.PrintString(cmbImpresora.Text, ckPrinter.ckReset & Me.txtResponse.Text & ckTearOff)
        If My.Settings.impresora.Trim <> cmbImpresora.Text Then
            My.Settings.impresora = cmbImpresora.Text
            My.Settings.Save()
        End If
        If ModoAutomatico Then
            Me.Close()
        End If
    End Sub

    Private Sub Accion()
        If Not Me.ckToolBar.Enabled Then Return
        Try
            bMSI = False
            chkMeses.Checked = False
            Me.lblDeclinada.Visible = False
            Me.ckToolBar.Enabled = False
            Me.ckPanel.Enabled = False
            Me.Cursor = Cursors.WaitCursor
            Dim validardatos As String = ""
            PedidoId = Me.txtPedidoId.Text.Trim
            If miPedido.PedidoId.Trim <> PedidoId Or (miPedido.PedidoId.Trim = "" Or PedidoId = "") And (ImporteRetiro <= 0) Then
                txtResponse.Text = "El numero de pedido no es válido "
                Return
            End If

            If Me.chkVentaNormal.Checked Then
                validardatos = fxValidarVentaNormal()
                If validardatos = "" Then
                    Procesar()
                Else
                    Me.txtResponse.Text = validardatos
                End If
            Else
                validardatos = fxValidarCancelacion()
                If validardatos = "" Then
                    Procesar()
                Else
                    Me.txtResponse.Text = validardatos
                End If
            End If
        Catch ex As Exception
            ckSuc.RegistrarError(ex, "PinPadVX", "Accion")
            ckNet.MsgErr(ex)
        Finally
            Me.ckToolBar.Enabled = True
            Me.ckPanel.Enabled = True
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click
        Accion()
    End Sub

    Private Function ValidarTotalesPedido() As String
        Dim resultado As String = ""
        Try
            Dim cmd As New SqlCommand("spPINPADvalidarTotales")
            cmd.Parameters.Add("@PedidoId", SqlDbType.VarChar, 16).Value = miPedido.PedidoId
            Dim tbl As DataTable = ckDatos.TablaSP(cmd)
            If tbl.Rows.Count > 0 Then
                resultado = tbl.Rows(0)(0)
            End If
            cmd.Dispose() : cmd = Nothing
            ckNet.LiberarMemoria()
            Return resultado
        Catch ex As Exception
            Throw New Exception("Error en ValidarPedido!", ex)
        End Try
    End Function

    Public Function fxValidarVentaNormal() As String
        Dim resultado As String = ""

        Me.lblEstatus.Text = miPedido.Estatus

        If Me.lblEstatus.Text = "PAGADO" Then
            resultado = resultado & "No es posible registrar pagos para pedidos ya PAGADOS..." & ControlChars.NewLine
        End If

        If Me.lblEstatus.Text = "CANCELADO" Then
            resultado = resultado & "No es posible registrar pagos para pedidos CANCELADOS..." & ControlChars.NewLine
        End If

        If Me.lblEstatus.Text <> "CONFIRMADO" And ImporteRetiro <= 0 Then
            resultado = resultado & "No es posible registrar pagos para pedidos SIN CONFIRMAR..." & ControlChars.NewLine
        End If

        If Val(Me.txtImporte.Text) <= 0 And ImporteRetiro <= 0 Then
            resultado = resultado & "El importe debe ser mayor que cero..." & ControlChars.NewLine
        End If

        'If Me.txtCVV2.Text.Length <> 3 Then
        '    resultado = resultado & "El codigo de seguridad parece no estar completo..." & ControlChars.NewLine
        'End If

        If Me.chkMeses.Checked And Me.txtTipoTarjeta.Text <> "CREDITO" Then
            resultado = resultado & "El tipo de tarjeta no permite meses sin intereses..." & ControlChars.NewLine
        End If

        If Me.chkMeses.Checked And Val(Me.txtImporte.Text) < ckVX.MinMonto Then
            resultado = resultado & "El importe no es suficiente para meses sin intereses..." & ControlChars.NewLine
        End If

        If Me.chkMeses.Checked And Val(Me.txtMeses.Text) > ckVX.MaxMeses Then
            resultado = resultado & "Los meses sin intereses son mayores a los permitidos..." & ControlChars.NewLine
        End If

        If Me.chkMeses.Checked And Val(Me.txtMeses.Text) <= 0 Then
            resultado = resultado & "Los meses sin intereses son menores a los permitidos..." & ControlChars.NewLine
        End If

        If Val(Me.lbiTotalPedido.Text) = 0 And ImporteRetiro <= 0 Then
            resultado = resultado & "El total del pedido es cero..." & ControlChars.NewLine
        End If

        If (Math.Round(Val(Me.lbiPagosRegistrados.Text), 0) >= Math.Round(Val(Me.lbiTotalPedido.Text), 0)) And ImporteRetiro <= 0 Then
            resultado = resultado & "El total los pagos registrados es mayor o igual que el total del pedido..." & ControlChars.NewLine
        End If

        'If Math.Round(Val(Me.txtImporte.Text), 0) > Math.Round(Val(Me.lbiTotalPedido.Text) - Val(Me.lbiPagosRegistrados.Text), 0) Then
        If Math.Floor(Val(Me.txtImporte.Text)) > Math.Floor(Val(Me.lbiTotalPedido.Text) - Val(Me.lbiPagosRegistrados.Text)) Then
            resultado = resultado & "El pago es mayor que el saldo del pedido..." & ControlChars.NewLine
        End If

        Dim validarTotales As String = ValidarTotalesPedido()
        If validarTotales.Trim <> "" Then
            resultado = resultado & validarTotales & ControlChars.NewLine
        End If

        If Probando Then resultado = ""

        Return resultado
    End Function

    Public Function fxValidarCancelacion() As String
        Dim resultado As String = ""

        'If Me.txtCVV2.Text.Length <> 3 Then
        '    resultado = resultado & "El codigo de seguridad parece no estar completo..." & ControlChars.NewLine
        'End If

        If Me.lblEstatus.Text = "PAGADO" Then
            resultado = resultado & "No es posible CANCELAR pagos de pedidos PAGADOS, primero debe cancelar el ticket..." & ControlChars.NewLine
        End If

        If Val(Me.txtSecTxn.Text) <= 0 Then
            resultado = resultado & "La secuencia de transaccion debe ser mayor que cero..." & ControlChars.NewLine
        End If

        If Val(Me.txtImporte.Text) <= 0 Then
            resultado = resultado & "El importe debe ser mayor que cero..." & ControlChars.NewLine
        End If

        If Val(Me.txtAutorizacion.Text) <= 0 Then
            resultado = resultado & "El numero de autorizacion debe ser mayor que cero..." & ControlChars.NewLine
        End If

        If Val(Me.txtReferenciaFinanciera.Text) <= 0 Then
            resultado = resultado & "La referencia financiera debe ser mayor que cero..." & ControlChars.NewLine
        End If

        If Probando Then resultado = ""

        Return resultado
    End Function

    Private Sub Procesar()
        Dim parameters As New Dictionary(Of ParametroOperacion, Object)
        Dim totalPosAPIPetition As New Peticion
        Dim operation As New Operacion
        Dim response As Respuesta
        Dim cardResponse As Tarjeta
        Dim typeCardSelect As String
        Dim showMessage As Boolean

        Try
            typeCardSelect = IIf(Me.optCredito.Checked, "c", "d")
            Me.txtResponse.Text = "INSERTE/DESLICE TARJETA..."
            Application.DoEvents()

            If Me.chkVentaNormal.Checked Then
                Me.txtSecTxn.Text = fxSecTransaccion()
            End If
            Application.DoEvents()
            ImporteRetiro = IIf(txtDispEfe.Text <> "", txtDispEfe.Text, 0.00)

            Try
                parameters.Add(ParametroOperacion.Importe, Me.txtImporte.Text)
                parameters.Add(ParametroOperacion.ReferenciaComercio, Val(Me.txtReferenciaComercial.Text))
                totalPosAPIPetition.SetAfiliacion(settings.ComercioAfiliacion, Moneda.Pesos)
                totalPosAPIPetition.SetTerminal(settings.ComercioTerminal, settings.ComercioMac)
                totalPosAPIPetition.Operador = settings.Operador
                totalPosAPIPetition.Fecha = DateTime.Now.ToString("yyyyMMddHHmmss")
                totalPosAPIPetition.Amex = False
                If Me.chkVentaNormal.Checked Then
                    Dim msgResponse As Integer
                    totalPosAPIPetition.SetOperacion(operation.Venta, parameters)
                    cardResponse = totalPosAPIPetition.LeerTarjeta()
                    If cardResponse IsNot Nothing And cardResponse.Producto IsNot "" Then
                        If typeCardSelect.Equals(cardResponse.Producto) Then
                            If cardResponse.Producto.Equals("c") Then
                                'DetectaCredito()
                                msgResponse = MessageBox.Show("Estimado afiliado, a su pago realizado con Tarjeta de Crédito se le hará una disminución del 3% sobre su compra. El monto total de la compra será de $" + Me.txtImporte.Text.ToString() + ". ¿Deseas continuar?",
                                        "Informacion",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question,
                                        MessageBoxDefaultButton.Button2)
                                If msgResponse = vbYes Then
                                    If cardResponse.Emisor.Equals("12") And My.Settings.puntos And Not chkMeses.Checked Then
                                        msgResponse = MessageBox.Show("¿Desea pagar con puntos Bancomer?",
                                            "Puntos BBVA",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question,
                                            MessageBoxDefaultButton.Button2)
                                        If msgResponse = vbYes Then
                                            totalPosAPIPetition.AddParametroOperacion(ParametroOperacion.Puntos, True)
                                            Me.txtResponse.Text = "Realizando operación... "
                                            AplicarTarjeta()
                                            response = totalPosAPIPetition.Autorizar()
                                        Else
                                            If cardResponse.Emisor.Equals("12") And Val(Me.txtImporte.Text) >= 1000 Then
                                                msgResponse = MessageBox.Show("Por el monto de compra aplica promoción a meses sin intereses ¿Desea aplicar promoción?",
                                                    "Promoción",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question,
                                                    MessageBoxDefaultButton.Button2)
                                                If msgResponse = vbYes Then
                                                    totalPosAPIPetition.SetPromocionMeses(Promocion.MesesSinIntereses, 0, txtMeses.Text)
                                                End If
                                                Me.txtResponse.Text = "Realizando operación... "
                                                AplicarTarjeta()
                                                response = totalPosAPIPetition.Autorizar()
                                            Else
                                                Me.txtResponse.Text = "Realizando operación... "
                                                AplicarTarjeta()
                                                response = totalPosAPIPetition.Autorizar()
                                            End If
                                        End If
                                    Else
                                        Me.txtResponse.Text = "Realizando operación... "
                                        AplicarTarjeta()
                                        response = totalPosAPIPetition.Autorizar()
                                    End If
                                Else
                                    totalPosAPIPetition.SincronizacionFinal()
                                    Me.txtResponse.Text = "Operación cancelada... "
                                End If
                            ElseIf cardResponse.Producto.Contains("d") Then
                                'DetectaDebito()
                                msgResponse = MessageBox.Show("La tarjeta ingresada es de débito. El monto total de la compra es de $" + Me.txtImporte.Text.ToString() + ". ¿Deseas continuar?",
                                    "Informacion Venta",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question,
                                    MessageBoxDefaultButton.Button2)
                                If msgResponse = vbYes Then
                                    If cardResponse.Emisor.Equals("12") And My.Settings.retiros And Val(Me.txtDispEfe.Text) > 0 Then
                                        msgResponse = MessageBox.Show("¿Desea realizar retiro de efectivo por $" + Me.txtDispEfe.Text.ToString() + "? Se cobrará comisión de $7.00",
                                            "Retiro de efectivo",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question,
                                            MessageBoxDefaultButton.Button2)
                                        If msgResponse = vbYes Then
                                            totalPosAPIPetition.AddParametroOperacion(ParametroOperacion.Cash, Val(Me.txtDispEfe.Text))
                                            totalPosAPIPetition.AddParametroOperacion(ParametroOperacion.CashComision, "7.00")
                                        End If
                                    End If
                                    Me.txtResponse.Text = "Realizando operación... "
                                    response = totalPosAPIPetition.Autorizar()
                                    Me.txtResponse.Text = "Operación realizada con éxito... "
                                Else
                                    totalPosAPIPetition.SincronizacionFinal()
                                    Me.txtResponse.Text = "Operación cancelada... "
                                    showMessage = True
                                End If
                            ElseIf cardResponse.Producto.Equals("") Then
                                totalPosAPIPetition.SincronizacionFinal()
                                Me.txtResponse.Text = "Operación cancelada... "
                                showMessage = True
                            End If
                        Else
                            totalPosAPIPetition.SincronizacionFinal()
                            showMessage = True
                            Me.txtResponse.Text = "Operación cancelada... El tipo de tarjeta ingresada (" + IIf(cardResponse.Producto.Equals("c"), "crédito", "débito") + ") no es la misma que la opción seleccionada (" + IIf(Me.optCredito.Checked, "crédito", "débito") + "). Ingrese nuevamente la tarjeta seleccionando el tipo de tarjeta correcto (" + IIf(cardResponse.Producto.Equals("c"), "crédito", "débito") + ")."
                        End If
                    Else
                        If typeCardSelect.Equals("c") Then
                            msgResponse = MessageBox.Show("Estimado afiliado, a su pago realizado con Tarjeta de Crédito se le hará una disminución del 3% sobre su compra. El monto total de la compra será de $" + Me.txtImporte.Text.ToString() + ". ¿Deseas continuar?",
                                        "Informacion",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question,
                                        MessageBoxDefaultButton.Button2)
                            If msgResponse = vbYes Then
                                Me.txtResponse.Text = "Realizando operación... "
                                AplicarTarjeta()
                                response = totalPosAPIPetition.Autorizar()
                            Else
                                totalPosAPIPetition.SincronizacionFinal()
                                Me.txtResponse.Text = "Operación cancelada porque el cliente no aceptó la disminución... "
                                showMessage = True
                            End If
                        Else
                            Me.txtResponse.Text = "Realizando operación... "
                            response = totalPosAPIPetition.Autorizar()
                        End If
                        'totalPosAPIPetition.SincronizacionFinal()
                        'showMessage = True
                        'Me.txtResponse.Text = "Operación cancelada... Error: Los bines de la tarjeta no se han encontrado en el método totalPos.LeerTarjeta(), respuesta vacia."
                    End If
                Else
                    Dim txtRef = Me.txtReferenciaFinanciera.Text
                    parameters.Add(ParametroOperacion.ReferenciaFinanciera, txtRef)
                    totalPosAPIPetition.SetOperacion(operation.CancelacionVentaTarjeta, parameters)
                    cardResponse = totalPosAPIPetition.LeerTarjeta()
                    response = totalPosAPIPetition.Autorizar()
                    If response.BinExcepcion Then
                        Try
                            Dim numberCard = response.NumeroTarjeta
                            Dim name = response.Tarjetahabiente
                            Dim track2 = response.TrackII
                            Dim track1 = response.TrackI
                            Dim securityCode = response.Cvv
                            Dim mode = response.ModoLectura
                            Dim codeResponse As String
                            Dim numberAutoritation As String
                            Dim dataAutoritation As String
                            totalPosAPIPetition.FinalizarLecturaTarjeta(codeResponse, numberAutoritation, dataAutoritation, mode)
                        Catch ex As Exception
                        End Try
                    End If
                End If

                If showMessage = False Then
                    If response IsNot Nothing Then
                        DatosSucursal()
                        Application.DoEvents()
                        Me.txtResponse.Text = "ESPERE UN MOMENTO..."
                        Application.DoEvents()
                        DatosTarjeta(response)

                        If Registrar Then PinLog()
                        Me.txtAutorizacion.Text = response.Autorizacion.Trim
                        Me.txtReferenciaComercial.Text = response.ReferenciaDelComercio.Trim
                        Application.DoEvents()

                        If response.CodigoRespuesta.Equals("00") Then
                            Me.txtResponse.Text = ticket.Pagare("ORIGINAL", IIf(Me.chkVentaNormal.Checked, operation.Venta, operation.CancelacionVentaTarjeta), response, typeCardSelect)
                            My.Settings.registro = txtResponse.Text
                            My.Settings.Save()
                            If chkVentaNormal.Checked Then
                                AgregarPagoTarjeta(response.Importe, Mid(response.NumeroTarjeta, 13, 4), response.EmisorTarjeta, IIf(response.Tarjetahabiente.Trim <> "", response.Tarjetahabiente, miPedido.Nombre), response.Autorizacion, response.ReferenciaFinanciera, response.SecuenciaTransaccion, response.CodigoPromocion, response.Parcializacion, IIf(response.ProductoTarjeta = "c", 1, 0))
                                If ImporteRetiro > 0 Then
                                    RegistrarRetiroEfectivo() 'Cash Advance 
                                End If
                                ckNet.MsgInf("El pago se ha REGISTRADO correctamente, ahora debe ir a la pantalla de pagos abra el pedido y presione F5.")
                            Else
                                ckSuc.RegistrarEvento("PINPAD", ckSuc.UsuarioId, "CANCELAR PAGO", Me.txtPedidoId.Text, Me.txtImporte.Text, Me.txtTipoTarjeta.Text, Me.txtSecTxn.Text)
                                Dim miLineaRef As Integer = Val(Me.grdPagos.Columns("LineaRef").Value)
                                EliminarPagoTarjeta(miLineaRef)
                                ckNet.MsgInf("El pago se ha CANCELADO correctamente, ahora debe ir a la pantalla de pagos abra el pedido y presione F5.")
                            End If
                        ElseIf response.CodigoRespuesta.Equals("04") Or response.CodigoRespuesta.Equals("05") Then
                            Me.lblDeclinada.Visible = True
                        Else
                            Me.txtResponse.Text = response.CodigoRespuesta + " - " + response.Leyenda
                        End If
                        Me.txtResponse.Text = Me.txtResponse.Text & ControlChars.NewLine
                        Me.txtResponse.Text = Me.txtResponse.Text & ControlChars.NewLine
                        Me.txtResponse.Text = Me.txtResponse.Text & ControlChars.NewLine
                        Me.txtResponse.Text = Me.txtResponse.Text & "- - - - - - - - - - - - - - - - - - - -" & ControlChars.NewLine
                        Me.txtResponse.Text = Me.txtResponse.Text & ControlChars.NewLine
                        Me.txtResponse.Text = Me.txtResponse.Text & ControlChars.NewLine
                        Me.txtResponse.Text = Me.txtResponse.Text & ControlChars.NewLine
                        Me.txtResponse.Text = Me.txtResponse.Text & ticket.Pagare("COPIA", IIf(Me.chkVentaNormal.Checked, operation.Venta, operation.CancelacionVentaTarjeta), response, typeCardSelect)
                        Imprimir()
                    Else
                        totalPosAPIPetition.SincronizacionFinal()
                        Me.txtResponse.Text = "Operación cancelada... Error: Los bines de la tarjeta no se han encontrado en el método totalPos.LeerTarjeta(), respuesta vacia."
                    End If
                End If
                CargarPagosEliminables(txtPedidoId.Text)
                ckNet.LiberarMemoria()
            Catch exPetition As PeticionException
                totalPosAPIPetition.SincronizacionFinal()
                Me.txtResponse.Text = "Operación cancelada... Error BBVA: " + exPetition.Message
            Catch ex As Exception
                totalPosAPIPetition.SincronizacionFinal()
                Me.txtResponse.Text = "Operación cancelada... Error PINPAD: " + ex.Message
            End Try
        Catch ex As Exception
            ckSuc.RegistrarError(ex, "PinPadVX", "Procesar")
            totalPosAPIPetition.SincronizacionFinal()
            Throw New Exception("Error al procesar datos...!", ex)
        Finally
        End Try
    End Sub

    Public Function ValidarBancoPromocion(ByVal pBanco As String) As Boolean
        Dim resultado As Boolean = False
        Dim cmd As New SqlCommand("sp2PromocionesBancos")
        Dim tbl As DataTable = ckDatos.TablaSP(cmd)
        For Each dr As DataRow In tbl.Rows
            If InStr(pBanco.ToUpper, dr("Banco"), CompareMethod.Text) > 0 Then
                resultado = True
                Exit For
            End If
        Next
        cmd.Dispose() : cmd = Nothing
        tbl.Dispose() : tbl = Nothing
        Return resultado
    End Function

    Private Sub txtCVV2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCVV2.TextChanged
        'ckError.SetError(Me.txtCVV2, "")
    End Sub

    Private Sub btnRequest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRequest.Click
        Clipboard.SetText(ckVX.miRequest)
        ckNet.MsgInf(ckVX.miRequest)
    End Sub

    Private Sub btnResponse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResponse.Click
        Clipboard.SetText(ckVX.miResponse)
        ckNet.MsgInf(ckVX.miResponse)
    End Sub

    Private Sub grdPedidos_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs)
        If e.ColIndex = 0 Then
            Dim importe As Double = 0
            Me.txtImporte.Text = e.ColIndex
        End If
    End Sub

    Private Sub lblMAC_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblMAC.DoubleClick
        ModoAvanzado(Me.btnReimprimir.Enabled)
    End Sub

    Private Function PedidoAbierto() As String
        Dim resultado As String = ""
        Try
            Dim cmd As New SqlCommand("")
        Catch ex As Exception
            Throw ex
        End Try
        Return resultado
    End Function

    Private Sub CargarPedido()
        Me.txtResponse.Text = ""
        Try
            Me.lblDeclinada.Visible = False
            bMSI = False
            chkMeses.Checked = False
            DatosSucursal()

            Me.txtPedidoId.Text = IIf(PedidoId.Trim <> "" And ModoAutomatico, PedidoId.Trim, txtPedidoId.Text)
            If Operacion IsNot Nothing And Operacion <> "" Then
                IIf(Operacion.Contains("CREDITO"), Me.optCredito.Checked, Me.optDebito.Checked)
            End If
            Me.txtAfiliacion.Text = ckVX.Afiliacion
            Me.txtMinMonto.Text = ckVX.MinMonto
            Me.txtMaxMeses.Text = ckVX.MaxMeses
            Me.txtMeses.Text = ckVX.MaxMeses
            Me.lblMAC.Text = settings.ComercioMac 'ckNet.DireccionMAC
            lblCaja.Text = CajaId
            txtSucursal.Text = ckSuc.SucursalId
            txtTerminal.Text = settings.ComercioTerminal 'Mid(CajaId, Len(CajaId), 1)
            txtSesion.Text = Format(ckDatos.FechaServer, "MMdd")
            txtReferenciaComercial.Text = Me.txtPedidoId.Text
            miPedido.Desbloquear()
            PedidoId = Me.txtPedidoId.Text
            miPedido = New ckSucursal.ckPedido()
            miPedido.PedidoId = PedidoId

            If miPedido.Existe Then
                Dim especial As String = fxPedidoEspecial(miPedido.PedidoId)
                If especial <> "" Then
                    Me.txtResponse.Text = "No es posible abrir este pedido " & miPedido.PedidoId & ControlChars.NewLine & especial
                    Me.txtPedidoId.Clear()
                    Me.txtPedidoId.Focus()
                    Exit Sub
                End If

                Dim m_Bloqueado As String = miPedido.BloqueadoEn
                If m_Bloqueado = "" Or m_Bloqueado.ToUpper = ckNet.Terminal.ToUpper Then
                    miPedido.ObtenerDatos()
                    miPedido.Bloquear(ckNet.Terminal)
                    miPedido.Calcular()
                    lblEstatus.Text = miPedido.Estatus
                    lbiTotalPedido.Text = miPedido.TotalExtendido.ToString("0.00")
                    lbiPagosRegistrados.Text = TotalPagosRegistrados().ToString("0.00")

                    DatosDescuento()

                    If ModoAutomatico And Me.txtTipoTarjeta.Text = "DEBITO" And Importe > 0 Then
                        Me.txtImporte.Text = Importe
                    Else
                        txtImporte.Text = (Val(lbiTotalPedido.Text) - Val(lbiPagosRegistrados.Text)).ToString("0.00")
                    End If
                    If Me.chkVentaNormal.Checked Then
                        CargarPagosEliminables("")
                        grdPagos.Visible = False
                    Else
                        CargarPagosEliminables(txtPedidoId.Text)
                        grdPagos.Visible = True
                        If Not Probando Then
                            Me.chkMeses.Enabled = False
                        End If
                    End If
                    If Me.txtPedidoId.Text.Trim <> "" Then Me.ActiveControl = txtCVV2
                Else
                    Dim UsuarioTerminal As String = ""
                    UsuarioTerminal = fxUsuarioTerminal(m_Bloqueado)
                    Me.txtResponse.Text = "El pedido se encuentra abierto en " & m_Bloqueado & " por " & UsuarioTerminal
                    Me.ActiveControl = txtPedidoId
                    Return
                End If
            Else
                If PedidoId.Trim <> "" Then
                    Me.txtResponse.Text = "El pedido " & PedidoId & " no existe... "
                    Me.txtPedidoId.Clear()
                    Me.ActiveControl = Me.txtPedidoId
                Else
                    LimpiarCampos()
                End If
            End If

            ModoSupervisor(False)
            'ModoAvanzado(False)
            Me.txtImporte.ReadOnly = True
            chkVentaNormal.Checked = True
        Catch ex As Exception
            ckSuc.RegistrarError(ex, "PINPAD", "CargarPedido", True)
        End Try
    End Sub

    Private Sub DatosDescuento()
        If TieneDescuentoTarjeta() Then
            txtTipoTarjeta.Text = "CREDITO"
            optCredito.Checked = True
            lblDescuentoTarjeta.Visible = True
        Else
            txtTipoTarjeta.Text = "DEBITO"
            optDebito.Checked = True
            lblDescuentoTarjeta.Visible = False
        End If
    End Sub

    Private Function fxUsuarioTerminal(ByVal pTerminal As String) As String
        Dim resultado As String = ""
        Try
            Dim cmd As New SqlCommand("sp2UsuarioTerminal")
            cmd.Parameters.Add(New SqlParameter("@Terminal", SqlDbType.VarChar, 32)).Value = pTerminal
            resultado = CStr(ckDatos.ValorSP(cmd))
            cmd.Dispose()
            ckNet.LiberarMemoria()
        Catch ex As Exception
            ckNet.MsgErr(ex)
        End Try
        Return resultado
    End Function

    Public Function fxPedidoEspecial(ByVal pPedidoId As String) As String
        Dim resultado As String = ""
        Try
            Dim cmd As New SqlCommand("sp2PedidoEspecial")
            cmd.Parameters.Add("@PedidoId", SqlDbType.VarChar, 15).Value = pPedidoId
            resultado = ckDatos.ValorSP(cmd)
        Catch ex As Exception
            resultado = "Error!" & ex.Message
        End Try
        Return resultado
    End Function

    Private Sub AplicarTarjeta()
        Try
            If lblEstatus.Text = "CONFIRMADO" Then
                Dim monto As Double = Val(txtImporte.Text)
                If monto < 0 Then monto = Val(lblTotalPedido.Text)
                If monto = 0 Then Return
                Dim cmd As New SqlCommand("spTARJETA")
                cmd.Parameters.AddWithValue("@PedidoId", PedidoId)
                cmd.Parameters.AddWithValue("@Monto", monto)
                cmd.Parameters.AddWithValue("@APLICAR", 1)
                ckDatos.EjecutarSP(cmd)
                cmd.Dispose()

                'paul revisa si esto se tiene que hacer aqui también
                'Pedido.ObtenerDatos()
                'ActualizarTodosLosTotales()
            End If
        Catch ex As Exception
            Throw New Exception("Error en PagosRegistrados", ex)
        End Try

    End Sub

    Public Sub SinTarjeta()
        Try
            Dim cmd As New SqlCommand("sp2PagosSinTarjeta")
            cmd.Parameters.Add("@PedidoId", SqlDbType.VarChar, 15).Value = PedidoId
            ckDatos.EjecutarSP(cmd)
            cmd.Dispose()
        Catch ex As Exception
            Throw New Exception("Error en SinTarjeta!", ex)
        End Try
    End Sub

    Public Function TieneDescuentoTarjeta() As Boolean
        Dim resultado As Boolean = False
        Try
            Dim cmd As New SqlCommand("spPINPADtieneDescuento")
            cmd.Parameters.AddWithValue("@PedidoId", PedidoId)
            Dim valor As String = ""
            valor = ckDatos.ValorSP(cmd)
            cmd.Dispose()
            If valor.Trim <> "" Then resultado = True
            Return resultado
        Catch ex As Exception
            Throw New Exception("Error en TieneDescuentoTarjeta!", ex)
        End Try
    End Function

    Public Function TotalPagosRegistrados() As Double
        Dim resultado As Double = 0
        Try
            Dim cmd As New SqlCommand("spPINPADpagosRegistrados")
            cmd.Parameters.AddWithValue("@PedidoId", PedidoId)
            resultado = Val(ckDatos.ValorSP(cmd))
            cmd.Dispose()
            Return resultado
        Catch ex As Exception
            Throw New Exception("Error en TotalPagosRegistrados!", ex)
        End Try
    End Function

    Public Function PinPadTienePagos() As Double
        Dim resultado As Double = 0
        Try
            Dim cmd As New SqlCommand("spPINPADtienePagos")
            cmd.Parameters.AddWithValue("@PedidoId", PedidoId)
            resultado = Val(ckDatos.ValorSP(cmd))
            cmd.Dispose()
            Return resultado
        Catch ex As Exception
            Throw New Exception("Error en PinPadTienePagos!", ex)
        End Try
    End Function

    Private Sub txtPedidoId_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPedidoId.TextChanged
        Me.txtReferenciaComercial.Text = Me.txtPedidoId.Text
    End Sub

    Private Sub btnReimprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReimprimir.Click
        Me.txtResponse.Text = My.Settings.registro
        Imprimir()
    End Sub

    Private Sub CargarPagosEliminables(ByVal pPedidoId As String)
        Try
            Dim cmd As New SqlCommand("spPINPADpagosEliminables")
            cmd.Parameters.AddWithValue("@Pedidoid", pPedidoId)
            Dim tblPagos As DataTable = ckDatos.TablaSP(cmd)

            grdPagos.SetDataBinding(tblPagos, "", False)
            If LineaRef > 0 Then
                For i As Integer = 0 To Me.grdPagos.RowCount - 1
                    grdPagos.Row = i
                    Dim linref As Integer = Val(grdPagos.Columns("LineaRef").Value)
                    If linref = LineaRef Then
                        DatosCancelar()
                        Exit For
                    End If
                Next
            Else
                DatosCancelar()
            End If
            cmd.Dispose()
            ckNet.LiberarMemoria()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TotalTarjeta(ByVal pPedidoId As String, ByVal pImporte As Double)
        Try
            Dim resultado As Double = 0

            Dim cmd As New SqlCommand("spTARJETA")
            cmd.Parameters.Add("@PedidoId", SqlDbType.VarChar, 16).Value = pPedidoId
            cmd.Parameters.Add("@Monto", SqlDbType.Money).Value = pImporte
            cmd.Parameters.Add("@APLICAR", SqlDbType.Money).Value = 0
            resultado = ckDatos.ValorSP(cmd)
            txtImporte.Text = Format(resultado, "0.00")
            cmd.Dispose()

        Catch ex As Exception
            Throw New Exception("Error en TotalTarjeta!", ex)
        End Try
    End Sub

    Private Sub lblEstatus_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblEstatus.TextChanged
        Me.lblEstatus.ForeColor = ckSuc.ColorEstatus(Me.lblEstatus.Text)
    End Sub

    Private Sub grdPagos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub grdPagos_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles grdPagos.RowColChange
        DatosCancelar()
    End Sub

    Private Sub DatosCancelar()
        If grdPagos.RowCount > 0 Then

            txtImporte.Text = Format(Val(grdPagos.Columns("Monto").Text), "#0.00")
            txtAutorizacion.Text = grdPagos.Columns("Autorizacion").Text
            txtSecTxn.Text = grdPagos.Columns("SecTxn").Text
            txtReferenciaComercial.Text = grdPagos.Columns("PedidoId").Text
            txtReferenciaFinanciera.Text = grdPagos.Columns("Referencia").Text
            txtTipoTarjeta.Text = grdPagos.Columns("Tipo").Text

            If txtTipoTarjeta.Text = "CREDITO" Then
                optCredito.Checked = True
            Else
                optDebito.Checked = True
            End If
        End If
    End Sub

    Private Sub txtPedidoId_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPedidoId.Validated
        If Me.txtPedidoId.Text.Trim <> "" Then
            Me.txtPedidoId.Text = ckSucursal.ckPedido.FormatearFolio(Me.txtPedidoId.Text)
            CargarPedido()
        Else
            Me.ActiveControl = Me.txtPedidoId
        End If
    End Sub

    Private Sub optCredito_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optCredito.Click
        If Me.txtPedidoId.Text.Trim = "" Then Return

        If Me.chkVentaNormal.Checked Then
            If optCredito.Checked Then
                If MessageBox.Show("Esta opción modificará el descuento de los modelos en el pedido seleccionado", "Continuar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    txtTipoTarjeta.Text = "CREDITO"
                    txtResponse.Text = "El descuento de este pedido ha sido MODIFICADO para pagar con CREDITO..."
                    AplicarTarjeta()
                Else
                    optDebito.Checked = True
                End If
            End If
            CargarPedido()
        End If
        Me.ActiveControl = txtCVV2
    End Sub

    Private Sub optDebito_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optDebito.Click
        If Me.txtPedidoId.Text.Trim = "" Then Return
        If Me.chkVentaNormal.Checked Then
            If optDebito.Checked Then
                txtTipoTarjeta.Text = "DEBITO"
                SinTarjeta()
                txtResponse.Text = "El descuento de este pedido ha sido RESTAURADO para pagar con DEBITO..."
                Dim miPedido As New ckSucursal.ckPedido(PedidoId)
                miPedido.Calcular()
                CargarPedido()
            End If
        End If
    End Sub

    Private Sub DetectaCredito()
        optDebito.Checked = False
        optCredito.Checked = True
        txtTipoTarjeta.Text = "CRÉDITO"
        TotalTarjeta(Me.txtPedidoId.Text, Val(Me.txtImporte.Text))
        'txtResponse.Text = "El descuento de este pedido ha sido RESTAURADO para pagar con DEBITO..."
        Dim miPedido As New ckSucursal.ckPedido(PedidoId)
        miPedido.Calcular()
        CargarPedido()
    End Sub

    Private Sub DetectaDebito()
        optDebito.Checked = True
        optCredito.Checked = False
        txtTipoTarjeta.Text = "DEBITO"
        SinTarjeta()
        txtResponse.Text = "El descuento de este pedido ha sido RESTAURADO para pagar con DEBITO..."
        Dim miPedido As New ckSucursal.ckPedido(PedidoId)
        miPedido.Calcular()
        CargarPedido()
    End Sub

    Private Sub optCredito_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optCredito.CheckedChanged

    End Sub

    Public Sub AgregarPagoTarjeta(ByVal pMonto As Double, ByVal pNumero As String, ByVal pBanco As String, ByVal pNombre As String, ByVal pAutorizacion As String, ByVal pReferencia As String, ByVal pSecuencia As String, ByVal pPromocion As String, ByVal pMeses As String, ByVal pTipo As Byte)
        If pMonto <= 0 Then Return
        If pBanco.Trim = "" Then pBanco = "Bancomer"
        Dim cmd As New SqlCommand("sp2PagosAgregar")
        cmd.Parameters.Add("@PedidoId", SqlDbType.VarChar, 15).Value = miPedido.PedidoId
        cmd.Parameters.Add("@ClienteId", SqlDbType.VarChar, 30).Value = miPedido.ClienteId
        cmd.Parameters.Add("@TipoPago", SqlDbType.VarChar, 2).Value = "TC"
        cmd.Parameters.Add("@Monto", SqlDbType.Money).Value = Math.Round(pMonto, 2)
        cmd.Parameters.Add("@MontoCQ", SqlDbType.Money).Value = Math.Round(pMonto, 2)
        cmd.Parameters.Add("@Numero", SqlDbType.VarChar, 30).Value = pNumero
        cmd.Parameters.Add("@Banco", SqlDbType.VarChar, 30).Value = pBanco
        cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 64).Value = pNombre
        cmd.Parameters.Add("@Autorizacion", SqlDbType.VarChar, 15).Value = pAutorizacion
        cmd.Parameters.Add("@FechaVenc", SqlDbType.SmallDateTime).Value = ckDatos.FechaServer
        cmd.Parameters.Add("@UsuarioId", SqlDbType.VarChar, 10).Value = ckSuc.UsuarioId
        cmd.Parameters.Add("@Referencia", SqlDbType.VarChar, 30).Value = pReferencia
        cmd.Parameters.Add("@SecTxn", SqlDbType.VarChar, 10).Value = pSecuencia
        cmd.Parameters.Add("@Promocion", SqlDbType.VarChar, 10).Value = pPromocion
        cmd.Parameters.Add("@Meses", SqlDbType.VarChar, 10).Value = pMeses
        cmd.Parameters.Add("@CrediDebi", SqlDbType.SmallInt).Value = pTipo
        ckDatos.EjecutarSP(cmd)
    End Sub

    Private Sub EliminarPagoTarjeta(ByVal pLineaRef As Integer)
        Dim cmd As New SqlCommand("sp2PagosEliminar")
        cmd.Parameters.Add("@PedidoId", SqlDbType.VarChar, 15).Value = miPedido.PedidoId
        cmd.Parameters.Add("@LineaRef", SqlDbType.Int).Value = pLineaRef
        cmd.Parameters.Add("@Lupd_User", SqlDbType.VarChar, 10).Value = ckSuc.UsuarioId
        ckDatos.EjecutarSP(cmd)
    End Sub

    Private Sub PinLog()
        Try
            Dim cmd As New SqlCommand("spPinLog")
            cmd.Parameters.AddWithValue("@PedidoId", miPedido.PedidoId)
            cmd.Parameters.AddWithValue("@ClienteId", miPedido.ClienteId)
            cmd.Parameters.AddWithValue("@Requerimiento", ckVX.miRequest)
            cmd.Parameters.AddWithValue("@Respuesta", ckVX.miResponse)
            ckDatos.EjecutarSP(cmd)
        Catch ex As Exception
            ckSuc.RegistrarError(ex, "PinPadVX", "PinLog", True)
            'ckNet.MsgErr(ex)
        End Try
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Nuevo()
    End Sub

    Private Sub Nuevo()
        If Not ModoAutomatico Then
            Me.txtPedidoId.Text = ""
            CargarPedido()
            ActiveControl = Me.txtPedidoId
            bMSI = False
            chkMeses.Checked = False
            ImporteRetiro = 0
            Me.txtDispEfe.Text = ""
            Me.lblCliente.Text = ""
        End If
    End Sub

    Private Sub LimpiarCampos()
        Me.txtCVV2.Text = ""
        Me.txtImporte.Text = ""
        Me.lbiPagosRegistrados.Text = ""
        Me.lbiTotalPedido.Text = ""
        Me.txtResponse.Text = ""
        Me.txtAutorizacion.Text = ""
        Me.txtReferenciaFinanciera.Text = ""
        Me.txtSecTxn.Text = ""
        Me.lblDescuentoTarjeta.Visible = False
        Me.lblDeclinada.Visible = False
    End Sub

    Private Sub optDebito_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optDebito.CheckedChanged

    End Sub

    Private Sub chkVentaNormal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVentaNormal.CheckedChanged

        If Me.chkVentaNormal.Checked Then
            Me.chkVentaNormal.Text = "Venta Normal"
            Me.chkVentaNormal.ForeColor = Color.Black
            LimpiarCampos()
            Me.grdPagos.Visible = False
            CargarPagosEliminables("")
            Me.txtImporte.ReadOnly = True
        Else
            Me.chkVentaNormal.Text = "CANCELACION"
            LimpiarCampos()
            Me.chkVentaNormal.ForeColor = Color.Red
            Me.grdPagos.Visible = True
            CargarPagosEliminables(txtPedidoId.Text)
            Me.txtResponse.Text = "NOTA: PARA CANCELAR UN PAGO DE LA PINPAD DEBE TENER A LA MANO LA TARJETA CON LA QUE REALIZO EL PAGO"
            Me.txtImporte.ReadOnly = True
        End If

    End Sub

    Private Sub btnCargarLlaves_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargarLlaves.Click
        CargarLlaves()
    End Sub

    Private Sub CargarLlaves()
        Dim parameters As New Dictionary(Of ParametroOperacion, Object)
        Dim totalPosAPIPetition As New Peticion
        Dim operation As New Operacion
        Dim response As Respuesta
        DatosSucursal()
        Try
            totalPosAPIPetition.SetAfiliacion(settings.ComercioAfiliacion, Moneda.Pesos)
            totalPosAPIPetition.SetTerminal(settings.ComercioTerminal, settings.ComercioMac)
            totalPosAPIPetition.Operador = settings.Operador
            totalPosAPIPetition.Fecha = DateTime.Now.ToString("yyyyMMddHHmmss")
            totalPosAPIPetition.Amex = False
            totalPosAPIPetition.SetOperacion(Operation.CargaLlaves, Nothing)
            response = totalPosAPIPetition.Autorizar()
            If response.CodigoRespuesta.Equals("00") Then
                Me.txtResponse.Text = "Carga de llaves exitosa."
            Else
                Me.txtResponse.Text = response.CodigoRespuesta + " - " + response.Leyenda
            End If
        Catch exPetition As PeticionException
            Me.txtResponse.Text = "Error en la petición: " + exPetition.Message
        Catch ex As Exception
            Me.txtResponse.Text = "Error: " + ex.Message
        End Try
    End Sub

    Private Function fxSecTransaccion() As Integer
        Dim resultado = 0
        Try
            Dim cmd As New SqlCommand("spPinPadCajas")
            cmd.Parameters.AddWithValue("@CajaId", CajaId)
            resultado = ckDatos.ValorSP(cmd)
            If resultado >= 10000 Then resultado = 1
            ckDatos.EjecutarSQL("update VT_CAJA set User01=" & resultado & " where cajaid='" & CajaId & "'")
        Catch ex As Exception
            Throw New Exception("Error en fxSecTransaccion...!", ex)
        End Try
        Return resultado
    End Function

    Public Sub DatosSucursal()
        Try
            Dim cmd As New SqlCommand("spPinPadDatos")
            Dim tbl As DataTable = ckDatos.TablaSP(cmd)
            For Each dr As DataRow In tbl.Rows
                With ckVX
                    .Afiliacion = Val(dr("Afiliacion"))
                    .SucNombre = CStr(dr("Nombre"))
                    .SucDomicilio = CStr(dr("Domicilio"))
                    .SucColoinia = CStr(dr("Colonia")) & " CP:" & CStr(dr("CP"))
                    .SucCiudad = CStr(dr("Ciudad")) & ", " & CStr(dr("Estado"))
                    .MinMonto = Val(dr("MinMonto"))
                    .MaxMeses = Val(dr("MaxMeses"))
                End With
                Exit For
            Next
        Catch ex As Exception
            Throw New Exception("Error en DatosSucursal...!", ex)
        End Try
    End Sub

    Public Sub DatosTarjeta(ByVal response As Respuesta)
        Try
            Dim numero As String = ""
            numero = Mid(response.NumeroTarjeta, 1, 6)


            Dim cmd As New SqlCommand("spPinPadBines")
            cmd.Parameters.AddWithValue("@bin", numero)
            Dim tBines As DataTable = ckDatos.TablaSP(cmd)
            Dim tarjetaTipo As String = ""
            Dim tarjetaBanco As String = ""
            For Each dr As DataRow In tBines.Rows
                tarjetaTipo = CStr(dr("Tipo"))
                tarjetaBanco = CStr(dr("Banco"))
                Exit For
            Next

            Select Case tarjetaTipo.ToUpper
                Case "D" : tarjetaTipo = "DEBITO"
                Case "C" : tarjetaTipo = "CREDITO"
                Case Else : tarjetaTipo = "DESCONOCIDO"
            End Select

        Catch ex As Exception
            Throw New Exception("Error en DatosTarjeta...!", ex)
        End Try
    End Sub

    Private Sub lblMAC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMAC.Click
        Clipboard.SetText(Me.lblMAC.Text)
    End Sub

    Private Function fxBandera1() As Integer
        Dim resultado As String = ""
        Dim miFile As String = "PinPadConfig.txt"
        Dim miSr As StreamReader = Nothing
        Try
            Dim archivo As String = ""
            If File.Exists(My.Application.Info.DirectoryPath & "\" & miFile) Then
                archivo = My.Application.Info.DirectoryPath & "\" & miFile
                'ElseIf File.Exists("..\" & miFile) Then
                '    archivo = "..\" & miFile
                'Else
                'archivo = ckNet.BuscaArchivo(miFile)


                miSr = File.OpenText(archivo)

                Do While miSr.Peek() >= 0
                    resultado = miSr.ReadLine
                    If Mid(resultado, 1, 10) = "CARGALLAVE" Then
                        resultado = Mid(resultado, 12, 1)
                        Exit Do
                    End If
                Loop

            End If
        Catch ex As Exception
            Throw New Exception("Error al obtener Bandera1!" & ControlChars.NewLine & ex.Message, ex)
        Finally
            If Not miSr Is Nothing Then miSr.Close()
        End Try

        Return Val(resultado)
    End Function

    Private Sub txtImporte_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtImporte.DoubleClick
        'If ModoAutomatico Then Return
        If Not chkVentaNormal.Checked Then Return
        Me.txtImporte.ReadOnly = Not Me.txtImporte.ReadOnly
    End Sub

    Private Sub txtImporte_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtImporte.TextChanged

    End Sub

#Region "Disposición de Efectivo"

    'Valida si pueden realizar Retiros de Efectivo
    Private Function fxRetirosEfectivo() As Boolean
        Dim result As Boolean = False

        Try
            If My.Settings.retiros Then
                result = True
            End If
        Catch ex As Exception
            result = False
        End Try

        Return result
    End Function

    'Muestra formulario para obtener el importe a disponer
    Private Sub RetiroEfectivo()
        Dim frm As New frmClientes
        frm.ShowDialog()

        ClienteId = frm.ClienteId
        ImporteRetiro = CDbl(frm.Importe_Retirar)

        Me.lblCliente.Text = ClienteId
        Me.txtDispEfe.Text = ImporteRetiro
    End Sub

    Private Sub btnRetiro_Click(sender As Object, e As EventArgs) Handles btnRetiro.Click
        RetiroEfectivo()
    End Sub

    'Funcion que da formato a valor double en string con punto decimal
    Private Function fxImporte(ByVal pImporte As Double) As String
        'Formatear importe 123.45 = 000000012345
        Dim resultado As String = ""
        resultado = Format(Fix(pImporte), StrDup(10, "0")) & Format((pImporte - Fix(pImporte)) * 100, "00")
        Return resultado
    End Function

    'Registra la disposición del efectivo
    Private Sub RegistrarRetiroEfectivo()
        Try
            Dim RetiroId As Integer = 0
            RetiroId = fxCrearRetiro()
            InsertarRetiro(RetiroId)

        Catch ex As Exception
            Throw New Exception("Error en registrar Disposición de Efectivo...!", ex)
        End Try
    End Sub

    'Funcion que devuelve la caja para el usuario y terminal ingresado
    Private Function CajasTerminal(ByVal pUsuarioId As String, ByVal pTerminal As String, ByVal pTipo As String) As DataTable
        Dim cmd As New SqlCommand("spCajasTerminal")
        cmd.Parameters.AddWithValue("@UsuarioId", pUsuarioId)
        cmd.Parameters.AddWithValue("@Terminal", pTerminal)
        cmd.Parameters.AddWithValue("@Tipo", pTipo)
        Return ckDatos.TablaSP(cmd)
    End Function

    'Funcion que obtiene nombre de la Caja
    Private Function fxNombreCaja() As String
        Dim m_caja As String = ""
        Try
            Dim lascajas As String = ""
            Dim tblCajas As DataTable = CajasTerminal(ckSuc.UsuarioId, ckNet.Terminal, "V")
            If tblCajas.Rows.Count > 1 Then
                For Each dr As DataRow In tblCajas.Rows
                    lascajas = lascajas & IIf(lascajas <> "", " | ", "") & dr("CajaId").ToString.Trim
                Next
                m_caja = InputBox("Escriba el nombre de la caja que desea utilizar" & ControlChars.NewLine & "Cajas Disponibles: " & lascajas, "Seleccionar Caja", "")
            ElseIf tblCajas.Rows.Count = 1 Then
                m_caja = tblCajas.Rows(0)("CajaId").ToString.Trim
            End If
        Catch ex As Exception
            m_caja = ""
        End Try
        Return m_caja
    End Function

    'Crea el retiro de efectivo por disposición
    Private Function fxCrearRetiro() As Integer
        Dim RetiroId As Integer = 0
        Try
            Dim cmdRetiro As New SqlCommand("sp2RetirosGuardar")
            Dim pRetiroId As New SqlParameter("@RetiroId", SqlDbType.Int)
            pRetiroId.Direction = ParameterDirection.InputOutput
            cmdRetiro.Parameters.Add(pRetiroId).Value = RetiroId
            cmdRetiro.Parameters.Add("@CajaId", SqlDbType.VarChar, 8).Value = fxNombreCaja()
            cmdRetiro.Parameters.Add("@CajeroId", SqlDbType.VarChar, 8).Value = ckSuc.UsuarioId
            cmdRetiro.Parameters.Add("@SupervisorId", SqlDbType.VarChar, 8).Value = SuperUsuario
            cmdRetiro.Parameters.Add("@Notas", SqlDbType.VarChar, 512).Value = "Disposición Efectivo"
            ckDatos.EjecutarSP(cmdRetiro)
            RetiroId = pRetiroId.Value
            cmdRetiro.Dispose()
        Catch ex As Exception
            ckNet.MsgErr("Error al Crear la disposicion de efectivo en BD")
        End Try

        Return RetiroId
    End Function

    'Inserta el detalle del la disposicón de efectivo
    Private Sub InsertarRetiro(ByVal RetiroId As Integer)
        Try
            Dim cmdDetalle As New SqlCommand("sp2RetirosDetInsertar")
            cmdDetalle.Parameters.Add("@RetiroId", SqlDbType.Int).Value = RetiroId
            cmdDetalle.Parameters.Add("@LineaRef", SqlDbType.Int).Value = 0
            cmdDetalle.Parameters.Add("@TabularId", SqlDbType.Int).Value = 0
            cmdDetalle.Parameters.Add("@Cantidad", SqlDbType.Int).Value = 0
            cmdDetalle.Parameters.Add("@Importe", SqlDbType.Money).Value = ImporteRetiro
            cmdDetalle.Parameters.Add("@Total", SqlDbType.Money).Value = ImporteRetiro
            cmdDetalle.Parameters.Add("@Numero", SqlDbType.VarChar, 16).Value = ""
            cmdDetalle.Parameters.Add("@Banco", SqlDbType.VarChar, 32).Value = ""
            cmdDetalle.Parameters.Add("@Nombre", SqlDbType.VarChar, 64).Value = ""
            ckDatos.EjecutarSP(cmdDetalle)
            cmdDetalle.Dispose()

        Catch ex As Exception
            ckNet.MsgErr("Error al insertar el detalle de la disposicion de efectivo")
        End Try
    End Sub

    'Cierra el retiro y actualiza el total de efectivo en caja
    Private Sub CerrarRetiro(ByVal RetiroId As Integer)
        Try
            Dim cmdLiberar As New SqlCommand("sp2RetirosLiberar")
            cmdLiberar.Parameters.Add("@RetiroId", SqlDbType.Int).Value = RetiroId
            cmdLiberar.Parameters.Add("@CajaId", SqlDbType.VarChar, 8).Value = fxNombreCaja()
            cmdLiberar.Parameters.Add("@Total", SqlDbType.Money).Value = ImporteRetiro
            ckDatos.EjecutarSP(cmdLiberar)
            cmdLiberar.Dispose()

            Dim Copias As Integer = 1
            For i As Integer = 1 To Copias
                ckPrinter.PrintString(cmbImpresora.Text, ckPrinter.ckReset & fxTicketRetiro(RetiroId) & ckPrinter.ckTearOff)
            Next

            ckSuc.RegistrarEvento("PAGOS", SuperUsuario, "RETIRAR", RetiroId, fxNombreCaja(), ckSuc.UsuarioId, ImporteRetiro)
        Catch ex As Exception

        End Try

    End Sub

    'Funcion que genera la impresion del ticket para copia en caja
    Public Function fxTicketRetiro(ByVal pRetiroId As Integer) As String
        Dim resultado As String = ""
        Dim str As New StringBuilder("")
        Try

            Dim cmd As New SqlCommand("sp2RetirosTotal")
            cmd.Parameters.Add("@RetiroId", SqlDbType.Int).Value = pRetiroId
            Dim tbl As DataTable = ckDatos.TablaSP(cmd)

            If tbl.Rows.Count > 0 Then
                Dim dr As DataRow = tbl.Rows(0)
                str.AppendLine()
                str.AppendLine("Retiro de efectivo: " & dr("RetiroId"))
                str.AppendLine("ESTATUS: " & dr("Estatus"))
                str.AppendLine()
                str.AppendLine("Caja: " & dr("CajaId"))
                str.AppendLine("Fecha: " & CDate(dr("Fecha")).ToLongDateString)
                str.AppendLine("Hora: " & CDate(dr("Fecha")).ToLongTimeString)
                str.AppendLine("TOTAL: " & Val(dr("Total")).ToString("$#,##0.00"))
                str.AppendLine()
                str.AppendLine("Cajero: " & dr("Cajero"))
                str.AppendLine("Supervisor: " & dr("Supervisor"))
                str.AppendLine()

                str.AppendLine("EFECTIVO")
                str.AppendLine(ckNet.StrIZQ("IMPORTE", 13) & ckNet.StrDER("CANTIDAD", 8) & ckNet.StrDER("TOTAL", 19))
                str.AppendLine(StrDup(40, "-"))

                Dim cmdDet As New SqlCommand("sp2RetirosDetalle")
                cmdDet.Parameters.Add("@RetiroId", SqlDbType.Int).Value = pRetiroId
                Dim tblDet As DataTable = ckDatos.TablaSP(cmdDet)


                Dim dTotalEfe As Double = 0
                For Each drdet As DataRow In tblDet.Rows
                    str.AppendLine(ckNet.StrDER(drdet("Nombre"), 13) & ckNet.StrDER(drdet("Cantidad"), 8) & ckNet.StrDER(Val(drdet("Total")).ToString("$#,##0.00"), 19))
                    dTotalEfe = dTotalEfe + drdet("Total")
                Next
                str.AppendLine(StrDup(40, "-"))
                str.AppendLine(ckNet.StrDER("TOTAL EFECTIVO: " & dTotalEfe.ToString("$#,##0.00"), 40))

                str.AppendLine()

                str.AppendLine(StrDup(40, "_"))
                str.AppendLine(ckNet.StrDER("TOTAL: " & Format(dTotalEfe, "$#,##0.00"), 40))

                str.AppendLine()
                str.AppendLine(dr("Notas"))
                str.AppendLine()
                cmdDet.Dispose()
                tblDet.Dispose()
            End If

            resultado = str.ToString
            cmd.Dispose()
            tbl.Dispose()
        Catch ex As Exception
            Throw ex
        End Try
        Return resultado
    End Function


#End Region

    'Valida si muestra el mensaje de puntos BBVA
    Private Function fxPuntos() As Boolean
        Dim result As Boolean = False

        Try
            If My.Settings.puntos And Not chkMeses.Checked Then
                Dim dr As DialogResult = MessageBox.Show("¿Desea utilizar sus Puntos Bancomer? ", "Puntos Bancomer",
                              MessageBoxButtons.YesNo,
                              MessageBoxIcon.Question)

                If dr = DialogResult.Yes Then result = True
            End If
        Catch ex As Exception
            result = False
        End Try

        Return result
    End Function

    Private Sub txtTerminal_TextChanged(sender As Object, e As EventArgs) Handles txtTerminal.TextChanged

    End Sub

    Private Sub txtAfiliacion_TextChanged(sender As Object, e As EventArgs) Handles txtAfiliacion.TextChanged

    End Sub

    Private Sub ckPanel_Paint(sender As Object, e As PaintEventArgs) Handles ckPanel.Paint

    End Sub

    Private Sub txtTipoTarjeta_TextChanged(sender As Object, e As EventArgs) Handles txtTipoTarjeta.TextChanged

    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        Dim frmSettings As New Configuracion
        frmSettings.ShowDialog()
        frmSettings.Dispose()
    End Sub

    Private Sub txtPuntosAction(sender As Object, e As EventArgs) Handles txtPuntos.Click
        Dim parameters As New Dictionary(Of ParametroOperacion, Object)
        Dim totalPosAPIPetition As New Peticion
        Dim operation As New Operacion
        Dim response As Respuesta
        Dim cardResponse As Tarjeta
        DatosSucursal()
        Try
            Me.txtResponse.Text = "INSERTE/DESLICE TARJETA..."
            Application.DoEvents()
            parameters.Add(ParametroOperacion.ReferenciaComercio, Val(Me.txtReferenciaComercial.Text))
            totalPosAPIPetition.SetAfiliacion(settings.ComercioAfiliacion, Moneda.Pesos)
            totalPosAPIPetition.SetTerminal(settings.ComercioTerminal, settings.ComercioMac)
            totalPosAPIPetition.Operador = settings.Operador
            totalPosAPIPetition.Fecha = DateTime.Now.ToString("yyyyMMddHHmmss")
            totalPosAPIPetition.Amex = False
            totalPosAPIPetition.SetOperacion(operation.ConsultaPuntos, parameters)
            cardResponse = totalPosAPIPetition.LeerTarjeta()
            response = totalPosAPIPetition.Autorizar()

            If response.CodigoRespuesta.Equals("00") Then
                Me.txtResponse.Text = "Operación exitosa."
                Me.txtResponse.Text = ticket.ConsultaPuntos(response)

            Else
                Me.txtResponse.Text = response.CodigoRespuesta + " - " + response.Leyenda
            End If
        Catch exPetition As PeticionException
            Me.txtResponse.Text = "Error en la petición: " + exPetition.Message
        Catch ex As Exception
            Me.txtResponse.Text = "Error: " + ex.Message
        End Try
    End Sub
End Class
