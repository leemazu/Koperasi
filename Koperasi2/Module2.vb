Module Module2
    Public Const TrialDate As String = ""
    Public Const InitApplUserID = "admin"
    Public Const InitApplUserName = "Administrator"
    Public Const InitApplUserPass = "abcd"

    Private _UserAuth As String
    Private _ApplUserLv As Int16

    Private _StrSQL As String
    Private _isDoubleLogin As Boolean


    Public Property UserAuth() As String
        Get
            Return _UserAuth
        End Get
        Set(ByVal value As String)
            _UserAuth = value
        End Set
    End Property
    Public Property ApplUserlv() As Int16
        Get
            Return _ApplUserLv
        End Get
        Set(ByVal value As Int16)
            _ApplUserLv = value
        End Set
    End Property


    Public Property isDoubleLogin() As Boolean
        Get
            Return _isDoubleLogin
        End Get
        Set(ByVal value As Boolean)
            _isDoubleLogin = True
        End Set
    End Property

    Public Sub viewReport(ByVal crv As CrystalDecisions.Windows.Forms.CrystalReportViewer, ByVal tableName As String, ByVal rFileName As String, ByVal paramFields As CrystalDecisions.Shared.ParameterFields)
        Dim logonInfo As New CrystalDecisions.Shared.TableLogOnInfo
        Dim logonInfos As New CrystalDecisions.Shared.TableLogOnInfos

        logonInfo.TableName = tableName
        logonInfo.ConnectionInfo.ServerName() = "(local)\SQLEXPRESS"
        logonInfo.ConnectionInfo.Password() = "asdf"
        logonInfo.ConnectionInfo.UserID = "sa"
        logonInfo.ConnectionInfo.DatabaseName = "tempReport"
        logonInfos.Add(logonInfo)

        crv.LogOnInfo = logonInfos
        crv.ParameterFieldInfo = paramFields
        crv.ReportSource = Application.StartupPath & "\" & rFileName & ".rpt"
        crv.Zoom(1)
    End Sub

    Public Function addParamField(ByVal fieldName As String, ByVal value As String) As CrystalDecisions.Shared.ParameterField
        Dim paramField As New CrystalDecisions.Shared.ParameterField
        Dim paramDiscreteVal As New CrystalDecisions.Shared.ParameterDiscreteValue

        paramField.ParameterFieldName = fieldName
        paramDiscreteVal.Value = value
        paramField.CurrentValues.Add(paramDiscreteVal)

        Return paramField
    End Function
End Module
