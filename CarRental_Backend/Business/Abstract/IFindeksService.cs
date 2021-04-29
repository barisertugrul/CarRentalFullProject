using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IFindeksService
    {
        IDataResult<int> GetFindeksPuan(string tcKimlikNo, string ad, string soyad);
    }
}
