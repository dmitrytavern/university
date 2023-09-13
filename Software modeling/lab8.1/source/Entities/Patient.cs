using App.Interfaces;

namespace App.Entities
{
    class Patient : IPatient
    {
        public string Name { get; }

        public string Birthday { get; }

        public ISymptoms Symptoms { get; }

        public TreatmentCourse TreatmentCourse { get; }

        public Patient(string name, string birthday, ISymptoms symptoms)
        {
            Name = name;
            Birthday = birthday;
            Symptoms = symptoms;
            TreatmentCourse = new TreatmentCourse();
        }
    }
}
