using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PetShopProject.Core.Contracts;
using PetShopProject.Core.ViewModels.CartViewModels;
using PetShopProject.Core.ViewModels.OrderViewModels;
using PetShopProject.Infrastructure.Data;
using PetShopProject.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopProject.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly PetShopDbContext dbContext;
        private readonly ILogger<OrderService> logger;

        public OrderService(PetShopDbContext _dbContect, ILogger<OrderService> _logger) 
        {
            dbContext = _dbContect;
            logger = _logger;
        }

        public async Task CreateOrderAsync(Order order)
        {
            await dbContext.AddAsync(order);
            await dbContext.SaveChangesAsync();
        }
    }
}
