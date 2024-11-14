using DucAnhERP.Data;
using DucAnhERP.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace DucAnhERP.Services
{
    public class EntityChangeService
    {
        private readonly ApplicationDbContext _context;

        public EntityChangeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                var entries = _context.ChangeTracker.Entries()
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
                await _context.SaveChangesAsync();
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
                // Logic xử lý khi thêm mới
                Console.WriteLine("Adding a new record to PKKLMongCTrons.");
            }
            else if (entry.State == EntityState.Modified)
            {
                // Logic xử lý khi sửa đổi
                Console.WriteLine("Updating a record in PKKLMongCTrons.");
            }
            else if (entry.State == EntityState.Deleted)
            {
                // Logic xử lý khi xóa
                Console.WriteLine("Deleting a record from PKKLMongCTrons.");
            }


        }


    }

}
