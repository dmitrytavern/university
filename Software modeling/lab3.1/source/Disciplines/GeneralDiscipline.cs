using University.Interfaces;

namespace University.Disciplines
{
    class GeneralDiscipline : IAbstractDiscipline
    {
        private readonly string name;
        private readonly string type;

        public GeneralDiscipline(string _name)
        {
            name = _name;
            type = "General";
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
