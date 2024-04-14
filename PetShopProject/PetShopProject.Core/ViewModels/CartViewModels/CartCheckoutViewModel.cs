using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopProject.Core.ViewModels.CartViewModels
{
    /// <summary>
    /// View model for checkout information
    /// </summary>
    public class CartCheckoutViewModel
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
        /// Product name
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Price of the product
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Quantity of he product in store
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Total sum to pay
        /// </summary>
        public decimal Total { get; set; }
    }
}
