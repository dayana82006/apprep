namespace AplMovilBexsolucionesApi.Models.DTOs;

public class PersonaErp
{
    public int PersonaId { get; set; }
    public int TipoDeDocumentoId { get; set; }
    public string NoIdentificacion { get; set; } = string.Empty;
    public string? RazonSocial { get; set; }
    public string? NombreCompleto { get; set; }
    public string? PrimerNombre { get; set; }
    public string? PrimerApellido { get; set; }
    public string? SegundoNombre { get; set; }
    public string? SegundoApellido { get; set; }
    public string? Direccion { get; set; }
    public string? Telefono1 { get; set; }
    public string? Email { get; set; }
    public int PaisId { get; set; }
    public int CiudadId { get; set; }
    public int DepartamentoId { get; set; }
    public int RegimenId { get; set; }
    public int EquipoId { get; set; }
}
