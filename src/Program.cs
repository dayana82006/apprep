using AplMovilBexsoluciones.Middleware;
using AplMovilBexsolucionesApi.Data;
using AplMovilBexsolucionesApi.Repositories;
using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Services;
using AplMovilBexsolucionesApi.Services.Interfaces;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(static options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API Bexsoluciones",
        Version = "v1"
    });

    options.AddSecurityDefinition("ApiKey", securityScheme: new OpenApiSecurityScheme
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
                    Type = ReferenceType.SecurityScheme,
                    Id = "ApiKey"
                }
            },
            Array.Empty<string>()
        }
    });
});

#region Inyecciones
builder.Services.AddSingleton<SqliteContext>();
builder.Services.AddScoped<DapperContext>();

builder.Services.AddScoped<IAmovilRepository, AmovilRepository>();
builder.Services.AddScoped<IBancoRepository, BancoRepository>();
builder.Services.AddScoped<ICarteraRepository, CarteraRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IDescuentoRepository, DescuentoRepository>();
builder.Services.AddScoped<IEstadoPedidoRepository, EstadoPedidoRepository>();
builder.Services.AddScoped<IInventarioRepository, InventarioRepository>();
builder.Services.AddScoped<IObsequioRepository, ObsequioRepository>();
builder.Services.AddScoped<IPrecioRepository, PrecioRepository>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IRuteroRepository, RuteroRepository>();
builder.Services.AddScoped<IVendedorRepository, VendedorRepository>();
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

if (app.Environment.IsDevelopment())
{
    
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "BEXSOLUCIONES");
        c.RoutePrefix = string.Empty;
    });
}
app.UseMiddleware<ApiKeyMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();