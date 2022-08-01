using System.Collections.Generic;

namespace BethanysPieShop.Models.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
