using App.Interfaces;

namespace App.Strategies
{
    class RyuStrategy : IStrategy
    {
        public void ExecuteTactic(IFighter fighter)
        {
            fighter.AddComment(fighter.Name + " decided to choose Ryu tactic.");

            fighter.Jump();
            fighter.Kick();

            fighter.AddComment("*" + fighter.Name + " jumped and neutralized the enemy with his foot..");

            fighter.AddComment("*The second opponent hit the barrel and it rolled towards the player.*");

            fighter.Jump();

            fighter.AddComment("*" + fighter.Name + " was able to dodge.*");

            fighter.Jump();
            fighter.Punch();

            fighter.AddComment("*" + fighter.Name + " repeated his blow and neutralized the second enemy.");

            fighter.AddComment("*The last enemy is defeated*");
        }
    }
}
