using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailDto> GetAllDetails(string defaultImagePath = null);
        List<CarDetailDto> GetAllDetailsBy(Expression<Func<Car, bool>> filter, string defaultImagePath=null);
        CarDetailDto GetDetails(Expression<Func<Car, bool>> filter, string defaultImagePath=null);
        List<CarDetailDto> GetRentableDetails(string defaultImagePath = null);
        List<CarDetailDto> GetRentedDetails(string defaultImagePath = null);
        List<CarDetailWithImagesDto> GetAllDetailsWithImages(string defaultImagePath = null);
        CarDetailWithImagesDto GetDetailsWithImagesById(int carId, string defaultImagePath = null);
    }
}
