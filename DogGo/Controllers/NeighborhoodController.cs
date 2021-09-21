using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DogGo.Models;
using DogGo.Repositories;


namespace DogGo.Controllers
{
    public class NeighborhoodController : Controller
    {
        private readonly INeighborhoodRepository _neighborhoodRepo;

        // ASP.NET will give us an instance of our Owner Repository. This is called "Dependency Injection"
        public NeighborhoodController(INeighborhoodRepository neighborhoodRepo)
        {
            _neighborhoodRepo = neighborhoodRepo;
        }
        // GET: NeighborhoodController
        public ActionResult Index()
        {
            List<Neighborhood> neighborhoods = _neighborhoodRepo.GetAllNeighborhoods();

            return View(neighborhoods);
        }

        // GET: NeighborhoodController/Details/5
        public ActionResult Details(int id)
        {
            Neighborhood neighborhood = _neighborhoodRepo.GetNeighborhoodById(id);

            if(neighborhood == null)
            {
                return NotFound();
            }

            return View(neighborhood);
        }

        // GET: NeighborhoodController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NeighborhoodController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NeighborhoodController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NeighborhoodController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NeighborhoodController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NeighborhoodController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
