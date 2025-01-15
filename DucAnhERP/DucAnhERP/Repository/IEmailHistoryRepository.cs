using DucAnhERP.Models;
using DucAnhERP.ViewModel;
using OfficeOpenXml.Sparkline;

namespace DucAnhERP.Repository
{
    public interface IEmailHistoryRepository : IBaseRepository<EmailHistory>
    {
        Task SendEmail(EmailHistory emailHistory);
        Task<int> GetUnreadNotiByUser(string userId);
        Task<List<NotificationModel>> GetAllNotiByUser(string userId);
        Task<List<(string, string, int)>> GetAllCategoriesByUser(string userId);
        Task InsertMulti(List<EmailHistory> entity);
        Task<List<EmailUserPermissionModel>> GetUserPermission(string companyId, string approvalStepId);
    }
}
