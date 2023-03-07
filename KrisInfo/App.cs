using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisInfo
{
    public class App
    {
        public void Run()
        {
            while (true)
            {
                
                Console.Clear();
                Console.WriteLine("Krisinformation");
                Console.WriteLine("***************\n");
                Console.WriteLine("1: Hämta 'samtliga' varningar");
                Console.WriteLine("2: Hämta 'en' varningar");
                Console.WriteLine("0: Exit");

                // TIPS: Här borde man köra någon form att kontroll att rätt värde skrivs in
                var choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        KrisInfo.GetJsonDataAll().Wait();
                        break;
                    case 2:
                        // TIPS: Låt användaren bestämma vilken id ska sökas
                        KrisInfo.GetJsonDataOne(18478).Wait();
                        
                        // Denna id finns inte... testa även med denna!
                        // Vad händer?
                        // KrisInfo.GetJsonDataOne(1).Wait();
                        break;
                    case 0:
                        return;
                    default:
                        break;
                }
            }
        }
    }
}
