using AplMovilBexsolucionesApi.Data;
using AplMovilBexsolucionesApi.Repositories;
using AplMovilBexsolucionesApi.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddScoped<DapperContext>();

builder.Services.AddScoped<IAmovilRepository, AmovilRepository>();
builder.Services.AddScoped<IBancoRepository, BancoRepository>();
builder.Services.AddScoped<ICarteraRepository, CarteraRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IDescuentoRepository, DescuentoRepository>();
builder.Services.AddScoped<IEstadoPedidoRepository, EstadoPedidoRepository>();
builder.Services.AddScoped<IInventarioRepository, InventarioRepository>();
builder.Services.AddScoped<IObsequioRepository, ObsequioRepository>();
builder.Services.AddScoped<IPrecioRepository,PrecioRepository>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IRuteroRepository, RuteroRepository>();
builder.Services.AddScoped<IVendedorRepository, VendedorRepository>();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();