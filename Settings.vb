Imports System.Xml
Imports EGlobal.TotalPosSDKNet.Interfaz.Authorizer
Imports EGlobal.TotalPosSDKNet.Interfaz

Public Class Settings
    Private _sOperatorId As String = "OPE001"
    Private _sClaveLogs As String = ""
    Private _sPinPadConexion As String = ""
    Private _sPinPadTimeOut As String = ""
    Private _sPinPadPuertoWiFi As String = ""
    Private _sPinPadMensaje As String = ""
    Private _sClaveBinesExcepcion As String = ""
    Private _sHostUrl As String = ""
    Private _sBinesUrl As String = ""
    Private _sTokenUrl As String = ""
    Private _sUpdateUrl As String = ""
    Private _sHostTimeOut As String = ""
    Private _sComercioAfiliacion As String = ""
    Private _sComercioTerminal As String = ""
    Private _sComercioMac As String = ""
    Private _sIdAplicacion As String = ""
    Private _sClaveSecreta As String = ""
    Private _bLogs As Boolean = False
    Private _bContactless As Boolean = False
    Private _bGaranti As Boolean = False
    Private _bMoto As Boolean = False
    Private _bCanDigit As Boolean = False

    Public Property Operador As String
        Get
            Return _sOperatorId
        End Get
        Set(ByVal value As String)
            _sOperatorId = value
        End Set
    End Property

    Public Property ClaveLogs As String
        Get
            Return _sClaveLogs
        End Get
        Set(ByVal value As String)
            _sClaveLogs = value
        End Set
    End Property

    Public Property PinPadConexion As String
        Get
            Return _sPinPadConexion
        End Get
        Set(ByVal value As String)
            _sPinPadConexion = value
        End Set
    End Property

    Public Property PinPadTimeOut As String
        Get
            Return _sPinPadTimeOut
        End Get
        Set(ByVal value As String)
            _sPinPadTimeOut = value
        End Set
    End Property

    Public Property PinPadPuertoWiFi As String
        Get
            Return _sPinPadPuertoWiFi
        End Get
        Set(ByVal value As String)
            _sPinPadPuertoWiFi = value
        End Set
    End Property

    Public Property PinPadMensaje As String
        Get
            Return _sPinPadMensaje
        End Get
        Set(ByVal value As String)
            _sPinPadMensaje = value
        End Set
    End Property

    Public Property ClaveBinesExcepcion As String
        Get
            Return _sClaveBinesExcepcion
        End Get
        Set(ByVal value As String)
            _sClaveBinesExcepcion = value
        End Set
    End Property

    Public Property HostUrl As String
        Get
            Return _sHostUrl
        End Get
        Set(ByVal value As String)
            _sHostUrl = value
        End Set
    End Property

    Public Property BinesUrl As String
        Get
            Return _sBinesUrl
        End Get
        Set(ByVal value As String)
            _sBinesUrl = value
        End Set
    End Property

    Public Property TokenUrl As String
        Get
            Return _sTokenUrl
        End Get
        Set(ByVal value As String)
            _sTokenUrl = value
        End Set
    End Property

    Public Property TelecargaUrl As String
        Get
            Return _sUpdateUrl
        End Get
        Set(ByVal value As String)
            _sUpdateUrl = value
        End Set
    End Property

    Public Property HostTimeOut As String
        Get
            Return _sHostTimeOut
        End Get
        Set(ByVal value As String)
            _sHostTimeOut = value
        End Set
    End Property

    Public Property ComercioAfiliacion As String
        Get
            Return _sComercioAfiliacion
        End Get
        Set(ByVal value As String)
            _sComercioAfiliacion = value
        End Set
    End Property

    Public Property ComercioTerminal As String
        Get
            Return _sComercioTerminal
        End Get
        Set(ByVal value As String)
            _sComercioTerminal = value
        End Set
    End Property

    Public Property ComercioMac As String
        Get
            Return _sComercioMac
        End Get
        Set(ByVal value As String)
            _sComercioMac = value
        End Set
    End Property

    Public Property IdAplicacion As String
        Get
            Return _sIdAplicacion
        End Get
        Set(ByVal value As String)
            _sIdAplicacion = value
        End Set
    End Property

    Public Property ClaveSecreta As String
        Get
            Return _sClaveSecreta
        End Get
        Set(ByVal value As String)
            _sClaveSecreta = value
        End Set
    End Property

    Public Property Logs As Boolean
        Get
            Return _bLogs
        End Get
        Set(ByVal value As Boolean)
            _bLogs = value
        End Set
    End Property

    Public Property PinPadContactless As Boolean
        Get
            Return _bContactless
        End Get
        Set(ByVal value As Boolean)
            _bContactless = value
        End Set
    End Property

    Public Property FuncionalidadGaranti As Boolean
        Get
            Return _bGaranti
        End Get
        Set(ByVal value As Boolean)
            _bGaranti = value
        End Set
    End Property

    Public Property FuncionalidadMoto As Boolean
        Get
            Return _bMoto
        End Get
        Set(ByVal value As Boolean)
            _bMoto = value
        End Set
    End Property

    Public Property TecladoLiberado As Boolean
        Get
            Return _bCanDigit
        End Get
        Set(ByVal value As Boolean)
            _bCanDigit = value
        End Set
    End Property


    Public Sub LoadSettings()
        Dim xmldoc As New XmlDataDocument()
        Try
            xmldoc.Load("C:\Local.config")
            _sOperatorId = "OPE001"
            _bLogs = xmldoc.SelectSingleNode("/configuracion/interfaz/logs/@value").Value = "1"
            _sClaveLogs = xmldoc.SelectSingleNode("/configuracion/interfaz/clavelogs/@value").Value
            _sPinPadConexion = xmldoc.SelectSingleNode("/configuracion/interfaz/pinpadconexion/@value").Value
            _sPinPadTimeOut = xmldoc.SelectSingleNode("/configuracion/interfaz/pinpadtimeout/@value").Value
            _sPinPadPuertoWiFi = xmldoc.SelectSingleNode("/configuracion/interfaz/pinpadpuertowifi/@value").Value
            _sPinPadMensaje = xmldoc.SelectSingleNode("/configuracion/interfaz/pinpadmensaje/@value").Value
            _bContactless = xmldoc.SelectSingleNode("/configuracion/interfaz/contactless/@value").Value = "1"
            _sClaveBinesExcepcion = xmldoc.SelectSingleNode("/configuracion/interfaz/clavebinesexcepcion/@value").Value
            _sHostUrl = xmldoc.SelectSingleNode("/configuracion/interfaz/hosturl/@value").Value
            _sBinesUrl = xmldoc.SelectSingleNode("/configuracion/interfaz/binesurl/@value").Value
            _sTokenUrl = xmldoc.SelectSingleNode("/configuracion/interfaz/tokenurl/@value").Value
            _sUpdateUrl = xmldoc.SelectSingleNode("/configuracion/interfaz/update/@value").Value
            _sHostTimeOut = xmldoc.SelectSingleNode("/configuracion/interfaz/hosttimeout/@value").Value
            _bGaranti = xmldoc.SelectSingleNode("/configuracion/interfaz/funcionalidadgaranti/@value").Value = "1"
            _bMoto = xmldoc.SelectSingleNode("/configuracion/interfaz/funcionalidadmoto/@value").Value = "1"
            _bCanDigit = xmldoc.SelectSingleNode("/configuracion/interfaz/tecladoliberado/@value").Value = "1"
            _sComercioAfiliacion = xmldoc.SelectSingleNode("/configuracion/interfaz/comercioafiliacion/@value").Value
            _sComercioTerminal = xmldoc.SelectSingleNode("/configuracion/interfaz/comercioterminal/@value").Value
            _sComercioMac = xmldoc.SelectSingleNode("/configuracion/interfaz/comerciomac/@value").Value
            _sIdAplicacion = xmldoc.SelectSingleNode("/configuracion/interfaz/idaplicacion/@value").Value
            _sClaveSecreta = xmldoc.SelectSingleNode("/configuracion/interfaz/clavesecreta/@value").Value
        Catch ex As Exception
            Throw New Exception("Error al cargar la configuración: " + ex.Message)
        End Try
    End Sub


    Public Sub LoadSettingsWithConfig()
        Dim config = New Util.Configuracion
        Dim xmldoc As New XmlDataDocument()
        Try
            xmldoc.Load("C:\Local.config")
            _sOperatorId = "OPE001"
            _bLogs = xmldoc.SelectSingleNode("/configuracion/interfaz/logs/@value").Value = "1"
            _sClaveLogs = xmldoc.SelectSingleNode("/configuracion/interfaz/clavelogs/@value").Value
            _sPinPadConexion = xmldoc.SelectSingleNode("/configuracion/interfaz/pinpadconexion/@value").Value
            _sPinPadTimeOut = xmldoc.SelectSingleNode("/configuracion/interfaz/pinpadtimeout/@value").Value
            _sPinPadPuertoWiFi = xmldoc.SelectSingleNode("/configuracion/interfaz/pinpadpuertowifi/@value").Value
            _sPinPadMensaje = xmldoc.SelectSingleNode("/configuracion/interfaz/pinpadmensaje/@value").Value
            _bContactless = xmldoc.SelectSingleNode("/configuracion/interfaz/contactless/@value").Value = "1"
            _sClaveBinesExcepcion = xmldoc.SelectSingleNode("/configuracion/interfaz/clavebinesexcepcion/@value").Value
            _sHostUrl = xmldoc.SelectSingleNode("/configuracion/interfaz/hosturl/@value").Value
            _sBinesUrl = xmldoc.SelectSingleNode("/configuracion/interfaz/binesurl/@value").Value
            _sTokenUrl = xmldoc.SelectSingleNode("/configuracion/interfaz/tokenurl/@value").Value
            _sUpdateUrl = xmldoc.SelectSingleNode("/configuracion/interfaz/update/@value").Value
            _sHostTimeOut = xmldoc.SelectSingleNode("/configuracion/interfaz/hosttimeout/@value").Value
            _bGaranti = xmldoc.SelectSingleNode("/configuracion/interfaz/funcionalidadgaranti/@value").Value = "1"
            _bMoto = xmldoc.SelectSingleNode("/configuracion/interfaz/funcionalidadmoto/@value").Value = "1"
            _bCanDigit = xmldoc.SelectSingleNode("/configuracion/interfaz/tecladoliberado/@value").Value = "1"
            _sComercioAfiliacion = xmldoc.SelectSingleNode("/configuracion/interfaz/comercioafiliacion/@value").Value
            _sComercioTerminal = xmldoc.SelectSingleNode("/configuracion/interfaz/comercioterminal/@value").Value
            _sComercioMac = xmldoc.SelectSingleNode("/configuracion/interfaz/comerciomac/@value").Value
            _sIdAplicacion = xmldoc.SelectSingleNode("/configuracion/interfaz/idaplicacion/@value").Value
            _sClaveSecreta = xmldoc.SelectSingleNode("/configuracion/interfaz/clavesecreta/@value").Value
            config.Logs = Logs
            config.ClaveLogs = ClaveLogs
            config.PinPadConexion = PinPadConexion
            config.PinPadTimeOut = PinPadTimeOut
            config.PinPadPuerto = PinPadPuertoWiFi
            config.PinPadMensaje = PinPadMensaje
            config.PinPadContactless = PinPadContactless
            config.ClaveBines = ClaveBinesExcepcion
            config.HostUrl = HostUrl
            config.BinesUrl = BinesUrl
            config.TokenUrl = TokenUrl
            config.TelecargaUrl = TelecargaUrl
            config.HostTimeOut = HostTimeOut
            config.FuncionalidadGaranti = FuncionalidadGaranti
            config.FuncionalidadMoto = FuncionalidadMoto
            config.TecladoLiberado = TecladoLiberado
            config.ComercioAfiliacion = ComercioAfiliacion
            config.ComercioTerminal = ComercioTerminal
            config.ComercioMac = ComercioMac
            config.IdAplicacion = IdAplicacion
            config.ClaveSecreta = ClaveSecreta
            Interfaz.Instance.Configuracion = config
            Interfaz.Instance.Inicializar()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub


    Public Sub SaveSettings()
        Dim xmldoc As New XmlDataDocument()
        Try
            xmldoc.Load("C:\Local.config")
            _sOperatorId = "OPE001"
            xmldoc.SelectSingleNode("/configuracion/interfaz/logs/@value").Value = IIf(_bLogs, "1", "0")
            xmldoc.SelectSingleNode("/configuracion/interfaz/clavelogs/@value").Value = _sClaveLogs
            xmldoc.SelectSingleNode("/configuracion/interfaz/pinpadconexion/@value").Value = _sPinPadConexion
            xmldoc.SelectSingleNode("/configuracion/interfaz/pinpadtimeout/@value").Value = _sPinPadTimeOut
            xmldoc.SelectSingleNode("/configuracion/interfaz/pinpadpuertowifi/@value").Value = _sPinPadPuertoWiFi
            xmldoc.SelectSingleNode("/configuracion/interfaz/pinpadmensaje/@value").Value = _sPinPadMensaje
            xmldoc.SelectSingleNode("/configuracion/interfaz/contactless/@value").Value = IIf(_bContactless, "1", "0")
            xmldoc.SelectSingleNode("/configuracion/interfaz/clavebinesexcepcion/@value").Value = _sClaveBinesExcepcion
            xmldoc.SelectSingleNode("/configuracion/interfaz/hosturl/@value").Value = _sHostUrl
            xmldoc.SelectSingleNode("/configuracion/interfaz/binesurl/@value").Value = _sBinesUrl
            xmldoc.SelectSingleNode("/configuracion/interfaz/tokenurl/@value").Value = _sTokenUrl
            xmldoc.SelectSingleNode("/configuracion/interfaz/update/@value").Value = _sUpdateUrl
            xmldoc.SelectSingleNode("/configuracion/interfaz/hosttimeout/@value").Value = _sHostTimeOut
            xmldoc.SelectSingleNode("/configuracion/interfaz/funcionalidadgaranti/@value").Value = IIf(_bGaranti, "1", "0")
            xmldoc.SelectSingleNode("/configuracion/interfaz/funcionalidadmoto/@value").Value = IIf(_bMoto, "1", "0")
            xmldoc.SelectSingleNode("/configuracion/interfaz/tecladoliberado/@value").Value = IIf(_bCanDigit, "1", "0")
            xmldoc.SelectSingleNode("/configuracion/interfaz/comercioafiliacion/@value").Value = _sComercioAfiliacion
            xmldoc.SelectSingleNode("/configuracion/interfaz/comercioterminal/@value").Value = _sComercioTerminal
            xmldoc.SelectSingleNode("/configuracion/interfaz/comerciomac/@value").Value = _sComercioMac
            xmldoc.SelectSingleNode("/configuracion/interfaz/idaplicacion/@value").Value = _sIdAplicacion
            xmldoc.SelectSingleNode("/configuracion/interfaz/clavesecreta/@value").Value = _sClaveSecreta
            xmldoc.Save("C:\Local.config")
        Catch ex As Exception
            Throw New Exception("Error al cargar la configuración: " + ex.Message)
        End Try
    End Sub


End Class
