namespace Auu.PlugIn.Cloud.Base
{
    public interface ICloudSlb
    {
        string CreateLoadBalancerHttpsListener(string loadBalancerId,int listenerPort);
        string StartLoadBalancerListener(string loadBalancerId, int listenerPort);
        string StopLoadBalancerListener(string loadBalancerId, int listenerPort);
        string DeleteLoadBalancerListener(string loadBalancerId, int listenerPort);
    }
}