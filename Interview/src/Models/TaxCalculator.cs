using System;
using System.ComponentModel;
using Enumerations;
using Interfaces;

namespace Models {

    /// <summary>
    /// An instance of a tax calculator
    /// </summary>
    public class TaxCalculator : ITaxCalculator {

        /// <inehritdoc cref="ITaxCalculator.CalculatePriceWithTax(Interfaces.IShoppingItem)">    
        public decimal CalculatePriceWithTax (Interfaces.IShoppingItem taxableItem) {

            if (taxableItem.Taxable == Taxable.Undefined) {
                throw new InvalidEnumArgumentException ($"To attempt to calculate tax {nameof(taxableItem)} must be defined");
            }
            if (taxableItem.PriceWithoutTax == 0 
                || taxableItem.TaxAmountAsPercent == 0
                || taxableItem.Taxable == Taxable.TaxExempt) 
            {
                return taxableItem.PriceWithoutTax;
            }

            decimal finalPriceWithTax = (taxableItem.PriceWithoutTax * taxableItem.TaxAmountAsPercent) + taxableItem.PriceWithoutTax;

            return Math.Round((finalPriceWithTax * 20) /20, 2);
        }

        /// <inehritdoc cref="ITaxCalculator.DetermineTaxPercentage(Taxable)">    
        public decimal DetermineTaxPercentage (Taxable taxableItem) {
            decimal baseTaxPercentage = .10M;
            decimal importTaxPercentage = .05M;

            if (taxableItem == Taxable.Undefined) {
                throw new InvalidEnumArgumentException ($"To attempt to calculate tax percentage {nameof(taxableItem)} must be defined");
            }

            if (taxableItem == Taxable.TaxExempt) {
                return default;
            }

            if (taxableItem == Taxable.Import) {
                return baseTaxPercentage + importTaxPercentage;
            }

            if (taxableItem == Taxable.ImportTaxExempt) {
                return importTaxPercentage;
            }

            return baseTaxPercentage;

        }
    }
}