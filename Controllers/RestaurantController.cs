using Restaurant_Rater.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Restaurant_Rater.Controllers
{
    public class RestaurantController : ApiController
    {
        private readonly RestaurantDbContext _dbContext = new RestaurantDbContext();
        //post method
        public async Task<IHttpActionResult> PostRestaurant(Restaurant restaurant)
        {
            if (ModelState.IsValid && restaurant != null)
            {
                _dbContext.Restaurants.Add(restaurant);
                await _dbContext.SaveChangesAsync();
                return Ok();
            }
            return BadRequest(ModelState);
        }

        // get all

        public async Task<IHttpActionResult> GetAllContent()
        {
            List<Restaurant> restaurants = await _dbContext.Restaurants.ToListAsync();
            return Ok(restaurants);
        }

        //get by id

        public async Task<IHttpActionResult> GetByID(int id)
        {
            Restaurant restaurant = await _dbContext.Restaurants.FindAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            return Ok(restaurant);
        }

        // put (update)

        // public async Task<IHttpActionResult> PutUpdate()

        // delete by ID
    }
}
