using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 50, ModelYear = 2002, Descriptions = "Beyaz Tofaş"},
                new Car{Id = 2, BrandId = 2, ColorId = 2, DailyPrice = 150, ModelYear = 2012, Descriptions = "Siyah Honda Civic"},
                new Car{Id = 3, BrandId = 3, ColorId = 2, DailyPrice = 200, ModelYear = 2018, Descriptions = "Siyah Renault Megane"},
                new Car{Id = 4, BrandId = 4, ColorId = 1, DailyPrice = 300, ModelYear = 2020, Descriptions = "Beyaz Volkswagen Passat"},
                new Car{Id = 5, BrandId = 2, ColorId = 3, DailyPrice = 250, ModelYear = 2020, Descriptions = "Kırmızı Honda Civic"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(int Id)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.Id == Id);
            _cars.Remove(carToDelete);
        }

        public void Delete(Car entity)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetAllCarDetailsByFilter(CarDetailFilterDto filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(p => p.Id == Id).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Descriptions = car.Descriptions;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
        }
    }
}
