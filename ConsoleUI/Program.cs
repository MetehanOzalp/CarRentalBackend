using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //ColorTest();
            //BrandTest();
            //UserTest();
            //RentalTest();
            //CustomerTest();
        }

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.Add(new Customer { UserId = 2, CompanyName = "X sirketi" });
            Console.WriteLine(result.Message);
        }

        private static void RentalTest()
        {
            //RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //var result = rentalManager.GetRentalDetails(1001);
            //if (result.Success)
            //{
            //    foreach (var car in result.Data)
            //    {
            //        Console.WriteLine(car.BrandName + car.UserName);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine(result.Message);
            //}
        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            /*var result = userManager.Add(new User { FirstName = "Osman", LastName = "Ozalp", Email = "osman@gamil.com", Password = "123456" });
            Console.WriteLine(result.Message);*/
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //Console.WriteLine(brandManager.GetByBrandId(1).Data.BrandName);
            var result = brandManager.GetAll();
            if (result.Success)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine(brand.BrandName);
                }
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            //colorManager.Add(new Color { });
            //colorManager.Delete(new Color { });
            var result = colorManager.GetAll();
            if (result.Success)
            {
                foreach (var color in result.Data)
                {
                    Console.WriteLine(color.ColorName);
                }
            }
            //Console.WriteLine(colorManager.GetByColorId(1).ColorName);
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            /*var result = carManager.GetCarsByBrandId(3);
            foreach (var car in result.Data)
            {
                Console.WriteLine(car.CarName);
            }*/

            /*var result2 = carManager.GetAll();
            Console.WriteLine(result2.Data);*/
            //carManager.Add(new Car { BrandId = 3, CarName = "A6", ColorId = 2, DailyPrice = 700, Descriptions = "Benzin Otomatik", ModelYear = 2015});
            var result = carManager.GetCarDetailById(1001);
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.BrandName + "-" + car.CarName + "-" + car.ColorName + "-" + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            //carManager.Update(new Car { Id=1,BrandId = 1, CarName = "E-250", ColorId = 2, DailyPrice = 800, Descriptions = "Dizel Otomatik", ModelYear = 2016 });
            //Console.WriteLine(carManager.GetCarById(1).DailyPrice);
        }
    }
}
