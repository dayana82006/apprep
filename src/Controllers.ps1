# Lista de módulos
$modulos = @(
"Amovil",
"Clientes",
"Productos",
"Inventarios",
"Precios",
"Ruteros",
"Vendedores",
"Cartera",
"EstadosPedidos",
"Bancos"
)

$controllersPath = "./Controllers"
$servicesPath = "./Services"

foreach ($modulo in $modulos) {

# Interface Service
$serviceContent = @"
using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexsolucionesApi.Services
{
    public interface I${modulo}Service
    {
        Task<IEnumerable<${modulo}Dto>> Obtener${modulo}();
    }
}
"@

$serviceFile = "$servicesPath/I${modulo}Service.cs"
$serviceContent | Out-File -Encoding utf8 $serviceFile

}

Write-Host "Archivos creados correctamente."