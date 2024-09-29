using ECommerce;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

public class OrderService
{
    private readonly IMongoCollection<Order> _orders;

    public OrderService(IOptions<MongoDBSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        var database = client.GetDatabase(settings.Value.DatabaseName);
        _orders = database.GetCollection<Order>(settings.Value.OrdersCollection);
    }

    public List<Order> Get() => _orders.Find(order => true).ToList();

    public Order Get(string id) => _orders.Find(order => order.Id == id).FirstOrDefault();

    public Order Create(Order order)
    {
        _orders.InsertOne(order);
        return order;
    }

    public void Update(string id, Order orderIn) => _orders.ReplaceOne(order => order.Id == id, orderIn);

    public void Remove(string id) => _orders.DeleteOne(order => order.Id == id);
}
