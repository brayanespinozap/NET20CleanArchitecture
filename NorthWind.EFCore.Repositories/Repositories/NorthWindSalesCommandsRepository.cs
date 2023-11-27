namespace NorthWind.EFCore.Repositories.Repositories
{
    public class NorthWindSalesCommandsRepository : INorthWindSalesCommandsRepository
    {
        readonly NorthWindSalesContext Context;

        public NorthWindSalesCommandsRepository(NorthWindSalesContext contex)
        {
            Context = contex;
        }

        public async ValueTask CreateOrder(OrderAggregate order)
        {
            await Context.AddAsync(order);
            foreach (var Item in order.OrderDetails)
            {
                await Context.AddAsync(new OrderDetail
                {
                    Order = order,
                    ProductId = Item.ProductId,
                    Quantity = Item.Quantity
                });
            }
        }
        public async ValueTask SaveChanges()
        {
            await Context.SaveChangesAsync();
        }
    }
}
