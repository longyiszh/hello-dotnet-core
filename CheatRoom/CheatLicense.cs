using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CheatRoom
{
    public class CheatLicense
    {
        // async await example
        public bool Download()
        {
            // A function that takes very long time to finish
            Console.WriteLine("⏬ Downloading Ultimate Cheat license...");
            Thread.Sleep(5000);
            Console.WriteLine("✅ Ultimate cheat license download complete!");
            return true;
        }

        public Task<bool> DownloadAsync()
        {
            var downloadLicense = new Task<bool>(Download);
            downloadLicense.Start();
            return downloadLicense;
        }

    }
}
