using University.Departments;
using University.Disciplines;
using University.Interfaces;

namespace University.Factories
{
    class DayFactory : IAbstractFactory
    {
        public IAbstractDepartment CreateDepartment(string name)
        {
            return new DayDepartment(name);
        }

        public IAbstractDiscipline CreateDiscipline(string name)
        {
            return new ProfessionalDiscipline(name);
        }
    }
}
