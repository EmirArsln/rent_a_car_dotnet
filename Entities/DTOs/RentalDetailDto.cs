using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class RentalDetailDto :IDto
    {
        public int RentalId { get; set; }
        public int CarId { get; set; }
        public string FirstName { get; set; } =string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string BrandName { get; set; } = string.Empty;
        public string ColorName { get; set; } = string.Empty;
        public string ModelYear { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty; 
        public decimal DailyPrice { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int UserId { get; set; }
        public int Seats { get; set; }
        public string Gear { get; set; }
        public int Speed { get; set; }
        public string FuelType { get; set; }
    }
}
