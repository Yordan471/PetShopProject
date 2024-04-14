using PetShopProject.Core.ViewModels.CartViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopProject.Core.ViewModels.OrderViewModels
{
    /// <summary>
    /// View model for visualizing checkout information
    /// </summary>
    public class OrderCheckoutViewModel
    {
        /// <summary>
        /// Collection of cart items
        /// </summary>
        public List<CartCheckoutViewModel> CartItems { get; set; }

        /// <summary>
        /// Total price of all products in the card
        /// </summary>
        public decimal TotalPrice { get; set; }
    }
}
