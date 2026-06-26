namespace AplMovilBexsolucionesApi.Models.DTOs;

public class CarteraDto
{
    public string NitCliente { get; set; }
    public int Dv { get; set; }
    public string Succliente { get; set;  }
    public string Prefijo { get; set; }
    public string Documento { get; set; }
    public DateOnly Fechamov {  get; set; }
    public DateOnly Fechavenci { get; set; }
    public string Valor { get; set; }
}
