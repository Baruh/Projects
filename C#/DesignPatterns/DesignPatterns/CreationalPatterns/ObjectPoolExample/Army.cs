namespace DesignPatterns.CreationalPatterns.ObjectPoolExample
{
    using System.Collections.Generic;

    public static class Army
    {
        private const int maxArmySize = 2;
        private static readonly Queue<Military> soldiers = new Queue<Military>(maxArmySize);

        public static Military GetNewSoldier()
        {
            Military soldier;
            if (soldiers.Count >= maxArmySize)
            {
                soldier = GetSoldier();
            }
            else
            {
                soldier = CreateNewSoldier();
            }

            return soldier;
        }

        public static void PutSoldier(Military obj)
        {
            soldiers.Enqueue(obj);
        }

        private static Military CreateNewSoldier()
        {
            var soldier = new Military();
            soldiers.Enqueue(soldier);
            return soldier;
        }

        private static Military GetSoldier()
        {
            var soldier = soldiers.Dequeue();
            soldier.Reset();
            return soldier;
        }
    }
}
