using ArchitectureSolutions.Application.Common.Interfaces;
using ArchitectureSolutions.Application.Common.Models;
using ArchitectureSolutions.Infrastructure.Persistence;
using ArchitectureSolutions.WebUI.Filters;
using ArchitectureSolutions.WebUI.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using NSwag;
using NSwag.Generation.Processors.Security;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddWebUIServices(this IServiceCollection services)
    {
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddSingleton<ICurrentUserService, CurrentUserService>();

        services.AddHttpContextAccessor();

        services.AddHealthChecks()
            .AddDbContextCheck<ApplicationDbContext>();

        services.AddControllersWithViews(options =>
        {
            options.Filters.Add<ApiExceptionFilterAttribute>();
            //options.InputFormatters.Insert(0, MyJPIF.GetJsonPatchInputFormatter());
        }
            )
                .AddFluentValidation(x => x.AutomaticValidationEnabled = false)
            .AddNewtonsoftJson(settings =>
        settings.SerializerSettings.ContractResolver = new PatchRequestContractResolver());

        services.AddRazorPages();

        // Customise default API behaviour
        services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);

        services.AddOpenApiDocument(configure =>
        {
            configure.Title = "ArchitectureSolutions API";
            configure.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
            {
                Type = OpenApiSecuritySchemeType.ApiKey,
                Name = "Authorization",
                In = OpenApiSecurityApiKeyLocation.Header,
                Description = "Type into the textbox: Bearer {your JWT token}."
            });

            configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
        });

        return services;
    }
}
