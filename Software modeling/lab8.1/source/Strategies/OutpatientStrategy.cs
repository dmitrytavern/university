using App.Enums;
using App.Factories;
using App.Interfaces;

namespace App.Strategies
{
    class OutpatientStrategy : IStrategy
    {
        public void Diagnose(IPatient patient)
        {
            patient.TreatmentCourse.Health = false;
            patient.TreatmentCourse.OutpatientTreatment = true;
            patient.TreatmentCourse.WarmthPrescription = true;
            patient.TreatmentCourse.AntibacterialTherapy = true;
            patient.TreatmentCourse.Medicines.Add(
                MedicineFactory.CreateMedicine(MedicinesEnum.Vitamins)
            );
            patient.TreatmentCourse.Medicines.Add(
                MedicineFactory.CreateMedicine(MedicinesEnum.CoughMedicine)
            );
            patient.TreatmentCourse.Medicines.Add(
                MedicineFactory.CreateMedicine(MedicinesEnum.FeverReducer)
            );
        }
    }
}
