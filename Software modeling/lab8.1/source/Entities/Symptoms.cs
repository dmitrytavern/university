using App.Interfaces;

namespace App.Entities
{
    class Symptoms : ISymptoms
    {
        public double Temperature { get; }

        public bool HasHeadache { get; }

        public bool HasSoreThroat { get; }

        public bool HasRunnyNose { get; }

        public bool HasCough { get; }

        public Symptoms(double temperature, bool hasHeadache, bool hasSoreThroat, bool hasRunnyNose, bool hasCough)
        {
            Temperature = temperature;
            HasHeadache = hasHeadache;
            HasSoreThroat = hasSoreThroat;
            HasRunnyNose = hasRunnyNose;
            HasCough = hasCough;
        }
    }
}
