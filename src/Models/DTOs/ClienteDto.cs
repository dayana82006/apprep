using System.Globalization;

namespace AplMovilBexsolucionesApi.Models.DTOs;

public class ClienteDto
{
    public string Codigo { get; set; }
    public char Dv {  get; set; }
    public string Sucursal { get; set; }
    public string RazonSocial { get; set; }
    public string NombreContacto { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public string CodListaPrecio { get; set; }
    public string CondicionPago { get; set; }
    public string Periocidad { get; set; }
    public string CodVendedor {  get; set; }
    public string Cupo { get; set; }
    public string CodigoGrupoPodcto { get; set; }
    public string Email { get; set; } 
    public string TipoCliente { get; set; }
    public string TipoTercero { get; set; }
    public string Estado { get; set; }

}
