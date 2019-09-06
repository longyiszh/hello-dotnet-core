using System;
using System.Collections.Generic;

namespace RGame
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayRGames();
        }


        static void PlayRGames()
        {
            List<RGames> RGamess = new List<RGames>();

            RGamess.Add(new RGames() { ID = 100, name = "tony", health = 100.0, maxHealth = 100.0 });
            RGamess.Add(new RGames() { ID = 101, name = "riba", health = 60.0, maxHealth = 100.0 });
            RGamess.Add(new RGames() { ID = 102, name = "phor", health = 20.0, maxHealth = 100.0 });
            RGamess.Add(new RGames() { ID = 103, name = "xeno", health = 1.0, maxHealth = 100.0 });

            QSTRestoreHealth qstRestoreHealth1 = new QSTRestoreHealth(questionableRH1);
            QSTRestoreHealth qstRestoreHealth2 = new QSTRestoreHealth(questionableRH1);

            foreach (RGames RGames in RGamess)
            {
                RGames.restoreHealth(20.5, qstRestoreHealth2);
                string info = (RGames.health <= 0 ?
                    RGames.name + " is like X_X with remaining HP " + RGames.health :
                    RGames.name + " is still alive with remaining HP " + RGames.health
                );
                Console.WriteLine(info);

            }
        }

        public static double questionableRH1(double health, double maxHealth)
        {
            return health * (maxHealth - health);
        }

        public static double questionableRH2(double health, double maxHealth)
        {
            return health - (maxHealth * health);
        }



    }
}
