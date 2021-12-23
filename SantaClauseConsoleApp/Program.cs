using System;
using System.Collections.Generic;
using System.IO;

namespace SantaClauseConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Question1();
            Question2();
            Question3();
            Question4();
            Question5();
            Question6();
        }
   
        static void Question1()
        {
            //Creating the object

             var child1 = new Child("Peter", new DateTime(2007, 03, 10), "Oradea", BehaviorEnum.Good)
                .AddLetter(new Letter(new DateTime(2021, 12, 20))
                .AddItem(new Item("Car"))
                .AddItem(new Item("Pencil")));
            var child2 = new Child("Petra", new DateTime(2012, 07, 20), "Cluj", BehaviorEnum.Good)
                .AddLetter(new Letter(new DateTime(2021, 12, 17))
                .AddItem(new Item("Barbie"))
                .AddItem(new Item("Toy")));
            var child3 = new Child("Parker", new DateTime(2009, 12, 1), "Nusfalau", BehaviorEnum.Bad)
                .AddLetter(new Letter(new DateTime(2021, 12, 21))
                .AddItem(new Item("Ball"))
                .AddItem(new Item("Bear")));

            //I can't add an another letter for a child wo already has one, but I can change it

            child1.AddLetter(new Letter(new DateTime(2021, 12, 21)).AddItem(new Item("Ball")).AddItem(new Item("Pencilcase")));
            child1.ChangeLetter(new Letter(new DateTime(2021, 12, 21)).AddItem(new Item("Ball")).AddItem(new Item("Pencilcase")));

            Console.WriteLine(child1);
            Console.WriteLine(child2);
            Console.WriteLine(child3);

            //Generating .txt files (letters) for childs

            child1.GenerateLetter();
            child2.GenerateLetter();
            child3.GenerateLetter();
        }

        static void Question2()
        {
            //I leave here the tryouts


            //var directory = new DirectoryInfo("D:/WinterInternship2022-Backend-main/SantaClauseConsoleApp/SantaClauseConsoleApp/Letters");
            //string template = File.ReadAllText(@"D:/WinterInternship2022-Backend-main/SantaClauseConsoleApp/SantaClauseConsoleApp/letter-template.txt");
            ////            FileStream templateFile = File.Open(@"D:/WinterInternship2022-Backend-main/SantaClauseConsoleApp/SantaClauseConsoleApp/letter-template.txt",FileMode.Open);

            //string result = "";

            //var foundIndexes1 = new List<int>();
            //var foundIndexes2 = new List<int>();


            //for (int i = template.IndexOf(']'); i > -1; i = template.IndexOf(']', i + 1))
            //{

            //    foundIndexes2.Add(i);

            //}

            //for (int i = 0; i < foundIndexes2.Count; i++)
            //    template = template.Insert(i*3+foundIndexes2[i], "{" + i + "}");

            //for (int i = template.IndexOf('['); i > -1; i = template.IndexOf('[', i + 1))
            //{
            //    foundIndexes1.Add(i);
            //}


            //for (int i = 0; i < foundIndexes1.Count; i++)
            //{

            //    result += template.Substring(foundIndexes1[i], i*3+foundIndexes2[i] - foundIndexes1[i] + 1);
            //}
            //template.Format(result, "alma", "alma", "alma", "alma", "alma");

            //foreach (var f in directory.GetFiles())
            //{
            //    string contents = File.ReadAllText(f.ToString());

            //    Console.WriteLine(contents);
            //    Console.WriteLine(template);
            //}
            //Console.WriteLine(result);
        }
        //Failed to solve

        static void Question3()
        {
            var child4 = new Child("Robert", new DateTime(2010, 07, 11), "Oradea", BehaviorEnum.Bad)
                .AddLetter(new Letter(new DateTime(2021, 12, 20))
                .AddItem(new Item("Car"))
                .AddItem(new Item("Chocklet"))
                .AddItem(new Item("Ball")));

            child4.GenerateLetter();

        }

        static void Question4()
        {
            SantaClaus santa = SantaClaus.Instance();


            Dictionary<string,int> ReportList = santa.Report();

            foreach (KeyValuePair<string, int> rep in ReportList)
            {
                Console.WriteLine("Toy = {0}, Quantity = {1}", rep.Key, rep.Value);
            }
        }

        static void Question5()
        {
            //We don't have two santa, and if accidentally someaone create an another santa, it can make problems.
            //So we can use Singleton on SantaClaus class.
        }

        static void Question6()
        {
            List<string> addresses = SantaClaus.Instance().Addresses();

            foreach (string address in addresses)
                Console.WriteLine(address);
        }
    }
}
