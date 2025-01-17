
using Microsoft.EntityFrameworkCore;

using ZepterApi.Models.DB;
using ZepterApi.Models.DTO;
using ZepterApi.wwwroot.Interfaces;

namespace ZepterApi.Services;

public class StoreService : IStoreService
{
    private readonly OrdersDbContext _context;

    public StoreService(OrdersDbContext context)
    {
        _context = context;
    }

    public async Task<ICollection<OrderDto>> GetDataThree()
    {
        var query = @"SELECT o.Id AS OrderId, 
                o.StoreId, 
                a.City, 
                a.Street, 
                a.PostalCode, 
                (SELECT SUM(ol.NetPrice * ol.Quantity) 
                    FROM OrderLines ol 
                    WHERE ol.OrderId = o.Id) AS TotalNetValue 
            FROM Orders o 
            JOIN Addresses a ON o.AddressId = a.Id  
            WHERE o.StoreId % 2 = 0 AND a.City LIKE ""%w%"";";

        var orders = await _context.Database
            .SqlQuery<OrderDto>($"SELECT * FROM Orders")
            .ToListAsync();

        return orders;
    }

    public Task GetPaymentSummary()
    {
        throw new NotImplementedException();
    }
}
