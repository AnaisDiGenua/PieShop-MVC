using BethanysPieShop.Models.Entities;
using BethanysPieShop.Models.Interfaces;
using System.Collections.Generic;

namespace BethanysPieShop.Models.EF
{
    public class EFCategoryRepo : ICategoryRepository
    {
        private readonly AppDbContext context;

        //Dependecy injection
        public EFCategoryRepo(AppDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Category> AllCategories => context.Categories;
    }
}
