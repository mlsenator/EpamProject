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
    public class TestResultMapper : IMapper<TestResult, DALTestResult>
    {
        public TestResult ToOrm(DALTestResult testResult)
        {
            return testResult.ToOrmTestResultFull();
        }

        public DALTestResult ToDal(TestResult testResult)
        {
            return testResult.ToDalTestResultFull();
        }
    }
}
