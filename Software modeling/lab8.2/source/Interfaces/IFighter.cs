namespace App.Interfaces
{
    interface IFighter
    {
        string Name { get; }

        List<string> GetHistory();

        void AddComment(string comment);

        void Kick();

        void Punch();

        void Jump();

        void Roll();
    }
}
