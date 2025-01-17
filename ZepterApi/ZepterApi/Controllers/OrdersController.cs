using Microsoft.AspNetCore.Mvc;

using ZepterApi.wwwroot.Interfaces;

namespace ZepterApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly ILogger<OrdersController> _logger;
    private readonly IStoreService _storeService;

    public OrdersController(ILogger<OrdersController> logger, IStoreService service)
    {
        _logger = logger;
        _storeService = service;
    }
}
