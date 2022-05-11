Imports Cklass.Net

Public Class frmRetiro

    Public Importe_Retirar As Double = 0
    Dim Importe_Maximo As Double = 0
    Public ClienteId As String = ""

    Dim ckSuc As New ckSucursal.CklassSucursal()
    Dim ckDatos As New ckData(ckSuc.SucCnnStr)

    'Obtiene el importe maximo a retirar
    Private Function fxObtenerMonto() As Double
        Dim result As Double = 0

        Dim sql As String = "SELECT User09 FROM VT_CAJA WHERE Tipo = 'V' and HOST = '" & ckNet.Terminal & "'"
        result = CDbl(ckDatos.ValorSQL(sql))
        result = result - 300

        If result < 0 Then
            result = 0
        ElseIf result > 2000 Then
            result = 2000
        End If

        Return result
    End Function


    Private Sub txtMonto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMonto.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If CDbl(Me.txtMonto.Text) > Importe_Maximo Then
                    ckNet.MsgErr("No puede retirar más de lo permitido $" & CStr(Importe_Maximo) & " o el monto ingresa es mayor de $2,000 MXN")
                    Me.txtMonto.Text = Importe_Maximo.ToString()
                    Me.txtMonto.Focus()
                    Me.txtMonto.SelectAll()
                Else
                    Importe_Retirar = CDbl(Me.txtMonto.Text)
                End If

        End Select
    End Sub

    Private Sub btnNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNo.Click
        Importe_Retirar = 0
        Me.Close()
    End Sub


    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Importe_Retirar = CDbl(Me.txtMonto.Text.Trim)
        Me.Close()
    End Sub

    Private Sub frmRetiro_Load(sender As Object, e As EventArgs) Handles Me.Load
        Importe_Maximo = fxObtenerMonto()
        Me.txtMonto.Text = CStr(Importe_Maximo)
        Me.lblMontoMx.Text = "$ " & CStr(Importe_Maximo) & " MXN"
    End Sub
End Class