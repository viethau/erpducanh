using DucAnhERP.Components.Pages.NghiepVuCongTrinh.BaoCao;
using DucAnhERP.Data;
using DucAnhERP.Models;
using DucAnhERP.Repository;
using DucAnhERP.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace DucAnhERP.Services
{

    public class PKKLHoGaRepository : IPKKLHoGaRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;

        public PKKLHoGaRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }
        public async Task<List<PKKLHoGa>> GetAll()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.PKKLHoGas.ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }
        public async Task<PKKLHoGa> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.PKKLHoGas.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            return entity;
        }
        public async Task<List<PKKLHoGaModel>> GetAllByVM(PKKLHoGaModel mModel)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var query = from a in context.PKKLHoGas
                            join b in context.PhanLoaiHoGas
                            on a.ThongTinChungHoGa_TenHoGaSauPhanLoai equals b.Id into plHoGaGroup
                            from b in plHoGaGroup.DefaultIfEmpty()
                            join dm in context.DSDanhMuc
                            on a.ThongTinChungHoGa_HinhThucHoGa equals dm.Id into dmgroup
                            from dm in dmgroup.DefaultIfEmpty()
                            join dm1 in context.DSDanhMuc
                            on a.ThongTinChungHoGa_KetCauMuMo equals dm1.Id into dm1group
                            from dm1 in dm1group.DefaultIfEmpty()
                            orderby a.CreateAt
                            select new PKKLHoGaModel
                            {
                                Id = a.Id,
                                Flag = a.Flag,

                                ThongTinChungHoGa_TenHoGaSauPhanLoai = a.ThongTinChungHoGa_TenHoGaSauPhanLoai,
                                ThongTinChungHoGa_TenHoGaSauPhanLoai_Name = b.ThongTinChungHoGa_TenHoGaSauPhanLoai,
                                
                                ThongTinChungHoGa_HinhThucHoGa = a.ThongTinChungHoGa_HinhThucHoGa,
                                ThongTinChungHoGa_HinhThucHoGa_Name = dm.Ten,
                                ThongTinChungHoGa_KetCauMuMo = a.ThongTinChungHoGa_KetCauMuMo,
                                ThongTinChungHoGa_KetCauMuMo_Name = dm1.Ten,
                                LoaiBeTong = a.LoaiBeTong,
                                HangMuc = a.HangMuc,
                                HangMucCongTac = a.HangMucCongTac,
                                TenCongTac = a.TenCongTac,
                                DonVi = a.DonVi,
                                BeTongLotMong_D = a.BeTongLotMong_D,
                                BeTongLotMong_R = a.BeTongLotMong_R,
                                BeTongLotMong_C = a.BeTongLotMong_C,
                                KTHH_DienTich = a.KTHH_DienTich,
                                GhiChu = a.GhiChu,
                                SLCauKien = a.SLCauKien,
                                KL1CK = a.KL1CK,
                                TTCDT_CDai = a.TTCDT_CDai,
                                TTCDT_Crong = a.TTCDT_Crong,
                                TTCDT_Cday = a.TTCDT_Cday,
                                TTCDT_DT = a.TTCDT_DT,
                                TTCDT_SLCK = a.TTCDT_SLCK,
                                TTCDT_KL = a.TTCDT_KL,
                                KLKP_KL = a.KLKP_KL,
                                KLKP_Sl = a.KLKP_Sl,
                                KL1CK_ChuaTruCC = a.KL1CK_ChuaTruCC,
                                KLCC1CK = a.KLCC1CK,
                                TKLCK_SauCC = a.TKLCK_SauCC,

                                CreateAt = a.CreateAt,
                                CreateBy = a.CreateBy,
                                IsActive = a.IsActive,
                            };

                if (!string.IsNullOrEmpty(mModel.ThongTinChungHoGa_TenHoGaSauPhanLoai))
                {
                    query = query.Where(x => x.ThongTinChungHoGa_TenHoGaSauPhanLoai == mModel.ThongTinChungHoGa_TenHoGaSauPhanLoai);
                }
               
                var data = await query.ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }

        }
        public async Task<List<PKKLHoGa>> GetExist(PKKLHoGa searchData)
        {
            try
            {
                using var context = _context.CreateDbContext();

                // Thực hiện lọc dữ liệu dựa trên các thuộc tính của searchData
                var query = context.PKKLHoGas
                             .Where(item => (
                                    item.ThongTinChungHoGa_TenHoGaSauPhanLoai == searchData.ThongTinChungHoGa_TenHoGaSauPhanLoai &&
                                    item.ThongTinChungHoGa_HinhThucHoGa == searchData.ThongTinChungHoGa_HinhThucHoGa &&
                                    item.ThongTinChungHoGa_KetCauMuMo == searchData.ThongTinChungHoGa_KetCauMuMo &&
                                    item.LoaiBeTong == searchData.LoaiBeTong &&
                                    item.HangMuc == searchData.HangMuc &&
                                    item.HangMucCongTac == searchData.HangMucCongTac &&
                                    item.TenCongTac == searchData.TenCongTac &&
                                    item.DonVi == searchData.DonVi &&
                                    item.BeTongLotMong_D == searchData.BeTongLotMong_D &&
                                    item.BeTongLotMong_R == searchData.BeTongLotMong_R &&
                                    item.BeTongLotMong_C == searchData.BeTongLotMong_C &&
                                    item.KTHH_DienTich == searchData.KTHH_DienTich &&
                                    item.GhiChu == searchData.GhiChu &&
                                    item.SLCauKien == searchData.SLCauKien &&
                                    item.KL1CK == searchData.KL1CK &&
                                    item.TTCDT_CDai == searchData.TTCDT_CDai &&
                                    item.TTCDT_Crong == searchData.TTCDT_Crong &&
                                    item.TTCDT_Cday == searchData.TTCDT_Cday &&
                                    item.TTCDT_DT == searchData.TTCDT_DT &&
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
        public async Task Update(PKKLHoGa PKKLHoGa)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(PKKLHoGa.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {PKKLHoGa.Id}");
            }

            context.PKKLHoGas.Update(PKKLHoGa);
            await context.SaveChangesAsync();
        }
        public async Task UpdateMulti(PKKLHoGa[] PKKLHoGa)
        {
            using var context = _context.CreateDbContext();
            string[] ids = PKKLHoGa.Select(x => x.Id).ToArray();
            var listEntities = await context.PKKLHoGas.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.PKKLHoGas.Update(entity);
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

            context.Set<PKKLHoGa>().Remove(entity);
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
            }
            return true;
        }
        public async Task Insert(PKKLHoGa entity)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                // Lấy tất cả các bản ghi phù hợp và thực hiện xử lý trên client-side
                var maxFlagValue = await context.PKKLHoGas
                    .Where(x => (x.ThongTinChungHoGa_TenHoGaSauPhanLoai == entity.ThongTinChungHoGa_TenHoGaSauPhanLoai) &&( x.HangMuc == entity.HangMuc))
                    .Select(x => x.Flag)
                    .ToListAsync(); // Lấy danh sách các giá trị Flag

                // Kiểm tra nếu danh sách không có giá trị nào, trả về 0, ngược lại lấy giá trị lớn nhất
                var maxFlag = maxFlagValue.Any() ? maxFlagValue.Max() : 0;


                // Tăng giá trị Flag lên 1
                entity.Flag = maxFlag + 1;

                // Chèn bản ghi mới vào bảng
                context.PKKLHoGas.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public async Task<string> InsertLaterFlag(PKKLHoGa entity, int FlagLast)
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
                var recordsToUpdate = await context.PKKLHoGas
                    .Where(x => x.Flag > FlagLast && x.ThongTinChungHoGa_TenHoGaSauPhanLoai == entity.ThongTinChungHoGa_TenHoGaSauPhanLoai)
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
                    var maxFlag = await context.PKKLHoGas.AnyAsync()
                                  ? await context.PKKLHoGas.MaxAsync(x => x.Flag)
                                  : 0;

                    // Tăng giá trị Flag lên 1
                    entity.Flag = maxFlag + 1;
                }
                else
                {
                    entity.Flag = FlagLast + 1;
                }

                // Bước 4: Chèn bản ghi mới vào bảng
                context.PKKLHoGas.Add(entity);

                // Lưu bản ghi mới vào cơ sở dữ liệu
                await context.SaveChangesAsync();
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

    }
}
