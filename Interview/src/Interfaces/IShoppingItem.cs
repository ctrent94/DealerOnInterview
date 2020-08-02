using System;
using Enumerations;

namespace Interfaces {
    /// <summary>
    /// An interface defining a taxable item
    /// </summary>
    public interface IShoppingItem {

        /// <summary>
        /// The items name
        /// </summary>
        /// <value></value>
        string ItemName { get; }

        /// <summary>
        /// The price without tax
        /// </summary>
        /// <value>0.00 when not provided to decimal.Max</value>
        decimal PriceWithoutTax { get; }

        /// <summary>
        /// A definition if the item is taxable.
        /// </summary>
        /// <value></value>
        Taxable Taxable { get; }

        /// <summary>
        /// The tax amount as a percent
        /// </summary>
        /// <value>0.00 to decimal.Max</value>
        decimal TaxAmountAsPercent { get; }

        /// <summary>
        /// The final item price
        /// </summary>
        /// <value>0.00 to decimal.Max</value>
        decimal FinalItemPrice { get; }
    }
}