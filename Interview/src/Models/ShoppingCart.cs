using System.Globalization;
using System.Collections.Generic;
using System.Collections.Immutable;
using Interfaces;
using System.Linq;

namespace Models {
   
    /// <summary>
    /// A lightweight class to hold a list of taxable items.
    /// </summary>
    public class ShoppingCart {
        private List<IShoppingItem> _taxableItems;

        /// <summary>
        /// Constructor for a tax item manager.
        /// </summary>
        public ShoppingCart () {
            _taxableItems = new List<IShoppingItem>();
        }

        /// <summary>
        /// Readonly copy of taxable items
        /// </summary>
        /// <value></value>
        public ImmutableList<IShoppingItem> TaxableItems => _taxableItems.ToImmutableList();

        /// <summary>
        /// Adds a taxable item to the list of taxable items
        /// </summary>
        /// <param name="taxableItem">the taxable item to be added</param>
        public void Add (IShoppingItem taxableItem) {
            _taxableItems.Add (taxableItem);
        }
        
        /// <summary>
        /// Checks to see if the item exists by name in the collection
        /// </summary>
        /// <param name="itemName">the name of the item to add</param>
        /// <returns>null if not found</returns>
        public IShoppingItem CheckIfItemExistsInCart(string itemName)
        {
            return _taxableItems.FirstOrDefault(x => x.ItemName.ToLower().Equals(itemName.ToLower()));
        }
    }
}