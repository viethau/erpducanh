using DucAnhERP.Data;
using DucAnhERP.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using DucAnhERP.Services;
using DucAnhERP.Repository;

namespace DucAnhERP.Services
{
    public class EntityChangeService
    {
        private readonly PKKLMongCTronRepository _pKKLMongCTronRepository;
        private readonly ApplicationDbContext _context;

        // Constructor khởi tạo trực tiếp lớp triển khai
        public EntityChangeService(ApplicationDbContext context)
        {
            _context = context;
        
        }

        public async Task SaveChangesAsync(ApplicationDbContext context)
        {
            try
            {
                // Lấy các entry thay đổi từ context
                var entries = context.ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted)
                    .ToList();
                
                foreach (var entry in entries)
                {
                    string tableName = entry.Metadata.GetTableName(); // Lấy tên bảng
                    switch (tableName)
                    {
                        case "PKKLMongCTrons":
                            await HandlePKKLMongCTronChanges(entry);
                            break;

                        default:
                            Console.WriteLine($"No specific logic for table: {tableName}");
                            break;
                    }
                }
                // Lưu các thay đổi
                await context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred while saving changes: {ex.Message}");
                throw;
            }
        }
        private async Task HandlePKKLMongCTronChanges(EntityEntry entry)
        {
            if (entry.State == EntityState.Added)
            {
               
            }
            else if (entry.State == EntityState.Modified)
            {
               
            }
            else if (entry.State == EntityState.Deleted)
            {
                try
                {
                    var addedEntity = entry.Entity as PKKLMongCTron;
                    var data = entry.Entity as PKKLMongCTron;

                    if (data != null )
                    {
                        var c = data.TKLCK_SauCC;
                        // Kiểm tra điều kiện HangMuc và PhanLoaiMongCongTronCongHop
                        if (data.HangMuc == "I.Móng cống tròn")
                        {
                            // Lọc tất cả các bản ghi có ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop giống với addedEntity
                            var recordsToUpdate = await _context.PKKLMongCTrons
                                .Where(x => x.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop == data.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop
                                && x.HangMuc == "II.Sản xuất + V.Chuyển B.Tông T.Phẩm móng cống tròn")
                                .ToListAsync();

                            // Cập nhật các cột TKLCK_SauCC cho từng bản ghi
                            foreach (var record in recordsToUpdate)
                            {
                                record.TKLCK_SauCC = await _pKKLMongCTronRepository.GetSumTKLCK_SauCC(data)  ;
                            }
                            await _pKKLMongCTronRepository.UpdateMulti(recordsToUpdate.ToArray());
                            await _context.SaveChangesAsync();
                        }
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
}
