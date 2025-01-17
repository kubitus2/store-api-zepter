using ZepterApi.Models.Enums;

namespace ZepterApi.Models;

public class Order
{
    public int Id { get; set; }
    public int StoreId { get; set; }
    public int AddressId { get; set; }
    public PaymentMethod PaymentMethod { get; set; }

}
