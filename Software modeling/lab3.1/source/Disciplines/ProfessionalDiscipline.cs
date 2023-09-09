using University.Interfaces;

namespace University.Disciplines
{
    class ProfessionalDiscipline : IAbstractDiscipline
    {
        private readonly string name;
        private readonly string type;

        public ProfessionalDiscipline(string _name)
        {
            name = _name;
            type = "Professional";
        }

        public string GetName()
        {
            return name;
        }

        public new string GetType()
        {
            return type;
        }
    }
}
