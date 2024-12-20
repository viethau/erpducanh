using DucAnhERP.Data;
using DucAnhERP.Models;
using DucAnhERP.ViewModel;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using DucAnhERP.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using DucAnhERP.Components.Pages.NghiepVuCongTrinh.PKKL;

namespace DucAnhERP.Services
{
    public class PKKLCTietHoGaRepository :IPKKLCTietHoGaRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;

        public PKKLCTietHoGaRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }
        public async Task<List<PKKLCTietHoGa>> GetAll()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.PKKLCTietHoGas.ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }
        public async Task<PKKLCTietHoGa> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.PKKLCTietHoGas.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            return entity;
        }
        public async Task<List<PKKLCTietHoGaModel>> GetAllByVM(PKKLCTietHoGaModel mModel)
        {
            try
            {
                using var context = _context.CreateDbContext();
                List<PKKLCTietHoGaModel> data = new();
                var query = from a in context.PKKLCTietHoGas
                            join b in context.PhanLoaiHoGaDetails
                            on a.ThongTinChungHoGa_TenHoGaSauPhanLoai equals b.Id
                            orderby b.ThongTinChungHoGa_TenHoGaSauPhanLoai ascending, a.HangMuc ascending, a.LoaiBeTong descending, a.CreateAt ascending
                            select new PKKLCTietHoGaModel
                            {
                                Id = a.Id,
                                Flag= a.Flag,
                                LoaiCauKien = b.ThongTinChungHoGa_TenHoGaSauPhanLoai ?? "",
                                LoaiCauKienId = a.ThongTinChungHoGa_TenHoGaSauPhanLoai,
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
                                KLKP_KL = a.KLKP_KL,
                                KL1CK_ChuaTruCC = a.KL1CK_ChuaTruCC,
                                KLCC1CK = a.KLCC1CK,
                                TKLCK_SauCC = a.TKLCK_SauCC,
                                CreateAt = a.CreateAt,
                                CreateBy = a.CreateBy,
                                IsActive = a.IsActive
                            };

                if (!string.IsNullOrEmpty(mModel.HangMuc))
                {
                    query = query.Where(x => x.HangMuc == mModel.HangMuc);
                }
                if (!string.IsNullOrEmpty(mModel.TenCongTac))
                {
                    query = query.Where(x => x.TenCongTac == mModel.TenCongTac);
                }
                if (!string.IsNullOrEmpty(mModel.LoaiCauKienId))
                {
                    query = query.Where(x => x.LoaiCauKienId == mModel.LoaiCauKienId);
                }

                data = await query.ToListAsync();

                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }

        }

        public async Task<List<THKLModel>> GetTHKL1HoGa()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var query = (from a in context.PKKLCTietHoGas
                             join b in context.PhanLoaiHoGaDetails
                             on a.ThongTinChungHoGa_TenHoGaSauPhanLoai equals b.Id
                             let kl1Dv = context.PKKLCTietHoGas
                                 .Where(x => x.ThongTinChungHoGa_TenHoGaSauPhanLoai == a.ThongTinChungHoGa_TenHoGaSauPhanLoai
                                          && x.LoaiBeTong == a.LoaiBeTong
                                          && x.HangMuc == a.HangMuc
                                          && x.HangMucCongTac == a.HangMucCongTac
                                          && x.TenCongTac == a.TenCongTac)
                                 .Sum(x => x.TKLCK_SauCC)
                             orderby b.ThongTinChungHoGa_TenHoGaSauPhanLoai, a.HangMuc, a.CreateAt
                             select new THKLModel
                             {
                                 PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai = b.ThongTinChungHoGa_TenHoGaSauPhanLoai ?? "",
                                 ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = a.ThongTinChungHoGa_TenHoGaSauPhanLoai,
                                 HangMucCongTac = a.HangMucCongTac,
                                 TenCongTac = a.TenCongTac,
                                 DonVi = a.DonVi,
                                 KL1DonVi = kl1Dv,

                             }).ToList();
                return query;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }

        }
        public async Task<List<THKLModel>> GetTHKLByTuyenDuong(string TuyenDuong)
        {
            try
            {
                using var context = _context.CreateDbContext();

                var query = (from a in context.PKKLCTietHoGas
                             join b in context.PhanLoaiHoGaDetails on a.ThongTinChungHoGa_TenHoGaSauPhanLoai equals b.Id
                             orderby a.Flag ascending
                             select new THKLModel
                             {
                                 Id = a.Id,
                                 ThongTinLyTrinh_TuyenDuong = TuyenDuong,
                                 ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = a.ThongTinChungHoGa_TenHoGaSauPhanLoai,
                                 PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai = b.ThongTinChungHoGa_TenHoGaSauPhanLoai,
                                 TenCongTac = a.TenCongTac,
                                 DonVi = a.DonVi,
                                 KL1DonVi = a.TKLCK_SauCC,
                                 SLTrai = (from n in (from n in context.DSNuocMua select new { n.ThongTinLyTrinh_TuyenDuong, n.ThongTinChungHoGa_TenHoGaTheoBanVe, n.ThongTinChungHoGa_TenHoGaSauPhanLoai, n.TraiPhai, G = n.ThongTinChungHoGa_TenHoGaTheoBanVe.EndsWith("=G") ? "=G" : "", n.CreateAt })
                                           join p in context.PhanLoaiHoGaDetails
                                               on new { Id_PhanLoaiHoGa = n.ThongTinChungHoGa_TenHoGaSauPhanLoai, n.G }
                                               equals new { Id_PhanLoaiHoGa = (string)p.Id_PhanLoaiHoGa, p.G }
                                           where n.TraiPhai == 0 && n.ThongTinLyTrinh_TuyenDuong == TuyenDuong && p.Id == a.ThongTinChungHoGa_TenHoGaSauPhanLoai
                                           select 1).Any() ? 1 : 0,
                                 SLPhai = (from n in (from n in context.DSNuocMua select new { n.ThongTinLyTrinh_TuyenDuong, n.ThongTinChungHoGa_TenHoGaTheoBanVe, n.ThongTinChungHoGa_TenHoGaSauPhanLoai, n.TraiPhai, G = n.ThongTinChungHoGa_TenHoGaTheoBanVe.EndsWith("=G") ? "=G" : "", n.CreateAt })
                                           join p in context.PhanLoaiHoGaDetails
                                               on new { Id_PhanLoaiHoGa = n.ThongTinChungHoGa_TenHoGaSauPhanLoai, n.G }
                                               equals new { Id_PhanLoaiHoGa = (string)p.Id_PhanLoaiHoGa, p.G }
                                           where n.TraiPhai == 1 && n.ThongTinLyTrinh_TuyenDuong == TuyenDuong && p.Id == a.ThongTinChungHoGa_TenHoGaSauPhanLoai
                                           select 1).Any() ? 1 : 0,


                                 SLTong = ((from n in (from n in context.DSNuocMua select new { n.ThongTinLyTrinh_TuyenDuong, n.ThongTinChungHoGa_TenHoGaTheoBanVe, n.ThongTinChungHoGa_TenHoGaSauPhanLoai, n.TraiPhai, G = n.ThongTinChungHoGa_TenHoGaTheoBanVe.EndsWith("=G") ? "=G" : "", n.CreateAt })
                                            join p in context.PhanLoaiHoGaDetails
                                               on new { Id_PhanLoaiHoGa = n.ThongTinChungHoGa_TenHoGaSauPhanLoai, n.G }
                                               equals new { Id_PhanLoaiHoGa = (string)p.Id_PhanLoaiHoGa, p.G }
                                            where n.TraiPhai == 0 && n.ThongTinLyTrinh_TuyenDuong == TuyenDuong && p.Id == a.ThongTinChungHoGa_TenHoGaSauPhanLoai
                                            select 1).Any() ? 1 : 0) +
                                            ((from n in (from n in context.DSNuocMua select new { n.ThongTinLyTrinh_TuyenDuong, n.ThongTinChungHoGa_TenHoGaTheoBanVe, n.ThongTinChungHoGa_TenHoGaSauPhanLoai, n.TraiPhai, G = n.ThongTinChungHoGa_TenHoGaTheoBanVe.EndsWith("=G") ? "=G" : "", n.CreateAt })
                                              join p in context.PhanLoaiHoGaDetails
                                               on new { Id_PhanLoaiHoGa = n.ThongTinChungHoGa_TenHoGaSauPhanLoai, n.G }
                                               equals new { Id_PhanLoaiHoGa = (string)p.Id_PhanLoaiHoGa, p.G }
                                              where n.TraiPhai == 1 && n.ThongTinLyTrinh_TuyenDuong == TuyenDuong && p.Id == a.ThongTinChungHoGa_TenHoGaSauPhanLoai
                                              select 1).Any() ? 1 : 0),
                                 KLTrai = ((from n in (from n in context.DSNuocMua select new { n.ThongTinLyTrinh_TuyenDuong, n.ThongTinChungHoGa_TenHoGaTheoBanVe, n.ThongTinChungHoGa_TenHoGaSauPhanLoai, n.TraiPhai, G = n.ThongTinChungHoGa_TenHoGaTheoBanVe.EndsWith("=G") ? "=G" : "", n.CreateAt })
                                            join p in context.PhanLoaiHoGaDetails
                                               on new { Id_PhanLoaiHoGa = n.ThongTinChungHoGa_TenHoGaSauPhanLoai, n.G }
                                               equals new { Id_PhanLoaiHoGa = (string)p.Id_PhanLoaiHoGa, p.G }
                                            where n.TraiPhai == 0 && n.ThongTinLyTrinh_TuyenDuong == TuyenDuong && p.Id == a.ThongTinChungHoGa_TenHoGaSauPhanLoai
                                            select 1).Any() ? 1 : 0) * a.TKLCK_SauCC,
                                 KLPhai = ((from n in (from n in context.DSNuocMua select new { n.ThongTinLyTrinh_TuyenDuong, n.ThongTinChungHoGa_TenHoGaTheoBanVe, n.ThongTinChungHoGa_TenHoGaSauPhanLoai, n.TraiPhai, G = n.ThongTinChungHoGa_TenHoGaTheoBanVe.EndsWith("=G") ? "=G" : "", n.CreateAt })
                                            join p in context.PhanLoaiHoGaDetails
                                                on new { Id_PhanLoaiHoGa = n.ThongTinChungHoGa_TenHoGaSauPhanLoai, n.G }
                                                equals new { Id_PhanLoaiHoGa = (string)p.Id_PhanLoaiHoGa, p.G }
                                            where n.TraiPhai == 1 && n.ThongTinLyTrinh_TuyenDuong == TuyenDuong && p.Id == a.ThongTinChungHoGa_TenHoGaSauPhanLoai
                                            select 1).Any() ? 1 : 0) * a.TKLCK_SauCC,
                                 KLTong = (((from n in (from n in context.DSNuocMua select new { n.ThongTinLyTrinh_TuyenDuong, n.ThongTinChungHoGa_TenHoGaTheoBanVe, n.ThongTinChungHoGa_TenHoGaSauPhanLoai, n.TraiPhai, G = n.ThongTinChungHoGa_TenHoGaTheoBanVe.EndsWith("=G") ? "=G" : "", n.CreateAt })
                                             join p in context.PhanLoaiHoGaDetails
                                                on new { Id_PhanLoaiHoGa = n.ThongTinChungHoGa_TenHoGaSauPhanLoai, n.G }
                                                equals new { Id_PhanLoaiHoGa = (string)p.Id_PhanLoaiHoGa, p.G }
                                             where n.TraiPhai == 0 && n.ThongTinLyTrinh_TuyenDuong == TuyenDuong && p.Id == a.ThongTinChungHoGa_TenHoGaSauPhanLoai
                                             select 1).Any() ? 1 : 0) +
                                            ((from n in (from n in context.DSNuocMua select new { n.ThongTinLyTrinh_TuyenDuong, n.ThongTinChungHoGa_TenHoGaTheoBanVe, n.ThongTinChungHoGa_TenHoGaSauPhanLoai, n.TraiPhai, G = n.ThongTinChungHoGa_TenHoGaTheoBanVe.EndsWith("=G") ? "=G" : "", n.CreateAt })
                                              join p in context.PhanLoaiHoGaDetails
                                               on new { Id_PhanLoaiHoGa = n.ThongTinChungHoGa_TenHoGaSauPhanLoai, n.G }
                                               equals new { Id_PhanLoaiHoGa = (string)p.Id_PhanLoaiHoGa, p.G }
                                              where n.TraiPhai == 1 && n.ThongTinLyTrinh_TuyenDuong == TuyenDuong && p.Id == a.ThongTinChungHoGa_TenHoGaSauPhanLoai
                                              select 1).Any() ? 1 : 0)) * a.TKLCK_SauCC,

                             }).ToList();

                return query;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }

        }
        public async Task<List<THKLModel>> GetTHKLByTuyenDuong(List<NuocMuaModel> nuocMua)
        {
            try
            {
                using var context = _context.CreateDbContext();

                // Khởi tạo một danh sách để lưu kết quả
                List<THKLModel> finalResult = new List<THKLModel>();

                // Duyệt qua từng tuyến đường trong danh sách `nuocMua`
                foreach (var item in nuocMua)
                {
                    var query = (from a in context.PKKLCTietHoGas join b in context.PhanLoaiHoGaDetails on a.ThongTinChungHoGa_TenHoGaSauPhanLoai equals b.Id
                                 orderby a.Flag ascending
                                 select new THKLModel
                                {   Id = a.Id,ThongTinLyTrinh_TuyenDuong =item.ThongTinLyTrinh_TuyenDuong,
                                    Flag = a.Flag,
                                    ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = a.ThongTinChungHoGa_TenHoGaSauPhanLoai,
                                    PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai = b.ThongTinChungHoGa_TenHoGaSauPhanLoai,
                                    TenCongTac =a.TenCongTac,
                                    DonVi= a.DonVi,KL1DonVi = a.TKLCK_SauCC,
                                    SLTrai = (from n in (from n in context.DSNuocMua select new { n.ThongTinLyTrinh_TuyenDuong,n.ThongTinChungHoGa_TenHoGaTheoBanVe,n.ThongTinChungHoGa_TenHoGaSauPhanLoai,n.TraiPhai,G = n.ThongTinChungHoGa_TenHoGaTheoBanVe.EndsWith("=G") ? "=G" : "", n.CreateAt})join p in context.PhanLoaiHoGaDetails
                                                  on new { Id_PhanLoaiHoGa = n.ThongTinChungHoGa_TenHoGaSauPhanLoai, n.G}
                                                  equals new { Id_PhanLoaiHoGa = (string)p.Id_PhanLoaiHoGa, p.G }
                                              where n.TraiPhai == 0 && n.ThongTinLyTrinh_TuyenDuong == item.ThongTinLyTrinh_TuyenDuong && p.Id == a.ThongTinChungHoGa_TenHoGaSauPhanLoai
                                              select 1).Any() ? 1 : 0,
                                    SLPhai = (from n in (from n in context.DSNuocMua select new { n.ThongTinLyTrinh_TuyenDuong, n.ThongTinChungHoGa_TenHoGaTheoBanVe, n.ThongTinChungHoGa_TenHoGaSauPhanLoai, n.TraiPhai, G = n.ThongTinChungHoGa_TenHoGaTheoBanVe.EndsWith("=G") ? "=G" : "", n.CreateAt })
                                              join p in context.PhanLoaiHoGaDetails
                                                  on new { Id_PhanLoaiHoGa = n.ThongTinChungHoGa_TenHoGaSauPhanLoai, n.G }
                                                  equals new { Id_PhanLoaiHoGa = (string)p.Id_PhanLoaiHoGa, p.G }
                                              where n.TraiPhai == 1 && n.ThongTinLyTrinh_TuyenDuong == item.ThongTinLyTrinh_TuyenDuong && p.Id == a.ThongTinChungHoGa_TenHoGaSauPhanLoai
                                              select 1).Any() ? 1 : 0,
                                    

                                    SLTong = ((from n in (from n in context.DSNuocMua select new { n.ThongTinLyTrinh_TuyenDuong, n.ThongTinChungHoGa_TenHoGaTheoBanVe, n.ThongTinChungHoGa_TenHoGaSauPhanLoai, n.TraiPhai, G = n.ThongTinChungHoGa_TenHoGaTheoBanVe.EndsWith("=G") ? "=G" : "", n.CreateAt })
                                               join p in context.PhanLoaiHoGaDetails
                                                  on new { Id_PhanLoaiHoGa = n.ThongTinChungHoGa_TenHoGaSauPhanLoai, n.G }
                                                  equals new { Id_PhanLoaiHoGa = (string)p.Id_PhanLoaiHoGa, p.G }
                                               where n.TraiPhai == 0 && n.ThongTinLyTrinh_TuyenDuong == item.ThongTinLyTrinh_TuyenDuong && p.Id == a.ThongTinChungHoGa_TenHoGaSauPhanLoai
                                               select 1).Any() ? 1 : 0) + 
                                               ((from n in (from n in context.DSNuocMua select new { n.ThongTinLyTrinh_TuyenDuong, n.ThongTinChungHoGa_TenHoGaTheoBanVe, n.ThongTinChungHoGa_TenHoGaSauPhanLoai, n.TraiPhai, G = n.ThongTinChungHoGa_TenHoGaTheoBanVe.EndsWith("=G") ? "=G" : "", n.CreateAt })
                                                 join p in context.PhanLoaiHoGaDetails
                                                  on new { Id_PhanLoaiHoGa = n.ThongTinChungHoGa_TenHoGaSauPhanLoai, n.G }
                                                  equals new { Id_PhanLoaiHoGa = (string)p.Id_PhanLoaiHoGa, p.G }
                                                 where n.TraiPhai == 1 && n.ThongTinLyTrinh_TuyenDuong == item.ThongTinLyTrinh_TuyenDuong && p.Id == a.ThongTinChungHoGa_TenHoGaSauPhanLoai
                                                 select 1).Any() ? 1 : 0),
                                    KLTrai = ((from n in (from n in context.DSNuocMua select new { n.ThongTinLyTrinh_TuyenDuong, n.ThongTinChungHoGa_TenHoGaTheoBanVe, n.ThongTinChungHoGa_TenHoGaSauPhanLoai, n.TraiPhai, G = n.ThongTinChungHoGa_TenHoGaTheoBanVe.EndsWith("=G") ? "=G" : "", n.CreateAt })
                                               join p in context.PhanLoaiHoGaDetails
                                                  on new { Id_PhanLoaiHoGa = n.ThongTinChungHoGa_TenHoGaSauPhanLoai, n.G }
                                                  equals new { Id_PhanLoaiHoGa = (string)p.Id_PhanLoaiHoGa, p.G }
                                               where n.TraiPhai == 0 && n.ThongTinLyTrinh_TuyenDuong == item.ThongTinLyTrinh_TuyenDuong && p.Id == a.ThongTinChungHoGa_TenHoGaSauPhanLoai
                                               select 1).Any() ? 1 : 0) * a.TKLCK_SauCC ,
                                    KLPhai =((from n in (from n in context.DSNuocMua select new { n.ThongTinLyTrinh_TuyenDuong, n.ThongTinChungHoGa_TenHoGaTheoBanVe, n.ThongTinChungHoGa_TenHoGaSauPhanLoai, n.TraiPhai, G = n.ThongTinChungHoGa_TenHoGaTheoBanVe.EndsWith("=G") ? "=G" : "", n.CreateAt })
                                              join p in context.PhanLoaiHoGaDetails
                                                  on new { Id_PhanLoaiHoGa = n.ThongTinChungHoGa_TenHoGaSauPhanLoai, n.G }
                                                  equals new { Id_PhanLoaiHoGa = (string)p.Id_PhanLoaiHoGa, p.G }
                                              where n.TraiPhai == 1 && n.ThongTinLyTrinh_TuyenDuong == item.ThongTinLyTrinh_TuyenDuong && p.Id == a.ThongTinChungHoGa_TenHoGaSauPhanLoai
                                              select 1).Any() ? 1 : 0) * a.TKLCK_SauCC,
                                    KLTong = (((from n in (from n in context.DSNuocMua select new { n.ThongTinLyTrinh_TuyenDuong, n.ThongTinChungHoGa_TenHoGaTheoBanVe, n.ThongTinChungHoGa_TenHoGaSauPhanLoai, n.TraiPhai, G = n.ThongTinChungHoGa_TenHoGaTheoBanVe.EndsWith("=G") ? "=G" : "", n.CreateAt })
                                                join p in context.PhanLoaiHoGaDetails
                                                   on new { Id_PhanLoaiHoGa = n.ThongTinChungHoGa_TenHoGaSauPhanLoai, n.G }
                                                   equals new { Id_PhanLoaiHoGa = (string)p.Id_PhanLoaiHoGa, p.G }
                                                where n.TraiPhai == 0 && n.ThongTinLyTrinh_TuyenDuong == item.ThongTinLyTrinh_TuyenDuong && p.Id == a.ThongTinChungHoGa_TenHoGaSauPhanLoai
                                                select 1).Any() ? 1 : 0) +
                                               ((from n in (from n in context.DSNuocMua select new { n.ThongTinLyTrinh_TuyenDuong, n.ThongTinChungHoGa_TenHoGaTheoBanVe, n.ThongTinChungHoGa_TenHoGaSauPhanLoai, n.TraiPhai, G = n.ThongTinChungHoGa_TenHoGaTheoBanVe.EndsWith("=G") ? "=G" : "", n.CreateAt })
                                                 join p in context.PhanLoaiHoGaDetails
                                                  on new { Id_PhanLoaiHoGa = n.ThongTinChungHoGa_TenHoGaSauPhanLoai, n.G }
                                                  equals new { Id_PhanLoaiHoGa = (string)p.Id_PhanLoaiHoGa, p.G }
                                                 where n.TraiPhai == 1 && n.ThongTinLyTrinh_TuyenDuong == item.ThongTinLyTrinh_TuyenDuong && p.Id == a.ThongTinChungHoGa_TenHoGaSauPhanLoai
                                                 select 1).Any() ? 1 : 0)) * a.TKLCK_SauCC,

                                }).ToList();
                    finalResult.AddRange(query);
                }

                // Trả về danh sách kết quả cuối cùng
                return finalResult;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }
        public async Task<PKKLCTietHoGa> GetTKLCK_SauCCByLCK(string id)
        {
            using var context = _context.CreateDbContext();
            var result = context.PKKLCTietHoGas
                .Where(a => a.ThongTinChungHoGa_TenHoGaSauPhanLoai == id &&
                 a.HangMuc == "II.Hố ga lắp đặt, hố ga" &&
                 a.LoaiBeTong == "Bê tông thương phẩm" && a.KTHH_GhiChu == "Rộng*Cao").OrderBy(a => a.CreateAt)
                 .FirstOrDefault();

            return result;
        }
        public async Task<double> GetSumTKLCK_SauCCByLCK(string id)
        {
            using var context = _context.CreateDbContext();
            var result = (from a in context.PKKLCTietHoGas
                          join b in context.PhanLoaiHoGaDetails
                          on a.ThongTinChungHoGa_TenHoGaSauPhanLoai equals b.Id
                          where a.ThongTinChungHoGa_TenHoGaSauPhanLoai == @id
                                && !new[]
                                {
                                    "VI.Sản xuất + V.Chuyển B.Tông T.Phẩm hố ga",
                                    "VII.Gia công, lắp dựng cốt thép hố ga"
                                }.Contains(a.HangMuc)
                                && a.LoaiBeTong == "Bê tông thương phẩm"
                                && !b.ThongTinChungHoGa_TenHoGaSauPhanLoai.Contains("=G")
                          select a.TKLCK_SauCC)
              .Sum(); 


            return result ;
        }

        public async Task<List<PKKLCTietHoGa>> GetExist(PKKLCTietHoGa searchData)
        {
            try
            {
                using var context = _context.CreateDbContext();

                // Thực hiện lọc dữ liệu dựa trên các thuộc tính của searchData
                var query = context.PKKLCTietHoGas
                             .Where(item =>
                                    item.ThongTinChungHoGa_TenHoGaSauPhanLoai == searchData.ThongTinChungHoGa_TenHoGaSauPhanLoai &&
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
                                          );
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
        public async Task Update(PKKLCTietHoGa TKThepDeCong)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(TKThepDeCong.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {TKThepDeCong.Id}");
            }

            context.PKKLCTietHoGas.Update(TKThepDeCong);
            await SaveChanges(context);
        }
        public async Task UpdateMulti(PKKLCTietHoGa[] PKKLCTietHoGa)
        {
            try
            {
                using var context = _context.CreateDbContext();

                string[] ids = PKKLCTietHoGa.Select(x => x.Id).ToArray();

                // Lấy danh sách các bản ghi từ database có ID nằm trong danh sách ids
                var listEntities = await context.PKKLCTietHoGas
                    .Where(x => ids.Contains(x.Id))
                    .ToListAsync();
                foreach (var entity in listEntities)
                {
                    var updatedEntity = PKKLCTietHoGa.FirstOrDefault(x => x.Id == entity.Id);
                    if (updatedEntity != null)
                    {
                        context.Entry(entity).CurrentValues.SetValues(updatedEntity);
                    }
                }

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

            context.Set<PKKLCTietHoGa>().Remove(entity);
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
        public async Task Insert(PKKLCTietHoGa entity)
        {
            try
            {
                entity.Id = Guid.NewGuid().ToString();
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                // Tìm giá trị Flag lớn nhất dựa trên điều kiện
                var maxFlag = await context.PKKLCTietHoGas
                    .Where(x => x.ThongTinChungHoGa_TenHoGaSauPhanLoai == entity.ThongTinChungHoGa_TenHoGaSauPhanLoai && x.HangMuc == entity.HangMuc)
                    .Select(x => (int?)x.Flag)
                    .MaxAsync() ?? 0;

                // Tăng giá trị Flag và thêm bản ghi
                entity.Flag = maxFlag + 1;
                context.PKKLCTietHoGas.Add(entity);
                await SaveChanges(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        //public async Task<string> InsertLaterFlag(PKKLCTietHoGa entity, int FlagLast)
        //{
        //    string id = "";
        //    try
        //    {
        //        using var context = _context.CreateDbContext();

        //        if (entity == null)
        //        {
        //            throw new Exception("Không có bản ghi nào để thêm!");
        //        }

        //        // Bước 1: Lấy danh sách các bản ghi có flag > FlagLast
        //        var recordsToUpdate = await context.PKKLCTietHoGas
        //            .Where(x => x.Flag > FlagLast && x.ThongTinChungHoGa_TenHoGaSauPhanLoai == entity.ThongTinChungHoGa_TenHoGaSauPhanLoai && x.HangMuc == entity.HangMuc)
        //            .ToListAsync();

        //        // Bước 2: Tăng giá trị flag của các bản ghi đó thêm 1
        //        foreach (var record in recordsToUpdate)
        //        {
        //            record.Flag += 1;
        //        }

        //        // Lưu các thay đổi cập nhật flag
        //        await context.SaveChangesAsync();

        //        // Bước 3: Đặt flag cho bản ghi mới bằng 3
        //        if (recordsToUpdate.Count() == 0)
        //        {
        //            // Kiểm tra xem bảng có bản ghi nào không
        //            var maxFlag = await context.PKKLCTietHoGas.AnyAsync()
        //                          ? await context.PKKLCTietHoGas.MaxAsync(x => x.Flag)
        //                          : 0;

        //            // Tăng giá trị Flag lên 1
        //            entity.Flag = maxFlag + 1;
        //        }
        //        else
        //        {
        //            entity.Flag = FlagLast + 1;
        //        }

        //        // Bước 4: Chèn bản ghi mới vào bảng
        //        context.PKKLCTietHoGas.Add(entity);

        //        // Lưu bản ghi mới vào cơ sở dữ liệu
        //        await SaveChanges(context);
        //        // Trả về Id của bản ghi mới được thêm
        //        id = entity.Id ?? "";
        //        return id;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //        return id;
        //    }
        //}

        public async Task<string> InsertLaterFlag(PKKLCTietHoGa entity, int FlagLast, bool insertBefore)
        {
            string id = "";
            try
            {
                using var context = _context.CreateDbContext();

                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                // Bước 1: Lấy danh sách các bản ghi cần cập nhật flag
                var recordsToUpdate = await context.PKKLCTietHoGas
                    .Where(x =>
                        (insertBefore ? x.Flag >= FlagLast : x.Flag > FlagLast) &&
                        x.ThongTinChungHoGa_TenHoGaSauPhanLoai == entity.ThongTinChungHoGa_TenHoGaSauPhanLoai &&
                        x.HangMuc == entity.HangMuc)
                    .ToListAsync();

                // Bước 2: Tăng giá trị flag của các bản ghi đó thêm 1
                foreach (var record in recordsToUpdate)
                {
                    record.Flag += 1;
                }

                // Lưu các thay đổi cập nhật flag
                await context.SaveChangesAsync();

                // Bước 3: Đặt flag cho bản ghi mới
                if (recordsToUpdate.Count == 0)
                {
                    // Kiểm tra xem bảng có bản ghi nào không
                    var maxFlag = await context.PKKLCTietHoGas.AnyAsync()
                                   ? await context.PKKLCTietHoGas.MaxAsync(x => x.Flag)
                                   : 0;

                    // Tăng giá trị Flag lên 1
                    entity.Flag = maxFlag + 1;
                }
                else
                {
                    entity.Flag = insertBefore ? FlagLast : FlagLast + 1;
                }

                // Bước 4: Chèn bản ghi mới vào bảng
                context.PKKLCTietHoGas.Add(entity);

                // Lưu bản ghi mới vào cơ sở dữ liệu
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

        //cập nhật lại số liệu
        public async Task SaveChanges(ApplicationDbContext context)
        {
            try
            {
                // Xử lý các thay đổi trong DbContext
                var entries = context.ChangeTracker.Entries<PKKLCTietHoGa>();

                foreach (var entry in entries)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            await HandleEntityAdd(entry);
                            break;

                        case EntityState.Modified:
                            await HandleEntityUpdate(entry);
                            break;

                        case EntityState.Deleted:
                            await HandleEntityDelete(entry);
                            break;
                    }
                }

                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error while saving changes: {ex.Message}");
                throw;
            }
        }
        private async Task HandleEntityAdd(EntityEntry<PKKLCTietHoGa> entry)
        {
            var entity = entry.Entity;
            using var context = _context.CreateDbContext();
            if (entity.HangMuc == "II.Hố ga lắp đặt, hố ga" && entity.HangMucCongTac.ToUpper().Trim() == "Bê tông hố ga lắp đặt".ToUpper().Trim() && entity.KTHH_GhiChu.ToUpper().Trim() == "Rộng*Cao".ToUpper().Trim())
            {
                //Cập nhật I.
                var recordsToUpdate = await context.PKKLCTietHoGas
                    .Where(x => x.ThongTinChungHoGa_TenHoGaSauPhanLoai == entity.ThongTinChungHoGa_TenHoGaSauPhanLoai &&
                                x.HangMuc == "II.Hố ga lắp đặt, hố ga" &&
                                x.HangMucCongTac == "Vận chuyển từ bãi đúc đến công trường")
                    .ToListAsync();

                foreach (var record in recordsToUpdate)
                {
                    UpdateRecordWithCalculations(record, entity.TKLCK_SauCC);
                }
                await UpdateMulti(recordsToUpdate.ToArray());
            }
            if (entity.HangMuc != "VII.Gia công, lắp dựng cốt thép hố ga" && entity.HangMuc != "VI.Sản xuất + V.Chuyển B.Tông T.Phẩm hố ga" && entity.LoaiBeTong == "Bê tông thương phẩm")
            {
                //Cập nhật VI.
                var recordsToUpdate1 = await context.PKKLCTietHoGas
                    .Where(x => x.ThongTinChungHoGa_TenHoGaSauPhanLoai == entity.ThongTinChungHoGa_TenHoGaSauPhanLoai
                               && x.HangMuc == "VI.Sản xuất + V.Chuyển B.Tông T.Phẩm hố ga"
                               && x.LoaiBeTong == "Bê tông thương phẩm")
                    .ToListAsync();

                foreach (var record in recordsToUpdate1)
                {
                    if (!string.IsNullOrEmpty(record.ThongTinChungHoGa_TenHoGaSauPhanLoai))
                    {
                        //var getOld = await GetById(record.Id);
                        var TKLCK_SauCC1 = await GetSumTKLCK_SauCCByLCK(entity.ThongTinChungHoGa_TenHoGaSauPhanLoai);
                        record.TKLCK_SauCC = Math.Round((TKLCK_SauCC1 + entity.TKLCK_SauCC), 4);
                    }
                }

                await UpdateMulti(recordsToUpdate1.ToArray());
            }
        }
        private async Task HandleEntityUpdate(EntityEntry<PKKLCTietHoGa> entry)
        {
            var entity = entry.Entity;
            using var context = _context.CreateDbContext();
            if (entity.HangMuc == "II.Hố ga lắp đặt, hố ga" && entity.HangMucCongTac.ToUpper().Trim() == "Bê tông hố ga lắp đặt".ToUpper().Trim() && entity.KTHH_GhiChu.ToUpper().Trim() == "Rộng*Cao".ToUpper().Trim())
            {
                //Cập nhật I.
                var recordsToUpdate = await context.PKKLCTietHoGas
                    .Where(x => x.ThongTinChungHoGa_TenHoGaSauPhanLoai == entity.ThongTinChungHoGa_TenHoGaSauPhanLoai &&
                                x.HangMuc == "II.Hố ga lắp đặt, hố ga" &&
                                x.HangMucCongTac == "Vận chuyển từ bãi đúc đến công trường")
                    .ToListAsync();

                foreach (var record in recordsToUpdate)
                {
                    UpdateRecordWithCalculations(record, entity.TKLCK_SauCC);
                }
                await UpdateMulti(recordsToUpdate.ToArray());
            }
            if (entity.HangMuc != "VII.Gia công, lắp dựng cốt thép hố ga" && entity.HangMuc != "VI.Sản xuất + V.Chuyển B.Tông T.Phẩm hố ga" && entity.LoaiBeTong == "Bê tông thương phẩm")
            {
                //Cập nhật VI.
                var recordsToUpdate1 = await context.PKKLCTietHoGas
                    .Where(x => x.ThongTinChungHoGa_TenHoGaSauPhanLoai == entity.ThongTinChungHoGa_TenHoGaSauPhanLoai
                               && x.HangMuc == "VI.Sản xuất + V.Chuyển B.Tông T.Phẩm hố ga"
                               && x.LoaiBeTong == "Bê tông thương phẩm")
                    .ToListAsync();

                foreach (var record in recordsToUpdate1)
                {
                    if (!string.IsNullOrEmpty(record.ThongTinChungHoGa_TenHoGaSauPhanLoai))
                    {
                        var getOld = await GetById(entity.Id);
                        var TKLCK_SauCC1 = await GetSumTKLCK_SauCCByLCK(entity.ThongTinChungHoGa_TenHoGaSauPhanLoai);
                        record.TKLCK_SauCC = Math.Round(((TKLCK_SauCC1 - getOld.TKLCK_SauCC) + entity.TKLCK_SauCC), 4);
                    }
                }

                await UpdateMulti(recordsToUpdate1.ToArray());
            }
        }
        private async Task HandleEntityDelete(EntityEntry<PKKLCTietHoGa> entry)
        {
            var entity = entry.Entity;
            using var context = _context.CreateDbContext();
            if (entity.HangMuc == "II.Hố ga lắp đặt, hố ga" && entity.HangMucCongTac.ToUpper().Trim() == "Bê tông hố ga lắp đặt".ToUpper().Trim() && entity.KTHH_GhiChu.ToUpper().Trim() == "Rộng*Cao".ToUpper().Trim())
            {
                //Cập nhật I.
                var recordsToUpdate = await context.PKKLCTietHoGas
                    .Where(x => x.ThongTinChungHoGa_TenHoGaSauPhanLoai == entity.ThongTinChungHoGa_TenHoGaSauPhanLoai &&
                                x.HangMuc == "II.Hố ga lắp đặt, hố ga" &&
                                x.HangMucCongTac == "Vận chuyển từ bãi đúc đến công trường")
                    .ToListAsync();

                foreach (var record in recordsToUpdate)
                {
                    UpdateRecordWithCalculations(record, entity.TKLCK_SauCC);
                }
                await UpdateMulti(recordsToUpdate.ToArray());
            }
            if (entity.HangMuc != "VII.Gia công, lắp dựng cốt thép hố ga" && entity.HangMuc != "VI.Sản xuất + V.Chuyển B.Tông T.Phẩm hố ga" && entity.LoaiBeTong == "Bê tông thương phẩm")
            {
                //Cập nhật VI.
                var recordsToUpdate1 = await context.PKKLCTietHoGas
                    .Where(x => x.ThongTinChungHoGa_TenHoGaSauPhanLoai == entity.ThongTinChungHoGa_TenHoGaSauPhanLoai
                               && x.HangMuc == "VI.Sản xuất + V.Chuyển B.Tông T.Phẩm hố ga"
                               && x.LoaiBeTong == "Bê tông thương phẩm")
                    .ToListAsync();

                foreach (var record in recordsToUpdate1)
                {
                    if (!string.IsNullOrEmpty(record.ThongTinChungHoGa_TenHoGaSauPhanLoai))
                    {
                        var TKLCK_SauCC1 = await GetSumTKLCK_SauCCByLCK(entity.ThongTinChungHoGa_TenHoGaSauPhanLoai);
                        record.TKLCK_SauCC = Math.Round((TKLCK_SauCC1 - entity.TKLCK_SauCC),4);
                    }
                }

                await UpdateMulti(recordsToUpdate1.ToArray());
            }
        }

        //tính toán
        private async void UpdateRecordWithCalculations(PKKLCTietHoGa record, double tklckSauCc)
        {
            record.KTHH_KL1CK = KTHH_KL1CK(record);
            record.TTCDT_KL = TTCDT_KL(record);
            record.KL1CK_ChuaTruCC = KL1CK_ChuaTruCC(record);
            record.KLKP_KL = tklckSauCc * 2400;
            record.TKLCK_SauCC = await TKLCK_SauCC(record);
        }

        public double KTHH_KL1CK(PKKLCTietHoGa obj)
        {
            double result = 0;
            if (obj.DonVi == "M3")
            {
                if (string.IsNullOrEmpty(obj.KTHH_GhiChu) || obj.KTHH_GhiChu == "0")
                {
                    result = obj.KTHH_D * obj.KTHH_R * obj.KTHH_C;
                }
                else if (obj.KTHH_GhiChu == "Rộng*Cao")
                {
                    result = obj.KTHH_DienTich * obj.KTHH_D;
                }
                else if (obj.KTHH_GhiChu == "Dài*Cao")
                {
                    result = obj.KTHH_DienTich * obj.KTHH_R;
                }
                else if (obj.KTHH_GhiChu == "Dài*Rộng")
                {
                    result = obj.KTHH_DienTich * obj.KTHH_C;
                }

            }
            return Math.Round(result, 4);
        }
        public double TTCDT_KL(PKKLCTietHoGa obj)
        {
            double result = 0;
            if (obj.DonVi.ToUpper().Trim() == "M2")
            {
                if (string.IsNullOrEmpty(obj.TTCDT_DienTich.ToString()) || obj.TTCDT_DienTich == 0)
                {
                    result = obj.KTHH_D * obj.KTHH_C * obj.TTCDT_CDai + obj.KTHH_R * obj.KTHH_C * obj.TTCDT_CRong + obj.KTHH_D * obj.KTHH_R * obj.TTCDT_CDay;
                }
                else
                {
                    result = obj.TTCDT_DienTich;
                }
            }
            return Math.Round(result, 4);
        }
        public double KL1CK_ChuaTruCC(PKKLCTietHoGa obj)
        {
            double result = 0;
            if (obj.KTHH_KL1CK > 0)
            {
                result = obj.KTHH_KL1CK * obj.KTHH_SLCauKien;
            }
            else if (obj.TTCDT_KL > 0)
            {
                result = obj.TTCDT_KL * obj.TTCDT_SLCK;
            }
            else
            {
                result = obj.KLKP_KL * obj.KLKP_Sl;
            }
            return Math.Round(result, 4);
        }
        public async Task<double> TKLCK_SauCC(PKKLCTietHoGa obj)
        {
            using var context = _context.CreateDbContext();
            var tenHoGaSauPhanLoai = await context.PhanLoaiHoGaDetails
             .Where(x => x.Id.Equals(obj.ThongTinChungHoGa_TenHoGaSauPhanLoai))
             .Select(x => x.ThongTinChungHoGa_TenHoGaSauPhanLoai)
             .FirstOrDefaultAsync();


            double result = 0;
            if (tenHoGaSauPhanLoai.EndsWith("=G"))
            {
                result = 0;

            }
            else
            {
                result = obj.KL1CK_ChuaTruCC - obj.KLCC1CK;
            }
            
            return Math.Round(result, 4);
        }

    }
}
