using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Collections.Generic;
using System.Linq;

namespace Services.Extension
{
    public static class CategoryExtension
    {
        public static IEnumerable<Attribute> GetAllAvailableAttributes(this ApplicationDbContext db, int categoryId)
            => 
            db.Categories
                .Include(e => e.Attributes)
                    .ThenInclude(e => e.ProductAttributes)
                .GetPathFromRoot(categoryId)
                .SelectMany(e => e.Attributes);
    }
}
