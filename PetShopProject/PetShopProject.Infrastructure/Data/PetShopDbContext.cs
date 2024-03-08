using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetShopProject.Infrastructure.Data.Models;

namespace PetShopProject.Infrastructure.Data
{
    public class PetShopDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public PetShopDbContext(DbContextOptions<PetShopDbContext> options)
            : base(options)
        {
        }
    }
}
