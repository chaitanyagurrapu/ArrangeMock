using System;

namespace ArrangeMock.UnitTest.TestableArtifacts
{
    public interface IPayrollSystem
    {
        bool IsOnline { get; set; }
        PaymentGateway PaymentGateway { get; set; }

        DateTime GetNextPayDate();
        int GetSalaryForEmployee(string employeeName);
        int GetSalaryForEmployeeForYear(string employeeName, int year);
        int GetSalaryForEmployeeForPeriod(string employeeName, DateTime from, DateTime to);
        void FinaliseAllPayments();
        void FinalisePaymentsForEmployee(string employeeName);
        void FinalisePaymentsForEmployeeForMonth(string employeeName, int month);
    }
}
