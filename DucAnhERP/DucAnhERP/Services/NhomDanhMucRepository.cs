﻿using DucAnhERP.Data;
using DucAnhERP.Models;
using DucAnhERP.Repository;
using Microsoft.EntityFrameworkCore;

namespace DucAnhERP.Services
{
    public class NhomNhomDanhMucRepository : INhomDanhMucRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;

        public NhomNhomDanhMucRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }
        public async Task<List<NhomDanhMuc>> GetAll()
        {
            using var context = _context.CreateDbContext();
            var entity = await context.DSNhomDanhMuc.ToListAsync();
            return entity;
        }

        public async Task Update(NhomDanhMuc NhomDanhMuc)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(NhomDanhMuc.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {NhomDanhMuc.Id}");
            }

            context.DSNhomDanhMuc.Update(NhomDanhMuc);
            await context.SaveChangesAsync();
        }

        public async Task UpdateMulti(NhomDanhMuc[] NhomDanhMuc)
        {
            using var context = _context.CreateDbContext();
            string[] ids = NhomDanhMuc.Select(x => x.Id).ToArray();
            var listEntities = await context.DSNhomDanhMuc.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.DSNhomDanhMuc.Update(entity);
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


        public async Task<NhomDanhMuc> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.DSNhomDanhMuc.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            return entity;
        }


        public async Task Insert(NhomDanhMuc entity)
        {
            using var context = _context.CreateDbContext();
            if (entity == null)
            {
                throw new Exception("Không có bản ghi nào để thêm!");
            }

            context.DSNhomDanhMuc.Add(entity);
            await context.SaveChangesAsync();
        }


    }
}