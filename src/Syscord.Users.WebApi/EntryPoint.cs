using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Syscord.Users.WebApi.V1.DI;

namespace Syscord.Users.WebApi;

public static class EntryPoint
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        ConfigureAutofacAsContainer(builder);
        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen();
        builder.Services.AddProblemDetails();
        AddHealthChecks(builder);
        
        ConfigureAutofac(builder);
        
        var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.MapHealthChecks("/alive", new HealthCheckOptions
            {
                Predicate = r => r.Tags.Contains("live")
            });
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }
        
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }

    //TODO by dretkh: add application /health check
    private static void AddHealthChecks(WebApplicationBuilder builder)
    {
        builder.Services.AddHealthChecks()
            .AddCheck("liveHealthCheck", () => HealthCheckResult.Healthy(), ["live"]);
    }

    private static void ConfigureAutofacAsContainer(WebApplicationBuilder builder)
    {
        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        
    }

    private static void ConfigureAutofac(WebApplicationBuilder builder)
    {
        builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
        {
            containerBuilder.RegisterModule(new ApiV1AutofacModule());
        });
    }
}