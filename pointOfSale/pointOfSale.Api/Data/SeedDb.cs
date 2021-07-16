using Microsoft.EntityFrameworkCore;
using pointOfSale.Api.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pointOfSale.Api.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckUserAsync();
            await CheckCustomersAsync();
            await CheckProductsrAsync();
        }

        private async Task CheckUserAsync()
        {
            if (!_context.Users.Any())
            {
                _context.Users.Add(new User
                {
                    Email = "and@yopmail.com",
                    FirstName = "and",
                    LastName = "roj",
                    Password = "123456"
                });

                _context.Users.Add(new User
                {
                    Email = "matt@yopmail.com",
                    FirstName = "matt",
                    LastName = "hinc",
                    Password = "123456"
                });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckCustomersAsync()
        {
            if (!_context.Customers.Any())
            {
                User user = await _context.Users.FirstOrDefaultAsync();
                for (int i = 0; i < 40; i++)
                {
                    _context.Customers.Add(new Customer
                    {
                        FirstName = $"Cliente {i}",
                        LastName = $"Apellido {i}",
                        PhoneNumber = "322 314 35 66",
                        Address = "Calle Falsa 123",
                        Email = $"cliente{i}@yopmail.com",
                        IsActive = true,
                        User = user
                    });
                }

                await _context.SaveChangesAsync();
            };
        }

        private async Task CheckProductsrAsync()
        {
            if (!_context.Products.Any())
            {
                Random random = new Random();
                User user = await _context.Users.FirstOrDefaultAsync();
                for (int i = 0; i < 200; i++)
                {
                    _context.Products.Add(new Product
                    {
                        Name = $"Producto {i}",
                        Description = $"Producto {i}",
                        Price = random.Next(5, 1000),
                        Stock = random.Next(0, 500),
                        IsActive = true,
                        User = user
                    });
                }

                await _context.SaveChangesAsync();
            }
        }
    }
}
