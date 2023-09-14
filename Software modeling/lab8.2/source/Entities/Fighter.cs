using App.Interfaces;

namespace App.Entities
{
    class Fighter : IFighter
    {
        private readonly List<string> history = new();

        public string Name { get; }

        public Fighter(string name)
        {
            Name = name;
        }

        public List<string> GetHistory()
        {
            return history.ToList();
        }

        public void AddComment(string comment)
        {
            history.Add(comment);
        }

        public void Kick()
        {
            history.Add(Name + " make a kick.");
        }

        public void Punch()
        {
            history.Add(Name + " make a punch.");
        }

        public void Jump()
        {
            history.Add(Name + " make an jump.");
        }

        public void Roll()
        {
            history.Add(Name + " make a roll.");
        }
    }
}
