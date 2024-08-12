using DucAnhERP.Models;

namespace DucAnhERP.Repository
{
    public interface IEmailHistoryRepository : IBaseRepository<EmailHistory>
    {
        Task SendEmail(EmailHistory emailHistory);

        Task<int> GetUnreadNotiByUser(string userId);

        Task<List<NotificationModel>> GetAllNotiByUser(string userId);

        Task<List<(string, string, int)>> GetAllCategoriesByUser(string userId);
    }
}
