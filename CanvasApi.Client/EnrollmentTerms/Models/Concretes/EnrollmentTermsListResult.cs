using System.Collections.Generic;
using System.Linq;

namespace CanvasApi.Client.EnrollmentTerms.Models.Concretes
{
    internal class EnrollmentTermsListResult
    {
        public EnrollmentTerm[] EnrollmentTerms { get; set; }

        public static IEnumerable<EnrollmentTerm> ToArray(EnrollmentTermsListResult apiResult) => apiResult.EnrollmentTerms.ToArray();
    }
}
