using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;
using Serilog;
using Exchange.Api.Middlewares;
using Exchange.Api.Models;
using Exchange.Api.Extensions;
using Exchange.Api.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ExchangeDb>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"),b=>{
        b.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
    });
});
builder.Services.MassTransitConfiguration(builder.Configuration);
builder.Services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true)
.AddNewtonsoftJson(opts =>
            {
                opts.SerializerSettings.Converters.Add(new StringEnumConverter());
                opts.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                opts.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                opts.SerializerSettings.MaxDepth = 3;
            })
            .AddJsonOptions(opts => opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Exchange Api", Version = "v1",Description = "You can give instructions with this api." });
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<INotificationService,NotificationService>();
builder.Services.AddScoped<IInstructionService,InstructionService>();

var logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", Serilog.Events.LogEventLevel.Error)
            .Enrich.FromLogContext()
            .WriteTo.File($"Logs/{Path.DirectorySeparatorChar}.txt", rollingInterval: RollingInterval.Day, flushToDiskInterval: TimeSpan.FromDays(1))
            .Enrich.FromLogContext()
            .CreateLogger();
builder.Logging.AddSerilog(logger);

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseMiddleware<ExceptionHandlingMiddleware>();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    var log = loggerFactory.CreateLogger<Program>();
    try
    {
        log.LogInformation("Bağlantı sağlanıyor");
        log.LogInformation("ConnectionString : "+builder.Configuration.GetConnectionString("Default"));
        var db = scope.ServiceProvider.GetRequiredService<ExchangeDb>();
        db.Database.Migrate();
    }
    catch (System.Exception ex)
    {
        log.LogError(ex, "An error occurred creating/updating the DB.");
    }
}
app.Run();