using System;

namespace SantaClauseConsoleApp
{
    public class Item
    {
        private Guid ID { get; }
        public string Name { get; set; }
        private string Description { get; set; } = "";

        public Item(string name)
        {
            ID = Guid.NewGuid();
            this.Name = name;
        }

        public Item AddDescription(string description)
        {
            Description = description;
            return this;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
