using DucAnhERP.Data;
using DucAnhERP.Models;
using DucAnhERP.Repository;
using DucAnhERP.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;

namespace DucAnhERP.Services
{
    public class PKKLMongCTronRepository : IPKKLMongCTronRepository
    {

        private readonly IDbContextFactory<ApplicationDbContext> _context;
      

        public PKKLMongCTronRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
            
        }
        public async Task<List<PKKLMongCTron>> GetAll()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.PKKLMongCTrons.ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }
        public async Task<PKKLMongCTron> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.PKKLMongCTrons.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            return entity;
        }
        public async Task<List<PKKLModel>> GetAllByVM(PKKLModel mModel)
        {
            try
            {
                using var context = _context.CreateDbContext();
                List<PKKLModel> data = new();
                var query = from a in context.PKKLMongCTrons
                            join b in context.PhanLoaiMongCTrons
                            on a.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop equals b.Id
                            orderby a.HangMuc ascending, a.CreateAt ascending
                            select new PKKLModel
                            {
                                Id = a.Id,
                                LoaiCauKien = b.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop ?? "",
                                LoaiCauKienId = a.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop,
                                LoaiBeTong = a.LoaiBeTong,
                                HangMuc = a.HangMuc,
                                HangMucCongTac = a.HangMucCongTac,
                                TenCongTac = a.TenCongTac,
                                DonVi = a.DonVi,
                                KTHH_D = a.KTHH_D,
                                KTHH_R = a.KTHH_R,
                                KTHH_C = a.KTHH_C,
                                KTHH_DienTich = a.KTHH_DienTich,
                                KTHH_GhiChu = a.KTHH_GhiChu,
                                KTHH_SLCauKien = a.KTHH_SLCauKien,
                                KTHH_KL1CK = a.KTHH_KL1CK,
                                TTCDT_CDai = a.TTCDT_CDai,
                                TTCDT_CRong = a.TTCDT_CRong,
                                TTCDT_CDay = a.TTCDT_CDay,
                                TTCDT_DienTich = a.TTCDT_DienTich,
                                TTCDT_SLCK = a.TTCDT_SLCK,
                                TTCDT_KL = a.TTCDT_KL,
                                KLKP_Sl = a.KLKP_Sl,
                                KL1CK_ChuaTruCC = a.KL1CK_ChuaTruCC,
                                KLCC1CK = a.KLCC1CK,
                                TKLCK_SauCC = a.TKLCK_SauCC
                            };

                data = query.ToList();
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }

        }
        public async Task<Double> GetSumTKLCK_SauCC(PKKLMongCTron input)
        {
            try
            {
                double sumTKLCK_SauCC = 0;
                using var context = _context.CreateDbContext();
                sumTKLCK_SauCC = context.PKKLMongCTrons.Where(item => item.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop == input.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop
                          && item.HangMuc == "I.Móng cống tròn"
                          && item.LoaiBeTong == input.LoaiBeTong).Sum(item => item.TKLCK_SauCC);
                return sumTKLCK_SauCC;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
        public async Task<PKKLMongCTron> GetTKLCK_SauCCByLCK(string id)
        {
            using var context = _context.CreateDbContext();
            var result = context.PKKLMongCTrons
                .Where(a => a.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop == id &&
                 a.HangMuc == "I.Sản xuất, vận chuyển, lắp đặt" &&
                 a.LoaiBeTong == "Bê tông thương phẩm")
                 .FirstOrDefault();

            return result;
        }
        public async Task<List<PKKLMongCTron>> GetExist(PKKLMongCTron searchData)
        {
            try
            {
                using var context = _context.CreateDbContext();

                // Thực hiện lọc dữ liệu dựa trên các thuộc tính của searchData
                var query = context.PKKLMongCTrons
                             .Where(item => (
                                    item.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop == searchData.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop &&
                                    item.LoaiBeTong == searchData.LoaiBeTong &&
                                    item.HangMuc == searchData.HangMuc &&
                                    item.HangMucCongTac == searchData.HangMucCongTac &&
                                    item.TenCongTac == searchData.TenCongTac &&
                                    item.DonVi == searchData.DonVi &&
                                    item.KTHH_D == searchData.KTHH_D &&
                                    item.KTHH_R == searchData.KTHH_R &&
                                    item.KTHH_C == searchData.KTHH_C &&
                                    item.KTHH_DienTich == searchData.KTHH_DienTich &&
                                    item.KTHH_GhiChu == searchData.KTHH_GhiChu &&
                                    item.KTHH_SLCauKien == searchData.KTHH_SLCauKien &&
                                    item.KTHH_KL1CK == searchData.KTHH_KL1CK &&
                                    item.TTCDT_CDai == searchData.TTCDT_CDai &&
                                    item.TTCDT_CRong == searchData.TTCDT_CRong &&
                                    item.TTCDT_CDay == searchData.TTCDT_CDay &&
                                    item.TTCDT_DienTich == searchData.TTCDT_DienTich &&
                                    item.TTCDT_SLCK == searchData.TTCDT_SLCK &&
                                    item.TTCDT_KL == searchData.TTCDT_KL &&
                                    item.KLKP_KL == searchData.KLKP_KL &&
                                    item.KLKP_Sl == searchData.KLKP_Sl &&
                                    item.KL1CK_ChuaTruCC == searchData.KL1CK_ChuaTruCC &&
                                    item.KLCC1CK == searchData.KLCC1CK &&
                                    item.TKLCK_SauCC == searchData.TKLCK_SauCC
                                          ));
                var result = await query.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }
        public async Task Update(PKKLMongCTron TKThepDeCong)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(TKThepDeCong.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {TKThepDeCong.Id}");
            }

            context.PKKLMongCTrons.Update(TKThepDeCong);
            await SaveChanges(context);
           
        }

        public async Task UpdateMulti(PKKLMongCTron[] PKKLMongCTron)
        {
            try
            {
                using var context = _context.CreateDbContext();

                string[] ids = PKKLMongCTron.Select(x => x.Id).ToArray();

                // Lấy danh sách các bản ghi từ database có ID nằm trong danh sách ids
                var listEntities = await context.PKKLMongCTrons
                    .Where(x => ids.Contains(x.Id))
                    .ToListAsync();
                foreach (var entity in listEntities)
                {
                    var updatedEntity = PKKLMongCTron.FirstOrDefault(x => x.Id == entity.Id);
                    if (updatedEntity != null)
                    {
                        context.Entry(entity).CurrentValues.SetValues(updatedEntity);
                    }
                }
                await SaveChanges(context);
                // Lưu các thay đổi vào database
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task DeleteById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await GetById(id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            context.Set<PKKLMongCTron>().Remove(entity);
            await SaveChanges(context);
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
            }
            return true;
        }
        public async Task Insert(PKKLMongCTron entity)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                // Lấy tất cả các bản ghi phù hợp và thực hiện xử lý trên client-side
                var maxFlagValue = await context.PKKLMongCTrons
                    .Where(x => x.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop == entity.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop && x.HangMuc == entity.HangMuc)
                    .Select(x => x.Flag)
                    .ToListAsync(); // Lấy danh sách các giá trị Flag

                // Kiểm tra nếu danh sách không có giá trị nào, trả về 0, ngược lại lấy giá trị lớn nhất
                var maxFlag = maxFlagValue.Any() ? maxFlagValue.Max() : 0;


                // Tăng giá trị Flag lên 1
                entity.Flag = maxFlag + 1;

                // Chèn bản ghi mới vào bảng
                context.PKKLMongCTrons.Add(entity);

                await SaveChanges(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public async Task<string> InsertLaterFlag(PKKLMongCTron entity, int FlagLast)
        {
            string id = "";
            try
            {
                using var context = _context.CreateDbContext();

                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                // Bước 1: Lấy danh sách các bản ghi có flag > FlagLast
                var recordsToUpdate = await context.PKKLMongCTrons
                    .Where(x => x.Flag > FlagLast && x.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop == entity.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop && x.HangMuc == entity.HangMuc)
                    .ToListAsync();

                // Bước 2: Tăng giá trị flag của các bản ghi đó thêm 1
                foreach (var record in recordsToUpdate)
                {
                    record.Flag += 1;
                }

                // Lưu các thay đổi cập nhật flag
                await context.SaveChangesAsync();

                // Bước 3: Đặt flag cho bản ghi mới bằng 3
                if (recordsToUpdate.Count() == 0)
                {
                    // Kiểm tra xem bảng có bản ghi nào không
                    var maxFlag = await context.PKKLMongCTrons.AnyAsync()
                                  ? await context.PKKLMongCTrons.MaxAsync(x => x.Flag)
                                  : 0;

                    // Tăng giá trị Flag lên 1
                    entity.Flag = maxFlag + 1;
                }
                else
                {
                    entity.Flag = FlagLast + 1;
                }

                // Bước 4: Chèn bản ghi mới vào bảng
                context.PKKLMongCTrons.Add(entity);

                await SaveChanges(context);
                
                // Trả về Id của bản ghi mới được thêm
                id = entity.Id ?? "";
                return id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return id;
            }
        }

        // Thêm phương thức SaveChanges() để lưu các thay đổi vào cơ sở dữ liệu
        public async Task SaveChanges(ApplicationDbContext context)
        {
            try
            {
                // Kiểm tra và xử lý các thay đổi trong DbContext
                var addedEntities = context.ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Added)
                    .ToList();

                var modifiedEntities = context.ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Modified)
                    .ToList();

                var deletedEntities = context.ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Deleted)
                    .ToList();

                // Xử lý thay đổi khi thêm
                if (addedEntities.Any())
                {
                    foreach (var addedEntity in addedEntities)
                    {
                        await HandleEntityAdd(addedEntity);
                    }
                }

                // Xử lý thay đổi khi sửa
                if (modifiedEntities.Any())
                {
                    foreach (var modifiedEntity in modifiedEntities)
                    {
                        await HandleEntityUpdate(modifiedEntity);
                    }
                }

                // Xử lý thay đổi khi xóa
                if (deletedEntities.Any())
                {
                    foreach (var deletedEntity in deletedEntities)
                    {
                        await HandleEntityDelete(deletedEntity);
                    }
                }

                // Lưu các thay đổi vào cơ sở dữ liệu
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred while saving changes: {ex.Message}");
                throw;
            }
        }

        // Xử lý khi thêm mới entity
        private async Task HandleEntityAdd(EntityEntry entityEntry)
        {
            var addedEntity = entityEntry.Entity as PKKLMongCTron;
            if (addedEntity != null)
            {
                // Kiểm tra điều kiện HangMuc và PhanLoaiMongCongTronCongHop
                if (addedEntity.HangMuc == "I.Móng cống tròn")
                {
                    using var context = _context.CreateDbContext();

                    // Lọc tất cả các bản ghi có ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop giống với addedEntity
                    var recordsToUpdate = await context.PKKLMongCTrons
                        .Where(x => x.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop == addedEntity.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop
                        && x.HangMuc == "II.Sản xuất + V.Chuyển B.Tông T.Phẩm móng cống tròn")
                        .ToListAsync();


                    // Cập nhật các cột TKLCK_SauCC cho từng bản ghi
                    foreach (var record in recordsToUpdate)
                    {
                        record.TKLCK_SauCC = await GetSumTKLCK_SauCC(addedEntity) + addedEntity.TKLCK_SauCC;
                    }

                    // Gọi phương thức UpdateMulti để cập nhật nhiều bản ghi
                    await UpdateMulti(recordsToUpdate.ToArray());
                    

                    // In thông tin của entity mới
                    Console.WriteLine($"Entity added: {addedEntity}");
                }
            }
        }
        // Xử lý khi sửa entity
        private async Task HandleEntityUpdate(EntityEntry entityEntry)
        {
            var modifiedEntity = entityEntry.Entity as PKKLMongCTron;
            if (modifiedEntity != null)
            {
                // Kiểm tra điều kiện HangMuc và PhanLoaiMongCongTronCongHop
                if (modifiedEntity.HangMuc == "I.Móng cống tròn")
                {
                    using var context = _context.CreateDbContext();

                    // Lọc tất cả các bản ghi có ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop giống với addedEntity
                    var recordsToUpdate = await context.PKKLMongCTrons
                        .Where(x => x.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop == modifiedEntity.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop
                        && x.HangMuc == "II.Sản xuất + V.Chuyển B.Tông T.Phẩm móng cống tròn")
                        .ToListAsync();


                    // Cập nhật các cột TKLCK_SauCC cho từng bản ghi
                    foreach (var record in recordsToUpdate)
                    {
                        record.TKLCK_SauCC = await GetSumTKLCK_SauCC(modifiedEntity) + modifiedEntity.TKLCK_SauCC;
                    }

                    // Gọi phương thức UpdateMulti để cập nhật nhiều bản ghi
                    await UpdateMulti(recordsToUpdate.ToArray());

                    // In thông tin của entity mới
                    Console.WriteLine($"Entity added: {modifiedEntity}");
                }
            }
        }

        // Xử lý khi xóa entity
        private async Task HandleEntityDelete(EntityEntry entityEntry)
        {
            var deletedEntity = entityEntry.Entity as PKKLMongCTron;
            if (deletedEntity != null)
            {
                // Kiểm tra điều kiện HangMuc và PhanLoaiMongCongTronCongHop
                if (deletedEntity.HangMuc == "I.Móng cống tròn")
                {
                    using var context = _context.CreateDbContext();

                    // Lọc tất cả các bản ghi có ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop giống với addedEntity
                    var recordsToUpdate = await context.PKKLMongCTrons
                        .Where(x => x.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop == deletedEntity.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop
                        && x.HangMuc == "II.Sản xuất + V.Chuyển B.Tông T.Phẩm móng cống tròn")
                        .ToListAsync();


                    // Cập nhật các cột TKLCK_SauCC cho từng bản ghi
                    foreach (var record in recordsToUpdate)
                    {
                        record.TKLCK_SauCC = await GetSumTKLCK_SauCC(deletedEntity) - deletedEntity.TKLCK_SauCC;
                    }

                    // Gọi phương thức UpdateMulti để cập nhật nhiều bản ghi
                    await UpdateMulti(recordsToUpdate.ToArray());

                    // In thông tin của entity mới
                    Console.WriteLine($"Entity added: {deletedEntity}");
                }
            }
        }

    }

}