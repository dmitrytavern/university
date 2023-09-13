using App.Enums;
using App.Factories;
using App.Interfaces;

namespace App.Strategies
{
    class HospitalizationStrategy : IStrategy
    {
        public void Diagnose(IPatient patient)
        {
            patient.TreatmentCourse.Health = false;
            patient.TreatmentCourse.HospitalizationRequired = true;
            patient.TreatmentCourse.Medicines.Add(
                MedicineFactory.CreateMedicine(MedicinesEnum.Vitamins)
            );
            patient.TreatmentCourse.Medicines.Add(
                MedicineFactory.CreateMedicine(MedicinesEnum.Antiviral)
            );
            patient.TreatmentCourse.Medicines.Add(
                MedicineFactory.CreateMedicine(MedicinesEnum.FeverReducer)
            );
        }
    }
}
