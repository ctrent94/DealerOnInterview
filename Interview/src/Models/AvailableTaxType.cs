using System;
using Enumerations;

namespace Models {
   
    /// <summary>
    /// A available tax type
    /// </summary>
    public class AvailableTaxType {
        /// <summary>
        /// Constructor for an available tax type
        /// </summary>
        /// <param name="taxable">a taxable option</param>
        /// <param name="description">the enum description</param>
        /// <param name="id">the identifier</param>
        /// <parma name="taxPercentage"the tax percentage></param>
        public AvailableTaxType (Taxable taxable, string description, int id, string taxPercentage) {
            Taxable = taxable;
            Description = description;
            Id = id;
            TaxPercentage = taxPercentage;
        }

        /// <summary>
        /// An id 
        /// </summary>
        /// <value></value>
        public int Id { get; }

        /// <summary>
        /// A taxable value
        /// </summary>
        /// <value></value>
        public Taxable Taxable { get; }

        /// <summary>
        /// A description string for the Taxable enumeration
        /// </summary>
        /// <value></value>
        public string Description { get; }
        
        /// <summary>
        /// A tax percentage as a string
        /// </summary>
        /// <value></value>
        public string TaxPercentage { get;}
    }
}