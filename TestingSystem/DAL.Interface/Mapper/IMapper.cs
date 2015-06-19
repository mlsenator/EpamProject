using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using Entity.Interface;

namespace DAL.Interface.Mapper
{
    public interface IMapper<TOrmEntity, TDalEntity>
        where TOrmEntity : IEntity
        where TDalEntity : IEntity
    {
        TOrmEntity ToOrm(TDalEntity dal);
        TDalEntity ToDal(TOrmEntity orm);
    }
}
