using System;
using System.Collections.Immutable;
using Enumerations;
using Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Models;
using Services;

namespace DealerOn {

    /// <summary>
    /// The program.
    /// </summary>
    class Program {

        /// <summary>
        /// The entry point defined in the runtime for .net
        /// </summary>
        /// <param name="args">string arguments</param>
        static void Main (string[] args) {

            ServiceProvider serviceProvider = new ServiceCollection ()
                .AddSingleton<ITaxCalculator, TaxCalculator> ()
                .AddSingleton<IEnumDescriptionService, EnumDescriptionService> ()
                .AddSingleton<IReceiptPrinter, ReceiptPrinter> ()
                .BuildServiceProvider ();

            RunApp (serviceProvider);
        }

        /// <summary>
        /// Runs the console application
        /// </summary>
        /// <param name="serviceProvider">the service provider</param>
        private static void RunApp (ServiceProvider serviceProvider) {
            ShoppingCart taxItemManager = new ShoppingCart ();

            bool finishedEnteringInput = false;
            while (!finishedEnteringInput) {
                string name = ReadTaxItemName ();

                Taxable taxSelection = ReadTaxSelection (serviceProvider);

                decimal priceWithoutTax = ReadPriceWithoutTax ();

                ITaxCalculator taxCalculator = serviceProvider.GetService<ITaxCalculator> ();

                IShoppingItem existingItem = taxItemManager.CheckIfItemExistsInCart (name);
                if (existingItem != null) {
                    Console.WriteLine ();
                    Console.WriteLine ($"Item with name {existingItem.ItemName} already exists, using prexisiting item price {existingItem.PriceWithoutTax}");
                    priceWithoutTax = existingItem.PriceWithoutTax;
                    taxSelection = existingItem.Taxable;
                }

                ShoppingItem taxableItem = new ShoppingItem (
                    taxSelection,
                    priceWithoutTax,
                    name,
                    taxCalculator
                );

                taxItemManager.Add (taxableItem);

                Console.WriteLine ();
                Console.Write ("Add another item? y/n: ");

                ConsoleKeyInfo key = Console.ReadKey ();
                if (key.KeyChar == 'n') {
                    finishedEnteringInput = true;
                }

                Console.WriteLine ();
            }
            IReceiptPrinter receiptPrinter = serviceProvider.GetService<IReceiptPrinter> ();
            receiptPrinter.PrintReceipt (taxItemManager.TaxableItems);
        }

        /// <summary>
        /// Reads the item name from the console
        /// </summary>
        /// <returns></returns>
        private static string ReadTaxItemName () {
            // assumption the user is not going to overflow the amount of characters that be put in the console line
            string itemName = string.Empty;
            while (string.IsNullOrWhiteSpace (itemName)) {
                Console.Write ("Please input name for item: ");
                itemName = Console.ReadLine ().Trim ();
                Console.WriteLine ();
            }
            return itemName;
        }

        /// <summary>
        /// Reads the tax selection from the console
        /// </summary>
        /// <param name="serviceProvider">the service provider</param>
        /// <returns></returns>
        private static Taxable ReadTaxSelection (ServiceProvider serviceProvider) {
            Console.WriteLine ("Please pick an id from the following list:");

            WriteUserFriendlyTaxDescriptions (serviceProvider);
            string id = Console.ReadLine ();

            Taxable taxable = Taxable.Undefined;
            while (taxable == Taxable.Undefined) {
                Console.WriteLine ();
                bool parsedInteger = int.TryParse (id, out int idAsInt);
                if (!parsedInteger || parsedInteger && idAsInt != default && !Enum.IsDefined (typeof (Taxable), idAsInt)) {
                    Console.WriteLine ("Please enter a valid id from the list:");
                    id = Console.ReadLine ();
                } else {
                    taxable = (Taxable) (idAsInt);
                }
            }
            return taxable;
        }

        /// <summary>
        /// Writes enum descriptions and id's to the console.
        /// </summary>
        /// <param name="serviceProvider">the service provider</param>
        private static void WriteUserFriendlyTaxDescriptions (ServiceProvider serviceProvider) {
            // typically we're going to inject services into a class... but using the console is not as nice sadly.
            IEnumDescriptionService enumDescriptionService = serviceProvider.GetService<IEnumDescriptionService> ();
            ImmutableList<AvailableTaxType> taxableDescriptions = enumDescriptionService.GetTaxableDescriptions ();

            foreach (AvailableTaxType taxType in taxableDescriptions) {
                Console.WriteLine ($"id: {taxType.Id}: {taxType.Description}, percentage: {taxType.TaxPercentage}");
            }
        }

        /// <summary>
        /// Reads the price without the tax from the console.
        /// </summary>
        /// <returns></returns>
        private static decimal ReadPriceWithoutTax () {
            Console.WriteLine ("Please enter a price without tax. ");
            Console.WriteLine ("Example value: 12.123 ");
            string priceAsAString = Console.ReadLine ();

            bool priceParsed = false;
            while (!priceParsed) {
                priceParsed = decimal.TryParse (priceAsAString, out decimal price);
                if (!priceParsed || priceParsed && price == default) {
                    Console.WriteLine ("Please enter a valid price: ");
                    priceAsAString = Console.ReadLine ();
                    priceParsed = false;
                } else {
                    return price;
                }
            }
            return default;
        }
    }
}