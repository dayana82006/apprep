using Microsoft.Identity.Client;

namespace AplMovilBexsolucionesApi.Models.DTOs;

public class RecPedidoDto
{
    public string TipoDoc { get; set; }
    public string CodVendedor { get; set; }
    public string NumDoc { get; set; }
    public string Cliente { get; set; }
    public string SucCliente { get; set; }
    public DateTime FechaMov { get; set; }
    public DateTime FechaEntreg { get; set; }
    public string CondPag { get; set; }
    public string CodBodega { get; set; }
    public string CodProduct { get; set; }
    public string CantMov { get; set; }
    public string PrecioMov { get; set; }
    public string IvaMov { get; set; }
    public string  Dcto1Mov { get; set; }
    public string Dcto2Mov { get; set; }
    public string Dcto3Mov { get; set; }
    public string Bonificado { get; set; }
    public string UnidadMov { get; set; }
    public string Peso { get; set; }
    public string Observacion { get; set; }

}
