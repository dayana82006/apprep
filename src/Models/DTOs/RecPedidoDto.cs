namespace AplMovilBexsolucionesApi.Models.DTOs;

/// <summary>
/// Pedido recibido por la app: una cabecera + una lista de productos.
/// Los campos marcados como "informativo" se reciben pero el ERP los deriva de la base
/// de datos (el documento de pedidos APL no maneja descuentos ni IVA enviados por el cliente).
/// </summary>
public class RecPedidoDto
{
    // --- Campos usados al guardar ---

    /// <summary>NoIdentificacion del cliente (debe existir en Personas). USADO.</summary>
    public string? Cliente { get; set; }

    /// <summary>Fecha del pedido. Si es null se usa la fecha actual del servidor. USADO.</summary>
    public DateTime? FechaMov { get; set; }

    /// <summary>Observación del pedido. USADO.</summary>
    public string? Observacion { get; set; }

    /// <summary>Sucursal de precios del ERP. Si es null se toma de Pedidos:SucursalErp. USADO.</summary>
    public int? SucursalErp { get; set; }

    // --- Campos informativos (se reciben, el ERP los deriva/ignora por ahora) ---

    public string? TipoDoc { get; set; }
    public string? CodVendedor { get; set; }
    public string? NumDoc { get; set; }
    public string? SucCliente { get; set; }
    public DateTime? FechaEntreg { get; set; }
    public string? CondPag { get; set; }

    public List<LineaPedidoDto> Lineas { get; set; } = new();
}

/// <summary>Cada producto del pedido.</summary>
public class LineaPedidoDto
{
    // --- Campos usados al guardar ---

    /// <summary>ProductoId. USADO.</summary>
    public int CodProduct { get; set; }

    /// <summary>Cantidad. USADO.</summary>
    public decimal CantMov { get; set; }

    /// <summary>Precio de venta / precio público. USADO.</summary>
    public decimal PrecioMov { get; set; }

    // --- Campos informativos (se reciben, el ERP los deriva/ignora por ahora) ---

    public string? CodBodega { get; set; }
    public string? IvaMov { get; set; }
    public string? Dcto1Mov { get; set; }
    public string? Dcto2Mov { get; set; }
    public string? Dcto3Mov { get; set; }
    public string? Bonificado { get; set; }
    public string? UnidadMov { get; set; }
    public string? Peso { get; set; }
    public string? Observacion { get; set; }
}
