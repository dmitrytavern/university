using University.Departments;
using University.Disciplines;
using University.Interfaces;

namespace University.Factories
{
    class EveningFactory : IAbstractFactory
    {
        public IAbstractDepartment CreateDepartment(string name)
        {
            return new EveningDepartment(name);
        }

        public IAbstractDiscipline CreateDiscipline(string name)
        {
            return new GeneralDiscipline(name);
        }
    }
}
