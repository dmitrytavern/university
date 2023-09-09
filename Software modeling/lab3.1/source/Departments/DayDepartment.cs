using University.Types;
using University.Interfaces;

namespace University.Departments
{
    class DayDepartment : IAbstractDepartment
    {
        private readonly string name;
        private readonly string type;
        private readonly List<IAbstractDiscipline> disciplines = new();

        public DayDepartment(string departmentName)
        {
            name = departmentName;
            type = nameof(TypesEnum.Day);
        }

        public string GetName()
        {
            return name;
        }

        public new string GetType()
        {
            return type;
        }

        public void AddDiscipline(IAbstractDiscipline discipline)
        {
            disciplines.Add(discipline);
        }

        public List<IAbstractDiscipline> GetDisciplines()
        {
            return disciplines;
        }
    }
}
