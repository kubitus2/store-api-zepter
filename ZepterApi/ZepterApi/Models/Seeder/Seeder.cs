using ZepterApi.Models.DB;
using ZepterApi.Models.Enums;
using ZepterApi.Utilities;

namespace ZepterApi.Models.Seeder;

public class Seeder
{
    private Random _random;
    private OrdersDbContext _context;

    public Seeder(OrdersDbContext context)
    {
        _context = context;
        _random = new Random();
    }

    public async Task Seed()
    {
        if (_context.Stores.Any())
            return;

        var stores = Enumerable.Range(1, 10).Select(i => new Store
        {
            Name = $"Sklep {i}"
        });
        var orders = new List<Order>();
        foreach (var store in stores)
        {
            var randomNumber = _random.Next(7);
            for (var i = 0; i < randomNumber; i++)
            {
                var order = new Order
                {
                    Store = store,
                    OrderLines = GetRandomOrderLines(5),
                    Address = GetRandomAddress(),
                    PaymentMethod = Helpers.GetRandomEnumValue<PaymentMethod>()
                };

                orders.Add(order);
            }
        }

        _context.Stores.AddRange(stores);
        _context.Orders.AddRange(orders);
        await _context.SaveChangesAsync();
    }

    private ICollection<OrderLine> GetRandomOrderLines(int number)
    {
        var lines = new List<OrderLine>();
        for (var i = 0; i < number; i++)
        {
            var randomPrice = GetRandomPrice(1, 500);
            var randomQuantity = _random.Next(1, 10);
            var line = new OrderLine
            {
                Sku = $"ABC{i}",
                NetPrice = randomPrice,
                Quantity = randomQuantity,
                GrossPrice = randomQuantity * randomPrice
            };

            lines.Add(line);
        }

        return lines;
    }

    private Address GetRandomAddress()
    {
        var cities = new[] { "Warszawa", "Wrocław", "Kraków", "Lublin", "Gdańsk", "Włocławek" };
        var streets = new[] { "Kwiatowa", "Leśna", "Słoneczna", "Lipowa", "Długa", "Krótka", "Polna", "Zielona", "Świerkowa", "Topolowa" };
        var zipCode = "00-000";

        return new Address()
        {
            City = Helpers.GetRandomElement(cities),
            Street = Helpers.GetRandomElement(streets),
            HouseNumber = "4",
            FlatNumber = string.Empty,
            PostalCode = zipCode
        };
    }

    private decimal GetRandomPrice(decimal min, decimal max)
    {
        var range = (double)(max - min);
        var randomValue = _random.NextDouble() * range + (double)min;
        return Math.Round((decimal)randomValue, 2);
    }
}
