﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> GetById(int id);
        IDataResult<List<Customer>> GetCustomersByUserId(int userId);
        IDataResult<CustomerDetailDto> GetCustomerDetailsById(int id);
        IDataResult<List<CustomerDetailDto>> GetAllCustomerDetails();
        IDataResult<List<CustomerDetailDto>> GetCustomerDetailsByUserId(int userId);
        IDataResult<int> GetFindeksPuani(int customerId);
        IResult Add(Customer customer);
        IResult Delete(Customer customer);
        IResult Update(Customer customer);
    }
}
