using System;
using System.Collections.Generic;
using System.Linq;

namespace laba1
{
    /// <summary>
    /// Структура содержащая массив, и его среднее значение
    /// </summary>
    public struct ArrayWithAverage
    {
        // спросить о гетерах и сетерах
        private const int Precision = 5;

        private List<int> Array;

        public List<int> myArray
        {
            get { return new List<int>(Array); }
        }

        public double Average;

        public ArrayWithAverage(double average, List<int> array)
        {
            this.Average = Math.Round(average,Precision);
            this.Array = array;
        }

 
    }

    /// <summary>
    /// Класс содеражащий алгоритм программы
    /// </summary>
    public static class Algorithm
    {
        /// <summary>
        /// Функция расчитывающая среднее значение массива по модулю
        /// </summary>
        /// <returns>Объект ArrayWithAverage</returns>
        /// <param name="numbers"> Список с числами int </param>
        /// <returns></returns>
        public static ArrayWithAverage GetAverage(List<int> numbers)
        {
            
            if (numbers.Count <= 0) // на всякий случай
            {

                 throw new Exception();

            }
            
            int sum = 0;
            foreach (var variable in numbers)
            {
                sum += Math.Abs(variable);
            }

            double average = sum * 1.0 / numbers.Count;
            ArrayWithAverage arrayWithAverage = new ArrayWithAverage(average, numbers);
            return arrayWithAverage;
            /* алгоритм при работе с большими числами, но при маленьких дает не очень точные результаты
            double average, n;
            int k;

            // вычисление среднего арифметического происходит по этому алгоритму, так как выяснилось, что при слишком больших значениях происходит перепеполнение переменной
            average = (Math.Abs(numbers[0]) + Math.Abs(numbers[1])) / 2;
            for (int i = 0; i < numbers.Count-2; i++)
            {
                k = i + 2; // индекс элемента с которым работает программа в данный момент
                n = (k * average + Math.Abs(numbers[i + 2])) / ((k + 1) * average); // коэфициент показывающий насколько новое среднее отличается от старого
                average = average * n;
            }
            ArrayWithAverage arrayWithAverage = new ArrayWithAverage(average, numbers);
            return arrayWithAverage;*/
        }
    }
}
