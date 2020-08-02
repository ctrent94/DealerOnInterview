using System;
namespace Enumerations {
    
    /// <summary>
    /// An enumeration representing if an item has tax applied
    /// </summary>
    public enum Taxable {
        /// <summary>
        /// Item taxable state not defined
        /// </summary>
        Undefined = 0,

        /// <summary>
        /// Item is defined as taxable and is an import
        /// </summary>
        Import = 1,

        /// <summary>
        /// Item is defined as not-taxable but is an import
        /// </summary>
        ImportTaxExempt = 2,

        /// <summary>
        /// Item is taxable but is not an import
        /// </summary>
        Taxable = 3,

        /// <summary>
        /// Item is defined as tax exempty
        /// </summary>
        TaxExempt = 4,
    }
}