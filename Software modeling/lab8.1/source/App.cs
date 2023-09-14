using App.Entities;
using App.Interfaces;
using App.Strategies;

namespace App
{
    public partial class App : Form
    {
        public App()
        {
            InitializeComponent();
        }

        private void buttonDiagnose_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxPatientName.Text))
            {
                return;
            }

            ISymptoms symptoms = new Symptoms(
                (double)numericPatientTemperature.Value,
                checkBoxHasHeadache.Checked,
                checkBoxHasSoreThroat.Checked,
                checkBoxHasRunnyNose.Checked,
                checkBoxHasCough.Checked
            );

            IPatient patient = new Patient(
                textBoxPatientName.Text,
                dateTimePickerPatientBirthday.Text,
                symptoms
            );

            Context context = new();

            context.SetStrategy(new HealthStrategy());

            if (patient.Symptoms.Temperature >= 37 && 
                patient.Symptoms.Temperature < 38  ||
                patient.Symptoms.HasCough ||
                patient.Symptoms.HasRunnyNose)
            {
                context.SetStrategy(new ColdStrategy());
            }

            if (patient.Symptoms.Temperature >= 38 &&
                patient.Symptoms.Temperature < 39 ||
                patient.Symptoms.HasHeadache ||
                patient.Symptoms.HasSoreThroat)
            {
                context.SetStrategy(new OutpatientStrategy());
            }

            if (patient.Symptoms.Temperature >= 39)
            {
             
                context.SetStrategy(new HospitalizationStrategy());
            }

            context.DiagnosePatient(patient);

            RenderList(patient);
        }

        private void RenderList(IPatient patient)
        {
            listBox1.Items.Clear();
            listBox1.Items.Add("Patient: " + patient.Name);

            if (patient.TreatmentCourse.Health)
            {
                listBox1.Items.Add("Treatment course: absent, patient is healthy");
            }
            else
            { 
                listBox1.Items.Add("Treatment course:");
                listBox1.Items.Add("  Doctor comment:");

                if (patient.TreatmentCourse.HomeTreatment)
                {
                    listBox1.Items.Add("    You need treatment at home");
                }

                if (patient.TreatmentCourse.OutpatientTreatment)
                {
                    listBox1.Items.Add("    You need to be treated on an outpatient basis");
                }

                if (patient.TreatmentCourse.HospitalizationRequired)
                {
                    listBox1.Items.Add("    You urgently need to be hospitalized");
                }

                listBox1.Items.Add("  Medicines list:");

                foreach (IMedicine medicine in patient.TreatmentCourse.Medicines)
                {
                    listBox1.Items.Add("    - " + medicine.Name);
                }

                if (patient.TreatmentCourse.AntibacterialTherapy ||
                    patient.TreatmentCourse.WarmthPrescription)
                {
                    listBox1.Items.Add("  Additional procedures:");

                    if (patient.TreatmentCourse.WarmthPrescription)
                    {
                        listBox1.Items.Add("    - Warming up is prescribed for you");
                    }

                    if (patient.TreatmentCourse.AntibacterialTherapy)
                    {
                        listBox1.Items.Add("    - You have been prescribed antibacterial therapy");

                    }
                }
            }
        }
    }
}