    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    namespace laba1
    {
        internal static class FileSystem
        {
            
            private enum Saving
            {
                Rewrite = 1,
                CreateNewFile = 2
            }

            /// <summary>
            /// Вспомогательное меню, воявляющееся при бнаружении уже существующего файла
            /// </summary>
            /// <returns>Ответ, создавать файл или нет</returns>
            private static int AdditionalMenu()
            {
                Console.WriteLine();
                Console.WriteLine("Выберите вариант:");
                Console.WriteLine("1. Перезаписать файл.");
                Console.WriteLine("2. Создать новый файл.");
                var variant = Interface.InputInt();
                var variantIsCorrect = false;
                while (!variantIsCorrect)
                    if (variant >= (int) Saving.Rewrite && variant <= (int) Saving.CreateNewFile)
                    {
                        variantIsCorrect = true;
                    }
                    else
                    {
                        Console.WriteLine("Ввод некорректен, попробуйте снова:");
                        variant = Interface.InputInt();
                    }

                Console.WriteLine();
                return variant;
            }
            
            /// <summary>
            /// Меню для записи текста в файл
            /// </summary>
            /// <param name="text">Текст для записи</param>
            public static void OpenFileForWrite(string text)
            {
                Console.WriteLine();
                Console.WriteLine("Введите путь к файлу");
                var path = Console.ReadLine();
                if (File.Exists(path))
                {
                    Console.WriteLine("Файл уже существует.");
                    var variant = AdditionalMenu();
                    switch (variant)
                    {
                        case (int) Saving.CreateNewFile:
                            OpenFileForWrite(text);
                            break;
                        case (int) Saving.Rewrite:
                            PrintTextInFile(path, text);
                            break;
                    }
                }
                else
                {
                    PrintTextInFile(path, text);
                }
            
            }

            /// <summary>
            /// Записывает текст в файл
            /// </summary>
            /// <param name="path">Путь к файлу</param>
            /// <param name="text">Текст для записи</param>
            private static void PrintTextInFile(string path, string text)
            {
                try
                {
                    var fileWriter = new StreamWriter(path);
                    fileWriter.WriteLine(text);
                    fileWriter.Close();
                    Console.WriteLine("Данные записаны");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Недопустимое имя файла. Попробуйте снова");
                    OpenFileForWrite(text);
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("Файл имеет атрибут \"Только для чтения\"");
                    OpenFileForWrite(text);
                }
            }

            /// <summary>
            /// Читает начальные данные из файла
            /// </summary>
            /// <returns>Список с числами </returns>
            public static List<int> ReadInitialData()
            {
                Console.WriteLine("Введите путь к файлу");
                var path = Console.ReadLine();
                while (true)
                    try
                    {
                        string[] stringSeparators = {"\r", "\n", " ", "\t"};
                        var numbers = File.ReadAllText(path)
                            .Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries) // разбиваем строку по указанным символам
                            .Select(n => int.Parse(n)) // преобразуем элементы в int
                            .ToList(); // преобразуем результат в список
                        if (numbers.Count == 0)
                        {
                            Console.WriteLine("В фале не найдено чисел, попробуйте снова...");
                            Console.WriteLine("Введите путь к файлу");
                            path = Console.ReadLine();
                        }
                        else
                        {
                            return numbers;
                        }
                    }
                    catch (FileNotFoundException)
                    {
                        Console.WriteLine("Файл не найден, попробуйте снова...");
                        Console.WriteLine("Введите путь к файлу");
                        path = Console.ReadLine();
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("В файле найдены неверные данные. Файл должен содержать только числа");
                        Console.WriteLine("Введите путь к файлу");
                        path = Console.ReadLine();
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Файл содержит слишком большое число");
                        Console.WriteLine("Введите путь к файлу");
                        path = Console.ReadLine();
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("Вы ввели пустое имя файла");
                        Console.WriteLine("Введите путь к файлу");
                        path = Console.ReadLine();
                    }
                    catch (DirectoryNotFoundException)
                    {
                        Console.WriteLine("Некорректное имя директории");
                        Console.WriteLine("Введите путь к файлу");
                        path = Console.ReadLine();
                    }
                    catch (UnauthorizedAccessException)
                    {
                        Console.WriteLine("У вас нет доступа к этой директории");
                        Console.WriteLine("Введите путь к файлу");
                        path = Console.ReadLine();
                    }
                    catch (IOException)
                    {
                        Console.WriteLine("Некорректное имя сетевого пути");
                        Console.WriteLine("Введите путь к файлу");
                        path = Console.ReadLine();
                    }
            }
        }
    }