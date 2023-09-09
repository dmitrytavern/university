using University.Types;
using University.Factories;
using University.Interfaces;
using University.Stores;

namespace University
{
    public readonly struct DepartmentForm
    {
        readonly public string Name;
        readonly public string Type;

        public DepartmentForm(string name, string type)
        {
            Name = name;
            Type = type;
        }
    }

    public readonly struct DisciplineForm
    {
        readonly public string Name;
        readonly public string Type;
        readonly public string Department;

        public DisciplineForm(string name, string type, string department)
        {
            Name = name;
            Type = type;
            Department = department;
        }
    }

    public partial class App : Form
    {
        private readonly List<IAbstractDepartment> departments = new();

        public App()
        {
            InitializeComponent();
        }

        private void App_Load(object sender, EventArgs e)
        {
            comboBoxDepartmentType.Items.Add(TypesEnum.Day);
            comboBoxDepartmentType.Items.Add(TypesEnum.Evening);
            comboBoxDepartmentType.SelectedIndex = 0;

            comboBoxDisciplineType.Items.Add(TypesEnum.Day);
            comboBoxDisciplineType.Items.Add(TypesEnum.Evening);
            comboBoxDisciplineType.SelectedIndex = 0;
        }

        private void buttonAddDepartment_Click(object sender, EventArgs e)
        {
            DepartmentForm form = ParseDepartmentForm();

            IAbstractFactory factory = CreateFacotry(form.Type);

            IAbstractDepartment department = factory.CreateDepartment(form.Name);

            departments.Add(department);

            RenderDepartmentList();
        }

        private void buttonAddDescipline_Click(object sender, EventArgs e)
        {
            DisciplineForm form = ParseDisciplineForm();

            IAbstractFactory factory = CreateFacotry(form.Type);

            IAbstractDiscipline discipline = factory.CreateDiscipline(form.Name);

            IAbstractDepartment department = DepartmentStore.GetByName(departments, form.Department);

            department.AddDiscipline(discipline);

            RenderDisciplineList();
        }

        private DepartmentForm ParseDepartmentForm()
        {
            string departmentName = textBoxDepartmentName.Text;
            string departmentType = ((TypesEnum)comboBoxDepartmentType.SelectedItem).ToString();

            if (departmentName is null)
            {
                throw new Exception("Department name is null.");
            }

            if (departmentType is null)
            {
                throw new Exception("Department type is null.");
            }

            if (DepartmentStore.ContainsByName(departments, departmentName))
            {
                throw new Exception("Department already exists.");
            }

            return new DepartmentForm(departmentName, departmentType);
        }

        private DisciplineForm ParseDisciplineForm()
        {
            string disciplineName = textBoxDisciplineName.Text;
            string? departmentName = (string)comboBoxDepartments.SelectedItem;
            string? disciplineType = ((TypesEnum)comboBoxDisciplineType.SelectedItem).ToString();

            if (disciplineName is null)
            {
                throw new Exception("Discipline name is null.");
            }

            if (departmentName is null)
            {
                throw new Exception("Department name is null.");
            }

            if (disciplineType is null)
            {
                throw new Exception("Discipline type is null.");
            }

            if (!DepartmentStore.ContainsByName(departments, departmentName))
            {
                throw new Exception("Department " + departmentName + " not exists.");
            }

            return new DisciplineForm(disciplineName, disciplineType, departmentName);
        }

        private void RenderDepartmentList()
        {
            listBoxDepartments.Items.Clear();
            comboBoxDepartments.Items.Clear();

            foreach (var department in departments)
            {
                string name = department.GetName();
                string type = department.GetType();

                listBoxDepartments.Items.Add(name + " (" + type + ")");
                comboBoxDepartments.Items.Add(name);
            }
        }

        private void RenderDisciplineList()
        {
            listBoxDisciplines.Items.Clear();

            foreach (IAbstractDepartment department in departments)
            {
                listBoxDisciplines.Items.Add(department.GetName() + " (" + department.GetType() + ")");

                foreach (IAbstractDiscipline discipline in department.GetDisciplines())
                {
                    listBoxDisciplines.Items.Add("  - " + discipline.GetName() + " (" + discipline.GetType() + ")");
                }
            }
        }

        private IAbstractFactory CreateFacotry(string type)
        {
            switch (type)
            {
                case nameof(TypesEnum.Day):
                    return new DayFactory();
                case nameof(TypesEnum.Evening):
                    return new EveningFactory();
                default:
                    throw new Exception("Invalid department id: " + type);
            }
        }
    }
}