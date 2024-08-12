using DucAnhERP.Repository;
using DucAnhERP.ViewModel;
using DucAnhERP.Data;
using DucAnhERP.Models;
using DucAnhERP.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace DucAnhERP.Services
{
    public class MajorRepository : IMajorRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;

        public MajorRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }

        public async Task<MMajor> AddMajor(MMajor mMajor)
        {
            using var context = _context.CreateDbContext();
            if (mMajor == null) return null;

            mMajor.Id = Guid.NewGuid().ToString();
            mMajor.CreateBy = "anhtuan.vp98@gmail.com";
            mMajor.CreateAt = DateTime.Now;
            mMajor.IsActive = 1;

            var newMajor = context.MMajors.Add(mMajor).Entity;
            await context.SaveChangesAsync();

            return newMajor;

        }

        public async Task<List<MajorModel>> GetAll(MajorModel majorModel)
        {
            using var context = _context.CreateDbContext();
            var query = from major in context.MMajors
                        join parent in context.MMajors.Where(p => p.IsActive == 1) // Lọc dữ liệu của parent trước khi ghép nối
                        on major.ParentId equals parent.Id into parentGroup
                        from parent in parentGroup.DefaultIfEmpty()
                        where major.IsActive == 1
                        select new MajorModel
                        {
                            Id = major.Id,
                            ParentId = major.ParentId,
                            ParentName = parent.MajorName != null ? parent.MajorName : "Nghiệp vụ cha",
                            MajorName = major.MajorName,
                            Table = major.Table,
                            Order = major.Order,
                            CreateAt = major.CreateAt,
                            CreateBy = major.CreateBy,
                            IsActive = major.IsActive
                        };

            if (!string.IsNullOrEmpty(majorModel.ParentId))
            {
                query = query.Where(m => m.ParentId == majorModel.ParentId);
            }

            if (!string.IsNullOrEmpty(majorModel.MajorName))
            {
                query = query.Where(m => m.MajorName.Contains(majorModel.MajorName));
            }

            if (!string.IsNullOrEmpty(majorModel.Table))
            {
                query = query.Where(m => m.Table == majorModel.Table);
            }

            var data = await query.ToListAsync();
            return data;
        }

        public async Task<List<MMajor>> GetAllParentMajor()
        {
            using var context = _context.CreateDbContext();
            var query = context.MMajors
                .Select(selectedMajor => new MMajor()
                {
                    Id = selectedMajor.Id,
                    ParentId = selectedMajor.ParentId,
                    MajorName = selectedMajor.MajorName,
                    Order = selectedMajor.Order,
                    Table = selectedMajor.Table
                })
                .Where(selectedMajor => selectedMajor.ParentId == null);

            var data = await query.ToListAsync();
            return data;
        }

        public async Task<MMajor> GetMajorByName(string majorName)
        {
            using var context = _context.CreateDbContext();
            var major = await context.MMajors.Where(x => x.MajorName == majorName && x.IsActive == 1).FirstOrDefaultAsync();
            if (major == null) return null;

            return major;
        }

        public async Task<MMajor> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.MMajors.Where(x => x.Id.Equals(id) && x.IsActive == 1).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            return entity;
        }

        public async Task<List<MMajor>> GetMajorByParentId(string id)
        {
            using var context = _context.CreateDbContext();
            var majors = await context.MMajors.Where(x => x.ParentId == id && x.IsActive == 1).ToListAsync();
            return majors;
        }

        public Task<List<MMajor>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task Update(MMajor major)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(major.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {major.Id}");
            }

            context.MMajors.Update(major);
            await context.SaveChangesAsync();
        }

        public async Task UpdateMulti(MMajor[] entities)
        {
            using var context = _context.CreateDbContext();
            string[] ids = entities.Select(x => x.Id).ToArray();
            var listEntities = await context.MMajors.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.MMajors.Update(entity);
            }
            await context.SaveChangesAsync();
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
            context.MMajors.Update(entity);
            await context.SaveChangesAsync();
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

        public async Task Insert(MMajor entity)
        {
            using var context = _context.CreateDbContext();
            if (entity == null)
            {
                throw new Exception("Không có bản ghi nào để thêm!");
            }

             context.MMajors.Add(entity);
            await context.SaveChangesAsync();
        }
    }
}
