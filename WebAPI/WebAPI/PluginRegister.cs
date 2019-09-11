using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Autofac;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Module = Autofac.Module;

namespace Auu.WebApi
{
    /// <inheritdoc />
    public class PluginRegister : Module
    {
        /// <inheritdoc />
        protected override void Load(ContainerBuilder builder)
        {
            //注册所有Controller
            var manager = new ApplicationPartManager();
            var assemblies = GetControllers();
            if (assemblies == null) return;
            foreach (var assembly in assemblies)
            {
                manager.ApplicationParts.Add(new AssemblyPart(assembly));
            }

            manager.FeatureProviders.Add(new ControllerFeatureProvider());
            var feature = new ControllerFeature();
            manager.PopulateFeature(feature);
            builder.RegisterTypes(feature.Controllers.Select(ti => ti.AsType()).ToArray()).PropertiesAutowired();
        }

        private static Assembly[] GetControllers()
        {
            try
            {
                return new DirectoryInfo(Path.Combine(AppContext.BaseDirectory, "plugins")).GetFiles("*.dll")
                    .Select(r => Assembly.LoadFrom(r.FullName))
                    .ToArray();
            }
            catch
            {
                return null;
            }
        }
    }
}