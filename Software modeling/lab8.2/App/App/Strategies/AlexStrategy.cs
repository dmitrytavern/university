using App.Interfaces;

namespace App.Strategies
{
    class AlexStrategy : IStrategy
    {
        public void ExecuteTactic(IFighter fighter)
        {
            fighter.AddComment(fighter.Name + " decided to choose Alex tactic.");

            fighter.Kick();

            fighter.AddComment(fighter.Name + " made such a kick that the enemy flew five meters.");

            fighter.AddComment("*The second opponent hit the barrel and it rolled towards the player.*");

            fighter.Kick();

            fighter.AddComment("*" + fighter.Name + " kicked the barrel, pushing it into the enemy.*");

            fighter.Roll();

            fighter.AddComment("*To reduce the distance, the player rolled towards the enemy.*");

            fighter.Punch();

            fighter.AddComment("*The last enemy is defeated*");
        }
    }
}
