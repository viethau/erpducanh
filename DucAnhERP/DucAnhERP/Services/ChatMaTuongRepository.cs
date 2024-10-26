using DucAnhERP.Data;
using DucAnhERP.Models;
using DucAnhERP.Repository;
using DucAnhERP.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace DucAnhERP.Services
{
    public class ChatMaTuongRepository :IChatMaTuongRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;

        public ChatMaTuongRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }
        public async Task<List<MaTuong>> GetAll()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.MaTuongs.ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }
        public async Task<MaTuong> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.MaTuongs.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            return entity;
        }

        public async Task<List<MaTuongModel>> GetAllByVM(MaTuongModel mModel)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var query = from a in context.MaTuongs
                            join b in context.PhanLoaiHoGas
                            on a.ThongTinChungHoGa_TenHoGaSauPhanLoai equals b.Id into plHoGaGroup
                            from b in plHoGaGroup.DefaultIfEmpty()
                            join KLBoSung1 in context.DSDanhMuc
                               on a.HinhThucDauNoi1_KLBoSung equals KLBoSung1.Id into gj26
                            from KLBoSung1 in gj26.DefaultIfEmpty() // Left join for HinhThucDauNoi1_KLBoSung

                            join KLBoSung2 in context.DSDanhMuc
                              on a.HinhThucDauNoi2_KLBoSung equals KLBoSung2.Id into gj27
                            from KLBoSung2 in gj27.DefaultIfEmpty() // Left join for HinhThucDauNoi2_KLBoSung

                            join KLBoSung3 in context.DSDanhMuc
                              on a.HinhThucDauNoi3_KLBoSung equals KLBoSung3.Id into gj28
                            from KLBoSung3 in gj28.DefaultIfEmpty() // Left join for HinhThucDauNoi2_KLBoSung

                            join KLBoSung4 in context.DSDanhMuc
                              on a.HinhThucDauNoi4_KLBoSung equals KLBoSung4.Id into gj29
                            from KLBoSung4 in gj29.DefaultIfEmpty() // Left join for HinhThucDauNoi4_KLBoSung

                            join KLBoSung5 in context.DSDanhMuc
                              on a.HinhThucDauNoi5_KLBoSung equals KLBoSung5.Id into gj30
                            from KLBoSung5 in gj30.DefaultIfEmpty() // Left join for HinhThucDauNoi5_KLBoSung

                            join KLBoSung6 in context.DSDanhMuc
                              on a.HinhThucDauNoi6_KLBoSung equals KLBoSung6.Id into gj31
                            from KLBoSung6 in gj31.DefaultIfEmpty() // Left join for HinhThucDauNoi6_KLBoSung

                            join KLBoSung7 in context.DSDanhMuc
                              on a.HinhThucDauNoi7_KLBoSung equals KLBoSung7.Id into gj32
                            from KLBoSung7 in gj32.DefaultIfEmpty() // Left join for HinhThucDauNoi7_KLBoSung

                            join KLBoSung8 in context.DSDanhMuc
                              on a.HinhThucDauNoi8_KLBoSung equals KLBoSung8.Id into gj33
                            from KLBoSung8 in gj33.DefaultIfEmpty() // Left join for HinhThucDauNoi8_KLBoSung

                            orderby a.CreateAt
                            select new MaTuongModel
                            {
                                Id = a.Id,
                                Flag = a.Flag,

                                ThongTinChungHoGa_TenHoGaSauPhanLoai = a.ThongTinChungHoGa_TenHoGaSauPhanLoai,
                                ThongTinChungHoGa_TenHoGaSauPhanLoai_Name = b.ThongTinChungHoGa_TenHoGaSauPhanLoai,
                                KLGX_TenCongTac = a.KLGX_TenCongTac,
                                KLGX_KL = a.KLGX_KL,
                                KLC_TenCongTac = a.KLC_TenCongTac,
                                KLC_KL = a.KLC_KL,
                                KLBT_TenCongTac = a.KLBT_TenCongTac??"",
                                KLBT_KL = a.KLBT_KL,
                                KLVK_TenCongTac = a.KLVK_TenCongTac ?? "",
                                KLVK_KL = a.KLVK_KL,
                                KLS_TenCongTac = a.KLS_TenCongTac ?? "",
                                KLS_KL = a.KLS_KL,
                                KLS_TenCongTac1 = a.KLS_TenCongTac1,
                                KLS_KL1 = a.KLS_KL1,
  
                                HinhThucDauNoi1_Loai = a.HinhThucDauNoi1_Loai,
                                HinhThucDauNoi1_KLBoSung = a.HinhThucDauNoi1_KLBoSung,
                                HinhThucDauNoi1_KLBoSung_Name = KLBoSung1.Ten,
                                HinhThucDauNoi1_CanhDai = a.HinhThucDauNoi1_CanhDai,
                                HinhThucDauNoi1_CDD = a.HinhThucDauNoi1_CDD,
                                HinhThucDauNoi1_CDR = a.HinhThucDauNoi1_CDR,
                                HinhThucDauNoi1_CDC = a.HinhThucDauNoi1_CDC,
                                HinhThucDauNoi1_CanhRong = a.HinhThucDauNoi1_CanhRong,
                                HinhThucDauNoi1_CRD = a.HinhThucDauNoi1_CRD,
                                HinhThucDauNoi1_CRR = a.HinhThucDauNoi1_CRR,
                                HinhThucDauNoi1_CRC = a.HinhThucDauNoi1_CRC,
                                HinhThucDauNoi1_CanhCheo = a.HinhThucDauNoi1_CanhCheo,
                                HinhThucDauNoi1_CCD = a.HinhThucDauNoi1_CCD,
                                HinhThucDauNoi1_CCR = a.HinhThucDauNoi1_CCR,
                                HinhThucDauNoi1_CCC = a.HinhThucDauNoi1_CCC,
                                HinhThucDauNoi2_Loai = a.HinhThucDauNoi2_Loai,
                                HinhThucDauNoi2_KLBoSung = a.HinhThucDauNoi2_KLBoSung,
                                HinhThucDauNoi2_KLBoSung_Name = KLBoSung2.Ten,
                                HinhThucDauNoi2_CanhDai = a.HinhThucDauNoi2_CanhDai,
                                HinhThucDauNoi2_CDD = a.HinhThucDauNoi2_CDD,
                                HinhThucDauNoi2_CDR = a.HinhThucDauNoi2_CDR,
                                HinhThucDauNoi2_CDC = a.HinhThucDauNoi2_CDC,
                                HinhThucDauNoi2_CanhRong = a.HinhThucDauNoi2_CanhRong,
                                HinhThucDauNoi2_CRD = a.HinhThucDauNoi2_CRD,
                                HinhThucDauNoi2_CRR = a.HinhThucDauNoi2_CRR,
                                HinhThucDauNoi2_CRC = a.HinhThucDauNoi2_CRC,
                                HinhThucDauNoi2_CanhCheo = a.HinhThucDauNoi2_CanhCheo,
                                HinhThucDauNoi2_CCD = a.HinhThucDauNoi2_CCD,
                                HinhThucDauNoi2_CCR = a.HinhThucDauNoi2_CCR,
                                HinhThucDauNoi2_CCC = a.HinhThucDauNoi2_CCC,
                                HinhThucDauNoi3_Loai = a.HinhThucDauNoi3_Loai,
                                HinhThucDauNoi3_KLBoSung = a.HinhThucDauNoi3_KLBoSung,
                                HinhThucDauNoi3_KLBoSung_Name = KLBoSung3.Ten,
                                HinhThucDauNoi3_CanhDai = a.HinhThucDauNoi3_CanhDai,
                                HinhThucDauNoi3_CDD = a.HinhThucDauNoi3_CDD,
                                HinhThucDauNoi3_CDR = a.HinhThucDauNoi3_CDR,
                                HinhThucDauNoi3_CDC = a.HinhThucDauNoi3_CDC,
                                HinhThucDauNoi3_CanhRong = a.HinhThucDauNoi3_CanhRong,
                                HinhThucDauNoi3_CRD = a.HinhThucDauNoi3_CRD,
                                HinhThucDauNoi3_CRR = a.HinhThucDauNoi3_CRR,
                                HinhThucDauNoi3_CRC = a.HinhThucDauNoi3_CRC,
                                HinhThucDauNoi3_CanhCheo = a.HinhThucDauNoi3_CanhCheo,
                                HinhThucDauNoi3_CCD = a.HinhThucDauNoi3_CCD,
                                HinhThucDauNoi3_CCR = a.HinhThucDauNoi3_CCR,
                                HinhThucDauNoi3_CCC = a.HinhThucDauNoi3_CCC,
                                HinhThucDauNoi4_Loai = a.HinhThucDauNoi4_Loai,
                                HinhThucDauNoi4_KLBoSung = a.HinhThucDauNoi4_KLBoSung,
                                HinhThucDauNoi4_KLBoSung_Name = KLBoSung4.Ten,
                                HinhThucDauNoi4_CanhDai = a.HinhThucDauNoi4_CanhDai,
                                HinhThucDauNoi4_CDD = a.HinhThucDauNoi4_CDD,
                                HinhThucDauNoi4_CDR = a.HinhThucDauNoi4_CDR,
                                HinhThucDauNoi4_CDC = a.HinhThucDauNoi4_CDC,
                                HinhThucDauNoi4_CanhRong = a.HinhThucDauNoi4_CanhRong,
                                HinhThucDauNoi4_CRD = a.HinhThucDauNoi4_CRD,
                                HinhThucDauNoi4_CRR = a.HinhThucDauNoi4_CRR,
                                HinhThucDauNoi4_CRC = a.HinhThucDauNoi4_CRC,
                                HinhThucDauNoi4_CanhCheo = a.HinhThucDauNoi4_CanhCheo,
                                HinhThucDauNoi4_CCD = a.HinhThucDauNoi4_CCD,
                                HinhThucDauNoi4_CCR = a.HinhThucDauNoi4_CCR,
                                HinhThucDauNoi4_CCC = a.HinhThucDauNoi4_CCC,
                                HinhThucDauNoi5_Loai = a.HinhThucDauNoi5_Loai,
                                HinhThucDauNoi5_KLBoSung = a.HinhThucDauNoi5_KLBoSung,
                                HinhThucDauNoi5_KLBoSung_Name = KLBoSung5.Ten,
                                HinhThucDauNoi5_CanhDai = a.HinhThucDauNoi5_CanhDai,
                                HinhThucDauNoi5_CDD = a.HinhThucDauNoi5_CDD,
                                HinhThucDauNoi5_CDR = a.HinhThucDauNoi5_CDR,
                                HinhThucDauNoi5_CDC = a.HinhThucDauNoi5_CDC,
                                HinhThucDauNoi5_CanhRong = a.HinhThucDauNoi5_CanhRong,
                                HinhThucDauNoi5_CRD = a.HinhThucDauNoi5_CRD,
                                HinhThucDauNoi5_CRR = a.HinhThucDauNoi5_CRR,
                                HinhThucDauNoi5_CRC = a.HinhThucDauNoi5_CRC,
                                HinhThucDauNoi5_CanhCheo = a.HinhThucDauNoi5_CanhCheo,
                                HinhThucDauNoi5_CCD = a.HinhThucDauNoi5_CCD,
                                HinhThucDauNoi5_CCR = a.HinhThucDauNoi5_CCR,
                                HinhThucDauNoi5_CCC = a.HinhThucDauNoi5_CCC,
                                HinhThucDauNoi6_Loai = a.HinhThucDauNoi6_Loai,
                                HinhThucDauNoi6_KLBoSung = a.HinhThucDauNoi6_KLBoSung,
                                HinhThucDauNoi6_KLBoSung_Name = KLBoSung6.Ten,
                                HinhThucDauNoi6_CanhDai = a.HinhThucDauNoi6_CanhDai,
                                HinhThucDauNoi6_CDD = a.HinhThucDauNoi6_CDD,
                                HinhThucDauNoi6_CDR = a.HinhThucDauNoi6_CDR,
                                HinhThucDauNoi6_CDC = a.HinhThucDauNoi6_CDC,
                                HinhThucDauNoi6_CanhRong = a.HinhThucDauNoi6_CanhRong,
                                HinhThucDauNoi6_CRD = a.HinhThucDauNoi6_CRD,
                                HinhThucDauNoi6_CRR = a.HinhThucDauNoi6_CRR,
                                HinhThucDauNoi6_CRC = a.HinhThucDauNoi6_CRC,
                                HinhThucDauNoi6_CanhCheo = a.HinhThucDauNoi6_CanhCheo,
                                HinhThucDauNoi6_CCD = a.HinhThucDauNoi6_CCD,
                                HinhThucDauNoi6_CCR = a.HinhThucDauNoi6_CCR,
                                HinhThucDauNoi6_CCC = a.HinhThucDauNoi6_CCC,
                                HinhThucDauNoi7_Loai = a.HinhThucDauNoi7_Loai,
                                HinhThucDauNoi7_KLBoSung = a.HinhThucDauNoi7_KLBoSung,
                                HinhThucDauNoi7_KLBoSung_Name = KLBoSung7.Ten,
                                HinhThucDauNoi7_CanhDai = a.HinhThucDauNoi7_CanhDai,
                                HinhThucDauNoi7_CDD = a.HinhThucDauNoi7_CDD,
                                HinhThucDauNoi7_CDR = a.HinhThucDauNoi7_CDR,
                                HinhThucDauNoi7_CDC = a.HinhThucDauNoi7_CDC,
                                HinhThucDauNoi7_CanhRong = a.HinhThucDauNoi7_CanhRong,
                                HinhThucDauNoi7_CRD = a.HinhThucDauNoi7_CRD,
                                HinhThucDauNoi7_CRR = a.HinhThucDauNoi7_CRR,
                                HinhThucDauNoi7_CRC = a.HinhThucDauNoi7_CRC,
                                HinhThucDauNoi7_CanhCheo = a.HinhThucDauNoi7_CanhCheo,
                                HinhThucDauNoi7_CCD = a.HinhThucDauNoi7_CCD,
                                HinhThucDauNoi7_CCR = a.HinhThucDauNoi7_CCR,
                                HinhThucDauNoi7_CCC = a.HinhThucDauNoi7_CCC,
                                HinhThucDauNoi8_Loai = a.HinhThucDauNoi8_Loai,
                                HinhThucDauNoi8_KLBoSung = a.HinhThucDauNoi8_KLBoSung,
                                HinhThucDauNoi8_KLBoSung_Name = KLBoSung8.Ten,
                                HinhThucDauNoi8_CanhDai = a.HinhThucDauNoi8_CanhDai,
                                HinhThucDauNoi8_CDD = a.HinhThucDauNoi8_CDD,
                                HinhThucDauNoi8_CDR = a.HinhThucDauNoi8_CDR,
                                HinhThucDauNoi8_CDC = a.HinhThucDauNoi8_CDC,
                                HinhThucDauNoi8_CanhRong = a.HinhThucDauNoi8_CanhRong,
                                HinhThucDauNoi8_CRD = a.HinhThucDauNoi8_CRD,
                                HinhThucDauNoi8_CRR = a.HinhThucDauNoi8_CRR,
                                HinhThucDauNoi8_CRC = a.HinhThucDauNoi8_CRC,
                                HinhThucDauNoi8_CanhCheo = a.HinhThucDauNoi8_CanhCheo,
                                HinhThucDauNoi8_CCD = a.HinhThucDauNoi8_CCD,
                                HinhThucDauNoi8_CCR = a.HinhThucDauNoi8_CCR,
                                HinhThucDauNoi8_CCC = a.HinhThucDauNoi8_CCC,

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
        public async Task<List<MaTuong>> GetExist(MaTuong searchData)
        {
            try
            {
                using var context = _context.CreateDbContext();

                // Thực hiện lọc dữ liệu dựa trên các thuộc tính của searchData
                var query = context.MaTuongs
                             .Where(item => (
                                    item.ThongTinChungHoGa_TenHoGaSauPhanLoai == searchData.ThongTinChungHoGa_TenHoGaSauPhanLoai
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
        public async Task<MaTuongModel> GetDetailByIdPLHoGa(string id)
        {
            if (id == null || string.IsNullOrWhiteSpace(id))
            {
                return new MaTuongModel(); 
            }

            try
            {
                using var context = _context.CreateDbContext();

                var query = from nuocMua in context.DSNuocMua
                            join plhg in context.PhanLoaiHoGas
                            on nuocMua.ThongTinChungHoGa_TenHoGaSauPhanLoai equals plhg.Id into plhgGroup
                            from plhg in plhgGroup.DefaultIfEmpty()
                            where nuocMua.ThongTinChungHoGa_TenHoGaSauPhanLoai == id
                            orderby nuocMua.CreateAt 
                            select new MaTuongModel
                            {
                                ThongTinChungHoGa_TenHoGaSauPhanLoai = nuocMua.ThongTinChungHoGa_TenHoGaSauPhanLoai,
                                ThongTinChungHoGa_TenHoGaSauPhanLoai_Name = plhg.ThongTinChungHoGa_TenHoGaSauPhanLoai,
                                HinhThucDauNoi1_Loai = nuocMua.HinhThucDauNoi1_Loai ?? 0,
                                HinhThucDauNoi1_KLBoSung = nuocMua.HinhThucDauNoi1_KLBoSung ?? "",
                                HinhThucDauNoi1_KLBoSung_Name = "",
                                HinhThucDauNoi1_CanhDai = nuocMua.HinhThucDauNoi1_CanhDai ?? 0,
                                HinhThucDauNoi1_CDD = nuocMua.HinhThucDauNoi1_CDD ?? 0,
                                HinhThucDauNoi1_CDR = nuocMua.HinhThucDauNoi1_CDR ?? 0,
                                HinhThucDauNoi1_CDC = nuocMua.HinhThucDauNoi1_CDC ?? 0,
                                HinhThucDauNoi1_CanhRong = nuocMua.HinhThucDauNoi1_CanhRong ?? 0,
                                HinhThucDauNoi1_CRD = nuocMua.HinhThucDauNoi1_CRD ?? 0,
                                HinhThucDauNoi1_CRR = nuocMua.HinhThucDauNoi1_CRR ?? 0,
                                HinhThucDauNoi1_CRC = nuocMua.HinhThucDauNoi1_CRC ?? 0,
                                HinhThucDauNoi1_CanhCheo = nuocMua.HinhThucDauNoi1_CanhCheo ?? 0,
                                HinhThucDauNoi1_CCD = nuocMua.HinhThucDauNoi1_CCD ?? 0,
                                HinhThucDauNoi1_CCR = nuocMua.HinhThucDauNoi1_CCR ?? 0,
                                HinhThucDauNoi1_CCC = nuocMua.HinhThucDauNoi1_CCC ?? 0,
                                HinhThucDauNoi2_Loai = nuocMua.HinhThucDauNoi2_Loai ?? 0,
                                HinhThucDauNoi2_KLBoSung = nuocMua.HinhThucDauNoi2_KLBoSung ?? "",
                                HinhThucDauNoi2_KLBoSung_Name = "",
                                HinhThucDauNoi2_CanhDai = nuocMua.HinhThucDauNoi2_CanhDai ?? 0,
                                HinhThucDauNoi2_CDD = nuocMua.HinhThucDauNoi2_CDD ?? 0,
                                HinhThucDauNoi2_CDR = nuocMua.HinhThucDauNoi2_CDR ?? 0,
                                HinhThucDauNoi2_CDC = nuocMua.HinhThucDauNoi2_CDC ?? 0,
                                HinhThucDauNoi2_CanhRong = nuocMua.HinhThucDauNoi2_CanhRong ?? 0,
                                HinhThucDauNoi2_CRD = nuocMua.HinhThucDauNoi2_CRD ?? 0,
                                HinhThucDauNoi2_CRR = nuocMua.HinhThucDauNoi2_CRR ?? 0,
                                HinhThucDauNoi2_CRC = nuocMua.HinhThucDauNoi2_CRC ?? 0,
                                HinhThucDauNoi2_CanhCheo = nuocMua.HinhThucDauNoi2_CanhCheo ?? 0,
                                HinhThucDauNoi2_CCD = nuocMua.HinhThucDauNoi2_CCD ?? 0,
                                HinhThucDauNoi2_CCR = nuocMua.HinhThucDauNoi2_CCR ?? 0,
                                HinhThucDauNoi2_CCC = nuocMua.HinhThucDauNoi2_CCC ?? 0,
                                HinhThucDauNoi3_Loai = nuocMua.HinhThucDauNoi3_Loai ?? 0,
                                HinhThucDauNoi3_KLBoSung = nuocMua.HinhThucDauNoi3_KLBoSung ?? "",
                                HinhThucDauNoi3_KLBoSung_Name = "",
                                HinhThucDauNoi3_CanhDai = nuocMua.HinhThucDauNoi3_CanhDai ?? 0,
                                HinhThucDauNoi3_CDD = nuocMua.HinhThucDauNoi3_CDD ?? 0,
                                HinhThucDauNoi3_CDR = nuocMua.HinhThucDauNoi3_CDR ?? 0,
                                HinhThucDauNoi3_CDC = nuocMua.HinhThucDauNoi3_CDC ?? 0,
                                HinhThucDauNoi3_CanhRong = nuocMua.HinhThucDauNoi3_CanhRong ?? 0,
                                HinhThucDauNoi3_CRD = nuocMua.HinhThucDauNoi3_CRD ?? 0,
                                HinhThucDauNoi3_CRR = nuocMua.HinhThucDauNoi3_CRR ?? 0,
                                HinhThucDauNoi3_CRC = nuocMua.HinhThucDauNoi3_CRC ?? 0,
                                HinhThucDauNoi3_CanhCheo = nuocMua.HinhThucDauNoi3_CanhCheo ?? 0,
                                HinhThucDauNoi3_CCD = nuocMua.HinhThucDauNoi3_CCD ?? 0,
                                HinhThucDauNoi3_CCR = nuocMua.HinhThucDauNoi3_CCR ?? 0,
                                HinhThucDauNoi3_CCC = nuocMua.HinhThucDauNoi3_CCC ?? 0,
                                HinhThucDauNoi4_Loai = nuocMua.HinhThucDauNoi4_Loai ?? 0,
                                HinhThucDauNoi4_KLBoSung = nuocMua.HinhThucDauNoi4_KLBoSung ?? "",
                                HinhThucDauNoi4_KLBoSung_Name = "",
                                HinhThucDauNoi4_CanhDai = nuocMua.HinhThucDauNoi4_CanhDai ?? 0,
                                HinhThucDauNoi4_CDD = nuocMua.HinhThucDauNoi4_CDD ?? 0,
                                HinhThucDauNoi4_CDR = nuocMua.HinhThucDauNoi4_CDR ?? 0,
                                HinhThucDauNoi4_CDC = nuocMua.HinhThucDauNoi4_CDC ?? 0,
                                HinhThucDauNoi4_CanhRong = nuocMua.HinhThucDauNoi4_CanhRong ?? 0,
                                HinhThucDauNoi4_CRD = nuocMua.HinhThucDauNoi4_CRD ?? 0,
                                HinhThucDauNoi4_CRR = nuocMua.HinhThucDauNoi4_CRR ?? 0,
                                HinhThucDauNoi4_CRC = nuocMua.HinhThucDauNoi4_CRC ?? 0,
                                HinhThucDauNoi4_CanhCheo = nuocMua.HinhThucDauNoi4_CanhCheo ?? 0,
                                HinhThucDauNoi4_CCD = nuocMua.HinhThucDauNoi4_CCD ?? 0,
                                HinhThucDauNoi4_CCR = nuocMua.HinhThucDauNoi4_CCR ?? 0,
                                HinhThucDauNoi4_CCC = nuocMua.HinhThucDauNoi4_CCC ?? 0,
                                HinhThucDauNoi5_Loai = nuocMua.HinhThucDauNoi5_Loai ?? 0,
                                HinhThucDauNoi5_KLBoSung = nuocMua.HinhThucDauNoi5_KLBoSung ?? "",
                                HinhThucDauNoi5_KLBoSung_Name = "",
                                HinhThucDauNoi5_CanhDai = nuocMua.HinhThucDauNoi5_CanhDai ?? 0,
                                HinhThucDauNoi5_CDD = nuocMua.HinhThucDauNoi5_CDD ?? 0,
                                HinhThucDauNoi5_CDR = nuocMua.HinhThucDauNoi5_CDR ?? 0,
                                HinhThucDauNoi5_CDC = nuocMua.HinhThucDauNoi5_CDC ?? 0,
                                HinhThucDauNoi5_CanhRong = nuocMua.HinhThucDauNoi5_CanhRong ?? 0,
                                HinhThucDauNoi5_CRD = nuocMua.HinhThucDauNoi5_CRD ?? 0,
                                HinhThucDauNoi5_CRR = nuocMua.HinhThucDauNoi5_CRR ?? 0,
                                HinhThucDauNoi5_CRC = nuocMua.HinhThucDauNoi5_CRC ?? 0,
                                HinhThucDauNoi5_CanhCheo = nuocMua.HinhThucDauNoi5_CanhCheo ?? 0,
                                HinhThucDauNoi5_CCD = nuocMua.HinhThucDauNoi5_CCD ?? 0,
                                HinhThucDauNoi5_CCR = nuocMua.HinhThucDauNoi5_CCR ?? 0,
                                HinhThucDauNoi5_CCC = nuocMua.HinhThucDauNoi5_CCC ?? 0,
                                HinhThucDauNoi6_Loai = nuocMua.HinhThucDauNoi6_Loai ?? 0,
                                HinhThucDauNoi6_KLBoSung = nuocMua.HinhThucDauNoi6_KLBoSung ?? "",
                                HinhThucDauNoi6_KLBoSung_Name = "",
                                HinhThucDauNoi6_CanhDai = nuocMua.HinhThucDauNoi6_CanhDai ?? 0,
                                HinhThucDauNoi6_CDD = nuocMua.HinhThucDauNoi6_CDD ?? 0,
                                HinhThucDauNoi6_CDR = nuocMua.HinhThucDauNoi6_CDR ?? 0,
                                HinhThucDauNoi6_CDC = nuocMua.HinhThucDauNoi6_CDC ?? 0,
                                HinhThucDauNoi6_CanhRong = nuocMua.HinhThucDauNoi6_CanhRong ?? 0,
                                HinhThucDauNoi6_CRD = nuocMua.HinhThucDauNoi6_CRD ?? 0,
                                HinhThucDauNoi6_CRR = nuocMua.HinhThucDauNoi6_CRR ?? 0,
                                HinhThucDauNoi6_CRC = nuocMua.HinhThucDauNoi6_CRC ?? 0,
                                HinhThucDauNoi6_CanhCheo = nuocMua.HinhThucDauNoi6_CanhCheo ?? 0,
                                HinhThucDauNoi6_CCD = nuocMua.HinhThucDauNoi6_CCD ?? 0,
                                HinhThucDauNoi6_CCR = nuocMua.HinhThucDauNoi6_CCR ?? 0,
                                HinhThucDauNoi6_CCC = nuocMua.HinhThucDauNoi6_CCC ?? 0,
                                HinhThucDauNoi7_Loai = nuocMua.HinhThucDauNoi7_Loai ?? 0,
                                HinhThucDauNoi7_KLBoSung = nuocMua.HinhThucDauNoi7_KLBoSung ?? "",
                                HinhThucDauNoi7_KLBoSung_Name = "",
                                HinhThucDauNoi7_CanhDai = nuocMua.HinhThucDauNoi7_CanhDai ?? 0,
                                HinhThucDauNoi7_CDD = nuocMua.HinhThucDauNoi7_CDD ?? 0,
                                HinhThucDauNoi7_CDR = nuocMua.HinhThucDauNoi7_CDR ?? 0,
                                HinhThucDauNoi7_CDC = nuocMua.HinhThucDauNoi7_CDC ?? 0,
                                HinhThucDauNoi7_CanhRong = nuocMua.HinhThucDauNoi7_CanhRong ?? 0,
                                HinhThucDauNoi7_CRD = nuocMua.HinhThucDauNoi7_CRD ?? 0,
                                HinhThucDauNoi7_CRR = nuocMua.HinhThucDauNoi7_CRR ?? 0,
                                HinhThucDauNoi7_CRC = nuocMua.HinhThucDauNoi7_CRC ?? 0,
                                HinhThucDauNoi7_CanhCheo = nuocMua.HinhThucDauNoi7_CanhCheo ?? 0,
                                HinhThucDauNoi7_CCD = nuocMua.HinhThucDauNoi7_CCD ?? 0,
                                HinhThucDauNoi7_CCR = nuocMua.HinhThucDauNoi7_CCR ?? 0,
                                HinhThucDauNoi7_CCC = nuocMua.HinhThucDauNoi7_CCC ?? 0,
                                HinhThucDauNoi8_Loai = nuocMua.HinhThucDauNoi8_Loai ?? 0,
                                HinhThucDauNoi8_KLBoSung = nuocMua.HinhThucDauNoi8_KLBoSung ?? "",
                                HinhThucDauNoi8_KLBoSung_Name = "",
                                HinhThucDauNoi8_CanhDai = nuocMua.HinhThucDauNoi8_CanhDai ?? 0,
                                HinhThucDauNoi8_CDD = nuocMua.HinhThucDauNoi8_CDD ?? 0,
                                HinhThucDauNoi8_CDR = nuocMua.HinhThucDauNoi8_CDR ?? 0,
                                HinhThucDauNoi8_CDC = nuocMua.HinhThucDauNoi8_CDC ?? 0,
                                HinhThucDauNoi8_CanhRong = nuocMua.HinhThucDauNoi8_CanhRong ?? 0,
                                HinhThucDauNoi8_CRD = nuocMua.HinhThucDauNoi8_CRD ?? 0,
                                HinhThucDauNoi8_CRR = nuocMua.HinhThucDauNoi8_CRR ?? 0,
                                HinhThucDauNoi8_CRC = nuocMua.HinhThucDauNoi8_CRC ?? 0,
                                HinhThucDauNoi8_CanhCheo = nuocMua.HinhThucDauNoi8_CanhCheo ?? 0,
                                HinhThucDauNoi8_CCD = nuocMua.HinhThucDauNoi8_CCD ?? 0,
                                HinhThucDauNoi8_CCR = nuocMua.HinhThucDauNoi8_CCR ?? 0,
                                HinhThucDauNoi8_CCC = nuocMua.HinhThucDauNoi8_CCC ?? 0,
                            };
                var result = await query.FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }
        public async Task Update(MaTuong MaTuong)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(MaTuong.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {MaTuong.Id}");
            }

            context.MaTuongs.Update(MaTuong);
            await context.SaveChangesAsync();
        }
        public async Task UpdateMulti(MaTuong[] MaTuong)
        {
            using var context = _context.CreateDbContext();
            string[] ids = MaTuong.Select(x => x.Id).ToArray();
            var listEntities = await context.MaTuongs.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.MaTuongs.Update(entity);
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

            context.Set<MaTuong>().Remove(entity);
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
        public async Task Insert(MaTuong entity)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }
                // Kiểm tra xem bảng có bản ghi nào không
                var maxFlag = await context.MaTuongs.AnyAsync()
                              ? await context.MaTuongs.MaxAsync(x => x.Flag)
                              : 0;

                // Tăng giá trị Flag lên 1
                entity.Flag = maxFlag + 1;

                // Chèn bản ghi mới vào bảng
                context.MaTuongs.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public async Task<string> InsertLaterFlag(MaTuong entity, int FlagLast)
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
                var recordsToUpdate = await context.MaTuongs
                     .Where(x => x.Flag > FlagLast)
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
                    var maxFlag = await context.MaTuongs.AnyAsync()
                                  ? await context.MaTuongs.MaxAsync(x => x.Flag)
                                  : 0;

                    // Tăng giá trị Flag lên 1
                    entity.Flag = maxFlag + 1;
                }
                else
                {
                    entity.Flag = FlagLast + 1;
                }

                // Bước 4: Chèn bản ghi mới vào bảng
                context.MaTuongs.Add(entity);

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
