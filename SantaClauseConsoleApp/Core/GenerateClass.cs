using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaClauseConsoleApp
{
    public static class GenerateClass
    {
        public static bool Generate(string name, DateTime date, string address, BehaviorEnum behav, Letter list)
        {
            int age = DateTime.Now.AddYears(date.Year).Year;

            age = age / 365;

            string template = File.ReadAllText(@"D:/WinterInternship2022-Backend-main/SantaClauseConsoleApp/SantaClauseConsoleApp/letter-template.txt");

            template = template.Replace("[FULL_NAME]", name);
            template = template.Replace("[AGE]" , age.ToString());
            template = template.Replace("[ADDRESS]", address);
            template = template.Replace("[BEHAVIOR]", behav.ToString());
            if (list.ItemList.Count() - 1 >= 0)
            template = template.Replace("[PRESENT1]", list.ItemList[0].Name);
            else
                template = template.Replace("[PRESENT1]", "");
            if (list.ItemList.Count() - 1 >= 1)
                template = template.Replace("[PRESENT2]", list.ItemList[1].Name);
            else
                template = template.Replace("[PRESENT2]", "");
            if (list.ItemList.Count()-1>1) 
            {
                for (int i = 2; i < list.ItemList.Count(); i++)
                    template += $",{list.ItemList[i].Name}";
            }


            string path = @"D:/WinterInternship2022-Backend-main/SantaClauseConsoleApp/SantaClauseConsoleApp/Letters/Letter" + name + ".txt";

            if (!File.Exists(path))
            {
                File.Create(path).Dispose();

                using (TextWriter tw = new StreamWriter(path))
                {
                    tw.WriteLine(template);
                }
                return true;
            }
            return false;
        }
    }
}
