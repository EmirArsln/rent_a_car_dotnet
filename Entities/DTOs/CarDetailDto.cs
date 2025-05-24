using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CarDetailDto:IDto 
    {
        public int CarId { get; set; }
        public string CarName { get; set; } = string.Empty;
        public string ModelYear { get; set; } 
        public string Description { get; set; } = string.Empty;
        public string BrandName { get; set; } = string.Empty;
        public string ColorName { get; set; } = string.Empty;
        public decimal DailyPrice { get; set; }
        public string ImagePath { get; set; } = string.Empty;
        public int Seats { get; set; }
        public string Gear { get; set; }
        public int Speed { get; set; }
        public string FuelType { get; set; }

    }
}
