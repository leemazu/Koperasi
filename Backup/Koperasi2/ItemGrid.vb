Public NotInheritable Class ItemGrid

    Public _Id As Guid
    Public _ItemString As String
    Public _ItemInt32 As Int32
    Public _ItemBoolean As Boolean
    Public _ItemDecimal As Decimal
    Public _ItemDateTime As DateTime
  


    Public Property Id() As Guid
        Get
            Return _Id
        End Get
        Set(ByVal value As Guid)
            _Id = value
        End Set
    End Property



    Public Property ItemString() As [String]
        Get
            Return _ItemString
        End Get
        Set(ByVal value As [String])
            _ItemString = value
        End Set



    End Property
    Public Property ItemInt32() As Int32
        Get
            Return _ItemInt32
        End Get
        Set(ByVal value As Int32)
            _ItemInt32 = value
        End Set




    End Property
    Public Property ItemBoolean() As [Boolean]
        Get
            Return _ItemBoolean
        End Get
        Set(ByVal value As [Boolean])
            _ItemBoolean = value
        End Set



    End Property
    Public Property ItemDecimal() As [Decimal]
        Get

        End Get
        Set(ByVal value As [Decimal])

        End Set



    End Property
    Public Property ItemDateTime() As DateTime
        Get
            Return ItemDateTime
        End Get
        Set(ByVal value As DateTime)

        End Set
    End Property

End Class