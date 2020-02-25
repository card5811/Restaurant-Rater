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
        [HttpPost]
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
        [HttpGet]
        public async Task<IHttpActionResult> GetAllContent()
        {
            List<Restaurant> restaurants = await _dbContext.Restaurants.ToListAsync();
            return Ok(restaurants);
        }

        //get by id
        [HttpGet]
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
        [HttpPut]
        public async Task<IHttpActionResult> UpdateRestaurant([FromUri]int id, [FromBody]Restaurant model)
        {
            if (ModelState.IsValid && model != null)
            {
                //this is an entity
                Restaurant restaurant = await _dbContext.Restaurants.FindAsync(id);

                if (restaurant != null)
                {
                    restaurant.Name = model.Name;
                    restaurant.Rating = model.Rating;
                    restaurant.Style = model.Style;
                    restaurant.DollarSigns = model.DollarSigns;

                    await _dbContext.SaveChangesAsync();
                    return Ok();
                }
                return NotFound();
            }
            return BadRequest(ModelState);
        }

        // delete by ID
        [HttpDelete]
        public async Task<IHttpActionResult> UpdateRestaurant(Restaurant restaurant)
        {
            if (ModelState.IsValid && restaurant != null)
            {
                _dbContext.Restaurants.Remove(restaurant);
                await _dbContext.SaveChangesAsync();
                return Ok();
            }
            return BadRequest(ModelState);
        }
    }
}


