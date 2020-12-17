Imports Com.Illuminati.Galileo
Imports Com.Illuminati.Galileo.Attr

Namespace Biz.V2

    Public Class AgentApiAttribute
        Inherits PostApiAttribute

        Public Sub New()
            Path = "/gateway/agent"
            Category = GalileoApiConfig.Category.AgentApi
        End Sub
    End Class
End Namespace
