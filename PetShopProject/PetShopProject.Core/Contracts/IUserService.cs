using PetShopProject.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopProject.Core.Contracts
{
    public interface IUserService
    {
        public Task UpdateUserBankAccountAmountAsync(User user, decimal totalPrice);
    }
}
