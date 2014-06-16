Imports System.Data



Public NotInheritable Class DataTableResult

    Inherits DataBaseResult
    Public _Records As DataTable


    Public Sub New()

        Records = New DataTable()

    End Sub



    Public Property Records() As DataTable
        Get
            Return _Records
        End Get
        Set(ByVal value As DataTable)
            _Records = value
        End Set
    End Property

End Class
