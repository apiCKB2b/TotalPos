<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRetiro
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRetiro))
        Me.lblMontoMx = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnNo = New System.Windows.Forms.Button()
        Me.lblLeyenda2 = New System.Windows.Forms.Label()
        Me.txtMonto = New Cklass.Net.ckTextBox()
        Me.lblLeyenda = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblMontoMx
        '
        Me.lblMontoMx.AutoSize = True
        Me.lblMontoMx.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMontoMx.Location = New System.Drawing.Point(114, 80)
        Me.lblMontoMx.Name = "lblMontoMx"
        Me.lblMontoMx.Size = New System.Drawing.Size(62, 16)
        Me.lblMontoMx.TabIndex = 10
        Me.lblMontoMx.Text = "MontoMx"
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(61, 133)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 35)
        Me.btnAceptar.TabIndex = 9
        Me.btnAceptar.Text = "Si"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnNo
        '
        Me.btnNo.Image = CType(resources.GetObject("btnNo.Image"), System.Drawing.Image)
        Me.btnNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNo.Location = New System.Drawing.Point(152, 133)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.Size = New System.Drawing.Size(75, 35)
        Me.btnNo.TabIndex = 6
        Me.btnNo.Text = "No"
        Me.btnNo.UseVisualStyleBackColor = True
        '
        'lblLeyenda2
        '
        Me.lblLeyenda2.AutoSize = True
        Me.lblLeyenda2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLeyenda2.Location = New System.Drawing.Point(44, 54)
        Me.lblLeyenda2.Name = "lblLeyenda2"
        Me.lblLeyenda2.Size = New System.Drawing.Size(214, 20)
        Me.lblLeyenda2.TabIndex = 7
        Me.lblLeyenda2.Text = "Monto MAXIMO A RETIRAR"
        '
        'txtMonto
        '
        Me.txtMonto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMonto.Digits = True
        Me.txtMonto.Highlight = True
        Me.txtMonto.HighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtMonto.Location = New System.Drawing.Point(112, 103)
        Me.txtMonto.MaxLength = 4
        Me.txtMonto.MaxValue = 0R
        Me.txtMonto.MinValue = 0R
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(64, 20)
        Me.txtMonto.TabIndex = 8
        Me.txtMonto.Text = "0"
        Me.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLeyenda
        '
        Me.lblLeyenda.AutoSize = True
        Me.lblLeyenda.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLeyenda.Location = New System.Drawing.Point(12, 21)
        Me.lblLeyenda.Name = "lblLeyenda"
        Me.lblLeyenda.Size = New System.Drawing.Size(276, 29)
        Me.lblLeyenda.TabIndex = 5
        Me.lblLeyenda.Text = "¿Desea Retirar Efectivo?"
        '
        'frmRetiro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(300, 190)
        Me.Controls.Add(Me.lblMontoMx)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnNo)
        Me.Controls.Add(Me.lblLeyenda2)
        Me.Controls.Add(Me.txtMonto)
        Me.Controls.Add(Me.lblLeyenda)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRetiro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Disposición de Efectivo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblMontoMx As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnNo As System.Windows.Forms.Button
    Friend WithEvents lblLeyenda2 As System.Windows.Forms.Label
    Friend WithEvents txtMonto As Cklass.Net.ckTextBox
    Friend WithEvents lblLeyenda As System.Windows.Forms.Label
End Class
