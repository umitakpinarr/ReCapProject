﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IColorService
    {
        IResult Update(Color color);
        IResult Delete(Color color);
        IResult Add(Color color);
        IDataResult<List<Color>> GetAll();
        IDataResult<Color> GetById(int Id);
    }
}