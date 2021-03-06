﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Mappers;
using DAL.Interface.DTO;
using BLL.Interface.Entities;

namespace BLL.Mappers
{
    public class TestResultMapper : IMapper<DALTestResult, BLLTestResult>
    {
        public DALTestResult ToDal(BLLTestResult testResult)
        {
            return testResult.ToDalTestResultFull();
        }

        public BLLTestResult ToBll(DALTestResult testResult)
        {
            return testResult.ToBllTestResultFull();
        }
    }
}
