using University.Types;
using University.Interfaces;

namespace University.Departments
{
    class EveningDepartment : IAbstractDepartment
    {
        private readonly string name;
        private readonly string type;

        private List<IAbstractDiscipline> disciplines = new();

        public EveningDepartment(string departmentName)
        {
            name = departmentName;
            type = nameof(TypesEnum.Evening);
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
