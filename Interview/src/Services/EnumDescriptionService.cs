using System.Collections.Generic;
using System.Collections.Immutable;
using Enumerations;
using Interfaces;
using Models;

namespace Services {

    /// <summary>
    /// A service to get a list of enum string descriptions
    /// </summary>
    public class EnumDescriptionService : IEnumDescriptionService {

       
        /// <inheritdoc cref="IEnumDescriptionService.GetTaxableDescriptions"/>
        /// note this isn't typically how I would implement this, it is better to have a microservice with a DB 
        /// backing a class with the enum, an id, and a description, but I'm not going to make things overly complicated so I can present
        /// the user with data.
        public ImmutableList<AvailableTaxType> GetTaxableDescriptions () {
            return new List<AvailableTaxType> {
                new AvailableTaxType (Taxable.Import, "Import", (int) Taxable.Import, "15%"),
                new AvailableTaxType (Taxable.ImportTaxExempt, "Import Tax Exempt", (int) Taxable.ImportTaxExempt, "5%"),
                new AvailableTaxType (Taxable.Taxable, "Taxable", (int) Taxable.Taxable, "10%"),
                new AvailableTaxType (Taxable.TaxExempt, "Tax Exempt", (int) Taxable.TaxExempt, "0%")
            }.ToImmutableList ();
        }
    }
}