using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserOperationClaimService
    {
        IResult Add(UserOperationClaim userOperationClaim);
    }
}
