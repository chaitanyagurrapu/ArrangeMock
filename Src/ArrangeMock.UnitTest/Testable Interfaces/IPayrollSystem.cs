using System;

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
        void FinalisePaymentsForEmployeeForMonth(string employeeName, int month);
    }
}
