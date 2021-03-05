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
            Exit
        }

        /// <summary>
        /// Приветсвие/Помощь
        /// </summary>
        public static void Greatings()
        {
            Console.WriteLine("Эта программа находит среднее арифметическое введенного массива чисел по модулю \n" +
                              "Автор: Хлебников Роман \n" +
                              "Группа: 494 \n" +
                              "Лабораторная работа №1 \n" +
                              "Вариант 15 (5)");
        }

        /// <summary>
        /// Основное меню программы
        /// </summary>
        public static void Menu()
        {
            Console.WriteLine();
            Console.WriteLine("Выберите вариант:");
            Console.WriteLine("1. Ввести массив вручную");
            Console.WriteLine("2. Ввести массив из файла");
            Console.WriteLine("3. Ввести массив случайно");
            Console.WriteLine("4. Показать помощь");
            Console.WriteLine("5. Выход");
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
                case (int) MenuChoice.Exit:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Вы ввели неправильное значение, введите число от 1 до 6");
                    break;
            }
        }

        /// <summary>
        /// Записывает или не записывает ответ в зависимости от выбора пользователя
        /// </summary>
        /// <param name="data">Структура ArrayWithAverage с обработанными данными</param>
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

            if (variant == (int) SaveChoice.Yes)
            {
                FileSystem.OpenFileForWrite(answer);
            }
        }

        /// <summary>
        /// Записывает или не записывает исходные данные в зависимости от выбора пользователя
        /// </summary>
        /// <param name="data">Структура ArrayWithAverage с обработанными данными</param>
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
                var initialData = string.Join(" ", data.myArray);
                FileSystem.OpenFileForWrite(initialData);
            }
        }

        /// <summary>
        /// Создает строку с ответом для последующего вывода/сохранения
        /// </summary>
        /// <param name="data">Структура ArrayWithAverage с обработанными данными</param>
        /// <returns>Строка с ответом</returns>
        private static string MakeAnswer(ArrayWithAverage data)
        {
            Console.WriteLine();
            var answer = "Размер массива: " + data.myArray.Count + "\n";
            answer += "Введенный массив: " + "\n";
            answer += string.Join(" ", data.myArray);
            answer += "\n";
            answer += "Среднее значение по модулю: " + data.Average;
            return answer;
        }

        /// <summary>
        /// Функция для ввода данных с клавиатуры
        /// </summary>
        /// <returns>Список с числами для обработки</returns>
        private static List<int> KeyboardInput()
        {
            Console.WriteLine();
            Console.WriteLine("Введите размер массива:");
            var size = InputSize();
            var numbers = new List<int>();
            Console.WriteLine("Введите элементы массива...");
            for (var i = 0; i < size; i++) numbers.Add(InputInt());

            return numbers;
        }

        /// <summary>
        /// Функция для ввода случайных данных
        /// </summary>
        /// <returns>Список с числами для обработки</returns>
        private static List<int> RandomInput()
        {
            var leftBorder = -5000;
            var rightBorder = 5000;
            Console.WriteLine();
            var rnd = new Random();
            Console.WriteLine("Введите размер массива:");
            var size = InputInt();
            var numbers = new List<int>();
            for (var i = 0; i < size; i++) numbers.Add(rnd.Next(leftBorder, rightBorder));

            return numbers;
        }

        /// <summary>
        /// Функция для ввода данных из файла
        /// </summary>
        /// <returns>Список с числами для обработки</returns>
        private static List<int> FileInput()
        {
            Console.WriteLine();
            var numbers = FileSystem.ReadInitialData();
            return numbers;
        }

        /// <summary>
        /// Функция для корректного ввода числа типа int
        /// </summary>
        /// <returns>Число int</returns>
        public static int InputInt()
        {
            int number;
            while (!int.TryParse(Console.ReadLine(), out number)) Console.WriteLine("Ошибка ввода! Введите число");

            return number;
        }

        /// <summary>
        /// Функция для корректного ввода размера массива
        /// </summary>
        /// <returns> Размер массива </returns>
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