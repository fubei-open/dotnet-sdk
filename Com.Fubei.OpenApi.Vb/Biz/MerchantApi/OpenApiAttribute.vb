Imports Com.Illuminati.Galileo
Imports Com.Illuminati.Galileo.Attr

Namespace Biz.V1
    Public Class MerchantApiAttribute 
        Inherits PostApiAttribute

        Public Sub New()
            Path = "/gateway"
            Category = GalileoApiConfig.Category.MerchantApi
        End Sub
    End Class
End Namespace
