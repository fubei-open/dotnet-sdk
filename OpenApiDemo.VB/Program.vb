﻿Imports Com.Illuminati.Galileo
Imports Com.Illuminati.Galileo.Foundation
Imports System.Net
Imports System.Threading
Imports Com.Fubei.Api.OpenApi.Biz
Imports Com.Fubei.Api.OpenApi.Biz.V1.Model.Request
Imports Com.Fubei.Api.OpenApi.Biz.V2.Model.Request

Class Program
    ' 商户维度
    Public Const MerchantApiAppId As String = ""
    Public Const MerchantAppSecret As String = ""
    Public Const StoreId As Integer = 0

    ' 代理商维度调用必须指定MerchantId和StoreId
    Public Const AgentVendorSn As String = ""
    Public Const AgentVendorSecret As String = ""
    Public Const AStoreId As Integer = StoreId
    Public Const AMerchantId As Integer = 0

    ' 当使用开放平台2.0接口时，是否使用代理商维度来调用
    ' 配置为false则使用商户维护调用
    Private Const IsAgent As Boolean = False

    Public Shared Sub Main(ByVal args As String())
        ' 初始化网络库
        InitGalileo()

        ' 创建定额码
        'CreateFixedQrcode()

        ' 订单支付(开放平台2.0接口)
        AOrderPay()

        ' 订单支付(开放平台1.0接口)
        Console.ReadLine()
    End Sub

    ' 2020-12-01 新增，开放平台2.0 支付接口
    Private Shared Sub AOrderPay()
        ' MerchantId这个字段，如果是商户级别调用，则可不传
        Dim param = New AOrderPayParam With {
            .MerchantOrderSn = $"{DateTime.Now}000000001",
            .StoreId = StoreId,
            .MerchantId = AMerchantId,
            .TotalAmount = 0.01D,
            .AuthCode = "134778135788159462"
        }

        Try
            Dim response = FubeiOpenApiFactory.AgentApi.OrderPay(param)
            Console.WriteLine($"付款码支付结果: {response.ToJson()}")
            ' 订单状态：USERPAYING需要继续查询订单状态
            Dim tradeState = response.OrderStatus
            ' 重试次数，请根据实际情况来查询，这里只是一个查询
            Dim retryCount = 30

            ' 当订单状态是USERPAYING
            While Equals("USERPAYING", tradeState) AndAlso retryCount > 0
                retryCount -= 1
                Dim queryResponse = FubeiOpenApiFactory.AgentApi.OrderQuery(New AOrderQueryParam With {
                    .MerchantId = AMerchantId,
                    .MerchantOrderSn = response.MerchantOrderSn
                })
                tradeState = queryResponse.OrderStatus
                Console.WriteLine($"付款码支付结果: {queryResponse}")
                ' 等待1秒钟后重新查询
                Thread.Sleep(TimeSpan.FromSeconds(1))
            End While

        Catch ex As Exception
            Console.WriteLine($"请求失败: {ex}")
        End Try
    End Sub

    ' 创建定额二维码
    Private Shared Sub CreateFixedQrcode()
        ' 代理商级别调用为必填参数，商户级别调用为非必填参数
        ' SubAppId必填
        Dim param = New ACreateFixedQrCodeParam With {
            .StoreId = StoreId,
            .MerchantOrderSn = $"{DateTime.Now}000000001",
            .TotalAmount = 0.1D,
            .SubAppId = "",
            .ExpiredTime = 600
        }

        Try
            Dim resp = FubeiOpenApiFactory.AgentApi.CreateFixedQrcode(param)

            If resp Is Nothing Then
                Console.WriteLine($"\n\n定额码创建失败！！！\n\n")
                Return
            End If

            Console.WriteLine($"\n\n定额码：{resp.QrcodeUrl}, 订单号：{resp.MerchantOrderSn}\n\n")
        Catch ex As Exception
            Console.WriteLine($"请求失败: {ex}")
        End Try
    End Sub

    ' 付款码支付接口
    Private Shared Sub OrderPay()

        ' Type 支付方式[微信1/支付宝2/银联5]
        Dim orderPayParam = New OrderPayParam With {
            .MerchantOrderSn = $"{DateTime.Now}000000001",
            .StoreId = StoreId,
            .TotalFee = 0.01D,
            .Type = 1,
            .AuthCode = "134666401897986717"
        }

        Try
            Dim response = FubeiOpenApiFactory.MerchantApi.OrderSwipe(orderPayParam)
            Console.WriteLine($"付款码支付结果: {response.ToJson()}")
            Dim tradeState = response.TradeState
            Dim retryCount = 30

            ' 订单状态：USERPAYING需要继续查询订单状态
            While Equals("USERPAYING", tradeState) AndAlso retryCount > 0
                retryCount -= 1
                Dim respOrderState = FubeiOpenApiFactory.MerchantApi.OrderQuery(New OrderQueryParam With {
                    .MerchantOrderSn = response.MerchantOrderSn
                })
                tradeState = respOrderState.TradeState
                Console.WriteLine($"付款码支付结果: {respOrderState.ToJson()}")
                Thread.Sleep(TimeSpan.FromSeconds(1))
            End While

        Catch ex As Exception
            Console.WriteLine($"请求失败: {ex}")
        End Try
    End Sub

    ' 扫码支付接口
    Public Shared Sub OrderScan()
        Dim orderScanParam = New OrderScanParam With {
            .MerchantOrderSn = $"{DateTime.Now}000000001",
            .StoreId = StoreId,
            .TotalFee = 0.01D,
            .Type = 1
        }

        Try
            Dim response = FubeiOpenApiFactory.MerchantApi.OrderScan(orderScanParam)
            Console.WriteLine($"请求成功: {response.ToJson()}")
            Console.WriteLine()
            Console.WriteLine()
            Console.WriteLine($"用于微信支付的定额二维码：{response.QrCode}")
            Console.WriteLine()
            Console.WriteLine()
        Catch ex As Exception
            Console.WriteLine($"请求失败: {ex}")
        End Try
    End Sub

    ' 初始化网络库，在这里输入AppId和AppSecret
    Private Shared Sub InitGalileo()
        GalileoApiConfig.Instance.Register(New GalileoApiConfig.ApiConfig With {
            .AppId = MerchantApiAppId,
            .AppSecret = MerchantAppSecret
        }, GalileoApiConfig.Category.MerchantApi)

        If IsAgent Then
            GalileoApiConfig.Instance.Register(New GalileoApiConfig.ApiConfig With {
                .AppId = "",
                .AppSecret = "",
                .VendorSn = AgentVendorSn,
                .VendorSecret = AgentVendorSecret
            }, GalileoApiConfig.Category.AgentApi)
        Else
            GalileoApiConfig.Instance.Register(New GalileoApiConfig.ApiConfig With {
                .AppId = MerchantApiAppId,
                .AppSecret = MerchantAppSecret,
                .VendorSn = "",
                .VendorSecret = ""
            }, GalileoApiConfig.Category.AgentApi)
        End If

        ' ***可选*** 设置付呗开放平台接口地址,如果是XP系统，需要启用这行
        'OpenApiStorage.Instance.OpenApiHost = "http://shq-api.51fubei.com"

        ' 忽略http错误
        ServicePointManager.ServerCertificateValidationCallback = Function(sender, certificate, chain, sslPolicyErrors) True

        ' 接管日志输出
        AddHandler GalileoLogger.Instance.Logger, Function(level, log)
                                                      Select Case level
                                                          Case GalileoLogger.Level.Trace, GalileoLogger.Level.Debug
                                                              Console.WriteLine($"DEBUG: {log}")
                                                          Case GalileoLogger.Level.Info
                                                              Console.WriteLine($"INFO: {log}")
                                                          Case GalileoLogger.Level.Warn
                                                              Console.WriteLine($"WARN: {log}")
                                                          Case GalileoLogger.Level.[Error]
                                                              Console.WriteLine($"Error: {log}")
                                                          Case GalileoLogger.Level.Fatal
                                                              Console.WriteLine($"Fatal: {log}")
                                                      End Select
                                                  End Function

        ' **********可选*********定义TraceId生成规则，（如不定义则按照默认规则生成）
        Dim n = 0
        GalileoApiConfig.Instance.GenerateTraceId = Function() $"{DateTime.Now}_{System.Threading.Interlocked.Increment(n)}"
    End Sub
End Class