using PetShopProject.Core.Contracts;
using PetShopProject.Infrastructure.Data;
using PetShopProject.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopProject.Core.Services
{
    public class UserService : IUserService
    {
        private readonly PetShopDbContext dbContext;

        public UserService(PetShopDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task UpdateUserBankAccountAmountAsync(User user, decimal totalPrice)
        {
            user.BankAccountAmount -= totalPrice;
            await dbContext.SaveChangesAsync();
        }
    }
}
