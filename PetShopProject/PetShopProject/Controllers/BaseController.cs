using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PetShopProject.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {       
    }
}
