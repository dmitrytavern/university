using App.Interfaces;

namespace App.Entities
{
    class TreatmentCourse
    {

        public readonly List<IMedicine> Medicines = new();

        public bool Health { get; set; } = false;

        public bool HomeTreatment { get; set; } = false;

        public bool OutpatientTreatment { get; set; } = false;

        public bool WarmthPrescription { get; set; } = false;

        public bool AntibacterialTherapy { get; set; } = false;

        public bool HospitalizationRequired { get; set; } = false;
    }
}
