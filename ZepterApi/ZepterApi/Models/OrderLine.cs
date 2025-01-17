namespace ZepterApi.Models;

public class OrderLine
{
    public int Id { get; set; }
    public string Sku { get; set; }
    public decimal NetPrice { get; set; }
    public decimal GrossPrice { get; set; }
    public int Quantity { get; set; }
    public Order Order { get; set; }
}
