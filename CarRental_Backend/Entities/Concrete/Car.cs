﻿using Core.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Car:IEntity
    {
        [Key]
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public string CarName { get; set; }
        public short ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public int MinFindeksPuan { get; set; }
        public string Description { get; set; }
    }
}
