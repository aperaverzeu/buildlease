using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class CategoryTreeExtenstion
    {
        public static void ValidateTree(this IEnumerable<Category> categories)
        {
            if (categories.Any(c => c.ParentId > c.Id))
                throw new ArgumentException($"Child category cannot have ID less than parent");

            var root = categories.GetRoot();

            if (categories.Any(c => categories.GetPathToRoot(c.Id).Last() != root))
                throw new ArgumentException($"All categories must have path to root");

            // ...
        }

        public static Category GetRoot(this IEnumerable<Category> categories)
        {
            return categories.Single(c => c.Id == c.ParentId);
        }

        public static IEnumerable<Category> GetSubtree(this IEnumerable<Category> categories, int categoryId)
        {
            var subtree = new List<Category>();

            foreach (var category in categories.OrderBy(c => c.Id))
                if (category.Id == categoryId || subtree.Any(c => c.Id == category.ParentId))
                    subtree.Add(category);

            return subtree;
        }

        public static IEnumerable<Category> GetPathToRoot(this IEnumerable<Category> categories, int categoryId)
        {
            var path = new List<Category>() { categories.Single(c => c.Id == categoryId) };

            foreach (var category in categories.OrderBy(c => c.Id).Reverse())
                if (category.Id == path.Last().ParentId && category.Id != path.Last().Id)
                    path.Add(category);

            return path;
        }

        public static IEnumerable<Category> GetPathFromRoot(this IEnumerable<Category> categories, int categoryId)
            => categories.GetPathToRoot(categoryId).Reverse();
    }
}
