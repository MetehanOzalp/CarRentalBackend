using Business.Abstract;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        ICarService _carService;
        ICustomerService _customerService;

        public RentalManager(IRentalDal rentalDal, ICarService carService, ICustomerService customerService)
        {
            _rentalDal = rentalDal;
            _carService = carService;
            _customerService = customerService;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(CheckReturnDate(rental.CarId), RentalCheck(rental), CheckFindeksScore(rental.CustomerId, rental.CarId));
            if (result != null)
            {
                return result;
            }
            _rentalDal.Add(rental);
            IncreasingFindeksScore(rental.CustomerId);
            return new SuccessResult(Messages.RentalSuccessful);
        }

        public IResult CheckReturnDate(int carId)
        {
            var result = _rentalDal.GetRentalDetails(r => r.CarId == carId && r.ReturnDate == null);
            if (result.Count > 0)
            {
                return new ErrorResult(Messages.RentalAddedError);
            }
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult CheckStatus(int carId)
        {
            var result = _rentalDal.GetRentalDetails(r => r.CarId == carId && r.ReturnDate == null);
            if (result.Count > 0)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails(int carId)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(r => r.CarId == carId));
        }

        public IDataResult<List<RentalDetailDto>> GetRentals()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public IResult UpdateReturnDate(int carId)
        {
            var result = _rentalDal.Get(r => r.CarId == carId && r.ReturnDate == null);
            var updatedRental = result;
            if (updatedRental.ReturnDate != null)
            {
                return new ErrorResult();
            }
            updatedRental.ReturnDate = DateTime.Now;
            _rentalDal.Update(updatedRental);
            return new SuccessResult();
        }

        public IResult RentalCheck(Rental rental)
        {
            var result = _rentalDal.GetAll(r => r.CarId == rental.CarId && (r.RentDate >= rental.RentDate || r.ReturnDate <= rental.ReturnDate)).Any();
            if (result)
            {
                return new ErrorResult(Messages.NotAvailable);
            }
            return new SuccessResult();
        }

        public IResult CheckFindeksScore(int customerId, int carId)
        {
            var customerFindeksScore = _customerService.GetById(customerId).Data.FindeksScore;
            var carFindeksScore = _carService.GetCarById(carId).Data.MinFindeksScore;

            if (customerFindeksScore < carFindeksScore)
            {
                return new ErrorResult(Messages.NotEnoughFindeksScore);
            }

            return new SuccessResult();
        }

        public IResult IncreasingFindeksScore(int customerId)
        {
            var customer = _customerService.GetById(customerId).Data;
            if (customer.FindeksScore <= 1880)
            {
                customer.FindeksScore += 20;
                _customerService.Update(customer);
            }
            return new SuccessResult();
        }
    }
}
