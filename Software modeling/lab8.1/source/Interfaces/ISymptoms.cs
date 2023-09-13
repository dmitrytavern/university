namespace App.Interfaces
{
    interface ISymptoms
    {
        double Temperature { get; }

        bool HasHeadache { get; }

        bool HasSoreThroat {  get; }

        bool HasRunnyNose { get; }

        bool HasCough { get;}
    }
}
