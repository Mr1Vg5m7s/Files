using System.Diagnostics.Tracing;
using System.Runtime.InteropServices.Marshalling;
using System.Text.RegularExpressions;
using System.Collections;
using System.Text;
using System.Reflection.PortableExecutable;

namespace At_day__at_night
{
    internal class Program
    {

        public delegate void Number(int[] randomNumber);

        static void Primes(int[] randomNumber)
        {
            using (FileStream fs = new FileStream("file1-prime.bin", FileMode.Create))
            using (BinaryWriter writer = new BinaryWriter(fs, Encoding.UTF8))
                foreach (var item in randomNumber)
                {
                bool isPrime = true;
                for (int i = 2; i < item; i++)
                {
                    if (item % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                    writer.Write(item);
                }
        }
        //22222222222222222222222
        static void Fiba(int[] randomNumber)
        {
            using (FileStream fs = new FileStream("file2-fibik.bin", FileMode.Create))
            using (BinaryWriter writer = new BinaryWriter(fs, Encoding.UTF8))
                foreach (var item in randomNumber)
            {
                if (Fibik(item))
                    writer.Write(item);

            }
        }
        static bool Fibik(int n)
        {
            int a = 0, b = 1;
            while (b < n)
            {
                int temp = a + b;
                a = b;
                b = temp;
            }
            return b == n || n == 0;
        }
        //2 задание

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;



            Random random = new Random();
            List<int> randomNumbers = new List<int>();

            int count = 100;
            int minValue = -10;
            int maxValue = 100;

            for (int i = 0; i < count; i++)
            {
                int randomNumber = random.Next(minValue, maxValue);
                randomNumbers.Add(randomNumber);
            }


            Number fiba = Fiba;
            Number primes = Primes;

            int[] numbersArray = randomNumbers.ToArray();///

            primes(numbersArray);
            fiba(numbersArray);
            

            // --- вывод  ---
            using (FileStream fs = new FileStream("file1-prime.bin", FileMode.Open))
            using (BinaryReader reader = new BinaryReader(fs, Encoding.UTF8))
            {
                Console.WriteLine("Простые числа:");
                while (fs.Position < fs.Length)
                {
                    Console.Write(reader.ReadInt32() + " ");
                }
            }

            // --- вывод второго ---
            using (FileStream fs = new FileStream("file2-fibik.bin", FileMode.Open))
            using (BinaryReader reader = new BinaryReader(fs, Encoding.UTF8))
            {
                Console.ReadLine();
                Console.WriteLine("Числа Фибоначчи:");
                while (fs.Position < fs.Length)
                {
                    Console.Write(reader.ReadInt32() + " ");
                }
            }

            // задание 2 
            Console.ReadLine();
            string[] lines = new string[] { "Incase i dt see u, good afternoon, good evening, and good night!" };

            string wordToFind = "dt";
            string wordToReplace = "don't";

            string text = string.Join(" ", lines);
            text = text.Replace(wordToFind, wordToReplace);


            using (FileStream fs = new FileStream("file2-result.bin", FileMode.Create))
            using (BinaryWriter writer = new BinaryWriter(fs, Encoding.UTF8))
            {
                writer.Write(text);
            }
            using (FileStream fs = new FileStream("file2-result.bin", FileMode.Open))
            using (BinaryReader reader = new BinaryReader(fs, Encoding.UTF8))
            {
                string resultText = reader.ReadString();
                Console.WriteLine("Результат замены:");
                Console.WriteLine(resultText);
            }
            //3 задание
            Console.ReadLine();
            string text2 = "Biney? - You always have trouble saying Brian. - I have a brother... - A real brother, none of this fucking whore";
            string[] WorldForChange = new string[] { "fucking", "whore" };

            foreach (string word in WorldForChange)
            {
                string stars = new string('*', word.Length);
                text2 = text2.Replace(word, stars);
            }

            using (FileStream fs = new FileStream("file3-moderated.bin", FileMode.Create))
            using (BinaryWriter writer = new BinaryWriter(fs, Encoding.UTF8))
            {
                writer.Write(text2);
            }

            using (FileStream fs = new FileStream("file3-moderated.bin", FileMode.Open))
            using (BinaryReader reader = new BinaryReader(fs, Encoding.UTF8))
            {
                string resultText = reader.ReadString();
                Console.WriteLine("Результат модерации:");
                Console.WriteLine(resultText);
            }
            //4
            Console.ReadLine();
            string text3 = "You promised me no more lies. You fucking promised me.";

            char[] reversed = text3.Reverse().ToArray();
            string reversedText = new string(reversed);

            using (FileStream fs = new FileStream("file4-revers.bin", FileMode.Create))
            using (BinaryWriter writer = new BinaryWriter(fs, Encoding.UTF8))
            {
                writer.Write(reversedText);
            }

            using (FileStream fs = new FileStream("file4-revers.bin", FileMode.Open))
            using (BinaryReader reader = new BinaryReader(fs, Encoding.UTF8))
            {
                string resultText = reader.ReadString();
                Console.WriteLine("Перевернутый текст:"); //я надеюсь его так надо было перевернуть
                Console.WriteLine(resultText);
            }
            //5
            Console.ReadLine();
            int count1=0;
            int count2=0;
            int count3=0;
            foreach (var item in randomNumbers)
            {
                if(item >= 0)
                {
                    count1 += 1;
                }
                else
                {
                    count2 += 1;
                }

                if (item >= 10 && item <= 99) count3++;
            }
            Console.WriteLine($"\n\nПоложительных чисел: {count1}\nОтрицательных чисел: {count2}\nДвух значных чисел: {count3}");
            //я знаю что кучу открытий/записей в файлы можно было избежать отдельным методом, но ради маленького проекта не стад
            //(додумался под конец работы)

        }

    }
}