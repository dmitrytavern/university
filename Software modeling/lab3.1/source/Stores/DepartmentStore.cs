using University.Interfaces;

namespace University.Stores
{
    class DepartmentStore
    {
        public static bool ContainsByName(List<IAbstractDepartment> departments, string departmentName)
        {
            foreach (IAbstractDepartment department in departments)
            {
                if (department.GetName() == departmentName)
                {
                    return true;
                }
            }

            return false;
        }

        public static IAbstractDepartment GetByName(List<IAbstractDepartment> departments,string departmentName)
        {
            foreach (IAbstractDepartment department in departments)
            {
                if (department.GetName() == departmentName)
                {
                    return department;
                }
            }

            throw new Exception("Department by name: " + departmentName + " not exists.");
        }
    }
}
