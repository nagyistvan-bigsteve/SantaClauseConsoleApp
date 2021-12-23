using System;
using System.Collections.Generic;

namespace SantaClauseConsoleApp
{
    public class Letter
    {
        public List<Item> ItemList;
        private DateTime WrittenDate { get; set; }

        public Letter(DateTime date)
        {
            WrittenDate = date;
            ItemList = new List<Item>();
        }

        public Letter AddItem(Item item)
        {
            if(!ItemList.Contains(item))
            ItemList.Add(item);
            return this;
        }

        public override string ToString()
        {
            string result = $"date : {WrittenDate} \n";
            foreach (Item item in ItemList)
                result += item.ToString() + ",";
            result = result.Substring(0, result.Length - 1);
            return result;
        }
    }
}
