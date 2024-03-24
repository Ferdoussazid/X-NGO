// RestaurantController.cs
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using assignment.EF;
using assignment.DTOs;

namespace assignment.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly NgoContext _context;

        public RestaurantController(NgoContext context)
        {
            _context = context;
        }

        // GET: Restaurant
        public IActionResult Index()
        {
            var db = new NgoContext();
            var data = db.Restaurants.ToList();
            return View(data);
        }

        // GET: Restaurant/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Restaurant/Create
        [HttpPost]
        public IActionResult Create(RestaurantDTO restaurantDTO)
        {
            if (ModelState.IsValid)
            {
                var restaurant = new Restaurant
                {
                    Name = restaurantDTO.Name,
                    Address = restaurantDTO.Address
                };
                _context.Restaurants.Add(restaurant);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(restaurantDTO);
        }

        // GET: Restaurant/Edit/1
        public IActionResult Edit(int id)
        {
            var restaurant = _context.Restaurants.Find(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            var restaurantDTO = new RestaurantDTO
            {
                Rid = restaurant.Rid,
                Name = restaurant.Name,
                Address = restaurant.Address
            };
            return View(restaurantDTO);
        }

        // POST: Restaurant/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, RestaurantDTO restaurantDTO)
        {
            if (id != restaurantDTO.Rid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var restaurant = new Restaurant
                {
                    Rid = restaurantDTO.Rid,
                    Name = restaurantDTO.Name,
                    Address = restaurantDTO.Address
                };
                _context.Restaurants.Update(restaurant);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(restaurantDTO);
        }

        // GET: Restaurant/Delete/1
        public IActionResult Delete(int id)
        {
            var restaurant = _context.Restaurants.Find(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            _context.Restaurants.Remove(restaurant);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
