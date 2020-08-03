using System;
using Enumerations;
using Interfaces;

namespace Models {
    
    /// <summary>
    /// An implementation of a taxable item.
    /// </summary>
    public class ShoppingItem : IShoppingItem {
       
        /// <summary>
        /// Constructor for a taxable item.
        /// </summary>
        /// <param name="taxable">an enumeration representing whether or not the item is taxable</param>
        /// <param name="priceWithoutTax">the price without tax</param>
        /// <param name="itemName">the item name</parma>
        /// <param name="taxCalculator">the tax calculator</param>
        public ShoppingItem (
            Taxable taxable,
            decimal priceWithoutTax,
            string itemName,
            ITaxCalculator taxCalculator
        ) 
        {
            Taxable = taxable;
            PriceWithoutTax = priceWithoutTax;
            ItemName = itemName;
            TaxAmountAsPercent = taxCalculator.DetermineTaxPercentage(Taxable);
            FinalItemPrice = taxCalculator.CalculatePriceWithTax(this);
        }

        /// <inheritdoc cref="IShoppingItem.PriceWithoutTax"/>
        public decimal PriceWithoutTax { get; }

        /// <inheritdoc cref="IShoppingItem.Taxable"/>
        public Taxable Taxable { get; }

        /// <inheritdoc cref="IShoppingItem.TaxAmountAsPercent"/>
        public decimal TaxAmountAsPercent { get; }

        /// <inheritdoc cref="IShoppingItem.FinalItemPrice"/>
        public decimal FinalItemPrice { get; }

        /// <inheritdoc cref="IShoppingItem.ItemName"/>
        public string ItemName { get; }
    }
}