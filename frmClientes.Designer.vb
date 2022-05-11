<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClientes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmClientes))
        Me.grd = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        CType(Me.grd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grd
        '
        Me.grd.AllowUpdate = False
        Me.grd.AlternatingRows = True
        Me.grd.CaptionHeight = 17
        Me.grd.DirectionAfterEnter = C1.Win.C1TrueDBGrid.DirectionAfterEnterEnum.MoveNone
        Me.grd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd.EmptyRows = True
        Me.grd.FilterBar = True
        Me.grd.GroupByCaption = "Drag a column header here to group by that column"
        Me.grd.Images.Add(CType(resources.GetObject("grd.Images"), System.Drawing.Image))
        Me.grd.Location = New System.Drawing.Point(0, 0)
        Me.grd.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRowRaiseCell
        Me.grd.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.grd.Name = "grd"
        Me.grd.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grd.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grd.PreviewInfo.ZoomFactor = 75.0R
        Me.grd.PrintInfo.PageSettings = CType(resources.GetObject("grdPagos.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grd.RowHeight = 15
        Me.grd.Size = New System.Drawing.Size(352, 275)
        Me.grd.TabIndex = 7
        Me.grd.PropBag = resources.GetString("grd.PropBag")
        '
        'frmClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(352, 275)
        Me.Controls.Add(Me.grd)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmClientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clientes"
        CType(Me.grd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grd As C1.Win.C1TrueDBGrid.C1TrueDBGrid
End Class
