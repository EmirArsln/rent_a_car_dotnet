using Core.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Car : IEntity 
    {
        public int CarId { get; set; }
        public  string CarName { get; set; } = string.Empty;
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public string ModelYear { get; set; } = string.Empty;
        public Decimal DailyPrice { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
