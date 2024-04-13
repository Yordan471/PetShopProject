using PetShopProject.Infrastructure.Data.Models;
using System.Security.Claims;

namespace PetShopProject.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string FindId(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
