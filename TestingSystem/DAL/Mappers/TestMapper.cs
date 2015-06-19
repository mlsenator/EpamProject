using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Mapper;
using DAL.Interface.DTO;
using ORM.Models;

namespace DAL.Mappers
{
    public class TestMapper : IMapper<Test, DALTest>
    {
        public Test ToOrm(DALTest test)
        {
            return test.ToOrmTestFull();
        }

        public DALTest ToDal(Test test)
        {
            return test.ToDalTestFull();
        }
    }
}
