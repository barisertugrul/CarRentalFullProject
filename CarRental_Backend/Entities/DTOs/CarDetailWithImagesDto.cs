﻿using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs
{
    public class CarDetailWithImagesDto : IDto
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public short ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public int MinFindeksPuan { get; set; }
        public string Description { get; set; }
        public List<CarImage> Images { get; set; }
    }
}
