using App.Entities;

namespace App.Interfaces
{
    interface IStrategy
    {
        void Diagnose(IPatient patient);
    }
}
