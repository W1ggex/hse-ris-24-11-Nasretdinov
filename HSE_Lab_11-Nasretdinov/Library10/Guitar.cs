 namespace Library10
 {
     public class Guitar : Instrument, IComparable<Guitar>, IComparer<Guitar>, ICloneable
    {
        private int stringCount;
        private string[] names = {"L-00", "SJ-200", "J-45", "Hummingbird", "J-185"};
        
        public int StringCount
        {
            get => stringCount;
            set
            {
                /*if(value < 4 || value > 6)
                    throw new ArgumentException("String count must be between 4 and 6"); */
                stringCount = value;
            }
        }
         
        //конструкторы
        public Guitar(){}
        
        public Guitar(string name, int stringCount): base(name)
        {
            this.name = name;
            this.stringCount = stringCount;
        }
        
        //методы
        public override string Show()  //string
        {
            return $"The Guitar is called {Name}, it has {StringCount} strings";    
        }

        public string ShowDefault()
        {
            return $"The Guitar is called {Name}, it has {StringCount} strings";
        }
        
        public override void Init()
        {
            base.Init();
            Console.Write("Enter the amount of string between 4 and 6: ");
            StringCount = Convert.ToInt32(Console.ReadLine());
        }
        
        public override void RandomInit()
        {
            Name = "Gibson " + names[new Random().Next(0, names.Length)];
            StringCount = (new Random().Next(-1000, 1000));
        }
        
        public int Compare(Guitar? obj1, Guitar? obj2)
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

        public int CompareTo(Guitar? obj)
        {
            int return_value = 0;
            if (obj is Guitar other)
            {
                if (other.Name.Length > this.Name.Length)
                    return_value = -1;
                if(other.Name.Length < this.Name.Length)
                    return_value = 1;
            }
            return return_value;
        }

        public override bool Equals(object? obj)
        {
            return obj is Guitar other
                   && base.Equals(other)
                   && StringCount == other.StringCount;
        }

        public object Clone()
        {
            return this;
        }
        
        public Guitar ShallowCopy(Guitar? obj)
        {
            return (Guitar)MemberwiseClone();
        }
    }
 }
