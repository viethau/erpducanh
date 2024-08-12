using DucAnhERP.Repository;
using DucAnhERP.ViewModel;
using DucAnhERP.Data;
using DucAnhERP.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DucAnhERP.Services
{
    public class ApprovalDeptSettingRepository : IApprovalDeptSettingRepository
    {

        private readonly IDbContextFactory<ApplicationDbContext> _context;

        public ApprovalDeptSettingRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }

        public async Task<bool> CheckExclusive(string[] ids, DateTime baseTime)
        {
            foreach (var id in ids)
            {
                var model = await GetById(id);
                if (model == null)
                {
                    throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
                }

                if (model.CreateAt > baseTime)
                {
                    throw new Exception($"ID: {id} đã bị thay đổi bởi người dùng khác. Vui lòng tải lại trang!");
                }

            }
            return true;
        }

        public async Task<bool> CreateApprovalDeptSetting(List<ApprovalDeptWrapper> approvalRowWrappers, DateTime baseTime)
        {
            if (approvalRowWrappers.Count == 0)
            {
                return false;
            }
            using var context = _context.CreateDbContext();
            var companyId = approvalRowWrappers.First().ApprovalRow.CompanyId;
            var majorId = approvalRowWrappers.First().ApprovalRow.MajorId;
            var screenId = approvalRowWrappers.First().ApprovalRow.ScreenId;

            // Xóa cài đặt cũ
            var listToDelete = await GetSetApprovalDept(companyId, majorId, screenId);
            var listId = listToDelete.Select(x => x.Id).ToArray();
            await CheckExclusive(listId, baseTime);

            foreach (var item in listToDelete)
            {
                await DeleteById(item.Id);
            }

            // Đăng ký cài đặt mới
            foreach (var row in approvalRowWrappers)
            {
                await Insert(row.ApprovalRow);
            }

            return true;

        }

        public async Task DeleteById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await GetById(id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }
            entity.IsActive = 0;
            context.ApprovalDeptSettings.Update(entity);
            await context.SaveChangesAsync();
        }

        public Task<List<ApprovalDeptSetting>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ApprovalDeptSetting> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.ApprovalDeptSettings.Where(x => x.Id.Equals(id) && x.IsActive == 1).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            return entity;
        }

        public async Task<List<ApprovalDeptSettingModel>> GetSetApprovalDept(string companyId, string majorId, string screenId)
        {
            using var context = _context.CreateDbContext();
            var query = from settings in context.ApprovalDeptSettings
                        join company in context.MCompanies on settings.CompanyId equals company.Id into companyGroup
                        from company in companyGroup.DefaultIfEmpty()
                        where company.IsActive == 1
                        join major in context.MMajors on settings.MajorId equals major.Id into majorGroup
                        from major in majorGroup.DefaultIfEmpty()
                        where major.IsActive == 1
                        join screen in context.MMajors on settings.ScreenId equals screen.Id into screenGroup
                        from screen in screenGroup.DefaultIfEmpty()
                        where screen.IsActive == 1
                        join dept in context.MDepartments on settings.DeptId equals dept.Id into deptGroup
                        from dept in deptGroup.DefaultIfEmpty()
                        where dept.IsActive == 1 && settings.IsActive == 1 && settings.CompanyId == companyId && settings.MajorId == majorId && settings.ScreenId == screenId
                        select new ApprovalDeptSettingModel
                        {
                            Id = settings.Id,
                            CompanyId = settings.CompanyId,
                            DeptId = settings.DeptId,
                            MajorId = settings.MajorId,
                            ScreenId = settings.ScreenId,
                            ApprovalStep = settings.ApprovalStep,
                            CreateAt = settings.CreateAt,
                            CreateBy = settings.CreateBy,
                            CompanyName = company.CompanyName,
                            MajorName = major.MajorName,
                            ScreenName = screen.MajorName,
                            DeptName = dept.DeptName
                        };
            var listSetting = await query.OrderBy(x => x.ApprovalStep).ToListAsync();
            return listSetting;
        }

        public async Task Insert(ApprovalDeptSetting entity)
        {
            using var context = _context.CreateDbContext();
            if (entity == null)
            {
                throw new Exception("Không có bản ghi nào để thêm!");
            }

            context.ApprovalDeptSettings.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task Update(ApprovalDeptSetting approvalDeptSetting)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(approvalDeptSetting.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {approvalDeptSetting.Id}");
            }

            context.ApprovalDeptSettings.Update(approvalDeptSetting);
            await context.SaveChangesAsync();
        }

        public Task UpdateMulti(ApprovalDeptSetting[] entities)
        {
            throw new NotImplementedException();
        }
    }
}
