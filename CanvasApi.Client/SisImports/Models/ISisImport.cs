using CanvasApi.Client.SisImports.Models;
using CanvasApi.Client.SisImports.Models.Concretes;
using CanvasApi.Client.Users.Models.Concrete;
using System;
using System.Collections.Generic;

namespace Canvas.Api.Client.SisImports.Models {

    public interface ISisImport {
        ulong Id { get; set; }

        DateTime? CreatedAt { get; set; }

        DateTime? EndedAt { get; set; }

        DateTime? UpdatedAt { get; set; }

        string WorkflowState { get; set; }

        SisImportData Data { get; set; }

        SisImportStatistics Statistics { get; set; }

        long? Progress { get; set; }

        Attachment? ErrorsAttachment { get; set; }
        IEnumerable<Attachment>? DiffedCsvAttachment { get; set; }

        User User { get; set; }

        IEnumerable<IEnumerable<string>> ProcessingWarnings { get; set; }

        IEnumerable<IEnumerable<string>> ProcessingErrors { get; set; }

        bool? BatchMode { get; set; }

        long? BatchModeTermId { get; set; }

        bool? MultiTermBatchMode { get; set; }

        bool? SkipDeletes { get; set; }

        bool? OverrideSisStickiness { get; set; }

        bool? AddSisStickiness { get; set; }

        bool? ClearSisStickiness { get; set; }

        string DiffingDataSetIdentifier { get; set; }

        ulong? DiffedAgainstImportId { get; set; }

        IEnumerable<Attachment> CsvAttachments { get; set; }

        bool DiffingThresholdExceeded { get; set; }
        
        ulong ChangeThreshold { get; set; }
    }
}