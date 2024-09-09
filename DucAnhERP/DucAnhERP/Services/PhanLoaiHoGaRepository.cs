using DucAnhERP.Data;
using DucAnhERP.Models;
using DucAnhERP.Repository;
using DucAnhERP.ViewModel;
using Microsoft.AspNetCore.Http.HttpResults;
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

        public async Task<List<PhanLoaiHoGa>> GetAll()
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
                            orderby plhg.CreateAt
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
                                CreateAt=plhg.CreateAt ,
                                CreateBy=plhg.CreateBy,
                                IsActive = plhg.IsActive,

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
        public async Task<bool> CheckUsingId(string id)
        {
            bool isSuccess = false;
            using var context = _context.CreateDbContext();
            var query = context.DSHopRanhThang
                         .Where(hrt => (hrt.ThongTinChungHoGa_TenHoGaSauPhanLoai == id));

            var data = await query.ToListAsync();

            // Kiểm tra nếu danh sách kết quả rỗng hoặc không có dữ liệu khớp
            isSuccess = data.Any();
            return (isSuccess);
        }

        public async Task GetMPhanLoaiHoGaByDetail(PhanLoaiHoGaModel searchData)
        {
            using var context = _context.CreateDbContext();
            var query = context.DSPhanLoaiHoGa.AsQueryable();

            // Thực hiện lọc dữ liệu dựa trên các thuộc tính của searchData
            query = query.Where(x =>
                (searchData.ThongTinChungHoGa_HinhThucHoGa == null || x.ThongTinChungHoGa_HinhThucHoGa.Contains(searchData.ThongTinChungHoGa_HinhThucHoGa)) &&
                (searchData.ThongTinChungHoGa_KetCauMuMo == null || x.ThongTinChungHoGa_KetCauMuMo.Contains(searchData.ThongTinChungHoGa_KetCauMuMo)) &&
                (searchData.ThongTinChungHoGa_KetCauTuong == null || x.ThongTinChungHoGa_KetCauTuong.Contains(searchData.ThongTinChungHoGa_KetCauTuong)) &&
                (searchData.ThongTinChungHoGa_HinhThucMongHoGa == null || x.ThongTinChungHoGa_HinhThucMongHoGa.Contains(searchData.ThongTinChungHoGa_HinhThucMongHoGa)) &&
                (searchData.ThongTinChungHoGa_KetCauMong == null || x.ThongTinChungHoGa_KetCauMong.Contains(searchData.ThongTinChungHoGa_KetCauMong)) &&
                (searchData.ThongTinChungHoGa_ChatMatTrong == null || x.ThongTinChungHoGa_ChatMatTrong.Contains(searchData.ThongTinChungHoGa_ChatMatTrong)) &&
                (searchData.ThongTinChungHoGa_ChatMatNgoai == null || x.ThongTinChungHoGa_ChatMatNgoai.Contains(searchData.ThongTinChungHoGa_ChatMatNgoai)) &&
                (searchData.PhuBiHoGa_CDai == null || x.PhuBiHoGa_CDai == searchData.PhuBiHoGa_CDai) &&
                (searchData.PhuBiHoGa_CRong == null || x.PhuBiHoGa_CRong == searchData.PhuBiHoGa_CRong) &&
                (searchData.BeTongLotMong_D == null || x.BeTongLotMong_D == searchData.BeTongLotMong_D) &&
                (searchData.BeTongLotMong_R == null || x.BeTongLotMong_R == searchData.BeTongLotMong_R) &&
                (searchData.BeTongLotMong_C == null || x.BeTongLotMong_C == searchData.BeTongLotMong_C) &&
                (searchData.BeTongMongHoGa_D == null || x.BeTongMongHoGa_D == searchData.BeTongMongHoGa_D) &&
                (searchData.BeTongMongHoGa_R == null || x.BeTongMongHoGa_R == searchData.BeTongMongHoGa_R) &&
                (searchData.BeTongMongHoGa_C == null || x.BeTongMongHoGa_C == searchData.BeTongMongHoGa_C) &&
                (searchData.DeHoGa_D == null || x.DeHoGa_D == searchData.DeHoGa_D) &&
                (searchData.DeHoGa_R == null || x.DeHoGa_R == searchData.DeHoGa_R) &&
                (searchData.DeHoGa_C == null || x.DeHoGa_C == searchData.DeHoGa_C) &&
                (searchData.TuongHoGa_D == null || x.TuongHoGa_D == searchData.TuongHoGa_D) &&
                (searchData.TuongHoGa_R == null || x.TuongHoGa_R == searchData.TuongHoGa_R) &&
                (searchData.TuongHoGa_C == null || x.TuongHoGa_C == searchData.TuongHoGa_C) &&
                (searchData.TuongHoGa_CdTuong == null || x.TuongHoGa_CdTuong == searchData.TuongHoGa_CdTuong) &&
                (searchData.DamGiuaHoGa_D == null || x.DamGiuaHoGa_D == searchData.DamGiuaHoGa_D) &&
                (searchData.DamGiuaHoGa_R == null || x.DamGiuaHoGa_R == searchData.DamGiuaHoGa_R) &&
                (searchData.DamGiuaHoGa_C == null || x.DamGiuaHoGa_C == searchData.DamGiuaHoGa_C) &&
                (searchData.DamGiuaHoGa_CdDam == null || x.DamGiuaHoGa_CdDam == searchData.DamGiuaHoGa_CdDam) &&
                (searchData.DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa == null || x.DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa == searchData.DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa) &&
                (searchData.ChatMatTrong_D == null || x.ChatMatTrong_D == searchData.ChatMatTrong_D) &&
                (searchData.ChatMatTrong_R == null || x.ChatMatTrong_R == searchData.ChatMatTrong_R) &&
                (searchData.ChatMatTrong_C == null || x.ChatMatTrong_C == searchData.ChatMatTrong_C) &&
                (searchData.ChatMatNgoaiCanh_D == null || x.ChatMatNgoaiCanh_D == searchData.ChatMatNgoaiCanh_D) &&
                (searchData.ChatMatNgoaiCanh_R == null || x.ChatMatNgoaiCanh_R == searchData.ChatMatNgoaiCanh_R) &&
                (searchData.ChatMatNgoaiCanh_C == null || x.ChatMatNgoaiCanh_C == searchData.ChatMatNgoaiCanh_C) &&
                (searchData.MuMoThotDuoi_D == null || x.MuMoThotDuoi_D == searchData.MuMoThotDuoi_D) &&
                (searchData.MuMoThotDuoi_R == null || x.MuMoThotDuoi_R == searchData.MuMoThotDuoi_R) &&
                (searchData.MuMoThotDuoi_C == null || x.MuMoThotDuoi_C == searchData.MuMoThotDuoi_C) &&
                (searchData.MuMoThotDuoi_CdTuong == null || x.MuMoThotDuoi_CdTuong == searchData.MuMoThotDuoi_CdTuong) &&
                (searchData.MuMoThotTren_D == null || x.MuMoThotTren_D == searchData.MuMoThotTren_D) &&
                (searchData.MuMoThotTren_R == null || x.MuMoThotTren_R == searchData.MuMoThotTren_R) &&
                (searchData.MuMoThotTren_C == null || x.MuMoThotTren_C == searchData.MuMoThotTren_C) &&
                (searchData.MuMoThotTren_CdTuong == null || x.MuMoThotTren_CdTuong == searchData.MuMoThotTren_CdTuong) &&
                (searchData.HinhThucDauNoi1_Loai == null || x.HinhThucDauNoi1_Loai == searchData.HinhThucDauNoi1_Loai) &&
                (searchData.HinhThucDauNoi1_CanhDai == null || x.HinhThucDauNoi1_CanhDai == searchData.HinhThucDauNoi1_CanhDai) &&
                (searchData.HinhThucDauNoi1_CanhRong == null || x.HinhThucDauNoi1_CanhRong == searchData.HinhThucDauNoi1_CanhRong) &&
                (searchData.HinhThucDauNoi1_CanhCheo == null || x.HinhThucDauNoi1_CanhCheo == searchData.HinhThucDauNoi1_CanhCheo) &&
                (searchData.HinhThucDauNoi2_Loai == null || x.HinhThucDauNoi2_Loai == searchData.HinhThucDauNoi2_Loai) &&
                (searchData.HinhThucDauNoi2_CanhDai == null || x.HinhThucDauNoi2_CanhDai == searchData.HinhThucDauNoi2_CanhDai) &&
                (searchData.HinhThucDauNoi2_CanhRong == null || x.HinhThucDauNoi2_CanhRong == searchData.HinhThucDauNoi2_CanhRong) &&
                (searchData.HinhThucDauNoi2_CanhCheo == null || x.HinhThucDauNoi2_CanhCheo == searchData.HinhThucDauNoi2_CanhCheo) &&
                (searchData.HinhThucDauNoi3_Loai == null || x.HinhThucDauNoi3_Loai == searchData.HinhThucDauNoi3_Loai) &&
                (searchData.HinhThucDauNoi3_CanhDai == null || x.HinhThucDauNoi3_CanhDai == searchData.HinhThucDauNoi3_CanhDai) &&
                (searchData.HinhThucDauNoi3_CanhRong == null || x.HinhThucDauNoi3_CanhRong == searchData.HinhThucDauNoi3_CanhRong) &&
                (searchData.HinhThucDauNoi3_CanhCheo == null || x.HinhThucDauNoi3_CanhCheo == searchData.HinhThucDauNoi3_CanhCheo) &&
                (searchData.HinhThucDauNoi4_Loai == null || x.HinhThucDauNoi4_Loai == searchData.HinhThucDauNoi4_Loai) &&
                (searchData.HinhThucDauNoi4_CanhDai == null || x.HinhThucDauNoi4_CanhDai == searchData.HinhThucDauNoi4_CanhDai) &&
                (searchData.HinhThucDauNoi4_CanhRong == null || x.HinhThucDauNoi4_CanhRong == searchData.HinhThucDauNoi4_CanhRong) &&
                (searchData.HinhThucDauNoi4_CanhCheo == null || x.HinhThucDauNoi4_CanhCheo == searchData.HinhThucDauNoi4_CanhCheo) &&
                (searchData.HinhThucDauNoi5_Loai == null || x.HinhThucDauNoi5_Loai == searchData.HinhThucDauNoi5_Loai) &&
                (searchData.HinhThucDauNoi5_CanhDai == null || x.HinhThucDauNoi5_CanhDai == searchData.HinhThucDauNoi5_CanhDai) &&
                (searchData.HinhThucDauNoi5_CanhRong == null || x.HinhThucDauNoi5_CanhRong == searchData.HinhThucDauNoi5_CanhRong) &&
                (searchData.HinhThucDauNoi5_CanhCheo == null || x.HinhThucDauNoi5_CanhCheo == searchData.HinhThucDauNoi5_CanhCheo) &&
                (searchData.HinhThucDauNoi6_Loai == null || x.HinhThucDauNoi6_Loai == searchData.HinhThucDauNoi6_Loai) &&
                (searchData.HinhThucDauNoi6_CanhDai == null || x.HinhThucDauNoi6_CanhDai == searchData.HinhThucDauNoi6_CanhDai) &&
                (searchData.HinhThucDauNoi6_CanhRong == null || x.HinhThucDauNoi6_CanhRong == searchData.HinhThucDauNoi6_CanhRong) &&
                (searchData.HinhThucDauNoi6_CanhCheo == null || x.HinhThucDauNoi6_CanhCheo == searchData.HinhThucDauNoi6_CanhCheo) &&
                (searchData.HinhThucDauNoi7_Loai == null || x.HinhThucDauNoi7_Loai == searchData.HinhThucDauNoi7_Loai) &&
                (searchData.HinhThucDauNoi7_CanhDai == null || x.HinhThucDauNoi7_CanhDai == searchData.HinhThucDauNoi7_CanhDai) &&
                (searchData.HinhThucDauNoi7_CanhRong == null || x.HinhThucDauNoi7_CanhRong == searchData.HinhThucDauNoi7_CanhRong) &&
                (searchData.HinhThucDauNoi7_CanhCheo == null || x.HinhThucDauNoi7_CanhCheo == searchData.HinhThucDauNoi7_CanhCheo) &&
                (searchData.HinhThucDauNoi8_Loai == null || x.HinhThucDauNoi8_Loai == searchData.HinhThucDauNoi8_Loai) &&
                (searchData.HinhThucDauNoi8_CanhDai == null || x.HinhThucDauNoi8_CanhDai == searchData.HinhThucDauNoi8_CanhDai) &&
                (searchData.HinhThucDauNoi8_CanhRong == null || x.HinhThucDauNoi8_CanhRong == searchData.HinhThucDauNoi8_CanhRong) &&
                (searchData.HinhThucDauNoi8_CanhCheo == null || x.HinhThucDauNoi8_CanhCheo == searchData.HinhThucDauNoi8_CanhCheo)
            );

            var result = await query.SingleOrDefaultAsync();
           
        }


        public async Task Update(PhanLoaiHoGa phanloaihoga)
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

        public async Task UpdateMulti(PhanLoaiHoGa[] phanloaihoga)
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

                context.Set<PhanLoaiHoGa>().Remove(entity);
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

            public async Task<PhanLoaiHoGa> GetById(string id)
            {
                using var context = _context.CreateDbContext();
                var entity = await context.DSPhanLoaiHoGa.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

                if (entity == null)
                {
                    throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
                }

                return entity;
            }

        public async Task Insert(PhanLoaiHoGa entity)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                // Kiểm tra xem bảng có bản ghi nào không
                var maxFlag = await context.DSPhanLoaiHoGa.AnyAsync()
                              ? await context.DSPhanLoaiHoGa.MaxAsync(x => x.Flag)
                              : 0;

                // Tăng giá trị Flag lên 1
                entity.Flag = maxFlag + 1;

                // Chèn bản ghi mới vào bảng
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
