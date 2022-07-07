using CarDealer.API.Models;
using MongoDB.Driver;
using MongoDB.Bson;

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
            //cars.DeleteMany(new BsonDocument());
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
                    Name = "Renault Kadjar",
                    Description = "Renault Kadjar 1.6 Energy TCe Intens",
                    ImageFile = "product-1.png",
                    Price = 64000.99M,
                },
                new  Car()
                {
                    Name = "Volkswagen Tiguan",
                    Description = "Volkswagen Tiguan 2.0 TDI 4Mot Sport&Style DSG",
                    ImageFile = "product-2.png",
                    Price = 52900.00M,
                },
                new Car()
                {
                    Name = "Audi Q7",
                    Description = "Audi Q7 3.0 TDI ultra quattro tiptronic",
                    ImageFile = "product-3.png",
                    Price = 245998.00M,
                },
                new Car()
                {
                    Name = "Alfa Romeo Giulia",
                    Description = "Alfa Romeo Giulia 2.0 Turbo Veloce TI Q4",
                    ImageFile = "product-4.png",
                    Price = 165000.00M,
                },
                new Car()
                {
                    Name = "Porsche Cayenne",
                    Description = "Porsche Cayenne S Diesel",
                    ImageFile = "product-5.png",
                    Price = 298000.00M,
                },
                new Car()
                {
                    Name = "Škoda Octavia",
                    Description = "Škoda Octavia 1.6 TDI SCR Ambition DSG",
                    ImageFile = "product-6.png",
                    Price = 59900.00M,
                }
            };
        }


    }
}
