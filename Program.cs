using AspNetCoreRateLimit;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ParadisePublicAPI.Database;
using ParadisePublicAPI.ProfilerDatabase;
using System.Reflection;


// AA 2026-08-03 When I first made this I made it do top level statements. I hate this.

namespace ParadisePublicAPI {
    public class Program {
        public static void Main(string[] args) {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            // Setup swagger
            builder.Services.AddSwaggerGen(options => {
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
                options.EnableAnnotations();
                options.SwaggerDoc("v1", new OpenApiInfo {
                    Version = "v1",
                    Title = "Paradise Public API",
                    Description = "Paradise Station public API for data querying. This API may change with no notice.<br>Source: <a href=\"https://github.com/ParadiseSS13/ParadisePublicAPI\">https://github.com/ParadiseSS13/ParadisePublicAPI</a><br>Requests are limited to 500 every minute, and 3600 every hour."
                });
            });

            // Setup Game DB
            builder.Services.AddDbContext<ParadiseGamedbContext>(options => {
                options.UseMySql(builder.Configuration.GetConnectionString("GameDB"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("GameDB")));
            });

            // Setup profiler DB
            builder.Services.AddDbContext<ParadiseProfilerdaemonContext>(options => {
                options.UseMySql(builder.Configuration.GetConnectionString("ProfilerDB"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("ProfilerDB")));
            });

            // Setup IP preservation for...
            builder.Services.Configure<ForwardedHeadersOptions>(options => {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });

            // Setup IP rate lmiting
            builder.Services.AddMemoryCache();
            builder.Services.Configure<IpRateLimitOptions>(options => {
                options.EnableEndpointRateLimiting = true;
                options.StackBlockedRequests = false;
                options.RealIpHeader = "X-Forwarded-For";
                options.HttpStatusCode = 429;
                options.GeneralRules = [
                    new RateLimitRule {
                        Endpoint = "*",
                        Period = "1m",
                        Limit = 500,
                    },
                    new RateLimitRule {
                        Endpoint = "*",
                        Period = "1h",
                        Limit = 3600,
                    }
                ];
                options.IpWhitelist = ["10.0.0.0/16"]; // Ignore internal subnets
            });
            builder.Services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            builder.Services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            builder.Services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();

            WebApplication app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint("swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;

            });

            app.UseIpRateLimiting();
            app.MapControllers();
            app.Run();
        }
    }
}