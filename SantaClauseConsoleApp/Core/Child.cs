using System;

namespace SantaClauseConsoleApp
{
    public class Child
    {
        private Guid ID { get; }
        public string Name { get; set; }
        private DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        private BehaviorEnum Behaviour { get; set; }
        private Letter ChristmasLetter { get; set; } = null;

        // I prefer to use builder for the letter to avoid the parameters on the constructor
        public Child(string name, DateTime date, string address, BehaviorEnum behaviour)
        {
            ID = Guid.NewGuid();
            Name = name;
            DateOfBirth = date;
            Address = address;
            Behaviour = behaviour;
            //If a child is created, the Santa write his on a list
            SantaClaus.AddChild(this);
        }

        public Child AddLetter(Letter letter)
        {
            if (ChristmasLetter == null)
                ChristmasLetter = letter;
            else
                Console.WriteLine($"{Name} has already a letter. You can change it with 'ChangeLetter'");
            return this;
        }

        public void GenerateLetter()
        {
            Console.WriteLine($"Generating letter... Letter by {this.Name}");

            if (GenerateClass.Generate(this.Name, this.DateOfBirth, this.Address, this.Behaviour, this.ChristmasLetter))
                Console.WriteLine("Complete");
            else
                Console.WriteLine("Already exist");
        }

        public Child ChangeLetter(Letter letter)
        {
            if (ChristmasLetter != null)
            {
                ChristmasLetter = letter;
                Console.WriteLine("Changed letter");
            }
            else
                Console.WriteLine("You haven't written a letter yet");
            return this;
        }

        public override string ToString()
        {
            if(ChristmasLetter != null)
                return $"Child: {Name} ({DateOfBirth}, {Behaviour}) has one written letter: {ChristmasLetter}";
            else
                return $"Child: {Name} ({DateOfBirth}, {Behaviour}) don't have letter yet";
        }

    }
}
