namespace AplMovilBexsolucionesApi.Models.DTOs;

public class SalidaMercanciaTercero
{
    public int SalidaId { get; set; }
    public string NoDocumento { get; set; } = string.Empty;
    public bool Procesada { get; set; }
    public int TipoDeDocumentoId { get; set; }
    public string NoIdentificacion { get; set; } = string.Empty;
    public int CiudadDeExpedicionId { get; set; }
    public string NombreCompleto { get; set; } = string.Empty;
    public string PrimerNombre { get; set; } = string.Empty;
    public string PrimerApellido { get; set; } = string.Empty;
    public string SegundoNombre { get; set; } = string.Empty;
    public string? SegundoApellido { get; set; }
    public string Alias { get; set; } = string.Empty;
    public string Direccion { get; set; } = string.Empty;
    public string? Telefono { get; set; }
    public string Telefono3 { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int Genero { get; set; }
    public DateTime? FechaNacimiento { get; set; }
    public int PaisId { get; set; }
    public int DepartamentoId { get; set; }
    public int CiudadId { get; set; }
    public int BarrioId { get; set; }
    public int? RutaId { get; set; }
    public int TipoPersona { get; set; }
    public int RegimenId { get; set; }
    public int TipoDeContribuyenteId { get; set; }
    public int EquipoId { get; set; }
    public int UsuarioId { get; set; }
    public int DigitoDeChequeo { get; set; }
    public string? RazonSocial { get; set; }
    public string? Representante { get; set; }
}
