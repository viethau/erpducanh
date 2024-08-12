using DucAnhERP.Data;
using DucAnhERP.Models;
using DucAnhERP.Repository;
using DucAnhERP.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace DucAnhERP.Services
{
    public class ApprovalStepSettingRepository : IApprovalStepSettingRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;

        public ApprovalStepSettingRepository(IDbContextFactory<ApplicationDbContext> context)
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

        public async Task DeleteById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await GetById(id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }
            entity.IsActive = 0;
            context.ApprovalStepSettings.Update(entity);
            await context.SaveChangesAsync();
        }

        public Task<List<ApprovalStepSetting>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ApprovalStepSetting> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.ApprovalStepSettings.Where(x => x.Id.Equals(id) && x.IsActive == 1).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            return entity;
        }

        public async Task Insert(ApprovalStepSetting entity)
        {
            using var context = _context.CreateDbContext();
            if (entity == null)
            {
                throw new Exception("Không có bản ghi nào để thêm!");
            }

            context.ApprovalStepSettings.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task Update(ApprovalStepSetting approvalStepSetting)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(approvalStepSetting.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {approvalStepSetting.Id}");
            }

            context.ApprovalStepSettings.Update(approvalStepSetting);
            await context.SaveChangesAsync();
        }

        public Task UpdateMulti(ApprovalStepSetting[] entities)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateApprovalStepSetting(List<ApprovalStepWrapper> approvalRowWrappers, DateTime baseTime)
        {
            if (approvalRowWrappers.Count == 0)
            {
                return false;
            }
            using var context = _context.CreateDbContext();
            var companyId = approvalRowWrappers.First().ApprovalRow.CompanyId;
            var majorId = approvalRowWrappers.First().ApprovalRow.MajorId;
            var screenId = approvalRowWrappers.First().ApprovalRow.ScreenId;
            var deptId = approvalRowWrappers.First().ApprovalRow.DeptId;
            var operation = approvalRowWrappers.First().ApprovalRow.OperationType;

            // Xóa cài đặt cũ
            var listToDelete = await GetSetApprovalStep(companyId, majorId, deptId, operation, screenId);
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


        public async Task<List<ApprovalStepSettingModel>> GetSetApprovalStep(string companyId, string majorId, string deptId, int operation, string screenId)
        {
            using var context = _context.CreateDbContext();
            var query = from settings in context.ApprovalStepSettings
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
                        where dept.IsActive == 1 && settings.IsActive == 1 && settings.CompanyId == companyId && settings.MajorId == majorId && settings.ScreenId == screenId && settings.DeptId == deptId && settings.OperationType == operation
                        select new ApprovalStepSettingModel
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
                            DeptName = dept.DeptName,
                            Content = settings.Content,
                            OperationType = settings.OperationType
                        };
            var listSetting = await query.OrderBy(x => x.ApprovalStep).ToListAsync();
            return listSetting;
        }

    }
}
