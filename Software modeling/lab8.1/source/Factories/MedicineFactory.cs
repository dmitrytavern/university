using App.Entities.Medicines;
using App.Enums;
using App.Interfaces;

namespace App.Factories
{
    class MedicineFactory
    {
        public static IMedicine CreateMedicine(MedicinesEnum medicine)
        {
            switch(medicine)
            {
                case MedicinesEnum.Vitamins:
                    return new Vitamins();
                case MedicinesEnum.CoughMedicine:
                    return new CoughMedicine();
                case MedicinesEnum.Antiviral:
                    return new Antiviral();
                case MedicinesEnum.Decongestant:
                    return new Decongestant();
                case MedicinesEnum.FeverReducer:
                    return new FeverReducer();
                default:
                    throw new Exception("Medicine is invalid.");
            }
        }
    }
}
