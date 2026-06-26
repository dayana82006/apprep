namespace AplMovilBexsolucionesApi.Models.DTOs;

public class RespuestaPedidoDto
{
    public int SalidaId { get; set; }
    public string NoDocumento { get; set; } = string.Empty;
    public decimal Total { get; set; }
}
