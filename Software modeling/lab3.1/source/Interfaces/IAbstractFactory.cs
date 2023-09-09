namespace University.Interfaces
{
    interface IAbstractFactory
    {
        IAbstractDepartment CreateDepartment(string name);

        IAbstractDiscipline CreateDiscipline(string name);
    }
}
