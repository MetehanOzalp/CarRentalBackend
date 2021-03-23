using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        public IResult Add(Payment payment)
        {
            return new SuccessResult(Messages.SuccessfullyPaid);
        }
    }
}
