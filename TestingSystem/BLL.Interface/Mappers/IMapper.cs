using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interface.Mappers
{
    public interface IMapper<TDalEntity, TBllEntity>
    {
        TDalEntity ToDal(TBllEntity bll);
        TBllEntity ToBll(TDalEntity dal);
    }
}
