using System.Linq;

namespace Library10
{
    public class ElectricGuitar : Guitar, IComparable<Guitar>, IComparer<Guitar>, ICloneable
    {
        private string powerSupply;
        private string[] powerSupplies = { "Batteries", "Accumulator", "Fixed power source", "USB" };
        private string[] names = {"Les Paul", "Slash", "Adam Jones", "ES-335", "SG", "Flying V"};
        //private int stringCount;
        
            
        public string PowerSupply
                {
                    get => powerSupply;
                    set
                    {
                        if(!powerSupplies.Contains(value))
                            throw new ArgumentException("Power supply must be one of the following:\nBatteries\nAccumulator\nFixed power source\nUSB");
                        powerSupply = value;
                    }
                }
        
        //конструкторы
        public ElectricGuitar(){}
        
        public ElectricGuitar(string name, string powerSupply, int stringCount) : base(name, stringCount)
        {
            this.powerSupply = powerSupply;
        }
        
        //методы
        public override string Show()
        {
            return $"The E-Giutar is called {Name}, it is powered by a(n) {PowerSupply} and has {StringCount} strings";    
        }
        
        public string ShowDefault()
        {
            return $"The E-Giutar is called {Name}, it is powered by a(n) {PowerSupply} and has {StringCount} strings";    
        }
        
        public override void Init()
        {
            base.Init();
            Console.Write("Enter the E-Guitar power supply: ");
            PowerSupply = Console.ReadLine();
        }
        
        public override void RandomInit()
        {
            Name = "Gibson " + names[new Random().Next(0, names.Length)];
            PowerSupply = powerSupplies[new Random().Next(0, powerSupplies.Length)];
            StringCount = new Random().Next(-1000, 1000);
            
        }
        
        
        int CompareTo(object obj)
        {
            int return_value = 0;
            if (obj is ElectricGuitar other)
            {
                if (other.Name.Length > this.Name.Length)
                    return_value = -1;
                if(other.Name.Length < this.Name.Length)
                    return_value = 1;
            }
            return return_value;
        }
        
        public int Compare(ElectricGuitar? obj1, ElectricGuitar? obj2)
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

        public object Clone()
        {
            ElectricGuitar e = (ElectricGuitar)MemberwiseClone();
            return e;
        }
        
        public ElectricGuitar ShallowCopy(ElectricGuitar? obj)
        {
            return (ElectricGuitar)MemberwiseClone();
        }

        public Guitar GetBase => new Guitar(Name, StringCount);
    }
}
