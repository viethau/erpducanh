using DucAnhERP.Repository;
using DucAnhERP.Data;
using DucAnhERP.Models;
using Microsoft.EntityFrameworkCore;

namespace DucAnhERP.Services
{
    public class ApprovalRepository : IApprovalRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;
        public ApprovalRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }

        public async Task<ApprovalStepSetting> GetApprovalStepSettingById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.ApprovalStepSettings.Where(x => x.Id.Equals(id) && x.IsActive != 100).FirstOrDefaultAsync();
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi.");
            }
            return entity;
        }

        //Lưu phòng ban, thứ tự duyệt, fist id, last id

        //checked quyền
        //get it tiep theo
        //gán id tiếp theo vào bảng
        //trường hợp đã là cuối cùng thì update trạng thái
        //trường hợp thêm mới hoặc sửa thì gét ID đầu tiên

        //hàm getID first
        //hàm getID tiếp theo
        //thêm cột trạng thái text
        //thêm cột id duyệt
        //thêm cột id duyệt cuối
        //Thêm cột thứ tự phòng ban duyệt

        //khi ID duyệt bằng ID cuối chỉ cần check quyền

        //thiết kế bảng phòng ban theo chi nhánh
        //phân quyền phòng ban
        //duyệt phòng ban


        //không duyệt
        //check quyền duyệt
        //update dữ liệu: lấy trạng thái bằng 3 mới nhất tại bảng log
        //viết tại service của mỗi bảng


        public async Task<bool> CheckApproval(string companyId, string deptId, ApplicationUser user, string approvalId)
        {
            using var context = _context.CreateDbContext();
            try
            {
                if (user.CreateBy == "symtem")
                {
                    return true;
                }
                else
                {
                    var result = await (from a in context.MajorUserApprovalDetails
                                        where a.UserId.Equals(user.Id)
                                              && a.CompanyId.Equals(companyId)
                                              && a.ApprovalId.Equals(approvalId)
                                              && a.DayinWeek.Equals(DateTime.Now.DayOfWeek)
                                        select a.Id).CountAsync();
                    return result > 0;
                }
            }
            catch (Exception)
            {
                var result = await (from p in context.ApprovalStepSettings
                                    where p.Id.Equals(approvalId)
                                    select p).FirstOrDefaultAsync();
                throw new Exception($"Bạn không có quyền " + result.Content + " trong thời gian này.");
            }
        }
        public async Task<bool> CheckPermission(string groupId, string companyId, ApplicationUser user, string permissionId)
        {
            using var context = _context.CreateDbContext();
            try
            {
                if (user.CreateBy == "symtem" && user.GroupId == groupId)
                {
                    return true;
                }
                else
                {
                    var result = await (from a in context.MajorUserPermissions
                                        where a.UserId.Equals(user)
                                              && a.GroupId.Equals(groupId)
                                              && a.CompanyId.Equals(companyId)
                                              && a.PermissionId.Equals(permissionId)
                                              && a.DayInWeek.Equals(DateTime.Now.DayOfWeek)
                                        select a.Id).CountAsync();
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw new Exception($"Bạn không có quyền để thực hiện hành động này");
            }
        }

        public async Task<ApprovalStepSetting> GetFirstApprovalStep(string companyId, string majorId, string permissionId)
        {
            using var context = _context.CreateDbContext();
            var entity = await (from p in context.ApprovalStepSettings
                                join q in context.ApprovalDeptSettings on p.MajorId equals q.MajorId
                                join chinhanh in context.ChiNhanhs on p.CompanyId equals chinhanh.Id
                                join parentMajor in context.Majors on p.ParentMajorId equals parentMajor.Id
                                join major in context.Majors on p.MajorId equals major.Id
                                join department in context.Departments on p.DeptId equals department.Id
                                join permission in context.Permissions on p.PermissionId equals permission.Id
                                where p.CompanyId.Equals(companyId)
                                    && q.CompanyId.Equals(companyId)
                                    && p.MajorId.Equals(majorId)
                                    && p.PermissionId.Equals(permissionId)
                                    && p.ApprovalStep == 1
                                    && q.ApprovalStep == 1
                                    && p.DeptId == q.DeptId
                                    && p.IsActive != 100
                                select new ApprovalStepSetting
                                {
                                    Id = p.Id,
                                    IdMain = p.IdMain,
                                    CompanyId = chinhanh.TenChiNhanh,
                                    DeptId = department.DeptName,
                                    ParentMajorId = parentMajor.MajorName,
                                    MajorId = major.MajorName,
                                    PermissionId = permission.PermissionName,
                                    Content = p.Content,
                                    ApprovalStep = p.ApprovalStep,
                                    GroupId = p.GroupId,
                                    Ordinarily = p.Ordinarily,
                                    CreateAt = p.CreateAt,
                                    CreateBy = p.CreateBy,
                                    IsActive = p.IsActive,
                                    ApprovalUserId = p.ApprovalUserId,
                                    DateApproval = p.DateApproval,
                                    DepartmentId = p.DeptId,
                                    DepartmentOrder = p.DepartmentOrder,
                                    ApprovalOrder = p.ApprovalOrder,
                                    ApprovalId = p.ApprovalId,
                                    LastApprovalId = p.LastApprovalId,
                                    IsStatus = p.IsStatus
                                }).FirstOrDefaultAsync();
            if (entity == null)
            {
                throw new Exception($"Bạn chưa cài đặt duyệt cho nghiệp vụ này.");
            }
            return entity;
        }

        public async Task<ApprovalStepSetting> GetNextApprovalStep(string companyId, string majorId, string permissionId, string departmentId, int departmentOrder, int approvalOrder)
        {
            using var context = _context.CreateDbContext();

            var entity = await (from p in context.ApprovalStepSettings
                                where p.CompanyId.Equals(companyId)
                                    && p.MajorId.Equals(majorId)
                                    && p.PermissionId.Equals(permissionId)
                                    && p.DeptId.Equals(departmentId)
                                    && p.ApprovalStep == approvalOrder + 1
                                    && p.IsActive != 100
                                select p).FirstOrDefaultAsync();
            if (entity == null)
            {
                var depentity = await (from p in context.ApprovalDeptSettings
                                       where p.CompanyId.Equals(companyId)
                                           && p.MajorId.Equals(majorId)
                                           && p.ApprovalStep.Equals(departmentOrder + 1)
                                           && p.IsActive != 100
                                       select p).FirstOrDefaultAsync();

                entity = await (from p in context.ApprovalStepSettings
                                where p.CompanyId.Equals(companyId)
                                    && p.MajorId.Equals(majorId)
                                    && p.PermissionId.Equals(permissionId)
                                    && p.DeptId.Equals(depentity.DeptId)
                                    && p.ApprovalStep == 1
                                    && p.IsActive != 100
                                select p).FirstOrDefaultAsync();
            }
            if (entity == null)
            {
                throw new Exception($"Bạn chưa cài đặt duyệt cho nghiệp vụ này.");
            }
            return entity;
        }

        public async Task<ApprovalStepSetting> GetLastApprovalStep(string companyId, string majorId, string permissionId)
        {
            using var context = _context.CreateDbContext();

            var query = await (from p in context.ApprovalDeptSettings
                               where p.CompanyId.Equals(companyId)
                               && p.MajorId.Equals(majorId)
                               select p).OrderByDescending(p => p.ApprovalStep).Take(1).FirstOrDefaultAsync();

            var entity = await (from p in context.ApprovalStepSettings
                                where p.CompanyId.Equals(companyId)
                                    && p.MajorId.Equals(majorId)
                                    && p.PermissionId.Equals(permissionId)
                                    && p.DeptId.Equals(query.DeptId)
                                    && p.DeptOrder.Equals(query.ApprovalStep)
                                    && p.IsActive != 100
                                select p).OrderByDescending(p => p.ApprovalStep).Take(1).FirstOrDefaultAsync();

            if (query == null || entity == null)
            {
                throw new Exception($"Bạn chưa cài đặt duyệt cho nghiệp vụ này.");
            }
            return entity;
        }

        public async Task<List<ApprovalStaffSetting>> GetApprovalStaffByApprovalStepId(string approvalStepId)
        {
            using var context = _context.CreateDbContext();
            var entity = await (from p in context.ApprovalStaffSettings
                                join q in context.ApplicationUsers on p.UserId equals q.Id
                                where p.ApprovalStepId.Equals(approvalStepId)
                                && p.IsActive != 100
                                && q.IsActive != 100
                                select new ApprovalStaffSetting
                                {
                                    Id = p.Id,
                                    CompanyId = p.CompanyId,
                                    DeptId = p.DeptId,
                                    UserId = p.UserId,
                                    ParentMajorId = p.ParentMajorId,
                                    MajorId = p.MajorId,
                                    ApprovalStepId = p.ApprovalStepId,
                                    Content = p.Content,
                                    GroupId = p.GroupId,
                                    CreateAt = p.CreateAt,
                                    CreateBy = q.Email,
                                    IsActive = p.IsActive
                                }).ToListAsync();
            return entity;
        }
    }
}
