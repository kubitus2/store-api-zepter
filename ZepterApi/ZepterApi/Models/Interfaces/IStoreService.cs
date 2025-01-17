using ZepterApi.Models.DTO;

namespace ZepterApi.wwwroot.Interfaces;

public interface IStoreService
{
    public Task<ICollection<OrderDto>> GetDataThree();
    public Task GetPaymentSummary();
}
