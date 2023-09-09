namespace University.Interfaces
{
    interface IAbstractDepartment
    {
        string GetName();

        string GetType();

        void AddDiscipline(IAbstractDiscipline discipline);

        List<IAbstractDiscipline> GetDisciplines();
    }
}
