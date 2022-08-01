using BethanysPieShop.Models.Entities;
using System.Collections.Generic;

namespace BethanysPieShop.Models.Interfaces
{
    public interface IPieRepository
    {
        IEnumerable<Pie> AllPies { get; }
        IEnumerable<Pie> PiesOfTheWeek { get; }
        Pie GetPieById(int pieId);
    }
}
