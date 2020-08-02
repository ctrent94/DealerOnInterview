using Enumerations;
using Interfaces;

namespace Tests.Fakes
{
    public class FakeShoppingItem : IShoppingItem
    {
        public string ItemName {get; set;}

        public decimal PriceWithoutTax { get; set; }

        public Taxable Taxable { get; set; }

        public decimal TaxAmountAsPercent  { get; set; }

        public decimal FinalItemPrice { get; set; }
    }
}