using CanvasApi.Client.EnrollmentTerms.Enums;
using System.Collections.Generic;

namespace CanvasApi.Client.EnrollmentTerms.Models.Concretes {
    internal class EnrollmentTermListOptions : IEnrollmentTermListOptions {
        public IEnumerable<EnrollmentTermIncludes> Include { get; set; }
        public IEnumerable<EnrollmentTermListWorkflowState> WorkflowState { get; set; }
        public int PerPage { get; set; }
    }
}