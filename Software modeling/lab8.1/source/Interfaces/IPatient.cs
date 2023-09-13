using App.Entities;

namespace App.Interfaces
{
    interface IPatient
    {
        string Name { get; }

        string Birthday { get; }

        ISymptoms Symptoms { get; }

        TreatmentCourse TreatmentCourse { get; }
    }
}
