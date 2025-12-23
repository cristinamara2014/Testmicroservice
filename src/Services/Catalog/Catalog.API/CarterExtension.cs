using Carter;
using System.Reflection;

namespace Catalog.API
{
    public static class CarterExtension
    {
        public static IServiceCollection AddCarterWithExtension(this IServiceCollection collection, params Assembly[] assemblies)
        {
            collection.AddCarter(configurator: config =>
            {
                foreach (var assembly in assemblies)
                {
                    var modules = assembly.GetTypes()
                        .Where(t => !t.IsAbstract && 
                                    !t.IsInterface && 
                                    typeof(ICarterModule).IsAssignableFrom(t))
                        .ToArray();
                    config.WithModules(modules);
                }
            });
            return collection;
        }
    }
}
