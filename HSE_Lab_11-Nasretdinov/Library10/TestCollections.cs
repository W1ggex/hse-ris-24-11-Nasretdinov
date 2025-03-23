namespace Library10;

public class TestCollections
{
    public Queue<ElectricGuitar> queue1 = new Queue<ElectricGuitar>();
    public Queue<string> queue2 = new Queue<string>();

    public Dictionary<Guitar, ElectricGuitar> dictionary1 = new Dictionary<Guitar, ElectricGuitar>();
    public Dictionary<string, ElectricGuitar> dictionary2 = new Dictionary<string, ElectricGuitar>();

    public static ElectricGuitar firstValue;
    public static ElectricGuitar middleValue;
    public static ElectricGuitar lastValue;
    
    public static Guitar firstKey;
    public static Guitar middleKey;
    public static Guitar lastKey;
    
    private void AddAll(Guitar g, ElectricGuitar eg)
    {
        queue1.Enqueue(eg);
        queue2.Enqueue(eg.ToString());
        dictionary1.Add(eg.GetBase, eg);
        //dictionary2.Add(eg.ToString(), eg);
    }
    
    const int length = 1000;

    public TestCollections()
    {
        for (int i = 0; i < length; i++)
        {
            Guitar g = new Guitar();
            g.RandomInit();
            ElectricGuitar eg = new ElectricGuitar();
            eg.RandomInit();

            if (i == 0)
            {
                firstKey = (Guitar)g.Clone();
                firstValue = (ElectricGuitar)eg.Clone();
                AddAll(g, eg);
                continue;
            }

            if (i == length / 2)
            {
                middleKey = (Guitar)g.Clone();
                middleValue = (ElectricGuitar)eg.Clone();
                AddAll(g, eg);
                continue;
            }

            if (i == length - 1)
            {
                lastKey = (Guitar)g.Clone();
                lastValue = (ElectricGuitar)eg.Clone();
                AddAll(g, eg);
                continue;
            }


            queue1.Enqueue(eg);
            queue2.Enqueue(eg.ToString());
            dictionary1.Add(eg.GetBase, eg);
            //dictionary2.Add(eg.ToString(), eg);

        }
    }
}