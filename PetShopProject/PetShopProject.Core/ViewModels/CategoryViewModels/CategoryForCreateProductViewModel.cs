using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopProject.Core.ViewModels.CategoryViewModels
{
    /// <summary>
    /// Category model nested in ProductCreateViewModel for creating product
    /// </summary>
    public class CategoryForCreateProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}
