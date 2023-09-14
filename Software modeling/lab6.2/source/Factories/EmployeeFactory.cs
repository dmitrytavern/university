using App.Entities;
using App.Enums;
using App.Interfaces;

namespace App.Factories
{
    class EmployeeFactory
    {
        private static DateTime dateCount = DateTime.Now;

        public static IEmployee CreateEmployee(string name, EmployeeEnum employee)
        {
            dateCount = dateCount.AddDays(1);

            switch (employee)
            {
                case EmployeeEnum.Worker:
                    return new Worker(name, dateCount.ToString());
                case EmployeeEnum.Manager:
                    return new Manager(name, dateCount.ToString());
                case EmployeeEnum.Director:
                    return new Director(name, dateCount.ToString());
                default:
                    throw new Exception("Invalid soldier.");
            }
        }
    }
}
