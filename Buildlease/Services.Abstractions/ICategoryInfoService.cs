using Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface ICategoryInfoService
    {
        CategoryInfo GetCategoryInfo(int categoryId);
        void SaveCategoryInfo(CategoryInfo info);
        void CreateSubcategory(int categoryId);
        void DeleteCategory(int categoryId);
    }
}
