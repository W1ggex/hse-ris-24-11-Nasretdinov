namespace Library10
{

        internal class Fortepiano : Instrument, IComparable<Fortepiano>, IComparer<Fortepiano>, ICloneable
    {
        private string[] names = {"A", "B", "D", "M", "O", "S"};
        private string keyLayout;
        private string[] keyLayouts = {"Octavian", "Scalic", "Digital"};
        private int keyNumber;

        public string KeyLayout
        {
            get => keyLayout;
            set
            {
                if(!keyLayouts.Contains(value))
                    throw new ArgumentException("Key Layout must be one of the following:\nOctavian\nScalic\nDigital");
                keyLayout = value;
            }
        }
        
        public int KeyNumber
        {
            get => keyNumber;
            set
            {
                if(value > 108 || value < 76)
                    throw new ArgumentException("Key Number must be between 76 and 108");
                keyNumber = value;
            }
        }
        
        //конструкторы
        public Fortepiano(){}
        
        public Fortepiano(string name, string keyLayout, int keyNumber) : base(name)
        {
            this.keyLayout = keyLayout;
            this.keyNumber = keyNumber;
        }
        
        //методы
        public override string Show()
        {
            return $"The Fortepiano is called {Name}, it has {KeyNumber} keys in the {keyLayout} layout.";    
        }
        
        public string ShowDefault()
        {
            return $"The Fortepiano is called {Name}, it has {KeyNumber} keys in the {keyLayout} layout.";    
        }
        
        public override void Init()
        {
            base.Init();
            Console.Write("Enter the Fortepiano's key layout: ");
            KeyLayout = Console.ReadLine();
            Console.Write("Enter the Fortepiano's key number: ");
            KeyNumber = Convert.ToInt32(Console.ReadLine());
        }

        public override void RandomInit()
        {
            Name = "Steinway & Sons' Model " + names[new Random().Next(0, names.Length)];
            KeyLayout = keyLayouts[new Random().Next(0, keyLayouts.Length)];
            KeyNumber = new Random().Next(76, 109);
        }

        public int CompareTo(Fortepiano? obj)
        {
            int return_value = 0;
            if (obj is Fortepiano other)
            {
                if (other.Name.Length > this.Name.Length)
                    return_value = -1;
                if(other.Name.Length < this.Name.Length)
                    return_value = 1;
            }
            return return_value;
        }

        public int Compare(Fortepiano? obj1, Fortepiano? obj2)
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

        public override bool Equals(object? obj)
        {
            return obj is Fortepiano other && base.Equals(other) && KeyNumber == other.KeyNumber && KeyLayout == other.KeyLayout;
        }

        public object Clone()
        {
            return this;
        }
        
        public Fortepiano ShallowCopy(Fortepiano? obj)
        {
            return (Fortepiano)MemberwiseClone();
        }
    }
}