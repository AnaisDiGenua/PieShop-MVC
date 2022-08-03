﻿using BethanysPieShop.Models.Interfaces;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult List()
        {
            PiesListViewModel piesList = new PiesListViewModel();
            piesList.Pies = _pieRepository.AllPies;

            piesList.CurrentCategory = "Cheese cake";
            return View(piesList);
        }


        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);

            if(pie == null)
                return NotFound();
            return View(pie);
        }
    }
}
