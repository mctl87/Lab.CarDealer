using CarDealer.API.Models;
using MongoDB.Driver;

namespace CarDealer.API.Data
{
    public class CarContext
    {
        public CarContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);
            //client.DropDatabase(configuration["DatabaseSettings:DatabaseName"]);
            var db = client.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);

            Cars = db.GetCollection<Car>(configuration["DatabaseSettings:CollectionName"]);
            SeedData(Cars);
        }
        public IMongoCollection<Car> Cars { get; }
        private void SeedData(IMongoCollection<Car> cars)
        {
            bool exist = cars.Find(p => true).Any();
            if (!exist)
            {
                cars.InsertManyAsync(GetPreconfiguredCars());
            }
        }

        private IEnumerable<Car> GetPreconfiguredCars()
        {
            return new List<Car>()
            {
                new Car()
                {
                    Name = "IPhone X",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-1.png",
                    Price = 950.00M,
                },
                new  Car()
                {
                    Name = "Samsung 10",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-2.png",
                    Price = 840.00M,
                },
                new Car()
                {
                    Name = "Huawei Plus",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-3.png",
                    Price = 650.00M,
                },
                new Car()
                {
                    Name = "Xiaomi Mi 9",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-4.png",
                    Price = 470.00M,
                },
                new Car()
                {
                    Name = "HTC U11+ Plus",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-5.png",
                    Price = 380.00M,
                },
                new Car()
                {
                    Name = "LG G7 ThinQ EndofCourse",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-6.png",
                    Price = 240.00M,
                }
            };
        }


    }
}
