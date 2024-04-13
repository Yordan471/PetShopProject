namespace PetShopProject.Core.ViewModels.CartViewModels
{
    /// <summary>
    /// Cart view model
    /// </summary>
    public class CartViewModel
    {
        /// <summary>
        /// Cart item identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Product identifier
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Name of the product
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Quantity of he product to buy
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Price of the product
        /// </summary>
        public string Price { get; set; }
    }
}
