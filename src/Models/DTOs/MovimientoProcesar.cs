namespace AplMovilBexsolucionesApi.Models.DTOs;

public class MovimientoProcesar
{
    public string NoDocumento { get; set; } = string.Empty;
    public int EmpresaId { get; set; }
    public int SucursalId { get; set; }
    public int BodegaId { get; set; }
    public bool Procesada { get; set; }
    public bool Contabilizada { get; set; }
    public DateTime FechaDeSistema { get; set; }
    public DateTime FechaDeProceso { get; set; }
    public int TipoProceso { get; set; }
    public int UsuarioId { get; set; }
    public DateTime FechaDocumento { get; set; }
    public int EquipoId { get; set; }
}
