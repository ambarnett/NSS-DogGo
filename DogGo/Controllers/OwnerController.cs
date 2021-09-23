﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DogGo.Models;
using DogGo.Repositories;
using System;

namespace DogGo.Controllers
{
    public class OwnerController : Controller
    {
        private readonly IOwnerRepository _ownerRepo;

        // ASP.NET will give us an instance of our Owner Repository. This is called "Dependency Injection"
        public OwnerController(IOwnerRepository ownerRepo)
        {
            _ownerRepo = ownerRepo;
        }
        // GET: OwnerController
        public ActionResult Index()
        {
            List<Owner> owners = _ownerRepo.GetAllOwners();
            return View(owners); 
            // This code is getting all of the owners in the Owner table,
            // converting it to a list and passing off to the view.
        }

        // GET: OwnerController/Details/5
        public ActionResult Details(int id)
        {
            Owner owner = _ownerRepo.GetOwnerById(id);

            if(owner == null)
            {
                return NotFound();
            }

            return View(owner);
        }

        // GET: OwnerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OwnerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Owner owner)
        {
            try
            {
                _ownerRepo.AddOwner(owner);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View(owner);
            }
        }

        // GET: OwnerController/Edit/5
        public ActionResult Edit(int id)
        {
            Owner owner = _ownerRepo.GetOwnerById(id);

            if(owner == null)
            {
                return NotFound();
            }

            return View(owner);
        }

        // POST: OwnerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Owner owner)
        {
            try
            {
                _ownerRepo.UpdateOwner(owner);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View(owner);
            }
        }

        // GET: OwnerController/Delete/5
        public ActionResult Delete(int id)
        {
            Owner owner = _ownerRepo.GetOwnerById(id);
            return View(owner);
        }

        // POST: OwnerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Owner owner)
        {
            try
            {
                _ownerRepo.DeleteOwner(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(owner);
            }
        }
    }
}
