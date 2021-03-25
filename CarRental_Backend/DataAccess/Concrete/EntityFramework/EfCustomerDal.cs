﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentACarContext>, ICustomerDal
    {

        public List<CustomerDetailDto> GetAllDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Customers
                             join u in context.Users
                             on c.UserId equals u.Id
                             select new CustomerDetailDto
                             {
                                 Id = c.Id,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email,
                                 CompanyName = c.CompanyName,
                             };
                return result.ToList();
            }
        }

        public CustomerDetailDto GetDetails(Expression<Func<Customer, bool>> filter)
        {
            return GetAllDetailsBy(filter).SingleOrDefault();
        }

        public List<CustomerDetailDto> GetAllDetailsBy(Expression<Func<Customer, bool>> filter)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Customers.Where(filter)
                             join u in context.Users
                             on c.UserId equals u.Id
                             select new CustomerDetailDto
                             {
                                 Id = c.Id,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email,
                                 CompanyName = c.CompanyName,
                             };
                return result.ToList();
            }
        }
    }
}
