using App.Enums;
using App.Interfaces;

namespace App.Entities.Medicines
{
    class CoughMedicine : IMedicine
    {
        public string Name { get; } = MedicinesEnum.CoughMedicine.ToString();
    }
}
