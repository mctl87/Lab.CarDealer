using CarDealer.API.Data;
using CarDealer.API.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace CarDealer.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly CarContext _context;

        private readonly ILogger<CarController> _logger;

        public CarController(CarContext context, ILogger<CarController> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet(Name = "GetCars")]
        public async Task<IEnumerable<Car>> Get()
        {
            return await _context.Cars.Find(prop=>true).ToListAsync();
        }
    }
}