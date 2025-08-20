using BaseArchitecture.Domain.Entities;
using BaseArchitecture.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EcommerceProject.Infrastructure.Seeder
{
    public static class DbSeeder
    {
        public static async Task ProductSeedAsync(AppDbContext _context)
        {
            var rolesCount = await _context.Product.CountAsync();
            if (rolesCount <= 0)
            {

                _context.Product.Add(new Product()
                {
                    Name = "Product 1",
                    NameLocalization = "ايفون 16",
                    CreationDate = DateTime.Now,
                    CreatorName = "System",
                    Description = "ايفون 16 هو أحدث إصدار من سلسلة هواتف آيفون، ويتميز بتصميم أنيق وأداء قوي.",
                    Price = 65000,
                    Stock = 100,
                    IsDeleted = false,
                });

                _context.SaveChanges();
            }
        }
        public static async Task OrderSeedAsync(AppDbContext _context)
        {
            var rolesCount = await _context.Order.CountAsync();
            if (rolesCount <= 0)
            {

                _context.Order.Add(new Order()
                {
                    CreationDate = DateTime.Now,
                    CreatorName = "System",
                    CustomerId = 1,
                    Status = "Pending",
                    StatusCode = 1,
                    TotalPrice = 130000,
                    IsDeleted = false,
                });

                _context.SaveChanges();
            }
        }
        public static async Task OrderDetailsSeedAsync(AppDbContext _context)
        {
            var rolesCount = await _context.OrderDetails.CountAsync();
            if (rolesCount <= 0)
            {

                _context.OrderDetails.Add(new OrderDetails()
                {
                    CreationDate = DateTime.Now,
                    CreatorName = "System",
                    OrderId = 1,
                    Quantity = 2,
                    ProductId = 1,
                    IsDeleted = false,
                });

                _context.SaveChanges();
            }
        }
    }
}
