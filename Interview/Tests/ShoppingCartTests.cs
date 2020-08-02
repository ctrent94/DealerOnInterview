using Interfaces;
using Enumerations;
using NUnit.Framework;
using Models;

namespace Tests
{
    public class ShoppingCartTests
    {
        ShoppingCart _shoppingCart;
        TaxCalculator _taxCalculator;

        [SetUp]
        public void Setup()
        {
            _shoppingCart = new ShoppingCart();
            _taxCalculator = new TaxCalculator();
        }
        
        [Test]
        public void CanSetupTaxItemManager()
        {
            Assert.AreNotEqual(_shoppingCart, null);
            Assert.AreNotEqual(_taxCalculator, null);
        }

        [Test]
        public void CanAddItemToTaxItemManager()
        {
            IShoppingItem itemToAdd = CreateFakeTaxItem("Playstation 5");
            _shoppingCart.Add(itemToAdd);

            var items = _shoppingCart.TaxableItems;

            Assert.AreEqual(items.Contains(itemToAdd), true);
        }

        [Test]
        public void CanCheckIfItemExistsInManager()
        {
            IShoppingItem itemToAdd = CreateFakeTaxItem("Playstation 4");
            _shoppingCart.Add(itemToAdd);

            Assert.AreNotEqual(_shoppingCart.CheckIfItemExistsInCart("Playstation 4"), null);
        }

        private IShoppingItem CreateFakeTaxItem(string name)
        {
            return new ShoppingItem(Taxable.Import, 10, name, _taxCalculator);
        }
    }
}