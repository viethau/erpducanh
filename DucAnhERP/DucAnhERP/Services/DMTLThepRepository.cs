using DucAnhERP.Components.Pages.NghiepVuCongTrinh.TKThep;
using DucAnhERP.Data;
using DucAnhERP.Helpers;
using DucAnhERP.Models;
using DucAnhERP.Repository;
using DucAnhERP.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DucAnhERP.Services
{
    public class DMTLThepRepository : IDMTLThepRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;
        private readonly TKThepHoGaRepository _tKThepHoGaRepository;
        private readonly TKThepTamDanRepository _tKThepTamDanRepository;
        private readonly TKThepCTronRepository _tKThepCTronRepository;
        private readonly TKThepMongCTronRepository _tKThepMongCTronRepository;
        private readonly TKThepDeCongRepository _tKThepDeCongRepository;
        private readonly TKThepCHopRepository _tKThepCHopRepository;
        private readonly TKThepMongCHopRepository _tKThepMongCHopRepository;
        private readonly TKThepTDanCHopRepository _tKThepTDanCHopRepository;
        private readonly TKThepRXayRepository _tKThepRXayRepository;
        private readonly TKThepTDanRXayRepository _tKThepTDanRXayRepository;
        private readonly TKThepTChongRepository _tKThepTChongRepository;
        private readonly TKThepRBTongRepository _tKThepRBTongRepository;
        private readonly TKThepTDRBTongRepository _tKThepTDRBTongRepository;
        public DMTLThepRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
            _tKThepHoGaRepository = new TKThepHoGaRepository(context);
            _tKThepTamDanRepository = new TKThepTamDanRepository(context);
            _tKThepCTronRepository = new TKThepCTronRepository(context);
            _tKThepMongCTronRepository = new TKThepMongCTronRepository(context);
            _tKThepDeCongRepository = new TKThepDeCongRepository(context);
            _tKThepCHopRepository = new TKThepCHopRepository(context);
            _tKThepMongCHopRepository = new TKThepMongCHopRepository(context);
            _tKThepTDanCHopRepository = new TKThepTDanCHopRepository(context);
            _tKThepRXayRepository = new TKThepRXayRepository(context);
            _tKThepTDanRXayRepository = new TKThepTDanRXayRepository(context);
            _tKThepTChongRepository = new TKThepTChongRepository(context);
            _tKThepRBTongRepository = new TKThepRBTongRepository(context);
            _tKThepTDRBTongRepository = new TKThepTDRBTongRepository(context);
        }
        public async Task<List<DMThep>> GetAll()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.DMTLTheps.ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }
        public async Task<DMThep> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.DMTLTheps.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            return entity;
        }
        public async Task<List<DMTLThepModel>> GetAllByVM(DMTLThepModel mModel)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var query = from tb1 in context.DMTLTheps
                            join tb2 in context.DSDanhMuc
                            on tb1.ChungLoaiThep equals tb2.Id
                            orderby tb1.CreateAt
                            select new DMTLThepModel
                            {
                                Id = tb1.Id,
                                Flag = tb1.Flag,
                                ChungLoaiThep = tb1.ChungLoaiThep,
                                ChungLoaiThep_Name = tb2.Ten,
                                DuongKinh = tb1.DuongKinh,
                                DonVi = tb1.DonVi,
                                TrongLuong = tb1.TrongLuong,
                                CreateAt = tb1.CreateAt,
                                CreateBy = tb1.CreateBy,
                                IsActive = tb1.IsActive,
                            };
                if (!string.IsNullOrEmpty(mModel.ChungLoaiThep))
                {
                    query = query.Where(x => x.ChungLoaiThep == mModel.ChungLoaiThep);
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
        public async Task<List<DMThep>> GetExist(DMThep searchData)
        {
            try
            {
                using var context = _context.CreateDbContext();

                // Thực hiện lọc dữ liệu dựa trên các thuộc tính của searchData
                var query = context.DMTLTheps
                             .Where(item => (
                                    item.ChungLoaiThep == searchData.ChungLoaiThep &&
                                    item.DuongKinh == searchData.DuongKinh 
                                    //&& item.DonVi == searchData.DonVi
                                    //&&item.TrongLuong == searchData.TrongLuong
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
        public async Task<DMThep?> GetTrongLuong(string LoaiThep, string DKCD)
        {
            using var context = _context.CreateDbContext();
            var result = await context.DMTLTheps
                .FirstOrDefaultAsync(x => x.ChungLoaiThep == LoaiThep && x.DuongKinh == DKCD);
            return result;
        }
        public async Task<bool> CheckUsingId(string loaiThep, string kichThuoc)
        {
            using var context = _context.CreateDbContext();

            // Danh sách các bảng cần kiểm tra
            var checks = new List<Func<Task<bool>>>
                {
                    async () => await context.TKThepCHops.AnyAsync(x => x.LoaiThep == loaiThep && x.DKCD.ToString() == kichThuoc),
                    async () => await context.TKThepCTrons.AnyAsync(x => x.LoaiThep == loaiThep && x.DKCD.ToString() == kichThuoc),
                    async () => await context.TKThepDeCongs.AnyAsync(x => x.LoaiThep == loaiThep && x.DKCD.ToString() == kichThuoc),
                    async () => await context.TKThepHoGas.AnyAsync(x => x.LoaiThep == loaiThep && x.DKCD.ToString() == kichThuoc),
                    async () => await context.TKThepMongCHops.AnyAsync(x => x.LoaiThep == loaiThep && x.DKCD.ToString() == kichThuoc),
                    async () => await context.TKThepMongCTrons.AnyAsync(x => x.LoaiThep == loaiThep && x.DKCD.ToString() == kichThuoc),
                    async () => await context.TKThepRBTongs.AnyAsync(x => x.LoaiThep == loaiThep && x.DKCD.ToString() == kichThuoc),
                    async () => await context.TKThepRXays.AnyAsync(x => x.LoaiThep == loaiThep && x.DKCD.ToString() == kichThuoc),
                    async () => await context.TKThepTamDans.AnyAsync(x => x.LoaiThep == loaiThep && x.DKCD.ToString() == kichThuoc),
                    async () => await context.TKThepTChongs.AnyAsync(x => x.LoaiThep == loaiThep && x.DKCD.ToString() == kichThuoc),
                    async () => await context.TKThepTDanCHops.AnyAsync(x => x.LoaiThep == loaiThep && x.DKCD.ToString() == kichThuoc),
                    async () => await context.TKThepTDanRXays.AnyAsync(x => x.LoaiThep == loaiThep && x.DKCD.ToString() == kichThuoc),
                    async () => await context.TKThepTDRBTongs.AnyAsync(x => x.LoaiThep == loaiThep && x.DKCD.ToString() == kichThuoc)
                };

            foreach (var check in checks)
            {
                if (await check())
                {
                    return true; 
                }
            }

            return false; 
        }
        public async Task Update(DMThep DMThep)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(DMThep.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {DMThep.Id}");
            }

            context.DMTLTheps.Update(DMThep);
            //await context.SaveChangesAsync();
            await SaveChanges(context);
        }
        public async Task UpdateMulti(DMThep[] DMThep)
        {
            using var context = _context.CreateDbContext();
            string[] ids = DMThep.Select(x => x.Id).ToArray();
            var listEntities = await context.DMTLTheps.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.DMTLTheps.Update(entity);
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

            context.Set<DMThep>().Remove(entity);
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
        public async Task Insert(DMThep entity)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                // Lấy tất cả các bản ghi phù hợp và thực hiện xử lý trên client-side
                var maxFlagValue = await context.DMTLTheps
                    .Where(x => x.ChungLoaiThep == entity.ChungLoaiThep)
                    .Select(x => x.Flag)
                    .ToListAsync(); // Lấy danh sách các giá trị Flag

                // Kiểm tra nếu danh sách không có giá trị nào, trả về 0, ngược lại lấy giá trị lớn nhất
                var maxFlag = maxFlagValue.Any() ? maxFlagValue.Max() : 0;


                // Tăng giá trị Flag lên 1
                entity.Flag = maxFlag + 1;

                // Chèn bản ghi mới vào bảng
                context.DMTLTheps.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public async Task<string> InsertLaterFlag(DMThep entity, int FlagLast)
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
                var recordsToUpdate = await context.DMTLTheps
                    .Where(x => x.Flag > FlagLast && x.ChungLoaiThep == entity.ChungLoaiThep)
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
                    var maxFlag = await context.DMTLTheps.AnyAsync()
                                  ? await context.DMTLTheps.MaxAsync(x => x.Flag)
                                  : 0;

                    // Tăng giá trị Flag lên 1
                    entity.Flag = maxFlag + 1;
                }
                else
                {
                    entity.Flag = FlagLast + 1;
                }

                // Bước 4: Chèn bản ghi mới vào bảng
                context.DMTLTheps.Add(entity);

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
        private async Task HandleEntityAdd(EntityEntry entityEntry)
        {
            var addedEntity = entityEntry.Entity as TKThepHoGa;
            if (addedEntity != null)
            {
                
                
            }
        }
        private async Task HandleEntityDelete(EntityEntry entityEntry)
        {
            var deletedEntity = entityEntry.Entity as TKThepHoGa;
            if (deletedEntity != null)
            {
              
            }
        }
        private async Task HandleEntityUpdate(EntityEntry entityEntry)
        {
            try
            {
                if (entityEntry.Entity is not DMThep modifiedEntity) return;

                var entity = await GetById(modifiedEntity.Id);
                if (entity == null)
                {
                    throw new Exception($"Không tìm thấy bản ghi theo ID: {modifiedEntity.Id}");
                }

                //tKThepHoGas
                var tKThepHoGaModel = new TKThepHoGaModel
                {
                    LoaiThep = entity.ChungLoaiThep,
                    DKCD = double.TryParse(entity.DuongKinh, out var parsedValue) ? parsedValue : -1
                };
                var result = await _tKThepHoGaRepository.GetAllByVM(tKThepHoGaModel);
                if (result == null || !result.Any()) return;
                var tKThepHoGas = result.Select(record =>
                {
                    if (string.IsNullOrEmpty(record.TenCongTac)) return null;

                    var dkcd = double.TryParse(modifiedEntity.DuongKinh, out var parsedValue1) ? parsedValue1 : 0;
                    var tongSoThanh = record.SoThanh * record.SoCK??0;
                    var tongChieuDai = Math.Round((tongSoThanh * record.ChieuDai1Thanh??0) / 1000, 4);
                    var trongLuong = modifiedEntity.TrongLuong;
                    var tongTrongLuong = record.LoaiThep_Name.Trim().ToUpper() == "THÉP BẢN"
                        ? Math.Round((dkcd * tongChieuDai * trongLuong ?? 0) / 1000000, 4)
                        : Math.Round(tongChieuDai * trongLuong ??0, 4);

                    return new TKThepHoGa
                    {
                        Id =record.Id,
                        ThongTinChungHoGa_TenHoGaSauPhanLoai = record.ThongTinChungHoGa_TenHoGaSauPhanLoai,
                        VTLayKhoiLuong = record.VTLayKhoiLuong,
                        LoaiThep = record.LoaiThep,
                        SoHieu = record.SoHieu,
                        DKCD = dkcd,
                        SoThanh = record.SoThanh,
                        SoCK = record.SoCK,
                        TongSoThanh = tongSoThanh,
                        ChieuDai1Thanh = record.ChieuDai1Thanh,
                        TongChieuDai = tongChieuDai,
                        TrongLuong = trongLuong,
                        TongTrongLuong = tongTrongLuong,
                        TenCongTac = $"Gia công lắp dựng thép {dkcd} {record.LoaiThep_Name} D{dkcd}",
                        CreateAt = record.CreateAt,
                        CreateBy = record.CreateBy,
                        Flag = record.Flag
                    };
                }).Where(x => x != null).ToList();
                if (tKThepHoGas.Any())
                {
                    await _tKThepHoGaRepository.UpdateMulti(tKThepHoGas.ToArray());
                }


                //tKThepHoGas
                var tKThepTamDanModel = new TKThepTamDanModel
                {
                    LoaiThep = entity.ChungLoaiThep,
                    DKCD = double.TryParse(entity.DuongKinh, out var parsedValueTD) ? parsedValueTD : -1
                };
                var resultThepTD = await _tKThepTamDanRepository.GetAllByVM(tKThepTamDanModel);
                if (resultThepTD == null || !resultThepTD.Any()) return;
                var tKThepTamDans = resultThepTD.Select(record =>
                {
                    if (string.IsNullOrEmpty(record.TenCongTac)) return null;

                    var dkcd = double.TryParse(modifiedEntity.DuongKinh, out var parsedValueTD1) ? parsedValueTD1 : 0;
                    var tongSoThanh = record.SoThanh * record.SoCK ?? 0;
                    var tongChieuDai = Math.Round((tongSoThanh * record.ChieuDai1Thanh ?? 0) / 1000, 4);
                    var trongLuong = modifiedEntity.TrongLuong;
                    var tongTrongLuong = record.LoaiThep_Name.Trim().ToUpper() == "THÉP BẢN"
                        ? Math.Round((dkcd * tongChieuDai * trongLuong ?? 0) / 1000000, 4)
                        : Math.Round(tongChieuDai * trongLuong ?? 0, 4);

                    return new TKThepTamDan
                    {
                        Id = record.Id,
                        ThongTinTamDanHoGa2_PhanLoaiDayHoGa = record.ThongTinTamDanHoGa2_PhanLoaiDayHoGa,
                        VTLayKhoiLuong = record.VTLayKhoiLuong,
                        LoaiThep = record.LoaiThep,
                        SoHieu = record.SoHieu,
                        DKCD = dkcd,
                        SoThanh = record.SoThanh,
                        SoCK = record.SoCK,
                        TongSoThanh = tongSoThanh,
                        ChieuDai1Thanh = record.ChieuDai1Thanh,
                        TongChieuDai = tongChieuDai,
                        TrongLuong = trongLuong,
                        TongTrongLuong = tongTrongLuong,
                        TenCongTac = $"Gia công lắp dựng thép {dkcd} {record.LoaiThep_Name} D{dkcd}",
                        CreateAt = record.CreateAt,
                        CreateBy = record.CreateBy,
                        Flag = record.Flag
                    };
                }).Where(x => x != null).ToList();
                if (tKThepTamDans.Any())
                {
                    await _tKThepTamDanRepository.UpdateMulti(tKThepTamDans.ToArray());
                }

                //tKThepCongTrons
                var tKThepCTronModel = new TKThepCTronModel
                {
                    LoaiThep = entity.ChungLoaiThep,
                    DKCD = double.TryParse(entity.DuongKinh, out var parsedValueCT) ? parsedValueCT : -1
                };
                var resultThepCT = await _tKThepCTronRepository.GetAllByVM(tKThepCTronModel);
                if (resultThepCT == null || !resultThepCT.Any()) return;
                var tKThepCongTrons = resultThepCT.Select(record =>
                {
                    if (string.IsNullOrEmpty(record.TenCongTac)) return null;

                    var dkcd = double.TryParse(modifiedEntity.DuongKinh, out var parsedValueCT1) ? parsedValueCT1 : 0;
                    var tongSoThanh = record.SoThanh * record.SoCK ?? 0;
                    var tongChieuDai = Math.Round((tongSoThanh * record.ChieuDai1Thanh ?? 0) / 1000, 4);
                    var trongLuong = modifiedEntity.TrongLuong;
                    var tongTrongLuong = record.LoaiThep_Name.Trim().ToUpper() == "THÉP BẢN"
                        ? Math.Round((dkcd * tongChieuDai * trongLuong ?? 0) / 1000000, 4)
                        : Math.Round(tongChieuDai * trongLuong ?? 0, 4);

                    return new TKThepCTron
                    {
                        Id = record.Id,
                        ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = record.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                        VTLayKhoiLuong = record.VTLayKhoiLuong,
                        LoaiThep = record.LoaiThep,
                        SoHieu = record.SoHieu,
                        DKCD = dkcd,
                        SoThanh = record.SoThanh,
                        SoCK = record.SoCK,
                        TongSoThanh = tongSoThanh,
                        ChieuDai1Thanh = record.ChieuDai1Thanh,
                        TongChieuDai = tongChieuDai,
                        TrongLuong = trongLuong,
                        TongTrongLuong = tongTrongLuong,
                        TenCongTac = $"Gia công lắp dựng thép {dkcd} {record.LoaiThep_Name} D{dkcd}",
                        CreateAt = record.CreateAt,
                        CreateBy = record.CreateBy,
                        Flag = record.Flag
                    };
                }).Where(x => x != null).ToList();
                if (tKThepCongTrons.Any())
                {
                    await _tKThepCTronRepository.UpdateMulti(tKThepCongTrons.ToArray());
                }

                //tKThepMongCongTrons
                var tKThepMongCTronModel = new TKThepMongCTronModel
                {
                    LoaiThep = entity.ChungLoaiThep,
                    DKCD = double.TryParse(entity.DuongKinh, out var parsedValueMCT) ? parsedValueMCT : -1
                };
                var resultThepMCT = await _tKThepMongCTronRepository.GetAllByVM(tKThepMongCTronModel);
                if (resultThepMCT == null || !resultThepMCT.Any()) return;
                var tKThepMongCongTrons = resultThepMCT.Select(record =>
                {
                    if (string.IsNullOrEmpty(record.TenCongTac)) return null;

                    var dkcd = double.TryParse(modifiedEntity.DuongKinh, out var parsedValueMCT1) ? parsedValueMCT1 : 0;
                    var tongSoThanh = record.SoThanh * record.SoCK ?? 0;
                    var tongChieuDai = Math.Round((tongSoThanh * record.ChieuDai1Thanh ?? 0) / 1000, 4);
                    var trongLuong = modifiedEntity.TrongLuong;
                    var tongTrongLuong = record.LoaiThep_Name.Trim().ToUpper() == "THÉP BẢN"
                        ? Math.Round((dkcd * tongChieuDai * trongLuong ?? 0) / 1000000, 4)
                        : Math.Round(tongChieuDai * trongLuong ?? 0, 4);

                    return new TKThepMongCTron
                    {
                        Id = record.Id,
                        ThongTinLyTrinh_TuyenDuong = record.ThongTinLyTrinh_TuyenDuong,
                        ThongTinLyTrinhTruyenDan_TuLyTrinh = record.ThongTinLyTrinhTruyenDan_TuLyTrinh,
                        ThongTinLyTrinhTruyenDan_DenLyTrinh = record.ThongTinLyTrinhTruyenDan_DenLyTrinh,
                        ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop = record.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop,
                        VTLayKhoiLuong = record.VTLayKhoiLuong,
                        LoaiThep = record.LoaiThep,
                        SoHieu = record.SoHieu,
                        DKCD = dkcd,
                        SoThanh = record.SoThanh,
                        SoCK = record.SoCK,
                        TongSoThanh = tongSoThanh,
                        ChieuDai1Thanh = record.ChieuDai1Thanh,
                        TongChieuDai = tongChieuDai,
                        TrongLuong = trongLuong,
                        TongTrongLuong = tongTrongLuong,
                        TenCongTac = $"Gia công lắp dựng thép {dkcd} {record.LoaiThep_Name} D{dkcd}",
                        CreateAt = record.CreateAt,
                        CreateBy = record.CreateBy,
                        Flag = record.Flag
                    };
                }).Where(x => x != null).ToList();
                if (tKThepMongCongTrons.Any())
                {
                    await _tKThepMongCTronRepository.UpdateMulti(tKThepMongCongTrons.ToArray());
                }
                
                //tKThepDeCongs
                var tKThepDCongModel = new TKThepDCongModel
                {
                    LoaiThep = entity.ChungLoaiThep,
                    DKCD = double.TryParse(entity.DuongKinh, out var parsedValueDC) ? parsedValueDC : -1
                };
                var resultThepDC = await _tKThepDeCongRepository.GetAllByVM(tKThepDCongModel);
                if (resultThepDC == null || !resultThepDC.Any()) return;
                var tKThepDeCongs = resultThepDC.Select(record =>
                {
                    if (string.IsNullOrEmpty(record.TenCongTac)) return null;

                    var dkcd = double.TryParse(modifiedEntity.DuongKinh, out var parsedValueMCT1) ? parsedValueMCT1 : 0;
                    var tongSoThanh = record.SoThanh * record.SoCK ?? 0;
                    var tongChieuDai = Math.Round((tongSoThanh * record.ChieuDai1Thanh ?? 0) / 1000, 4);
                    var trongLuong = modifiedEntity.TrongLuong;
                    var tongTrongLuong = record.LoaiThep_Name.Trim().ToUpper() == "THÉP BẢN"
                        ? Math.Round((dkcd * tongChieuDai * trongLuong ?? 0) / 1000000, 4)
                        : Math.Round(tongChieuDai * trongLuong ?? 0, 4);
                    return new TKThepDCong
                    {
                        Id = record.Id,
                        ThongTinDeCong_TenLoaiDeCong = record.ThongTinDeCong_TenLoaiDeCong,
                        VTLayKhoiLuong = record.VTLayKhoiLuong,
                        LoaiThep = record.LoaiThep,
                        SoHieu = record.SoHieu,
                        DKCD = dkcd,
                        SoThanh = record.SoThanh,
                        SoCK = record.SoCK,
                        TongSoThanh = tongSoThanh,
                        ChieuDai1Thanh = record.ChieuDai1Thanh,
                        TongChieuDai = tongChieuDai,
                        TrongLuong = trongLuong,
                        TongTrongLuong = tongTrongLuong,
                        TenCongTac = $"Gia công lắp dựng thép {dkcd} {record.LoaiThep_Name} D{dkcd}",
                        CreateAt = record.CreateAt,
                        CreateBy = record.CreateBy,
                        Flag = record.Flag
                    };
                }).Where(x => x != null).ToList();
                if (tKThepDeCongs.Any())
                {
                    await _tKThepDeCongRepository.UpdateMulti(tKThepDeCongs.ToArray());
                }

                //tKThepCongHops
                var tkThepCHopModel = new TKThepCHopModel
                {
                    LoaiThep = entity.ChungLoaiThep,
                    DKCD = double.TryParse(entity.DuongKinh, out var parsedValueCH) ? parsedValueCH : -1
                };
                var resultThepCH = await _tKThepCHopRepository.GetAllByVM(tkThepCHopModel);
                if (resultThepCH == null || !resultThepCH.Any()) return;
                var tKThepCongHops = resultThepCH.Select(record =>
                {
                    if (string.IsNullOrEmpty(record.TenCongTac)) return null;

                    var dkcd = double.TryParse(modifiedEntity.DuongKinh, out var parsedValueCH1) ? parsedValueCH1 : 0;
                    var tongSoThanh = record.SoThanh * record.SoCK ?? 0;
                    var tongChieuDai = Math.Round((tongSoThanh * record.ChieuDai1Thanh ?? 0) / 1000, 4);
                    var trongLuong = modifiedEntity.TrongLuong;
                    var tongTrongLuong = record.LoaiThep_Name.Trim().ToUpper() == "THÉP BẢN"
                        ? Math.Round((dkcd * tongChieuDai * trongLuong ?? 0) / 1000000, 4)
                        : Math.Round(tongChieuDai * trongLuong ?? 0, 4);
                    return new TKThepCHop
                    {
                        Id = record.Id,
                        ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = record.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                        VTLayKhoiLuong = record.VTLayKhoiLuong,
                        LoaiThep = record.LoaiThep,
                        SoHieu = record.SoHieu,
                        DKCD = dkcd,
                        SoThanh = record.SoThanh,
                        SoCK = record.SoCK,
                        TongSoThanh = tongSoThanh,
                        ChieuDai1Thanh = record.ChieuDai1Thanh,
                        TongChieuDai = tongChieuDai,
                        TrongLuong = trongLuong,
                        TongTrongLuong = tongTrongLuong,
                        TenCongTac = $"Gia công lắp dựng thép {dkcd} {record.LoaiThep_Name} D{dkcd}",
                        CreateAt = record.CreateAt,
                        CreateBy = record.CreateBy,
                        Flag = record.Flag
                    };
                }).Where(x => x != null).ToList();
                if (tKThepCongHops.Any())
                {
                    await _tKThepCHopRepository.UpdateMulti(tKThepCongHops.ToArray());
                }

                //tKThepMongCongHops
                var tkThepMongCHopModel = new TKThepMongCHopModel
                {
                    LoaiThep = entity.ChungLoaiThep,
                    DKCD = double.TryParse(entity.DuongKinh, out var parsedValueMCH) ? parsedValueMCH : -1
                };
                var resultThepMCH = await _tKThepMongCHopRepository.GetAllByVM(tkThepMongCHopModel);
                if (resultThepMCH == null || !resultThepMCH.Any()) return;
                var tKThepMongCongHops = resultThepMCH.Select(record =>
                {
                    if (string.IsNullOrEmpty(record.TenCongTac)) return null;

                    var dkcd = double.TryParse(modifiedEntity.DuongKinh, out var parsedValueMCH1) ? parsedValueMCH1 : 0;
                    var tongSoThanh = record.SoThanh * record.SoCK ?? 0;
                    var tongChieuDai = Math.Round((tongSoThanh * record.ChieuDai1Thanh ?? 0) / 1000, 4);
                    var trongLuong = modifiedEntity.TrongLuong;
                    var tongTrongLuong = record.LoaiThep_Name.Trim().ToUpper() == "THÉP BẢN"
                        ? Math.Round((dkcd * tongChieuDai * trongLuong ?? 0) / 1000000, 4)
                        : Math.Round(tongChieuDai * trongLuong ?? 0, 4);
                    return new TKThepMongCHop
                    {
                        Id = record.Id,
                        ThongTinLyTrinh_TuyenDuong = record.ThongTinLyTrinh_TuyenDuong,
                        ThongTinLyTrinhTruyenDan_TuLyTrinh = record.ThongTinLyTrinhTruyenDan_TuLyTrinh,
                        ThongTinLyTrinhTruyenDan_DenLyTrinh = record.ThongTinLyTrinhTruyenDan_DenLyTrinh,
                        ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop = record.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop,
                        VTLayKhoiLuong = record.VTLayKhoiLuong,
                        LoaiThep = record.LoaiThep,
                        SoHieu = record.SoHieu,
                        DKCD = dkcd,
                        SoThanh = record.SoThanh,
                        SoCK = record.SoCK,
                        TongSoThanh = tongSoThanh,
                        ChieuDai1Thanh = record.ChieuDai1Thanh,
                        TongChieuDai = tongChieuDai,
                        TrongLuong = trongLuong,
                        TongTrongLuong = tongTrongLuong,
                        TenCongTac = $"Gia công lắp dựng thép {dkcd} {record.LoaiThep_Name} D{dkcd}",
                        CreateAt = record.CreateAt,
                        CreateBy = record.CreateBy,
                        Flag = record.Flag
                    };
                }).Where(x => x != null).ToList();
                if (tKThepMongCongHops.Any())
                {
                    await _tKThepMongCHopRepository.UpdateMulti(tKThepMongCongHops.ToArray());
                }

                //tKThepTamDanConghops
                var tkThepTDanCHopModel = new TKThepTDanCHopModel
                {
                    LoaiThep = entity.ChungLoaiThep,
                    DKCD = double.TryParse(entity.DuongKinh, out var parsedValueTDCH) ? parsedValueTDCH : -1
                };
                var resultThepTDCH = await _tKThepTDanCHopRepository.GetAllByVM(tkThepTDanCHopModel);
                if (resultThepTDCH == null || !resultThepTDCH.Any()) return;
                var tKThepTDanCHops = resultThepTDCH.Select(record =>
                {
                    if (string.IsNullOrEmpty(record.TenCongTac)) return null;

                    var dkcd = double.TryParse(modifiedEntity.DuongKinh, out var parsedValueTDCH1) ? parsedValueTDCH1 : 0;
                    var tongSoThanh = record.SoThanh * record.SoCK ?? 0;
                    var tongChieuDai = Math.Round((tongSoThanh * record.ChieuDai1Thanh ?? 0) / 1000, 4);
                    var trongLuong = modifiedEntity.TrongLuong;
                    var tongTrongLuong = record.LoaiThep_Name.Trim().ToUpper() == "THÉP BẢN"
                        ? Math.Round((dkcd * tongChieuDai * trongLuong ?? 0) / 1000000, 4)
                        : Math.Round(tongChieuDai * trongLuong ?? 0, 4);
                    return new TKThepTDanCHop
                    {
                        Id = record.Id,
                        TTTDCongHoRanh_TenLoaiTamDanTieuChuan = record.TTTDCongHoRanh_TenLoaiTamDanTieuChuan,
                        VTLayKhoiLuong = record.VTLayKhoiLuong,
                        LoaiThep = record.LoaiThep,
                        SoHieu = record.SoHieu,
                        DKCD = dkcd,
                        SoThanh = record.SoThanh,
                        SoCK = record.SoCK,
                        TongSoThanh = tongSoThanh,
                        ChieuDai1Thanh = record.ChieuDai1Thanh,
                        TongChieuDai = tongChieuDai,
                        TrongLuong = trongLuong,
                        TongTrongLuong = tongTrongLuong,
                        TenCongTac = $"Gia công lắp dựng thép {dkcd} {record.LoaiThep_Name} D{dkcd}",
                        CreateAt = record.CreateAt,
                        CreateBy = record.CreateBy,
                        Flag = record.Flag
                    };
                }).Where(x => x != null).ToList();
                if (tKThepTDanCHops.Any())
                {
                    await _tKThepTDanCHopRepository.UpdateMulti(tKThepTDanCHops.ToArray());
                }

                //tKThepRanhXays
                var tkThepRXayModel = new TKThepRXayModel
                {
                    LoaiThep = entity.ChungLoaiThep,
                    DKCD = double.TryParse(entity.DuongKinh, out var parsedValueRX) ? parsedValueRX : -1
                };
                var resultThepRX = await _tKThepRXayRepository.GetAllByVM(tkThepRXayModel);
                if (resultThepRX == null || !resultThepRX.Any()) return;
                var tKThepRanhXays = resultThepRX.Select(record =>
                {
                    if (string.IsNullOrEmpty(record.TenCongTac)) return null;

                    var dkcd = double.TryParse(modifiedEntity.DuongKinh, out var parsedValueRX1) ? parsedValueRX1 : 0;
                    var tongSoThanh = record.SoThanh * record.SoCK ?? 0;
                    var tongChieuDai = Math.Round((tongSoThanh * record.ChieuDai1Thanh ?? 0) / 1000, 4);
                    var trongLuong = modifiedEntity.TrongLuong;
                    var tongTrongLuong = record.LoaiThep_Name.Trim().ToUpper() == "THÉP BẢN"
                        ? Math.Round((dkcd * tongChieuDai * trongLuong ?? 0) / 1000000, 4)
                        : Math.Round(tongChieuDai * trongLuong ?? 0, 4);
                    return new TKThepRXay
                    {
                        Id = record.Id,
                        ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = record.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                        VTLayKhoiLuong = record.VTLayKhoiLuong,
                        LoaiThep = record.LoaiThep,
                        SoHieu = record.SoHieu,
                        DKCD = dkcd,
                        SoThanh = record.SoThanh,
                        SoCK = record.SoCK,
                        TongSoThanh = tongSoThanh,
                        ChieuDai1Thanh = record.ChieuDai1Thanh,
                        TongChieuDai = tongChieuDai,
                        TrongLuong = trongLuong,
                        TongTrongLuong = tongTrongLuong,
                        TenCongTac = $"Gia công lắp dựng thép {dkcd} {record.LoaiThep_Name} D{dkcd}",
                        CreateAt = record.CreateAt,
                        CreateBy = record.CreateBy,
                        Flag = record.Flag
                    };
                }).Where(x => x != null).ToList();
                if (tKThepRanhXays.Any())
                {
                    await _tKThepRXayRepository.UpdateMulti(tKThepRanhXays.ToArray());
                }

                //tKThepTDRanhXays
                var tkThepTDanRXayModel = new TKThepTDanRXayModel
                {
                    LoaiThep = entity.ChungLoaiThep,
                    DKCD = double.TryParse(entity.DuongKinh, out var parsedValueTDRX) ? parsedValueTDRX : -1
                };
                var resultThepTDRX = await _tKThepTDanRXayRepository.GetAllByVM(tkThepTDanRXayModel);
                if (resultThepTDRX == null || !resultThepTDRX.Any()) return;
                var tKThepTDRanhXays = resultThepTDRX.Select(record =>
                {
                    if (string.IsNullOrEmpty(record.TenCongTac)) return null;

                    var dkcd = double.TryParse(modifiedEntity.DuongKinh, out var parsedValueTDRX1) ? parsedValueTDRX1 : 0;
                    var tongSoThanh = record.SoThanh * record.SoCK ?? 0;
                    var tongChieuDai = Math.Round((tongSoThanh * record.ChieuDai1Thanh ?? 0) / 1000, 4);
                    var trongLuong = modifiedEntity.TrongLuong;
                    var tongTrongLuong = record.LoaiThep_Name.Trim().ToUpper() == "THÉP BẢN"
                        ? Math.Round((dkcd * tongChieuDai * trongLuong ?? 0) / 1000000, 4)
                        : Math.Round(tongChieuDai * trongLuong ?? 0, 4);
                    return new TKThepTDanRXay
                    {
                        Id = record.Id,
                        TTTDCongHoRanh_TenLoaiTamDanTieuChuan = record.TTTDCongHoRanh_TenLoaiTamDanTieuChuan,
                        VTLayKhoiLuong = record.VTLayKhoiLuong,
                        LoaiThep = record.LoaiThep,
                        SoHieu = record.SoHieu,
                        DKCD = dkcd,
                        SoThanh = record.SoThanh,
                        SoCK = record.SoCK,
                        TongSoThanh = tongSoThanh,
                        ChieuDai1Thanh = record.ChieuDai1Thanh,
                        TongChieuDai = tongChieuDai,
                        TrongLuong = trongLuong,
                        TongTrongLuong = tongTrongLuong,
                        TenCongTac = $"Gia công lắp dựng thép {dkcd} {record.LoaiThep_Name} D{dkcd}",
                        CreateAt = record.CreateAt,
                        CreateBy = record.CreateBy,
                        Flag = record.Flag
                    };
                }).Where(x => x != null).ToList();
                if (tKThepTDRanhXays.Any())
                {
                    await _tKThepTDanRXayRepository.UpdateMulti(tKThepTDRanhXays.ToArray());
                }

                //tKThepRanhBeTongs
                var tkThepRBTongModel = new TKThepRBTongModel
                {
                    LoaiThep = entity.ChungLoaiThep,
                    DKCD = double.TryParse(entity.DuongKinh, out var parsedValueRBT) ? parsedValueRBT : -1
                };
                var resultThepRBT = await _tKThepRBTongRepository.GetAllByVM(tkThepRBTongModel);
                if (resultThepRBT == null || !resultThepRBT.Any()) return;
                var tKThepRanhBeTongs = resultThepRBT.Select(record =>
                {
                    if (string.IsNullOrEmpty(record.TenCongTac)) return null;

                    var dkcd = double.TryParse(modifiedEntity.DuongKinh, out var parsedValueRBT1) ? parsedValueRBT1 : 0;
                    var tongSoThanh = record.SoThanh * record.SoCK ?? 0;
                    var tongChieuDai = Math.Round((tongSoThanh * record.ChieuDai1Thanh ?? 0) / 1000, 4);
                    var trongLuong = modifiedEntity.TrongLuong;
                    var tongTrongLuong = record.LoaiThep_Name.Trim().ToUpper() == "THÉP BẢN"
                        ? Math.Round((dkcd * tongChieuDai * trongLuong ?? 0) / 1000000, 4)
                        : Math.Round(tongChieuDai * trongLuong ?? 0, 4);
                    return new TKThepRBTong
                    {
                        Id = record.Id,
                        ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = record.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                        VTLayKhoiLuong = record.VTLayKhoiLuong,
                        LoaiThep = record.LoaiThep,
                        SoHieu = record.SoHieu,
                        DKCD = dkcd,
                        SoThanh = record.SoThanh,
                        SoCK = record.SoCK,
                        TongSoThanh = tongSoThanh,
                        ChieuDai1Thanh = record.ChieuDai1Thanh,
                        TongChieuDai = tongChieuDai,
                        TrongLuong = trongLuong,
                        TongTrongLuong = tongTrongLuong,
                        TenCongTac = $"Gia công lắp dựng thép {dkcd} {record.LoaiThep_Name} D{dkcd}",
                        CreateAt = record.CreateAt,
                        CreateBy = record.CreateBy,
                        Flag = record.Flag
                    };
                }).Where(x => x != null).ToList();
                if (tKThepRanhBeTongs.Any())
                {
                    await _tKThepRBTongRepository.UpdateMulti(tKThepRanhBeTongs.ToArray());
                }

                //tKThepTDRanhBeTongs
                var tkThepTDRBTongModel = new TKThepTDRBTongModel
                {
                    LoaiThep = entity.ChungLoaiThep,
                    DKCD = double.TryParse(entity.DuongKinh, out var parsedValueTC) ? parsedValueTC : -1
                };
                var resultThepTDRBT = await _tKThepTDRBTongRepository.GetAllByVM(tkThepTDRBTongModel);
                if (resultThepTDRBT == null || !resultThepTDRBT.Any()) return;
                var tKThepTDRanhBeTongs = resultThepTDRBT.Select(record =>
                {
                    if (string.IsNullOrEmpty(record.TenCongTac)) return null;

                    var dkcd = double.TryParse(modifiedEntity.DuongKinh, out var parsedValueTDRX1) ? parsedValueTDRX1 : 0;
                    var tongSoThanh = record.SoThanh * record.SoCK ?? 0;
                    var tongChieuDai = Math.Round((tongSoThanh * record.ChieuDai1Thanh ?? 0) / 1000, 4);
                    var trongLuong = modifiedEntity.TrongLuong;
                    var tongTrongLuong = record.LoaiThep_Name.Trim().ToUpper() == "THÉP BẢN"
                        ? Math.Round((dkcd * tongChieuDai * trongLuong ?? 0) / 1000000, 4)
                        : Math.Round(tongChieuDai * trongLuong ?? 0, 4);
                    return new TKThepTDRBTong
                    {
                        Id = record.Id,
                        TTTDCongHoRanh_TenLoaiTamDanTieuChuan = record.TTTDCongHoRanh_TenLoaiTamDanTieuChuan,
                        VTLayKhoiLuong = record.VTLayKhoiLuong,
                        LoaiThep = record.LoaiThep,
                        SoHieu = record.SoHieu,
                        DKCD = dkcd,
                        SoThanh = record.SoThanh,
                        SoCK = record.SoCK,
                        TongSoThanh = tongSoThanh,
                        ChieuDai1Thanh = record.ChieuDai1Thanh,
                        TongChieuDai = tongChieuDai,
                        TrongLuong = trongLuong,
                        TongTrongLuong = tongTrongLuong,
                        TenCongTac = $"Gia công lắp dựng thép {dkcd} {record.LoaiThep_Name} D{dkcd}",
                        CreateAt = record.CreateAt,
                        CreateBy = record.CreateBy,
                        Flag = record.Flag
                    };
                }).Where(x => x != null).ToList();
                if (tKThepTDRanhBeTongs.Any())
                {
                    await _tKThepTDRBTongRepository.UpdateMulti(tKThepTDRanhBeTongs.ToArray());
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

    }
}
