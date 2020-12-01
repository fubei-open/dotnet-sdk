using Com.Illuminati.Galileo;
using Com.Illuminati.Galileo.Biz;
using Com.Illuminati.Galileo.Biz.MerchantApi.Model.Request;
using Com.Illuminati.Galileo.Foundation;
using System;
using System.Net;
using System.Threading;
using Com.Fubei.Api.OpenApi.Biz.AgentApi.Model.Request;
using Com.Fubei.Api.OpenApi.Biz.MerchantApi.Model.Request;

namespace OpenApiDemo
{
    class Program
    {
        // 商户维度
        public const string MerchantApiAppId = "20170607085534749364";
        public const string MerchantAppSecret = "1809d9615714ab8fdc90d0d838a0f2e1";
        public const int StoreId = 145827;

        // 代理商维度，如果是商户维护调用（使用AppId和AppSecret）则可不配置
        public const string AgentVendorSn = "2018113015321682303a";
        public const string AgentVendorSecret = "1b2da5600e53fde3c657a2652839b84e";
        // 代理商维度调用必须指定MerchantId和StoreId
        public const int AStoreId = StoreId;
        public const int AMerchantId = 189160;

        // 当使用开放平台2.0接口时，是否使用代理商维度来调用
        private const bool IsAgent = false;


        static void Main(string[] args)
        {
            // 初始化客户端网络库，和OpenApi相关的参数
            InitGalileo();

            // 开放平台2.0付呗码
            //AOrderPay();
            
            // 创建聚合码
            CreateFixedQrcode();

            //// 定额码
            //OrderScan();

            //// 开放平台1.0支付
            //OrderPay();

            Console.ReadLine();
        }

        /// <summary>
        /// 2020-12-01 新增，开放平台2.0 支付接口
        /// </summary>
        private static void AOrderPay()
        {
            var param = new AOrderPayParam
            {
                MerchantOrderSn = $"{DateTime.Now:yyyyMMddHHmmss}000000001",
                StoreId = StoreId,
                // 这个字段，如果是商户级别调用，则可不传
                MerchantId = AMerchantId,
                TotalAmount = 0.01m,
                AuthCode = "134779556436361053"
            };
            try
            {
                var response = FubeiOpenApiFactory.AgentApi.OrderPay(param);
                Console.WriteLine($"付款码支付结果: {response.ToJson()}");

                // 订单状态：USERPAYING需要继续查询订单状态
                var tradeState = response.OrderStatus;
                // 重试次数，请根据实际情况进行
                var retryCount = 30;
                // 当订单状态是USERPAYING
                while (Equals("USERPAYING", tradeState) && retryCount > 0)
                {
                    --retryCount;
                    var queryResponse = FubeiOpenApiFactory.AgentApi.OrderQuery(new AOrderQueryParam
                    {
                        // 这个字段，如果是商户级别调用，则可不传
                        MerchantId = AMerchantId,
                        MerchantOrderSn = response.MerchantOrderSn
                    });
                    tradeState = queryResponse.OrderStatus;
                    Console.WriteLine($"付款码支付结果: {queryResponse}");
                    // 等待1秒钟后重新查询
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"请求失败: {ex}");
            }
        }

        private static void CreateFixedQrcode()
        {
            var param = new ACreateFixedQrCodeParam
            {
                // 代理商级别调用为必填参数，商户级别调用为非必填参数
                //MerchantId = AMerchantId,
                StoreId = StoreId,
                MerchantOrderSn = $"{DateTime.Now:yyyyMMddHHmmss}000000001",
                TotalAmount = 0.1m,
                // TODO: 必须填入SubAppId
                SubAppId = "",
                // 二维码超时时间
                ExpiredTime = 600
            };
            try
            {
                var resp = FubeiOpenApiFactory.AgentApi.CreateFixedQrcode(param);
                if (resp == null)
                {
                    Console.WriteLine($"\n\n定额码创建失败！！！\n\n");
                    return;
                }
                Console.WriteLine($"\n\n定额码：{resp.QrcodeUrl}, 订单号：{resp.MerchantOrderSn}\n\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"请求失败: {ex}");
            }
        }

        /// <summary>
        /// 付款码支付接口
        /// </summary>
        private static void OrderPay()
        {
            var orderPayParam = new OrderPayParam
            {
                MerchantOrderSn = $"{DateTime.Now:yyyyMMddHHmmss}000000001",
                StoreId = StoreId,
                TotalFee = 0.01m,
                // 支付方式[微信1/支付宝2/银联5]
                Type = 1,
                AuthCode = "134666401897986717"
            };
            try
            {
                var response = FubeiOpenApiFactory.MerchantApi.OrderSwipe(orderPayParam);
                Console.WriteLine($"付款码支付结果: {response.ToJson()}");

                // 订单状态：USERPAYING需要继续查询订单状态
                var tradeState = response.TradeState;
                // 重试次数，请根据实际情况进行
                var retryCount = 30;
                // 当订单状态是USERPAYING
                while (Equals("USERPAYING", tradeState) && retryCount > 0)
                {
                    --retryCount;
                    var respOrderState = FubeiOpenApiFactory.MerchantApi.OrderQuery(new OrderQueryParam
                    {
                        MerchantOrderSn = response.MerchantOrderSn
                    });
                    tradeState = respOrderState.TradeState;
                    Console.WriteLine($"付款码支付结果: {respOrderState.ToJson()}");
                    // 等待1秒钟后重新查询
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"请求失败: {ex}");
            }
        }

        /// <summary>
        /// 扫码支付接口
        /// </summary>
        public static void OrderScan()
        {
            var orderScanParam = new OrderScanParam
            {
                MerchantOrderSn = $"{DateTime.Now:yyyyMMddHHmmss}000000001",
                StoreId = StoreId,
                TotalFee = 0.01m,
                // 支付方式[微信1/支付宝2/银联5]
                Type = 1,
            };
            try
            {
                var response = FubeiOpenApiFactory.MerchantApi.OrderScan(orderScanParam);
                Console.WriteLine($"请求成功: {response.ToJson()}");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine($"用于微信支付的定额二维码：{response.QrCode}");
                Console.WriteLine();
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"请求失败: {ex}");
            }
        }

        /// <summary>
        /// 初始化伽利略
		/// 在这里输入AppId和AppSecret
        /// </summary>
        private static void InitGalileo()
        {
            // 设置AppId和AppSecret
            // 这里是开放平台1.0的参数
            GalileoApiConfig.Instance.Register(new GalileoApiConfig.ApiConfig
            {
                AppId = MerchantApiAppId,
                AppSecret = MerchantAppSecret
            }, GalileoApiConfig.Category.MerchantApi);

            // 根据设置判断，设置不同的接口参数
            if (IsAgent)
            {
                // 设置VendorSn和VendorSn
                // 这里是开放平台2.0的参数
                GalileoApiConfig.Instance.Register(new GalileoApiConfig.ApiConfig
                {
                    AppId = "",
                    AppSecret = "",
                    VendorSn = AgentVendorSn,
                    VendorSecret = AgentVendorSecret
                }, GalileoApiConfig.Category.AgentApi);
            }
            else
            {
                // 设置AppId和AppSecret
                // 这里是开放平台2.0的参数
                GalileoApiConfig.Instance.Register(new GalileoApiConfig.ApiConfig
                {
                    AppId = MerchantApiAppId,
                    AppSecret = MerchantAppSecret,
                    VendorSn = "",
                    VendorSecret = ""
                }, GalileoApiConfig.Category.AgentApi);
            }

            // ***可选*** 设置付呗开放平台接口地址
            //OpenApiStorage.Instance.OpenApiHost = "http://shq-api.51fubei.com";

            // 忽略http错误
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            
            // 注册伽利略网络库日志回调
            GalileoLogger.Instance.Logger += (level, log) =>
            {
                switch (level)
                {
                    case GalileoLogger.Level.Trace:
                    case GalileoLogger.Level.Debug:
                        Console.WriteLine($"DEBUG: {log}");
                        break;
                    case GalileoLogger.Level.Info:
                        Console.WriteLine($"INFO: {log}");
                        break;
                    case GalileoLogger.Level.Warn:
                        Console.WriteLine($"WARN: {log}");
                        break;
                    case GalileoLogger.Level.Error:
                        Console.WriteLine($"Error: {log}");
                        break;
                    case GalileoLogger.Level.Fatal:
                        Console.WriteLine($"Fatal: {log}");
                        break;
                }
            };

            // **********可选*********定义TraceId生成规则，（如不定义则按照默认规则生成）
            var n = 0;
            GalileoApiConfig.Instance.GenerateTraceId = () => $"{DateTime.Now:yyyyMMdd_HHmmss}_{++n}";
        }

    }
}
