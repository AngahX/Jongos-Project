using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Threading;

namespace Telegram_Flood_Bot
{
    class Program
    {
        static void Main(string[] args)
        {
            string token;
            string chat_id;
            string text;
            string url;
            string srepeat;
            string sdelay;
            int repeat;
            int delay;
            int counter = 0;
            bool ok = false;

            Console.Write("token: ");
            token = Console.ReadLine();

            Console.Write("chat_id: ");
            chat_id = Console.ReadLine();

            Console.Write("text: ");
            text = Console.ReadLine();

            Console.Write("Repeat: ");
            srepeat = Console.ReadLine();
            ok = Int32.TryParse(srepeat, out repeat);

            while (ok != true)
            {
                Console.Write("Repeat: ");
                srepeat = Console.ReadLine();
                ok = Int32.TryParse(srepeat, out repeat);
            }

            ok = false;

            Console.Write("Delay: ");
            sdelay = Console.ReadLine();
            ok = Int32.TryParse(sdelay, out delay);

            while (ok != true)
            {
                Console.Write("Delay: ");
                sdelay = Console.ReadLine();
                ok = Int32.TryParse(sdelay, out delay);
            }

            url = "https://api.telegram.org/bot" + token + "/sendMessage?chat_id=" + chat_id + "&text=" + text;

            while (counter < repeat)
            {
                WebClient myClient = new WebClient();
                Stream response = myClient.OpenRead(url);
                response.Close();
                Thread.Sleep(delay);
                counter++;
            }

            Console.WriteLine("Success!");
            Console.ReadKey();
        }
    }
}
