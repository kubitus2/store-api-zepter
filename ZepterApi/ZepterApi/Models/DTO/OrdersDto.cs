namespace ZepterApi.Models.DTO;

public class OrderDto
{
    public int OrderId { get; set; }
    public int StoreId { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string PostalCode { get; set; }
    public decimal TotalNetValue { get; set; }
}
}
