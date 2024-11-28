using DucAnhERP.Repository;
using DucAnhERP.ViewModel;
using DucAnhERP.Data;
using DucAnhERP.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design;

namespace DucAnhERP.Services
{
    public class PermissionControlRepository : IPermissionControlRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;
        private readonly IMajorUserPermissionRepository _majorUserPermissionRepository;
        private readonly IEmailHistoryRepository _emailHistoryRepository;

        public PermissionControlRepository(IDbContextFactory<ApplicationDbContext> context, IMajorUserPermissionRepository majorUserPermissionRepository, IEmailHistoryRepository emailHistoryRepository)
        {
            _context = context;
            _majorUserPermissionRepository = majorUserPermissionRepository;
            _emailHistoryRepository = emailHistoryRepository;
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
            context.Set<MPermissionControl>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<List<MPermissionControl>> GetAll()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.MPermissionControls.ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }

        public async Task<List<MPermissionControl>> GetExist(MPermissionControl input)
        {
            using var context = _context.CreateDbContext();

            var query = context.MPermissionControls
                     .Where(item =>
                     item.CompanyId == input.CompanyId &&
                         item.MajorId == input.MajorId &&
                        item.UserId == input.UserId)
                     .OrderByDescending(permission => permission.CreateAt);

            // Lấy kết quả dưới dạng danh sách
            var data = await query.ToListAsync();
            return data;

        }

        public async Task<List<PermissionControlModel>> GetAllByVM(PermissionControlModel permissionControlModel)
        {
            using var context = _context.CreateDbContext();
            var query = from perContr in context.MPermissionControls
                        join company in context.MCompanies
                        on perContr.CompanyId equals company.Id into gr1
                        from company in gr1.DefaultIfEmpty()
                        join major in context.MMajors
                       on perContr.MajorId equals major.Id into gr2
                        from major in gr2.DefaultIfEmpty()
                        join user in context.ApplicationUsers
                      on perContr.UserId equals user.Id into gr3
                        from user in gr3.DefaultIfEmpty()
                        join parentM in context.MMajors
                      on major.ParentId equals parentM.Id into gr4
                        from parentM in gr4.DefaultIfEmpty()

                        orderby perContr.CreateAt descending
                        select new PermissionControlModel
                        {
                            Id = perContr.Id,
                            CompanyId = perContr.CompanyId,
                            CompanyName = company.CompanyName,
                            ParentMajorId = major.ParentId??"",
                            ParentMajorName =parentM.MajorName,
                            MajorId = perContr.MajorId,
                            MajorName = major.MajorName,
                            UserId = perContr.UserId,
                            UserName = user.UserName,
                            CreateAt = perContr.CreateAt,
                            CreateBy = perContr.CreateBy,
                            IsActive = perContr.IsActive
                        };
            if (!string.IsNullOrEmpty(permissionControlModel.CompanyId))
            {
                query = query.Where(m => m.CompanyId == permissionControlModel.CompanyId);
            }

            if (!string.IsNullOrEmpty(permissionControlModel.ParentMajorId))
            {
                query = query.Where(m => m.ParentMajorId == permissionControlModel.ParentMajorId);
            }

            if (!string.IsNullOrEmpty(permissionControlModel.MajorId))
            {
                query = query.Where(m => m.MajorId == permissionControlModel.MajorId);
            }

            if (!string.IsNullOrEmpty(permissionControlModel.UserId))
            {
                query = query.Where(m => m.UserId == permissionControlModel.UserId);
            }

            var data = await query.ToListAsync();
            return data;
        }

        public async Task<MPermissionControl> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.MPermissionControls.Where(x => x.Id.Equals(id) && x.IsActive == 1).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            return entity;
        }

        public async Task Insert(MPermissionControl entity)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                context.MPermissionControls.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public async Task<bool> InsertPermission(MajorUserPermissionModel majorUserPermission, List<PermissionModel> corePermission)
        {
            using var context = _context.CreateDbContext();
            using (SqlConnection connection = new SqlConnection(context.Database.GetConnectionString()))
            {
                connection.Open();
                var transaction = connection.BeginTransaction();
                try
                {
                    // Đăng ký mới table m_permission_control
                    var mPermissionControlModel = new MPermissionControl()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CompanyId = majorUserPermission.CompanyId,
                        MajorId = majorUserPermission.MajorId,
                        UserId = majorUserPermission.UserId,
                        CreateAt = DateTime.Now,
                        CreateBy = "test.vp@gmail.com",
                        IsActive = 1
                    };

                    context.MPermissionControls.Add(mPermissionControlModel);
                    await context.SaveChangesAsync();

                    // Xóa logic record cũ của table m_major_user_permission
                    await _majorUserPermissionRepository.DeleteExistPermission(majorUserPermission.CompanyId, majorUserPermission.MajorId, majorUserPermission.UserId);


                    // Đăng ký mới table m_major_user_permission
                    foreach (var permission in corePermission)
                    {
                        if (permission.IsChecked)
                        {
                            var mMajorUserPermissionModel = new MMajorUserPermission()
                            {
                                Id = Guid.NewGuid().ToString(),
                                CompanyId = majorUserPermission.CompanyId,
                                MajorId = majorUserPermission.MajorId,
                                UserId = majorUserPermission.UserId,
                                
                                PermissionId = permission.Id,
                                CreateAt = DateTime.Now,
                                CreateBy = "anhtuan.vp98@gmail.com",
                             
                                IsActive = 1
                            };

                            await _majorUserPermissionRepository.Insert(mMajorUserPermissionModel);
                        }

                    }

                    // Tạo mới đối tượng
                    var emailHistory = new EmailHistory();

                    // Lấy nội dung mail từ template
                    //var content = await HttpClient.GetStringAsync("/templates/confirm_login.html");

                    // Thay thế các tham số
                    //var replaceContent = new StringBuilder(content)
                    //.Replace("@confirmCode", code)
                    //.ToString();

                    // Gán giá trị cho các thuộc tính
                    emailHistory.Id = Guid.NewGuid().ToString();
                    emailHistory.Receiver = "anhtuan.vp98@gmail.com";
                    emailHistory.Subject = "Cài đặt phân quyền thành công";
                    emailHistory.Content = "Tạo Quyền";
                    emailHistory.CompanyId = "496264a8-b53a-450a-9464-8b99f9ed5952";
                    emailHistory.MajorId = "ff9590bc-7b3b-4f9b-a7fd-913c248beadf";
                    emailHistory.ScreenId = "7d3ea4cc-b3dc-4adc-8411-a7f033935284";
                    emailHistory.CreateAt = DateTime.Now;
                    emailHistory.CreateBy = "Người quản trị hệ thống";

                    // Thực hiện gửi mail
                    await _emailHistoryRepository.SendEmail(emailHistory);

                    transaction.Commit();

                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;

                }
                finally { connection.Close(); }
            }



            return true;
        }

        public async Task<MPermissionControl> IsExistPermission(string companyId, string majorId, string userId)
        {
            using var context = _context.CreateDbContext();
            var major = await context.MPermissionControls.Where(x => x.CompanyId == companyId && x.MajorId == majorId && x.UserId == userId && x.IsActive == 1).FirstOrDefaultAsync();
            return major;
        }

        public async Task Update(MPermissionControl mPermission)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(mPermission.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {mPermission.Id}");
            }
            context.MPermissionControls.Update(mPermission);
            await context.SaveChangesAsync();
        }

        public async Task UpdateMulti(MPermissionControl[] entities)
        {
            using var context = _context.CreateDbContext();
            string[] ids = entities.Select(x => x.Id).ToArray();
            var listEntities = await context.MPermissionControls.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.MPermissionControls.Update(entity);
            }
            await context.SaveChangesAsync();
        }
    }
}
