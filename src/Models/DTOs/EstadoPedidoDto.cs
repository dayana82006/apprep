namespace AplMovilBexsolucionesApi.Models.DTOs;

public class EstadoPedidoDto
{
    public string CodEmp { get; set; }              
    public string CodVend { get; set; }            
    public string TipoPed { get; set; }     
    public string NumPed { get; set; }       
    public string NitCli { get; set; }         
    public string SucCli { get; set; }         
    public DateTime FecPed { get; set; }         
    public string OrdenPed { get; set; }           
    public string CodPro { get; set; }             
    public string Refer { get; set; }               
    public string Descrip { get; set; }             
    public decimal CantPed { get; set; }            
    public decimal VlrBruPed { get; set; }          
    public string IvaBruPed { get; set; }         
    public decimal VlrNetoPed { get; set; }       
    public int CantFacPed { get; set; }             
    public string Estado { get; set; }              
    public string Tipo { get; set; } = "PEDIDO";    
    public string TipoFac { get; set; }           
    public string Factura { get; set; }           
    public string OrdenFac { get; set; }           
    public int CantFac { get; set; }                
    public string VlrBruFac { get; set; }           
    public string IvaBruFac { get; set; }        
    public string VlrNetoFac { get; set; }         
    public string ObsPed { get; set; }        
    public string UndFacPed { get; set; }
}
