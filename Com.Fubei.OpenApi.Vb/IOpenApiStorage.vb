Imports Castle.Components.DictionaryAdapter
Imports Com.Illuminati.Galileo.Foundation


' OpenApi存储接口
Public Interface IOpenApiStorage
    <Key("openapi_host")>
    Property OpenApiHost As String
End Interface


Public Class OpenApiStorage
    Private Shared ReadOnly GalileoConfiguration As GalileoConfiguration = New GalileoConfiguration()

    Public Shared ReadOnly Property Instance As IOpenApiStorage
        Get
            Return GalileoConfiguration.GetConfiguration(Of IOpenApiStorage)()
        End Get
    End Property

    Public Shared Function GetConfiguration(Of T)() As T
        Return GalileoConfiguration.GetConfiguration(Of T)()
    End Function
End Class

