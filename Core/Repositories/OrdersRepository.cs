using Core.DB;
using Core.Interfaces;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        ApplicationContext _context;
        DbSet<User> _dbSet;

        public OrdersRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<User>();
        }

        public async Task<Cart?> FindCartItemAsync(Cart cart)
        {
            var cartItem = await _context.Carts
                .Where(cartItem => cartItem.ProductId == cart.ProductId && cartItem.UserId == cart.UserId)
                .SingleOrDefaultAsync();
            return cartItem;
        }

        public async Task AddCartAsync(Cart cart)
        {
            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCartAsync(Cart cart)
        {
            _context.Carts.Update(cart);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CartForView>> GetCartAsync(int userId)
        {
            var cartItem = await _context.Carts.Where(c => c.UserId == userId)
                .Join(_context.Products, c => c.ProductId, p => p.Id, (c, p) => new CartForView()
                {
                    Id = c.Id,
                    ProductId = c.ProductId,
                    BrandId = p.BrandId,
                    Title = p.Title,
                    Model = p.Model,
                    Price = p.Price,
                    ImageUrls = p.ImageUrls,
                    Quantity = c.Quantity
                })
                .Join(_context.Brands, c => c.BrandId, b => b.Id, (c, b) => new CartForView()
                {
                    Id = c.Id,
                    ProductId = c.ProductId,
                    BrandName = b.Name,
                    BrandCountry = b.Country,
                    Title = c.Title,
                    Model = c.Model,
                    Price = c.Price,
                    ImageUrls = c.ImageUrls,
                    Quantity = c.Quantity
                }
                ).ToListAsync();

            return cartItem;
        }

        public async Task<int> CreateOrderAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order.Id;
        }

        public async Task AddOrderItemsAsync(OrderItems orderItems)
        {
            await _context.OrderItems.AddAsync(orderItems);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCartAsync(int id)
        {
            await _context.Carts.Where(c => c.Id == id)
                .ExecuteDeleteAsync();
            await _context.SaveChangesAsync();
        }
    }
}















//var orderItem = await _context.Orders
//    .Join(_context.OrderItems, oi => oi.OrderId, o => o.Id (o, oi) => new OrderItems()
//    {
//        Id = o.Id,
//        UserId = o.UserId,
//        TotalAmount = o.TotalAmount,
//        ShippingAddress = o.ShippingAddress,
//        PaymentMethod = o.PaymentMethod,
//        OrderId = oi.OrderId,
//        ProductId = oi.ProductId,
//        Quantity = oi.Quantity
//    })
//    .Where(o => o.OrderId == orderId)
//    .ToListAsync();

//return orderItem;