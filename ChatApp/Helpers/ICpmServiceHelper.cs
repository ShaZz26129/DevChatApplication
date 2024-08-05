
namespace ChatApp.Helpers
{
    public interface ICpmServiceHelper
    {
        Task<CpmMyGuideResponse> GetCpmMyGuide(string tenantId, string tenantOuId, string AppId, string ViewType, string eventName);
        Task<GuideTreeResponse> GetFilteredGuideTreeData(string CategoryId, string Category, string Count);
        Task<GuideTreeResponse> GetGuideTreeData(string tenantId, string tenantOuId, string AppId, string CategoryId);
        Task<JobUnderstoodResponse> GetJobUnderstood(string tenantId, string tenantOuId, string AppId, string jobId);
        Task<JobByIdResponse> GetMyGuideJob(string tenantId, string tenantOuId, string AppId, string jobId);
        Task<ScheduleInfoResult> GetSchedule(string userId, int calendertype, string otypes, int tenantdetails);
        Task<PostScheduleResponse> PostSchedule(ScheduleInfo scheduleInfo);
    }
}