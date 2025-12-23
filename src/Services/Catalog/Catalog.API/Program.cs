using Carter;
using Catalog.API;
using Catalog.API.Product.CreateProduct;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.PropertyNameCaseInsensitive = true;
    options.SerializerOptions.PropertyNamingPolicy = null;
    options.SerializerOptions.AllowTrailingCommas = true;
    options.SerializerOptions.ReadCommentHandling = System.Text.Json.JsonCommentHandling.Skip;
});

var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
   
});
//var catalog = new DependencyContextAssemblyCatalog();
//var types = catalog.GetAssemblies().SelectMany(x => x.GetTypes());
//var modules = types
//            .Where(t =>
//                !t.IsAbstract &&
//                typeof(ICarterModule).IsAssignableFrom(t)
//                && (t.IsPublic || t.IsNestedPublic)
//            ).ToList();

//builder.Services.AddCarter(configurator: c =>
//{
//    c.WithModules(modules.ToArray());
//});
////builder.Services.AddCarter(new DependencyContextAssemblyCatalogCustom());
//builder.Services.AddCarter();
//builder.Services.AddCarter(null,conf=>conf.WithModules(typeof(CreateProductEndpoint)));
//builder.Services.AddCarter(null, config =>
//{
//    var modules = typeof(Program).Assembly.GetTypes().Where(t => t.IsAssignableTo(typeof(ICarterModule))).ToArray();
//    config.WithModules(modules);
//});
builder.Services.AddCarterWithExtension(assembly);

var app = builder.Build();

app.UseHttpsRedirection();
app.MapCarter();


app.Run();
