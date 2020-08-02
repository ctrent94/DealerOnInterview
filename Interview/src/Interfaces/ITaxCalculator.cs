using System;
using Enumerations;

namespace Interfaces {
    /// <summary>
    /// An interface definition for a tax calculator.
    /// </summary>
    public interface ITaxCalculator {
        
        /// <summary>
        /// Calculates a price with tax
        /// </summary>
        /// <param name="A taxable item interface">the taxable item</param>
        /// <returns>a final price as a decimal</returns>
        /// <exception cref="IShoppingItem.Taxable">When undefined</exception>
        decimal CalculatePriceWithTax (IShoppingItem taxableItem);

        /// <summary>
        /// Determines a tax percentage
        /// </summary>
        /// <param name="A taxable enumeration">the taxable item</param>
        /// <returns>a decimal representing a percentage</returns>
        /// <exception cref="IShoppingItem.Taxable">When undefined</exception>
        decimal DetermineTaxPercentage (Taxable taxable);

    }
}