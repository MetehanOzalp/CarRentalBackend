using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetCarById(int Id);
        IDataResult<List<Car>> GetCarsByBrandId(int Id);
        IDataResult<List<Car>> GetCarsByColorId(int Id);
        IDataResult<List<CarDetailDto>> GetCarsDetails();
        IDataResult<List<CarDetailDto>> GetCarsDetailsByFilter(CarDetailFilterDto filterDto);
        IDataResult<List<CarDetailDto>> GetCarDetailById(int id);
        IDataResult<List<CarDetailDto>> GetCarDetailByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetCarDetailByColorId(int colorId);
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IResult AddTransactionalTest(Car car);
    }
}
