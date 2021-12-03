using Contracts.DTOs;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Services.Abstractions;
using Services.Extension.Mapping;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    internal sealed class CategoryInfoService : ICategoryInfoService
    {
        private readonly ApplicationDbContext _db;

        public CategoryInfoService(ApplicationDbContext dbContext, IServiceManager manager) => _db = dbContext;

        public CategoryInfo GetCategoryInfo(int categoryId)
        {
            var category = _db.Categories
                .Include(e => e.Attributes)
                .Single(e => e.Id == categoryId);

            var info = category.MapToCategoryInfo();

            return info;
        }

        public void SaveCategoryInfo(CategoryInfo info)
        {
            if (info.Id == 0) throw new System.NotImplementedException();

            var category = info.MapToCategory();
            category.ParentId = _db.Categories.Single(e => e.Id == category.Id).ParentId;

            var attributes = info.Attributes
                .MapToAttribute()
                .Select(e => { e.CategoryId = category.Id; return e; });

            var attributesIds = attributes.Select(e => e.Id);

            _db.ChangeTracker.Clear();
            _db.Database.BeginTransaction();

            _db.Categories.Update(category);

            var deleted = _db.Attributes.Where(e => e.CategoryId == category.Id).Where(e => !attributesIds.Contains(e.Id));
            var updated = attributes.Where(e => e.Id != 0);
            var added = attributes.Where(e => e.Id == 0);
            _db.Attributes.RemoveRange(deleted);
            _db.Attributes.UpdateRange(updated);
            _db.Attributes.AddRange(added);

            _db.SaveChanges();
            _db.Database.CommitTransaction();
        }

        public void CreateSubcategory(int categoryId)
        {
            var category = _db.Categories.Single(e => e.Id == categoryId);

            _db.Categories.Add(new Category() { ParentId = category.Id, Name = "New category" });
            _db.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            var category = _db.Categories.Single(e => e.Id == categoryId);

            _db.Categories.Remove(category);
            _db.SaveChanges();
        }
    }
}
