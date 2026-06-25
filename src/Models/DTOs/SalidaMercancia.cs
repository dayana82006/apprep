namespace AplMovilBexsolucionesApi.Models.DTOs;


public class SalidaMercancia
{
    public int SalidaId { get; set; }
    public string NoDocumento { get; set; } = string.Empty;
    public bool Procesada { get; set; }
    public int EmpresaId { get; set; }
    public int BodegaId { get; set; }
    public int CentroDeCostoId { get; set; }
    public int? VendedorId { get; set; }
    public int? MotivoId { get; set; }
    public int? DomiciliarioId { get; set; }
    public string? NoCotizacion { get; set; }
    public DateTime FechaDeSalida { get; set; }
    public TimeSpan? HoraDeSalida { get; set; }
    public decimal TotalSalida { get; set; }
    public decimal TotalUtilidad { get; set; }
    public decimal TotalCancelo { get; set; }
    public int TotalPuntos { get; set; }
    public decimal TotalAhorro { get; set; }
    public decimal TotalDescuento { get; set; }
    public decimal TotalCredito { get; set; }
    public string? Resolucion { get; set; }
    public string Observacion { get; set; } = string.Empty;
    public int EquipoId { get; set; }
    public int UsuarioId { get; set; }
    public DateTime FechaDeSistema { get; set; }
    public int? EquipoDestinoTemporalId { get; set; }
    public DateTime? FechaFin { get; set; }
    public int? EstadoApartado { get; set; }
    public decimal? TotalAbono { get; set; }
    public int? EstadoCotizacion { get; set; }
    public int? TipoDevolucion { get; set; }
    public int? ModoDevolucion { get; set; }
    public int? ModoEnSa { get; set; }
    public string TipoDocumento { get; set; } = "11";
    public string? Discriminator { get; set; }
    public int Consecutivo { get; set; }
    public string? NoFacturaDevolucion { get; set; }
    public int EstadoPedido { get; set; }
    public int? RutaPedidoId { get; set; }
    public int? EstadoTemporal { get; set; }
    public int ClienteId { get; set; }
    public string? NoPedido { get; set; }
    public decimal TotalIva { get; set; }
    public bool Cartera { get; set; }
    public bool Domicilio { get; set; }
    public bool ChequePosFechado { get; set; }
    public int? RutaFacturaId { get; set; }
    public bool ActualizaPrecios { get; set; }
    public string? NoApartado { get; set; }
    public DateTime FechaDePedidoFactura { get; set; }
    public string? NoIdentificacionNuevo { get; set; }
    public int SucursalId { get; set; }
    public int EstadoDomicilio { get; set; }
    public decimal PropinaFactura { get; set; }
    public decimal PropinaTemporal { get; set; }
    public string? NoTemporal { get; set; }
    public string? NoRemisionDevolucion { get; set; }
    public int? TipoDevolucionRemision { get; set; }
    public int? ModoDevolucionRemision { get; set; }
    public int? MotivoRemisionId { get; set; }
    public int? EstadoRemision { get; set; }
    public int? EstadoRemisionTemporal { get; set; }
    public int? EquipoDestinoRemisionTemporalId { get; set; }
    public decimal? PropinaRemisionTemporal { get; set; }
    public DateTime FechaDePedidoRemision { get; set; }
    public int? RutaRemisionId { get; set; }
    public string? Prefijo { get; set; }
    public decimal TotalConcesion { get; set; }
    public bool EsFacturaDomicilio { get; set; }
    public bool Email { get; set; }
    public int TipoDocumentoFactura { get; set; }
    public int TipoDocumentoGenerar { get; set; }
    public bool PendienteCobro { get; set; }
    public int Id2 { get; set; }
    public bool Id1 { get; set; }
    public bool EsFacturaConCanal { get; set; }
    public int? CanalId { get; set; }
    public int? ListaId { get; set; }
    public bool AplicaCanalTemporal { get; set; }
    public string? NoPedidoGenerado { get; set; }
    public DateTime FechaVencimiento { get; set; }
    public int TipoDocumentoId { get; set; }
    public int TipoFacturacion { get; set; }
    public bool Anulada { get; set; }
    public bool EsConversion { get; set; }
    public string? NoFacturaOrigen { get; set; }
    public string Letra { get; set; } = "0";
    public decimal TotalCosto { get; set; }
    public DateTime Id3 { get; set; }
    public decimal? AjusteAlPeso { get; set; }
    public decimal TotalDomicilioTercero { get; set; }
}
