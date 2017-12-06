Public Class clsCatalog
    Private strCatalogID As String
    Private intYear As Integer
    Private strQuarter As String
    Private strCourseID As String
    Private strProfID As String

    Public Property catalogID As String
        Get
            Return strCatalogID
        End Get
        Set(value As String)
            strCatalogID = value
        End Set
    End Property

    Public Property year As Integer
        Get
            Return intYear
        End Get
        Set(value As Integer)
            intYear = value
        End Set
    End Property

    Public Property quarter As String
        Get
            Return strQuarter
        End Get
        Set(value As String)
            strQuarter = value
        End Set
    End Property
    Public Property courseID As String
        Get
            Return strCourseID
        End Get
        Set(value As String)
            strCourseID = value
        End Set
    End Property
    Public Property profID As String
        Get
            Return strProfID
        End Get
        Set(value As String)
            strProfID = value
        End Set
    End Property
End Class