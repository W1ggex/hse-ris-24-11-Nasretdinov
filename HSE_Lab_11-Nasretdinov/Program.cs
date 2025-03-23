using System.Collections;
using System.Diagnostics;
using Library10;

namespace HSE_Lab_11_Nasretdinov
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            
            //ЗАДАНИЕ 1
            Console.WriteLine("Task 1\n");
            Queue instruments = new Queue();
            
            //заполнение
            for (int i = 0; i < 5; i++)
            {
                var element = new Instrument();
                element.RandomInit();
                instruments.Enqueue(element);
            }
            
            //добавление элемента, который необходимо найти
            Fortepiano fortepianoToFind = new Fortepiano();
            fortepianoToFind.Name = "ABC";
            fortepianoToFind.KeyLayout = "Octavian";
            fortepianoToFind.KeyNumber = 108;
            instruments.Enqueue(fortepianoToFind);
            
            for (int i = 0; i < 5; i++)
            {
                var element = new Fortepiano();
                element.RandomInit();
                instruments.Enqueue(element);
            }
            
            //удаление
            instruments.Dequeue();
            
            //запросы
            //количество губных гармошек в очереди
            int harpCount = 0;
            foreach (Instrument instrument in instruments)
            {
                if (instrument.Name == "Harmonica")
                {
                    harpCount++;
                    Console.WriteLine($"Instrumnet name: {instrument.Name}:");
                }
            }
            Console.WriteLine($"\nThere are {harpCount} harmonicas in the queue");
            
            //фортепиано с наибольшим количеством клавиш в октавной раскладке (ЛР 10)
            int maxOctavianKeyNumber = 0;
            foreach (Instrument instrument in instruments)
            {
                Fortepiano f = instrument as Fortepiano;
                if(instrument as Fortepiano != null)
                    if (f.KeyLayout == "Octavian" && f.KeyNumber > maxOctavianKeyNumber)
                    maxOctavianKeyNumber = f.KeyNumber;
            }
            Console.WriteLine($"\nOctavian fortepiano has a maximum of {maxOctavianKeyNumber} keys");
            
            //сумма клавиш фортепиано с цифровой раскладкой
            int octavianKeyCount = 0;
            foreach (Instrument instrument in instruments)
            {
                Fortepiano f = instrument as Fortepiano;
                if(instrument as Fortepiano != null)
                    if (f.KeyLayout == "Digital")
                        octavianKeyCount += f.KeyNumber;
            }
            Console.WriteLine($"\nDigital fortepianos have {octavianKeyCount} keys combined");
            
            
            //перебор с помощью foreach
            Console.WriteLine("\nQueue consists of the following instruments:");
            foreach (Instrument instrument in instruments)
            {
                Console.WriteLine(instrument.Show());
            }
            
            //клонирование
            Queue clonedQueue = new Queue();
            foreach (Instrument instrument in instruments)
            {
                clonedQueue.Enqueue(instrument);
            }
            
            //поиск (нет смысла сортировать очередь)
            bool searchSuccessful = false;
            foreach (Instrument instrument in instruments)
            {
                if(instrument is Fortepiano)
                    if (instrument == fortepianoToFind)
                    {
                        Console.WriteLine($"\nFollowing fortepiano was found: {fortepianoToFind.Show()}");
                        searchSuccessful = true;
                    }
            }
            if(!searchSuccessful)
                Console.WriteLine("Search failed");
            
            
            //ЗАДАНИЕ 2
            Console.WriteLine("\nTask 2\n");
            //добавление элементов
            Stack<Instrument> instrumentStack = new Stack<Instrument>();
            for (int i = 0; i < 5; i++)
            {
                var element = new Instrument();
                element.RandomInit();
                instrumentStack.Push(element);
            }

            //добавление элемента, который необходимо найти
            Instrument saxToFind = new Instrument();
            saxToFind.Name = "Sax";
            instrumentStack.Push(saxToFind);
            
            for (int i = 0; i < 5; i++)
            {
                var element = new Fortepiano();
                element.RandomInit();
                instrumentStack.Push(element);
            }
            
            //удаление элемента
            instrumentStack.Pop();
            
            int saxCount = 0;
            foreach (Instrument instrument in instrumentStack)
            {
                if (instrument.Name == "Sax")
                {
                    harpCount++;
                    Console.WriteLine($"Instrument name: {instrument.Name}");
                }
            }
            Console.WriteLine($"\nThere are {saxCount} saxophones in the stack");
            
            //фортепиано с наибольшим количеством клавиш в шкальной раскладке (ЛР 10)
            int maxScalicKeyNumber = 0;
            foreach (Instrument instrument in instrumentStack)
            {
                Fortepiano f = instrument as Fortepiano;
                if(instrument as Fortepiano != null)
                    if (f.KeyLayout == "Scalic" && f.KeyNumber > maxScalicKeyNumber)
                        maxScalicKeyNumber = f.KeyNumber;
            }
            Console.WriteLine($"\nScalic fortepiano has a maximum of {maxOctavianKeyNumber} keys");
            
            //сумма клавиш фортепиано с шкальной раскладкой
            int scalicKeyCount = 0;
            foreach (Instrument instrument in instrumentStack)
            {
                Fortepiano f = instrument as Fortepiano;
                if(instrument as Fortepiano != null)
                    if (f.KeyLayout == "Scalic")
                        scalicKeyCount += f.KeyNumber;
            }
            Console.WriteLine($"\nScalic fortepianos have {scalicKeyCount} keys combined");
            
            //перебор с помощью foreach
            Console.WriteLine("\nStack consists of the following instruments:");
            foreach (Instrument instrument in instrumentStack)
            {
                Console.WriteLine(instrument.Show());
            }
            
            //клонирование
            Stack<Instrument> clonedStack = new Stack<Instrument>();
            foreach (Instrument instrument in instrumentStack)
            {
                clonedStack.Push(instrument);
            }
            
            //поиск (нет смысла сортировать стек)
            bool searchSuccessfulForStack = false;
            foreach (Instrument instrument in instrumentStack)
            {
                    if (instrument == saxToFind)
                        searchSuccessfulForStack = true;
            }
            if(!searchSuccessfulForStack)
                Console.WriteLine("Search failed"); 
            
            
            //ЗАДАНИЕ 3 (выбраны классы Guitar и ElectricGuitar)
            //
            TestCollections collections = new TestCollections();

            Stopwatch sw = Stopwatch.StartNew();
            sw.Restart();
            TestCollections C = new TestCollections();
            sw.Stop();
            Console.WriteLine($"Создание коллекции: {sw.ElapsedTicks}");

            Console.WriteLine("\nQueue<ElectricGuitar>");
            bool isFound = false;
            long sum = 0;
            Guitar notPresentedElement = new Guitar();
            notPresentedElement.RandomInit(); // Создаем элемент, которого нет в коллекции
            ElectricGuitar notPresentedEGuitar = new ElectricGuitar();
            notPresentedEGuitar.RandomInit(); // Создаем кнопку, которой нет в коллекции

            // Проверка для первого элемента в Queue<Guitar>
            for (int i = 0; i < 10; i++)
            {
                sw.Restart();
                isFound = C.queue1.Contains(TestCollections.firstValue);
                sw.Stop();
                sum += sw.ElapsedTicks;
            }
            Console.WriteLine($"The first element {isFound}: {sum/10}");

            // Проверка для среднего элемента в Queue<Guitar>
            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sw.Restart();
                isFound = C.queue1.Contains(TestCollections.middleValue);
                sw.Stop();
                sum += sw.ElapsedTicks;
            }
            Console.WriteLine($"The middle element {isFound}: {sum / 10}");

            // Проверка для последнего элемента в Queue<Guitar>
            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sw.Restart();
                isFound = C.queue1.Contains(TestCollections.lastValue);
                sw.Stop();
                sum += sw.ElapsedTicks;
            }
            Console.WriteLine($"The last element {isFound}: {sum / 10}");

            // Проверка для несуществующего элемента в Queue<Guitar>
            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sw.Restart();
                isFound = C.queue1.Contains(notPresentedEGuitar);
                sw.Stop();
                sum += sw.ElapsedTicks;
            }
            Console.WriteLine($"Found element {isFound}: {sum / 10}");

            Console.WriteLine("\nQueue<string>");
            // Проверка для первого элемента в Queue<string>
            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sw.Restart();
                isFound = C.queue2.Contains(TestCollections.firstValue.ToString());
                sw.Stop();
                sum += sw.ElapsedTicks;
            }
            Console.WriteLine($"The first found element {isFound}: {sum / 10}");

            // Проверка для среднего элемента в Queue<string>
            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sw.Restart();
                isFound = C.queue2.Contains(TestCollections.middleValue.ToString());
                sw.Stop();
                sum += sw.ElapsedTicks;
            }
            Console.WriteLine($"The middle found element  {isFound}: {sum / 10}");

            // Проверка для последнего элемента в Queue<string>
            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sw.Restart();
                isFound = C.queue2.Contains(TestCollections.lastValue.ToString());
                sw.Stop();
                sum += sw.ElapsedTicks;
            }
            Console.WriteLine($"The last found element {isFound}: {sum / 10}");

            // Проверка для несуществующего элемента в Queue<string>
            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sw.Restart();
                isFound = C.queue2.Contains(notPresentedEGuitar.ToString());
                sw.Stop();
                sum += sw.ElapsedTicks;
            }
            Console.WriteLine($"Found element {isFound}: {sum / 10}");

            Console.WriteLine("\nDictionary<Guitar, ElectricGuitar> ContainsKey");

            // Проверка для первого ключа в Dictionary<Guitar, ElectricGuitar>
            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sw.Restart();
                isFound = C.dictionary1.ContainsKey(TestCollections.firstKey);
                sw.Stop();
                sum += sw.ElapsedTicks;
            }
            Console.WriteLine($"The first found element {isFound}: {sum / 10}");

            // Проверка для среднего ключа в Dictionary<Guitar, ElectricGuitar>
            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sw.Restart();
                isFound = C.dictionary1.ContainsKey(TestCollections.middleKey);
                sw.Stop();
                sum += sw.ElapsedTicks;
            }
            Console.WriteLine($"The middle found element {isFound}: {sum / 10}");

            // Проверка для последнего ключа в Dictionary<Guitar, ElectricGuitar>
            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sw.Restart();
                isFound = C.dictionary1.ContainsKey(TestCollections.lastKey);
                sw.Stop();
                sum += sw.ElapsedTicks;
            }
            Console.WriteLine($"The last found element {isFound}: {sum / 10}");

            // Проверка для несуществующего ключа в Dictionary<Guitar, ElectricGuitar>
            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sw.Restart();
                isFound = C.dictionary1.ContainsKey(notPresentedElement);
                sw.Stop();
                sum += sw.ElapsedTicks;
            }
            Console.WriteLine($"Found element {isFound}: {sum / 10}"); 

            Console.WriteLine("\nDictionary<Guitar, ElectricGuitar> ContainsValue");
            // Проверка для первого значения в Dictionary<Guitar, ElectricGuitar>
            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sw.Restart();
                isFound = C.dictionary1.ContainsValue(TestCollections.firstValue);
                sw.Stop();
                sum += sw.ElapsedTicks;
            }
            Console.WriteLine($"The first Found element {isFound}: {sum / 10}");

            // Проверка для среднего значения в Dictionary<Guitar, ElectricGuitar>
            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sw.Restart();
                isFound = C.dictionary1.ContainsValue(TestCollections.middleValue);
                sw.Stop();
                sum += sw.ElapsedTicks;
            }
            Console.WriteLine($"The middle Found element {isFound}: {sum / 10}");

            // Проверка для последнего значения в Dictionary<Guitar, ElectricGuitar>
            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sw.Restart();
                isFound = C.dictionary1.ContainsValue(TestCollections.lastValue);
                sw.Stop();
                sum += sw.ElapsedTicks;
            }
            Console.WriteLine($"The last found element  {isFound}: {sum / 10}");

            // Проверка для несуществующего значения в Dictionary<Guitar, ElectricGuitar>
            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sw.Restart();
                isFound = C.dictionary1.ContainsValue(notPresentedEGuitar);
                sw.Stop();
                sum += sw.ElapsedTicks;
            }
            Console.WriteLine($"Found element {isFound}: {sum / 10}");

            Console.WriteLine("\nDictionary<string, ElectricGuitar> ContainsKey");
            // Проверка для первого строкового ключа в Dictionary<string, ElectricGuitar>
            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sw.Restart();
                isFound = C.dictionary2.ContainsKey(TestCollections.firstKey.ToString());
                sw.Stop();
                sum += sw.ElapsedTicks;
            }
            Console.WriteLine($"The first Found element  {isFound}: {sum / 10}");

            // Проверка для среднего строкового ключа в Dictionary<string, ElectricGuitar>
            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sw.Restart();
                isFound = C.dictionary2.ContainsKey(TestCollections.middleKey.ToString());
                sw.Stop();
                sum += sw.ElapsedTicks;
            }
            Console.WriteLine($"The middle Found element {isFound}: {sum / 10}");

            // Проверка для последнего строкового ключа в Dictionary<string, ElectricGuitar>
            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sw.Restart();
                isFound = C.dictionary2.ContainsKey(TestCollections.lastKey.ToString());
                sw.Stop();
                sum += sw.ElapsedTicks;
            }
            Console.WriteLine($"The last found element {isFound}: {sum / 10}");

            // Проверка для несуществующего строкового ключа в Dictionary<string, ElectricGuitar>
            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sw.Restart();
                isFound = C.dictionary2.ContainsKey(notPresentedElement.ToString());
                sw.Stop();
                sum += sw.ElapsedTicks;
            }
            Console.WriteLine($"Found element {isFound}: {sum / 10}");

            Console.WriteLine("\nDictionary<string, ElectricGuitar> ContainsValue");
            // Проверка для первого значения в Dictionary<string, ElectricGuitar>
            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sw.Restart();
                isFound = C.dictionary2.ContainsValue(TestCollections.firstValue);
                sw.Stop();
                sum += sw.ElapsedTicks;
            }
            Console.WriteLine($"The first Found element {isFound}: {sum / 10}");

            // Проверка для среднего значения в Dictionary<string, ElectricGuitar>
            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sw.Restart();
                isFound = C.dictionary2.ContainsValue(TestCollections.middleValue);
                sw.Stop();
                sum += sw.ElapsedTicks;
            }
            Console.WriteLine($"The middle Found element {isFound}: {sum / 10}");

            // Проверка для последнего значения в Dictionary<string, ElectricGuitar>
            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sw.Restart();
                isFound = C.dictionary2.ContainsValue(TestCollections.lastValue);
                sw.Stop();
                sum += sw.ElapsedTicks;
            }
            Console.WriteLine($"The last found element {isFound}: {sum / 10}");

            // Проверка для несуществующего значения в Dictionary<string, ElectricGuitar>
            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sw.Restart();
                isFound = C.dictionary2.ContainsValue(notPresentedEGuitar);
                sw.Stop();
                sum += sw.ElapsedTicks;
            }
            Console.WriteLine($"Found element {isFound}: {sum / 10}");
        }
        }
    }
