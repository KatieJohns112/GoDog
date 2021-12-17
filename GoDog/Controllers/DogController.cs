using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoDog.Models;
using GoDog.Repositories;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace GoDog.Controllers
{
    public class DogController : Controller
    {
        private readonly IDogRepository _dogRepo;

        // ASP.NET will give us an instance of our Walker Repository. This is called "Dependency Injection"
        public DogController(IDogRepository dogRepository)
        {
            _dogRepo = dogRepository;
        }
        // GET: DogController
        [Authorize]
        public ActionResult Index()
        {
            int ownerId = GetCurrentUserId();

            List<Dog> dogs = _dogRepo.GetDogsByOwnerId(ownerId);

            return View(dogs);
        }

        // GET: DogController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DogController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DogController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(Dog dog)
        {
            try
            {
                // update the dogs OwnerId to the current user's Id
                dog.OwnerId = GetCurrentUserId();

                _dogRepo.AddDog(dog);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(dog);
            }
        }

        // GET: DogController/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            int ownerId = GetCurrentUserId();
            Dog dog = _dogRepo.GetDogById(id);

            return View(dog);

            if(ownerId != dog.OwnerId)
            {
                return StatusCode(404);
            }
            else
            {
                return View(dog);
            }

            return View(dog);
        }

        // POST: DogController/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Dog dog)
        {
            try
            {
                int ownerId = GetCurrentUserId();
                _dogRepo.UpdateDog(dog);

                if(ownerId == dog.OwnerId)
                {
                    _dogRepo.UpdateDog(dog);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(dog);
            }
        }

        // GET: DogController/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            int ownerId = GetCurrentUserId();
            Dog dog = _dogRepo.GetDogById(id);

            if(dog.OwnerId != ownerId)
            {
                return StatusCode(404);
            }
            else
            {
                return View(dog);
            }
        }

        // POST: DogController/Delete/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Dog dog)
        {
            try
            {
                int ownerId = GetCurrentUserId();
                _dogRepo.DeleteDog(id);

                if(dog.OwnerId == ownerId)
                {
                    _dogRepo.DeleteDog(dog.Id);
                }
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
            }
        }
        private int GetCurrentUserId()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.Parse(id);
        }
    }
}
