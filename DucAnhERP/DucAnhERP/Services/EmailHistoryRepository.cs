using DucAnhERP.Repository;
using DucAnhERP.Data;
using DucAnhERP.Models;
using Microsoft.EntityFrameworkCore;

namespace DucAnhERP.Services
{
    public class EmailHistoryRepository : IEmailHistoryRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;

        public EmailHistoryRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }

        public Task<bool> CheckExclusive(string[] ids, DateTime baseTime)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<EmailHistory>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<(string, string, int)>> GetAllCategoriesByUser(string userId)
        {
            using var context = _context.CreateDbContext();
            var query = from eh in context.EmailHistories
                        join maj in context.MMajors on eh.MajorId equals maj.Id into majGroup
                        from maj in majGroup.DefaultIfEmpty()
                        where maj.IsActive == 1 && eh.Receiver == userId
                        group new { eh, maj } by new { eh.MajorId, maj.MajorName } into g
                        select new 
                        {
                            g.Key.MajorId,
                            g.Key.MajorName,
                            UnreadCount = g.Sum(e => e.eh.IsRead == 0 ? 1 : 0)
                        };

            var result = await query.ToListAsync();
            return result.Select(x => (x.MajorId, x.MajorName, x.UnreadCount)).ToList();

        }

        public async Task<List<NotificationModel>> GetAllNotiByUser(string userId)
        {
            using var context = _context.CreateDbContext();
            var emailHistories = await (from eh in context.EmailHistories
                                        join parentMajor in context.MMajors on eh.MajorId equals parentMajor.Id into pmj
                                        from parentMajor in pmj.DefaultIfEmpty()
                                        where parentMajor.IsActive == 1
                                        join major in context.MMajors on eh.ScreenId equals major.Id into mj
                                        from major in mj.DefaultIfEmpty()
                                        where major.IsActive == 1
                                        where eh.Receiver == userId
                                        orderby eh.MajorId, eh.ScreenId
                                        select new NotificationModel
                                        {
                                            Id = eh.Id,
                                            Receiver = eh.Receiver,
                                            ParentName = parentMajor.MajorName,
                                            MajorName = major.MajorName,
                                            Subject = eh.Subject,
                                            Content = eh.Content,
                                            CompanyId = eh.CompanyId,
                                            MajorId = eh.MajorId,
                                            ScreenId = eh.ScreenId,
                                            CreateAt = eh.CreateAt,
                                            CreateBy = eh.CreateBy,
                                            IsRead = eh.IsRead

                                        }).ToListAsync();

            return emailHistories;
        }

        public async Task<EmailHistory> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.EmailHistories.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            return entity;
        }

        public async Task<int> GetUnreadNotiByUser(string userId)
        {
            using var context = _context.CreateDbContext();
            var notifs = await context.EmailHistories.Where(x => x.Receiver == userId && x.IsRead == 0).CountAsync();
            return notifs;
        }

        public Task Insert(EmailHistory entity)
        {
            throw new NotImplementedException();
        }

        public async Task SendEmail(EmailHistory emailHistory)
        {
            using var context = _context.CreateDbContext();
            if (emailHistory == null)
            {
                throw new Exception("Không có bản ghi nào để thêm!");
            }

            context.EmailHistories.Add(emailHistory);
            await context.SaveChangesAsync();
        }

        public async Task Update(EmailHistory emailHistory)
        {
            using var context = _context.CreateDbContext();
            if (emailHistory == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {emailHistory.Id}");
            }

            context.EmailHistories.Update(emailHistory);
            await context.SaveChangesAsync();
        }

        public Task UpdateMulti(EmailHistory[] entities)
        {
            throw new NotImplementedException();
        }
    }
}
