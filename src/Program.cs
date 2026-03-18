using AplMovilBexsoluciones.Middleware;
using AplMovilBexsolucionesApi.Data;
using AplMovilBexsolucionesApi.Repositories;
using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Services;
using AplMovilBexsolucionesApi.Services.Interfaces;
using Microsoft.OpenApi.Models;
using System.Reflection;
using WatchDog;
using WatchDog.src.Enums;

var builder = WebApplication.CreateBuilder(args);

#region Servicios base

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

#endregion


#region Swagger

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API Bexsoluciones",
        Version = "v1",
        Description = @"Esta API es el núcleo de integración para la sincronización de datos 
        en tiempo real entre el sistema central y la aplicación móvil.",
        Contact = new OpenApiContact
        {
            Name = "GRUPO APL INGENIEROS LTDA.",
            Email = "sistemas@apl.com.co",
            Url = new Uri("https://apl.com.co")
        }
    });

    options.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        Name = "X-API-KEY",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Description = "Ingresa tu API Key"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "ApiKey",
                    Type = ReferenceType.SecurityScheme
                }
            },
            Array.Empty<string>()
        }
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

#endregion


#region WatchDog (Logs y monitoreo)

builder.Services.AddWatchDogServices(opt =>
{
    opt.IsAutoClear = true;
    opt.ClearTimeSchedule = WatchDogAutoClearScheduleEnum.Weekly;
});

#endregion


#region Contextos

builder.Services.AddSingleton<SqliteContext>();
builder.Services.AddScoped<DapperContext>();

#endregion


#region Repositories

builder.Services.AddScoped<IAmovilRepository, AmovilRepository>();
builder.Services.AddScoped<IBancoRepository, BancoRepository>();
builder.Services.AddScoped<ICarteraRepository, CarteraRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IDescuentoRepository, DescuentoRepository>();
builder.Services.AddScoped<IEstadoPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IInventarioRepository, InventarioRepository>();
builder.Services.AddScoped<IObsequioRepository, ObsequioRepository>();
builder.Services.AddScoped<IPrecioRepository, PrecioRepository>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IRuteroRepository, RuteroRepository>();
builder.Services.AddScoped<IVendedorRepository, VendedorRepository>();

#endregion


#region Services

builder.Services.AddScoped<IAmovilService, AmovilService>();
builder.Services.AddScoped<IBancoService, BancoService>();
builder.Services.AddScoped<ICarteraService, CarteraService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IDescuentoService, DescuentoService>();
builder.Services.AddScoped<IEstadoPedidoService, EstadoPedidoService>();
builder.Services.AddScoped<IInventarioService, InventarioService>();
builder.Services.AddScoped<IObsequioService, ObsequioService>();
builder.Services.AddScoped<IPrecioService, PrecioService>();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IRuteroService, RuteroService>();
builder.Services.AddScoped<IVendedorService, VendedorService>();

#endregion

var app = builder.Build();

#region Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "BEXSOLUCIONES API");
    c.RoutePrefix = string.Empty;
});
#endregion

#region WatchDog Middleware (PRIMERO)
app.UseWatchDogExceptionLogger();

app.UseWatchDog(opt =>
{
    opt.WatchPageUsername = "admin";
    opt.WatchPagePassword = "1234";
});
#endregion

#region Middlewares personalizados
app.UseMiddleware<ApiKeyMiddleware>();
#endregion

#region Otros middlewares
app.UseHttpsRedirection();

app.UseCors(policy =>
{
    policy.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader();
});

app.UseAuthorization();
#endregion

#region Endpoints
app.MapControllers();
#endregion

app.Run();