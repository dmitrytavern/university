using App.Agencies;
using App.Enums;
using App.Interfaces;
using App.Entities;

namespace App
{
    public partial class App : Form
    {
        private IPerson? person;
        private IAgency agency = new WorkUA();

        public App()
        {
            InitializeComponent();
        }

        private void App_Load(object sender, EventArgs e)
        {
            comboBoxAgency.Items.Clear();
            comboBoxAgency.Items.Add(AgenciesEnum.WorkUA);
            comboBoxAgency.SelectedIndex = 0;

            comboBoxVacancy.Items.Clear();
            comboBoxVacancy.Items.Add(VacanciesEnum.Designer);
            comboBoxVacancy.Items.Add(VacanciesEnum.BackendDeveloper);
            comboBoxVacancy.Items.Add(VacanciesEnum.FrontendDeveloper);
            comboBoxVacancy.SelectedIndex = 0;

            comboBoxPersonVacancy.Items.Clear();
            comboBoxPersonVacancy.Items.Add(VacanciesEnum.Designer);
            comboBoxPersonVacancy.Items.Add(VacanciesEnum.BackendDeveloper);
            comboBoxPersonVacancy.Items.Add(VacanciesEnum.FrontendDeveloper);
            comboBoxPersonVacancy.SelectedIndex = 0;

            buttonComfirmVacancy.Enabled = false;
        }

        private void comboBoxAgency_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxAgency.SelectedItem)
            {
                case AgenciesEnum.WorkUA:
                    agency = new WorkUA();
                    break;
                default:
                    throw new Exception("Agency is invalid.");
            }
        }

        private void buttonAddVacancy_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("Added vacancy: " + comboBoxVacancy.SelectedItem);
            agency.AddVacancy((VacanciesEnum)comboBoxVacancy.SelectedItem);
        }

        private void buttonAddPerson_Click(object sender, EventArgs e)
        {
            person = new Person(
                textBoxPersonName.Text,
                (VacanciesEnum)comboBoxPersonVacancy.SelectedItem
            );

            person.Updated += Person_Updated;

            agency.AddObserver(person);

            buttonAddPerson.Enabled = false;
            textBoxPersonName.Enabled = false;
            comboBoxPersonVacancy.Enabled = false;
        }

        private void buttonComfirmVacancy_Click(object sender, EventArgs e)
        {
            if (person is null)
            {
                throw new Exception("Person is null.");
            }

            agency.RemoveObserver(person);
            buttonComfirmVacancy.Enabled = false;
        }

        private void Person_Updated(string arg1, Person arg2)
        {
            listBox1.Items.Add(arg1);
            buttonComfirmVacancy.Enabled = true;
        }
    }
}