using Com.Fubei.Api.OpenApi;
using Com.Illuminati.Galileo;
using Com.Illuminati.Galileo.Biz;
using Com.Illuminati.Galileo.Biz.MerchantApi.Model.Request;
using Com.Illuminati.Galileo.Foundation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using Com.Fubei.Api.OpenApi.Biz.MerchantApi.Model.Request;

namespace OpenApiDemo
{
    class Program
    {
        public const string MerchantApiAppId = "20170607085534749364";
        public const string MerchantAppSecret = "1809d9615714ab8fdc90d0d838a0f2e1";
        public const int StoreId = 145827;

        static void Main(string[] args)
        {
            // 初始化客户端网络库
            InitGalileo();

            // 定额码
            OrderScan();

            OrderPay();

            Console.ReadLine();
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
            // 设置AppKey和AppSecret
            GalileoApiConfig.Instance.Register(new GalileoApiConfig.ApiConfig
            {
                AppId = MerchantApiAppId,
                AppSecret = MerchantAppSecret
            }, GalileoApiConfig.Category.MerchantApi);

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
