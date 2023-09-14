using App.Interfaces;

namespace App.Strategies
{
    class KenStrategy : IStrategy
    {
        public void ExecuteTactic(IFighter fighter)
        {
            fighter.AddComment(fighter.Name + " decided to choose Ken tactic.");

            fighter.Punch();

            fighter.AddComment("*" + fighter.Name + " neutralized the first enemy with his blow..");

            fighter.AddComment("*The second opponent hit the barrel and it rolled towards the player.*");

            fighter.Kick();

            fighter.AddComment("*" + fighter.Name + " kicked the barrel, pushing it into the enemy.*");

            fighter.AddComment("*The last enemy is defeated*");
        }
    }
}
