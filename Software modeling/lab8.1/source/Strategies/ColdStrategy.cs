using App.Enums;
using App.Factories;
using App.Interfaces;

namespace App.Strategies
{
    class ColdStrategy : IStrategy
    {
        public void Diagnose(IPatient patient)
        {
            patient.TreatmentCourse.Health = false;
            patient.TreatmentCourse.HomeTreatment = true;
            patient.TreatmentCourse.Medicines.Add(
                MedicineFactory.CreateMedicine(MedicinesEnum.Vitamins)
            );
            patient.TreatmentCourse.Medicines.Add(
                MedicineFactory.CreateMedicine(MedicinesEnum.CoughMedicine)
            );
            patient.TreatmentCourse.Medicines.Add(
                MedicineFactory.CreateMedicine(MedicinesEnum.Decongestant)
            );
        }
    }
}
