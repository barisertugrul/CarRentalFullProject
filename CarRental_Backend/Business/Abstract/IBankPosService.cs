using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBankPosService
    {
        IResult Pay(CreditCardExtend creditCard, decimal amount);
    }
}
