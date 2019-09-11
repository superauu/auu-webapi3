using Auu.Framework.Common;
using Auu.PlugIn.Cloud.Base;

namespace Auu.PlugIn.Cloud.AliyunApi
{
    public class SlbController
    {
        private readonly ApiParam _apiParam;

        public SlbController(ApiParam param)
        {
            _apiParam = param;
        }

        /// <summary>
        ///     创建负载均衡监听
        /// </summary>
        /// <param name="loadBalancerId">lb-m5eubnu9oay5hx94thuuq</param>
        /// <param name="listenerPort"></param>
        /// <returns></returns>
        public string CreateLoadBalancerHttpsListener(string loadBalancerId,
            int listenerPort)
        {
            return Auu.PlugIn.Cloud.AliyunApi.AliyunApi.Request(_apiParam, "CreateLoadBalancerHTTPSListener",
                "LoadBalancerId=" + loadBalancerId,
                "ListenerPort=" + listenerPort,
                "BackendServerPort=" + listenerPort,
                "Bandwidth=-1", "StickySession=off",
                "HealthCheck=on", "HealthCheckURI=" + Encrypt.UrlEncode("/swagger/images/favicon-16x16.png"),
                "HealthCheckConnectPort=-520", "HealthyThreshold=2",
                "UnhealthyThreshold=2", "HealthCheckTimeout=5",
                "HealthCheckInterval=2",
                "ServerCertificateId=1349011346882730_15df4dd09c6_-315689589_299556397");
        }

        /// <summary>
        ///     开始
        /// </summary>
        /// <param name="loadBalancerId"></param>
        /// <param name="listenerPort"></param>
        /// <returns></returns>
        public string StartLoadBalancerListener(string loadBalancerId, int listenerPort)
        {
            return Auu.PlugIn.Cloud.AliyunApi.AliyunApi.Request(_apiParam, "StartLoadBalancerListener",
                "LoadBalancerId=" + loadBalancerId,
                "ListenerPort=" + listenerPort);
        }

        /// <summary>
        ///     停止
        /// </summary>
        /// <param name="loadBalancerId"></param>
        /// <param name="listenerPort"></param>
        /// <returns></returns>
        public string StopLoadBalancerListener(string loadBalancerId, int listenerPort)
        {
            return Auu.PlugIn.Cloud.AliyunApi.AliyunApi.Request(_apiParam, "StopLoadBalancerListener",
                "LoadBalancerId=" + loadBalancerId,
                "ListenerPort=" + listenerPort);
        }

        /// <summary>
        ///     删除
        /// </summary>
        /// <param name="loadBalancerId"></param>
        /// <param name="listenerPort"></param>
        /// <returns></returns>
        public string DeleteLoadBalancerListener(string loadBalancerId, int listenerPort)
        {
            return Auu.PlugIn.Cloud.AliyunApi.AliyunApi.Request(_apiParam, "DeleteLoadBalancerListener",
                "LoadBalancerId=" + loadBalancerId,
                "ListenerPort=" + listenerPort);
        }
    }
}