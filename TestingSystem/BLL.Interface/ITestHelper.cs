using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interface
{
    public interface ITestHelper
    {
        int HandleTestResult(BLLTest test, List<int> answersId, string username, DateTime startTime, DateTime finishTime);
    }
}
