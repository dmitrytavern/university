using App.Enums;
using App.Interfaces;

namespace App.Entities.Medicines
{
    class FeverReducer : IMedicine
    {
        public string Name { get; } = MedicinesEnum.FeverReducer.ToString();
    }
}
