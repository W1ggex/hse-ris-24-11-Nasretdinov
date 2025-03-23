namespace Library10
{
    
    public class Instrument : IInit, IComparer, IComparable<Instrument>, ICloneable
    {
        protected string[] names =
            { "Harmonica", "Sax", "Violin"};
        //поля
        protected string name;

        public string Name
        {
            get => name;
            set => name = value;
         }       
        
        //конструкторы
        public Instrument()
        {
           
        }
        
        public Instrument(string name)
        {
            this.Name = name;
        }
        
        //методы
        public virtual string Show()
        {
            return $"The instrument is called {Name}";
        }
        
        
        public virtual void Init()
        {
            Console.Write("Enter the name of the instrument: ");
            Name = Console.ReadLine() ?? throw new InvalidOperationException();
        }
        
        public virtual void RandomInit()
        {
            var rnd = new Random();
            Name = names[rnd.Next(names.Length)];
        }

        public int CompareTo(Instrument? obj)
        {
            int return_value = 0;
            if (obj is Instrument other)
            {
                if (other.Name.Length > this.Name.Length)
                    return_value = -1;
                if(other.Name.Length < this.Name.Length)
                    return_value = 1;
            }
            return return_value;
        }

        public override bool Equals(object obj)
        {
            if (obj is Instrument other)
                return Name == other.Name;
            return false;
        }

        public object Clone()
        {
            return this;
        }


        public int Compare(object obj1, object obj2)
        {
            int return_value = 0;
            if (obj1 is Instrument o1 && obj2 is Instrument o2)
            {
                if (o2.Name.Length >o1.Name.Length)
                    return_value = -1;
                if(o2.Name.Length < o1.Name.Length)
                    return_value = 1;
            }
            return return_value;  
        }
        
        public Instrument ShallowCopy(Instrument? obj)
        {
            return (Instrument)MemberwiseClone();
        }
        
    }
    
}