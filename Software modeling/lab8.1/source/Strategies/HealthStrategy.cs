using App.Interfaces;

namespace App.Strategies
{
    class HealthStrategy : IStrategy
    {
        public void Diagnose(IPatient patient)
        {
            patient.TreatmentCourse.Health = true;
        }
    }
}
