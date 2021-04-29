using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CreditCardManager:ICreditCardService
    {
        private ICreditCardDal _creditCardDal; 


        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }


        public IDataResult<List<CreditCard>> GetAll()
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll());
        }

        public IDataResult<CreditCard> GetById(int id)
        {
            return new SuccessDataResult<CreditCard>(_creditCardDal.Get(c => c.Id == id));
        }

        public IDataResult<List<CreditCard>> GetCardsByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll(c => c.CustomerId == customerId));
        }

        [ValidationAspect(typeof(CreditCardValidator))]
        [CacheRemoveAspect("ICreditCardService.Get")]
        public IResult Add(CreditCard creditCard)
        {
            IResult result = IsExistCard(creditCard);
            if (!result.Success)
            {
                return new ErrorResult(Messages.ExistCard);
            }
            _creditCardDal.Add(creditCard);
            return new SuccessResult(Messages.NewCardAdded);
        }

        [ValidationAspect(typeof(CreditCardValidator))]
        [CacheRemoveAspect("ICreditCardService.Get")]
        public IResult Delete(CreditCard creditCard)
        {
            _creditCardDal.Delete(creditCard);
            return new SuccessResult();
        }


        [ValidationAspect(typeof(CreditCardValidator))]
        [CacheRemoveAspect("ICreditCardService.Get")]
        public IResult Update(CreditCard creditCard)
        {
            IResult result = IsExistCard(creditCard, true);
            if (!result.Success)
            {
                return new ErrorResult(Messages.ExistCard);
            }

            _creditCardDal.Update(creditCard);
            return new SuccessResult();
        }

        private IResult IsExistCard(CreditCard creditCard, bool isUpdate=false)
        {
            CreditCard card = (isUpdate)
                ? _creditCardDal.Get(c => c.CardNumber == creditCard.CardNumber && c.Id != creditCard.Id)
                : _creditCardDal.Get(c => c.CardNumber == creditCard.CardNumber);
            if (card != null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
