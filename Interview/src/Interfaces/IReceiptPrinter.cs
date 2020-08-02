using System.Collections.Immutable;

namespace Interfaces {
    /// <summary>
    /// an interface for a receipt printer
    /// </summary>
    public interface IReceiptPrinter {
       
        /// <summary>
        /// Prints a receipt for an order
        /// </summary>
        /// <param name="taxableItems">the list of taxable itemss</param>
        void PrintReceipt (ImmutableList<IShoppingItem> taxableItems);
    }
}