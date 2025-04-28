using Business.Abstract;
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
    public class ColorManager (IColorDal colorDal): IColorService
    {
        readonly IColorDal _colorDal = colorDal;

        public List<Color> GetCarsByColorId(int colorId)
        {
            var colors = _colorDal.Get(c => c.ColorId == colorId);
            return colors != null ? [colors] : [];
        }
    }
}
