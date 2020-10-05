using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordContactImporter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Luna's Discord Backup Contact Exporter");
            Console.WriteLine();
            Console.Write("Please drag and drop your \"user.json\" from the backup onto this window, and press enter: ");
            string path = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Luna's Discord Backup Contact Exporter");
            Console.WriteLine();

            dynamic json = JObject.Parse(File.ReadAllText(path));

            foreach (var relation in json.relationships)
            {
                if ((int)relation.type == 1)
                {
                    Console.WriteLine("Found friend: " + (string)relation.user.username + "#" + (string)relation.user.discriminator);
                    File.AppendAllText("discord-contacts.txt", (string)relation.user.username + "#" + (string)relation.user.discriminator + "\r\n");
                }
            }
            Console.WriteLine("Done! Any found contacts have been exported to discord-contacts.txt");
        }
    }
}
