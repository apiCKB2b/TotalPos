<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPinPad
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPinPad))
        Me.txtResponse = New System.Windows.Forms.TextBox()
        Me.pnlPedido = New System.Windows.Forms.Panel()
        Me.chkVentaNormal = New System.Windows.Forms.CheckBox()
        Me.lblEstatus = New System.Windows.Forms.Label()
        Me.txtPedidoId = New Cklass.Net.ckTextBox()
        Me.lblPedido = New System.Windows.Forms.Label()
        Me.ckPanel = New System.Windows.Forms.Panel()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.lblClienteId = New System.Windows.Forms.Label()
        Me.txtDispEfe = New Cklass.Net.ckTextBox()
        Me.lblDisponer = New System.Windows.Forms.Label()
        Me.lblSUC = New System.Windows.Forms.Label()
        Me.lblDescuentoTarjeta = New System.Windows.Forms.Label()
        Me.lblDeclinada = New System.Windows.Forms.Label()
        Me.lbiTotalPedido = New System.Windows.Forms.Label()
        Me.lblTotalPedido = New System.Windows.Forms.Label()
        Me.lbiPagosRegistrados = New System.Windows.Forms.Label()
        Me.optCredito = New System.Windows.Forms.RadioButton()
        Me.optDebito = New System.Windows.Forms.RadioButton()
        Me.lblPagosRegistrados = New System.Windows.Forms.Label()
        Me.txtImporte = New Cklass.Net.ckTextBox()
        Me.lblMAC = New System.Windows.Forms.Label()
        Me.lblCaja = New System.Windows.Forms.Label()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.txtTipoTarjeta = New System.Windows.Forms.TextBox()
        Me.txtMaxMeses = New System.Windows.Forms.TextBox()
        Me.lblMaxMeses = New System.Windows.Forms.Label()
        Me.txtMinMonto = New System.Windows.Forms.TextBox()
        Me.lblMinMonto = New System.Windows.Forms.Label()
        Me.lblAfiliacion = New System.Windows.Forms.Label()
        Me.txtAfiliacion = New System.Windows.Forms.TextBox()
        Me.chkMeses = New System.Windows.Forms.CheckBox()
        Me.txtAutorizacion = New System.Windows.Forms.TextBox()
        Me.lblAprobacion = New System.Windows.Forms.Label()
        Me.txtReferenciaFinanciera = New System.Windows.Forms.TextBox()
        Me.lblReferencia = New System.Windows.Forms.Label()
        Me.lblSec = New System.Windows.Forms.Label()
        Me.txtSecTxn = New System.Windows.Forms.TextBox()
        Me.txtMeses = New System.Windows.Forms.TextBox()
        Me.lblImporte = New System.Windows.Forms.Label()
        Me.txtCVV2 = New System.Windows.Forms.TextBox()
        Me.lblCVV2 = New System.Windows.Forms.Label()
        Me.txtReferenciaComercial = New System.Windows.Forms.TextBox()
        Me.lblReferenciaComercial = New System.Windows.Forms.Label()
        Me.txtSesion = New System.Windows.Forms.TextBox()
        Me.lblSesion = New System.Windows.Forms.Label()
        Me.txtTerminal = New System.Windows.Forms.TextBox()
        Me.lblTerminal = New System.Windows.Forms.Label()
        Me.txtSucursal = New System.Windows.Forms.TextBox()
        Me.lblSucursal = New System.Windows.Forms.Label()
        Me.ckToolBar = New System.Windows.Forms.ToolStrip()
        Me.btnProcesar = New System.Windows.Forms.ToolStripButton()
        Me.btnSupervisor = New System.Windows.Forms.ToolStripButton()
        Me.btnCerrar = New System.Windows.Forms.ToolStripButton()
        Me.btnImprimir = New System.Windows.Forms.ToolStripButton()
        Me.cmbImpresora = New System.Windows.Forms.ToolStripComboBox()
        Me.btnNuevo = New System.Windows.Forms.ToolStripButton()
        Me.txtPuntos = New System.Windows.Forms.ToolStripButton()
        Me.btnCargarLlaves = New System.Windows.Forms.ToolStripButton()
        Me.btnSettings = New System.Windows.Forms.ToolStripButton()
        Me.btnReimprimir = New System.Windows.Forms.ToolStripButton()
        Me.btnRequest = New System.Windows.Forms.ToolStripButton()
        Me.btnResponse = New System.Windows.Forms.ToolStripButton()
        Me.btnRetiro = New System.Windows.Forms.ToolStripButton()
        Me.grdPagos = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.pnlPedido.SuspendLayout()
        Me.ckPanel.SuspendLayout()
        Me.ckToolBar.SuspendLayout()
        CType(Me.grdPagos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtResponse
        '
        Me.txtResponse.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtResponse.Font = New System.Drawing.Font("Lucida Console", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtResponse.ForeColor = System.Drawing.Color.Navy
        Me.txtResponse.Location = New System.Drawing.Point(0, 230)
        Me.txtResponse.Multiline = True
        Me.txtResponse.Name = "txtResponse"
        Me.txtResponse.Size = New System.Drawing.Size(942, 285)
        Me.txtResponse.TabIndex = 1
        Me.txtResponse.Text = resources.GetString("txtResponse.Text")
        '
        'pnlPedido
        '
        Me.pnlPedido.Controls.Add(Me.chkVentaNormal)
        Me.pnlPedido.Controls.Add(Me.lblEstatus)
        Me.pnlPedido.Controls.Add(Me.txtPedidoId)
        Me.pnlPedido.Controls.Add(Me.lblPedido)
        Me.pnlPedido.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlPedido.Location = New System.Drawing.Point(0, 31)
        Me.pnlPedido.Name = "pnlPedido"
        Me.pnlPedido.Size = New System.Drawing.Size(942, 34)
        Me.pnlPedido.TabIndex = 2
        '
        'chkVentaNormal
        '
        Me.chkVentaNormal.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkVentaNormal.AutoSize = True
        Me.chkVentaNormal.Checked = True
        Me.chkVentaNormal.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkVentaNormal.Enabled = False
        Me.chkVentaNormal.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkVentaNormal.ForeColor = System.Drawing.Color.Black
        Me.chkVentaNormal.Location = New System.Drawing.Point(346, 1)
        Me.chkVentaNormal.Name = "chkVentaNormal"
        Me.chkVentaNormal.Size = New System.Drawing.Size(126, 29)
        Me.chkVentaNormal.TabIndex = 39
        Me.chkVentaNormal.Text = "VentaNormal"
        Me.chkVentaNormal.UseVisualStyleBackColor = True
        '
        'lblEstatus
        '
        Me.lblEstatus.BackColor = System.Drawing.Color.White
        Me.lblEstatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEstatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblEstatus.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblEstatus.Location = New System.Drawing.Point(172, 7)
        Me.lblEstatus.Name = "lblEstatus"
        Me.lblEstatus.Size = New System.Drawing.Size(92, 20)
        Me.lblEstatus.TabIndex = 2
        Me.lblEstatus.Text = "ESTATUS"
        Me.lblEstatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPedidoId
        '
        Me.txtPedidoId.AutoTab = True
        Me.txtPedidoId.Digits = True
        Me.txtPedidoId.FilterMode = True
        Me.txtPedidoId.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtPedidoId.Highlight = True
        Me.txtPedidoId.HighlightColor = System.Drawing.Color.WhiteSmoke
        Me.txtPedidoId.Location = New System.Drawing.Point(74, 8)
        Me.txtPedidoId.MaxLength = 15
        Me.txtPedidoId.MaxValue = 0R
        Me.txtPedidoId.MinValue = 0R
        Me.txtPedidoId.Name = "txtPedidoId"
        Me.txtPedidoId.SearchColumnsWidth = "80,60,160,60,30"
        Me.txtPedidoId.SelTextOnFocus = True
        Me.txtPedidoId.Size = New System.Drawing.Size(92, 21)
        Me.txtPedidoId.TabIndex = 1
        Me.txtPedidoId.ValidateField = "PedidoId"
        Me.txtPedidoId.ValidateTable = "VT_PEDIDOS"
        '
        'lblPedido
        '
        Me.lblPedido.AutoSize = True
        Me.lblPedido.Location = New System.Drawing.Point(10, 11)
        Me.lblPedido.Name = "lblPedido"
        Me.lblPedido.Size = New System.Drawing.Size(40, 13)
        Me.lblPedido.TabIndex = 0
        Me.lblPedido.Text = "Pedido"
        '
        'ckPanel
        '
        Me.ckPanel.Controls.Add(Me.lblCliente)
        Me.ckPanel.Controls.Add(Me.lblClienteId)
        Me.ckPanel.Controls.Add(Me.txtDispEfe)
        Me.ckPanel.Controls.Add(Me.lblDisponer)
        Me.ckPanel.Controls.Add(Me.lblSUC)
        Me.ckPanel.Controls.Add(Me.lblDescuentoTarjeta)
        Me.ckPanel.Controls.Add(Me.lblDeclinada)
        Me.ckPanel.Controls.Add(Me.lbiTotalPedido)
        Me.ckPanel.Controls.Add(Me.lblTotalPedido)
        Me.ckPanel.Controls.Add(Me.lbiPagosRegistrados)
        Me.ckPanel.Controls.Add(Me.optCredito)
        Me.ckPanel.Controls.Add(Me.optDebito)
        Me.ckPanel.Controls.Add(Me.lblPagosRegistrados)
        Me.ckPanel.Controls.Add(Me.txtImporte)
        Me.ckPanel.Controls.Add(Me.lblMAC)
        Me.ckPanel.Controls.Add(Me.lblCaja)
        Me.ckPanel.Controls.Add(Me.lblTipo)
        Me.ckPanel.Controls.Add(Me.txtTipoTarjeta)
        Me.ckPanel.Controls.Add(Me.txtMaxMeses)
        Me.ckPanel.Controls.Add(Me.lblMaxMeses)
        Me.ckPanel.Controls.Add(Me.txtMinMonto)
        Me.ckPanel.Controls.Add(Me.lblMinMonto)
        Me.ckPanel.Controls.Add(Me.lblAfiliacion)
        Me.ckPanel.Controls.Add(Me.txtAfiliacion)
        Me.ckPanel.Controls.Add(Me.chkMeses)
        Me.ckPanel.Controls.Add(Me.txtAutorizacion)
        Me.ckPanel.Controls.Add(Me.lblAprobacion)
        Me.ckPanel.Controls.Add(Me.txtReferenciaFinanciera)
        Me.ckPanel.Controls.Add(Me.lblReferencia)
        Me.ckPanel.Controls.Add(Me.lblSec)
        Me.ckPanel.Controls.Add(Me.txtSecTxn)
        Me.ckPanel.Controls.Add(Me.txtMeses)
        Me.ckPanel.Controls.Add(Me.lblImporte)
        Me.ckPanel.Controls.Add(Me.txtCVV2)
        Me.ckPanel.Controls.Add(Me.lblCVV2)
        Me.ckPanel.Controls.Add(Me.txtReferenciaComercial)
        Me.ckPanel.Controls.Add(Me.lblReferenciaComercial)
        Me.ckPanel.Controls.Add(Me.txtSesion)
        Me.ckPanel.Controls.Add(Me.lblSesion)
        Me.ckPanel.Controls.Add(Me.txtTerminal)
        Me.ckPanel.Controls.Add(Me.lblTerminal)
        Me.ckPanel.Controls.Add(Me.txtSucursal)
        Me.ckPanel.Controls.Add(Me.lblSucursal)
        Me.ckPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.ckPanel.Location = New System.Drawing.Point(0, 65)
        Me.ckPanel.Name = "ckPanel"
        Me.ckPanel.Size = New System.Drawing.Size(942, 165)
        Me.ckPanel.TabIndex = 3
        '
        'lblCliente
        '
        Me.lblCliente.BackColor = System.Drawing.SystemColors.Control
        Me.lblCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCliente.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCliente.Location = New System.Drawing.Point(832, 35)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(95, 23)
        Me.lblCliente.TabIndex = 43
        Me.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblClienteId
        '
        Me.lblClienteId.AutoSize = True
        Me.lblClienteId.Location = New System.Drawing.Point(735, 39)
        Me.lblClienteId.Name = "lblClienteId"
        Me.lblClienteId.Size = New System.Drawing.Size(48, 13)
        Me.lblClienteId.TabIndex = 42
        Me.lblClienteId.Text = "ClienteId"
        '
        'txtDispEfe
        '
        Me.txtDispEfe.BackColor = System.Drawing.SystemColors.Control
        Me.txtDispEfe.Digits = True
        Me.txtDispEfe.DigitsType = Cklass.Net.DigitsType.Decimals
        Me.txtDispEfe.Enabled = False
        Me.txtDispEfe.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDispEfe.ForeColor = System.Drawing.Color.Blue
        Me.txtDispEfe.HighlightColor = System.Drawing.Color.WhiteSmoke
        Me.txtDispEfe.Location = New System.Drawing.Point(832, 4)
        Me.txtDispEfe.MaxLength = 9
        Me.txtDispEfe.MaxValue = 0R
        Me.txtDispEfe.MinValue = 0R
        Me.txtDispEfe.Name = "txtDispEfe"
        Me.txtDispEfe.ReadOnly = True
        Me.txtDispEfe.Size = New System.Drawing.Size(92, 27)
        Me.txtDispEfe.TabIndex = 41
        Me.txtDispEfe.Text = "0.00"
        Me.txtDispEfe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisponer
        '
        Me.lblDisponer.AutoSize = True
        Me.lblDisponer.Location = New System.Drawing.Point(733, 14)
        Me.lblDisponer.Name = "lblDisponer"
        Me.lblDisponer.Size = New System.Drawing.Size(100, 13)
        Me.lblDisponer.TabIndex = 40
        Me.lblDisponer.Text = "Disponer Efectivo $"
        Me.lblDisponer.Visible = False
        '
        'lblSUC
        '
        Me.lblSUC.AutoSize = True
        Me.lblSUC.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSUC.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblSUC.Location = New System.Drawing.Point(325, 140)
        Me.lblSUC.Name = "lblSUC"
        Me.lblSUC.Size = New System.Drawing.Size(29, 13)
        Me.lblSUC.TabIndex = 39
        Me.lblSUC.Text = "SUC"
        '
        'lblDescuentoTarjeta
        '
        Me.lblDescuentoTarjeta.AutoSize = True
        Me.lblDescuentoTarjeta.BackColor = System.Drawing.Color.Yellow
        Me.lblDescuentoTarjeta.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblDescuentoTarjeta.ForeColor = System.Drawing.Color.Red
        Me.lblDescuentoTarjeta.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDescuentoTarjeta.Location = New System.Drawing.Point(10, 54)
        Me.lblDescuentoTarjeta.Name = "lblDescuentoTarjeta"
        Me.lblDescuentoTarjeta.Size = New System.Drawing.Size(364, 16)
        Me.lblDescuentoTarjeta.TabIndex = 28
        Me.lblDescuentoTarjeta.Text = "DESCUENTO MODIFICADO POR PAGO CON TARJETA"
        Me.lblDescuentoTarjeta.Visible = False
        '
        'lblDeclinada
        '
        Me.lblDeclinada.AutoSize = True
        Me.lblDeclinada.BackColor = System.Drawing.Color.Red
        Me.lblDeclinada.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblDeclinada.ForeColor = System.Drawing.Color.White
        Me.lblDeclinada.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDeclinada.Location = New System.Drawing.Point(587, 55)
        Me.lblDeclinada.Name = "lblDeclinada"
        Me.lblDeclinada.Size = New System.Drawing.Size(144, 16)
        Me.lblDeclinada.TabIndex = 38
        Me.lblDeclinada.Text = "***** DECLINADA *****"
        Me.lblDeclinada.Visible = False
        '
        'lbiTotalPedido
        '
        Me.lbiTotalPedido.BackColor = System.Drawing.SystemColors.Control
        Me.lbiTotalPedido.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbiTotalPedido.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbiTotalPedido.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbiTotalPedido.Location = New System.Drawing.Point(636, 29)
        Me.lbiTotalPedido.Name = "lbiTotalPedido"
        Me.lbiTotalPedido.Size = New System.Drawing.Size(95, 23)
        Me.lbiTotalPedido.TabIndex = 33
        Me.lbiTotalPedido.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalPedido
        '
        Me.lblTotalPedido.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTotalPedido.Location = New System.Drawing.Point(500, 35)
        Me.lblTotalPedido.Name = "lblTotalPedido"
        Me.lblTotalPedido.Size = New System.Drawing.Size(130, 17)
        Me.lblTotalPedido.TabIndex = 32
        Me.lblTotalPedido.Text = "Total del pedido"
        Me.lblTotalPedido.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbiPagosRegistrados
        '
        Me.lbiPagosRegistrados.BackColor = System.Drawing.SystemColors.Control
        Me.lbiPagosRegistrados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbiPagosRegistrados.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbiPagosRegistrados.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbiPagosRegistrados.Location = New System.Drawing.Point(636, 4)
        Me.lbiPagosRegistrados.Name = "lbiPagosRegistrados"
        Me.lbiPagosRegistrados.Size = New System.Drawing.Size(95, 23)
        Me.lbiPagosRegistrados.TabIndex = 31
        Me.lbiPagosRegistrados.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'optCredito
        '
        Me.optCredito.AutoSize = True
        Me.optCredito.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optCredito.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.optCredito.Location = New System.Drawing.Point(324, 28)
        Me.optCredito.Name = "optCredito"
        Me.optCredito.Size = New System.Drawing.Size(175, 23)
        Me.optCredito.TabIndex = 5
        Me.optCredito.Text = "Tarjeta de crédito"
        Me.optCredito.UseVisualStyleBackColor = True
        '
        'optDebito
        '
        Me.optDebito.AutoSize = True
        Me.optDebito.Checked = True
        Me.optDebito.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optDebito.ForeColor = System.Drawing.Color.Green
        Me.optDebito.Location = New System.Drawing.Point(324, 1)
        Me.optDebito.Name = "optDebito"
        Me.optDebito.Size = New System.Drawing.Size(170, 23)
        Me.optDebito.TabIndex = 4
        Me.optDebito.TabStop = True
        Me.optDebito.Text = "Tarjeta de débito"
        Me.optDebito.UseVisualStyleBackColor = True
        '
        'lblPagosRegistrados
        '
        Me.lblPagosRegistrados.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPagosRegistrados.Location = New System.Drawing.Point(500, 10)
        Me.lblPagosRegistrados.Name = "lblPagosRegistrados"
        Me.lblPagosRegistrados.Size = New System.Drawing.Size(130, 17)
        Me.lblPagosRegistrados.TabIndex = 30
        Me.lblPagosRegistrados.Text = "Total pagos registrados"
        Me.lblPagosRegistrados.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtImporte
        '
        Me.txtImporte.BackColor = System.Drawing.SystemColors.Control
        Me.txtImporte.Digits = True
        Me.txtImporte.DigitsType = Cklass.Net.DigitsType.Decimals
        Me.txtImporte.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporte.ForeColor = System.Drawing.Color.Blue
        Me.txtImporte.HighlightColor = System.Drawing.Color.WhiteSmoke
        Me.txtImporte.Location = New System.Drawing.Point(74, 1)
        Me.txtImporte.MaxLength = 9
        Me.txtImporte.MaxValue = 0R
        Me.txtImporte.MinValue = 0R
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.ReadOnly = True
        Me.txtImporte.Size = New System.Drawing.Size(92, 27)
        Me.txtImporte.TabIndex = 3
        Me.txtImporte.Text = "0.00"
        Me.txtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblMAC
        '
        Me.lblMAC.AutoSize = True
        Me.lblMAC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMAC.Location = New System.Drawing.Point(200, 139)
        Me.lblMAC.Name = "lblMAC"
        Me.lblMAC.Size = New System.Drawing.Size(32, 13)
        Me.lblMAC.TabIndex = 37
        Me.lblMAC.Text = "MAC"
        '
        'lblCaja
        '
        Me.lblCaja.AutoSize = True
        Me.lblCaja.Location = New System.Drawing.Point(150, 139)
        Me.lblCaja.Name = "lblCaja"
        Me.lblCaja.Size = New System.Drawing.Size(28, 13)
        Me.lblCaja.TabIndex = 36
        Me.lblCaja.Text = "Caja"
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Location = New System.Drawing.Point(10, 35)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(28, 13)
        Me.lblTipo.TabIndex = 6
        Me.lblTipo.Text = "Tipo"
        '
        'txtTipoTarjeta
        '
        Me.txtTipoTarjeta.Enabled = False
        Me.txtTipoTarjeta.Location = New System.Drawing.Point(60, 32)
        Me.txtTipoTarjeta.MaxLength = 16
        Me.txtTipoTarjeta.Name = "txtTipoTarjeta"
        Me.txtTipoTarjeta.ReadOnly = True
        Me.txtTipoTarjeta.Size = New System.Drawing.Size(63, 20)
        Me.txtTipoTarjeta.TabIndex = 7
        Me.txtTipoTarjeta.TabStop = False
        Me.txtTipoTarjeta.Text = "DEBITO"
        '
        'txtMaxMeses
        '
        Me.txtMaxMeses.Location = New System.Drawing.Point(462, 108)
        Me.txtMaxMeses.MaxLength = 4
        Me.txtMaxMeses.Name = "txtMaxMeses"
        Me.txtMaxMeses.ReadOnly = True
        Me.txtMaxMeses.Size = New System.Drawing.Size(68, 20)
        Me.txtMaxMeses.TabIndex = 27
        Me.txtMaxMeses.TabStop = False
        '
        'lblMaxMeses
        '
        Me.lblMaxMeses.AutoSize = True
        Me.lblMaxMeses.Location = New System.Drawing.Point(398, 111)
        Me.lblMaxMeses.Name = "lblMaxMeses"
        Me.lblMaxMeses.Size = New System.Drawing.Size(61, 13)
        Me.lblMaxMeses.TabIndex = 26
        Me.lblMaxMeses.Text = "Max Meses"
        '
        'txtMinMonto
        '
        Me.txtMinMonto.Location = New System.Drawing.Point(462, 80)
        Me.txtMinMonto.MaxLength = 4
        Me.txtMinMonto.Name = "txtMinMonto"
        Me.txtMinMonto.ReadOnly = True
        Me.txtMinMonto.Size = New System.Drawing.Size(68, 20)
        Me.txtMinMonto.TabIndex = 25
        Me.txtMinMonto.TabStop = False
        '
        'lblMinMonto
        '
        Me.lblMinMonto.AutoSize = True
        Me.lblMinMonto.Location = New System.Drawing.Point(398, 83)
        Me.lblMinMonto.Name = "lblMinMonto"
        Me.lblMinMonto.Size = New System.Drawing.Size(57, 13)
        Me.lblMinMonto.TabIndex = 24
        Me.lblMinMonto.Text = "Min Monto"
        '
        'lblAfiliacion
        '
        Me.lblAfiliacion.AutoSize = True
        Me.lblAfiliacion.Location = New System.Drawing.Point(150, 83)
        Me.lblAfiliacion.Name = "lblAfiliacion"
        Me.lblAfiliacion.Size = New System.Drawing.Size(49, 13)
        Me.lblAfiliacion.TabIndex = 16
        Me.lblAfiliacion.Text = "Afiliación"
        '
        'txtAfiliacion
        '
        Me.txtAfiliacion.Location = New System.Drawing.Point(203, 80)
        Me.txtAfiliacion.MaxLength = 4
        Me.txtAfiliacion.Name = "txtAfiliacion"
        Me.txtAfiliacion.ReadOnly = True
        Me.txtAfiliacion.Size = New System.Drawing.Size(68, 20)
        Me.txtAfiliacion.TabIndex = 17
        Me.txtAfiliacion.TabStop = False
        '
        'chkMeses
        '
        Me.chkMeses.AutoSize = True
        Me.chkMeses.Location = New System.Drawing.Point(145, 34)
        Me.chkMeses.Name = "chkMeses"
        Me.chkMeses.Size = New System.Drawing.Size(118, 17)
        Me.chkMeses.TabIndex = 8
        Me.chkMeses.TabStop = False
        Me.chkMeses.Text = "&Meses sin intereses"
        Me.chkMeses.UseVisualStyleBackColor = True
        '
        'txtAutorizacion
        '
        Me.txtAutorizacion.Location = New System.Drawing.Point(68, 80)
        Me.txtAutorizacion.MaxLength = 8
        Me.txtAutorizacion.Name = "txtAutorizacion"
        Me.txtAutorizacion.ReadOnly = True
        Me.txtAutorizacion.Size = New System.Drawing.Size(68, 20)
        Me.txtAutorizacion.TabIndex = 11
        Me.txtAutorizacion.TabStop = False
        '
        'lblAprobacion
        '
        Me.lblAprobacion.AutoSize = True
        Me.lblAprobacion.Location = New System.Drawing.Point(4, 83)
        Me.lblAprobacion.Name = "lblAprobacion"
        Me.lblAprobacion.Size = New System.Drawing.Size(61, 13)
        Me.lblAprobacion.TabIndex = 10
        Me.lblAprobacion.Text = "Aprobación"
        '
        'txtReferenciaFinanciera
        '
        Me.txtReferenciaFinanciera.Location = New System.Drawing.Point(68, 108)
        Me.txtReferenciaFinanciera.MaxLength = 30
        Me.txtReferenciaFinanciera.Name = "txtReferenciaFinanciera"
        Me.txtReferenciaFinanciera.ReadOnly = True
        Me.txtReferenciaFinanciera.Size = New System.Drawing.Size(68, 20)
        Me.txtReferenciaFinanciera.TabIndex = 13
        Me.txtReferenciaFinanciera.TabStop = False
        '
        'lblReferencia
        '
        Me.lblReferencia.AutoSize = True
        Me.lblReferencia.Location = New System.Drawing.Point(4, 111)
        Me.lblReferencia.Name = "lblReferencia"
        Me.lblReferencia.Size = New System.Drawing.Size(59, 13)
        Me.lblReferencia.TabIndex = 12
        Me.lblReferencia.Text = "Referencia"
        '
        'lblSec
        '
        Me.lblSec.AutoSize = True
        Me.lblSec.Location = New System.Drawing.Point(277, 111)
        Me.lblSec.Name = "lblSec"
        Me.lblSec.Size = New System.Drawing.Size(47, 13)
        Me.lblSec.TabIndex = 14
        Me.lblSec.Text = "Sec Txn"
        '
        'txtSecTxn
        '
        Me.txtSecTxn.Location = New System.Drawing.Point(328, 108)
        Me.txtSecTxn.MaxLength = 4
        Me.txtSecTxn.Name = "txtSecTxn"
        Me.txtSecTxn.ReadOnly = True
        Me.txtSecTxn.Size = New System.Drawing.Size(68, 20)
        Me.txtSecTxn.TabIndex = 15
        Me.txtSecTxn.TabStop = False
        '
        'txtMeses
        '
        Me.txtMeses.Location = New System.Drawing.Point(270, 31)
        Me.txtMeses.MaxLength = 2
        Me.txtMeses.Name = "txtMeses"
        Me.txtMeses.ReadOnly = True
        Me.txtMeses.Size = New System.Drawing.Size(32, 20)
        Me.txtMeses.TabIndex = 9
        Me.txtMeses.TabStop = False
        '
        'lblImporte
        '
        Me.lblImporte.AutoSize = True
        Me.lblImporte.Location = New System.Drawing.Point(10, 8)
        Me.lblImporte.Name = "lblImporte"
        Me.lblImporte.Size = New System.Drawing.Size(51, 13)
        Me.lblImporte.TabIndex = 2
        Me.lblImporte.Text = "Importe $"
        '
        'txtCVV2
        '
        Me.txtCVV2.BackColor = System.Drawing.SystemColors.Info
        Me.txtCVV2.Enabled = False
        Me.txtCVV2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCVV2.Location = New System.Drawing.Point(68, 132)
        Me.txtCVV2.MaxLength = 3
        Me.txtCVV2.Name = "txtCVV2"
        Me.txtCVV2.ReadOnly = True
        Me.txtCVV2.Size = New System.Drawing.Size(68, 27)
        Me.txtCVV2.TabIndex = 1
        Me.txtCVV2.Visible = False
        '
        'lblCVV2
        '
        Me.lblCVV2.AutoSize = True
        Me.lblCVV2.Location = New System.Drawing.Point(18, 139)
        Me.lblCVV2.Name = "lblCVV2"
        Me.lblCVV2.Size = New System.Drawing.Size(48, 13)
        Me.lblCVV2.TabIndex = 0
        Me.lblCVV2.Text = "Cod Seg"
        Me.lblCVV2.Visible = False
        '
        'txtReferenciaComercial
        '
        Me.txtReferenciaComercial.Location = New System.Drawing.Point(599, 80)
        Me.txtReferenciaComercial.MaxLength = 45
        Me.txtReferenciaComercial.Name = "txtReferenciaComercial"
        Me.txtReferenciaComercial.ReadOnly = True
        Me.txtReferenciaComercial.Size = New System.Drawing.Size(95, 20)
        Me.txtReferenciaComercial.TabIndex = 35
        Me.txtReferenciaComercial.TabStop = False
        '
        'lblReferenciaComercial
        '
        Me.lblReferenciaComercial.AutoSize = True
        Me.lblReferenciaComercial.Location = New System.Drawing.Point(536, 83)
        Me.lblReferenciaComercial.Name = "lblReferenciaComercial"
        Me.lblReferenciaComercial.Size = New System.Drawing.Size(48, 13)
        Me.lblReferenciaComercial.TabIndex = 34
        Me.lblReferenciaComercial.Text = "Ref Com"
        '
        'txtSesion
        '
        Me.txtSesion.Location = New System.Drawing.Point(328, 80)
        Me.txtSesion.MaxLength = 4
        Me.txtSesion.Name = "txtSesion"
        Me.txtSesion.ReadOnly = True
        Me.txtSesion.Size = New System.Drawing.Size(68, 20)
        Me.txtSesion.TabIndex = 23
        Me.txtSesion.TabStop = False
        '
        'lblSesion
        '
        Me.lblSesion.AutoSize = True
        Me.lblSesion.Location = New System.Drawing.Point(277, 83)
        Me.lblSesion.Name = "lblSesion"
        Me.lblSesion.Size = New System.Drawing.Size(39, 13)
        Me.lblSesion.TabIndex = 22
        Me.lblSesion.Text = "Sesión"
        '
        'txtTerminal
        '
        Me.txtTerminal.Location = New System.Drawing.Point(599, 108)
        Me.txtTerminal.MaxLength = 4
        Me.txtTerminal.Name = "txtTerminal"
        Me.txtTerminal.ReadOnly = True
        Me.txtTerminal.Size = New System.Drawing.Size(95, 20)
        Me.txtTerminal.TabIndex = 21
        Me.txtTerminal.TabStop = False
        '
        'lblTerminal
        '
        Me.lblTerminal.AutoSize = True
        Me.lblTerminal.Location = New System.Drawing.Point(537, 111)
        Me.lblTerminal.Name = "lblTerminal"
        Me.lblTerminal.Size = New System.Drawing.Size(47, 13)
        Me.lblTerminal.TabIndex = 20
        Me.lblTerminal.Text = "Terminal"
        '
        'txtSucursal
        '
        Me.txtSucursal.Location = New System.Drawing.Point(203, 108)
        Me.txtSucursal.MaxLength = 4
        Me.txtSucursal.Name = "txtSucursal"
        Me.txtSucursal.ReadOnly = True
        Me.txtSucursal.Size = New System.Drawing.Size(68, 20)
        Me.txtSucursal.TabIndex = 19
        Me.txtSucursal.TabStop = False
        '
        'lblSucursal
        '
        Me.lblSucursal.AutoSize = True
        Me.lblSucursal.Location = New System.Drawing.Point(150, 111)
        Me.lblSucursal.Name = "lblSucursal"
        Me.lblSucursal.Size = New System.Drawing.Size(48, 13)
        Me.lblSucursal.TabIndex = 18
        Me.lblSucursal.Text = "Sucursal"
        '
        'ckToolBar
        '
        Me.ckToolBar.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ckToolBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnProcesar, Me.btnSupervisor, Me.btnCerrar, Me.btnImprimir, Me.cmbImpresora, Me.btnNuevo, Me.txtPuntos, Me.btnCargarLlaves, Me.btnSettings, Me.btnReimprimir, Me.btnRequest, Me.btnResponse, Me.btnRetiro})
        Me.ckToolBar.Location = New System.Drawing.Point(0, 0)
        Me.ckToolBar.Name = "ckToolBar"
        Me.ckToolBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ckToolBar.Size = New System.Drawing.Size(942, 31)
        Me.ckToolBar.TabIndex = 5
        '
        'btnProcesar
        '
        Me.btnProcesar.Image = CType(resources.GetObject("btnProcesar.Image"), System.Drawing.Image)
        Me.btnProcesar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(109, 28)
        Me.btnProcesar.Text = "Procesar (F10)"
        '
        'btnSupervisor
        '
        Me.btnSupervisor.Image = CType(resources.GetObject("btnSupervisor.Image"), System.Drawing.Image)
        Me.btnSupervisor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSupervisor.Name = "btnSupervisor"
        Me.btnSupervisor.Size = New System.Drawing.Size(90, 28)
        Me.btnSupervisor.Text = "&Supervisor"
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Image)
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(67, 28)
        Me.btnCerrar.Text = "&Cerrar"
        '
        'btnImprimir
        '
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(81, 28)
        Me.btnImprimir.Text = "&Imprimir"
        '
        'cmbImpresora
        '
        Me.cmbImpresora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbImpresora.DropDownWidth = 200
        Me.cmbImpresora.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbImpresora.Name = "cmbImpresora"
        Me.cmbImpresora.Size = New System.Drawing.Size(230, 31)
        '
        'btnNuevo
        '
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(93, 28)
        Me.btnNuevo.Text = "Nuevo (F6)"
        '
        'txtPuntos
        '
        Me.txtPuntos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.txtPuntos.Name = "txtPuntos"
        Me.txtPuntos.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always
        Me.txtPuntos.Size = New System.Drawing.Size(102, 19)
        Me.txtPuntos.Text = "Consultar Puntos"
        '
        'btnCargarLlaves
        '
        Me.btnCargarLlaves.Image = CType(resources.GetObject("btnCargarLlaves.Image"), System.Drawing.Image)
        Me.btnCargarLlaves.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCargarLlaves.Name = "btnCargarLlaves"
        Me.btnCargarLlaves.Size = New System.Drawing.Size(102, 28)
        Me.btnCargarLlaves.Text = "CargarLlaves"
        '
        'btnSettings
        '
        Me.btnSettings.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(87, 28)
        Me.btnSettings.Text = "Configuración"
        Me.btnSettings.Visible = False
        '
        'btnReimprimir
        '
        Me.btnReimprimir.AutoToolTip = False
        Me.btnReimprimir.Enabled = False
        Me.btnReimprimir.Image = CType(resources.GetObject("btnReimprimir.Image"), System.Drawing.Image)
        Me.btnReimprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnReimprimir.Name = "btnReimprimir"
        Me.btnReimprimir.Size = New System.Drawing.Size(96, 28)
        Me.btnReimprimir.Text = "re-imprimir"
        Me.btnReimprimir.ToolTipText = "reimprime la ultima operación aprobada"
        Me.btnReimprimir.Visible = False
        '
        'btnRequest
        '
        Me.btnRequest.Enabled = False
        Me.btnRequest.Image = CType(resources.GetObject("btnRequest.Image"), System.Drawing.Image)
        Me.btnRequest.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRequest.Name = "btnRequest"
        Me.btnRequest.Size = New System.Drawing.Size(74, 28)
        Me.btnRequest.Text = "request"
        Me.btnRequest.Visible = False
        '
        'btnResponse
        '
        Me.btnResponse.Enabled = False
        Me.btnResponse.Image = CType(resources.GetObject("btnResponse.Image"), System.Drawing.Image)
        Me.btnResponse.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnResponse.Name = "btnResponse"
        Me.btnResponse.Size = New System.Drawing.Size(82, 28)
        Me.btnResponse.Text = "response"
        Me.btnResponse.Visible = False
        '
        'btnRetiro
        '
        Me.btnRetiro.Image = CType(resources.GetObject("btnRetiro.Image"), System.Drawing.Image)
        Me.btnRetiro.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRetiro.Name = "btnRetiro"
        Me.btnRetiro.Size = New System.Drawing.Size(105, 28)
        Me.btnRetiro.Text = "Disp-Efectivo"
        Me.btnRetiro.Visible = False
        '
        'grdPagos
        '
        Me.grdPagos.AllowUpdate = False
        Me.grdPagos.AlternatingRows = True
        Me.grdPagos.Caption = "SELECCIONE UN PAGO PARA CANCELAR"
        Me.grdPagos.DirectionAfterEnter = C1.Win.C1TrueDBGrid.DirectionAfterEnterEnum.MoveNone
        Me.grdPagos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grdPagos.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdPagos.Images.Add(CType(resources.GetObject("grdPagos.Images"), System.Drawing.Image))
        Me.grdPagos.Location = New System.Drawing.Point(0, 515)
        Me.grdPagos.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRowRaiseCell
        Me.grdPagos.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.grdPagos.Name = "grdPagos"
        Me.grdPagos.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdPagos.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdPagos.PreviewInfo.ZoomFactor = 75.0R
        Me.grdPagos.PrintInfo.PageSettings = CType(resources.GetObject("grdPagos.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdPagos.Size = New System.Drawing.Size(942, 93)
        Me.grdPagos.TabIndex = 6
        Me.grdPagos.Visible = False
        Me.grdPagos.PropBag = resources.GetString("grdPagos.PropBag")
        '
        'frmPinPad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(942, 608)
        Me.Controls.Add(Me.txtResponse)
        Me.Controls.Add(Me.ckPanel)
        Me.Controls.Add(Me.pnlPedido)
        Me.Controls.Add(Me.ckToolBar)
        Me.Controls.Add(Me.grdPagos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPinPad"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PinPad Bancomer TotalPOS Verifone .NET FW4 Basic 64 v.1"
        Me.pnlPedido.ResumeLayout(False)
        Me.pnlPedido.PerformLayout()
        Me.ckPanel.ResumeLayout(False)
        Me.ckPanel.PerformLayout()
        Me.ckToolBar.ResumeLayout(False)
        Me.ckToolBar.PerformLayout()
        CType(Me.grdPagos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtResponse As System.Windows.Forms.TextBox
    Friend WithEvents pnlPedido As System.Windows.Forms.Panel
    Friend WithEvents chkVentaNormal As System.Windows.Forms.CheckBox
    Friend WithEvents lblEstatus As System.Windows.Forms.Label
    Friend WithEvents txtPedidoId As Cklass.Net.ckTextBox
    Friend WithEvents lblPedido As System.Windows.Forms.Label
    Friend WithEvents ckPanel As System.Windows.Forms.Panel
    Friend WithEvents lblDescuentoTarjeta As System.Windows.Forms.Label
    Friend WithEvents lblDeclinada As System.Windows.Forms.Label
    Friend WithEvents lbiTotalPedido As System.Windows.Forms.Label
    Friend WithEvents lblTotalPedido As System.Windows.Forms.Label
    Friend WithEvents lbiPagosRegistrados As System.Windows.Forms.Label
    Friend WithEvents lblPagosRegistrados As System.Windows.Forms.Label
    Friend WithEvents txtImporte As Cklass.Net.ckTextBox
    Friend WithEvents lblMAC As System.Windows.Forms.Label
    Friend WithEvents lblCaja As System.Windows.Forms.Label
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Public WithEvents txtTipoTarjeta As System.Windows.Forms.TextBox
    Public WithEvents txtMaxMeses As System.Windows.Forms.TextBox
    Friend WithEvents lblMaxMeses As System.Windows.Forms.Label
    Public WithEvents txtMinMonto As System.Windows.Forms.TextBox
    Friend WithEvents lblMinMonto As System.Windows.Forms.Label
    Friend WithEvents lblAfiliacion As System.Windows.Forms.Label
    Public WithEvents txtAfiliacion As System.Windows.Forms.TextBox
    Public WithEvents chkMeses As System.Windows.Forms.CheckBox
    Public WithEvents txtAutorizacion As System.Windows.Forms.TextBox
    Friend WithEvents lblAprobacion As System.Windows.Forms.Label
    Public WithEvents txtReferenciaFinanciera As System.Windows.Forms.TextBox
    Friend WithEvents lblReferencia As System.Windows.Forms.Label
    Friend WithEvents lblSec As System.Windows.Forms.Label
    Public WithEvents txtSecTxn As System.Windows.Forms.TextBox
    Public WithEvents txtMeses As System.Windows.Forms.TextBox
    Friend WithEvents lblImporte As System.Windows.Forms.Label
    Public WithEvents txtCVV2 As System.Windows.Forms.TextBox
    Friend WithEvents lblCVV2 As System.Windows.Forms.Label
    Public WithEvents txtReferenciaComercial As System.Windows.Forms.TextBox
    Friend WithEvents lblReferenciaComercial As System.Windows.Forms.Label
    Public WithEvents txtSesion As System.Windows.Forms.TextBox
    Friend WithEvents lblSesion As System.Windows.Forms.Label
    Public WithEvents txtTerminal As System.Windows.Forms.TextBox
    Friend WithEvents lblTerminal As System.Windows.Forms.Label
    Public WithEvents txtSucursal As System.Windows.Forms.TextBox
    Friend WithEvents lblSucursal As System.Windows.Forms.Label
    Friend WithEvents ckToolBar As System.Windows.Forms.ToolStrip
    Friend WithEvents btnProcesar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSupervisor As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmbImpresora As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCargarLlaves As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnReimprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnRequest As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnResponse As System.Windows.Forms.ToolStripButton
    Friend WithEvents grdPagos As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents lblSUC As System.Windows.Forms.Label
    Friend WithEvents txtDispEfe As Cklass.Net.ckTextBox
    Friend WithEvents lblDisponer As System.Windows.Forms.Label
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents lblClienteId As System.Windows.Forms.Label
    Public WithEvents optCredito As RadioButton
    Public WithEvents optDebito As RadioButton
    Friend WithEvents btnSettings As ToolStripButton
    Friend WithEvents txtPuntos As ToolStripButton
    Friend WithEvents btnRetiro As ToolStripButton
End Class
