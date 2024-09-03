using DucAnhERP.Data;
using DucAnhERP.Models;
using DucAnhERP.Repository;
using DucAnhERP.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace DucAnhERP.Services
{
    public class PhanLoaiHoGaRepository : IPhanLoaiHoGaRepository
    {
      
            private readonly IDbContextFactory<ApplicationDbContext> _context;

            public PhanLoaiHoGaRepository(IDbContextFactory<ApplicationDbContext> context)
            {
                _context = context;
            }

            public async Task<List<MPhanLoaiHoGa>> GetAll()
            {
                try
                {
                    using var context = _context.CreateDbContext();
                    var entity = await context.DSPhanLoaiHoGa.ToListAsync();
                    return entity;
                }
                catch (Exception ex)
                {
                    // Log the exception
                    Console.Error.WriteLine($"An error occurred: {ex.Message}");
                    throw; // Optionally rethrow the exception
                }
            }

           

        public async Task<List<PhanLoaiHoGaModel>> GetAllByVM()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var query = from plhg in context.DSPhanLoaiHoGa
                            orderby plhg.CreatAt
                            select new PhanLoaiHoGaModel
                            {
                                Id = plhg.Id,
                                ThongTinChungHoGa_TenHoGaSauPhanLoai = plhg.ThongTinChungHoGa_TenHoGaSauPhanLoai ?? "",
                                ThongTinChungHoGa_HinhThucHoGa = plhg.ThongTinChungHoGa_HinhThucHoGa ?? "",
                                ThongTinChungHoGa_KetCauMuMo = plhg.ThongTinChungHoGa_KetCauMuMo ?? "",
                                ThongTinChungHoGa_KetCauTuong = plhg.ThongTinChungHoGa_KetCauTuong ?? "",
                                ThongTinChungHoGa_HinhThucMongHoGa = plhg.ThongTinChungHoGa_HinhThucMongHoGa ?? "",
                                ThongTinChungHoGa_KetCauMong = plhg.ThongTinChungHoGa_KetCauMong ?? "",
                                ThongTinChungHoGa_ChatMatTrong = plhg.ThongTinChungHoGa_ChatMatTrong ?? "",
                                ThongTinChungHoGa_ChatMatNgoai = plhg.ThongTinChungHoGa_ChatMatNgoai ?? "",
                                PhuBiHoGa_CDai = plhg.PhuBiHoGa_CDai ?? 0,
                                PhuBiHoGa_CRong = plhg.PhuBiHoGa_CRong ?? 0,
                                BeTongLotMong_D = plhg.BeTongLotMong_D ?? 0,
                                BeTongLotMong_R = plhg.BeTongLotMong_R ?? 0,
                                BeTongLotMong_C = plhg.BeTongLotMong_C ?? 0,
                                BeTongMongHoGa_D = plhg.BeTongMongHoGa_D ?? 0,
                                BeTongMongHoGa_R = plhg.BeTongMongHoGa_R ?? 0,
                                BeTongMongHoGa_C = 0,
                                DeHoGa_D = plhg.DeHoGa_D ?? 0,
                                DeHoGa_R = plhg.DeHoGa_R ?? 0,
                                DeHoGa_C = plhg.DeHoGa_C ?? 0,
                                TuongHoGa_D = plhg.TuongHoGa_D ?? 0,
                                TuongHoGa_R = plhg.TuongHoGa_R ?? 0,
                                TuongHoGa_C = 0,
                                TuongHoGa_CdTuong = plhg.TuongHoGa_CdTuong ?? 0,
                                DamGiuaHoGa_D = plhg.DamGiuaHoGa_D ?? 0,
                                DamGiuaHoGa_R = plhg.DamGiuaHoGa_R ?? 0,
                                DamGiuaHoGa_C = plhg.DamGiuaHoGa_C ?? 0,
                                DamGiuaHoGa_CdDam = plhg.DamGiuaHoGa_CdDam ?? 0,
                                DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa = plhg.DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa ?? 0,
                                ChatMatTrong_D = plhg.ChatMatTrong_D ?? 0,
                                ChatMatTrong_R = plhg.ChatMatTrong_R ?? 0,
                                ChatMatTrong_C = 0,
                                ChatMatNgoaiCanh_D = plhg.ChatMatNgoaiCanh_D ?? 0,
                                ChatMatNgoaiCanh_R = plhg.ChatMatNgoaiCanh_R ?? 0,
                                ChatMatNgoaiCanh_C = 0,
                                MuMoThotDuoi_D = plhg.MuMoThotDuoi_D ?? 0,
                                MuMoThotDuoi_R = plhg.MuMoThotDuoi_R ?? 0,
                                MuMoThotDuoi_C = plhg.MuMoThotDuoi_C ?? 0,
                                MuMoThotDuoi_CdTuong = plhg.MuMoThotDuoi_CdTuong ?? 0,
                                MuMoThotTren_D = plhg.MuMoThotTren_D ?? 0,
                                MuMoThotTren_R = plhg.MuMoThotTren_R ?? 0,
                                MuMoThotTren_C = plhg.MuMoThotTren_C ?? 0,
                                MuMoThotTren_CdTuong = plhg.MuMoThotTren_CdTuong ?? 0,
                                HinhThucDauNoi1_Loai = plhg.HinhThucDauNoi1_Loai ?? 0,
                                HinhThucDauNoi1_CanhDai = plhg.HinhThucDauNoi1_CanhDai ?? 0,
                                HinhThucDauNoi1_CanhRong = plhg.HinhThucDauNoi1_CanhRong ?? 0,
                                HinhThucDauNoi1_CanhCheo = plhg.HinhThucDauNoi1_CanhCheo ?? 0,
                                HinhThucDauNoi2_Loai = plhg.HinhThucDauNoi2_Loai ?? 0,
                                HinhThucDauNoi2_CanhDai = plhg.HinhThucDauNoi2_CanhDai ?? 0,
                                HinhThucDauNoi2_CanhRong = plhg.HinhThucDauNoi2_CanhRong ?? 0,
                                HinhThucDauNoi2_CanhCheo = plhg.HinhThucDauNoi2_CanhCheo ?? 0,
                                HinhThucDauNoi3_Loai = plhg.HinhThucDauNoi3_Loai ?? 0,
                                HinhThucDauNoi3_CanhDai = plhg.HinhThucDauNoi3_CanhDai ?? 0,
                                HinhThucDauNoi3_CanhRong = plhg.HinhThucDauNoi3_CanhRong ?? 0,
                                HinhThucDauNoi3_CanhCheo = plhg.HinhThucDauNoi3_CanhCheo ?? 0,
                                HinhThucDauNoi4_Loai = plhg.HinhThucDauNoi4_Loai ?? 0,
                                HinhThucDauNoi4_CanhDai = plhg.HinhThucDauNoi4_CanhDai ?? 0,
                                HinhThucDauNoi4_CanhRong = plhg.HinhThucDauNoi4_CanhRong ?? 0,
                                HinhThucDauNoi4_CanhCheo = plhg.HinhThucDauNoi4_CanhCheo ?? 0,
                                HinhThucDauNoi5_Loai = plhg.HinhThucDauNoi5_Loai ?? 0,
                                HinhThucDauNoi5_CanhDai = plhg.HinhThucDauNoi5_CanhDai ?? 0,
                                HinhThucDauNoi5_CanhRong = plhg.HinhThucDauNoi5_CanhRong ?? 0,
                                HinhThucDauNoi5_CanhCheo = plhg.HinhThucDauNoi5_CanhCheo ?? 0,
                                HinhThucDauNoi6_Loai = plhg.HinhThucDauNoi6_Loai ?? 0,
                                HinhThucDauNoi6_CanhDai = plhg.HinhThucDauNoi6_CanhDai ?? 0,
                                HinhThucDauNoi6_CanhRong = plhg.HinhThucDauNoi6_CanhRong ?? 0,
                                HinhThucDauNoi6_CanhCheo = plhg.HinhThucDauNoi6_CanhCheo ?? 0,
                                HinhThucDauNoi7_Loai = plhg.HinhThucDauNoi7_Loai ?? 0,
                                HinhThucDauNoi7_CanhDai = plhg.HinhThucDauNoi7_CanhDai ?? 0,
                                HinhThucDauNoi7_CanhRong = plhg.HinhThucDauNoi7_CanhRong ?? 0,
                                HinhThucDauNoi7_CanhCheo = plhg.HinhThucDauNoi7_CanhCheo ?? 0,
                                HinhThucDauNoi8_Loai = plhg.HinhThucDauNoi8_Loai ?? 0,
                                HinhThucDauNoi8_CanhDai = plhg.HinhThucDauNoi8_CanhDai ?? 0,
                                HinhThucDauNoi8_CanhRong = plhg.HinhThucDauNoi8_CanhRong ?? 0,
                                HinhThucDauNoi8_CanhCheo = plhg.HinhThucDauNoi8_CanhCheo ?? 0,
                                CreatAt = plhg.CreatAt,

                            };

                var data = await query
                    .ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
            
        }

        public async Task Update(MPhanLoaiHoGa phanloaihoga)
            {
                using var context = _context.CreateDbContext();
                var entity = GetById(phanloaihoga.Id);

                if (entity == null)
                {
                    throw new Exception($"Không tìm thấy bản ghi theo ID: {phanloaihoga.Id}");
                }

                context.DSPhanLoaiHoGa.Update(phanloaihoga);
                await context.SaveChangesAsync();
            }

            public async Task UpdateMulti(MPhanLoaiHoGa[] phanloaihoga)
            {
                using var context = _context.CreateDbContext();
                string[] ids = phanloaihoga.Select(x => x.Id).ToArray();
                var listEntities = await context.DSPhanLoaiHoGa.Where(x => ids.Contains(x.Id)).ToListAsync();
                foreach (var entity in listEntities)
                {
                    context.DSPhanLoaiHoGa.Update(entity);
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

                context.Set<MPhanLoaiHoGa>().Remove(entity);
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

            public async Task<MPhanLoaiHoGa> GetById(string id)
            {
                using var context = _context.CreateDbContext();
                var entity = await context.DSPhanLoaiHoGa.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

                if (entity == null)
                {
                    throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
                }

                return entity;
            }

            public async Task Insert(MPhanLoaiHoGa entity)
            {
                try
                {
                    using var context = _context.CreateDbContext();
                    if (entity == null)
                    {
                        throw new Exception("Không có bản ghi nào để thêm!");
                    }

                    context.DSPhanLoaiHoGa.Add(entity);
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    
}
