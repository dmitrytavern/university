using App.Enums;
using App.Interfaces;

namespace App.Entities.Medicines
{
    class Decongestant : IMedicine
    {
        public string Name { get; } = MedicinesEnum.Decongestant.ToString();
    }
}
