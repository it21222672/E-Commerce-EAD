using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly OrderService _orderService;

    public OrdersController(OrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public ActionResult<List<Order>> Get() => _orderService.Get();

    [HttpGet("{id}")]
    public ActionResult<Order> Get(string id) => _orderService.Get(id);

    [HttpPost]
    public ActionResult<Order> Create(Order order) => _orderService.Create(order);

    [HttpPut("{id}")]
    public IActionResult Update(string id, Order orderIn)
    {
        _orderService.Update(id, orderIn);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        _orderService.Remove(id);
        return NoContent();
    }
}
