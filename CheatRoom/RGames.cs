using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheatRoom
{
    public delegate double QSTRestoreHealth(double health, double maxHealth);
    public class RGames
    {
        public int ID;
        public string name;
        public double health;
        public double maxHealth;

        //List<string> effects = new List<string> { "" };

        public void restoreHealth(double val, QSTRestoreHealth rsHealth)
        {
            health += val;
            health *= rsHealth(health, maxHealth);

        }

        public void restoreHealth(double val)
        {
            health += val;
        }

    }
}
