using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using PetShopProject.Core.ViewModels.OrderViewModels;

namespace PetShopProject.UnitTests
{
    [TestClass]
    public class OrderServiceTests
    {
        
            private OrderService _orderService;
            private Mock<PetShopDbContext> _mockDbContext;

            [SetUp]
            public void Setup()
            {
                // Create a mock instance of PetShopDbContext
                _mockDbContext = new Mock<PetShopDbContext>();

                // Initialize the OrderService instance with the mocked dbContext
                _orderService = new OrderService(_mockDbContext.Object);
            }

            [Test]
            public async Task CreateOrderAsync_ValidOrder_ShouldAddOrderToDbContext()
            {
                // Arrange
                var order = new Order
                {
                    CustomerId = 1,
                    TotalAmount = 100.00m,
                    // Set other necessary properties
                };

                // Act
                await _orderService.CreateOrderAsync(order);

                // Assert
                _mockDbContext.Verify(db => db.AddAsync(order), Times.Once);
                _mockDbContext.Verify(db => db.SaveChangesAsync(), Times.Once);
            }
        
    }
}
