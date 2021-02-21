using System;
using System.Collections.Generic;


namespace laba1
{
    internal static class Interface
    {
        private enum SaveChoice
        {
            Yes = 1,
            No
        }

        private enum MenuChoice
        {
            KeyboardInput = 1,
            FileInput,
            RandomInput,
            Help,
            ModuleTests,
            Exit
        }

        public static void Greatings()
        {
            Console.WriteLine("привет");
        }

        public static void Menu()
        {
            Console.WriteLine();
            Console.WriteLine("Выберите вариант:");
            Console.WriteLine("1. Ввести массив вручную");
            Console.WriteLine("2. Ввести массив из файла");
            Console.WriteLine("3. Ввести массив случайно");
            Console.WriteLine("4. Показать помощь");
            Console.WriteLine("5. Запустить модульные тесты");
            Console.WriteLine("6. Выход");
            var variant = InputInt();
            ArrayWithAverage arrayWithAverage;
            switch (variant)
            {
                case (int) MenuChoice.KeyboardInput:
                    arrayWithAverage = Algorithm.GetAverage(KeyboardInput());
                    PrintAnswer(arrayWithAverage);
                    SaveInitialData(arrayWithAverage);
                    break;
                case (int) MenuChoice.FileInput:
                    arrayWithAverage = Algorithm.GetAverage(FileInput());
                    PrintAnswer(arrayWithAverage);
                    SaveInitialData(arrayWithAverage);
                    break;
                case (int) MenuChoice.RandomInput:
                    arrayWithAverage = Algorithm.GetAverage(RandomInput());
                    PrintAnswer(arrayWithAverage);
                    SaveInitialData(arrayWithAverage);
                    break;
                case (int) MenuChoice.Help:
                    Greatings();
                    break;
                case (int) MenuChoice.ModuleTests:
                    break;
                case (int) MenuChoice.Exit:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Вы ввели неправильное значение, введите число от 1 до 6");
                    break;
            }
        }

        private static void PrintAnswer(ArrayWithAverage data)
        {
            Console.WriteLine();
            var answer = MakeAnswer(data);
            Console.WriteLine(answer);
            Console.WriteLine();
            Console.WriteLine("Записать ответ в файл?");
            Console.WriteLine("1 - Да | 2 - Нет");
            var variant = InputInt();
            var isChoiceCorrect = false;
            while (!isChoiceCorrect)
                if (variant >= (int) SaveChoice.Yes && variant <= (int) SaveChoice.No)
                {
                    isChoiceCorrect = true;
                }
                else
                {
                    Console.WriteLine("Ввод некорректен, попробуйте снова:");
                    variant = InputInt();
                }

            if (variant == (int) SaveChoice.Yes) FileSystem.OpenFileForWrite(answer);
        }


        private static void SaveInitialData(ArrayWithAverage data)
        {
            Console.WriteLine("Записать начальные данные в файл?");
            Console.WriteLine("1 - Да | 2 - Нет");
            var variant = InputInt();
            var isChoiceCorrect = false;
            while (!isChoiceCorrect)
                if (variant >= (int) SaveChoice.Yes && variant <= (int) SaveChoice.No)
                {
                    isChoiceCorrect = true;
                }
                else
                {
                    Console.WriteLine("Ввод некорректен, попробуйте снова:");
                    variant = InputInt();
                }

            if (variant == (int) SaveChoice.Yes)
            {
                var initialData = string.Join(" ", data.Array);
                FileSystem.OpenFileForWrite(initialData);
            }
        }


        private static string MakeAnswer(ArrayWithAverage data)
        {
            Console.WriteLine();
            var answer = "Размер массива: " + data.Array.Count + "\n";
            answer += "Введенный массив: " + "\n";
            answer += string.Join(" ", data.Array);
            answer += "\n";
            answer += "Среднее значение по модулю: " + data.Average;
            return answer;
        }

        private static List<int> KeyboardInput()
        {
            Console.WriteLine();
            int size;
            Console.WriteLine("Введите размер массива:");
            size = InputSize();
            var numbers = new List<int>();
            Console.WriteLine("Введите элементы массива...");
            for (var i = 0; i < size; i++) numbers.Add(InputInt());

            return numbers;
        }

        private static List<int> RandomInput()
        {
            var leftBorder = -5000;
            var rightBorder = 5000;
            Console.WriteLine();
            var rnd = new Random();
            int size;
            Console.WriteLine("Введите размер массива:");
            size = InputInt();
            var numbers = new List<int>();
            for (var i = 0; i < size; i++) numbers.Add(rnd.Next(leftBorder, rightBorder));

            return numbers;
        }

        private static List<int> FileInput()
        {
            Console.WriteLine();
            var numbers = FileSystem.ReadInitialData();
            return numbers;
        }


        public static int InputInt()
        {
            int number;
            while (!int.TryParse(Console.ReadLine(), out number)) Console.WriteLine("Ошибка ввода! Введите число");

            return number;
        }

        private static int InputSize()
        {
            var isNumberCorrect = false;
            var size = InputInt();
            while (!isNumberCorrect)
                if (size <= 0)
                {
                    Console.WriteLine("Размер массива должен быть больше 0. Попробуйте еще раз");
                    size = InputInt();
                }
                else
                {
                    isNumberCorrect = true;
                }

            return size;
        }
    }
}