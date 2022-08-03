using BethanysPieShop.Models.Entities;
using BethanysPieShop.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BethanysPieShop.Models.EF
{
    public class EFPieRepo : IPieRepository
    {
        private readonly AppDbContext context;

        //Dependecy injection
        public EFPieRepo(AppDbContext context)
        {
            this.context = context;
        }

        //proprietà
        public IEnumerable<Pie> AllPies
        {
            get { return context.Pies.Include(p => p.Category); }
        }

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get { return context.Pies.Include(p => p.Category).Where(p => p.IsPieOfTheWeek); }
        }

        //metodo
        public Pie GetPieById(int pieId)
        {
            return context.Pies.FirstOrDefault(p => p.PieId == pieId);
        }
    }
}
