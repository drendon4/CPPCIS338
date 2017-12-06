Public Class clsCourse
    Private strCourseID As String
    Private strDescription As String
    Private intUnits As String

    Public Property courseID As String
        Get
            Return strCourseID
        End Get
        Set(value As String)
            strCourseID = value
        End Set
    End Property

    Public Property description As String
        Get
            Return strDescription
        End Get
        Set(value As String)
            strDescription = value
        End Set
    End Property

    Public Property units As String
        Get
            Return intUnits
        End Get
        Set(value As String)
            intUnits = value
        End Set
    End Property
End Class