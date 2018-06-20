using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeepakCars.Data;
using DeepakCars.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [HttpPost]
        [AutoValidateAntiforgeryToken]
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

        //Details: ServiceTypes/Details/id
        public async Task<IActionResult> Details (int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var serviceType = await _db.ServiceTypes.SingleOrDefaultAsync(m=>m.Id == id);
            if(serviceType == null)
            {
                return NotFound();
            }
            return View(serviceType);
        }

        //Edit: ServiceTypes/Edit/id
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var serviceType = await _db.ServiceTypes.SingleOrDefaultAsync(m => m.Id == id);
            if (serviceType == null)
            {
                return NotFound();
            }
            return View(serviceType);
        }

        //POST: Edit: ServiceTypes/Edit/id
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(int id, ServiceType serviceType)
        {
            if(id != serviceType.Id)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                _db.Update(serviceType);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(serviceType);
        }

        //Delete: ServiceTypes/Delete/id
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var serviceType = await _db.ServiceTypes.SingleOrDefaultAsync(m => m.Id == id);
            if (serviceType == null)
            {
                return NotFound();
            }
            return View(serviceType);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var serviceType = await _db.ServiceTypes.SingleOrDefaultAsync(m => m.Id == id);
            _db.Remove(serviceType);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
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