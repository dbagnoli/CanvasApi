namespace CanvasApi.Client.SisImports.Enums {
    public enum SisImportWorkflowState {
        initializing,
        importing,
        created,
        cleanup_batch,
        imported,
        imported_with_messages,
        aborted,
        failed_with_messages,
        failed,
        restoring,
        partially_restored,
        restored
    }
}