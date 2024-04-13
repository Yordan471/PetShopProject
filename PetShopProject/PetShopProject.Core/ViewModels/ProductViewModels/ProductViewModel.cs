namespace PetShopProject.Core.ViewModels.ProductViewModels
{
    /// <summary>
    /// General view for product
    /// </summary>
    public class ProductViewModel
    {
        /// <summary>
        /// Product identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Product name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Product description
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Product price
        /// </summary>
        public string Price { get; set; }

        /// <summary>
        /// Product quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Animal Type (dog, cat, etc)
        /// </summary>
        public string AnimalType { get; set; } = string.Empty;

        /// <summary>
        /// Product image url
        /// </summary>
        public string ImageUrl { get; set; } = string.Empty;
    }
}
