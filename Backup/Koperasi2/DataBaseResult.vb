Public MustInherit Class DataBaseResult

    Public _TotalRecord As Int32

    Protected Sub New()

        TotalRecord = 0

    End Sub



    Public Property TotalRecord() As Int32
        Get
            Return _TotalRecord
        End Get
        Set(ByVal value As Int32)
            _TotalRecord = value
        End Set
    End Property

End Class