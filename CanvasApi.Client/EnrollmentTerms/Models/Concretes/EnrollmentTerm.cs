﻿using System;

namespace CanvasApi.Client.EnrollmentTerms.Models.Concretes
{
    public class EnrollmentTerm : IEnrollmentTerm
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string SisTermId { get; set; }
        public long? SisImportId { get; set; }
        public EnrollmentOverrides Overrides { get; set; }

        public DateTime? StartAt { get; set; }
        public DateTime? EndAt { get; set; }

        IEnrollmentOverrides IEnrollmentTerm.Overrides => this.Overrides;
    }
}
