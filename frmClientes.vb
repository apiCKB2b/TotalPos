Imports Cklass.Net

Public Class frmClientes

    Dim ckSuc As New ckSucursal.CklassSucursal()
    Dim ckDatos As New ckData(ckSuc.SucCnnStr)
    Public ClienteId As String = ""
    Public Importe_Retirar As Double = 0

    Private Sub CargarClientes()
        Try
            Dim tbl As New DataTable()
            Dim sql As String = "SELECT ClienteId, Nombre FROM CL_CLIENTES"

            tbl = ckDatos.TablaSQL(sql)

            grd.SetDataBinding(tbl, "", True)
            grd.Refresh()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarClientes()
    End Sub

    Private Sub DisponerEfectivo()
        Dim frm As New frmRetiro()
        frm.ClienteId = ClienteId
        frm.ShowDialog()
        Importe_Retirar = frm.Importe_Retirar
        Me.Close()
    End Sub

    Private Sub grd_KeyDown(sender As Object, e As KeyEventArgs) Handles grd.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                ClienteId = grd.Columns("ClienteId").Text.ToString()
                DisponerEfectivo()
        End Select
    End Sub
End Class