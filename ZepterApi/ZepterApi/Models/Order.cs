using ZepterApi.Models.Enums;

namespace ZepterApi.Models;

public class Order
{
    public int Id { get; set; }
    public Store Store { get; set; }
    public ICollection<OrderLine> OrderLines { get; set; }
    public Address Address { get; set; }
    public PaymentMethod PaymentMethod { get; set; }

}
