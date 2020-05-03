using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CheatRoom
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("============ Start playing games (Delegation example) ================");
            PlayRGames();
            Console.WriteLine("============ Start cheat license (async/await example)================");
            await GetLicense();

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

        static async Task<bool> GetLicense()
        {
            var cLicense = new CheatLicense();

            Console.WriteLine($"We are fetching your RGame license FTL," +
                $"but also reminding you buying our premium license " +
                $"for CGame! Free trial for 10 days!");

            Console.WriteLine($"You will never regret that we -> promise <- !");

            bool result = await cLicense.DownloadAsync();

            // Because we use await, the message below only shows after "download"
            Console.WriteLine($"Cool! You know what? " +
                $"You will get gaming experience even smoother than that download!");

            return result;

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
