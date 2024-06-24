using System;

namespace CanvasApi.Client.SisImports.Models {

    public interface IAttachment {
        ulong Id { get; set; }
        string Uuid { get; set; }
        ulong? FolderId { get; set; }
        string DisplayName { get; set; }
        string Filename { get; set; }
        string UploadStatus { get; set; }
        string ContentType { get; set; }
        string Url { get; set; }
        ulong Size { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
        //DateTime? UnlockAt { get; set; }
        //bool Locked { get; set; }
        //bool Hidden { get; set; }
        //DateTime? LockAt { get; set; }
        //bool HiddenForUser { get; set; }
        //string ThumbnailUrl { get; set; }
        DateTime? ModifiedAt { get; set; }
        //string MimeClass { get; set; }
        //ulong? MediaEntryId { get; set; }
        //bool LockedForUser { get; set; }
    }
}