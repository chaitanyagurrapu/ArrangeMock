using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrangeMock.UnitTest.TestableInterfaces
{
    public interface IPayrollSystem
    {
        DateTime GetNextPayDate();
        int GetSalaryForEmployee(string employeeName);
        void FinaliseAllPayments();
        void FinalisePaymentsForEmployee(string employeeName);
    }
}
