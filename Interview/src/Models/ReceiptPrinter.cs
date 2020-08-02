using System;
using System.Collections.Immutable;
using System.Linq;
using Interfaces;

namespace Models {
  
    /// <summary>
    /// An implementation of a receipt printer
    /// </summary>
    public class ReceiptPrinter : IReceiptPrinter {
        
        /// <inheritdoc cref="IReceiptPrinter.PrintReceipt(ImmutableList{ShoppingItem})" />
        public void PrintReceipt(ImmutableList<Interfaces.IShoppingItem> taxableItems) {
            var groupedTaxableItems = taxableItems.GroupBy (x => x.ItemName.ToLower());

            Console.WriteLine();
            Console.WriteLine("Receipt:");

            decimal totalOrderPrice = default;
            decimal totalOrderTax = default;
            foreach (IGrouping<string, Interfaces.IShoppingItem> group in groupedTaxableItems) {
                int duplicateItemsPurchasedCount = group.Count();
                decimal finalPriceSummation = group.Sum(x => x.FinalItemPrice);
                decimal finalTaxSummation = group.Sum(x => x.FinalItemPrice - x.PriceWithoutTax);

                decimal pricePerUnit = finalPriceSummation / duplicateItemsPurchasedCount;

                string costPerUnitDisplay = duplicateItemsPurchasedCount > 1 ? $"quantity {duplicateItemsPurchasedCount} at {pricePerUnit} ea" : string.Empty;

                totalOrderPrice += finalPriceSummation;
                totalOrderTax += finalTaxSummation;
                Console.WriteLine ($"item name: {group.Key}, total cost: {finalPriceSummation}, {costPerUnitDisplay}");
            }
            Console.WriteLine($"Sales Taxes: {totalOrderTax}");
            Console.WriteLine($"Total: {totalOrderPrice}");
            Console.WriteLine();
        }
    }
}