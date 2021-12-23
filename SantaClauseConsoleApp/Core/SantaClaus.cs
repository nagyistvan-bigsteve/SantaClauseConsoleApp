using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SantaClauseConsoleApp
{
    public class SantaClaus
    {
        protected static SantaClaus _santa = null;
        private Dictionary<string,int> ReportList = new Dictionary<string,int>();
        private static List<Child> ChildList = new List<Child>();
        private List<string> AddressList = new List<string>();
        private SantaClaus()
        {
            Name = "Santa Claus";
        }

        public static void AddChild(Child child)
        {
            if(!ChildList.Contains(child))
                ChildList.Add(child);
        }

        public static SantaClaus Instance()
        {
            if (_santa == null)
                _santa = new SantaClaus();
            return _santa;
        }

        public string Name { get; set; }

        public Dictionary<string, int> Report()
        {
            var directory = new DirectoryInfo("D:/WinterInternship2022-Backend-main/SantaClauseConsoleApp/SantaClauseConsoleApp/Letters");
            string allcontent = "";
            foreach (var f in directory.GetFiles())
            {
                string contents = "";

                FileStream fs = f.Open(FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read);

                StreamReader sr = new StreamReader(fs);

                while (sr.EndOfStream == false)
                {
                    contents = sr.ReadLine();
                }
                allcontent += contents+","; 

                sr.Close();
                fs.Close();             
            }
            allcontent = allcontent.Substring(0, allcontent.Length - 1);

            string[] list = allcontent.Split(',');

            foreach (string i in list)
            {
                if (!ReportList.ContainsKey(i))
                    ReportList.Add(i, 1);
                else
                {
                    ReportList[i] += 1;
                }

            }
            ReportList = ReportList.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            return ReportList;
        }

        public List<string> Addresses()
        {

            foreach (Child child in ChildList)
            {

                AddressList.Add(child.Address);
               
            }
            AddressList.Sort();

            return AddressList;
        }   
    }
}