namespace AplMovilBexsolucionesApi.Models.DTOs;

public class SalidaMercanciaDetalle
{
    public string NoDocumento { get; set; } = string.Empty;
    public int Id { get; set; }
    public int ProductoId { get; set; }
    public string CodigoAlterno { get; set; } = string.Empty;
    public string? DescripcionLarga { get; set; }
    public string? DescripcionCorta { get; set; }
    public string? Embalaje { get; set; }
    public int IvaVentaId { get; set; }
    public int IvaCompraId { get; set; }
    public decimal ImpoConsumo { get; set; }
    public decimal PrecioCosto { get; set; }
    public decimal PrecioPublico { get; set; }
    public decimal PrecioPublicoReal { get; set; }
    public decimal CantidadEntrada { get; set; }
    public decimal CantidadSalida { get; set; }
    public decimal BasePuntos { get; set; }
    public decimal NoPuntos { get; set; }
    public decimal TotalPuntos { get; set; }
    public decimal D1 { get; set; }
    public decimal D2 { get; set; }
    public decimal D3 { get; set; }
    public decimal D4 { get; set; }
    public decimal D5 { get; set; }
    public decimal TotalRegistro { get; set; }
    public string? NoRemision { get; set; }
    public string? NoApartado { get; set; }
    public string? Observacion { get; set; }
    public int? CanalId { get; set; }
    public int? ListaId { get; set; }
    public int? ZonaId { get; set; }
    public int? EventoId { get; set; }
    public int? VendedorId { get; set; }
    public int TipoDocumento { get; set; }
    public decimal TarifaIvaVenta { get; set; }
    public decimal TarifaIvaCompra { get; set; }
    public decimal PrecioVenta { get; set; }
    public bool AplicaPuntos { get; set; }
    public int CantidadDpc { get; set; }
    public decimal DescuentoProducto { get; set; }
    public decimal Ahorro { get; set; }
    public bool MostrarDescuento { get; set; }
    public bool VenderXPeso { get; set; }
    public bool VenderXFraccion { get; set; }
    public bool NoManejaInventario { get; set; }
    public bool EsConjunto { get; set; }
    public bool TieneLote { get; set; }
    public bool TieneSerial { get; set; }
    public bool EsServicio { get; set; }
    public bool EsProduccion { get; set; }
    public bool EsAncheta { get; set; }
    public bool EsConcesion { get; set; }
    public bool EsObsequio { get; set; }
    public bool PerteneceAsociacion { get; set; }
    public bool Productoweb { get; set; }
    public bool EsBolsa { get; set; }
    public bool Interno { get; set; }
    public DateTime Fecha { get; set; }
    public int UsuarioId { get; set; }
    public int EquipoId { get; set; }
    public int TipoLiquidacionId { get; set; }
    public string? NoCotizacion { get; set; }
    public string? NoPedido { get; set; }
    public string? NoFacturaTemporal { get; set; }
    public bool AplicaGrupoDeCosto { get; set; }
    public bool NoAplicaRedondeo { get; set; }
    public bool EsInsumo { get; set; }
    public int Id1 { get; set; }
    public int? Id2 { get; set; }
    public int SalidaId { get; set; }
    public bool EsKit { get; set; }
    public int? ImpuestoId { get; set; }
    public decimal TarifaIvaImpuesto { get; set; }
}
