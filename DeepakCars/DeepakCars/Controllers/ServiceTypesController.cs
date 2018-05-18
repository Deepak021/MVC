using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeepakCars.Data;
using DeepakCars.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeepakCars.Controllers
{
    public class ServiceTypesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ServiceTypesController(ApplicationDbContext db)
        {
            _db = db;
        }

        //GET: ServiceType
        public IActionResult Index()
        {
            return View(_db.ServiceTypes.ToList());
        }

        //GET: ServiceTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Services/Create
        public async Task<IActionResult> Create(ServiceType serviceType)
        {
            if(ModelState.IsValid)
            {
                _db.Add(serviceType);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serviceType);
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                _db.Dispose();
            }
        }
    }
}