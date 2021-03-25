using Business.Abstract;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [CacheRemoveAspect("IUserService.Get")]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult();
        }

        [CacheRemoveAspect("IUserService.Get")]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult();
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id));
        }

        [CacheRemoveAspect("IUserService.Get")]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var result = _userDal.GetClaims(user);
            if(result == null)
            {
                return new ErrorDataResult<List<OperationClaim>>();
            }
            return new SuccessDataResult<List<OperationClaim>>(result);
        }

        [CacheAspect]
        public IDataResult<User> GetByMail(string email)
        {
            var result = _userDal.Get(u => u.Email == email);
            if(result == null)
            {
                return new ErrorDataResult<User>();
            }
            return new SuccessDataResult<User>(result);
        }
    }
}
