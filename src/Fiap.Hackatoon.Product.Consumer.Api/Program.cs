using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Fiap.Hackatoon.Product.Consumer.Api.Logging;
using Fiap.Hackatoon.Product.Consumer.Domain.Interfaces;
using Fiap.Hackatoon.Product.Consumer.Domain.Interfaces.Infrastructure;
using Fiap.Hackatoon.Product.Consumer.Domain.Services;
using Fiap.Hackatoon.Product.Consumer.Infrastructure.Data;
using Fiap.Hackatoon.Product.Consumer.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Globalization;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using System.Reflection;
using Fiap.Hackatoon.Product.Consumer.Application.Interfaces;
using Fiap.Hackatoon.Product.Consumer.Application.Services;
using Fiap.Hackatoon.Product.Consumer.Application.DataTransferObjects;
using Fiap.Hackatoon.Product.Consumer.Domain.Settings;
using Prometheus;
using Fiap.Hackatoon.Product.Consumer.Api.Robots.RabbitMQ;
using Fiap.Hackatoon.Product.Consumer.Domain.Interfaces.ElasticSearch;
using Fiap.Hackatoon.Product.Consumer.Infrastructure.ElasticSearch.Services;

var builder = WebApplication.CreateBuilder(args);
var env = builder.Environment;

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();

builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

var jwtKeyConfig = builder.Configuration["Token:Key"];
if (string.IsNullOrEmpty(jwtKeyConfig))
    throw new InvalidOperationException("Token:Key configuration is missing or empty.");

builder.Services.Configure<ConsumerSettings>(builder.Configuration);
builder.WebHost.UseUrls("https://0.0.0.0:5056");

builder.Services.AddAuthentication(o =>
{
    o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, o =>
{
    o.RequireHttpsMetadata = false;
    o.SaveToken = true;
    o.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(jwtKeyConfig)),
        RequireExpirationTime = true,
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true
    };
});

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    var settings = options.SerializerSettings;
    settings.NullValueHandling = NullValueHandling.Ignore;
    settings.FloatFormatHandling = FloatFormatHandling.DefaultValue;
    settings.FloatParseHandling = FloatParseHandling.Double;
    settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    settings.DateFormatString = "yyyy-MM-ddTHH:mm:ss";
    settings.Culture = new CultureInfo("en-US");
    settings.Converters.Add(new StringEnumConverter());
    settings.ContractResolver = new DefaultContractResolver() { NamingStrategy = new SnakeCaseNamingStrategy() };
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Fiap.Hackatoon.Product.Consumer API", Version = "v1" });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

    c.CustomSchemaIds(type => 
    {
        var namingStrategy = new SnakeCaseNamingStrategy();
        return namingStrategy.GetPropertyName(type.Name, false);
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization Header - utilizado com Bearer Authentication. \r\n\r\n Insira 'Bearer' [espaço] e então seu token na caixa abaixo.\r\n\r\nExemplo: (informar sem as aspas): 'Bearer 1234sdfgsdf' ",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddAutoMapper((sp, cfg) =>
{
    cfg.AllowNullDestinationValues = true;
    cfg.AllowNullCollections = true;
    cfg.ConstructServicesUsing(sp.GetService);
}, Assembly.GetAssembly(typeof(BaseModel)));

builder.Logging.ClearProviders();
builder.Logging.AddProvider(new CustomLoggerProvider(new CustomLoggerProviderConfiguration
{
    LogLevel = LogLevel.Information
}));

builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection"));
    options.LogTo(message => Debug.WriteLine(message), LogLevel.Information);
    options.EnableSensitiveDataLogging();
});

builder.Services.AddMemoryCache();

// Inject all Services and repositories

#region Repositories

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductTypeRepository, ProductTypeRepository>();

#endregion

#region Services

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductTypeService, ProductTypeService>();

#endregion

#region Application Services

builder.Services.AddScoped<IProductApplicationService, ProductApplicationService>();

#endregion

#region RabbitMQConsumers

builder.Services.AddHostedService<ProductConsumerService>();

#endregion

#region ElasticSearch

builder.Services.Configure<ElasticSearchSettings>(
    builder.Configuration.GetSection("ElasticSearch")
);

builder.Services.AddScoped(typeof(IElasticSearchService<>), typeof(ElasticSearchService<>));
builder.Services.AddScoped<IProductElasticSearchService, ProductElasticSearchService>();

#endregion

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fiap.Hackatoon.Product.Consumer API 2025"));

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDBContext>();

    context.Database.Migrate();
}

app.UseHttpMetrics();
app.MapMetrics();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
