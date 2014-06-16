Imports System.Collections.Generic



Public NotInheritable Class DataResult(Of T As Class)
    Inherits DataBaseResult
    Public _Records As List(Of T)



    Public Sub New()

        Records = New List(Of T)()

    End Sub



    Public Property Records() As List(Of T)
        Get
            Return _Records
        End Get
        Set(ByVal value As List(Of T))
            _Records = value
        End Set
    End Property

End Class