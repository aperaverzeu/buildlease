using Buildlease.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buildlease.Logic
{
    public static class CategoryTreeExtenstion
    {
        public static void ValidateTree(this IEnumerable<Category> categories)
        {
            if (categories.Any(c => c.ParentId > c.Id))
                throw new ArgumentException($"Child category cannot have ID less than parent");

            var root = categories.SingleOrDefault(c => c.Id == 0);
            if (root is null)
                throw new ArgumentException($"There must be a root category with ID = 0");
            if (root.ParentId != 0)
                throw new ArgumentException($"Root category must have ParentId = 0");

            // TO BE CONTINUED
        }

        public static Category[] GetSubtree(this IEnumerable<Category> categories, int categoryId)
        {
            var subtree = new List<Category>();

            foreach (var category in categories.OrderBy(c => c.Id))
                if (category.Id == categoryId || subtree.Any(c => c.Id == category.ParentId))
                    subtree.Add(category);

            return subtree.ToArray();
        }

        public static Category[] GetPathFromRoot(this IEnumerable<Category> categories, int categoryId)
        {
            var path = new List<Category>() { 
                categories.Single(c => c.Id == categoryId) 
            };

            foreach (var category in categories.OrderBy(c => c.Id).Reverse())
                if (category.ParentId == path.Last().Id)
                    path.Add(category);

            return path.AsEnumerable().Reverse().ToArray();
        }
    }
}
