using Org.BouncyCastle.Bcpg.OpenPgp;
using System.Globalization;

namespace AplMovilBexsolucionesApi.Models.DTOs;

public class FacturasDto
{
    public string? condVendedor {  get; set; }
    public string numberCustomer { get; set; } 
    public string codePlace { get; set; }
    public string razonSocial { get; set; }
    public string address { get; set; }
    public string? geolocation { get; set; }
    public string? phone {  get; set; }
    public string? email { get; set; }
    public string? city { get; set; }
    public string? state { get; set; }
    public string? observations { get; set; }
    public DateTime Date { get; set; }
    public DateTime Date_delivery { get; set; }
    public string Codfpagovta { get; set; }
    public int Periodfpagovta { get; set; }
    public string Order_number { get; set; }
    public string Type { get; set; }

    public decimal Grand_total { get; set; }
    public decimal? Retencion { get; set; }
    public string Type_of_charge { get; set; }
    public string Code_warehouse { get; set; }
    public string Operative_center { get; set; }
    public string Cost_center { get; set; }
    public string Unidneg { get; set; }
    public string Type_transaction { get; set; }
    public List<FacturaItemDto> Items { get; set; } = new List<FacturaItemDto>();

}
