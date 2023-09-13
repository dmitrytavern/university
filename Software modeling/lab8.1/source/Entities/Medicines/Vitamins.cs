using App.Enums;
using App.Interfaces;

namespace App.Entities.Medicines
{
    class Vitamins : IMedicine
    {
        public string Name { get; } = MedicinesEnum.Vitamins.ToString();
    }
}
