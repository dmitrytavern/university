using App.Enums;
using App.Interfaces;

namespace App.Entities.Medicines
{
    class Antiviral : IMedicine
    {
        public string Name { get; } = MedicinesEnum.Antiviral.ToString();
    }
}
