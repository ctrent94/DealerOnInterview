using Interfaces;
using Enumerations;
using NUnit.Framework;
using Models;
using Tests.Fakes;

namespace Tests {
    
    public class TaxCalculatorTests {
        
        decimal baseTaxPercentage = .10M;
        decimal importTaxPercentage = .05M;

        ITaxCalculator _taxCalculator;

        [SetUp]
        public void Setup () {
            
            // typically I'd prefer to inject this but for now this will work
            _taxCalculator = new TaxCalculator();
        }

        [Test]
        public void CanSetupDependencies () {
            Assert.AreNotEqual(_taxCalculator, null);
        }

        [Test]
        public void CanDetermineSalesTaxPercentageForExempt()
        {
            Assert.AreEqual(_taxCalculator.DetermineTaxPercentage(Taxable.TaxExempt), 0.0M);
        }


        [Test]
        public void CanDetermineSalesTaxPercentageForImport()
        {
            Assert.AreEqual(_taxCalculator.DetermineTaxPercentage(Taxable.Import), baseTaxPercentage + importTaxPercentage);
        }

        [Test]
        public void CanDetermineSalesTaxPercentageForImportTaxExempt()
        {
            Assert.AreEqual(_taxCalculator.DetermineTaxPercentage(Taxable.ImportTaxExempt), importTaxPercentage);
        }

        [Test]
        public void CanDetermineBaseTaxPercentageWhenTaxable()
        {
            Assert.AreEqual(_taxCalculator.DetermineTaxPercentage(Taxable.Taxable), baseTaxPercentage);
        }

        [Test]
        public void ShouldThrowInvalidEnumArgumentExceptionWhenTaxUndefined()
        {
            Assert.Catch( ()=> _taxCalculator.DetermineTaxPercentage(Taxable.Undefined));
        }

        [Test]
        public void ShouldThrowInvalidEnumArgumentExceptionWhenTaxableUndefined()
        {
            FakeShoppingItem fakeItem = CreateFakeItem();
            fakeItem.Taxable = Taxable.Undefined;
            Assert.Catch( ()=> _taxCalculator.CalculatePriceWithTax(fakeItem));
        }

        [Test]
        public void TaxExemptShouldReturnPriceWithoutTax()
        {
            const decimal ten = 10m;

            FakeShoppingItem fakeItem = CreateFakeItem();
            fakeItem.Taxable = Taxable.TaxExempt;
            fakeItem.PriceWithoutTax = ten;
            decimal result = _taxCalculator.CalculatePriceWithTax(fakeItem);

            Assert.AreEqual(result, ten);
        }

        [Test]
        public void NoPriceAndATaxAmountShouldReturnZero()
        {
             const decimal zero = 0m;

            FakeShoppingItem fakeItem = CreateFakeItem();
            fakeItem.PriceWithoutTax = zero;
            decimal result = _taxCalculator.CalculatePriceWithTax(fakeItem);

            Assert.AreEqual(result, zero);
        }

        [Test]
        public void ZeroPrecentTaxShouldReturnPriceWithoutTax()
        {
            const decimal zero = 0m;

            FakeShoppingItem fakeItem = CreateFakeItem();
            fakeItem.TaxAmountAsPercent = zero;
            decimal result = _taxCalculator.CalculatePriceWithTax(fakeItem);

            Assert.AreEqual(result, fakeItem.PriceWithoutTax);
        }

        private FakeShoppingItem CreateFakeItem()
        {
            return new FakeShoppingItem
            {
                ItemName = "0",
                PriceWithoutTax = 10M,
                Taxable = Taxable.Taxable,
                TaxAmountAsPercent = .05M,
                FinalItemPrice = 11M
            };
        }
    }
}