using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    public interface IGameStrategy
    {
        string Action();
    }

    public class AttackStrategy : IGameStrategy
    {
        public string Action()
        {
            return "Attack";
        }
    }

    public class DefenseStrategy : IGameStrategy
    {
        public string Action()
        {
            return "Defense";
        }
    }

    public class Game
    {
        public int AllyTeamGold { get; set; }
        public int EnemyTeamGold { get; set; }
        public IGameStrategy Strategy { get; set; }

        public string MakeAction()
        {
            if (AllyTeamGold > EnemyTeamGold)
                Strategy = new AttackStrategy();
            else Strategy = new DefenseStrategy();

            return Strategy.Action();
        }
    }
}
