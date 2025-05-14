using Business.Abstract;
using Business.Constants;
using Core.Aspect.AutoFac.Validation;
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
    public class ColorManager : IColorService
    {
       
        
        readonly IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
           _colorDal = colorDal;
        }

         //[SecuredOperation("color.add, admin")]
         // [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
          //ValidationTool.Validate(new ColorValidator(), color);

           _colorDal.Add(color);
           return new SuccessResult();
        }

        public IResult Delete(Color color)
        {
          _colorDal.Delete(color);
          return new SuccessResult();
        }

        public IDataResult<List<Color>> GetAll()
        {
           return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.EntitiesListed);
        }

        public IResult Update(Color color)
        {
           _colorDal.Update(color);
           return new SuccessResult();
        }

        public IDataResult<Color> GetByColorId(int colorId)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(b => b.ColorId == colorId));
        }
    }
    
}