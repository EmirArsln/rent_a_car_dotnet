using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager (IBrandDal brandDal) : IBrandService
    {
        readonly IBrandDal _brandDal = brandDal;

        public IResult AddBrand(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult();
        }

        public List<Brand> GetCarsByBrandId(int brandId)
        {          
                var brands = _brandDal.Get(b => b.BrandId == brandId);
                return brands != null ? [brands] : [];
            
        }
    }
    


    
}
