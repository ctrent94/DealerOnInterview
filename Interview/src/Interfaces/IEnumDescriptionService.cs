using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using Models;

namespace Interfaces {
    
    /// <summary>
    /// An interface for getting an enum description
    /// </summary>
    public interface IEnumDescriptionService {
        /// <summary>
        /// Gets a list of user friendly descriptions
        /// </summary>
        /// <returns>a list of available tax types</returns>
        ImmutableList<AvailableTaxType> GetTaxableDescriptions ();
    }
}