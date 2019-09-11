using Autofac;

namespace Auu.Framework.Common
{
    public static class LocContainer
    {
        public static IContainer Main { get; set; }
        public static ContainerBuilder ContainerBuilder { get; set; }
    }
}