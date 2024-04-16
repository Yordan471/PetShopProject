using Microsoft.Extensions.Logging;
using Moq;
using PetShopProject.Core.Contracts;
using PetShopProject.Core.Services;
using PetShopProject.Infrastructure.Data;
using PetShopProject.Infrastructure.Data.Models;

namespace PetShopProject.UnitTesting.Services
{
    [TestFixture]
    public class OrderServiceTests
    {
        private OrderService orderService;
        private Mock<PetShopDbContext> mockDbContext;
        private Mock<ILogger<OrderService>> mockLogger;

        [SetUp]
        public void Setup()
        {
            // Create a mock instance of PetShopDbContext
            mockDbContext = new Mock<PetShopDbContext>();

            // Create a mock instance of ILogger<OrderService>
            mockLogger = new Mock<ILogger<OrderService>>();

            // Initialize the OrderService instance with the mocked dependencies
            orderService = new OrderService(mockDbContext.Object, mockLogger.Object);
        }
    }
}