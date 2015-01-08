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
        int GetSalaryForEmployeeForYear(string employeeName, int year);
        int GetSalaryForEmployeeForPeriod(string employeeName, DateTime from, DateTime to);
        void FinaliseAllPayments();
        void FinalisePaymentsForEmployee(string employeeName);
    }
}
