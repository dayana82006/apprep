
namespace AplMovilBexsolucionesApi.Models.DTOs;

public class FacturaItemDto
{
    public string Coditem { get; set; }
    public string Name_item { get; set; }
    public decimal Amount { get; set; }
    public string Unit_of_measurement { get; set; }
    public string Name_of_measurement { get; set; }
    public decimal Price { get; set; }
    public string Type_item { get; set; }
    public string Rowid { get; set; }
    public decimal? Weight { get; set; }
    public decimal? Volumen { get; set; }
}