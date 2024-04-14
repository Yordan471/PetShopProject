using PetShopProject.Core.ViewModels.ProductViewModels;

namespace PetShopProject.Core.ViewModels.HomeViewModels
{
    /// <summary>
    /// Home view model
    /// </summary>
    public class HomeViewModel
    {
        /// <summary>
        /// Animal type ("dog", "cat" etc)
        /// </summary>
        public string AnimalType { get; set; }

        /// <summary>
        /// Category name (WetFood, DryFood etc)
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// Collection of products
        /// </summary>
        public List<ProductViewModel> Products { get; set; }
    }
}
