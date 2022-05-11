Imports EGlobal.TotalPosSDKNet.Interfaz.Authorizer
Imports EGlobal.TotalPosSDKNet.Interfaz.Exceptions
Imports EGlobal.TotalPosSDKNet.Interfaz

Public Class Configuracion
    Private Sub FrmSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim settings = New Settings()
        settings.LoadSettings()
        Me.chkLogs.Checked = settings.Logs
        Me.txtLogsKey.Text = settings.ClaveLogs
        Me.txtPinPadConexion.Text = settings.PinPadConexion
        Me.txtPinPadTimeOut.Text = settings.PinPadTimeOut
        Me.txtPinPadPuertoWiFi.Text = settings.PinPadPuertoWiFi
        Me.txtPinPadMensaje.Text = settings.PinPadMensaje
        Me.chkContactless.Checked = settings.PinPadContactless
        Me.txtBinesExcepcion.Text = settings.ClaveBinesExcepcion
        Me.txtHostUrl.Text = settings.HostUrl
        Me.txtBinesUrl.Text = settings.BinesUrl
        Me.txtTokenUrl.Text = settings.TokenUrl
        Me.txtUpdateUrl.Text = settings.TelecargaUrl
        Me.txtHostTimeOut.Text = settings.HostTimeOut
        Me.chkGaranti.Checked = settings.FuncionalidadGaranti
        Me.chkMoto.Checked = settings.FuncionalidadMoto
        Me.chkCanDigit.Checked = settings.TecladoLiberado
        Me.txtComercioAfiliacion.Text = settings.ComercioAfiliacion
        Me.txtComercioTerminal.Text = settings.ComercioTerminal
        Me.txtComercioMac.Text = settings.ComercioMac
        Me.txtIdAplicacion.Text = settings.IdAplicacion
        Me.txtClaveSecreta.Text = settings.ClaveSecreta
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim config = New Util.Configuracion
        Dim settings = New Settings()
        Try
            settings.Logs = Me.chkLogs.Checked
            settings.ClaveLogs = Me.txtLogsKey.Text
            settings.PinPadConexion = Me.txtPinPadConexion.Text
            settings.PinPadTimeOut = Me.txtPinPadTimeOut.Text
            settings.PinPadPuertoWiFi = Me.txtPinPadPuertoWiFi.Text
            settings.PinPadMensaje = Me.txtPinPadMensaje.Text
            settings.PinPadContactless = Me.chkContactless.Checked
            settings.ClaveBinesExcepcion = Me.txtBinesExcepcion.Text
            settings.HostUrl = Me.txtHostUrl.Text
            settings.BinesUrl = Me.txtBinesUrl.Text
            settings.TokenUrl = Me.txtTokenUrl.Text
            settings.TelecargaUrl = Me.txtUpdateUrl.Text
            settings.HostTimeOut = Me.txtHostTimeOut.Text
            settings.FuncionalidadGaranti = Me.chkGaranti.Checked
            settings.FuncionalidadMoto = Me.chkMoto.Checked
            settings.TecladoLiberado = Me.chkCanDigit.Checked
            settings.ComercioAfiliacion = Me.txtComercioAfiliacion.Text
            settings.ComercioTerminal = Me.txtComercioTerminal.Text
            settings.ComercioMac = Me.txtComercioMac.Text
            settings.IdAplicacion = Me.txtIdAplicacion.Text
            settings.ClaveSecreta = Me.txtClaveSecreta.Text
            settings.SaveSettings()
            config.Logs = settings.Logs
            config.ClaveLogs = settings.ClaveLogs
            config.PinPadConexion = settings.PinPadConexion
            config.PinPadTimeOut = settings.PinPadTimeOut
            config.PinPadPuerto = settings.PinPadPuertoWiFi
            config.PinPadMensaje = settings.PinPadMensaje
            config.PinPadContactless = settings.PinPadContactless
            config.ClaveBines = settings.ClaveBinesExcepcion
            config.HostUrl = settings.HostUrl
            config.BinesUrl = settings.BinesUrl
            config.TokenUrl = settings.TokenUrl
            config.TelecargaUrl = settings.TelecargaUrl
            config.HostTimeOut = settings.HostTimeOut
            config.FuncionalidadGaranti = settings.FuncionalidadGaranti
            config.FuncionalidadMoto = settings.FuncionalidadMoto
            config.TecladoLiberado = settings.TecladoLiberado
            config.ComercioAfiliacion = settings.ComercioAfiliacion
            config.ComercioTerminal = settings.ComercioTerminal
            config.ComercioMac = settings.ComercioMac
            config.IdAplicacion = settings.IdAplicacion
            config.ClaveSecreta = settings.ClaveSecreta
            Interfaz.Instance.Configuracion = config
            Interfaz.Instance.Inicializar()
            Dim msgResponse As Integer
            msgResponse = MessageBox.Show("Se guardó la configuración con éxito.",
                                   "Informacion",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Exclamation)
            If msgResponse = vbOK Then
                Me.Dispose()
            End If
            'MessageBox.Show("Se guardó la configuración con éxito.", "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch exPetition As PeticionException
            MessageBox.Show("Error en petición: " + exPetition.Message, "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error al guardar: " + ex.Message, "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

End Class