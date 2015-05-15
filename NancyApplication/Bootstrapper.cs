using System.Data.Linq;
using Nancy.Hal;
using Nancy.Hal.Configuration;
using Nancy.TinyIoc;

namespace NancyApplication
{
    using Nancy;

    public class Bootstrapper : DefaultNancyBootstrapper
    {
        // The bootstrapper enables you to reconfigure the composition of the framework,
        // by overriding the various methods and properties.
        // For more information https://github.com/NancyFx/Nancy/wiki/Bootstrapper

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            // This is the important part - build HAL config for types
            container.Register(typeof(IProvideHalTypeConfiguration), HypermediaConfiguration());

        }

        private static HalConfiguration HypermediaConfiguration()
        {
            var config = new HalConfiguration();

            config
                .For<Product>()
                .Links(model => new Link("self", "/product/{id}").CreateLink(model));
            
            return config;
        }

    }
}